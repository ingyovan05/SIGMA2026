Imports System.Data.SqlClient

Public Class Fr_OpcionesImpresión

    Public Tipo As Integer '0 - Orden de compra
    Public ID As Integer
    Public IdSalida As Integer
    Public TipoRemision As String
    Private bddatos As New FuncionesBase.ClaseCargarMaestras

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub


    Public Sub cargar()
        Dim dsCargar As New DataSet
        dsCargar = bddatos.CargarMaestrasSiscontrol(4, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, 1, 1)

        Me.Cb_Empresa.DataSource = dsCargar.Tables(1)
        Me.Cb_Empresa.DisplayMember = "NOMBRE"
        Me.Cb_Empresa.ValueMember = "IDTRASPORTADORA"
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        If Me.Ck_Impresión1.Checked = False And
            Me.Ck_Impresión2.Checked = False And
            Me.Ck_Impresión3.Checked = False And
            Me.Ck_Impresión4.Checked = False And
            Me.Ck_Impresión5.Checked = False And
            Me.Ck_Impresión6.Checked = False And
            Me.Ck_Impresión7.Checked = False And
            Me.Ck_Impresión8.Checked = False And
            Me.Ck_Impresión9.Checked = False And
            Me.Ck_Sobre.Checked = False Then
            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
            Me.Close()
            Exit Sub
        End If

        Select Case Tipo
            Case 0 'Orden de compra
                Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                Dim Array As New ArrayList
                Array.Add(62)
                climpresiones.IDORDENDECOMPRA = ID
                If Me.Ck_Impresión1.Checked = True Then
                    climpresiones.copiaparacontabilidad1 = True
                End If
                climpresiones.copiaparacontabilidad2 = False
                climpresiones.copiaparaconsecutivo = False
                If Me.Ck_Impresión2.Checked = True Then
                    climpresiones.copiaparafolderpedido = True
                End If
                climpresiones.FormatoImprimirMateriales(Array, True, False)
            Case 1 'Remisión
                Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                Dim Array As New ArrayList
                Array.Add(67)
                climpresiones.IDREMISIONIMPRESION = ID
                If Me.Ck_Impresión1.Checked = True Then
                    climpresiones.copiaparadestinatario = True
                End If
                If Me.Ck_Impresión2.Checked = True Then
                    climpresiones.copiaparatransportador = True
                End If
                If Me.Ck_Impresión3.Checked = True Then
                    climpresiones.copiaparaconsecutivo = True
                End If
                If Me.Ck_Impresión4.Checked = True Then
                    climpresiones.copiaparaporteriasalida = True
                End If
                If Me.Ck_MediaCarta.Checked = True Then
                    climpresiones.MediaCarta2 = True
                End If
                climpresiones.FormatoImprimirMateriales(Array, True, False)
            Case 2
                Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                Dim Array As New ArrayList
                Array.Add(70)
                climpresiones.IDMANTENIMIENTOEXTERNO = ID
                If Me.Ck_Impresión1.Checked = True Then
                    climpresiones.copiaparadestinatario = True
                End If
                If Me.Ck_Impresión2.Checked = True Then
                    climpresiones.copiaparatransportador = True
                End If
                If Me.Ck_Impresión3.Checked = True Then
                    climpresiones.copiaparaconsecutivo = True
                End If
                If Me.Ck_Impresión4.Checked = True Then
                    climpresiones.copiaparaporteriasalida = True
                End If
                climpresiones.FormatoImprimirMateriales(Array, True, False)
            Case 3 'Remisión Valorizada
                Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                Dim Array As New ArrayList
                Array.Add(73)
                climpresiones.IDREMISIONIMPRESION = ID
                If Me.Ck_Impresión1.Checked = True Then
                    climpresiones.copiaparadestinatario = True
                End If
                If Me.Ck_Impresión2.Checked = True Then
                    climpresiones.copiaparatransportador = True
                End If
                If Me.Ck_Impresión3.Checked = True Then
                    climpresiones.copiaparaconsecutivo = True
                End If
                If Me.Ck_Impresión4.Checked = True Then
                    climpresiones.copiaparaporteriasalida = True
                End If
                If Me.Ck_MediaCarta.Checked = True Then
                    climpresiones.MediaCarta2 = True
                End If
                climpresiones.FormatoImprimirMateriales(Array, True, False)
            Case 4 'Solicitud de Maquinaria y Equipo
                Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                Dim Array As New ArrayList
                Array.Add(74)
                climpresiones.IdSolicitudMaquinaria = ID
                If Me.Ck_Impresión1.Checked = True Then
                    climpresiones.copiaparaDeptoMaquinariayEquipo = True
                End If
                If Me.Ck_Impresión2.Checked = True Then
                    climpresiones.copiaparaEquipoCapital = False
                End If
                If Me.Ck_Impresión3.Checked = True Then
                    climpresiones.copiaparaTransportes = False
                End If
                climpresiones.FormatoImprimirMateriales(Array, True, False)
            Case 5 ' Impresion combinada de Remision normal, valorizada y sobre


                Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                Dim Array As New ArrayList
                climpresiones.IDREMISIONIMPRESION = ID

                If Ck_MediaCarta.Checked = True Then

                    If Me.Ck_Impresión1.Checked = True Then
                        climpresiones.copiaparadestinatario = True
                    End If
                    If Me.Ck_Impresión2.Checked = True Then
                        climpresiones.copiaparatransportador = True
                    End If
                    If Me.Ck_Impresión3.Checked = True Then
                        climpresiones.copiaparaconsecutivo = True
                    End If
                    If Me.Ck_Impresión4.Checked = True Then
                        climpresiones.copiaparaporteriasalida = True
                    End If
                    If Me.Ck_MediaCarta.Checked = True Then
                        climpresiones.MediaCarta2 = True
                    End If
                    If Me.Ck_Impresión6.Checked = True Then
                        climpresiones.copiaparadestinatarioR = True
                    End If
                    If Me.Ck_Impresión7.Checked = True Then
                        climpresiones.copiaparatransportadorR = True
                    End If
                    If Me.Ck_Impresión8.Checked = True Then
                        climpresiones.copiaparaconsecutivoR = True
                    End If
                    If Me.Ck_Impresión9.Checked = True Then
                        climpresiones.copiaparaporteriasalidaR = True
                    End If

                    climpresiones.ImpresionCompartida = True
                    If Ck_Impresión1.Checked = True Or Ck_Impresión2.Checked = True Or Ck_Impresión3.Checked = True Or Ck_Impresión4.Checked = True Or Ck_Impresión6.Checked = True Or Ck_Impresión7.Checked = True Or Ck_Impresión8.Checked = True Or Ck_Impresión9.Checked = True Then

                        Array.Add(78) 'Impresion media carta combinada
                        climpresiones.FormatoImprimirMateriales(Array, Ck_VistaPrevia.Checked, False)
                    End If
                Else

                    If Me.Ck_Impresión1.Checked = True Then
                        climpresiones.copiaparadestinatario = True
                    End If
                    If Me.Ck_Impresión2.Checked = True Then
                        climpresiones.copiaparatransportador = True
                    End If
                    If Me.Ck_Impresión3.Checked = True Then
                        climpresiones.copiaparaconsecutivo = True
                    End If
                    If Me.Ck_Impresión4.Checked = True Then
                        climpresiones.copiaparaporteriasalida = True
                    End If

                    If Ck_Impresión1.Checked = True Or Ck_Impresión2.Checked = True Or Ck_Impresión3.Checked = True Or Ck_Impresión4.Checked = True Then
                        Array.Add(67)
                        climpresiones.FormatoImprimirMateriales(Array, Ck_VistaPrevia.Checked, False)
                    End If

                    Array.Clear()

                    Dim climpresiones1 As New ImpresiónMateriales.Cl_Impresión
                    climpresiones1.IDREMISIONIMPRESION = ID
                    If Me.Ck_Impresión6.Checked = True Then
                        climpresiones1.copiaparadestinatario = True
                    End If
                    If Me.Ck_Impresión7.Checked = True Then
                        climpresiones1.copiaparatransportador = True
                    End If
                    If Me.Ck_Impresión8.Checked = True Then
                        climpresiones1.copiaparaconsecutivo = True
                    End If
                    If Me.Ck_Impresión9.Checked = True Then
                        climpresiones1.copiaparaporteriasalida = True
                    End If
                    If Ck_Impresión6.Checked = True Or Ck_Impresión7.Checked = True Or Ck_Impresión8.Checked = True Or Ck_Impresión9.Checked = True Then
                        Array.Add(73)
                        climpresiones1.FormatoImprimirMateriales(Array, Ck_VistaPrevia.Checked, False)
                    End If
                    Array.Clear()

                End If
                Array.Clear()

                If Ck_Sobre.Checked = True Then

                    Dim Comando1 As New SqlClient.SqlCommand("dbo.GestionarSobres")
                    Comando1.CommandType = CommandType.StoredProcedure


                    Comando1.Parameters.AddWithValue("@TIPO", 4)
                    Comando1.Parameters.AddWithValue("@IDSOBRE", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@AÑO", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@CONSECUTIVO", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@FECHASOBRE", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@ENTIDAD", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@IDDEPENDENCIADE", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
                    Comando1.Parameters.AddWithValue("@IDPERSONADE", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@PERSONAPARA", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@DESCRIPCION", Tb_Descripcion.Text)
                    Comando1.Parameters.AddWithValue("@IDEMPRESATRANSPORTADORA", Cb_Empresa.SelectedValue)
                    Comando1.Parameters.AddWithValue("@GUIA", Tb_Guia.Text)
                    Comando1.Parameters.AddWithValue("@FECHADESPACHO", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@FECHAPLANILLA", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@IDPERSONAFIRMA", SqlDbType.Int).Value = IdSalida
                    Comando1.Parameters.AddWithValue("@FECHAREGISTRO", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
                    Comando1.Parameters.AddWithValue("@FECHAMODIFICACION", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)
                    Comando1.Parameters.AddWithValue("@FECHAANULACION", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@IDPERSONAANULA", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@ANULADA", "N")
                    Comando1.Parameters.AddWithValue("@IMPRESA", "N")
                    Comando1.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
                    Comando1.Parameters.AddWithValue("@IDCODIGOPOBLACIONPARA", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@DIRECCIONPARA", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@CARGODE", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@CARGOPARA", DBNull.Value)

                    Comando1.Parameters.AddWithValue("@IDCENTROCOSTO", DBNull.Value)

                    Comando1.Parameters.AddWithValue("@TELEFONO", DBNull.Value)

                    Dim msgParam2 As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                    msgParam2.Direction = ParameterDirection.Output
                    Comando1.Parameters.Add(msgParam2)
                    Dim conexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                    conexion.Open()
                    Comando1.Connection = conexion
                    Comando1.ExecuteNonQuery()

                    conexion.Close()
                    Me.Close()



                    Dim climpresion3 As New ImpresiónSisControl.Cl_Impresión
                    climpresion3.IdSOBRE = Comando1.Parameters("@IDMENSAJE").Value
                    Array.Add(71)
                    climpresion3.FormatoImprimirSisControl(Array, Ck_VistaPrevia.Checked, False)
                End If



        End Select
        MsgBox("Impresión finalizada.", MsgBoxStyle.Information, "FIN IMPRESION")
        Me.Close()
    End Sub


    'Private Sub Fr_OpcionesImpresión_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'End Sub

    'Private Sub Ck_Impresión1_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_Impresión1.CheckedChanged

    'End Sub
End Class