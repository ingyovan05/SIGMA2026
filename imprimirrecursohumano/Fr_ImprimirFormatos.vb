Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_ImprimirFormatos
    'Public TIPOIMPRESION As String
    Public CODIGOTIPO As Short
    Public IDBASE As Integer
    Public IDPERSONA As Integer
    Public IDCONTRATO As Integer
    Private dtImprimirFormatos As New DataTable
    Private dtTipoCargo As New DataTable

    Private Sub Fr_ImprimirFormatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub cargarformatos()
        Dgv_Formatos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Formatos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ListarImprimirFormatos", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@CODIGOTIPO", CODIGOTIPO)
        comando.Parameters.AddWithValue("@IDBASE", IDBASE)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsImprimirFormatos As New DataSet
        Try
            'conexion.Open()
            adaptador.Fill(dsImprimirFormatos)
            conexion.Close()
            dtImprimirFormatos = dsImprimirFormatos.Tables(0)
            dtTipoCargo = dsImprimirFormatos.Tables(1)

            Dgv_Formatos.DataSource = dtImprimirFormatos

            Dim tamaño As Size
            Dim dgrow As DataGridViewRow = Dgv_Formatos.Rows(0)
            tamaño.Height = (dtImprimirFormatos.Rows.Count * dgrow.Height) + 130
            tamaño.Width = Me.Width
            Me.Size = tamaño

            ComboBox_Cargo_Desempeña.DataSource = dtTipoCargo
            ComboBox_Cargo_Desempeña.ValueMember = "CODIGOTIPOCARGO"
            ComboBox_Cargo_Desempeña.DisplayMember = "NOMBRETIPOCARGO"
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Bt_Imprimir_Click(sender As Object, e As EventArgs) Handles Bt_Imprimir.Click
        Dim Array As New ArrayList
        Try
            For i = 0 To Dgv_Formatos.RowCount - 1
                Dim IdDocumento As Integer
                Dim _Imprimir As String
                IdDocumento = Dgv_Formatos.Rows(i).Cells("IDDOCUMENTOIMPRIMIR").Value
                _Imprimir = Dgv_Formatos.Rows(i).Cells("IMPRIMIR").Value
                If _Imprimir = "S" Then
                    Array.Add(IdDocumento)
                End If
            Next
            Dim Cl_Imprimir As New Cl_Impresión

            Cl_Imprimir.Idpersona = IDPERSONA
            Cl_Imprimir.IdContrato = IDCONTRATO
            Cl_Imprimir.IdBase = IDBASE
            Cl_Imprimir.IdCargoPropuesto = ComboBox_Cargo_Desempeña.SelectedValue
            Cl_Imprimir.NombreCargoPropuesto = ComboBox_Cargo_Desempeña.Text
            Cl_Imprimir.FormatosImprimir(Array, Ck_VistaPrevia.Checked)
            Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Close()
        End Try
    End Sub

    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Close()
    End Sub

    Private Sub Bt_Seleccionar_Click(sender As Object, e As EventArgs) Handles Bt_Seleccionar.Click
        For i = 0 To Dgv_Formatos.RowCount - 1
            Dgv_Formatos.Rows(i).Cells("IMPRIMIR").Value = "S"
        Next
    End Sub

    Private Sub Bt_Desseleccionar_Click(sender As Object, e As EventArgs) Handles Bt_Desseleccionar.Click
        For i = 0 To Dgv_Formatos.RowCount - 1
            Dgv_Formatos.Rows(i).Cells("IMPRIMIR").Value = "N"
        Next
    End Sub

    Public Sub DesactivarDocumento(ByVal IDDOCUMENTOIMPRIMIR As Integer)
        For i = 0 To Dgv_Formatos.RowCount - 1
            If Dgv_Formatos.Rows(i).Cells("IDDOCUMENTOIMPRIMIR").Value = IDDOCUMENTOIMPRIMIR Then
                Dgv_Formatos.Rows(i).Cells("IMPRIMIR").Value = "N"
            End If
        Next
    End Sub

    Public Sub ActivarDocumento(ByVal IDDOCUMENTOIMPRIMIR As Integer)
        For i = 0 To Dgv_Formatos.RowCount - 1
            If Dgv_Formatos.Rows(i).Cells("IDDOCUMENTOIMPRIMIR").Value = IDDOCUMENTOIMPRIMIR Then
                Dgv_Formatos.Rows(i).Cells("IMPRIMIR").Value = "S"
            End If
        Next
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles Dgv_Formatos.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Font)
        If Dgv_Formatos.RowHeadersWidth < CInt(size.Width + 20) Then
            Dgv_Formatos.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim bt As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

End Class