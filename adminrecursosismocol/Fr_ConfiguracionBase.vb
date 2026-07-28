Imports System.Data.SqlClient

Public Class Fr_ConfiguracionBase
    Private filaConf As DataRow
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private accion As TipoAccion
    Private Enum TipoAccion
        Agregar = 1
        Modificar = 2
    End Enum

    Private Sub Fr_ConfiguracionBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        If VariablesBase.VariablesBase.IdBaseSiscontrolActual = 0 Then 'BUC PRINCIPAL
            VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = 1 'ADMINISTRACION
        Else
            VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        End If
        Cu_CiudadContratacion.CargarDatos()
        Cu_BPCoordinadorQAQC.CargarDatos()
        Cu_BPCoordinadorHSE.CargarDatos()
        Cu_BPMedicoBase.CargarDatos()
        Cu_BPResidente.CargarDatos()
        Cu_BPJefePersonal.CargarDatos()
        Cu_BPAdministrador.CargarDatos()
        Cu_BPJefeBodega.CargarDatos()
        comando = New SqlCommand("SELECT * FROM DatosConfiguracionBase(@IDBASE)", conexion)
        comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtConf As New DataTable
        Try
            adaptador.Fill(dtConf)
            conexion.Close()
            If dtConf.Rows.Count > 0 Then
                accion = TipoAccion.Modificar
                filaConf = dtConf.Rows(0)
                If Not IsDBNull(filaConf("CODIGOCONTRATOISMOCOL")) Then
                    Tx_CodigoContrato.Text = filaConf("CODIGOCONTRATOISMOCOL")
                End If
                If Not IsDBNull(filaConf("IDCENTROCOSTO")) Then
                    Cu_CentroCostoBase.IdCentroCosto = filaConf("IDCENTROCOSTO")
                    Cu_CentroCostoBase.CargarCentro()
                End If
                Cu_CiudadContratacion.Cb_Ciudad.SelectedValue = filaConf("CODIGOCIUDADCONTRATACION")
                If Not IsDBNull(filaConf("IDPERSONACOORDINADORQAQC")) Then
                    Cu_BPCoordinadorQAQC.Cb_Persona.SelectedValue = filaConf("IDPERSONACOORDINADORQAQC")
                    Cu_BPCoordinadorQAQC.CargarCajaTexto()
                Else
                    Cu_BPCoordinadorQAQC.Cb_Persona.SelectedIndex = -1
                End If
                If Not IsDBNull(filaConf("IDPERSONACOORDINADORHSEC")) Then
                    Cu_BPCoordinadorHSE.Cb_Persona.SelectedValue = filaConf("IDPERSONACOORDINADORHSEC")
                    Cu_BPCoordinadorHSE.CargarCajaTexto()
                Else
                    Cu_BPCoordinadorHSE.Cb_Persona.SelectedIndex = -1
                End If
                If Not IsDBNull(filaConf("IDPERSONAMEDICO")) Then
                    Cu_BPMedicoBase.Cb_Persona.SelectedValue = filaConf("IDPERSONAMEDICO")
                    Cu_BPMedicoBase.CargarCajaTexto()
                Else
                    Cu_BPMedicoBase.Cb_Persona.SelectedIndex = -1
                End If
                If Not IsDBNull(filaConf("IDPERSONARESIDENTE")) Then
                    Cu_BPResidente.Cb_Persona.SelectedValue = filaConf("IDPERSONARESIDENTE")
                    Cu_BPResidente.CargarCajaTexto()
                Else
                    Cu_BPResidente.Cb_Persona.SelectedIndex = -1
                End If
                If Not IsDBNull(filaConf("IDPERSONAJEFEPERSONAL")) Then
                    Cu_BPJefePersonal.Cb_Persona.SelectedValue = filaConf("IDPERSONAJEFEPERSONAL")
                    Cu_BPJefePersonal.CargarCajaTexto()
                Else
                    Cu_BPJefePersonal.Cb_Persona.SelectedIndex = -1
                End If
                If Not IsDBNull(filaConf("IDPERSONAADMINISTRADOR")) Then
                    Cu_BPAdministrador.Cb_Persona.SelectedValue = filaConf("IDPERSONAADMINISTRADOR")
                    Cu_BPAdministrador.CargarCajaTexto()
                Else
                    Cu_BPAdministrador.Cb_Persona.SelectedIndex = -1
                End If
                If Not IsDBNull(filaConf("IDPERSONAJEFEBODEGA")) Then
                    Cu_BPJefeBodega.Cb_Persona.SelectedValue = filaConf("IDPERSONAJEFEBODEGA")
                    Cu_BPJefeBodega.CargarCajaTexto()
                Else
                    Cu_BPJefeBodega.Cb_Persona.SelectedIndex = -1
                End If
                If Not IsDBNull(filaConf("LUGARENTREGADOTACION")) Then
                    Tx_LugarEntregaDotacion.Text = filaConf("LUGARENTREGADOTACION")
                End If
            Else
                accion = TipoAccion.Agregar
                Cu_BPCoordinadorQAQC.Cb_Persona.SelectedIndex = -1
                Cu_BPCoordinadorHSE.Cb_Persona.SelectedIndex = -1
                Cu_BPMedicoBase.Cb_Persona.SelectedIndex = -1
                Cu_BPResidente.Cb_Persona.SelectedIndex = -1
                Cu_BPJefePersonal.Cb_Persona.SelectedIndex = -1
                Cu_BPAdministrador.Cb_Persona.SelectedIndex = -1
                Cu_BPJefeBodega.Cb_Persona.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cargar configuración", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        Finally
            conexion.Close()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Button_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Cancelar.Click
        Close()
    End Sub

    Private Function ValidarCampos() As Boolean
        If Cu_CiudadContratacion.Cb_Ciudad.SelectedIndex <= 0 OrElse Trim(Cu_CiudadContratacion.Cb_Ciudad.Text) = "" Then
            MessageBox.Show("Debe seleccionar la ciudad o municipio de contratación", "LUGAR DE CONTRATACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        'If Cu_CentroCostoBase.IdCentroCosto <= 0 Then
        '    MessageBox.Show("Debe seleccionar el centro de costo de la base", "CENTRO DE COSTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return False
        'End If
        Return True
    End Function

    Private Sub Button_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Aceptar.Click
        If ValidarCampos() Then
            comando = New SqlCommand("dbo.GestionarConfiguracionBase", conexion) With {.CommandType = CommandType.StoredProcedure}
            comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
            comando.Parameters.Add("@IDBASESISCONTROL", SqlDbType.Int)
            comando.Parameters.Add("@CODIGOCONTRATOISMOCOL", SqlDbType.NVarChar, 50)
            comando.Parameters.Add("@IDCENTROCOSTO", SqlDbType.Int)
            comando.Parameters.Add("@CODIGOCIUDADCONTRATACION", SqlDbType.NChar, 5)
            comando.Parameters.Add("@IDPERSONACOORDINADORQAQC", SqlDbType.Int)
            comando.Parameters.Add("@IDPERSONACOORDINADORHSEC", SqlDbType.Int)
            comando.Parameters.Add("@IDPERSONAMEDICO", SqlDbType.Int)
            comando.Parameters.Add("@IDPERSONARESIDENTE", SqlDbType.Int)
            comando.Parameters.Add("@IDPERSONAJEFEPERSONAL", SqlDbType.Int)
            comando.Parameters.Add("@IDPERSONAADMINISTRADOR", SqlDbType.Int)
            comando.Parameters.Add("@IDPERSONAJEFEBODEGA", SqlDbType.Int)
            comando.Parameters.Add("@LUGARENTREGADOTACION", SqlDbType.NVarChar, 100)
            comando.Parameters("@Accion").Value = accion
            comando.Parameters("@IDBASESISCONTROL").Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual 'filaConf("IDBASESISCONTROL")
            comando.Parameters("@CODIGOCONTRATOISMOCOL").Value = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_CodigoContrato.Text)
            If Cu_CentroCostoBase.IdCentroCosto > 0 Then
                comando.Parameters("@IDCENTROCOSTO").Value = Cu_CentroCostoBase.IdCentroCosto
            Else
                comando.Parameters("@IDCENTROCOSTO").Value = DBNull.Value
            End If
            comando.Parameters("@CODIGOCIUDADCONTRATACION").Value = Cu_CiudadContratacion.Cb_Ciudad.SelectedValue
            If Cu_BPCoordinadorQAQC.Cb_Persona.SelectedIndex > 0 Then
                comando.Parameters("@IDPERSONACOORDINADORQAQC").Value = Cu_BPCoordinadorQAQC.Cb_Persona.SelectedValue
            Else
                comando.Parameters("@IDPERSONACOORDINADORQAQC").Value = DBNull.Value
            End If
            If Cu_BPCoordinadorHSE.Cb_Persona.SelectedIndex > 0 Then
                comando.Parameters("@IDPERSONACOORDINADORHSEC").Value = Cu_BPCoordinadorHSE.Cb_Persona.SelectedValue
            Else
                comando.Parameters("@IDPERSONACOORDINADORHSEC").Value = DBNull.Value
            End If
            If Cu_BPMedicoBase.Cb_Persona.SelectedIndex > 0 Then
                comando.Parameters("@IDPERSONAMEDICO").Value = Cu_BPMedicoBase.Cb_Persona.SelectedValue
            Else
                comando.Parameters("@IDPERSONAMEDICO").Value = DBNull.Value
            End If
            If Cu_BPResidente.Cb_Persona.SelectedIndex > 0 Then
                comando.Parameters("@IDPERSONARESIDENTE").Value = Cu_BPResidente.Cb_Persona.SelectedValue
            Else
                comando.Parameters("@IDPERSONARESIDENTE").Value = DBNull.Value
            End If
            If Cu_BPJefePersonal.Cb_Persona.SelectedIndex > 0 Then
                comando.Parameters("@IDPERSONAJEFEPERSONAL").Value = Cu_BPJefePersonal.Cb_Persona.SelectedValue
            Else
                comando.Parameters("@IDPERSONAJEFEPERSONAL").Value = DBNull.Value
            End If
            If Cu_BPAdministrador.Cb_Persona.SelectedIndex > 0 Then
                comando.Parameters("@IDPERSONAADMINISTRADOR").Value = Cu_BPAdministrador.Cb_Persona.SelectedValue
            Else
                comando.Parameters("@IDPERSONAADMINISTRADOR").Value = DBNull.Value
            End If
            If Cu_BPJefeBodega.Cb_Persona.SelectedIndex > 0 Then
                comando.Parameters("@IDPERSONAJEFEBODEGA").Value = Cu_BPJefeBodega.Cb_Persona.SelectedValue
            Else
                comando.Parameters("@IDPERSONAJEFEBODEGA").Value = DBNull.Value
            End If
            comando.Parameters("@LUGARENTREGADOTACION").Value = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_LugarEntregaDotacion.Text)
            Cursor = Cursors.WaitCursor
            Try
                conexion.Open()
                comando.ExecuteNonQuery()
                FuncionesBase.FuncionesBase.Cargar_Configuración() 'Asigna la nueva configuración a las variables globales en VariablesBase.
                MessageBox.Show("Se guardaron los cambios exitosamente.")
                Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Guardar configuración", MessageBoxButtons.OK, MessageBoxIcon.Error) 'Error al intentar guardar la configuración, revise e intente nuevamente.
                Exit Sub
            Finally
                Cursor = Cursors.Default
                conexion.Close()
            End Try
        End If
    End Sub

    Public Sub EventoCajaEnter(Optional NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Cu_BPCoordinadorQAQC.Name
                Try
                    filas = Cu_BPCoordinadorQAQC.DT_BUSCARPERSONA.Select("IDENTIFICACION='" & (Cu_BPCoordinadorQAQC.Tx_TextoCódigo.Text).ToString & "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cu_BPCoordinadorQAQC.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no está registrada o no está asociada a la dependencia.", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Cu_BPCoordinadorQAQC.Tx_TextoCódigo.Text = ""
                End Try
            Case Cu_BPCoordinadorHSE.Name
                Try
                    filas = Cu_BPCoordinadorHSE.DT_BUSCARPERSONA.Select("IDENTIFICACION='" & (Cu_BPCoordinadorHSE.Tx_TextoCódigo.Text).ToString & "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cu_BPCoordinadorHSE.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no está registrada o no está asociada a la dependencia.", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Cu_BPCoordinadorHSE.Tx_TextoCódigo.Text = ""
                End Try
            Case Cu_BPMedicoBase.Name
                Try
                    filas = Cu_BPMedicoBase.DT_BUSCARPERSONA.Select("IDENTIFICACION='" & (Cu_BPMedicoBase.Tx_TextoCódigo.Text).ToString & "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cu_BPMedicoBase.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no está registrada o no está asociada a la dependencia.", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Cu_BPMedicoBase.Tx_TextoCódigo.Text = ""
                End Try
            Case Cu_BPResidente.Name
                Try
                    filas = Cu_BPResidente.DT_BUSCARPERSONA.Select("IDENTIFICACION='" & (Cu_BPResidente.Tx_TextoCódigo.Text).ToString & "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cu_BPResidente.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no está registrada o no está asociada a la dependencia.", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Cu_BPResidente.Tx_TextoCódigo.Text = ""
                End Try
            Case Cu_BPJefePersonal.Name
                Try
                    filas = Cu_BPJefePersonal.DT_BUSCARPERSONA.Select("IDENTIFICACION='" & (Cu_BPJefePersonal.Tx_TextoCódigo.Text).ToString & "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cu_BPJefePersonal.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no está registrada o no está asociada a la dependencia.", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Cu_BPJefePersonal.Tx_TextoCódigo.Text = ""
                End Try
            Case Cu_BPAdministrador.Name
                Try
                    filas = Cu_BPAdministrador.DT_BUSCARPERSONA.Select("IDENTIFICACION='" & (Cu_BPAdministrador.Tx_TextoCódigo.Text).ToString & "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cu_BPAdministrador.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no está registrada o no está asociada a la dependencia.", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Cu_BPAdministrador.Tx_TextoCódigo.Text = ""
                End Try
            Case Cu_BPJefeBodega.Name
                Try
                    filas = Cu_BPJefeBodega.DT_BUSCARPERSONA.Select("IDENTIFICACION='" & (Cu_BPJefeBodega.Tx_TextoCódigo.Text).ToString & "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cu_BPJefeBodega.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no está registrada o no está asociada a la bodega.", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Cu_BPJefeBodega.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub

    Public Sub cargarpersonalasociadobodega(IDPERSONA As Integer, NOMBRECOMPONENTE As String)
        'Dim temp As Integer = -1
        'temp = Cu_BP.Cb_Persona.SelectedValue
        Select Case NOMBRECOMPONENTE
            Case Cu_BPCoordinadorQAQC.Name
                Cu_BPCoordinadorQAQC.CargarDatos()
                Cu_BPCoordinadorQAQC.Cb_Persona.SelectedValue = IDPERSONA
                Cu_BPCoordinadorQAQC.CargarCajaTexto()
            Case Cu_BPCoordinadorHSE.Name
                Cu_BPCoordinadorHSE.CargarDatos()
                Cu_BPCoordinadorHSE.Cb_Persona.SelectedValue = IDPERSONA
                Cu_BPCoordinadorHSE.CargarCajaTexto()
            Case Cu_BPMedicoBase.Name
                Cu_BPMedicoBase.CargarDatos()
                Cu_BPMedicoBase.Cb_Persona.SelectedValue = IDPERSONA
                Cu_BPMedicoBase.CargarCajaTexto()
            Case Cu_BPResidente.Name
                Cu_BPResidente.CargarDatos()
                Cu_BPResidente.Cb_Persona.SelectedValue = IDPERSONA
                Cu_BPResidente.CargarCajaTexto()
            Case Cu_BPJefePersonal.Name
                Cu_BPJefePersonal.CargarDatos()
                Cu_BPJefePersonal.Cb_Persona.SelectedValue = IDPERSONA
                Cu_BPJefePersonal.CargarCajaTexto()
            Case Cu_BPAdministrador.Name
                Cu_BPAdministrador.CargarDatos()
                Cu_BPAdministrador.Cb_Persona.SelectedValue = IDPERSONA
                Cu_BPAdministrador.CargarCajaTexto()
            Case Cu_BPJefeBodega.Name
                Cu_BPJefeBodega.CargarDatos()
                Cu_BPJefeBodega.Cb_Persona.SelectedValue = IDPERSONA
                Cu_BPJefeBodega.CargarCajaTexto()
        End Select
    End Sub

End Class