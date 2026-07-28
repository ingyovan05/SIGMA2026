Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_Sobres

    Dim DsSobre As New DatosSisControl.Ds_Siscontrol
    Dim DsSobrePara As New DatosSisControl.Ds_Siscontrol
    'Dim sc_DependenciaTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_DEPENDENCIATableAdapter
    'Dim SC_CONTRATISTATableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_CONTRATISTATableAdapter
    'Dim Sc_TrasportadorTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_EMPRESATRASPORTADORATableAdapter
    'Dim SC_BaseTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_BASETableAdapter


    Private bddatos As New FuncionesBase.ClaseCargarMaestras
  Public Editando As Boolean = False
  Public IdSobre As Integer
    Public Dependencia As Integer
    Private Año As String = CStr(Year(Date.Now))
    Private Consecutivo As Integer

    Private CargoPersonaPara As Boolean = False
    Private CargoPersonaDe As Boolean = False

    Public Sub CargarDatos()
        'If Editando Then
        '    'Editando, debo cargar el iddpendencia del registro
        '    VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = Dependencia
        'Else
        '    VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        'End If
        CargarCombos()

    If Editando Then
            'Dim sc_SobreTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_SOBRETableAdapter
            'sc_SobreTableAdapter.Fill(DsSobre.SC_SOBRE, 1, "x", IdSobre, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            'Dim fila As DataRow
            'If DsSobre.SC_SOBRE.Count > 0 Then
            '  fila = DsSobre.SC_SOBRE.Rows(0)
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT * FROM dbo.ListaSobre(@ACCION,@TIPO,@VARIABLE, @IDBASE)", conexion)
            comando.Parameters.AddWithValue("@ACCION", 1)
            comando.Parameters.AddWithValue("@TIPO", "x")
            comando.Parameters.AddWithValue("@VARIABLE", IdSobre)
            comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dtSobre As New DataTable
            Try
                conexion.Open()
                adaptador.Fill(dtSobre)
                conexion.Close()
                Dim fila As DataRow
                If dtSobre.Rows.Count > 0 Then
                    fila = dtSobre.Rows(0)
                    IdSobre = fila("IDSOBRE")
                    Dtp_Fecha.Value = fila("Fecha")
                    Cb_DeDependencia.SelectedValue = fila("IDDEPENDENCIADE")
                    Cu_BuscarDeFuncionario.Cb_Persona.SelectedValue = fila("IDPERSONADE")
                    'VariablesBase.VariablesBase.IddependenciaSiscontrolActual = fila("IDDEPENDENCIAPARA")
                    Tx_DirigidoA.Text = fila("PERSONAPARA")
                    Tb_Entidad.Text = Trim(fila("Entidad"))
                    Tb_Descripción.Text = Trim(fila("Descripcion"))
                    Cb_Empresa.SelectedValue = fila("IDEMPRESATRANSPORTADORA")
                    Tb_Guia.Text = Trim(fila("No.Guia"))
                    Tb_DirrecionPara.Text = Trim(fila("DIRECCIONPARA"))
                    If Year(fila("FECHADESPACHO")) <> "1900" Then
                        Dtp_Fechadespacho.Value = fila("FECHADESPACHO")
                        Dtp_Fechadespacho.Checked = True
                    Else
                        'Dtp_Fechadespacho.Value = ""
                    End If

                    Tb_CargoDe.Text = Trim(fila("CARGODE"))
                    Cu_CiudadPara.Cb_Ciudad.SelectedValue = fila("IDCODIGOPOBLACIONPARA")

                    Tb_CargoPara.Text = Trim(fila("CARGOPARA"))
                    TB_Telefono.Text = Trim(fila("TELEFONO"))

                    VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = fila("IDDEPENDENCIAFIRMA")

                    Me.Cu_CentroCosto1.IdCentroCosto = fila("IDCENTROCOSTO")
                    Me.Cu_CentroCosto1.Editando = 3
                    Me.Cu_CentroCosto1.CargarCentro()

                    Año = fila("Año")
                    Consecutivo = fila("Consecutivo")
                    Lb_CódigoArtículo.Visible = True
                    Lb_CódigoArtículo.Text = CStr(fila("Consecutivo")) + " - " + fila("Año")
                End If
            Catch ex As Exception
                conexion.Close()
                MsgBox(ex.Message)
            Finally
                conexion.Close()
            End Try
        Else
            Me.Cu_CentroCosto1.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoSisControl
            Me.Cu_CentroCosto1.Editando = 2
            Me.Cu_CentroCosto1.CargarCentro()
        End If

    End Sub

    Private Sub ClickEntidad(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim item As New ToolStripMenuItem
        item = sender
        Me.Tb_Entidad.Text = item.Text
    End Sub

    Dim dsCargar As New DataSet
    Private Sub CargarCombos()

        dsCargar = bddatos.CargarMaestrasSiscontrol(4, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, IdSobre, 1)

        CargarPersonas()

        Cu_CiudadPara.CargarDatos()
        Cu_CiudadPara.Cb_Ciudad.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "S", "CIUDADPARA", -1)
        Me.Cms_Base.Items.Clear()
        'Me.SC_BaseTableAdapter.Fill(DsSobre.SC_BASE)
        'For i = 0 To Me.DsSobre.SC_BASE.Rows.Count - 1
        For i = 0 To Me.dsCargar.Tables(0).Rows.Count - 1
            Dim fila As DataRow
            'fila = Me.DsSobre.SC_BASE.Rows(i)
            fila = Me.dsCargar.Tables(0).Rows(i)
            Dim Item As New ToolStripMenuItem("Base", Nothing, New System.EventHandler(AddressOf Me.ClickEntidad))
            Item.Text = fila("BASE")
            Me.Cms_Base.Items.Add(Item)
        Next

        'Me.Sc_TrasportadorTableAdapter.Fill(DsSobre.SC_EMPRESATRASPORTADORA)
        'Me.Cb_Empresa.DataSource = DsSobre.SC_EMPRESATRASPORTADORA
        Me.Cb_Empresa.DataSource = dsCargar.Tables(1)
        Me.Cb_Empresa.DisplayMember = "NOMBRE"
        Me.Cb_Empresa.ValueMember = "IDTRASPORTADORA"

        'Me.sc_DependenciaTableAdapter.Fill(DsSobrePara.SC_DEPENDENCIA, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        'Me.Cb_DeDependencia.DataSource = Me.DsSobrePara.SC_DEPENDENCIA
        Me.Cb_DeDependencia.DataSource = dsCargar.Tables(2)
        Me.Cb_DeDependencia.DisplayMember = "NOMBREDEPENDENCIA"
        Me.Cb_DeDependencia.ValueMember = "IDDEPENDENCIA"
        CargoPersonaDe = True
        Cb_DeDependencia.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "S", "DEPENDENCIADE", -1)

        CargarPersonaPorDependenciaDe()


        Dtp_Fechadespacho.Checked = False

    End Sub
  Private Sub CargarPersonas()
        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual

  End Sub
    Private Sub Bt_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Guardar.Click
        If ValidarSobre() = True Then
            GuardarSobre()
        End If
    End Sub

    Private Sub GuardarSobre()

        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarSobres")
        Comando.CommandType = CommandType.StoredProcedure

        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 2)
        End If

        Comando.Parameters.AddWithValue("@IDSOBRE", IdSobre)
        Comando.Parameters.AddWithValue("@AÑO", Año)
        Comando.Parameters.AddWithValue("@CONSECUTIVO", Consecutivo)
        Comando.Parameters.AddWithValue("@FECHASOBRE", Dtp_Fecha.Value)
        Comando.Parameters.AddWithValue("@ENTIDAD", UCase(Trim(Tb_Entidad.Text)))
        Comando.Parameters.AddWithValue("@IDDEPENDENCIADE", Cb_DeDependencia.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONADE", Cu_BuscarDeFuncionario.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@PERSONAPARA", Trim(UCase(Tx_DirigidoA.Text)))
        Comando.Parameters.AddWithValue("@DESCRIPCION", UCase(Trim(Tb_Descripción.Text)))
        Comando.Parameters.AddWithValue("@IDEMPRESATRANSPORTADORA", Cb_Empresa.SelectedValue)
        Comando.Parameters.AddWithValue("@GUIA", Trim(Tb_Guia.Text))

        If Dtp_Fechadespacho.Checked Then
            Comando.Parameters.AddWithValue("@FECHADESPACHO", Dtp_Fechadespacho.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHADESPACHO", "")
        End If

        Comando.Parameters.AddWithValue("@FECHAPLANILLA", "")


        Comando.Parameters.AddWithValue("@IDPERSONAFIRMA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAREGISTRO", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAMODIFICACION", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAANULACION", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAANULA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@ANULADA", "N")
        Comando.Parameters.AddWithValue("@IMPRESA", "N")
        Comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Comando.Parameters.AddWithValue("@IDCODIGOPOBLACIONPARA", Cu_CiudadPara.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@DIRECCIONPARA", UCase(Tb_DirrecionPara.Text))
        Comando.Parameters.AddWithValue("@CARGODE", UCase(Trim(Tb_CargoDe.Text)))
        Comando.Parameters.AddWithValue("@CARGOPARA", UCase(Trim(Tb_CargoPara.Text)))

    Comando.Parameters.AddWithValue("@IDCENTROCOSTO", Me.Cu_CentroCosto1.IdCentroCosto)

    Comando.Parameters.AddWithValue("@TELEFONO", UCase(Trim(TB_Telefono.Text)))

        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()

        If Editando = False Then
            MsgBox("El consecutivo del sobre es: " + CStr(msgParam.Value), MsgBoxStyle.Information, "CONSECUTIVO")
        End If

        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "S", "DEPENDENCIADE", Cb_DeDependencia.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "S", "FUNCIONARIODE", Cu_BuscarDeFuncionario.Cb_Persona.SelectedValue)
        'FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "S", "DEPENDENCIAPARA", Cb_DependenciaPara.SelectedValue)
        'FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "S", "FUNCIONARIOPARA", Cu_BuscarParaFuncionario.Cb_Persona.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "S", "CIUDADPARA", Cu_CiudadPara.Cb_Ciudad.SelectedValue)


        conn.Close()
        Me.Close()
    End Sub

    Private Function ValidarSobre() As Boolean

        If Trim(Tx_DirigidoA.Text) = "" Then
            MsgBox("Debe Agregar la persona a la cual va dirigida", MsgBoxStyle.Critical, "SOBRE")
            Me.Tx_DirigidoA.Focus()
            ValidarSobre = False
            Exit Function
        End If

        If IsNothing(Cu_BuscarDeFuncionario.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione funcionario", MsgBoxStyle.Critical, "FUNCIONARIO")
            ValidarSobre = False
            Cu_BuscarDeFuncionario.Cb_Persona.Focus()
            Exit Function
        End If

        If Trim(Tb_CargoDe.Text) = "" Then
            MsgBox("Digite el cargo del funcionario", MsgBoxStyle.Critical, "FUNCIONARIO")
            Me.Tb_CargoDe.Focus()
            ValidarSobre = False
            Exit Function
        End If

        If IsNothing(Cu_CiudadPara.Cb_Ciudad.SelectedValue) Then
            MsgBox("Seleccione ciudad destino ", MsgBoxStyle.Critical, "CIUDAD")
            ValidarSobre = False
            Cu_CiudadPara.Cb_Ciudad.Focus()
            Exit Function
        End If

        If Trim(Tb_DirrecionPara.Text) = "" Then
            MsgBox("Digite la dirección", MsgBoxStyle.Critical, "DIRECCIÓN")
            Me.Tb_DirrecionPara.Focus()
            ValidarSobre = False
            Exit Function
        End If

        If Trim(Tb_Descripción.Text) = "" Then
            MsgBox("Digite la Descripción", MsgBoxStyle.Critical, "Descripción")
            Me.Tb_Descripción.Focus()
            ValidarSobre = False
            Exit Function
        End If

        If IsNothing(Cb_Empresa.SelectedValue) Then
            MsgBox("Seleccione empresa transportadora", MsgBoxStyle.Critical, "TRANSPORTADORA")
            ValidarSobre = False
            Cb_Empresa.Focus()
            Exit Function
        End If

        ValidarSobre = True
    End Function

    Private Sub Btn_AgregarTransportadora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AgregarTransportadora.Click
        Dim frAgregarTrasportador As New Fr_BuscarEmpTrasmporte
        frAgregarTrasportador.ShowDialog()
        'Me.Sc_TrasportadorTableAdapter.Fill(DsSobre.SC_EMPRESATRASPORTADORA)
        'Me.Cb_Empresa.DataSource = DsSobre.SC_EMPRESATRASPORTADORA
        Me.Cb_Empresa.DataSource = dsCargar.Tables(1)
        Me.Cb_Empresa.DisplayMember = "NOMBRE"
        Me.Cb_Empresa.ValueMember = "IDTRASPORTADORA"
    End Sub

    Private Sub Bt_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    'Private Sub Cb_DependenciaPara_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CargarPersonaPorDependenciaPara()
    'End Sub

    'Private Sub CargarPersonaPorDependenciaPara()
    '    If CargoPersonaPara Then
    '        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = Cb_DependenciaPara.SelectedValue
    '        Cu_BuscarParaFuncionario.CargarDatos()
    '        Cu_BuscarDeFuncionario.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "S", "FUNCIONARIOPARA", Cu_BuscarParaFuncionario.Cb_Persona.SelectedValue)
    '    End If
    'End Sub

    Private Sub Cb_DeDependencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_DeDependencia.SelectedIndexChanged
        CargarPersonaPorDependenciaDe()
    End Sub

    Private Sub CargarPersonaPorDependenciaDe()
        If CargoPersonaDe Then
            VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = Cb_DeDependencia.SelectedValue
            Cu_BuscarDeFuncionario.CargarDatos()
            Cu_BuscarDeFuncionario.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "S", "FUNCIONARIODE", -1)
        End If
    End Sub

    Private Sub Bt_BuscarPersona_Click(sender As Object, e As EventArgs) Handles Bt_BuscarPersona.Click
        Dim frBuscarPersona As New FormulariosClasesBase.Fr_BuscarPersona
        frBuscarPersona.Cargar_Tabla("P")
        frBuscarPersona.ShowDialog()
        Try
            If frBuscarPersona.IdPersona <> -1 Then
                Me.Tx_DirigidoA.Text = Trim(frBuscarPersona.NombrePersona)
            End If
        Catch ex As Exception
        End Try
    End Sub

  Dim Temp_IdDependencia As Integer = -1

    Private Sub Fr_Sobres(sender As Object, e As EventArgs) Handles Me.Activated
        If Temp_IdDependencia <> -1 Then
            VariablesBase.VariablesBase.IddependenciaSiscontrolActual = Temp_IdDependencia
        End If
    End Sub

    Public Sub CambiarDependenciaParaAsociar()
        Temp_IdDependencia = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        VariablesBase.VariablesBase.IddependenciaSiscontrolActual = Me.Cb_DeDependencia.SelectedValue
    End Sub


    'Para cargar al asociar una persona 
    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1, Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_BuscarDeFuncionario.Cb_Persona.SelectedValue
            Me.Cu_BuscarDeFuncionario.CargarDatos()
            Me.Cu_BuscarDeFuncionario.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarDeFuncionario.CargarCajaTexto()
        Catch ex As Exception
        End Try

        'Try
        '    temp = Me.Cu_BuscarFirma.Cb_Persona.SelectedValue
        '    Me.Cu_BuscarFirma.CargarDatos()
        '    Me.Cu_BuscarFirma.Cb_Persona.SelectedValue = temp
        '    Me.Cu_BuscarFirma.CargarCajaTexto()
        'Catch ex As Exception
        'End Try
   

        Select Case NOMBRECOMPONENTE
            Case Cu_BuscarDeFuncionario.Name
                Me.Cu_BuscarDeFuncionario.Cb_Persona.SelectedValue = IDPERSONA

                'Case Cu_BuscarFirma.Name
                '    Me.Cu_BuscarFirma.Cb_Persona.SelectedValue = IDPERSONA

        End Select

    End Sub


End Class