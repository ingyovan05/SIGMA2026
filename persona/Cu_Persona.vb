Imports Microsoft.Office.Interop
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports System.Text
Imports System.Net.Mail
Imports System.Net

Public Class Cu_Persona
    Private bddatos As New DatosClasesBase.Busquedas
    Private dsTerceros As New DataSet
    Private dsCalificaciones As New DataSet
    Private FiltroAplicado As Boolean = False
    Dim dtCalificacion As New DataTable
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private dsEvaluacion As New DataSet
    Const tamannoMaximoArchivo As Long = 15728640 '15 MB
    Public idconcepto As Integer = 0
    Dim GoogleDrive As New FuncionesGoogle.FuncionesGoogle
    Private Index_Registro_Actual As Integer = -1
    Private Enum Tablas
        Persona
        Examenes
        Encuestas
        Calificaciones
        Evaluacion
    End Enum
    Private tablaCargada As Tablas

    Public Sub Comportamiento_Predeterminado()
        Dgv_Persona.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Persona.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Nbc_Persona.ActiveGroup = Nbg_Persona
        CambioNbg()

        tablaCargada = Tablas.Persona
        Nbc_Persona.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbc_Persona.Tag)
        'Persona
        Nbg_Persona.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Persona.Tag)
        Nbi_CargarPersonas.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarPersonas.Tag)
        Nbi_VerPersona.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPersona.Tag)
        Nbi_RegistrarPersona.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarPersona.Tag)
        Nbi_RegistrarPersonaBásico.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarPersonaBásico.Tag)
        Nbi_EditarRegistroPersona.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarRegistroPersona.Tag)
        Nbi_EditarPersonaBasico.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarPersonaBasico.Tag)
        Nbi_DesactivarPersona.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_DesactivarPersona.Tag)
        Nbi_BuscarPersona.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarPersona.Tag)
        Nbi_ImprimirFormatos.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirFormatos.Tag)
        Nbi_RegistrarContrato.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarContrato.Tag)
        Nbi_SubirValidacionHDeVida.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirValidacionHDeVida.Tag)
        Nbi_VerValidacionHDeVida.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerValidacionHDeVida.Tag)

        'Exámenes
        Nbg_Examenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Examenes.Tag)
        Nbi_ListarExamenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarExamenes.Tag)
        Nbi_EnviarAExamenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EnviarAExamenes.Tag)
        Nbi_ConceptoMedico.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ConceptoMedico.Tag)
        Nbi_VerExamen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerExamen.Tag)
        Nbi_BuscarExamenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarExamenes.Tag)
        Nbi_ImprimirExamenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirExamenes.Tag)
        Nbi_HabilitarEdición.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HabilitarEdición.Tag)
        Nbi_EditarExamen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarExamen.Tag)
        Nbi_AgregarVacunas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AgregarVacunas.Tag)


        'Encuestas
        Nbg_COVID19.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_COVID19.Tag)
        Nbi_CargarEncuestas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarEncuestas.Tag)
        Nbi_CrearEncuesta.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearEncuesta.Tag)
        Nbi_EditarEncuesta.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarEncuesta.Tag)
        Nbi_BuscarEncuesta.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarEncuesta.Tag)
        Nbi_CancelarEncuesta.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarEncuesta.Tag)
        Nbi_ImprimirEncuesta.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirEncuesta.Tag)
        Nbi_AutorizarIngresoCOVID.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AutorizarIngresoCOVID.Tag)

        'Calificaciones
        Nbg_ProgramaCalificación.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_ProgramaCalificación.Tag)
        'Nbi_CargarCalificaciones.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarCalificaciones.Tag)
        Nbi_AgregarCalificación.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AgregarCalificación.Tag)
        Nbi_GestionarCalificaciones.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_GestionarCalificaciones.Tag)
        Nbi_ProgramarCapacitaciones.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ProgramarCapacitaciones.Tag)
        Nbi_ImprimirCarnet.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirCarnet.Tag)
        'Nbi_BuscarCalificacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarCalificacion.Tag)

        'Evaluación Desempeño
        Nbg_EvalaucionDesempeño.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_EvalaucionDesempeño.Tag)
        Nbi_ListarEvaluacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarEvaluacion.Tag)
        Nbi_CrearEvaluacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearEvaluacion.Tag)
        Nbi_VerEvaluacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerEvaluacion.Tag)
        Nbi_EditarEvaluacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarEvaluacion.Tag)
        Nbi_BuscarEvaluacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarEvaluacion.Tag)
        Nbi_EnviarCorreo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EnviarCorreo.Tag)
        Nbi_EnviarCorreoBloque.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EnviarCorreoBloque.Tag)

        'Verficar acesso a ISMOCOL
        Nbg_VerificarEstado.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_VerificarEstado.Tag)
        Nbi_RegistrarEstado.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarEstado.Tag)
        Nbi_ConsultarEstado.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ConsultarEstado.Tag)
        Nbi_VerResumen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerResumen.Tag)
        Nbi_HistorialConsultas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialConsultas.Tag)
        Nbi_AgregarPersonaSeguridad.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AgregarPersonaSeguridad.Tag)

    End Sub

    Public Sub Cargar_Tabla()
        Cargar_Personas()
    End Sub

    Private Sub Dgv_Persona_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles Dgv_Persona.DoubleClick
        Dim pt As Point = sender.PointToClient(Windows.Forms.Cursor.Position)
        Dim hit As DataGridView.HitTestInfo = sender.HitTest(pt.X, pt.Y)
        If hit.RowIndex >= 0 Then
            Select Case tablaCargada
                Case Tablas.Persona
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("40") = True Then
                        EditarPersona()
                    End If
                Case Tablas.Examenes
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("706") = True Then
                        VerExamen()
                    End If
            End Select
        End If
    End Sub

    Private Sub Dgv_Persona_RowPostPaint(ByVal sender As Object, ByVal e As DataGridViewRowPostPaintEventArgs) Handles Dgv_Persona.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Font)
        If Dgv_Persona.RowHeadersWidth < CInt(size.Width + 20) Then
            Dgv_Persona.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim bt As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub AplicarFormatoColumnas()
        Pn_Calificaciones.Visible = False
        Select Case tablaCargada
            Case Tablas.Persona
                For i = 0 To Dgv_Persona.ColumnCount - 1
                    Select Case Dgv_Persona.Columns(i).Name
                        Case "Id"
                            Dgv_Persona.Columns(i).Width = 41
                            Dgv_Persona.Columns(i).ToolTipText = "Identificador de la persona"
                        Case "Identificación"
                            Dgv_Persona.Columns(i).ToolTipText = "Número de identificación"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_Persona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "Nombre"
                            Dgv_Persona.Columns(i).Width = 220
                            Dgv_Persona.Columns(i).ToolTipText = "Nombre completo"
                        Case "Estado Civil"
                            Dgv_Persona.Columns(i).Width = 85
                            Dgv_Persona.Columns(i).ToolTipText = "Estado civil"
                        Case "Celular"
                            Dgv_Persona.Columns(i).Width = 80
                            Dgv_Persona.Columns(i).ToolTipText = "Número de teléfono celular"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "Fecha Nacimiento"
                            Dgv_Persona.Columns(i).HeaderText = "F. Nacimiento"
                            Dgv_Persona.Columns(i).Width = 80
                            Dgv_Persona.Columns(i).ToolTipText = "Fecha de nacimiento"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "Edad"
                            Dgv_Persona.Columns(i).Width = 40
                            Dgv_Persona.Columns(i).ToolTipText = "Edad"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "E-mail"
                            Dgv_Persona.Columns(i).Width = 180
                            Dgv_Persona.Columns(i).ToolTipText = "Correo electrónico personal"
                        Case "Contrato"
                            Dgv_Persona.Columns(i).Width = 75
                            Dgv_Persona.Columns(i).ToolTipText = "Código de contrato"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "Base"
                            Dgv_Persona.Columns(i).HeaderText = "Base"
                            Dgv_Persona.Columns(i).Width = 130
                            Dgv_Persona.Columns(i).ToolTipText = "Base Contrato"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Dgv_Persona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Case "Fecha Terminacion Contrato"
                            Dgv_Persona.Columns(i).HeaderText = "F. Terminación"
                            Dgv_Persona.Columns(i).Width = 130
                            Dgv_Persona.Columns(i).ToolTipText = "Fecha terminación contrato"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Dgv_Persona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Case "Estado Contrato"
                            Dgv_Persona.Columns(i).HeaderText = "Est. Cont."
                            Dgv_Persona.Columns(i).Width = 50
                            Dgv_Persona.Columns(i).ToolTipText = "Estado del contrato"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case Else
                            Dgv_Persona.Columns(i).Visible = False
                    End Select
                Next
            Case Tablas.Examenes
                For i = 0 To Dgv_Persona.ColumnCount - 1
                    Select Case Dgv_Persona.Columns(i).Name
                        Case "IDENVIOEXAMEN"
                            Dgv_Persona.Columns(i).ToolTipText = "Identificador o Consecutivo del Envío"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_Persona.Columns(i).Width = 80
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "NOMBRE"
                            Dgv_Persona.Columns(i).Width = 200
                            Dgv_Persona.Columns(i).HeaderText = "Nombre"
                            Dgv_Persona.Columns(i).ToolTipText = "Nombre completo de la Persona"
                        Case "Celular"
                            Dgv_Persona.Columns(i).Width = 80
                            Dgv_Persona.Columns(i).ToolTipText = "Número de teléfono celular"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "IDENTIFICACION"
                            Dgv_Persona.Columns(i).Width = 120
                            Dgv_Persona.Columns(i).HeaderText = "Identificación"
                            Dgv_Persona.Columns(i).ToolTipText = "Número de identificación de la Persona"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "FECHAENVIO"
                            Dgv_Persona.Columns(i).Width = 80
                            Dgv_Persona.Columns(i).HeaderText = "Fecha Envío"
                            Dgv_Persona.Columns(i).ToolTipText = "Fecha del Envío a Exámenes"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "NOMBREBASE"
                            Dgv_Persona.Columns(i).Width = 150
                            Dgv_Persona.Columns(i).HeaderText = "Nombre base"
                            Dgv_Persona.Columns(i).ToolTipText = "Nombre base"
                        Case "NOMBRECENTROCLINICO"
                            Dgv_Persona.Columns(i).Width = 150
                            Dgv_Persona.Columns(i).HeaderText = "Nombre Centro Clinico"
                            Dgv_Persona.Columns(i).ToolTipText = "Nombre Centro Clinico"
                        Case "NOMBRETIPOCARGO"
                            Dgv_Persona.Columns(i).Width = 200
                            Dgv_Persona.Columns(i).HeaderText = "Cargo"
                            Dgv_Persona.Columns(i).ToolTipText = "Cargo"
                        Case "MOTIVOCONSULTA"
                            Dgv_Persona.Columns(i).Width = 120
                            Dgv_Persona.Columns(i).HeaderText = "Motivo Consulta"
                            Dgv_Persona.Columns(i).ToolTipText = "Motivo Consulta"
                        Case "CIUDAD"
                            Dgv_Persona.Columns(i).Width = 150
                            Dgv_Persona.Columns(i).HeaderText = "Ciudad Examenes"
                            Dgv_Persona.Columns(i).ToolTipText = "Ciudad Examenes"
                        Case "CONCEPTOMEDICO"
                            Dgv_Persona.Columns(i).Width = 100
                            Dgv_Persona.Columns(i).HeaderText = "Concepto Médico"
                            Dgv_Persona.Columns(i).ToolTipText = "Concepto Médico"
                        Case "CONTINUAPROCESO"
                            Dgv_Persona.Columns(i).Width = 40
                            Dgv_Persona.Columns(i).HeaderText = "Apto"
                            Dgv_Persona.Columns(i).ToolTipText = "Apto"
                        Case "PERMITIREDICION"
                            Dgv_Persona.Columns(i).Width = 40
                            Dgv_Persona.Columns(i).HeaderText = "Editable"
                            Dgv_Persona.Columns(i).ToolTipText = "Editable"
                        Case Else
                            Dgv_Persona.Columns(i).Visible = False
                    End Select
                Next
            Case Tablas.Encuestas
                For i = 0 To Dgv_Persona.ColumnCount - 1
                    Select Case Dgv_Persona.Columns(i).Name
                        Case "IdE"
                            Dgv_Persona.Columns(i).ToolTipText = "Identificador de la encuesta"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_Persona.Columns(i).Width = 40
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "IdP"
                            Dgv_Persona.Columns(i).Width = 41
                            Dgv_Persona.Columns(i).ToolTipText = "Identificador de la persona"
                        Case "NOMBRE"
                            Dgv_Persona.Columns(i).Width = 200
                            Dgv_Persona.Columns(i).HeaderText = "Nombre"
                            Dgv_Persona.Columns(i).ToolTipText = "Nombre completo de la Persona"
                        Case "NOMBREBASE"
                            Dgv_Persona.Columns(i).Width = 150
                            Dgv_Persona.Columns(i).HeaderText = "Nombre base"
                            Dgv_Persona.Columns(i).ToolTipText = "Nombre base"
                        Case "Celular"
                            Dgv_Persona.Columns(i).Width = 80
                            Dgv_Persona.Columns(i).ToolTipText = "Número de teléfono celular"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "IDENTIFICACION"
                            Dgv_Persona.Columns(i).Width = 120
                            Dgv_Persona.Columns(i).HeaderText = "Identificación"
                            Dgv_Persona.Columns(i).ToolTipText = "Número de identificación de la Persona"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "LLENOVIAWEB"
                            Dgv_Persona.Columns(i).Width = 40
                            Dgv_Persona.Columns(i).HeaderText = "Web"
                            Dgv_Persona.Columns(i).ToolTipText = "Si realizo la encuesta por la página WEB"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "AUTORIZADOMEDICO"
                            Dgv_Persona.Columns(i).Width = 40
                            Dgv_Persona.Columns(i).HeaderText = "Aut."
                            Dgv_Persona.Columns(i).ToolTipText = "Autorizado por el Médico"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "INGRESO"
                            Dgv_Persona.Columns(i).Width = 60
                            Dgv_Persona.Columns(i).HeaderText = "Ingresar"
                            Dgv_Persona.Columns(i).ToolTipText = "Si puede ingresar"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "Edad"
                            Dgv_Persona.Columns(i).Width = 40
                            Dgv_Persona.Columns(i).ToolTipText = "Edad"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "TEMPERATURA"
                            Dgv_Persona.Columns(i).Width = 40
                            Dgv_Persona.Columns(i).ToolTipText = "Temperatura"
                            Dgv_Persona.Columns(i).HeaderText = "Temp."
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "FECHAREGISTRO"
                            Dgv_Persona.Columns(i).Width = 100
                            Dgv_Persona.Columns(i).HeaderText = "Fecha Registro"
                            Dgv_Persona.Columns(i).ToolTipText = "Fecha Registro Encuesta"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "NOMBRETIPOCARGO"
                            Dgv_Persona.Columns(i).Width = 150
                            Dgv_Persona.Columns(i).HeaderText = "Cargo"
                            Dgv_Persona.Columns(i).ToolTipText = "Cargo"
                        Case "PERSONAREGISTRO"
                            Dgv_Persona.Columns(i).Width = 150
                            Dgv_Persona.Columns(i).HeaderText = "Persona Registro"
                            Dgv_Persona.Columns(i).ToolTipText = "Persona Registro"
                        Case "CORREOELECTRONICO"
                            Dgv_Persona.Columns(i).Width = 150
                            Dgv_Persona.Columns(i).HeaderText = "E-Mail"
                            Dgv_Persona.Columns(i).ToolTipText = "E-Mail"
                        Case Else
                            Dgv_Persona.Columns(i).Visible = False
                    End Select
                Next
            Case Tablas.Evaluacion
                For i = 0 To Dgv_Persona.ColumnCount - 1
                    Select Case Dgv_Persona.Columns(i).Name
                        Case "Id"
                            Dgv_Persona.Columns(i).Width = 41
                            Dgv_Persona.Columns(i).ToolTipText = "Identificador Evaluación"
                        Case "Identificacion Evaluado"
                            Dgv_Persona.Columns(i).Width = 80
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "NIVELDESEMPEÑOTOTAL"
                            Dgv_Persona.Columns(i).HeaderText = "Puntaje"
                            Dgv_Persona.Columns(i).Width = 50
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "ESTADO"
                            Dgv_Persona.Columns(i).HeaderText = "Estado"
                            Dgv_Persona.Columns(i).Width = 50
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "PROYECTO"
                            Dgv_Persona.Columns(i).Width = 100
                            Dgv_Persona.Columns(i).HeaderText = "Proyecto"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "Persona Evaluado"
                            Dgv_Persona.Columns(i).Width = 200
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        
                        Case "Identificación Evalua"
                            Dgv_Persona.Columns(i).Width = 80
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "Persona Evalua"
                            Dgv_Persona.Columns(i).Width = 200
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                       
                        Case "PERIODO"
                            Dgv_Persona.Columns(i).HeaderText = "Periodo"
                            Dgv_Persona.Columns(i).Width = 80
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Dgv_Persona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                        Case Else
                            Dgv_Persona.Columns(i).Visible = False
                    End Select
                Next
            Case Tablas.Calificaciones
                For i = 0 To Dgv_Persona.ColumnCount - 1
                    Select Case Dgv_Persona.Columns(i).Name
                        Case "Id"
                            Dgv_Persona.Columns(i).ToolTipText = "Id Persona"
                            Dgv_Persona.Columns(i).HeaderText = "Id Persona"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_Persona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "Cedula"
                            Dgv_Persona.Columns(i).ToolTipText = "Numero de Cedula"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                            Dgv_Persona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "NOMBRECOMPLETO"
                            Dgv_Persona.Columns(i).Width = 150
                            Dgv_Persona.Columns(i).HeaderText = " Nombre"
                            Dgv_Persona.Columns(i).ToolTipText = "Nombre Completo de la Persona"
                            Dgv_Persona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "Cargo"
                            Dgv_Persona.Columns(i).Width = 150
                            Dgv_Persona.Columns(i).HeaderText = "Cargo"
                            Dgv_Persona.Columns(i).ToolTipText = "Cargo de la Persona"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "CODIGOCONTRATO"
                            Dgv_Persona.Columns(i).Width = 50
                            Dgv_Persona.Columns(i).HeaderText = "Cód Cont"
                            Dgv_Persona.Columns(i).ToolTipText = "Código del contrato"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "NOMBREBASE"
                            Dgv_Persona.Columns(i).Width = 130
                            Dgv_Persona.Columns(i).HeaderText = "Base"
                            Dgv_Persona.Columns(i).ToolTipText = "Base"
                            Dgv_Persona.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Case "ESTADOCONTRATO"
                            Dgv_Persona.Columns(i).Width = 50
                            Dgv_Persona.Columns(i).HeaderText = "Estado"
                            Dgv_Persona.Columns(i).ToolTipText = "Estado Contrato"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "No. CERTIFICADO"
                            Dgv_Persona.Columns(i).Width = 50
                            Dgv_Persona.Columns(i).HeaderText = "No. Cert"
                            Dgv_Persona.Columns(i).ToolTipText = "Numero de Certificados"
                            Dgv_Persona.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case Else
                            Dgv_Persona.Columns(i).Visible = False
                    End Select
                Next

                Pn_Calificaciones.Visible = True
            Case Else

        End Select
        SplitContainer1.SplitterDistance = Me.Width - 350
    End Sub

    Private Sub Dgv_Persona_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dgv_Persona.SelectionChanged
        Select Case tablaCargada
            Case Tablas.Persona
                Try
                    Dim xx As New Cl_Persona(Dgv_Persona.SelectedRows(0))
                    Pg_DetalleLista.SelectedObject = xx
                    If Ck_MostrarFotoPersona.Checked Then
                        CargarFotoPersona(Me.Dgv_Persona.SelectedRows(0).Cells(0).Value)
                    End If
                Catch
                    Pg_DetalleLista.SelectedObject = Nothing
                End Try
            Case Tablas.Examenes
                Try
                    Dim xx As New Cl_Examen(Dgv_Persona.SelectedRows(0))
                    Pg_DetalleLista.SelectedObject = xx
                Catch
                    Pg_DetalleLista.SelectedObject = Nothing
                End Try
            Case Tablas.Encuestas
                Try
                    Dim xx As New Cl_Encuesta(Dgv_Persona.SelectedRows(0))
                    Pg_DetalleLista.SelectedObject = xx
                Catch
                    Pg_DetalleLista.SelectedObject = Nothing
                End Try
            Case Tablas.Evaluacion
                Try
                    Dim xx As New Cl_Evaluacion(Dgv_Persona.SelectedRows(0))
                    Pg_DetalleLista.SelectedObject = xx
                Catch
                    Pg_DetalleLista.SelectedObject = Nothing
                End Try
            Case Tablas.Calificaciones
                Try
                    Dim xx As New Cl_Calificacion(Dgv_Persona.SelectedRows(0))
                    Pg_DetalleLista.SelectedObject = xx
                    CargarCalificacionesXPersona()
                Catch
                    Pg_DetalleLista.SelectedObject = Nothing
                End Try
        End Select
    End Sub


#Region "Persona"
    Private Sub Nbi_CargarPersonas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarPersonas.ItemClick
        Cargar_Personas()
    End Sub

    Dim FrPersona As New Persona.Fr_Persona

    Public Sub CodigoContrato()
        Dim Contrato As Integer = Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Contrato").Value
        Dim FrPersona As New Persona.Fr_Persona

    End Sub
    Public Sub EstadoContrato()
        Dim EstadoContrato As String = Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("estado contrato").Value
    End Sub

    Public Sub Cargar_Personas()
        Cursor.Current = Cursors.WaitCursor
        dsTerceros = bddatos.BusquedaCondiciones(18, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        If dsTerceros.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
            dsTerceros.Tables.Remove(dsTerceros.Tables(0).TableName) 'Borrar la tabla del conteo.
        Else 'Si solo trae el conteo es porque se exceden los campos.
            MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dsTerceros.Clear()
        End If
        tablaCargada = Tablas.Persona
        Dgv_Persona.DataSource = Nothing
        Dgv_Persona.DataSource = dsTerceros.Tables(0)
        AplicarFormatoColumnas()
        Lb_CantidadReportes.Text = "Cantidad de Personas: " & dsTerceros.Tables(0).Rows.Count
        If Dgv_Persona.RowCount > 0 Then
            Dgv_Persona.ClearSelection()
            Dgv_Persona.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Nbi_RegistrarPersona_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_RegistrarPersona.ItemClick
        Dim FrPersona As New Fr_Persona
        FrPersona.Contrato = -1
        FrPersona.Cargar_Tablas()
        FrPersona.Show()

        If FrPersona.Guardado Then
            Cargar_Personas()
        End If
    End Sub

    Private Sub Nbi_VerPersona_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_VerPersona.ItemClick
        If tablaCargada = Tablas.Persona Then
            Dim FrPersona As New Fr_Persona
            FrPersona.Editando = True
            FrPersona.IdPersonaEditando = Dgv_Persona.SelectedRows(0).Cells("Id").Value
            FrPersona.Cargar_Tablas()
            FrPersona.CargarDatosPersona()
            FrPersona.Button_Aceptar.Enabled = False
            FrPersona.ShowDialog()
        Else
            MessageBox.Show("Cargue el listado de Personal")
        End If
    End Sub

    Private Sub Nbi_EditarRegistroPersona_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_EditarRegistroPersona.ItemClick
        If tablaCargada = Tablas.Persona Then
            EditarPersona()
        Else
            MessageBox.Show("Cargue el listado de Personal")
        End If
    End Sub

    Private Sub EditarPersona()
        Dim FrPersona As New Fr_Persona
        FrPersona.Editando = True
        If IsDBNull(Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Contrato").Value) = False Then
            FrPersona.Contrato = Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Contrato").Value
            FrPersona.EstadoContrato = Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("estado contrato").Value
        End If
        FrPersona.IdPersonaEditando = Dgv_Persona.SelectedRows(0).Cells("Id").Value
        FrPersona.Cargar_Tablas()
        FrPersona.CargarDatosPersona()
        FrPersona.ShowDialog()
        If FrPersona.Guardado Then
            Cargar_Personas()
        End If
    End Sub

    Private Sub Nbi_BuscarPersona_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarPersona.ItemClick
        BuscarPersona()
    End Sub

    Private Sub BuscarPersona()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("P.IDENTIFICACION", "Identificación (sin puntos)", "2")
        campos.Rows.Add("1", "Nombre", "7")
        campos.Rows.Add("dbo.ciudadcondepartamento(P.CODIGOLUGARNACIMIENTO)", "Ciudad de nacimiento", "1")
        campos.Rows.Add("LTRIM(RTRIM(P.CORREOELECTRONICO))", "Correo electrónico", "1")
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de Persona registrada en SIGMA"
        frbuscar.tabla = 18 ' Terceros
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsTerceros = DSbusqueda
        If Not IsNothing(dsTerceros) Then
            If dsTerceros.Tables.Count > 0 Then
                If dsTerceros.Tables(0).Rows.Count > 0 Then
                    CargarEvaluacionesFiltro(dsTerceros)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        End If
    End Sub

    Private Sub CargarEvaluacionesFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        Dgv_Persona.DataSource = Nothing
        Dgv_Persona.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.Persona
        AplicarFormatoColumnas()
        Dgv_Persona.ReadOnly = True
        Lb_CantidadReportes.Text = "Cantidad de Personas: " + DsTabla.Tables(0).Rows.Count.ToString
        If Dgv_Persona.RowCount > 0 Then
            Dgv_Persona.ClearSelection()
            Dgv_Persona.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Nbi_RegistrarContrato_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarContrato.ItemClick
        If tablaCargada = Tablas.Persona Then
            'Dim adaptador As SqlDataAdapter
            Dim dsMaestras As DataSet
            Dim Identificacion As String = Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Identificación").Value
            comando = New SqlCommand("dbo.GestionarAccesosISMOCOL", conexion) With {.CommandType = CommandType.StoredProcedure}
            comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
            comando.Parameters.Add("@ACCESODENEGADO", SqlDbType.Char)
            comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
            comando.Parameters.Add("@IDENTIFICACION", SqlDbType.NVarChar, 15)
            comando.Parameters.Add("@TIPOMODULO", SqlDbType.NChar, 1)
            comando.Parameters.Add("@TIPOOBSERVACION", SqlDbType.Char)
            comando.Parameters.Add("@OBSERVACION", SqlDbType.NVarChar, 300)
            comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)

            comando.Parameters("@Accion").Value = 1
            comando.Parameters("@ACCESODENEGADO").Value = ""
            comando.Parameters("@IDPERSONA").Value = -1
            comando.Parameters("@IDENTIFICACION").Value = Replace(Identificacion, ".", "")
            comando.Parameters("@TIPOMODULO").Value = "C"
            comando.Parameters("@TIPOOBSERVACION").Value = ""
            comando.Parameters("@OBSERVACION").Value = ""
            comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona

            comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})

            adaptador = New SqlDataAdapter(comando)
            dsMaestras = New DataSet
            Try
                conexion.Open()
                adaptador.Fill(dsMaestras)
                conexion.Close()

                If comando.Parameters("@IDMENSAJE").Value = 1 Then
                    Dim fila As DataRow
                    fila = dsMaestras.Tables(0).Rows(0)

                    If fila("ACCESODENEGADO") = "S" Then
                        MessageBox.Show("Esta persona tiene el acceso denegado.", "Estado Ismocol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error al carlos los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try

            Dim idPersona As Integer = -1
            idPersona = Dgv_Persona.SelectedRows(0).Cells("Id").Value
            If idPersona > 0 Then
                Dim Comando1 As New SqlClient.SqlCommand("dbo.VerificarConceptoParaContratar")
                Comando1.CommandType = CommandType.StoredProcedure
                Comando1.Parameters.AddWithValue("@IDPERSONA", idPersona)
                Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                msgParam.Direction = ParameterDirection.Output
                Comando1.Parameters.Add(msgParam)
                Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                Try
                    conn.Open()
                    Comando1.Connection = conn
                    Comando1.ExecuteNonQuery()
                    conn.Close()
                    idconcepto = Comando1.Parameters("@IDMENSAJE").Value
                    Select Case idconcepto
                        Case 0
                        Case 1 '
                            If MsgBox("El Candidato que va a Contratar no tiene Registro de Órdenes de Exámenes de Ingreso Recientes. ¿Desea Continuar?.", MsgBoxStyle.YesNo, "Conceptos  Médicos") = MsgBoxResult.Yes Then
                            Else
                                Exit Sub
                            End If
                        Case 2 '
                            MessageBox.Show("El Candidato que va a Contratar tiene Órdenes de Exámenes de ingreso pendientes por asignar Concepto Médico. En caso de requerir ayuda deberá comunicarse con Administración Bucaramanga, para recibir indicaciones al respecto.", "Conceptos  Médicos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        Case 3  ' 
                            MessageBox.Show("El Candidato que va a Contratar tiene uno o más Conceptos Médicos Recientes con indicación de ''No Continuar el Proceso''. En caso de requerir ayuda deberá comunicarse con Administración Bucaramanga, para recibir indicaciones al respecto.", "Conceptos  Médicos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        Case 4
                            If MsgBox("El Candidato tiene los Conceptos Médicos de ingreso con fechas superiores a siete (07) días, se debe verificar la vigencia de los Exámenes. ¿Desea continuar?", MsgBoxStyle.YesNo, "Conceptos  Médicos") = MsgBoxResult.Yes Then
                            Else
                                Exit Sub
                            End If
                    End Select
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
            If Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("VALIDO").Value = 0 Then
                MessageBox.Show("Esta persona no tiene la información personal completa, por favor revisar antes de contratar.", "Información personal incompleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            'Si aun no se le han registrado contratos o no tiene contratos activos.
            If IsDBNull(Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Contrato").Value) OrElse _
                Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Estado Contrato").Value = "T" OrElse _
                Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Estado Contrato").Value = "N" Then
                Dim FrContratar As New FormularioContrato.Fr_Contratar
                FrContratar.IdPersonaContratar = Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Id").Value
                FrContratar.Label_Nombre.Text = "NOMBRE: " + Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Nombre").Value
                FrContratar.Label_Cedula.Text = "IDENTIFICACION: " + Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Identificación").Value
                Select Case idconcepto
                    Case 0
                    Case 1 '
                        FrContratar.Tx_Observación.Text = "El trabajador fue vinculado sin examen médico de ingreso reciente"
                    Case 2 '
                    Case 3  ' 
                    Case 4 '
                        FrContratar.Tx_Observación.Text = "El trabajador fue vinculado con un concepto médico superior a siete (07) días"
                End Select
                FrContratar.Cargar_Tablas()
                FrContratar.TipoAccion = "I"
                FrContratar.ShowDialog()
                If FrContratar.Guardado Then
                    Cargar_Personas()
                End If
            Else
                Select Case Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Estado Contrato").Value
                    Case "A"
                        MessageBox.Show("Esta persona tiene un contrato activo.", "Contrato activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Case "E"
                        MessageBox.Show("Esta persona tiene un contrato extendido.", "Contrato extendido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Case "I"
                        MessageBox.Show("Esta persona tiene un contrato inactivo.", "Contrato inactivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Case "S"
                        MessageBox.Show("Esta persona tiene un contrato suspendido.", "Contrato suspendido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Select
            End If
        Else
            MessageBox.Show("Cargue el listado de Personal")
        End If
    End Sub

    Private Sub Nbi_ImprimirFormatos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirFormatos.ItemClick
        If tablaCargada = Tablas.Persona Then
            Try
                Dim FrImprimirFormatos As New ImprimirRecursoHumano.Fr_ImprimirFormatos
                FrImprimirFormatos.IDPERSONA = Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Id").Value
                FrImprimirFormatos.CODIGOTIPO = -1
                FrImprimirFormatos.IDBASE = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                FrImprimirFormatos.IDCONTRATO = -1
                FrImprimirFormatos.cargarformatos()
                FrImprimirFormatos.Label1.Visible = True
                FrImprimirFormatos.ComboBox_Cargo_Desempeña.Visible = True
                FrImprimirFormatos.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Imprimir formatos requerimiento", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Cargue el listado de Personal")
        End If
    End Sub

    Private Sub Nbi_RegistrarPersonaBásico_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarPersonaBásico.ItemClick
        RegistrarPersona()
    End Sub

    Private Sub RegistrarPersona()
        Dim FrPersona As New Fr_PersonaBasico
        FrPersona.Cargar_Tablas()
        FrPersona.Show()
        If FrPersona.Guardado Then
            Cargar_Personas()
        End If
    End Sub

    Private Sub Nbi_EditarPersonaBasico_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarPersonaBasico.ItemClick
        If tablaCargada = Tablas.Persona Then
            Dim FrPersona As New Fr_PersonaBasico
            FrPersona.Editando = True
            FrPersona.IdPersonaEditando = Dgv_Persona.SelectedRows(0).Cells("Id").Value
            FrPersona.Cargar_Tablas()
            FrPersona.CargarDatosPersona()
            FrPersona.ShowDialog()
            If FrPersona.Guardado Then
                Cargar_Personas()
            End If
        Else
            MessageBox.Show("Cargue el listado de Personal")
        End If
    End Sub

    Private Sub Nbi_SubirValidacionHDeVida_ItemClick(sender As Object, e As EventArgs) Handles Nbi_SubirValidacionHDeVida.ItemClick

        If Me.Dgv_Persona.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.Dgv_Persona.CurrentCell.RowIndex
            Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
            Dim PuedeSubir As Boolean = False
            Dim Tipo As Integer = 0
            Dim IdDocumento As String = ""
            Dim NombreDocumento As String = ""
            Dim AñoDocumento As String = ""
            Dim SubidoNube As String = ""
            Dim Actualizar As Boolean = False
          
            If tablaCargada <> Tablas.Persona Then
                MsgBox("Cargue el listado de Personal", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            Tipo = 2
            NombreDocumento = Trim(Me.Dgv_Persona.Item("Identificación", Index_Registro_Actual).Value.ToString)
            NombreDocumento = NombreDocumento.Replace(".", "")
            SubidoNube = Me.Dgv_Persona.Item("Servidor", Index_Registro_Actual).Value.ToString
            If SubidoNube = "S" Then
                Actualizar = True
            Else
                Actualizar = False
            End If

            Dim Subido As Boolean = False

            If Tipo = 2 Then
                Subido = GoogleDrive.SubirArchivoSinSubCarpeta(Tipo, NombreDocumento, "")
            Else
                Exit Sub
            End If
            If Subido Then
                MarcarSubidoServidor(Dgv_Persona.SelectedRows(0).Cells(0).Value)
                MsgBox("Archivo subido", MsgBoxStyle.Information, "Archivo subido")
                Cargar_Personas()
            Else
                MsgBox("No se subio el archivo", MsgBoxStyle.Critical, "Error")
                Cursor.Current = Cursors.Default
            End If
        End If
    End Sub

    Private Sub MarcarSubidoServidor(idPersona As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.MarcarSubidoServidor_HojaDeVida", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDPERSONA", idPersona)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Function existeObjeto(dir As String, user As String, pass As String) As Boolean
        Dim peticionFTP As FtpWebRequest
        ' Creamos una petición FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp
        peticionFTP.UsePassive = False
        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            Return True
        Catch
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function

    Private Sub Nbi_VerValidacionHDeVida_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerValidacionHDeVida.ItemClick
        If Me.Dgv_Persona.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.Dgv_Persona.CurrentCell.RowIndex
            Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
            Dim PuedeVer As Boolean = False
            Dim NombreDocumento As String = ""
            Dim AñoDocumento As String = ""
            Dim SubidoNube As String = ""
            Dim Descargar As String = "ArchivosPDF"
            Dim CarpetaDrive As String = ""

            If tablaCargada <> Tablas.Persona Then
                MsgBox("Cargue el listado de Personal", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            NombreDocumento = Trim(Me.Dgv_Persona.Item("Identificación", Index_Registro_Actual).Value.ToString)
            NombreDocumento = NombreDocumento.Replace(".", "")
            SubidoNube = Me.Dgv_Persona.Item("Servidor", Index_Registro_Actual).Value.ToString
            CarpetaDrive = "Pruebas"


            If SubidoNube = "S" Then
                GoogleDrive.DescargarArchivosSinSubCarpeta(NombreDocumento + ".pdf", CarpetaDrive)
            End If
        End If
    End Sub

#End Region 'Persona

#Region "Examenes"
    Private Sub Nbi_ListarExamenes_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarExamenes.ItemClick
        Cargar_Examenes()
    End Sub

    Private Sub Cargar_Examenes()
        Cursor.Current = Cursors.WaitCursor
        dsTerceros = bddatos.BusquedaCondiciones(37, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        If Not IsNothing(dsTerceros) Then
            If dsTerceros.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
                dsTerceros.Tables.Remove(dsTerceros.Tables(0).TableName) 'Borrar la tabla del conteo.
            Else 'Si solo trae el conteo es porque se exceden los campos.
                MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsTerceros.Clear()
            End If
            tablaCargada = Tablas.Examenes
            Dgv_Persona.DataSource = Nothing
            Dgv_Persona.DataSource = dsTerceros.Tables(0)
            AplicarFormatoColumnas()
            Lb_CantidadReportes.Text = "Cantidad de Exámenes: " & dsTerceros.Tables(0).Rows.Count
            If Dgv_Persona.RowCount > 0 Then
                Dgv_Persona.ClearSelection()
                Dgv_Persona.Rows(0).Selected = True
            End If
        Else
            Dgv_Persona.DataSource = Nothing
            Lb_CantidadReportes.Text = "Cantidad de Exámenes: 0"
        End If
        Cursor.Current = Cursors.Default
    End Sub

    'Crear un nuevo envío a exámenes.
    Private Sub Nbi_EnviarAExamenes_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EnviarAExamenes.ItemClick
        If Dgv_Persona.SelectedRows.Count > 0 Then
            Dim idPersona As Integer = -1
            Dim Identificacion As String
            Dim dsMaestras As DataSet
            Select Case tablaCargada
                Case Tablas.Persona
                    idPersona = Dgv_Persona.SelectedRows(0).Cells("Id").Value
                    Identificacion = Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Identificación").Value
                Case Tablas.Examenes
                    idPersona = Dgv_Persona.SelectedRows(0).Cells("IDPERSONA").Value
                    Identificacion = Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("IDENTIFICACION").Value
                Case Else
                    MessageBox.Show("Cargue el listado de personal o de exámanes.")
                    Exit Sub
            End Select
            comando = New SqlCommand("dbo.GestionarAccesosISMOCOL", conexion) With {.CommandType = CommandType.StoredProcedure}
            comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
            comando.Parameters.Add("@ACCESODENEGADO", SqlDbType.Char)
            comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
            comando.Parameters.Add("@IDENTIFICACION", SqlDbType.NVarChar, 15)
            comando.Parameters.Add("@TIPOMODULO", SqlDbType.NChar, 1)
            comando.Parameters.Add("@TIPOOBSERVACION", SqlDbType.Char)
            comando.Parameters.Add("@OBSERVACION", SqlDbType.NVarChar, 300)
            comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)

            comando.Parameters("@Accion").Value = 1
            comando.Parameters("@ACCESODENEGADO").Value = ""
            comando.Parameters("@IDPERSONA").Value = -1
            comando.Parameters("@IDENTIFICACION").Value = Replace(Identificacion, ".", "")
            comando.Parameters("@TIPOMODULO").Value = "E"
            comando.Parameters("@TIPOOBSERVACION").Value = ""
            comando.Parameters("@OBSERVACION").Value = ""
            comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona

            comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})

            adaptador = New SqlDataAdapter(comando)
            dsMaestras = New DataSet
            Try
                conexion.Open()
                adaptador.Fill(dsMaestras)
                conexion.Close()

                If comando.Parameters("@IDMENSAJE").Value = 1 Then
                    Dim fila As DataRow
                    fila = dsMaestras.Tables(0).Rows(0)

                    If fila("ACCESODENEGADO") = "S" Then
                        MessageBox.Show("Esta persona tiene el acceso denegado.", "Estado Ismocol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error al carlos los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try

            Dim dtPendientes = ExamenesPendientesConcepto(idPersona)
            If Not IsNothing(dtPendientes) Then
                If dtPendientes.Rows.Count = 0 Then
                    Dim FrImprimirExamenes As New Fr_ImprimirExamenes
                    FrImprimirExamenes.TipoAccion = Fr_ImprimirExamenes.Accion.Crear
                    FrImprimirExamenes.IdPersona = idPersona
                    FrImprimirExamenes.ShowDialog()
                    If FrImprimirExamenes.Guardado Then
                        Cargar_Examenes()
                    End If
                Else
                    Dim frExamenesPendientesConcepto As New Fr_ExamenesPendientesConcepto
                    Select Case tablaCargada
                        Case Tablas.Persona
                            frExamenesPendientesConcepto.IdPersona = Dgv_Persona.SelectedRows(0).Cells("Id").Value
                            frExamenesPendientesConcepto.Identificacion = Dgv_Persona.SelectedRows(0).Cells("Identificación").Value
                            frExamenesPendientesConcepto.Nombre = Dgv_Persona.SelectedRows(0).Cells("Nombre").Value
                        Case Tablas.Examenes
                            frExamenesPendientesConcepto.IdPersona = Dgv_Persona.SelectedRows(0).Cells("IDPERSONA").Value
                            frExamenesPendientesConcepto.Identificacion = Dgv_Persona.SelectedRows(0).Cells("IDENTIFICACION").Value
                            frExamenesPendientesConcepto.Nombre = Dgv_Persona.SelectedRows(0).Cells("NOMBRE").Value
                        Case Else
                            MessageBox.Show("Cargue el listado de personal o de exámanes.")
                            Exit Sub
                    End Select

                    frExamenesPendientesConcepto.ShowDialog()

                    'MessageBox.Show("El examen con consecutivo " & dtPendientes.Compute("MAX([IDENVIOEXAMEN])", String.Empty) & " está pendiente por registro de concepto médico.", "Exámenes pendientes por concepto médico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("No se cargaron los datos de exámenes.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Seleccione una fila para realizar la operación.")
        End If
    End Sub

    Private Function ExamenesPendientesConcepto(idPersona As Integer) As DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ExamenesPendientesConcepto(@IDPERSONA)", conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", idPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtPendientes As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtPendientes)
            Return dtPendientes
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function

    'Agregar concepto médico al examen.
    Private Sub Nbi_ConceptoMedico_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ConceptoMedico.ItemClick
        If tablaCargada = Tablas.Examenes Then
            If Dgv_Persona.SelectedRows.Count > 0 Then
                If Trim(Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("CONCEPTOMEDICO").Value) = "" Then
                    If Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Idbase").Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                        If Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("FECHAENVIO").Value < Date.Now Then
                            Dim FrImprimirExamenes As New Fr_ImprimirExamenes
                            FrImprimirExamenes.TipoAccion = Fr_ImprimirExamenes.Accion.AgregarConcepto
                            FrImprimirExamenes.IdPersona = Dgv_Persona.SelectedRows(0).Cells("IDPERSONA").Value
                            FrImprimirExamenes.IdEnvioExamen = Dgv_Persona.SelectedRows(0).Cells("IDENVIOEXAMEN").Value
                            FrImprimirExamenes.ShowDialog()
                            If FrImprimirExamenes.Guardado Then
                                Cargar_Examenes()
                            End If
                        Else
                            MsgBox("La fecha de envio de estos examenes es posterior a la fecha actual, revisar las fechas antes de continuar", MsgBoxStyle.Information, "Concepto Médico")
                        End If
                    Else
                        MsgBox("Esta persona pertenece a otra base y no puede agregarle el concepto.", MsgBoxStyle.Information, "Concepto Médico")
                    End If
                Else
                    MsgBox("Esta persona ya tiene el concepto.", MsgBoxStyle.Information, "Concepto Médico")
                End If
            End If
        Else
            MessageBox.Show("Cargue el listado de Exámenes")
        End If
    End Sub

    Private Sub Nbi_VerExamen_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerExamen.ItemClick
        VerExamen()
    End Sub

    Private Sub VerExamen()
        If tablaCargada = Tablas.Examenes Then
            If Dgv_Persona.SelectedRows.Count > 0 Then
                Dim FrImprimirExamenes As New Fr_ImprimirExamenes
                FrImprimirExamenes.TipoAccion = Fr_ImprimirExamenes.Accion.Ver
                FrImprimirExamenes.IdPersona = Dgv_Persona.SelectedRows(0).Cells("IDPERSONA").Value
                FrImprimirExamenes.IdEnvioExamen = Dgv_Persona.SelectedRows(0).Cells("IDENVIOEXAMEN").Value
                FrImprimirExamenes.ShowDialog()
            End If
        Else
            MessageBox.Show("Cargue el listado de Exámenes")
        End If
    End Sub

    Private Sub Nbi_BuscarExamenes_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarExamenes.ItemClick
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("EE.FECHAENVIO", "Fecha envío", "3")
        campos.Rows.Add("P.IDENTIFICACION", "Número de identificación (sin puntos)", "2")
        campos.Rows.Add("2", "Nombre", "7")
        campos.Rows.Add("EE.IDENVIOEXAMEN", "Consecutivo envío", "2")
        campos.Rows.Add("3", "Pendiente Concepto x Base", "4")
        frbuscar.campos = campos
        frbuscar.tabla = 37 ' Envíos a Exámenes Preocupacionales
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsTerceros = DSbusqueda
        Try
            If dsTerceros.Tables.Count > 0 Then
                If dsTerceros.Tables(0).Rows.Count > 0 Then
                    CargarExamenesFiltro(DSbusqueda)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarExamenesFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        Dgv_Persona.DataSource = Nothing
        Dgv_Persona.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.Examenes
        AplicarFormatoColumnas()
        Dgv_Persona.ReadOnly = True
        Lb_CantidadReportes.Text = "Cantidad de Exámenes: " & DsTabla.Tables(0).Rows.Count
        If Dgv_Persona.RowCount > 0 Then
            Dgv_Persona.ClearSelection()
            Dgv_Persona.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

    'Reimpresión de exámenes (editar examen)
    Private Sub Nbi_ImprimirExamenes_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirExamenes.ItemClick
        If tablaCargada = Tablas.Examenes Then
            If Dgv_Persona.SelectedRows.Count > 0 Then
                If IsDBNull(Dgv_Persona.SelectedRows(0).Cells("CONCEPTOMEDICO").Value) OrElse Trim(Dgv_Persona.SelectedRows(0).Cells("CONCEPTOMEDICO").Value) = "" Then
                    Dim FrImprimirExamenes As New Fr_ImprimirExamenes
                    FrImprimirExamenes.TipoAccion = Fr_ImprimirExamenes.Accion.Reimprimir
                    FrImprimirExamenes.IdPersona = Dgv_Persona.SelectedRows(0).Cells("IDPERSONA").Value
                    FrImprimirExamenes.IdEnvioExamen = Dgv_Persona.SelectedRows(0).Cells("IDENVIOEXAMEN").Value
                    FrImprimirExamenes.ShowDialog()
                    If FrImprimirExamenes.Guardado Then
                        Cargar_Examenes()
                    End If
                Else
                    MessageBox.Show("Ya se emitió el concepto médico para este envío a exámenes.", "Envío ya tiene concepto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Else
            MessageBox.Show("Cargue el listado de Exámenes")
        End If
    End Sub

    '
    ' Encuestas
    '
    Private Sub Nbi_CargarEncuestas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarEncuestas.ItemClick
        Cargar_Encuestas()
    End Sub

    Private Sub Cargar_Encuestas()
        Cursor.Current = Cursors.WaitCursor
        dsTerceros = bddatos.BusquedaCondiciones(42, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        If Not IsNothing(dsTerceros) Then
            If dsTerceros.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
                dsTerceros.Tables.Remove(dsTerceros.Tables(0).TableName) 'Borrar la tabla del conteo.
            Else 'Si solo trae el conteo es porque se exceden los campos.
                MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsTerceros.Clear()
            End If
            tablaCargada = Tablas.Encuestas
            Dgv_Persona.DataSource = Nothing
            Dgv_Persona.DataSource = dsTerceros.Tables(0)
            AplicarFormatoColumnas()
            Lb_CantidadReportes.Text = "Cantidad de Encuestas: " & dsTerceros.Tables(0).Rows.Count
            If Dgv_Persona.RowCount > 0 Then
                Dgv_Persona.ClearSelection()
                Dgv_Persona.Rows(0).Selected = True
            End If
        Else
            Dgv_Persona.DataSource = Nothing
            Lb_CantidadReportes.Text = "Cantidad de Encuestas: 0"
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Nbi_CrearEncuesta_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearEncuesta.ItemClick
        Try
            If Dgv_Persona.SelectedRows.Count > 0 Then
                Dim idPersona As Integer = -1
                Select Case tablaCargada
                    Case Tablas.Persona
                        idPersona = Dgv_Persona.SelectedRows(0).Cells("Id").Value
                    Case Tablas.Encuestas
                        idPersona = Dgv_Persona.SelectedRows(0).Cells("IdP").Value
                    Case Else
                        MessageBox.Show("Cargue el listado de personal o de encuestas.")
                        Exit Sub
                End Select
                Dim FrEncuesta As New Fr_Encuesta
                FrEncuesta.TipoAccion = Fr_Encuesta.Accion.Crear
                FrEncuesta.IdPersona = idPersona
                FrEncuesta.CargarDatos()
                FrEncuesta.ShowDialog()
                Cargar_Encuestas()
            Else
                MessageBox.Show("Seleccione una fila para realizar la operación.")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Nbi_EditarEncuesta_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarEncuesta.ItemClick
        If tablaCargada = Tablas.Encuestas Then
            If Dgv_Persona.SelectedRows.Count > 0 Then
                If Dgv_Persona.SelectedRows(0).Cells("IDUSUARIOREGISTRO").Value = VariablesBase.VariablesBase.IdPersona Then
                    Dim FrEncuesta As New Fr_Encuesta
                    FrEncuesta.TipoAccion = Fr_Encuesta.Accion.Editar
                    FrEncuesta.IdPersona = Dgv_Persona.SelectedRows(0).Cells("IdP").Value
                    FrEncuesta.IdEncuesta = Dgv_Persona.SelectedRows(0).Cells("IdE").Value
                    FrEncuesta.CargarDatos()
                    FrEncuesta.ShowDialog()
                Else
                    MessageBox.Show("Solo el usuario que ingreso la encuesta la puede modificar", "Usuario no valido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Else
            MessageBox.Show("Cargue el listado de Encuestas")
        End If
    End Sub

    Private Sub Nbi_BuscarEncuesta_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarEncuesta.ItemClick
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'campos.Rows.Add("DME.FECHAENCUESTA", "Fecha de encuesta", "3")
        campos.Rows.Add("DME.FECHARESPONDE", "Fecha respuesta", "3")
        campos.Rows.Add("P.IDENTIFICACION", "Número de identificación (sin puntos)", "2")
        campos.Rows.Add("2", "Nombre", "7")
        campos.Rows.Add("5", "Pendientes de Autorizar por Base", "7")
        campos.Rows.Add("3", "Autorizado médico", "4")
        campos.Rows.Add("4", "Eliminadas", "4")
        'campos.Rows.Add("6", "Entre Fechas por Base Actual", "3")
        frbuscar.campos = campos
        frbuscar.tabla = 42 'Encuestas
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsTerceros = DSbusqueda
        Try
            If dsTerceros.Tables.Count > 0 Then
                If dsTerceros.Tables(0).Rows.Count > 0 Then
                    CargarEncuestasFiltro(DSbusqueda)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarEncuestasFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        Dgv_Persona.DataSource = Nothing
        Dgv_Persona.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.Encuestas
        AplicarFormatoColumnas()
        Dgv_Persona.ReadOnly = True
        Lb_CantidadReportes.Text = "Cantidad de Encuestas: " & DsTabla.Tables(0).Rows.Count
        If Dgv_Persona.RowCount > 0 Then
            Dgv_Persona.ClearSelection()
            Dgv_Persona.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Nbi_CancelarEncuesta_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CancelarEncuesta.ItemClick
        If tablaCargada = Tablas.Encuestas Then
            If Dgv_Persona.SelectedRows.Count > 0 Then
                If Dgv_Persona.SelectedRows(0).Cells("IDUSUARIOREGISTRO").Value = VariablesBase.VariablesBase.IdPersona Then
                    If MsgBox("¿Seguro que desea cancelar la encuesta seleccionada?, esta encuesta es realiza a: " + Dgv_Persona.SelectedRows(0).Cells("NOMBRE").Value + ".", MsgBoxStyle.YesNo, "¿Cancelar?") = MsgBoxResult.Yes Then
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

                        comando.Parameters("@ACCION").Value = 4
                        comando.Parameters("@ID_DM_ENCUESTA").Value = Dgv_Persona.SelectedRows(0).Cells("IdE").Value()
                        comando.Parameters("@FECHAENCUESTA").Value = DBNull.Value
                        comando.Parameters("@CLAVEACCESOWEB").Value = DBNull.Value
                        comando.Parameters("@IDPERSONA").Value = DBNull.Value
                        comando.Parameters("@PROYECTO").Value = DBNull.Value
                        comando.Parameters("@IDBASESISCONTROL").Value = DBNull.Value
                        comando.Parameters("@EDAD").Value = DBNull.Value
                        comando.Parameters("@NOMBRETIPOCARGO").Value = DBNull.Value

                        comando.Parameters("@RESPUESTA1").Value = DBNull.Value
                        comando.Parameters("@RESPUESTA2").Value = DBNull.Value
                        comando.Parameters("@RESPUESTA3").Value = DBNull.Value
                        comando.Parameters("@RESPUESTA4").Value = DBNull.Value
                        comando.Parameters("@RESPUESTA5").Value = DBNull.Value
                        comando.Parameters("@RESPUESTA6").Value = DBNull.Value
                        comando.Parameters("@RESPUESTA7").Value = DBNull.Value
                        comando.Parameters("@RESPUESTA8").Value = DBNull.Value
                        comando.Parameters("@RESPUESTA9").Value = DBNull.Value
                        comando.Parameters("@RESPUESTA10").Value = DBNull.Value
                        comando.Parameters("@CORREOELECTRONICO").Value = DBNull.Value
                        comando.Parameters("@IDPERSONARESPONDE").Value = DBNull.Value
                        comando.Parameters("@FECHARESPONDE").Value = DBNull.Value
                        comando.Parameters("@LLENOVIAWEB").Value = DBNull.Value
                        comando.Parameters("@AUTORIZADOMEDICO").Value = DBNull.Value
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
                            MsgBox("Se cancelo la encuesta correctamente", MsgBoxStyle.Information, "Guardado")
                            Cargar_Encuestas()
                        Catch ex As Exception
                            MessageBox.Show("Error al guardar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            conexion.Close()
                        End Try
                    End If
                Else
                    MessageBox.Show("Solo el usuario que ingreso la encuesta la puede cancelar", "Usuario no valido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Else
            MessageBox.Show("Cargue el listado de Encuestas")
        End If
    End Sub

    Private Sub Nbi_ImprimirEncuesta_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirEncuesta.ItemClick
        If Me.Dgv_Persona.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        If tablaCargada = Tablas.Encuestas Then
            Dim climpresion As New ImprimirRecursoHumano.Cl_Impresión
            Dim Array As New ArrayList
            climpresion.Idpersona = Dgv_Persona.SelectedRows(0).Cells("IdP").Value
            Array.Add(73)
            If Array.Count > 0 Then
                climpresion.FormatosImprimir(Array, True)
            End If
        Else
            MessageBox.Show("Cargue el listado de Encuestas")
        End If
    End Sub

#End Region 'Exámenes

#Region "Calificaciones"
    Private Sub Nbi_CargarCalificaciones_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarCalificaciones.ItemClick
        Cargar_Calificaciones()
    End Sub

    Private Sub Cargar_Calificaciones()
        Cursor.Current = Cursors.WaitCursor
        dsCalificaciones = bddatos.BusquedaCondiciones(39, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        If Not IsNothing(dsCalificaciones) Then
            If dsCalificaciones.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
                dsCalificaciones.Tables.Remove(dsCalificaciones.Tables(0).TableName) 'Borrar la tabla del conteo.
            Else 'Si solo trae el conteo es porque se exceden los campos.
                MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsCalificaciones.Clear()
            End If
            tablaCargada = Tablas.Calificaciones
            Dgv_Persona.DataSource = Nothing
            Dgv_Persona.DataSource = dsCalificaciones.Tables(0)
            AplicarFormatoColumnas()
            Lb_CantidadReportes.Text = "Cantidad de Calificaciones: " & dsCalificaciones.Tables(0).Rows.Count
            If Dgv_Persona.RowCount > 0 Then
                Dgv_Persona.ClearSelection()
                Dgv_Persona.Rows(0).Selected = True
            End If
        Else
            Dgv_Persona.DataSource = Nothing
            Lb_CantidadReportes.Text = "Cantidad de Calificaciones: 0"
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Nbi_AgregarCalificación_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AgregarCalificación.ItemClick
        If tablaCargada = Tablas.Persona Or tablaCargada = Tablas.Calificaciones Then
            Dim FrAgregarCalificación As New Fr_AgregarCalificación
            FrAgregarCalificación.IdPersona = Dgv_Persona.SelectedRows(0).Cells("Id").Value
            FrAgregarCalificación.Editando = False
            FrAgregarCalificación.Cargar_Tablas()
            FrAgregarCalificación.Show()
        Else
            MessageBox.Show("Cargue el listado de Personal o calificaciones")
        End If
    End Sub


    Private Sub Nbi_GestionarCalificaciones_ItemClick(sender As Object, e As EventArgs) Handles Nbi_GestionarCalificaciones.ItemClick
        If tablaCargada = Tablas.Persona Or tablaCargada = Tablas.Calificaciones Then
            Dim FrGestionarCalificaciones As New Fr_GestionarCalificaciones
            FrGestionarCalificaciones.IdPersona = Dgv_Persona.SelectedRows(0).Cells("Id").Value
            FrGestionarCalificaciones.Cargar_Tablas()
            FrGestionarCalificaciones.Show()
        Else
            MessageBox.Show("Cargue el listado de Personal o calificaciones")
        End If
    End Sub

    Private Sub Nbi_ProgramarCalificaciones_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ProgramarCapacitaciones.ItemClick
        If tablaCargada = Tablas.Persona Or tablaCargada = Tablas.Calificaciones Then
            Dim dr As DialogResult
            Dim frProgramarCapacitaciones As New Fr_ProgramarCapacitaciones
            dr = frProgramarCapacitaciones.ShowDialog()
            If dr = DialogResult.OK Then
                Cargar_Calificaciones()
            End If
        Else
            MessageBox.Show("Cargue el listado de Personal o calificaciones")
        End If
    End Sub

    Private Sub Nbi_ImprimirCarnet_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirCarnet.ItemClick
        If tablaCargada = Tablas.Persona Or tablaCargada = Tablas.Calificaciones Then
            'validar que la persona tenga contrato activo y traer el contrato para impresión
            Dim idpersona As Integer
            idpersona = Dgv_Persona.SelectedRows(0).Cells("Id").Value
            Dim idcontrato As Integer
            idcontrato = FuncionesBase.FuncionesBase.CONSULTARULTIMOCONTRATOACTIVOXIDPERSONA(idpersona)
            Dim imprimir As New ImprimirRecursoHumano.Cl_Impresión
            Dim arrayDocs As New ArrayList
            imprimir.Idpersona = idpersona
            imprimir.IdContrato = idcontrato
            imprimir.IdBase = VariablesBase.VariablesBase.IdBaseSiscontrolActual
            arrayDocs.Add(69)
            imprimir.FormatosImprimir(arrayDocs, True, False)
            If imprimir.ImpresionFinalizada Then
                MessageBox.Show("Impresión finalizada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Cargue el listado de Personal o calificaciones")
        End If
    End Sub

    Private Sub Nbi_BuscarCalificacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarCalificacion.ItemClick
        BuscarCalificacion()
    End Sub

    Private Sub BuscarCalificacion()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("P.IDENTIFICACION", "Identificación (sin puntos)", "2")
        campos.Rows.Add("1", "Nombre", "7")
        campos.Rows.Add("C.CODIGOCONTRATO", "Código Contrato", "2")
        campos.Rows.Add("CP.TITULO", "Título del Curso", "1")
        campos.Rows.Add("AC.NOMBREACTIVIDADCAPACITACION", "Actividad del Curso", "1")
        campos.Rows.Add("CP.FECHACERTIFICACIONEXTERNA", "Fecha Certificación Externa", "3")
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de calificación registrada en SIGMA"
        frbuscar.tabla = 39 ' Calificaciones
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsCalificaciones = DSbusqueda
        If Not IsNothing(dsCalificaciones) Then
            If dsCalificaciones.Tables.Count > 0 Then
                If dsCalificaciones.Tables(0).Rows.Count > 0 Then
                    CargarCalificacionesFiltro(DSbusqueda)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        End If
    End Sub

    Private Sub CargarCalificacionesFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        Dgv_Persona.DataSource = Nothing
        Dgv_Persona.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.Calificaciones
        AplicarFormatoColumnas()
        Dgv_Persona.ReadOnly = True
        Lb_CantidadReportes.Text = "Cantidad de Calificaciones: " + DsTabla.Tables(0).Rows.Count.ToString
        If Dgv_Persona.RowCount > 0 Then
            Dgv_Persona.ClearSelection()
            Dgv_Persona.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CargarCalificacionesXPersona()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM ListaCalificacionesXpersona(@IDPERSONA)", conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", Dgv_Persona.SelectedRows(0).Cells("Id").Value)
        Dim adaptador As New SqlDataAdapter(comando)
        dtCalificacion.Clear()
        Try
            conexion.Open()
            adaptador.Fill(dtCalificacion)
            conexion.Close()
            Me.Dgv_Calificaciones.DataSource = dtCalificacion
            Me.Lb_CantidadCalificaciones.Text = "Lista de Calificaciones Asociadas a la Persona: " + Dgv_Calificaciones.RowCount.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
        AplicarFormatoColumnasCalificaciones()
    End Sub

    Private Sub AplicarFormatoColumnasCalificaciones()
        For i = 0 To Dgv_Calificaciones.ColumnCount - 1
            Select Case Dgv_Calificaciones.Columns(i).Name
                Case "Actividad"
                    Dgv_Calificaciones.Columns(i).Width = 350
                    Dgv_Calificaciones.Columns(i).ToolTipText = "Actividad"
                    Dgv_Calificaciones.Columns(i).HeaderText = "Actividad"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Fecha Teorica"
                    Dgv_Calificaciones.Columns(i).Width = 80
                    Dgv_Calificaciones.Columns(i).ToolTipText = "Fecha Prueba Teorica"
                    Dgv_Calificaciones.Columns(i).HeaderText = "FPT"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Calificacion Teorica"
                    Dgv_Calificaciones.Columns(i).Width = 40
                    Dgv_Calificaciones.Columns(i).ToolTipText = "Calificación Prueba Teorica"
                    Dgv_Calificaciones.Columns(i).HeaderText = "CPT"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "Fecha Practica"
                    Dgv_Calificaciones.Columns(i).Width = 80
                    Dgv_Calificaciones.Columns(i).ToolTipText = "Fecha Prueba Practica"
                    Dgv_Calificaciones.Columns(i).HeaderText = "FPP"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Calificacion practica"
                    Dgv_Calificaciones.Columns(i).Width = 40
                    Dgv_Calificaciones.Columns(i).ToolTipText = "Calificación Prueba Practica"
                    Dgv_Calificaciones.Columns(i).HeaderText = "CPP"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "Fecha Directa"
                    Dgv_Calificaciones.Columns(i).Width = 80
                    Dgv_Calificaciones.Columns(i).ToolTipText = "Fecha Calificación Directa"
                    Dgv_Calificaciones.Columns(i).HeaderText = "FCD"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Entidad certificadora"
                    Dgv_Calificaciones.Columns(i).Width = 200
                    Dgv_Calificaciones.Columns(i).HeaderText = "Entidad Certificadora"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Titulo"
                    Dgv_Calificaciones.Columns(i).Width = 250
                    Dgv_Calificaciones.Columns(i).HeaderText = "Titulo"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "No. Certificado"
                    Dgv_Calificaciones.Columns(i).Width = 100
                    Dgv_Calificaciones.Columns(i).ToolTipText = "No. Certificado"
                    Dgv_Calificaciones.Columns(i).HeaderText = "No. Certificado"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Fecha Externa"
                    Dgv_Calificaciones.Columns(i).Width = 80
                    Dgv_Calificaciones.Columns(i).ToolTipText = "Fecha Certificación Externa"
                    Dgv_Calificaciones.Columns(i).HeaderText = "FCE"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Fecha Hasta"
                    Dgv_Calificaciones.Columns(i).Width = 80
                    Dgv_Calificaciones.Columns(i).ToolTipText = "Fecha Validad Hasta"
                    Dgv_Calificaciones.Columns(i).HeaderText = "FVH"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Observacion"
                    Dgv_Calificaciones.Columns(i).Width = 280
                    Dgv_Calificaciones.Columns(i).ToolTipText = "Observación"
                    Dgv_Calificaciones.Columns(i).HeaderText = "Observación"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Fecha Programada"
                    Dgv_Calificaciones.Columns(i).Width = 80
                    Dgv_Calificaciones.Columns(i).ToolTipText = "Fecha Capacitación Programada"
                    Dgv_Calificaciones.Columns(i).HeaderText = "FP"
                    Dgv_Calificaciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    Dgv_Calificaciones.Columns(i).Visible = False
            End Select
        Next
    End Sub
#End Region 'Calificaciones


    Private Sub Cu_Persona_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, Dgv_Persona.KeyDown, Nbc_Persona.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BuscarPersona()
            Case Keys.F2
                RegistrarPersona()
            Case Keys.F4
                Cargar_Personas()
            Case Keys.F1
                FuncionesBase.FuncionesBase.AbrirAyudaOnline("/Inicio.aspx?MODULO=Personal")
            Case Keys.F6
                ExportarDatosExcel(Dgv_Persona)
        End Select
    End Sub

    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView)
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)

        With objHojaExcel
            .Name = ("Datos Exportados")
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 1
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, Dgv_Persona.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    Private Sub Cu_Persona_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.SplitContainer1.SplitterDistance = Me.Width * 0.75
        Catch ex As Exception

        End Try
    End Sub

#Region "Encuesta Covid 19"

    Private Sub Nbi_AutorizarIngreso_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AutorizarIngresoCOVID.ItemClick
        If tablaCargada = Tablas.Encuestas Then
            If Dgv_Persona.SelectedRows.Count > 0 Then
                If MsgBox("¿Seguro que desea autorizar el ingreso a ISMOCOL según la encuesta seleccionada?, esta encuesta es realiza a: " + Dgv_Persona.SelectedRows(0).Cells("NOMBRE").Value + ".", MsgBoxStyle.YesNo, "¿Cancelar?") = MsgBoxResult.Yes Then
                    comando = New SqlCommand("dbo.GestionarEncuesta", conexion) With {.CommandType = CommandType.StoredProcedure}
                    comando.Parameters.Add("@ACCION", SqlDbType.TinyInt)
                    comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
                    comando.Parameters.Add("@PROYECTO", SqlDbType.NVarChar, 50)
                    comando.Parameters.Add("@IDBASESISCONTROL", SqlDbType.Int)
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

                    comando.Parameters("@ACCION").Value = 5
                    comando.Parameters("@ID_DM_ENCUESTA").Value = Dgv_Persona.SelectedRows(0).Cells("IdE").Value()
                    comando.Parameters("@FECHAENCUESTA").Value = DBNull.Value
                    comando.Parameters("@CLAVEACCESOWEB").Value = DBNull.Value
                    comando.Parameters("@IDPERSONA").Value = DBNull.Value
                    comando.Parameters("@PROYECTO").Value = DBNull.Value
                    comando.Parameters("@IDBASESISCONTROL").Value = DBNull.Value
                    comando.Parameters("@EDAD").Value = DBNull.Value
                    comando.Parameters("@NOMBRETIPOCARGO").Value = DBNull.Value

                    comando.Parameters("@RESPUESTA1").Value = DBNull.Value
                    comando.Parameters("@RESPUESTA2").Value = DBNull.Value
                    comando.Parameters("@RESPUESTA3").Value = DBNull.Value
                    comando.Parameters("@RESPUESTA4").Value = DBNull.Value
                    comando.Parameters("@RESPUESTA5").Value = DBNull.Value
                    comando.Parameters("@RESPUESTA6").Value = DBNull.Value
                    comando.Parameters("@RESPUESTA7").Value = DBNull.Value
                    comando.Parameters("@RESPUESTA8").Value = DBNull.Value
                    comando.Parameters("@RESPUESTA9").Value = DBNull.Value
                    comando.Parameters("@RESPUESTA10").Value = DBNull.Value
                    comando.Parameters("@CORREOELECTRONICO").Value = DBNull.Value
                    comando.Parameters("@IDPERSONARESPONDE").Value = DBNull.Value
                    comando.Parameters("@FECHARESPONDE").Value = DBNull.Value
                    comando.Parameters("@LLENOVIAWEB").Value = DBNull.Value

                    comando.Parameters("@AUTORIZADOMEDICO").Value = "S"

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
                        MsgBox("Ingreso autorizado", MsgBoxStyle.Information, "Guardado")
                        Cargar_Encuestas()
                    Catch ex As Exception
                        MessageBox.Show("Error al guardar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        conexion.Close()
                    End Try
                End If
            End If
        Else
            MessageBox.Show("Cargue el listado de Encuestas")
        End If
    End Sub

    Private Sub Nbi_VerEncuestaCovid_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerEncuestaCovid.ItemClick
        VerEncuesta()
    End Sub

    Private Sub VerEncuesta()
        If tablaCargada = Tablas.Encuestas Then
            If Dgv_Persona.SelectedRows.Count > 0 Then
                Dim FrEncuesta As New Fr_Encuesta
                FrEncuesta.TipoAccion = Fr_Encuesta.Accion.Ver
                FrEncuesta.IdPersona = Dgv_Persona.SelectedRows(0).Cells("IdP").Value
                FrEncuesta.IdEncuesta = Dgv_Persona.SelectedRows(0).Cells("IdE").Value
                FrEncuesta.CargarDatos()
                FrEncuesta.ShowDialog()
            End If
        Else
            MessageBox.Show("Cargue el listado de Encuestas")
        End If
    End Sub

    Private Sub Nbi_AutorizarIngresoMultiple_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AutorizarIngresoMultiple.ItemClick
        Try
            If Dgv_Persona.SelectedRows.Count > 0 Then
                Dim idPersona As Integer = -1
                Select Case tablaCargada
                    Case Tablas.Encuestas
                        idPersona = Dgv_Persona.SelectedRows(0).Cells("IdP").Value
                    Case Else
                        MessageBox.Show("Cargue el listado de encuestas.")
                        Exit Sub
                End Select
                Dim FrAutorizarIngresoMultiple As New Fr_AutorizarIngresoMultiple
                FrAutorizarIngresoMultiple.IdPersona = idPersona
                FrAutorizarIngresoMultiple.CargarDatos()
                FrAutorizarIngresoMultiple.ShowDialog()
                Cargar_Encuestas()
            Else
                MessageBox.Show("Seleccione una fila para realizar la operación.")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Nbi_RegistrarTemperatura_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarTemperatura.ItemClick
        Try
            If Dgv_Persona.SelectedRows.Count > 0 Then
                Dim idPersona As Integer = -1
                Dim idEncuesta As Integer
                Dim fechaRegistro As DateTime
                Dim base As String
                Select Case tablaCargada
                    Case Tablas.Encuestas
                        idPersona = Dgv_Persona.SelectedRows(0).Cells("IdP").Value
                        idEncuesta = Dgv_Persona.SelectedRows(0).Cells("IdE").Value
                        fechaRegistro = Dgv_Persona.SelectedRows(0).Cells("FECHAREGISTRO").Value
                        base = Dgv_Persona.SelectedRows(0).Cells("NOMBREBASE").Value
                    Case Else
                        MessageBox.Show("Cargue el listado de encuestas.")
                        Exit Sub
                End Select
                Dim FrRegistrarTemperatura As New Fr_RegistrarTemperatura
                FrRegistrarTemperatura.IdPersona = idPersona
                FrRegistrarTemperatura.IdEncuesta = idEncuesta
                FrRegistrarTemperatura.FechaRegistro = fechaRegistro
                FrRegistrarTemperatura.Base = base
                FrRegistrarTemperatura.CargarDatos()
                FrRegistrarTemperatura.ShowDialog()
                Cargar_Encuestas()
            Else
                MessageBox.Show("Seleccione una fila para realizar la operación.")
            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region 'Encuesta Covid 19

#Region "Evaluación Desempeño"


    Private Sub Nbi_ListarEvaluacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarEvaluacion.ItemClick
        CargarEvaluacion()
    End Sub

    Public Sub CargarEvaluacion()
        Cursor.Current = Cursors.WaitCursor
        dsEvaluacion = bddatos.BusquedaCondiciones(53, 1, 4, 1, "", 0, Date.Now, Date.Now, 0, 50)
        If dsEvaluacion.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
            dsEvaluacion.Tables.Remove(dsEvaluacion.Tables(0).TableName) 'Borrar la tabla del conteo.
        Else 'Si solo trae el conteo es porque se exceden los campos.
            MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dsEvaluacion.Clear()
        End If
        tablaCargada = Tablas.Evaluacion
        Dgv_Persona.DataSource = Nothing
        Dgv_Persona.DataSource = dsEvaluacion.Tables(0)
        AplicarFormatoColumnas()
        Lb_CantidadReportes.Text = "Cantidad de Evaluaciones: " & dsEvaluacion.Tables(0).Rows.Count
        If Dgv_Persona.RowCount > 0 Then
            Dgv_Persona.ClearSelection()
            Dgv_Persona.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Nbi_CrearEvaluacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearEvaluacion.ItemClick
        Dim FrEvaluacionDesempeño As New Fr_EvaluacionDesempeño
        FrEvaluacionDesempeño.CargarTablas()
        FrEvaluacionDesempeño.ShowDialog()
        If FrEvaluacionDesempeño.Guardado Then
            CargarEvaluacion()
        End If
    End Sub

    Private Sub Nbi_EditarEvaluacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarEvaluacion.ItemClick
        If tablaCargada = Tablas.Evaluacion Then
            If Me.Dgv_Persona.Item("ESTADO", Me.Dgv_Persona.CurrentCell.RowIndex).Value = "V" Then
                MsgBox("La evaluación ya fue Revisada", MsgBoxStyle.Critical, "EVALUACIÓN")
            Else
                EditarEvaluacion()
            End If
        Else
            MessageBox.Show("Cargue el listado de Evaluaciones")
        End If
    End Sub

    Private Sub EditarEvaluacion()

        Dim FrEvaluacionDesempeño As New Persona.Fr_EvaluacionDesempeño
        FrEvaluacionDesempeño.IdEvaluacion = Me.Dgv_Persona.SelectedRows(0).Cells("Id").Value
        FrEvaluacionDesempeño.Editando = True
        FrEvaluacionDesempeño.CargarTablas()
        FrEvaluacionDesempeño.CargarDatosEvaluacion()
        FrEvaluacionDesempeño.ShowDialog()
        If FrEvaluacionDesempeño.Guardado Then
            CargarEvaluacion()
        End If
    End Sub

    Private Sub Nbi_VerEvaluacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerEvaluacion.ItemClick
        If tablaCargada = Tablas.Evaluacion Then
            Dim FrEvaluacionDesempeño As New Fr_EvaluacionDesempeño
            FrEvaluacionDesempeño.Editando = True
            FrEvaluacionDesempeño.IdEvaluacion = Dgv_Persona.SelectedRows(0).Cells("Id").Value
            FrEvaluacionDesempeño.CargarTablas()
            FrEvaluacionDesempeño.CargarDatosEvaluacion()
            FrEvaluacionDesempeño.Bt_Guardar.Enabled = False
            FrEvaluacionDesempeño.ShowDialog()
        Else
            MessageBox.Show("Cargue el listado de Evaluaciones")
        End If
    End Sub

    Private Sub Nbi_BuscarEvaluacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarEvaluacion.ItemClick
        BuscarEvaluacion()
    End Sub

    Private Sub BuscarEvaluacion()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("P1.IDENTIFICACION", "Identificación (sin puntos) Evaluado", "2")
        campos.Rows.Add("1", "Nombre Evaluado", "7")
        campos.Rows.Add("P2.IDENTIFICACION", "Identificación (sin puntos) Evaluador", "2")
        campos.Rows.Add("2", "Nombre Evaluador", "7")
        campos.Rows.Add("LTRIM(RTRIM(ED.CORREOELECTRONICOEVALUA))", "Correo electrónico Evaluador", "1")
        campos.Rows.Add("LTRIM(RTRIM(ED.PROYECTO))", "Proyecto", "1")
        campos.Rows.Add("LTRIM(RTRIM(ED.ESTADO))", "Estado", "1")
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de Evaluación de desempeño registrada en SIGMA"
        frbuscar.tabla = 53 ' Terceros
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsTerceros = DSbusqueda
        If Not IsNothing(dsTerceros) Then
            If dsTerceros.Tables.Count > 0 Then
                If dsTerceros.Tables(0).Rows.Count > 0 Then
                    CargarTercerosFiltro(DSbusqueda)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        End If
    End Sub

    Private Sub CargarTercerosFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        Dgv_Persona.DataSource = Nothing
        Dgv_Persona.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.Evaluacion
        AplicarFormatoColumnas()
        Dgv_Persona.ReadOnly = True
        Lb_CantidadReportes.Text = "Cantidad de Evaluaciones: " + DsTabla.Tables(0).Rows.Count.ToString
        If Dgv_Persona.RowCount > 0 Then
            Dgv_Persona.ClearSelection()
            Dgv_Persona.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub



    Public Sub enviarConfirmacion(ByVal textoContenido As String, ByVal asunto As String, ByVal CorreoPara As String, ByVal conteo As Integer, IdEvaluado As String)
        Dim objStreamWriter As StreamWriter
        'Pass the file path and the file name to the StreamWriter constructor.


        If IO.File.Exists(VariablesBase.VariablesBase._path + "\correosevaluaciondesempeñoenviados.txt") = True Then
            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + "\correosevaluaciondesempeñoenviados.txt", True)
        Else
            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + "\correosevaluaciondesempeñoenviados.txt")
        End If
        'Open the file.



        Try
            ' Se arma el html que va a llegar al correo
            Dim cuerpo As String = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>"
            cuerpo += "<html xmlns=""http://www.w3.org/1999/xhtml"">"
            cuerpo += "<head>"
            cuerpo += "<meta http-equiv=""Content-Type"" content=""text/html charset=utf-8"" />"
            cuerpo += "<title>REQUISICIÓN</title>"
            cuerpo += "</head>"
            cuerpo += "<body>"
            cuerpo += "<center>"
            cuerpo += textoContenido
            cuerpo += "</center>"
            cuerpo += "</body>"
            cuerpo += "</html>"

            '********************************************** Envío de mail ************************************************/

            Dim correoDestino As String = CorreoPara
            Dim strSMTP As String = "smtp.gmail.com"
            'revisar conteo para cambiar de correo cuando se llegue a 450 enviados
            Dim correoOrigen As String
            Dim correoOrigenClave As String

            'impar 1 correo
            correoOrigen = "competencias@ismocol.com" 'cambiar este correo 
            correoOrigenClave = "COMPETENCIAS987" 'y esta clave

            objStreamWriter.WriteLine(IdEvaluado + ">" + CorreoPara + ">" + "SI>" + Date.Now.ToString + ">" + correoOrigen)
            objStreamWriter.Close()
        Catch ex As Exception
            'Write a line of text.
            objStreamWriter.WriteLine(IdEvaluado + ">" + CorreoPara + ">" + "NO>" + Date.Now.ToString)
            objStreamWriter.Close()
        End Try
    End Sub



    Dim Archivoadjunto As Boolean = False
    Dim nombrearchivoadjunto As String = ""

    Private Sub Nbi_EnviarCorreo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EnviarCorreo.ItemClick
        Dim FD As New OpenFileDialog
        If MsgBox("Desea adjuntar un archivo", MsgBoxStyle.YesNo, "ADJUNTAR ARCHIVO") = MsgBoxResult.Yes Then
            Archivoadjunto = True
            FD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ToString
            FD.Filter = "Archivos PDF (*.pdf)|*.pdf|Documentos de Word (*.doc)|*.doc|Todos los archivos (*.*)|*.*"
            FD.Multiselect = True
            If (FD.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                Try
                    nombrearchivoadjunto = FD.FileName.ToString
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            End If

        Else
            Archivoadjunto = False
            nombrearchivoadjunto = ""
        End If

        Dim IdEvaluacion As Integer
        Try

            If Me.Dgv_Persona.SelectedRows.Count > 0 Then
                For i = 0 To Dgv_Persona.SelectedRows.Count - 1
                    IdEvaluacion = Dgv_Persona.SelectedRows(i).Cells("Id").Value
                    If Archivoadjunto = True Then
                        'se envia adjuntando
                        If File.Exists(nombrearchivoadjunto) Then
                            Archivoadjunto = True

                            Dim archivoBinario As Byte() = File.ReadAllBytes(nombrearchivoadjunto)
                            If archivoBinario.Length <= tamannoMaximoArchivo Then 'Si el archivo tiene tamaño inferior al tamaño máximo admitido.
                                EnviarCorreoEvaluacionPendiente(IdEvaluacion)
                            Else
                                MessageBox.Show("El tamaño del archivo seleccionado supera los 15 MB. Por favor elija un archivo de menor tamaño.", "Archivo muy grande", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If

                        Else
                            MsgBox("El archivo adjunto no existe", MsgBoxStyle.Information, "Evaluación Desempeño")
                            Exit Sub
                        End If
                    Else
                        'lo envia especificando que no se adjuntara nada
                        Try
                            EnviarCorreoEvaluacionPendiente(IdEvaluacion)
                        Catch ex As Exception

                        End Try

                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("No se envió notificación al correo, Verificar correo de la persona quien realizo la evaluación", MsgBoxStyle.Information, "Enviar Correo")
            Exit Sub
        End Try
        MsgBox("Se envió notificación a los correos ", MsgBoxStyle.Information, "Evaluación Desempeño")
    End Sub

    Private Sub EnviarCorreoEvaluacionPendiente(ByVal IDEVALUACION As Integer)
        Dim Cadena_Consulta As String = ""
        Dim Dt_Evaluacion As DataTable
        Dim FilaEvaluacion As DataRow
        Dim textoContenido As New System.Text.StringBuilder
        Dim correoDestino As String = ""
        Dim asunto As String = ""
        Dim ContadorItems As Integer = 0

        Cadena_Consulta += "SELECT ED.IDPERSONAEVALUADO, dbo.Personanombrecompleto(ED.IDPERSONAEVALUADO) as PERSONAEVALUADO, dbo.formatearnumeroidentificacion(P1.IDENTIFICACION) AS IDENTIFICACIONEVALUADO,  ED.CARGOEVALUADO, "
        Cadena_Consulta += "ED.IDPERSONAEVALUA,dbo.Personanombrecompleto(ED.IDPERSONAEVALUA) AS PERSONAEVALUA, dbo.formatearnumeroidentificacion(P2.IDENTIFICACION) AS IDENTIFICACIONEVALUA, ED.CARGOEVALUA, ED.CORREOELECTRONICOEVALUA,  "
        Cadena_Consulta += "ED.PROYECTO, ED.FECHAREGISTRO, ED.PERIODO, isnull(ED.CLAVEACCESOWEB,0) as CLAVEACCESOWEB "
        Cadena_Consulta += "FROM COM_EVALUACIONDESEMPEÑO AS ED INNER JOIN PERSONA AS P1 ON P1.IDPERSONA = ED.IDPERSONAEVALUADO  INNER JOIN PERSONA AS P2 ON P2.IDPERSONA = ED.IDPERSONAEVALUA   "
        Cadena_Consulta += "WHERE ED.ESTADO = 'A' AND ED.IDEVALUACIONDESEMPEÑO = " + CStr(IDEVALUACION) + " "

        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Dt_Evaluacion = New DataTable
        Adaptador.FillSchema(Dt_Evaluacion, SchemaType.Source)
        Adaptador.Fill(Dt_Evaluacion)
        Consulta.Connection.Close()
        FilaEvaluacion = Dt_Evaluacion.Rows(0)

        Dim mail As New MailMessage
        If VariablesBase.VariablesBase.NombreBaseDatos = "ISMOCOLPRODUCCION" Then
            correoDestino = Dt_Evaluacion.Rows(0)("CORREOELECTRONICOEVALUA").ToString()
        Else
            correoDestino = "soporteaplicaciones@ismocol.com"
        End If

        asunto = "Link Para Realizar la Evaluación de Desempeño 2020-2021 de " + Trim(FilaEvaluacion("PERSONAEVALUADO"))


        textoContenido.AppendLine("Cordial saludo,")
        textoContenido.AppendLine("<br/><br/>")
        textoContenido.AppendLine("Señor(a) " + Trim(FilaEvaluacion("PERSONAEVALUA")) + "")
        textoContenido.AppendLine("<br/><br/>")
        textoContenido.AppendLine("Para dar cumplimiento a normas, procedimientos y aspectos legales que conciernen a la empresa, se debe aplicar la evaluación de desempeño del periodo " + Trim(FilaEvaluacion("PERIODO")) + ", razón  por la cual usted debe evaluar el desempeño del señor(a) " + Trim(FilaEvaluacion("PERSONAEVALUADO")) + ".")
        textoContenido.AppendLine("<br/><br/>")
        textoContenido.AppendLine("Tenga en cuenta éstas recomendaciones para la aplicación de la evaluación de desempeño:")
        textoContenido.AppendLine("<br/><br/>")
        textoContenido.AppendLine("1. Debe ser concertada con el evaluado.")
        textoContenido.AppendLine("<br/>2. Disponga de un tiempo prudente para realizar la evaluación con cada colaborador.")
        textoContenido.AppendLine("<br/>3. Explique al colaborador el propósito de la misma.")
        textoContenido.AppendLine("<br/>4. Asigne una calificación a cada uno de los comportamientos evaluados de acuerdo a la entrevista realizada al colaborador.")
        textoContenido.AppendLine("<br/>5. Sea objetivo en la calificación.")
        textoContenido.AppendLine("<br/>6. Retroalimente al colaborador y escriba si es necesario los aspectos por mejorar o compromisos que se acuerden.")
        textoContenido.AppendLine("<br/>7. Al finalizar hacer click en terminar.")
        textoContenido.AppendLine("<br/>8. Imprima el documento en una hoja por doble cara y envíelo firmado (por el evaluador y el evaluado) al área de Competencias Laborales. ")
        textoContenido.AppendLine("<br/>9. Hay plazo para realizar la prueba hasta el día 9 de octubre del 2021. ")
        textoContenido.AppendLine("<br/><br/>")
        textoContenido.AppendLine("Si desea ampliar ésta información, vea el video con las indicaciones y la guía de aplicación de la evaluación de desempeño que se encuentra adjunto en el correo. ")
        textoContenido.AppendLine("<br/><br/>")
        Select Case Trim(FilaEvaluacion("PERIODO"))
            Case "2019-2020"
                textoContenido.AppendLine("Para iniciar la evaluación de desempeño  <a href=' http://190.0.43.174:7070/Publico/wf_EvaluacionDesempeño.aspx' target='_blank'>HAGA CLICK AQUÍ</a>,. Ingrese la siguiente clave de acceso en la casilla TOKEN ENCUESTA para iniciar la prueba.")
            Case Else
                textoContenido.AppendLine("Para iniciar la evaluación de desempeño  <a href=' http://190.0.43.174:7070/Publico/wf_EvaluacionDesempeñov4.aspx' target='_blank'>HAGA CLICK AQUÍ</a>,. Ingrese la siguiente clave de acceso en la casilla TOKEN ENCUESTA para iniciar la prueba.")
        End Select
        textoContenido.AppendLine("<br/><br/>")
        textoContenido.AppendLine("<Strong>" + Trim(FilaEvaluacion("CLAVEACCESOWEB")) + "</Strong>")
        textoContenido.AppendLine("<br/><br/>")
        textoContenido.AppendLine("Cualquier duda comunicarse con el área de competencias laborales en el departamento administrativo (7) 6573377 ext. 1208 y al correo electrónico competencias@ismocol.com")

        ' Se arma el HTML que va a llegar al correo
        Dim cuerpo As String = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>"
        cuerpo += "<html xmlns='http://www.w3.org/1999/xhtml'>"
        cuerpo += "    <head>"
        cuerpo += "        <meta http-equiv='Content-Type' content='text/html charset=utf-8' />"
        cuerpo += "        <title>EVALAUCIÓN DESEMPEÑO</title>"
        cuerpo += "    </head>"
        cuerpo += "    <body >"
        cuerpo += "        " + textoContenido.ToString()
        cuerpo += "    </body>"
        cuerpo += "</html>"

        '********************************************** Envío de mail ************************************************/

        Dim strSMTP As String = "smtp.gmail.com"
        'revisar conteo para cambiar de correo cuando se llegue a 450 enviados
        Dim correoOrigen As String = "competencias@ismocol.com"
        Dim correoOrigenClave As String = "COMPETENCIAS987"

        Dim SmtpServer As New SmtpClient("smtp.gmail.com", 587)
        SmtpServer.UseDefaultCredentials = False
            SmtpServer.Credentials = New Net.NetworkCredential(correoOrigen, correoOrigenClave)
            SmtpServer.EnableSsl = True
            mail.To.Add(correoDestino)
            mail.From = New MailAddress(correoOrigen)
            mail.Subject = asunto
            If Archivoadjunto = True Then
                Dim archivo As New System.Net.Mail.Attachment(nombrearchivoadjunto)
                mail.Attachments.Add(archivo)
            End If
            mail.Body = cuerpo
            mail.IsBodyHtml = True
            mail.Priority = MailPriority.Normal
            'QUITAR PARA QUE FUNCIONE
            Try
                SmtpServer.Send(mail)
            Catch ex As Exception

            End Try

            Try
                'SI SE DESEA SOLO GRABAR LOS REGISTROS SIN ENVIAR CORREOS COMENTAR LA LINEA DE ABAJO
                enviarConfirmacion(cuerpo, correoOrigen, correoDestino, 0, Trim(FilaEvaluacion("IDPERSONAEVALUADO")).ToString) 'envio de correo
                'enviarConfirmacion(cuerpo, Dgv_CorreosEnviados.Rows(i).Cells(14).Value.ToString, "desprendibles.nomina@ismocol.com", i) 'envio de correo
                'System.Threading.Thread.Sleep(200)
            Catch ex As Exception
                'grabo la ultima posicion de envio y termino el procedimiento
                MsgBox(ex.ToString)
                'bgw_correos.ReportProgress(i, "AgregarErrorEnvio")
                'Lb_CorreosSinEnviar.Text = "Error de envio en este registro"
                'bgw_correos.ReportProgress(i, "Error de envio en este registro")
                'bgw_correos.ReportProgress(i, "BorrarDesdeEnviados")
                'BorrarDesdeEnviados(i)
                'bgw_correos.ReportProgress(i, "Guardando tablas en la base de datos")
                ''Lb_Progreso.Text = "Guardando tablas en la base de datos"
                'Try
                '    GuardarTabla()
                '    MsgBox("Registros alcanzados a enviar Guardados en la base de datos")
                'Catch ex3 As Exception
                '    MsgBox("Error al guardar en la base de datos")
                'End Try
                'HabilitarControles()
                'Exit Sub
            End Try


    End Sub

    Private Sub Nbi_EnviarCorreoBloque_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EnviarCorreoBloque.ItemClick
        If MsgBox("¿Seguro que desea enviar los correos de evaluaciones de desempeño pendientes en bloque?", MsgBoxStyle.YesNo, "ENVIAR CORREOS PENDIENTES") = MsgBoxResult.Yes Then
            Dim FD As New OpenFileDialog
            If MsgBox("Desea adjuntar un archivo", MsgBoxStyle.YesNo, "ADJUNTAR ARCHIVO") = MsgBoxResult.Yes Then
                Archivoadjunto = True
                FD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.ToString
                FD.Filter = "Archivos PDF (*.pdf)|*.pdf|Documentos de Word (*.doc)|*.doc|Todos los archivos (*.*)|*.*"
                FD.Multiselect = True
                If (FD.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                    Try
                        nombrearchivoadjunto = FD.FileName.ToString
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End If

            Else
                Archivoadjunto = False
                nombrearchivoadjunto = ""
            End If

            If Archivoadjunto = True Then
                'se envia adjuntando
                If File.Exists(nombrearchivoadjunto) Then
                    Archivoadjunto = True

                    Dim archivoBinario As Byte() = File.ReadAllBytes(nombrearchivoadjunto)
                    If archivoBinario.Length <= tamannoMaximoArchivo Then 'Si el archivo tiene tamaño inferior al tamaño máximo admitido.
                        EnviarCorreosEvaluacionDesempeño()
                    Else
                        MessageBox.Show("El tamaño del archivo seleccionado supera los 15 MB. Por favor elija un archivo de menor tamaño.", "Archivo muy grande", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                Else
                    MsgBox("El archivo adjunto no existe", MsgBoxStyle.Information, "Evaluación Desempeño")
                    Exit Sub
                End If
            Else
                'lo envia especificando que no se adjuntara nada
                Try
                    EnviarCorreosEvaluacionDesempeño()
                Catch ex As Exception

                End Try
            End If
            MsgBox("Se envió notificación a los correos ", MsgBoxStyle.Information, "Evaluación Desempeño")
        End If
    End Sub

    Private Sub EnviarCorreosEvaluacionDesempeño()
        Cursor = Cursors.WaitCursor

        'IMPLEMENTAR
        Dim Cadena_Consulta As String = ""
        Dim tablaUsuarios As DataTable
        Dim tablaEvaluaciones As DataTable

        Cadena_Consulta += "SELECT ED.IDPERSONAEVALUADO, dbo.Personanombrecompleto(ED.IDPERSONAEVALUADO) as PERSONAEVALUADO, dbo.formatearnumeroidentificacion(P1.IDENTIFICACION) AS IDENTIFICACIONEVALUADO,  ED.CARGOEVALUADO, "
        Cadena_Consulta += "ED.IDPERSONAEVALUA,dbo.Personanombrecompleto(ED.IDPERSONAEVALUA) AS PERSONAEVALUA, dbo.formatearnumeroidentificacion(P2.IDENTIFICACION) AS IDENTIFICACIONEVALUA, ED.CARGOEVALUA, ED.CORREOELECTRONICOEVALUA,  "
        Cadena_Consulta += "ED.PROYECTO, ED.FECHAREGISTRO, ED.PERIODO, isnull(ED.CLAVEACCESOWEB,'') as CLAVEACCESOWEB "
        Cadena_Consulta += "FROM COM_EVALUACIONDESEMPEÑO AS ED INNER JOIN PERSONA AS P1 ON P1.IDPERSONA = ED.IDPERSONAEVALUADO  INNER JOIN PERSONA AS P2 ON P2.IDPERSONA = ED.IDPERSONAEVALUA   "
        Cadena_Consulta += "WHERE ED.ESTADO = 'A' "
        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        tablaEvaluaciones = New DataTable
        Adaptador.FillSchema(tablaEvaluaciones, SchemaType.Source)
        Adaptador.Fill(tablaEvaluaciones)
        Consulta.Connection.Close()

        tablaUsuarios = tablaEvaluaciones.DefaultView.ToTable(True, "IDPERSONAEVALUADO")

        Dim cuerpo As New StringBuilder

        For i As Integer = 0 To tablaUsuarios.Rows.Count - 1
            Dim FilaUsuario As DataRow
            FilaUsuario = tablaUsuarios.Rows(i)
            Dim filasDocumentosPendientes As DataRow()
            filasDocumentosPendientes = tablaEvaluaciones.Select("IDPERSONAEVALUADO=" & FilaUsuario("IDPERSONAEVALUADO").ToString)
            Dim filasDocumentosPendientesReferencia As DataRow
            filasDocumentosPendientesReferencia = filasDocumentosPendientes(0)
            Try

                For nrodocumentopendiente = 0 To filasDocumentosPendientes.Count - 1
                    Dim filaDocumentosPendientes As DataRow
                    filaDocumentosPendientes = filasDocumentosPendientes(nrodocumentopendiente)


                    cuerpo.AppendLine("<div style='text-align: left'>")
                    cuerpo.AppendLine("Cordial saludo,")
                    cuerpo.AppendLine("<br/><br/>")
                    cuerpo.AppendLine("Señor(a) " + Trim(filaDocumentosPendientes("PERSONAEVALUA")) + "")
                    cuerpo.AppendLine("<br/><br/>")
                    cuerpo.AppendLine("Para dar cumplimiento a normas, procedimientos y aspectos legales que conciernen a la empresa, se debe aplicar la evaluación de desempeño del periodo " + Trim(filaDocumentosPendientes("PERIODO")) + ", razón por la cual usted debe evaluar el desempeño del señor(a) " + Trim(filaDocumentosPendientes("PERSONAEVALUADO")) + ".")
                    cuerpo.AppendLine("<br/><br/>")
                    cuerpo.AppendLine("Tenga en cuenta éstas recomendaciones para la aplicación de la evaluación de desempeño:")
                    cuerpo.AppendLine("<br/><br/>")
                    cuerpo.AppendLine("1. Debe ser concertada con el evaluado.")
                    cuerpo.AppendLine("<br/>2. Disponga de un tiempo prudente para realizar la evaluación con cada colaborador.")
                    cuerpo.AppendLine("<br/>3. Explique al colaborador el propósito de la misma.")
                    cuerpo.AppendLine("<br/>4. Asigne una calificación a cada uno de los comportamientos evaluados de acuerdo a la entrevista realizada al colaborador.")
                    cuerpo.AppendLine("<br/>5. Sea objetivo en la calificación.")
                    cuerpo.AppendLine("<br/>6. Retroalimente al colaborador y escriba si es necesario los aspectos por mejorar o compromisos que se acuerden.")
                    cuerpo.AppendLine("<br/>7. Al finalizar hacer click en terminar.")
                    cuerpo.AppendLine("<br/>8. Imprima el documento en una hoja por doble cara y envíelo firmado (por el evaluador y el evaluado) al área de Competencias Laborales. ")
                    cuerpo.AppendLine("<br/>9. Hay plazo para realizar la prueba hasta el día 9 de octubre del 2021. ")
                    cuerpo.AppendLine("<br/><br/>")
                    cuerpo.AppendLine("Si desea ampliar ésta información, vea el video con las indicaciones y la guía de aplicación de la evaluación de desempeño que se encuentra adjunto en el correo. ")
                    cuerpo.AppendLine("<br/><br/>")
                    Select Case Trim(filaDocumentosPendientes("PERIODO"))
                        Case "2019-2020"
                            cuerpo.AppendLine("Para iniciar la evaluación de desempeño  <a href=' http://190.0.43.174:7070/Publico/wf_EvaluacionDesempeño.aspx' target='_blank'>HAGA CLICK AQUÍ</a>,. Ingrese la siguiente clave de acceso en la casilla TOKEN ENCUESTA para iniciar la prueba.")
                        Case Else
                            cuerpo.AppendLine("Para iniciar la evaluación de desempeño  <a href=' http://190.0.43.174:7070/Publico/wf_EvaluacionDesempeñov4.aspx' target='_blank'>HAGA CLICK AQUÍ</a>,. Ingrese la siguiente clave de acceso en la casilla TOKEN ENCUESTA para iniciar la prueba.")
                    End Select
                    cuerpo.AppendLine("<br/><br/>")
                    cuerpo.AppendLine("<Strong>" + Trim(filaDocumentosPendientes("CLAVEACCESOWEB")) + "</Strong>")
                    cuerpo.AppendLine("<br/><br/>")
                    cuerpo.AppendLine("<div/>")
                    cuerpo.AppendLine("Cualquier duda comunicarse con el área de competencias laborales en el departamento administrativo (7) 6573377 ext. 1208 y al correo electrónico competencias@ismocol.com")
                Next

                If Archivoadjunto = True Then
                    FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Link Para Realizar la Evaluación de Desempeño 2020-2021 de" + Trim(filasDocumentosPendientesReferencia("PERSONAEVALUADO")), VariablesBase.VariablesBase.correoInformacionCompetencias, filasDocumentosPendientesReferencia("CORREOELECTRONICOEVALUA"), Nothing, False, nombrearchivoadjunto)
                Else
                    FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Link Para Realizar la Evaluación de Desempeño 2020-2021 de" + Trim(filasDocumentosPendientesReferencia("PERSONAEVALUADO")), VariablesBase.VariablesBase.correoInformacionCompetencias, filasDocumentosPendientesReferencia("CORREOELECTRONICOEVALUA"), Nothing, False, "")
                End If


                cuerpo.Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                'SI SE DESEA SOLO GRABAR LOS REGISTROS SIN ENVIAR CORREOS COMENTAR LA LINEA DE ABAJO
                enviarConfirmacion(cuerpo.ToString, VariablesBase.VariablesBase.correoInformacionCompetencias, filasDocumentosPendientesReferencia("CORREOELECTRONICOEVALUA"), 0, filasDocumentosPendientesReferencia("IDPERSONAEVALUADO").ToString) 'envio de correo
                'enviarConfirmacion(cuerpo, Dgv_CorreosEnviados.Rows(i).Cells(14).Value.ToString, "desprendibles.nomina@ismocol.com", i) 'envio de correo
                'System.Threading.Thread.Sleep(200)
            Catch ex As Exception
                'grabo la ultima posicion de envio y termino el procedimiento
                MsgBox(ex.ToString)

                'bgw_correos.ReportProgress(i, "AgregarErrorEnvio")
                'Lb_CorreosSinEnviar.Text = "Error de envio en este registro"
                'bgw_correos.ReportProgress(i, "Error de envio en este registro")
                'bgw_correos.ReportProgress(i, "BorrarDesdeEnviados")
                'BorrarDesdeEnviados(i)
                'bgw_correos.ReportProgress(i, "Guardando tablas en la base de datos")
                ''Lb_Progreso.Text = "Guardando tablas en la base de datos"
                'Try
                '    GuardarTabla()
                '    MsgBox("Registros alcanzados a enviar Guardados en la base de datos")
                'Catch ex3 As Exception
                '    MsgBox("Error al guardar en la base de datos")
                'End Try
                'HabilitarControles()
                'Exit Sub
            End Try

        Next
    End Sub

#End Region 'Evaluación Desempeño

    Private Sub Nbi_RegistrarEstado_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarEstado.ItemClick
        CargarAgregarEstado("I")
    End Sub
    Private Sub Nbi_ConsultarEstado_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ConsultarEstado.ItemClick
        CargarAgregarEstado("C")
    End Sub
    Private Sub Nbi_VerResumen_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerResumen.ItemClick
        CargarAgregarEstado("H")
    End Sub

    Private Sub Nbi_HistorialConsultas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HistorialConsultas.ItemClick
        CargarAgregarEstado("X")
    End Sub

    Private Sub CargarAgregarEstado(ByVal TIPO As String)
        Dim FrAgregarEstado As New Fr_AgregarEstado
        FrAgregarEstado.IDENTIFICACION = Replace(Replace(Replace(InputBox("¿Digite la identificación de la persona?", "IDENTIFICACION", ""), ".", ""), ",", ""), "'", "")
        FrAgregarEstado.tipoModulo = "S"
        If Trim(FrAgregarEstado.IDENTIFICACION) <> "" Then
            If IsNumeric(FrAgregarEstado.IDENTIFICACION) = True Then
                FrAgregarEstado.Cargar(TIPO)
                Select Case TIPO
                    Case "H", "X"
                        FrAgregarEstado.AplicarFormatoColumnas()
                End Select
                FrAgregarEstado.ShowDialog()
            Else
                MsgBox("El valor ingresado no es valido")
            End If
        Else
            MsgBox("El valor ingresado no es valido")
        End If
    End Sub

    Private Sub Nbi_EditarExamen_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarExamen.ItemClick
        If tablaCargada = Tablas.Examenes Then
            If Dgv_Persona.SelectedRows.Count > 0 Then
                If Trim(Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("PERMITIREDICION").Value) = "S" Then
                    If Trim(Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("CONCEPTOMEDICO").Value) = "" Then
                        Dim FrImprimirExamenes As New Fr_ImprimirExamenes
                        FrImprimirExamenes.TipoAccion = Fr_ImprimirExamenes.Accion.Editar
                        FrImprimirExamenes.IdPersona = Dgv_Persona.SelectedRows(0).Cells("IDPERSONA").Value
                        FrImprimirExamenes.IdEnvioExamen = Dgv_Persona.SelectedRows(0).Cells("IDENVIOEXAMEN").Value
                        FrImprimirExamenes.ShowDialog()
                        If FrImprimirExamenes.Guardado Then
                            Cargar_Examenes()
                        End If
                    Else
                        MessageBox.Show("Este examen ya tiene concepto médico y no puede ser editado")
                    End If
                Else
                    MessageBox.Show("Este examen ya fue impreso y esta bloqueado para editar, debe solicitar el desbloqueo")
                End If
            End If
        Else
            MessageBox.Show("Cargue el listado de Exámenes")
        End If
    End Sub

    Private Sub Nbi_HabilitarEdición_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HabilitarEdición.ItemClick
        If tablaCargada = Tablas.Examenes Then
            If Dgv_Persona.SelectedRows.Count > 0 Then
                If Trim(Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("PERMITIREDICION").Value) = "N" Then
                    If Trim(Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("CONCEPTOMEDICO").Value) = "" Then
                        'Desbloquear para edición
                        comando = New SqlCommand("UPDATE ENVIOEXAMEN set PERMITIREDICION='S' where IDENVIOEXAMEN=@IDENVIOEXAMEN", conexion)
                        comando.Parameters.AddWithValue("@IDENVIOEXAMEN", Dgv_Persona.SelectedRows(0).Cells("IDENVIOEXAMEN").Value)
                        adaptador = New SqlDataAdapter(comando)
                        Try
                            comando.Connection.Open()
                            comando.ExecuteNonQuery()
                            Cargar_Examenes()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            conexion.Close()
                        End Try
                    Else
                        MessageBox.Show("Este examen ya tiene Concepto Médico y no puede ser Editado")
                    End If
                Else
                    MsgBox("Este examen se encuentra bloqueado para Edición", MsgBoxStyle.Information, "Exámenes")
                End If
            End If
        Else
            MessageBox.Show("Cargue el listado de Exámenes")
        End If
    End Sub

    Private Sub Nbi_AgregarPersonaSeguridad_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AgregarPersonaSeguridad.ItemClick
        Dim FrPersona As New Fr_PersonaSeguridad
        FrPersona.Cargar_Tablas()
        FrPersona.GuardaFotoServidor = False
        FrPersona.Show()
        If FrPersona.Guardado Then
            Cargar_Personas()
        End If
    End Sub

    Private Sub Nbi_AgregarVacunas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AgregarVacunas.ItemClick

        Dim FrGestionarVacuna As New Fr_GestionarVacunas

        'If IsDBNull(Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("IDPERSONA").Value) = False Then
        If Dgv_Persona.SelectedRows.Count > 0 Then
            Select Case tablaCargada
                Case Tablas.Persona
                    FrGestionarVacuna.IdPersona = Dgv_Persona.SelectedRows(0).Cells("ID").Value
                    FrGestionarVacuna.Nombre = Dgv_Persona.SelectedRows(0).Cells("NOMBRE").Value
                    FrGestionarVacuna.identificacion = Dgv_Persona.SelectedRows(0).Cells("IDENTIFICACIÓN").Value

                Case Tablas.Examenes
                    FrGestionarVacuna.IdPersona = Dgv_Persona.SelectedRows(0).Cells("IDPERSONA").Value
                    FrGestionarVacuna.Nombre = Dgv_Persona.SelectedRows(0).Cells("NOMBRE").Value
                    FrGestionarVacuna.identificacion = Dgv_Persona.SelectedRows(0).Cells("IDENTIFICACION").Value

                Case Else
                    MessageBox.Show("Cargue el listado de personal o de exámanes.")
                    Exit Sub
            End Select



        End If


        'FrGestionarVacuna.IdPersona = Dgv_Persona.SelectedRows(0).Cells("Id").Value
        FrGestionarVacuna.Cargar_Tablas()


        FrGestionarVacuna.ShowDialog()
        If FrPersona.Guardado Then
            Cargar_Personas()
        End If


        'If Dgv_Persona.SelectedRows.Count > 0 Then
        '    Dim idPersona As Integer = -1
        '    Dim Identificacion As String

        '    Select Case tablaCargada
        '        Case Tablas.Persona
        '            FrGestionarVacuna.IdPersona = Dgv_Persona.SelectedRows(0).Cells("Id").Value
        '            Identificacion = Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("Identificación").Value
        '        Case Tablas.Examenes
        '            FrGestionarVacuna.IdPersona = Dgv_Persona.SelectedRows(0).Cells("IDPERSONA").Value
        '            Identificacion = Dgv_Persona.Rows(Dgv_Persona.CurrentRow.Index).Cells("IDENTIFICACION").Value
        '        Case Else
        '            MessageBox.Show("Cargue el listado de personal o de exámanes.")
        '            Exit Sub
        '    End Select
        '    FrGestionarVacuna.ShowDialog()
        'End If

    End Sub

    Private Sub Ck_MostrarFotoPersona_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_MostrarFotoPersona.CheckedChanged
        If tablaCargada = Tablas.Persona Then
            If Ck_MostrarFotoPersona.Checked = True Then
                Pb_FotoPersona.Enabled = True
                If Me.Dgv_Persona.SelectedRows.Count = 1 Then
                    CargarFotoPersona(Me.Dgv_Persona.SelectedRows(0).Cells(0).Value)
                End If
            Else
                Pb_FotoPersona.Enabled = False
                Pb_FotoPersona.Image = Nothing
            End If
        End If
    End Sub

    Private Sub CargarFotoPersona(ByVal IdPersona As Integer)
        Try
            Pb_FotoPersona.Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(1, IdPersona)
        Catch ex As Exception
        End Try
        If Pb_FotoPersona.Image Is Nothing Then
            Pb_FotoPersona.Image = Im_Defecto.Images(0)
        End If
    End Sub

    Private Sub Pb_FotoPersona_Click(sender As Object, e As EventArgs) Handles Pb_FotoPersona.Click
        If Ck_MostrarFotoPersona.Checked Then
            If Dgv_Persona.Rows.Count > 0 Then
                Dim FrMostrarFoto As New Form
                Dim Pb_Foto As New PictureBox
                With Pb_Foto
                    .Dock = DockStyle.Fill
                    .Size = New Size(480, 620)
                End With
                With FrMostrarFoto
                    .ClientSize = New Size(Pb_Foto.Right, Pb_Foto.Bottom)
                    .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
                    .Controls.Add(Pb_Foto)
                    .StartPosition = FormStartPosition.CenterScreen
                End With
                If Not FuncionesBase.FuncionesBase.ImagenesIguales(Pb_FotoPersona.Image, Im_Defecto.Images(0)) Then
                    Dim Cedula As String = Me.Dgv_Persona.SelectedRows(0).Cells("Identificación").Value.ToString
                    Cedula = Cedula.Replace(".", "")
                    Dim Foto As Boolean = GoogleDrive.DescargarFotos(Cedula, "Persona")
                    If Foto Then
                        Dim appPath As String = Application.StartupPath + "/Temp.jpg"
                        Dim filestream As New IO.FileStream(appPath, IO.FileMode.Open, IO.FileAccess.Read)
                        Dim imagen As Image = Image.FromStream(filestream)
                        filestream.Close()
                        Pb_Foto.Image = imagen
                    End If
                    FrMostrarFoto.ShowDialog()
                    Dim appPath2 As String
                    Try
                        Pb_Foto.Image.Dispose()
                        appPath2 = Application.StartupPath + "\Temp.jpg" '+ Me.Dgv_Persona.SelectedRows(0).Cells("Identificación").Value.ToString.ToString + ".jpg"
                        If My.Computer.FileSystem.FileExists(appPath2) Then
                            My.Computer.FileSystem.DeleteFile(appPath2)
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub CambioNbg() Handles Nbc_Persona.ActiveGroupChanged
        If Nbc_Persona.ActiveGroup.Name = "Nbg_Persona" Then
            MostrarPanelFotos()
        Else
            OcultarPanelFotos()
        End If
    End Sub
    Private Sub MostrarPanelFotos()
        SplitContainer2.Panel2Collapsed = False
        SplitContainer2.Panel2.Show()
    End Sub
    Private Sub OcultarPanelFotos()
        SplitContainer2.Panel2Collapsed = True
        SplitContainer2.Panel2.Hide()
    End Sub
End Class 'Cu_Persona

Friend Class Cl_Persona
    Private _nombre As String
    Private _identificacion As String
    Private _tipoIdentifiacion As String
    Private _lugarExpIdentificacion As String
    Private _fechaExpIdentificacion As String
    Private _idPersona As String
    Private _genero As String
    Private _lugarNacimiento As String
    Private _fechaNacimiento As String
    Private _estadoCivil As String
    Private _numeroContacto As String
    Private _telefonoMovil As String
    Private _correoElectronico As String
    Private _profesion As String
    Private _nivelEducativo As String
    Private _tarjetaProfesional As String
    Private _personasCargo As String
    Private _numeroHijos As String
    Private _usuarioRegistra As String
    Private _fechaRegistro As String
    Private _usuarioModifica As String
    Private _fechaModifica As String
    Private _revisadoNomina As String
    Private _codigoContrato As String
    Private _estadoContrato As String

    <Description("Nombre completo"), _
    Category("Datos Personales"),
    DisplayNameAttribute("Nombre")> _
    Public ReadOnly Property IdPersonaNombre() As String
        Get
            Return _nombre
        End Get
    End Property

    <Description("Número de identificación"), _
    Category("Identificación"),
    DisplayNameAttribute("Identificación")> _
    Public ReadOnly Property Identificacion() As String
        Get
            Return _identificacion
        End Get
    End Property

    <Description("Tipo de documento de identificación"), _
    Category("Identificación"),
    DisplayNameAttribute("Tipo de Identificación")> _
    Public ReadOnly Property Tipoidentificacion() As String
        Get
            Return _tipoIdentifiacion
        End Get
    End Property

    <Description("Lugar de expedición del documento de identificación"), _
    Category("Identificación"),
    DisplayNameAttribute("Lugar de Exp. Identificación")> _
    Public ReadOnly Property LugarExpIdentificacion() As String
        Get
            Return _lugarExpIdentificacion
        End Get
    End Property

    <Description("Fecha de expedición del documento de identificación"), _
    Category("Identificación"),
    DisplayNameAttribute("Fecha Exp. Identificación")> _
    Public ReadOnly Property FechaExpIdentificación() As String
        Get
            Return _fechaExpIdentificacion
        End Get
    End Property

    <Description("Identificador SIGMA de la persona"), _
    Category(""),
    DisplayNameAttribute("Id Persona")> _
    Public ReadOnly Property IdPesona() As String
        Get
            Return _idPersona
        End Get
    End Property

    <Description("Género"), _
    Category("Datos Personales"),
    DisplayNameAttribute("Género")> _
    Public ReadOnly Property Genero() As String
        Get
            Return _genero
        End Get
    End Property

    <Description("Lugar de nacimiento"), _
    Category("Nacimiento"),
    DisplayNameAttribute("Lugar de Nacimiento")> _
    Public ReadOnly Property LugarNacimineto() As String
        Get
            Return _lugarNacimiento
        End Get
    End Property

    <Description("Fecha de nacimiento"), _
    Category("Nacimiento"),
    DisplayNameAttribute("Fecha de Nacimiento")> _
    Public ReadOnly Property FechaNacimiento() As String
        Get
            Return _fechaNacimiento
        End Get
    End Property

    <Description("Estado civil"), _
     Category("Datos Personales"),
     DisplayNameAttribute("Estado Civil")> _
    Public ReadOnly Property EstadoCivil() As String
        Get
            Return _estadoCivil
        End Get
    End Property

    <Description("Número telefónico de contacto"), _
    Category("Contacto"),
    DisplayNameAttribute("Número de Contacto")> _
    Public ReadOnly Property NumeroContacto() As String
        Get
            Return _numeroContacto
        End Get
    End Property

    <Description("Número de teléfono móvil o celular"), _
    Category("Contacto"),
    DisplayNameAttribute("Teléfono Móvil")> _
    Public ReadOnly Property TelefonoMovil() As String
        Get
            Return _telefonoMovil
        End Get
    End Property

    <Description("Dirección de correo electrónico personal"), _
    Category("Contacto"),
    DisplayNameAttribute("Correo Electrónico")> _
    Public ReadOnly Property CorreoElectronico() As String
        Get
            Return _correoElectronico
        End Get
    End Property

    <Description("Profesión"), _
    Category("Educación"),
    DisplayNameAttribute("Profesión")> _
    Public ReadOnly Property Profesion() As String
        Get
            Return _profesion
        End Get
    End Property

    <Description("Máximo nivel de educación obtenido"), _
     Category("Educación"),
     DisplayNameAttribute("Nivel Educativo")> _
    Public ReadOnly Property Niveleducativo() As String
        Get
            Return _nivelEducativo
        End Get
    End Property

    <Description("Número de tarjeta profesional"), _
    Category("Educación"),
    DisplayNameAttribute("Tarjeta Profesional")> _
    Public ReadOnly Property TarjetaProfesional() As String
        Get
            Return _tarjetaProfesional
        End Get
    End Property

    <Description("Número de personas a cargo de la persona"), _
    Category("Familia"),
    DisplayNameAttribute("Personas a Cargo")> _
    Public ReadOnly Property PersonasCargo() As String
        Get
            Return _personasCargo
        End Get
    End Property

    <Description("Número de hijos"), _
    Category("Familia"),
    DisplayNameAttribute("Número de Hijos")> _
    Public ReadOnly Property NumeroHijos() As String
        Get
            Return _numeroHijos
        End Get
    End Property

    <Description("Nombre del usuario que realizó el registro"), _
    Category("Auditoria"),
    DisplayNameAttribute("Usuario Registra")> _
    Public ReadOnly Property UsuarioRegistra() As String
        Get
            Return _usuarioRegistra
        End Get
    End Property

    <Description("Fecha de registro"), _
    Category("Auditoria"),
    DisplayNameAttribute("Fecha de Registro")> _
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _fechaRegistro
        End Get
    End Property

    <Description("Nombre del usuario que modificó el registro"), _
    Category("Auditoria"),
    DisplayNameAttribute("Usuario Modifica")> _
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _usuarioModifica
        End Get
    End Property

    <Description("Fecha de modificación"), _
    Category("Auditoria"),
    DisplayNameAttribute("Fecha Modifica")> _
    Public ReadOnly Property Fecha_Modifica() As String
        Get
            Return _fechaModifica
        End Get
    End Property

    <Description("El registro fue validado con el departamento de nómina"), _
    Category(""),
    DisplayNameAttribute("Revisado Nómina")> _
    Public ReadOnly Property RevisadoNomina() As String
        Get
            Return _revisadoNomina
        End Get
    End Property

    <Description("Código del contrato"), _
    Category("Contrato"),
    DisplayNameAttribute("Código Contrato")> _
    Public ReadOnly Property CodigoContrato() As String
        Get
            Return _codigoContrato
        End Get
    End Property

    <Description("Estado del contrato"), _
    Category("Contrato"),
    DisplayNameAttribute("Estado Contrato")> _
    Public ReadOnly Property EstadoContrato() As String
        Get
            Return _estadoContrato
        End Get
    End Property

    Public Sub New(ByVal FilaPersona As DataGridViewRow)
        Try
            _nombre = FilaPersona.Cells("Nombre").Value
        Catch
            _nombre = ""
        End Try
        Try
            _identificacion = FilaPersona.Cells("Identificación").Value
        Catch
            _identificacion = ""
        End Try
        Try
            _tipoIdentifiacion = FilaPersona.Cells("Tipo Identificacion").Value
        Catch
            _tipoIdentifiacion = ""
        End Try
        Try
            _idPersona = FilaPersona.Cells("Id").Value
        Catch
            _idPersona = ""
        End Try
        Try
            _lugarExpIdentificacion = FilaPersona.Cells("Lugar Exp Identificacion").Value
        Catch
            _lugarExpIdentificacion = ""
        End Try
        Try
            _fechaExpIdentificacion = FilaPersona.Cells("Fecha Exp Identificacion").Value
        Catch
            _fechaExpIdentificacion = ""
        End Try
        Try
            Select Case FilaPersona.Cells("Genero").Value
                Case "F"
                    _genero = "Femenino"
                Case "M"
                    _genero = "Masculino"
            End Select
        Catch
            _genero = ""
        End Try
        Try
            _lugarNacimiento = FilaPersona.Cells("Lugar Nacimiento").Value
        Catch
            _lugarNacimiento = ""
        End Try
        Try
            _fechaNacimiento = FilaPersona.Cells("Fecha Nacimiento").Value
        Catch
            _fechaNacimiento = ""
        End Try
        Try
            _estadoCivil = FilaPersona.Cells("Estado Civil").Value
        Catch
            _estadoCivil = ""
        End Try
        Try
            _numeroContacto = FilaPersona.Cells("Numero Contacto").Value
        Catch
            _numeroContacto = ""
        End Try
        Try
            _telefonoMovil = FilaPersona.Cells("Celular").Value
        Catch
            _telefonoMovil = ""
        End Try
        Try
            _correoElectronico = FilaPersona.Cells("E-mail").Value
        Catch
            _correoElectronico = ""
        End Try
        Try
            _profesion = FilaPersona.Cells("Profesion").Value
        Catch
            _profesion = ""
        End Try
        Try
            _nivelEducativo = FilaPersona.Cells("Nivel Educativo").Value
        Catch
            _nivelEducativo = ""
        End Try
        Try
            _tarjetaProfesional = FilaPersona.Cells("Tarjeta Profesional").Value
        Catch
            _tarjetaProfesional = ""
        End Try
        Try
            _personasCargo = FilaPersona.Cells("Personas a Cargo").Value
        Catch
            _personasCargo = ""
        End Try
        Try
            _numeroHijos = FilaPersona.Cells("Numero Hijos").Value
        Catch
            _numeroHijos = ""
        End Try
        Try
            _usuarioRegistra = FilaPersona.Cells("Usuario Registra").Value
        Catch
            _usuarioRegistra = ""
        End Try
        Try
            _fechaRegistro = FilaPersona.Cells("Fecha Registro").Value
        Catch
            _fechaRegistro = ""
        End Try
        Try
            _usuarioModifica = FilaPersona.Cells("Usuario Modifica").Value
        Catch
            _usuarioModifica = ""
        End Try
        Try
            _fechaModifica = FilaPersona.Cells("Fecha Modifica").Value
        Catch
            _fechaModifica = ""
        End Try
        Try
            Select Case FilaPersona.Cells("Revisado Nomina").Value
                Case "S"
                    _revisadoNomina = "Sí"
                Case "N"
                    _revisadoNomina = "No"
            End Select
        Catch
            _revisadoNomina = ""
        End Try
        Try
            _codigoContrato = FilaPersona.Cells("Contrato").Value
        Catch
            _codigoContrato = ""
        End Try
        Try
            Select Case FilaPersona.Cells("Estado Contrato").Value
                Case "A"
                    _estadoContrato = "Activo"
                Case "S"
                    _estadoContrato = "Suspendido"
                Case "T"
                    _estadoContrato = "Terminado"
                Case Else
                    _estadoContrato = FilaPersona.Cells("Estado Contrato").Value
            End Select
        Catch
            _estadoContrato = ""
        End Try
    End Sub
End Class 'Cl_Persona

Friend Class Cl_Examen
    Private _idEnvioExamen As String
    Private _nombre As String
    Private _identificacion As String
    Private _fechaEnvio As String
    Private _usuarioRegistra As String
    Private _fechaRegistro As String
    Private _cargoAspira As String

    <Description("Consecutivo del examen"), _
    Category("2. Examen"),
    DisplayNameAttribute("Id Examen")> _
    Public ReadOnly Property IdEnvioExamen() As String
        Get
            Return _idEnvioExamen
        End Get
    End Property

    <Description("Nombre completo del candidato"), _
    Category("1. Persona"),
    DisplayNameAttribute("Nombre")> _
    Public ReadOnly Property Nombre() As String
        Get
            Return _nombre
        End Get
    End Property

    <Description("Número de identificación"), _
    Category("1. Persona"),
    DisplayNameAttribute("Identificación")> _
    Public ReadOnly Property Identificacion() As String
        Get
            Return _identificacion
        End Get
    End Property

    <Description("Fecha de envío a exámenes"), _
    Category("2. Examen"),
    DisplayNameAttribute("Fecha envío")> _
    Public ReadOnly Property FechaEnvio() As String
        Get
            Return _fechaEnvio
        End Get
    End Property

    <Description("Nombre completo del usuario que registró el envío"), _
    Category("3. Auditoría"),
    DisplayNameAttribute("Usuario registra")> _
    Public ReadOnly Property UsuarioRegistra() As String
        Get
            Return _usuarioRegistra
        End Get
    End Property

    <Description("Fecha  de registro del envío"), _
    Category("3. Auditoría"),
    DisplayNameAttribute("Fecha de registro")> _
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _fechaRegistro
        End Get
    End Property

    <Description("Cargo al que aspira"), _
    Category(""),
    DisplayNameAttribute("Cargo")> _
    Public ReadOnly Property CargoAspira() As String
        Get
            Return _cargoAspira
        End Get
    End Property

    Public Sub New(FilaExamen As DataGridViewRow)
        Try
            _idEnvioExamen = FilaExamen.Cells("IDENVIOEXAMEN").Value
        Catch
            _idEnvioExamen = ""
        End Try
        Try
            _nombre = FilaExamen.Cells("NOMBRE").Value
        Catch
            _nombre = ""
        End Try
        Try
            _identificacion = FilaExamen.Cells("IDENTIFICACION").Value
        Catch
            _identificacion = ""
        End Try
        Try
            _fechaEnvio = FilaExamen.Cells("FECHAENVIO").Value
        Catch
            _fechaEnvio = ""
        End Try
        Try
            _usuarioRegistra = FilaExamen.Cells("USUARIOREGISTRA").Value
        Catch
            _usuarioRegistra = ""
        End Try
        Try
            _fechaRegistro = FilaExamen.Cells("FECHAREGISTRO").Value
        Catch
            _fechaRegistro = ""
        End Try
        Try
            _cargoAspira = FilaExamen.Cells("NOMBRETIPOCARGO").Value
        Catch
            _cargoAspira = ""
        End Try
    End Sub
End Class 'Cl_Examen

Friend Class Cl_Encuesta
    Private _idEncuesta As String
    Private _idPersona As String
    Private _nombre As String
    Private _celular As String
    Private _identificacion As String
    Private _nombreBase As String
    Private _fechaEncuesta As String
    Private _edad As String
    Private _nombreTipoCargo As String
    Private _idUsuarioRegistro As String
    Private _personaRegistro As String
    Private _fechaRegistro As String
    Private _correoElectronico As String
    Private _llenoViaWeb As String
    Private _Respuesta1 As String
    Private _Respuesta2 As String
    Private _Respuesta3 As String
    Private _Respuesta4 As String
    Private _Respuesta5 As String
    Private _Respuesta6 As String
    Private _Respuesta7 As String
    Private _Respuesta8 As String
    Private _Respuesta9 As String
    Private _Respuesta10 As String
    Private _temperatura As String
    Private _PersonaRegistroT As String
    Private _FechaRegistroT As String


    <Description("Nombre completo del encuestado"), _
    Category("Datos Encuestado"),
    DisplayNameAttribute("Nombre")> _
    Public ReadOnly Property Nombre As String
        Get
            Return _nombre
        End Get
    End Property

    <Description("Número de teléfono celular"), _
    Category("Datos Encuestado"),
    DisplayNameAttribute("Celular")> _
    Public ReadOnly Property Celular As String
        Get
            Return _celular
        End Get
    End Property

    <Description("Número de identificación"), _
    Category("Datos Encuestado"),
    DisplayNameAttribute("Identificación")> _
    Public ReadOnly Property Identificacion As String
        Get
            Return _identificacion
        End Get
    End Property

    <Description("Base donde se registró la encuesta"), _
    Category("Encuesta"),
    DisplayNameAttribute("Base")> _
    Public ReadOnly Property NombreBase As String
        Get
            Return _nombreBase
        End Get
    End Property

    <Description("Fecha de la encuesta"), _
    Category("Encuesta"),
    DisplayNameAttribute("Fecha encuesta")> _
    Public ReadOnly Property FechaEncuesta As String
        Get
            Return _fechaEncuesta
        End Get
    End Property

    <Description("Edad del encuestado"), _
    Category("Datos Encuestado"),
    DisplayNameAttribute("Edad")> _
    Public ReadOnly Property Edad As String
        Get
            Return _edad
        End Get
    End Property

    <Description("Cargo del encuestado"), _
    Category("Datos Encuestado"),
    DisplayNameAttribute("Cargo")> _
    Public ReadOnly Property NombreTipoCargo As String
        Get
            Return _nombreTipoCargo
        End Get
    End Property

    <Description("Persona que registró la encuesta"), _
    Category("Auditoría"),
    DisplayNameAttribute("Registró")> _
    Public ReadOnly Property PersonaRegistro As String
        Get
            Return _personaRegistro
        End Get
    End Property

    <Description("Fecha en que se registró la encuesta"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha registro")> _
    Public ReadOnly Property FechaRegistro As String
        Get
            Return _fechaRegistro
        End Get
    End Property

    <Description("Dirección de correo electrónico del encuestado"), _
    Category("Datos Encuestado"),
    DisplayNameAttribute("Correo electrónico")> _
    Public ReadOnly Property CorreoElectronico As String
        Get
            Return _correoElectronico
        End Get
    End Property

    <Description("Indica si el encuestado respondío mediante el portal web"), _
    Category("Encuesta"),
    DisplayNameAttribute("Llenó vía web")> _
    Public ReadOnly Property LlenoViaWeb As String
        Get
            Return _llenoViaWeb
        End Get
    End Property

    <Description("1. ¿Tiene fiebre comprobada con termómetro superior a 38°c?"), _
    Category("Respuestas"),
    DisplayNameAttribute("Respuesta 1")> _
    Public ReadOnly Property Respuesta1 As String
        Get
            Return _Respuesta1
        End Get
    End Property

    <Description("2. ¿Tiene tos continua improductiva (que no desgarra) o que la que la gente conoce como tos seca?"), _
    Category("Respuestas"),
    DisplayNameAttribute("Respuesta 2")> _
    Public ReadOnly Property Respuesta2 As String
        Get
            Return _Respuesta2
        End Get
    End Property

    <Description("3. ¿Tiene dificultad respiratoria (le cuesta trabajo respirar y al hacerlo le duelen las costillas)?"), _
    Category("Respuestas"),
    DisplayNameAttribute("Respuesta 3")> _
    Public ReadOnly Property Respuesta3 As String
        Get
            Return _Respuesta3
        End Get
    End Property

    <Description("4. ¿Siente pérdida de la fuerza y/o dolores musculares?"), _
    Category("Respuestas"),
    DisplayNameAttribute("Respuesta 4")> _
    Public ReadOnly Property Respuesta4 As String
        Get
            Return _Respuesta4
        End Get
    End Property

    <Description("5. ¿Ha notado tener pérdida del olfato, la boca tiene un sabor raro o no le encuentra gusto a las comidas?"), _
    Category("Respuestas"),
    DisplayNameAttribute("Respuesta 5")> _
    Public ReadOnly Property Respuesta5 As String
        Get
            Return _Respuesta5
        End Get
    End Property

    <Description("6. ¿En los últimos 30 días usted ha tenido contacto físico (Tocado, abrazado, besado, acariciado)  con algún familiar o amigo que haya regresado de un viaje del exterior?"), _
    Category("Respuestas"),
    DisplayNameAttribute("Respuesta 6")> _
    Public ReadOnly Property Respuesta6 As String
        Get
            Return _Respuesta6
        End Get
    End Property

    <Description("7. ¿Sabe de haber tenido contacto directo o indirecto a través de un tercero, con una persona diagnosticada y confirmada con coronavirus?"), _
    Category("Respuestas"),
    DisplayNameAttribute("Respuesta 7")> _
    Public ReadOnly Property Respuesta7 As String
        Get
            Return _Respuesta7
        End Get
    End Property

    <Description("8. ¿Sufre de Asma o Enfermedades respiratorias crónicas?"), _
    Category("Respuestas"),
    DisplayNameAttribute("Respuesta 8")> _
    Public ReadOnly Property Respuesta8 As String
        Get
            Return _Respuesta8
        End Get
    End Property

    <Description("9. ¿Sufre de diabetes, obesidad, hipertensión o enfermedades cardiovasculares?"), _
    Category("Respuestas"),
    DisplayNameAttribute("Respuesta 9")> _
    Public ReadOnly Property Respuesta9 As String
        Get
            Return _Respuesta9
        End Get
    End Property

    <Description("10. ¿En los últimos dos años a recibido tratamiento para cáncer, lupus, enfermedades autoinmunes?"), _
    Category("Respuestas"),
    DisplayNameAttribute("Respuesta_10")> _
    Public ReadOnly Property Respuesta10 As String
        Get
            Return _Respuesta10
        End Get
    End Property

    <Description("Temperatura Persona"), _
    Category("Temperatura"),
    DisplayNameAttribute("Temperatura")> _
    Public ReadOnly Property Temperatura As String
        Get
            Return _temperatura
        End Get
    End Property

    <Description("Persona registro temperatura"), _
     Category("Temperatura"),
     DisplayNameAttribute("Persona Registro")> _
    Public ReadOnly Property PersonaRT As String
        Get
            Return _PersonaRegistroT
        End Get
    End Property

    <Description("Fecha Registro de Temperatura"), _
    Category("Temperatura"),
    DisplayNameAttribute("Fecha Registro")> _
    Public ReadOnly Property FRegistro As String
        Get
            Return _FechaRegistroT
        End Get
    End Property


    Public Sub New(FilaEncuesta As DataGridViewRow)
        Try
            _nombre = FilaEncuesta.Cells("NOMBRE").Value
        Catch
            _nombre = ""
        End Try
        Try
            _celular = FilaEncuesta.Cells("Celular").Value
        Catch
            _celular = ""
        End Try
        Try
            _identificacion = FilaEncuesta.Cells("IDENTIFICACION").Value
        Catch
            _identificacion = ""
        End Try
        Try
            _nombreBase = FilaEncuesta.Cells("NOMBREBASE").Value
        Catch
            _nombreBase = ""
        End Try
        Try
            _fechaEncuesta = FilaEncuesta.Cells("FECHAENCUESTA").Value
        Catch
            _fechaEncuesta = ""
        End Try
        Try
            _edad = FilaEncuesta.Cells("Edad").Value
        Catch
            _edad = ""
        End Try
        Try
            _nombreTipoCargo = FilaEncuesta.Cells("NOMBRETIPOCARGO").Value
        Catch
            _nombreTipoCargo = ""
        End Try
        Try
            _personaRegistro = FilaEncuesta.Cells("PERSONAREGISTRO").Value
        Catch
            _personaRegistro = ""
        End Try
        Try
            _fechaRegistro = FilaEncuesta.Cells("FECHAREGISTRO").Value
        Catch
            _fechaRegistro = ""
        End Try
        Try
            _correoElectronico = FilaEncuesta.Cells("CORREOELECTRONICO").Value
        Catch
            _correoElectronico = ""
        End Try
        Try
            Select Case FilaEncuesta.Cells("LLENOVIAWEB").Value
                Case "S"
                    _llenoViaWeb = "Sí"
                Case "N"
                    _llenoViaWeb = "No"
                Case Else
                    _llenoViaWeb = ""
            End Select
        Catch
            _llenoViaWeb = ""
        End Try
        Try
            Select Case FilaEncuesta.Cells("R1").Value
                Case "S"
                    _Respuesta1 = "Sí"
                Case "N"
                    _Respuesta1 = "No"
                Case Else
                    _Respuesta1 = ""
            End Select
        Catch
            _Respuesta1 = ""
        End Try
        Try
            Select Case FilaEncuesta.Cells("R2").Value
                Case "S"
                    _Respuesta2 = "Sí"
                Case "N"
                    _Respuesta2 = "No"
                Case Else
                    _Respuesta2 = ""
            End Select
        Catch
            _Respuesta2 = ""
        End Try
        Try
            Select Case FilaEncuesta.Cells("R3").Value
                Case "S"
                    _Respuesta3 = "Sí"
                Case "N"
                    _Respuesta3 = "No"
                Case Else
                    _Respuesta3 = ""
            End Select
        Catch
            _Respuesta3 = ""
        End Try
        Try
            Select Case FilaEncuesta.Cells("R4").Value
                Case "S"
                    _Respuesta4 = "Sí"
                Case "N"
                    _Respuesta4 = "No"
                Case Else
                    _Respuesta4 = ""
            End Select
        Catch
            _Respuesta4 = ""
        End Try
        Try
            Select Case FilaEncuesta.Cells("R5").Value
                Case "S"
                    _Respuesta5 = "Sí"
                Case "N"
                    _Respuesta5 = "No"
                Case Else
                    _Respuesta5 = ""
            End Select
        Catch
            _Respuesta5 = ""
        End Try
        Try
            Select Case FilaEncuesta.Cells("R6").Value
                Case "S"
                    _Respuesta6 = "Sí"
                Case "N"
                    _Respuesta6 = "No"
                Case Else
                    _Respuesta6 = ""
            End Select
        Catch
            _Respuesta6 = ""
        End Try
        Try
            Select Case FilaEncuesta.Cells("R7").Value
                Case "S"
                    _Respuesta7 = "Sí"
                Case "N"
                    _Respuesta7 = "No"
                Case Else
                    _Respuesta7 = ""
            End Select
        Catch
            _Respuesta7 = ""
        End Try
        Try
            Select Case FilaEncuesta.Cells("R8").Value
                Case "S"
                    _Respuesta8 = "Sí"
                Case "N"
                    _Respuesta8 = "No"
                Case Else
                    _Respuesta8 = ""
            End Select
        Catch
            _Respuesta8 = ""
        End Try
        Try
            Select Case FilaEncuesta.Cells("R9").Value
                Case "S"
                    _Respuesta9 = "Sí"
                Case "N"
                    _Respuesta9 = "No"
                Case Else
                    _Respuesta9 = ""
            End Select
        Catch
            _Respuesta9 = ""
        End Try
        Try
            Select Case FilaEncuesta.Cells("R10").Value
                Case "S"
                    _Respuesta10 = "Sí"
                Case "N"
                    _Respuesta10 = "No"
                Case Else
                    _Respuesta10 = ""
            End Select
        Catch
            _Respuesta10 = ""
        End Try
        Try
            _temperatura = FilaEncuesta.Cells("TEMPERATURA").Value
        Catch
            _temperatura = ""
        End Try
        Try
            _PersonaRegistroT = FilaEncuesta.Cells("USUARIOREGISTROT").Value
        Catch
            _PersonaRegistroT = ""
        End Try
        Try
            _FechaRegistroT = FilaEncuesta.Cells("FECHAREGISTROT").Value
        Catch
            _FechaRegistroT = ""
        End Try
    End Sub
End Class

Friend Class Cl_Calificacion
    Private _Cedula As String
    Private _Nombre As String
    Private _Cargo As String
    Private _BaseContrato As String
    Private _BaseActual As String
    Private _EstadoContrato As String

    <Description(""), _
    Category("Datos Personales"),
    DisplayNameAttribute("Cédula")> _
    Public ReadOnly Property Cedula() As String
        Get
            Return _Cedula
        End Get
    End Property

    <Description(""), _
    Category("Datos Personales"),
    DisplayNameAttribute("Nombre")> _
    Public ReadOnly Property Nombre() As String
        Get
            Return _Nombre
        End Get
    End Property

    <Description(""), _
    Category("Información"),
    DisplayNameAttribute("Cargo")> _
    Public ReadOnly Property Cargo() As String
        Get
            Return _Cargo
        End Get
    End Property

    <Description(""), _
    Category("Información"),
    DisplayNameAttribute("Base del Contrato")> _
    Public ReadOnly Property BaseContrato() As String
        Get
            Return _BaseContrato
        End Get
    End Property

    <Description(""), _
    Category("Información"),
    DisplayNameAttribute("Base Actual")> _
    Public ReadOnly Property BaseActual() As String
        Get
            Return _BaseActual
        End Get
    End Property


    <Description(""), _
Category("Información"),
DisplayNameAttribute("Estado Contrato")> _
    Public ReadOnly Property EstadoContrato() As String
        Get
            Return _EstadoContrato
        End Get
    End Property


    Public Sub New(FilaCalificacion As DataGridViewRow)
        Try
            _Cedula = FilaCalificacion.Cells("Cedula").Value
        Catch
            _Cedula = ""
        End Try
        Try
            _Nombre = FilaCalificacion.Cells("NOMBRECOMPLETO").Value
        Catch
            _Nombre = ""
        End Try
        Try
            _Cargo = FilaCalificacion.Cells("Cargo").Value
        Catch
            _Cargo = ""
        End Try
        Try
            _BaseContrato = FilaCalificacion.Cells("NOMBREBASE").Value
        Catch
            _BaseContrato = ""
        End Try
        Try
            _EstadoContrato = FilaCalificacion.Cells("ESTADOCONTRATO").Value
        Catch
            _EstadoContrato = ""
        End Try
    End Sub

End Class ' Cl_Calificacion

Friend Class Cl_Evaluacion
    Private _nombreEvaluado As String
    Private _idEvaluacion As String
    Private _fechaRegistroEvaluacion As String
    Private _token As String
    Private _correoEvalua As String
    Private _cargoEvalua As String
    Private _fechaRegistro As String
    Private _periodo As String
    Private _puntaje As String
    Private _estado As String
    Private _cargoEvaluado As String
    Private _personaEvalua As String
    Private _identificacionEvaluado As String
    Private _identificacionEvalua As String
    Private _proyecto As String

    <Description("Nombre completo Evaluado"), _
    Category("Evaluado"),
    DisplayNameAttribute("Nombre")> _
    Public ReadOnly Property IdPersonaNombre() As String
        Get
            Return _nombreEvaluado
        End Get
    End Property

    <Description("Número de identificación Evaluado"), _
    Category("Evaluado"),
    DisplayNameAttribute("Identificación")> _
    Public ReadOnly Property Identificacion() As String
        Get
            Return _identificacionEvaluado
        End Get
    End Property

    <Description("Cargo Evaluado"), _
 Category("Evaluado"),
 DisplayNameAttribute("Cargo")> _
    Public ReadOnly Property CargoEvaluado() As String
        Get
            Return _cargoEvaluado
        End Get
    End Property

    <Description("Identificador SIGMA de la evaluacion"), _
      Category(""),
      DisplayNameAttribute("Id Evaluación")> _
    Public ReadOnly Property IdPesona() As String
        Get
            Return _idEvaluacion
        End Get
    End Property


    <Description("Dirección de correo electrónico Evaluador"), _
    Category("Evaluador"),
    DisplayNameAttribute("Correo")> _
    Public ReadOnly Property CorreoElectronicoEvalua() As String
        Get
            Return _correoEvalua
        End Get
    End Property

    <Description("Cargo Evalua"), _
 Category("Evaluador"),
 DisplayNameAttribute("Cargo")> _
    Public ReadOnly Property CargoEvaluador() As String
        Get
            Return _cargoEvalua
        End Get
    End Property
    <Description("Nombre del Evaluador"), _
    Category("Evaluador"),
    DisplayNameAttribute("Nombre")> _
    Public ReadOnly Property UsuarioRegistra() As String
        Get
            Return _personaEvalua
        End Get
    End Property

    <Description("Número de identificación Evalua"), _
 Category("Evaluador"),
 DisplayNameAttribute("Identificación")> _
    Public ReadOnly Property IdentificacionEvalua() As String
        Get
            Return _identificacionEvalua
        End Get
    End Property

    <Description("Fecha de registro"), _
    Category("Evaluación"),
    DisplayNameAttribute("Fecha Registro")> _
    Public ReadOnly Property FechaRegistroEvaluacion() As String
        Get
            Return _fechaRegistro
        End Get
    End Property

    <Description("Periodo de Evaluación"), _
      Category("Evaluación"),
      DisplayNameAttribute("Periodo")> _
    Public ReadOnly Property periodo() As String
        Get
            Return _periodo
        End Get
    End Property

    <Description("Estado de la Evaluación"), _
   Category("Evaluación"),
   DisplayNameAttribute("Estado")> _
    Public ReadOnly Property estadoEvaluacion() As String
        Get
            Return _estado
        End Get
    End Property

    <Description("Puntaje"), _
    Category("Evaluación"),
    DisplayNameAttribute("Puntaje")> _
    Public ReadOnly Property Puntaje() As String
        Get
            Return _puntaje
        End Get
    End Property

    <Description("Token"), _
       Category(""),
       DisplayNameAttribute("Token")> _
    Public ReadOnly Property Idtoken() As String
        Get
            Return _token
        End Get
    End Property

    <Description("Proyecto"), _
      Category(""),
      DisplayNameAttribute("Proyecto")> _
    Public ReadOnly Property proyecto() As String
        Get
            Return _proyecto
        End Get
    End Property


    Public Sub New(ByVal FilaPersona As DataGridViewRow)
        Try
            _nombreEvaluado = FilaPersona.Cells("Persona Evaluado").Value
        Catch
            _nombreEvaluado = ""
        End Try
        Try
            _fechaRegistro = FilaPersona.Cells("FECHAREGISTRO").Value
        Catch
            _fechaRegistro = ""
        End Try
        Try
            _identificacionEvaluado = FilaPersona.Cells("Identificacion Evaluado").Value
        Catch
            _identificacionEvaluado = ""
        End Try
        Try
            _identificacionEvalua = FilaPersona.Cells("Identificación Evalua").Value
        Catch
            _identificacionEvalua = ""
        End Try

        Try
            _idEvaluacion = FilaPersona.Cells("Id").Value
        Catch
            _idEvaluacion = ""
        End Try

        Try
            _token = FilaPersona.Cells("CLAVEACCESOWEB").Value
        Catch
            _token = ""
        End Try

        Try
            Select Case FilaPersona.Cells("Estado").Value
                Case "A"
                    _estado = "Activa"
                Case "C"
                    _estado = "Completa"
            End Select
        Catch
            _estado = ""
        End Try
        Try
            _periodo = FilaPersona.Cells("Periodo").Value
        Catch
            _periodo = ""
        End Try

        Try
            _personaEvalua = FilaPersona.Cells("Persona Evalua").Value
        Catch
            _personaEvalua = ""
        End Try

        Try
            _cargoEvaluado = FilaPersona.Cells("CARGOEVALUADO").Value
        Catch
            _cargoEvaluado = ""
        End Try
        Try
            _cargoEvalua = FilaPersona.Cells("CARGOEVALUA").Value
        Catch
            _cargoEvalua = ""
        End Try
        Try
            _correoEvalua = FilaPersona.Cells("CORREOELECTRONICOEVALUA").Value
        Catch
            _correoEvalua = ""
        End Try
        Try
            _proyecto = FilaPersona.Cells("PROYECTO").Value
        Catch
            _proyecto = ""
        End Try

        Try
            _puntaje = FilaPersona.Cells("NIVELDESEMPEÑOTOTAL").Value
        Catch
            _puntaje = ""
        End Try

    End Sub
End Class