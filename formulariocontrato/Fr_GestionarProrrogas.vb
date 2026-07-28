Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text

Public Class Fr_GestionarProrrogas
    Property Editar As Boolean = False
    Property IdPersona As Integer = -1
    Property IdContrato As Long = -1
    Property Nombre As String = ""
    Property CodigoContrato As String = ""
    Property Guardado As Boolean = False
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private dtTipoDuracion As New DataTable
    Private dtProrrogas As DataTable
    Private datosCargados As Boolean = False
    Private diasAnno As UInteger = 360
    Private duracionContratoInicial As Integer
    Private tipoDuracionContratoInicial As String

    Private Sub Fr_GestionarProrrogas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtTipoDuracion.Columns.Add("CODIGOTIPODURACION")
        dtTipoDuracion.Columns.Add("NOMBRETIPODURACION")
        dtTipoDuracion.Rows.Add("M", "Meses")
        dtTipoDuracion.Rows.Add("D", "Días")

        Cb_TipoDuracionInicial.ValueMember = "CODIGOTIPODURACION"
        Cb_TipoDuracionInicial.DisplayMember = "NOMBRETIPODURACION"
        Cb_TipoDuracionInicial.DataSource = dtTipoDuracion.Copy

        Col_TipoDuracion.ValueMember = "CODIGOTIPODURACION"
        Col_TipoDuracion.DisplayMember = "NOMBRETIPODURACION"
        Col_TipoDuracion.DataSource = dtTipoDuracion.Copy

        Lb_Nombre.Text = Nombre
        Lb_Codigo.Text = CodigoContrato
        Dgv_Prorrogas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
        comando = New SqlCommand("SELECT * FROM ListaProrrogasContrato(@IDCONTRATO)", conexion)
        comando.Parameters.AddWithValue("@IDCONTRATO", IdContrato)
        adaptador = New SqlDataAdapter(comando)
        Dim dtResultados As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtResultados)
            conexion.Close()
            If dtResultados.Rows.Count > 0 Then
                Dim drResultado1 As DataRow = dtResultados.Select("[" & Col_IdContratoProrroga.DataPropertyName & "]" & " IS NULL")(0)

                Dtp_FechaInicioContrato.Value = drResultado1.Item(Col_FechaInicio.DataPropertyName)
                Dtp_FechaTerminacionInicial.Value = drResultado1.Item(Col_FechaFin.DataPropertyName)
                Dtp_FechaFirmaInicial.Value = drResultado1.Item(Col_FechaFirma.DataPropertyName)

                duracionContratoInicial = drResultado1.Item(Col_Duracion.DataPropertyName)
                tipoDuracionContratoInicial = drResultado1.Item(Col_TipoDuracion.DataPropertyName)
                Nud_DuracionInicial.Value = duracionContratoInicial
                Cb_TipoDuracionInicial.SelectedValue = tipoDuracionContratoInicial

                Dim drResultados As DataRow() = dtResultados.Select("[" & Col_IdContratoProrroga.DataPropertyName & "]" & " IS NOT NULL", "[" & Col_Consecutivo.DataPropertyName & "] ASC")
                If drResultados.Length > 0 Then
                    dtProrrogas = drResultados.CopyToDataTable
                    Dgv_Prorrogas.DataSource = dtProrrogas
                    Bt_EliminarUltimaProrroga.Enabled = True
                End If
                If Not Editar Then
                    Dgv_Prorrogas.ReadOnly = True
                    Bt_EliminarUltimaProrroga.Visible = False
                    Bt_Aceptar.Enabled = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Fr_GestionarProrrogas_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AddHandler Nud_DuracionInicial.ValueChanged, AddressOf Nud_Duracion_ValueChanged
        AddHandler Cb_TipoDuracionInicial.SelectedIndexChanged, AddressOf Cb_TipoDuracion_SelectedIndexChanged
    End Sub

    Private Sub Nud_Duracion_ValueChanged(sender As Object, e As EventArgs)
        CalcularFechaContratoInicial()
    End Sub

    Private Sub Cb_TipoDuracion_SelectedIndexChanged(sender As Object, e As EventArgs)
        Select Case Cb_TipoDuracionInicial.SelectedValue
            Case "D"
                Nud_DuracionInicial.Value *= 30
                Nud_DuracionInicial.Maximum = diasAnno
            Case "M"
                Nud_DuracionInicial.Maximum = 12
        End Select
        CalcularFechaContratoInicial()
    End Sub

    Private Sub Dgv_Prorrogas_DataSourceChanged(sender As Object, e As EventArgs) Handles Dgv_Prorrogas.DataSourceChanged
        Dgv_Prorrogas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub Dgv_Prorrogas_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Dgv_Prorrogas.DataError
        'Evita que se inserten valores erroneos.
    End Sub

    Private Sub Dgv_Prorrogas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Prorrogas.CellEndEdit
        Dgv_Prorrogas.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
        Dgv_Prorrogas.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Drawing.Color.White
        Select Case Dgv_Prorrogas.Columns(e.ColumnIndex).Name
            Case Col_TipoDuracion.Name
                If (Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_TipoDuracion.Name).Value = "M" AndAlso Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_Duracion.Name).Value > 12) Then
                    Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_Duracion.Name).ErrorText = "La duración sobrepasa el año de contratación."
                ElseIf (Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_TipoDuracion.Name).Value = "D" AndAlso Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_Duracion.Name).Value < diasAnno) Then
                    Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_Duracion.Name).Value *= 30
                End If
            Case Col_Duracion.Name
                If IsNumeric(Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_Duracion.Name).Value) AndAlso Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_Duracion.Name).Value > 0 Then
                    If Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_TipoDuracion.Name).Value = "M" AndAlso Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_Duracion.Name).Value > 12 Then
                        Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_Duracion.Name).ErrorText = "La duración sobrepasa el año de contratación."
                    ElseIf Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_TipoDuracion.Name).Value = "D" AndAlso Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_Duracion.Name).Value > diasAnno Then
                        Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_Duracion.Name).ErrorText = "La duración sobrepasa el año de contratación."
                    End If
                    CalcularFechasProrrogas(e.RowIndex)
                    Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_IdUsuarioModifica.Name).Value = VariablesBase.VariablesBase.IdPersona
                    Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_FechaModificacion.Name).Value = DateTime.Now
                Else
                    Dgv_Prorrogas.Rows(e.RowIndex).Cells(Col_Duracion.Name).ErrorText = "El valor no es válido."
                End If
        End Select
        If Dgv_Prorrogas.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText <> "" Then
            Dgv_Prorrogas.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Drawing.Color.MintCream
        End If
    End Sub

    Private Sub Bt_EliminarUltimaProrroga_Click(sender As Object, e As EventArgs) Handles Bt_EliminarUltimaProrroga.Click
        If Dgv_Prorrogas.Rows.Count > 0 Then
            Dim drEliminar As DataRow = Dgv_Prorrogas.DataSource.Select("", "[" & Col_Consecutivo.DataPropertyName & "] DESC")(0)
            Dgv_Prorrogas.DataSource.Rows.Remove(drEliminar)
            If Dgv_Prorrogas.Rows.Count = 0 Then
                Bt_EliminarUltimaProrroga.Enabled = False
            End If
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        If Editar Then
            Close()
        Else
            Close()
        End If
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Validar() Then
            Guardar()
            If Guardado Then
                MessageBox.Show("Cambios guardados.", "GUARDADO", MessageBoxButtons.OK)
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
            End If
        End If
    End Sub


    Private Sub CalcularFechaContratoInicial()
        Dtp_FechaTerminacionInicial.Value = FuncionesBase.FuncionesBase.Calcular_Fecha_terminación_Contrato(Dtp_FechaInicioContrato.Value, Cb_TipoDuracionInicial.SelectedValue, Nud_DuracionInicial.Value)
        CalcularFechasProrrogas()
    End Sub

    Private Sub CalcularFechasProrrogas(Optional index As UInteger = 0)
        If index = 0 Then
            Dgv_Prorrogas.Rows(0).Cells(Col_FechaInicio.Name).Value = Dtp_FechaTerminacionInicial.Value.AddDays(1)
        End If
        For i As Integer = index To Dgv_Prorrogas.Rows.Count - 1
            Dgv_Prorrogas.Rows(i).Cells(Col_FechaFin.Name).Value = FuncionesBase.FuncionesBase.Calcular_Fecha_terminación_Contrato(Dgv_Prorrogas.Rows(i).Cells(Col_FechaInicio.Name).Value, Dgv_Prorrogas.Rows(i).Cells(Col_TipoDuracion.Name).Value, Dgv_Prorrogas.Rows(i).Cells(Col_Duracion.Name).Value)
            Dgv_Prorrogas.Rows(i).Cells(Col_FechaInicio.Name).ErrorText = ""
            Dgv_Prorrogas.Rows(i).Cells(Col_FechaFin.Name).ErrorText = ""
            Dgv_Prorrogas.Rows(i).Cells(Col_FechaFirma.Name).ErrorText = ""
            If i < Dgv_Prorrogas.Rows.Count - 1 Then
                Dgv_Prorrogas.Rows(i + 1).Cells(Col_FechaInicio.Name).Value = DirectCast(Dgv_Prorrogas.Rows(i).Cells(Col_FechaFin.Name).Value, Date).AddDays(1)
            End If
        Next
    End Sub

    Private Function Validar() As Boolean
        If ValidarCeldas() = False Then
            Return False
        End If
        If ValidarFechasDuracion() = False Then
            Return False
        End If
        If ValidarReportesDiarios() = False Then
            Return False
        End If

        Return True
    End Function

    Private Function ValidarCeldas() As Boolean
        For Each row In Dgv_Prorrogas.Rows
            For Each cell In row.Cells
                If cell.ErrorText <> "" Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Private Function ValidarFechasDuracion()
        'If Dtp_FechaFirmaInicial.Value >= Dtp_FechaInicioContrato.Value Then
        '    MessageBox.Show("La fecha de firma no puede ser superior o igual a la fecha de inicio del contrato.", "Firma contrato inicial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return False
        'End If
        If Dgv_Prorrogas.Rows.Count > 0 Then
            If (Dgv_Prorrogas.Rows(0).Cells(Col_TipoDuracion.Name).Value = Cb_TipoDuracionInicial.SelectedValue AndAlso Dgv_Prorrogas.Rows(0).Cells(Col_Duracion.Name).Value > Nud_DuracionInicial.Value) OrElse _
                (Dgv_Prorrogas.Rows(0).Cells(Col_Duracion.Name).Value > Nud_DuracionInicial.Value * 30) OrElse _
                (Cb_TipoDuracionInicial.SelectedValue = "D" AndAlso Dgv_Prorrogas.Rows(0).Cells(Col_TipoDuracion.Name).Value = "M") Then

                Dgv_Prorrogas.Rows(0).Cells(Col_Duracion.Name).ErrorText = "La duración de la prórroga excede la duración del contrato inicial."
            End If
            If Dgv_Prorrogas.Rows(0).Cells(Col_FechaInicio.Name).Value <= Dtp_FechaTerminacionInicial.Value Then
                Dgv_Prorrogas.Rows(0).Cells(Col_FechaInicio.Name).ErrorText = "La fecha de inicio coincide con la fecha de terminación del contrato inicial."
            End If
            If Dgv_Prorrogas.Rows(0).Cells(Col_FechaInicio.Name).Value > Dtp_FechaTerminacionInicial.Value.AddDays(1) Then
                Dgv_Prorrogas.Rows(0).Cells(Col_FechaInicio.Name).ErrorText = "La fecha de inicio no es contínua con la fecha de terminación del contrato inicial (" & (DirectCast(Dgv_Prorrogas.Rows(0).Cells(Col_FechaInicio.Name).Value, Date) - Dtp_FechaTerminacionInicial.Value).Days & " días de separación)."
            End If
            For i As Integer = 0 To Dgv_Prorrogas.Rows.Count - 1
                If Dgv_Prorrogas.Rows(i).Cells(Col_FechaInicio.Name).Value >= Dgv_Prorrogas.Rows(i).Cells(Col_FechaFin.Name).Value Then
                    Dgv_Prorrogas.Rows(i).Cells(Col_FechaInicio.Name).ErrorText = "La fecha de finalización es igual o anterior a la fecha de inicio."
                End If
                If Dgv_Prorrogas.Rows(i).Cells(Col_FechaFirma.Name).Value >= Dgv_Prorrogas.Rows(i).Cells(Col_FechaInicio.Name).Value Then
                    Dgv_Prorrogas.Rows(i).Cells(Col_FechaFirma.Name).ErrorText = "La fecha de firma no puede ser superior o igual a la fecha de inicio de la prórroga."
                End If
                If i < Dgv_Prorrogas.Rows.Count - 1 Then
                    If (Dgv_Prorrogas.Rows(i + 1).Cells(Col_TipoDuracion.Name).Value = Dgv_Prorrogas.Rows(i).Cells(Col_TipoDuracion.Name).Value AndAlso Dgv_Prorrogas.Rows(i + 1).Cells(Col_Duracion.Name).Value > Dgv_Prorrogas.Rows(i).Cells(Col_Duracion.Name).Value) OrElse _
                (Dgv_Prorrogas.Rows(i + 1).Cells(Col_Duracion.Name).Value > Dgv_Prorrogas.Rows(i).Cells(Col_Duracion.Name).Value * 30) OrElse _
                (Dgv_Prorrogas.Rows(i).Cells(Col_TipoDuracion.Name).Value = "D" AndAlso Dgv_Prorrogas.Rows(i + 1).Cells(Col_TipoDuracion.Name).Value = "M") Then
                        Dgv_Prorrogas.Rows(i + 1).Cells(Col_Duracion.Name).ErrorText = "La duración de la prórroga actual excede la duración de la prórroga anterior."
                    End If
                    If Dgv_Prorrogas.Rows(i).Cells(Col_FechaFin.Name).Value >= Dgv_Prorrogas.Rows(i + 1).Cells(Col_FechaInicio.Name).Value Then
                        Dgv_Prorrogas.Rows(i + 1).Cells(Col_FechaInicio.Name).ErrorText = "La fecha de inicio es anterior a la fecha de finalización de la prórroga anterior."
                    End If
                    If Dgv_Prorrogas.Rows(i + 1).Cells(Col_FechaInicio.Name).Value > DirectCast(Dgv_Prorrogas.Rows(i).Cells(Col_FechaFin.Name).Value, Date).AddDays(1) Then
                        Dgv_Prorrogas.Rows(i + 1).Cells(Col_FechaInicio.Name).ErrorText = "La fecha de inicio no es contínua con la la fecha de finalización de la prórroga anterior (" & (DirectCast(Dgv_Prorrogas.Rows(0).Cells(Col_FechaInicio.Name).Value, Date) - Dtp_FechaTerminacionInicial.Value).Days & " días de separación)."
                    End If
                End If
            Next
        End If
        If Not ValidarCeldas() Then
            Return False
        End If
        Return True
    End Function

    'Revisar que no hayan reportes diarios por fuera de las fechas del contrato y prórrogas.
    Private Function ValidarReportesDiarios() As Boolean
        Dim FechaFinContrato As Date
        If Dgv_Prorrogas.Rows.Count > 0 Then
            FechaFinContrato = Dgv_Prorrogas.DataSource.Select("", "[" & Col_Consecutivo.DataPropertyName & "] DESC")(0).Item(Col_FechaFin.DataPropertyName)
        Else
            FechaFinContrato = Dtp_FechaTerminacionInicial.Value
        End If
        comando = New SqlCommand("SELECT * FROM ReporteDiarioFueraDeFechaContrato(@IDCONTRATO, @FECHAFINCONTRATO)", conexion)
        comando.Parameters.AddWithValue("@IDCONTRATO", IdContrato)
        comando.Parameters.AddWithValue("@FECHAFINCONTRATO", FechaFinContrato)
        adaptador = New SqlDataAdapter(comando)
        Dim dtReportes As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtReportes)
            conexion.Close()
            If dtReportes.Rows.Count = 0 Then
                Return True
            Else
                Dim textoReportes As New StringBuilder
                If dtReportes.Rows.Count = 1 Then
                    textoReportes.AppendLine("El trabajador se incluyó en el reporte de tiempo " & dtReportes.Rows(0).Item("REPORTEDIARIO") & " del día " & dtReportes.Rows(0).Item("FECHAREPORTEDIARIO") & ", el cual se encuentra fuera de fechas de contrato.")
                Else
                    textoReportes.AppendLine("El trabajador se incluyó en los siguientes reportes de tiempo que se encuentran fuera de las fechas de contrato:")
                    textoReportes.AppendLine()
                    textoReportes.AppendLine("  • " & dtReportes.Rows(0).Item("REPORTEDIARIO") & " del día " & dtReportes.Rows(0).Item("FECHAREPORTEDIARIO") & ".")
                    textoReportes.AppendLine()
                End If
                textoReportes.Append("Retírelo de los reportes e intente gestionar las prórrogas nuevamente.")
                MessageBox.Show(textoReportes.ToString, "Contrato en Reportes fuera de Contrato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            conexion.Close()
        End Try
        Return True
    End Function

    Private Sub Guardar()
        Dim dtGuardarProrroga As DataTable
        If Dgv_Prorrogas.Rows.Count > 0 Then
            dtGuardarProrroga = Dgv_Prorrogas.DataSource.Copy
            dtGuardarProrroga.Columns.Remove(Col_IdContratoProrroga.DataPropertyName)
            dtGuardarProrroga.Columns.Remove(Col_IdContrato.DataPropertyName)
            dtGuardarProrroga.Columns.Remove(Col_UsuarioRegistra.DataPropertyName)
            dtGuardarProrroga.Columns.Remove(Col_UsuarioModifica.DataPropertyName)
            'dtGuardarProrroga.Columns.Remove(Col_IdUsuarioModifica.DataPropertyName)
            'dtGuardarProrroga.Columns.Remove(Col_FechaModificacion.DataPropertyName)
        Else
            dtGuardarProrroga = New DataTable
            dtGuardarProrroga.Columns.Add(Col_Consecutivo.DataPropertyName)
            dtGuardarProrroga.Columns.Add(Col_FechaInicio.DataPropertyName)
            dtGuardarProrroga.Columns.Add(Col_FechaFin.DataPropertyName)
            dtGuardarProrroga.Columns.Add(Col_FechaFirma.DataPropertyName)
            dtGuardarProrroga.Columns.Add(Col_Duracion.DataPropertyName)
            dtGuardarProrroga.Columns.Add(Col_TipoDuracion.DataPropertyName)
            dtGuardarProrroga.Columns.Add(Col_IdUsuarioRegistra.DataPropertyName)
            dtGuardarProrroga.Columns.Add(Col_FechaRegistro.DataPropertyName)
            dtGuardarProrroga.Columns.Add(Col_IdUsuarioModifica.DataPropertyName)
            dtGuardarProrroga.Columns.Add(Col_FechaModificacion.DataPropertyName)
            dtGuardarProrroga.Columns.Add(Col_EstadoProrroga.DataPropertyName)
        End If

        comando = New SqlCommand("GestionarProrrogas", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDCONTRATO", IdContrato)
        comando.Parameters.AddWithValue("@FECHAINICIOCONTRATO", Dtp_FechaInicioContrato.Value)
        comando.Parameters.AddWithValue("@FECHAFIRMACONTRATO", Dtp_FechaFirmaInicial.Value)
        comando.Parameters.AddWithValue("@FECHATERMINOCONTRATOINICIAL", Dtp_FechaTerminacionInicial.Value)
        comando.Parameters.AddWithValue("@DURACION", Nud_DuracionInicial.Value)
        comando.Parameters.AddWithValue("@CODIGOTIPODURACION", Cb_TipoDuracionInicial.SelectedValue)
        comando.Parameters.AddWithValue("@TablaPRORROGAS", dtGuardarProrroga)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.Add(New SqlParameter("@MENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
        adaptador = New SqlDataAdapter(comando)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
            If Not IsDBNull(comando.Parameters("@MENSAJE").Value) Then
                Select Case comando.Parameters("@MENSAJE").Value
                    Case 0 'No se guardaron los cambios

                    Case 1 'Cambios guardados correctamente
                        Guardado = True
                End Select
            Else
                MessageBox.Show("Ocurrió un error al guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

End Class


Public Class CalendarColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property
End Class

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "d"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As CalendarEditingControl = _
            CType(DataGridView.EditingControl, CalendarEditingControl)

        ' Use the default row value when Value property is null.
        If (Me.Value Is Nothing) Then
            ctl.Value = CType(Me.DefaultNewRowValue, DateTime)
        Else
            ctl.Value = CType(Me.Value, DateTime)
        End If
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that CalendarCell uses.
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return DateTime.Now
        End Get
    End Property
End Class

Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.Short
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Value.ToShortDateString()
        End Get

        Set(ByVal value As Object)
            Try
                ' This will throw an exception of the string is 
                ' null, empty, or not in the format of a date.
                Me.Value = DateTime.Parse(CStr(value))
            Catch
                ' In the case of an exception, just use the default
                ' value so we're not left with a null value.
                Me.Value = DateTime.Now
            End Try
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Value.ToShortDateString()

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        ' No preparation needs to be done.
    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get
    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)
        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)
    End Sub
End Class