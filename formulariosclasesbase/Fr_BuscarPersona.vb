Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.SqlClient

Public Class Fr_BuscarPersona
    Public _Tipo As String
    Public idpersonaincluir As Integer = -1
    Public IdPersona As Integer
    Public Identificacion As String = ""
    Public NombrePersona As String = ""
    Public CodigoContrato As Integer
    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private cmde As SqlCommand
    Private da As SqlDataAdapter
    Private FechaReporteDiario As Date
    Private DT_BUSCARPERSONA As New DataTable


    Private Sub Fr_BuscarPersona_Load(sender As Object, e As EventArgs) Handles Me.Load
        Bt_AgregarPersona.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_AgregarPersona.Tag)
        Dgv_Buscar.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Buscar.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub

    Public Sub Cargar_Tabla(ByVal TIPO As String, Optional IdPersonaIncluirCarga As Integer = -1)
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        _Tipo = TIPO
        conexion.Open()
        cmde = New SqlCommand("dbo.ListaTercerosFiltrada", conexion) With {.CommandType = CommandType.StoredProcedure}
        cmde.Parameters.Add("@Tipo", SqlDbType.NChar).Value = _Tipo
        cmde.Parameters.Add("@IdbodegaActual", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBodegaActual
        cmde.Parameters.Add("@IddependenciaSiscontrol", SqlDbType.Int).Value = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        cmde.Parameters.Add("@IdBaseSiscontrolActual", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        cmde.Parameters.Add("@IdPersonaIncluirCarga", SqlDbType.Int).Value = IdPersonaIncluirCarga
        da = New SqlDataAdapter(cmde)
        Try
            da.Fill(DT_BUSCARPERSONA)
        Catch ex As Exception
            Throw ex
        Finally
            conexion.Close()
        End Try
        For i = 0 To Dgv_Buscar.ColumnCount - 1
            Dgv_Buscar.Columns(i).Visible = True
            Select Case TIPO
                Case "PCB", "PCI", "PABASE"  'Con contrato"
                    Select Case Dgv_Buscar.Columns(i).Name
                        Case "DGVTBC_IDPERSONA"
                            Dgv_Buscar.Columns(i).Width = 80
                        Case "DGVTBC_IDENTIFICACION"
                            Dgv_Buscar.Columns(i).Width = 130
                        Case "DGVTBC_NOMBRECOMPLETO"
                            Dgv_Buscar.Columns(i).Width = 300
                        Case "DGVTBC_CODIGOCONTRATO"
                            Dgv_Buscar.Columns(i).Width = 80
                            'Case "DGVTBC_ESTADOCONTRATO"
                            '    Dgv_Buscar.Columns(i).Width = 80
                        Case Else
                            Dgv_Buscar.Columns(i).Visible = False
                    End Select
                Case "P", "PSC", "PAP", "PNUS", "PABO", "PUABO", "PADEP", "PUACB", "PHVB", "PHVBSG" 'Sin contrato"
                    Select Case Dgv_Buscar.Columns(i).Name
                        Case "DGVTBC_IDPERSONA"
                            Dgv_Buscar.Columns(i).Width = 80
                        Case "DGVTBC_IDENTIFICACION"
                            Dgv_Buscar.Columns(i).Width = 130
                        Case "DGVTBC_NOMBRECOMPLETO"
                            Dgv_Buscar.Columns(i).Width = 400
                        Case Else
                            Dgv_Buscar.Columns(i).Visible = False
                    End Select
            End Select
        Next
        Dgv_Buscar.SuspendLayout()
        Dgv_Buscar.DataSource = DT_BUSCARPERSONA
        Dgv_Buscar.ResumeLayout()
        ComboBox_Filtrar.SelectedIndex = 0
        Cursor.Current = Cursors.Default
        ' Cb_Filtrar.Checked = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Tb_Descripción.TextChanged
        If Cb_Filtrar.Checked Then
            Dim vista As New DataView(DT_BUSCARPERSONA)
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
                    Columna = "NOMBRECOMPLETO"
                    If pabla.Count > 2 Then
                        vista.RowFilter = String.Format("{0} like '%{1}%' AND {0} like '%{2}%' AND {0} like '%{3}%' ", Columna, pabla(0), pabla(1), pabla(2))
                    ElseIf pabla.Count = 2 Then
                        vista.RowFilter = String.Format("{0} like '%{1}%' AND {0} like '%{2}%'", Columna, pabla(0), pabla(1))
                    ElseIf pabla.Count = 1 Then
                        vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, pabla(0))
                    End If
                    Dim Columna2 As String = "NOMBRESINTILDES"
                    For i As Integer = 0 To pabla.Length - 1
                        pabla(i) = QuitarDiacriticos(pabla(i))
                    Next
                    If pabla.Count > 2 Then
                        vista.RowFilter += String.Format("OR ({0} like '%{1}%' AND {0} like '%{2}%' AND {0} like '%{3}%') ", Columna2, pabla(0), pabla(1), pabla(2))
                    ElseIf pabla.Count = 2 Then
                        vista.RowFilter += String.Format("OR ({0} like '%{1}%' AND {0} like '%{2}%')", Columna2, pabla(0), pabla(1))
                    ElseIf pabla.Count = 1 Then
                        vista.RowFilter += String.Format("OR ({0} like '%{1}%')", Columna2, pabla(0))
                    End If
                Case 1
                    Columna = "IDENTIFICACION"
                    vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
                Case 2
                    Columna = "CODIGOCONTRATO"
                    Try
                        vista.RowFilter = String.Format("{0} = {1}", Columna, Trim(Me.Tb_Descripción.Text))
                    Catch ex As Exception
                    End Try
            End Select

        End If
    End Sub

    Private Function QuitarDiacriticos(palabra As String) As String
        If Trim(palabra.Length) > 0 Then
            Dim pa2 As String = palabra.ToLower()
            If System.Text.RegularExpressions.Regex.IsMatch(pa2, "[áéíóúü]") Then
                'pa2 = pa2.Replace("Á", "A") 'U+00C1
                pa2 = pa2.Replace("á", "a") 'U+00E1
                'pa2 = pa2.Replace("É", "E") 'U+00C9
                pa2 = pa2.Replace("é", "e") 'U+00E9
                'pa2 = pa2.Replace("Í", "I") 'U+00CD
                pa2 = pa2.Replace("í", "i") 'U+00ED
                'pa2 = pa2.Replace("Ó", "O") 'U+00D3
                pa2 = pa2.Replace("ó", "o") 'U+00F3
                'pa2 = pa2.Replace("Ú", "U") 'U+00DA
                pa2 = pa2.Replace("ú", "u") 'U+00FA
                'pa2 = pa2.Replace("Ü", "U") 'U+00DC
                pa2 = pa2.Replace("ü", "u") 'U+00FC
                Return pa2
            End If
        End If
        Return palabra
    End Function

    Private Sub Cb_Filtrar_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Cb_Filtrar.CheckedChanged
        Tb_Descripción.Text = ""
        If Cb_Filtrar.Checked = False Then
            Cargar_Tabla(_Tipo)
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        'Verificar que el codigo del municipio no este en la lista
        Try
            IdPersona = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("DGVTBC_IDPERSONA").Value
        Catch
        End Try
        Try
            Identificacion = Trim(Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("DGVTBC_IDENTIFICACION").Value)
        Catch
        End Try
        Try
            NombrePersona = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("DGVTBC_NOMBRECOMPLETO").Value
        Catch
        End Try
        Try
            CodigoContrato = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("DGVTBC_CODIGOCONTRATO").Value
        Catch
        End Try
        DialogResult = DialogResult.OK
        Close()
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

    Private Sub Bt_AgregarPersona_Click(sender As Object, e As EventArgs) Handles Bt_AgregarPersona.Click
        Dim FrAgregarPersona As New Fr_AgregarPersona
        FrAgregarPersona.ShowDialog()
        Cargar_Tabla(_Tipo)
    End Sub

End Class 'Fr_BuscarPersona