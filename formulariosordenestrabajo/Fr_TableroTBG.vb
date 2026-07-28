Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms

Public Class Fr_TableroTBG
    Public IdTBG As Integer
    Public TipoEdicion As TiposEdicion
    Public Enum TiposEdicion
        Crear
        Editar
        Ver
    End Enum
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private filaTBG As DataRow
    Private dtPeriodo As New DataTable
    Private archivo As Byte()
    Private cargoArchivo As Boolean = False
    Const tamannoMaximoArchivo As Long = 10485760 '10 MB
    Private _guardado As Boolean = False
    ReadOnly Property Guardado As Boolean
        Get
            Return _guardado
        End Get
    End Property

    Private Sub Fr_GestionarTBG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtPeriodo.Columns.Add("NUMEROMES")
        dtPeriodo.Columns.Add("NOMBREMES")
        dtPeriodo.Rows.Add(1, "Enero")
        dtPeriodo.Rows.Add(2, "Febrero")
        dtPeriodo.Rows.Add(3, "Marzo")
        dtPeriodo.Rows.Add(4, "Abril")
        dtPeriodo.Rows.Add(5, "Mayo")
        dtPeriodo.Rows.Add(6, "Junio")
        dtPeriodo.Rows.Add(7, "Julio")
        dtPeriodo.Rows.Add(8, "Agosto")
        dtPeriodo.Rows.Add(9, "Septiembre")
        dtPeriodo.Rows.Add(10, "Octubre")
        dtPeriodo.Rows.Add(11, "Noviembre")
        dtPeriodo.Rows.Add(12, "Diciembre")
        Cb_PeriodoMedicion.DataSource = dtPeriodo
        Cb_PeriodoMedicion.SelectedValue = Date.Today.Month

        comando = New SqlCommand("dbo.TBG_DatosTablero", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        comando.Parameters.Add("@IdTableroTBG", SqlDbType.Int)
        If TipoEdicion = TiposEdicion.Crear Then
            comando.Parameters("@Accion").Value = 1
            comando.Parameters("@IdTableroTBG").Value = DBNull.Value
        Else
            comando.Parameters("@Accion").Value = 2
            comando.Parameters("@IdTableroTBG").Value = IdTBG
        End If
        adaptador = New SqlDataAdapter(comando)
        Dim dsTBG As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsTBG)
            conexion.Close()
            If dsTBG.Tables.Count > 0 Then
                If TipoEdicion <> TiposEdicion.Crear Then
                    If dsTBG.Tables(0).Rows.Count > 0 Then
                        filaTBG = dsTBG.Tables(0).Rows(0)
                        If Not IsDBNull(filaTBG("ARCHIVOTBG")) Then
                            archivo = filaTBG("ARCHIVOTBG")
                            Tx_Archivo.Text = filaTBG("NOMBREARCHIVO")
                        End If
                        If Not IsDBNull(filaTBG("FECHAMEDICION")) Then
                            Dtp_FechaMedicion.Value = filaTBG("FECHAMEDICION")
                        End If
                        If Not IsDBNull(filaTBG("PERIODOMEDICION")) Then
                            Cb_PeriodoMedicion.SelectedValue = filaTBG("PERIODOMEDICION")
                        End If
                        If Not IsDBNull(filaTBG("FECHAPRESENTACION")) Then
                            Dtp_FechaPresentacion.Value = filaTBG("FECHAPRESENTACION")
                        End If
                    End If
                    If TipoEdicion = TiposEdicion.Ver Then
                        Bt_CargarArchivo.Enabled = False
                        Dtp_FechaMedicion.Enabled = False
                        Cb_PeriodoMedicion.Enabled = False
                        Dtp_FechaPresentacion.Enabled = False

                        Bt_Aceptar.Visible = False
                    End If
                End If
            Else
                MessageBox.Show("Ocurrió un error al cargar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("Ocurrió un error al cargar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Fr_GestionarTBG_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If TipoEdicion = TiposEdicion.Ver Then
            Bt_Cancelar.Select()
        Else
            Bt_CargarArchivo.Select()
        End If
    End Sub


    Private Sub Tx_Archivo_TextChanged(sender As Object, e As EventArgs) Handles Tx_Archivo.TextChanged
        If Tx_Archivo.Text.Length > 0 Then
            Bt_VerArchivo.Enabled = True
            If TipoEdicion <> TiposEdicion.Ver Then
                Bt_QuitarArchivo.Enabled = True
            End If
        Else
            Bt_VerArchivo.Enabled = False
            Bt_QuitarArchivo.Enabled = False
        End If
    End Sub

    Private Sub Bt_CargarArchivo_Click(sender As Object, e As EventArgs) Handles Bt_CargarArchivo.Click
        If Ofd_ArchivoTBG.ShowDialog() = DialogResult.OK Then
            Dim archivoBinario As Byte() = File.ReadAllBytes(Ofd_ArchivoTBG.FileName)
            If archivoBinario.Length <= tamannoMaximoArchivo Then 'Si el archivo tiene tamaño inferior al tamaño máximo admitido.
                archivo = archivoBinario
                Tx_Archivo.Text = Path.GetFileName(Ofd_ArchivoTBG.FileName)
                cargoArchivo = True
            Else
                MessageBox.Show("El tamaño del archivo seleccionado supera los 10 MB. Por favor elija un archivo de menor tamaño.", "Archivo muy grande", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub Bt_VerArchivo_Click(sender As Object, e As EventArgs) Handles Bt_VerArchivo.Click
        Dim archivoTemp As String = VariablesBase.VariablesBase._path & "\" & "temp" & Path.GetExtension(Tx_Archivo.Text)
        If File.Exists(archivoTemp) Then
            Try
                File.Delete(archivoTemp)
            Catch ex As Exception

            End Try
        End If
        File.WriteAllBytes(archivoTemp, archivo)
        Try
            Process.Start(archivoTemp)
        Catch
            MessageBox.Show("No se pudo abrir el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Bt_QuitarArchivo_Click(sender As Object, e As EventArgs) Handles Bt_QuitarArchivo.Click
        archivo = Nothing
        cargoArchivo = False
        Tx_Archivo.Text = ""
    End Sub


    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Validar() Then
            Guardar()
            If Guardado Then
                Me.Close()
            End If
        End If
    End Sub

    Private Function Validar()
        Return True
    End Function

    Private Sub Guardar()
        comando = New SqlCommand("dbo.GestionarTBG_Tablero", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        comando.Parameters.Add("@IdTableroTBG", SqlDbType.Int)
        comando.Parameters.Add("@IdBase", SqlDbType.Int)
        comando.Parameters.Add("@ArchivoTBG", SqlDbType.VarBinary)
        comando.Parameters.Add("@NombreArchivo", SqlDbType.VarChar, 100)
        comando.Parameters.Add("@FechaMedicion", SqlDbType.Date)
        comando.Parameters.Add("@PeriodoMedicion", SqlDbType.TinyInt)
        comando.Parameters.Add("@FechaPresentacion", SqlDbType.Date)
        comando.Parameters.Add("@IdUsuario", SqlDbType.Int)
        comando.Parameters.Add(New SqlParameter("@Mensaje", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
        If TipoEdicion = TiposEdicion.Crear Then
            comando.Parameters("@Accion").Value = 1
            comando.Parameters("@IdTableroTBG").Value = DBNull.Value
        Else
            comando.Parameters("@Accion").Value = 2
            comando.Parameters("@IdTableroTBG").Value = IdTBG
        End If
        comando.Parameters("@IdBase").Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual

        If cargoArchivo Then
            comando.Parameters("@ArchivoTBG").Value = archivo
            comando.Parameters("@NombreArchivo").Value = Tx_Archivo.Text
        ElseIf archivo IsNot Nothing Then
            comando.Parameters("@ArchivoTBG").Value = DBNull.Value
            comando.Parameters("@NombreArchivo").Value = ""
        Else
            comando.Parameters("@ArchivoTBG").Value = DBNull.Value
            comando.Parameters("@NombreArchivo").Value = DBNull.Value
        End If
        comando.Parameters("@FechaMedicion").Value = Dtp_FechaMedicion.Value
        comando.Parameters("@PeriodoMedicion").Value = Cb_PeriodoMedicion.SelectedValue
        If Dtp_FechaPresentacion.Checked Then
            comando.Parameters("@FechaPresentacion").Value = Dtp_FechaMedicion.Value
        Else
            comando.Parameters("@FechaPresentacion").Value = DBNull.Value
        End If
        comando.Parameters("@IdUsuario").Value = VariablesBase.VariablesBase.IdPersona
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
            If comando.Parameters("@Mensaje").Value Then
                Select Case comando.Parameters("@Mensaje").Value
                    Case 1
                        _guardado = True
                        MessageBox.Show("Se guardó correctamente.", "Tablero TBG", MessageBoxButtons.OK)
                    Case 2
                        MessageBox.Show("Ocurrió un error al guardar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select
            Else
                MessageBox.Show("Ocurrió un error al guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("Ocurrió un error al guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        If TipoEdicion <> TiposEdicion.Ver AndAlso Not Guardado Then
            If MessageBox.Show("¿Desea salir sin guardar cambios?", "Salir", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        Else
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

End Class
