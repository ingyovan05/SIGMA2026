Imports System.Globalization
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class Cu_Vacuna
    Public dtVacunaPersona As DataTable
    Public IdPersona As Integer
    Public ModuloRegistro As String
    Public contRegIni As Integer

    Private Sub Cu_vacuna(sender As Object, e As EventArgs) Handles Me.Load
        Dgv_VacunasPersona.AutoSize = True
        CargarDatos()
    End Sub

    Public Sub CargarDatos()

        Dgv_VacunasPersona.DataSource = dtVacunaPersona
        For i = 0 To Dgv_VacunasPersona.ColumnCount - 1
            Select Case Dgv_VacunasPersona.Columns(i).Name
                Case DGVVP_NOMBRE.Name
                    Dgv_VacunasPersona.Columns(i).HeaderText = "Vacuna"
                    Dgv_VacunasPersona.Columns(i).ToolTipText = "Nombre Vacuna"
                    Dgv_VacunasPersona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_VacunasPersona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_VacunasPersona.Columns(i).SortMode = DataGridViewColumnSortMode.Programmatic

                Case DGVVP_FechaVacuna.Name ' fecha Aplica  vacuna
                    Dgv_VacunasPersona.Columns(i).HeaderText = "Fecha Vacuna"
                    Dgv_VacunasPersona.Columns(i).ToolTipText = "Fecha Vacunación"
                    Dgv_VacunasPersona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_VacunasPersona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_VacunasPersona.Columns(i).SortMode = DataGridViewColumnSortMode.Programmatic



                Case DGVVP_MODULOCREACION.Name ' Modulo Creación   vacuna
                    Dgv_VacunasPersona.Columns(i).HeaderText = "Mod. Creación"
                    Dgv_VacunasPersona.Columns(i).ToolTipText = "Módulo creación del registro en sigma "
                    Dgv_VacunasPersona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_VacunasPersona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_VacunasPersona.Columns(i).SortMode = DataGridViewColumnSortMode.Programmatic

                Case DGVVP_PERSONAREGISTRA.Name 'Nombre Persona Registra 
                    Dgv_VacunasPersona.Columns(i).HeaderText = "Usuario Registra"
                    Dgv_VacunasPersona.Columns(i).ToolTipText = "Nombre Persona Registra"
                    Dgv_VacunasPersona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_VacunasPersona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_VacunasPersona.Columns(i).SortMode = DataGridViewColumnSortMode.Programmatic
                Case DGVVP_FechaRegistro.Name ' fecha Registro
                    Dgv_VacunasPersona.Columns(i).HeaderText = "Fecha Registro"
                    Dgv_VacunasPersona.Columns(i).ToolTipText = "Fecha Registro Sigma"
                    Dgv_VacunasPersona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_VacunasPersona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_VacunasPersona.Columns(i).SortMode = DataGridViewColumnSortMode.Programmatic
                Case Else
                    Dgv_VacunasPersona.Columns(i).Visible = False
                    Dgv_VacunasPersona.Columns(i).SortMode = DataGridViewColumnSortMode.Programmatic
            End Select
        Next
        Try
            Dgv_VacunasPersona.Sort(Dgv_VacunasPersona.Columns(7), ListSortDirection.Ascending)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub EsconderFilas()
        Me.Dgv_VacunasPersona.CurrentCell = Nothing
        For i As Integer = 0 To dtVacunaPersona.Rows.Count - 1
            If dtVacunaPersona.Rows(i).Item("ACTIVA") = "N" Then
                Me.Dgv_VacunasPersona.Rows(i).Visible = False
            End If
        Next
    End Sub

    Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Dgv_VacunasPersona.UserDeletingRow

        Dim startingBalanceRow As DataGridViewRow = Dgv_VacunasPersona.Rows(0)

        If Dgv_VacunasPersona.SelectedRows.Contains(startingBalanceRow) Then

            MessageBox.Show("Esta eliminando el Primer registro de vacuna")


            e.Cancel = True
        End If

        'Registros  iniciales
        If contRegIni > 0 Then

            Dim FilaSeleccionada As DataGridViewRow = Dgv_VacunasPersona.CurrentRow

            If Me.Dgv_VacunasPersona.CurrentRow IsNot Nothing Then 'Averiguar si se seleccionó un campo en el Datagridview

                Dim fila As Integer = Me.Dgv_VacunasPersona.CurrentRow.Index

                For i As Integer = 0 To dtVacunaPersona.Rows.Count - 1
                    If dtVacunaPersona.Rows(i).Item("ACTIVA").ToString = "S" Then
                        If dtVacunaPersona.Rows(fila).Item("IDVACUNA").ToString = dtVacunaPersona.Rows(i).Item("IDPADRE").ToString Then
                            e.Cancel = True
                            MsgBox("No se puede eliminar el registro, tiene más registros asociados del mismo tipo.")
                            Exit Sub
                        End If
                    End If
                Next

                Me.Dgv_VacunasPersona.CurrentCell = Nothing

                Dim userMsg As String
                userMsg = Microsoft.VisualBasic.InputBox("Descripción del motivo de eliminación del registro de vacunación ", "Motivo eliminación Vacuna", "", -1, -1)

                If userMsg = "" Then
                    MessageBox.Show("El cambio no fue guardado, No se registró el motivo de eliminación")
                    e.Cancel = True
                Else
                    e.Cancel = True
                    dtVacunaPersona.Rows(fila).Item("ACTIVA") = "N"
                    'Me.Dgv_VacunasPersona.Rows(fila).Visible = False
                    'Me.Dgv_VacunasPersona.Rows(fila).Cells("ACTIVA").Value = "N"
                    Me.Dgv_VacunasPersona.Rows(fila).Cells("OBSERVACIONINACTIVACION").Value = userMsg.ToString
                    Me.Dgv_VacunasPersona.Rows(fila).Cells("IDPERSONAINACTIVA").Value = VariablesBase.VariablesBase.IdPersona
                    Me.Dgv_VacunasPersona.Rows(fila).Cells("FECHAINACTIVACION").Value = Now
                End If
            End If
        Else
            Dim FilaSeleccionada As DataGridViewRow = Dgv_VacunasPersona.CurrentRow
            'Dgv_VacunasPersona.Rows.RemoveAt(Dgv_VacunasPersona.CurrentRow.Index)
            If Me.Dgv_VacunasPersona.CurrentRow IsNot Nothing Then 'Averiguar si se seleccionó un campo en el Datagridview
                ' Escribir el código anterior
                Dim fila As Integer = Me.Dgv_VacunasPersona.CurrentRow.Index
                Me.Dgv_VacunasPersona.CurrentCell = Nothing
                Me.Dgv_VacunasPersona.Rows.Remove(FilaSeleccionada)
            End If
        End If
        dtVacunaPersona.AcceptChanges()
        EsconderFilas()


    End Sub




    Private Sub Bt_Agregar_Click(sender As Object, e As EventArgs) Handles Bt_Agregar.Click
        Dim frEditarVacuna As New Fr_EditarVacuna(IdPersona)
        frEditarVacuna.Fr_dtVacunaPersona = dtVacunaPersona.Copy


        If contRegIni > 0 Then
            frEditarVacuna.ShowDialog()

            If frEditarVacuna.Agregado = True Then
                Dim existeVacuna As Boolean = False
                For Each itm As DataGridViewRow In Dgv_VacunasPersona.Rows
                    If itm.Cells("IDVACUNA").Value = Convert.ToInt32(frEditarVacuna.Cb_Vacunas.SelectedValue) And itm.Cells("ACTIVA").Value = "S" And itm.Cells("IDVACUNA").Value < 10 Then
                        existeVacuna = True
                    End If
                Next
                If Me.Dgv_VacunasPersona.Rows.Count > 0 AndAlso existeVacuna = True Then
                    MsgBox("Alerta: ya existe Un registro de esta vacuna!!!")
                End If

                For i As Integer = 0 To dtVacunaPersona.Rows.Count - 1
                    Dim FechaNueva As DateTime = frEditarVacuna.Dt_FechaVacuna.Value.ToString("dd/MM/yyyy")
                    Dim FechaPadre As DateTime = Convert.ToDateTime(dtVacunaPersona.Rows(i).Item("FECHAVACUNA")).ToString("dd/MM/yyyy")
                    If dtVacunaPersona.Rows(i).Item("IDVACUNA") = frEditarVacuna.IdPadre AndAlso (FechaPadre = FechaNueva Or FechaNueva < FechaPadre) AndAlso dtVacunaPersona.Rows(i).Item("ACTIVA").ToString = "S" Then
                        MsgBox("Esta registrando una fecha de vacunación menor o igual de un mismo tipo de vacuna")
                        Exit Sub
                    End If
                Next

                If existeVacuna = False Then
                    Try
                        Dim row As DataRow
                        row = dtVacunaPersona.NewRow
                        row("IDVACUNAXPERSONA") = 111
                        row("IDPERSONA") = IdPersona
                        row("IDVACUNA") = Convert.ToInt32(frEditarVacuna.Cb_Vacunas.SelectedValue)
                        row("NOMBREVACUNA") = frEditarVacuna.Cb_Vacunas.Text
                        row("FECHAVACUNA") = frEditarVacuna.Dt_FechaVacuna.Value.ToString("dd/MM/yyyy")
                        row("MODULOCREACION") = ModuloRegistro
                        row("IDPERSONAREGISTRO") = VariablesBase.VariablesBase.IdPersona
                        row("ACTIVA") = "S"
                        row("OBSERVACIONINACTIVACION") = DBNull.Value
                        row("IDPERSONAINACTIVA") = DBNull.Value
                        row("NOMPERSONAREGISTRO") = VariablesBase.VariablesBase.Nombre_Usuario
                        row("FECHAREGISTRO") = Now
                        row("FECHAINACTIVACION") = DBNull.Value
                        row("IDPADRE") = frEditarVacuna.IdPadre
                        dtVacunaPersona.Rows.Add(row)
                        'Dgv_VacunasPersona.DataSource = dtVacunaPersona
                    Catch ex As Exception
                    End Try
                End If
            End If
        Else

            frEditarVacuna.ShowDialog()

            If frEditarVacuna.Agregado = True Then
                Dim existeVacuna As Boolean = False
                For Each itm As DataGridViewRow In Dgv_VacunasPersona.Rows
                    If itm.Cells("IDVACUNA").Value = Convert.ToInt32(frEditarVacuna.Cb_Vacunas.SelectedValue) And itm.Cells("IDVACUNA").Value < 10 Then
                        existeVacuna = True
                    End If
                Next

                If Me.Dgv_VacunasPersona.Rows.Count > 0 AndAlso existeVacuna = True Then
                    MsgBox("Alerta: ya existe Un registro de esta vacuna!!!")
                End If
                If existeVacuna = False Then
                    Try
                        Dim row As DataRow
                        row = dtVacunaPersona.NewRow
                        row("IDVACUNAXPERSONA") = 1
                        row("IDPERSONA") = IdPersona
                        row("IDVACUNA") = Convert.ToInt32(frEditarVacuna.Cb_Vacunas.SelectedValue)
                        row("NOMBREVACUNA") = frEditarVacuna.Cb_Vacunas.Text
                        row("FECHAVACUNA") = frEditarVacuna.Dt_FechaVacuna.Value.ToString("dd/MM/yyyy")
                        row("MODULOCREACION") = ModuloRegistro
                        row("IDPERSONAREGISTRO") = VariablesBase.VariablesBase.IdPersona
                        row("ACTIVA") = "S"
                        row("OBSERVACIONINACTIVACION") = DBNull.Value
                        row("IDPERSONAINACTIVA") = DBNull.Value
                        row("NOMPERSONAREGISTRO") = VariablesBase.VariablesBase.Nombre_Usuario
                        row("FECHAREGISTRO") = Now
                        row("FECHAINACTIVACION") = DBNull.Value
                        row("IDPADRE") = frEditarVacuna.IdPadre
                        dtVacunaPersona.Rows.Add(row)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
        EsconderFilas()

    End Sub

End Class



Public Class Fr_EditarVacuna
    Inherits Form
    Property IdPersona As Integer = -1
    Public Editando As Boolean = False
    Friend WithEvents Pn_Controles As New Panel
    Friend WithEvents Lb_Vacuna As New Label
    Friend WithEvents Lb_Fecha As New Label
    Friend WithEvents Cb_Vacunas As New ComboBox
    Friend WithEvents Tx_Otros As New TextBox
    Friend WithEvents Flp_Botones As New FlowLayoutPanel
    Friend WithEvents Bt_Aceptar As New Button
    Friend WithEvents Bt_Cancelar As New Button
    Friend WithEvents Dt_FechaVacuna As New DateTimePicker
    Public dtVacunas As New DataTable
    Public Fr_dtVacunaPersona As New DataTable
    Public IdVacuna As Integer
    Public FechaVacuna As DateTime
    Public Agregado As Boolean
    Public IdPadre As Integer

    Public Sub New(_idPersona As Integer)
        IdPersona = _idPersona
        InicializarControles()
    End Sub

    Private Sub InicializarControles()
        Dim Base As Integer = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        With Lb_Vacuna
            .Enabled = True
            .Location = New System.Drawing.Point(20, 25)
            .Text = "Vacuna"
        End With
        With Lb_Fecha
            .Enabled = True
            .Location = New System.Drawing.Point(20, 50)
            .Text = "Fecha"
        End With

        With Cb_Vacunas
            .DisplayMember = "NOMBREVACUNA"
            .DropDownStyle = ComboBoxStyle.DropDown
            .Enabled = True
            .Location = New System.Drawing.Point(80, 25)
            .Size = New System.Drawing.Size(150, 20)
            .ValueMember = "IDVACUNA"
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

        With Dt_FechaVacuna
            .Enabled = True
            .Location = New System.Drawing.Point(80, 50)
            .Name = "dateTimePicker1"
            .Size = New System.Drawing.Size(150, 20)
            .TabIndex = 2
            .Format = DateTimePickerFormat.Short
            .CustomFormat = "dd/MM/yyyy"

        End With
        With Bt_Cancelar
            .AutoSize = True
            .UseVisualStyleBackColor = True
            .Text = "Cancelar"
        End With
        With Bt_Aceptar
            .AutoSize = True
            .UseVisualStyleBackColor = True
            .Text = "Aceptar"
        End With
        With Flp_Botones
            .BackColor = Drawing.Color.Silver
            .Dock = DockStyle.Bottom
            .FlowDirection = FlowDirection.RightToLeft
            .Height = 30
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)

        End With
        With Me
            .AcceptButton = Bt_Aceptar
            .CancelButton = Bt_Cancelar
            .FormBorderStyle = FormBorderStyle.FixedSingle
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New System.Drawing.Size(280, 170)
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Guardar Vacunacion"
            .Controls.Add(Flp_Botones)
            .Controls.Add(Pn_Controles)
        End With
        With Pn_Controles
            .Dock = DockStyle.Fill
            .Controls.Add(Cb_Vacunas)
            .Controls.Add(Dt_FechaVacuna)
            .Controls.Add(Lb_Vacuna)
            .Controls.Add(Lb_Fecha)
        End With
    End Sub
    Private Sub Fr_EditarVacuna_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarVacunas()
        Dt_FechaVacuna.MaxDate = Today.Date
    End Sub

    Private Sub CargarVacunas()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        If Fr_dtVacunaPersona.Columns.Count = 14 Then
            Fr_dtVacunaPersona.Columns.Remove("NOMPERSONAREGISTRO")
            Fr_dtVacunaPersona.Columns.Remove("IDPADRE")
        End If
        For i As Integer = 0 To Fr_dtVacunaPersona.Rows.Count - 1
            If Fr_dtVacunaPersona.Rows(i).Item("MODULOCREACION").ToString = "CONTRATO" Or Fr_dtVacunaPersona.Rows(i).Item("MODULOCREACION").ToString = "C" Then
                Fr_dtVacunaPersona.Rows(i).Item("MODULOCREACION") = "C"
            Else
                Fr_dtVacunaPersona.Rows(i).Item("MODULOCREACION") = "H"
            End If
        Next
        Dim comando As New SqlCommand()
        comando.CommandText = "dbo.ListarVacunasCombo"
        comando.Connection = conexion
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDPERSONA", IdPersona)
        comando.Parameters.AddWithValue("@TablaVacunas", Fr_dtVacunaPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            adaptador.Fill(dtVacunas)
            Cb_Vacunas.DataSource = dtVacunas.Copy
        Catch ex As Exception
            MessageBox.Show("Error " & Environment.NewLine & ex.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try

        If dtVacunas.Rows.Count = 0 Then
            Me.Close()
            MsgBox(" No se ecuentran vacunas para registrar")
        End If

    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Agregado = False
        Me.Close()
    End Sub
    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If ValidarVacuna() Then
            Agregado = True
            IdPadre = dtVacunas.Rows(Cb_Vacunas.SelectedIndex).Item("IDPADRE")
        Else
            Agregado = False
            Exit Sub
        End If

        Me.Close()
    End Sub

    Protected Sub BtnRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim itemsSelected As Integer() = Cb_Vacunas.SelectedItem

        For i As Integer = 0 To itemsSelected.Length - 1
            Cb_Vacunas.Items.RemoveAt(i)
        Next
    End Sub

    Private Function ValidarVacuna() As Boolean
        If Cb_Vacunas.SelectedValue Is Nothing Then
            MsgBox("Debe seleccionar el tipo de vacuna", MsgBoxStyle.Critical, "TIPOVACUNA")
            Me.Cb_Vacunas.Focus()
            ValidarVacuna = False
            Exit Function
        End If

        If Dt_FechaVacuna.Text = "" Then
            MsgBox("Debe digitar la fecha de aplicación de la vacuna", MsgBoxStyle.Critical, "FECHAVACUNACION")
            Me.Dt_FechaVacuna.Focus()
            ValidarVacuna = False
            Exit Function
        End If
        ValidarVacuna = True
    End Function
End Class