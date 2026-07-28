Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Fr_ProgramarCapacitaciones
    Private dtPersonas As New DataTable
    Private dtCalificaciones As New DataTable
    Private dtProgramacion As New DataTable
    Private guardado As Boolean = False

    Private Sub Fr_ProgramarCapacitaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dsCargar As New DataSet
        Dim bddatos As New FuncionesBase.ClaseCargarMaestras
        dsCargar = bddatos.CargarMaestras(9, -1, -1, 1)
        '0	CP_CALIFICACIONPERSONAL
        '1	PERSONA
        '2	CP_ACTIVIDADCAPACITACION
        '3	CP_ENTIDADCERTIFICADORA
        '4	CP_CALIFICACIONPERSONALLISTADO
        Cb_ActividadCapacitacion.DataSource = dsCargar.Tables(2)

        Cubp_Persona.CargarDatos()
        Cubp_Persona.CargarCajaTexto()

        Dgv_Personal.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        dtPersonas.Columns.Add("IDPERSONA", Type.GetType("System.Int32"))
        For i As Integer = 0 To Dgv_Personal.Columns.Count - 1
            If Not dtPersonas.Columns.Contains(Dgv_Personal.Columns(i).DataPropertyName) Then
                dtPersonas.Columns.Add(Dgv_Personal.Columns(i).DataPropertyName)
            End If
        Next
        Dgv_Personal.DataSource = dtPersonas
        Dgv_Personal.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)

        Dtp_FechaProgramaInicio.MinDate = Date.Today
        Dtp_FechaProgramaInicio.MinDate = Date.Today

        Dgv_Calificaciones.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        dtCalificaciones.Columns.Add("CODIGOACTIVIDADCAPACITACION", Type.GetType("System.Int32"))
        For j As Integer = 0 To Dgv_Calificaciones.Columns.Count - 1
            If Not dtCalificaciones.Columns.Contains(Dgv_Calificaciones.Columns(j).DataPropertyName) Then
                dtCalificaciones.Columns.Add(Dgv_Calificaciones.Columns(j).DataPropertyName)
            End If
        Next
        Dgv_Calificaciones.DataSource = dtCalificaciones
        Dgv_Calificaciones.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)

        Dgv_Programacion.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        dtProgramacion.Columns.Add("IDPERSONA", Type.GetType("System.Int32"))
        dtProgramacion.Columns.Add("CODIGOACTIVIDADCAPACITACION", Type.GetType("System.Int32"))
        For k As Integer = 0 To Dgv_Programacion.Columns.Count - 1
            If Not dtProgramacion.Columns.Contains(Dgv_Programacion.Columns(k).DataPropertyName) Then
                dtProgramacion.Columns.Add(Dgv_Programacion.Columns(k).DataPropertyName)
            End If
        Next
        Dgv_Programacion.DataSource = dtProgramacion
        Dgv_Programacion.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader)
    End Sub


    Private Sub Bt_AgregarPersona_Click(sender As Object, e As EventArgs) Handles Bt_AgregarPersona.Click
        If Cubp_Persona.Tx_TextoCódigo.Text.Length = 0 Then
            Cubp_Persona.CargarCajaTexto()
        End If
        If dtPersonas.Select(ColPer_IdPersona.DataPropertyName & " = " & Cubp_Persona.Cb_Persona.SelectedValue).Length > 0 Then
            MessageBox.Show("La persona " & Cubp_Persona.Cb_Persona.Text & " con identificación " & FuncionesBase.FuncionesBase.FormatearIdentificacion(Cubp_Persona.Tx_TextoCódigo.Text) & " ya se encuentra incluída", _
                            "Ya se ingresó", MessageBoxButtons.OK)
            Exit Sub
        End If
        Dim dr As DataRow = dtPersonas.NewRow
        dr.Item(ColPer_IdPersona.DataPropertyName) = Cubp_Persona.Cb_Persona.SelectedValue
        dr.Item(ColPer_Identificacion.DataPropertyName) = Cubp_Persona.Tx_TextoCódigo.Text
        dr.Item(ColPer_NombreCompleto.DataPropertyName) = Cubp_Persona.Cb_Persona.Text
        dtPersonas.Rows.Add(dr)
        Dgv_Personal.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub Bt_AgregarCalificacion_Click(sender As Object, e As EventArgs) Handles Bt_AgregarCalificacion.Click
        If Cb_ActividadCapacitacion.SelectedIndex >= 0 Then
            If dtCalificaciones.Select(ColCal_CodigoActividadCapacitacion.DataPropertyName & " = " & Cb_ActividadCapacitacion.SelectedValue).Length > 0 Then
                MessageBox.Show("La actividad " & Cb_ActividadCapacitacion.Text & " ya se encuentra incluída.", "Ya se ingresó", MessageBoxButtons.OK)
                Exit Sub
            End If
            Dim dr As DataRow = dtCalificaciones.NewRow
            dr.Item(ColCal_CodigoActividadCapacitacion.DataPropertyName) = Cb_ActividadCapacitacion.SelectedValue
            dr.Item(ColCal_NombreActividadCapacitacion.DataPropertyName) = Cb_ActividadCapacitacion.Text
            dtCalificaciones.Rows.Add(dr)
            Dgv_Calificaciones.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        End If
    End Sub

    Private Sub Dtp_FechaProgramaInicio_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaProgramaInicio.ValueChanged
        If Dtp_FechaProgramaFin.Checked Then
            If Dtp_FechaProgramaFin.Value < Dtp_FechaProgramaInicio.Value Then
                Dtp_FechaProgramaFin.MinDate = Dtp_FechaProgramaInicio.Value
            End If
        End If
    End Sub

    Private Sub Bt_AgregarProgramacion_Click(sender As Object, e As EventArgs) Handles Bt_AgregarProgramacion.Click
        dtPersonas.AcceptChanges()
        dtCalificaciones.AcceptChanges()
        Dim filaPersonal As DataGridViewRow
        Dim filaCalificacion As DataGridViewRow
        Dim filas() As DataRow
        Dim filaProgramacion As DataRow
        Dim sb As New System.Text.StringBuilder
        Dim hayRepetido As Boolean = False
        For i As Integer = 0 To Dgv_Calificaciones.Rows.Count - 1
            filaCalificacion = Dgv_Calificaciones.Rows(i)
            For j As Integer = 0 To Dgv_Personal.Rows.Count - 1
                filaPersonal = Dgv_Personal.Rows(j)
                If dtProgramacion.Rows.Count > 0 Then
                    filas = dtProgramacion.Select(ColPro_Idpersona.DataPropertyName & " = " & filaPersonal.Cells(ColPer_IdPersona.Name).Value & _
                                                  " AND " & ColPro_CodigoActividadCapacitacion.DataPropertyName & " = " & filaCalificacion.Cells(ColCal_CodigoActividadCapacitacion.Name).Value )
                    If filas.Length > 0 Then
                        sb.AppendLine("• " & FuncionesBase.FuncionesBase.FormatearIdentificacion(filaPersonal.Cells(ColPer_Identificacion.Name).Value) & " " & _
                                  filaPersonal.Cells(ColPer_NombreCompleto.Name).Value & ", " & _
                                  "Actividad: " & filaCalificacion.Cells(ColCal_NombreActividadCapacitacion.Name).Value & ", " & _
                                  "Fecha: " & filas(0).Item("FECHAPROGRAMADA") & " - " & filas(0).Item("FECHAPROGRAMADA") & ".")
                        hayRepetido = True
                        Continue For
                    End If
                End If
                filaProgramacion = dtProgramacion.NewRow
                filaProgramacion.Item(ColPro_CodigoActividadCapacitacion.DataPropertyName) = filaCalificacion.Cells(ColCal_CodigoActividadCapacitacion.Name).Value
                filaProgramacion.Item(ColPro_NombreActividadCapacitacion.DataPropertyName) = filaCalificacion.Cells(ColCal_NombreActividadCapacitacion.Name).Value
                filaProgramacion.Item(ColPro_Idpersona.DataPropertyName) = filaPersonal.Cells(ColPer_IdPersona.Name).Value
                filaProgramacion.Item(ColPro_Identificacion.DataPropertyName) = filaPersonal.Cells(ColPer_Identificacion.Name).Value
                filaProgramacion.Item(ColPro_NombreCompleto.DataPropertyName) = filaPersonal.Cells(ColPer_NombreCompleto.Name).Value
                filaProgramacion.Item(ColPro_FechaProgramaInicio.DataPropertyName) = Dtp_FechaProgramaInicio.Value.ToShortDateString
                filaProgramacion.Item(ColPro_FechaProgramaFin.DataPropertyName) = If(Dtp_FechaProgramaFin.Checked, Dtp_FechaProgramaFin.Value.ToShortDateString, DBNull.Value)
                dtProgramacion.Rows.Add(filaProgramacion)
            Next
        Next
        Dgv_Programacion.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        If hayRepetido Then
            MessageBox.Show("La siguiente programación ya se encuentraba incluída:" & Environment.NewLine & Environment.NewLine & sb.ToString, "Programación duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Personal.KeyDown, Dgv_Calificaciones.KeyDown, Dgv_Programacion.KeyDown
        If Not e.Handled Then
            Try
                Dim dgv As DataGridView = sender
                Dim dt As DataTable = dgv.DataSource
                Select Case e.KeyValue
                    Case Keys.Delete
                        dgv.Rows.RemoveAt(dgv.SelectedCells(0).RowIndex)
                        e.Handled = True
                        dt.AcceptChanges()
                    Case Else

                End Select
            Catch

            End Try
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Validar() Then
            guardado = Guardar()
            If guardado Then
                Dim dr As DialogResult
                dr = MessageBox.Show("¿Desea continuar con la programación de capacitaciones?", "Continuar programación", MessageBoxButtons.YesNo)
                If dr = DialogResult.Yes Then
                    Dtp_FechaProgramaInicio.MinDate = Date.Today
                    Dtp_FechaProgramaFin.MinDate = Date.Today
                    Dtp_FechaProgramaInicio.Value = Date.Today
                    Dtp_FechaProgramaFin.Value = Date.Today
                    dtProgramacion.Clear()
                Else
                    DialogResult = DialogResult.OK
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        Dim valido As Boolean = True
        Dim filaTieneErrores As Boolean = False
        For i As Integer = 0 To Dgv_Programacion.Rows.Count - 1
            filaTieneErrores = False

            If IsDBNull(Dgv_Programacion.Rows(i).Cells(ColPro_Idpersona.Name).Value) Then
                Dgv_Programacion.Rows(i).Cells(ColPro_Idpersona.Name).ErrorText = ""
                filaTieneErrores = True
            Else
                Dgv_Programacion.Rows(i).Cells(ColPro_Idpersona.Name).ErrorText = ""
            End If

            If IsDBNull(Dgv_Programacion.Rows(i).Cells(ColPro_Identificacion.Name).Value) Then
                Dgv_Programacion.Rows(i).Cells(ColPro_Identificacion.Name).ErrorText = ""
                filaTieneErrores = True
            Else
                Dgv_Programacion.Rows(i).Cells(ColPro_Identificacion.Name).ErrorText = ""
            End If

            If filaTieneErrores Then
                Dgv_Programacion.Rows(i).ErrorText = "Hay datos en la fila que contienen errores."
                valido = False
            Else
                Dgv_Programacion.Rows(i).ErrorText = ""
            End If
        Next
        Return valido
    End Function


    Private Function Guardar() As Boolean
        If dtProgramacion.Rows.Count = 0 Then
            MessageBox.Show("No ha agregado ninguna capacitación a la programación", "No hay capacitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        dtProgramacion.AcceptChanges()
        Dim dtProgramarCapacitaciones As New DataTable
        dtProgramarCapacitaciones.Columns.Add(ColPro_Idpersona.DataPropertyName)
        dtProgramarCapacitaciones.Columns.Add(ColPro_CodigoActividadCapacitacion.DataPropertyName)
        dtProgramarCapacitaciones.Columns.Add(ColPro_FechaProgramaInicio.DataPropertyName)
        dtProgramarCapacitaciones.Columns.Add(ColPro_FechaProgramaFin.DataPropertyName)
        For i As Integer = 0 To dtProgramacion.Rows.Count - 1
            dtProgramarCapacitaciones.ImportRow(dtProgramacion.Rows(i))
        Next

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("CP_ProgramarCapacitaciones", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TablaPROGRAMACIONCAPACITACIONES", dtProgramarCapacitaciones)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.Add(New SqlParameter("@Mensaje", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
            If Not IsDBNull(comando.Parameters("@Mensaje").Value) Then
                Select Case comando.Parameters("@Mensaje").Value
                    Case 1
                        MessageBox.Show("Se guardaron los cambios correctamente.", "Cambios guardados", MessageBoxButtons.OK)
                        Return True
                    Case Else
                        MessageBox.Show("No fue posible guardar los cambios", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                End Select
            Else
                MessageBox.Show("No fue posible guardar los cambios", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("No fue posible guardar los cambios", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function


    Public Sub EventoCajaEnter(Optional NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Cubp_Persona.Name
                Try
                    filas = Cubp_Persona.DT_BUSCARPERSONA.Select("IDENTIFICACION='" & Cubp_Persona.Tx_TextoCódigo.Text & "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cubp_Persona.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MessageBox.Show("Esta identificación no está registrada o no está asociada a la bodega.", "No se encuentra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Catch ex As Exception
                    Cubp_Persona.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub

End Class 'Fr_ProgramarCapacitaciones


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