Public Class Fr_Compradores

    Private Sub Fr_Compradores_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Dgv_Compradores.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Compradores.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub

    Dim DsRequisicion As New DatosRequisición.Ds_Requisicion

    Public IdpersonaVistoBueno As Int64
    Public IdpersonaVistoBuenoSubgerencia As Int64
    Public IdBodegaRequisicion As Integer

    Public IDREQUISICION As Int64

    Dim dt As New DataTable

    Public Sub cargar()
        Dim Comando As New SqlClient.SqlCommand("SELECT * FROM dbo.SeleccionComprador(" + IDREQUISICION.ToString() + ")")
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Comando.Connection = conn
        dt.Clear()
        Dim da As New SqlClient.SqlDataAdapter
        da = New SqlClient.SqlDataAdapter(Comando)
        conn.Open()
        da.Fill(dt)
        conn.Close()

        Me.Dgv_Compradores.DataSource = dt

        'Cargar personas para visto bueno
        Cu_Bp_VistoBueno.CargarDatos()
        Cu_Bp_VBSubgerencia.CargarDatos()

        Try
            Cu_Bp_VistoBueno.Cb_Persona.SelectedValue = IdpersonaVistoBueno
            If IdpersonaVistoBueno = -1 Then
                Me.Cb_RequiereVistoBueno.Checked = False
            Else
                Me.Cb_RequiereVistoBueno.Checked = True
            End If

        Catch ex As Exception
            Cu_Bp_VistoBueno.Cb_Persona.SelectedIndex = -1
            Me.Cb_RequiereVistoBueno.Checked = False
        End Try

        Try
            Cu_Bp_VBSubgerencia.Cb_Persona.SelectedValue = IdpersonaVistoBuenoSubgerencia
            If IdpersonaVistoBuenoSubgerencia = -1 Then
                Me.Cb_RequiereVBSubgerencia.Checked = False
            Else
                Me.Cb_RequiereVBSubgerencia.Checked = True
            End If

        Catch ex As Exception
            Cu_Bp_VBSubgerencia.Cb_Persona.SelectedIndex = -1
            Me.Cb_RequiereVBSubgerencia.Checked = False
        End Try


    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Public REQUISICION As String = ""

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        If Cb_RequiereVistoBueno.Checked = True Then
            If Cu_Bp_VistoBueno.Cb_Persona.SelectedIndex = -1 Then
                MsgBox("No se ha seleccionado ninguna persona para visto bueno", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If

        If Dgv_Compradores.SelectedRows.Count > 0 Then
            If MsgBox("¿Desea asignar el comprador " + Trim(Me.Dgv_Compradores.SelectedRows(0).Cells(2).Value) _
                      + " a la requisición " + Trim(REQUISICION) + "?", MsgBoxStyle.YesNo, "Asignar Comprador") = MsgBoxResult.Yes Then
                'Dim adap As New DatosRequisición.Ds_RequisicionTableAdapters.PROCEDIMIENTOS
                'adap.AsignarComprador(Me.Dgv_Compradores.SelectedRows(0).Cells(0).Value, VariablesBase.VariablesBase.IdPersona, IDREQUISICION)


                Dim Comando As New SqlClient.SqlCommand("dbo.AsignarCompradorRQ")
                Comando.CommandType = CommandType.StoredProcedure
                Dim IDrequisicionREvisada As Integer = IDREQUISICION
                Comando.Parameters.AddWithValue("@IDREQUISICION", IDrequisicionREvisada)
                Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                Comando.Parameters.AddWithValue("@REVISADOBODEGAPRINCIPAL", "S")
                Comando.Parameters.AddWithValue("@IDPERSONACOMPRA", Me.Dgv_Compradores.SelectedRows(0).Cells(0).Value)
                If Cb_RequiereVistoBueno.Checked = True Then
                    Comando.Parameters.AddWithValue("@IDPERSONAVISTOBUENO", Cu_Bp_VistoBueno.Cb_Persona.SelectedValue)
                Else
                    Comando.Parameters.AddWithValue("@IDPERSONAVISTOBUENO", -1)
                End If
                If Cb_RequiereVBSubgerencia.Checked = True Then
                    Comando.Parameters.AddWithValue("@IDPERSONAVISTOBUENOSUBGERENCIA", Cu_Bp_VBSubgerencia.Cb_Persona.SelectedValue)
                Else
                    Comando.Parameters.AddWithValue("@IDPERSONAVISTOBUENOSUBGERENCIA", -1)
                End If
                Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                conn.Open()
                Comando.Connection = conn
                Comando.ExecuteNonQuery()
                conn.Close()
            Else
                Exit Sub
            End If
        Else
            MsgBox("No se ha seleccionado ningun comprador", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub Cb_RequiereVistoBueno_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Cb_RequiereVistoBueno.CheckedChanged
        If Cb_RequiereVistoBueno.Checked = False Then
            Cu_Bp_VistoBueno.Cb_Persona.SelectedIndex = -1
        End If
    End Sub

    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Try
            filas = Cu_Bp_VistoBueno.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_Bp_VistoBueno.Tx_TextoCódigo.Text).ToString + "'")
            If filas.Length > 0 Then
                Dim fila As DataRow = filas(0)
                Me.Cu_Bp_VistoBueno.Cb_Persona.SelectedValue = fila("IDPERSONA")
            Else
                MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
            End If
        Catch ex As Exception
            Me.Cu_Bp_VistoBueno.Tx_TextoCódigo.Text = ""
        End Try
       
    End Sub


End Class