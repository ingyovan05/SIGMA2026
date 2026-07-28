Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class Fr_Encuesta

    Public Enum Accion
        Crear
        Editar
        Ver
        AgregarConcepto
    End Enum

    Property TipoAccion As Accion
    Property IdPersona As Integer
    Property IdEncuesta As Integer = -1

    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private dsMaestras As DataSet

    Public Sub CargarDatos()

        'Me.Dgv_Encuesta.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        'Me.Dgv_Encuesta.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Encuesta.AutoGenerateColumns = False

        comando = New SqlCommand("dbo.CargarMaestrasEncuesta", conexion) With {.CommandType = CommandType.StoredProcedure}
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        comando.Parameters.Add("@IdBase", SqlDbType.Int)
        comando.Parameters.Add("@Identificador", SqlDbType.BigInt)
        comando.Parameters.Add("@Tipo", SqlDbType.TinyInt)
        comando.Parameters.Add("@Identificador2", SqlDbType.BigInt)
        comando.Parameters.Add("@Cedula", SqlDbType.NVarChar, 15)
        comando.Parameters("@Accion").Value = 1
        comando.Parameters("@IdBase").Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        comando.Parameters("@Identificador").Value = IdEncuesta
        comando.Parameters("@Identificador2").Value = IdPersona
        comando.Parameters("@Cedula").Value = ""
        If TipoAccion = Accion.Crear Then 'Envío a Exámenes
            comando.Parameters("@Tipo").Value = 1
        Else 'Editar, Ver, AgregarConcepto.
            comando.Parameters("@Tipo").Value = 2
        End If
        adaptador = New SqlDataAdapter(comando)
        dsMaestras = New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsMaestras)
        Catch ex As Exception
            MessageBox.Show("Error al carlos los datos de la encuesta." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try

        Dgv_Encuesta.AutoGenerateColumns = False

        For i = 0 To Dgv_Encuesta.Columns.Count - 1
            Select Case Dgv_Encuesta.Columns(i).Name
                Case "DGVTBC_SI", "DGVTBC_NO"
                    Dgv_Encuesta.Columns(i).Width = 40
                Case "DGVTBC_PREGUNTA"
                    Dgv_Encuesta.Columns(i).Width = 500
                Case Else
                    Dgv_Encuesta.Columns(i).Visible = False
            End Select
        Next



        Dgv_Encuesta.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        Dgv_Encuesta.DataSource = dsMaestras.Tables(1)


        For i = 0 To Dgv_Encuesta.Rows.Count - 1
            Dim row As DataGridViewRow
            row = Dgv_Encuesta.Rows(i)
            Select Case i
                Case 4, 5, 6
                    row.Height = 55
                    row.MinimumHeight = 55
                Case 9
                    Dgv_Encuesta.Rows.RemoveAt(i)   ''Quyitar la pregunta 10

            End Select
        Next

        Dim row1 As DataGridViewRow
        row1 = Dgv_Encuesta.RowTemplate

        row1.Height = 30
        row1.MinimumHeight = 30

        Cb_Base.DataSource = dsMaestras.Tables(2)
        Cb_Base.DisplayMember = "NOMBREBASE"
        Cb_Base.ValueMember = "IDBASESISCONTROL"


        If TipoAccion = Accion.Crear Then
            Dim fila As DataRow
            fila = dsMaestras.Tables(3).Rows(0)
            Me.Lb_Nombre.Text = fila("NOMBRECOMPLETO")
            Me.Lb_Identificacion.Text = fila("IDENTIFICACION")
            Me.NUD_Edad.Value = IIf(fila("EDAD") > 100, 18, fila("EDAD"))
            Me.Tx_CorreoElectrónico.Text = fila("CORREOELECTRONICO")
            Me.Dtp_Encuesta.Value = Date.Now
            Me.Tx_Cargo.Text = fila("NOMBRETIPOCARGO")
            Me.Cb_Base.SelectedValue = fila("IDBASECONTRATADO")
            Me.Tx_Proyecto.Text = fila("PROYECTO")
        Else
            Dim fila As DataRow
            fila = dsMaestras.Tables(0).Rows(0)
            Me.Lb_Nombre.Text = fila("NOMBRECOMPLETO")
            Me.Lb_Identificacion.Text = fila("IDENTIFICACION")
            Me.Cb_Base.SelectedValue = fila("IDBASESISCONTROL")
            Me.Tx_Cargo.Text = fila("NOMBRETIPOCARGO")
            Me.Dtp_Encuesta.Value = fila("FECHAENCUESTA")
            Me.NUD_Edad.Value = IIf(fila("EDAD") > 100, 18, fila("EDAD"))
            Me.Tx_CorreoElectrónico.Text = fila("CORREOELECTRONICO")
            Me.Tx_Proyecto.Text = fila("PROYECTO")
        End If
        If TipoAccion = Accion.Ver Then
            DeshabilitarControles()
        End If

    End Sub

    Private Sub DeshabilitarControles()
        Tx_Proyecto.Enabled = False
        Tx_Cargo.Enabled = False
        Tx_CorreoElectrónico.Enabled = False
        Cb_Base.Enabled = False
        Dtp_Encuesta.Enabled = False
        NUD_Edad.Enabled = False
        Bt_CrearyEnviar.Visible = False
        Dgv_Encuesta.Enabled = False
        Bt_Guardar.Visible = False
        Button2.Text = "Cerrar"
    End Sub

    Private Sub GuardarEncuesta()
        comando = New SqlCommand("dbo.GestionarEncuesta", conexion) With {.CommandType = CommandType.StoredProcedure}

        comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
        comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
        comando.Parameters.Add("@IDBASESISCONTROL", SqlDbType.Int)
        comando.Parameters.Add("@PROYECTO", SqlDbType.NVarChar, 50)
        comando.Parameters.Add("@FECHAENCUESTA", SqlDbType.Date)
        comando.Parameters.Add("@EDAD", SqlDbType.TinyInt)
        comando.Parameters.Add("@NOMBRETIPOCARGO", SqlDbType.NVarChar, 80)
        comando.Parameters.Add("@RESPUESTA1", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA2", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA3", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA4", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA5", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA6", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA7", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA8", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA9", SqlDbType.NChar, 1)
        comando.Parameters.Add("@RESPUESTA10", SqlDbType.NChar, 1)
        comando.Parameters.Add("@IDPERSONARESPONDE", SqlDbType.Int)
        comando.Parameters.Add("@FECHARESPONDE", SqlDbType.DateTime)
        comando.Parameters.Add("@CLAVEACCESOWEB", SqlDbType.NChar, 8)
        comando.Parameters.Add("@LLENOVIAWEB", SqlDbType.NChar, 1)
        comando.Parameters.Add("@CORREOELECTRONICO", SqlDbType.NVarChar, 100)
        comando.Parameters.Add("@AUTORIZADOMEDICO", SqlDbType.NChar, 1)
        comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)
        comando.Parameters.Add("@ID_DM_ENCUESTA", SqlDbType.BigInt)

        Select Case TipoAccion
            Case Accion.Crear
                comando.Parameters("@ACCION").Value = 1
                comando.Parameters("@ID_DM_ENCUESTA").Value = DBNull.Value
            Case Accion.Editar
                comando.Parameters("@ACCION").Value = 2
                comando.Parameters("@ID_DM_ENCUESTA").Value = IdEncuesta
        End Select

        comando.Parameters("@FECHAENCUESTA").Value = Dtp_Encuesta.Value
        comando.Parameters("@CLAVEACCESOWEB").Value = DBNull.Value

        comando.Parameters("@IDPERSONA").Value = IdPersona
        comando.Parameters("@IDBASESISCONTROL").Value = Cb_Base.SelectedValue
        comando.Parameters("@PROYECTO").Value = Tx_Proyecto.Text
        comando.Parameters("@EDAD").Value = NUD_Edad.Value
        comando.Parameters("@NOMBRETIPOCARGO").Value = Tx_Cargo.Text


        comando.Parameters("@RESPUESTA1").Value = IIf(IsDBNull(Dgv_Encuesta.Rows(0).Cells("DGVTBC_SI").Value) = False, "S", "N")
        comando.Parameters("@RESPUESTA2").Value = IIf(IsDBNull(Dgv_Encuesta.Rows(1).Cells("DGVTBC_SI").Value) = False, "S", "N")
        comando.Parameters("@RESPUESTA3").Value = IIf(IsDBNull(Dgv_Encuesta.Rows(2).Cells("DGVTBC_SI").Value) = False, "S", "N")
        comando.Parameters("@RESPUESTA4").Value = IIf(IsDBNull(Dgv_Encuesta.Rows(3).Cells("DGVTBC_SI").Value) = False, "S", "N")
        comando.Parameters("@RESPUESTA5").Value = IIf(IsDBNull(Dgv_Encuesta.Rows(4).Cells("DGVTBC_SI").Value) = False, "S", "N")
        comando.Parameters("@RESPUESTA6").Value = IIf(IsDBNull(Dgv_Encuesta.Rows(5).Cells("DGVTBC_SI").Value) = False, "S", "N")
        comando.Parameters("@RESPUESTA7").Value = IIf(IsDBNull(Dgv_Encuesta.Rows(6).Cells("DGVTBC_SI").Value) = False, "S", "N")
        comando.Parameters("@RESPUESTA8").Value = IIf(IsDBNull(Dgv_Encuesta.Rows(7).Cells("DGVTBC_SI").Value) = False, "S", "N")
        comando.Parameters("@RESPUESTA9").Value = IIf(IsDBNull(Dgv_Encuesta.Rows(8).Cells("DGVTBC_SI").Value) = False, "S", "N")
        comando.Parameters("@RESPUESTA10").Value = IIf(IsDBNull(Dgv_Encuesta.Rows(9).Cells("DGVTBC_SI").Value) = False, "S", "N")


        comando.Parameters("@CORREOELECTRONICO").Value = Me.Tx_CorreoElectrónico.Text
        comando.Parameters("@AUTORIZADOMEDICO").Value = DBNull.Value
        'Parametros de quien diligencia y elm medio
        comando.Parameters("@IDPERSONARESPONDE").Value = VariablesBase.VariablesBase.IdPersona
        comando.Parameters("@FECHARESPONDE").Value = Date.Now
        comando.Parameters("@LLENOVIAWEB").Value = "N"
        comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona

        Dim msgParam As New SqlParameter("@MENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)

        Dim msgParam1 As New SqlParameter("@CONSECUTIVO", SqlDbType.NChar, 8)
        msgParam1.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam1)

        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            MsgBox("Se guardó la encuesta correctamente", MsgBoxStyle.Information, "Guardado")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
        If MsgBox("¿Desea imprimir la Encuesta?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
            Dim climpresiones As New ImprimirRecursoHumano.Cl_Impresión
            Dim Array As New ArrayList
            Array.Add(73)
            climpresiones.Idpersona = IdPersona
            climpresiones.FormatosImprimir(Array, True)
            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESIÓN")
        End If

    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click

        If Me.Cb_Base.SelectedIndex = -1 Then
            MsgBox("Debe diligenciar la base donde se presenta la encuesta", MsgBoxStyle.Critical, "Diligenciamiento incompleto")
            Exit Sub
        End If

        If Me.Tx_Cargo.Text = "" Then
            MsgBox("Debe diligenciar el cargo", MsgBoxStyle.Critical, "Diligenciamiento incompleto")
            Exit Sub
        End If

        Try
            For i = 0 To Dgv_Encuesta.Rows.Count - 1
                If IsDBNull(Dgv_Encuesta.Rows(i).Cells("DGVTBC_SI").Value) And IsDBNull(Dgv_Encuesta.Rows(i).Cells("DGVTBC_NO").Value) Then
                    MsgBox("Debe diligenciar todas las preguntas", MsgBoxStyle.Critical, "Diligenciamiento incompleto")
                    Exit Sub
                End If
            Next

            For i = 0 To Dgv_Encuesta.Rows.Count - 1
                If IsDBNull(Dgv_Encuesta.Rows(i).Cells("DGVTBC_SI").Value) = False And IsDBNull(Dgv_Encuesta.Rows(i).Cells("DGVTBC_NO").Value) = False Then
                    MsgBox("Debe diligenciar solo una respuesta a todas las preguntas", MsgBoxStyle.Critical, "Diligenciamiento incorrecto")
                    Exit Sub
                End If
            Next


        Catch ex As Exception
            MsgBox("Debe diligenciar todas las preguntas", MsgBoxStyle.Critical, "Diligenciamiento incompleto")
            Exit Sub
        End Try



        GuardarEncuesta()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class