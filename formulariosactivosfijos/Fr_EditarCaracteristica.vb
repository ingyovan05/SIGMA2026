Public Class Fr_EditarCaracteristica
    Public edicion As Boolean = False
    Public nombretipo As String
    Public nombresubtipo As String
    Public idcaracteristica As Integer
    Public idsubtipo As Integer
    Public idtipocaracteristica As Integer
    Public actualizado As Boolean = False
    Public irrepetible As String = "N"

    'declaro un string para mensajes de error, un dataset y la clase para los llamados a procedimientos
    Dim ds As New DataSet
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()

    Private Sub Fr_EditarCaracteristica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cargar combobox con tipos de datos
        Try
            ds = bddatos.ModificarCaracteristicas(1, 0, 0, 0, 0, "", "", 0, 0, False, "", 0, Date.Now, "")
            Cb_tipo.DataSource = ds.Tables(0).DefaultView
            Cb_tipo.DisplayMember = "DESCRIPCION"
            Cb_tipo.ValueMember = "IDTIPOCARACTERISTICA"

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        'revisar si es una caracteristica nueva o se va a editar una existente y llenar campos
        If edicion = True Then
            'llenar campos
            Btn_Eliminar.Enabled = True
            Cb_tipo.Enabled = False
            Try
                ds = bddatos.ModificarCaracteristicas(3, 0, 0, idcaracteristica, 0, "", "", 0, 0, False, "", 0, Date.Now, "")
                Lbl_Tipo.Text = ds.Tables(0).Rows(0)("TIPOARTICULO")
                Lbl_subtipo.Text = ds.Tables(0).Rows(0)("SUBTIPOARTICULO")
                idsubtipo = ds.Tables(0).Rows(0)("IDSUBTIPOARTICULO")
                Tb_Nombre.Text = ds.Tables(0).Rows(0)("NOMBRECARACTERISTICA")
                Tb_Descripcion.Text = ds.Tables(0).Rows(0)("DESCRIPCIONCARACTERISTICA")
                Cb_tipo.SelectedValue = ds.Tables(0).Rows(0)("IDTIPOVALOR")
                If ds.Tables(0).Rows(0)("IRREPETIBLE") = "S" Then
                    Cbx_Irrepetible.Checked = True
                Else
                    Cbx_Irrepetible.Checked = False
                End If
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        Else
            Lbl_Tipo.Text = nombretipo
            Lbl_subtipo.Text = nombresubtipo
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'revisar campos vacios
        If Tb_Nombre.Text = "" Or Tb_Descripcion.Text = "" Then
            MsgBox("No pueden haber campos sin llenar o seleccionar", MsgBoxStyle.Exclamation, "Falta llenar campos")
            Return
        End If
        'establezco campo irrepetible
        If Cbx_Irrepetible.Checked = True Then
            irrepetible = "S"
        Else
            irrepetible = "N"
        End If
        'determino si estoy editando o creando
        If edicion = True Then
            'edicion de elemento
            Try
                ds = bddatos.ModificarCaracteristicas(5, 0, 0, idcaracteristica, 0, UCase(Tb_Nombre.Text), UCase(Tb_Descripcion.Text), 0, 0, False, "", 0, Date.Now, irrepetible)
                Dim resultado As VariantType
                resultado = MsgBox("Caracteristica modificada correctamente.", MsgBoxStyle.Information, "Caracteristica Modificada")
                actualizado = True
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try

        Else
            'creacion de un nuevo registro
            Try
                ds = bddatos.ModificarCaracteristicas(4, 0, idsubtipo, 0, 0, UCase(Tb_Nombre.Text), UCase(Tb_Descripcion.Text), 0, Cb_tipo.SelectedValue, False, "", 0, Date.Now, irrepetible)
                Dim resultado As VariantType
                resultado = MsgBox("Caracteristica creada, Desea crear mas caracteristicas para el subtipo: " + Lbl_subtipo.Text + "?", MsgBoxStyle.YesNo, "Caracteristica Creada")
                actualizado = True
                If resultado = vbNo Then
                    Me.Close()
                Else
                    Tb_Descripcion.Text = ""
                    Tb_Nombre.Text = ""
                End If
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try

        End If
    End Sub

    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click
        Dim confirmacion As VariantType
        confirmacion = MsgBox("ADVERTENCIA, si elimina este tipo de caracteristica se borraran los valores de ESTA caracteristica de TODOS los articulos asociados a este subtipo, esta seguro que desea continuar?", MsgBoxStyle.YesNo, "ADVERTENCIA")
        If confirmacion = vbYes Then
            Try
                ds = bddatos.ModificarCaracteristicas(6, 0, 0, idcaracteristica, 0, "", "", 0, 0, False, "", 0, Date.Now, "")
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
            MsgBox("CARACTERISTICA ELIMINADA", vbOKOnly, "Caracteristica Eliminada")
            Me.Close()
            actualizado = True
        Else

        End If
    End Sub
End Class