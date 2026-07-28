Imports System.Data.SqlClient

Public Class Fr_AsociarPersonaBodega

    Public Respuesta As Boolean = False
    Public IDPERSONA As Integer
    Public CrearUsuario As Boolean = False
    Public TipoAsociacion As String = "BOD"
    Public TipoBúsqueda As String = "P"


    Private Sub Btn_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Aceptar.Click
        If Trim(Me.Tx_Identificación.Text) = "" Then
            MsgBox("Dede digitar una identificación valida", MsgBoxStyle.Critical, "Identificación valida")
        Else
            If IsNumeric(Me.Tx_Identificación.Text) = False Then
                MsgBox("Dede digitar una identificación valida", MsgBoxStyle.Critical, "Identificación valida")
            Else
                Dim SqlComando As String = ""
                Dim Pertenece As String = ""

                Select Case TipoAsociacion
                    Case "DEP"
                        SqlComando = "dbo.AsociarPersonaDependencia"
                        Pertenece = "@IDDEPENDENCIA"
                    Case "BOD"
                        SqlComando = "dbo.AsociarPersonaBodega"
                        Pertenece = "@IDBODEGA"
                    Case "BASE"
                        SqlComando = "dbo.AsociarPersonaBase"
                        Pertenece = "@IDBASE"
                End Select

                Dim Comando As New SqlClient.SqlCommand(SqlComando)
                Comando.CommandType = CommandType.StoredProcedure


                Select Case TipoAsociacion
                    Case "DEP"
                        Comando.Parameters.AddWithValue(Pertenece, VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
                    Case "BOD"
                        Comando.Parameters.AddWithValue(Pertenece, VariablesBase.VariablesBase.IdBodegaActual)
                    Case "BASE"
                        Comando.Parameters.AddWithValue(Pertenece, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
                End Select
                Comando.Parameters.AddWithValue("@IDENTIFICACION", Trim(Me.Tx_Identificación.Text))
                If CrearUsuario = True Then
                    Comando.Parameters.AddWithValue("@CREARUSUARIO", 1)
                Else
                    Comando.Parameters.AddWithValue("@CREARUSUARIO", 0)
                End If
                Comando.Parameters.AddWithValue("@IDUSUARIOMODIFICA", VariablesBase.VariablesBase.IdPersona)
                Dim msgParam As New SqlParameter("@MENSAJE", SqlDbType.Int, 1)
                msgParam.Direction = ParameterDirection.Output
                Comando.Parameters.Add(msgParam)
                Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                conn.Open()
                Comando.Connection = conn
                Comando.ExecuteNonQuery()
                conn.Close()
                Me.Close()
                Select Case Comando.Parameters("@MENSAJE").Value
                    Case Is > 0
                        MsgBox("Se realizo la asociación correctamente", MsgBoxStyle.Information, "ASOCIACION")
                        Respuesta = True
                        IDPERSONA = Comando.Parameters("@MENSAJE").Value
                        Me.Close()
                    Case -2
                        MsgBox("Esta persona no esta registrada en el sistema", MsgBoxStyle.Information, "ASOCIACION")
                        Respuesta = False
                    Case -1

                        Select Case TipoAsociacion
                            Case "DEP"
                                MsgBox("Esta persona ya esta asociada a la dependencia actual", MsgBoxStyle.Information, "ASOCIACION")
                            Case "BOD"
                                MsgBox("Esta persona ya esta asociada a la bodega actual", MsgBoxStyle.Information, "ASOCIACION")
                            Case "BASE"
                                MsgBox("Esta persona ya esta asociada a la base actual", MsgBoxStyle.Information, "ASOCIACION")
                        End Select



                        Respuesta = False
                        Me.Close()
                End Select
            End If
            End If
    End Sub

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click
        Respuesta = False
        Me.Close()
    End Sub

    Private Sub Bt_BuscarPersona_Click(sender As System.Object, e As System.EventArgs) Handles Bt_BuscarPersona.Click
        Dim FrBuscarPersona As New Fr_BuscarPersona

        ' FrBuscarPersona._Tipo = "P"
        'FrBuscarPersona.Cargar_Tabla("P")
        FrBuscarPersona._Tipo = TipoBúsqueda
        FrBuscarPersona.Cargar_Tabla(TipoBúsqueda)

        FrBuscarPersona.ShowDialog()
        Me.Tx_Identificación.Text = FrBuscarPersona.Identificacion
    End Sub

    Private Sub Tx_Identificación_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Tx_Identificación.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

End Class