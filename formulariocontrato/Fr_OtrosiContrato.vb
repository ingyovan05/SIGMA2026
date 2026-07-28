Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_OtrosiContrato
    Property IdPersona As Integer
    Property IdContrato As Integer
    Property Nombre As String
    Property CodigoContrato As String
    Property Guardado As Boolean
        Get
            Return _guardado
        End Get
        Private Set(value As Boolean)
            _guardado = value
        End Set
    End Property
    Private _guardado As Boolean = False
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private ultimoOtrosi As DataRow

    Private Sub Fr_OtrosiContrato_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Cu_CiudadContratación.CargarDatos()
        Cu_CiudadContratación.Cb_Ciudad.SelectedValue = ConsultarCiudadContratacion()
        ConsultarOtrosi()
        If Not IsNothing(ultimoOtrosi) Then
            Tx_FechaOtrosiAnterior.Text = ultimoOtrosi("FECHAINICIO")
        Else
            Tx_FechaOtrosiAnterior.Text = ""
        End If
        Dtp_FechaInicioOtrosi.Value = Date.Today
        Dtp_FechaInicioOtrosi.MinDate = Date.Today
        Lb_Nombre.Text = "Nombre: " & Nombre
        Lb_CodigoContrato.Text = "Código Contrato: " & CodigoContrato
    End Sub

    Private Function ConsultarCiudadContratacion() As String
        comando = New SqlCommand("SELECT dbo.BaseCiudadContratacion(@IDBASE)", conexion)
        comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Dim codigoCiudad As String = ""
        Try
            conexion.Open()
            codigoCiudad = comando.ExecuteScalar()
        Catch
            codigoCiudad = "00000"
        Finally
            conexion.Close()
        End Try
        If IsNothing(codigoCiudad) OrElse Trim(codigoCiudad) = "" Then
            codigoCiudad = "00000"
        End If
        Return codigoCiudad
    End Function

    Private Sub ConsultarOtrosi()
        comando = New SqlCommand("SELECT * FROM ListaOtrosiContrato(@IDCONTRATO) ORDER BY IDOTROSI DESC", conexion)
        comando.Parameters.AddWithValue("@IDCONTRATO", IdContrato)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtOtrosi As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtOtrosi)
            conexion.Close()
            If dtOtrosi.Rows.Count > 0 Then
                ultimoOtrosi = dtOtrosi.Rows(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Dtp_FechaFirmaOtrosi_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaFirmaOtrosi.ValueChanged
        Dtp_FechaInicioOtrosi.MinDate = Dtp_FechaFirmaOtrosi.Value
    End Sub

    Private Sub Tx_LaborContratada_TextChanged(sender As Object, e As EventArgs) Handles Tx_LaborContratada.TextChanged
        Lb_LaborContratada.Text = "(" & Tx_LaborContratada.Text.Length & "/" & Tx_LaborContratada.MaxLength & ")"
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_OK.Click
        If MessageBox.Show("¿Desea registrar el otrosí al contrato" & CodigoContrato & "?", "OTRO SI A CONTRATO", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
            If ValidarOtrosi() Then
                Guardar_Registro_Contrato()
            End If
        Else
            Exit Sub
        End If
        Dim climpresion As New ImprimirRecursoHumano.Cl_Impresión
        Dim Array As New ArrayList
        climpresion.Idpersona = IdPersona
        climpresion.IdContrato = IdContrato
        climpresion.IdBase = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        If MessageBox.Show("¿Desea imprimir el otrosí?", "OTRO SI REGISTRADO", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
            Array.Add(55)
        End If
        If MessageBox.Show("¿Desea imprimir la carta de terminación de contrato?", "OTRO SI REGISTRADO", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
            Array.Add(14)
        End If
        If Array.Count > 0 Then
            climpresion.FormatosImprimir(Array, True)
        End If
        Close()
    End Sub

    Private Function ValidarOtrosi() As Boolean
        If Cu_CiudadContratación.Cb_Ciudad.SelectedIndex < 0 Then
            MessageBox.Show("Debe indicar la población donde se firma el otrosí.", "INDICAR EL LUGAR DE CONTRATACIÓN", MessageBoxButtons.YesNo)
            Cu_CiudadContratación.Cb_Ciudad.Select()
            Return False
        End If
        If Trim(Tx_LaborContratada.Text) = "" Then
            MessageBox.Show("Debe indicar la labor del otrosí.", "INDICAR LA LABOR", MessageBoxButtons.YesNo)
            Tx_LaborContratada.Select()
            Return False
        End If
        Return True
    End Function

    Private Sub Guardar_Registro_Contrato()
        comando = New SqlClient.SqlCommand("dbo.GestionarOtrosiContrato", conexion) With {.CommandType = CommandType.StoredProcedure}
        comando.Parameters.AddWithValue("@ACCION", 1) 'Crear
        comando.Parameters.AddWithValue("@IDCONTRATO", IdContrato)
        comando.Parameters.AddWithValue("@FECHAINICIO", Dtp_FechaInicioOtrosi.Value)
        comando.Parameters.AddWithValue("@FECHAFIRMA", Dtp_FechaFirmaOtrosi.Value)
        comando.Parameters.AddWithValue("@CODIGOLUGARFIRMA", Cu_CiudadContratación.Cb_Ciudad.SelectedValue)
        comando.Parameters.AddWithValue("@LABOROTROSI", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_LaborContratada.Text))
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.TinyInt) With {.Direction = ParameterDirection.Output})
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
            If Not IsDBNull(comando.Parameters("@IDMENSAJE").Value) Then
                Select Case comando.Parameters("@IDMENSAJE").Value
                    Case 0
                        MessageBox.Show("No se pudo realizar la operación", "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        _guardado = False
                        Exit Sub
                    Case 1
                        MessageBox.Show("El registro ha sido exitoso", "Contrato", MessageBoxButtons.OK)
                        _guardado = True
                        Close()
                End Select
            Else
                MessageBox.Show("No se pudo realizar la operación", "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo realizar la operación." & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        DialogResult = System.Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

End Class 'Fr_OtrosiContrato