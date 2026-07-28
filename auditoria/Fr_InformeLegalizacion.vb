Public Class Fr_InformeLegalizacion
    Public TipoInforme As Integer
    Public Consecutivo_desde As Integer
    Public Consecutivo_Hasta As Integer
    Public Identificacion As String
    Public fecha As Date
    Public Fecha_Desde As Date
    Public Fecha_Hasta As Date
    Public año As String


    'select * from InformeAuditoriaMaestro(0,'',1,20,'' ,'','2014') --"Consecutivos" 
    'select * from InformeAuditoriaMaestro(1,'1095787437','', '','' ,'','2014') --"IDENTIFICACION"
    'select * from InformeAuditoriaMaestro(2,'','' , '','01/01/2014' ,'09/09/2014',"")--"fECHADESDE_HASTA"


    Private Sub CargarTabla()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Select Case TipoInforme

            Case 0
                Me.InformeAuditoriaMaestroTableAdapter.Fill(Ds_Auditoria.InformeAuditoriaMaestro, 0, "", Consecutivo_desde, Consecutivo_Hasta, "", "", año)
            Case 1
                Try
                    Me.InformeAuditoriaMaestroTableAdapter.Fill(Ds_Auditoria.InformeAuditoriaMaestro, 1, Identificacion, -1, -1, "", "", Format(fecha, "yyyy-MM-dd"))
                Catch ex As Exception

                End Try

            Case 2
                Me.InformeAuditoriaMaestroTableAdapter.Fill(Ds_Auditoria.InformeAuditoriaMaestro, 2, -1, -1, -1, Format(Fecha_Desde, "yyyy-MM-dd"), Format(Fecha_Hasta, "yyyy-MM-dd"), Year(Date.Now))
        End Select

        Me.Dgv_InformeLegalizaicon.SuspendLayout()
        Me.Dgv_InformeLegalizaicon.DataSource = Me.Ds_Auditoria.InformeAuditoriaMaestro
        Me.Dgv_InformeLegalizaicon.ResumeLayout()

    End Sub


    Private Sub Fr_InformeLegalizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dgv_InformeLegalizaicon.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_InformeLegalizaicon.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        CargarTabla()
    End Sub

    Private Sub Btn_ExportarExcel_Informe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExportarExcel_Informe.Click
        FuncionesBase.FuncionesBase.GridAExcel(Dgv_InformeLegalizaicon, "Informe Legalizacion " & Date.Now)
    End Sub

    Private Sub Bt_Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cerrar.Click
        Me.Close()
    End Sub

End Class