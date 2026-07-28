
Imports System.Data.SqlClient
Imports System.Windows.Forms






Public Class Fr_GestionarVacunas


    Property Editar As Boolean = True
    Property IdPersona As Integer
    Property Nombre As String = ""
    Property identificacion As String = ""
    Property Guardado As Boolean = False
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter

    Private dtVacunaCopy As DataTable
    Public dtVacunaPersona As DataTable
    Public idconcepto As Integer = 0
    Public ModuloRegistro As String
    Public contRegIni As Integer
    Private Fila_Editar_Persona As DataRow
    Private bddatos As New FuncionesBase.ClaseCargarMaestras

    Public Sub Cargar_Tablas()
        Dim dsCargar As New DataSet

        Lb_Nombre.Text = Nombre
        Lb_Identificacion.Text = identificacion

        dsCargar = bddatos.CargarMaestras(1, VariablesBase.VariablesBase.IdBaseSiscontrolActual, IdPersona, IIf(IdPersona = -1, 1, 2))
        Cu_Vacuna1.AutoSize = True

        Me.Cu_Vacuna1.ModuloRegistro = "HSE"
        Me.Cu_Vacuna1.IdPersona = IdPersona
        Me.Cu_Vacuna1.dtVacunaPersona = dsCargar.Tables(20)
        Me.Cu_Vacuna1.contRegIni = dsCargar.Tables(20).Rows.Count
    End Sub


    Private Sub Guardar()

        If Cu_Vacuna1.dtVacunaPersona.Rows.Count > 0 Then
            dtVacunaCopy = Cu_Vacuna1.dtVacunaPersona.Copy

            Dim contVacuna As Integer = 0
            'For i As Integer = 0 To dtVacunaCopy.Rows.Count - 1
            '    If dtVacunaCopy.Rows(i).Item("IDVACUNA") = 1 And dtVacunaCopy.Rows(i).Item("ACTIVA") = "S" Then
            '        contVacuna += 1
            '    ElseIf dtVacunaCopy.Rows(i).Item("IDVACUNA") = 2 And dtVacunaCopy.Rows(i).Item("ACTIVA") = "S" Then
            '        contVacuna += 1
            '    Else
            '    End If
            'Next
            If contVacuna >= 0 Then
                Dim Comando As New SqlClient.SqlCommand("dbo.GestionarVacuna")
                Comando.CommandType = CommandType.StoredProcedure
                Comando.Parameters.Add("@TIPO", SqlDbType.TinyInt)
                Comando.Parameters("@TIPO").Value = 2
                Cu_Vacuna1.dtVacunaPersona.AcceptChanges()
                dtVacunaCopy = Cu_Vacuna1.dtVacunaPersona.Copy
                dtVacunaCopy.Columns.Remove("NOMPERSONAREGISTRO")
                dtVacunaCopy.Columns.Remove("IDPADRE")
                For i As Integer = 0 To dtVacunaCopy.Rows.Count - 1
                    If dtVacunaCopy.Rows(i).Item("MODULOCREACION").ToString = "CONTRATO" Or dtVacunaCopy.Rows(i).Item("MODULOCREACION").ToString = "C" Then
                        dtVacunaCopy.Rows(i).Item("MODULOCREACION") = "C"
                    Else
                        dtVacunaCopy.Rows(i).Item("MODULOCREACION") = "H"
                    End If
                Next
                dtVacunaCopy.AcceptChanges()
                Cu_Vacuna1.EsconderFilas()
                Comando.Parameters.AddWithValue("@TIP_VACUNAXPERSONA", dtVacunaCopy)
                Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                msgParam.Direction = ParameterDirection.Output
                Comando.Parameters.Add(msgParam)
                Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                Comando.Connection = conn
                Try
                    conn.Open()
                    Comando.ExecuteNonQuery()
                    conn.Close()
                    Select Case Comando.Parameters("@IDMENSAJE").Value
                        Case 0
                            MessageBox.Show("No se pudo realizar la operación.", "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        Case 1
                            MessageBox.Show("El registro ha sido exitoso.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                            Exit Sub
                    End Select
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    conn.Close()
                End Try
            Else
                MsgBox("Registro de vacunacion incompleto.", MsgBoxStyle.Critical, "Vacunas")
                Exit Sub
            End If
        Else
            MsgBox("No se han registrado vacunas.", MsgBoxStyle.Critical, "Vacunas")

            Exit Sub
        End If
    End Sub



    Private Sub Bt_Aceptar_Click_1(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        Guardar()
    End Sub

    Private Sub Bt_Cancelar_Click_1(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        If Editar Then
            Close()
        Else
            Close()
        End If
    End Sub
End Class