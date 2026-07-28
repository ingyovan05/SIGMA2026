Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing
Imports Microsoft.Office.Interop
Imports FormulariosOrdenesTrabajo

Public Class Cu_OrdendeTrabajo
    Public TipoExportarOT As Integer
    Public ReactivarPrincipal As Boolean = True
    Private dtServicios As New DataTable
    Private DtInformeCargar As New DataTable
    Private bddatos As New DatosClasesBase.Busquedas
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private dsOrdenesDeTrabajo As DataSet
    Private dtOrdenTrabajo As DataTable
    Private Index_Registro_Actual As Integer
    Private tablaCargada As Tablas
    Private IdBase As Integer = VariablesBase.VariablesBase.IdBaseSiscontrolActual
    Private Enum Tablas
        OrdenTrabajo
        MaterialNoConforme
        NoConformidad
        IntervencionDirecta
        ObrasSobreDDV
        Valvulas
        URPC
        DefectologiaXSoldador
        TablerosTBG
        PlanDeOptimizacion
    End Enum
    Structure EstadoOT
        Shared Programada As String = "PR"
        Shared NoEjecutada As String = "NE"
        Shared Aprobada As String = "AP"
        Shared Anulada As String = "AN"
        Shared EnEjecucion As String = "EJ"
        Shared Suspendida As String = "SU"
        Shared Terminada As String = "TE"
    End Structure


    Public Sub Comportamiento_Predeterminado()
        Me.Dgv_ListaOrdenTrabajo.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaOrdenTrabajo.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Nbc_OrdenesDeTrabajo.ActiveGroup = Me.Nbg_OrdenTrabajo
        'Orden de Trabajo
        Nbg_OrdenTrabajo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_OrdenTrabajo.Tag)
        Nbi_ListarOT.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarOT.Tag)
        Nbi_CrearOT.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearOT.Tag)
        Nbi_ClonarOT.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarOT.Tag)
        Nbi_ModificarOT.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ModificarOT.Tag)
        Nbi_CambiarEstado.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CambiarEstado.Tag)
        Nbi_ImprimirOT.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirOT.Tag)
        Nbi_BuscarOT.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarOT.Tag)
        Nbi_BuscarOT_Portapapeles.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarOT_Portapapeles.Tag)
        Nbi_VerOT.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerOT.Tag)
        Nbi_CambiarEstadoSAP.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CambiarEstadoSAP.Tag)
        ' Exportar Excel
        Nbg_ExportarExcel.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_ExportarExcel.Tag)
        Nbi_OM.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_OM.Tag)
        Nbi_SabanaFacturacionOM.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SabanaFacturacionOM.Tag)
        Nbi_ResumenFacturacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ResumenFacturacion.Tag)
        Nbi_AnalisisComparativoxOMs.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnalisisComparativoxOMs.Tag)
        Nbi_ImprObraEjecutadaxOM.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprObraEjecutadaxOM.Tag)
        Nbi_ImprAnalisisComparativo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprAnalisisComparativo.Tag)
        If Me.Nbi_AnalisisComparativoxOMs.Visible = False And Me.Nbi_ImprimirOT.Visible = False Then
            Me.NetBarItem1.Visible = False
        End If
        Nbi_Informe246.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Informe246.Tag)
        'Material No Conforme
        Nbg_MaterialNoConforme.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_MaterialNoConforme.Tag)
        Nbi_ListarMNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarMNC.Tag)
        Nbi_CrearMNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearMNC.Tag)
        Nbi_EditarMNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarMNC.Tag)
        Nbi_VerMNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerMNC.Tag)
        Nbi_AnularMNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularMNC.Tag)
        Nbi_CerrarMNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CerrarMNC.Tag)
        Nbi_BuscarMNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarMNC.Tag)
        'No Conformidad
        Nbg_NoConformidad.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_NoConformidad.Tag)
        Nbi_ListarNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarNC.Tag)
        Nbi_CrearNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearNC.Tag)
        Nbi_EditarNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarNC.Tag)
        Nbi_VerNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerNC.Tag)
        Nbi_AnularNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularNC.Tag)
        Nbi_CerrarMNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CerrarMNC.Tag)
        Nbi_BuscarMNC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarMNC.Tag)
        'Intervencón Directa
        Nbg_IntervencionDirecta.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_IntervencionDirecta.Tag)
        Nbi_ListarID.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarID.Tag)
        Nbi_BuscarID.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarID.Tag)
        'Obras Sobre DDV
        Nbg_ObrasSobreDDV.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_ObrasSobreDDV.Tag)
        Nbi_ListarOSDDV.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarOSDDV.Tag)
        Nbi_BuscarOSDDV.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarOSDDV.Tag)
        ' Válvulas
        Nbg_Valvulas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Valvulas.Tag)
        Nbi_ListarV.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarV.Tag)
        Nbi_BuscarV.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarV.Tag)
        'URPC
        Nbg_URPC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_URPC.Tag)
        Nbi_ListarURPC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarURPC.Tag)
        Nbi_BuscarURPC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarURPC.Tag)
        'Varaibles Mantenimiento
        Nbg_VariablesMantenimiento.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_VariablesMantenimiento.Tag)
        Nbi_Graficar.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Graficar.Tag)
        'Defectología Por Soldador
        Nbg_DefectologiaXSoldador.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_DefectologiaXSoldador.Tag)
        Nbi_ListarDS.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarDS.Tag)
        Nbi_BuscarDS.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarDS.Tag)
        'Tableros TBG
        Nbg_TablerosTBG.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_TablerosTBG.Tag)
        Nbi_CargarTBG.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarTBG.Tag)
        Nbi_CrearTBG.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearTBG.Tag)
        Nbi_EditarTBG.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarTBG.Tag)
        Nbi_VerTBG.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerTBG.Tag)
        Nbi_BuscarTBG.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarTBG.Tag)
        'Plan de Optimización
        Nbg_PlanDeOptimizacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_PlanDeOptimizacion.Tag)
        Nbi_ListarPlanesOptimizacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarPlanesOptimizacion.Tag)
        Nbi_CrearPlanOptimizacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearPlanOptimizacion.Tag)
        Nbi_EditarPlanOptimizacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarPlanOptimizacion.Tag)
        Nbi_VerPlanOptimizacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPlanOptimizacion.Tag)
        Nbi_BuscarPlanesOptimizacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarPlanesOptimizacion.Tag)
    End Sub

    Public Sub Cargar_Tabla()
        Me.Cursor = Cursors.WaitCursor
        dsOrdenesDeTrabajo = bddatos.BusquedaCondiciones(35, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        If dsOrdenesDeTrabajo.Tables.Count > 0 Then
            dtOrdenTrabajo = dsOrdenesDeTrabajo.Tables(1)
            If dtOrdenTrabajo.Rows.Count > 0 Then
                Dgv_ListaOrdenTrabajo.DataSource = dtOrdenTrabajo
                Lb_CantidadOrdenTrabajo.Text = "Cantidad de Ordenes de Mantenimiento " + dtOrdenTrabajo.Rows.Count.ToString
            End If
        End If
        tablaCargada = Tablas.OrdenTrabajo
        AplicarFormatoColumnas()
        Dgv_ListaOrdenTrabajo.Focus()
        Ubicar_Registro()
        ReactivarPrincipal = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AplicarFormatoColumnas()
        Select Case tablaCargada
            Case Tablas.OrdenTrabajo
                SplitContainer1.Panel2Collapsed = False
                For i = 0 To Dgv_ListaOrdenTrabajo.ColumnCount - 1
                    If IdBase = 121 Or IdBase = 122 Or IdBase = 123 Or IdBase = 124 Or IdBase = 125 Then
                        Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                            Case "IDORDENTRABAJO"
                                Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Id Orden Mantenimiento"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Id OT"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Case "NROORDENSAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Número orden SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Nro SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                                Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Case "CODIGOORDENCLIENTE"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Código Orden Ismocol"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Cod. Ismocol"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                                Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Case "NOMBREBASE"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 140
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Base"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Base"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Case "FECHAINICIO"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha Inicio SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "F Inicio SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Case "OBJETO"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 300
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Objeto"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Objeto"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Case "FECHAFINEXTREMO"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha Fin Extremo"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "F Fin Ext"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Case "VALORTOTALSAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Total SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Total SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Format = "C"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            Case "VALORTOTALISMOCOL"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Total Ismocol"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Total ISM"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Format = "C"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            Case "ESTADO"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Estado"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Estado"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Case "ESTADOSAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 120
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Estado SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Estado SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Case Else
                                Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                        End Select
                    Else
                        Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                            Case "IDORDENTRABAJO"
                                Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Id Orden Mantenimiento"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Id OT"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Case "NROORDENSAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Número orden SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Nro SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                                Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Case "NOMBREBASE"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 140
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Base"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Base"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Case "FECHAINICIO"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha Inicio SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "F Inicio SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Case "OBJETO"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 300
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Objeto"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Objeto"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Case "FECHAFINEXTREMO"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha Fin Extremo"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "F Fin Ext"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Case "VALORTOTALSAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Total SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Total SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Format = "C"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            Case "VALORTOTALISMOCOL"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Total Ismocol"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Total ISM"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Format = "C"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            Case "ESTADO"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Estado"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Estado"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Case "ESTADOSAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).Width = 120
                                Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Estado SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Estado SAP"
                                Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Case Else
                                Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                        End Select
                    End If
                Next
                Try
                    If VariablesBase.VariablesBase.TipoUsuario = 26 Or VariablesBase.VariablesBase.TipoUsuario = 50 Then
                        For i = 0 To Dgv_ListaOrdenTrabajo.ColumnCount - 1
                            Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                                Case "VALORTOTALSAP", "VALORTOTALISMOCOL"
                                    Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                            End Select
                        Next
                    End If
                Catch ex As Exception
                End Try
            Case Tablas.MaterialNoConforme
                SplitContainer1.Panel2Collapsed = True
                For i = 0 To Dgv_ListaOrdenTrabajo.ColumnCount - 1
                    Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                        Case "IDMATERIALNOCONFORME"
                            Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Id registro de Material No Conforme"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Id"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "NUMEROREPORTE"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Número de Reporte"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "No. Reporte"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "FECHARECEPCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha de Recepción"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Fecha Recepción"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "FECHACIERRE"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha de cierre del Reporte"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Fecha Cierre"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case Else
                            Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                    End Select
                Next
            Case Tablas.NoConformidad
                SplitContainer1.Panel2Collapsed = True
                For i = 0 To Dgv_ListaOrdenTrabajo.ColumnCount - 1
                    Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                        Case "IDNOCONFORMIDAD"
                            Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Id registro de No Conformidad"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Id"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "NUMEROREPORTE"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Número de Reporte"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "No. Reporte"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "FECHA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha del Reporte"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Fecha Reporte"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "FECHACIERRE"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha de cierre del Reporte"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Fecha Cierre"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case Else
                            Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                    End Select
                Next
            Case Tablas.IntervencionDirecta
                SplitContainer1.Panel2Collapsed = True
                For i = 0 To Dgv_ListaOrdenTrabajo.ColumnCount - 1
                    Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                        Case "IDCONSECUTIVO"
                            Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Id consecutivo de intervenciòn directa"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Id"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "SISTEMA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Sistema"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Sistema"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "LINEA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Línea"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Línea"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "NROORDENSAP"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Numero de Orden Sap"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Nro SAP"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "FECHAINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Fecha Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "BASE"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Nombre Base"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Base"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "AÑO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Año"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Año"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "TIPOINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Tipo Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Tipo Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "CAUSAINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Causa Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Causa Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "ANOMALIADEBAJODESOBRECAMISA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Anomalia de bajo de sobre Camisa"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Anom. Baj. Sobre Camisa"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "TIPORECUBRIMIENTO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Tipo Recubrimiento"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "T. Recubrim."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "FUNCIONARIOREALIZALIBERACIONCALIDAD"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Funcionario Realiza Liberación Calidad"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Func. Rea. Lib. Cal."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "EVIDENCIANOMBREINFORMECAMPO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Evidencia Nombre Informe Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Evid. Nomb. Inf. Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "URLUBICACIONINFORMECAMPO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Url Ubicación Informe Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Url Ubi. Inf. Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case Else
                            Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                    End Select
                Next
            Case Tablas.ObrasSobreDDV
                SplitContainer1.Panel2Collapsed = True
                For i = 0 To Dgv_ListaOrdenTrabajo.ColumnCount - 1
                    Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                        Case "IDCONSECUTIVO"
                            Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Id consecutivo de Obras Sobre DDV"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Id"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "SISTEMA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Sistema"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Sistema"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "LINEA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Línea"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Línea"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "NROORDENSAP"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Número de Orden Sap"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Nro SAP"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "FECHAINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Fecha Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "BASE"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Nombre Base"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Base"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "AÑO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Año"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Año"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "TIPOINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Tipo Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Tipo Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "CAUSAINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Causa Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Causa Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "FUNCIONARIOREALIZALIBERACIONCALIDAD"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Funcionario Realiza Liberación Calidad"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Func. Rea. Lib. Cal."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "EVIDENCIANOMBREINFORMECAMPO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Evidencia Nombre Informe Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Evid. Nomb. Inf. Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "URLUBICACIONINFORMECAMPO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Url Ubicación Informe Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Url Ubi. Inf. Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case Else
                            Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                    End Select
                Next
            Case Tablas.Valvulas
                SplitContainer1.Panel2Collapsed = True
                For i = 0 To Dgv_ListaOrdenTrabajo.ColumnCount - 1
                    Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                        Case "IDCONSECUTIVO"
                            Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Id consecutivo de Válvulas"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Id"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "TRONCAL"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Troncal"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Troncal"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "SISTEMA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Sistema"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Sistema"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "NROORDENSAP"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Numero de Orden Sap"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Nro SAP"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "FECHAINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Fecha Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "BASE"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Nombre Base"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Base"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "AÑO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Año"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Año"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "NOMBREVALVULA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Nombre Válvula"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Nombre Válvula"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "ABSCISADOCAMPO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Abscisado Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Abscisado C."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "TIPOVALVULA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Tipo Válvula"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Tipo Válvula"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "RATING"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Rating"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Rating"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "DIAMETRO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Diametro"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Diametro"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "TIPOACTUADOR"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Tipo Actuador"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "T. Actuador"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "ESTADOOPERACION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Estado de Operación"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Est. Oper."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "TIPOINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Tipo Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Tipo Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "CAUSAINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Causa Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Causa Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "URLUBICACIONINFORME"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Url Ubicación Informe Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Url Ubi. Inf. Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case Else
                            Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                    End Select
                Next
            Case Tablas.URPC
                SplitContainer1.Panel2Collapsed = True
                For i = 0 To Dgv_ListaOrdenTrabajo.ColumnCount - 1
                    Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                        Case "IDCONSECUTIVO"
                            Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Id consecutivo de URPC"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Id"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "TRONCAL"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Troncal"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Troncal"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "SISTEMA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Sistema"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Sistema"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "NROORDENSAP"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Numero de Orden Sap"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Nro SAP"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "FECHAINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Fecha Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "BASE"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Nombre Base"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Base"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "AÑO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Año"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Año"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "NOMBREURPC"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Nombre URPC"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Nombre URPC"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "ABSCISADOCAMPO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Abscisado Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Abscisado C."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "TIPOINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Tipo Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Tipo Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "CAUSAINTERVENCION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Causa Intervención"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Causa Interv."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "URLUBICACIONINFORME"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Url Ubicación Informe Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Url Ubi. Inf. Campo"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case Else
                            Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                    End Select
                Next
            Case Tablas.DefectologiaXSoldador
                SplitContainer1.Panel2Collapsed = True
                For i = 0 To Dgv_ListaOrdenTrabajo.ColumnCount - 1
                    Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                        Case "IDCONSECUTIVO"
                            Dgv_ListaOrdenTrabajo.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Id consecutivo de defectología"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Id"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "ZONA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Zona"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Zona"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "BASE"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Base"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Base"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "TRABAJADOR"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 200
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Trabajador"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Trabajador"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "MES"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 80
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Mes"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Mes"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "AÑO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Año"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Año"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "NOMBREURPC"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Nombre URPC"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Nombre"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "JUNTASDEFECTUOSAS"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 40
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Juntas Defectuosas"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "J. Defec."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "JUNTASINSPECCIONADASPOREND"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 40
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Juntas Inspeccionadas Por End"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "J. Inspec."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case Else
                            Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                    End Select
                Next
            Case Tablas.TablerosTBG
                SplitContainer1.Panel2Collapsed = True
                For i = 0 To Dgv_ListaOrdenTrabajo.ColumnCount - 1
                    Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                        Case "IDTABLEROTBG"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Identificador del TBG"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Id."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "FECHAMEDICION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha de medición"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Fecha Medición"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "NOMBREPERIODO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Periodo de medición"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Periodo"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "FECHAPRESENTACION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 100
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Fecha de presentación"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Fecha Presentación"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case Else
                            Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                    End Select
                Next
                Dgv_ListaOrdenTrabajo.AutoResizeColumns()
            Case Tablas.PlanDeOptimizacion
                SplitContainer1.Panel2Collapsed = True
                For i = 0 To Dgv_ListaOrdenTrabajo.ColumnCount - 1
                    Select Case Dgv_ListaOrdenTrabajo.Columns(i).Name
                        Case "IDPLANOPTIMIZACION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 60
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Identificador de plan de optimización"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Id."
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Case "TITULO"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 200
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Título de plan de optimización"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Título"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "PROPOSITOMEJORA"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 300
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Propósito de mejora de plan de optimización"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Propósito Mejora"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "NOMBREARCHIVOOPTIMIZACION"
                            Dgv_ListaOrdenTrabajo.Columns(i).Width = 200
                            Dgv_ListaOrdenTrabajo.Columns(i).ToolTipText = "Nombre del archivo de optimización"
                            Dgv_ListaOrdenTrabajo.Columns(i).HeaderText = "Archivo Optimización"
                            Dgv_ListaOrdenTrabajo.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case Else
                            Dgv_ListaOrdenTrabajo.Columns(i).Visible = False
                    End Select
                Next
                Dgv_ListaOrdenTrabajo.AutoResizeColumns()
            Case Else

        End Select
    End Sub

    Private Sub Dgv_ListaOrdenTrabajo_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Dgv_ListaOrdenTrabajo.CellFormatting
        Try
            Select Case tablaCargada
                Case Tablas.OrdenTrabajo
                    Dim dgv As DataGridView
                    dgv = sender
                    If dgv.Columns(e.ColumnIndex).Name = "ESTADO" Then
                        Dim _filaDGV As DataGridViewRow = dgv.Rows(e.RowIndex)
                        Select Case e.Value.ToString
                            Case "EJECUCION"
                                _filaDGV.DefaultCellStyle.ForeColor = Color.Black
                            Case "CERRADA", "CANCELADA", "SUSPENDIDA"
                                _filaDGV.DefaultCellStyle.ForeColor = Color.Red
                            Case "PLANEADA", "PLANEACION"
                                _filaDGV.DefaultCellStyle.ForeColor = Color.DarkBlue
                        End Select
                    End If
                Case Tablas.MaterialNoConforme
                Case Tablas.NoConformidad
                Case Tablas.IntervencionDirecta
                Case Tablas.ObrasSobreDDV
                Case Tablas.Valvulas
                Case Tablas.URPC
                Case Tablas.DefectologiaXSoldador
                Case Tablas.TablerosTBG
                Case Tablas.PlanDeOptimizacion
                Case Else

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgv_ListaOrdenTrabajo_DoubleClick(sender As Object, e As System.EventArgs) Handles Dgv_ListaOrdenTrabajo.DoubleClick
        Select Case tablaCargada
            Case Tablas.OrdenTrabajo
                EditarOrdenTrabajo()
            Case Tablas.MaterialNoConforme
                EditarMNC(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDMATERIALNOCONFORME").Value)
            Case Tablas.NoConformidad
                EditarNC(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDNOCONFORMIDAD").Value)
            Case Tablas.IntervencionDirecta
                EditarNC(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDCONSECUTIVO").Value)
            Case Tablas.ObrasSobreDDV
            Case Tablas.Valvulas
            Case Tablas.URPC
            Case Tablas.DefectologiaXSoldador
            Case Tablas.TablerosTBG
                EditarTBG(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDTABLEROTBG").Value)
            Case Tablas.PlanDeOptimizacion
                EditarPDO(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDPLANOPTIMIZACION").Value)
            Case Else

        End Select
    End Sub

    Private Sub Dgv_ListaOrdenTrabajo_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles Dgv_ListaOrdenTrabajo.SelectionChanged
        Try
            Dim xx As Object
            Select Case tablaCargada
                Case Tablas.OrdenTrabajo
                    xx = New Pro_OT(Dgv_ListaOrdenTrabajo.SelectedRows(0))
                    CargarServicios()
                Case Tablas.MaterialNoConforme
                    xx = New Pro_MaterialNoConforme(Dgv_ListaOrdenTrabajo.SelectedRows(0))
                Case Tablas.NoConformidad
                    xx = New Pro_NoConformidad(Dgv_ListaOrdenTrabajo.SelectedRows(0))
                Case Tablas.IntervencionDirecta
                    xx = New Pro_IntervencionDirecta(Dgv_ListaOrdenTrabajo.SelectedRows(0))
                Case Tablas.ObrasSobreDDV
                    xx = New Pro_ObrasSobreDDV(Dgv_ListaOrdenTrabajo.SelectedRows(0))
                Case Tablas.Valvulas
                    xx = New Pro_Valvulas(Dgv_ListaOrdenTrabajo.SelectedRows(0))
                Case Tablas.URPC
                    xx = New Pro_URPC(Dgv_ListaOrdenTrabajo.SelectedRows(0))
                Case Tablas.DefectologiaXSoldador
                    Exit Sub
                Case Tablas.TablerosTBG
                    xx = New Pro_TableroTBG(Dgv_ListaOrdenTrabajo.SelectedRows(0))
                Case Tablas.PlanDeOptimizacion
                    xx = New Pro_PlanOptimizacion(Dgv_ListaOrdenTrabajo.SelectedRows(0))
                Case Else
                    Exit Sub
            End Select
            Pg_Propiedades.SelectedObject = xx
        Catch ex As Exception
            Pg_Propiedades.SelectedObject = Nothing
        End Try
    End Sub

    Private Sub Cu_OrdendeTrabajo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, Dgv_ListaOrdenTrabajo.KeyDown, Nbc_OrdenesDeTrabajo.KeyDown, Dgv_ListaServicios.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                FuncionesBase.FuncionesBase.AbrirAyudaOnline("/Inicio.aspx?MODULO=Ordenes")
            Case Keys.F2
                Select Case tablaCargada
                    Case Tablas.OrdenTrabajo
                        CrearOT()
                    Case Tablas.MaterialNoConforme
                        RegistrarMNC()
                    Case Tablas.NoConformidad
                        RegistrarNC()
                    Case Tablas.IntervencionDirecta
                    Case Tablas.ObrasSobreDDV
                    Case Tablas.Valvulas
                    Case Tablas.URPC
                    Case Tablas.DefectologiaXSoldador
                    Case Tablas.TablerosTBG
                        CrearTBG()
                    Case Tablas.PlanDeOptimizacion
                        CrearPDO()
                    Case Else

                End Select
            Case Keys.F3
                Select Case tablaCargada
                    Case Tablas.OrdenTrabajo
                        BuscarOT()
                    Case Tablas.MaterialNoConforme
                        BuscarMNC()
                    Case Tablas.NoConformidad
                        BuscarNC()
                    Case Tablas.IntervencionDirecta
                        BuscarID()
                    Case Tablas.ObrasSobreDDV
                        BuscarOSDDV()
                    Case Tablas.Valvulas
                        BuscarV()
                    Case Tablas.URPC
                        BuscarURPC()
                    Case Tablas.TablerosTBG
                        BuscarTBG()
                    Case Tablas.PlanDeOptimizacion
                        BuscarPDO()
                    Case Else

                End Select
            Case Keys.F4
                Cargar_Tabla()
                Nbc_OrdenesDeTrabajo.ActiveGroup = Nbg_OrdenTrabajo
            Case Keys.F6
                ExportarDatosExcel(Dgv_ListaOrdenTrabajo)
            Case Keys.F7

            Case Keys.F8

            Case Keys.F9

            Case Keys.F10

            Case Keys.F11

            Case Keys.F12
                FuncionesBase.FuncionesBase.AbrirAccesoRemoto()
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
            With .Range(.Cells(1, 1), .Cells(1, Dgv_ListaOrdenTrabajo.Columns.Count)).Font
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

    Public Sub Ubicar_Registro()
        Try
            Dgv_ListaOrdenTrabajo.CurrentCell = Dgv_ListaOrdenTrabajo(0, Index_Registro_Actual)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Dgv_ListaOrdenTrabajo_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles Dgv_ListaOrdenTrabajo.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If Dgv_ListaOrdenTrabajo.RowHeadersWidth < CInt(size.Width + 20) Then
            Dgv_ListaOrdenTrabajo.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim bt As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

#Region "Orden de Trabajo"
    Private Sub Nbi_ListarOT_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarOT.ItemClick
        Cargar_Tabla()
    End Sub

    Private Sub Nbi_CrearOT_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_CrearOT.ItemClick
        CrearOT()
    End Sub

    Private Sub CrearOT()
        Me.ReactivarPrincipal = False
        Dim FrOrdenesTrabajo As New FormulariosOrdenesTrabajo.Fr_OT

        Dim Consultar As New Boolean
        Dim Fr_OM As New Form
        Dim Lb_Texto As New Label
        Dim Bt_Ocensa As New Button
        Dim Bt_ODC As New Button
        Dim Bt_Cancelar As New Button

        With Lb_Texto
            .AutoSize = True
            .Location = New System.Drawing.Point(20, 27)
            .Name = "Lb_Texto"
            .Size = New System.Drawing.Size(20, 13)
            .Text = "Crear Orden de Mantenimiento de: "
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With

        With Bt_Ocensa
            .Location = New System.Drawing.Point(20, 68)
            .Name = "Bt_Ocensa"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = 4
            .Text = "Ocensa"
            .UseVisualStyleBackColor = True
        End With

        With Bt_ODC
            .Location = New System.Drawing.Point(100, 68)
            .Name = "Bt_ODC"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = 4
            .Text = "Odc"
            .UseVisualStyleBackColor = True
        End With

        With Bt_Cancelar
            .Location = New System.Drawing.Point(180, 68)
            .Name = "Bt_Cancelar"
            .Size = New System.Drawing.Size(75, 23)
            .TabIndex = 5
            .Text = "Cancelar"
            .UseVisualStyleBackColor = True
        End With

        With Fr_OM
            .AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            .AcceptButton = Bt_Ocensa
            .FormBorderStyle = FormBorderStyle.Sizable
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New System.Drawing.Size(280, 140)
            .MaximumSize = New System.Drawing.Size(280, 140)
            .MinimumSize = New System.Drawing.Size(280, 140)
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Crear OM"
            .Controls.Add(Lb_Texto)
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_ODC)
            .Controls.Add(Bt_Ocensa)
        End With


        AddHandler Bt_Ocensa.Click, Sub()

                                        Consultar = True
                                        FrOrdenesTrabajo.Proyecto = "O"
                                        FrOrdenesTrabajo.Cargar_Tablas()
                                        FrOrdenesTrabajo.Cu_padre = New Object
                                        FrOrdenesTrabajo.Cu_padre = Me
                                        FrOrdenesTrabajo.ShowDialog()
                                        Fr_OM.Close()
                                    End Sub

        AddHandler Bt_ODC.Click, Sub()
                                     Consultar = True
                                     FrOrdenesTrabajo.Proyecto = "D"
                                     FrOrdenesTrabajo.Cargar_Tablas()
                                     FrOrdenesTrabajo.Cu_padre = New Object
                                     FrOrdenesTrabajo.Cu_padre = Me
                                     FrOrdenesTrabajo.ShowDialog()
                                     Fr_OM.Close()
                                 End Sub

        AddHandler Bt_Cancelar.Click, Sub()

                                          If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then

                                              Consultar = False
                                              Fr_OM.Close()
                                          End If
                                      End Sub

        If IdBase = 121 Or IdBase = 123 Or IdBase = 124 Then
            Fr_OM.ShowDialog()
        Else
            If IdBase = 122 Or IdBase = 125 Then
                FrOrdenesTrabajo.Proyecto = "O"
                FrOrdenesTrabajo.Cargar_Tablas()
                FrOrdenesTrabajo.Cu_padre = New Object
                FrOrdenesTrabajo.Cu_padre = Me
                FrOrdenesTrabajo.ShowDialog()
            Else
                FrOrdenesTrabajo.Proyecto = "C"
                FrOrdenesTrabajo.Cargar_Tablas()
                FrOrdenesTrabajo.Cu_padre = New Object
                FrOrdenesTrabajo.Cu_padre = Me
                FrOrdenesTrabajo.ShowDialog()
            End If
        End If


        Me.ReactivarPrincipal = True
    End Sub

    Private Sub Nbi_ClonarOT_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ClonarOT.ItemClick
        If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
            Try
                Me.ReactivarPrincipal = False
                Dim IndiceFilaseleccionada As Integer = Dgv_ListaOrdenTrabajo.CurrentRow.Index
                Dim FrOT As New FormulariosOrdenesTrabajo.Fr_OT
                FrOT.IdOrdenTrabajoModificar = Me.Dgv_ListaOrdenTrabajo.Rows(IndiceFilaseleccionada).Cells(0).Value
                Index_Registro_Actual = Me.Dgv_ListaOrdenTrabajo.CurrentCell.RowIndex
                FrOT.tipoAccion = "E"
                FrOT.CargarProyecto()
                FrOT.Cargar_Tablas()
                FrOT.CargarDatosOT()
                FrOT.LimpiarXClonación()
                FrOT.Cu_padre = New Object
                FrOT.Cu_padre = Me
                FrOT.Show()
            Catch ex As Exception
                MsgBox("Ocurrio un error al intentar recuperar los datos, revise y vuelva a intentar")
            End Try
        End If
    End Sub

    Private Sub Nbi_VerOT_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerOT.ItemClick
        VerOrdenTrabajo()
    End Sub

    Public Sub VerOrdenTrabajo()
        If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
            Try
                Me.ReactivarPrincipal = False
                Dim IndiceFilaseleccionada As Integer = Dgv_ListaOrdenTrabajo.CurrentRow.Index
                Dim FrOT As New FormulariosOrdenesTrabajo.Fr_OT
                FrOT.IdOrdenTrabajoModificar = Me.Dgv_ListaOrdenTrabajo.Rows(IndiceFilaseleccionada).Cells(0).Value
                Index_Registro_Actual = Me.Dgv_ListaOrdenTrabajo.CurrentCell.RowIndex

                Dim IdbaseReporte As Integer
                IdbaseReporte = Me.Dgv_ListaOrdenTrabajo.Rows(IndiceFilaseleccionada).Cells("IDBASE").Value

                Dim Estado As String = ""
                Estado = Me.Dgv_ListaOrdenTrabajo.Rows(IndiceFilaseleccionada).Cells("ESTADO").Value

                FrOT.tipoAccion = "V"
                FrOT.Cargar_Tablas()
                FrOT.CargarDatosOT()
                FrOT.Cu_padre = New Object
                FrOT.Cu_padre = Me
                FrOT.Show()
            Catch ex As Exception
                MsgBox("Ocurrio un error al intentar recuperar los datos, revise y vuelva a intentar")
            End Try
        End If
    End Sub

    Private Sub Nbi_ModificarOT_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ModificarOT.ItemClick
        EditarOrdenTrabajo()
    End Sub

    Public Sub EditarOrdenTrabajo()
        If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
            Try
                Me.ReactivarPrincipal = False
                Dim IndiceFilaseleccionada As Integer = Dgv_ListaOrdenTrabajo.CurrentRow.Index
                Dim FrOT As New FormulariosOrdenesTrabajo.Fr_OT
                FrOT.IdOrdenTrabajoModificar = Me.Dgv_ListaOrdenTrabajo.Rows(IndiceFilaseleccionada).Cells(0).Value
                Index_Registro_Actual = Me.Dgv_ListaOrdenTrabajo.CurrentCell.RowIndex

                Dim IdbaseReporte As Integer
                IdbaseReporte = Me.Dgv_ListaOrdenTrabajo.Rows(IndiceFilaseleccionada).Cells("IDBASE").Value

                Dim Estado As String = ""
                Estado = Me.Dgv_ListaOrdenTrabajo.Rows(IndiceFilaseleccionada).Cells("ESTADO").Value

                Dim EstadoSAP As String = ""
                EstadoSAP = Me.Dgv_ListaOrdenTrabajo.Rows(IndiceFilaseleccionada).Cells("ESTADOSAP").Value

                If FuncionesBase.FuncionesBase.ConsultarPermiso(770) = False Then
                    If EstadoSAP = "OTAP - FACTURADA" Then
                        MsgBox("No se puede editar la orden de trabajo en este estado SAP, debe se diferente a OTAP - FACTURADA para poder editarla", MsgBoxStyle.Information, "Estado de la Orden")
                        Exit Sub
                    End If
                End If
                If VariablesBase.VariablesBase.TipoUsuario = 26 Or VariablesBase.VariablesBase.TipoUsuario = 50 Then  'verificar que los supervisores no puedan modificar
                    If VariablesBase.VariablesBase.IdBaseSiscontrolActual <> IdbaseReporte Then
                        MsgBox("No se puede editar la orden de trabajo desde esta base", MsgBoxStyle.Critical, "Base no valida")
                        Exit Sub
                    End If

                    If Estado <> "PLANEACION" Then
                        MsgBox("No se puede editar la orden de trabajo en este estado, debe estar en PLANEACION para poder editarla", MsgBoxStyle.Information, "Estado de la Orden")
                        Exit Sub
                    End If

                    Dim IDPERSONASUPERVISORISMOCOL As Integer
                    IDPERSONASUPERVISORISMOCOL = Me.Dgv_ListaOrdenTrabajo.Rows(IndiceFilaseleccionada).Cells("IDPERSONASUPERVISORISMOCOL").Value

                    If IDPERSONASUPERVISORISMOCOL <> VariablesBase.VariablesBase.IdPersona Then
                        MsgBox("Esta Orden de mantenimiento no esta asignada a el usuario actual, esta asignada al supervisor " + Me.Dgv_ListaOrdenTrabajo.Rows(IndiceFilaseleccionada).Cells("Supervisor Ismocol").Value, MsgBoxStyle.Information, "Usuario Incorrecto")
                        Exit Sub
                    End If
                Else
                    Select Case IdbaseReporte
                        Case 94, 103, 107, 108 'Area oriente
                            Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                                Case 95, 96, 97, 98, 106, 119, 101, 102, 99, 100, 105, 109
                                    MsgBox("No se puede editar la orden de trabajo desde esta base")
                                    Exit Sub
                            End Select
                        Case 95, 96, 97, 98, 106, 119 'Area Norte
                            Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                                Case 94, 103, 107, 108, 101, 102, 99, 100, 105, 109
                                    MsgBox("No se puede editar la orden de trabajo desde esta base")
                                    Exit Sub
                            End Select
                        Case 101, 102 'Area Magdalena
                            Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                                Case 95, 96, 97, 98, 106, 119, 94, 103, 107, 108, 99, 100, 105, 109
                                    MsgBox("No se puede editar la orden de trabajo desde esta base")
                                    Exit Sub
                            End Select
                        Case 99, 100, 105, 109 'Area Andina
                            Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                                Case 94, 103, 107, 108, 95, 96, 97, 98, 106, 119, 101, 102
                                    MsgBox("No se puede editar la orden de trabajo desde esta base")
                                    Exit Sub
                            End Select
                    End Select
                End If
                FrOT.tipoAccion = "E"
                FrOT.CargarProyecto()
                FrOT.Cargar_Tablas()
                FrOT.CargarDatosOT()
                FrOT.Cu_padre = New Object
                FrOT.Cu_padre = Me
                FrOT.Show()
            Catch ex As Exception
                MsgBox("Ocurrio un error al intentar recuperar los datos, revise y vuelva a intentar")
            End Try
        End If
    End Sub

    Private Sub CargarServicios()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM ListaServiciosOT(@IDOTSERVICIO)", conexion)
        comando.Parameters.AddWithValue("@IDOTSERVICIO", Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells(0).Value)
        Dim adaptador As New SqlDataAdapter(comando)
        dtServicios.Clear()
        Try
            conexion.Open()
            adaptador.Fill(dtServicios)
            conexion.Close()
            Me.Dgv_ListaServicios.DataSource = dtServicios
            Me.Lb_CantidadServicios.Text = "Lista de Servicios Asociados a la OT: " + Dgv_ListaServicios.RowCount.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
        AplicarFormatoColumnasServicios()
    End Sub

    Private Sub AplicarFormatoColumnasServicios()
        For i = 0 To Dgv_ListaServicios.ColumnCount - 1
            Select Case Dgv_ListaServicios.Columns(i).Name
                Case "Código"
                    Dgv_ListaServicios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_ListaServicios.Columns(i).ToolTipText = "Codigo Servicio"
                    Dgv_ListaServicios.Columns(i).HeaderText = "Código"
                    Dgv_ListaServicios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv_ListaServicios.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                Case "Nombre"
                    Dgv_ListaServicios.Columns(i).ToolTipText = "Nombre Servicio"
                    Dgv_ListaServicios.Columns(i).HeaderText = "Nombre"
                    Dgv_ListaServicios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_ListaServicios.Columns(i).Width = 420
                Case "Valor Unitario"
                    Dgv_ListaServicios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_ListaServicios.Columns(i).ToolTipText = "Valor Unitario"
                    Dgv_ListaServicios.Columns(i).HeaderText = "Vr Unitario"
                    Dgv_ListaServicios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "Fecha Inicial"
                    Dgv_ListaServicios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_ListaServicios.Columns(i).ToolTipText = "Fecha Inicial"
                    Dgv_ListaServicios.Columns(i).HeaderText = "F Inicial"
                    Dgv_ListaServicios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Fecha Final"
                    Dgv_ListaServicios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_ListaServicios.Columns(i).ToolTipText = "Fecha Final"
                    Dgv_ListaServicios.Columns(i).HeaderText = "F Final"
                    Dgv_ListaServicios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Unidad"
                    Dgv_ListaServicios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_ListaServicios.Columns(i).ToolTipText = "Tipo Unidad"
                    Dgv_ListaServicios.Columns(i).HeaderText = "Und"
                    Dgv_ListaServicios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Cantidad"
                    Dgv_ListaServicios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_ListaServicios.Columns(i).ToolTipText = "Cantidad"
                    Dgv_ListaServicios.Columns(i).HeaderText = "Cant"
                    Dgv_ListaServicios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "Valor Total"
                    Dgv_ListaServicios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_ListaServicios.Columns(i).ToolTipText = "Valor Total Servicio"
                    Dgv_ListaServicios.Columns(i).HeaderText = "Vr Total"
                    Dgv_ListaServicios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Dgv_ListaServicios.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                Case ""
                Case Else
                    Dgv_ListaServicios.Columns(i).Visible = False
            End Select
        Next
        Try
            If VariablesBase.VariablesBase.TipoUsuario = 26 Or VariablesBase.VariablesBase.TipoUsuario = 50 Then
                For i = 0 To Dgv_ListaServicios.ColumnCount - 1
                    Select Case Dgv_ListaServicios.Columns(i).Name
                        Case "Valor Total", "Valor Unitario"
                            Dgv_ListaServicios.Columns(i).Visible = False
                    End Select
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Nbi_BuscarOT_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarOT.ItemClick
        BuscarOT()
    End Sub

    Private Sub BuscarOT()
        Me.ReactivarPrincipal = False
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("OT.NROORDENSAPPADRE", "Código de la orden de trabajo padre", "2")
        campos.Rows.Add("OT.NROORDENSAP", "Código de la orden de trabajo", "2")
        campos.Rows.Add("OT.CODIGOORDENCLIENTE", "Código Orden Ismocol", "1")
        campos.Rows.Add("B.NOMBREBASE", "Nombre de la base", "1")
        campos.Rows.Add("11", "Persona Registro OM", "7")
        campos.Rows.Add("OT.FECHACREACIONSAP", "Fecha de creacion SAP", "3")
        campos.Rows.Add("OT.OBJETO", "Objeto de la orden de trabajo", "1")
        campos.Rows.Add("9", "Todas OT Supervisadas Usuario Actual", "4") 'Consulta especial
        campos.Rows.Add("UT.CODIGOUBICACIONTECNICA", "Ubicación Técnica  SAP", "1")
        campos.Rows.Add("OT.VEREDA", "Vereda", "1")
        campos.Rows.Add("E.IDEQUIPOSAP", "Equipo SAP", "2")
        campos.Rows.Add("OT.FECHAINICIO", "Fecha de inicio", "3")
        campos.Rows.Add("S.CODIGOSERVICIO", "Código de servicio", "1")
        campos.Rows.Add("UT.EMPLAZAMIENTO", "Emplazamiento Ubicación Técnica  SAP", "1")
        campos.Rows.Add("MTCO.CODIGOTIPOCLASEORDEN", "Código Tipo Clase Orden", "1")
        campos.Rows.Add("MTCO.NOMBRETIPOCLASEORDEN", "Descripción Tipo Clase Orden", "1")
        campos.Rows.Add("2", "OT en ejecución base actual", "4") 'Consulta especial
        campos.Rows.Add("3", "OT suspendidas base actual", "4") 'Consulta especial
        campos.Rows.Add("4", "OT cerradas base actual", "4") 'Consulta especial
        campos.Rows.Add("5", "OT canceladas base actual", "4") 'Consulta especial
        campos.Rows.Add("6", "Todas OT base actual", "4") 'Consulta especial
        campos.Rows.Add("7", "Todas OT zona actual", "4") 'Consulta especial
        campos.Rows.Add("8", "Todas OT en ejecución zona actual", "4") 'Consulta especial
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de Ordenes de Trabajo"
        frbuscar.tabla = 35
        frbuscar.ShowDialog()
        Try
            Dim DSbusqueda = frbuscar.DsBuscar
            dsOrdenesDeTrabajo = DSbusqueda
            If dsOrdenesDeTrabajo.Tables.Count > 0 Then
                If dsOrdenesDeTrabajo.Tables(0).Rows.Count > 0 Then
                    Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(0)
                    tablaCargada = Tablas.OrdenTrabajo
                    AplicarFormatoColumnas()

                    Me.Lb_CantidadOrdenTrabajo.Text = "Cantidad de Ordenes de Mantenimiento " + dsOrdenesDeTrabajo.Tables(0).Rows.Count.ToString
                    Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
                Else
                    MessageBox.Show("Ningún Registro Encontrado")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar, por favor volver a intentar")
        End Try
    End Sub

    Private Sub Nbi_ImprimirOT_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirOT.ItemClick
        If Me.Dgv_ListaOrdenTrabajo.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        Dim TablaId As New DataTable
        TablaId.Columns.Add("IDORDENTRABAJO", System.Type.GetType("System.Int32"))
        For i = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = TablaId.NewRow
            fila("IDORDENTRABAJO") = Dgv_ListaOrdenTrabajo.SelectedRows(i).Cells(0).Value
            TablaId.Rows.Add(fila)
        Next
        Dim listaidot As New ArrayList
        Dim climpresion As New ImprimirControlProyecto.Cl_Impresión
        Dim Array As New ArrayList
        Array.Add(1)
        For i = 0 To TablaId.Rows.Count - 1
            Dim tempTabla As New DataTable
            tempTabla.Columns.Add("IDORDENTRABAJO", System.Type.GetType("System.Int32"))
            Dim fila, fila1 As DataRow
            fila = tempTabla.NewRow
            fila1 = TablaId.Rows(i)
            fila(0) = fila1(0)
            tempTabla.Rows.Add(fila)
            climpresion.TablaId = tempTabla
            climpresion.ImprimirFormatos(Array, True, False)
        Next
    End Sub

    Private Sub Nbi_CambiarEstado_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CambiarEstado.ItemClick
        Dim FrEstadoxOM As New Fr_EstadoOM
        FrEstadoxOM.Tipo = "OMSI"
        FrEstadoxOM.TablaIdOMS.Columns.Add("NROORDENSAP", System.Type.GetType("System.Int32"))
        FrEstadoxOM.TablaIdOMS.Columns.Add("ESTADO", System.Type.GetType("System.String"))
        FrEstadoxOM.TablaIdOMSProcedimiento.Columns.Add("NROORDENSAP", System.Type.GetType("System.Int32"))
        Me.ReactivarPrincipal = False
        FrEstadoxOM.Cu_padre = New Object
        FrEstadoxOM.Cu_padre = Me

        For j = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim IdbaseReporte As Integer = Me.Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("IDBASE").Value
            Select Case IdbaseReporte
                Case 94, 103, 107, 108 'Area oriente
                    Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                        Case 94, 103, 107, 108
                            Dim fila As DataRow
                            fila = FrEstadoxOM.TablaIdOMS.NewRow
                            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("NROORDENSAP").Value
                            fila("ESTADO") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("ESTADO").Value
                            FrEstadoxOM.TablaIdOMS.Rows.Add(fila)
                    End Select
                Case 95, 96, 97, 98, 106, 119 'Area Norte
                    Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                        Case 95, 96, 97, 98, 106, 119

                            Dim fila As DataRow
                            fila = FrEstadoxOM.TablaIdOMS.NewRow
                            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("NROORDENSAP").Value
                            fila("ESTADO") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("ESTADO").Value
                            FrEstadoxOM.TablaIdOMS.Rows.Add(fila)
                    End Select
                Case 101, 102 'Area Magdalena
                    Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                        Case 101, 102
                            Dim fila As DataRow
                            fila = FrEstadoxOM.TablaIdOMS.NewRow
                            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("NROORDENSAP").Value
                            fila("ESTADO") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("ESTADO").Value
                            FrEstadoxOM.TablaIdOMS.Rows.Add(fila)
                    End Select
                Case 99, 100, 105, 109 'Area Andina
                    Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                        Case 99, 100, 105, 109
                            Dim fila As DataRow
                            fila = FrEstadoxOM.TablaIdOMS.NewRow
                            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("NROORDENSAP").Value
                            fila("ESTADO") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("ESTADO").Value
                            FrEstadoxOM.TablaIdOMS.Rows.Add(fila)
                    End Select
            End Select
        Next
        FrEstadoxOM.CargarTabla()
        FrEstadoxOM.ShowDialog()
        Ubicar_Registro()
    End Sub

    Private Sub Nbi_BuscarOT_Portapapeles_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarOT_Portapapeles.ItemClick
        Me.ReactivarPrincipal = False

        Dim TablaId As New DataTable
        TablaId.Columns.Add("CODIGO", System.Type.GetType("System.Int32"))
        Try
            Dim delimiterChars() As Char = {" ", ",", ".", ":", "\t", "\r", "\n", vbCrLf}
            Dim words() As String = Clipboard.GetText().Split(delimiterChars)
            Dim textobusqueda As String = ""
            Dim cont As Integer = 1
            For i = 0 To words.Length - 1
                Dim line As String
                line = Replace(LTrim(RTrim(words(i))), vbLf, "")
                If line.Length > 0 Then
                    Try
                        Dim fila As DataRow
                        fila = TablaId.NewRow
                        fila("CODIGO") = line
                        TablaId.Rows.Add(fila)
                        If (cont Mod 3) = 0 Then
                            textobusqueda = textobusqueda + line + vbCrLf
                            cont = 1
                        Else
                            textobusqueda = textobusqueda + line + vbTab
                            cont = cont + 1
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Next

            If MsgBox("¿Desea realizar la búsqueda con estos datos de OM ? " + vbCrLf + textobusqueda, MsgBoxStyle.YesNo, "Buscar") = MsgBoxResult.No Then
                Exit Sub
            End If

            bddatos.TablaBusqueda = TablaId
            dsOrdenesDeTrabajo = bddatos.BusquedaCondiciones(35, 1, 4, 1, "", 0, Date.Now, Date.Now, 10, 500)
            If dsOrdenesDeTrabajo.Tables.Count > 0 Then
                dtOrdenTrabajo = dsOrdenesDeTrabajo.Tables(1)
                If dtOrdenTrabajo.Rows.Count > 0 Then
                    Dgv_ListaOrdenTrabajo.DataSource = dtOrdenTrabajo
                    Lb_CantidadOrdenTrabajo.Text = "Cantidad de Ordenes de Mantenimiento " + dtOrdenTrabajo.Rows.Count.ToString
                Else
                    Dgv_ListaOrdenTrabajo.DataSource = Nothing
                    Dgv_ListaServicios.DataSource = Nothing
                End If
            End If
            tablaCargada = Tablas.OrdenTrabajo
            AplicarFormatoColumnas()
            Me.Dgv_ListaOrdenTrabajo.Focus()
            Ubicar_Registro()
            ReactivarPrincipal = False

            Me.Cursor = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Nbi_CambiarEstadoSAP_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CambiarEstadoSAP.ItemClick
        Dim FrEstadoxOM As New Fr_EstadoOM
        FrEstadoxOM.Tipo = "OMSA"
        FrEstadoxOM.TablaIdOMS.Columns.Add("NROORDENSAP", System.Type.GetType("System.Int32"))
        FrEstadoxOM.TablaIdOMS.Columns.Add("ESTADOSAP", System.Type.GetType("System.String"))
        FrEstadoxOM.TablaIdOMSProcedimiento.Columns.Add("NROORDENSAP", System.Type.GetType("System.Int32"))
        Me.ReactivarPrincipal = False
        FrEstadoxOM.Cu_padre = New Object
        FrEstadoxOM.Cu_padre = Me
        For j = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim IdbaseReporte As Integer = Me.Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("IDBASE").Value

            Select Case IdbaseReporte
                Case 94, 103, 107, 108 'Area oriente
                    Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                        Case 94, 103, 107, 108
                            Dim fila As DataRow
                            fila = FrEstadoxOM.TablaIdOMS.NewRow
                            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("NROORDENSAP").Value
                            fila("ESTADOSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("ESTADOSAP").Value
                            FrEstadoxOM.TablaIdOMS.Rows.Add(fila)

                    End Select
                Case 95, 96, 97, 98, 106, 119 'Area Norte
                    Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                        Case 95, 96, 97, 98, 106, 119
                            Dim fila As DataRow
                            fila = FrEstadoxOM.TablaIdOMS.NewRow
                            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("NROORDENSAP").Value
                            fila("ESTADOSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("ESTADOSAP").Value
                            FrEstadoxOM.TablaIdOMS.Rows.Add(fila)
                    End Select
                Case 101, 102 'Area Magdalena
                    Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                        Case 101, 102
                            Dim fila As DataRow
                            fila = FrEstadoxOM.TablaIdOMS.NewRow
                            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("NROORDENSAP").Value
                            fila("ESTADOSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("ESTADOSAP").Value
                            FrEstadoxOM.TablaIdOMS.Rows.Add(fila)
                    End Select
                Case 99, 100, 105, 109 'Area Andina
                    Select Case VariablesBase.VariablesBase.IdBaseSiscontrolActual
                        Case 99, 100, 105, 109
                            Dim fila As DataRow
                            fila = FrEstadoxOM.TablaIdOMS.NewRow
                            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("NROORDENSAP").Value
                            fila("ESTADOSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(j).Cells("ESTADOSAP").Value
                            FrEstadoxOM.TablaIdOMS.Rows.Add(fila)
                    End Select
            End Select
        Next

        FrEstadoxOM.CargarTabla()
        FrEstadoxOM.ShowDialog()
        Ubicar_Registro()
    End Sub
#End Region 'Orden de Trabajo

#Region "Exportar a Xls"
    Private Sub Nbi_OM_ItemClick(sender As Object, e As EventArgs) Handles Nbi_OM.ItemClick
        ExportarExcel_OMMultiplesHojas()
    End Sub

    Public Sub ExportarExcel_OMMultiplesHojas()
        If Me.Dgv_ListaOrdenTrabajo.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        Dim TablaId As New DataTable
        TablaId.Columns.Add("IDORDENTRABAJO", System.Type.GetType("System.Int32"))

        For i = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = TablaId.NewRow
            fila("IDORDENTRABAJO") = Dgv_ListaOrdenTrabajo.SelectedRows(i).Cells(0).Value
            TablaId.Rows.Add(fila)
        Next

        Dim dtBasica As New DataTable
        Dim dtServicios As New DataTable
        Dim dtPersonal As New DataTable
        Dim dtComplementos As New DataTable
        Dim dtEquipo As New DataTable
        Dim dtCostoIndirecto As New DataTable
        Dim dtMateriales As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ImpresionOT", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TABLAIDOT", TablaId)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsOT As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsOT)
            conexion.Close()
            If dsOT.Tables.Count > 0 Then
                dtBasica = dsOT.Tables(0)
                dtServicios = dsOT.Tables(1)
                dtPersonal = dsOT.Tables(2)
                dtEquipo = dsOT.Tables(3)
                dtCostoIndirecto = dsOT.Tables(4)
                dtMateriales = dsOT.Tables(5)
                dtComplementos = dsOT.Tables(7)
            Else
                MsgBox("No hay recursos para Exportar.", MsgBoxStyle.Information, "Exportar Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los recursos para Exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        Dim objHojaBasica As Excel.Worksheet = objLibroExcel.Worksheets(1)
        Dim objHojaServicios As Excel.Worksheet = objLibroExcel.Worksheets(2)
        Dim objHojaPersonal As Excel.Worksheet = objLibroExcel.Worksheets(3)
        Dim objHojaComplementos As Excel.Worksheet = objLibroExcel.Worksheets(4)
        Dim objHojaEquipo As Excel.Worksheet = objLibroExcel.Worksheets(5)
        Dim objHojaCostoIndirecto As Excel.Worksheet = objLibroExcel.Worksheets(6)
        Dim objHojaMateriales As Excel.Worksheet = objLibroExcel.Worksheets(7)

        With objHojaBasica
            .Name = ("Basica")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtBasica.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtBasica.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtBasica.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtBasica.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaServicios
            .Name = "Servicios"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1

            For Each dc As DataColumn In dtServicios.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtServicios.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtServicios.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtServicios.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaPersonal
            .Name = "Personal"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtPersonal.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtPersonal.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtPersonal.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtPersonal.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaComplementos
            .Name = "Complementos"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtComplementos.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtComplementos.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtComplementos.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtComplementos.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaEquipo
            .Name = "Equipo"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtEquipo.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtEquipo.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtEquipo.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtEquipo.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaCostoIndirecto
            .Name = "Costo Indirecto"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtCostoIndirecto.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtCostoIndirecto.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtCostoIndirecto.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtCostoIndirecto.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaMateriales
            .Name = "Materiales"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtMateriales.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtMateriales.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtMateriales.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtMateriales.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    Private Sub Nbi_SabanaFacturacionOM_ItemClick(sender As Object, e As EventArgs) Handles Nbi_SabanaFacturacionOM.ItemClick
        Dim FrExportarxOM As New Fr_ExportarxOM
        FrExportarxOM.Text = "Exportar x OM Sabana Facturación"
        FrExportarxOM.Tipo = "F"
        FrExportarxOM.TablaId.Columns.Add("NROORDENSAP", System.Type.GetType("System.Int32"))
        For i = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = FrExportarxOM.TablaId.NewRow
            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(i).Cells("NROORDENSAP").Value
            FrExportarxOM.TablaId.Rows.Add(fila)
        Next
        FrExportarxOM.CargarTabla()
        FrExportarxOM.ShowDialog()
    End Sub

    Private Sub Nbi_ResumenFacturacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ResumenFacturacion.ItemClick
        Dim FrExportarxOM As New Fr_ExportarxOM
        FrExportarxOM.Text = "Exportar x OM Resumen Facturación"
        FrExportarxOM.Tipo = "S"
        FrExportarxOM.TablaId.Columns.Add("NROORDENSAP", System.Type.GetType("System.Int32"))
        For i = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = FrExportarxOM.TablaId.NewRow
            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(i).Cells("NROORDENSAP").Value
            FrExportarxOM.TablaId.Rows.Add(fila)
        Next
        FrExportarxOM.CargarTabla()
        FrExportarxOM.ShowDialog()
    End Sub

    Private Sub Nbi_AnalisisComparativoxOMs_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AnalisisComparativoxOMs.ItemClick
        ExportarExcel_AnalisisComparativo()
    End Sub

    Public Sub ExportarExcel_AnalisisComparativo()
        If Me.Dgv_ListaOrdenTrabajo.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        Dim TablaId As New DataTable
        TablaId.Columns.Add("IDORDENTRABAJO", System.Type.GetType("System.Int32"))

        For i = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = TablaId.NewRow
            fila("IDORDENTRABAJO") = Dgv_ListaOrdenTrabajo.SelectedRows(i).Cells(0).Value
            TablaId.Rows.Add(fila)
        Next

        Dim dtOrdenesMantenimiento As New DataTable
        Dim dtServicios As New DataTable
        Dim dtEquipos As New DataTable
        Dim dtCostoIndirecto As New DataTable
        Dim dtMateriales As New DataTable
        Dim dtManoObra As New DataTable
        Dim dtAdicionales As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ComparativoOrdenesCENIT", conexion)
        comando.CommandType = CommandType.StoredProcedure

        comando.Parameters.AddWithValue("@TIPO", 0)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@FECHAI", DBNull.Value)
        comando.Parameters.AddWithValue("@FECHAF", DBNull.Value)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@TABLAIDOT", TablaId)

        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsOT As New DataSet 'Contiene las tablas con los datos de la licitación y los recursos para la impresión.
        Try
            conexion.Open()
            adaptador.Fill(dsOT)
            conexion.Close()
            If dsOT.Tables.Count > 0 Then
                dtOrdenesMantenimiento = dsOT.Tables(0)
                dtServicios = dsOT.Tables(1)
                dtEquipos = dsOT.Tables(2)
                dtCostoIndirecto = dsOT.Tables(3)
                dtMateriales = dsOT.Tables(4)
                dtManoObra = dsOT.Tables(5)
                dtAdicionales = dsOT.Tables(6)
            Else
                MsgBox("No hay recursos para exportar.", MsgBoxStyle.Information, "Exportar Recursos")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("No se cargaron los recursos para Exportar.", MsgBoxStyle.Critical, "Error Exportar Recursos")
            Exit Sub
        Finally
            conexion.Close()
        End Try

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        Dim objHojaOrdenesMantenimiento As Excel.Worksheet = objLibroExcel.Worksheets(1)
        Dim objHojaServicios As Excel.Worksheet = objLibroExcel.Worksheets(2)
        Dim objHojaEquipos As Excel.Worksheet = objLibroExcel.Worksheets(3)
        Dim objHojaCostoIndirecto As Excel.Worksheet = objLibroExcel.Worksheets(4)
        Dim objHojaMateriales As Excel.Worksheet = objLibroExcel.Worksheets(5)
        Dim objHojaManoObra As Excel.Worksheet = objLibroExcel.Worksheets(6)
        Dim objHojaAdicionales As Excel.Worksheet = objLibroExcel.Worksheets(7)

        With objHojaOrdenesMantenimiento
            .Name = ("Órdenes Mantenimiento")
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtOrdenesMantenimiento.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtOrdenesMantenimiento.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtOrdenesMantenimiento.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtOrdenesMantenimiento.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaServicios
            .Name = "Servicios"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1

            For Each dc As DataColumn In dtServicios.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtServicios.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtServicios.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtServicios.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaEquipos
            .Name = "Equipos"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtEquipos.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtEquipos.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtEquipos.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtEquipos.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaCostoIndirecto
            .Name = "Costo Indirecto"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtCostoIndirecto.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtCostoIndirecto.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtCostoIndirecto.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtCostoIndirecto.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaMateriales
            .Name = "Materiales"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtMateriales.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtMateriales.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtMateriales.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtMateriales.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaManoObra
            .Name = "Mano de Obra"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtManoObra.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtManoObra.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtManoObra.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtManoObra.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With

        With objHojaAdicionales
            .Name = "Adicionales"
            .Activate()
            .Cells.Select()
            .Cells.ClearContents()
            ' Seleccionamos la primera celda de la hoja.
            .Range("A1").Select()
            ' Escribimos los nombres de las columnas en la primera
            ' celda de la primera fila de la hoja de cálculo
            Dim fila As Integer = 1
            Dim columna As Integer = 1
            For Each dc As DataColumn In dtAdicionales.Columns
                .Cells(fila, columna) = dc.ColumnName
                columna += 1
            Next
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, dtAdicionales.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With
            ' Insertamos los datos en la hoja de cálculo, comenzando por la
            ' fila número 2, ya que la primera fila está ocupada
            ' por el nombre de las columnas.
            fila = 2
            For Each row As DataRow In dtAdicionales.Rows
                ' Primera columna
                columna = 1
                For Each dc As DataColumn In dtAdicionales.Columns
                    .Cells(fila, columna) = row(dc.ColumnName)

                    ' Siguiente columna
                    columna += 1
                Next
                ' Siguiente fila
                fila += 1
            Next
            ' Autoajustamos el ancho de todas las columnas utilizadas.
            .Columns().AutoFit()
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Nbi_Informe246_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Informe246.ItemClick
        Dim FrExportarxOM As New Fr_ExportarxOM
        FrExportarxOM.Text = "Exportar x OM Informe 246"
        FrExportarxOM.Tipo = "I"
        FrExportarxOM.TablaId.Columns.Add("NROORDENSAP", System.Type.GetType("System.Int32"))
        For i = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = FrExportarxOM.TablaId.NewRow
            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(i).Cells("NROORDENSAP").Value
            FrExportarxOM.TablaId.Rows.Add(fila)
        Next
        FrExportarxOM.CargarTabla()
        FrExportarxOM.ShowDialog()
    End Sub

    Private Sub Nbi_ImprObraEjecutadaxOM_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprObraEjecutadaxOM.ItemClick
        Dim FrExportarxOM As New Fr_ExportarxOM
        FrExportarxOM.Text = "Imprimir RD de Obra Ejecutada x OM"
        FrExportarxOM.Tipo = "OE"
        FrExportarxOM.TablaIdOE.Columns.Add("NROORDENSAP", System.Type.GetType("System.Int32"))
        For i = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = FrExportarxOM.TablaIdOE.NewRow
            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(i).Cells("NROORDENSAP").Value
            FrExportarxOM.TablaIdOE.Rows.Add(fila)
        Next

        FrExportarxOM.CargarTabla()
        FrExportarxOM.ShowDialog()
    End Sub

    Private Sub Nbi_ImprAnalisisComparativo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprAnalisisComparativo.ItemClick
        If Me.Dgv_ListaOrdenTrabajo.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        Dim TablaIdC As New DataTable
        TablaIdC.Columns.Add("IDORDENTRABAJO", System.Type.GetType("System.Int32"))

        For i = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = TablaIdC.NewRow
            fila("IDORDENTRABAJO") = Dgv_ListaOrdenTrabajo.SelectedRows(i).Cells(0).Value
            TablaIdC.Rows.Add(fila)
        Next
        Dim listaidot As New ArrayList
        Dim climpresion As New ImprimirControlProyecto.Cl_Impresión
        Dim Array As New ArrayList
        Array.Add(14)

        For i = 0 To TablaIdC.Rows.Count - 1
            Dim tempTabla As New DataTable
            tempTabla.Columns.Add("IDORDENTRABAJO", System.Type.GetType("System.Int32"))
            Dim fila, fila1 As DataRow
            fila = tempTabla.NewRow
            fila1 = TablaIdC.Rows(i)
            fila(0) = fila1(0)
            tempTabla.Rows.Add(fila)
            climpresion.TablaIdC = tempTabla
            climpresion.ImprimirFormatos(Array, True, True)
        Next
    End Sub

    Private Sub Nbi_ReporteDiarioxOM_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ReporteDiarioxOM.ItemClick
        Dim FrExportarxOM As New Fr_ExportarxOM
        FrExportarxOM.Text = "Exportar x OM Reportes Tiempo"
        FrExportarxOM.Tipo = "R"
        FrExportarxOM.TablaId.Columns.Add("NROORDENSAP", System.Type.GetType("System.Int32"))
        For i = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = FrExportarxOM.TablaId.NewRow
            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(i).Cells("NROORDENSAP").Value
            FrExportarxOM.TablaId.Rows.Add(fila)
        Next
        FrExportarxOM.CargarTabla()
        FrExportarxOM.ShowDialog()
    End Sub

    Private Sub Nbi_ImprAnalisisComparativoxServicio_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprAnalisisComparativoxServicio.ItemClick
        If Me.Dgv_ListaOrdenTrabajo.SelectedRows.Count > 1 Then
            MsgBox("Solo se puede seleccionar una OM", MsgBoxStyle.Critical, "Solo un servicio")
            Exit Sub
        End If

        If Me.Dgv_ListaOrdenTrabajo.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar una OM", MsgBoxStyle.Critical, "Seleccionar una OM")
            Exit Sub
        End If

        If Dgv_ListaServicios.SelectedRows.Count > 1 Then
            MsgBox("Solo se puede seleccionar un servicio", MsgBoxStyle.Critical, "Solo un servicio")
            Exit Sub
        End If

        If Dgv_ListaServicios.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un servicio", MsgBoxStyle.Critical, "Seleccionar un servicio")
            Exit Sub
        End If

        Dim TablaIdC As New DataTable
        TablaIdC.Columns.Add("IDORDENTRABAJO", System.Type.GetType("System.Int32"))

        For i = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = TablaIdC.NewRow
            fila("IDORDENTRABAJO") = Dgv_ListaOrdenTrabajo.SelectedRows(i).Cells(0).Value
            TablaIdC.Rows.Add(fila)
        Next

        Dim listaidot As New ArrayList
        Dim climpresion As New ImprimirControlProyecto.Cl_Impresión
        Dim Array As New ArrayList
        Array.Add(14)
        climpresion.IDOTSERVICIO = Dgv_ListaServicios.SelectedRows(0).Cells("IDOTSERVICIO").Value()

        For i = 0 To TablaIdC.Rows.Count - 1
            Dim tempTabla As New DataTable
            tempTabla.Columns.Add("IDORDENTRABAJO", System.Type.GetType("System.Int32"))
            Dim fila, fila1 As DataRow
            fila = tempTabla.NewRow
            fila1 = TablaIdC.Rows(i)
            fila(0) = fila1(0)
            tempTabla.Rows.Add(fila)
            climpresion.TablaIdC = tempTabla
            climpresion.ImprimirFormatos(Array, True, True)
        Next
    End Sub

    Private Sub Nbi_ImprObraEjecutadaxOMEntreFechas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprObraEjecutadaxOMEntreFechas.ItemClick
        Dim FrExportarxOM As New Fr_ExportarxOM
        FrExportarxOM.Text = "Imprimir RD de Obra Ejecutada x OM Entre Fechas"
        FrExportarxOM.Tipo = "OEF"
        FrExportarxOM.TablaIdOE.Columns.Add("NROORDENSAP", System.Type.GetType("System.Int32"))
        For i = 0 To Dgv_ListaOrdenTrabajo.SelectedRows.Count - 1
            Dim fila As DataRow
            fila = FrExportarxOM.TablaIdOE.NewRow
            fila("NROORDENSAP") = Dgv_ListaOrdenTrabajo.SelectedRows(i).Cells("NROORDENSAP").Value
            FrExportarxOM.TablaIdOE.Rows.Add(fila)
        Next

        FrExportarxOM.CargarTabla()
        FrExportarxOM.ShowDialog()
    End Sub
#End Region 'Exportar a Xls

#Region "Material No Conforme"
    Private Sub Nbi_ListarMNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarMNC.ItemClick
        ListarMNC()
    End Sub

    Private Sub ListarMNC()
        Me.Cursor = Cursors.WaitCursor
        dsOrdenesDeTrabajo = bddatos.BusquedaCondiciones(43, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If Not IsNothing(dsOrdenesDeTrabajo) AndAlso dsOrdenesDeTrabajo.Tables.Count > 0 Then
            tablaCargada = Tablas.MaterialNoConforme
            Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(1)
            AplicarFormatoMNC()
            If Dgv_ListaOrdenTrabajo.Rows.Count > 0 Then
                Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AplicarFormatoMNC()
        AplicarFormatoColumnas()
        Lb_CantidadOrdenTrabajo.Text = "Cantidad de registros de Material No Conforme: " & Dgv_ListaOrdenTrabajo.Rows.Count
    End Sub

    Private Sub Nbi_RegistrarMNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearMNC.ItemClick
        RegistrarMNC()
    End Sub

    Private Sub RegistrarMNC()
        Using frMaterialNoConforme As New Fr_MaterialNoConforme
            frMaterialNoConforme.TipoEdicion = Fr_MaterialNoConforme.TiposEdicion.Crear
            frMaterialNoConforme.ShowDialog()
            If frMaterialNoConforme.Guardado Then
                ListarMNC()
            End If
        End Using
    End Sub

    Private Sub Nbi_EditarMNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarMNC.ItemClick
        If tablaCargada = Tablas.MaterialNoConforme Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                If Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("ANULADO").Value = "N" Then
                    If Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("CERRADO").Value = "N" Then
                        Index_Registro_Actual = Dgv_ListaOrdenTrabajo.SelectedRows(0).Index
                        EditarMNC(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDMATERIALNOCONFORME").Value)
                        Ubicar_Registro()
                    Else
                        MessageBox.Show("El registro se encuentra cerrado.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("El registro se encuentra anulado.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de Material No Conforme.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub EditarMNC(idMaterialNoConforme As Integer)
        Using frMaterialNoConforme As New Fr_MaterialNoConforme
            frMaterialNoConforme.IdMaterialNoConforme = idMaterialNoConforme
            frMaterialNoConforme.TipoEdicion = Fr_MaterialNoConforme.TiposEdicion.Editar
            frMaterialNoConforme.ShowDialog()
            If frMaterialNoConforme.Guardado Then
                ListarMNC()
            End If
        End Using
    End Sub

    Private Sub Nbi_VerMNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerMNC.ItemClick
        If tablaCargada = Tablas.MaterialNoConforme Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                VerMNC(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDMATERIALNOCONFORME").Value)
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Ver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de Material No Conforme.", "Ver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub VerMNC(idMaterialNoConforme As Integer)
        Using frMaterialNoConforme As New Fr_MaterialNoConforme
            frMaterialNoConforme.IdMaterialNoConforme = idMaterialNoConforme
            frMaterialNoConforme.TipoEdicion = Fr_MaterialNoConforme.TiposEdicion.Ver
            frMaterialNoConforme.ShowDialog()
        End Using
    End Sub

    Private Sub Nbi_AnularMNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AnularMNC.ItemClick
        If tablaCargada = Tablas.MaterialNoConforme Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                If Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("ANULADO").Value = "N" Then
                    AnularMNC(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDMATERIALNOCONFORME").Value)
                Else
                    MessageBox.Show("El registro ya se encuentra anulado.", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de Material No Conforme.", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub AnularMNC(idMaterialNoConforme As Integer)
        Using frMaterialNoConforme As New Fr_MaterialNoConforme
            frMaterialNoConforme.IdMaterialNoConforme = idMaterialNoConforme
            If frMaterialNoConforme.Anular() Then
                ListarMNC()
            End If
        End Using
    End Sub

    Private Sub Nbi_CierreMNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CerrarMNC.ItemClick
        If tablaCargada = Tablas.MaterialNoConforme Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                If Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("ANULADO").Value = "N" Then
                    If Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("CERRADO").Value = "N" Then
                        Index_Registro_Actual = Dgv_ListaOrdenTrabajo.SelectedRows(0).Index
                        CerrarMNC(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDMATERIALNOCONFORME").Value)
                        Ubicar_Registro()
                    Else
                        MessageBox.Show("El registro ya se encuentra cerrado.", "Registrar Cierre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("El registro se encuentra anulado.", "Registrar Cierre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Registrar Cierre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de Material No Conforme.", "Registrar Cierre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub CerrarMNC(idMaterialNoConforme As Integer)
        Using frMaterialNoConforme As New Fr_MaterialNoConforme
            frMaterialNoConforme.IdMaterialNoConforme = idMaterialNoConforme
            frMaterialNoConforme.TipoEdicion = Fr_MaterialNoConforme.TiposEdicion.Cerrar
            frMaterialNoConforme.ShowDialog()
            If frMaterialNoConforme.Guardado Then
                ListarMNC()
            End If
        End Using
    End Sub

    Private Sub Nbi_BuscarMNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarMNC.ItemClick
        BuscarMNC()
    End Sub

    Private Sub BuscarMNC()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("MNC.IDMATERIALNOCONFORME", "Id. del registro", "2")
        campos.Rows.Add("MNC.NUMEROREPORTE", "Número de reporte", "1")
        campos.Rows.Add("2", "Nombre persona Elabora", "7") 'Consulta especial
        campos.Rows.Add("3", "Nombre persona Verifica", "7") 'Consulta especial
        campos.Rows.Add("4", "Nombre persona Acepta", "7") 'Consulta especial
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de registros de Material No Conforme"
        frbuscar.tabla = 43
        frbuscar.ShowDialog()
        Try
            Dim DSbusqueda = frbuscar.DsBuscar
            dsOrdenesDeTrabajo = DSbusqueda
            If dsOrdenesDeTrabajo.Tables.Count > 0 Then
                If dsOrdenesDeTrabajo.Tables(0).Rows.Count > 0 Then
                    tablaCargada = Tablas.MaterialNoConforme
                    Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(0)
                    AplicarFormatoMNC()
                Else
                    MessageBox.Show("Ningún registro encontrado.", "Buscar registros de Material No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region 'Material No Conforme

#Region "No Conformidad"
    Private Sub Nbi_ListarNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarNC.ItemClick
        ListarNC()
    End Sub

    Private Sub ListarNC()
        Cursor.Current = Cursors.WaitCursor
        dsOrdenesDeTrabajo = bddatos.BusquedaCondiciones(44, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If Not IsNothing(dsOrdenesDeTrabajo) AndAlso dsOrdenesDeTrabajo.Tables.Count > 0 Then
            tablaCargada = Tablas.NoConformidad
            Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(1)
            AplicarFormatoNC()
            If Dgv_ListaOrdenTrabajo.Rows.Count > 0 Then
                Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub AplicarFormatoNC()
        AplicarFormatoColumnas()
        Lb_CantidadOrdenTrabajo.Text = "Cantidad de registros de No Conformidad: " & Dgv_ListaOrdenTrabajo.Rows.Count
    End Sub

    Private Sub Nbi_RegistrarNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearNC.ItemClick
        RegistrarNC()
    End Sub

    Private Sub RegistrarNC()
        Using frNoConformidad As New Fr_NoConformidad
            frNoConformidad.TipoEdicion = Fr_NoConformidad.TiposEdicion.Crear
            frNoConformidad.ShowDialog()
            If frNoConformidad.Guardado Then
                ListarNC()
            End If
        End Using
    End Sub

    Private Sub Nbi_EditarNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarNC.ItemClick
        If tablaCargada = Tablas.NoConformidad Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                If Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("ANULADO").Value = "N" Then
                    If Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("CERRADO").Value = "N" Then
                        Index_Registro_Actual = Dgv_ListaOrdenTrabajo.SelectedRows(0).Index
                        EditarNC(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDNOCONFORMIDAD").Value)
                        Ubicar_Registro()
                    Else
                        MessageBox.Show("El registro se encuentra cerrado.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("El registro se encuentra anulado.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de No Conformidades.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub EditarNC(idNoConformidad As Integer)
        Using frNoConformidad As New Fr_NoConformidad
            frNoConformidad.IdNoConformidad = idNoConformidad
            frNoConformidad.TipoEdicion = Fr_NoConformidad.TiposEdicion.Editar
            frNoConformidad.ShowDialog()
            If frNoConformidad.Guardado Then
                ListarNC()
            End If
        End Using
    End Sub

    Private Sub Nbi_VerNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerNC.ItemClick
        If tablaCargada = Tablas.NoConformidad Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                VerNC(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDNOCONFORMIDAD").Value)
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Ver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de No Conformidades.", "Ver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub VerNC(idNoConformidad As Integer)
        Using frNoConformidad As New Fr_NoConformidad
            frNoConformidad.IdNoConformidad = idNoConformidad
            frNoConformidad.TipoEdicion = Fr_NoConformidad.TiposEdicion.Ver
            frNoConformidad.ShowDialog()
        End Using
    End Sub

    Private Sub Nbi_AnularNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AnularNC.ItemClick
        If tablaCargada = Tablas.NoConformidad Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                If Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("ANULADO").Value = "N" Then
                    AnularNC(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDNOCONFORMIDAD").Value)
                Else
                    MessageBox.Show("El registro ya se encuentra anulado.", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de No Conformidades.", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub AnularNC(idNoConformidad As Integer)
        Using frNoConformidad As New Fr_NoConformidad
            frNoConformidad.IdNoConformidad = idNoConformidad
            If frNoConformidad.Anular() Then
                ListarNC()
            End If
        End Using
    End Sub

    Private Sub Nbi_CierreNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CerrarNC.ItemClick
        If tablaCargada = Tablas.NoConformidad Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                If Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("ANULADO").Value = "N" Then
                    If Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("CERRADO").Value = "N" Then
                        Index_Registro_Actual = Dgv_ListaOrdenTrabajo.SelectedRows(0).Index
                        CerrarNC(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDNOCONFORMIDAD").Value)
                        Ubicar_Registro()
                    Else
                        MessageBox.Show("El registro ya se encuentra cerrado.", "Registrar cierre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("El registro se encuentra anulado.", "Registrar cierre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Registrar cierre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de No Conformidades.", "Registrar cierre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub CerrarNC(idNoConformidad As Integer)
        Using frNoConformidad As New Fr_NoConformidad
            frNoConformidad.IdNoConformidad = idNoConformidad
            frNoConformidad.TipoEdicion = Fr_NoConformidad.TiposEdicion.Cerrar
            frNoConformidad.ShowDialog()
            If frNoConformidad.Guardado Then
                ListarNC()
            End If
        End Using
    End Sub

    Private Sub Nbi_BuscarNC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarNC.ItemClick
        BuscarNC()
    End Sub

    Private Sub BuscarNC()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("NC.IDNOCONFORMIDAD", "Id. del registro", "2")
        campos.Rows.Add("NC.NUMEROREPORTE", "Número de reporte", "1")
        campos.Rows.Add("NC.NUMEROAUDITORIA", "Número de auditoría", "1")
        campos.Rows.Add("NC.FECHA", "Fecha registro", "3")
        campos.Rows.Add("2", "Detector", "7") 'Consulta especial
        campos.Rows.Add("3", "Representante del Proceso", "7") 'Consulta especial
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de registros de No Conformidad"
        frbuscar.tabla = 44
        frbuscar.ShowDialog()
        Try
            Dim DSbusqueda = frbuscar.DsBuscar
            dsOrdenesDeTrabajo = DSbusqueda
            If dsOrdenesDeTrabajo.Tables.Count > 0 Then
                If dsOrdenesDeTrabajo.Tables(0).Rows.Count > 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    tablaCargada = Tablas.NoConformidad
                    Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(0)
                    AplicarFormatoNC()
                Else
                    MessageBox.Show("Ningún registro encontrado", "Buscar registros de No Conformidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region 'No Conformidad

#Region "Intervención Directa"
    Private Sub Nbi_ListarID_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarID.ItemClick
        ListarID()
    End Sub

    Private Sub ListarID()
        Cursor.Current = Cursors.WaitCursor
        dsOrdenesDeTrabajo = bddatos.BusquedaCondiciones(45, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If Not IsNothing(dsOrdenesDeTrabajo) Then
            If dsOrdenesDeTrabajo.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
                dsOrdenesDeTrabajo.Tables.Remove(dsOrdenesDeTrabajo.Tables(0).TableName) 'Borrar la tabla del conteo.
            Else 'Si solo trae el conteo es porque se exceden los campos.
                MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsOrdenesDeTrabajo.Clear()
            End If
            tablaCargada = Tablas.IntervencionDirecta
            Dgv_ListaOrdenTrabajo.DataSource = Nothing
            Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(0)
            AplicarFormatoColumnas()
            Lb_CantidadOrdenTrabajo.Text = "Cantidad de Intervenciones Directas: " & dsOrdenesDeTrabajo.Tables(0).Rows.Count
            If Dgv_ListaOrdenTrabajo.RowCount > 0 Then
                Dgv_ListaOrdenTrabajo.ClearSelection()
                Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
            End If
        Else
            Dgv_ListaOrdenTrabajo.DataSource = Nothing
            Lb_CantidadOrdenTrabajo.Text = "Cantidad de Intervenciones Directa: 0"
        End If
        Cursor.Current = Cursors.Default

    End Sub
    Private Sub Nbi_BuscarID_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarID.ItemClick
        BuscarID()
    End Sub

    Private Sub BuscarID()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("2", "Sistema", "7")
        campos.Rows.Add("3", "Linea", "7")
        campos.Rows.Add("ID.NROORDENSAP ", "Número Orden Sap", "1")
        campos.Rows.Add("ID.FECHAINTERVENCION", "Fecha de Intervención", "3")
        campos.Rows.Add("4", "Tipo Intervención", "7")
        campos.Rows.Add("5", "Causa Intervención", "7")
        campos.Rows.Add("6", "Anomalía De Bajo de Sobre Camisa", "7")
        campos.Rows.Add("7", "Tipo Recubrimienton", "7")
        campos.Rows.Add("8", "Funcionario Realiza Liberación de Calidad", "7")
        campos.Rows.Add("9", "Evidencia Nombre Informe Campo", "7")
        campos.Rows.Add("10", "Url Ubicación Informe de Campo", "7")
        campos.Rows.Add("11", "Base", "7")
        campos.Rows.Add("ID.AÑO", "Año", "1")

        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de registros de Intervención"
        frbuscar.tabla = 45
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsOrdenesDeTrabajo = DSbusqueda
        Try
            If dsOrdenesDeTrabajo.Tables.Count > 0 Then
                If dsOrdenesDeTrabajo.Tables(0).Rows.Count > 0 Then
                    CargarIDFiltro(DSbusqueda)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarIDFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        Dgv_ListaOrdenTrabajo.DataSource = Nothing
        Dgv_ListaOrdenTrabajo.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.IntervencionDirecta
        AplicarFormatoColumnas()
        Dgv_ListaOrdenTrabajo.ReadOnly = True
        Lb_CantidadOrdenTrabajo.Text = "Cantidad de Intervenciones Directas: " & DsTabla.Tables(0).Rows.Count
        If Dgv_ListaOrdenTrabajo.RowCount > 0 Then
            Dgv_ListaOrdenTrabajo.ClearSelection()
            Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

#End Region ' Intervención Directa

#Region "Obras Sobre DDV"
    Private Sub Nbi_ListarOSDDV_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarOSDDV.ItemClick
        ListarOSDDV()
    End Sub

    Private Sub ListarOSDDV()
        Cursor.Current = Cursors.WaitCursor
        dsOrdenesDeTrabajo = bddatos.BusquedaCondiciones(46, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If Not IsNothing(dsOrdenesDeTrabajo) Then
            If dsOrdenesDeTrabajo.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
                dsOrdenesDeTrabajo.Tables.Remove(dsOrdenesDeTrabajo.Tables(0).TableName) 'Borrar la tabla del conteo.
            Else 'Si solo trae el conteo es porque se exceden los campos.
                MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsOrdenesDeTrabajo.Clear()
            End If
            tablaCargada = Tablas.ObrasSobreDDV
            Dgv_ListaOrdenTrabajo.DataSource = Nothing
            Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(0)
            AplicarFormatoColumnas()
            Lb_CantidadOrdenTrabajo.Text = "Cantidad de Obras Sobre DDV: " & dsOrdenesDeTrabajo.Tables(0).Rows.Count
            If Dgv_ListaOrdenTrabajo.RowCount > 0 Then
                Dgv_ListaOrdenTrabajo.ClearSelection()
                Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
            End If
        Else
            Dgv_ListaOrdenTrabajo.DataSource = Nothing
            Lb_CantidadOrdenTrabajo.Text = "Cantidad de Obras Sobre DDV: 0"
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Nbi_BuscarOSDDV_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarOSDDV.ItemClick
        BuscarOSDDV()
    End Sub

    Private Sub BuscarOSDDV()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("2", "Sistema", "7")
        campos.Rows.Add("3", "Linea", "7")
        campos.Rows.Add("OSDDV.NROORDENSAP ", "Número Orden Sap", "1")
        campos.Rows.Add("OSDDV.FECHAINTERVENCION", "Fecha de Intervención", "3")
        campos.Rows.Add("4", "Tipo Intervención", "7")
        campos.Rows.Add("5", "Causa Intervención", "7")
        campos.Rows.Add("6", "Funcionario Realiza Liberación de Calidad", "7")
        campos.Rows.Add("7", "Evidencia Nombre Informe Campo", "7")
        campos.Rows.Add("8", "Url Ubicación Informe de Campo", "7")
        campos.Rows.Add("9", "Base", "7")
        campos.Rows.Add("OSDDV.AÑO", "Año", "1")
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de registros de Obras Sobre DDV"
        frbuscar.tabla = 46
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsOrdenesDeTrabajo = DSbusqueda
        Try
            If dsOrdenesDeTrabajo.Tables.Count > 0 Then
                If dsOrdenesDeTrabajo.Tables(0).Rows.Count > 0 Then
                    CargarOSDDVFiltro(DSbusqueda)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarOSDDVFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        Dgv_ListaOrdenTrabajo.DataSource = Nothing
        Dgv_ListaOrdenTrabajo.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.ObrasSobreDDV
        AplicarFormatoColumnas()
        Dgv_ListaOrdenTrabajo.ReadOnly = True
        Lb_CantidadOrdenTrabajo.Text = "Cantidad de Obras Sobre DDV: " & DsTabla.Tables(0).Rows.Count
        If Dgv_ListaOrdenTrabajo.RowCount > 0 Then
            Dgv_ListaOrdenTrabajo.ClearSelection()
            Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

#End Region ' Obras Sobre DDV

#Region "Valvulas"
    Private Sub Nbi_ListarV_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarV.ItemClick
        ListarV()
    End Sub

    Private Sub ListarV()
        Cursor.Current = Cursors.WaitCursor
        dsOrdenesDeTrabajo = bddatos.BusquedaCondiciones(47, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If Not IsNothing(dsOrdenesDeTrabajo) Then
            If dsOrdenesDeTrabajo.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
                dsOrdenesDeTrabajo.Tables.Remove(dsOrdenesDeTrabajo.Tables(0).TableName) 'Borrar la tabla del conteo.
            Else 'Si solo trae el conteo es porque se exceden los campos.
                MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsOrdenesDeTrabajo.Clear()
            End If
            tablaCargada = Tablas.Valvulas
            Dgv_ListaOrdenTrabajo.DataSource = Nothing
            Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(0)
            AplicarFormatoColumnas()
            Lb_CantidadOrdenTrabajo.Text = "Cantidad de Válvulas: " & dsOrdenesDeTrabajo.Tables(0).Rows.Count
            If Dgv_ListaOrdenTrabajo.RowCount > 0 Then
                Dgv_ListaOrdenTrabajo.ClearSelection()
                Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
            End If
        Else
            Dgv_ListaOrdenTrabajo.DataSource = Nothing
            Lb_CantidadOrdenTrabajo.Text = "Cantidad de Válvulas: 0"
        End If
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub Nbi_BuscarV_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarV.ItemClick
        BuscarV()
    End Sub

    Private Sub BuscarV()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("2", "Troncal", "7")
        campos.Rows.Add("3", "Sistema", "7")
        campos.Rows.Add("V.NROORDENSAP ", "Número Orden Sap", "1")
        campos.Rows.Add("V.FECHAINTERVENCION", "Fecha de Intervención", "3")
        campos.Rows.Add("4", "Nombre Válvula", "7")
        campos.Rows.Add("5", "Tipo Válvula", "7")
        campos.Rows.Add("V.RATING ", "Rating", "1")
        campos.Rows.Add("V.DIAMETRO ", "Diametro", "1")
        campos.Rows.Add("6", "Tipo Actuador", "7")
        campos.Rows.Add("7", "Estado Operación", "7")
        campos.Rows.Add("8", "Tipo Intervención", "7")
        campos.Rows.Add("9", "Causa Intervención", "7")
        campos.Rows.Add("10", "Url Ubicación Informe de Campo", "7")
        campos.Rows.Add("11", "Base", "7")
        campos.Rows.Add("V.AÑO", "Año", "1")
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de registros de Válvulas"
        frbuscar.tabla = 47
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsOrdenesDeTrabajo = DSbusqueda
        Try
            If dsOrdenesDeTrabajo.Tables.Count > 0 Then
                If dsOrdenesDeTrabajo.Tables(0).Rows.Count > 0 Then
                    CargarVFiltro(DSbusqueda)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarVFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        Dgv_ListaOrdenTrabajo.DataSource = Nothing
        Dgv_ListaOrdenTrabajo.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.Valvulas
        AplicarFormatoColumnas()
        Dgv_ListaOrdenTrabajo.ReadOnly = True
        Lb_CantidadOrdenTrabajo.Text = "Cantidad de Válvulas: " & DsTabla.Tables(0).Rows.Count
        If Dgv_ListaOrdenTrabajo.RowCount > 0 Then
            Dgv_ListaOrdenTrabajo.ClearSelection()
            Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

#End Region 'Valvulas

#Region "URPC"
    Private Sub Nbi_ListarURPC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarURPC.ItemClick
        ListarURPC()
    End Sub

    Private Sub ListarURPC()
        Cursor.Current = Cursors.WaitCursor
        dsOrdenesDeTrabajo = bddatos.BusquedaCondiciones(48, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If Not IsNothing(dsOrdenesDeTrabajo) Then
            If dsOrdenesDeTrabajo.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
                dsOrdenesDeTrabajo.Tables.Remove(dsOrdenesDeTrabajo.Tables(0).TableName) 'Borrar la tabla del conteo.
            Else 'Si solo trae el conteo es porque se exceden los campos.
                MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsOrdenesDeTrabajo.Clear()
            End If
            tablaCargada = Tablas.URPC
            Dgv_ListaOrdenTrabajo.DataSource = Nothing
            Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(0)
            AplicarFormatoColumnas()
            Lb_CantidadOrdenTrabajo.Text = "Cantidad de URPC: " & dsOrdenesDeTrabajo.Tables(0).Rows.Count
            If Dgv_ListaOrdenTrabajo.RowCount > 0 Then
                Dgv_ListaOrdenTrabajo.ClearSelection()
                Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
            End If
        Else
            Dgv_ListaOrdenTrabajo.DataSource = Nothing
            Lb_CantidadOrdenTrabajo.Text = "Cantidad de URPC: 0"
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Nbi_BuscarURPC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarURPC.ItemClick
        BuscarURPC()
    End Sub

    Private Sub BuscarURPC()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("2", "Troncal", "7")
        campos.Rows.Add("3", "Sistema", "7")
        campos.Rows.Add("U.NROORDENSAP ", "Número Orden Sap", "1")
        campos.Rows.Add("U.FECHAINTERVENCION", "Fecha de Intervención", "3")
        campos.Rows.Add("4", "Nombre URPC", "7")
        campos.Rows.Add("5", "Tipo Intervención", "7")
        campos.Rows.Add("6", "Causa Intervención", "7")
        campos.Rows.Add("7", "Url Ubicación Informe de Campo", "7")
        campos.Rows.Add("8", "Base", "7")
        campos.Rows.Add("U.AÑO", "Año", "1")
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de registros de URPC"
        frbuscar.tabla = 48
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsOrdenesDeTrabajo = DSbusqueda
        Try
            If dsOrdenesDeTrabajo.Tables.Count > 0 Then
                If dsOrdenesDeTrabajo.Tables(0).Rows.Count > 0 Then
                    CargarURPCFiltro(DSbusqueda)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarURPCFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        Dgv_ListaOrdenTrabajo.DataSource = Nothing
        Dgv_ListaOrdenTrabajo.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.URPC
        AplicarFormatoColumnas()
        Dgv_ListaOrdenTrabajo.ReadOnly = True
        Lb_CantidadOrdenTrabajo.Text = "Cantidad de URPC: " & DsTabla.Tables(0).Rows.Count
        If Dgv_ListaOrdenTrabajo.RowCount > 0 Then
            Dgv_ListaOrdenTrabajo.ClearSelection()
            Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

#End Region 'URPC

#Region "Variables Mantenimiento"
    Private Sub Nbi_Graficar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Graficar.ItemClick
        Dim FrGraficasVariablesMantenimiento As New FormulariosOrdenesTrabajo.Fr_GraficasVariablesMantenimiento
        FrGraficasVariablesMantenimiento.ShowDialog()
    End Sub

#End Region 'Variables Mantenimiento

#Region "Defectología por Soldador"
    Private Sub Nbi_ListarDS_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarDS.ItemClick
        ListarSD()
    End Sub

    Private Sub ListarSD()
        Cursor.Current = Cursors.WaitCursor
        dsOrdenesDeTrabajo = bddatos.BusquedaCondiciones(49, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        If Not IsNothing(dsOrdenesDeTrabajo) Then
            If dsOrdenesDeTrabajo.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
                dsOrdenesDeTrabajo.Tables.Remove(dsOrdenesDeTrabajo.Tables(0).TableName) 'Borrar la tabla del conteo.
            Else 'Si solo trae el conteo es porque se exceden los campos.
                MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsOrdenesDeTrabajo.Clear()
            End If
            tablaCargada = Tablas.DefectologiaXSoldador
            Dgv_ListaOrdenTrabajo.DataSource = Nothing
            Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(0)
            AplicarFormatoColumnas()
            Lb_CantidadOrdenTrabajo.Text = "Cantidad de Defectología Por Soldador: " & dsOrdenesDeTrabajo.Tables(0).Rows.Count
            If Dgv_ListaOrdenTrabajo.RowCount > 0 Then
                Dgv_ListaOrdenTrabajo.ClearSelection()
                Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
            End If
        Else
            Dgv_ListaOrdenTrabajo.DataSource = Nothing
            Lb_CantidadOrdenTrabajo.Text = "Cantidad de Defectología Por Soldador: 0"
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Nbi_BuscarDS_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarDS.ItemClick
        BuscarDS()
    End Sub

    Private Sub BuscarDS()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("DS.ZONA", "Zona", "1")
        campos.Rows.Add("1", "Trabajador", "7")
        campos.Rows.Add("2", "Base", "7")
        campos.Rows.Add("DS.AÑO", "Año", "1")
        campos.Rows.Add("DS.MES", "Mes", "1")
        campos.Rows.Add("DS.JUNTASDEFECTUOSAS", "Juntas Defectuosas", "1")
        campos.Rows.Add("DS.JUNTASINSPECCIONADASPOREND", "Juntas Inspeccionadas Por End", "1")
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de registros de Defectología Por Soldador"
        frbuscar.tabla = 49
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsOrdenesDeTrabajo = DSbusqueda
        Try
            If dsOrdenesDeTrabajo.Tables.Count > 0 Then
                If dsOrdenesDeTrabajo.Tables(0).Rows.Count > 0 Then
                    CargarDSFiltro(DSbusqueda)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarDSFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        Dgv_ListaOrdenTrabajo.DataSource = Nothing
        Dgv_ListaOrdenTrabajo.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.DefectologiaXSoldador
        AplicarFormatoColumnas()
        Dgv_ListaOrdenTrabajo.ReadOnly = True
        Lb_CantidadOrdenTrabajo.Text = "Cantidad de Defectología Por Soldador: " & DsTabla.Tables(0).Rows.Count
        If Dgv_ListaOrdenTrabajo.RowCount > 0 Then
            Dgv_ListaOrdenTrabajo.ClearSelection()
            Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub



#End Region 'Defectología por Soldador

#Region "Tableros TBG"
    Private Sub Nbi_CargarTBG_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarTBG.ItemClick
        ListarTBG()
    End Sub

    Private Sub ListarTBG()
        Cursor.Current = Cursors.WaitCursor
        dsOrdenesDeTrabajo = bddatos.BusquedaCondiciones(50, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If Not IsNothing(dsOrdenesDeTrabajo) AndAlso dsOrdenesDeTrabajo.Tables.Count > 0 Then
            tablaCargada = Tablas.TablerosTBG
            Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(1)
            AplicarFormatoTBG()
            If Dgv_ListaOrdenTrabajo.Rows.Count > 0 Then
                Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub AplicarFormatoTBG()
        AplicarFormatoColumnas()
        Lb_CantidadOrdenTrabajo.Text = "Cantidad de Tableros TBG: " & Dgv_ListaOrdenTrabajo.Rows.Count
    End Sub

    Private Sub Nbi_CrearTBG_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearTBG.ItemClick
        CrearTBG()
    End Sub

    Private Sub CrearTBG()
        Using frTableroTBG As New Fr_TableroTBG
            frTableroTBG.TipoEdicion = Fr_TableroTBG.TiposEdicion.Crear
            frTableroTBG.ShowDialog()
            If frTableroTBG.Guardado Then
                ListarTBG()
            End If
        End Using
    End Sub

    Private Sub Nbi_EditarTBG_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarTBG.ItemClick
        If tablaCargada = Tablas.TablerosTBG Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Dgv_ListaOrdenTrabajo.SelectedRows(0).Index
                EditarTBG(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDTABLEROTBG").Value)
                Ubicar_Registro()
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de Tableros TBG.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub EditarTBG(idTableroTBG As Integer)
        Using frTableroTBG As New Fr_TableroTBG
            frTableroTBG.IdTBG = idTableroTBG
            frTableroTBG.TipoEdicion = Fr_TableroTBG.TiposEdicion.Editar
            frTableroTBG.ShowDialog()
            If frTableroTBG.Guardado Then
                ListarTBG()
            End If
        End Using
    End Sub

    Private Sub Nbi_VerTBG_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerTBG.ItemClick
        If tablaCargada = Tablas.TablerosTBG Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                VerTBG(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDTABLEROTBG").Value)
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Ver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de Tableros TBG.", "Ver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub VerTBG(idTableroTBG As Integer)
        Using frTableroTBG As New Fr_TableroTBG
            frTableroTBG.IdTBG = idTableroTBG
            frTableroTBG.TipoEdicion = Fr_TableroTBG.TiposEdicion.Ver
            frTableroTBG.ShowDialog()
        End Using
    End Sub

    Private Sub Nbi_BuscarTBG_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarTBG.ItemClick
        BuscarTBG()
    End Sub

    Private Sub BuscarTBG()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("3", "Nombre del archivo", "7")
        campos.Rows.Add("TBG.FECHAMEDICION", "Fecha de Medición", "3")
        campos.Rows.Add("CONVERT(varchar, YEAR(TBG.FECHAMEDICION))+'-'+RIGHT('0'+CONVERT(varchar, MONTH(TBG.FECHAMEDICION)), 2)", "Año y mes Medición (AAAA-MM)", "1")
        campos.Rows.Add("YEAR(TBG.FECHAMEDICION)", "Año de Medición", "2")
        campos.Rows.Add("TBG.PERIODOMEDICION", "Periodo Medición (núm. de mes)", "2")
        campos.Rows.Add("TBG.FECHAPRESENTACION", "Fecha de Presentación", "3")
        campos.Rows.Add("YEAR(TBG.FECHAPRESENTACION)", "Año de Presentación", "2")
        campos.Rows.Add("2", "Todos los tableros", "4")
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de registros de Material No Conforme"
        frbuscar.tabla = 50
        frbuscar.ShowDialog()
        Try
            Dim DSbusqueda = frbuscar.DsBuscar
            dsOrdenesDeTrabajo = DSbusqueda
            If dsOrdenesDeTrabajo.Tables.Count > 0 Then
                If dsOrdenesDeTrabajo.Tables(0).Rows.Count > 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    tablaCargada = Tablas.TablerosTBG
                    Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(0)
                    AplicarFormatoMNC()
                Else
                    MessageBox.Show("Ningún registro encontrado.", "Buscar registros de Material No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region 'Tableros TBG

#Region "Plan de Optimización"
    Private Sub Nbi_ListarPlanesOptimizacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarPlanesOptimizacion.ItemClick
        ListarPDO()
    End Sub

    Private Sub ListarPDO()
        Cursor.Current = Cursors.WaitCursor
        dsOrdenesDeTrabajo = bddatos.BusquedaCondiciones(51, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If Not IsNothing(dsOrdenesDeTrabajo) AndAlso dsOrdenesDeTrabajo.Tables.Count > 0 Then
            tablaCargada = Tablas.PlanDeOptimizacion
            Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(1)
            AplicarFormatoPDO()
            If Dgv_ListaOrdenTrabajo.Rows.Count > 0 Then
                Dgv_ListaOrdenTrabajo.Rows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub AplicarFormatoPDO()
        AplicarFormatoColumnas()
        Lb_CantidadOrdenTrabajo.Text = "Cantidad de registros de Plan de Optimización: " & Dgv_ListaOrdenTrabajo.Rows.Count
    End Sub

    Private Sub Nbi_CrearPlanOptimizacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearPlanOptimizacion.ItemClick
        CrearPDO()
    End Sub

    Private Sub CrearPDO()
        Using frPlanOptimizacion As New Fr_PlanDeOptimizacion
            frPlanOptimizacion.TipoEdicion = Fr_PlanDeOptimizacion.TiposEdicion.Crear
            frPlanOptimizacion.ShowDialog()
            If frPlanOptimizacion.Guardado Then
                ListarPDO()
            End If
        End Using
    End Sub

    Private Sub Nbi_EditarPlanOptimizacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarPlanOptimizacion.ItemClick
        If tablaCargada = Tablas.PlanDeOptimizacion Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Dgv_ListaOrdenTrabajo.SelectedRows(0).Index
                EditarPDO(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDPLANOPTIMIZACION").Value)
                Ubicar_Registro()
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de Plan de Optimización.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub EditarPDO(idPlanOptimizacion As Integer)
        Using frPlanOptimizacion As New Fr_PlanDeOptimizacion
            frPlanOptimizacion.IdPlanOptimizacion = idPlanOptimizacion
            frPlanOptimizacion.TipoEdicion = Fr_PlanDeOptimizacion.TiposEdicion.Editar
            frPlanOptimizacion.ShowDialog()
            If frPlanOptimizacion.Guardado Then
                ListarPDO()
            End If
        End Using
    End Sub

    Private Sub Nbi_VerPlanOptimizacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerPlanOptimizacion.ItemClick
        If tablaCargada = Tablas.PlanDeOptimizacion Then
            If Dgv_ListaOrdenTrabajo.SelectedRows.Count > 0 Then
                VerPDO(Dgv_ListaOrdenTrabajo.SelectedRows(0).Cells("IDPLANOPTIMIZACION").Value)
            Else
                MessageBox.Show("Seleccione un registro para realizar la operación.", "Ver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Cargue el listado de Plan de Optimización.", "Ver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub VerPDO(idPlanOptimizacion As Integer)
        Using frPlanOptimizacion As New Fr_PlanDeOptimizacion
            frPlanOptimizacion.IdPlanOptimizacion = idPlanOptimizacion
            frPlanOptimizacion.TipoEdicion = Fr_PlanDeOptimizacion.TiposEdicion.Ver
            frPlanOptimizacion.ShowDialog()
        End Using
    End Sub

    Private Sub Nbi_BuscarPlanesOptimizacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarPlanesOptimizacion.ItemClick
        BuscarPDO()
    End Sub

    Private Sub BuscarPDO()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")

        campos.Rows.Add("PDO.IDPLANOPTIMIZACION", "Id. de plan de optimización", "2")
        campos.Rows.Add("2", "Título", "7")
        campos.Rows.Add("3", "Propósito de mejora", "7")
        campos.Rows.Add("4", "Nombre del archivo de optimización", "7")
        campos.Rows.Add("PDO.FECHAREGISTRO", "Fecha de registro", "3")

        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de registros de Plan de Optimización"
        frbuscar.tabla = 51
        frbuscar.ShowDialog()
        Try
            Dim DSbusqueda = frbuscar.DsBuscar
            dsOrdenesDeTrabajo = DSbusqueda
            If dsOrdenesDeTrabajo.Tables.Count > 0 Then
                If dsOrdenesDeTrabajo.Tables(0).Rows.Count > 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    tablaCargada = Tablas.PlanDeOptimizacion
                    Dgv_ListaOrdenTrabajo.DataSource = dsOrdenesDeTrabajo.Tables(0)
                    AplicarFormatoPDO()
                Else
                    MessageBox.Show("Ningún registro encontrado", "Buscar registros de Plan de Optimización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar, por favor vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region 'Plan de Optimización


End Class 'Cu_OrdendeTrabajo


Friend Class Pro_OT
    Private _IdOrdenTrabajo As String
    Private _numeroOrdenTrabajo As String
    Private _suborden As String
    Private _numeroOrdenSapPadre As String
    Private _base As String
    Private _fechacreacionSap As Date
    Private _objeto As String
    Private _claseOrdenSap As String
    Private _actividad As String
    Private _estado As String
    Private _estadoSAP As String
    Private _fechaInicio As Date
    Private _fechaFin As Date
    Private _fechaFinextremo As Date
    Private _areaAtencionPrimaria As String
    Private _tipoActividad As String
    Private _tipoReparacion As String
    Private _municipio As String
    Private _vereda As String
    Private _observacion As String
    Private _supervisorIsmocol As String
    Private _supervisorEcopetrol As String
    Private _facturador As String
    Private _valorTotalSap As String
    Private _valorTotalIsmocol As String
    Private _valorTotalServicios As String
    Private _valorTotalPersonal As String
    Private _valorTotalEquipo As String
    Private _valorTotalCIndirecto As String
    Private _valorTotalMateriales As String
    Private _valorTotalComplemento As String
    Private _admin As String
    Private _impuestos As String
    Private _utilidad As String
    Private _georeferenciación As String
    Private _abscisa As String
    Private _usuarioRegistra As String
    Private _usuarioModifica As String
    Private _fechaRegistro As Date
    Private _fechaModificacion As Date
    Private _dtServicios As DataTable


    <Description(""), _
    Category("Descripción"),
    DisplayNameAttribute("Número Orden de Mantenimiento SAP")> _
    ReadOnly Property NumeroOrdenTrabajo() As String
        Get
            Return _numeroOrdenTrabajo
        End Get
    End Property

    <Description(""), _
    Category("Descripción"),
    DisplayNameAttribute("Id Orden de Mantenimiento SAP")> _
    ReadOnly Property IdOrdenTrabajo() As String
        Get
            Return _IdOrdenTrabajo
        End Get
    End Property

    <Description(""), _
    Category("Descripción"),
    DisplayNameAttribute("Sub Orden")> _
    ReadOnly Property Suborden() As String
        Get
            Return _suborden
        End Get
    End Property

    <Description("Número Orden Sap Padre"), _
    Category("Descripción"),
    DisplayNameAttribute("Número Orden Sap Padre")> _
    ReadOnly Property NumeroOrdenSapPadre() As String
        Get
            Return _numeroOrdenSapPadre
        End Get
    End Property

    <Description("Base"), _
    Category("Descripción"),
    DisplayNameAttribute("Base")> _
    ReadOnly Property Base() As String
        Get
            Return _base
        End Get
    End Property

    <Description("Fecha Creación SAP"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Creación SAP")> _
    ReadOnly Property FechaCreacionSap() As String
        Get
            Return _fechacreacionSap
        End Get
    End Property

    <Description("Objeto"), _
    Category("Descripción"),
    DisplayNameAttribute("Objeto")> _
    ReadOnly Property Objeto() As String
        Get
            Return _objeto
        End Get
    End Property

    <Description("Clase Orden SAP"), _
    Category("Descripción"),
    DisplayNameAttribute("Clase Orden SAP")> _
    ReadOnly Property ClaseOrdenSap() As String
        Get
            Return _claseOrdenSap
        End Get
    End Property

    <Description("Actividad"), _
    Category("Descripción"),
    DisplayNameAttribute("Actividad")> _
    ReadOnly Property Actividad() As String
        Get
            Return _actividad
        End Get
    End Property

    <Description("Estado"), _
    Category("Descripción"),
    DisplayNameAttribute("Estado")> _
    ReadOnly Property Estado() As String
        Get
            Return _estado
        End Get
    End Property

    <Description("Estado SAP"), _
    Category("Descripción"),
    DisplayNameAttribute("EstadoSAP")> _
    ReadOnly Property EstadoSAP() As String
        Get
            Return _estadoSAP
        End Get
    End Property


    <Description("Fecha Inicio"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Inicio")> _
    ReadOnly Property FechaInicio() As String
        Get
            Return _fechaInicio
        End Get
    End Property

    <Description("Fecha Fin"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Fin")> _
    ReadOnly Property FechaFin() As String
        Get
            Return _fechaFin
        End Get
    End Property

    <Description("Fecha Fin Extremo"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Fin Extremo")> _
    ReadOnly Property FechaFinExtremo() As String
        Get
            Return _fechaFinextremo
        End Get
    End Property

    <Description("Area Atención Primaria"), _
    Category("Descripción"),
    DisplayNameAttribute("Area Atención Primaria")> _
    ReadOnly Property AreaAtencionPrimeria() As String
        Get
            Return _areaAtencionPrimaria
        End Get
    End Property

    <Description("Tipo Actividad"), _
    Category("Descripción"),
    DisplayNameAttribute("Tipo Actividad")> _
    ReadOnly Property TipoActividad() As String
        Get
            Return _tipoActividad
        End Get
    End Property

    <Description("Tipo Reparación"), _
    Category("Descripción"),
    DisplayNameAttribute("Tipo Reparación")> _
    ReadOnly Property Tiporeparacion() As String
        Get
            Return _tipoReparacion
        End Get
    End Property

    <Description("Observación"), _
    Category("Descripción"),
    DisplayNameAttribute("Observación")> _
    ReadOnly Property Observacion() As String
        Get
            Return _observacion
        End Get
    End Property

    <Description("Supervisor Ismocol"), _
    Category("Persona"),
    DisplayNameAttribute("Supervisor Ismocol")> _
    ReadOnly Property SupervisorI() As String
        Get
            Return _supervisorIsmocol
        End Get
    End Property

    <Description("Supervisor Ecopetrol"), _
    Category("Persona"),
    DisplayNameAttribute("Supervisor Ecopetrol")> _
    ReadOnly Property SupervisorE() As String
        Get
            Return _supervisorEcopetrol
        End Get
    End Property

    <Description("Facturador"), _
    Category("Persona"),
    DisplayNameAttribute("Facturador")> _
    ReadOnly Property Facturador() As String
        Get
            Return _facturador
        End Get
    End Property

    <Description("Valor Total SAP"), _
    Category("Presupuesto"),
    DisplayNameAttribute("Valor Total SAP")> _
    ReadOnly Property valorTotalS() As String
        Get
            Return _valorTotalSap
        End Get
    End Property

    <Description("Valor Total Ismocol"), _
    Category("Presupuesto"),
    DisplayNameAttribute("Valor Total Ismocol")> _
    ReadOnly Property ValorTotalI() As String
        Get
            Return _valorTotalIsmocol
        End Get
    End Property

    <Description("Valor Total Servicios"), _
    Category("Presupuesto"),
    DisplayNameAttribute("Valor Total Servicios")> _
    ReadOnly Property ValorTotalSv() As String
        Get
            Return _valorTotalServicios
        End Get
    End Property

    <Description("Valor Total Personal"), _
    Category("Presupuesto"),
    DisplayNameAttribute("Valor Total Personal")> _
    ReadOnly Property ValorTotalP() As String
        Get
            Return _valorTotalPersonal
        End Get
    End Property

    <Description("Valor Total Equipo"), _
    Category("Presupuesto"),
    DisplayNameAttribute("Valor Total Equipo")> _
    ReadOnly Property ValorTotalE() As String
        Get
            Return _valorTotalEquipo
        End Get
    End Property

    <Description("Valor Total C Indirecto"), _
    Category("Presupuesto"),
    DisplayNameAttribute("Valor Total C Indirecto")> _
    ReadOnly Property ValorTotalCI() As String
        Get
            Return _valorTotalCIndirecto
        End Get
    End Property

    <Description("Valor Total Materiales"), _
    Category("Presupuesto"),
    DisplayNameAttribute("Valor Total Materiales")> _
    ReadOnly Property ValorTotalM() As String
        Get
            Return _valorTotalMateriales
        End Get
    End Property

    <Description("Valor Total Complemento"), _
    Category("Presupuesto"),
    DisplayNameAttribute("Valor Total Complemento")> _
    ReadOnly Property ValorTotalComp() As String
        Get
            Return _valorTotalComplemento
        End Get
    End Property

    <Description("Administración"), _
    Category("Presupuesto"),
    DisplayNameAttribute("Administración")> _
    ReadOnly Property Admin() As String
        Get
            Return _admin
        End Get
    End Property

    <Description("Impuestos"), _
    Category("Presupuesto"),
    DisplayNameAttribute("Impuestos")> _
    ReadOnly Property Impuestos() As String
        Get
            Return _impuestos
        End Get
    End Property

    <Description("Utilidad"), _
    Category("Presupuesto"),
    DisplayNameAttribute("Utilidad")> _
    ReadOnly Property Utilidad() As String
        Get
            Return _utilidad
        End Get
    End Property

    <Description("Georeferenciación"), _
    Category("Localización"),
    DisplayNameAttribute("Georeferenciación")> _
    ReadOnly Property Georefrenciación() As String
        Get
            Return _georeferenciación
        End Get
    End Property

    <Description("Abscisa"), _
    Category("Localización"),
    DisplayNameAttribute("Abscisa")> _
    ReadOnly Property Abscisa() As String
        Get
            Return _abscisa
        End Get
    End Property

    <Description("Municipio"), _
    Category("Localización"),
    DisplayNameAttribute("Municipio")> _
    ReadOnly Property Municipio() As String
        Get
            Return _municipio
        End Get
    End Property

    <Description("Vereda"), _
    Category("Localización"),
    DisplayNameAttribute("Vereda")> _
    ReadOnly Property Vereda() As String
        Get
            Return _vereda
        End Get
    End Property

    <Description("Persona quien realiza el Registro"), _
    Category("Auditoria"),
    DisplayNameAttribute("Usuario Registra")> _
    ReadOnly Property URegistro() As String
        Get
            Return _usuarioRegistra
        End Get
    End Property

    <Description("Fecha de Registro"), _
    Category("Auditoria"),
    DisplayNameAttribute("Fecha Registro")> _
    ReadOnly Property FechaRegistro() As String
        Get
            Return _fechaRegistro
        End Get
    End Property

    <Description("Persona quien modifica el Registro"), _
    Category("Auditoria"),
    DisplayNameAttribute("Usuario Modifica")> _
    ReadOnly Property UModifica() As String
        Get
            Return _usuarioModifica
        End Get
    End Property

    <Description("Fecha de Modificación"), _
     Category("Auditoria"),
     DisplayNameAttribute("Fecha Modificación")> _
    ReadOnly Property FechaModifica() As String
        Get
            Return _fechaModificacion
        End Get
    End Property

    Public Sub New(ByVal FilaOT As DataGridViewRow)

        Try
            _numeroOrdenTrabajo = FilaOT.Cells("NROORDENSAP").Value
        Catch
            _numeroOrdenTrabajo = ""
        End Try

        Try
            _IdOrdenTrabajo = FilaOT.Cells("IDORDENTRABAJO").Value
        Catch
            _IdOrdenTrabajo = ""
        End Try

        Try
            _suborden = FilaOT.Cells("Sub Orden").Value
        Catch
            _suborden = ""
        End Try

        Try
            _numeroOrdenSapPadre = FilaOT.Cells("Numero OSAP Padre").Value
        Catch
            _numeroOrdenSapPadre = ""
        End Try

        Try
            _base = FilaOT.Cells("NOMBREBASE").Value
        Catch
            _base = ""
        End Try

        Try
            _fechacreacionSap = FilaOT.Cells("FECHACREACIONSAP").Value
        Catch
            _fechacreacionSap = ""
        End Try

        Try
            _objeto = FilaOT.Cells("OBJETO").Value
        Catch
            _objeto = ""
        End Try

        Try
            _claseOrdenSap = FilaOT.Cells("Clase Orden").Value
        Catch
            _claseOrdenSap = ""
        End Try

        Try
            _actividad = FilaOT.Cells("Actividad").Value
        Catch
            _actividad = ""
        End Try

        Try
            _estado = FilaOT.Cells("ESTADO").Value
        Catch
            _estado = ""
        End Try

        Try
            _estadoSAP = FilaOT.Cells("ESTADOSAP").Value
        Catch
            _estadoSAP = ""
        End Try

        Try
            _fechaInicio = FilaOT.Cells("FECHAINICIO").Value
        Catch
            _fechaInicio = ""
        End Try

        Try
            _fechaFin = FilaOT.Cells("FECHAFIN").Value
        Catch
            _fechaFin = ""
        End Try

        Try
            _fechaFinextremo = FilaOT.Cells("FECHAFINEXTREMO").Value
        Catch
            _fechaFinextremo = ""
        End Try

        Try
            _areaAtencionPrimaria = FilaOT.Cells("Area Primaria").Value
        Catch
            _areaAtencionPrimaria = ""
        End Try

        Try
            _tipoActividad = FilaOT.Cells("Tipo Actividad").Value
        Catch
            _tipoActividad = ""
        End Try

        Try
            _tipoReparacion = FilaOT.Cells("Tipo Reparacion").Value
        Catch
            _tipoReparacion = ""
        End Try

        Try
            _municipio = FilaOT.Cells("Municipio").Value
        Catch
            _municipio = ""
        End Try

        Try
            _vereda = FilaOT.Cells("Vereda").Value
        Catch
            _vereda = ""
        End Try

        Try
            _observacion = FilaOT.Cells("Observacion").Value
        Catch
            _observacion = ""
        End Try

        Try
            _supervisorIsmocol = FilaOT.Cells("Supervisor Ismocol").Value
        Catch
            _supervisorIsmocol = ""


        End Try

        Try
            _supervisorEcopetrol = FilaOT.Cells("Supervisor Ecopetrol").Value
        Catch
            _supervisorEcopetrol = ""
        End Try

        Try
            _facturador = FilaOT.Cells("Facturador").Value
        Catch
            _facturador = ""
        End Try

        If VariablesBase.VariablesBase.TipoUsuario <> 26 And VariablesBase.VariablesBase.TipoUsuario <> 50 Then
            Try
                _valorTotalSap = FilaOT.Cells("Valor Sap").Value
            Catch
                _valorTotalSap = ""
            End Try

            Try
                _valorTotalIsmocol = FilaOT.Cells("Valor Ismocol").Value
            Catch
                _valorTotalIsmocol = ""
            End Try

            Try
                _admin = FilaOT.Cells("PORADMINISTRACION").Value
            Catch
                _admin = ""
            End Try

            Try
                _impuestos = FilaOT.Cells("PORIMPUESTOS").Value
            Catch
                _impuestos = ""
            End Try

            Try
                _utilidad = FilaOT.Cells("PORUTILIDAD").Value
            Catch
                _utilidad = ""
            End Try

            Try
                _valorTotalServicios = FilaOT.Cells("valor total servicio").Value
            Catch
                _valorTotalServicios = ""
            End Try

            Try
                _valorTotalPersonal = FilaOT.Cells("valor total personal").Value
            Catch
                _valorTotalPersonal = ""
            End Try

            Try
                _valorTotalEquipo = FilaOT.Cells("valor total equipo").Value
            Catch
                _valorTotalEquipo = ""
            End Try

            Try
                _valorTotalCIndirecto = FilaOT.Cells("valor total CIndirecto").Value
            Catch
                _valorTotalCIndirecto = ""
            End Try

            Try
                _valorTotalMateriales = FilaOT.Cells("valor materiales").Value
            Catch
                _valorTotalMateriales = ""
            End Try

            Try
                _valorTotalComplemento = FilaOT.Cells("valor complemento").Value
            Catch
                _valorTotalComplemento = ""
            End Try

        End If

        Try
            _georeferenciación = FilaOT.Cells("GEOREFERENCIACION").Value
        Catch
            _georeferenciación = ""
        End Try

        Try
            _abscisa = FilaOT.Cells("ABSCISA").Value
        Catch
            _abscisa = ""
        End Try

        Try
            _usuarioRegistra = FilaOT.Cells("Usuario Registra").Value
        Catch
            _usuarioRegistra = ""
        End Try

        Try
            _fechaRegistro = FilaOT.Cells("FECHAREGISTRO").Value
        Catch
            _fechaRegistro = ""
        End Try

        Try
            _usuarioModifica = FilaOT.Cells("Usuario Modifica").Value
        Catch
            _usuarioModifica = ""
        End Try

        Try
            _fechaModificacion = FilaOT.Cells("FECHAMODIFICACION").Value
        Catch
            _fechaModificacion = ""
        End Try
    End Sub
End Class 'Pro_OT

Friend Class Pro_MaterialNoConforme
    Private _IdMaterialNoConforme As String = ""
    Private _Base As String = ""
    Private _Contrato As String = ""
    Private _NumeroReporte As String = ""
    Private _Lugar As String = ""
    Private _FechaRecepcion As String = ""
    Private _NombreProveedor As String = ""
    Private _NitProveedor As String = ""
    Private _OrdenTrabajo As String = ""
    Private _Ciudad As String = ""
    Private _Requisicion As String = ""
    Private _Remision As String = ""
    Private _OrdenCompra As String = ""
    Private _ItemOC As String = ""
    Private _Material As String = ""
    Private _Unidad As String = ""
    Private _Cantidad As String = ""
    Private _Observacion As String = ""
    Private _Descripcion As String = ""
    Private _Marcado As String = ""
    Private _LlevadoAreaCuarentena As String = ""
    Private _Seguimiento As String = ""
    Private _PersonaElabora As String = ""
    Private _PersonaVerifica As String = ""
    Private _PersonaAcepta As String = ""
    Private _Cerrado As String = ""
    Private _FechaCierre As String = ""
    Private _UsuarioCierra As String = ""
    Private _Anulado As String = ""
    Private _FechaAnulacion As String = ""
    Private _UsuarioAnula As String = ""
    Private _FechaRegistro As String = ""
    Private _UsuarioRegistra As String = ""
    Private _FechaModificacion As String = ""
    Private _UsuarioModifica As String = ""

    <Description("Identificador del registro de Material No Conforme"), _
    Category("Reporte"),
    DisplayNameAttribute("Id")> _
    ReadOnly Property Id() As String
        Get
            Return _IdMaterialNoConforme
        End Get
    End Property

    <Description("Base en la que se realizó el registro"), _
    Category("Reporte"),
    DisplayNameAttribute("Base")> _
    ReadOnly Property Base() As String
        Get
            Return _Base
        End Get
    End Property

    <Description("Número de contrato del proyecto"), _
    Category("Reporte"),
    DisplayNameAttribute("Contrato")> _
    ReadOnly Property Contrato() As String
        Get
            Return _Contrato
        End Get
    End Property

    <Description("Número de reporte"), _
    Category("Reporte"),
    DisplayNameAttribute("Número Reporte")> _
    ReadOnly Property NumeroReporte() As String
        Get
            Return _NumeroReporte
        End Get
    End Property

    <Description("Lugar"), _
    Category("Reporte"),
    DisplayNameAttribute("Lugar")> _
    ReadOnly Property Lugar() As String
        Get
            Return _Lugar
        End Get
    End Property

    <Description("Fecha de recepción"), _
    Category("Adquisición"),
    DisplayNameAttribute("Fecha Recepción")> _
    ReadOnly Property FechaRecepcion() As String
        Get
            Return _FechaRecepcion
        End Get
    End Property

    <Description("Razón social del proveedor"), _
    Category("Proveedor"),
    DisplayNameAttribute("Nombre")> _
    ReadOnly Property NombreProveedor() As String
        Get
            Return _NombreProveedor
        End Get
    End Property

    <Description("Identificación del proveedor"), _
    Category("Proveedor"),
    DisplayNameAttribute("NIT")> _
    ReadOnly Property NitProveedor() As String
        Get
            Return _NitProveedor
        End Get
    End Property

    <Description("Orden de trabajo"), _
    Category("Orden de trabajo"),
    DisplayNameAttribute("Orden de Mantenimiento SAP")> _
    ReadOnly Property OrdenTrabajo() As String
        Get
            Return _OrdenTrabajo
        End Get
    End Property

    <Description("Ciudad o población"), _
    Category("Reporte"),
    DisplayNameAttribute("Ciudad")> _
    ReadOnly Property Ciudad() As String
        Get
            Return _Ciudad
        End Get
    End Property

    <Description("Número de requisición"), _
    Category("Adquisición"),
    DisplayNameAttribute("Requisición")> _
    ReadOnly Property Requisicion() As String
        Get
            Return _Requisicion
        End Get
    End Property

    <Description("Número de remisión"), _
    Category("Adquisición"),
    DisplayNameAttribute("Remisión")> _
    ReadOnly Property Remision() As String
        Get
            Return _Remision
        End Get
    End Property

    <Description("Número de orden de compra"), _
    Category("Adquisición"),
    DisplayNameAttribute("Orden de Compra")> _
    ReadOnly Property OrdenCompra() As String
        Get
            Return _OrdenCompra
        End Get
    End Property

    <Description("Ítem en la orden de compra"), _
    Category("Adquisición"),
    DisplayNameAttribute("Ítem OC")> _
    ReadOnly Property ItemOC() As String
        Get
            Return _ItemOC
        End Get
    End Property

    <Description("Material"), _
    Category("Material"),
    DisplayNameAttribute("Material")> _
    ReadOnly Property Material() As String
        Get
            Return _Material
        End Get
    End Property

    <Description("Unidad de medida"), _
    Category("Material"),
    DisplayNameAttribute("Unidad")> _
    ReadOnly Property Unidad() As String
        Get
            Return _Unidad
        End Get
    End Property

    <Description("Cantidad"), _
    Category("Material"),
    DisplayNameAttribute("Cantidad")> _
    ReadOnly Property Cantidad() As String
        Get
            Return _Cantidad
        End Get
    End Property

    <Description("Observación"), _
    Category("Reporte"),
    DisplayNameAttribute("Observación")> _
    ReadOnly Property Observacion() As String
        Get
            Return _Observacion
        End Get
    End Property

    <Description("Descripción"), _
    Category("Reporte"),
    DisplayNameAttribute("Descripción")> _
    ReadOnly Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
    End Property

    <Description("Marcado"), _
    Category("Reporte"),
    DisplayNameAttribute("Marcado")> _
    ReadOnly Property Marcado() As String
        Get
            Return _Marcado
        End Get
    End Property

    <Description("Llevado al área de cuarentena"), _
    Category("Reporte"),
    DisplayNameAttribute("Llevado Área Cuarentena")> _
    ReadOnly Property LlevadoAreaCuarentena() As String
        Get
            Return _LlevadoAreaCuarentena
        End Get
    End Property

    <Description("Seguimiento"), _
    Category("Seguimiento"),
    DisplayNameAttribute("Seguimiento")> _
    ReadOnly Property Seguimiento() As String
        Get
            Return _Seguimiento
        End Get
    End Property

    <Description("Nombre de la persona que elaboró el reporte"), _
    Category("Firmantes"),
    DisplayNameAttribute("Persona  Elaboró")> _
    ReadOnly Property PersonaElabora() As String
        Get
            Return _PersonaElabora
        End Get
    End Property

    <Description("Nombre de la persona que verificó el reporte"), _
    Category("Firmantes"),
    DisplayNameAttribute("Persona Verificó")> _
    ReadOnly Property PersonaVerifica() As String
        Get
            Return _PersonaVerifica
        End Get
    End Property

    <Description("Nombre de la persona que aceptó el reporte"), _
    Category("Firmantes"),
    DisplayNameAttribute("Persona Aceptó")> _
    ReadOnly Property PersonaAcepta() As String
        Get
            Return _PersonaAcepta
        End Get
    End Property

    <Description("Cerrado"), _
    Category("Cierre"),
    DisplayNameAttribute("Cerrado")> _
    ReadOnly Property Cerrado() As String
        Get
            Return _Cerrado
        End Get
    End Property

    <Description("Fecha de cierre"), _
    Category("Cierre"),
    DisplayNameAttribute("Fecha Cierre")> _
    ReadOnly Property FechaCierre() As String
        Get
            Return _FechaCierre
        End Get
    End Property

    <Description("Nombre del usuario que cerró el reporte"), _
    Category("Cierre"),
    DisplayNameAttribute("Usuario Cerró")> _
    ReadOnly Property UsuarioCierra() As String
        Get
            Return _UsuarioCierra
        End Get
    End Property

    <Description("Anulado"), _
    Category("Anulación"),
    DisplayNameAttribute("Anulado")> _
    ReadOnly Property Anulado() As String
        Get
            Return _Anulado
        End Get
    End Property

    <Description("Fecha de anulación"), _
    Category("Anulación"),
    DisplayNameAttribute("Fecha Anulación")> _
    ReadOnly Property FechaAnulacion() As String
        Get
            Return _FechaAnulacion
        End Get
    End Property

    <Description("Nombre del usuario que anuló el reporte"), _
    Category("Anulación"),
    DisplayNameAttribute("Usuario Anuló")> _
    ReadOnly Property UsuarioAnula() As String
        Get
            Return _UsuarioAnula
        End Get
    End Property

    <Description("Fecha de registro en el sistema"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Registro")> _
    ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Nombre del usuario que registró"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Registró")> _
    ReadOnly Property UsuarioRegistra() As String
        Get
            Return _UsuarioRegistra
        End Get
    End Property

    <Description("Fecha de modificación"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Modificación")> _
    ReadOnly Property FechaModificacion() As String
        Get
            Return _FechaModificacion
        End Get
    End Property

    <Description("Nombre del usuario que modificó"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Modificó")> _
    ReadOnly Property UsuarioModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property

    Public Sub New(fila As DataGridViewRow)
        _IdMaterialNoConforme = fila.Cells("IDMATERIALNOCONFORME").Value
        If Not IsDBNull(fila.Cells("IDMATERIALNOCONFORME").Value) Then
            _IdMaterialNoConforme = fila.Cells("IDMATERIALNOCONFORME").Value
        End If
        If Not IsDBNull(fila.Cells("BASE").Value) Then
            _Base = fila.Cells("BASE").Value
        End If
        If Not IsDBNull(fila.Cells("CONTRATO").Value) Then
            _Contrato = fila.Cells("CONTRATO").Value
        End If
        If Not IsDBNull(fila.Cells("NUMEROREPORTE").Value) Then
            _NumeroReporte = fila.Cells("NUMEROREPORTE").Value
        End If
        If Not IsDBNull(fila.Cells("LUGAR").Value) Then
            _Lugar = fila.Cells("LUGAR").Value
        End If
        If Not IsDBNull(fila.Cells("FECHARECEPCION").Value) Then
            _FechaRecepcion = fila.Cells("FECHARECEPCION").Value
        End If
        If Not IsDBNull(fila.Cells("NOMBREPROVEEDOR").Value) Then
            _NombreProveedor = fila.Cells("NOMBREPROVEEDOR").Value
        End If
        If Not IsDBNull(fila.Cells("NITPROVEEDOR").Value) Then
            _NitProveedor = fila.Cells("NITPROVEEDOR").Value
        End If
        If Not IsDBNull(fila.Cells("ORDENTRABAJO").Value) Then
            _OrdenTrabajo = fila.Cells("ORDENTRABAJO").Value
        End If
        If Not IsDBNull(fila.Cells("CIUDAD").Value) Then
            _Ciudad = fila.Cells("CIUDAD").Value
        End If
        If Not IsDBNull(fila.Cells("REQUISICION").Value) Then
            _Requisicion = fila.Cells("REQUISICION").Value
        End If
        If Not IsDBNull(fila.Cells("REMISION").Value) Then
            _Remision = fila.Cells("REMISION").Value
        End If
        If Not IsDBNull(fila.Cells("ORDENCOMPRA").Value) Then
            _OrdenCompra = fila.Cells("ORDENCOMPRA").Value
        End If
        If Not IsDBNull(fila.Cells("ITEMORDENCOMPRA").Value) Then
            _ItemOC = fila.Cells("ITEMORDENCOMPRA").Value
        End If
        If Not IsDBNull(fila.Cells("MATERIAL").Value) Then
            _Material = fila.Cells("MATERIAL").Value
        End If
        If Not IsDBNull(fila.Cells("UNIDAD").Value) Then
            _Unidad = fila.Cells("UNIDAD").Value
        End If
        If Not IsDBNull(fila.Cells("CANTIDAD").Value) Then
            _Cantidad = fila.Cells("CANTIDAD").Value
        End If
        If Not IsDBNull(fila.Cells("OBSERVACION").Value) Then
            _Observacion = fila.Cells("OBSERVACION").Value
        End If
        If Not IsDBNull(fila.Cells("DESCRIPCION").Value) Then
            _Descripcion = fila.Cells("DESCRIPCION").Value
        End If
        If Not IsDBNull(fila.Cells("MARCADO").Value) Then
            If fila.Cells("MARCADO").Value = "S" Then
                _Marcado = "Sí"
            ElseIf fila.Cells("MARCADO").Value = "N" Then
                _Marcado = "No"
            End If
        End If
        If Not IsDBNull(fila.Cells("LLEVADOAREACUARENTENA").Value) Then
            If fila.Cells("LLEVADOAREACUARENTENA").Value = "S" Then
                _LlevadoAreaCuarentena = "Sí"
            ElseIf fila.Cells("LLEVADOAREACUARENTENA").Value = "N" Then
                _LlevadoAreaCuarentena = "No"
            End If
        End If
        If Not IsDBNull(fila.Cells("SEGUIMIENTO").Value) Then
            _Seguimiento = fila.Cells("SEGUIMIENTO").Value
        End If
        If Not IsDBNull(fila.Cells("PERSONAELABORA").Value) Then
            _PersonaElabora = fila.Cells("PERSONAELABORA").Value
        End If
        If Not IsDBNull(fila.Cells("PERSONAVERIFICA").Value) Then
            _PersonaVerifica = fila.Cells("PERSONAVERIFICA").Value
        End If
        If Not IsDBNull(fila.Cells("PERSONAACEPTA").Value) Then
            _PersonaAcepta = fila.Cells("PERSONAACEPTA").Value
        End If
        If Not IsDBNull(fila.Cells("CERRADO").Value) Then
            _Cerrado = fila.Cells("CERRADO").Value
        End If
        If Not IsDBNull(fila.Cells("FECHACIERRE").Value) Then
            _FechaCierre = fila.Cells("FECHACIERRE").Value
        End If
        If Not IsDBNull(fila.Cells("USUARIOCIERRA").Value) Then
            _UsuarioCierra = fila.Cells("USUARIOCIERRA").Value
        End If
        If Not IsDBNull(fila.Cells("ANULADO").Value) Then
            _Anulado = fila.Cells("ANULADO").Value
        End If
        If Not IsDBNull(fila.Cells("FECHAANULACION").Value) Then
            _FechaAnulacion = fila.Cells("FECHAANULACION").Value
        End If
        If Not IsDBNull(fila.Cells("USUARIOANULA").Value) Then
            _UsuarioAnula = fila.Cells("USUARIOANULA").Value
        End If
        If Not IsDBNull(fila.Cells("FECHAREGISTRO").Value) Then
            _FechaRegistro = fila.Cells("FECHAREGISTRO").Value
        End If
        If Not IsDBNull(fila.Cells("USUARIOREGISTRA").Value) Then
            _UsuarioRegistra = fila.Cells("USUARIOREGISTRA").Value
        End If
        If Not IsDBNull(fila.Cells("FECHAMODIFICACION").Value) Then
            _FechaModificacion = fila.Cells("FECHAMODIFICACION").Value
        End If
        If Not IsDBNull(fila.Cells("USUARIOMODIFICA").Value) Then
            _UsuarioModifica = fila.Cells("USUARIOMODIFICA").Value
        End If
    End Sub
End Class 'Pro_MaterialNoConforme

Friend Class Pro_NoConformidad
    Private _IdNoConformidad As String = ""
    Private _Base As String = ""
    Private _Contrato As String = ""
    Private _Sistema As String = ""
    Private _TipoNoConformidad As String = ""
    Private _Fecha As String = ""
    Private _NumeroReporte As String = ""
    Private _NumeroAuditoria As String = ""
    Private _Proceso As String = ""
    Private _Detector As String = ""
    Private _Fuente As String = ""
    Private _RepresentanteProceso As String = ""
    Private _Descripcion As String = ""
    Private _Reaccion As String = ""
    Private _ExistenSimilares As String = ""
    Private _VerificacionEficacia As String = ""
    Private _Cerrado As String = ""
    Private _FechaCierre As String = ""
    Private _UsuarioCierra As String = ""
    Private _Anulado As String = ""
    Private _FechaAnulacion As String = ""
    Private _UsuarioAnula As String = ""
    Private _FechaRegistro As String = ""
    Private _UsuarioRegistra As String = ""
    Private _FechaModificacion As String = ""
    Private _UsuarioModifica As String = ""

    <Description("Identificador del registro de No Conformidad"), _
    Category("Reporte"),
    DisplayNameAttribute("Id")> _
    ReadOnly Property Id() As String
        Get
            Return _IdNoConformidad
        End Get
    End Property

    <Description("Base en la que se realizó el registro"), _
    Category("Reporte"),
    DisplayNameAttribute("Base")> _
    ReadOnly Property Base() As String
        Get
            Return _Base
        End Get
    End Property

    <Description("Número de contrato del proyecto"), _
    Category("Reporte"),
    DisplayNameAttribute("Contrato")> _
    ReadOnly Property Contrato() As String
        Get
            Return _Contrato
        End Get
    End Property

    <Description("Sistema"), _
    Category("Reporte"),
    DisplayNameAttribute("Sistema")> _
    ReadOnly Property Sistema() As String
        Get
            Return _Sistema
        End Get
    End Property

    <Description("Tipo de No Conformidad"), _
    Category("Reporte"),
    DisplayNameAttribute("Tipo")> _
    ReadOnly Property TipoNoConformidad() As String
        Get
            Return _TipoNoConformidad
        End Get
    End Property

    <Description("Fecha del reporte"), _
    Category("Reporte"),
    DisplayNameAttribute("Fecha")> _
    ReadOnly Property Fecha() As String
        Get
            Return _Fecha
        End Get
    End Property

    <Description("Número de reporte"), _
    Category("Reporte"),
    DisplayNameAttribute("Número Reporte")> _
    ReadOnly Property NumeroReporte() As String
        Get
            Return _NumeroReporte
        End Get
    End Property

    <Description("Número de auditoría"), _
    Category("Reporte"),
    DisplayNameAttribute("Número Auditoría")> _
    ReadOnly Property NumeroAuditoria() As String
        Get
            Return _NumeroAuditoria
        End Get
    End Property

    <Description("Proceso"), _
    Category("Reporte"),
    DisplayNameAttribute("Proceso")> _
    ReadOnly Property Proceso() As String
        Get
            Return _Proceso
        End Get
    End Property

    <Description("Detector"), _
    Category("Reporte"),
    DisplayNameAttribute("Detector")> _
    ReadOnly Property PersonaDetector() As String
        Get
            Return _Detector
        End Get
    End Property

    <Description("Fuente"), _
    Category("Reporte"),
    DisplayNameAttribute("Fuente")> _
    ReadOnly Property Fuente() As String
        Get
            Return _Fuente
        End Get
    End Property

    <Description("Representante del proceso"), _
    Category("Reporte"),
    DisplayNameAttribute("Rep. del Proc.")> _
    ReadOnly Property PersonaRepProc() As String
        Get
            Return _RepresentanteProceso
        End Get
    End Property

    <Description("Descripción"), _
    Category("Reporte"),
    DisplayNameAttribute("Descripción")> _
    ReadOnly Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
    End Property

    <Description("Reacción"), _
    Category("Reporte"),
    DisplayNameAttribute("Reacción")> _
    ReadOnly Property Reaccion() As String
        Get
            Return _Reaccion
        End Get
    End Property

    <Description("Existen No Conformidades similares o que puedan ocurrir"), _
    Category("Reporte"),
    DisplayNameAttribute("Existen Similares")> _
    ReadOnly Property ExistenSimilares() As String
        Get
            Return _ExistenSimilares
        End Get
    End Property

    <Description("Verificación de la eficacia"), _
    Category("Reporte"),
    DisplayNameAttribute("Verificación Eficacia")> _
    ReadOnly Property VerificacionEficacia() As String
        Get
            Return _VerificacionEficacia
        End Get
    End Property

    <Description("Cerrado"), _
    Category("Cierre"),
    DisplayNameAttribute("Cerrado")> _
    ReadOnly Property Cerrado() As String
        Get
            Return _Cerrado
        End Get
    End Property

    <Description("Fecha de cierre"), _
    Category("Cierre"),
    DisplayNameAttribute("Fecha Cierre")> _
    ReadOnly Property FechaCierre() As String
        Get
            Return _FechaCierre
        End Get
    End Property

    <Description("Nombre del usuario que cerró el reporte"), _
    Category("Cierre"),
    DisplayNameAttribute("Usuario Cerró")> _
    ReadOnly Property UsuarioCierra() As String
        Get
            Return _UsuarioCierra
        End Get
    End Property

    <Description("Anulado"), _
    Category("Anulación"),
    DisplayNameAttribute("Anulado")> _
    ReadOnly Property Anulado() As String
        Get
            Return _Anulado
        End Get
    End Property

    <Description("Fecha de anulación"), _
    Category("Anulación"),
    DisplayNameAttribute("Fecha Anulación")> _
    ReadOnly Property FechaAnulacion() As String
        Get
            Return _FechaAnulacion
        End Get
    End Property

    <Description("Nombre del usuario que anuló el reporte"), _
    Category("Anulación"),
    DisplayNameAttribute("Usuario Anuló")> _
    ReadOnly Property UsuarioAnula() As String
        Get
            Return _UsuarioAnula
        End Get
    End Property

    <Description("Fecha de registro en el sistema"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Registro")> _
    ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Nombre del usuario que registró"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Registró")> _
    ReadOnly Property UsuarioRegistra() As String
        Get
            Return _UsuarioRegistra
        End Get
    End Property

    <Description("Fecha de modificación"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Modificación")> _
    ReadOnly Property FechaModificacion() As String
        Get
            Return _FechaModificacion
        End Get
    End Property

    <Description("Nombre del usuario que modificó"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Modificó")> _
    ReadOnly Property UsuarioModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property

    Public Sub New(fila As DataGridViewRow)
        _IdNoConformidad = fila.Cells("IDNOCONFORMIDAD").Value
        If Not IsDBNull(fila.Cells("BASE").Value) Then
            _Base = fila.Cells("BASE").Value
        End If
        If Not IsDBNull(fila.Cells("CONTRATO").Value) Then
            _Contrato = fila.Cells("CONTRATO").Value
        End If
        If Not IsDBNull(fila.Cells("SISTEMA").Value) Then
            _Sistema = fila.Cells("SISTEMA").Value
        End If
        If Not IsDBNull(fila.Cells("TIPONOCONFORMIDAD").Value) Then
            _TipoNoConformidad = fila.Cells("TIPONOCONFORMIDAD").Value
        End If
        If Not IsDBNull(fila.Cells("FECHA").Value) Then
            _Fecha = fila.Cells("FECHA").Value
        End If
        If Not IsDBNull(fila.Cells("NUMEROREPORTE").Value) Then
            _NumeroReporte = fila.Cells("NUMEROREPORTE").Value
        End If
        If Not IsDBNull(fila.Cells("NUMEROAUDITORIA").Value) Then
            _NumeroAuditoria = fila.Cells("NUMEROAUDITORIA").Value
        End If
        If Not IsDBNull(fila.Cells("PROCESO").Value) Then
            _Proceso = fila.Cells("PROCESO").Value
        End If
        If Not IsDBNull(fila.Cells("PERSONADETECTOR").Value) Then
            _Detector = fila.Cells("PERSONADETECTOR").Value
        End If
        If Not IsDBNull(fila.Cells("FUENTE").Value) Then
            _Fuente = fila.Cells("FUENTE").Value
        End If
        If Not IsDBNull(fila.Cells("PERSONAREPPROC").Value) Then
            _RepresentanteProceso = fila.Cells("PERSONAREPPROC").Value
        End If
        If Not IsDBNull(fila.Cells("DESCRIPCION").Value) Then
            _Descripcion = fila.Cells("DESCRIPCION").Value
        End If
        If Not IsDBNull(fila.Cells("REACCION").Value) Then
            _Reaccion = fila.Cells("REACCION").Value
        End If
        If Not IsDBNull(fila.Cells("EXISTENSIMILARES").Value) Then
            If fila.Cells("EXISTENSIMILARES").Value = "S" Then
                _ExistenSimilares = "Sí"
            ElseIf fila.Cells("EXISTENSIMILARES").Value = "N" Then
                _ExistenSimilares = "No"
            End If
        End If
        If Not IsDBNull(fila.Cells("VERIFICACIONEFICACIA").Value) Then
            _VerificacionEficacia = fila.Cells("VERIFICACIONEFICACIA").Value
        End If
        If Not IsDBNull(fila.Cells("CERRADO").Value) Then
            If fila.Cells("CERRADO").Value = "S" Then
                _Cerrado = "Sí"
            ElseIf fila.Cells("CERRADO").Value = "N" Then
                _Cerrado = "No"
            End If
        End If
        If Not IsDBNull(fila.Cells("FECHACIERRE").Value) Then
            _FechaCierre = fila.Cells("FECHACIERRE").Value
        End If
        If Not IsDBNull(fila.Cells("USUARIOCIERRA").Value) Then
            _UsuarioCierra = fila.Cells("USUARIOCIERRA").Value
        End If
        If Not IsDBNull(fila.Cells("ANULADO").Value) Then
            If fila.Cells("ANULADO").Value = "S" Then
                _Anulado = "Sí"
            ElseIf fila.Cells("ANULADO").Value = "N" Then
                _Anulado = "No"
            End If
        End If
        If Not IsDBNull(fila.Cells("FECHAANULACION").Value) Then
            _FechaAnulacion = fila.Cells("FECHAANULACION").Value
        End If
        If Not IsDBNull(fila.Cells("USUARIOANULA").Value) Then
            _UsuarioAnula = fila.Cells("USUARIOANULA").Value
        End If
        If Not IsDBNull(fila.Cells("FECHAREGISTRO").Value) Then
            _FechaRegistro = fila.Cells("FECHAREGISTRO").Value
        End If
        If Not IsDBNull(fila.Cells("USUARIOREGISTRA").Value) Then
            _UsuarioRegistra = fila.Cells("USUARIOREGISTRA").Value
        End If
        If Not IsDBNull(fila.Cells("FECHAMODIFICACION").Value) Then
            _FechaModificacion = fila.Cells("FECHAMODIFICACION").Value
        End If
        If Not IsDBNull(fila.Cells("USUARIOMODIFICA").Value) Then
            _UsuarioModifica = fila.Cells("USUARIOMODIFICA").Value
        End If
    End Sub
End Class 'Pro_NoConformidad

Friend Class Pro_IntervencionDirecta
    Private _IdConsecutivo As String = ""
    Private _DuracionIntervencion As String = ""
    Private _LatitudInicial As String = ""
    Private _LongitudInicial As String = ""
    Private _DistanciaInicial As String = ""
    Private _PkInicial As String = ""
    Private _LatitudFinal As String = ""
    Private _LongitudFinal As String = ""
    Private _DistanciaFinal As String = ""
    Private _PkFinal As String = ""
    Private _Espesor As String = ""
    Private _Material As String = ""
    Private _Longitud As String = ""
    Private _SoldaduraReferencia As String = ""
    Private _DistanciaSoldadura As String = ""
    Private _DistanciaSoldaduraRef As String = ""
    Private _CamisaPretensada As String = ""
    Private _Relleno As String = ""
    Private _HorasHombre As String = ""
    Private _HorasMaquina As String = ""


    <Description("Identificador Del Consecutivo de la Intervención Directa"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Id.")> _
    ReadOnly Property Id() As String
        Get
            Return _IdConsecutivo
        End Get
    End Property

    <Description(""), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Duración Intervención")> _
    ReadOnly Property Duracion() As String
        Get
            Return _DuracionIntervencion
        End Get
    End Property

    <Description("Latitud Inicial Intervención Directa"), _
    Category("Inicio Intervención"),
    DisplayNameAttribute("Latitud")> _
    ReadOnly Property LatitudIni() As String
        Get
            Return _LatitudInicial
        End Get
    End Property

    <Description("Longitud Inicial Intervención Directa"), _
    Category("Inicio Intervención"),
    DisplayNameAttribute("Longitud")> _
    ReadOnly Property LongitudIni() As String
        Get
            Return _LongitudInicial
        End Get
    End Property

    <Description("Distancia Registro Inicial Intervención Directa"), _
    Category("Inicio Intervención"),
    DisplayNameAttribute("Distancia Registro")> _
    ReadOnly Property DsitanciaIni() As String
        Get
            Return _DistanciaInicial
        End Get
    End Property

    <Description("PK Inicial Intervención Directa"), _
    Category("Inicio Intervención"),
    DisplayNameAttribute("PK")> _
    ReadOnly Property PKIni() As String
        Get
            Return _PkInicial
        End Get
    End Property

    <Description("Latitud Final Intervención Directa"), _
    Category("Fin Intervención"),
    DisplayNameAttribute("Latitud")> _
    ReadOnly Property LatitudFin() As String
        Get
            Return _LatitudInicial
        End Get
    End Property

    <Description("Longitud Final Intervención Directa"), _
    Category("Fin Intervención"),
    DisplayNameAttribute("Longitud")> _
    ReadOnly Property LongitudFin() As String
        Get
            Return _LongitudFinal
        End Get
    End Property

    <Description("Distancia Registro Intervención Directa"), _
    Category("Fin Intervención"),
    DisplayNameAttribute("Distancia Registro")> _
    ReadOnly Property DsitanciaFin() As String
        Get
            Return _DistanciaFinal
        End Get
    End Property

    <Description("PK Final Intervención Directa"), _
    Category("Fin Intervención"),
    DisplayNameAttribute("PK")> _
    ReadOnly Property PKFin() As String
        Get
            Return _PkFinal
        End Get
    End Property

    <Description("Espesor Intervención Directa"), _
    Category("Camisa/SobreCamisa"),
    DisplayNameAttribute("Espesor")> _
    ReadOnly Property Espesor() As String
        Get
            Return _Espesor
        End Get
    End Property

    <Description(" Material Intervención Directa"), _
    Category("Camisa/SobreCamisa"),
    DisplayNameAttribute("Material")> _
    ReadOnly Property Material() As String
        Get
            Return _Material
        End Get
    End Property

    <Description("Longitud Intervención Directa"), _
    Category("Camisa/SobreCamisa"),
    DisplayNameAttribute("Longitud")> _
    ReadOnly Property Longitud() As String
        Get
            Return _Longitud
        End Get
    End Property

    <Description("Soldadura Referencia Intervención Directa"), _
    Category("Camisa/SobreCamisa"),
    DisplayNameAttribute("Soldaura Ref.")> _
    ReadOnly Property SoldaduraRef() As String
        Get
            Return _SoldaduraReferencia
        End Get
    End Property

    <Description("Distancia Registro Soldadura Intervención Directa"), _
     Category("Camisa/SobreCamisa"),
     DisplayNameAttribute("Distancia Reg. Sol.")> _
    ReadOnly Property DistanciaR() As String
        Get
            Return _DistanciaSoldadura
        End Get
    End Property

    <Description("Distancia Soldadura Referencia Intervención Directa "), _
    Category("Camisa/SobreCamisa"),
    DisplayNameAttribute("Distancia Sol. Ref")> _
    ReadOnly Property DistanciaS() As String
        Get
            Return _DistanciaSoldaduraRef
        End Get
    End Property

    <Description("Camisa Pretensada Intervención Directa"), _
    Category("Camisa/SobreCamisa"),
    DisplayNameAttribute("Camisa Pret.")> _
    ReadOnly Property CamisaP() As String
        Get
            Return _CamisaPretensada
        End Get
    End Property

    <Description("Relleno de Intervención Directa"), _
    Category("Camisa/SobreCamisa"),
    DisplayNameAttribute("Relleno")> _
    ReadOnly Property Relleno() As String
        Get
            Return _Relleno
        End Get
    End Property

    <Description("Horas Hombre Evidencia de Intervención"), _
    Category("Evidencia de Intervención"),
    DisplayNameAttribute("H. Hombre")> _
    ReadOnly Property HHombre() As String
        Get
            Return _HorasHombre
        End Get
    End Property

    <Description("Horas Máquina Evidencia de Intervención."), _
    Category("Evidencia de Intervención"),
    DisplayNameAttribute("H. Máquina")> _
    ReadOnly Property HMaquina() As String
        Get
            Return _HorasMaquina
        End Get
    End Property

    Public Sub New(fila As DataGridViewRow)
        _IdConsecutivo = fila.Cells("IDCONSECUTIVO").Value
        If Not IsDBNull(fila.Cells("DURACIONINTERVENCION").Value) Then
            _DuracionIntervencion = fila.Cells("DURACIONINTERVENCION").Value
        Else
            _DuracionIntervencion = ""
        End If
        If Not IsDBNull(fila.Cells("LATITUDINI_INTERV").Value) Then
            _LatitudInicial = fila.Cells("LATITUDINI_INTERV").Value
        Else
            _LatitudInicial = ""
        End If
        If Not IsDBNull(fila.Cells("LONGITUDINI_INTERV").Value) Then
            _LongitudInicial = fila.Cells("LONGITUDINI_INTERV").Value
        Else
            _LongitudInicial = ""
        End If
        If Not IsDBNull(fila.Cells("DISTANCIAREGISTROINI_INTERV").Value) Then
            _DistanciaInicial = fila.Cells("DISTANCIAREGISTROINI_INTERV").Value
        Else
            _DistanciaInicial = ""
        End If
        If Not IsDBNull(fila.Cells("PKINI_INTERV").Value) Then
            _PkInicial = fila.Cells("PKINI_INTERV").Value
        Else
            _PkInicial = ""
        End If
        If Not IsDBNull(fila.Cells("LATITUDFIN_INTERV").Value) Then
            _LatitudFinal = fila.Cells("LATITUDFIN_INTERV").Value
        Else
            _LatitudFinal = ""
        End If
        If Not IsDBNull(fila.Cells("LONGITUDFIN_INTERV").Value) Then
            _LongitudFinal = fila.Cells("LONGITUDFIN_INTERV").Value
        Else
            _LongitudFinal = ""
        End If
        If Not IsDBNull(fila.Cells("DISTANCIAREGISTROFIN_INTERV").Value) Then
            _DistanciaFinal = fila.Cells("DISTANCIAREGISTROFIN_INTERV").Value
        Else
            _DistanciaFinal = ""
        End If
        If Not IsDBNull(fila.Cells("PKFIN_INTERV").Value) Then
            _PkFinal = fila.Cells("PKFIN_INTERV").Value
        Else
            _PkFinal = ""
        End If
        If Not IsDBNull(fila.Cells("ESPESOR").Value) Then
            _Espesor = fila.Cells("ESPESOR").Value
        Else
            _Espesor = ""
        End If
        If Not IsDBNull(fila.Cells("MATERIAL").Value) Then
            _Material = fila.Cells("MATERIAL").Value
        Else
            _Material = ""
        End If
        If Not IsDBNull(fila.Cells("LONGITUD").Value) Then
            _Longitud = fila.Cells("LONGITUD").Value
        Else
            _Longitud = ""
        End If
        If Not IsDBNull(fila.Cells("SOLDADURAREFERENCIA").Value) Then
            _SoldaduraReferencia = fila.Cells("SOLDADURAREFERENCIA").Value
        Else
            _SoldaduraReferencia = ""
        End If
        If Not IsDBNull(fila.Cells("DISTANCIAREGISTROSOLDADURA").Value) Then
            _DistanciaSoldadura = fila.Cells("DISTANCIAREGISTROSOLDADURA").Value
        Else
            _DistanciaSoldadura = ""
        End If
        If Not IsDBNull(fila.Cells("DISTANCIASOLDADURAREF").Value) Then
            _DistanciaSoldaduraRef = fila.Cells("DISTANCIASOLDADURAREF").Value
        Else
            _DistanciaSoldaduraRef = ""
        End If
        If Not IsDBNull(fila.Cells("CAMISAPRETENSADA").Value) Then
            _CamisaPretensada = fila.Cells("CAMISAPRETENSADA").Value
        Else
            _CamisaPretensada = ""
        End If
        If Not IsDBNull(fila.Cells("RELLENO").Value) Then
            _Relleno = fila.Cells("RELLENO").Value
        Else
            _Relleno = ""
        End If
        If Not IsDBNull(fila.Cells("HORASHOMBRE").Value) Then
            _HorasHombre = fila.Cells("HORASHOMBRE").Value
        Else
            _HorasHombre = ""
        End If
        If Not IsDBNull(fila.Cells("HORASMAQUINA").Value) Then
            _HorasMaquina = fila.Cells("HORASMAQUINA").Value
        Else
            _HorasMaquina = ""
        End If



    End Sub
End Class 'Pro_IntervencionDirecta


Friend Class Pro_ObrasSobreDDV
    Private _IdConsecutivo As String = ""
    Private _DuracionIntervencion As String = ""
    Private _LatitudInicial As String = ""
    Private _LongitudInicial As String = ""
    Private _DistanciaInicial As String = ""
    Private _PkInicial As String = ""
    Private _LatitudFinal As String = ""
    Private _LongitudFinal As String = ""
    Private _DistanciaFinal As String = ""
    Private _PkFinal As String = ""
    Private _HorasHombre As String = ""
    Private _HorasMaquina As String = ""


    <Description("Identificador Del Consecutivo Obras Sobre DDV"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Id.")> _
    ReadOnly Property Id() As String
        Get
            Return _IdConsecutivo
        End Get
    End Property

    <Description("Duración Intervención de Obras Sobre DDV"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Duración Intervención")> _
    ReadOnly Property Duracion() As String
        Get
            Return _DuracionIntervencion
        End Get
    End Property

    <Description("Latitud Inicial Obras Sobre DDV"), _
    Category("Inicio Intervención"),
    DisplayNameAttribute("Latitud")> _
    ReadOnly Property LatitudIni() As String
        Get
            Return _LatitudInicial
        End Get
    End Property

    <Description("Longitud Inicial Obras Sobre DDV"), _
    Category("Inicio Intervención"),
    DisplayNameAttribute("Longitud")> _
    ReadOnly Property LongitudIni() As String
        Get
            Return _LongitudInicial
        End Get
    End Property

    <Description("Distancia Registro Inicial Obras Sobre DDV"), _
    Category("Inicio Intervención"),
    DisplayNameAttribute("Distancia Registro")> _
    ReadOnly Property DsitanciaIni() As String
        Get
            Return _DistanciaInicial
        End Get
    End Property

    <Description("PK Inicial Obras Sobre DDV"), _
    Category("Inicio Intervención"),
    DisplayNameAttribute("PK")> _
    ReadOnly Property PKIni() As String
        Get
            Return _PkInicial
        End Get
    End Property

    <Description("Latitud Final Obras Sobre DDV"), _
    Category("Fin Intervención"),
    DisplayNameAttribute("Latitud")> _
    ReadOnly Property LatitudFin() As String
        Get
            Return _LatitudInicial
        End Get
    End Property

    <Description("Longitud Final Obras Sobre DDV"), _
    Category("Fin Intervención"),
    DisplayNameAttribute("Longitud")> _
    ReadOnly Property LongitudFin() As String
        Get
            Return _LongitudFinal
        End Get
    End Property

    <Description("Distancia Registro Obras Sobre DDV"), _
    Category("Fin Intervención"),
    DisplayNameAttribute("Distancia Registro")> _
    ReadOnly Property DsitanciaFin() As String
        Get
            Return _DistanciaFinal
        End Get
    End Property

    <Description("PK Final Obras Sobre DDV"), _
    Category("Fin Intervención"),
    DisplayNameAttribute("PK")> _
    ReadOnly Property PKFin() As String
        Get
            Return _PkFinal
        End Get
    End Property

    <Description("Horas Hombre Obras Sobre DDV"), _
    Category("Evidencia de Intervención"),
    DisplayNameAttribute("H. Hombre")> _
    ReadOnly Property HHombre() As String
        Get
            Return _HorasHombre
        End Get
    End Property

    <Description("Horas Máquina Obras Sobre DDV"), _
    Category("Evidencia de Intervención"),
    DisplayNameAttribute("H. Máquina")> _
    ReadOnly Property HMaquina() As String
        Get
            Return _HorasMaquina
        End Get
    End Property

    Public Sub New(fila As DataGridViewRow)
        _IdConsecutivo = fila.Cells("IDCONSECUTIVO").Value
        If Not IsDBNull(fila.Cells("DURACIONINTERVENCION").Value) Then
            _DuracionIntervencion = fila.Cells("DURACIONINTERVENCION").Value
        Else
            _DuracionIntervencion = ""
        End If
        If Not IsDBNull(fila.Cells("LATITUDINI_INTERV").Value) Then
            _LatitudInicial = fila.Cells("LATITUDINI_INTERV").Value
        Else
            _LatitudInicial = ""
        End If
        If Not IsDBNull(fila.Cells("LONGITUDINI_INTERV").Value) Then
            _LongitudInicial = fila.Cells("LONGITUDINI_INTERV").Value
        Else
            _LongitudInicial = ""
        End If
        If Not IsDBNull(fila.Cells("DISTANCIAREGISTROINI_INTERV").Value) Then
            _DistanciaInicial = fila.Cells("DISTANCIAREGISTROINI_INTERV").Value
        Else
            _DistanciaInicial = ""
        End If
        If Not IsDBNull(fila.Cells("PKINI_INTERV").Value) Then
            _PkInicial = fila.Cells("PKINI_INTERV").Value
        Else
            _PkInicial = ""
        End If
        If Not IsDBNull(fila.Cells("LATITUDFIN_INTERV").Value) Then
            _LatitudFinal = fila.Cells("LATITUDFIN_INTERV").Value
        Else
            _LatitudFinal = ""
        End If
        If Not IsDBNull(fila.Cells("LONGITUDFIN_INTERV").Value) Then
            _LongitudFinal = fila.Cells("LONGITUDFIN_INTERV").Value
        Else
            _LongitudFinal = ""
        End If
        If Not IsDBNull(fila.Cells("DISTANCIAREGISTROFIN_INTERV").Value) Then
            _DistanciaFinal = fila.Cells("DISTANCIAREGISTROFIN_INTERV").Value
        Else
            _DistanciaFinal = ""
        End If
        If Not IsDBNull(fila.Cells("PKFIN_INTERV").Value) Then
            _PkFinal = fila.Cells("PKFIN_INTERV").Value
        Else
            _PkFinal = ""
        End If
        If Not IsDBNull(fila.Cells("HORASHOMBRE").Value) Then
            _HorasHombre = fila.Cells("HORASHOMBRE").Value
        Else
            _HorasHombre = ""
        End If
        If Not IsDBNull(fila.Cells("HORASMAQUINA").Value) Then
            _HorasMaquina = fila.Cells("HORASMAQUINA").Value
        Else
            _HorasMaquina = ""
        End If

    End Sub
End Class 'Pro_ObrasSobreDDV


Friend Class Pro_Valvulas
    Private _IdConsecutivo As String = ""
    Private _DuracionIntervencion As String = ""
    Private _Latitud As String = ""
    Private _Longitud As String = ""
    Private _CodEquipo As String = ""
    Private _HorasHombre As String = ""
    Private _HorasMaquina As String = ""


    <Description("Identificador Del Consecutivo Válvula"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Id.")> _
    ReadOnly Property Id() As String
        Get
            Return _IdConsecutivo
        End Get
    End Property

    <Description("Duración Intervención Válvulas"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Duración Intervención")> _
    ReadOnly Property Duracion() As String
        Get
            Return _DuracionIntervencion
        End Get
    End Property

    <Description("Latitud Válvulas"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Latitud")> _
    ReadOnly Property Latitud() As String
        Get
            Return _Latitud
        End Get
    End Property

    <Description("Longitud Válvulas"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Longitud")> _
    ReadOnly Property Longitud() As String
        Get
            Return _Longitud
        End Get
    End Property

    <Description("Código Equipo Válvulas"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Cod. Equipo")> _
    ReadOnly Property CodEquipo() As String
        Get
            Return _CodEquipo
        End Get
    End Property


    <Description("Horas Hombre Válvulas"), _
    Category("Evidencia de Intervención"),
    DisplayNameAttribute("H. Hombre")> _
    ReadOnly Property HHombre() As String
        Get
            Return _HorasHombre
        End Get
    End Property

    <Description("Horas Máquina Válvulas"), _
    Category("Evidencia de Intervención"),
    DisplayNameAttribute("H. Máquina")> _
    ReadOnly Property HMaquina() As String
        Get
            Return _HorasMaquina
        End Get
    End Property

    Public Sub New(fila As DataGridViewRow)
        _IdConsecutivo = fila.Cells("IDCONSECUTIVO").Value
        If Not IsDBNull(fila.Cells("DURACIONINTERVENCION").Value) Then
            _DuracionIntervencion = fila.Cells("DURACIONINTERVENCION").Value
        Else
            _DuracionIntervencion = ""
        End If
        If Not IsDBNull(fila.Cells("LATITUD").Value) Then
            _Latitud = fila.Cells("LATITUD").Value
        Else
            _Latitud = ""
        End If
        If Not IsDBNull(fila.Cells("LONGITUD").Value) Then
            _Longitud = fila.Cells("LONGITUD").Value
        Else
            _Longitud = ""
        End If
        If Not IsDBNull(fila.Cells("CODIGOEQUIPO").Value) Then
            _CodEquipo = fila.Cells("CODIGOEQUIPO").Value
        Else
            _CodEquipo = ""
        End If
        If Not IsDBNull(fila.Cells("HORASHOMBRE").Value) Then
            _HorasHombre = fila.Cells("HORASHOMBRE").Value
        Else
            _HorasHombre = ""
        End If
        If Not IsDBNull(fila.Cells("HORASMAQUINA").Value) Then
            _HorasMaquina = fila.Cells("HORASMAQUINA").Value
        Else
            _HorasMaquina = ""
        End If

    End Sub
End Class 'Pro_Valvulas

Friend Class Pro_URPC
    Private _IdConsecutivo As String = ""
    Private _DuracionIntervencion As String = ""
    Private _Latitud As String = ""
    Private _Longitud As String = ""
    Private _CodEquipo As String = ""
    Private _HorasHombre As String = ""
    Private _HorasMaquina As String = ""


    <Description("Identificador Del Consecutivo URPC"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Id.")> _
    ReadOnly Property Id() As String
        Get
            Return _IdConsecutivo
        End Get
    End Property

    <Description("Duración Intervención URPC"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Duración Intervención")> _
    ReadOnly Property Duracion() As String
        Get
            Return _DuracionIntervencion
        End Get
    End Property

    <Description("Latitud URPC"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Latitud")> _
    ReadOnly Property Latitud() As String
        Get
            Return _Latitud
        End Get
    End Property

    <Description("Longitud URPC"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Longitud")> _
    ReadOnly Property Longitud() As String
        Get
            Return _Longitud
        End Get
    End Property

    <Description("Código Equipo URPC"), _
    Category("Datos Intervención"),
    DisplayNameAttribute("Cod. Equipo")> _
    ReadOnly Property CodEquipo() As String
        Get
            Return _CodEquipo
        End Get
    End Property


    <Description("Horas Hombre URPC"), _
    Category("Evidencia de Intervención"),
    DisplayNameAttribute("H. Hombre")> _
    ReadOnly Property HHombre() As String
        Get
            Return _HorasHombre
        End Get
    End Property

    <Description("Horas Máquina URPC"), _
    Category("Evidencia de Intervención"),
    DisplayNameAttribute("H. Máquina")> _
    ReadOnly Property HMaquina() As String
        Get
            Return _HorasMaquina
        End Get
    End Property

    Public Sub New(fila As DataGridViewRow)
        _IdConsecutivo = fila.Cells("IDCONSECUTIVO").Value
        If Not IsDBNull(fila.Cells("DURACIONINTERVENCION").Value) Then
            _DuracionIntervencion = fila.Cells("DURACIONINTERVENCION").Value
        Else
            _DuracionIntervencion = ""
        End If
        If Not IsDBNull(fila.Cells("LATITUD").Value) Then
            _Latitud = fila.Cells("LATITUD").Value
        Else
            _Latitud = ""
        End If
        If Not IsDBNull(fila.Cells("LONGITUD").Value) Then
            _Longitud = fila.Cells("LONGITUD").Value
        Else
            _Longitud = ""
        End If
        If Not IsDBNull(fila.Cells("CODIGOEQUIPO").Value) Then
            _CodEquipo = fila.Cells("CODIGOEQUIPO").Value
        Else
            _CodEquipo = ""
        End If
        If Not IsDBNull(fila.Cells("HORASHOMBRE").Value) Then
            _HorasHombre = fila.Cells("HORASHOMBRE").Value
        Else
            _HorasHombre = ""
        End If
        If Not IsDBNull(fila.Cells("HORASMAQUINA").Value) Then
            _HorasMaquina = fila.Cells("HORASMAQUINA").Value
        Else
            _HorasMaquina = ""
        End If

    End Sub
End Class 'Pro_URPC


Friend Class Pro_TableroTBG
    Private _IdTableroTBG As String = ""
    Private _Base As String = ""
    Private _NombreArchivo As String = ""
    Private _FechaMedicion As String = ""
    Private _NombrePeriodo As String = ""
    Private _FechaPresentacion As String = ""
    Private _FechaRegistro As String = ""
    Private _UsuarioRegistra As String = ""
    Private _FechaModificacion As String = ""
    Private _UsuarioModifica As String = ""

    <Description("Identificador del registro de No Conformidad"), _
    Category(""),
    DisplayNameAttribute("Id.")> _
    ReadOnly Property Id() As String
        Get
            Return _IdTableroTBG
        End Get
    End Property

    <Description("Base"), _
    Category(""),
    DisplayNameAttribute("Base")> _
    ReadOnly Property Base() As String
        Get
            Return _Base
        End Get
    End Property

    <Description("Nombre del archivo"), _
    Category("Archivo"),
    DisplayNameAttribute("Nombre Archivo")> _
    ReadOnly Property NombreArchivo() As String
        Get
            Return _NombreArchivo
        End Get
    End Property

    <Description("Fecha de medición"), _
    Category("Medición"),
    DisplayNameAttribute("Fecha Medición")> _
    ReadOnly Property FechaMedicion() As String
        Get
            Return _FechaMedicion
        End Get
    End Property

    <Description("Periodo de medición"), _
    Category("Medición"),
    DisplayNameAttribute("Periodo Medición")> _
    ReadOnly Property NombrePeriodo() As String
        Get
            Return _NombrePeriodo
        End Get
    End Property

    <Description("Fecha de presentación"), _
    Category("Presentación"),
    DisplayNameAttribute("Fecha Presentación")> _
    ReadOnly Property FechaPresentacion() As String
        Get
            Return _FechaPresentacion
        End Get
    End Property

    <Description("Fecha de registro"), _
    Category("Registro"),
    DisplayNameAttribute("Fecha Registro")> _
    ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Nombre del usuario que registró"), _
    Category("Registro"),
    DisplayNameAttribute("Usuario Registra")> _
    ReadOnly Property UsuarioRegistra() As String
        Get
            Return _UsuarioRegistra
        End Get
    End Property

    <Description("Última fecha de modificación"), _
    Category("Modificación"),
    DisplayNameAttribute("Fecha Modificación")> _
    ReadOnly Property FechaModificacion() As String
        Get
            Return _FechaModificacion
        End Get
    End Property

    <Description("Nombre del usuario que modificó"), _
    Category("Modificación"),
    DisplayNameAttribute("Usuario Modifica")> _
    ReadOnly Property UsuarioModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property


    Public Sub New(fila As DataGridViewRow)
        _IdTableroTBG = fila.Cells("IDTABLEROTBG").Value
        If Not IsDBNull(fila.Cells("NOMBREARCHIVO").Value) Then
            _NombreArchivo = fila.Cells("NOMBREARCHIVO").Value
        Else
            _NombreArchivo = ""
        End If
        If Not IsDBNull(fila.Cells("FECHAMEDICION").Value) Then
            _FechaMedicion = fila.Cells("FECHAMEDICION").Value
        Else
            _FechaMedicion = ""
        End If
        If Not IsDBNull(fila.Cells("NOMBREPERIODO").Value) Then
            _NombrePeriodo = fila.Cells("NOMBREPERIODO").Value
        Else
            _NombrePeriodo = ""
        End If
        If Not IsDBNull(fila.Cells("FECHAPRESENTACION").Value) Then
            _FechaPresentacion = fila.Cells("FECHAPRESENTACION").Value
        Else
            _FechaPresentacion = ""
        End If
        If Not IsDBNull(fila.Cells("FECHAREGISTRO").Value) Then
            _FechaRegistro = fila.Cells("FECHAREGISTRO").Value
        Else
            _FechaRegistro = ""
        End If
        If Not IsDBNull(fila.Cells("USUARIOREGISTRA").Value) Then
            _UsuarioRegistra = fila.Cells("USUARIOREGISTRA").Value
        Else
            _UsuarioRegistra = ""
        End If
        If Not IsDBNull(fila.Cells("FECHAMODIFICACION").Value) Then
            _FechaModificacion = fila.Cells("FECHAMODIFICACION").Value
        Else
            _FechaModificacion = ""
        End If
        If Not IsDBNull(fila.Cells("USUARIOMODIFICA").Value) Then
            _UsuarioModifica = fila.Cells("USUARIOMODIFICA").Value
        Else
            _UsuarioModifica = ""
        End If
    End Sub
End Class 'Pro_TableroTBG

Class Pro_PlanOptimizacion
    Private _idPlanOptimizacion As String = ""
    Private _base As String = ""
    Private _titulo As String = ""
    Private _propositoMejora As String = ""
    Private _nombreArchivoOptimizacion As String = ""
    Private _fechaRegistro As String = ""
    Private _usuarioRegistra As String = ""
    Private _fechaModificacion As String = ""
    Private _usuarioModifica As String = ""

    <Description("Identificador de Plan de Optimización"), _
    Category("Datos"),
    DisplayNameAttribute("Id.")> _
    ReadOnly Property IdPlanOptimizacion() As String
        Get
            Return _idPlanOptimizacion
        End Get
    End Property

    <Description("Base en que se realizó el registro"), _
    Category("Datos"),
    DisplayNameAttribute("Base")> _
    ReadOnly Property Base() As String
        Get
            Return _base
        End Get
    End Property

    <Description("Título"), _
    Category("Datos"),
    DisplayNameAttribute("Título")> _
    ReadOnly Property Titulo() As String
        Get
            Return _titulo
        End Get
    End Property

    <Description("Propósito de la mejora"), _
    Category("Datos"),
    DisplayNameAttribute("Propósito Mejora")> _
    ReadOnly Property PropositoMejora() As String
        Get
            Return _propositoMejora
        End Get
    End Property

    <Description("Nombre del archivo de optimización"), _
    Category("Datos"),
    DisplayNameAttribute("Archivo Optimización")> _
    ReadOnly Property NombreArchivoOptimizacion() As String
        Get
            Return _nombreArchivoOptimizacion
        End Get
    End Property

    <Description("Fecha de registro"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Registro")> _
    ReadOnly Property FechaRegistro() As String
        Get
            Return _fechaRegistro
        End Get
    End Property

    <Description("Nombre del usuario que registró"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Registra")> _
    ReadOnly Property UsuarioRegistra() As String
        Get
            Return _usuarioRegistra
        End Get
    End Property

    <Description("Fecha de última modificación"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Modificación")> _
    ReadOnly Property FechaModificacion() As String
        Get
            Return _fechaModificacion
        End Get
    End Property

    <Description("Nombre del usuario que modificó"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Modifica")> _
    ReadOnly Property UsuarioModifica() As String
        Get
            Return _usuarioModifica
        End Get
    End Property

    Public Sub New(fila As DataGridViewRow)
        _idPlanOptimizacion = fila.Cells("IDPLANOPTIMIZACION").Value
        If Not IsDBNull(fila.Cells("BASE").Value) Then
            _base = fila.Cells("BASE").Value
        Else
            _base = ""
        End If
        If Not IsDBNull(fila.Cells("TITULO").Value) Then
            _titulo = fila.Cells("TITULO").Value
        Else
            _titulo = ""
        End If
        If Not IsDBNull(fila.Cells("PROPOSITOMEJORA").Value) Then
            _propositoMejora = fila.Cells("PROPOSITOMEJORA").Value
        Else
            _propositoMejora = ""
        End If
        If Not IsDBNull(fila.Cells("NOMBREARCHIVOOPTIMIZACION").Value) Then
            _nombreArchivoOptimizacion = fila.Cells("NOMBREARCHIVOOPTIMIZACION").Value
        Else
            _nombreArchivoOptimizacion = ""
        End If
        If Not IsDBNull(fila.Cells("FECHAREGISTRO").Value) Then
            _fechaRegistro = fila.Cells("FECHAREGISTRO").Value
        Else
            _fechaRegistro = ""
        End If
        If Not IsDBNull(fila.Cells("USUARIOREGISTRA").Value) Then
            _usuarioRegistra = fila.Cells("USUARIOREGISTRA").Value
        Else
            _usuarioRegistra = ""
        End If
        If Not IsDBNull(fila.Cells("FECHAMODIFICACION").Value) Then
            _fechaModificacion = fila.Cells("FECHAMODIFICACION").Value
        Else
            _fechaModificacion = ""
        End If
        If Not IsDBNull(fila.Cells("USUARIOMODIFICA").Value) Then
            _usuarioModifica = fila.Cells("USUARIOMODIFICA").Value
        Else
            _usuarioModifica = ""
        End If
    End Sub
End Class 'Pro_PlanOptimizacion