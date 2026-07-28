Imports System.Data.SqlClient

Public Class Fr_BoletaSalida

    Dim DsBoletaSalida As New DatosSisControl.Ds_Siscontrol
    'Dim sc_DependenciaTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_DEPENDENCIATableAdapter

    Public IdBoletaSalida As Integer = -1
    Private Tipo As Integer = 1
    Public Editando As Boolean = False
    Private Año As String = Date.Now.Year.ToString
    Private bddatos As New FuncionesBase.ClaseCargarMaestras

    Dim dsCargar As New DataSet
    Public Sub CargarDatos()

        dsCargar = bddatos.CargarMaestrasSiscontrol(10, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, IdBoletaSalida, 1)

        'Me.sc_DependenciaTableAdapter.Fill(DsBoletaSalida.SC_DEPENDENCIA, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        'Me.Cb_Dependencia.DataSource = Me.DsBoletaSalida.SC_DEPENDENCIA
        Me.Cb_Dependencia.DataSource = Me.dsCargar.Tables(0)
        Me.Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
        Me.Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
        Me.Cb_Dependencia.SelectedValue = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        Me.Cb_TipoDiligencia.SelectedIndex = 1
        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual

        Cu_Trabajador.CargarDatos()
        Cu_BuscarPersonaJefedepartamento.CargarDatos()
        Cu_BuscarPersonaJefeAdministrativo.CargarDatos()

        ' Dtp_HoraLlegada.Value = "1900-01-01 00:00:00.000"
        'Dtp_HoraSalida.Value = "1900-01-01 00:00:00.000"
        Dtp_HoraLlegadaVigilante.Value = "1900-01-01 00:00:00.000"
        Dtp_HoraSalidaVigilante.Value = "1900-01-01 00:00:00.000"

        If Editando Then
            Cu_BuscarPersonaVigilanteEntrada.CargarDatos()
            Cu_BuscarPersonaVigilanteSalida.CargarDatos()

            Tipo = 2

            'Dim sc_BoletaSalidaTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_BOLETASALIDATableAdapter
            'sc_BoletaSalidaTableAdapter.FillIdBoletaSalida(DsBoletaSalida.SC_BOLETASALIDA, IdBoletaSalida, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            Dim fila As DataRow
            'If DsBoletaSalida.SC_BOLETASALIDA.Count > 0 Then
            '    fila = DsBoletaSalida.SC_BOLETASALIDA.Rows(0)
            If dsCargar.Tables(1).Rows.Count > 0 Then
                fila = dsCargar.Tables(1).Rows(0)
                IdBoletaSalida = fila("Id")
                Cu_Trabajador.Cb_Persona.SelectedValue = fila("IDPERSONASOLICITA")
                Cb_Dependencia.SelectedValue = fila("IDDEPENDENCIA")
                Dtp_Fecha.Value = fila("FECHA")

                Dim horasalida As Date = fila("HORASALIDA")
                If horasalida.Hour > 12 Then
                    Cb_HoraSalida.SelectedIndex = horasalida.Hour - 13
                    Cb_horarioSalida.SelectedIndex = 1
                Else
                    Cb_HoraSalida.SelectedIndex = horasalida.Hour - 1
                    Cb_horarioSalida.SelectedIndex = 0

                End If
                Cb_minSalida.SelectedItem = horasalida.Minute

                Select Case horasalida.Minute
                    Case 0
                        Cb_minSalida.SelectedIndex = 0
                    Case 5
                        Cb_minSalida.SelectedIndex = 1
                    Case 10
                        Cb_minSalida.SelectedIndex = 2
                    Case 15
                        Cb_minSalida.SelectedIndex = 3
                    Case 20
                        Cb_minSalida.SelectedIndex = 4
                    Case 25
                        Cb_minSalida.SelectedIndex = 5
                    Case 30
                        Cb_minSalida.SelectedIndex = 6
                    Case 35
                        Cb_minSalida.SelectedIndex = 7
                    Case 40
                        Cb_minSalida.SelectedIndex = 8
                    Case 45
                        Cb_minSalida.SelectedIndex = 9
                    Case 50
                        Cb_minSalida.SelectedIndex = 10
                    Case 55
                        Cb_minSalida.SelectedIndex = 11
                End Select

                If fila("HORAENTRADA") <> "1900-01-01 00:00:00.000" Then
                    Dim horallegada As Date = fila("HORAENTRADA")
                    If horallegada.Hour > 12 Then
                        Cb_HoraLlegada.SelectedIndex = horallegada.Hour - 13
                        Cb_HorarioLlegada.SelectedIndex = 1
                    Else
                        Cb_HoraLlegada.SelectedIndex = horallegada.Hour - 1
                        Cb_HorarioLlegada.SelectedIndex = 0
                    End If

                    Select Case horallegada.Minute
                        Case 0
                            Cb_MinLlegada.SelectedIndex = 0
                        Case 5
                            Cb_MinLlegada.SelectedIndex = 1
                        Case 10
                            Cb_MinLlegada.SelectedIndex = 2
                        Case 15
                            Cb_MinLlegada.SelectedIndex = 3
                        Case 20
                            Cb_MinLlegada.SelectedIndex = 4
                        Case 25
                            Cb_MinLlegada.SelectedIndex = 5
                        Case 30
                            Cb_MinLlegada.SelectedIndex = 6
                        Case 35
                            Cb_MinLlegada.SelectedIndex = 7
                        Case 40
                            Cb_MinLlegada.SelectedIndex = 8
                        Case 45
                            Cb_MinLlegada.SelectedIndex = 9
                        Case 50
                            Cb_MinLlegada.SelectedIndex = 10
                        Case 55
                            Cb_MinLlegada.SelectedIndex = 11
                    End Select
                End If
                'If fila("HORASALIDA") = "1900-01-01 00:00:00.000" Then
                '    Dtp_HoraSalida.Value = fila("HORASALIDA")
                '    Dtp_Fecha.Checked = False
                'Else
                '    Dtp_HoraSalida.Value = fila("HORASALIDA")
                '    Dtp_Fecha.Checked = True
                'End If

                'If fila("HORAENTRADA") = "1900-01-01 00:00:00.000" Then
                '    Dtp_HoraLlegada.Value = fila("HORAENTRADA")
                '    Dtp_HoraLlegada.Checked = False
                'Else
                '    Dtp_HoraLlegada.Value = fila("HORAENTRADA")
                '    Dtp_HoraLlegada.Checked = True
                'End If

                If fila("TIPODILIGENCIA") = "P" Then
                    Cb_TipoDiligencia.SelectedItem = "Personal"
                Else
                    Cb_TipoDiligencia.SelectedItem = "Laboral"
                End If

                Tx_Descripcion.Text = fila("DESCRIPCION")
                Cu_BuscarPersonaJefedepartamento.Cb_Persona.SelectedValue = fila("IDPERSONAJEFEDEPARTAMENTO")
                Cu_BuscarPersonaJefeAdministrativo.Cb_Persona.SelectedValue = fila("IDPERSONAJEFEADMINISTRATIVO")
                Cu_BuscarPersonaVigilanteSalida.Cb_Persona.SelectedValue = fila("IDPERSONAVIGILANTESALIDA")
                Dtp_HoraSalidaVigilante.Value = fila("HORASALIDAVIGILANTE")
                Cu_BuscarPersonaVigilanteEntrada.Cb_Persona.SelectedValue = fila("IDPERSONAVIGILANTEENTRADA")
                Dtp_HoraLlegadaVigilante.Value = fila("HORAENTRADAVIGILANTE")
                Año = fila("AÑO")
            End If
        End If

        Cu_Trabajador.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "BS", "IDPERSONASOLICITA", -1)
        Cu_BuscarPersonaJefedepartamento.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "BS", "IDPERSONAJEFEDEPARTAMENTO", -1)
        Cu_BuscarPersonaJefeAdministrativo.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "BS", "IDPERSONAJEFEADMINISTRATIVO", -1)

    End Sub

    Private Sub GuardarBoletaSalida()

        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarBoletaSalida")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TIPO", Tipo)

        Comando.Parameters.AddWithValue("@IDBOLETASALIDA", IdBoletaSalida)
        Comando.Parameters.AddWithValue("@IDPERSONASOLICITA", Cu_Trabajador.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDDEPENDENCIA", Cb_Dependencia.SelectedValue)
        Comando.Parameters.AddWithValue("@FECHA", Dtp_Fecha.Value)

        If Cb_HoraSalida.SelectedItem <> "" Then
            Dim HoraSalida As Integer
            If Cb_horarioSalida.SelectedIndex = 0 Then
                HoraSalida = Cb_HoraSalida.SelectedItem
            Else
                HoraSalida = Cb_HoraSalida.SelectedItem + 12
            End If
            Comando.Parameters.AddWithValue("@HORASALIDA", CStr(HoraSalida) + ":" + Cb_minSalida.SelectedItem.ToString + ":00.0")
        Else
            Comando.Parameters.AddWithValue("@HORASALIDA", 0)
        End If

        If Cb_HoraLlegada.SelectedItem <> "" Then
            Dim Horallegada As Integer
            If Cb_HoraLlegada.SelectedIndex = 0 Then
                Horallegada = Cb_HoraLlegada.SelectedItem
            Else
                Horallegada = Cb_HoraLlegada.SelectedItem + 12
            End If

            Comando.Parameters.AddWithValue("@HORAENTRADA", CStr(Horallegada) + ":" + Cb_MinLlegada.SelectedItem.ToString + ":00.0")
        Else
            Comando.Parameters.AddWithValue("@HORAENTRADA", 0)
        End If


        If Cb_TipoDiligencia.SelectedItem = "Personal" Then
            Comando.Parameters.AddWithValue("@TIPODILIGENCIA", "P")
        Else 'Laboral
            Comando.Parameters.AddWithValue("@TIPODILIGENCIA", "L")
        End If
        Comando.Parameters.AddWithValue("@DESCRIPCION", UCase(Trim(Tx_Descripcion.Text)))
        Comando.Parameters.AddWithValue("@IDPERSONAJEFEDEPARTAMENTO", Cu_BuscarPersonaJefedepartamento.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAJEFEADMINISTRATIVO", Cu_BuscarPersonaJefeAdministrativo.Cb_Persona.SelectedValue)
        If IsNothing(Cu_BuscarPersonaVigilanteSalida.Cb_Persona.SelectedValue) Then
            Comando.Parameters.AddWithValue("@IDPERSONAVIGILANTESALIDA", -1)
            Comando.Parameters.AddWithValue("@HORASALIDAVIGILANTE", 0)
        Else
            Comando.Parameters.AddWithValue("@IDPERSONAVIGILANTESALIDA", Cu_BuscarPersonaVigilanteSalida.Cb_Persona.SelectedValue)
            Comando.Parameters.AddWithValue("@HORASALIDAVIGILANTE", Dtp_HoraSalidaVigilante.Value)
        End If

        If IsNothing(Cu_BuscarPersonaVigilanteEntrada.Cb_Persona.SelectedValue) Then
            Comando.Parameters.AddWithValue("@IDPERSONAVIGILANTEENTRADA", -1)
            Comando.Parameters.AddWithValue("@HORAENTRADAVIGILANTE", 0)
        Else
            Comando.Parameters.AddWithValue("@IDPERSONAVIGILANTEENTRADA", Cu_BuscarPersonaVigilanteEntrada.Cb_Persona.SelectedValue)
            Comando.Parameters.AddWithValue("@HORAENTRADAVIGILANTE", Dtp_HoraLlegadaVigilante.Value)
        End If

        Comando.Parameters.AddWithValue("@IMPRESA", "N")
        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAREGISTRO", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAMODIFICO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAMODIFICO", Date.Now)
        Comando.Parameters.AddWithValue("@AÑO", Año)
        Comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)

        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        conn.Close()

        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "BS", "IDPERSONASOLICITA", Cu_Trabajador.Cb_Persona.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "BS", "IDPERSONAJEFEDEPARTAMENTO", Cu_BuscarPersonaJefedepartamento.Cb_Persona.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "BS", "IDPERSONAJEFEADMINISTRATIVO", Cu_BuscarPersonaJefeAdministrativo.Cb_Persona.SelectedValue)

        If MsgBox("¿Desea imprimir la Boleta de Salida", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
            Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
            Dim Array As New ArrayList
            Array.Add(74)
            climpresiones.IdBOLETASALIDA = msgParam.Value
            climpresiones.FormatoImprimirSisControl(Array, True, False)
            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
        End If
        Me.Close()

    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If ValidarBoletaSalida() Then
            GuardarBoletaSalida()
        End If

    End Sub

    Private Function ValidarBoletaSalida() As Boolean

        If Trim(Tx_Descripcion.Text) = "" Then
            MsgBox("Debe Agregar la descripción por la cual se va ausentar", MsgBoxStyle.Critical, "DESCRIPCIÓN")
            Me.Tx_Descripcion.Focus()
            ValidarBoletaSalida = False
            Exit Function
        End If

        If Cb_HoraSalida.SelectedItem = "" Then
            MsgBox("Debe ingresar la hora de salida", MsgBoxStyle.Critical, "DESCRIPCIÓN")
            Me.Tx_Descripcion.Focus()
            ValidarBoletaSalida = False
            Exit Function
        End If

        Return True
    End Function

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub


    Private Sub Cb_HoraSalida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_HoraSalida.SelectedIndexChanged
        Cb_minSalida.SelectedIndex = 0
        Cb_horarioSalida.SelectedIndex = 0
    End Sub

    Private Sub Cb_HoraLlegada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_HoraLlegada.SelectedIndexChanged
        Cb_MinLlegada.SelectedIndex = 0
        Cb_HorarioLlegada.SelectedIndex = 0
    End Sub
End Class