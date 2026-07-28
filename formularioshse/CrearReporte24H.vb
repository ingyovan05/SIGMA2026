Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_CrearReporte24H
    Public TIPO As Integer
    Public EDITANDO As Boolean
    Public IDREPORTE As Integer
    Public IDREPORTEMODIFICANDO As Integer = -1
    Public TIPOINCIDENTE As Integer
    Public guardado As Boolean

    Private dtReporte As DataTable
    Private dtReportePersona As DataTable
    Private dtTestigos As DataTable
    Private dtAcciones As DataTable
    Private filareporte As DataRow
    Private filareportepersona As DataRow
    Private filatestigos As DataRow
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private Sub CrearReporte24H_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub ComportamientoPredeterminado()

        Me.Tb_Contrato.Focus()
        Me.Dgv_AccionesInmediatas.Columns(2).ReadOnly = True
        Me.TabControl1.Controls.Remove(Me.TabPage2)
        Me.TabControl1.Controls.Remove(Me.TabPage3)
        Lb_Empleador.Hide()
        Tx_Empleador.Hide()
        Lb_OtrosAnexos.Hide()
        Tb_OtrosAnexos.Hide()
        Lb_Trasladado.Hide()
        Tb_Traslado.Hide()
        Lb_TrabajoHabitual.Hide()
        Tx_TrabajoHabitual.Hide()
        Me.Dgv_Testigos.Columns(1).ReadOnly = True
        Me.Dgv_Testigos.Columns(2).ReadOnly = True

        DTP_FechaIncidente.MaxDate = Today
        DTP_FechaNacimiento.MaxDate = Today
        DTP_InicioContrato.MaxDate = Today

        DTP_HoraIncidente.Value = Today
        DTP_HorasLaboradas.Value = Date.Today

        'Poner los Combobox en selectedindex -1
        Me.Cb_Proyecto.SelectedIndex = -1
        Me.Cb_TipoIncidente.SelectedIndex = -1
        Me.Cb_TipoConsecuencia.SelectedIndex = -1
        Me.Cb_Area.SelectedIndex = -1
        Me.Cb_ActividadPrincipal.SelectedIndex = -1
        Me.Cu_CiudadIncidente.Cb_Ciudad.SelectedIndex = -1
        Me.Cb_Severidad.SelectedIndex = -1
        Me.Cb_Recurrencia.SelectedIndex = -1
        Me.Cu_BuscarPersonaReporta.Cb_Persona.SelectedIndex = -1
        Me.Cb_CargoReporta.SelectedIndex = -1
        Me.Cu_BuscarPersonaValida1.Cb_Persona.SelectedIndex = -1
        Me.Cu_BuscarPersonaValida2.Cb_Persona.SelectedIndex = -1
        Me.Cu_BuscarPersonaValida3.Cb_Persona.SelectedIndex = -1
        Me.Cu_BuscarPersonaValida4.Cb_Persona.SelectedIndex = -1
        Me.Cb_TipoVinculacion.SelectedIndex = -1
        Me.Cu_BuscarPersonaAfectada.Cb_Persona.SelectedIndex = -1
        Me.Cb_EPS.SelectedIndex = -1
        Me.Cb_AFP.SelectedIndex = -1
        Me.Cb_CargoPersonaAccidente.SelectedIndex = -1
        Me.Cb_OcupacionHabitual.SelectedIndex = -1
        Me.Cb_JornadaHabitual.SelectedIndex = -1
        Me.Cb_JornadaIncidente.SelectedIndex = -1
        Me.Cb_SitioIncidente.SelectedIndex = -1
        Me.Cb_TipoLesion.SelectedIndex = -1
        Me.Cb_ParteAfectada.SelectedIndex = -1
        Me.Cb_AgenteAccidente.SelectedIndex = -1
        Me.Cb_MecanismoAccidente.SelectedIndex = -1
        Me.Cb_AtencionInmediata.SelectedIndex = -1

        If TIPO = 1 Then
            If Cb_TipoIncidente.SelectedIndex <> -1 Then
                If Cb_TipoIncidente.SelectedValue.ToString = "1" Then
                    Me.TabControl1.TabPages.Add(Me.TabPage2)
                    dsCargar = bddatos.CargarMaestrasHSE(0, 1, 1, 1)
                    CargarComboboxSalud()
                    Cb_TipoConsecuencia.DataSource = dsCargar.Tables(7)
                    Cb_TipoConsecuencia.ValueMember = "ID"
                    Cb_TipoConsecuencia.DisplayMember = "NOMBRE"

                    Cb_Severidad.DataSource = dsCargar.Tables(8)
                    Cb_Severidad.ValueMember = "IDMATRIZPERDIDA"
                    Cb_Severidad.DisplayMember = "NOMBREMATRIZPERDIDA"
                End If
            End If
        End If

        Me.Tb_CategoriaResultante.Enabled = False
        If TIPO = 2 Then
            Me.Cb_Area.Enabled = False
            Me.Cb_TipoIncidente.Enabled = False
            Me.Cb_Proyecto.Enabled = False
            Me.Cb_ActividadPrincipal.Enabled = False
            Me.Tb_Contrato.Enabled = False
            Me.Ck_Empleador.Enabled = False
            Me.Tx_Empleador.Enabled = False
        End If

    End Sub

    Dim dsCargar As New DataSet

    Public Sub CargarComboboxSalud()

        Cb_TipoVinculacion.DataSource = dsCargar.Tables(11)
        Cb_TipoVinculacion.ValueMember = "ID"
        Cb_TipoVinculacion.DisplayMember = "VINCULACION"

        Cb_CargoPersonaAccidente.DataSource = dsCargar.Tables(5)
        Cb_CargoPersonaAccidente.ValueMember = "ID"
        Cb_CargoPersonaAccidente.DisplayMember = "NOMBRE"

        Cb_OcupacionHabitual.DataSource = dsCargar.Tables(5).Copy
        Cb_OcupacionHabitual.ValueMember = "ID"
        Cb_OcupacionHabitual.DisplayMember = "NOMBRE"

        Cb_JornadaHabitual.DataSource = dsCargar.Tables(12)
        Cb_JornadaHabitual.ValueMember = "ID"
        Cb_JornadaHabitual.DisplayMember = "JORNADAHABITUAL"

        Cb_JornadaIncidente.DataSource = dsCargar.Tables(13)
        Cb_JornadaIncidente.ValueMember = "ID"
        Cb_JornadaIncidente.DisplayMember = "JORNADAINCIDENTE"

        Cb_AtencionInmediata.DataSource = dsCargar.Tables(14)
        Cb_AtencionInmediata.ValueMember = "ID"
        Cb_AtencionInmediata.DisplayMember = "ATENCIONINMEDIATA"

        DGVCB_Cargo.DataSource = dsCargar.Tables(5).Copy
        DGVCB_Cargo.DisplayMember = "NOMBRE"
        DGVCB_Cargo.ValueMember = "ID"

        Cb_SitioIncidente.DataSource = dsCargar.Tables(15)
        Cb_SitioIncidente.DisplayMember = "NOMBRE"
        Cb_SitioIncidente.ValueMember = "ID"

        Cb_TipoLesion.DataSource = dsCargar.Tables(16)
        Cb_TipoLesion.DisplayMember = "NOMBRE"
        Cb_TipoLesion.ValueMember = "ID"

        Cb_ParteAfectada.DataSource = dsCargar.Tables(17)
        Cb_ParteAfectada.DisplayMember = "NOMBRE"
        Cb_ParteAfectada.ValueMember = "ID"

        Cb_AgenteAccidente.DataSource = dsCargar.Tables(18)
        Cb_AgenteAccidente.DisplayMember = "NOMBRE"
        Cb_AgenteAccidente.ValueMember = "ID"

        Cb_MecanismoAccidente.DataSource = dsCargar.Tables(19)
        Cb_MecanismoAccidente.DisplayMember = "NOMBRE"
        Cb_MecanismoAccidente.ValueMember = "ID"

        Cb_EPS.DataSource = dsCargar.Tables(21)
        Cb_EPS.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cb_EPS.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"

        Cb_AFP.DataSource = dsCargar.Tables(22)
        Cb_AFP.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cb_AFP.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"

        'Poner los Combobox en selectedindex -1
        Me.Cb_TipoVinculacion.SelectedIndex = -1
        Me.Cu_BuscarPersonaAfectada.Cb_Persona.SelectedIndex = -1
        Me.Cb_EPS.SelectedIndex = -1
        Me.Cb_AFP.SelectedIndex = -1
        Me.Cb_CargoPersonaAccidente.SelectedIndex = -1
        Me.Cb_OcupacionHabitual.SelectedIndex = -1
        Me.Cb_JornadaHabitual.SelectedIndex = -1
        Me.Cb_JornadaIncidente.SelectedIndex = -1
        Me.Cb_SitioIncidente.SelectedIndex = -1
        Me.Cb_TipoLesion.SelectedIndex = -1
        Me.Cb_ParteAfectada.SelectedIndex = -1
        Me.Cb_AgenteAccidente.SelectedIndex = -1
        Me.Cb_MecanismoAccidente.SelectedIndex = -1
        Me.Cb_AtencionInmediata.SelectedIndex = -1

    End Sub
    Public Sub CargarTablas()
        Dim identificador As Long
        Dim tipo As Integer
        Dim subtipo As Integer

        If IDREPORTEMODIFICANDO < 0 Then
            identificador = IDREPORTE
            tipo = 1 'Crear
        Else
            identificador = IDREPORTEMODIFICANDO
            tipo = 2 'Editar
            subtipo = TIPOINCIDENTE
        End If

        dsCargar = bddatos.CargarMaestrasHSE(0, identificador, tipo, subtipo)
        'Lleno los combobox
        Cb_Area.DataSource = dsCargar.Tables(4)
        Cb_Area.DisplayMember = "NOMBRE"
        Cb_Area.ValueMember = "ID"

        Cb_CargoReporta.DataSource = dsCargar.Tables(5)
        Cb_CargoReporta.DisplayMember = "NOMBRE"
        Cb_CargoReporta.ValueMember = "ID"

        Cb_ActividadPrincipal.DataSource = dsCargar.Tables(6)
        Cb_ActividadPrincipal.DisplayMember = "NOMBRE"
        Cb_ActividadPrincipal.ValueMember = "ID"

        Cb_TipoConsecuencia.DataSource = dsCargar.Tables(7)
        Cb_TipoConsecuencia.ValueMember = "ID"
        Cb_TipoConsecuencia.DisplayMember = "NOMBRE"

        Cb_Severidad.DataSource = dsCargar.Tables(8)
        Cb_Severidad.ValueMember = "IDMATRIZPERDIDA"
        Cb_Severidad.DisplayMember = "NOMBREMATRIZPERDIDA"

        Cb_TipoIncidente.DataSource = dsCargar.Tables(9)
        Cb_TipoIncidente.DisplayMember = "NOMBRE"
        Cb_TipoIncidente.ValueMember = "ID"

        Cb_Recurrencia.DataSource = dsCargar.Tables(10)
        Cb_Recurrencia.DisplayMember = "RECURRENCIA"
        Cb_Recurrencia.ValueMember = "ID"

        Cb_Proyecto.DataSource = dsCargar.Tables(20)
        Cb_Proyecto.DisplayMember = "NOMBREBASE"
        Cb_Proyecto.ValueMember = "IDBASEHSE"

        Me.Cu_BuscarPersonaReporta.CargarDatos()
        Me.Cu_BuscarPersonaValida2.CargarDatos()
        Me.Cu_BuscarPersonaAfectada.CargarDatos()
        Me.Cu_BuscarPersonaValida3.CargarDatos()
        Me.Cu_BuscarPersonaValida4.CargarDatos()
        Me.Cu_BuscarPersonaValida1.CargarDatos()
        Me.Cu_CiudadIncidente.CargarDatos()

        Dgv_AccionesInmediatas.AutoGenerateColumns = False
        dtAcciones = dsCargar.Tables(3)
        Dgv_AccionesInmediatas.DataSource = dtAcciones

        If dtAcciones.Rows.Count < 3 Then
            dtAcciones.Rows.Add()
        End If

        dtTestigos = dsCargar.Tables(2)
        Me.Dgv_Testigos.Columns(0).DataPropertyName = "Cedula"
        Me.Dgv_Testigos.Columns(1).DataPropertyName = "Nombre"
        Me.Dgv_Testigos.Columns(2).DataPropertyName = "Cargo"
        Me.Dgv_Testigos.DataSource = dtTestigos
        'llenar tablas con la informacion para cuando se edita
        If Me.TIPO = 2 Then
            dtReporte = dsCargar.Tables(0)
            dtReportePersona = dsCargar.Tables(1)
            If dtTestigos.Rows.Count > 0 Then
                Me.Dgv_Testigos.Columns(2).ReadOnly = False
            End If

            If dtReporte.Rows.Count > 0 Then
                filareporte = dtReporte.Rows(0)
                If Me.TIPOINCIDENTE = 1 Then
                    filareportepersona = dtReportePersona.Rows(0)
                    DGVCB_Cargo.DataSource = dsCargar.Tables(5)
                    DGVCB_Cargo.DisplayMember = "NOMBRE"
                    DGVCB_Cargo.ValueMember = "ID"
                End If
            End If
        End If
    End Sub

    Public Sub LlenarReporte()
        If TIPO = 2 Then
            Me.Tb_Contrato.Text = filareporte("CONTRATO")
            Me.Cb_Proyecto.SelectedValue = filareporte("IDBASE")
            Me.Cb_TipoIncidente.SelectedValue = filareporte("IDTIPOINCIDENTE")
            Me.Cb_TipoConsecuencia.SelectedValue = filareporte("IDTIPOCONSECUENCIA")
            Me.Cb_Area.SelectedValue = filareporte("IDAREA")
            Ck_Empleador.CheckState = Windows.Forms.CheckState.Unchecked
            If filareporte("EMPLEADOR").ToString <> "ISMOCOL" Then
                Me.Ck_Empleador.Checked = False
                Me.Tx_Empleador.Show()
                Me.Tx_Empleador.Text = filareporte("EMPLEADOR")
            Else
                Me.Ck_Empleador.Checked = True
            End If
            Me.Cb_ActividadPrincipal.SelectedValue = filareporte("ACTIVIDADPRINCIPAL")
            Me.Tb_SitioIncidente.Text = filareporte("SITIOINCIDENTE")
            If filareporte("ZONAOCURRIO").ToString = "U" Then
                Me.Rb_ZonaUrbana.Checked = True
            Else
                Me.Rb_ZonaRural.Checked = True
            End If

            Me.Cu_CiudadIncidente.Cb_Ciudad.SelectedValue = filareporte("MUNICIPIO")
            If filareporte("LUGARACCIDENTE").ToString = "D" Then
                Me.Rb_LugarDentroEmpresa.Checked = True
            Else
                Me.Rb_LugarFueraEmpresa.Checked = True
            End If

            Me.DTP_FechaIncidente.Checked = True
            Me.DTP_FechaIncidente.Value = filareporte("FECHAACCIDENTE")
            Me.DTP_HoraIncidente.Checked = True
            Me.DTP_HoraIncidente.Value = filareporte("HORAACCIDENTE")

            Me.DTP_HorasLaboradas.Checked = True
            Me.DTP_HorasLaboradas.Value = filareporte("HORASLABORADASDIA")

            Me.Tb_Descripcion.Text = filareporte("DESCRIPCIONINCIDENTE")
            Me.Cb_Severidad.SelectedValue = filareporte("SEVERIDADPERDIDAPOTENCIAL")

            Dim Recurrencia As String = filareporte("CATEGORIAPERDIDAPOTENCIAL")
            Recurrencia = Recurrencia(1)
            If Recurrencia = "1" Then
                Me.Cb_Recurrencia.SelectedValue = 1
            Else
                If Recurrencia = "2" Then
                    Me.Cb_Recurrencia.SelectedValue = 2
                Else
                    Me.Cb_Recurrencia.SelectedValue = 3
                End If
            End If

            Me.Tb_EvitadoAccidente.Text = filareporte("EVITADOINCIDENTE")

            Dim anexos As String = filareporte("ANEXOS")
            Me.Ck_AnexoDibujos.CheckState = Windows.Forms.CheckState.Unchecked
            Me.Ck_AnexoFotos.CheckState = Windows.Forms.CheckState.Unchecked
            Me.Ck_AnexoInformesMedicos.CheckState = Windows.Forms.CheckState.Unchecked
            Me.Ck_OtrosAnexos.CheckState = Windows.Forms.CheckState.Unchecked

            Dim ch As Char = anexos(0)
            If ch = "S" Then
                Me.Ck_AnexoDibujos.Checked = True
            Else
                Me.Ck_AnexoDibujos.Checked = False
            End If
            ch = anexos(1)
            If ch = "S" Then
                Me.Ck_AnexoFotos.Checked = True
            Else
                Me.Ck_AnexoFotos.Checked = False
            End If
            ch = anexos(2)
            If ch = "S" Then
                Me.Ck_AnexoInformesMedicos.Checked = True
            Else
                Me.Ck_AnexoInformesMedicos.Checked = False
            End If
            ch = anexos(3)
            If ch = "S" Then
                Me.Ck_OtrosAnexos.Checked = True
                Me.Tb_OtrosAnexos.Text = filareporte("OTROSANEXOS")
            Else
                Me.Ck_OtrosAnexos.Checked = False
            End If

            Me.Cu_BuscarPersonaReporta.Cb_Persona.SelectedValue = filareporte("IDPERSONAREPORTA")
            Me.Cb_CargoReporta.SelectedValue = filareporte("IDCARGOPERSONAREPORTA")
            Me.Cu_BuscarPersonaValida1.Cb_Persona.SelectedValue = filareporte("IDVALIDA_1")
            Me.Cu_BuscarPersonaValida2.Cb_Persona.SelectedValue = filareporte("IDVALIDA_2")
            Me.Cu_BuscarPersonaValida3.Cb_Persona.SelectedValue = filareporte("IDVALIDA_3")
            Me.Cu_BuscarPersonaValida4.Cb_Persona.SelectedValue = filareporte("IDVALIDA_4")

            If filareporte("IDTIPOINCIDENTE").ToString = "1" Then

                Me.TabControl1.Controls.Remove(Me.TabPage2)
                Me.TabControl1.Controls.Remove(Me.TabPage3)
                Me.TabControl1.TabPages.Add(Me.TabPage2)
                If dtTestigos.Rows.Count > 0 Then
                    Me.Rb_TestigosSi.Checked = True
                    Dim indiceTabpage As Integer = Me.TabControl1.TabPages.IndexOf(Me.TabPage3)
                    indiceTabpage = Me.TabControl1.TabPages.IndexOf(Me.TabPage2)
                    Me.TabControl1.TabPages.Add(Me.TabPage3)
                    Me.Dgv_Testigos.Columns("Cedula").DataPropertyName = "Cedula"
                    Me.Dgv_Testigos.Columns("Nombre").DataPropertyName = "Nombre"
                    Me.Dgv_Testigos.Columns("DGVCB_Cargo").DataPropertyName = "Cargo"
                    Me.Dgv_Testigos.DataSource = dtTestigos
                Else
                    Me.Rb_TestigosNo.Checked = False
                    Me.TabControl1.Controls.Remove(Me.TabPage3)
                End If
                CargarComboboxSalud()

                Me.Cb_TipoVinculacion.SelectedValue = filareportepersona("TIPOVINCULACION")

                Me.Cu_BuscarPersonaAfectada.Cb_Persona.SelectedValue = filareportepersona("IDPERSONAACCIDENTE")
                Me.DTP_FechaNacimiento.Checked = True
                Me.DTP_FechaNacimiento.Value = filareportepersona("FECHANACIMIENTO")

                If filareportepersona("GENERO").ToString = "M" Then
                    Me.Rb_Masculino.Checked = True
                Else
                    Me.Ck_Empleador.Checked = False
                End If

                Me.Cb_EPS.SelectedValue = filareportepersona("EPS")
                Me.Cb_AFP.SelectedValue = filareportepersona("AFP")

                Me.Tb_Direccion.Text = filareportepersona("DIRECCION")
                Me.Tb_Telefono.Text = filareportepersona("TELEFONO")
                Me.Tb_TelefonoMovil.Text = filareportepersona("TELEFONOMOVIL")
                Me.Tb_CorreoElectronico.Text = filareportepersona("CORREOELECTRONICO")
                Me.Cb_CargoPersonaAccidente.SelectedValue = filareportepersona("IDCARGOPERSONACCIDENTE")
                Me.Cb_OcupacionHabitual.SelectedValue = filareportepersona("OCUPACIONHABITUAL")
                Me.Tb_Salario.Text = filareportepersona("SALARIO")
                Me.Cb_JornadaHabitual.SelectedValue = filareportepersona("JORNADAHABITUAL")
                Me.DTP_InicioContrato.Checked = True
                Me.DTP_InicioContrato.Value = filareportepersona("FECHAINICIOCONTRATO")

                If filareportepersona("CAUSOMUERTE") = "S" Then
                    Me.Rb_MuerteSi.Checked = True
                Else
                    Me.Rb_MuerteNo.Checked = True
                End If

                Me.Cb_JornadaIncidente.SelectedValue = filareportepersona("JORNADAINCIDENTE")
                If filareportepersona("TRABAJOHABITUAL") = "S" Then
                    Me.Rb_TrabajoHabitualSi.Checked = True
                    Me.Rb_TrabajoHabitualNo.Checked = False
                    Me.Lb_TrabajoHabitual.Hide()
                    Me.Tx_TrabajoHabitual.Hide()
                Else
                    Me.Rb_TrabajoHabitualSi.Checked = False
                    Me.Rb_TrabajoHabitualNo.Checked = True
                    Me.Lb_TrabajoHabitual.Show()
                    Me.Tx_TrabajoHabitual.Text = filareportepersona("OTROTRABAJOHABITUAL")
                    Me.Tx_TrabajoHabitual.Show()
                End If

                Me.Cb_SitioIncidente.SelectedValue = filareportepersona("SITIOACCIDENTE")
                If filareportepersona("SITIOACCIDENTE").ToString = "236" Then
                    Me.Tb_OtroSitioIncidente.Text = filareportepersona("OTROSITIOACCIDENTE")
                    Me.Tb_OtroSitioIncidente.Show()
                End If

                Me.Cb_TipoLesion.SelectedValue = filareportepersona("TIPOLESION")
                If filareportepersona("TIPOLESION").ToString = "252" Then
                    Me.Tb_OtroTipoLesion.Text = filareportepersona("OTROTIPOLESION")
                    Me.Tb_OtroTipoLesion.Show()
                End If

                Dim a As String = filareportepersona("PARTECUERPOAFECTADA").ToString
                Me.Cb_ParteAfectada.SelectedValue = filareportepersona("PARTECUERPOAFECTADA")
                If filareportepersona("PARTECUERPOAFECTADA").ToString = "287" Then
                    Me.Tb_OtraParteAfectada.Text = filareportepersona("OTRAPARTECUERPOAFECTADA").ToString
                    Me.Tb_OtraParteAfectada.Show()
                End If

                Dim b As Integer = filareportepersona("AGENTEACCIDENTE")
                Me.Cb_AgenteAccidente.SelectedValue = filareportepersona("AGENTEACCIDENTE")
                If filareportepersona("AGENTEACCIDENTE").ToString = "297" Then
                    Me.Tb_OtroAgenteAccidente.Text = filareportepersona("OTROAGENTEACCIDENTE")
                    Me.Tb_OtroAgenteAccidente.Show()
                End If

                Me.Cb_MecanismoAccidente.SelectedValue = filareportepersona("MECANISMO")
                If filareportepersona("MECANISMO").ToString = "305" Then
                    Me.Tb_OtroMecanismoAccidente.Text = filareportepersona("OTROMECANISMO")
                    Me.Tb_OtroMecanismoAccidente.Show()
                End If

                Me.Tb_DiagnosticoLesion.Text = filareportepersona("DIAGNOSTICO")

                Me.Cb_AtencionInmediata.SelectedValue = filareportepersona("TIPOATENCIONINMEDIATA")
                If filareportepersona("TIPOATENCIONINMEDIATA").ToString = "5" Then
                    Me.Tb_Traslado.Text = filareportepersona("TRASLADO")
                End If

                If dtTestigos.Rows.Count > 0 Then
                    Me.Rb_TestigosSi.Checked = True
                Else
                    Me.Rb_TestigosNo.Checked = True
                End If

            End If
        End If
    End Sub
    Private Sub Cb_TipoIncidente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoIncidente.SelectedIndexChanged
        If TIPO = 1 Or EDITANDO = True Then
            If Cb_TipoIncidente.SelectedIndex <> -1 Then
                'Tipo Salud
                If Cb_TipoIncidente.SelectedValue.ToString() = "1" Then
                    Me.TabControl1.Controls.Remove(Me.TabPage2)
                    Me.TabControl1.Controls.Remove(Me.TabPage3)
                    Me.TabControl1.TabPages.Insert(1, Me.TabPage2)
                    Rb_TestigosSi.Checked = False
                    Rb_TestigosNo.Checked = False

                    If Rb_TestigosSi.Checked Then
                        Me.TabControl1.TabPages.Insert(2, Me.TabPage3)
                    End If
                    dsCargar = bddatos.CargarMaestrasHSE(0, 1, 1, 1)
                    CargarComboboxSalud()
                Else
                    'Tipo Seguridad
                    If Cb_TipoIncidente.SelectedValue.ToString() = "2" Then
                        Me.TabControl1.Controls.Remove(Me.TabPage2)
                        Me.TabControl1.Controls.Remove(Me.TabPage3)
                        dsCargar = bddatos.CargarMaestrasHSE(0, 1, 1, 2)
                    Else
                        'Tipo Ambiental
                        If Cb_TipoIncidente.SelectedValue.ToString() = "3" Then
                            Me.TabControl1.Controls.Remove(Me.TabPage2)
                            Me.TabControl1.Controls.Remove(Me.TabPage3)
                            dsCargar = bddatos.CargarMaestrasHSE(0, 1, 1, 3)
                        Else
                            'Tipo Casi-Accidente
                            If Cb_TipoIncidente.SelectedValue.ToString() = "4" Then
                                Me.TabControl1.Controls.Remove(Me.TabPage2)
                                Me.TabControl1.Controls.Remove(Me.TabPage3)
                                dsCargar = bddatos.CargarMaestrasHSE(0, 1, 1, 4)
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Cb_TipoConsecuencia.DataSource = dsCargar.Tables(7)
        Cb_TipoConsecuencia.ValueMember = "ID"
        Cb_TipoConsecuencia.DisplayMember = "NOMBRE"

        Cb_Severidad.DataSource = dsCargar.Tables(8)
        Cb_Severidad.ValueMember = "IDMATRIZPERDIDA"
        Cb_Severidad.DisplayMember = "NOMBREMATRIZPERDIDA"

        Me.Cb_TipoConsecuencia.SelectedIndex = -1
        Me.Cb_Severidad.SelectedIndex = -1
        Me.Cb_Recurrencia.SelectedIndex = -1

    End Sub

    Private Sub Cb_SitioIncidente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_SitioIncidente.SelectedIndexChanged
        If Cb_SitioIncidente.Text = "Otro sitio incidente" Then
            Tb_OtroSitioIncidente.Show()
            Lb_SitioIncidente.Show()
        Else
            Tb_OtroSitioIncidente.Hide()
            Lb_SitioIncidente.Hide()
        End If
    End Sub

    Private Sub Cb_TipoLesion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoLesion.SelectedIndexChanged
        If Cb_TipoLesion.Text = "Otro tipo lesion" Then
            Tb_OtroTipoLesion.Show()
            Lb_TipoLesion.Show()
        Else
            Tb_OtroTipoLesion.Hide()
            Lb_TipoLesion.Hide()
        End If
    End Sub

    Private Sub Cb_ParteAfectada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_ParteAfectada.SelectedIndexChanged
        If Cb_ParteAfectada.Text = "Otra parte del cuerpo" Then
            Tb_OtraParteAfectada.Show()
            Lb_ParteAfectada.Show()
        Else
            Tb_OtraParteAfectada.Hide()
            Lb_ParteAfectada.Hide()
        End If
    End Sub

    Private Sub Cb_AgenteAccidente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_AgenteAccidente.SelectedIndexChanged
        If Cb_AgenteAccidente.Text = "Otro agente accidente" Then
            Tb_OtroAgenteAccidente.Show()
            Lb_AgenteAccidente.Show()
        Else
            Tb_OtroAgenteAccidente.Hide()
            Lb_AgenteAccidente.Hide()
        End If
    End Sub

    Private Sub Cb_MecanismoAccidente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_MecanismoAccidente.SelectedIndexChanged
        If Cb_MecanismoAccidente.Text = "Otro mecanismo accidente" Then
            Tb_OtroMecanismoAccidente.Show()
            Lb_Mecanismo.Show()
        Else
            Tb_OtroMecanismoAccidente.Hide()
            Lb_Mecanismo.Hide()
        End If
    End Sub

    Private Sub Cb_AtencionInmediata_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_AtencionInmediata.SelectedIndexChanged
        If Cb_AtencionInmediata.Text <> "Traslado a centro de Atención" Then
            Lb_Trasladado.Hide()
            Tb_Traslado.Hide()
        Else
            Lb_Trasladado.Show()
            Tb_Traslado.Show()
        End If
    End Sub

    Private Sub Empleador_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_Empleador.CheckedChanged
        If Ck_Empleador.Checked = True Then
            Lb_Empleador.Hide()
            Tx_Empleador.Hide()
        End If
        If Ck_Empleador.Checked = False Then
            Lb_Empleador.Show()
            Tx_Empleador.Text = ""
            Tx_Empleador.Show()
        End If
    End Sub

    Private Sub Rb_TrabajoHabitualSi_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_TrabajoHabitualSi.CheckedChanged
        If Rb_TrabajoHabitualSi.Checked = True Then
            Lb_TrabajoHabitual.Hide()
            Tx_TrabajoHabitual.Hide()
        End If
        If Rb_TrabajoHabitualSi.Checked = False Then
            Lb_TrabajoHabitual.Show()
            Tx_TrabajoHabitual.Text = ""
            Tx_TrabajoHabitual.Show()
        End If
    End Sub

    Private Sub Rb_TrabajoHabitualNo_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_TrabajoHabitualNo.CheckedChanged
        If Rb_TrabajoHabitualNo.Checked = False Then
            Lb_TrabajoHabitual.Hide()
            Tx_TrabajoHabitual.Hide()
        End If
        If Rb_TrabajoHabitualNo.Checked = True Then
            Lb_TrabajoHabitual.Show()
            Tx_TrabajoHabitual.Text = ""
            Tx_TrabajoHabitual.Show()
        End If
    End Sub
    Private Sub Ck_OtrosAnexos_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_OtrosAnexos.CheckedChanged
        If Ck_OtrosAnexos.Checked = True Then
            Lb_OtrosAnexos.Show()
            Tb_OtrosAnexos.Text = ""
            Tb_OtrosAnexos.Show()
        End If
        If Ck_OtrosAnexos.Checked = False Then
            Lb_OtrosAnexos.Hide()
            Tb_OtrosAnexos.Hide()
        End If
    End Sub

    Private Sub Rb_TestigosSi_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_TestigosSi.CheckedChanged
        If TIPO = 1 Or EDITANDO = True Then
            If Rb_TestigosSi.Checked = True Then
                Me.TabControl1.TabPages.Insert(2, Me.TabPage3)
            Else
                Me.TabControl1.Controls.Remove(Me.TabPage3)
            End If
        End If
    End Sub

    Private Sub Rb_TestigosNo_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_TestigosNo.CheckedChanged
        If TIPO = 1 Or EDITANDO = True Then
            If Rb_TestigosNo.Checked = True Then
                Me.TabControl1.Controls.Remove(Me.TabPage3)
            End If
        End If
    End Sub

    Private Sub Bt_Agregar_Click(sender As Object, e As EventArgs) Handles Bt_Agregar.Click
        Dim fila As DataRow
        If dtTestigos IsNot Nothing Then
            fila = dtTestigos.NewRow
            dtTestigos.Rows.Add(fila)
        End If
    End Sub

    Private Sub EliminarFilaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarFilaToolStripMenuItem.Click
        If TIPO = 1 Or EDITANDO = True Then
            Dim indice As Integer
            indice = Me.Dgv_Testigos.SelectedCells(0).RowIndex
            If Me.Dgv_Testigos.Rows.Count > 1 Then
                Dgv_Testigos.Rows.RemoveAt(indice)
            Else
                If Me.Dgv_Testigos.Rows.Count = 1 Then
                    Dgv_Testigos.Rows.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub Dgv_Testigos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Testigos.CellEndEdit

        Select Case e.ColumnIndex
            Case Dgv_Testigos.Columns("Cedula").Index

                If IsDBNull(Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value) Or Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                    MsgBox("Debe ingresar un valor")
                    Exit Sub
                End If

                For i = 0 To Dgv_Testigos.Rows.Count - 2
                    If Dgv_Testigos.Item(e.ColumnIndex, i).Value = "" Then
                        MsgBox("Hay campos de la columna cedula sin llenar anteriores a la fila actual")
                        Dgv_Testigos.Item(e.ColumnIndex, i).Value = ""
                        dtTestigos.Rows().RemoveAt(i)
                        Exit Sub
                    End If
                Next

                For i = 0 To Dgv_Testigos.Rows.Count - 2
                    If e.RowIndex <> i Then
                        If Not IsDBNull(Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value) Or Trim(Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value.ToString) = "" Or Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                            If Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value = Dgv_Testigos.Rows(i).Cells("Cedula").Value Then
                                Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value = ""
                                MsgBox("Ya hay un testigo con ese número de documento")
                                Exit Sub
                            End If
                        End If
                    End If
                Next

                Dim Cadena_Consulta As String = "select P.IDPERSONA from PERSONA as P where P.IDENTIFICACION = '" + Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value + "'"
                Dim IdPersona As String
                Dim Consulta As New SqlCommand(Cadena_Consulta)
                Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                Consulta.Connection = Conexión
                Consulta.Connection.Open()
                IdPersona = Consulta.ExecuteScalar()
                Consulta.Connection.Close()
                If IdPersona Is Nothing Then
                    Dgv_Testigos.Item(e.ColumnIndex, e.RowIndex).Value = ""
                    MsgBox("No se encontró una persona con ese documento")
                    Exit Sub
                End If
                Dim Cadena_Consulta2 As String = "SELECT dbo.Personanombrecompleto(" + IdPersona + ")"
                Dim Consulta2 As New SqlCommand(Cadena_Consulta2)
                Dim dt As New DataTable
                Consulta2.Connection = Conexión
                Dim adaptador As New SqlDataAdapter(Consulta2)
                Consulta2.Connection.Open()
                adaptador.FillSchema(dt, SchemaType.Source)
                adaptador.Fill(dt)
                Consulta2.Connection.Close()
                Dgv_Testigos.Rows(e.RowIndex).Cells(1).Value = dt(0).Item(0)
                Me.Dgv_Testigos.Columns("DGVCB_Cargo").ReadOnly = False
        End Select
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Public Function ValidarCasillas() As Boolean
        If Trim(Tb_Contrato.Text) = "" Then
            MsgBox("Debe indicar el número del contrato.", MsgBoxStyle.Information, "No. Contrato")
            TabControl1.SelectedIndex = 0
            Tb_Contrato.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Proyecto.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un proyecto.", MsgBoxStyle.Information, "Proyecto")
            TabControl1.SelectedIndex = 0
            Cb_Proyecto.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_TipoIncidente.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un tipo de incidente.", MsgBoxStyle.Information, "Tipo de incidente")
            TabControl1.SelectedIndex = 0
            Cb_TipoIncidente.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_TipoConsecuencia.SelectedIndex = -1 Then
            MsgBox("Debe selecionar una consecuencia.", MsgBoxStyle.Information, "Consecuencia")
            TabControl1.SelectedIndex = 0
            Cb_TipoConsecuencia.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Area.SelectedIndex = -1 Then
            MsgBox("Debe selecionar un área.", MsgBoxStyle.Information, "Área")
            TabControl1.SelectedIndex = 0
            Cb_Area.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Ck_Empleador.CheckState = Windows.Forms.CheckState.Indeterminate Then
            MsgBox("Debe indicar si el empleador es o no Ismocol, en caso de seleccionar no indique cual es.", MsgBoxStyle.Information, "Empleador (SI/NO)")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Exit Function
        End If
        If Ck_Empleador.Checked = False Then
            If Tx_Empleador.Text = "" Then
                MsgBox("Debe escribir el nombre del empleador.", MsgBoxStyle.Information, "Nombre empleador")
                TabControl1.SelectedIndex = 0
                Tx_Empleador.Focus()
                ValidarCasillas = False
                Exit Function
            End If
        End If
        If Cb_ActividadPrincipal.SelectedIndex = -1 Then
            MsgBox("Debe selecionar la actividad principal.", MsgBoxStyle.Information, "Actividad principal")
            TabControl1.SelectedIndex = 0
            Cb_ActividadPrincipal.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_SitioIncidente.Text) = "" Then
            MsgBox("Debe indicar el sitio especifico del incidente.", MsgBoxStyle.Information, "Sitio específico del incidente")
            TabControl1.SelectedIndex = 0
            Tb_SitioIncidente.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Rb_ZonaRural.Checked = False AndAlso Rb_ZonaUrbana.Checked = False Then
            MsgBox("Debe seleccionar la zona donde ocurrió el incidente.", MsgBoxStyle.Information, "Zona donde ocurrió el incidente")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Exit Function
        End If
        If Cu_CiudadIncidente.Cb_Ciudad.Text = "" OrElse Cu_CiudadIncidente.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la ciudad del incidente.", MsgBoxStyle.Information, "Ciudad del incidente")
            TabControl1.SelectedIndex = 0
            Cu_CiudadIncidente.Cb_Ciudad.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Rb_LugarDentroEmpresa.Checked = False AndAlso Rb_LugarFueraEmpresa.Checked = False Then
            MsgBox("Debe seleccionar si el lugar donde ocurrió el incidente fue dentro o fuera de la empresa.", MsgBoxStyle.Information, "Lugar donde ocurrió el incidente")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Exit Function
        End If
        If DTP_FechaIncidente.Checked = False Then
            MsgBox("Debe seleccionar la fecha del incidente.", MsgBoxStyle.Information, "Fecha del incidente")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            DTP_FechaIncidente.Focus()
            Exit Function
        End If
        If DTP_HoraIncidente.Value.Hour > TimeOfDay.Hour Then
            MsgBox("No puede seleccionar una hora mayor a la hora actual", MsgBoxStyle.Information, "Hora del incidente")
            ValidarCasillas = False
            TabControl1.SelectedIndex = 0
            DTP_HoraIncidente.Focus()
        End If
        If DTP_HorasLaboradas.Value.Hour > 10 Then
            MsgBox("No puede seleccionar mas de 10 horas", MsgBoxStyle.Information, "Horas laboradas")
            ValidarCasillas = False
            TabControl1.SelectedIndex = 0
            DTP_HorasLaboradas.Focus()
            Exit Function
        End If
        If Trim(Tb_Descripcion.Text) = "" Then
            MsgBox("Debe dar una descripción del incidente.", MsgBoxStyle.Information, "Descripción del incidente")
            TabControl1.SelectedIndex = 0
            Tb_Descripcion.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Severidad.SelectedIndex = -1 Then
            MsgBox("Debe selecionar la severidad.", MsgBoxStyle.Information, "Severidad")
            TabControl1.SelectedIndex = 0
            Cb_Severidad.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Recurrencia.SelectedIndex = -1 Then
            MsgBox("Debe selecionar la recurrencia.", MsgBoxStyle.Information, "Recurrencia")
            TabControl1.SelectedIndex = 0
            Cb_Recurrencia.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_EvitadoAccidente.Text) = "" Then
            MsgBox("Debe indicar como pudo haberse evitado el incidente.", MsgBoxStyle.Information, "Evitado incidente")
            TabControl1.SelectedIndex = 0
            Tb_EvitadoAccidente.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Ck_AnexoDibujos.CheckState = Windows.Forms.CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si hay o no anexos de Dibujos/Diagramas.", MsgBoxStyle.Information, "Anexos Dibujos/Diagramas")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Exit Function
        End If
        If Ck_AnexoFotos.CheckState = Windows.Forms.CheckState.Indeterminate Then
            MsgBox("Debe selecionar si hay o no anexos de Fotos/Videos.", MsgBoxStyle.Information, "Anexos Fotos/Videos")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Exit Function
        End If
        If Ck_AnexoInformesMedicos.CheckState = Windows.Forms.CheckState.Indeterminate Then
            MsgBox("Debe selecionar si hay o no anexos de Informes médicos.", MsgBoxStyle.Information, "Anexos Informes médicos")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Exit Function
        End If
        If Ck_OtrosAnexos.CheckState = Windows.Forms.CheckState.Indeterminate Then
            MsgBox("Debe selecionar si hay o no otros anexos .", MsgBoxStyle.Information, "Otros anexos")
            TabControl1.SelectedIndex = 0
            ValidarCasillas = False
            Exit Function
        End If
        If Ck_OtrosAnexos.Checked = True Then
            If Trim(Tb_OtrosAnexos.Text) = " " Then
                MsgBox("Debe indicar el nombre de los otros anexos .", MsgBoxStyle.Information, "Otros anexos")
                TabControl1.SelectedIndex = 0
                Tb_OtrosAnexos.Focus()
                ValidarCasillas = False
                Exit Function
            End If
        End If

        If Cu_BuscarPersonaReporta.Cb_Persona.Text = "" OrElse Cu_BuscarPersonaReporta.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la persona que reporta.", MsgBoxStyle.Information, "Persona reporta")
            TabControl1.SelectedIndex = 0
            Cu_BuscarPersonaReporta.Cb_Persona.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Cb_CargoReporta.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el cargo de la persona que reporta.", MsgBoxStyle.Information, "Cargo reporta")
            TabControl1.SelectedIndex = 0
            Cb_CargoReporta.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Cu_BuscarPersonaValida1.Cb_Persona.Text = "" OrElse Cu_BuscarPersonaValida1.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar quien valido el reporte.", MsgBoxStyle.Information, "Validado por")
            TabControl1.SelectedIndex = 0
            Cu_BuscarPersonaValida1.Cb_Persona.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cu_BuscarPersonaValida2.Cb_Persona.Text = "" OrElse Cu_BuscarPersonaValida2.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar quien valido el reporte.", MsgBoxStyle.Information, "Validado por")
            TabControl1.SelectedIndex = 0
            Cu_BuscarPersonaValida2.Cb_Persona.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        'Si es tipo salud
        If Cb_TipoIncidente.SelectedValue = 1 Then
            If Cb_TipoVinculacion.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar el tipo de vinculación.", MsgBoxStyle.Information, "Tipo vinculación")
                TabControl1.SelectedIndex = 1
                Cb_TipoVinculacion.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cu_BuscarPersonaAfectada.Cb_Persona.Text = "" OrElse Cu_BuscarPersonaAfectada.Cb_Persona.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la persona afectada.", MsgBoxStyle.Information, "Persona afectada")
                TabControl1.SelectedIndex = 1
                Cu_BuscarPersonaAfectada.Cb_Persona.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If DTP_FechaNacimiento.Checked = False Then
                MsgBox("Debe seleccionar la fecha de nacimiento.", MsgBoxStyle.Information, "Fecha de nacimiento")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                DTP_FechaIncidente.Focus()
                Exit Function
            End If
            If Rb_Femenino.Checked = False AndAlso Rb_Masculino.Checked = False Then
                MsgBox("Debe seleccionar el genero.", MsgBoxStyle.Information, "Genero")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_EPS.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la EPS.", MsgBoxStyle.Information, "EPS")
                TabControl1.SelectedIndex = 1
                Cb_EPS.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_AFP.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la AFP.", MsgBoxStyle.Information, "AFP")
                TabControl1.SelectedIndex = 1
                Cb_AFP.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Direccion.Text) = "" Then
                MsgBox("Debe escribir la dirección de la persona afectada.", MsgBoxStyle.Information, "Dirección")
                TabControl1.SelectedIndex = 1
                Tb_Direccion.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Telefono.Text) = "" Then
                MsgBox("Debe escribir el número de teléfono de la persona afectada.", MsgBoxStyle.Information, "Teléfono")
                TabControl1.SelectedIndex = 1
                Tb_Telefono.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_TelefonoMovil.Text) = "" Then
                MsgBox("Debe escribir el número de teléfono de la persona afectada.", MsgBoxStyle.Information, "Teléfono")
                TabControl1.SelectedIndex = 1
                Tb_TelefonoMovil.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_CorreoElectronico.Text) = "" Then
                MsgBox("Debe escribir el correo electrónico de la persona afectada.", MsgBoxStyle.Information, "Correo electrónico")
                TabControl1.SelectedIndex = 1
                Tb_CorreoElectronico.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_CargoPersonaAccidente.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar el cargo.", MsgBoxStyle.Information, "Cargo")
                TabControl1.SelectedIndex = 1
                Cb_CargoPersonaAccidente.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_OcupacionHabitual.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la ocupación habitual.", MsgBoxStyle.Information, "Ocupación habitual")
                TabControl1.SelectedIndex = 1
                Cb_OcupacionHabitual.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Salario.Text) = "" Then
                MsgBox("Debe escribir el salario.", MsgBoxStyle.Information, "Salario")
                TabControl1.SelectedIndex = 1
                Tb_Salario.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_JornadaHabitual.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la jornada habitual de trabajo.", MsgBoxStyle.Information, "Jornada habitual")
                TabControl1.SelectedIndex = 1
                Cb_JornadaHabitual.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If DTP_InicioContrato.Checked = False Then
                MsgBox("Debe seleccionar la fecha en que inicio el contrato.", MsgBoxStyle.Information, "Inicio contrato")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                DTP_InicioContrato.Focus()
                Exit Function
            End If
            If Rb_MuerteSi.Checked = False AndAlso Rb_MuerteNo.Checked = False Then
                MsgBox("Debe seleccionar si el incidente causo muerte o no.", MsgBoxStyle.Information, "Causo muerte [Si/No]")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Exit Function
            End If

            If Cb_JornadaIncidente.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la jornada del incidente.", MsgBoxStyle.Information, "Jornada incidente")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Cb_JornadaIncidente.Focus()
                Exit Function
            End If
            If Rb_TrabajoHabitualNo.Checked = False AndAlso Rb_TrabajoHabitualSi.Checked = False Then
                MsgBox("Debe seleccionar si estaba realizando su trabajo habitual o no.", MsgBoxStyle.Information, "Trabajo habitual [Si/No]")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Exit Function
            End If
            If Rb_TrabajoHabitualNo.Checked = True Then
                If Trim(Tx_TrabajoHabitual.Text) = "" Then
                    MsgBox("Debe escribir el trabajo que estaba realizando.", MsgBoxStyle.Information, "Trabajo")
                    TabControl1.SelectedIndex = 1
                    ValidarCasillas = False
                    Tx_TrabajoHabitual.Focus()
                    Exit Function
                End If
            End If
            If Cb_SitioIncidente.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar el sitio del incidente.", MsgBoxStyle.Information, "Sitio incidente")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Cb_SitioIncidente.Focus()
                Exit Function
            End If
            If Cb_SitioIncidente.Text = "Otro sitio incidente" Then
                If Trim(Tb_OtroSitioIncidente.Text) = "" Then
                    MsgBox("Debe escribir el sitio del incidente.", MsgBoxStyle.Information, "Sitio incidente")
                    TabControl1.SelectedIndex = 1
                    ValidarCasillas = False
                    Tb_OtroSitioIncidente.Focus()
                    Exit Function
                End If
            End If

            If Cb_TipoLesion.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar el tipo de lesion.", MsgBoxStyle.Information, "Tipo de lesion")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Cb_TipoLesion.Focus()
                Exit Function
            End If
            If Cb_TipoLesion.Text = "Otro tipo lesion" Then
                If Trim(Tb_OtroTipoLesion.Text) = "" Then
                    MsgBox("Debe escribir el tipo de lesion.", MsgBoxStyle.Information, "Tipo de lesion")
                    TabControl1.SelectedIndex = 1
                    ValidarCasillas = False
                    Tb_OtroTipoLesion.Focus()
                    Exit Function
                End If
            End If

            If Cb_ParteAfectada.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la parte del cuerpo afectada.", MsgBoxStyle.Information, "Parte afectada")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Cb_ParteAfectada.Focus()
                Exit Function
            End If
            If Cb_ParteAfectada.Text = "Otra parte del cuerpo" Then
                If Trim(Tb_OtraParteAfectada.Text) = "" Then
                    MsgBox("Debe escribir la parte del cuerpo afectada.", MsgBoxStyle.Information, "Parte afectada")
                    TabControl1.SelectedIndex = 1
                    ValidarCasillas = False
                    Tb_OtraParteAfectada.Focus()
                    Exit Function
                End If
            End If

            If Cb_AgenteAccidente.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar el agente del accidente.", MsgBoxStyle.Information, "Agente accidente")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Cb_AgenteAccidente.Focus()
                Exit Function
            End If
            If Cb_AgenteAccidente.Text = "Otro agente accidente" Then
                If Trim(Tb_OtroAgenteAccidente.Text) = "" Then
                    MsgBox("Debe escribir el agente del accidente.", MsgBoxStyle.Information, "Agente accidente")
                    TabControl1.SelectedIndex = 1
                    ValidarCasillas = False
                    Tb_OtroAgenteAccidente.Focus()
                    Exit Function
                End If
            End If

            If Cb_MecanismoAccidente.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar el mecanismo del accidente.", MsgBoxStyle.Information, "Mecanismo accidente")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Cb_MecanismoAccidente.Focus()
                Exit Function
            End If
            If Cb_MecanismoAccidente.Text = "Otro mecanismo accidente" Then
                If Trim(Tb_OtroMecanismoAccidente.Text) = "" Then
                    MsgBox("Debe escribir el mecanismo del acccidente.", MsgBoxStyle.Information, "Mecanismo accidente")
                    TabControl1.SelectedIndex = 1
                    ValidarCasillas = False
                    Tb_OtroMecanismoAccidente.Focus()
                    Exit Function
                End If
            End If

            If Trim(Tb_DiagnosticoLesion.Text) = "" Then
                MsgBox("Debe escribir el diagnostico.", MsgBoxStyle.Information, "Diagnostico")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Tb_DiagnosticoLesion.Focus()
                Exit Function
            End If

            If Cb_AtencionInmediata.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la atención inmediata.", MsgBoxStyle.Information, "Atención inmediata")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Cb_AtencionInmediata.Focus()
                Exit Function
            End If
            If Cb_AtencionInmediata.Text = "Traslado a centro de Atención" Then
                If Trim(Tb_Traslado.Text) = "" Then
                    MsgBox("Debe escribir a donde fue trasladado.", MsgBoxStyle.Information, "Traslado")
                    TabControl1.SelectedIndex = 1
                    ValidarCasillas = False
                    Tb_Traslado.Focus()
                    Exit Function
                End If
            End If
            If Rb_TestigosSi.Checked = False AndAlso Rb_TestigosNo.Checked = False Then
                MsgBox("Debe seleccionar si hubo o no testigos.", MsgBoxStyle.Information, "Testigos [Si/No]")
                TabControl1.SelectedIndex = 1
                ValidarCasillas = False
                Exit Function
            End If
            If Rb_TestigosSi.Checked Then
                If Dgv_Testigos.Rows.Count - 2 < 0 Then
                    MsgBox("Debe ingresar los testigos.", MsgBoxStyle.Information, "Testigos")
                    TabControl1.SelectedIndex = 2
                    ValidarCasillas = False
                    Exit Function
                End If
            End If
        End If

        ValidarCasillas = True
    End Function

    Public Sub GuardarReporte24H()
        If ValidarCasillas() = False Then
            Exit Sub
        End If
        Dim Comando As New SqlCommand("dbo.GestionarFormato24H")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@ACCION", TIPO)
        Comando.Parameters.AddWithValue("@IDREPORTE24H", IDREPORTEMODIFICANDO)
        Comando.Parameters.AddWithValue("@AÑO", Now.Year)
        Comando.Parameters.AddWithValue("@CONTRATO", Me.Tb_Contrato.Text)
        Comando.Parameters.AddWithValue("@IDBASE", Me.Cb_Proyecto.SelectedValue)
        Comando.Parameters.AddWithValue("@IDAREA", Me.Cb_Area.SelectedValue)
        Comando.Parameters.AddWithValue("@IDTIPOINCIDENTE", Me.Cb_TipoIncidente.SelectedValue)
        Comando.Parameters.AddWithValue("@IDTIPOCONSECUENCIA", Me.Cb_TipoConsecuencia.SelectedValue)
        If Me.Ck_Empleador.Checked Then
            Comando.Parameters.AddWithValue("@EMPLEADOR", "ISMOCOL")
        Else
            Comando.Parameters.AddWithValue("@EMPLEADOR", Me.Tx_Empleador.Text)
        End If
        Comando.Parameters.AddWithValue("@ACTIVIDADPRINCIPAL", Me.Cb_ActividadPrincipal.SelectedValue)
        Comando.Parameters.AddWithValue("@SITIOINCIDENTE", Me.Tb_SitioIncidente.Text)
        Comando.Parameters.AddWithValue("@FECHAACCIDENTE", Me.DTP_FechaIncidente.Value.Date)
        Comando.Parameters.AddWithValue("@HORAACCIDENTE", Me.DTP_HoraIncidente.Value)
        If Rb_ZonaRural.Checked Then
            Comando.Parameters.AddWithValue("@ZONAOCURRIO", "R")
        End If
        If Rb_ZonaUrbana.Checked Then
            Comando.Parameters.AddWithValue("@ZONAOCURRIO", "U")
        End If
        Comando.Parameters.AddWithValue("@HORASLABORADASDIA", Me.DTP_HorasLaboradas.Value)
        Comando.Parameters.AddWithValue("@SEVERIDADPERDIDAPOTENCIAL", Me.Cb_Severidad.SelectedValue)

        Dim categoria As String
        Dim letratipo As String
        If Me.Cb_Severidad.SelectedValue = 1 Or Me.Cb_Severidad.SelectedValue = 6 Or Me.Cb_Severidad.SelectedValue = 11 Then
            letratipo = "A"
        Else
            If Me.Cb_Severidad.SelectedValue = 2 Or Me.Cb_Severidad.SelectedValue = 7 Or Me.Cb_Severidad.SelectedValue = 12 Then
                letratipo = "B"
            Else
                If Me.Cb_Severidad.SelectedValue = 3 Or Me.Cb_Severidad.SelectedValue = 8 Or Me.Cb_Severidad.SelectedValue = 13 Then
                    letratipo = "C"
                Else
                    If Me.Cb_Severidad.SelectedValue = 4 Or Me.Cb_Severidad.SelectedValue = 9 Or Me.Cb_Severidad.SelectedValue = 14 Then
                        letratipo = "D"
                    Else
                        letratipo = "E"
                    End If
                End If
            End If
        End If
        categoria = letratipo + Me.Cb_Recurrencia.SelectedValue
        Comando.Parameters.AddWithValue("@CATEGORIAPERDIDAPOTENCIAL", categoria)

        If categoria = "A1" Or categoria = "A2" Or categoria = "A3" Or categoria = "B2" Or categoria = "B3" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAPOTENCIAL", "A")
        End If
        If categoria = "B1" Or categoria = "C1" Or categoria = "C2" Or categoria = "C3" Or categoria = "D2" Or categoria = "D3" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAPOTENCIAL", "M")
        End If
        If categoria = "D1" Or categoria = "E1" Or categoria = "E2" Or categoria = "E3" Then
            Comando.Parameters.AddWithValue("@NIVELPERDIDAPOTENCIAL", "B")
        End If

        Comando.Parameters.AddWithValue("@IDPERSONAREPORTA", Me.Cu_BuscarPersonaReporta.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDCARGOPERSONAREPORTA", Me.Cb_CargoReporta.SelectedValue)
        Comando.Parameters.AddWithValue("@DESCRIPCIONINCIDENTE", Me.Tb_Descripcion.Text)

        Dim cantidadacciones As Integer = Me.Dgv_AccionesInmediatas.Rows.Count
        Dim cantidadaccionesTemp As Integer = cantidadacciones
        For i As Integer = cantidadacciones - 1 To 0 Step -1
            Dim row As DataGridViewRow = Dgv_AccionesInmediatas.Rows(i)
            If Not row.IsNewRow And IsDBNull(row.Cells(0).Value) Or row.Cells(0).Value Is Nothing Then
                cantidadaccionesTemp += -1
            End If
        Next
        If cantidadaccionesTemp = 1 Or cantidadaccionesTemp < 4 Then
            If Me.Dgv_AccionesInmediatas.Rows(0) IsNot Nothing Then
                Comando.Parameters.AddWithValue("@ACCIONESINMEDIATAS_1", Me.Dgv_AccionesInmediatas.Rows(0).Cells(0).Value)
                Dim IdPersona
                Dim Cadena_Consulta4 As String = "SELECT IDPERSONA FROM PERSONA WHERE IDENTIFICACION  = '" + Me.Dgv_AccionesInmediatas.Rows(0).Cells(1).Value + "'"
                Dim Consulta4 As New SqlClient.SqlCommand(Cadena_Consulta4)
                Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                Consulta4.Connection = Conexión
                Consulta4.Connection.Open()
                IdPersona = Consulta4.ExecuteScalar()
                Consulta4.Connection.Close()
                Comando.Parameters.AddWithValue("@IDPERSONAACCIONESINMEDIATAS_1", IdPersona)
            End If
        End If
        If cantidadaccionesTemp = 2 Or cantidadaccionesTemp < 4 Then
            If Me.Dgv_AccionesInmediatas.Rows(1) IsNot Nothing Then
                Comando.Parameters.AddWithValue("@ACCIONESINMEDIATAS_2", Me.Dgv_AccionesInmediatas.Rows(1).Cells(0).Value)
                Dim IdPersona
                Dim Cadena_Consulta4 As String = "SELECT IDPERSONA FROM PERSONA WHERE IDENTIFICACION  = '" + Me.Dgv_AccionesInmediatas.Rows(1).Cells(1).Value + "'"
                Dim Consulta4 As New SqlClient.SqlCommand(Cadena_Consulta4)
                Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                Consulta4.Connection = Conexión
                Consulta4.Connection.Open()
                IdPersona = Consulta4.ExecuteScalar()
                Consulta4.Connection.Close()
                Comando.Parameters.AddWithValue("@IDPERSONAACCIONESINMEDIATAS_2", IdPersona)
            End If
        End If

        If cantidadaccionesTemp = 3 Then
            If Me.Dgv_AccionesInmediatas.Rows(2) IsNot Nothing Then
                Comando.Parameters.AddWithValue("@ACCIONESINMEDIATAS_3", Me.Dgv_AccionesInmediatas.Rows(2).Cells(0).Value)
                Dim IdPersona
                Dim Cadena_Consulta4 As String = "SELECT IDPERSONA FROM PERSONA WHERE IDENTIFICACION  = '" + Me.Dgv_AccionesInmediatas.Rows(2).Cells(1).Value + "'"
                Dim Consulta4 As New SqlClient.SqlCommand(Cadena_Consulta4)
                Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                Consulta4.Connection = Conexión
                Consulta4.Connection.Open()
                IdPersona = Consulta4.ExecuteScalar()
                Consulta4.Connection.Close()
                Comando.Parameters.AddWithValue("@IDPERSONAACCIONESINMEDIATAS_3", IdPersona)
            End If
        End If

        If Rb_LugarDentroEmpresa.Checked Then
            Comando.Parameters.AddWithValue("@LUGARACCIDENTE", "D")
        End If
        If Rb_LugarFueraEmpresa.Checked Then
            Comando.Parameters.AddWithValue("@LUGARACCIDENTE", "F")
        End If

        Comando.Parameters.AddWithValue("@MUNICIPIO", Me.Cu_CiudadIncidente.Tx_Codigo.Text)

        Comando.Parameters.AddWithValue("@EVITADOINCIDENTE", Me.Tb_EvitadoAccidente.Text)
        Comando.Parameters.AddWithValue("@IDVALIDA_1", Me.Cu_BuscarPersonaValida1.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDVALIDA_2", Me.Cu_BuscarPersonaValida2.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDVALIDA_3", Me.Cu_BuscarPersonaValida3.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDVALIDA_4", Me.Cu_BuscarPersonaValida4.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IMPRESO", "N")
        Dim anexos As String
        If Me.Ck_AnexoDibujos.Checked Then
            anexos = "S"
        Else
            anexos = "N"
        End If
        If Me.Ck_AnexoFotos.Checked Then
            anexos = anexos + "S"
        Else
            anexos = anexos + "N"
        End If
        If Me.Ck_AnexoInformesMedicos.Checked Then
            anexos = anexos + "S"
        Else
            anexos = anexos + "N"
        End If
        If Me.Ck_OtrosAnexos.Checked Then
            anexos = anexos + "S"
        Else
            anexos = anexos + "N"
        End If
        Comando.Parameters.AddWithValue("@ANEXOS", anexos)
        If Me.Ck_OtrosAnexos.Checked Then
            Comando.Parameters.AddWithValue("@OTROSANEXOS", Me.Tb_OtrosAnexos.Text)
        Else
            Comando.Parameters.AddWithValue("@OTROSANEXOS", DBNull.Value)
        End If

        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)
        If Cb_TipoIncidente.SelectedValue.ToString() = "1" Then
            Comando.Parameters.AddWithValue("@IDREPORTEPERSONA24H", 1)
            Comando.Parameters.AddWithValue("@IDPERSONAACCIDENTE", Me.Cu_BuscarPersonaAfectada.Cb_Persona.SelectedValue)
            Comando.Parameters.AddWithValue("@IDCARGOPERSONACCIDENTE", Me.Cb_CargoPersonaAccidente.SelectedValue)
            Comando.Parameters.AddWithValue("@FECHANACIMIENTO", Me.DTP_FechaNacimiento.Value)
            If Rb_Femenino.Checked Then
                Comando.Parameters.AddWithValue("@GENERO", "F")
            End If
            If Rb_Masculino.Checked Then
                Comando.Parameters.AddWithValue("@GENERO", "M")
            End If
            Comando.Parameters.AddWithValue("@DIRECCION", Me.Tb_Direccion.Text)
            Comando.Parameters.AddWithValue("@TELEFONO", Me.Tb_Telefono.Text)
            Comando.Parameters.AddWithValue("@TELEFONOMOVIL", Me.Tb_TelefonoMovil.Text)
            Comando.Parameters.AddWithValue("@CORREOELECTRONICO", Me.Tb_CorreoElectronico.Text)
            Comando.Parameters.AddWithValue("@EPS", Me.Cb_EPS.SelectedValue)
            Comando.Parameters.AddWithValue("@AFP", Me.Cb_AFP.SelectedValue)
            Comando.Parameters.AddWithValue("@TIPOVINCULACION", Me.Cb_TipoVinculacion.SelectedValue)
            Comando.Parameters.AddWithValue("@OCUPACIONHABITUAL", Me.Cb_OcupacionHabitual.SelectedValue)
            Comando.Parameters.AddWithValue("@SALARIO", Me.Tb_Salario.Text)
            Comando.Parameters.AddWithValue("@JORNADAHABITUAL", Me.Cb_JornadaHabitual.SelectedValue)
            Comando.Parameters.AddWithValue("@JORNADAINCIDENTE", Me.Cb_JornadaIncidente.SelectedValue)
            If Me.Rb_TrabajoHabitualNo.Checked = True Then
                Comando.Parameters.AddWithValue("@TRABAJOHABITUAL", "N")
                Comando.Parameters.AddWithValue("@OTROTRABAJOHABITUAL", Me.Tx_TrabajoHabitual.Text)
            Else
                Comando.Parameters.AddWithValue("@TRABAJOHABITUAL", "S")
            End If
            Comando.Parameters.AddWithValue("@FECHAINICIOCONTRATO", Me.DTP_InicioContrato.Value.Date)
            If Rb_MuerteSi.Checked Then
                Comando.Parameters.AddWithValue("@CAUSOMUERTE", "S")
            End If
            If Rb_MuerteNo.Checked Then
                Comando.Parameters.AddWithValue("@CAUSOMUERTE", "N")
            End If
            Comando.Parameters.AddWithValue("@DIAGNOSTICO", Me.Tb_DiagnosticoLesion.Text)
            If Me.Cb_AtencionInmediata.SelectedValue = 5 Then
                Comando.Parameters.AddWithValue("@TIPOATENCIONINMEDIATA", Me.Cb_AtencionInmediata.SelectedValue)
                Comando.Parameters.AddWithValue("@TRASLADO", Me.Tb_Traslado.Text)
            Else
                Comando.Parameters.AddWithValue("@TIPOATENCIONINMEDIATA", Me.Cb_AtencionInmediata.SelectedValue)
                Comando.Parameters.AddWithValue("@TRASLADO", DBNull.Value)
            End If
            If Me.Cb_SitioIncidente.Text = "Otro sitio incidente" Then
                Comando.Parameters.AddWithValue("@SITIOACCIDENTE", Me.Cb_SitioIncidente.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROSITIOACCIDENTE", Me.Tb_OtroSitioIncidente.Text)
            Else
                Comando.Parameters.AddWithValue("@SITIOACCIDENTE", Me.Cb_SitioIncidente.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROSITIOACCIDENTE", DBNull.Value)
            End If
            If Me.Cb_TipoLesion.Text = "Otro tipo lesion" Then
                Comando.Parameters.AddWithValue("@TIPOLESION", Me.Cb_TipoLesion.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROTIPOLESION", Me.Tb_OtroTipoLesion.Text)
            Else
                Comando.Parameters.AddWithValue("@TIPOLESION", Me.Cb_TipoLesion.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROTIPOLESION", DBNull.Value)
            End If
            If Me.Cb_ParteAfectada.Text = "Otra parte del cuerpo" Then
                Comando.Parameters.AddWithValue("@PARTECUERPOAFECTADA", Me.Cb_ParteAfectada.SelectedValue)
                Comando.Parameters.AddWithValue("@OTRAPARTECUERPOAFECTADA", Me.Tb_OtraParteAfectada.Text)
            Else
                Comando.Parameters.AddWithValue("@PARTECUERPOAFECTADA", Me.Cb_ParteAfectada.SelectedValue)
                Comando.Parameters.AddWithValue("@OTRAPARTECUERPOAFECTADA", DBNull.Value)
            End If
            If Me.Cb_AgenteAccidente.Text = "Otro agente accidente" Then
                Comando.Parameters.AddWithValue("@AGENTEACCIDENTE", Me.Cb_AgenteAccidente.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROAGENTEACCIDENTE", Me.Tb_OtroAgenteAccidente.Text)
            Else
                Comando.Parameters.AddWithValue("@AGENTEACCIDENTE", Me.Cb_AgenteAccidente.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROAGENTEACCIDENTE", DBNull.Value)
            End If
            If Me.Cb_MecanismoAccidente.Text = "Otro mecanismo accidente" Then
                Comando.Parameters.AddWithValue("@MECANISMO", Me.Cb_MecanismoAccidente.SelectedValue)

                Comando.Parameters.AddWithValue("@OTROMECANISMO", Me.Tb_OtroMecanismoAccidente.Text)
            Else
                Comando.Parameters.AddWithValue("@MECANISMO", Me.Cb_MecanismoAccidente.SelectedValue)
                Comando.Parameters.AddWithValue("@OTROMECANISMO", DBNull.Value)
            End If

            If Me.Rb_TestigosSi.Checked Then
                Dim TablaTestigos As New DataTable
                TablaTestigos.Columns.Add("IDREPORTE24H")
                TablaTestigos.Columns.Add("IDREPORTEINVESTIGACION")
                TablaTestigos.Columns.Add("IDPERSONA")
                TablaTestigos.Columns.Add("IDCARGO")
                TablaTestigos.Columns.Add("DESCRIPCION")
                Dim TablaTestigos2 As New DataTable
                TablaTestigos2.Columns.Add("CEDULA")
                TablaTestigos2.Columns.Add("NOMBRE")
                TablaTestigos2.Columns.Add("CARGO")
                Dim Fila As DataRow
                For i = 0 To Dgv_Testigos.Rows.Count - 2
                    Dim IdPersona
                    Dim Cadena_Consulta3 As String = "SELECT IDPERSONA FROM PERSONA WHERE IDENTIFICACION  = '" + Dgv_Testigos.Rows(i).Cells("Cedula").Value + "'"
                    Dim Consulta3 As New SqlClient.SqlCommand(Cadena_Consulta3)
                    Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta3.Connection = Conexión
                    Consulta3.Connection.Open()
                    IdPersona = Consulta3.ExecuteScalar()
                    Consulta3.Connection.Close()
                    Fila = TablaTestigos.NewRow
                    Fila("IDPERSONA") = IdPersona
                    Fila("IDCARGO") = Dgv_Testigos.Rows(i).Cells("DGVCB_Cargo").Value
                    TablaTestigos.Rows.Add(Fila)
                Next
                Comando.Parameters.AddWithValue("@TableTestigos", TablaTestigos)
            End If
        End If

        Dim conexion2 As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        conexion2.Open()
        Comando.Connection = conexion2
        Try
            Comando.ExecuteNonQuery()
            conexion2.Close()
            guardado = True
        Catch ex As Exception
            conexion2.Close()
            MsgBox(ex.ToString)
            guardado = False
        End Try
    End Sub
    Private Sub CrearReporte24H_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.Bt_Guardar.Enabled = True And guardado = False Then
            If MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "SALIR SIN GUARDAR") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        GuardarReporte24H()
        Me.Close()
    End Sub

    'Permite ver la imagen de la matriz de perdida
    'Private Sub Bt_VerMatriz_Click(sender As Object, e As EventArgs) Handles Bt_VerMatriz.Click
    '    Dim Matriz As New Fr_MatrizPerdida
    '    Matriz.ShowDialog()
    'End Sub

    Private Sub Cb_Severidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Severidad.SelectedIndexChanged
        If Cb_Recurrencia.SelectedIndex = -1 Then
            Exit Sub
        End If
        CalcularPerdida()
    End Sub

    Private Sub Cb_Recurrencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Recurrencia.SelectedIndexChanged
        If Cb_Severidad.SelectedIndex = -1 Then
            Exit Sub
        End If
        CalcularPerdida()
    End Sub
    Private Sub CalcularPerdida()
        Dim categoria As String
        Dim letratipo As String
        If Me.Cb_Severidad.SelectedValue = 1 Or Me.Cb_Severidad.SelectedValue = 6 Or Me.Cb_Severidad.SelectedValue = 11 Then
            letratipo = "A"
        Else
            If Me.Cb_Severidad.SelectedValue = 2 Or Me.Cb_Severidad.SelectedValue = 7 Or Me.Cb_Severidad.SelectedValue = 12 Then
                letratipo = "B"
            Else
                If Me.Cb_Severidad.SelectedValue = 3 Or Me.Cb_Severidad.SelectedValue = 8 Or Me.Cb_Severidad.SelectedValue = 13 Then
                    letratipo = "C"
                Else
                    If Me.Cb_Severidad.SelectedValue = 4 Or Me.Cb_Severidad.SelectedValue = 9 Or Me.Cb_Severidad.SelectedValue = 14 Then
                        letratipo = "D"
                    Else
                        letratipo = "E"
                    End If
                End If
            End If
        End If
        categoria = letratipo + Me.Cb_Recurrencia.SelectedValue
        Dim nivel
        If categoria = "A1" Or categoria = "A2" Or categoria = "A3" Or categoria = "B2" Or categoria = "B3" Then
            nivel = "Alto"
        End If
        If categoria = "B1" Or categoria = "C1" Or categoria = "C2" Or categoria = "C3" Or categoria = "D2" Or categoria = "D3" Then
            nivel = "Medio"
        End If
        If categoria = "D1" Or categoria = "E1" Or categoria = "E2" Or categoria = "E3" Then
            nivel = "Bajo"
        End If

        Tb_CategoriaResultante.Text = categoria + ", Potencial:" + nivel
    End Sub

    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Me.Cu_BuscarPersonaAfectada.Name
                Try
                    filas = Cu_BuscarPersonaAfectada.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaAfectada.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaAfectada.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaAfectada.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaValida3.Name
                Try
                    filas = Cu_BuscarPersonaValida3.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaValida3.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaValida3.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaValida3.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaValida4.Name
                Try
                    filas = Cu_BuscarPersonaValida4.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaValida4.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaValida4.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaValida4.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaValida1.Name
                Try
                    filas = Cu_BuscarPersonaValida1.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaValida1.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaValida1.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaValida1.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaReporta.Name
                Try
                    filas = Cu_BuscarPersonaReporta.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaReporta.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaReporta.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaReporta.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaValida2.Name
                Try
                    filas = Cu_BuscarPersonaValida2.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaValida2.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaValida2.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaValida2.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub
    Private Function AgregarFilas_Testigos() Handles Dgv_Testigos.RowLeave
        If Dgv_Testigos.Rows.Count >= 7 Then
            Dgv_Testigos.AllowUserToAddRows = False
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub QuitarFilas_Testigos(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles Dgv_Testigos.RowsRemoved
        If Dgv_Testigos.Rows.Count < 8 Then
            Dgv_Testigos.AllowUserToAddRows = True
        End If
    End Sub
    Private Sub Bt_AgregarTestigo_Click(sender As Object, e As EventArgs) Handles Bt_Agregar.Click
        If AgregarFilas_Testigos() Then
            Dim fila As DataRow
            fila = dtTestigos.NewRow
            dtTestigos.Rows.Add(fila)
        End If
    End Sub
    Private Sub Caja_Texto_KeyPress(sender As Object, e As KeyPressEventArgs) _
        Handles Tb_Telefono.KeyPress, Tb_TelefonoMovil.KeyPress, Tb_Salario.KeyPress

        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Dgv_Testigos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_Testigos.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_Testigos
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dText_KeyPressDgv_Testigos(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_Testigos.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 0
                e.KeyChar = Char.ToUpper(e.KeyChar)
                Select Case e.KeyChar
                    Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", Convert.ToChar(8)
                        e.Handled = False
                    Case Else
                        e.Handled = True
                End Select
        End Select
    End Sub

    Private Sub Dgv_AccionesInmediatas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_AccionesInmediatas.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_AccionesInmediatas
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dText_KeyPressDgv_AccionesInmediatas(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_AccionesInmediatas.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 1
                e.KeyChar = Char.ToUpper(e.KeyChar)
                Select Case e.KeyChar
                    Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", Convert.ToChar(8)
                        e.Handled = False
                    Case Else
                        e.Handled = True
                End Select
        End Select
    End Sub
    Private Function AgregarFilas_AccionesInmediatas() Handles Dgv_AccionesInmediatas.RowLeave
        If Dgv_AccionesInmediatas.Rows.Count >= 2 Then
            Dgv_AccionesInmediatas.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub AgregarFila_AccionesInmediatas2(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_AccionesInmediatas.CellEndEdit
        If Dgv_AccionesInmediatas.Rows.Count <= 3 Then
            Select Case e.ColumnIndex
                Case Dgv_AccionesInmediatas.Columns(1).Index

                    If IsDBNull(Dgv_AccionesInmediatas.Item(e.ColumnIndex, e.RowIndex).Value) Or Dgv_AccionesInmediatas.Item(e.ColumnIndex, e.RowIndex).Value Is Nothing Then
                        MsgBox("Debe ingresar un valor")
                        Exit Sub
                    End If

                    Dim Cadena_Consulta As String = "select P.IDPERSONA from PERSONA as P where P.IDENTIFICACION = '" + Dgv_AccionesInmediatas.Item(e.ColumnIndex, e.RowIndex).Value + "'"
                    Dim IdPersona As String
                    Dim Consulta As New SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = Conexión
                    Consulta.Connection.Open()
                    IdPersona = Consulta.ExecuteScalar()
                    Consulta.Connection.Close()
                    If IdPersona Is Nothing Then
                        Dgv_AccionesInmediatas.Item(e.ColumnIndex, e.RowIndex).Value = ""
                        MsgBox("No se encontró una persona con ese documento")
                        Exit Sub
                    End If
                    Dim Cadena_Consulta2 As String = "SELECT dbo.Personanombrecompleto(" + IdPersona + ")"
                    Dim Consulta2 As New SqlCommand(Cadena_Consulta2)
                    Dim dt As New DataTable
                    Consulta2.Connection = Conexión
                    Dim adaptador As New SqlDataAdapter(Consulta2)
                    Consulta2.Connection.Open()
                    adaptador.FillSchema(dt, SchemaType.Source)
                    adaptador.Fill(dt)
                    Consulta2.Connection.Close()
                    Dgv_AccionesInmediatas.Rows(e.RowIndex).Cells(2).Value = dt(0).Item(0)
                    If Dgv_AccionesInmediatas.Rows.Count < 3 Then
                        dtAcciones.Rows.Add()
                    End If
            End Select
        End If
    End Sub
    Private Sub QuitarFilas_AccionesInmediatas(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles Dgv_AccionesInmediatas.RowsRemoved
        If Dgv_AccionesInmediatas.Rows.Count < 3 Then
            Dgv_AccionesInmediatas.AllowUserToAddRows = True
        End If
    End Sub
End Class
