Imports System.Drawing
Imports System.Windows.Forms

Public Class Fr_BuscarCentroCosto

    Public IdCentroCosto As Integer
    Public NombreCentroCosto As String

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        'Verificar que el codigo del municipio no este en la lista
        Try
            IdCentroCosto = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(0).Value
            NombreCentroCosto = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(1).Value
        Catch ex As Exception
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End Try

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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

    Private Sub Fr_BuscarCentroCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Dgv_Buscar.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Buscar.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.ComboBox_Filtrar.SelectedIndex = 0
    End Sub
    Public datas2 As New DataSet
    Public datas As New DataSet
    Public cmde As New SqlClient.SqlCommand
    Public da As New SqlClient.SqlDataAdapter

    ''' <summary>
    ''' Esta clase es de muestra para la documentación
    ''' </summary>
    ''' <param name="Editando">Indica si estamos editando (1) o agregando (0), para mostrar en edición el centro asi este inactivo</param>
    ''' <param name="IdCentroCosto">Centro de costos</param>
    ''' <param name="IdBodega">Bodega Actual</param>
    ''' 
    Dim _Editando As Integer
    Dim _IdCentroCosto As Integer
    Dim _IdBodega As Integer

    Public Sub CargarListaCentroCostos(ByVal Editando As Integer, ByVal IdCentroCosto As Integer,
                             ByVal IdBodega As Integer)

        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        sqlconeccion.Open()
        cmde.Parameters.Clear()
        cmde.CommandType = CommandType.StoredProcedure
        cmde.Connection = sqlconeccion
        cmde.CommandText = "dbo.ListarCentroCostos"

        cmde.Parameters.Add("@EDITANDO", SqlDbType.Int, 300).Value = Editando
        cmde.Parameters.Add("@IDCENTROCOSTO", SqlDbType.Int, 300).Value = IdCentroCosto


        Select Case Editando
            Case 0, 1
                cmde.Parameters.Add("@IDBODEGA", SqlDbType.Int, 300).Value = VariablesBase.VariablesBase.IdBodegaActual
            Case 2, 3
                cmde.Parameters.Add("@IDBODEGA", SqlDbType.Int, 300).Value = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        End Select

        da = New SqlClient.SqlDataAdapter(cmde)
        datas = New DataSet()

        da.Fill(datas)
        sqlconeccion.Close()

        Me.Dgv_Buscar.SuspendLayout()
        Me.Dgv_Buscar.DataSource = datas.Tables(0)
        Me.Dgv_Buscar.ResumeLayout()


        For i = 0 To Dgv_Buscar.ColumnCount - 1

            Select Case Dgv_Buscar.Columns(i).Name
                Case "IDCENTROCOSTO"
                    Dgv_Buscar.Columns(i).Width = 40
                    Dgv_Buscar.Columns(i).ToolTipText = "Id"
                    Dgv_Buscar.Columns(i).HeaderText = "Id"
                Case "SUBCENTRO"
                    Dgv_Buscar.Columns(i).Width = 150
                    Dgv_Buscar.Columns(i).ToolTipText = "Código"
                    Dgv_Buscar.Columns(i).HeaderText = "Código"
                Case "NOMBRE"
                    Dgv_Buscar.Columns(i).Width = 450
                    Dgv_Buscar.Columns(i).ToolTipText = "Nombre"
                    Dgv_Buscar.Columns(i).HeaderText = "Nombre"
                Case "ACTIVO"
                    Dgv_Buscar.Columns(i).Width = 30
                    Dgv_Buscar.Columns(i).ToolTipText = "Activo"
                    Dgv_Buscar.Columns(i).HeaderText = "Activo"

            End Select
        Next

        _Editando = Editando
        _IdCentroCosto = IdCentroCosto
        _IdBodega = IdBodega
        CentroCostosBase()

    End Sub

    Private Sub Dgv_Buscar_CellMouseDoubleClick(sender As Object, e As Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv_Buscar.CellMouseDoubleClick
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            'Verificar que el codigo del municipio no este en la lista
            Try
                IdCentroCosto = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(0).Value
                NombreCentroCosto = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(1).Value
            Catch ex As Exception
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            End Try

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tb_Descripción.TextChanged
        If Cb_Filtrar.Checked = True Then
            Dim vista As New DataView(datas.Tables(0))
            Me.Dgv_Buscar.SuspendLayout()
            Me.Dgv_Buscar.DataSource = vista
            Me.Dgv_Buscar.ResumeLayout()
            Dim Columna As String = ""
            Dim Texto As String = Me.Tb_Descripción.Text
            Dim pabla() As String
            pabla = Split(Trim(Texto), "  ")
            While pabla.Count > 1
                Texto = Replace(Trim(Texto), "  ", " ")
                pabla = Split(Trim(Texto), "  ")
            End While
            pabla = Split(Trim(Texto), " ")
            Select Case Me.ComboBox_Filtrar.SelectedIndex
                Case 0
                    Columna = "SUBCENTRO"
                Case 1
                    Columna = "NOMBRE"
            End Select


            If pabla.Count > 2 Then
                vista.RowFilter = String.Format("{0} like '%{1}%' AND {0} like '%{2}%' AND {0} like '%{3}%' ", Columna, pabla(0), pabla(1), pabla(2))
            ElseIf pabla.Count = 2 Then
                vista.RowFilter = String.Format("{0} like '%{1}%' AND {0} like '%{2}%'", Columna, pabla(0), pabla(1))
            ElseIf pabla.Count = 1 Then
                vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, pabla(0))
            End If

        End If
    End Sub

    Private Sub Cb_Filtrar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Filtrar.CheckedChanged
        Me.Tb_Descripción.Text = ""
        If Me.Cb_Filtrar.Checked = False Then
            CargarListaCentroCostos(_Editando, _IdCentroCosto, _IdBodega)
        End If
    End Sub



    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Dgv_Buscar.CellFormatting


        For j As Integer = 0 To Dgv_Buscar.Rows.Count - 1

            Dim NombreCentroOP As String = ""
            Dim a As Integer = CInt(Int(datas2.Tables(0).Rows(0).Item(0).ToString))
            If Dgv_Buscar.Rows(j).Cells(0).Value = a Then
                NombreCentroOP = Me.Dgv_Buscar.Rows(j).Cells(1).Value.ToString
                Dim subst As String = NombreCentroOP.Substring(0, 3)
                For z As Integer = 0 To Dgv_Buscar.Rows.Count - 1
                    If Dgv_Buscar.Rows(z).Cells(1).Value.ToString.Contains(subst) Then


                        Dgv_Buscar.Rows(z).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192)


                    End If
                Next

            End If



        Next

    End Sub

    Public Sub CentroCostosBase()
        Dim sqlConexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        sqlConexion.Open()
        cmde.Parameters.Clear()
        cmde.CommandType = CommandType.StoredProcedure
        cmde.Connection = sqlConexion
        cmde.CommandText = "dbo.BuscarCentroCostoxDependencia"
        cmde.Parameters.Add("@IDBODEGA", SqlDbType.Int, 300).Value = VariablesBase.VariablesBase.IddependenciaSiscontrolActual

        Try
            da = New SqlClient.SqlDataAdapter(cmde)
            datas2 = New DataSet()
            da.Fill(datas2)
            sqlConexion.Close()

        Catch ex As Exception

        End Try

    End Sub


End Class