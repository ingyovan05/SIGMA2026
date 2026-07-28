Imports System.Data.SqlClient
Imports FuncionesBase
Imports System.Windows.Forms

Public Class Fr_GestionarUsuarioCorrespondencia
    Dim dtUsuarioCorrespondencia As New DataTable


    Sub New()
        InitializeComponent()
        AddHandler Tx_LlenarTodo.KeyPress, AddressOf FuncionesBase.FuncionesBase.TextBoxNumericoEntero_KeyPress
    End Sub


    Private Sub Fr_AsociarUsuarioConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaInicial()
        Comportamiento_Predeterminado()
    End Sub


    Private Sub CargaInicial()
        Try
            Dgv_Cantidades.DataSource = Nothing
            Cu_BuscarPersonaCorrespondencia.CargarDatos()
            Cu_BuscarPersonaCorrespondencia.Cb_Persona.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub Comportamiento_Predeterminado()
        Dgv_Cantidades.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Cantidades.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub


    Private Sub Dgv_Cantidades_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_Cantidades.EditingControlShowing
        If Dgv_Cantidades.CurrentCell.ColumnIndex = 3 Then 'Columna CANTIDADLIMITE
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub


    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Char.IsDigit(CChar(CStr(e.KeyChar))) = False Then
            e.Handled = True
        End If
    End Sub


    Private Sub Bt_Cargar_Click(sender As Object, e As EventArgs) Handles Bt_Cargar.Click
        If Cu_BuscarPersonaCorrespondencia.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el usuario del cual requiere cargar las cantidades de correspondencia pendiente.", MsgBoxStyle.Information, "Seleccionar Usuario")
            Exit Sub
        Else
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT * FROM dbo.SC_ListarUsuarioCorrespondencia(@IDUSUARIO)", conexion)
            comando.Parameters.AddWithValue("@IDUSUARIO", Cu_BuscarPersonaCorrespondencia.Cb_Persona.SelectedValue)
            dtUsuarioCorrespondencia.Clear()
            Dim adaptador As New SqlDataAdapter(comando)
            Try
                conexion.Open()
                'adaptador.FillSchema(dtUsuarioCorrespondencia, SchemaType.Source)
                adaptador.Fill(dtUsuarioCorrespondencia)
                conexion.Close()

                For i As Integer = 0 To dtUsuarioCorrespondencia.Rows.Count - 1
                    Select Case dtUsuarioCorrespondencia.Rows(i).Item("TIPOCORRESPONDENCIA")
                        Case "E"
                            dtUsuarioCorrespondencia.Rows(i).Item("TIPOCORRESPONDENCIA") = "Externa"
                        Case "F"
                            dtUsuarioCorrespondencia.Rows(i).Item("TIPOCORRESPONDENCIA") = "Fax"
                        Case "I"
                            dtUsuarioCorrespondencia.Rows(i).Item("TIPOCORRESPONDENCIA") = "Interna"
                    End Select
                    Select Case dtUsuarioCorrespondencia.Rows(i).Item("TIPOPENDIENTE")
                        Case "PAC"
                            dtUsuarioCorrespondencia.Rows(i).Item("TIPOPENDIENTE") = "Pendiente Archivo Central"
                        Case "PSS"
                            dtUsuarioCorrespondencia.Rows(i).Item("TIPOPENDIENTE") = "Pendiente Subir al Servidor"
                    End Select
                Next

                Dgv_Cantidades.DataSource = dtUsuarioCorrespondencia
                Dgv_Cantidades.Columns("IDUSUARIO").Visible = False
                Dgv_Cantidades.Columns("TIPOCORRESPONDENCIA").HeaderText = "Tipo Correspondencia"
                Dgv_Cantidades.Columns("TIPOCORRESPONDENCIA").ReadOnly = True
                Dgv_Cantidades.Columns("TIPOPENDIENTE").HeaderText = "Tipo Pendiente"
                Dgv_Cantidades.Columns("TIPOPENDIENTE").ReadOnly = True
                Dgv_Cantidades.Columns("CANTIDADDOCUMENTOS").HeaderText = "Cantidad Pendientes"
                Dgv_Cantidades.Columns("CANTIDADDOCUMENTOS").ReadOnly = True
                Dgv_Cantidades.Columns("CANTIDADLIMITE").HeaderText = "Cantidad Límite"

                Pn_Filtro.Enabled = False
                Bt_Cancelar.Enabled = True
                Bt_Guardar.Enabled = True
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conexion.Close()
            End Try
        End If
    End Sub


    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If MsgBox("¿Desea aplicar los cambios realizados?", MsgBoxStyle.YesNo, "Realizar cambios") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dgv_Cantidades.DataSource = Nothing
        For i As Integer = 0 To dtUsuarioCorrespondencia.Rows.Count - 1
            Select Case dtUsuarioCorrespondencia.Rows(i).Item("TIPOCORRESPONDENCIA")
                Case "Externa"
                    dtUsuarioCorrespondencia.Rows(i).Item("TIPOCORRESPONDENCIA") = "E"
                Case "Fax"
                    dtUsuarioCorrespondencia.Rows(i).Item("TIPOCORRESPONDENCIA") = "F"
                Case "Interna"
                    dtUsuarioCorrespondencia.Rows(i).Item("TIPOCORRESPONDENCIA") = "I"
            End Select
            Select Case dtUsuarioCorrespondencia.Rows(i).Item("TIPOPENDIENTE")
                Case "Pendiente Archivo Central"
                    dtUsuarioCorrespondencia.Rows(i).Item("TIPOPENDIENTE") = "PAC"
                Case "Pendiente Subir al Servidor"
                    dtUsuarioCorrespondencia.Rows(i).Item("TIPOPENDIENTE") = "PSS"
            End Select
        Next
        '
        ' Retirar columna "Cantidad de Documentos Realizados", innescesaria para guardar las cantidades límite.
        '
        dtUsuarioCorrespondencia.Columns.Remove("CANTIDADDOCUMENTOS")

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("dbo.GestionarSC_UsuarioCorrespondencia", conexion)
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TablaUsuarioCorrespondencia", dtUsuarioCorrespondencia)
        Comando.Parameters.AddWithValue("@ACCION", 0)
        Comando.Parameters.AddWithValue("@IDUSUARIO", Cu_BuscarPersonaCorrespondencia.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDUSUARIOMODIFICA", VariablesBase.VariablesBase.IdPersona)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            Comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try

        If MsgBox("Se actualizaron correctamente los permisos del usuario " + Trim(Cu_BuscarPersonaCorrespondencia.Cb_Persona.Text) + "." + Environment.NewLine _
                  + "¿Desea salir?", MsgBoxStyle.YesNo, "SALIR") = MsgBoxResult.Yes Then
            Close()
        Else
            Pn_Filtro.Enabled = True
            Bt_Guardar.Enabled = False
            Bt_Cancelar.Enabled = False
            dtUsuarioCorrespondencia.Clear()
        End If
    End Sub


    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Pn_Filtro.Enabled = True
        Bt_Cancelar.Enabled = False
        Bt_Guardar.Enabled = False
        dtUsuarioCorrespondencia.Clear()
    End Sub


    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Close()
    End Sub


    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Try
            filas = Cu_BuscarPersonaCorrespondencia.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaCorrespondencia.Tx_TextoCódigo.Text).ToString + "'")
            If filas.Length > 0 Then
                Dim fila As DataRow = filas(0)
                Me.Cu_BuscarPersonaCorrespondencia.Cb_Persona.SelectedValue = fila("IDPERSONA")
            Else
                MsgBox("Esta identificación no esta registrada o no esta asociada a una bodega", MsgBoxStyle.Critical, "No se encuentra")
            End If
        Catch ex As Exception
            Cu_BuscarPersonaCorrespondencia.Tx_TextoCódigo.Text = ""
        End Try
    End Sub


    Private Sub Bt_LLenarTodo_Click(sender As Object, e As EventArgs) Handles Bt_LLenarTodo.Click
        For i As Integer = 0 To dtUsuarioCorrespondencia.Rows.Count - 1
            dtUsuarioCorrespondencia.Rows(i).Item("CANTIDADLIMITE") = FuncionesBase.FuncionesBase.ValorRealInt(Tx_LlenarTodo.Text)
        Next
    End Sub

End Class