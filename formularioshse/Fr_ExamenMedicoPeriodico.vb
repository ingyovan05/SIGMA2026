Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports FormulariosClasesBase
Imports System.Runtime.CompilerServices
Imports System.Drawing

Public Class Fr_ExamenMedicoPeriodico
    Public TIPO As Integer
    Public EDITANDO As Boolean
    Public IDEXAMEN As Integer
    Public IDEXAMENMODIFICANDO As Integer = -1
    Public guardado As Boolean

    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private Estilo_Celda_Error As New DataGridViewCellStyle
    Private Estilo_Celda As New DataGridViewCellStyle
    Dim dsCargar As New DataSet
    Private dtExamen As DataTable
    Private dtAntecedentes As DataTable
    Private dtEnfermedades As DataTable
    Private dtHabitos As DataTable
    Private dtHigiene As DataTable
    Private dtAntecedentesLaboral As DataTable
    Private dtRiesgosAntecedentesLaborales As DataTable
    Private dtImpresionDiagnostica As DataTable
    Private dtSecuelas As DataTable 'Accidentes
    Private dtTareas As DataTable
    Private dtValoracionAuditiva As DataTable
    Private dtVacunas As New DataTable

    Private FilaExamen As DataRow

    Public Sub ComportamientoPredeterminado()

        AddHandlerBuscarPersona()
        Estilo_Celda_Error.BackColor = Color.Red
        Estilo_Celda.BackColor = Color.White

        Me.TC_ExamenMedicoPeriodico.Controls.Remove(Me.TP_ExamenAuditivo)
        Me.TC_ExamenMedicoPeriodico.Controls.Remove(Me.TP_ExamenComplementario)
        Me.Tb_Lasegue.Hide()

        'Poner todos los ComboBox en Index -1
        Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedIndex = -1
        Me.Cu_CiudadContrato.Cb_Ciudad.SelectedIndex = -1
        Me.Cb_NivelAcademico.SelectedIndex = -1
        Me.Cb_EstadoCivil.SelectedIndex = -1
        Me.Cb_Dominancia.SelectedIndex = -1
        Me.Cb_Proyecto.SelectedIndex = -1
        Me.Cb_Base.SelectedIndex = -1
        Me.Cb_Dependencia.SelectedIndex = -1
        Me.Cb_Cargo.SelectedIndex = -1
        Me.Cb_TipoCargo.SelectedIndex = -1
        Me.Cb_Jornada.SelectedIndex = -1
        Me.Cb_GrupoSanguineo.SelectedIndex = -1
        Me.Cb_AFP.SelectedIndex = -1
        Me.Cb_EPS.SelectedIndex = -1
        Me.Cb_ViaComprometida8000.SelectedIndex = -1
        Me.Cb_ViaComprometida6000.SelectedIndex = -1
        Me.Cb_ViaComprometida3000.SelectedIndex = -1
        Me.Cb_ViaComprometida2000.SelectedIndex = -1
        Me.Cb_ViaComprometida1000.SelectedIndex = -1
        Me.Cb_ViaComprometida05.SelectedIndex = -1
        Me.Cb_ViaComprometida025.SelectedIndex = -1
        Me.Cb_Espirometria.SelectedIndex = -1
        Me.Cb_Audiometria.SelectedIndex = -1
        Me.Cb_EKG.SelectedIndex = -1

        'Max value DTPs
        Me.Dtp_FechaIngreso.MaxDate = Date.Today

        Me.Cu_Vacuna1.Enabled = False
        Me.Cu_Vacuna1.ModuloRegistro = "HSE"

        Me.Bt_AgregarHabito.Visible = False
        Me.Bt_AgregarAntecedente.Visible = False

        If TIPO = 1 Then
            Me.Tb_Simetria.Text = "Normal"
            Me.Tb_Curvatura.Text = "Normal"
            Me.Tb_Dolor.Text = "Ausente"
            Me.Tb_Espasmo.Text = "Normal"
            Me.Tb_Flexion.Text = "Normal"
            Me.Tb_Extension.Text = "Normal"
            Me.Tb_FlexionLateral.Text = "Normal"
            Me.Tb_Rotacion.Text = "Normal"
            Me.Tb_ArtEscapulohumeral.Text = "Normal"
            Me.Tb_ArtAcromioclavicular.Text = "Normal"
            Me.Tb_ArtEscapulotorácica.Text = "Normal"
            Me.Tb_Subdeltoidea.Text = "Normal"
            Me.Tb_EjeAnteroposterior.Text = "Normal"
            Me.Tb_EjeTransversal.Text = "Normal"
            Me.Tb_EjeLongitudinal.Text = "Normal"
            Me.Tb_Circunduccion.Text = "Normal"
            Me.Tb_AbduccionElevacion.Text = "Normal"
            Me.Tb_Aduccion.Text = "Normal"
            Me.Tb_RotacionExterna.Text = "Normal"
            Me.Tb_FlexoExtension.Text = "Normal"
            Me.Tb_HombroDerecho.Text = "Normal"
            Me.Tb_HombroIzquierdo.Text = "Normal"
            Me.Tb_CodoDerecho.Text = "Normal"
            Me.Tb_CodoIzquierdo.Text = "Normal"
            Me.Tb_MuñecaDerecha.Text = "Normal"
            Me.Tb_MuñecaIzquierda.Text = "Normal"
            Me.Tb_ManoDerecha.Text = "Normal"
            Me.Tb_ManoIzquierda.Text = "Normal"
            Me.Tb_DedoDerecho1.Text = "Normal"
            Me.Tb_DedoDerecho2.Text = "Normal"
            Me.Tb_DedoDerecho3.Text = "Normal"
            Me.Tb_DedoDerecho4.Text = "Normal"
            Me.Tb_DedoDerecho5.Text = "Normal"
            Me.Tb_DedoIzquierdo1.Text = "Normal"
            Me.Tb_DedoIzquierdo2.Text = "Normal"
            Me.Tb_DedoIzquierdo3.Text = "Normal"
            Me.Tb_DedoIzquierdo4.Text = "Normal"
            Me.Tb_DedoIzquierdo5.Text = "Normal"
            Me.Tb_CaderasDerecha.Text = "Normal"
            Me.Tb_CaderasIzquierda.Text = "Normal"
            Me.Tb_RodillaDerecha.Text = "Normal"
            Me.Tb_RodillaIzquierda.Text = "Normal"
            Me.Tb_TobilloDerecho.Text = "Normal"
            Me.Tb_TobilloIzquierdo.Text = "Normal"
            Me.Tb_PieDerecho.Text = "Normal"
            Me.Tb_PieIzquierdo.Text = "Normal"
            Me.Tb_FaseApoyoPieDerecho.Text = "Normal"
            Me.Tb_FaseApoyoPieIzquierdo.Text = "Normal"
            Me.Tb_FaseBalanceoPieDerecho.Text = "Normal"
            Me.Tb_FaseBalanceoPieIzquierdo.Text = "Normal"
            Me.Tb_Marcha.Text = "Normal"
            Me.Tb_Detalle8000.Text = "Normal"
            Me.Tb_Detalle6000.Text = "Normal"
            Me.Tb_Detalle3000.Text = "Normal"
            Me.Tb_Detalle2000.Text = "Normal"
            Me.Tb_Detalle1000.Text = "Normal"
            Me.Tb_Detalle05.Text = "Normal"
            Me.Tb_Detalle025.Text = "Normal"
        End If

        If TIPO = 2 Then
            Cb_Base.Enabled = False
            Cu_BuscarPersonaExamenMedico.Enabled = False
            Rb_ExamenIngreso.Enabled = False
            Rb_ExamenEgreso.Enabled = False
            Rb_ExamenPeriodico.Enabled = False
            Me.Cu_Vacuna1.Enabled = True
        End If
    End Sub

    Public Sub CargarTablas()
        Dim identificador As Long
        Dim tipo As Integer
        Dim subtipo As Integer
        If IDEXAMENMODIFICANDO < 0 Then
            identificador = IDEXAMEN
            tipo = 1 'Crear
        Else
            identificador = IDEXAMENMODIFICANDO
            tipo = 2 'Editar
            subtipo = IDEXAMEN
        End If

        dsCargar = bddatos.CargarMaestrasHSE(3, identificador, tipo, subtipo)

        Cb_NivelAcademico.DataSource = dsCargar.Tables(0)
        Cb_NivelAcademico.DisplayMember = "NOMBRENIVELEDUCATIVO"
        Cb_NivelAcademico.ValueMember = "CODIGONIVELEDUCATIVO"

        Cb_EstadoCivil.DataSource = dsCargar.Tables(1)
        Cb_EstadoCivil.DisplayMember = "NOMBRETIPOESTADOCIVIL"
        Cb_EstadoCivil.ValueMember = "CODIGOTIPOESTADOCIVIL"

        Cb_Dominancia.DataSource = dsCargar.Tables(2)
        Cb_Dominancia.DisplayMember = "NOMBRE"
        Cb_Dominancia.ValueMember = "ID"

        Cb_Proyecto.DataSource = dsCargar.Tables(3)
        Cb_Proyecto.DisplayMember = "NOMBRE"
        Cb_Proyecto.ValueMember = "ID"

        Cb_Base.DataSource = dsCargar.Tables(4)
        Cb_Base.DisplayMember = "ABREVIATURABASE"
        Cb_Base.ValueMember = "IDBASESISCONTROL"

        Cb_Cargo.DataSource = dsCargar.Tables(6)
        Cb_Cargo.DisplayMember = "NOMBRE"
        Cb_Cargo.ValueMember = "ID"

        Cb_TipoCargo.DataSource = dsCargar.Tables(7)
        Cb_TipoCargo.DisplayMember = "NOMBRE"
        Cb_TipoCargo.ValueMember = "ID"

        Cb_Jornada.DataSource = dsCargar.Tables(8)
        Cb_Jornada.DisplayMember = "NOMBRE"
        Cb_Jornada.ValueMember = "ID"

        Cb_GrupoSanguineo.DataSource = dsCargar.Tables(9)
        Cb_GrupoSanguineo.DisplayMember = "NOMBRE"
        Cb_GrupoSanguineo.ValueMember = "ID"

        Cb_AFP.DataSource = dsCargar.Tables(10)
        Cb_AFP.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cb_AFP.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"

        Cb_EPS.DataSource = dsCargar.Tables(11)
        Cb_EPS.DisplayMember = "NOMBRETIPOENTIDADADMINISTRADORA"
        Cb_EPS.ValueMember = "CODIGOTIPOENTIDADADMINISTRADORA"

        DGVC_Agente.DataSource = dsCargar.Tables(12)
        DGVC_Agente.DisplayMember = "NOMBRE"
        DGVC_Agente.ValueMember = "ID"

        DGVC_Magnitud.DataSource = dsCargar.Tables(13)
        DGVC_Magnitud.DisplayMember = "NOMBRE"
        DGVC_Magnitud.ValueMember = "ID"

        DGVC_OrigenEnfermedad.DataSource = dsCargar.Tables(15)
        DGVC_OrigenEnfermedad.DisplayMember = "NOMBRE"
        DGVC_OrigenEnfermedad.ValueMember = "ID"

        DGVC_OrigenAccidente.DataSource = dsCargar.Tables(16)
        DGVC_OrigenAccidente.DisplayMember = "NOMBRE"
        DGVC_OrigenAccidente.ValueMember = "ID"

        DGVC_Habitos.DataSource = dsCargar.Tables(17)
        DGVC_Habitos.ValueMember = "IDHABITO"
        DGVC_Habitos.DisplayMember = "NOMBREHABITO"

        DGVCB_Aplica.DataSource = dsCargar.Tables(14)
        DGVCB_Aplica.ValueMember = "ID"
        DGVCB_Aplica.DisplayMember = "NOMBRE"

        DGVC_TIEMPO.DataSource = dsCargar.Tables(18)
        DGVC_TIEMPO.DisplayMember = "NOMBRE"
        DGVC_TIEMPO.ValueMember = "ID"

        DGVC_FrecuenciaHabitos.DataSource = dsCargar.Tables(19)
        DGVC_FrecuenciaHabitos.DisplayMember = "NOMBRE"
        DGVC_FrecuenciaHabitos.ValueMember = "ID"

        DGVC_Antecedentes.DataSource = dsCargar.Tables(21)
        DGVC_Antecedentes.DisplayMember = "NOMBRE"
        DGVC_Antecedentes.ValueMember = "ID"

        Cb_ViaComprometida8000.DataSource = dsCargar.Tables(22).Copy
        Cb_ViaComprometida8000.DisplayMember = "NOMBRE"
        Cb_ViaComprometida8000.ValueMember = "ID"

        Cb_ViaComprometida6000.DataSource = dsCargar.Tables(22).Copy
        Cb_ViaComprometida6000.DisplayMember = "NOMBRE"
        Cb_ViaComprometida6000.ValueMember = "ID"

        Cb_ViaComprometida3000.DataSource = dsCargar.Tables(22).Copy
        Cb_ViaComprometida3000.DisplayMember = "NOMBRE"
        Cb_ViaComprometida3000.ValueMember = "ID"

        Cb_ViaComprometida2000.DataSource = dsCargar.Tables(22).Copy
        Cb_ViaComprometida2000.DisplayMember = "NOMBRE"
        Cb_ViaComprometida2000.ValueMember = "ID"

        Cb_ViaComprometida1000.DataSource = dsCargar.Tables(22).Copy
        Cb_ViaComprometida1000.DisplayMember = "NOMBRE"
        Cb_ViaComprometida1000.ValueMember = "ID"

        Cb_ViaComprometida05.DataSource = dsCargar.Tables(22).Copy
        Cb_ViaComprometida05.DisplayMember = "NOMBRE"
        Cb_ViaComprometida05.ValueMember = "ID"

        Cb_ViaComprometida025.DataSource = dsCargar.Tables(22).Copy
        Cb_ViaComprometida025.DisplayMember = "NOMBRE"
        Cb_ViaComprometida025.ValueMember = "ID"

        Cb_Audiometria.DataSource = dsCargar.Tables(34).Copy
        Cb_Audiometria.DisplayMember = "NOMBRE"
        Cb_Audiometria.ValueMember = "ID"

        Cb_Espirometria.DataSource = dsCargar.Tables(35).Copy
        Cb_Espirometria.DisplayMember = "NOMBRE"
        Cb_Espirometria.ValueMember = "ID"

        Cb_EKG.DataSource = dsCargar.Tables(36).Copy
        Cb_EKG.DisplayMember = "NOMBRE"
        Cb_EKG.ValueMember = "ID"

        Dgv_Antecedentes.AutoGenerateColumns = False
        dtAntecedentes = dsCargar.Tables(24)
        Dgv_Antecedentes.DataSource = dtAntecedentes

        Dgv_Enfermedades.AutoGenerateColumns = False
        dtEnfermedades = dsCargar.Tables(25)
        Dgv_Enfermedades.DataSource = dtEnfermedades

        Dgv_Habitos.AutoGenerateColumns = False
        dtHabitos = dsCargar.Tables(26)
        Dgv_Habitos.DataSource = dtHabitos

        Dgv_ImpresionDiagnosticaFinal.AutoGenerateColumns = False
        dtImpresionDiagnostica = dsCargar.Tables(27)
        Dgv_ImpresionDiagnosticaFinal.DataSource = dtImpresionDiagnostica

        Dgv_Accidente.AutoGenerateColumns = False
        dtSecuelas = dsCargar.Tables(28)
        Dgv_Accidente.DataSource = dtSecuelas

        Dgv_Tareas.AutoGenerateColumns = False
        dtTareas = dsCargar.Tables(29)
        Dgv_Tareas.DataSource = dtTareas

        dtValoracionAuditiva = dsCargar.Tables(30)

        Dgv_Higiene.AutoGenerateColumns = False
        dtHigiene = dsCargar.Tables(31)
        Dgv_Higiene.DataSource = dtHigiene

        Dgv_AntecedenteLaborales.AutoGenerateColumns = False
        dtAntecedentesLaboral = dsCargar.Tables(37)
        Dgv_AntecedenteLaborales.DataSource = dtAntecedentesLaboral

        dtRiesgosAntecedentesLaborales = dsCargar.Tables(40)

        DGVC_ARL.DataSource = dsCargar.Tables(38).Copy
        DGVC_ARL.DisplayMember = "NOMBRE"
        DGVC_ARL.ValueMember = "ID"

        DGVC_Cargo.DataSource = dsCargar.Tables(6).Copy
        DGVC_Cargo.DisplayMember = "NOMBRE"
        DGVC_Cargo.ValueMember = "ID"

        DGVC_Origen.DataSource = dsCargar.Tables(16).Copy
        DGVC_Origen.DisplayMember = "NOMBRE"
        DGVC_Origen.ValueMember = "ID"

        DGVC_Jornada.DataSource = dsCargar.Tables(8).Copy
        DGVC_Jornada.DisplayMember = "NOMBRE"
        DGVC_Jornada.ValueMember = "ID"

        dtExamen = dsCargar.Tables(23)
        If dtExamen.Rows.Count > 0 Then
            FilaExamen = dtExamen.Rows(0)
        End If

        If tipo = 1 Then
            Dim FilaHabitos As DataRow
            For i As Integer = 0 To dsCargar.Tables(17).Rows.Count - 1
                FilaHabitos = dtHabitos.NewRow
                FilaHabitos(0) = dsCargar.Tables(17).Rows(i).Item(0)
                FilaHabitos(1) = "N"
                FilaHabitos(2) = 0
                FilaHabitos(3) = "N"
                FilaHabitos(4) = 0
                FilaHabitos(5) = 0
                FilaHabitos(6) = "N/A"
                dtHabitos.Rows.Add(FilaHabitos)
            Next
            Dim FilaAntecedentesPatologicos As DataRow
            For i As Integer = 0 To dsCargar.Tables(21).Rows.Count - 1
                FilaAntecedentesPatologicos = dtAntecedentes.NewRow
                FilaAntecedentesPatologicos(0) = dsCargar.Tables(21).Rows(i).Item(0)
                dtAntecedentes.Rows.Add(FilaAntecedentesPatologicos)
            Next
        End If

        If tipo = 2 Then
            Me.Cu_Vacuna1.IdPersona = FilaExamen("IDPERSONA")
            Me.Cu_Vacuna1.dtVacunaPersona = dsCargar.Tables(20).Copy
            Me.Cu_Vacuna1.contRegIni = dsCargar.Tables(20).Rows.Count
        End If

        If dtValoracionAuditiva IsNot Nothing Then
            If dtValoracionAuditiva.Rows.Count > 0 Then
                Me.TC_ExamenMedicoPeriodico.TabPages.Add(Me.TP_ExamenAuditivo)
                Me.TC_ExamenMedicoPeriodico.Controls.Remove(Me.TP_ImpresionDiagnostica)
                Me.TC_ExamenMedicoPeriodico.TabPages.Add(Me.TP_ImpresionDiagnostica)
            End If
        End If

        If FilaExamen IsNot Nothing Then
            If Trim(FilaExamen("LINEAROJA").ToString) <> "" Then
                Me.TC_ExamenMedicoPeriodico.TabPages.Add(Me.TP_ExamenComplementario)
                Me.TC_ExamenMedicoPeriodico.Controls.Remove(Me.TP_ImpresionDiagnostica)
                Me.TC_ExamenMedicoPeriodico.TabPages.Add(Me.TP_ImpresionDiagnostica)
            End If
        End If

        Me.Cu_BuscarPersonaExamenMedico.CargarDatos()
        Me.Cu_CiudadContrato.CargarDatos()
    End Sub

    Public Sub LlenarExamen()
        Me.Cu_BuscarPersonaExamenMedico.CargarDatos()
        If FilaExamen("TIPOEXAMEN").ToString = "I" Then
            Me.Rb_ExamenIngreso.Checked = True
            Me.Rb_ExamenPeriodico.Checked = False
            Me.Rb_ExamenEgreso.Checked = False
            Me.Dtp_FechaIngreso.Enabled = False
        Else
            If FilaExamen("TIPOEXAMEN").ToString = "P" Then
                Me.Rb_ExamenIngreso.Checked = False
                Me.Rb_ExamenPeriodico.Checked = True
                Me.Rb_ExamenEgreso.Checked = False
            Else
                Me.Rb_ExamenIngreso.Checked = False
                Me.Rb_ExamenPeriodico.Checked = False
                Me.Rb_ExamenEgreso.Checked = True
            End If
        End If

        Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue = FilaExamen("IDPERSONA")
        Me.Cu_BuscarPersonaExamenMedico.CargarCajaTexto()
        Me.Tb_Edad.Text = FilaExamen("EDAD").ToString
        If FilaExamen("GENERO").ToString = "M" Then
            Me.Rb_Masculino.Checked = True
            Me.Rb_Femenino.Checked = False
        Else
            Me.Rb_Femenino.Checked = True
            Me.Rb_Masculino.Checked = False
        End If
        Me.Cb_NivelAcademico.SelectedValue = FilaExamen("NIVELACADEMICO")
        Me.Cb_EstadoCivil.SelectedValue = FilaExamen("ESTADOCIVIL")
        Me.Cb_Dominancia.SelectedValue = FilaExamen("DOMINANCIA")
        Me.Cb_Proyecto.SelectedValue = FilaExamen("PROYECTO")
        Me.Cb_Base.SelectedValue = FilaExamen("BASE")
        Me.Cb_Dependencia.SelectedValue = FilaExamen("DEPENDENCIA")
        Me.Cb_Cargo.SelectedValue = FilaExamen("CARGO")
        Me.Cb_TipoCargo.SelectedValue = FilaExamen("TIPOCARGO")

        If Trim(FilaExamen("FECHAINGRESOEMPRESA").ToString) <> "" Then
            Me.Dtp_FechaIngreso.Checked = True
            Me.Dtp_FechaIngreso.Value = FilaExamen("FECHAINGRESOEMPRESA")
        Else
            Me.Dtp_FechaIngreso.Checked = False
        End If

        Me.Cu_CiudadContrato.Cb_Ciudad.SelectedValue = FilaExamen("CIUDADCONTRATO")

        Me.Num_CargoAños.Value = FilaExamen("TIEMPOCARGOAÑOS")
        Me.Num_CargoMeses.Value = FilaExamen("TIEMPOCARGOMESES")
        Me.Cb_Jornada.SelectedValue = FilaExamen("JORNADA")
        Me.Num_Turnos.Value = FilaExamen("TURNOS")
        Me.Cb_GrupoSanguineo.SelectedValue = FilaExamen("GRUPOSANGUINEO")
        Me.Cb_AFP.SelectedValue = FilaExamen("AFP")
        Me.Cb_EPS.SelectedValue = FilaExamen("EPS")

        Dim Riesgos As String = FilaExamen("RIESGO")
        Me.Cb_Biomecanico.CheckState = Windows.Forms.CheckState.Unchecked
        Me.Cb_Psicosocial.CheckState = Windows.Forms.CheckState.Unchecked
        Me.Cb_Biológico.CheckState = Windows.Forms.CheckState.Unchecked
        Me.Cb_Seguridad.CheckState = Windows.Forms.CheckState.Unchecked
        Me.Cb_Fisico.CheckState = Windows.Forms.CheckState.Unchecked
        Me.Cb_Quimico.CheckState = Windows.Forms.CheckState.Unchecked
        Me.Cb_Natural.CheckState = Windows.Forms.CheckState.Unchecked
        Me.Cb_Locativo.CheckState = Windows.Forms.CheckState.Unchecked

        Dim ch As Char = Riesgos(0)
        If ch = "S" Then
            Me.Cb_Biomecanico.Checked = True
        Else
            Me.Cb_Biomecanico.Checked = False
        End If
        ch = Riesgos(1)
        If ch = "S" Then
            Me.Cb_Psicosocial.Checked = True
        Else
            Me.Cb_Psicosocial.Checked = False
        End If
        ch = Riesgos(2)
        If ch = "S" Then
            Me.Cb_Biológico.Checked = True
        Else
            Me.Cb_Biológico.Checked = False
        End If
        ch = Riesgos(3)
        If ch = "S" Then
            Me.Cb_Seguridad.Checked = True
        Else
            Me.Cb_Seguridad.Checked = False
        End If
        ch = Riesgos(4)
        If ch = "S" Then
            Me.Cb_Fisico.Checked = True
        Else
            Me.Cb_Fisico.Checked = False
        End If
        ch = Riesgos(5)
        If ch = "S" Then
            Me.Cb_Quimico.Checked = True
        Else
            Me.Cb_Quimico.Checked = False
        End If
        ch = Riesgos(6)
        If ch = "S" Then
            Me.Cb_Natural.Checked = True
        Else
            Me.Cb_Natural.Checked = False
        End If
        ch = Riesgos(7)
        If ch = "S" Then
            Me.Cb_Locativo.Checked = True
        Else
            Me.Cb_Locativo.Checked = False
        End If

        Me.Tb_RevisionSistemas.Text = FilaExamen("REVISIONPORSISTEMA").ToString
        Me.Num_TaSist.Value = FilaExamen("TENSIONSISTOLICA")
        Me.Num_TaDiast.Value = FilaExamen("TENSIONDIASTOLICA")
        Me.Num_FC.Value = FilaExamen("FRECUENCIACARDIACA")
        Me.Num_FR.Value = FilaExamen("FRECUENCIARESPIRATORIA")
        Me.Num_SO2.Value = FilaExamen("SO2")
        Me.Tb_Peso.Text = FilaExamen("PESO")
        Me.Tb_Talla.Text = FilaExamen("TALLA")
        CalcularImc()
        Me.Num_PerimetroAbdomen.Value = FilaExamen("PERIMETROABDOMEN")
        Me.Tb_EvidenciasClinicas.Text = FilaExamen("EVIDENCIASCLINICASSIGNOSVITALES")
        Me.Tb_Simetria.Text = FilaExamen("SIMETRIA")
        Me.Tb_Curvatura.Text = FilaExamen("CURVATURA")
        Me.Tb_Dolor.Text = FilaExamen("DOLOR")
        Me.Tb_Espasmo.Text = FilaExamen("ESPASMO")
        Me.Tb_Flexion.Text = FilaExamen("FLEXION")
        Me.Tb_Extension.Text = FilaExamen("EXTENSION")
        Me.Tb_FlexionLateral.Text = FilaExamen("FLEXIONLATERAL")
        Me.Tb_Rotacion.Text = FilaExamen("ROTACION")
        If Trim(FilaExamen("TESTSCHOBER").ToString) = "S" Then
            Me.Rb_Mayor5cm.Checked = True
            Me.Rb_Menor5cm.Checked = False
        Else
            Me.Rb_Mayor5cm.Checked = False
            Me.Rb_Menor5cm.Checked = True
        End If

        If Trim(FilaExamen("SIGNOLASEGUE").ToString) <> "" Then
            Me.Rb_Positivo.Checked = True
            Me.Rb_Negativo.Checked = False
            Me.Tb_Lasegue.Show()
            Me.Tb_Lasegue.Text = FilaExamen("SIGNOLASEGUE").ToString
        Else
            Me.Rb_Positivo.Checked = False
            Me.Rb_Negativo.Checked = True
            Me.Tb_Lasegue.Hide()
        End If

        If FilaExamen("TESTWELLS").ToString = "1" Then
            Me.Rb_Superior.Checked = True
            Me.Rb_Excelente.Checked = False
            Me.Rb_Bueno.Checked = False
            Me.Rb_Promedio.Checked = False
            Me.Rb_Deficiente.Checked = False
            Me.Rb_Pobre.Checked = False
            Me.Rb_MuyPobre.Checked = False
        Else
            If FilaExamen("TESTWELLS").ToString = "2" Then
                Me.Rb_Superior.Checked = False
                Me.Rb_Excelente.Checked = True
                Me.Rb_Bueno.Checked = False
                Me.Rb_Promedio.Checked = False
                Me.Rb_Deficiente.Checked = False
                Me.Rb_Pobre.Checked = False
                Me.Rb_MuyPobre.Checked = False
            Else
                If FilaExamen("TESTWELLS").ToString = "3" Then
                    Me.Rb_Superior.Checked = False
                    Me.Rb_Excelente.Checked = False
                    Me.Rb_Bueno.Checked = True
                    Me.Rb_Promedio.Checked = False
                    Me.Rb_Deficiente.Checked = False
                    Me.Rb_Pobre.Checked = False
                    Me.Rb_MuyPobre.Checked = False
                Else
                    If FilaExamen("TESTWELLS").ToString = "4" Then
                        Me.Rb_Superior.Checked = False
                        Me.Rb_Excelente.Checked = False
                        Me.Rb_Bueno.Checked = False
                        Me.Rb_Promedio.Checked = True
                        Me.Rb_Deficiente.Checked = False
                        Me.Rb_Pobre.Checked = False
                        Me.Rb_MuyPobre.Checked = False
                    Else
                        If FilaExamen("TESTWELLS").ToString = "5" Then
                            Me.Rb_Superior.Checked = False
                            Me.Rb_Excelente.Checked = False
                            Me.Rb_Bueno.Checked = False
                            Me.Rb_Promedio.Checked = False
                            Me.Rb_Deficiente.Checked = True
                            Me.Rb_Pobre.Checked = False
                            Me.Rb_MuyPobre.Checked = False
                        Else
                            If FilaExamen("TESTWELLS").ToString = "6" Then
                                Me.Rb_Superior.Checked = False
                                Me.Rb_Excelente.Checked = False
                                Me.Rb_Bueno.Checked = False
                                Me.Rb_Promedio.Checked = False
                                Me.Rb_Deficiente.Checked = False
                                Me.Rb_Pobre.Checked = True
                                Me.Rb_MuyPobre.Checked = False
                            Else
                                If FilaExamen("TESTWELLS").ToString = "7" Then
                                    Me.Rb_Superior.Checked = False
                                    Me.Rb_Excelente.Checked = False
                                    Me.Rb_Bueno.Checked = False
                                    Me.Rb_Promedio.Checked = False
                                    Me.Rb_Deficiente.Checked = False
                                    Me.Rb_Pobre.Checked = False
                                    Me.Rb_MuyPobre.Checked = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Me.Tb_ArtEscapulohumeral.Text = FilaExamen("ARTESCAPULOHUMERAL").ToString
        Me.Tb_ArtAcromioclavicular.Text = FilaExamen("ARTACROMIOCLAVICULAR").ToString
        Me.Tb_ArtEscapulotorácica.Text = FilaExamen("ARTESCAPULOTORACICA").ToString
        Me.Tb_Subdeltoidea.Text = FilaExamen("ARTSUBDELTOIDEA").ToString
        Me.Tb_EjeAnteroposterior.Text = FilaExamen("EJEANTEROPOSTERIOR").ToString
        Me.Tb_EjeTransversal.Text = FilaExamen("EJETRANSVERSAL").ToString
        Me.Tb_EjeLongitudinal.Text = FilaExamen("EJELONGITUDINAL").ToString
        Me.Tb_Circunduccion.Text = FilaExamen("CIRCUNDUCCION").ToString
        Me.Tb_AbduccionElevacion.Text = FilaExamen("ABDUCCIONELEVACION").ToString
        Me.Tb_Aduccion.Text = FilaExamen("ADUCCION").ToString
        Me.Tb_RotacionExterna.Text = FilaExamen("ROTACIONEXTERNA").ToString
        Me.Tb_FlexoExtension.Text = FilaExamen("FLEXOEXTENSION").ToString
        Me.Tb_HombroDerecho.Text = FilaExamen("HOMBRODERECHO").ToString
        Me.Tb_HombroIzquierdo.Text = FilaExamen("HOMBROIZQUIERDO").ToString
        Me.Tb_CodoDerecho.Text = FilaExamen("CODODERECHO").ToString
        Me.Tb_CodoIzquierdo.Text = FilaExamen("CODOIZQUIERDO").ToString
        Me.Tb_MuñecaDerecha.Text = FilaExamen("MUNECADERECHA").ToString
        Me.Tb_MuñecaIzquierda.Text = FilaExamen("MUNECAIZQUIERDA").ToString
        Me.Tb_ManoDerecha.Text = FilaExamen("MANODERECHA").ToString
        Me.Tb_ManoIzquierda.Text = FilaExamen("MANOIZQUIERDA").ToString
        Me.Tb_DedoDerecho1.Text = FilaExamen("DEDODERECHO1").ToString
        Me.Tb_DedoDerecho2.Text = FilaExamen("DEDODERECHO2").ToString
        Me.Tb_DedoDerecho3.Text = FilaExamen("DEDODERECHO3").ToString
        Me.Tb_DedoDerecho4.Text = FilaExamen("DEDODERECHO4").ToString
        Me.Tb_DedoDerecho5.Text = FilaExamen("DEDODERECHO5").ToString
        Me.Tb_DedoIzquierdo1.Text = FilaExamen("DEDOIZQUIERDO1").ToString
        Me.Tb_DedoIzquierdo2.Text = FilaExamen("DEDOIZQUIERDO2").ToString
        Me.Tb_DedoIzquierdo3.Text = FilaExamen("DEDOIZQUIERDO3").ToString
        Me.Tb_DedoIzquierdo4.Text = FilaExamen("DEDOIZQUIERDO4").ToString
        Me.Tb_DedoIzquierdo5.Text = FilaExamen("DEDOIZQUIERDO5").ToString
        Me.Tb_ComentariosMiembrosSuperiores.Text = FilaExamen("COMENTARIOSEVIDENCIASMIEMBROSSUPERIORES").ToString
        Me.Tb_CaderasDerecha.Text = FilaExamen("CADERADERECHA").ToString
        Me.Tb_CaderasIzquierda.Text = FilaExamen("CADERAIZQUIERDA").ToString
        Me.Tb_RodillaDerecha.Text = FilaExamen("RODILLADERECHA").ToString
        Me.Tb_RodillaIzquierda.Text = FilaExamen("RODILLAIZQUIERDA").ToString
        Me.Tb_TobilloDerecho.Text = FilaExamen("TOBILLODERECHO").ToString
        Me.Tb_TobilloIzquierdo.Text = FilaExamen("TOBILLOIZQUIERDO").ToString
        Me.Tb_PieDerecho.Text = FilaExamen("PIEDERECHO").ToString
        Me.Tb_PieIzquierdo.Text = FilaExamen("PIEIZQUIERDO").ToString
        Me.Tb_FaseApoyoPieDerecho.Text = FilaExamen("FASEAPOYOPIEDERECHO").ToString
        Me.Tb_FaseApoyoPieIzquierdo.Text = FilaExamen("FASEAPOYOPIEIZQUIERDO").ToString
        Me.Tb_FaseBalanceoPieDerecho.Text = FilaExamen("FASEBALANCEOPIEDERECHO").ToString
        Me.Tb_FaseBalanceoPieIzquierdo.Text = FilaExamen("FASEBALANCEOPIEIZQUIERDO").ToString
        Me.Tb_Marcha.Text = FilaExamen("MARCHA").ToString
        Me.Tb_ComentariosMiembrosInferiores.Text = FilaExamen("COMENTARIOSEVIDENCIASMIEMBROSINFERIORES").ToString

        If dtValoracionAuditiva IsNot Nothing Then
            If dtValoracionAuditiva.Rows.Count > 0 Then
                Me.Rb_AuditivaSi.Checked = True
                Me.Rb_AuditivaNo.Checked = False

                Me.Num_OI_8000.Value = dtValoracionAuditiva.Rows(0).Item("OIDOIZQUIERDO")
                Me.Num_OD_8000.Value = dtValoracionAuditiva.Rows(0).Item("OIDODERECHO")
                Me.Cb_ViaComprometida8000.SelectedValue = dtValoracionAuditiva.Rows(0).Item("VIACOMPROMETIDA")
                Me.Tb_Detalle8000.Text = dtValoracionAuditiva.Rows(0).Item("DETALLE")

                Me.Num_OI_6000.Value = dtValoracionAuditiva.Rows(1).Item("OIDOIZQUIERDO")
                Me.Num_OD_6000.Value = dtValoracionAuditiva.Rows(1).Item("OIDODERECHO")
                Me.Cb_ViaComprometida6000.SelectedValue = dtValoracionAuditiva.Rows(1).Item("VIACOMPROMETIDA")
                Me.Tb_Detalle6000.Text = dtValoracionAuditiva.Rows(1).Item("DETALLE")

                Me.Num_OI_3000.Value = dtValoracionAuditiva.Rows(2).Item("OIDOIZQUIERDO")
                Me.Num_OD_3000.Value = dtValoracionAuditiva.Rows(2).Item("OIDODERECHO")
                Me.Cb_ViaComprometida3000.SelectedValue = dtValoracionAuditiva.Rows(2).Item("VIACOMPROMETIDA")
                Me.Tb_Detalle3000.Text = dtValoracionAuditiva.Rows(2).Item("DETALLE")

                Me.Num_OI_2000.Value = dtValoracionAuditiva.Rows(3).Item("OIDOIZQUIERDO")
                Me.Num_OD_2000.Value = dtValoracionAuditiva.Rows(3).Item("OIDODERECHO")
                Me.Cb_ViaComprometida2000.SelectedValue = dtValoracionAuditiva.Rows(3).Item("VIACOMPROMETIDA")
                Me.Tb_Detalle2000.Text = dtValoracionAuditiva.Rows(3).Item("DETALLE")

                Me.Num_OI_1000.Value = dtValoracionAuditiva.Rows(4).Item("OIDOIZQUIERDO")
                Me.Num_OD_1000.Value = dtValoracionAuditiva.Rows(4).Item("OIDODERECHO")
                Me.Cb_ViaComprometida1000.SelectedValue = dtValoracionAuditiva.Rows(4).Item("VIACOMPROMETIDA")
                Me.Tb_Detalle1000.Text = dtValoracionAuditiva.Rows(4).Item("DETALLE")

                Me.Num_OI_05.Value = dtValoracionAuditiva.Rows(5).Item("OIDOIZQUIERDO")
                Me.Num_OD_05.Value = dtValoracionAuditiva.Rows(5).Item("OIDODERECHO")
                Me.Cb_ViaComprometida05.SelectedValue = dtValoracionAuditiva.Rows(5).Item("VIACOMPROMETIDA")
                Me.Tb_Detalle05.Text = dtValoracionAuditiva.Rows(5).Item("DETALLE")

                Me.Num_OI_025.Value = dtValoracionAuditiva.Rows(6).Item("OIDOIZQUIERDO")
                Me.Num_OD_025.Value = dtValoracionAuditiva.Rows(6).Item("OIDODERECHO")
                Me.Cb_ViaComprometida025.SelectedValue = dtValoracionAuditiva.Rows(6).Item("VIACOMPROMETIDA")
                Me.Tb_Detalle025.Text = dtValoracionAuditiva.Rows(6).Item("DETALLE")
            Else
                Me.Rb_AuditivaSi.Checked = False
                Me.Rb_AuditivaNo.Checked = True
            End If
        End If
        If FilaExamen IsNot Nothing Then
            If Trim(FilaExamen("LINEAROJA").ToString) <> "" Then
                Me.Rb_SiExComplementario.Checked = True

                Me.Tb_LineaRoja.Text = FilaExamen("LINEAROJA").ToString
                FormatearEnteros(Me.Tb_LineaRoja)
                Me.Tb_LineaBlanca.Text = FilaExamen("LINEABLANCA").ToString
                FormatearEnteros(Me.Tb_LineaBlanca)
                Me.Tb_Plaquetas.Text = FilaExamen("PLAQUETAS").ToString
                FormatearEnteros(Me.Tb_Plaquetas)
                Me.Tb_CuadroHematico.Text = FilaExamen("OBSERVACIONESCUADROHEMATICO").ToString
                Me.Tb_Triglicerios.Text = FilaExamen("TRIGLICERIOS").ToString
                Me.Tb_Colesterol.Text = FilaExamen("COLESTEROL").ToString
                Me.Tb_HDL.Text = FilaExamen("HDL").ToString
                Me.Tb_LDL.Text = FilaExamen("LDL").ToString
                Me.Tb_Quimica.Text = FilaExamen("OBSERVACIONESQUIMICA").ToString
                Me.Tb_Glicemia.Text = FilaExamen("GLICEMIA").ToString
                Me.Tb_GlicemiaConcepto.Text = FilaExamen("ESTADOGLICEMIA").ToString
                Me.Tb_FuncionRenal.Text = FilaExamen("FUNCIONRENAL").ToString
                Me.Tb_FuncionRenalConcepto.Text = FilaExamen("ESTADOFUNCIONRENAL").ToString
                Me.Tb_FuncionHepaticaAST.Text = FilaExamen("FUNCIONHEPATICAAST").ToString
                Me.Tb_FuncionHepaticaALT.Text = FilaExamen("FUNCIONHEPATICAALT").ToString
                Me.Tb_FuncionHepaticaConcepto.Text = FilaExamen("ESTADOFUNCIONHEPATICA").ToString

                Dim ParcialOrina As String = FilaExamen("PARCIALORINA").ToString
                Me.Ck_PONormal.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_POBacterias.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_POProteinura.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_POGlucosuria.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_POCalcio.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_POSangre.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_POAlbumina.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_POEritocitocis.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_POCreatinuria.CheckState = Windows.Forms.CheckState.Unchecked

                Dim po As Char = ParcialOrina(0)
                If po = "S" Then
                    Me.Ck_PONormal.Checked = True
                Else
                    Me.Ck_PONormal.Checked = False
                End If
                po = ParcialOrina(1)
                If po = "S" Then
                    Me.Ck_POBacterias.Checked = True
                Else
                    Me.Ck_POBacterias.Checked = False
                End If
                po = ParcialOrina(2)
                If po = "S" Then
                    Me.Ck_POProteinura.Checked = True
                Else
                    Me.Ck_POProteinura.Checked = False
                End If
                po = ParcialOrina(3)
                If po = "S" Then
                    Me.Ck_POGlucosuria.Checked = True
                Else
                    Me.Ck_POGlucosuria.Checked = False
                End If
                po = ParcialOrina(4)
                If po = "S" Then
                    Me.Ck_POCalcio.Checked = True
                Else
                    Me.Ck_POCalcio.Checked = False
                End If
                po = ParcialOrina(5)
                If po = "S" Then
                    Me.Ck_POSangre.Checked = True
                Else
                    Me.Ck_POSangre.Checked = False
                End If
                po = ParcialOrina(6)
                If po = "S" Then
                    Me.Ck_POAlbumina.Checked = True
                Else
                    Me.Ck_POAlbumina.Checked = False
                End If
                po = ParcialOrina(7)
                If po = "S" Then
                    Me.Ck_POEritocitocis.Checked = True
                Else
                    Me.Ck_POEritocitocis.Checked = False
                End If
                po = ParcialOrina(8)
                If po = "S" Then
                    Me.Ck_POCreatinuria.Checked = True
                Else
                    Me.Ck_POCreatinuria.Checked = False
                End If

                Dim Psicofarmacos As String = FilaExamen("PSICOFARMACOS").ToString
                Me.Ck_PsNegativo.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_PsMarihuana.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_PsCocaina.CheckState = Windows.Forms.CheckState.Unchecked
                Dim ps As Char = Psicofarmacos(0)
                If ps = "S" Then
                    Me.Ck_PsNegativo.Checked = True
                Else
                    Me.Ck_PsNegativo.Checked = False
                End If
                ps = Riesgos(1)
                If ps = "S" Then
                    Me.Ck_PsMarihuana.Checked = True
                Else
                    Me.Ck_PsMarihuana.Checked = False
                End If
                ps = Riesgos(2)
                If ps = "S" Then
                    Me.Ck_PsCocaina.Checked = True
                Else
                    Me.Ck_PsCocaina.Checked = False
                End If

                Dim Visiometria As String = FilaExamen("VISIOMETRIA")
                Me.Ck_VNormal.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_VCerca.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_VLejos.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_VMovilidad.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_VParpados.CheckState = Windows.Forms.CheckState.Unchecked
                Me.Ck_VConjuntiva.CheckState = Windows.Forms.CheckState.Unchecked
                Dim vs As Char = Visiometria(0)
                If vs = "S" Then
                    Me.Ck_VNormal.Checked = True
                Else
                    Me.Ck_VNormal.Checked = False
                End If
                vs = Visiometria(1)
                If vs = "S" Then
                    Me.Ck_VCerca.Checked = True
                Else
                    Me.Ck_VCerca.Checked = False
                End If
                vs = Visiometria(2)
                If vs = "S" Then
                    Me.Ck_VLejos.Checked = True
                Else
                    Me.Ck_VLejos.Checked = False
                End If
                vs = Visiometria(3)
                If vs = "S" Then
                    Me.Ck_VMovilidad.Checked = True
                Else
                    Me.Ck_VMovilidad.Checked = False
                End If
                vs = Visiometria(4)
                If vs = "S" Then
                    Me.Ck_VParpados.Checked = True
                Else
                    Me.Ck_VParpados.Checked = False
                End If
                vs = Visiometria(5)
                If vs = "S" Then
                    Me.Ck_VConjuntiva.Checked = True
                Else
                    Me.Ck_VConjuntiva.Checked = False
                End If
                Me.Tb_OtrasAlteracionesVisuales.Text = FilaExamen("OTRASALTERACIONESVISUALES").ToString
                Me.Cb_Espirometria.SelectedValue = FilaExamen("ESPIROMETRIA").ToString
                Me.Cb_Audiometria.SelectedValue = FilaExamen("AUDIOMETRIA").ToString
                Me.Cb_EKG.SelectedValue = FilaExamen("EKG").ToString
                Me.Tb_EKGConclusion.Text = FilaExamen("EKGCONCLUSION").ToString
                Me.Tb_ImagenesDiagnosticas.Text = FilaExamen("IMAGENESDIAGNOSTICAS").ToString
            Else
                Me.Rb_SiExComplementario.Checked = False
                Me.Rb_NoExComplementario.Checked = True
            End If
        End If



        Me.Tb_ComentariosFinales.Text = FilaExamen("COMENTARIOSEVIDENCIASFINALES").ToString
        Me.Tb_EstudiosFinales.Text = FilaExamen("ESTUDIOSMIEMBROSFINALES").ToString

    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If GuardarExamenMedico() = True Then
            Me.Close()
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Fr_ExamenMedicoPeriodico_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.Bt_Guardar.Enabled = True And guardado = False Then
            If MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "SALIR SIN GUARDAR") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Public Function ValidarCasillas() As Boolean
        If Rb_ExamenIngreso.Checked = False And Rb_ExamenPeriodico.Checked = False And Rb_ExamenEgreso.Checked = False Then
            MsgBox("Debe seleccionar el tipo de examen.", MsgBoxStyle.Information, "Tipo Examen")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Gb_TipoExamen.Focus()
            ValidarCasillas = False
        End If
        If Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe selecionar una persona.", MsgBoxStyle.Information, "Persona")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cu_BuscarPersonaExamenMedico.Cb_Persona.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Edad.Text) = "" Then
            MsgBox("Debe ingresar la edad de la persona.", MsgBoxStyle.Information, "Edad Persona")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Tb_Edad.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Rb_Masculino.Checked = False And Rb_Femenino.Checked = False Then
            MsgBox("Debe seleccionar el genero de la persona.", MsgBoxStyle.Information, "Genero Persona")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Gb_Genero.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_NivelAcademico.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el nivel académico de la persona.", MsgBoxStyle.Information, "Nivel Académico Persona")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_NivelAcademico.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_EstadoCivil.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el estado civil de la persona.", MsgBoxStyle.Information, "Estado Civil Persona")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_EstadoCivil.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Dominancia.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la dominancia de la persona.", MsgBoxStyle.Information, "Dominancia Persona")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Dominancia.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Proyecto.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el proyecto al que pertence la persona.", MsgBoxStyle.Information, "Proyecto Persona")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Proyecto.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Base.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la base a la que pertence la persona.", MsgBoxStyle.Information, "Base Persona")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Base.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Dependencia.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la dependencia a la que pertence la persona.", MsgBoxStyle.Information, "Dependencia Persona")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Dependencia.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Cargo.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el cargo de la persona.", MsgBoxStyle.Information, "Cargo Persona")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Cargo.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_TipoCargo.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de cargo de la persona.", MsgBoxStyle.Information, "Tipo Cargo Persona")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_TipoCargo.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Dtp_FechaIngreso.Checked = False And Rb_ExamenIngreso.Checked = False Then
            MsgBox("Debe seleccionar la fecha de ingreso a la empresa.", MsgBoxStyle.Information, "Fecha ingreso")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Dtp_FechaIngreso.Focus()
            ValidarCasillas = False
            Exit Function
        Else
            If Dtp_FechaIngreso.Value.Date > Today.Date Then
                MsgBox("La fecha de ingreso no puede ser mayor a la fecha actual.", MsgBoxStyle.Information, "Fecha ingreso")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
                Dtp_FechaIngreso.Focus()
                ValidarCasillas = False
                Exit Function
            End If
        End If
        If Rb_ExamenIngreso.Checked = True Then
            If Cu_CiudadContrato.Cb_Ciudad.Text = "" OrElse Cu_CiudadContrato.Cb_Ciudad.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la ciudad de contratación.", MsgBoxStyle.Information, "Ciudad")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
                Cu_CiudadContrato.Cb_Ciudad.Focus()
                ValidarCasillas = False
                Exit Function
            End If
        End If

        If Num_CargoAños.Value = 0 And Num_CargoMeses.Value = 0 And Rb_ExamenIngreso.Checked = False Then
            MsgBox("Debe ingresar el tiempo en el cargo.", MsgBoxStyle.Information, "Tiempo Cargo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Num_CargoAños.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Cb_Jornada.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la jornada en la que trabaja.", MsgBoxStyle.Information, "Jornada")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Jornada.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Cb_GrupoSanguineo.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de sangre de la persona.", MsgBoxStyle.Information, "Grupo Sanguineo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_GrupoSanguineo.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_AFP.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar si esta afiliado a pensión.", MsgBoxStyle.Information, "Pensión")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_AFP.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_EPS.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la EPS.", MsgBoxStyle.Information, "EPS")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_EPS.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Cb_Biomecanico.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si el riesgo es Biomecánico o no.", MsgBoxStyle.Information, "Riesgo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Biomecanico.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Psicosocial.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si el riesgo es Psicosocial o no.", MsgBoxStyle.Information, "Riesgo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Biomecanico.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Biológico.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si el riesgo es Biológico o no.", MsgBoxStyle.Information, "Riesgo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Biomecanico.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Seguridad.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si el riesgo es de Seguridad o no.", MsgBoxStyle.Information, "Riesgo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Biomecanico.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Fisico.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si el riesgo es Físico o no.", MsgBoxStyle.Information, "Riesgo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Biomecanico.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Quimico.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si el riesgo es Químico o no.", MsgBoxStyle.Information, "Riesgo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Biomecanico.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Natural.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si el riesgo es Natural o no.", MsgBoxStyle.Information, "Riesgo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Biomecanico.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Cb_Locativo.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe seleccionar si el riesgo es Locativo o no.", MsgBoxStyle.Information, "Riesgo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DatosPersonales)
            Cb_Biomecanico.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Num_TaSist.Value = 0 Then
            MsgBox("Debe ingresar un valor diferente de 0 en el campo T.A. Sist.", MsgBoxStyle.Information, "T.A. Sistólica")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Num_TaSist.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Num_TaDiast.Value = 0 Then
            MsgBox("Debe ingresar un valor diferente de 0 en el campo T.A. Diast.", MsgBoxStyle.Information, "T.A. Diastólica")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Num_TaDiast.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Num_FC.Value = 0 Then
            MsgBox("Debe ingresar un valor diferente de 0 en el campo FC.", MsgBoxStyle.Information, "F.C.")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Num_FC.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Num_FR.Value = 0 Then
            MsgBox("Debe ingresar un valor diferente de 0 en el campo FR.", MsgBoxStyle.Information, "F.R.")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Num_FR.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Num_SO2.Value = 0 Then
            MsgBox("Debe ingresar un valor diferente de 0 en el campo SO2.", MsgBoxStyle.Information, "SO2")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Num_SO2.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Peso.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Peso.", MsgBoxStyle.Information, "Peso")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Tb_Peso.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Talla.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Talla.", MsgBoxStyle.Information, "Talla")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Tb_Talla.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Num_PerimetroAbdomen.Value = 0 Then
            MsgBox("Debe ingresar un valor diferente de 0 en el campo Perimetro Abdomen.", MsgBoxStyle.Information, "Perimetro Abdomen")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Num_PerimetroAbdomen.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Trim(Tb_EvidenciasClinicas.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Evidencias Clinicas.", MsgBoxStyle.Information, "Evidencias clinicas")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Tb_EvidenciasClinicas.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Trim(Tb_Simetria.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Simetria.", MsgBoxStyle.Information, "Simetria")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Tb_Simetria.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Curvatura.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Curvatura.", MsgBoxStyle.Information, "Curvatura")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Tb_Curvatura.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Dolor.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Dolor.", MsgBoxStyle.Information, "Dolor")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Tb_Dolor.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Espasmo.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Espasmo.", MsgBoxStyle.Information, "Espasmo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Tb_Espasmo.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Flexion.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Flexión.", MsgBoxStyle.Information, "Flexión")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Tb_Flexion.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Extension.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Extensión.", MsgBoxStyle.Information, "Extensión")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Tb_Extension.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_FlexionLateral.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Flexión Lateral.", MsgBoxStyle.Information, "Flexión Lateral")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Tb_FlexionLateral.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Rotacion.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Rotación.", MsgBoxStyle.Information, "Rotación")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico1)
            Tb_Rotacion.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Rb_Mayor5cm.Checked = False And Rb_Menor5cm.Checked = False Then
            MsgBox("Debe seleccionar una opción en el campo Test Schober.", MsgBoxStyle.Information, "Test Schober")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Gb_TestSchober.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Rb_Positivo.Checked = False And Rb_Negativo.Checked = False Then
            MsgBox("Debe seleccionar una opción en el campo Signo Lasegue.", MsgBoxStyle.Information, "Signo Lasegue")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Gb_SignoLasegue.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Rb_Positivo.Checked = True Then
            If Trim(Tb_Lasegue.Text) = "" Then
                MsgBox("Usted selecciono Positivo en el campo Signo Lasegue, debe ingresar un valor.", MsgBoxStyle.Information, "Signo Lasegue")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
                Tb_Lasegue.Focus()
                ValidarCasillas = False
                Exit Function
            End If
        End If

        If Rb_Superior.Checked = False And Rb_Excelente.Checked = False And Rb_Bueno.Checked = False And Rb_Promedio.Checked = False And Rb_Deficiente.Checked = False And Rb_Pobre.Checked = False And Rb_MuyPobre.Checked = False Then
            MsgBox("Debe seleccionar una opción en el campo Test Wells.", MsgBoxStyle.Information, "Test Wells")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Gb_TestWells.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Trim(Tb_ArtEscapulohumeral.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Art. Escapulohumeral.", MsgBoxStyle.Information, "Art. Escapulohumeral")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Tb_ArtEscapulohumeral.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Trim(Tb_ArtAcromioclavicular.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Art. Acromioclavicular.", MsgBoxStyle.Information, "Art. Acromioclavicular")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Tb_ArtAcromioclavicular.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Trim(Tb_ArtEscapulotorácica.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Art. Escapulotorácica.", MsgBoxStyle.Information, "Art. Escapulotorácica")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Tb_ArtEscapulotorácica.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Subdeltoidea.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Art. Subdeltoidea.", MsgBoxStyle.Information, "Art. Subdeltoidea")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Tb_Subdeltoidea.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_EjeAnteroposterior.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Eje Anteroposterior.", MsgBoxStyle.Information, "Eje Anteroposterior")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Tb_EjeAnteroposterior.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_EjeTransversal.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Eje Transversal.", MsgBoxStyle.Information, "Eje Transversal")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Tb_EjeTransversal.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_EjeLongitudinal.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Eje Longitudinal.", MsgBoxStyle.Information, "Eje Longitudinal")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Tb_EjeLongitudinal.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Circunduccion.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Circunducción.", MsgBoxStyle.Information, "Circunducción")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Tb_Circunduccion.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_AbduccionElevacion.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Abducción Elevación.", MsgBoxStyle.Information, "Abducción Elevación")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Tb_AbduccionElevacion.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Aduccion.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Aducción.", MsgBoxStyle.Information, "Aducción")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico2)
            Tb_Aduccion.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_RotacionExterna.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Rotación Externa.", MsgBoxStyle.Information, "Rotación Externa")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_RotacionExterna.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_FlexoExtension.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Flexo Extensión.", MsgBoxStyle.Information, "Flexo Extensión")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_FlexoExtension.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_HombroDerecho.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Hombro Derecho.", MsgBoxStyle.Information, "Hombro Derecho")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_HombroDerecho.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_HombroIzquierdo.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Hombro Izquierdo.", MsgBoxStyle.Information, "Hombro Izquierdo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_HombroIzquierdo.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_CodoDerecho.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Codo Derecho.", MsgBoxStyle.Information, "Codo Derecho")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_CodoDerecho.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_CodoIzquierdo.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Codo Izquierdo.", MsgBoxStyle.Information, "Codo Izquierdo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_CodoIzquierdo.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_MuñecaDerecha.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Muñeca Derecha.", MsgBoxStyle.Information, "Muñeca Derecha")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_MuñecaDerecha.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_MuñecaIzquierda.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Muñeca Izquierda.", MsgBoxStyle.Information, "Muñeca Izquierda")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_MuñecaIzquierda.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_ManoDerecha.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Derecha.", MsgBoxStyle.Information, "Mano Derecha")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_ManoDerecha.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_ManoIzquierda.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Izquierda.", MsgBoxStyle.Information, "Mano Izquierda")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_ManoIzquierda.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Trim(Tb_DedoDerecho1.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Derecha Dedo 1.", MsgBoxStyle.Information, "Mano Derecha Dedo 1")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_DedoDerecho1.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_DedoDerecho2.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Derecha Dedo 2.", MsgBoxStyle.Information, "Mano Derecha Dedo 2")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_DedoDerecho2.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_DedoDerecho3.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Derecha Dedo 3.", MsgBoxStyle.Information, "Mano Derecha Dedo 3")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_DedoDerecho3.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_DedoDerecho4.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Derecha Dedo 4.", MsgBoxStyle.Information, "Mano Derecha Dedo 4")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_DedoDerecho4.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_DedoDerecho5.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Derecha Dedo 5.", MsgBoxStyle.Information, "Mano Derecha Dedo 5")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico3)
            Tb_DedoDerecho5.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_DedoIzquierdo1.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Izquierda Dedo 1.", MsgBoxStyle.Information, "Mano Izquierda Dedo 1")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico4)
            Tb_DedoIzquierdo1.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_DedoIzquierdo2.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Izquierda Dedo 2.", MsgBoxStyle.Information, "Mano Izquierda Dedo 2")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico4)
            Tb_DedoIzquierdo2.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_DedoIzquierdo3.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Izquierda Dedo 3.", MsgBoxStyle.Information, "Mano Izquierda Dedo 3")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico4)
            Tb_DedoIzquierdo3.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_DedoIzquierdo4.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Izquierda Dedo 4.", MsgBoxStyle.Information, "Mano Izquierda Dedo 4")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico4)
            Tb_DedoIzquierdo4.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_DedoIzquierdo5.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Mano Izquierda Dedo 5.", MsgBoxStyle.Information, "Mano Izquierda Dedo 5")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico4)
            Tb_DedoIzquierdo5.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_ComentariosMiembrosSuperiores.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Comentarios De Las Evidencias.", MsgBoxStyle.Information, "Comentarios Evidencias")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico4)
            Tb_ComentariosMiembrosSuperiores.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_CaderasDerecha.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Cadera Derecha.", MsgBoxStyle.Information, "Cadera Derecha")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico4)
            Tb_CaderasDerecha.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_CaderasIzquierda.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Cadera Izquierda.", MsgBoxStyle.Information, "Cadera Izquierda")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico4)
            Tb_CaderasIzquierda.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_RodillaDerecha.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Rodilla Derecha.", MsgBoxStyle.Information, "Rodilla Derecha")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico4)
            Tb_RodillaDerecha.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_RodillaIzquierda.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Rodilla Izquierda.", MsgBoxStyle.Information, "Rodilla Izquierda")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico4)
            Tb_RodillaIzquierda.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_TobilloDerecho.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Tobillo Derecho.", MsgBoxStyle.Information, "Tobillo Derecho")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Tb_TobilloDerecho.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_TobilloIzquierdo.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Tobillo Izquierdo.", MsgBoxStyle.Information, "Tobillo Izquierdo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Tb_TobilloIzquierdo.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_PieDerecho.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Pie Derecho.", MsgBoxStyle.Information, "Pie Derecho")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Tb_PieDerecho.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_PieIzquierdo.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Pie Izquierdo.", MsgBoxStyle.Information, "Pie Izquierdo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Tb_PieIzquierdo.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_FaseApoyoPieDerecho.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Fase Apoyo Pie Derecho.", MsgBoxStyle.Information, "Fase Apoyo Pie Derecho")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Tb_FaseApoyoPieDerecho.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_FaseApoyoPieIzquierdo.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Fase Apoyo Pie Izquierdo.", MsgBoxStyle.Information, "Fase Apoyo Pie Izquierdo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Tb_FaseApoyoPieIzquierdo.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_FaseBalanceoPieDerecho.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Fase Balanceo Pie Derecho.", MsgBoxStyle.Information, "Fase Balanceo Pie Derecho")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Tb_FaseBalanceoPieDerecho.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_FaseBalanceoPieIzquierdo.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Fase Balanceo Pie Izquierdo.", MsgBoxStyle.Information, "Fase Balanceo Pie Izquierdo")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Tb_FaseBalanceoPieIzquierdo.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_Marcha.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Marcha.", MsgBoxStyle.Information, "Marcha")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Tb_Marcha.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Trim(Tb_ComentariosMiembrosInferiores.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Comentarios De Las Evidencias.", MsgBoxStyle.Information, "Comentarios De Las Evidencias")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Tb_ComentariosMiembrosInferiores.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Rb_AuditivaNo.Checked = False And Rb_AuditivaSi.Checked = False Then
            MsgBox("Debe seleccionar si hay o no Valoración Auditiva.", MsgBoxStyle.Information, "Valoración Auditiva")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Gb_Auditivo.Focus()
            ValidarCasillas = False
            Exit Function
        End If
        If Rb_AuditivaSi.Checked = True Then
            If Num_OI_8000.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 8000 - OI.", MsgBoxStyle.Information, "8000 - OI")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OI_8000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Num_OD_8000.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 8000 - OD.", MsgBoxStyle.Information, "8000 - OD")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OD_8000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_ViaComprometida8000.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una opción en el campo 8000 - Via Comprometida.", MsgBoxStyle.Information, "8000 - Via Comprometida")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Cb_ViaComprometida8000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Detalle8000.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo 8000 - Detalle.", MsgBoxStyle.Information, "8000 - Detalle")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Tb_Detalle8000.Focus()
                ValidarCasillas = False
                Exit Function
            End If

            If Num_OI_6000.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 6000 - OI.", MsgBoxStyle.Information, "6000 - OI")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OI_6000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Num_OD_6000.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 6000 - OD.", MsgBoxStyle.Information, "6000 - OD")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OD_6000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_ViaComprometida6000.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una opción en el campo 6000 - Via Comprometida.", MsgBoxStyle.Information, "6000 - Via Comprometida")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Cb_ViaComprometida6000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Detalle6000.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo 6000 - Detalle.", MsgBoxStyle.Information, "6000 - Detalle")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Tb_Detalle6000.Focus()
                ValidarCasillas = False
                Exit Function
            End If

            If Num_OI_3000.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 3000 - OI.", MsgBoxStyle.Information, "3000 - OI")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OI_3000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Num_OD_3000.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 3000 - OD.", MsgBoxStyle.Information, "3000 - OD")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OD_3000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_ViaComprometida3000.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una opción en el campo 3000 - Via Comprometida.", MsgBoxStyle.Information, "3000 - Via Comprometida")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Cb_ViaComprometida3000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Detalle3000.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo 3000 - Detalle.", MsgBoxStyle.Information, "3000 - Detalle")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Tb_Detalle3000.Focus()
                ValidarCasillas = False
                Exit Function
            End If

            If Num_OI_2000.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 2000 - OI.", MsgBoxStyle.Information, "2000 - OI")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OI_2000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Num_OD_2000.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 2000 - OD.", MsgBoxStyle.Information, "2000 - OD")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OD_2000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_ViaComprometida2000.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una opción en el campo 2000 - Via Comprometida.", MsgBoxStyle.Information, "2000 - Via Comprometida")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Cb_ViaComprometida2000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Detalle2000.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo 2000 - Detalle.", MsgBoxStyle.Information, "2000 - Detalle")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Tb_Detalle2000.Focus()
                ValidarCasillas = False
                Exit Function
            End If

            If Num_OI_1000.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 1000 - OI.", MsgBoxStyle.Information, "1000 - OI")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OI_1000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Num_OD_1000.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 1000 - OD.", MsgBoxStyle.Information, "1000 - OD")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OD_1000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_ViaComprometida1000.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una opción en el campo 1000 - Via Comprometida.", MsgBoxStyle.Information, "1000 - Via Comprometida")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Cb_ViaComprometida1000.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Detalle1000.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo 1000 - Detalle.", MsgBoxStyle.Information, "1000 - Detalle")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Tb_Detalle1000.Focus()
                ValidarCasillas = False
                Exit Function
            End If

            If Num_OI_05.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 0,5 - OI.", MsgBoxStyle.Information, "0,5 - OI")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OI_05.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Num_OD_05.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 0,5 - OD.", MsgBoxStyle.Information, "0,5 - OD")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OD_05.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_ViaComprometida05.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una opción en el campo 0,5 - Via Comprometida.", MsgBoxStyle.Information, "0,5 - Via Comprometida")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Cb_ViaComprometida05.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Detalle05.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo 0,5 - Detalle.", MsgBoxStyle.Information, "0,5 - Detalle")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Tb_Detalle05.Focus()
                ValidarCasillas = False
                Exit Function
            End If

            If Num_OI_025.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 0,25 - OI.", MsgBoxStyle.Information, "0,25 - OI")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OI_025.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Num_OD_025.Value = 0 Then
                MsgBox("Debe ingresar un valor diferente de 0 en el campo 0,25 - OD.", MsgBoxStyle.Information, "0,25 - OD")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Num_OD_025.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_ViaComprometida025.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una opción en el campo 0,25 - Via Comprometida.", MsgBoxStyle.Information, "0,25 - Via Comprometida")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Cb_ViaComprometida025.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Detalle025.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo 0,25 - Detalle.", MsgBoxStyle.Information, "0,25 - Detalle")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenAuditivo)
                Tb_Detalle025.Focus()
                ValidarCasillas = False
                Exit Function
            End If
        End If

        If Rb_SiExComplementario.Checked = False And Rb_NoExComplementario.Checked = False Then
            MsgBox("Debe seleccionar si hay o no Examenes Complementarios.", MsgBoxStyle.Information, "Examen Complementario")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenFisico5)
            Gb_ExamenesComplementarios.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Rb_SiExComplementario.Checked = True Then
            If Trim(Tb_LineaRoja.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Linea Roja.", MsgBoxStyle.Information, "Linea Roja")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_LineaRoja.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_LineaBlanca.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Linea Blanca.", MsgBoxStyle.Information, "Linea Blanca")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_LineaBlanca.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Plaquetas.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Plaquetas.", MsgBoxStyle.Information, "Plaquetas")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_Plaquetas.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_CuadroHematico.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Observaciones.", MsgBoxStyle.Information, "Observaciones")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_CuadroHematico.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Triglicerios.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Triglicerios.", MsgBoxStyle.Information, "Triglicerios")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_Triglicerios.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Colesterol.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Colesterol.", MsgBoxStyle.Information, "Colesterol")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_Colesterol.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_HDL.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo HDL.", MsgBoxStyle.Information, "HDL")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_HDL.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_LDL.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo LDL.", MsgBoxStyle.Information, "LDL")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_LDL.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Quimica.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Observaciones.", MsgBoxStyle.Information, "Observaciones")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_Quimica.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_Glicemia.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Glicemia.", MsgBoxStyle.Information, "Glicemia")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_Glicemia.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_GlicemiaConcepto.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Observaciones Glicemia.", MsgBoxStyle.Information, "Observaciones Glicemia")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_GlicemiaConcepto.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_FuncionRenal.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Función Renal.", MsgBoxStyle.Information, "Función Renal")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_FuncionRenal.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_FuncionRenalConcepto.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Observaciones Función Renal.", MsgBoxStyle.Information, "Observaciones Función Renal")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_GlicemiaConcepto.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_FuncionHepaticaAST.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo AST/GOT.", MsgBoxStyle.Information, "Función Hepática")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_FuncionHepaticaAST.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_FuncionHepaticaALT.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo ALT/GPT.", MsgBoxStyle.Information, "Función Hepática")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_FuncionHepaticaAST.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_FuncionHepaticaConcepto.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Observaciones Función Hepática.", MsgBoxStyle.Information, "Observaciones Función Hepática")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Tb_FuncionHepaticaConcepto.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_PONormal.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si el parcial de orina es normal o no.", MsgBoxStyle.Information, "Parcial Orina")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_PONormal.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_POBacterias.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si el parcial de orina presenta bacterias o no.", MsgBoxStyle.Information, "Parcial Orina")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_POBacterias.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_POProteinura.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si el parcial de orina presenta proteinura o no.", MsgBoxStyle.Information, "Parcial Orina")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_POProteinura.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_POGlucosuria.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si el parcial de orina presenta glucosuria o no.", MsgBoxStyle.Information, "Parcial Orina")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_POGlucosuria.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_POCalcio.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si el parcial de orina presenta calcio o no.", MsgBoxStyle.Information, "Parcial Orina")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_POCalcio.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_POSangre.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si el parcial de orina presenta sangre o no.", MsgBoxStyle.Information, "Parcial Orina")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_POSangre.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_POAlbumina.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si el parcial de orina presenta Albumina o no.", MsgBoxStyle.Information, "Parcial Orina")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_POAlbumina.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_POEritocitocis.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si el parcial de orina presenta eritocitocis o no.", MsgBoxStyle.Information, "Parcial Orina")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_POEritocitocis.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_POCreatinuria.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si el parcial de orina presenta creatinuria o no.", MsgBoxStyle.Information, "Parcial Orina")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_POCreatinuria.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_PsNegativo.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si es negativo o no en Psicofarmacos.", MsgBoxStyle.Information, "Psicofarmacos")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_PsNegativo.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_PsMarihuana.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si es positivo o no para marihuana.", MsgBoxStyle.Information, "Psicofarmacos")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_PsMarihuana.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_PsCocaina.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si es positivo o no para cocaina.", MsgBoxStyle.Information, "Psicofarmacos")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_PsCocaina.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_VNormal.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si la visiometria es normal o no.", MsgBoxStyle.Information, "Visiometria")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_VNormal.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_VCerca.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si la visiometria tiene alteraciones de vision de cerca o no.", MsgBoxStyle.Information, "Visiometria")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_VCerca.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_VLejos.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si la visiometria tiene alteraciones de vision de lejos o no.", MsgBoxStyle.Information, "Visiometria")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_VLejos.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_VMovilidad.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si la visiometria tiene alteraciones de movilidad o no.", MsgBoxStyle.Information, "Visiometria")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_VMovilidad.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_VParpados.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si la visiometria tiene alteraciones de parpados o no.", MsgBoxStyle.Information, "Visiometria")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_VParpados.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Ck_VConjuntiva.CheckState = CheckState.Indeterminate Then
                MsgBox("Debe seleccionar si la visiometria tiene alteraciones conjuntivas o no.", MsgBoxStyle.Information, "Visiometria")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Ck_VParpados.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            'If Trim(Tb_OtrasAlteracionesVisuales.Text) = "" Then
            '    MsgBox("Debe ingresar un valor en el campo Otras Alteraciones.", MsgBoxStyle.Information, "Visiometria")
            '    TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ImpresionDiagnostica)
            '    Tb_OtrasAlteracionesVisuales.Focus()
            '    ValidarCasillas = False
            '    Exit Function
            'End If
            If Cb_Espirometria.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una opción en el campo Espirometria.", MsgBoxStyle.Information, "Espirometria")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Cb_Espirometria.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_Audiometria.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una opción en el campo Audiometria.", MsgBoxStyle.Information, "Audiometria")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Cb_Audiometria.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Cb_EKG.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una opción en el campo EKG.", MsgBoxStyle.Information, "EKG")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ExamenComplementario)
                Cb_EKG.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_EKGConclusion.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Conclusion EKG.", MsgBoxStyle.Information, "EKG")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ImpresionDiagnostica)
                Tb_EKGConclusion.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Trim(Tb_ImagenesDiagnosticas.Text) = "" Then
                MsgBox("Debe ingresar un valor en el campo Imagenes Diagnosticas.", MsgBoxStyle.Information, "Imagenes Diagnosticas")
                TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ImpresionDiagnostica)
                Tb_ImagenesDiagnosticas.Focus()
                ValidarCasillas = False
                Exit Function
            End If
        End If

        If Trim(Tb_ComentariosFinales.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Comentarios De Las Evidencias.", MsgBoxStyle.Information, "Comentarios De Las Evidencias")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ImpresionDiagnostica)
            Tb_ComentariosFinales.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Trim(Tb_EstudiosFinales.Text) = "" Then
            MsgBox("Debe ingresar un valor en el campo Estudios.", MsgBoxStyle.Information, "Estudios")
            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ImpresionDiagnostica)
            Tb_EstudiosFinales.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        dtAntecedentes.AcceptChanges()
        For i As Integer = 0 To dtAntecedentes.Rows.Count - 1
            For j As Integer = 0 To dtAntecedentes.Columns.Count - 1
                If Trim(dtAntecedentes.Rows(i).Item(j).ToString) = "" Then
                    TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_AntecedentesPatologicos)
                    MsgBox("Debe ingresar un valor en todas las columnas de Antecedentes.", MsgBoxStyle.Information, "Antecedentes")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next

        dtEnfermedades.AcceptChanges()
        For i As Integer = 0 To dtEnfermedades.Rows.Count - 1
            For j As Integer = 0 To dtEnfermedades.Columns.Count - 2
                If Trim(dtEnfermedades.Rows(i).Item(j).ToString) = "" Then
                    TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_Antecedentes)
                    MsgBox("Debe ingresar un valor en todas las columnas de Enfermedades.", MsgBoxStyle.Information, "Enfermedades")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next

        dtHabitos.AcceptChanges()
        For i As Integer = 0 To dtHabitos.Rows.Count - 1
            For j As Integer = 0 To dtHabitos.Columns.Count - 1
                If Trim(dtHabitos.Rows(i).Item(j).ToString) = "" Then
                    TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_AntecedentesPatologicos)
                    MsgBox("Debe ingresar un valor en todas las columnas de Habitos.", MsgBoxStyle.Information, "Habitos")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next

        If Rb_ExamenIngreso.Checked = False Then
            dtHigiene.AcceptChanges()
            For i As Integer = 0 To dtHigiene.Rows.Count - 1
                For j As Integer = 0 To dtHigiene.Columns.Count - 1
                    If Trim(dtHigiene.Rows(i).Item(j).ToString) = "" Then
                        TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DescripcionCargo)
                        MsgBox("Debe ingresar un valor en todas las columnas de Higiene Industrial.", MsgBoxStyle.Information, "Higiene Industrial")
                        ValidarCasillas = False
                        Exit Function
                    End If
                Next
            Next
        End If

        If Rb_ExamenIngreso.Checked Then
            dtAntecedentesLaboral.AcceptChanges()
            For i As Integer = 0 To dtAntecedentesLaboral.Rows.Count - 1
                For j As Integer = 1 To dtAntecedentesLaboral.Columns.Count - 2
                    If j <> 2 And j <> 3 And j <> 6 And j <> 7 And j <> 8 Then
                        If Trim(dtAntecedentesLaboral.Rows(i).Item(j).ToString) = "" Then
                            TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DescripcionCargo)
                            MsgBox("Debe ingresar un valor en todas las columnas de Antecedentes Laborales.", MsgBoxStyle.Information, "Antecedentes Laborales")
                            ValidarCasillas = False
                            Exit Function
                        End If
                    End If
                Next
            Next
        End If

        dtImpresionDiagnostica.AcceptChanges()
        'QuitarFilasVaciasImpresionDiagnostica()
        For i As Integer = 0 To dtImpresionDiagnostica.Rows.Count - 1
            For j As Integer = 0 To dtImpresionDiagnostica.Columns.Count - 2
                If Trim(dtImpresionDiagnostica.Rows(i).Item(j).ToString) = "" Then
                    TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_ImpresionDiagnostica)
                    MsgBox("Debe ingresar un valor en todas las columnas de Impresion Diagnostica.", MsgBoxStyle.Information, "Impresion Diagnostica")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next

        dtSecuelas.AcceptChanges()
        For i As Integer = 0 To dtSecuelas.Rows.Count - 1
            For j As Integer = 0 To dtSecuelas.Columns.Count - 2
                If Trim(dtSecuelas.Rows(i).Item(j).ToString) = "" Then
                    TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_Antecedentes)
                    MsgBox("Debe ingresar un valor en todas las columnas de Accidentes.", MsgBoxStyle.Information, "Accidentes")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next

        dtTareas.AcceptChanges()
        For i As Integer = 0 To dtTareas.Rows.Count - 1
            For j As Integer = 0 To dtTareas.Columns.Count - 1
                If Trim(dtTareas.Rows(i).Item(j).ToString) = "" Then
                    TC_ExamenMedicoPeriodico.SelectedIndex = TC_ExamenMedicoPeriodico.TabPages.IndexOf(TP_DescripcionCargo)
                    MsgBox("Debe ingresar un valor en todas las columnas de Tareas.", MsgBoxStyle.Information, "Tareas")
                    ValidarCasillas = False
                    Exit Function
                End If
            Next
        Next

        Return True
    End Function

    Public Function GuardarExamenMedico() As Boolean
        If ValidarCasillas() = False Then
            GuardarExamenMedico = False
            Exit Function
        End If

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("dbo.GestionarExamenMedico")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@ACCION", TIPO)

        If Me.Rb_ExamenIngreso.Checked = True Then
            Comando.Parameters.AddWithValue("@TIPOEXAMEN", "I")
        Else
            If Me.Rb_ExamenPeriodico.Checked = True Then
                Comando.Parameters.AddWithValue("@TIPOEXAMEN", "P")
            Else
                Comando.Parameters.AddWithValue("@TIPOEXAMEN", "E")
            End If
        End If

        Comando.Parameters.AddWithValue("@IDEXAMENMEDICO", IDEXAMENMODIFICANDO)
        Comando.Parameters.AddWithValue("@FECHAEXAMENMEDICO", Today.Date)
        Comando.Parameters.AddWithValue("@IDPERSONA", Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@EDAD", Me.Tb_Edad.Text)
        If Me.Rb_Masculino.Checked = True Then
            Comando.Parameters.AddWithValue("@GENERO", "M")
        Else
            Comando.Parameters.AddWithValue("@GENERO", "F")
        End If

        Comando.Parameters.AddWithValue("@NIVELACADEMICO", Me.Cb_NivelAcademico.SelectedValue)
        Comando.Parameters.AddWithValue("@ESTADOCIVIL", Me.Cb_EstadoCivil.SelectedValue)
        Comando.Parameters.AddWithValue("@DOMINANCIA", Me.Cb_Dominancia.SelectedValue)
        Comando.Parameters.AddWithValue("@PROYECTO", Me.Cb_Proyecto.SelectedValue)
        Comando.Parameters.AddWithValue("@BASE", Me.Cb_Base.SelectedValue)
        Comando.Parameters.AddWithValue("@DEPENDENCIA", Me.Cb_Dependencia.SelectedValue)
        Comando.Parameters.AddWithValue("@CARGO", Me.Cb_Cargo.SelectedValue)
        Comando.Parameters.AddWithValue("@TIPOCARGO", Me.Cb_TipoCargo.SelectedValue)
        Dim Riesgo As String = ""
        If Me.Cb_Biomecanico.Checked = True Then
            Riesgo = "S"
        Else
            Riesgo = "N"
        End If
        If Me.Cb_Psicosocial.Checked = True Then
            Riesgo = Riesgo + "S"
        Else
            Riesgo = Riesgo + "N"
        End If
        If Me.Cb_Biológico.Checked = True Then
            Riesgo = Riesgo + "S"
        Else
            Riesgo = Riesgo + "N"
        End If
        If Me.Cb_Seguridad.Checked = True Then
            Riesgo = Riesgo + "S"
        Else
            Riesgo = Riesgo + "N"
        End If
        If Me.Cb_Fisico.Checked = True Then
            Riesgo = Riesgo + "S"
        Else
            Riesgo = Riesgo + "N"
        End If
        If Me.Cb_Quimico.Checked = True Then
            Riesgo = Riesgo + "S"
        Else
            Riesgo = Riesgo + "N"
        End If
        If Me.Cb_Natural.Checked = True Then
            Riesgo = Riesgo + "S"
        Else
            Riesgo = Riesgo + "N"
        End If
        If Me.Cb_Locativo.Checked = True Then
            Riesgo = Riesgo + "S"
        Else
            Riesgo = Riesgo + "N"
        End If

        Comando.Parameters.AddWithValue("@RIESGO", Riesgo)

        If Me.Rb_ExamenIngreso.Checked = True Then
            Comando.Parameters.AddWithValue("@FECHAINGRESOEMPRESA", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHAINGRESOEMPRESA", Me.Dtp_FechaIngreso.Value.Date)
        End If

        If Trim(Me.Cu_CiudadContrato.Tx_Codigo.Text) = "" Then
            Comando.Parameters.AddWithValue("@CIUDADCONTRATO", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@CIUDADCONTRATO", Me.Cu_CiudadContrato.Tx_Codigo.Text)
        End If

        Comando.Parameters.AddWithValue("@TIEMPOCARGOAÑOS", Me.Num_CargoAños.Value)
        Comando.Parameters.AddWithValue("@TIEMPOCARGOMESES", Me.Num_CargoMeses.Value)
        Comando.Parameters.AddWithValue("@JORNADA", Me.Cb_Jornada.SelectedValue)
        Comando.Parameters.AddWithValue("@TURNOS", Me.Num_Turnos.Value)
        Comando.Parameters.AddWithValue("@GRUPOSANGUINEO", Me.Cb_GrupoSanguineo.SelectedValue)
        Comando.Parameters.AddWithValue("@AFP", Me.Cb_AFP.SelectedValue)
        Comando.Parameters.AddWithValue("@EPS", Me.Cb_EPS.SelectedValue)
        Comando.Parameters.AddWithValue("@REVISIONPORSISTEMA", Me.Tb_RevisionSistemas.Text)
        Comando.Parameters.AddWithValue("@TENSIONSISTOLICA", Me.Num_TaSist.Value)
        Comando.Parameters.AddWithValue("@TENSIONDIASTOLICA", Me.Num_TaDiast.Value)
        Comando.Parameters.AddWithValue("@FRECUENCIACARDIACA", Me.Num_FC.Value)
        Comando.Parameters.AddWithValue("@FRECUENCIARESPIRATORIA", Me.Num_FR.Value)
        Comando.Parameters.AddWithValue("@SO2", Me.Num_SO2.Value)
        Comando.Parameters.AddWithValue("@PESO", Convert.ToDecimal(Me.Tb_Peso.Text.ToString))
        Comando.Parameters.AddWithValue("@TALLA", Convert.ToDecimal(Me.Tb_Talla.Text.ToString))
        Comando.Parameters.AddWithValue("@PERIMETROABDOMEN", Me.Num_PerimetroAbdomen.Value)
        Comando.Parameters.AddWithValue("@EVIDENCIASCLINICASSIGNOSVITALES", Me.Tb_EvidenciasClinicas.Text)
        Comando.Parameters.AddWithValue("@SIMETRIA", Me.Tb_Simetria.Text)
        Comando.Parameters.AddWithValue("@CURVATURA", Me.Tb_Curvatura.Text)
        Comando.Parameters.AddWithValue("@DOLOR", Me.Tb_Dolor.Text)
        Comando.Parameters.AddWithValue("@ESPASMO", Me.Tb_Espasmo.Text)
        Comando.Parameters.AddWithValue("@FLEXION", Me.Tb_Flexion.Text)
        Comando.Parameters.AddWithValue("@EXTENSION", Me.Tb_Extension.Text)
        Comando.Parameters.AddWithValue("@FLEXIONLATERAL", Me.Tb_FlexionLateral.Text)
        Comando.Parameters.AddWithValue("@ROTACION", Me.Tb_Rotacion.Text)
        If Me.Rb_Mayor5cm.Checked Then
            Comando.Parameters.AddWithValue("@TESTSCHOBER", "S")
        Else
            Comando.Parameters.AddWithValue("@TESTSCHOBER", "N")
        End If

        If Me.Rb_Positivo.Checked Then
            Comando.Parameters.AddWithValue("@SIGNOLASEGUE", Me.Tb_Lasegue.Text)
        Else
            Comando.Parameters.AddWithValue("@SIGNOLASEGUE", DBNull.Value)
        End If

        If Me.Rb_Superior.Checked Then
            Comando.Parameters.AddWithValue("@TESTWELLS", "1")
        Else
            If Me.Rb_Excelente.Checked Then
                Comando.Parameters.AddWithValue("@TESTWELLS", "2")
            Else
                If Me.Rb_Bueno.Checked Then
                    Comando.Parameters.AddWithValue("@TESTWELLS", "3")
                Else
                    If Me.Rb_Promedio.Checked Then
                        Comando.Parameters.AddWithValue("@TESTWELLS", "4")
                    Else
                        If Me.Rb_Deficiente.Checked Then
                            Comando.Parameters.AddWithValue("@TESTWELLS", "5")
                        Else
                            If Me.Rb_Pobre.Checked Then
                                Comando.Parameters.AddWithValue("@TESTWELLS", "6")
                            Else
                                If Me.Rb_MuyPobre.Checked Then
                                    Comando.Parameters.AddWithValue("@TESTWELLS", "7")
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Comando.Parameters.AddWithValue("@ARTESCAPULOHUMERAL", Me.Tb_ArtEscapulohumeral.Text)
        Comando.Parameters.AddWithValue("@ARTACROMIOCLAVICULAR", Me.Tb_ArtAcromioclavicular.Text)
        Comando.Parameters.AddWithValue("@ARTESCAPULOTORACICA", Me.Tb_ArtEscapulotorácica.Text)
        Comando.Parameters.AddWithValue("@ARTSUBDELTOIDEA", Me.Tb_Subdeltoidea.Text)
        Comando.Parameters.AddWithValue("@EJEANTEROPOSTERIOR", Me.Tb_EjeAnteroposterior.Text)
        Comando.Parameters.AddWithValue("@EJETRANSVERSAL", Me.Tb_EjeTransversal.Text)
        Comando.Parameters.AddWithValue("@EJELONGITUDINAL", Me.Tb_EjeLongitudinal.Text)
        Comando.Parameters.AddWithValue("@CIRCUNDUCCION", Me.Tb_Circunduccion.Text)
        Comando.Parameters.AddWithValue("@ABDUCCIONELEVACION", Me.Tb_AbduccionElevacion.Text)
        Comando.Parameters.AddWithValue("@ADUCCION", Me.Tb_Aduccion.Text)
        Comando.Parameters.AddWithValue("@ROTACIONEXTERNA", Me.Tb_RotacionExterna.Text)
        Comando.Parameters.AddWithValue("@FLEXOEXTENSION", Me.Tb_FlexoExtension.Text)
        Comando.Parameters.AddWithValue("@HOMBRODERECHO", Me.Tb_HombroDerecho.Text)
        Comando.Parameters.AddWithValue("@HOMBROIZQUIERDO", Me.Tb_HombroIzquierdo.Text)
        Comando.Parameters.AddWithValue("@CODODERECHO", Me.Tb_CodoDerecho.Text)
        Comando.Parameters.AddWithValue("@CODOIZQUIERDO", Me.Tb_CodoIzquierdo.Text)
        Comando.Parameters.AddWithValue("@MUNECADERECHA", Me.Tb_MuñecaDerecha.Text)
        Comando.Parameters.AddWithValue("@MUNECAIZQUIERDA", Me.Tb_MuñecaIzquierda.Text)
        Comando.Parameters.AddWithValue("@MANODERECHA", Me.Tb_ManoDerecha.Text)
        Comando.Parameters.AddWithValue("@MANOIZQUIERDA", Me.Tb_ManoIzquierda.Text)
        Comando.Parameters.AddWithValue("@DEDODERECHO1", Me.Tb_DedoDerecho1.Text)
        Comando.Parameters.AddWithValue("@DEDODERECHO2", Me.Tb_DedoDerecho2.Text)
        Comando.Parameters.AddWithValue("@DEDODERECHO3", Me.Tb_DedoDerecho3.Text)
        Comando.Parameters.AddWithValue("@DEDODERECHO4", Me.Tb_DedoDerecho4.Text)
        Comando.Parameters.AddWithValue("@DEDODERECHO5", Me.Tb_DedoDerecho5.Text)
        Comando.Parameters.AddWithValue("@DEDOIZQUIERDO1", Me.Tb_DedoIzquierdo1.Text)
        Comando.Parameters.AddWithValue("@DEDOIZQUIERDO2", Me.Tb_DedoIzquierdo2.Text)
        Comando.Parameters.AddWithValue("@DEDOIZQUIERDO3", Me.Tb_DedoIzquierdo3.Text)
        Comando.Parameters.AddWithValue("@DEDOIZQUIERDO4", Me.Tb_DedoIzquierdo4.Text)
        Comando.Parameters.AddWithValue("@DEDOIZQUIERDO5", Me.Tb_DedoIzquierdo5.Text)
        Comando.Parameters.AddWithValue("@COMENTARIOSEVIDENCIASMIEMBROSSUPERIORES", Me.Tb_ComentariosMiembrosSuperiores.Text)
        Comando.Parameters.AddWithValue("@CADERADERECHA", Me.Tb_CaderasDerecha.Text)
        Comando.Parameters.AddWithValue("@CADERAIZQUIERDA", Me.Tb_CaderasIzquierda.Text)
        Comando.Parameters.AddWithValue("@RODILLADERECHA", Me.Tb_RodillaDerecha.Text)
        Comando.Parameters.AddWithValue("@RODILLAIZQUIERDA", Me.Tb_RodillaIzquierda.Text)
        Comando.Parameters.AddWithValue("@TOBILLODERECHO", Me.Tb_TobilloDerecho.Text)
        Comando.Parameters.AddWithValue("@TOBILLOIZQUIERDO", Me.Tb_TobilloIzquierdo.Text)
        Comando.Parameters.AddWithValue("@PIEDERECHO", Me.Tb_PieDerecho.Text)
        Comando.Parameters.AddWithValue("@PIEIZQUIERDO", Me.Tb_PieIzquierdo.Text)
        Comando.Parameters.AddWithValue("@FASEAPOYOPIEDERECHO", Me.Tb_FaseApoyoPieDerecho.Text)
        Comando.Parameters.AddWithValue("@FASEAPOYOPIEIZQUIERDO", Me.Tb_FaseApoyoPieIzquierdo.Text)
        Comando.Parameters.AddWithValue("@FASEBALANCEOPIEDERECHO", Me.Tb_FaseBalanceoPieDerecho.Text)
        Comando.Parameters.AddWithValue("@FASEBALANCEOPIEIZQUIERDO", Me.Tb_FaseBalanceoPieIzquierdo.Text)
        Comando.Parameters.AddWithValue("@MARCHA", Me.Tb_Marcha.Text)

        If Me.Rb_SiExComplementario.Checked Then
            Dim ValorSinFormato As String = ""
            ValorSinFormato = Me.Tb_LineaRoja.Text
            ValorSinFormato = ValorSinFormato.Replace(".", "")
            Comando.Parameters.AddWithValue("@LINEAROJA", Convert.ToInt64(ValorSinFormato))
            ValorSinFormato = Me.Tb_LineaBlanca.Text
            ValorSinFormato = ValorSinFormato.Replace(".", "")
            Comando.Parameters.AddWithValue("@LINEABLANCA", Convert.ToInt64(ValorSinFormato))
            ValorSinFormato = Me.Tb_Plaquetas.Text
            ValorSinFormato = ValorSinFormato.Replace(".", "")
            Comando.Parameters.AddWithValue("@PLAQUETAS", Convert.ToInt64(ValorSinFormato))
            Comando.Parameters.AddWithValue("@OBSERVACIONESCUADROHEMATICO", Me.Tb_CuadroHematico.Text)
            Comando.Parameters.AddWithValue("@TRIGLICERIOS", Convert.ToDecimal(Me.Tb_Triglicerios.Text))
            Comando.Parameters.AddWithValue("@COLESTEROL", Convert.ToDecimal(Me.Tb_Colesterol.Text))
            Comando.Parameters.AddWithValue("@HDL", Convert.ToDecimal(Me.Tb_HDL.Text))
            Comando.Parameters.AddWithValue("@LDL", Convert.ToDecimal(Me.Tb_LDL.Text))
            Comando.Parameters.AddWithValue("@OBSERVACIONESQUIMICA", Me.Tb_Quimica.Text)
            Comando.Parameters.AddWithValue("@GLICEMIA", Convert.ToDecimal(Me.Tb_Glicemia.Text))
            Comando.Parameters.AddWithValue("@ESTADOGLICEMIA", Me.Tb_GlicemiaConcepto.Text)
            Comando.Parameters.AddWithValue("@FUNCIONRENAL", Convert.ToDecimal(Me.Tb_FuncionRenal.Text))
            Comando.Parameters.AddWithValue("@ESTADOFUNCIONRENAL", Me.Tb_FuncionRenalConcepto.Text)
            Comando.Parameters.AddWithValue("@FUNCIONHEPATICAAST", Convert.ToDecimal(Me.Tb_FuncionHepaticaAST.Text))
            Comando.Parameters.AddWithValue("@FUNCIONHEPATICAALT", Convert.ToDecimal(Me.Tb_FuncionHepaticaALT.Text))
            Comando.Parameters.AddWithValue("@ESTADOFUNCIONHEPATICA", Me.Tb_FuncionHepaticaConcepto.Text)

            Dim ParcialOrina As String = ""
            If Me.Ck_PONormal.Checked = True Then
                ParcialOrina += "S"
            Else
                ParcialOrina += "N"
            End If
            If Me.Ck_POBacterias.Checked = True Then
                ParcialOrina = ParcialOrina + "S"
            Else
                ParcialOrina = ParcialOrina + "N"
            End If
            If Me.Ck_POProteinura.Checked = True Then
                ParcialOrina = ParcialOrina + "S"
            Else
                ParcialOrina = ParcialOrina + "N"
            End If
            If Me.Ck_POGlucosuria.Checked = True Then
                ParcialOrina += "S"
            Else
                ParcialOrina += "N"
            End If
            If Me.Ck_POCalcio.Checked = True Then
                ParcialOrina = ParcialOrina + "S"
            Else
                ParcialOrina = ParcialOrina + "N"
            End If
            If Me.Ck_POSangre.Checked = True Then
                ParcialOrina = ParcialOrina + "S"
            Else
                ParcialOrina = ParcialOrina + "N"
            End If
            If Me.Ck_POAlbumina.Checked = True Then
                ParcialOrina = ParcialOrina + "S"
            Else
                ParcialOrina = ParcialOrina + "N"
            End If
            If Me.Ck_POEritocitocis.Checked = True Then
                ParcialOrina = ParcialOrina + "S"
            Else
                ParcialOrina = ParcialOrina + "N"
            End If
            If Me.Ck_POCreatinuria.Checked = True Then
                ParcialOrina = ParcialOrina + "S"
            Else
                ParcialOrina = ParcialOrina + "N"
            End If
            Comando.Parameters.AddWithValue("@PARCIALORINA", ParcialOrina)

            Dim Psicofarmacos As String = ""
            If Me.Ck_PsNegativo.Checked = True Then
                Psicofarmacos += "S"
            Else
                Psicofarmacos += "N"
            End If
            If Me.Ck_PsMarihuana.Checked = True Then
                Psicofarmacos = Psicofarmacos + "S"
            Else
                Psicofarmacos = Psicofarmacos + "N"
            End If
            If Me.Ck_PsCocaina.Checked = True Then
                Psicofarmacos = Psicofarmacos + "S"
            Else
                Psicofarmacos = Psicofarmacos + "N"
            End If
            Comando.Parameters.AddWithValue("@PSICOFARMACOS", Psicofarmacos)

            Dim Visiometria As String = ""
            If Me.Ck_VNormal.Checked = True Then
                Visiometria += "S"
            Else
                Visiometria += "N"
            End If
            If Me.Ck_VCerca.Checked = True Then
                Visiometria = Visiometria + "S"
            Else
                Visiometria = Visiometria + "N"
            End If
            If Me.Ck_VLejos.Checked = True Then
                Visiometria = Visiometria + "S"
            Else
                Visiometria = Visiometria + "N"
            End If
            If Me.Ck_VMovilidad.Checked = True Then
                Visiometria += "S"
            Else
                Visiometria += "N"
            End If
            If Me.Ck_VParpados.Checked = True Then
                Visiometria = Visiometria + "S"
            Else
                Visiometria = Visiometria + "N"
            End If
            If Me.Ck_VConjuntiva.Checked = True Then
                Visiometria = Visiometria + "S"
            Else
                Visiometria = Visiometria + "N"
            End If
            Comando.Parameters.AddWithValue("@VISIOMETRIA", Visiometria)
            Comando.Parameters.AddWithValue("@OTRASALTERACIONESVISUALES", Me.Tb_OtrasAlteracionesVisuales.Text)
            Comando.Parameters.AddWithValue("@ESPIROMETRIA", Me.Cb_Espirometria.SelectedValue)
            Comando.Parameters.AddWithValue("@AUDIOMETRIA", Me.Cb_Audiometria.SelectedValue)
            Comando.Parameters.AddWithValue("@EKG", Me.Cb_EKG.SelectedValue)
            Comando.Parameters.AddWithValue("@EKGCONCLUSION", Me.Tb_EKGConclusion.Text)
            Comando.Parameters.AddWithValue("@IMAGENESDIAGNOSTICAS", Me.Tb_ImagenesDiagnosticas.Text)
        Else
            Comando.Parameters.AddWithValue("@LINEAROJA", DBNull.Value)
            Comando.Parameters.AddWithValue("@LINEABLANCA", DBNull.Value)
            Comando.Parameters.AddWithValue("@PLAQUETAS", DBNull.Value)
            Comando.Parameters.AddWithValue("@OBSERVACIONESCUADROHEMATICO", DBNull.Value)
            Comando.Parameters.AddWithValue("@TRIGLICERIOS", DBNull.Value)
            Comando.Parameters.AddWithValue("@COLESTEROL", DBNull.Value)
            Comando.Parameters.AddWithValue("@HDL", DBNull.Value)
            Comando.Parameters.AddWithValue("@LDL", DBNull.Value)
            Comando.Parameters.AddWithValue("@OBSERVACIONESQUIMICA", DBNull.Value)
            Comando.Parameters.AddWithValue("@GLICEMIA", DBNull.Value)
            Comando.Parameters.AddWithValue("@ESTADOGLICEMIA", DBNull.Value)
            Comando.Parameters.AddWithValue("@FUNCIONRENAL", DBNull.Value)
            Comando.Parameters.AddWithValue("@ESTADOFUNCIONRENAL", DBNull.Value)
            Comando.Parameters.AddWithValue("@FUNCIONHEPATICAAST", DBNull.Value)
            Comando.Parameters.AddWithValue("@FUNCIONHEPATICAALT", DBNull.Value)
            Comando.Parameters.AddWithValue("@ESTADOFUNCIONHEPATICA", DBNull.Value)
            Comando.Parameters.AddWithValue("@PARCIALORINA", DBNull.Value)
            Comando.Parameters.AddWithValue("@PSICOFARMACOS", DBNull.Value)
            Comando.Parameters.AddWithValue("@VISIOMETRIA", DBNull.Value)
            Comando.Parameters.AddWithValue("@OTRASALTERACIONESVISUALES", DBNull.Value)
            Comando.Parameters.AddWithValue("@ESPIROMETRIA", DBNull.Value)
            Comando.Parameters.AddWithValue("@AUDIOMETRIA", DBNull.Value)
            Comando.Parameters.AddWithValue("@EKG", DBNull.Value)
            Comando.Parameters.AddWithValue("@EKGCONCLUSION", DBNull.Value)
            Comando.Parameters.AddWithValue("@IMAGENESDIAGNOSTICAS", DBNull.Value)
        End If



        Comando.Parameters.AddWithValue("@COMENTARIOSEVIDENCIASMIEMBROSINFERIORES", Me.Tb_ComentariosMiembrosInferiores.Text)
        Comando.Parameters.AddWithValue("@COMENTARIOSEVIDENCIASFINALES", Me.Tb_ComentariosFinales.Text)
        If Trim(Me.Tb_EstudiosFinales.Text) <> "" Then
            Comando.Parameters.AddWithValue("@ESTUDIOSMIEMBROSFINALES", Me.Tb_EstudiosFinales.Text)
        Else
            Comando.Parameters.AddWithValue("@ESTUDIOSMIEMBROSFINALES", DBNull.Value)
        End If
        Comando.Parameters.AddWithValue("@PROGRAMASVIGILANCIA", DBNull.Value)
        Comando.Parameters.AddWithValue("@CONCEPTO", DBNull.Value)
        Comando.Parameters.AddWithValue("@RECOMENDADOCARGO", DBNull.Value)
        Comando.Parameters.AddWithValue("@APTOTIPOTRABAJO", DBNull.Value)
        Comando.Parameters.AddWithValue("@RECOMENDACIONES", DBNull.Value)
        Comando.Parameters.AddWithValue("@LABORATORIOSREALIZADOS", DBNull.Value)
        Comando.Parameters.AddWithValue("@OTROSLABORATORIOS", DBNull.Value)
        Comando.Parameters.AddWithValue("@IMPRESO", "N")
        Comando.Parameters.AddWithValue("@PERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@PERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)

        If dtAntecedentes IsNot Nothing Then
            If dtAntecedentes.Rows.Count > 0 Then
                QuitarFilasVaciasAntecedentes()
                Comando.Parameters.AddWithValue("@AntecedentesSiNo", "S")
                Comando.Parameters.AddWithValue("@TableAntecedentes", dtAntecedentes)
            Else
                Comando.Parameters.AddWithValue("@AntecedentesSiNo", "N")
            End If
        Else
            Comando.Parameters.AddWithValue("@AntecedentesSiNo", "N")
        End If

        Dim dtEnfermedadesSecuelas As New DataTable
        dtEnfermedadesSecuelas.Columns.Add("IDENFERMEDAD")
        dtEnfermedadesSecuelas.Columns.Add("ORIGEN")
        dtEnfermedadesSecuelas.Columns.Add("SECUELA")
        dtEnfermedadesSecuelas.Columns.Add("TIPO")

        If dtEnfermedades IsNot Nothing Then
            If dtEnfermedades.Rows.Count > 0 Then
                Dim Fila As DataRow
                For i As Integer = 0 To dtEnfermedades.Rows.Count - 1
                    dtEnfermedades.Rows(i).Item("TIPO") = "E"
                    Fila = dtEnfermedadesSecuelas.NewRow
                    Fila("IDENFERMEDAD") = dtEnfermedades.Rows(i).Item("IDENFERMEDAD")
                    Fila("ORIGEN") = dtEnfermedades.Rows(i).Item("ORIGEN")
                    Fila("SECUELA") = dtEnfermedades.Rows(i).Item("SECUELA")
                    Fila("TIPO") = dtEnfermedades.Rows(i).Item("TIPO")
                    dtEnfermedadesSecuelas.Rows.Add(Fila)
                Next
            End If
        End If

        If dtHabitos IsNot Nothing Then
            If dtHabitos.Rows.Count > 0 Then
                QuitarFilasVaciasHabitos()
                Comando.Parameters.AddWithValue("@HabitosSiNo", "S")
                Comando.Parameters.AddWithValue("@TableHabitos", dtHabitos)
            Else
                Comando.Parameters.AddWithValue("@HabitosSiNo", "N")
            End If
        Else
            Comando.Parameters.AddWithValue("@HabitosSiNo", "N")
        End If

        If dtHigiene IsNot Nothing Then
            If dtHigiene.Rows.Count > 0 Then
                QuitarFilasVaciasHigiene()
                Comando.Parameters.AddWithValue("@HigieneSiNo", "S")
                Comando.Parameters.AddWithValue("@TableHigiene", dtHigiene)
            Else
                Comando.Parameters.AddWithValue("@HigieneSiNo", "N")
            End If
        Else
            Comando.Parameters.AddWithValue("@HigieneSiNo", "N")
        End If

        If dtAntecedentesLaboral IsNot Nothing Then
            If dtAntecedentesLaboral.Rows.Count > 0 Then
                EnumerarFilas()
                Comando.Parameters.AddWithValue("@HistorialAntecedentesLaboralesSiNo", "S")
                Comando.Parameters.AddWithValue("@TableAntecedentesLaborales", dtAntecedentesLaboral)
                Comando.Parameters.AddWithValue("@TableRiesgosAntecedentes", dtRiesgosAntecedentesLaborales)
            Else
                Comando.Parameters.AddWithValue("@HistorialAntecedentesLaboralesSiNo", "N")
            End If
        Else
            Comando.Parameters.AddWithValue("@HistorialAntecedentesLaboralesSiNo", "N")
        End If

        dtImpresionDiagnostica.AcceptChanges()
        If dtImpresionDiagnostica IsNot Nothing Then
            If dtImpresionDiagnostica.Rows.Count > 0 Then
                Dim dtImpresionDiagnosticaFinal As New DataTable
                dtImpresionDiagnosticaFinal.Columns.Add("IDIMPRESIONDIAGNOSTICA")
                dtImpresionDiagnosticaFinal.Columns.Add("IDENFERMEDAD")
                dtImpresionDiagnosticaFinal.Columns.Add("DESCRIPCIONENFERMEDAD")

                For i As Integer = 0 To dtImpresionDiagnostica.Rows.Count - 1
                    If Trim(dtImpresionDiagnostica.Rows(i).Item("IDIMPRESIONDIAGNOSTICA").ToString) = "" Then
                        dtImpresionDiagnostica.Rows(i).Item("IDIMPRESIONDIAGNOSTICA") = -1
                    End If

                    Dim FilaImpDiag As DataRow
                    FilaImpDiag = dtImpresionDiagnosticaFinal.NewRow

                    FilaImpDiag.Item("IDIMPRESIONDIAGNOSTICA") = dtImpresionDiagnostica.Rows(i).Item("IDIMPRESIONDIAGNOSTICA")
                    FilaImpDiag.Item("IDENFERMEDAD") = dtImpresionDiagnostica.Rows(i).Item("IDENFERMEDAD")
                    FilaImpDiag.Item("DESCRIPCIONENFERMEDAD") = dtImpresionDiagnostica.Rows(i).Item("DESCRIPCIONENFERMEDAD")

                    dtImpresionDiagnosticaFinal.Rows.Add(FilaImpDiag)
                Next

                dtImpresionDiagnosticaFinal.AcceptChanges()
                Comando.Parameters.AddWithValue("@ImpresionDiagnosticaSiNo", "S")
                Comando.Parameters.AddWithValue("@TableImpresionDiagnostica", dtImpresionDiagnosticaFinal)
            Else
                Comando.Parameters.AddWithValue("@ImpresionDiagnosticaSiNo", "N")
            End If
        Else
            Comando.Parameters.AddWithValue("@ImpresionDiagnosticaSiNo", "N")
        End If

        If dtSecuelas IsNot Nothing Then
            If dtSecuelas.Rows.Count > 0 Then
                'dtSecuelas.Columns.Remove("CODIGOENFERMEDAD")
                'dtSecuelas.Columns.Remove("NOMBREENFERMEDAD")
                Dim Fila As DataRow
                For i As Integer = 0 To dtSecuelas.Rows.Count - 1
                    dtSecuelas.Rows(i).Item("TIPO") = "A"
                    Fila = dtEnfermedadesSecuelas.NewRow
                    Fila("IDENFERMEDAD") = dtSecuelas.Rows(i).Item("IDENFERMEDAD")
                    Fila("ORIGEN") = dtSecuelas.Rows(i).Item("ORIGEN")
                    Fila("SECUELA") = dtSecuelas.Rows(i).Item("SECUELA")
                    Fila("TIPO") = dtSecuelas.Rows(i).Item("TIPO")
                    dtEnfermedadesSecuelas.Rows.Add(Fila)
                Next
            End If
        End If

        If dtEnfermedadesSecuelas IsNot Nothing Then
            If dtEnfermedadesSecuelas.Rows.Count > 0 Then
                Comando.Parameters.AddWithValue("@EnfermedadesSecuelasSiNo", "S")
                Comando.Parameters.AddWithValue("@TableEnfermedadesSecuelas", dtEnfermedadesSecuelas)
            Else
                Comando.Parameters.AddWithValue("@EnfermedadesSecuelasSiNo", "N")
            End If
        End If

        If dtTareas IsNot Nothing Then
            If dtTareas.Rows.Count > 0 Then
                QuitarFilasTareas()
                Comando.Parameters.AddWithValue("@TareaSiNo", "S")
                Comando.Parameters.AddWithValue("@TableTarea", dtTareas)
            Else
                Comando.Parameters.AddWithValue("@TareaSiNo", "N")
            End If
        Else
            Comando.Parameters.AddWithValue("@TareaSiNo", "N")
        End If

        Cu_Vacuna1.dtVacunaPersona.AcceptChanges()
        If Cu_Vacuna1.dtVacunaPersona IsNot Nothing Then
            If Cu_Vacuna1.dtVacunaPersona.Rows.Count > 0 Then
                Dim dtVacunasFinal As New DataTable
                dtVacunasFinal = Cu_Vacuna1.dtVacunaPersona.Clone
                dtVacunasFinal.Columns.Remove("NOMPERSONAREGISTRO")
                dtVacunasFinal.Columns.Remove("IDPADRE")

                For i As Integer = 0 To Cu_Vacuna1.dtVacunaPersona.Rows.Count - 1
                    Dim FilaVacuna As DataRow
                    FilaVacuna = dtVacunasFinal.NewRow
                    FilaVacuna.Item("IDVACUNAXPERSONA") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("IDVACUNAXPERSONA")
                    FilaVacuna.Item("IDPERSONA") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("IDPERSONA")
                    FilaVacuna.Item("IDVACUNA") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("IDVACUNA")
                    FilaVacuna.Item("NOMBREVACUNA") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("NOMBREVACUNA")
                    FilaVacuna.Item("FECHAVACUNA") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("FECHAVACUNA")
                    FilaVacuna.Item("MODULOCREACION") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("MODULOCREACION")
                    FilaVacuna.Item("IDPERSONAREGISTRO") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("IDPERSONAREGISTRO")
                    FilaVacuna.Item("FECHAREGISTRO") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("FECHAREGISTRO")
                    FilaVacuna.Item("ACTIVA") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("ACTIVA")
                    FilaVacuna.Item("OBSERVACIONINACTIVACION") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("OBSERVACIONINACTIVACION")
                    FilaVacuna.Item("IDPERSONAINACTIVA") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("IDPERSONAINACTIVA")
                    FilaVacuna.Item("FECHAINACTIVACION") = Cu_Vacuna1.dtVacunaPersona.Rows(i).Item("FECHAINACTIVACION")

                    dtVacunasFinal.Rows.Add(FilaVacuna)
                Next

                For i As Integer = 0 To dtVacunasFinal.Rows.Count - 1
                    If dtVacunasFinal.Rows(i).Item("MODULOCREACION").ToString = "CONTRATO" Or dtVacunasFinal.Rows(i).Item("MODULOCREACION").ToString = "C" Then
                        dtVacunasFinal.Rows(i).Item("MODULOCREACION") = "C"
                    Else
                        dtVacunasFinal.Rows(i).Item("MODULOCREACION") = "H"
                    End If
                Next
                dtVacunasFinal.AcceptChanges()
                Comando.Parameters.AddWithValue("@TableVacunasPersona", dtVacunasFinal)
            End If
        End If

        If Rb_AuditivaSi.Checked Then
            dtValoracionAuditiva.Rows.Clear()

            Dim row As DataRow
            row = dtValoracionAuditiva.NewRow
            row(0) = "8000"
            row(1) = Me.Num_OI_8000.Value
            row(2) = Me.Num_OD_8000.Value
            row(3) = Me.Cb_ViaComprometida8000.SelectedValue
            row(4) = Me.Tb_Detalle8000.Text

            Dim row1 As DataRow
            row1 = dtValoracionAuditiva.NewRow
            row1(0) = "6000"
            row1(1) = Me.Num_OI_6000.Value
            row1(2) = Me.Num_OD_6000.Value
            row1(3) = Me.Cb_ViaComprometida6000.SelectedValue
            row1(4) = Me.Tb_Detalle6000.Text()

            Dim row2 As DataRow
            row2 = dtValoracionAuditiva.NewRow
            row2(0) = "3000"
            row2(1) = Me.Num_OI_3000.Value
            row2(2) = Me.Num_OD_3000.Value
            row2(3) = Me.Cb_ViaComprometida3000.SelectedValue
            row2(4) = Me.Tb_Detalle3000.Text()

            Dim row3 As DataRow
            row3 = dtValoracionAuditiva.NewRow
            row3(0) = "2000"
            row3(1) = Me.Num_OI_2000.Value
            row3(2) = Me.Num_OD_2000.Value
            row3(3) = Me.Cb_ViaComprometida2000.SelectedValue
            row3(4) = Me.Tb_Detalle2000.Text()

            Dim row4 As DataRow
            row4 = dtValoracionAuditiva.NewRow
            row4(0) = "1000"
            row4(1) = Me.Num_OI_1000.Value
            row4(2) = Me.Num_OD_1000.Value
            row4(3) = Me.Cb_ViaComprometida1000.SelectedValue
            row4(4) = Me.Tb_Detalle1000.Text()

            Dim row5 As DataRow
            row5 = dtValoracionAuditiva.NewRow
            row5(0) = "0,5"
            row5(1) = Me.Num_OI_05.Value
            row5(2) = Me.Num_OD_05.Value
            row5(3) = Me.Cb_ViaComprometida05.SelectedValue
            row5(4) = Me.Tb_Detalle05.Text()

            Dim row6 As DataRow
            row6 = dtValoracionAuditiva.NewRow
            row6(0) = "0,25"
            row6(1) = Me.Num_OI_025.Value
            row6(2) = Me.Num_OD_025.Value()
            row6(3) = Me.Cb_ViaComprometida025.SelectedValue
            row6(4) = Me.Tb_Detalle025.Text()

            dtValoracionAuditiva.Rows.Add(row)
            dtValoracionAuditiva.Rows.Add(row1)
            dtValoracionAuditiva.Rows.Add(row2)
            dtValoracionAuditiva.Rows.Add(row3)
            dtValoracionAuditiva.Rows.Add(row4)
            dtValoracionAuditiva.Rows.Add(row5)
            dtValoracionAuditiva.Rows.Add(row6)
            dtValoracionAuditiva.AcceptChanges()
            Comando.Parameters.AddWithValue("@ValoracionAuditivaSiNo", "S")
            Comando.Parameters.AddWithValue("@TableValoracionAuditiva", dtValoracionAuditiva)
        Else
            Comando.Parameters.AddWithValue("@ValoracionAuditivaSiNo", "N")
        End If

        conexion.Open()
        Comando.Connection = conexion
        Try
            Comando.ExecuteNonQuery()
            conexion.Close()
            guardado = True
            GuardarExamenMedico = True
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.ToString)
            guardado = False
            GuardarExamenMedico = False
        End Try

    End Function

    Private Sub EnumerarFilas()
        For i As Integer = 0 To dtAntecedentesLaboral.Rows.Count - 1
            Dim NroItemActualizar As Integer = dtAntecedentesLaboral.Rows(i).Item(0)
            Dim NroItem = i + 1
            dtAntecedentesLaboral.Rows(i).Item(0) = NroItem 'i + 1
            Dim drActualizar() As DataRow = dtRiesgosAntecedentesLaborales.Select("IDITEMANTECEDENTELABORAL = " + NroItemActualizar.ToString)
            If drActualizar.Length > 0 Then
                For Each FilaActualizar In drActualizar
                    FilaActualizar.Item(0) = NroItem 'i + 1
                Next
            End If
        Next
    End Sub

    Private Sub Cb_Base_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Base.SelectedIndexChanged
        ActualizarDependencias()
    End Sub

    Private Sub ActualizarDependencias()
        Try
            Dim cn As New SqlConnection(My.Settings.CadenaConexión)
            Dim cmd As String = "SELECT IDDEPENDENCIA, LTRIM(RTRIM(NOMBREDEPENDENCIA)) AS NOMBREDEPENDENCIA FROM SC_DEPENDENCIA WHERE ACTIVO = 'S' AND IDBASESISCONTROL=" & Cb_Base.SelectedValue.ToString & ""
            '" & Me.ComboBox1.Text & "'"
            Dim da As New SqlDataAdapter(cmd, cn)
            Dim ds As New DataSet
            da.Fill(ds)
            With Me.Cb_Dependencia
                Me.Cb_Dependencia.DataSource = ds.Tables(0)
                Me.Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
                Me.Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
                Me.Cb_Dependencia.SelectedIndex = -1
            End With
        Catch ex As Exception
        End Try
    End Sub

    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Me.Cu_BuscarPersonaExamenMedico.Name
                Try
                    filas = Cu_BuscarPersonaExamenMedico.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaExamenMedico.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue = fila("IDPERSONA")
                        LlenarCampos(fila("IDPERSONA"))
                        CargarVacunas(fila("IDPERSONA"))
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaExamenMedico.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub

    Public Sub Focus_Edad() Handles Tb_Edad.GotFocus
        If Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedIndex <> -1 Then
            CalcularEdadBD(Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue)
        End If
    End Sub

    Public Sub CalcularImc() Handles Tb_Peso.LostFocus, Tb_Talla.LostFocus
        If Trim(Tb_Peso.Text) <> "" And Trim(Tb_Talla.Text) <> "" Then
            Tb_IMC.Text = Format(Convert.ToDecimal(Tb_Peso.Text) / (Convert.ToDecimal(Tb_Talla.Text) * Convert.ToDecimal(Tb_Talla.Text)), "0.00")
        End If
    End Sub

    Public Sub CalcularEdadBD(ByVal IdPersona As String)
        Dim Cadena_Consulta As String
        Cadena_Consulta = "select dbo.RetornaEdad(FECHANACIMIENTO) from PERSONA where IDPERSONA = @IDPERSONA"
        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        If IdPersona IsNot Nothing Then
            Consulta.Parameters.AddWithValue("@IDPERSONA", IdPersona)
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = conexion
            Consulta.Connection.Open()
            Dim resultado As String = Consulta.ExecuteScalar.ToString
            Tb_Edad.Text = resultado.ToString
            Consulta.Connection.Close()
        End If

    End Sub



    Private Sub Rb_AuditivaSi_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_AuditivaSi.CheckedChanged
        If Rb_AuditivaSi.Checked Then
            Dim Pagina As Integer = Me.TC_ExamenMedicoPeriodico.TabPages.IndexOf(Me.TP_ExamenFisico5)
            Me.TC_ExamenMedicoPeriodico.TabPages.Insert(Pagina + 1, Me.TP_ExamenAuditivo)
        Else
            Me.TC_ExamenMedicoPeriodico.Controls.Remove(Me.TP_ExamenAuditivo)
        End If
    End Sub

    Private Sub Rb_AuditivaNo_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_AuditivaNo.CheckedChanged
        If Rb_AuditivaNo.Checked Then
            Me.TC_ExamenMedicoPeriodico.Controls.Remove(Me.TP_ExamenAuditivo)
        End If
    End Sub

    Private Sub Rb_SiExComplementario_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_SiExComplementario.CheckedChanged
        If Rb_SiExComplementario.Checked Then
            Dim Pagina As Integer = Me.TC_ExamenMedicoPeriodico.TabPages.IndexOf(Me.TP_ImpresionDiagnostica)
            Me.TC_ExamenMedicoPeriodico.TabPages.Insert(Pagina, Me.TP_ExamenComplementario)
        Else
            Me.TC_ExamenMedicoPeriodico.Controls.Remove(Me.TP_ExamenComplementario)
        End If
    End Sub

    Private Sub Rb_NoExComplementario_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_NoExComplementario.CheckedChanged
        If Rb_NoExComplementario.Checked Then
            Me.TC_ExamenMedicoPeriodico.Controls.Remove(Me.TP_ExamenComplementario)
        End If
    End Sub

    Private Sub Caja_Texto_KeyPress_Enteros(sender As Object, e As KeyPressEventArgs) _
        Handles Tb_Edad.KeyPress, Tb_LineaRoja.KeyPress, Tb_LineaBlanca.KeyPress, Tb_Plaquetas.KeyPress

        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Public Sub LostFocus_Enteros(sender As Object, e As EventArgs) _
        Handles Tb_Edad.LostFocus, Tb_LineaRoja.LostFocus, Tb_LineaBlanca.LostFocus, Tb_Plaquetas.LostFocus
        FormatearEnteros(sender)
    End Sub


    Public Sub FormatearEnteros(Caja As TextBox)
        Dim Texto As String = Caja.Text
        Texto = Texto.Replace(".", "")
        Dim i = Texto.Length - 3
        While i > 0
            Texto = Texto.Insert(i, ".")
            i = i - 3
        End While
        Caja.Text = Texto
        'Return Caja
    End Sub

    Private Sub Caja_Texto_KeyPress_Decimales(sender As Object, e As KeyPressEventArgs) _
    Handles Tb_Peso.KeyPress, Tb_Talla.KeyPress, Tb_Plaquetas.KeyPress, Tb_Triglicerios.KeyPress, Tb_Colesterol.KeyPress, Tb_HDL.KeyPress, Tb_LDL.KeyPress, Tb_Glicemia.KeyPress, Tb_FuncionRenal.KeyPress, Tb_FuncionHepaticaAST.KeyPress, Tb_FuncionHepaticaALT.KeyPress

        If InStr(1, ",0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub
    Private Sub FormatearTexto(sender As Object, e As EventArgs) Handles Tb_Plaquetas.LostFocus, Tb_Triglicerios.LostFocus, Tb_Colesterol.LostFocus, Tb_HDL.LostFocus, Tb_LDL.LostFocus, Tb_Glicemia.LostFocus, Tb_FuncionRenal.LostFocus, Tb_FuncionHepaticaAST.LostFocus, Tb_FuncionHepaticaALT.LostFocus
        Try
            Dim Caja As TextBox = sender
            Dim Cadena As String = ""
            Cadena = Replace(Cadena, " ", "")
            Cadena = Replace(Cadena, ".", "")

            Dim pos As Integer = Cadena.LastIndexOf(",")
            If pos = Cadena.Length - 3 Then
                'tiene ",00"
                Cadena = Mid(Cadena, 1, Cadena.Length - 3)
            Else
                If pos = Cadena.Length - 2 Then
                    'tiene ",0"
                    Cadena = Mid(Cadena, 1, Cadena.Length - 2)
                End If
            End If
            Cadena = Replace(Cadena, ",", "")
            If IsNumeric(Cadena) = False Then
                Caja.BackColor = Drawing.Color.MintCream
            Else
                Caja.Text = Replace(Format(Cadena, "Currency"), ",00", "")
                Caja.BackColor = Drawing.Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgv_Habitos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_Habitos.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPressDgv_Habitos
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dText_KeyPressDgv_Habitos(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_Habitos.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 2, 5
                e.KeyChar = Char.ToUpper(e.KeyChar)
                Select Case e.KeyChar
                    Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", Convert.ToChar(8)
                        e.Handled = False
                    Case Else
                        e.Handled = True
                End Select
        End Select
    End Sub

    Private Sub Dgv_ImpresionDiagnosticaFinal_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_ImpresionDiagnosticaFinal.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPress_Dgv_ImpresionDiagnosticaFinal
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dText_KeyPress_Dgv_ImpresionDiagnosticaFinal(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_ImpresionDiagnosticaFinal.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 0
                Select Case e.KeyChar
                    Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", Convert.ToChar(8)
                        e.Handled = False
                    Case Else
                        e.Handled = True
                End Select
        End Select
    End Sub

    Private Sub Dgv_ImpresionDiagnosticaFinal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv_ImpresionDiagnosticaFinal.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim fr_Enfermedades As FormulariosClasesBase.Fr_BuscarEnfermedades = New FormulariosClasesBase.Fr_BuscarEnfermedades
                fr_Enfermedades.dtEnfermedades = dsCargar.Tables(32)
                fr_Enfermedades.dtGrupos = dsCargar.Tables(33)
                fr_Enfermedades.CargarEnfermedades()
                fr_Enfermedades.ComportamientoPredeterminado()
                fr_Enfermedades.ShowDialog()
                If fr_Enfermedades.Resultado Then
                    If VerificarEnfermedadesDGV(fr_Enfermedades.IdEnfermedad, "IDENFERMEDAD", dtImpresionDiagnostica, Dgv_ImpresionDiagnosticaFinal) Then
                        Dim filasenfermedad As DataRow()
                        filasenfermedad = dsCargar.Tables(32).Select("IDENFERMEDAD = " + fr_Enfermedades.IdEnfermedad.ToString)
                        If filasenfermedad.Length > 0 Then
                            Dim fila As DataRow
                            Dim filaenfermedad As DataRow
                            filaenfermedad = filasenfermedad(0)
                            fila = dtImpresionDiagnostica.NewRow
                            fila("IDIMPRESIONDIAGNOSTICA") = -1
                            fila("IDENFERMEDAD") = filaenfermedad("IDENFERMEDAD").ToString
                            fila("CODIGOENFERMEDAD") = filaenfermedad("CODIGOENFERMEDAD").ToString
                            fila("NOMBREENFERMEDAD") = filaenfermedad("NOMBREENFERMEDAD").ToString
                            fila("DESCRIPCIONENFERMEDAD") = DBNull.Value
                            If Me.Dgv_ImpresionDiagnosticaFinal.CurrentRow.Index = dtImpresionDiagnostica.Rows.Count Then
                                dtImpresionDiagnostica.Rows.Add(fila)
                            Else
                                dtImpresionDiagnostica.Rows(Me.Dgv_ImpresionDiagnosticaFinal.CurrentRow.Index).Item("IDIMPRESIONDIAGNOSTICA") = fila("IDIMPRESIONDIAGNOSTICA")
                                dtImpresionDiagnostica.Rows(Me.Dgv_ImpresionDiagnosticaFinal.CurrentRow.Index).Item("IDENFERMEDAD") = fila("IDENFERMEDAD")
                                dtImpresionDiagnostica.Rows(Me.Dgv_ImpresionDiagnosticaFinal.CurrentRow.Index).Item("CODIGOENFERMEDAD") = fila("CODIGOENFERMEDAD")
                                dtImpresionDiagnostica.Rows(Me.Dgv_ImpresionDiagnosticaFinal.CurrentRow.Index).Item("NOMBREENFERMEDAD") = fila("NOMBREENFERMEDAD")
                                dtImpresionDiagnostica.Rows(Me.Dgv_ImpresionDiagnosticaFinal.CurrentRow.Index).Item("DESCRIPCIONENFERMEDAD") = fila("DESCRIPCIONENFERMEDAD")
                            End If
                            Try
                                Me.Dgv_ImpresionDiagnosticaFinal.Rows.RemoveAt(Me.Dgv_ImpresionDiagnosticaFinal.CurrentRow.Index)
                            Catch
                            End Try
                        Else
                            MsgBox("No se encontró una enfermedad con ese código", MsgBoxStyle.Exclamation, "Enfermedad no encontrada")
                            Try
                                Me.Dgv_ImpresionDiagnosticaFinal.Rows.RemoveAt(Me.Dgv_ImpresionDiagnosticaFinal.CurrentRow.Index)
                            Catch
                            End Try
                        End If

                    Else
                        MsgBox("Ya se encuentra esa enfermedad registrada", MsgBoxStyle.Exclamation, "Registro existente")
                    End If
                End If
        End Select
    End Sub

    Private Sub Dgv_ImpresionDiagnosticaFinal_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Dgv_ImpresionDiagnosticaFinal.CellEndEdit
        Dim Celda As DataGridViewCell = Me.Dgv_ImpresionDiagnosticaFinal.CurrentCell()
        Dim AgregarExamen As Boolean = False
        Dim Columna As String = ""
        Select Case Celda.ColumnIndex
            Case 0
                AgregarExamen = True
                Columna = "IDENFERMEDAD"
            Case 1
                AgregarExamen = True
                Columna = "CODIGOENFERMEDAD"
        End Select

        If AgregarExamen Then
            If IsDBNull(Me.Dgv_ImpresionDiagnosticaFinal.Item(e.ColumnIndex, e.RowIndex).Value) Then
                Me.Dgv_ImpresionDiagnosticaFinal.Item(e.ColumnIndex, e.RowIndex).Value = 0
                Exit Sub
            End If
            If Trim(Me.Dgv_ImpresionDiagnosticaFinal.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
                Try
                    Me.Dgv_ImpresionDiagnosticaFinal.Rows.RemoveAt(e.RowIndex)
                Catch
                End Try
                Exit Sub
            End If

            Dim IDEXAMEN As String = ""
            If Not IsDBNull(Me.Dgv_ImpresionDiagnosticaFinal.Item(e.ColumnIndex, e.RowIndex).Value) Then
                IDEXAMEN = Me.Dgv_ImpresionDiagnosticaFinal.Item(e.ColumnIndex, e.RowIndex).Value
            End If

            If VerificarEnfermedadesDGV(IDEXAMEN, Columna, dtImpresionDiagnostica, Dgv_ImpresionDiagnosticaFinal) And Trim(IDEXAMEN) <> "" Then
                Dim filasenfermedad As DataRow()
                Dim Busqueda As String = ""
                If Columna = "CODIGOENFERMEDAD" Then
                    Busqueda = "'" + Me.Dgv_ImpresionDiagnosticaFinal.CurrentCell.Value.ToString.ToString + "'"
                Else
                    Busqueda = Me.Dgv_ImpresionDiagnosticaFinal.CurrentCell.Value.ToString
                End If
                filasenfermedad = dsCargar.Tables(32).Select(Columna + " = " + Busqueda)
                If filasenfermedad.Length > 0 Then
                    Dim fila As DataRow
                    Dim filaenfermedad As DataRow
                    filaenfermedad = filasenfermedad(0)
                    fila = dtImpresionDiagnostica.NewRow
                    fila("IDIMPRESIONDIAGNOSTICA") = -1
                    fila("IDENFERMEDAD") = filaenfermedad("IDENFERMEDAD").ToString
                    fila("CODIGOENFERMEDAD") = filaenfermedad("CODIGOENFERMEDAD").ToString
                    fila("NOMBREENFERMEDAD") = filaenfermedad("NOMBREENFERMEDAD").ToString
                    fila("DESCRIPCIONENFERMEDAD") = DBNull.Value

                    If dtImpresionDiagnostica.Rows.Count = Me.Dgv_ImpresionDiagnosticaFinal.CurrentCell.RowIndex Then
                        Try
                            Me.Dgv_ImpresionDiagnosticaFinal.Rows.RemoveAt(e.RowIndex)
                        Catch
                        End Try
                        dtImpresionDiagnostica.Rows.Add(fila)
                    Else
                        dtImpresionDiagnostica.Rows(e.RowIndex).Item("IDIMPRESIONDIAGNOSTICA") = fila("IDIMPRESIONDIAGNOSTICA")
                        dtImpresionDiagnostica.Rows(e.RowIndex).Item("IDENFERMEDAD") = fila("IDENFERMEDAD")
                        dtImpresionDiagnostica.Rows(e.RowIndex).Item("CODIGOENFERMEDAD") = fila("CODIGOENFERMEDAD")
                        dtImpresionDiagnostica.Rows(e.RowIndex).Item("NOMBREENFERMEDAD") = fila("NOMBREENFERMEDAD")
                        dtImpresionDiagnostica.Rows(e.RowIndex).Item("DESCRIPCIONENFERMEDAD") = DBNull.Value
                    End If
                Else
                    MsgBox("No se encontró una enfermedad con ese código", MsgBoxStyle.Exclamation, "Enfermedad no encontrada")
                    Try
                        Me.Dgv_ImpresionDiagnosticaFinal.Rows.RemoveAt(e.RowIndex)
                    Catch
                    End Try
                End If
            Else
                MsgBox("Ya se encuentra esa enfermedad registrada", MsgBoxStyle.Exclamation, "Enfermedad no encontrada")
                Try
                    Me.Dgv_ImpresionDiagnosticaFinal.Rows.RemoveAt(e.RowIndex)
                Catch
                End Try
            End If
        End If
    End Sub

    Private Sub Dgv_Enfermedades_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_Enfermedades.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPress_Dgv_Enfermedades
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dText_KeyPress_Dgv_Enfermedades(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_Enfermedades.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 0
                Select Case e.KeyChar
                    Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", Convert.ToChar(8)
                        e.Handled = False
                    Case Else
                        e.Handled = True
                End Select
        End Select
    End Sub

    Private Sub Dgv_Enfermedades_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv_Enfermedades.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim fr_Enfermedades As FormulariosClasesBase.Fr_BuscarEnfermedades = New FormulariosClasesBase.Fr_BuscarEnfermedades
                fr_Enfermedades.dtEnfermedades = dsCargar.Tables(32)
                fr_Enfermedades.dtGrupos = dsCargar.Tables(33)
                fr_Enfermedades.CargarEnfermedades()
                fr_Enfermedades.ComportamientoPredeterminado()
                fr_Enfermedades.ShowDialog()
                If fr_Enfermedades.Resultado Then
                    If VerificarEnfermedadesDGV(fr_Enfermedades.IdEnfermedad, "IDENFERMEDAD", dtEnfermedades, Dgv_Enfermedades) Then
                        Dim filasenfermedad As DataRow()
                        filasenfermedad = dsCargar.Tables(32).Select("IDENFERMEDAD = " + fr_Enfermedades.IdEnfermedad.ToString)
                        If filasenfermedad.Length > 0 Then
                            Dim fila As DataRow
                            Dim filaenfermedad As DataRow
                            filaenfermedad = filasenfermedad(0)
                            fila = dtEnfermedades.NewRow
                            fila("IDENFERMEDAD") = filaenfermedad("IDENFERMEDAD").ToString
                            fila("CODIGOENFERMEDAD") = filaenfermedad("CODIGOENFERMEDAD").ToString
                            fila("NOMBREENFERMEDAD") = filaenfermedad("NOMBREENFERMEDAD").ToString
                            fila("ORIGEN") = DBNull.Value
                            fila("SECUELA") = DBNull.Value
                            If Me.Dgv_Enfermedades.CurrentRow.Index = dtEnfermedades.Rows.Count Then
                                dtEnfermedades.Rows.Add(fila)
                            Else
                                dtEnfermedades.Rows(Me.Dgv_Enfermedades.CurrentRow.Index).Item("IDENFERMEDAD") = fila("IDENFERMEDAD")
                                dtEnfermedades.Rows(Me.Dgv_Enfermedades.CurrentRow.Index).Item("CODIGOENFERMEDAD") = fila("CODIGOENFERMEDAD")
                                dtEnfermedades.Rows(Me.Dgv_Enfermedades.CurrentRow.Index).Item("NOMBREENFERMEDAD") = fila("NOMBREENFERMEDAD")
                                dtEnfermedades.Rows(Me.Dgv_Enfermedades.CurrentRow.Index).Item("ORIGEN") = fila("ORIGEN")
                                dtEnfermedades.Rows(Me.Dgv_Enfermedades.CurrentRow.Index).Item("SECUELA") = fila("SECUELA")
                            End If
                        Else
                            MsgBox("No se encontró una enfermedad con ese código", MsgBoxStyle.Exclamation, "Enfermedad no encontrada")
                            Try
                                Me.Dgv_Enfermedades.Rows.RemoveAt(Me.Dgv_Enfermedades.CurrentRow.Index)
                            Catch
                            End Try
                        End If

                    Else
                        MsgBox("Ya se encuentra esa enfermedad registrada", MsgBoxStyle.Exclamation, "Registro existente")
                    End If
                End If
        End Select
    End Sub

    Private Sub Dgv_Enfermedades_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Dgv_Enfermedades.CellEndEdit
        Dim Celda As DataGridViewCell = Me.Dgv_Enfermedades.CurrentCell()
        Dim AgregarExamen As Boolean = False
        Dim Columna As String = ""
        Select Case Celda.ColumnIndex
            Case 0
                AgregarExamen = True
                Columna = "IDENFERMEDAD"
            Case 1
                AgregarExamen = True
                Columna = "CODIGOENFERMEDAD"
        End Select

        If AgregarExamen Then
            If IsDBNull(Me.Dgv_Enfermedades.Item(e.ColumnIndex, e.RowIndex).Value) Then
                Me.Dgv_Enfermedades.Item(e.ColumnIndex, e.RowIndex).Value = 0
                Exit Sub
            End If
            If Trim(Me.Dgv_Enfermedades.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
                Try
                    Me.Dgv_Enfermedades.Rows.RemoveAt(e.RowIndex)
                Catch
                End Try
                Exit Sub
            End If

            Dim IDEXAMEN As String = ""
            If Not IsDBNull(Me.Dgv_Enfermedades.Item(e.ColumnIndex, e.RowIndex).Value) Then
                IDEXAMEN = Me.Dgv_Enfermedades.Item(e.ColumnIndex, e.RowIndex).Value
            End If

            If VerificarEnfermedadesDGV(IDEXAMEN, Columna, dtEnfermedades, Dgv_Enfermedades) And Trim(IDEXAMEN) <> "" Then
                Dim filasenfermedad As DataRow()
                Dim Busqueda As String = ""
                If Columna = "CODIGOENFERMEDAD" Then
                    Busqueda = "'" + Me.Dgv_Enfermedades.CurrentCell.Value.ToString.ToString + "'"
                Else
                    Busqueda = Me.Dgv_Enfermedades.CurrentCell.Value.ToString
                End If
                filasenfermedad = dsCargar.Tables(32).Select(Columna + " = " + Busqueda)
                If filasenfermedad.Length > 0 Then
                    Dim fila As DataRow
                    Dim filaenfermedad As DataRow
                    filaenfermedad = filasenfermedad(0)
                    fila = dtEnfermedades.NewRow
                    fila("IDENFERMEDAD") = filaenfermedad("IDENFERMEDAD").ToString
                    fila("CODIGOENFERMEDAD") = filaenfermedad("CODIGOENFERMEDAD").ToString
                    fila("NOMBREENFERMEDAD") = filaenfermedad("NOMBREENFERMEDAD").ToString
                    fila("ORIGEN") = DBNull.Value
                    fila("SECUELA") = DBNull.Value

                    If dtEnfermedades.Rows.Count = Me.Dgv_Enfermedades.CurrentCell.RowIndex Then
                        Try
                            Me.Dgv_Enfermedades.Rows.RemoveAt(e.RowIndex)
                        Catch
                        End Try
                        dtEnfermedades.Rows.Add(fila)
                    Else
                        dtEnfermedades.Rows(e.RowIndex).Item("IDENFERMEDAD") = fila("IDENFERMEDAD")
                        dtEnfermedades.Rows(e.RowIndex).Item("CODIGOENFERMEDAD") = fila("CODIGOENFERMEDAD")
                        dtEnfermedades.Rows(e.RowIndex).Item("NOMBREENFERMEDAD") = fila("NOMBREENFERMEDAD")
                        dtEnfermedades.Rows(e.RowIndex).Item("ORIGEN") = fila("ORIGEN")
                        dtEnfermedades.Rows(e.RowIndex).Item("SECUELA") = DBNull.Value
                    End If
                Else
                    MsgBox("No se encontró una enfermedad con ese código", MsgBoxStyle.Exclamation, "Enfermedad no encontrada")
                    Try
                        Me.Dgv_Enfermedades.Rows.RemoveAt(e.RowIndex)
                    Catch
                    End Try
                End If
            Else
                MsgBox("Ya se encuentra esa enfermedad registrada", MsgBoxStyle.Exclamation, "Enfermedad no encontrada")
                Try
                    Me.Dgv_Enfermedades.Rows.RemoveAt(e.RowIndex)
                Catch
                End Try
            End If
        End If
    End Sub

    Private Sub Dgv_Accidente_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_Accidente.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPress_Dgv_Accidente
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dText_KeyPress_Dgv_Accidente(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_Accidente.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 0
                Select Case e.KeyChar
                    Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", Convert.ToChar(8)
                        e.Handled = False
                    Case Else
                        e.Handled = True
                End Select
        End Select
    End Sub

    Private Sub Dgv_Accidente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv_Accidente.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Dim fr_Enfermedades As FormulariosClasesBase.Fr_BuscarEnfermedades = New FormulariosClasesBase.Fr_BuscarEnfermedades
                fr_Enfermedades.dtEnfermedades = dsCargar.Tables(32)
                fr_Enfermedades.dtGrupos = dsCargar.Tables(33)
                fr_Enfermedades.CargarEnfermedades()
                fr_Enfermedades.ComportamientoPredeterminado()
                fr_Enfermedades.ShowDialog()
                If fr_Enfermedades.Resultado Then
                    If VerificarEnfermedadesDGV(fr_Enfermedades.IdEnfermedad, "IDENFERMEDAD", dtSecuelas, Dgv_Accidente) Then
                        Dim filasenfermedad As DataRow()
                        filasenfermedad = dsCargar.Tables(32).Select("IDENFERMEDAD = " + fr_Enfermedades.IdEnfermedad.ToString)
                        If filasenfermedad.Length > 0 Then
                            Dim fila As DataRow
                            Dim filaenfermedad As DataRow
                            filaenfermedad = filasenfermedad(0)
                            fila = dtSecuelas.NewRow
                            fila("IDENFERMEDAD") = filaenfermedad("IDENFERMEDAD").ToString
                            fila("CODIGOENFERMEDAD") = filaenfermedad("CODIGOENFERMEDAD").ToString
                            fila("NOMBREENFERMEDAD") = filaenfermedad("NOMBREENFERMEDAD").ToString
                            fila("ORIGEN") = DBNull.Value
                            fila("SECUELA") = DBNull.Value
                            If Me.Dgv_Accidente.CurrentRow.Index = dtSecuelas.Rows.Count Then
                                dtSecuelas.Rows.Add(fila)
                            Else
                                dtSecuelas.Rows(Me.Dgv_Accidente.CurrentRow.Index).Item("IDENFERMEDAD") = fila("IDENFERMEDAD")
                                dtSecuelas.Rows(Me.Dgv_Accidente.CurrentRow.Index).Item("CODIGOENFERMEDAD") = fila("CODIGOENFERMEDAD")
                                dtSecuelas.Rows(Me.Dgv_Accidente.CurrentRow.Index).Item("NOMBREENFERMEDAD") = fila("NOMBREENFERMEDAD")
                                dtSecuelas.Rows(Me.Dgv_Accidente.CurrentRow.Index).Item("ORIGEN") = fila("ORIGEN")
                                dtSecuelas.Rows(Me.Dgv_Accidente.CurrentRow.Index).Item("SECUELA") = fila("SECUELA")
                            End If
                        Else
                            MsgBox("No se encontró una enfermedad con ese código", MsgBoxStyle.Exclamation, "Enfermedad no encontrada")
                            Try
                                Me.Dgv_Accidente.Rows.RemoveAt(Me.Dgv_Accidente.CurrentRow.Index)
                            Catch
                            End Try
                        End If

                    Else
                        MsgBox("Ya se encuentra esa enfermedad registrada", MsgBoxStyle.Exclamation, "Registro existente")
                    End If
                End If
        End Select
    End Sub

    Private Sub Dgv_Accidente_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Dgv_Accidente.CellEndEdit
        Dim Celda As DataGridViewCell = Me.Dgv_Accidente.CurrentCell()
        Dim AgregarExamen As Boolean = False
        Dim Columna As String = ""
        Select Case Celda.ColumnIndex
            Case 0
                AgregarExamen = True
                Columna = "IDENFERMEDAD"
            Case 1
                AgregarExamen = True
                Columna = "CODIGOENFERMEDAD"
        End Select

        If AgregarExamen Then
            If IsDBNull(Me.Dgv_Accidente.Item(e.ColumnIndex, e.RowIndex).Value) Then
                Me.Dgv_Accidente.Item(e.ColumnIndex, e.RowIndex).Value = 0
                Exit Sub
            End If
            If Trim(Me.Dgv_Accidente.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
                Try
                    Me.Dgv_Accidente.Rows.RemoveAt(e.RowIndex)
                Catch
                End Try
                Exit Sub
            End If

            Dim IDEXAMEN As String = ""
            If Not IsDBNull(Me.Dgv_Accidente.Item(e.ColumnIndex, e.RowIndex).Value) Then
                IDEXAMEN = Me.Dgv_Accidente.Item(e.ColumnIndex, e.RowIndex).Value
            End If

            If VerificarEnfermedadesDGV(IDEXAMEN, Columna, dtSecuelas, Dgv_Accidente) And Trim(IDEXAMEN) <> "" Then
                Dim filasenfermedad As DataRow()
                Dim Busqueda As String = ""
                If Columna = "CODIGOENFERMEDAD" Then
                    Busqueda = "'" + Me.Dgv_Accidente.CurrentCell.Value.ToString.ToString + "'"
                Else
                    Busqueda = Me.Dgv_Accidente.CurrentCell.Value.ToString
                End If
                filasenfermedad = dsCargar.Tables(32).Select(Columna + " = " + Busqueda)
                If filasenfermedad.Length > 0 Then
                    Dim fila As DataRow
                    Dim filaenfermedad As DataRow
                    filaenfermedad = filasenfermedad(0)
                    fila = dtSecuelas.NewRow
                    fila("IDENFERMEDAD") = filaenfermedad("IDENFERMEDAD").ToString
                    fila("CODIGOENFERMEDAD") = filaenfermedad("CODIGOENFERMEDAD").ToString
                    fila("NOMBREENFERMEDAD") = filaenfermedad("NOMBREENFERMEDAD").ToString
                    fila("ORIGEN") = DBNull.Value
                    fila("SECUELA") = DBNull.Value

                    If dtSecuelas.Rows.Count = Me.Dgv_Accidente.CurrentCell.RowIndex Then
                        Try
                            Me.Dgv_Accidente.Rows.RemoveAt(e.RowIndex)
                        Catch
                        End Try
                        dtSecuelas.Rows.Add(fila)
                    Else
                        dtSecuelas.Rows(e.RowIndex).Item("IDENFERMEDAD") = fila("IDENFERMEDAD")
                        dtSecuelas.Rows(e.RowIndex).Item("CODIGOENFERMEDAD") = fila("CODIGOENFERMEDAD")
                        dtSecuelas.Rows(e.RowIndex).Item("NOMBREENFERMEDAD") = fila("NOMBREENFERMEDAD")
                        dtSecuelas.Rows(e.RowIndex).Item("ORIGEN") = fila("ORIGEN")
                        dtSecuelas.Rows(e.RowIndex).Item("SECUELA") = DBNull.Value
                    End If
                Else
                    MsgBox("No se encontró una enfermedad con ese código", MsgBoxStyle.Exclamation, "Enfermedad no encontrada")
                    Try
                        Me.Dgv_Accidente.Rows.RemoveAt(e.RowIndex)
                    Catch
                    End Try
                End If
            Else
                MsgBox("Ya se encuentra esa enfermedad registrada", MsgBoxStyle.Exclamation, "Enfermedad no encontrada")
                Try
                    Me.Dgv_Accidente.Rows.RemoveAt(e.RowIndex)
                Catch
                End Try
            End If
        End If
    End Sub

    Private Function VerificarEnfermedadesDGV(ByVal IDENFEREMEDAD As String, ByVal Columna As String, ByVal dataTable As DataTable, ByVal dgv As DataGridView) As Boolean
        Dim filas As DataRow
        If dataTable IsNot Nothing Then
            If dataTable.Rows.Count > 0 Then
                Dim Busqueda As String = ""
                If Columna = "CODIGOENFERMEDAD" Then
                    Busqueda = "'" + IDENFEREMEDAD.ToString + "'"
                Else
                    Busqueda = IDENFEREMEDAD.ToString
                End If
                filas = dataTable.Select(Columna + " = " + Busqueda).FirstOrDefault
                Dim i As Integer = dataTable.Rows.IndexOf(filas)

                If filas IsNot Nothing Then
                    If i <> dgv.CurrentRow.Index Then
                        VerificarEnfermedadesDGV = False
                        Exit Function
                    End If
                End If
            End If

        End If
        VerificarEnfermedadesDGV = True
    End Function

    Private Sub Rb_Positivo_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_Positivo.CheckedChanged
        If Rb_Positivo.Checked Then
            Tb_Lasegue.Show()
        End If
    End Sub

    Private Sub Rb_Negativo_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_Negativo.CheckedChanged
        If Rb_Negativo.Checked Then
            Tb_Lasegue.Hide()
        End If
    End Sub

    Private Function AgregarFilas_Accidente() Handles Dgv_Accidente.RowLeave
        If Dgv_Accidente.Rows.Count >= 5 Then
            Dgv_Accidente.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarAccidente_Click(sender As Object, e As EventArgs) Handles Bt_AgregarAccidente.Click
        Dim agregarfila As Boolean = AgregarFilas_Accidente()
        If AgregarFilas_Accidente() Then
            Dim fila As DataRow
            fila = dtSecuelas.NewRow
            dtSecuelas.Rows.Add(fila)
        End If
    End Sub

    Private Function AgregarFilas_Enfermedades() Handles Dgv_Enfermedades.RowLeave
        If Dgv_Enfermedades.Rows.Count >= 5 Then
            Dgv_Enfermedades.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarEnfermedad_Click(sender As Object, e As EventArgs) Handles Bt_AgregarEnfermedades.Click
        If AgregarFilas_Enfermedades() Then
            Dim fila As DataRow
            fila = dtEnfermedades.NewRow
            dtEnfermedades.Rows.Add(fila)
        End If
    End Sub

    Private Function AgregarFilas_ImpresionDiagnostica() Handles Dgv_ImpresionDiagnosticaFinal.RowLeave
        If Dgv_ImpresionDiagnosticaFinal.Rows.Count >= 10 Then
            Dgv_ImpresionDiagnosticaFinal.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarImpresionDiagnosticaFinal_Click(sender As Object, e As EventArgs) Handles Bt_AgregarImpresionDiagnosticaFinal.Click
        If AgregarFilas_ImpresionDiagnostica() Then
            Dim fila As DataRow
            fila = dtImpresionDiagnostica.NewRow
            dtImpresionDiagnostica.Rows.Add(fila)
        End If
    End Sub

    Private Function AgregarFilas_Tareas() Handles Dgv_Tareas.RowLeave
        If Dgv_Tareas.Rows.Count >= 6 Then
            Dgv_Tareas.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarTarea_Click(sender As Object, e As EventArgs) Handles Bt_AgregarTarea.Click
        If AgregarFilas_Tareas() Then
            Dim fila As DataRow
            fila = dtTareas.NewRow
            dtTareas.Rows.Add(fila)
        End If
    End Sub

    Private Function AgregarFilasAntecedentesLaborales()
        If Dgv_AntecedenteLaborales.Rows.Count >= 5 Then
            Dgv_AntecedenteLaborales.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Bt_AgregarHigieneIndustrial_Click(sender As Object, e As EventArgs) Handles Bt_AgregarHigieneIndustrial.Click
        If Rb_ExamenIngreso.Checked Then
            If AgregarFilasAntecedentesLaborales() Then
                If dtAntecedentesLaboral.Rows.Count > 0 Then
                    For i As Integer = 1 To dtAntecedentesLaboral.Columns.Count - 1
                        Dim IndexUltimaFila As Integer = dtAntecedentesLaboral.Rows.Count - 1
                        If i <> 2 And i <> 3 And i <> 6 And i <> 7 And i <> 8 Then
                            If IsDBNull(Dgv_AntecedenteLaborales.Rows(IndexUltimaFila).Cells(i).Value) Then
                                MsgBox("Aun hay información por llenar en la fila.", MsgBoxStyle.Information, "Falta Información")
                                Dgv_AntecedenteLaborales.CurrentCell = Dgv_AntecedenteLaborales(i, IndexUltimaFila)
                                Exit Sub
                            End If
                        End If
                    Next
                End If
                Dim fila As DataRow
                fila = dtAntecedentesLaboral.NewRow
                fila.Item(0) = dtAntecedentesLaboral.Rows.Count + 1
                fila.Item(5) = "N"
                fila.Item(6) = "N"
                dtAntecedentesLaboral.Rows.Add(fila)
            End If
        Else
            If AgregarFilas_HigieneIndustrial() Then
                Dim fila As DataRow
                fila = dtHigiene.NewRow
                dtHigiene.Rows.Add(fila)
            End If
        End If

    End Sub

    Private Function AgregarFilas_HigieneIndustrial() Handles Dgv_Higiene.RowLeave
        If Dgv_Higiene.Rows.Count >= 4 Then
            Dgv_Higiene.AllowUserToAddRows = False
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub QuitarFilasTareas()
        Dim cantidad As Integer = Me.dtTareas.Rows.Count
        Dim flag As Boolean = False
        For i As Integer = cantidad - 1 To 0 Step -1
            Dim row As DataGridViewRow = Dgv_Tareas.Rows(i)
            For j As Integer = 0 To Dgv_Tareas.Columns.Count - 1
                If Not row.IsNewRow And IsDBNull(row.Cells(j).Value) Or row.Cells(j).Value Is Nothing Then
                    flag = True
                Else
                    flag = False
                End If
            Next
            If flag = True Then
                dtTareas.Rows.RemoveAt(i)
                flag = False
            End If
        Next
    End Sub

    Private Sub QuitarFilasVaciasHigiene()
        Dim cantidad As Integer = Me.dtHigiene.Rows.Count
        Dim flag As Boolean = False
        For i As Integer = cantidad - 1 To 0 Step -1
            Dim row As DataGridViewRow = Dgv_Higiene.Rows(i)
            For j As Integer = 0 To Dgv_Higiene.Columns.Count - 1
                If Not row.IsNewRow And IsDBNull(row.Cells(j).Value) Or row.Cells(j).Value Is Nothing Then
                    flag = True
                Else
                    flag = False
                End If
            Next
            If flag = True Then
                dtHigiene.Rows.RemoveAt(i)
                flag = False
            End If
        Next
    End Sub

    Private Sub QuitarFilasVaciasHabitos()
        Dim cantidad As Integer = Me.dtHabitos.Rows.Count
        Dim flag As Boolean = False
        For i As Integer = cantidad - 1 To 0 Step -1
            Dim row As DataGridViewRow = Dgv_Habitos.Rows(i)
            For j As Integer = 0 To Dgv_Habitos.Columns.Count - 1
                If Not row.IsNewRow And IsDBNull(row.Cells(j).Value) Or row.Cells(j).Value Is Nothing Then
                    flag = True
                Else
                    flag = False
                End If
            Next
            If flag = True Then
                dtHabitos.Rows.RemoveAt(i)
                flag = False
            End If
        Next
    End Sub

    Private Sub QuitarFilasVaciasAntecedentes()
        Dim cantidad As Integer = Me.dtAntecedentes.Rows.Count
        Dim flag As Boolean = False
        For i As Integer = cantidad - 1 To 0 Step -1
            Dim row As DataGridViewRow = Dgv_Antecedentes.Rows(i)
            For j As Integer = 0 To Dgv_Antecedentes.Columns.Count - 1
                If Not row.IsNewRow And IsDBNull(row.Cells(j).Value) Or row.Cells(j).Value Is Nothing Then
                    flag = True
                Else
                    flag = False
                End If
            Next
            If flag = True Then
                dtAntecedentes.Rows.RemoveAt(i)
                flag = False
            End If
        Next
    End Sub

    Private Sub QuitarFilasVaciasImpresionDiagnostica()
        Dim cantidad As Integer = Me.dtImpresionDiagnostica.Rows.Count
        Dim flag As Boolean = False
        For i As Integer = cantidad - 1 To 0 Step -1
            Dim row As DataGridViewRow = Dgv_ImpresionDiagnosticaFinal.Rows(i)
            For j As Integer = 0 To Dgv_ImpresionDiagnosticaFinal.Columns.Count - 2
                If Not row.IsNewRow And IsDBNull(row.Cells(j).Value) Or row.Cells(j).Value Is Nothing Then
                    flag = True
                Else
                    flag = False
                End If
            Next
            If flag = True Then
                dtImpresionDiagnostica.Rows.RemoveAt(i)
                flag = False
            End If
        Next
    End Sub

    Public Sub AddHandlerBuscarPersona()
        AddHandler (Cu_BuscarPersonaExamenMedico.Cb_Persona.KeyDown), AddressOf CalcularCampos
        AddHandler (Cu_BuscarPersonaExamenMedico.Cb_Persona.PreviewKeyDown), AddressOf CalcularCampos2
        AddHandler (Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedIndexChanged), AddressOf CalcularCampos3
        Cu_BuscarPersonaExamenMedico.Cb_Persona.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Cu_BuscarPersonaExamenMedico.Cb_Persona.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Public Sub CalcularCampos(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            LlenarCampos(Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue)
            CargarVacunas(Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue)
            Me.Tb_Edad.Focus()
        End If
    End Sub

    Public Sub CalcularCampos2(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs)
        LlenarCampos(Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue)
        CargarVacunas(Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue)
        If e.KeyCode = Keys.Tab Then
            e.IsInputKey = True
            SendKeys.Send("{ENTER}")
            Cu_BuscarPersonaExamenMedico.Cb_Persona.Focus()
        End If
    End Sub

    Public Sub CalcularCampos3()
        LlenarCampos(Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue)
        CargarVacunas(Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue)
    End Sub

    Public Sub LlenarCampos(ByVal IdPersona As String)
        If IdPersona IsNot Nothing Then
            Dim Cadena_Consulta As String
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Cadena_Consulta = "SELECT dbo.RetornaEdad(P.FECHANACIMIENTO) AS EDAD,P.GENERO, P.CODIGONIVELEDUCATIVO, P.CODIGOTIPOESTADOCIVIL, C.IDBASECONTRATADO, U.IDDEPENDENCIA, C.CODIGOTIPOCARGO, C.CODIGOTIPOROLBASE, C.FECHAINICIOCONTRATO,P.GRUPOSANGUINEO, P.CODIGOENTIDADADMINAFP, P.CODIGOENTIDADADMINEPS FROM PERSONA AS P LEFT JOIN USUARIO AS U ON U.IDPERSONA = P.IDPERSONA LEFT JOIN CONTRATO AS C ON C.IDPERSONA = P.IDPERSONA WHERE P.IDPERSONA = @IdPersona"
            Dim Consulta As New SqlCommand(Cadena_Consulta, conexion)
            Consulta.Parameters.AddWithValue("@IdPersona", IdPersona)
            Dim adaptador As New SqlDataAdapter(Consulta)
            Dim dtCampos As New DataTable
            conexion.Open()
            adaptador.Fill(dtCampos)
            conexion.Close()

            If dtCampos IsNot Nothing Then
                If Trim(dtCampos.Rows(0).Item("EDAD").ToString) <> "" Then
                    Tb_Edad.Text = dtCampos.Rows(0).Item("EDAD").ToString
                End If

                If Trim(dtCampos.Rows(0).Item("GENERO").ToString) <> "" Then
                    If dtCampos.Rows(0).Item("GENERO").ToString = "M" Then
                        Rb_Masculino.Checked = True
                    Else
                        Rb_Femenino.Checked = True
                    End If
                End If
                If Trim(dtCampos.Rows(0).Item("CODIGONIVELEDUCATIVO").ToString) <> "" Then
                    Cb_NivelAcademico.SelectedValue = dtCampos.Rows(0).Item("CODIGONIVELEDUCATIVO")
                End If

                If Trim(dtCampos.Rows(0).Item("CODIGOTIPOESTADOCIVIL").ToString) <> "" Then
                    Cb_EstadoCivil.SelectedValue = dtCampos.Rows(0).Item("CODIGOTIPOESTADOCIVIL")
                End If

                If Trim(dtCampos.Rows(0).Item("IDBASECONTRATADO").ToString) <> "" Then
                    Cb_Base.SelectedValue = dtCampos.Rows(0).Item("IDBASECONTRATADO")
                End If

                If Trim(dtCampos.Rows(0).Item("IDDEPENDENCIA").ToString) <> "" Then
                    Cb_Dependencia.SelectedValue = dtCampos.Rows(0).Item("IDDEPENDENCIA")
                End If

                If Rb_ExamenIngreso.Checked = False Then
                    If Trim(dtCampos.Rows(0).Item("FECHAINICIOCONTRATO").ToString) <> "" Then
                        Dtp_FechaIngreso.Value = dtCampos.Rows(0).Item("FECHAINICIOCONTRATO")
                    End If
                End If

                If Trim(dtCampos.Rows(0).Item("GRUPOSANGUINEO").ToString) <> "" Then
                    Cb_GrupoSanguineo.SelectedValue = dtCampos.Rows(0).Item("GRUPOSANGUINEO")
                End If

                If Trim(dtCampos.Rows(0).Item("CODIGOENTIDADADMINAFP").ToString) <> "" Then
                    Cb_AFP.SelectedValue = dtCampos.Rows(0).Item("CODIGOENTIDADADMINAFP")
                End If

                If Trim(dtCampos.Rows(0).Item("CODIGOENTIDADADMINEPS").ToString) <> "" Then
                    Cb_EPS.SelectedValue = dtCampos.Rows(0).Item("CODIGOENTIDADADMINEPS")
                End If
            End If
        End If
    End Sub

    Public Sub CargarVacunas(ByVal IdPersona As String)
        If dtVacunas IsNot Nothing Then
            dtVacunas.Clear()
        End If
        If Me.Cu_Vacuna1.dtVacunaPersona IsNot Nothing Then
            Me.Cu_Vacuna1.dtVacunaPersona.Clear()
        End If


        If IdPersona IsNot Nothing Then
            Dim Cadena_Consulta As String
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Cadena_Consulta = "SELECT VP.IDVACUNAXPERSONA,VP.IDPERSONA,VP.IDVACUNA,V.NOMBREVACUNA,convert(varchar,VP.FECHAVACUNA,103) as FECHAVACUNA,CASE VP.MODULOCREACION WHEN 'C' THEN 'CONTRATO' WHEN 'H' THEN 'HSE' END AS  MODULOCREACION,VP.IDPERSONAREGISTRO,VP.FECHAREGISTRO,VP.ACTIVA,VP.OBSERVACIONINACTIVACION,VP.IDPERSONAINACTIVA,VP.FECHAINACTIVACION,dbo.Personanombrecompleto(vp.IDPERSONAREGISTRO) as NOMPERSONAREGISTRO,V.IDPADRE FROM VACUNAXPERSONA as VP INNER JOIN MA_VACUNA as V on V.IDVACUNA =VP.IDVACUNA where IDPERSONA= @IDPERSONA AND VP.ACTIVA ='S'"
            Dim Consulta As New SqlCommand(Cadena_Consulta, conexion)
            Consulta.Parameters.AddWithValue("@IDPERSONA", IdPersona)
            Dim adaptador As New SqlDataAdapter(Consulta)
            conexion.Open()
            adaptador.Fill(dtVacunas)
            conexion.Close()
            Me.Cu_Vacuna1.Enabled = True
            Me.Cu_Vacuna1.IdPersona = IdPersona
            Me.Cu_Vacuna1.dtVacunaPersona = dtVacunas
            Me.Cu_Vacuna1.contRegIni = dtVacunas.Rows.Count
            Me.Cu_Vacuna1.CargarDatos()
        End If
    End Sub

    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1,
                                    Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaExamenMedico.CargarDatos()
            Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaExamenMedico.CargarCajaTexto()
        Catch ex As Exception
        End Try


        Select Case NOMBRECOMPONENTE
            Case Cu_BuscarPersonaExamenMedico.Name
                Me.Cu_BuscarPersonaExamenMedico.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub

    Private Sub Ck_VNormal_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_VNormal.CheckedChanged
        If Ck_VNormal.Checked Then
            Ck_VCerca.Checked = False
            Ck_VLejos.Checked = False
            Ck_VMovilidad.Checked = False
            Ck_VParpados.Checked = False
            Ck_VConjuntiva.Checked = False
            Ck_VCerca.Enabled = False
            Ck_VLejos.Enabled = False
            Ck_VMovilidad.Enabled = False
            Ck_VParpados.Enabled = False
            Ck_VConjuntiva.Enabled = False
        Else
            Ck_VCerca.Enabled = True
            Ck_VLejos.Enabled = True
            Ck_VMovilidad.Enabled = True
            Ck_VParpados.Enabled = True
            Ck_VConjuntiva.Enabled = True
        End If
    End Sub

    Private Sub Ck_PONormal_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_PONormal.CheckedChanged
        If Ck_PONormal.Checked Then
            Ck_POBacterias.Checked = False
            Ck_POProteinura.Checked = False
            Ck_POGlucosuria.Checked = False
            Ck_POCalcio.Checked = False
            Ck_POSangre.Checked = False
            Ck_POAlbumina.Checked = False
            Ck_POEritocitocis.Checked = False
            Ck_POCreatinuria.Checked = False
            Ck_POBacterias.Enabled = False
            Ck_POProteinura.Enabled = False
            Ck_POGlucosuria.Enabled = False
            Ck_POCalcio.Enabled = False
            Ck_POSangre.Enabled = False
            Ck_POAlbumina.Enabled = False
            Ck_POEritocitocis.Enabled = False
            Ck_POCreatinuria.Enabled = False
        Else
            Ck_POBacterias.Enabled = True
            Ck_POProteinura.Enabled = True
            Ck_POGlucosuria.Enabled = True
            Ck_POCalcio.Enabled = True
            Ck_POSangre.Enabled = True
            Ck_POAlbumina.Enabled = True
            Ck_POEritocitocis.Enabled = True
            Ck_POCreatinuria.Enabled = True
        End If
    End Sub

    Private Sub Ck_PsNegativo_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_PsNegativo.CheckedChanged
        If Ck_PsNegativo.Checked Then
            Ck_PsMarihuana.Checked = False
            Ck_PsCocaina.Checked = False
            Ck_PsMarihuana.Enabled = False
            Ck_PsCocaina.Enabled = False
        Else
            Ck_PsMarihuana.Enabled = True
            Ck_PsCocaina.Enabled = True
        End If
    End Sub

    Private Sub Rb_ExamenIngreso_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_ExamenIngreso.CheckedChanged, Rb_ExamenEgreso.CheckedChanged, Rb_ExamenPeriodico.CheckedChanged
        If Rb_ExamenIngreso.Checked Then
            Dtp_FechaIngreso.Enabled = False
            Lb_HigieneIndustrial.Text = "Antecedentes Laborales"
            Gb_TipoExamen.Enabled = False
            Bt_AgregarHigieneIndustrial.Location = New System.Drawing.Point(178, 2)
            Dgv_Higiene.Visible = False
            Dgv_AntecedenteLaborales.Visible = True
        Else
            Dtp_FechaIngreso.Enabled = True
            Gb_TipoExamen.Enabled = False
            Dgv_Higiene.Visible = True
            Dgv_AntecedenteLaborales.Visible = False
        End If
    End Sub

    Private Sub Dgv_AntecedenteLaborales_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_AntecedenteLaborales.EditingControlShowing
        Try
            Dim dText As DataGridViewTextBoxEditingControl = e.Control
            AddHandler dText.KeyPress, AddressOf dText_KeyPress_Dgv_AntecedenteLaborales
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dText_KeyPress_Dgv_AntecedenteLaborales(sender As Object, e As KeyPressEventArgs)
        Dim Celda As DataGridViewCell = Me.Dgv_AntecedenteLaborales.CurrentCell()
        Select Case Celda.ColumnIndex
            Case 2, 3, 7, 10
                e.KeyChar = Char.ToUpper(e.KeyChar)
                Select Case e.KeyChar
                    Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", Convert.ToChar(8)
                        e.Handled = False
                    Case Else
                        e.Handled = True
                End Select
        End Select
    End Sub

    Private Sub Dgv_AntecedenteLaborales_RowLeave(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Dgv_AntecedenteLaborales.RowLeave
        Dim IndexActual As Integer = e.RowIndex
        For i As Integer = 1 To dtAntecedentesLaboral.Columns.Count - 1
            If i <> 2 And i <> 3 And i <> 6 And i <> 7 And i <> 8 Then
                If IsDBNull(Dgv_AntecedenteLaborales.Rows(IndexActual).Cells(i).Value) Then
                    Dgv_AntecedenteLaborales.CurrentCell = Dgv_AntecedenteLaborales(i, IndexActual)
                End If
            End If
        Next

    End Sub

    Private Sub Dgv_AntecedenteLaborales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_AntecedenteLaborales.CellContentClick
        Dim Celda As DataGridView = CType(sender, DataGridView)
        If Celda.CurrentCell.GetType Is GetType(DataGridViewButtonCell) Then
            Dim Fr_RiesgosAntecedentesLaborales As New Fr_RiesgosAntecedentesLaborales
            Fr_RiesgosAntecedentesLaborales.IdItem = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVT_NroItem").Value.ToString
            Fr_RiesgosAntecedentesLaborales.Empresa = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVT_NOMBREEMPRESA").Value.ToString
            Fr_RiesgosAntecedentesLaborales.TiempoTrabajadoMeses = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVT_TIEMPOTRABAJADOMESES").Value.ToString
            Fr_RiesgosAntecedentesLaborales.TiempoTrabajadoAños = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVT_TIEMPOTRABAJADOAÑOS").Value.ToString
            Fr_RiesgosAntecedentesLaborales.ARL = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVC_ARL").FormattedValue.ToString.ToString
            Fr_RiesgosAntecedentesLaborales.IT = IIf(Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVCK_INCAPACIDAD").Value = "S", "Si", "No")
            Fr_RiesgosAntecedentesLaborales.Origen = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVC_ORIGEN").FormattedValue.ToString
            Fr_RiesgosAntecedentesLaborales.DiasIT = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVT_DIASINCAPACIDAD").Value.ToString
            Fr_RiesgosAntecedentesLaborales.Secuela = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVT_SECUELA").Value.ToString
            Fr_RiesgosAntecedentesLaborales.Jornada = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVC_JORNADA").FormattedValue.ToString
            Fr_RiesgosAntecedentesLaborales.Turno = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVT_TURNO").FormattedValue.ToString
            Fr_RiesgosAntecedentesLaborales.Cargo = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVC_CARGO").FormattedValue.ToString
            Dim Item As Integer = Dgv_AntecedenteLaborales.CurrentRow.Cells("DGVT_NroItem").Value
            Dim drRiesgos() As DataRow = dtRiesgosAntecedentesLaborales.Select("IDITEMANTECEDENTELABORAL =" + Item.ToString)
            If drRiesgos.Length > 0 Then
                Fr_RiesgosAntecedentesLaborales.dtRiesgos = drRiesgos.CopyToDataTable
            Else
                Dim dtVacio As DataTable = dtRiesgosAntecedentesLaborales.Clone
                dtVacio.Clear()
                Fr_RiesgosAntecedentesLaborales.dtRiesgos = dtVacio
            End If

            Fr_RiesgosAntecedentesLaborales.dtCbRiesgos = dsCargar.Tables(39).Copy
            Fr_RiesgosAntecedentesLaborales.dtCbAgentes = dsCargar.Tables(12).Copy
            Fr_RiesgosAntecedentesLaborales.ComportamientoPredeterminado()
            Fr_RiesgosAntecedentesLaborales.ShowDialog()

            If Fr_RiesgosAntecedentesLaborales.Aceptar = True Then
                For Each FilaBorrar In drRiesgos
                    dtRiesgosAntecedentesLaborales.Rows.Remove(FilaBorrar)
                Next
                For i As Integer = 0 To Fr_RiesgosAntecedentesLaborales.dtRiesgos.Rows.Count - 1
                    Dim Fila As DataRow
                    Fila = dtRiesgosAntecedentesLaborales.NewRow
                    Fila.Item(0) = Fr_RiesgosAntecedentesLaborales.dtRiesgos.Rows(i).Item(0)
                    Fila.Item(1) = Fr_RiesgosAntecedentesLaborales.dtRiesgos.Rows(i).Item(1)
                    Fila.Item(2) = Fr_RiesgosAntecedentesLaborales.dtRiesgos.Rows(i).Item(2)
                    Fila.Item(3) = Fr_RiesgosAntecedentesLaborales.dtRiesgos.Rows(i).Item(3)
                    Fila.Item(4) = Fr_RiesgosAntecedentesLaborales.dtRiesgos.Rows(i).Item(4)
                    dtRiesgosAntecedentesLaborales.Rows.Add(Fila)
                Next
            End If
        End If
    End Sub

    Private Sub Dgv_AntecedenteLaborales_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles Dgv_AntecedenteLaborales.UserDeletedRow
        dtAntecedentesLaboral.AcceptChanges()
        dtRiesgosAntecedentesLaborales.AcceptChanges()
        EnumerarFilas()
    End Sub

    Private Sub Dgv_AntecedenteLaborales_UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Dgv_AntecedenteLaborales.UserDeletingRow
        Dim Celda As DataGridView = CType(sender, DataGridView)
        Dim NroItemEliminada As Integer = Celda.Item("DGVT_NroItem", e.Row.Index).Value
        Dim drEliminar() As DataRow = dtRiesgosAntecedentesLaborales.Select("IDITEMANTECEDENTELABORAL = " + NroItemEliminada.ToString)
        If drEliminar.Length > 0 Then
            For Each FilaEliminar In drEliminar
                dtRiesgosAntecedentesLaborales.Rows.Remove(FilaEliminar)
            Next
        End If
    End Sub

End Class
