Public Class Fr_RiesgosAntecedentesLaborales

    'Public DtRiesgos As DataTable = Nothing
    'Public drRiesgos() As DataRow = Nothing
    Public dtRiesgos As DataTable = Nothing
    Public dtCbRiesgos As DataTable = Nothing
    Public dtCbAgentes As DataTable = Nothing

    Public IdItem As Integer = 0
    Public Empresa As String = ""
    Public TiempoTrabajadoMeses As String = ""
    Public TiempoTrabajadoAños As String = ""
    Public ARL As String = ""
    Public IT As String = ""
    Public Origen As String = ""
    Public DiasIT As String = ""
    Public Secuela As String = ""
    Public Jornada As String = ""
    Public Turno As String = ""
    Public Cargo As String = ""
    Public Aceptar As Boolean = False
    Public Sub ComportamientoPredeterminado()
        Tb_Empresa.Text = Empresa
        Tb_TiempoTrabajadoMeses.Text = TiempoTrabajadoMeses
        Tb_TiempoTrabajadoAños.Text = TiempoTrabajadoAños
        Tb_ARL.Text = ARL
        Tb_IT.Text = IT
        Tb_Origen.Text = Origen
        Tb_DiasIT.Text = DiasIT
        Tb_Secuela.Text = Secuela
        Tb_Jornada.Text = Jornada
        Tb_Turno.Text = Turno
        Tb_Cargo.Text = Cargo

        Dgv_Riesgos.AutoGenerateColumns = False
        Dgv_Riesgos.DataSource = dtRiesgos

        DGVC_TipoRiesgo.DataSource = dtCbRiesgos.Copy
        DGVC_TipoRiesgo.DisplayMember = "NOMBRE"
        DGVC_TipoRiesgo.ValueMember = "ID"

        DGVC_AgenteCausal.DataSource = dtCbAgentes.Copy
        DGVC_AgenteCausal.DisplayMember = "NOMBRE"
        DGVC_AgenteCausal.ValueMember = "ID"

    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        dtRiesgos.AcceptChanges()
        Aceptar = True
        Me.Close()
    End Sub

    Private Sub Bt_AgregarRiesgos_Click(sender As Object, e As EventArgs) Handles Bt_AgregarRiesgos.Click
        Dim fila As DataRow
        fila = dtRiesgos.NewRow
        fila.Item(0) = IdItem
        fila.Item(1) = 0
        fila.Item(2) = dtRiesgos.Rows.Count + 1
        dtRiesgos.Rows.Add(fila)
    End Sub
End Class