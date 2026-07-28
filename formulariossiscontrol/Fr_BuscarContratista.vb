Imports System.Drawing

Public Class Fr_BuscarContratista

    Dim DsOrdenServicio As New DatosSisControl.Ds_Siscontrol
    'Dim SC_CONTRATISTATableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_CONTRATISTATableAdapter
    Public IdContratista As Integer
    Public Identificacion As String = ""
    Public NombreContratista As String = ""
    Private bddatos As New FuncionesBase.ClaseCargarMaestras

    Private Sub Fr_BuscarContratista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Btn_AgregarContratista.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Btn_AgregarContratista.Tag)
        Btn_Editar.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Btn_Editar.Tag)
    End Sub

    Dim dsCargar As New DataSet
    Public Sub Cargar_Tabla()

        dsCargar = bddatos.CargarMaestrasSiscontrol(9, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, IdContratista, 1)

        ComboBox_Filtrar.SelectedIndex = 1
        Me.Dgv_Buscar.DataSource = Nothing
        'Me.SC_CONTRATISTATableAdapter.Fill(Me.DsOrdenServicio.SC_CONTRATISTA)
        'Me.Dgv_Buscar.DataSource = Me.DsOrdenServicio.SC_CONTRATISTA
        Me.Dgv_Buscar.DataSource = Me.dsCargar.Tables(0)
        Me.Dgv_Buscar.AutoGenerateColumns = True
        Me.Dgv_Buscar.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Dgv_Buscar.ReadOnly = True

        For i = 0 To Dgv_Buscar.ColumnCount - 1
            Dgv_Buscar.Columns(i).Visible = True
            Select Case Dgv_Buscar.Columns(i).Name
                Case "Identificación"
                    Dgv_Buscar.Columns(i).Width = 100
                Case "Nombre"
                    Dgv_Buscar.Columns(i).Width = 150
                Case "Dirección"
                    Dgv_Buscar.Columns(i).Width = 250
                Case "Digito Verificación"
                    Dgv_Buscar.Columns(i).Width = 50
                Case Else
                    Dgv_Buscar.Columns(i).Visible = False
            End Select
        Next

    End Sub

    Private Sub Tb_Descripción_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tb_Descripción.TextChanged
        If Cb_Filtrar.Checked = True Then
            'Dim vista As New DataView(Me.DsOrdenServicio.SC_CONTRATISTA)
            Dim vista As New DataView(Me.dsCargar.Tables(0))
            Me.Dgv_Buscar.SuspendLayout()
            Me.Dgv_Buscar.DataSource = vista
            Me.Dgv_Buscar.ResumeLayout()
            Dim Columna As String = ""
            Select Case Me.ComboBox_Filtrar.SelectedIndex
                Case 0
                    Columna = "Nombre"
                Case 1
                    Columna = "Identificación"
            End Select
            vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
        End If
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        Try
            IdContratista = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(0).Value
        Catch ex As Exception
        End Try
        Try
            Identificacion = Trim(Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(1).Value)
        Catch ex As Exception
        End Try

        Try
            NombreContratista = Trim(Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(2).Value)
        Catch ex As Exception
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Dgv_Buscar_DoubleClick(sender As System.Object, e As System.EventArgs) Handles Dgv_Buscar.DoubleClick
        Me.OK_Button.PerformClick()
    End Sub

    Private Sub Dgv_Buscar_RowPostPaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles Dgv_Buscar.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If Dgv_Buscar.RowHeadersWidth < CInt(size.Width + 20) Then
            Dgv_Buscar.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim bt As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub Btn_AgregarContratista_Click(sender As System.Object, e As System.EventArgs) Handles Btn_AgregarContratista.Click
        Dim fr_agregarcontratista As New Fr_AgregarContratista
        fr_agregarcontratista.ShowDialog()
        Try
            Cargar_Tabla()
            Me.Tb_Descripción.Text = fr_agregarcontratista.Identificacion
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub Btn_Editar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Editar.Click
        EditarContratista()
    End Sub

    Private Sub EditarContratista()
        If Dgv_Buscar.RowCount > 0 Then
            Dim fr_agregarcontratista As New Fr_AgregarContratista
            fr_agregarcontratista.IdContratista = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(0).Value
            fr_agregarcontratista.Editando = True
            fr_agregarcontratista.CargarContratista()
            fr_agregarcontratista.ShowDialog()
            Try
                Cargar_Tabla()
                Me.Tb_Descripción.Text = fr_agregarcontratista.Identificacion
            Catch ex As Exception
            End Try
        End If
    End Sub

End Class