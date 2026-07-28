Imports System.Data.SqlClient

Public Class Busquedas
    Public datas As New DataSet
    Public cmde As New SqlCommand
    Public da As New SqlDataAdapter
    Public TablaBusqueda As New DataTable

    Public Function BusquedaCondiciones(Procedimiento As Integer, Campo As String, Tipo As Integer, Condicion As Integer,
                                        ValorStr As String, ValorNum As Double, ValorDate As Date, ValorDate2 As Date,
                                        AccionEspecial As Integer, TOP_VALORES As Integer)


        'declaro la cadena de conexión
        Dim sqlconeccion As New SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            Select Case Procedimiento
                'SisControl
                Case 1 'Recepción
                    cmde.CommandText = "dbo.ListarSiscontrolRecepción"
                Case 2 'Correspondencia Externa
                    cmde.CommandText = "dbo.ListarSiscontrolCorresExt"
                Case 3 'Correspondencia Interna
                    cmde.CommandText = "dbo.ListarSiscontrolCorresInt"
                Case 4 'Fax
                    cmde.CommandText = "dbo.ListarSiscontrolFax"
                Case 5 'Gerencia
                    cmde.CommandText = "dbo.ListarSiscontrolGerencia"
                Case 6 'Órdenes de Servicio
                    cmde.CommandText = "dbo.ListarSiscontrolOrdenes"
                Case 7 'Cobro
                    cmde.CommandText = "dbo.ListarSiscontrolCobro"
                Case 8 'Sobres
                    cmde.CommandText = "dbo.ListarSiscontrolSobres"
                Case 9 'Visitantes
                    cmde.CommandText = "dbo.ListarSiscontrolVisitantes"

                    'Compras
                Case 10 'Requisiciones
                    cmde.CommandText = "dbo.ListarComprasReq"
                Case 11 'Órdenes de Compra
                    cmde.CommandText = "dbo.ListarComprasOrdenes"
                Case 12 'Proveedores
                    cmde.CommandText = "dbo.ListarComprasProveedores"

                    'Bodega
                Case 13 'Entradas de Almacén
                    cmde.CommandText = "dbo.ListaBodegaEntrada"
                Case 14 'Traslados de Bodega
                    cmde.CommandText = "dbo.ListarBodegaTraslados"
                Case 15 'Salidas de Almacén
                    cmde.CommandText = "dbo.ListaBodegaSalidas"

                    'Activos Fijos
                Case 16 'Activos Fijos
                    cmde.CommandText = "dbo.ListarActivosFijosEquipos"
                Case 17 'Mantenimientos Externos
                    cmde.CommandText = "dbo.ListarRevisionesExternas"

                    'Personal
                Case 18 'Terceros
                    cmde.CommandText = "dbo.ListaTerceros"

                    'Materiales Especiales
                Case 19 'Isométricos
                    cmde.CommandText = "dbo.ListarMTE_Isometrico"
                Case 20 'Spools
                    cmde.CommandText = "dbo.ListarMTE_Spool"
                Case 21 'Planos
                    cmde.CommandText = "dbo.ListarMTE_Plano"
                Case 22 'Típicos
                    cmde.CommandText = "dbo.ListarMTE_Tipico"
                Case 23 'Carretes de Cable
                    cmde.CommandText = "dbo.ListarMTE_Carrete"
                Case 24 'Entradas
                    cmde.CommandText = "dbo.ListarMTE_Entrada"
                Case 25 'Salidas
                    cmde.CommandText = "dbo.ListarMTE_Salida"

                    'Licitaciones
                Case 26 'Licitaciones
                    cmde.CommandText = "dbo.ListarLIC_Licitacion"
                Case 27 'Ítems APU
                    cmde.CommandText = "dbo.ListarLIC_APU"
                Case 28 'Materiales
                    cmde.CommandText = "dbo.ListarLIC_Material"
                Case 29 'Maquinaria y Equipo
                    cmde.CommandText = "dbo.ListarLIC_MaquinariaYEquipo"
                Case 30 'Mano de obra
                    cmde.CommandText = "dbo.ListarLIC_ManoDeObra"

                    'SisControl
                Case 31 'Aprobaciones de Facturación Electrónica
                    cmde.CommandText = "dbo.ListarSC_FE_Aprobacion"
                Case 32 'Rechazos de Aprobaciones de Facturación Electrónica
                    cmde.CommandText = "dbo.ListarSC_FE_Rechazo"

                    'Contrato
                Case 33 'Contratos
                    cmde.CommandText = "dbo.ListarContratos"

                    'Reporte Diario
                Case 34 'Reportes
                    cmde.CommandText = "dbo.ListarReportesDiarios"

                    'Órdenes de Trabajo
                Case 35 'Órdenes de Trabajo
                    cmde.CommandText = "dbo.ListarOT_OrdenTrabajo"

                    'Administración de Usuario
                Case 36 'Usuarios
                    cmde.CommandText = "dbo._ListaUsuarios"

                    'Personal
                Case 37 'Envíos a Exámenes Preocupacionales
                    cmde.CommandText = "dbo.ListarEnvioExamenes"

                    'Órdenes de Trabajo
                Case 38 'Cuadrillas
                    cmde.CommandText = "dbo.ListarCuadrillas"

                    'Personal
                Case 39 'Calificaciones
                    cmde.CommandText = "dbo.ListaCalificaciones"

                    'Auditoria
                Case 40 'Legalizaciones
                    cmde.CommandText = "dbo.ListarLegalizaciones"

                    'Bodega
                Case 41 'Bodegas
                    cmde.CommandText = "dbo.ListarBodegas"

                    'Personal
                Case 42 'Encuestas
                    cmde.CommandText = "dbo.ListarEncuestas"

                    'Órdenes de Trabajo
                Case 43 'Material No Conforme
                    cmde.CommandText = "dbo.ListarNC_MaterialNoConforme"

                    'Órdenes de Trabajo
                Case 44 'No Conformidad
                    cmde.CommandText = "dbo.ListarNC_NoConformidad"

                    'Órdenes de Trabajo
                Case 45 'Intervencion Directa
                    cmde.CommandText = "dbo.ListarID_IntervencionDirecta"

                    'Órdenes de Trabajo
                Case 46 'Obras Sobre DDV
                    cmde.CommandText = "dbo.ListarObrasSobreDDV"

                    'Órdenes de Trabajo
                Case 47 'Válvulas
                    cmde.CommandText = "dbo.ListarValvulas"

                    'Órdenes de Trabajo
                Case 48 'URPC
                    cmde.CommandText = "dbo.ListarURPC"

                    'Órdenes de Trabajo
                Case 49 'URPC
                    cmde.CommandText = "dbo.ListarCAL_DefectologiaXSoldador"

                    'Órdenes de Trabajo
                Case 50 'Tableros TBG
                    cmde.CommandText = "dbo.ListarTBG_Tablero"

                    'Órdenes de Trabajo
                Case 51 'Plan de Optimización
                    cmde.CommandText = "dbo.ListarPDO_PlanOptimizacion"

                    'SisControl
                Case 52 'Documento Equivalente
                    cmde.CommandText = "dbo.ListarSiscontrolDocumento"

                    'Personal
                Case 53 'Evaluación Desempeño
                    cmde.CommandText = "dbo.ListarEvaluacionDesempeño"

                    'SisControl
                Case 54 'Contratistas
                    cmde.CommandText = "dbo.ListarSiscontrolContratista"

                    'HSE
                Case 55 'Reportes 24 horas
                    cmde.CommandText = "dbo.ListarReportes24H"

                Case 56 'Reportes Investigacion
                    cmde.CommandText = "dbo.ListarReportesInvestigacion"

                Case 57 'Resumen Estadistico
                    cmde.CommandText = "dbo.ListarResumenEstadistico"

                Case 58 'Examenes Medicos Periodicos
                    cmde.CommandText = "dbo.ListarExamenesMedicos"

                Case 59 'Contratos
                    cmde.CommandText = "dbo.ListarSiscontrolContratos"

                Case Else
                    MsgBox("Procedimiento no encontrado")
                    BusquedaCondiciones = Nothing
                    Exit Function
            End Select

            Dim WHERE As String
            WHERE = " AND " + Campo
            Select Case Tipo
                Case 1 'texto
                    Select Case Condicion
                        Case 1
                            WHERE += " LIKE '%" + ValorStr.Trim + "%' "
                        Case 2
                            WHERE += " = '" + ValorStr.Trim + "' "
                        Case 3
                            WHERE += " NOT LIKE '%" + ValorStr.Trim + "%' "
                    End Select
                Case 2 'número
                    Select Case Condicion
                        Case 1
                            WHERE += " = '" + ValorNum.ToString + "'"
                        Case 2
                            WHERE += " > '" + ValorNum.ToString + "'"
                        Case 3
                            WHERE += " < '" + ValorNum.ToString + "'"
                        Case 4
                            WHERE += " <> '" + ValorNum.ToString + "'"
                    End Select
                Case 3 'fecha
                    Select Case Procedimiento
                        Case 34, 33, 38, 39, 40, 52, 53
                            Select Case Condicion
                                Case 1
                                    WHERE += " = '" + ValorDate.ToShortDateString + "' "
                                Case 2
                                    WHERE += " > '" + ValorDate.ToShortDateString + "' "
                                Case 3
                                    WHERE += " < '" + ValorDate.ToShortDateString + "' "
                                Case 4
                                    WHERE = " AND (" + Campo + " < '" + ValorDate.ToShortDateString + "' OR " + Campo + " > '" + ValorDate.ToShortDateString + " ') "
                                Case 5
                                    WHERE = " AND (" + Campo + " >= '" + ValorDate.ToShortDateString + " ' AND " + Campo + " <= '" + ValorDate2.ToShortDateString + " ') "
                            End Select
                        Case Else
                            Select Case Condicion
                                Case 1
                                    WHERE += " >= '" + ValorDate.ToShortDateString + " 00:00:00.000' AND " + Campo + " < '" + ValorDate.ToShortDateString + " 23:59:59.997' "
                                Case 2
                                    WHERE += " > '" + ValorDate.ToShortDateString + " 00:00:00.000' "
                                Case 3
                                    WHERE += " < '" + ValorDate.ToShortDateString + " 23:59:59.997' "
                                Case 4
                                    WHERE = " AND (" + Campo + " < '" + ValorDate.ToShortDateString + " 00:00:00.000' OR " + Campo + " > '" + ValorDate.ToShortDateString + " 23:59:59.997') "
                                Case 5
                                    WHERE = " AND (" + Campo + " >= '" + ValorDate.ToShortDateString + " 00:00:00.000' AND " + Campo + " <= '" + ValorDate2.ToShortDateString + " 23:59:59.997') "
                            End Select
                    End Select
                    
                Case 4, 5 'consultas especiales
                    'agregar parámetro de acción especial
                    WHERE = ""
                Case 6 'Consultar proveedor por ciudad
                    WHERE += " = " + ValorStr.Trim + " "
                Case 7 'Consulta por desglose de parágrafo, separando por palabras (máximo 5)
                    WHERE = Trim(ValorStr)
            End Select

            cmde.Parameters.Add("@WHERE", SqlDbType.VarChar, 300).Value = WHERE

            Select Case Procedimiento
                Case 1
                    cmde.Parameters.Add("@Top", SqlDbType.Int).Value = TOP_VALORES
                    cmde.Parameters.Add("@IdBase", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.Int).Value = AccionEspecial
                Case 2, 3, 4, 7
                    cmde.Parameters.Add("@TOP", SqlDbType.Int).Value = TOP_VALORES
                    cmde.Parameters.Add("@IDBASE", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                Case 5, 6, 8, 9
                    cmde.Parameters.Add("@IDBASE", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                Case 10, 11, 12
                    cmde.Parameters.Add("@IDpersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
                    cmde.Parameters.Add("@IDbodegaActual", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBodegaActual
                    cmde.Parameters.Add("@TOP", SqlDbType.Int).Value = TOP_VALORES
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.Int).Value = AccionEspecial
                    cmde.Parameters.Add("@IDArticulo", SqlDbType.Int).Value = ValorNum
                Case 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    cmde.Parameters.Add("@IDpersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
                    cmde.Parameters.Add("@IDbodegaActual", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBodegaActual
                    cmde.Parameters.Add("@TOP", SqlDbType.Int).Value = TOP_VALORES
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.Int).Value = AccionEspecial
                Case 26, 28, 29, 30, 40, 55, 56, 57, 58
                    cmde.Parameters.Add("@IdPersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.Int).Value = AccionEspecial
                    cmde.Parameters.Add("@TOP", SqlDbType.Int).Value = TOP_VALORES
                Case 27
                    cmde.Parameters.Add("@IdPersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.Int).Value = AccionEspecial
                    cmde.Parameters.Add("@TOP", SqlDbType.Int).Value = TOP_VALORES
                    cmde.Parameters.Add("@IdLicitacion", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdLicitacionCargada
                Case 31, 32
                    cmde.Parameters.Add("@IdPersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.Int).Value = AccionEspecial
                    cmde.Parameters.Add("@TOP", SqlDbType.Int).Value = TOP_VALORES
                    cmde.Parameters.Add("@IDEMPRESA", SqlDbType.TinyInt).Value = VariablesBase.VariablesBase.EmpresaSisControlActual
                Case 33, 34
                    cmde.Parameters.Add("@IDpersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
                    cmde.Parameters.Add("@IDBASE", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                    cmde.Parameters.Add("@TOP", SqlDbType.Int).Value = TOP_VALORES
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.Int).Value = AccionEspecial
                Case 35
                    cmde.Parameters.Add("@IDpersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
                    cmde.Parameters.Add("@IDBASE", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                    cmde.Parameters.Add("@TOP", SqlDbType.Int).Value = TOP_VALORES
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.Int).Value = AccionEspecial
                    cmde.Parameters.AddWithValue("@TABLA", TablaBusqueda)
                Case 36, 39, 53, 54
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.Int).Value = AccionEspecial
                    cmde.Parameters.Add("@TOP", SqlDbType.Int).Value = TOP_VALORES
                Case 37, 38, 42
                    cmde.Parameters.Add("@IdPersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
                    cmde.Parameters.Add("@IdBase", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.Int).Value = AccionEspecial
                    cmde.Parameters.Add("@TOP", SqlDbType.Int).Value = TOP_VALORES
                Case 41
                    cmde.Parameters.Add("@IdPersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.Int).Value = AccionEspecial
                    cmde.Parameters.Add("@Top", SqlDbType.Int).Value = TOP_VALORES
                Case 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 59
                    cmde.Parameters.Add("@IdBase", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual
                    cmde.Parameters.Add("@AccionEspecial", SqlDbType.TinyInt).Value = AccionEspecial
                    cmde.Parameters.Add("@Top", SqlDbType.Int).Value = TOP_VALORES
            End Select

            da = New SqlDataAdapter(cmde)
            datas = New DataSet()
            da.Fill(datas)
            sqlconeccion.Close()
            Return datas
        Catch ex As Exception
            MsgBox("Valor inválido, por favor corregirlo e ingresarlo de nuevo.")
            BusquedaCondiciones = Nothing
        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()
        End Try
    End Function

    Public Sub New()
        TablaBusqueda.Columns.Add("CODIGO", System.Type.GetType("System.Int32"))
    End Sub

End Class