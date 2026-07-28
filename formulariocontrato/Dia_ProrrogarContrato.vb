Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Dia_ProrrogarContrato
    Property IdPersona As Integer
    Property IdContrato As Integer
    Property FechaInicioProrroga As Date
    Property Nombre As String
    Property CodigoContrato As String
    Property Duracion As Integer = 0
    Property TipoDuracion As String = ""
    Property Guardado As Boolean
        Get
            Return _guardado
        End Get
        Private Set(value As Boolean)
            _guardado = value
        End Set
    End Property
    Private _guardado As Boolean = False
    Private _prorroga As String
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private dtProrrogas As DataTable
    Private ultimaProrroga As DataRow
    Private dtTipoDuracion As New DataTable
    Private Sub Dia_ProrrogarContrato_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarControles()
        ConsultarProrrogas()
        If Not IsDBNull(ultimaProrroga("CODIGOTIPODURACION")) AndAlso Not IsDBNull(ultimaProrroga("DURACION")) Then
            TipoDuracion = ultimaProrroga("CODIGOTIPODURACION")
            Duracion = ultimaProrroga("DURACION")
        Else
            MessageBox.Show("No se determinó la duración de la prórroga anterior. Se usarán los datos de duración del contrato inicial.", "No se encontró duración de prórroga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Select Case ultimaProrroga("CONSECUTIVOPRORROGA")
            Case 0
                _prorroga = ("PRIMERA")
            Case 1
                _prorroga = ("SEGUNDA")
            Case 2
                _prorroga = ("TERCERA")
            Case Else
                _prorroga = (ultimaProrroga("CONSECUTIVOPRORROGA") + 1) & "ª"
        End Select
        Lb_AvisoComplemento.Text = "" & _prorroga
        Lb_Aviso.Text = "Se registrará la                             prórroga con los siguientes parámetros:"
        Cb_TipoDuracion.SelectedValue = TipoDuracion
        If TipoDuracion = "D" Then 'La prórroga no debe pasar de Días a Meses.
            Cb_TipoDuracion.Enabled = False
        End If
        Nud_Duracion.Value = Duracion
        Nud_Duracion.Maximum = Duracion
        Tx_FechasAnterior.Text = ultimaProrroga("FECHAINICIO") & " - " & ultimaProrroga("FECHAFIN")
        Dtp_FechaInicio.Value = DirectCast(ultimaProrroga("FECHAFIN"), Date).AddDays(1)
        Dtp_FechaTerminacion.Value = FuncionesBase.FuncionesBase.Calcular_Fecha_terminación_Contrato(Dtp_FechaInicio.Value, Cb_TipoDuracion.SelectedValue, Nud_Duracion.Value)


        'Try
        '    Dim cantdias As Integer
        '    cantdias = DateDiff(DateInterval.Day, ultimaProrroga("FECHAINICIO"), DirectCast(ultimaProrroga("FECHAFIN"), Date).AddDays(1))
        '    If cantdias < 31 Then
        '        Dtp_FechaFirma.Value = Dtp_FechaInicio.Value.AddDays(-Math.Ceiling(cantdias / 2))
        '    ElseIf cantdias = 31 Or cantdias = 32 Then
        '        Dtp_FechaFirma.Value = Dtp_FechaInicio.Value.AddDays(-31)
        '    Else
        '        Dtp_FechaFirma.Value = Dtp_FechaInicio.Value.AddDays(-32)
        '    End If
        'Catch ex As Exception
        'End Try

        Try
            Dim cantdias As Integer
            cantdias = DateDiff(DateInterval.Day, ultimaProrroga("FECHAINICIO"), DirectCast(ultimaProrroga("FECHAFIN"), Date).AddDays(1))
            If cantdias < 32 Then
                Dtp_FechaFirma.Value = Dtp_FechaInicio.Value.AddDays(-Math.Ceiling(cantdias / 2))
            ElseIf cantdias = 32 Then
                Dtp_FechaFirma.Value = Dtp_FechaInicio.Value.AddDays(-31)
            Else
                Dtp_FechaFirma.Value = Dtp_FechaInicio.Value.AddDays(-32)
            End If
        Catch ex As Exception
        End Try

        Dtp_FechaFirma.MinDate = ultimaProrroga("FECHAINICIO")
        Dtp_FechaFirma.MaxDate = ultimaProrroga("FECHAFIN")
        Lb_NombreComplemento.Text = Nombre
        Lb_Nombre.Text = "Nombre: "
        Lb_Codigo.Text = "Código Contrato: " & CodigoContrato
        Dtp_FechaTerminacion.Value = FuncionesBase.FuncionesBase.Calcular_Fecha_terminación_Contrato(Dtp_FechaInicio.Value, Cb_TipoDuracion.SelectedValue, Nud_Duracion.Value)
    End Sub

    Private Sub CargarControles()
        dtTipoDuracion.Columns.Add("CODIGOTIPODURACION")
        dtTipoDuracion.Columns.Add("NOMBRETIPODURACION")
        dtTipoDuracion.Rows.Add("M", "Meses")
        dtTipoDuracion.Rows.Add("D", "Días")
        Cb_TipoDuracion.ValueMember = "CODIGOTIPODURACION"
        Cb_TipoDuracion.DisplayMember = "NOMBRETIPODURACION"
        Cb_TipoDuracion.DataSource = dtTipoDuracion
    End Sub

    Private Sub ConsultarProrrogas()
        comando = New SqlCommand("SELECT * FROM ListaProrrogasContrato(@IDCONTRATO) ORDER BY CONSECUTIVOPRORROGA DESC", conexion)
        comando.Parameters.AddWithValue("@IDCONTRATO", IdContrato)
        adaptador = New SqlDataAdapter(comando)
        dtProrrogas = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtProrrogas)
            conexion.Close()
            ultimaProrroga = dtProrrogas.Rows(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Cb_TipoDuración_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_TipoDuracion.SelectedIndexChanged
        If Not IsNothing(dtProrrogas) Then
            Dtp_FechaTerminacion.Value = FuncionesBase.FuncionesBase.Calcular_Fecha_terminación_Contrato(Dtp_FechaInicio.Value, Cb_TipoDuracion.SelectedValue, Nud_Duracion.Value)
            Dim tempDuracion As Integer = Nud_Duracion.Value
            If Cb_TipoDuracion.SelectedValue = "D" Then 'Calcular tiempo máximo de la prórroga que no exceda la anterior.
                Nud_Duracion.Maximum = Duracion * 30
                Nud_Duracion.Value = tempDuracion * 30
            Else
                Nud_Duracion.Maximum = Duracion
            End If
        End If
        'CalcularFechaFirma()
    End Sub

    Private Sub NUD_Días_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Nud_Duracion.ValueChanged
        Dtp_FechaTerminacion.Value = FuncionesBase.FuncionesBase.Calcular_Fecha_terminación_Contrato(Dtp_FechaInicio.Value, Cb_TipoDuracion.SelectedValue, Nud_Duracion.Value)
        'CalcularFechaFirma()

    End Sub



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ValidarProrroga() Then
            If MessageBox.Show("¿Desea registrar la " & _prorroga & " prórroga del contrato?", "PRORROGAR CONTRATO", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
                Guardar_Registro_Contrato()
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If
        Dim climpresion As New ImprimirRecursoHumano.Cl_Impresión
        Dim Array As New ArrayList
        climpresion.Idpersona = IdPersona
        climpresion.IdContrato = IdContrato
        climpresion.IdBase = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        If MessageBox.Show("¿Desea imprimir las prórrogas y la carta de terminación del contrato?", "PRÓRROGAS REGISTRADAS", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Array.Add(71)
            climpresion.FormatosImprimir(Array, True)
            Array.Clear()
        End If
        If MessageBox.Show("¿Desea imprimir el carné del empleado?", "PRÓRROGAS REGISTRADAS", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Array.Add(11)
            climpresion.FormatosImprimir(Array, True)
            Array.Clear()
        End If
        Close()
    End Sub

    Private Function ValidarProrroga() As Boolean
        If Cb_TipoDuracion.SelectedValue = "M" Then
            If Nud_Duracion.Value > 12 Then
                MessageBox.Show("La duración no corresponde", "SELECCIONAR TIPO DE DURACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cb_TipoDuracion.Focus()
                ValidarProrroga = False
                Exit Function
            End If
        End If

        '1 FECHAINICIAL es MENOR a FECHA FINAL
        '0 FECHAINICIAL es IGUAL a FECHA FINAL
        '-1 FECHAINICIAL es MAYOR a FECHA FINAL
        If FuncionesBase.FuncionesBase.CompararFechas(Me.Dtp_FechaFirma.Value, Me.Dtp_FechaInicio.Value) < 1 Then 'Es igual o la fecha de la firma es inferior
            MessageBox.Show("La fecha de la firma no puede ser superior o igual a la fecha de inicio de la prorroga", "SELECCIONAR TIPO DE DURACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Dtp_FechaFirma.Focus()
            ValidarProrroga = False
            Exit Function
        End If

        If Dtp_FechaFirma.Value.DayOfWeek = DayOfWeek.Sunday Then
            If MsgBox("La fecha de la firma es un Domingo, ¿Desea continuar?", MsgBoxStyle.YesNo, "FECHA FIRMA PRORROGA") = MsgBoxResult.No Then
                Dtp_FechaFirma.Focus()
                ValidarProrroga = False
                Exit Function
            End If
        End If

        If Dtp_FechaFirma.Value.DayOfWeek = DayOfWeek.Saturday Then
            If MsgBox("La fecha de la firma es un Sabado, ¿Desea continuar?", MsgBoxStyle.YesNo, "FECHA FIRMA PRORROGA") = MsgBoxResult.No Then
                Dtp_FechaFirma.Focus()
                ValidarProrroga = False
                Exit Function
            End If
        End If

        If ValidarFestivo(Dtp_FechaFirma.Value) = True Then
            If MsgBox("La fecha de la firma es un festivo, ¿Desea continuar?", MsgBoxStyle.YesNo, "FECHA FIRMA PRORROGA") = MsgBoxResult.No Then
                Dtp_FechaFirma.Focus()
                ValidarProrroga = False
                Exit Function
            End If
        End If


        ValidarProrroga = True
    End Function


    Private Function ValidarFestivo(fecha As Date) As Boolean
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT dbo.EsFestivo(@FECHA)", conexion)
        comando.Parameters.AddWithValue("@FECHA", fecha)
        Dim esFestivo As Boolean
        Try
            comando.Connection.Open()
            esFestivo = comando.ExecuteScalar()
            comando.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            comando.Connection.Close()
        End Try
        If esFestivo = True Then
            Return True
        End If
        Return False
    End Function


    Private Sub Guardar_Registro_Contrato()
        'Llamar al procedimiento para crear el tipo categoría
        comando = New SqlClient.SqlCommand("dbo.GestionarProrrogaContrato", conexion) With {.CommandType = CommandType.StoredProcedure}
        comando.Parameters.AddWithValue("@ACCION", 1) 'Crear
        Comando.Parameters.AddWithValue("@IDCONTRATO", IdContrato)
        comando.Parameters.AddWithValue("@FECHAINICIO", Dtp_FechaInicio.Value)
        comando.Parameters.AddWithValue("@FECHAFIN", Dtp_FechaTerminacion.Value)
        comando.Parameters.AddWithValue("@FECHAFIRMA", Dtp_FechaFirma.Value)
        comando.Parameters.AddWithValue("@DURACION", Nud_Duracion.Value)
        comando.Parameters.AddWithValue("@CODIGOTIPODURACION", Cb_TipoDuracion.SelectedValue)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
        Try
            conexion.Open()
            Comando.ExecuteNonQuery()
            conexion.Close()
            If Not IsDBNull(comando.Parameters("@IDMENSAJE").Value) Then
                Select Case comando.Parameters("@IDMENSAJE").Value
                    Case 0
                        MessageBox.Show("No se pudo realizar la operación", "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        _guardado = False
                        Exit Sub
                    Case 1
                        MessageBox.Show("El registro ha sido exitoso", "Contrato", MessageBoxButtons.OK)
                        _guardado = True
                        Close()
                End Select
            Else
                MessageBox.Show("No se pudo realizar la operación", "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo realizar la operación." & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        DialogResult = System.Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

End Class 'Dia_ProrrogarContrato