Imports System.Drawing

Public Class Fr_BuscarProveedor


    Dim adap As New DatosProveedores.Ds_ProveedorTableAdapters.BUSCARPROVEEDORTableAdapter
    Dim DsProveedor As New DatosProveedores.Ds_Proveedor

    Private Sub Tb_Descripción_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Tb_Descripción.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Try
                    IdProveedor = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(0).Value
                Catch ex As Exception
                End Try
                Try
                    Identificacion = Trim(Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(1).Value)
                Catch ex As Exception

                End Try
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tb_Descripción.TextChanged
        If Cb_Filtrar.Checked = True Then
            Dim vista As New DataView(Me.DsProveedor.BUSCARPROVEEDOR)
            Me.Dgv_Buscar.SuspendLayout()
            Me.Dgv_Buscar.DataSource = vista
            Me.Dgv_Buscar.ResumeLayout()
            Dim Columna As String = ""
            Select Case Me.ComboBox_Filtrar.SelectedIndex
                Case 0
                    Columna = "NOMBRECOMPLETO"
                Case 1
                    Columna = "IDENTIFICACION"
                Case 2
                    Columna = "NOMENCLATURA"
            End Select
            vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
        End If
    End Sub

    Public Sub Cargar_Tabla()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        adap.Fill(DsProveedor.BUSCARPROVEEDOR)
        Me.Dgv_Buscar.DataSource = DsProveedor.BUSCARPROVEEDOR
        ComboBox_Filtrar.SelectedIndex = 0
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Cb_Filtrar.Checked = True
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
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

    Private Sub Fr_BuscarProveedor_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Me.Tb_Descripción.Focus()
    End Sub

    Private Sub Fr_BuscarPersona_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Dgv_Buscar.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Buscar.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub

    Private Sub Dgv_Buscar_DoubleClick(sender As System.Object, e As System.EventArgs) Handles Dgv_Buscar.DoubleClick
        Me.OK_Button.PerformClick()
    End Sub


    Public IdProveedor As Integer
    Public Identificacion As String = ""

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Verificar que el codigo del municipio no este en la lista
        Try
            IdProveedor = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(0).Value
        Catch ex As Exception
        End Try
        Try
            Identificacion = Trim(Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells(1).Value)
        Catch ex As Exception

        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class