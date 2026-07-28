Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_ExamenesPendientesConcepto
    Property IdPersona As Integer = -1
    Property Nombre As String = ""
    Property Identificacion As String = ""

    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter

    Private Sub Fr_ExamenesPendientesConcepto_Load(sender As Object, e As EventArgs) Handles Me.Load
        Lb_Nombre.Text = Nombre
        Lb_Identificación.Text = Identificacion
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT EE.IDENVIOEXAMEN, RTRIM(B.ABREVIATURABASE)+' - '+B.NOMBREBASE AS BASE," + _
                                "EE.FECHAENVIO,MTC.NOMBRETIPOCARGO as CARGO," + _
                                "case when EE.CODIGOMOTIVOCONSULTA =2 then 'Ingreso' " + _
                                "when EE.CODIGOMOTIVOCONSULTA =7 then 'Ingreso Atención Emergencias' " + _
                                "when EE.CODIGOMOTIVOCONSULTA =4 then 'Retiro'" + _
                                "when EE.CODIGOMOTIVOCONSULTA =3 then 'Periódico'" + _
                                "when EE.CODIGOMOTIVOCONSULTA =5 then 'Reubicación'" + _
                                "when EE.CODIGOMOTIVOCONSULTA =6 then 'Post - incapacidad'" + _
                                "when EE.CODIGOMOTIVOCONSULTA =8 then 'Otro Motivo'" + _
                                "else '' end as MOTIVO" + _
                                 ", dbo.Personanombrecompleto(EE.IDUSUARIOREGISTRA) AS USUARIOREGISTRA," + _
                                "EE.FECHAREGISTRO FROM ENVIOEXAMEN AS EE JOIN SC_BASE AS B ON B.IDBASESISCONTROL = EE.IDBASE LEFT JOIN " + _
                                "MA_TIPOCARGO MTC ON EE.CODIGOTIPOCARGO=MTC.CODIGOTIPOCARGO " + _
                                "WHERE IDPERSONA = " + IdPersona.ToString + " 	AND (CONCEPTOMEDICO IS NULL OR RTRIM(CONCEPTOMEDICO) = '') AND CODIGOMOTIVOCONSULTA <> 4", conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)

        Dim dtExamenesPendientes As New DataTable

        Dgv_Examenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        Try
            conexion.Open()
            adaptador.Fill(dtExamenesPendientes)
            conexion.Close()

            If dtExamenesPendientes.Rows.Count > 0 Then
                Dgv_Examenes.DataSource = dtExamenesPendientes
                'Dgv_Prorrogas.AutoResizeColumns()
            Else
                If Not IsNothing(Dgv_Examenes.DataSource) Then
                    Dgv_Examenes.DataSource.Clear()
                End If
            End If
        Catch
            conexion.Close()
            If Not IsNothing(Dgv_Examenes.DataSource) Then
                Dgv_Examenes.DataSource.Clear()
            End If
        End Try

        For i = 0 To Dgv_Examenes.ColumnCount - 1
            Select Case Dgv_Examenes.Columns(i).Name
                Case DGVTBC_Id.Name
                    Dgv_Examenes.Columns(i).ToolTipText = "Id"
                    Dgv_Examenes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Examenes.Columns(i).Width = 50
                Case DGBTBC_Base.Name
                    Dgv_Examenes.Columns(i).ToolTipText = "Base"
                    Dgv_Examenes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Examenes.Columns(i).Width = 70
                Case DGVTBC_Fecha.Name
                    Dgv_Examenes.Columns(i).ToolTipText = "Fecha Envío"
                    Dgv_Examenes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Examenes.Columns(i).Width = 80
                Case DGVTBC_Cargo.Name
                    Dgv_Examenes.Columns(i).ToolTipText = "Cargo"
                    Dgv_Examenes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Examenes.Columns(i).Width = 120
                Case DGVTBC_Motivo.Name
                    Dgv_Examenes.Columns(i).ToolTipText = "Motivo"
                    Dgv_Examenes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Examenes.Columns(i).Width = 100
                Case DGVTBC_Registra.Name
                    Dgv_Examenes.Columns(i).ToolTipText = "Usuario Registra"
                    Dgv_Examenes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Examenes.Columns(i).Width = 100
                Case DGVTBC_FechaRegistro.Name
                    Dgv_Examenes.Columns(i).ToolTipText = "Fecha Registro"
                    Dgv_Examenes.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Examenes.Columns(i).Width = 80
                Case Else
                    Dgv_Examenes.Columns(i).Visible = False
            End Select
        Next




    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Close()
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        Dim FrExamenesPendientesConcepto As New Fr_ExamenesPendientesConcepto
        FrExamenesPendientesConcepto.Close()
        Dim FrImprimirExamenes As New Fr_ImprimirExamenes
        FrImprimirExamenes.TipoAccion = Fr_ImprimirExamenes.Accion.Crear
        FrImprimirExamenes.IdPersona = IdPersona
        FrImprimirExamenes.ShowDialog()
        'If FrImprimirExamenes.Guardado Then
        '    Cargar_Examenes()
        'End If
        Close()
    End Sub
End Class