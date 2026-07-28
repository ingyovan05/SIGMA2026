Public Class Fr_SeleccionarArticulo
    Public idtipo As Integer
    Public idsubtipo As Integer
    Public idarticulo As Integer = 0
    Public nombretipo, nombresubtipo As String

    'llamo el dataset para invocar el procedimiento de gastionar articulos
    Dim ds As New DataSet
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()

    Private Sub Fr_SeleccionarArticulo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Cb_Filtro.Text = "NOMBRE"

        Dgv_Articulos.AutoGenerateColumns = False
        Tb_Tipo.Text = nombretipo
        Tb_Subtipo.Text = nombresubtipo
        ds = bddatos.ModificarArticulos(4, 0, 0, "", "", "", 0, "", 0, "", 0, idtipo, idsubtipo, 0)
        Dgv_Articulos.DataSource = ds.Tables(0).DefaultView
    End Sub

    Private Sub Btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Cancelar.Click

    End Sub

    Private Sub Btn_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Aceptar.Click
        'enviar el id del articulo
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("no ha seleccionado ningun articulo", MsgBoxStyle.Exclamation, "error")
            Exit Sub
        End If
        idarticulo = Dgv_Articulos.CurrentRow.Cells("ID").Value.ToString
        Me.Close()
    End Sub

    Private Sub Dgv_Articulos_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Articulos.CellEnter
        Lb_descripcion.Text = Dgv_Articulos.CurrentRow.Cells("DESCRIPCION").Value.ToString
    End Sub

    Private Sub Cb_Filtrar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Cb_Filtrar.CheckedChanged
        If Tb_Filtro.Text = "" Then
            'renovar filtro y datagrid
            If Cb_Filtrar.Checked = True Then
                ds = bddatos.ModificarArticulos(5, 0, 0, "", "", "", 0, "", 0, "", 0, 0, 0, 0)
                Dgv_Articulos.DataSource = ds.Tables(0).DefaultView
            Else
                ds = bddatos.ModificarArticulos(4, 0, 0, "", "", "", 0, "", 0, "", 0, idtipo, idsubtipo, 0)
                Dgv_Articulos.DataSource = ds.Tables(0).DefaultView
            End If
        End If
    End Sub

    Private Sub Dgv_Articulos_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Articulos.CellDoubleClick
        'enviar el id del articulo
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("no ha seleccionado ningun articulo", MsgBoxStyle.Exclamation, "error")
            Exit Sub
        End If
        idarticulo = Dgv_Articulos.CurrentRow.Cells("ID").Value.ToString
        Me.Close()
    End Sub

    Private Sub Tb_Filtro_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tb_Filtro.TextChanged
        'renovar filtro y datagrid
        Dim idtipotemp, idsubtipotemp, acciontemp As Integer
        Dim nombretemp, descripciontemp As String
        If Cb_Filtrar.Checked = True Then
            idtipotemp = 0
            idsubtipotemp = 0
            acciontemp = 5
        Else
            idtipotemp = idtipo
            idsubtipotemp = idsubtipo
            acciontemp = 4
        End If
        nombretemp = ""
        descripciontemp = ""

        If Cb_Filtro.Text = "NOMBRE" Then
            nombretemp = Tb_Filtro.Text

        ElseIf Cb_Filtro.Text = "Descripción" Then
            descripciontemp = Tb_Filtro.Text

        End If
        ds = bddatos.ModificarArticulos(acciontemp, 0, 0, nombretemp, descripciontemp, "", 0, "", 0, "", 0, idtipo, idsubtipo, 0)
        Dgv_Articulos.DataSource = ds.Tables(0).DefaultView
    End Sub
End Class