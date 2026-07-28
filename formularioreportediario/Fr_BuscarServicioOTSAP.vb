Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class Fr_BuscarServicioOTSAP

    Public _Tipo As String

    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private cmde As SqlCommand
    Private da As SqlDataAdapter

    Private DT_BUSCARSERVICIO As New DataTable

    Public tablaunidades As New DataTable

    Public TipoBusqueda As String 'Para validar a que tabla se esta retornando el valor, definir si se puede seleccionar mas de un registro
    'P - Personas
    'E - Equipos
    'S- Servicios
    'A- Articulos
    'C- Costos Indirectos

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        TablaServicios.Columns.Add("IDOTSERVICIO", GetType(Int32))
        TablaServicios.Columns.Add("IDORDENTRABAJO", GetType(Int32))
        TablaServicios.Columns.Add("SERVICIO", GetType(String))
        TablaServicios.Columns.Add("NOMBRESERVICIO", GetType(String))
        TablaServicios.Columns.Add("CODIGOTIPOUNIDAD", GetType(Int32))
        TablaServicios.Columns.Add("CODIGOPOBLACION", GetType(String))
        TablaServicios.Columns.Add("IDCLASEATENCION", GetType(Int32))



    End Sub



    Private Sub Fr_BuscarPersona_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dgv_Buscar.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Buscar.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        If TipoBusqueda = "S" Then
            Me.Dgv_Buscar.MultiSelect = True
        Else
            Me.Dgv_Buscar.MultiSelect = False
        End If

    End Sub

    Public Sub Cargar_Tabla(ByVal TIPO As String)
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        _Tipo = TIPO
        conexion.Open()
        cmde = New SqlCommand("dbo.ListaServicioOT", conexion) With {.CommandType = CommandType.StoredProcedure}
        cmde.Parameters.Add("@Tipo", SqlDbType.NChar).Value = _Tipo
        cmde.Parameters.Add("@IDBASE", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        cmde.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
        cmde.Parameters.Add("@IDOTSERVICIO", SqlDbType.Int).Value = -1

        da = New SqlDataAdapter(cmde)
        Try
            da.Fill(DT_BUSCARSERVICIO)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conexion.Close()
        End Try

        Dim idbase As Integer = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        If idbase = 121 Or idbase = 122 Or idbase = 123 Or idbase = 124 Or idbase = 125 Then
            Me.DGVTBC_CODIGOORDENCLIENTE.Visible = True
        End If
        Me.DGVTBC_CODIGOTIPOUNIDAD.DataSource = tablaunidades
        Me.DGVTBC_CODIGOTIPOUNIDAD.ValueMember = "CODIGOTIPOUNIDAD"
        Me.DGVTBC_CODIGOTIPOUNIDAD.DisplayMember = "ABREVIATURA"

        Dgv_Buscar.SuspendLayout()
        Dgv_Buscar.DataSource = DT_BUSCARSERVICIO
        Dgv_Buscar.ResumeLayout()
        ComboBox_Filtrar.SelectedIndex = 0
        Cursor.Current = Cursors.Default
        ' Cb_Filtrar.Checked = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tb_Descripción.TextChanged
        Timer1.Stop()
        Timer1.Interval = VariablesBase.VariablesBase.TiempoRespuestaBuscador * 2
        Timer1.Start()
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor


        If Cb_Filtrar.Checked Then
            Dim vista As New DataView(DT_BUSCARSERVICIO)
            Dgv_Buscar.SuspendLayout()
            Dgv_Buscar.DataSource = vista
            Dgv_Buscar.ResumeLayout()
            Dim Columna As String = ""
            Dim Texto As String = Tb_Descripción.Text
            Dim pabla() As String
            pabla = Split(Trim(Texto), "  ")
            While pabla.Count > 1
                Texto = Replace(Trim(Texto), "  ", " ")
                pabla = Split(Trim(Texto), "  ")
            End While
            pabla = Split(Trim(Texto), " ")
            Select Case ComboBox_Filtrar.SelectedIndex
                Case 0
                    If IsNumeric(Trim(Tb_Descripción.Text)) Then
                        vista.RowFilter = String.Format("CONVERT(NROORDENSAP, System.String) LIKE '%{0}%'", Tb_Descripción.Text)
                    End If
                Case 1
                    Columna = "OBJETO"
                Case 2
                    If IsNumeric(Trim(Tb_Descripción.Text)) Then
                        vista.RowFilter = String.Format("CONVERT(CODIGOSERVICIO, System.String) LIKE '%{0}%'", Tb_Descripción.Text)
                    End If
                Case 3
                    Columna = "NOMBRESERVICIO"
                Case 4
                    Columna = "NOMBREBASE"
                Case 5
                    Columna = "CODIGOORDENCLIENTE"
            End Select
            Select Case ComboBox_Filtrar.SelectedIndex
                Case 1, 3, 4, 5
                    If pabla.Count > 2 Then
                        vista.RowFilter = String.Format("{0} like '%{1}%' AND {0} like '%{2}%' AND {0} like '%{3}%' ", Columna, pabla(0), pabla(1), pabla(2))
                    ElseIf pabla.Count = 2 Then
                        vista.RowFilter = String.Format("{0} like '%{1}%' AND {0} like '%{2}%'", Columna, pabla(0), pabla(1))
                    ElseIf pabla.Count = 1 Then
                        vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, pabla(0))
                    End If
            End Select
        End If

        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub

    Private Sub Cb_Filtrar_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Cb_Filtrar.CheckedChanged
        Tb_Descripción.Text = ""
        If Cb_Filtrar.Checked = False Then
            Cargar_Tabla(_Tipo)
        End If
    End Sub

    Public TablaServicios As New DataTable

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        'Verificar que el codigo del municipio no este en la lista
        If Dgv_Buscar.SelectedRows.Count > 0 Then
            'tienen seleccionados
            For i = 0 To Dgv_Buscar.SelectedRows.Count - 1
                Dim fila As DataRow
                fila = TablaServicios.NewRow
                fila("IDOTSERVICIO") = Dgv_Buscar.SelectedRows(i).Cells("DGVTBC_IDOTSERVICIO").Value
                fila("IDORDENTRABAJO") = Dgv_Buscar.SelectedRows(i).Cells("DGVTBC_IDORDENTRABAJO").Value
                fila("SERVICIO") = Dgv_Buscar.SelectedRows(i).Cells("DGVTBC_SERVICIO").Value
                fila("NOMBRESERVICIO") = Dgv_Buscar.SelectedRows(i).Cells("DGVTBC_NOMBRESERVICIO").Value
                fila("CODIGOTIPOUNIDAD") = Dgv_Buscar.SelectedRows(i).Cells("DGVTBC_CODIGOTIPOUNIDAD").Value
                fila("CODIGOPOBLACION") = Dgv_Buscar.SelectedRows(i).Cells("DGVTBC_CODIGOPOBLACION").Value
                If IsDBNull(Dgv_Buscar.SelectedRows(i).Cells("DGVTBC_IDCLASEATENCION").Value) = True Then
                    fila("IDCLASEATENCION") = -1
                Else
                    fila("IDCLASEATENCION") = Dgv_Buscar.SelectedRows(i).Cells("DGVTBC_IDCLASEATENCION").Value
                End If
                TablaServicios.Rows.Add(fila)
                DialogResult = DialogResult.OK
                Close()
            Next
        Else
            If MsgBox("No ha selecionado ninguna fila, desea continuar", MsgBoxStyle.YesNo, "Seleccionar fila") = MsgBoxResult.Yes Then
                TablaServicios.Rows.Clear()
                DialogResult = DialogResult.OK
                Close()
            End If
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub Dgv_Buscar_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles Dgv_Buscar.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If Dgv_Buscar.RowHeadersWidth < CInt(size.Width + 20) Then
            Dgv_Buscar.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim bt As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub Dgv_Buscar_DoubleClick(sender As Object, e As EventArgs) Handles Dgv_Buscar.DoubleClick
        OK_Button.PerformClick()
    End Sub


End Class