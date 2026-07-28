Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_GestionarCalificaciones
    Public IdPersona As Integer
    Private bddatos As New FuncionesBase.ClaseCargarMaestras

    Private Sub Fr_GestionarCalificaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dgv_ListaCalificaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    End Sub

    Public Sub Cargar_Tablas()
        Dim datosCargados As Boolean = False

        ' 0	CP_CALIFICACIONPERSONAL
        ' 1	PERSONA
        ' 2	CP_ACTIVIDADCAPACITACION
        ' 3	CP_ENTIDADCERTIFICADORA
        ' 4	CP_CALIFICACIONPERSONALLISTADO

        Dim dsCargar As New DataSet
        dsCargar = bddatos.CargarMaestras(9, IdPersona, -1, 1)
        If dsCargar.Tables.Count > 1 Then
            Dim dtCalificaciones As DataTable = dsCargar.Tables(1)
            If dtCalificaciones.Rows.Count > 0 Then
                Dim fila As DataRow
                fila = dtCalificaciones.Rows(0)
                Try
                    Lb_Persona.Text = FuncionesBase.FuncionesBase.FormatearIdentificacion(Trim(fila("IDENTIFICACION"))) + " --> " + fila("NOMBRECOMPLETO")
                    Dgv_ListaCalificaciones.DataSource = dsCargar.Tables(4)
                    datosCargados = True
                    AplicarFormatoColumnas()
                Catch
                    MessageBox.Show("No se encontraton calificaciones para gestionar.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            Else
                MessageBox.Show("No se encontraton calificaciones para gestionar.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se encontraton calificaciones para gestionar.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        If Not datosCargados Then
            Lb_Persona.Text = ""
            Bt_Editar.Enabled = False
            Bt_Eliminar.Enabled = False
            Bt_Imprimir.Enabled = False
        End If
    End Sub

    Private Sub AplicarFormatoColumnas()
        For i = 0 To Dgv_ListaCalificaciones.ColumnCount - 1
            Select Case Dgv_ListaCalificaciones.Columns(i).Name
                Case "NOMBREACTIVIDADCAPACITACION"
                    Dgv_ListaCalificaciones.Columns(i).Width = 300
                    Dgv_ListaCalificaciones.Columns(i).HeaderText = "Actividad Capacitación"
                    Dgv_ListaCalificaciones.Columns(i).ToolTipText = "Actividad de capacitación"
                Case "NOMBREENTIDADCERTIFICADORA"
                    Dgv_ListaCalificaciones.Columns(i).Width = 120
                    Dgv_ListaCalificaciones.Columns(i).HeaderText = "Entidad Certificadora"
                    Dgv_ListaCalificaciones.Columns(i).ToolTipText = "Entidad certificadora"
                Case "TITULO"
                    Dgv_ListaCalificaciones.Columns(i).Width = 100
                    Dgv_ListaCalificaciones.Columns(i).HeaderText = "Título"
                    Dgv_ListaCalificaciones.Columns(i).ToolTipText = "Título obtenido"
                Case "NROCERTIFICADO"
                    Dgv_ListaCalificaciones.Columns(i).Width = 110
                    Dgv_ListaCalificaciones.Columns(i).HeaderText = "Nro. Certificado"
                    Dgv_ListaCalificaciones.Columns(i).ToolTipText = "Número de Certificado"
                Case "FECHAINICIO"
                    Dgv_ListaCalificaciones.Columns(i).Width = 80
                    Dgv_ListaCalificaciones.Columns(i).HeaderText = "Fecha Inicio"
                    Dgv_ListaCalificaciones.Columns(i).ToolTipText = "Fecha de inicio de la certificación"
                Case "FECHAVALIDAHASTA"
                    Dgv_ListaCalificaciones.Columns(i).Width = 80
                    Dgv_ListaCalificaciones.Columns(i).HeaderText = "Válida Hasta"
                    Dgv_ListaCalificaciones.Columns(i).ToolTipText = "Fecha de validez de la certificación"
                Case "FECHAPROGRAMADAINICIO"
                    Dgv_ListaCalificaciones.Columns(i).Width = 110
                    Dgv_ListaCalificaciones.Columns(i).HeaderText = "Programada Desde"
                    Dgv_ListaCalificaciones.Columns(i).ToolTipText = "Fecha de inicio programada"
                Case "FECHAPROGRAMADAFIN"
                    Dgv_ListaCalificaciones.Columns(i).Width = 110
                    Dgv_ListaCalificaciones.Columns(i).HeaderText = "Programada Hasta"
                    Dgv_ListaCalificaciones.Columns(i).ToolTipText = "Fecha final programada"
                Case Else
                    Dgv_ListaCalificaciones.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        If MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Bt_Editar_Click(sender As Object, e As EventArgs) Handles Bt_Editar.Click
        Try
            Dim FrAgregarCalificacion As New Fr_AgregarCalificación
            FrAgregarCalificacion.IdPersona = Dgv_ListaCalificaciones.SelectedRows(0).Cells("IDPERSONA").Value
            FrAgregarCalificacion.IDCALIFICACIONPERSONALMODIFICANDO = Dgv_ListaCalificaciones.SelectedRows(0).Cells("IDCALIFICACIONPERSONAL").Value
            FrAgregarCalificacion.Editando = True
            FrAgregarCalificacion.Cargar_Tablas()
            FrAgregarCalificacion.CargarDatosCalificación()
            FrAgregarCalificacion.ShowDialog()
            Cargar_Tablas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bt_Eliminar_Click(sender As Object, e As EventArgs) Handles Bt_Eliminar.Click
        If MessageBox.Show("¿Seguro desea eliminar la calificación", "Eliminar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim Comando As New SqlCommand("dbo.GestionarCalificación")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@ACCION", 3) 'Eliminar
            Comando.Parameters.AddWithValue("@IDCALIFICACIONPERSONAL", Dgv_ListaCalificaciones.SelectedRows(0).Cells("IDCALIFICACIONPERSONAL").Value)
            Comando.Parameters.AddWithValue("@IDPERSONA", 1)
            Comando.Parameters.AddWithValue("@CODIGOACTIVIDADCAPACITACION", 1)
            Comando.Parameters.AddWithValue("@FECHAPRUEBATEORICA", DBNull.Value)
            Comando.Parameters.AddWithValue("@CALIFICACIONPRUEBATEORICA", 0)
            Comando.Parameters.AddWithValue("@FECHAPRUEBAPRACTICA", DBNull.Value)
            Comando.Parameters.AddWithValue("@CALIFICACIONPRUEBAPRACTICA", 0)
            Comando.Parameters.AddWithValue("@FECHACALIFICACIONDIRECTA", DBNull.Value)
            Comando.Parameters.AddWithValue("@CODIGOENTIDADCERTIFICADORA", 1)
            Comando.Parameters.AddWithValue("@TITULO", "")
            Comando.Parameters.AddWithValue("@NROCERTIFICADO", "")
            Comando.Parameters.AddWithValue("@FECHACERTIFICACIONEXTERNA", DBNull.Value)
            Comando.Parameters.AddWithValue("@FECHAVALIDAHASTA", DBNull.Value)
            Comando.Parameters.AddWithValue("@OBSERVACION", "")
            Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
            Comando.Parameters.AddWithValue("ESTADO", "")
            Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            Comando.Parameters.Add(msgParam)

            Dim conn As New SqlConnection(My.Settings.CadenaConexión)
            Comando.Connection = conn
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()
            Cargar_Tablas()
        End If
    End Sub

    Private Sub Bt_Imprimir_Click(sender As Object, e As EventArgs) Handles Bt_Imprimir.Click
        Try
            'Validar que la persona tenga contrato activo y traer el contrato para impresión.
            Dim idcontrato As Integer
            idcontrato = FuncionesBase.FuncionesBase.CONSULTARULTIMOCONTRATOACTIVOXIDPERSONA(IdPersona)

            If idcontrato = -1 Or idcontrato = 0 Then
                MessageBox.Show("Esta persona no tiene contrato vigente con ISMOCOL", "CONTRATO ACTIVO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim imprimir As New ImprimirRecursoHumano.Cl_Impresión
            Dim arrayDocs As New ArrayList
            imprimir.Idpersona = IdPersona
            imprimir.IdContrato = idcontrato
            imprimir.IdBase = VariablesBase.VariablesBase.IdBaseSiscontrolActual
            arrayDocs.Add(69)
            imprimir.FormatosImprimir(arrayDocs, True, False)
            If imprimir.ImpresionFinalizada Then
                MessageBox.Show("Impresión finalizada.", "Imprimir Calificaciones", MessageBoxButtons.OK)
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class