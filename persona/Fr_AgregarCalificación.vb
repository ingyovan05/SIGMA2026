Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class Fr_AgregarCalificación
    Public IdPersona As Integer
    Public IDCALIFICACIONPERSONALMODIFICANDO As Integer = -1
    Public Editando As Boolean = False
    Private filaEditarCalificacion As DataRow
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private _guardado As Boolean = False
    Private tieneFechaProgramacion As Boolean = False

    Private Sub Fr_AgregarCalificación_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tieneFechaProgramacion = Dtp_FechaProgramadaInicio.Checked
    End Sub

    Public Sub Cargar_Tablas()
        Dim datosCargados As Boolean = False
        ' 0	CP_CALIFICACIONPERSONAL
        ' 1	PERSONA
        ' 2	CP_ACTIVIDADCAPACITACION
        ' 3	CP_ENTIDADCERTIFICADORA
        ' 4	CP_CALIFICACIONPERSONALLISTADO

        Dim dsCargar As New DataSet
        dsCargar = bddatos.CargarMaestras(9, IdPersona, IDCALIFICACIONPERSONALMODIFICANDO, If(IDCALIFICACIONPERSONALMODIFICANDO = -1, 1, 2))
        If dsCargar.Tables.Count > 1 Then
            Dim dtPersona As DataTable
            dtPersona = dsCargar.Tables(1)
            If dtPersona.Rows.Count > 0 Then
                Dim fila As DataRow
                fila = dtPersona.Rows(0)
                Try
                    Lb_Persona.Text = FuncionesBase.FuncionesBase.FormatearIdentificacion(Trim(fila("IDENTIFICACION"))) + " --> " + fila("NOMBRECOMPLETO")

                    Cb_ActividadCapacitacion.DataSource = dsCargar.Tables(2)
                    Cb_ActividadCapacitacion.ValueMember = "CODIGOACTIVIDADCAPACITACION"
                    Cb_ActividadCapacitacion.DisplayMember = "NOMBREACTIVIDADCAPACITACION"

                    Cb_EntidadCertificadora.DataSource = dsCargar.Tables(3)
                    Cb_EntidadCertificadora.ValueMember = "CODIGOENTIDADCERTIFICADORA"
                    Cb_EntidadCertificadora.DisplayMember = "NOMBREENTIDADCERTIFICADORA"

                    If Editando = True Then
                        filaEditarCalificacion = dsCargar.Tables(0).Rows(0)
                    Else
                        Cb_ActividadCapacitacion.SelectedIndex = -1
                        Cb_EntidadCertificadora.SelectedIndex = -1
                    End If
                    datosCargados = True
                Catch
                    MessageBox.Show("No se encontraton datos de calificaciones.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            Else
                MessageBox.Show("No se encontraton datos de calificaciones.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se encontraton datos de calificaciones.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        If Not datosCargados Then
            Bt_Guardar.Enabled = False
        End If
    End Sub

#Region "Cargar Datos Editar"
    ''' <summary>Asigna los datos de la persona a los controles del formulario.</summary>
    Public Sub CargarDatosCalificación()
        Cb_ActividadCapacitacion.SelectedValue = filaEditarCalificacion("CODIGOACTIVIDADCAPACITACION")
        If IsDBNull(filaEditarCalificacion("FECHAPRUEBATEORICA")) Then
            Dtp_FechaPruebaTeorica.Value = Date.Now
            Dtp_FechaPruebaTeorica.Checked = False
        Else
            Dtp_FechaPruebaTeorica.Checked = True
            Dtp_FechaPruebaTeorica.Value = filaEditarCalificacion("FECHAPRUEBATEORICA")
        End If
        Try
            Tx_CalificacionPruebaTeorica.Text = Trim(filaEditarCalificacion("CALIFICACIONPRUEBATEORICA"))
        Catch
            Tx_CalificacionPruebaTeorica.Text = ""
        End Try
        If IsDBNull(filaEditarCalificacion("FECHAPRUEBAPRACTICA")) Then
            Dtp_FechaPruebaPractica.Value = Date.Now
            Dtp_FechaPruebaPractica.Checked = False
        Else
            Dtp_FechaPruebaPractica.Checked = True
            Dtp_FechaPruebaPractica.Value = filaEditarCalificacion("FECHAPRUEBAPRACTICA")
        End If
        Try
            Tx_CalificacionPruebaPractica.Text = Trim(filaEditarCalificacion("CALIFICACIONPRUEBAPRACTICA"))
        Catch
            Tx_CalificacionPruebaPractica.Text = ""
        End Try
        If IsDBNull(filaEditarCalificacion("FECHACALIFICACIONDIRECTA")) Then
            Dtp_FechaCalificacionDirecta.Value = Date.Now
            Dtp_FechaCalificacionDirecta.Checked = False
        Else
            Dtp_FechaCalificacionDirecta.Checked = True
            Dtp_FechaCalificacionDirecta.Value = filaEditarCalificacion("FECHACALIFICACIONDIRECTA")
        End If
        Try
            Cb_EntidadCertificadora.SelectedValue = filaEditarCalificacion("CODIGOENTIDADCERTIFICADORA")
        Catch

        End Try
        Try
            Tx_Titulo.Text = filaEditarCalificacion("TITULO")
        Catch
            Tx_Titulo.Text = ""
        End Try
        Try
            Tx_NroCertificado.Text = filaEditarCalificacion("NROCERTIFICADO")
        Catch
            Tx_NroCertificado.Text = ""
        End Try
        If IsDBNull(filaEditarCalificacion("FECHACERTIFICACIONEXTERNA")) Then
            Dtp_FechaCertificacionExterna.Value = DateTime.Now
            Dtp_FechaCertificacionExterna.Checked = False
        Else
            Dtp_FechaCertificacionExterna.Checked = True
            Dtp_FechaCertificacionExterna.Value = filaEditarCalificacion("FECHACERTIFICACIONEXTERNA")
        End If
        If IsDBNull(filaEditarCalificacion("FECHAVALIDAHASTA")) Then
            Dtp_FechaValidoHasta.Value = DateTime.Now
            Dtp_FechaValidoHasta.Checked = False
        Else
            Dtp_FechaValidoHasta.Checked = True
            Dtp_FechaValidoHasta.Value = filaEditarCalificacion("FECHAVALIDAHASTA")
        End If
        Try
            Tx_Observacion.Text = filaEditarCalificacion("OBSERVACION")
        Catch
            Tx_Observacion.Text = ""
        End Try
        If IsDBNull(filaEditarCalificacion("FECHAPROGRAMADAINICIO")) Then
            Dtp_FechaProgramadaInicio.Value = Date.Today
            Dtp_FechaProgramadaInicio.Checked = False
        Else
            Dtp_FechaProgramadaInicio.Checked = True
            Dtp_FechaProgramadaInicio.Value = filaEditarCalificacion("FECHAPROGRAMADAINICIO")
        End If
        If IsDBNull(filaEditarCalificacion("FECHAPROGRAMADAFIN")) Then
            Dtp_FechaProgramadaFin.Value = Date.Today
            Dtp_FechaProgramadaFin.Checked = False
        Else
            Dtp_FechaProgramadaFin.Checked = True
            Dtp_FechaProgramadaFin.Value = filaEditarCalificacion("FECHAPROGRAMADAFIN")
        End If
        Try
            If filaEditarCalificacion("ESTADO") = "A" Then
                Ck_Activo.CheckState = CheckState.Checked
            Else
                Ck_Activo.CheckState = CheckState.Unchecked
            End If
        Catch

        End Try
    End Sub
#End Region

    Private Sub Dtp_FechaProgramadaInicio_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaProgramadaInicio.ValueChanged
        If Dtp_FechaProgramadaInicio.Checked <> tieneFechaProgramacion Then
            tieneFechaProgramacion = Dtp_FechaProgramadaInicio.Checked
            Dtp_FechaProgramadaFin.Enabled = Dtp_FechaProgramadaInicio.Checked
            Dtp_FechaProgramadaFin.Checked = False
        End If
        If Dtp_FechaProgramadaFin.Checked Then
            If Dtp_FechaProgramadaFin.Value < Dtp_FechaProgramadaInicio.Value Then
                Dtp_FechaProgramadaFin.Value = Dtp_FechaProgramadaInicio.Value
            End If
        End If
    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If ValidarCalificacion() = True Then
            Guardar()
            If _guardado Then
                Me.Close()
            End If
        End If
    End Sub

    Private Function ValidarCalificacion() As Boolean
        If Cb_ActividadCapacitacion.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar la actividad de capacitación", "Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If Ck_Activo.CheckState = CheckState.Checked AndAlso Cb_EntidadCertificadora.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar la entidad certificadora", "Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If Ck_Activo.CheckState = Windows.Forms.CheckState.Indeterminate Then
            MessageBox.Show("Debe indicar si esta activo o no", "Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If Dtp_FechaProgramadaFin.Checked AndAlso Dtp_FechaProgramadaFin.Value < Dtp_FechaProgramadaInicio.Value Then
            MessageBox.Show("La fecha final de la programación debe ser mayor a la fecha de inicio.", "Calificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

#Region "Guardar o actualizar datos"
    Private Sub Guardar()
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("dbo.GestionarCalificación", conn)
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
        If Not Editando Then
            Comando.Parameters("@ACCION").Value = 1
        Else
            Comando.Parameters("@ACCION").Value = 2
        End If
        Comando.Parameters.AddWithValue("@IDCALIFICACIONPERSONAL", IDCALIFICACIONPERSONALMODIFICANDO)
        Comando.Parameters.AddWithValue("@IDPERSONA", IdPersona)
        Comando.Parameters.AddWithValue("@CODIGOACTIVIDADCAPACITACION", Cb_ActividadCapacitacion.SelectedValue)
        Comando.Parameters.Add("@FECHAPRUEBATEORICA", SqlDbType.Date)
        If Dtp_FechaPruebaTeorica.Checked = False Then
            Comando.Parameters("@FECHAPRUEBATEORICA").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAPRUEBATEORICA").Value = Dtp_FechaPruebaTeorica.Value.ToShortDateString
        End If
        Comando.Parameters.AddWithValue("@CALIFICACIONPRUEBATEORICA", Tx_CalificacionPruebaTeorica.Text)

        Comando.Parameters.Add("@FECHAPRUEBAPRACTICA", SqlDbType.Date)
        If Dtp_FechaPruebaPractica.Checked = False Then
            Comando.Parameters("@FECHAPRUEBAPRACTICA").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAPRUEBAPRACTICA").Value = Dtp_FechaPruebaPractica.Value
        End If
        Comando.Parameters.AddWithValue("@CALIFICACIONPRUEBAPRACTICA", Tx_CalificacionPruebaPractica.Text)
        Comando.Parameters.Add("@FECHACALIFICACIONDIRECTA", SqlDbType.Date)
        If Dtp_FechaCalificacionDirecta.Checked = False Then
            Comando.Parameters("@FECHACALIFICACIONDIRECTA").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHACALIFICACIONDIRECTA").Value = Dtp_FechaCalificacionDirecta.Value
        End If
        Comando.Parameters.Add("@CODIGOENTIDADCERTIFICADORA", SqlDbType.TinyInt)
        If Ck_Activo.CheckState = CheckState.Checked Then
            Comando.Parameters("@CODIGOENTIDADCERTIFICADORA").Value = Cb_EntidadCertificadora.SelectedValue
        Else
            Comando.Parameters("@CODIGOENTIDADCERTIFICADORA").Value = DBNull.Value
        End If
        Comando.Parameters.AddWithValue("@TITULO", Tx_Titulo.Text)
        Comando.Parameters.AddWithValue("@NROCERTIFICADO", Tx_NroCertificado.Text)
        Comando.Parameters.Add("@FECHACERTIFICACIONEXTERNA", SqlDbType.Date)
        If Dtp_FechaCertificacionExterna.Checked = False Then
            Comando.Parameters("@FECHACERTIFICACIONEXTERNA").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHACERTIFICACIONEXTERNA").Value = Dtp_FechaCertificacionExterna.Value
        End If
        Comando.Parameters.Add("@FECHAVALIDAHASTA", SqlDbType.Date)
        If Dtp_FechaValidoHasta.Checked = False Then
            Comando.Parameters("@FECHAVALIDAHASTA").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAVALIDAHASTA").Value = Dtp_FechaValidoHasta.Value
        End If
        Comando.Parameters.AddWithValue("@OBSERVACION", Tx_Observacion.Text)
        Comando.Parameters.Add("@FECHAPROGRAMADAINICIO", SqlDbType.Date)
        If Dtp_FechaProgramadaInicio.Checked = False Then
            Comando.Parameters("@FECHAPROGRAMADAINICIO").Value = DBNull.Value
        Else
            Comando.Parameters("@FECHAPROGRAMADAINICIO").Value = Dtp_FechaProgramadaInicio.Value
        End If
        Comando.Parameters.Add("@FECHAPROGRAMADAFIN", SqlDbType.Date)
        If Dtp_FechaProgramadaFin.Enabled AndAlso Dtp_FechaProgramadaFin.Checked Then
            Comando.Parameters("@FECHAPROGRAMADAFIN").Value = Dtp_FechaProgramadaFin.Value
        Else
            Comando.Parameters("@FECHAPROGRAMADAFIN").Value = DBNull.Value
        End If
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("ESTADO", If(Ck_Activo.CheckState = CheckState.Checked, "A", "I"))
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Try
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()
            Select Case Comando.Parameters("@IDMENSAJE").Value
                Case 0
                    MessageBox.Show("No se pudo realizar la operación.", "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    _guardado = False
                Case 1
                    MessageBox.Show("El registro ha sido exitoso.", "Registro de calificación", MessageBoxButtons.OK)
                    _guardado = True
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        If MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

End Class