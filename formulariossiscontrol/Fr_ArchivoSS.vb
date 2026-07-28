Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO

Public Class Fr_ArchivoSS

    Public IdArchivo As Integer
    Public Tipo As String
    Public IdDocumento As Integer
    Private _guardado As Boolean = False
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private archivo As String
    Private cargoArchivo As Boolean = False
    Private GoogleDrive As New FuncionesGoogle.FuncionesGoogle

    Property Guardado As Boolean
        Get
            Return _guardado
        End Get
        Private Set(value As Boolean)
            _guardado = value
        End Set
    End Property

    Dim dsCargar As New DataSet
    Public Sub CargarTablas()

        dsCargar = bddatos.CargarMaestras(1, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, IdArchivo, 2)

        Cb_AFP.DataSource = dsCargar.Tables(17)
        Cb_AFP.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cb_AFP.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cb_AFP.SelectedIndex = -1

        Cb_EPS.DataSource = dsCargar.Tables(16)
        Cb_EPS.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"
        Cb_EPS.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"

    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        If Guardar_Datos() = True Then
            Close()
        End If
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub

    Private Function Guardar_Datos() As Boolean
        Try
            If ValidarArchivoSS() Then
                GuardarArchivosSS()
            Else
                Guardar_Datos = False
                Exit Function
            End If
            Guardar_Datos = _guardado
        Catch ex As Exception
            Guardar_Datos = False
            MessageBox.Show(ex.Message, "Error al guardar los datos." & Environment.NewLine & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub GuardarArchivosSS()

        Dim Subido As Boolean
        Dim Comando As New SqlClient.SqlCommand("GestionarArchivoSS")
        Comando.CommandType = CommandType.StoredProcedure

        Comando.Parameters.AddWithValue("@Accion", 1)
        Comando.Parameters.AddWithValue("@IdArchivoSS", IdArchivo)
        Comando.Parameters.AddWithValue("@FechaArchivo", Dtp_FechaArchivoSS.Value)
        Comando.Parameters.AddWithValue("@CodigoEntidadAdminAFP", Cb_AFP.SelectedValue)
        Comando.Parameters.AddWithValue("@CodigoEntidadAdminEPS", Cb_EPS.SelectedValue)
        Comando.Parameters.AddWithValue("@TipoModulo", Tipo)
        Comando.Parameters.AddWithValue("@IdDocumento", IdDocumento)
        Comando.Parameters.AddWithValue("@IdUsuario", VariablesBase.VariablesBase.IdPersona)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        conn.Close()
        Me.Close()

        Subido = GoogleDrive.SubirArchivo(6, msgParam.Value, Tipo + "-" + IdDocumento.ToString, Dtp_FechaArchivoSS.Value.Year.ToString, False, Tx_Archivo.Text)

    End Sub

    Private Function ValidarArchivoSS() As Boolean

        If Cb_AFP.SelectedIndex < 0 Then
            MsgBox("Debe seleccionar una AFP", MsgBoxStyle.Information, "SELECCIONAR")
            Cb_AFP.Focus()
            ValidarArchivoSS = False
            Exit Function
        End If

        If Cb_EPS.SelectedIndex < 0 Then
            MsgBox("Debe seleccionar una EPS", MsgBoxStyle.Information, "SELECCIONAR")
            Cb_AFP.Focus()
            ValidarArchivoSS = False
            Exit Function
        End If

        If cargoArchivo = False Then
            MsgBox("Debe Adjuntar un Archivo", MsgBoxStyle.Information, "Archivo")
            ValidarArchivoSS = False
            Exit Function
        End If
        ValidarArchivoSS = True
    End Function


    Private Sub Bt_CargarArchivo_Click(sender As Object, e As EventArgs) Handles Bt_CargarArchivo.Click
        Dim RutaArchivo As String = ""
        Dim OpenFileSubir As New OpenFileDialog
        'Filtrar por archivos PDF

        OpenFileSubir.Filter = "Pdf Files|*.pdf"
        If (OpenFileSubir.ShowDialog() = DialogResult.OK) Then
            'RutaArchivo = OpenFileSubir.FileName
            Tx_Archivo.Text = OpenFileSubir.FileName
            cargoArchivo = True
        Else
            cargoArchivo = False
            Tx_Archivo.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        DialogResult = System.Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
End Class