Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
Imports System.IO
Imports System.Net.Mail
Imports System.Drawing
Imports System.Text
Imports FormulariosSisControl
Imports Microsoft.Office.Interop

Public Class Cu_SisControl
    Private TablaCarga As String = ""
    Private bddatos As New DatosClasesBase.Busquedas
    Private ValorFiltro As String
    Private nombrecolumna As String
    Private bddatos1 As New FuncionesBase.ClaseCargarMaestras
    Private Index_Registro_Actual As Integer = -1
    Private RespuestaFr_Aceptada As Integer
    Private dsDocumento As New DataSet
    Private dsContratos As New DataSet
    Dim dsContratistas As New DataSet
    Dim GoogleDrive As New FuncionesGoogle.FuncionesGoogle
    Dim nombrearchivo As String = ""
    Public Sub Cargar_Tabla()
        If VariablesBase.VariablesBase.IdBaseSiscontrolActual = 0 Then
            CargarTablaxDefectoPendientes()
        Else
            CargarTablaxDefectoExterna()
        End If

        Comportamiento_Predeterminado()
    End Sub

    Public Sub Comportamiento_Predeterminado()
        Me.Nbc_SisControl.ActiveGroup = Me.Nbg_CorreExterna
        Me.DGV_ListaSisControl.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.DGV_ListaSisControl.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Detalle.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Detalle.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Nbg_CorreExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_CorreExterna.Tag)
        Nbg_CorreInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_CorreInterna.Tag)
        Nbg_Fax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Fax.Tag)
        Nbg_Ordenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Ordenes.Tag)
        Nbg_Cobro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Cobro.Tag)
        Nbg_Sobres.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Sobres.Tag)
        Nbg_Recepcion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Recepcion.Tag)
        Nbg_Visitantes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Visitantes.Tag)
        Nbg_OpcionesArchivos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_OpcionesArchivos.Tag)

        'Opciones Archivos
        Nbi_EnviarCorreosFaltantes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EnviarCorreosFaltantes.Tag)
        Nbi_GestionarUsuarioCorrespondenciaPendiente.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_GestionarUsuarioCorrespondenciaPendiente.Tag)

        'Órdenes de Servicio
        Nbi_CargarOrdenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarOrdenes.Tag)
        Nbi_CrearOrdenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearOrdenes.Tag)
        Nbi_CierreOrden.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CierreOrden.Tag)
        Nbi_EditarOrden.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarOrden.Tag)
        Nbi_VerOrdenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerOrdenes.Tag)
        Nbi_AnularOrdenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularOrdenes.Tag)
        Nbi_BuscarOrdenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarOrdenes.Tag)
        Nbi_ExportarOrden.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ExportarOrden.Tag)
        Nbi_ListadoOrdenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListadoOrdenes.Tag)
        Nbi_ImprimirOrden.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirOrden.Tag)
        Nbi_ImprimirCierre.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirCierre.Tag)
        Nbi_ClonarOrdenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarOrdenes.Tag)
        Nbi_HabilitarOrden.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HabilitarOrden.Tag)
        Nbi_ConsecutivoOrdenes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ConsecutivoOrdenes.Tag)
        Nbi_RegistrarFactura.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarFactura.Tag)
        Nbi_EnviarCorreoPenOS.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EnviarCorreoPenOS.Tag)
        Nbi_SubirPDFOS.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPDFOS.Tag)
        Nbi_VerPDFOS.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPDFOS.Tag)
        Nbi_HistorialArchivosPdfOS.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialArchivosPdfOS.Tag)

        'Correspondencia Externa
        Nbi_CargarCorrExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarCorrExterna.Tag)
        Nbi_CrearCorrExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearCorrExterna.Tag)
        Nbi_EditarCorrExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarCorrExterna.Tag)
        Nbi_VerCorrExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerCorrExterna.Tag)
        Nbi_AnularCorrExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularCorrExterna.Tag)
        Nbi_BuscarCorreExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarCorreExterna.Tag)
        Nbi_ExportarExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ExportarExterna.Tag)
        Nbi_ListadoCorreExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListadoCorreExterna.Tag)
        Nbi_ClonarExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarExterna.Tag)
        Nbi_ConsecutivoExterno.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ConsecutivoExterno.Tag)
        Nbi_SubirPdfCorrespondenciaExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfCorrespondenciaExterna.Tag)
        Nbi_VerPdfCorrespondenciaExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPdfCorrespondenciaExterna.Tag)
        Nbi_SubirPdfCorrespondenciaExBloque.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfCorrespondenciaExBloque.Tag)
        Nbi_MarcarRecibidoArchivoCentralCE.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_MarcarRecibidoArchivoCentralCE.Tag)
        Nbi_MarcarRevisadoServidorCE.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_MarcarRevisadoServidorCE.Tag)
        Nbi_HistorialArchivosPdfCE.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialArchivosPdfCE.Tag)

        'Correspondencia Interna
        Nbi_CargarCorrInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarCorrInterna.Tag)
        Nbi_CrearCorrInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearCorrInterna.Tag)
        Nbi_EditarCorrInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarCorrInterna.Tag)
        Nbi_VerCorrInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerCorrInterna.Tag)
        Nbi_AnularCorrInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularCorrInterna.Tag)
        Nbi_BuscarCorreInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarCorreInterna.Tag)
        Nbi_ExportarInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ExportarInterna.Tag)
        Nbi_ListadoCorreInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListadoCorreInterna.Tag)
        Nbi_ClonarInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarInterna.Tag)
        Nbi_ConsecuticoI.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ConsecuticoI.Tag)
        Nbi_SubirPdfCorrespondenciaInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfCorrespondenciaInterna.Tag)
        Nbi_VerPdfCorrespondenciaInterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPdfCorrespondenciaInterna.Tag)
        Nbi_SubirPdfCorrespondenciaInBloque.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfCorrespondenciaInBloque.Tag)
        Nbi_MarcarRecibidoArchivoCentralCI.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_MarcarRecibidoArchivoCentralCI.Tag)
        Nbi_MarcarRevisadoServidorCI.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_MarcarRevisadoServidorCI.Tag)
        Nbi_HistorialArchivosPdfCI.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialArchivosPdfCI.Tag)

        'Fax
        Nbi_CargarFax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarFax.Tag)
        Nbi_CrearFax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearFax.Tag)
        Nbi_EditarFax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarFax.Tag)
        Nbi_VerFáx.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerFáx.Tag)
        Nbi_AnularFax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularFax.Tag)
        Nbi_BuscarFax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarFax.Tag)
        Nbi_ExportarFax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ExportarFax.Tag)
        Nbi_ListaFax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListaFax.Tag)
        Nbi_ClonarFax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarFax.Tag)
        Nbi_ConsecutivoF.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ConsecutivoF.Tag)
        Nbi_SubirPdfFax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfFax.Tag)
        Nbi_VerPdfFax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPdfFax.Tag)
        Nbi_SubirPdfFaxBloque.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfFaxBloque.Tag)
        Nbi_HistorialArchivosPdfFax.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialArchivosPdfFax.Tag)

        'Cuentas de Cobro
        Nbi_CargarCobro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarCobro.Tag)
        Nbi_CrearCobro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearCobro.Tag)
        Nbi_EditarCobro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarCobro.Tag)
        Nbi_VerCobro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerCobro.Tag)
        Nbi_AnularCobro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularCobro.Tag)
        Nbi_BuscarCobro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarCobro.Tag)
        Nbi_ExportarCobro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ExportarCobro.Tag)
        Nbi_ListaCobro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListaCobro.Tag)
        Nbi_ClonarCobro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarCobro.Tag)
        Nbi_consecutivoCobro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_consecutivoCobro.Tag)

        'Sobres
        Nbi_CargarSobres.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarSobres.Tag)
        Nbi_CrearSobre.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearSobre.Tag)
        Nbi_EditarSobre.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarSobre.Tag)
        Nbi_VerSobre.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerSobre.Tag)
        Nbi_AnularSobre.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularSobre.Tag)
        Nbi_BuscarSobre.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarSobre.Tag)
        Nbi_ExportarSobres.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ExportarSobres.Tag)
        Nbi_ListaSobre.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListaSobre.Tag)
        Nbi_ImprimirSobre.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirSobre.Tag)
        Nbi_ClonarSobre.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarSobre.Tag)

        'Recepción
        Nbi_CargarRecepcion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarRecepcion.Tag)
        Nbi_CrearRecepcion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearRecepcion.Tag)
        Nbi_EditarRecepcion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarRecepcion.Tag)
        Nbi_VerRecepcion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerRecepcion.Tag)
        Nbi_AnularRecepcion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularRecepcion.Tag)
        Nbi_BuscarRecepcion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarRecepcion.Tag)
        Nbi_ExportarTablaRecepcion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ExportarTablaRecepcion.Tag)
        Nbi_ListaRecepcion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListaRecepcion.Tag)
        Nbi_ClonarRecepcion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarRecepcion.Tag)
        Nbi_RadicaFacturasContabilidad.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RadicaFacturasContabilidad.Tag)
        Nbi_HabilitarImpresionRecepcion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HabilitarImpresionRecepcion.Tag)
        Nbi_GenerarStickers.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_GenerarStickers.Tag)
        Nbi_ImprimirStickers.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirStickers.Tag)
        Nbi_RecibirStickers.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RecibirStickers.Tag)
        Nbi_EnviarDocsDependencias.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EnviarDocsDependencias.Tag)
        Nbi_DevolverCorrespondenciaAlProveedor.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_DevolverCorrespondenciaAlProveedor.Tag)

        'Visitantes
        Nbi_CargarVisitantes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarVisitantes.Tag)
        Ngi_CrearVisitante.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Ngi_CrearVisitante.Tag)
        Nbi_EditarVisitante.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarVisitante.Tag)
        Nbi_VerVisitante.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerVisitante.Tag)
        Nbi_AnularVisitante.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularVisitante.Tag)
        Nbi_BuscarVisitante.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarVisitante.Tag)
        Nbi_ExportarVisitante.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ExportarVisitante.Tag)
        Nbi_ListaVisitante.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListaVisitante.Tag)
        Nbi_ClonarVisitante.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarVisitante.Tag)
        Nbi_RegistrarSalida.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarSalida.Tag)
        Nbi_ImprimirPolDatos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirPolDatos.Tag)
        Nbi_ImprimirStickerVisita.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirStickerVisita.Tag)

        'Facturación Electrónica
        Nbg_FacturacionElectronica.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_FacturacionElectronica.Tag)
        Nbi_ListarAprobaciones.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ListarAprobaciones.Tag)
        Nbi_RegistrarAprobacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarAprobacion.Tag)
        Nbi_VerAprobacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerAprobacion.Tag)
        Nbi_EditarAprobacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarAprobacion.Tag)
        Nbi_AnularAprobacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularAprobacion.Tag)
        Nbi_BuscarAprobacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarAprobacion.Tag)
        Nbi_RegistrarAceptacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarAceptacion.Tag)
        Nbi_RegistrarRechazo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarRechazo.Tag)
        Nbi_SubirArchivosFE.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirArchivosFE.Tag)
        Nbi_CorreosAprobPendxFE.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CorreosAprobPendxFE.Tag)

        'Documento Soporte
        Nbg_Documento.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Documento.Tag)
        Nbi_CargarDocumento.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarDocumento.Tag)
        Nbi_CrearDocumento.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearDocumento.Tag)
        Nbi_EditarDocumento.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarDocumento.Tag)
        Nbi_VerDocumento.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerDocumento.Tag)
        Nbi_AnularDocumento.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularDocumento.Tag)
        Nbi_BuscarDocumento.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarDocumento.Tag)
        nbi_ExportarBusquedaDocumento.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(nbi_ExportarBusquedaDocumento.Tag)
        Nbi_ClonarDocumento.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarDocumento.Tag)
        Nbi_Imprimir.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Imprimir.Tag)
        Nbi_Aprobar.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Aprobar.Tag)
        Nbi_HabilitarImpresion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HabilitarImpresion.Tag)
        Nbi_SubirPDFDS.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPDFDS.Tag)
        Nbi_VerPDFDS.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPDFDS.Tag)
        Nbi_HistorialArchivosPdfDO.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialArchivosPdfDO.Tag)

        'Contratistas
        Nbg_Contratistas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Contratistas.Tag)
        Nbi_CargarContratistas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarContratistas.Tag)
        Nbi_CrearContratista.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearContratista.Tag)
        Nbi_VerContratista.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerContratista.Tag)
        Nbi_EditarContratista.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarContratista.Tag)
        Nbi_BuscarContratista.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarContratista.Tag)

        'Contratos
        Nbg_Contratos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Contratos.Tag)
        Nbi_CargarContratos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarContratos.Tag)
        Nbi_CrearContratos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearContratos.Tag)
        Nbi_VerContratos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerContratos.Tag)
        Nbi_EditarContratos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarContratos.Tag)
        Nbi_BuscarContratos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarContratos.Tag)
        Nbi_SubirPDF.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPDF.Tag)
        Nbi_VerPDF.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPDF.Tag)
        Nbi_Anular.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Anular.Tag)
        Nbi_HistorialArchivosPdfCO.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialArchivosPdfCO.Tag)


        OcultarPanelMiniatura()
        OcultarPanelDetalle()
    End Sub

    Private Sub DGV_ListaSisControl_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV_ListaSisControl.SelectionChanged
        CargarListaxSeleccion()
    End Sub

    Private Sub CargarListaxSeleccion()
        Try
            Select Case TablaCarga
                Case "ORDENSERVICIO"
                    Dim xx As New ORDENSERVICIO(Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                Case "EXTERNA", "INTERNA", "FAX", "BOLETA"
                    Dim xx As New CORRESPONDENCIA(Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                Case "COBRO"
                    Dim xx As New COBRO(Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                Case "DOCUMENTO"
                    Dim xx As New DOCUMENTO(Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                Case "VISITANTE"
                    Dim xx As New VISITANTE(Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                    If Ck_MostrarFotoVisitante.Checked Then
                        CargarFotoVisitante(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
                    Else
                        Me.Pb_FotoVisitante.Image = Nothing
                    End If
                Case "SOBRE"
                    Dim xx As New SOBRE(Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                Case "RECEPCION"
                    Dim xx As New RECEPCION(Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                    If Ck_VerDetalle.Checked Then
                        CargarDetalle(DGV_ListaSisControl.SelectedRows(0).Cells("IDRECEPCION").Value)
                    End If
                Case "FE_APROBACION"
                    Dim xx As New FE_APROBACION(DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index))
                    Pg_DetalleLista.SelectedObject = xx
                Case "FE_RECHAZO"
                    Dim xx As New FE_RECHAZO(DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index))
                    Pg_DetalleLista.SelectedObject = xx
                Case "CONTRATOS"
                    Dim xx As New CONTRATO(Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
            End Select
        Catch ex As Exception
            Pg_DetalleLista.SelectedObject = Nothing
        End Try
    End Sub

#Region "Orden de servicio"
    Private dtOrdenServicio As New DataTable

    Private Sub Nbi_CargarOrdenes_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarOrdenes.ItemClick
        CargarOrdenesServicio(0)
        OcultarPanelMiniatura()
        OcultarPanelDetalle()
    End Sub

    Private Sub CargarOrdenesServicio(ByVal Accion As Integer, Optional ByVal Varible As String = "")
        Nbi_ExportarOrden.Enabled = False
        TablaCarga = "ORDENSERVICIO"
        DGV_ListaSisControl.DataSource = Nothing
        dtOrdenServicio.Clear()

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListaOrdenServicio(@ACCION, @VARIABLE, @IDBASE)", conexion)
        comando.Parameters.AddWithValue("@ACCION", Accion)
        comando.Parameters.AddWithValue("@VARIABLE", Varible)
        comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dtOrdenServicio)
            conexion.Close()

            DGV_ListaSisControl.DataSource = dtOrdenServicio
            DGV_ListaSisControl.AutoGenerateColumns = True
            DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
            DGV_ListaSisControl.ReadOnly = True

            For i = 0 To DGV_ListaSisControl.ColumnCount - 1

                DGV_ListaSisControl.Columns(i).Visible = True
                Select Case DGV_ListaSisControl.Columns(i).Name
                    'Case "Id"
                    '    DGV_ListaSisControl.Columns(i).Width = 50
                    Case "Año"
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    Case "Codigo"
                        DGV_ListaSisControl.Columns(i).Width = 120
                        DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                        DGV_ListaSisControl.Columns(i).HeaderText = "Orden Servicio"
                    Case "Consecutivo"
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_ListaSisControl.Columns(i).HeaderText = "Conse"
                    Case "Nombre Contratista"
                        DGV_ListaSisControl.Columns(i).Width = 200
                    Case "Nit"
                        DGV_ListaSisControl.Columns(i).Width = 80
                    Case "Ciudad"
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_ListaSisControl.Columns(i).HeaderText = "Ciudad Contratista"
                    Case "Dirección"
                        DGV_ListaSisControl.Columns(i).Width = 200
                        DGV_ListaSisControl.Columns(i).HeaderText = "Dirección Contratista"
                    Case "Base"
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Case "Dependencia"
                        DGV_ListaSisControl.Columns(i).Width = 190
                    Case "Descripción"
                        DGV_ListaSisControl.Columns(i).Width = 190
                    Case "CERRADA"
                        DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_ListaSisControl.Columns(i).HeaderText = "Cer"
                    Case "ANULADA"
                        DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_ListaSisControl.Columns(i).HeaderText = "Anu"
                    Case Else
                        DGV_ListaSisControl.Columns(i).Visible = False
                End Select
            Next
            If DGV_ListaSisControl.RowCount > 0 Then
                DGV_ListaSisControl.Rows(0).Selected = True
                DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(1)
            End If
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Nbi_CrearOrdenes_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearOrdenes.ItemClick
        CrearOrdenServicio()
    End Sub

    Private Sub CrearOrdenServicio()
        Dim frOrdenServicio As New FormulariosSisControl.Fr_OrdenServicio
        frOrdenServicio.TipoEditando = "N"
        frOrdenServicio.CargarDatos()
        frOrdenServicio.ShowDialog()
        CargarOrdenesServicio(0)
    End Sub

    Private Sub Nbi_EditarOrden_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarOrden.ItemClick
        If TablaCarga = "ORDENSERVICIO" Then
            Dim puedeEditar As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(785) Then 'Puede editar todas las órdenes de Ismocol
                puedeEditar = True
            Else
                If FuncionesBase.FuncionesBase.ConsultarPermiso(784) AndAlso _
                   DGV_ListaSisControl.Item("IDBASESISCONTROL", DGV_ListaSisControl.CurrentCell.RowIndex).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then 'Puede cerrar las órdenes de la base
                    puedeEditar = True
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(783) AndAlso _
                       DGV_ListaSisControl.Item("IDDEPENDENCIA", DGV_ListaSisControl.CurrentCell.RowIndex).Value = VariablesBase.VariablesBase.IddependenciaSiscontrolActual Then 'Puede cerrar las órdenes de la dependencia
                        puedeEditar = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(782) AndAlso _
                           DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = VariablesBase.VariablesBase.IdPersona Then 'Puede cerrar las órdenes propias
                            puedeEditar = True
                        End If
                    End If
                End If
            End If
            If puedeEditar Then
                EditarOrdenServicio()
            Else
                MsgBox("No cuenta con el permiso para realizar esta operación", MsgBoxStyle.Critical, "ORDEN")
            End If
        Else
            MsgBox("Cargue el listado de órdenes de servicio", MsgBoxStyle.Critical, "Orden de Servicio")
        End If
    End Sub

    Private Sub Nbi_CierreOrden_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_CierreOrden.ItemClick
        If TablaCarga = "ORDENSERVICIO" Then
            Dim puedeCerrar As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(789) Then 'Puede cerrar todas las órdenes de Ismocol
                puedeCerrar = True
            Else
                If FuncionesBase.FuncionesBase.ConsultarPermiso(788) AndAlso _
                   DGV_ListaSisControl.Item("IDBASESISCONTROL", DGV_ListaSisControl.CurrentCell.RowIndex).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then 'Puede cerrar las órdenes de la base
                    puedeCerrar = True
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(787) AndAlso _
                       DGV_ListaSisControl.Item("IDDEPENDENCIA", DGV_ListaSisControl.CurrentCell.RowIndex).Value = VariablesBase.VariablesBase.IddependenciaSiscontrolActual Then 'Puede cerrar las órdenes de la dependencia
                        puedeCerrar = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(786) AndAlso _
                           DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = VariablesBase.VariablesBase.IdPersona Then 'Puede cerrar las órdenes propias
                            puedeCerrar = True
                        End If
                    End If
                End If
            End If
            If puedeCerrar Then
                If DGV_ListaSisControl.Item("CERRADA", DGV_ListaSisControl.CurrentCell.RowIndex).Value = "N" Then
                    CerrarOrdenServicio()
                Else
                    MsgBox("Esta orden de servicio ya fue cerrada", MsgBoxStyle.Critical, "ORDEN")
                End If
            Else
                MsgBox("No cuenta con el permiso para realizar esta operación", MsgBoxStyle.Critical, "ORDEN")
            End If
        Else
            MsgBox("Cargue el listado de órdenes de servicio", MsgBoxStyle.Critical, "Orden de Servicio")
        End If
    End Sub

    Private Sub EditarOrdenServicio()
        Dim frOrdenServicio As New FormulariosSisControl.Fr_OrdenServicio
        frOrdenServicio.IdOrdenServicio = Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index).Cells(0).Value()
        frOrdenServicio.IdDependencia = Me.DGV_ListaSisControl.Item("IDDEPENDENCIA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
        frOrdenServicio.TipoEditando = "E"
        If Me.DGV_ListaSisControl.Item("CERRADA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = "S" Then
            frOrdenServicio.CierreOrden = True
        End If
        frOrdenServicio.CargarDatos()
        frOrdenServicio.ShowDialog()
        CargarOrdenesServicio(0)
    End Sub

    Private Sub CerrarOrdenServicio()
        Dim frOrdenServicio As New FormulariosSisControl.Fr_OrdenServicio
        frOrdenServicio.IdOrdenServicio = Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index).Cells(0).Value()
        frOrdenServicio.IdDependencia = Me.DGV_ListaSisControl.Item("IDDEPENDENCIA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
        frOrdenServicio.TipoEditando = "E"
        frOrdenServicio.CierreOrden = True
        frOrdenServicio.CargarDatos()
        frOrdenServicio.ShowDialog()
        CargarOrdenesServicio(0)
    End Sub


    Private Sub Nbi_ClonarOrdenes_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ClonarOrdenes.ItemClick
        If TablaCarga <> "ORDENSERVICIO" Then
            MsgBox("Cargue Ordenes de servicio", MsgBoxStyle.Critical, "Orden de Servicio")
            Exit Sub
        End If
        ClonarOrdenServicio()
    End Sub

    Private Sub ClonarOrdenServicio()
        Dim frOrdenServicio As New FormulariosSisControl.Fr_OrdenServicio
        frOrdenServicio.IdOrdenServicio = Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index).Cells(0).Value()
        frOrdenServicio.IdDependencia = Me.DGV_ListaSisControl.Item("IDDEPENDENCIA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
        frOrdenServicio.TipoEditando = "C"
        frOrdenServicio.CargarDatos()
        frOrdenServicio.Lb_Consecutivo.Visible = False
        frOrdenServicio.ShowDialog()
        CargarOrdenesServicio(0)
    End Sub

    Private Sub Nbi_VerOrdenes_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_VerOrdenes.ItemClick
        If TablaCarga = "ORDENSERVICIO" Then
            Dim frOrdenServicio As New FormulariosSisControl.Fr_OrdenServicio
            frOrdenServicio.IdOrdenServicio = Me.DGV_ListaSisControl.Rows(DGV_ListaSisControl.CurrentRow.Index).Cells(0).Value()
            frOrdenServicio.TipoEditando = "V"
            frOrdenServicio.Bt_Guardar.Enabled = False
            If Me.DGV_ListaSisControl.Item("CERRADA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = "S" Then
                frOrdenServicio.CierreOrden = True
            End If
            frOrdenServicio.CargarDatos()
            frOrdenServicio.ShowDialog()
        Else
            MsgBox("Cargue Ordenes de servicio", MsgBoxStyle.Critical, "Orden de Servicio")
        End If
    End Sub

    Private Sub Nbi_ImprimirOrden_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ImprimirOrden.ItemClick
        If TablaCarga <> "ORDENSERVICIO" Then
            MsgBox("Cargue Ordenes de servicio", MsgBoxStyle.Critical, "Orden de Servicio")
            Exit Sub
        End If
        ImprimirOrden(False)
    End Sub

    Private Sub Nbi_ImprimirCierre_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ImprimirCierre.ItemClick
        If TablaCarga <> "ORDENSERVICIO" Then
            MsgBox("Cargue Ordenes de servicio", MsgBoxStyle.Critical, "Orden de Servicio")
            Exit Sub
        End If
        If Me.DGV_ListaSisControl.Item("CERRADA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = "S" Then
            ImprimirOrden(True)
        Else
            MsgBox("Debe cerrar la orden de servicio antes de imprimir", MsgBoxStyle.Critical, "ORDEN")
        End If
    End Sub

    Private Sub ImprimirOrden(ByVal Cierre As Boolean)
        If Me.DGV_ListaSisControl.Item("IMPRESA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = "N" Then
            If MsgBox("¿Desea imprimir la Orden de Servicio", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
                Dim Array As New ArrayList
                Array.Add(70)
                If MsgBox("¿Desea imprimir formato completo", MsgBoxStyle.YesNo, "Formato") = MsgBoxResult.Yes Then
                    climpresiones.Formatoorden = True
                End If
                climpresiones.OrdenCierre = Cierre
                climpresiones.IdOrdenServicio = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
                climpresiones.FormatoImprimirSisControl(Array, True, False)
                MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                CargarOrdenesServicio(0)
            End If
        Else
            MsgBox("La Orden de Servicio No" + CStr(Me.DGV_ListaSisControl.Item("Consecutivo", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value) + " - " + CStr(Me.DGV_ListaSisControl.Item("Año", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value) + "  ya fue impresa", vbCritical, "Impresión Orden de Servicio")
            Exit Sub
        End If
    End Sub

    Private Sub Nbi_AnularOrdenes_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_AnularOrdenes.ItemClick
        If TablaCarga = "ORDENSERVICIO" Then
            Dim puedeAnular As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(793) Then 'Puede anular todas las órdenes de Ismocol
                puedeAnular = True
            Else
                If FuncionesBase.FuncionesBase.ConsultarPermiso(792) AndAlso _
                   DGV_ListaSisControl.Item("IDBASESISCONTROL", DGV_ListaSisControl.CurrentCell.RowIndex).Value = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then 'Puede anular las órdenes de la base
                    puedeAnular = True
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(791) AndAlso _
                       DGV_ListaSisControl.Item("IDDEPENDENCIA", DGV_ListaSisControl.CurrentCell.RowIndex).Value = VariablesBase.VariablesBase.IddependenciaSiscontrolActual Then 'Puede anular las órdenes de la dependencia
                        puedeAnular = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(790) AndAlso _
                           DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = VariablesBase.VariablesBase.IdPersona Then 'Puede anular las órdenes propias
                            puedeAnular = True
                        End If
                    End If
                End If
            End If
            If puedeAnular Then
                If DGV_ListaSisControl.Item("ANULADA", DGV_ListaSisControl.CurrentCell.RowIndex).Value = "N" Then
                    AnularOrdenServicio()
                Else
                    MsgBox("Esta orden de servicio ya está anulada.", MsgBoxStyle.Critical, "Orden de servicio")
                End If
            Else
                MsgBox("No cuenta con el permiso para realizar esta operación.", MsgBoxStyle.Critical, "Orden de servicio")
            End If
        Else
            MsgBox("Cargue el listado de órdenes de servicio.", MsgBoxStyle.Critical, "Orden de Servicio")
        End If
    End Sub

    Private Sub AnularOrdenServicio()
        If MsgBox("¿Desea anular la orden de servicio", MsgBoxStyle.YesNo, "Anular") = MsgBoxResult.Yes Then
            Dim Dt_OrdenServicio As DataTable
            Dim Cadena_Consulta_Update As String = ""
            Dim FechaAnulado As String = CStr(Date.Now.Day) + "/" + CStr(Date.Now.Month) + "/" + CStr(Date.Now.Year) + " " + CStr(Date.Now.Hour) + ":" + CStr(Date.Now.Minute) + ":" + CStr(Date.Now.Second) + "." + CStr(Date.Now.Millisecond)
            Cadena_Consulta_Update = "UPDATE SC_ORDENESSERVICIO SET ANULADA = 'S' ,  IDPERSONAANULA =  " + CStr(VariablesBase.VariablesBase.IdPersona) + " , FECHAANULACION = '" + FechaAnulado + "' where IDORDENESSERVICIO = " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dt_OrdenServicio = New DataTable
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Try
                Consulta.Connection.Open()
                Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
                Adaptador.Fill(Dt_OrdenServicio)
                Consulta.Connection.Close()
            Catch ex As Exception
                Consulta.Connection.Close()
                MsgBox(ex.Message)
            Finally
                Consulta.Connection.Close()
            End Try
            CargarOrdenesServicio(0)
        End If
    End Sub

    Private Sub Nbi_BuscarOrdenes_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BuscarOrdenes.ItemClick
        Buscar_Orden()
    End Sub

    Private Sub Buscar_Orden()
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("[Nombre Contratista]", "Nombre Contratista", "1")
        campos.Rows.Add("Nit", "Nit Proveedor", "2")
        campos.Rows.Add("Consecutivo", "Consecutivo", "2")
        campos.Rows.Add("Dirección", "Dirección", "1")
        campos.Rows.Add("Base", "Nombre Base", "1") '------REVISAR COMILLAS
        campos.Rows.Add("Ciudad", "Ciudad ", "1")
        campos.Rows.Add("FECHA", "Fecha Elaboración", "3")
        campos.Rows.Add("Dependencia", "Dependencia", "1")
        campos.Rows.Add("Descripción", "Descripción", "1")
        campos.Rows.Add("Acepta", "Aceptado por", "1")
        campos.Rows.Add("Solicita", "Solicitado Por", "1")
        campos.Rows.Add("Recibe", "Recibido Por", "1")
        campos.Rows.Add("FACTURA", "Factura", "1")
        campos.Rows.Add("VALORFACTURA", "Valor", "2")
        campos.Rows.Add("OBSERVACION", "Observación", "1")
        campos.Rows.Add("CODIGOCENTROCOSTOSSOLIN", "Centro de Costo", "1")
        campos.Rows.Add("SUBCENTROCOSTOSSOLIN", "Subcentro de Costo", "1")
        campos.Rows.Add("FECHARECIBE", "Fecha Recibido", "3")
        campos.Rows.Add("FECHAFACTURA", "Fecha de Factura", "3")
        campos.Rows.Add("FECHAVENCIMIENTOFACTURA", "Fecha de Vencimiento", "3")
        frbuscar.campos = campos
        frbuscar.tabla = 6
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarOrdenesServicioFiltro(DSbusqueda)
                Nbi_ExportarOrden.Enabled = True
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub

    Private Sub CargarOrdenesServicioFiltro(ByVal Tabla As DataSet)
        TablaCarga = "ORDENSERVICIO"
        Me.DGV_ListaSisControl.DataSource = Nothing
        Me.DGV_ListaSisControl.DataSource = Tabla.Tables(0).DefaultView
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1

            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                'Case "Id"
                '    DGV_ListaSisControl.Columns(i).Width = 50
                Case "Año"
                    DGV_ListaSisControl.Columns(i).Width = 50
                Case "Consecutivo"
                    DGV_ListaSisControl.Columns(i).Width = 70
                Case "Nombre Contratista"
                    DGV_ListaSisControl.Columns(i).Width = 200
                Case "Nit"
                    DGV_ListaSisControl.Columns(i).Width = 80
                Case "Ciudad"
                    DGV_ListaSisControl.Columns(i).Width = 200
                Case "Dirección"
                    DGV_ListaSisControl.Columns(i).Width = 200
                Case "Base"
                    DGV_ListaSisControl.Columns(i).Width = 190
                Case "Dependencia"
                    DGV_ListaSisControl.Columns(i).Width = 190
                Case "Descripción"
                    DGV_ListaSisControl.Columns(i).Width = 190
                Case "CERRADA"
                    DGV_ListaSisControl.Columns(i).Width = 50
                Case "ANULADA"
                    DGV_ListaSisControl.Columns(i).Width = 50
                Case "AUTORIZADESCTSS"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Autoriza Dcto SS"
                Case "SERVIDOR"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Servidor"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(1)
        End If
    End Sub

    Private Sub Nbi_HabilitarOrden_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HabilitarOrden.ItemClick
        If TablaCarga <> "ORDENSERVICIO" Then
            MsgBox("Cargue Ordenes de servicio", MsgBoxStyle.Critical, "Orden de Servicio")
            Exit Sub
        End If
        If MsgBox("¿Desea habilitar la impresión de la Orden de Servicio", MsgBoxStyle.YesNo, "Habilitar") = MsgBoxResult.Yes Then
            Dim Dt_OrdenServicio As DataTable
            Dim Cadena_Consulta_Update As String = ""
            Cadena_Consulta_Update = "update SC_ORDENESSERVICIO set IMPRESA = 'N' where IDORDENESSERVICIO =  " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_OrdenServicio = New DataTable
            Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
            Adaptador.Fill(Dt_OrdenServicio)
            Consulta.Connection.Close()
            CargarOrdenesServicio(0)
        End If
    End Sub

    Private Sub Nbi_RegistrarFactura_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_RegistrarFactura.ItemClick
        If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
            If TablaCarga = "ORDENSERVICIO" Then
                Index_Registro_Actual = Me.DGV_ListaSisControl.CurrentCell.RowIndex
                Dim EditarOC As Boolean = False
                If MsgBox("¿Seguro que desea relacionar factura a la Orden de Servicio " & Me.DGV_ListaSisControl.SelectedRows(0).Cells("Consecutivo").Value & "?", vbYesNo, "REGISTRAR FACTURA") = MsgBoxResult.Yes Then
                    Dim IDORDENSERVICIOMODIFICANDO As Integer
                    IDORDENSERVICIOMODIFICANDO = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
                    Dim Fr_Aceptada As New Form
                    Dim Bt_AceptarFr As New System.Windows.Forms.Button
                    Dim Bt_CancelarFr As New System.Windows.Forms.Button
                    Dim Lb_NroFactura As New System.Windows.Forms.Label
                    Dim Tx_NroFactura As New System.Windows.Forms.TextBox
                    Dim Lb_FechaFactura As New System.Windows.Forms.Label
                    Dim Dtp_FechaFactura As New System.Windows.Forms.DateTimePicker
                    'Bt_Aceptar
                    Bt_AceptarFr.Location = New System.Drawing.Point(315, 63)
                    Bt_AceptarFr.Name = "Bt_Aceptar"
                    Bt_AceptarFr.Size = New System.Drawing.Size(75, 23)
                    Bt_AceptarFr.TabIndex = 0
                    Bt_AceptarFr.Text = "Aceptar"
                    Bt_AceptarFr.UseVisualStyleBackColor = True
                    AddHandler Bt_AceptarFr.Click, AddressOf Bt_AceptarFrEvento
                    'Bt_Cancelar
                    Bt_CancelarFr.Location = New System.Drawing.Point(396, 63)
                    Bt_CancelarFr.Name = "Bt_Cancelar"
                    Bt_CancelarFr.Size = New System.Drawing.Size(75, 23)
                    Bt_CancelarFr.TabIndex = 1
                    Bt_CancelarFr.Text = "Cancelar"
                    Bt_CancelarFr.UseVisualStyleBackColor = True
                    AddHandler Bt_CancelarFr.Click, AddressOf Bt_CancelarFrEvento
                    'Label1
                    Lb_NroFactura.AutoSize = True
                    Lb_NroFactura.Location = New System.Drawing.Point(12, 9)
                    Lb_NroFactura.Name = "Lb_NroFactura"
                    Lb_NroFactura.Size = New System.Drawing.Size(107, 13)
                    Lb_NroFactura.TabIndex = 2
                    Lb_NroFactura.Text = "Factura:"
                    'TextBox1
                    Tx_NroFactura.Location = New System.Drawing.Point(125, 6)
                    Tx_NroFactura.MaxLength = 100
                    Tx_NroFactura.Name = "Tx_NroFactura"
                    Tx_NroFactura.Size = New System.Drawing.Size(346, 20)
                    Tx_NroFactura.TabIndex = 3
                    'Label2
                    Lb_FechaFactura.AutoSize = True
                    Lb_FechaFactura.Location = New System.Drawing.Point(21, 37)
                    Lb_FechaFactura.Name = "Lb_FechaFactura"
                    Lb_FechaFactura.Size = New System.Drawing.Size(98, 13)
                    Lb_FechaFactura.TabIndex = 4
                    Lb_FechaFactura.Text = "Fecha factura:"
                    'DateTimePicker1
                    Dtp_FechaFactura.Location = New System.Drawing.Point(125, 34)
                    Dtp_FechaFactura.Name = "Dtp_FechaFactura"
                    Dtp_FechaFactura.Size = New System.Drawing.Size(200, 20)
                    Dtp_FechaFactura.TabIndex = 5
                    'Fr_Aceptada
                    Fr_Aceptada.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                    Fr_Aceptada.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                    Fr_Aceptada.ClientSize = New System.Drawing.Size(478, 91)
                    Fr_Aceptada.Controls.Add(Lb_FechaFactura)
                    Fr_Aceptada.Controls.Add(Bt_AceptarFr)
                    Fr_Aceptada.Controls.Add(Bt_CancelarFr)
                    Fr_Aceptada.Controls.Add(Lb_NroFactura)
                    Fr_Aceptada.Controls.Add(Tx_NroFactura)
                    Fr_Aceptada.Controls.Add(Dtp_FechaFactura)
                    Fr_Aceptada.MaximizeBox = False
                    Fr_Aceptada.MaximumSize = New System.Drawing.Size(494, 129)
                    Fr_Aceptada.MinimizeBox = False
                    Fr_Aceptada.MinimumSize = New System.Drawing.Size(494, 129)
                    Fr_Aceptada.Name = "Fr_Aceptada"
                    Fr_Aceptada.Text = "Registrar factura a la orden de servicio"
                    Fr_Aceptada.ShowDialog()
                    If Trim(Tx_NroFactura.Text) = "" Then
                        MsgBox("Debe especificar el número de la factura de la Orden de Servicio", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If RespuestaFr_Aceptada = 1 Then
                        Dim Comando As New SqlClient.SqlCommand("dbo.RelacionarFacturaOrdenServicio")
                        Comando.CommandType = CommandType.StoredProcedure
                        Comando.Parameters.AddWithValue("@IDORDENESSERVICIO", IDORDENSERVICIOMODIFICANDO)
                        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                        Comando.Parameters.AddWithValue("@FECHAFACTURA", Dtp_FechaFactura.Value)
                        Comando.Parameters.AddWithValue("@FACTURA", Trim(Mid(Tx_NroFactura.Text, 1, 50)))
                        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                        msgParam.Direction = ParameterDirection.Output
                        Comando.Parameters.Add(msgParam)
                        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                        Try
                            conn.Open()
                            Comando.Connection = conn
                            Comando.ExecuteNonQuery()
                            conn.Close()
                            Select Case Comando.Parameters("@IDMENSAJE").Value
                                Case -1 '-1 --Indica que  ocurrió un error antes de actualizar
                                    MsgBox("Ocurrió un error al intentar registrar la factura a la OS, vuelva a intentar o póngase en contacto con el área de soporte", MsgBoxStyle.Critical)
                                Case 1 '1 --Indica que la orden de servicio no ha sido cerrada
                                    MsgBox("La orden de servicio no ha sido cerrada y por lo tanto no se puede asociar la factura", MsgBoxStyle.Critical)
                                Case 2  '-Se registro Correctamente 
                                    MsgBox("La Orden de servicio ha sido asociada correctamente con la factura", MsgBoxStyle.Information)
                                Case 3 '--La fecha de la factura es anterior a la fecha de emisión del servicio
                                    MsgBox("La fecha de la factura es anterior a la fecha de emisión de la orden de servicio", MsgBoxStyle.Critical)
                            End Select
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Nbi_ListadoOrdenes_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ListadoOrdenes.ItemClick
        Listado("O")
    End Sub

#End Region 'Orden de servicio

#Region "Correspondencia"

    'Dim LISTACORRESPONDENCIAEXTERNATableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_CORRESPONDENCIATableAdapter
    'Dim DsCorrespondenciaExterna As New DatosSisControl.Ds_Siscontrol
    Private dtCorrespondencia As New DataTable

    Private Sub Nbi_CrearCorrExterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearCorrExterna.ItemClick
        CrearCorrespondencia("E")
    End Sub


    Private Sub Nbi_CrearCorrInterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearCorrInterna.ItemClick
        CrearCorrespondencia("I")
    End Sub


    Private Sub Nbi_CrearFax_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearFax.ItemClick
        CrearCorrespondencia("F")
    End Sub


    Private Sub CrearCorrespondencia(ByVal Tipo As String)
        If VariablesBase.VariablesBase.IdBaseSiscontrolActual = 0 Then 'Si está en la Base BUC - PRINCIPAL
            If VariablesBase.VariablesBase.IdPersona <> 3608 Then 'Usuario secretaria de Gerencia CLAUDIA LILIANA GAMBOA ALMEYDA, encargada de generar los consecutivos de correspondencia externa ICG para los demás funcionarios.
                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                Dim comando As New SqlCommand("SELECT * FROM dbo.SC_ListarUsuarioCorrespondencia(@IDUSUARIO)", conexion)
                comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                Dim dtUsuarioCorrespondencia As New DataTable
                Dim adaptador As New SqlDataAdapter(comando)
                Try
                    comando.Connection.Open()
                    adaptador.Fill(dtUsuarioCorrespondencia)
                    comando.Connection.Close()
                    Dim drcCantidad As DataRow() = dtUsuarioCorrespondencia.Select("TIPOCORRESPONDENCIA = '" & Tipo & "'")
                    If drcCantidad(0).Item("CANTIDADDOCUMENTOS") >= drcCantidad(0).Item("CANTIDADLIMITE") OrElse drcCantidad(1).Item("CANTIDADDOCUMENTOS") >= drcCantidad(1).Item("CANTIDADLIMITE") Then
                        If drcCantidad(0).Item("CANTIDADDOCUMENTOS") >= drcCantidad(0).Item("CANTIDADLIMITE") Then
                            MsgBox("Este usuario presenta " & drcCantidad(0).Item("CANTIDADLIMITE") & " o más pendientes en archivo central, por favor proceder a cerrar los pendientes para continuar", MsgBoxStyle.Exclamation, "CORRESPONDENCIA")
                        End If
                        If drcCantidad(1).Item("CANTIDADDOCUMENTOS") >= drcCantidad(1).Item("CANTIDADLIMITE") Then
                            MsgBox("Este usuario presenta " & drcCantidad(1).Item("CANTIDADLIMITE") & " o más pendientes en archivo central, por favor proceder a cerrar los pendientes para continuar", MsgBoxStyle.Exclamation, "CORRESPONDENCIA")
                        End If
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    comando.Connection.Close()
                End Try
            End If
        End If
        Dim FrCorrespondenciaExterna As New FormulariosSisControl.Fr_Correspondencia
        Select Case Tipo
            Case "E"
                FrCorrespondenciaExterna.Lb_Titulo.Text = "CORRESPONDENCIA EXTERNA"
                FrCorrespondenciaExterna.Text = "CORRESPONDENCIA EXTERNA"
            Case "I"
                FrCorrespondenciaExterna.Lb_Titulo.Text = "CORRESPONDENCIA INTERNA"
                FrCorrespondenciaExterna.Text = "CORRESPONDENCIA INTERNA"
            Case "F"
                FrCorrespondenciaExterna.Lb_Titulo.Text = "CONTROL DE AUTORIZACIÓN - FAX ENVIADOS"
                FrCorrespondenciaExterna.Text = "CONTROL DE AUTORIZACIÓN - FAX ENVIADOS"
        End Select
        FrCorrespondenciaExterna.Tipo = Tipo
        FrCorrespondenciaExterna.Cargar_Datos()
        FrCorrespondenciaExterna.ShowDialog()
        CargarCorrespondencia(Tipo, 0)
    End Sub


    Private Sub Nbi_CargarCorrExterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarCorrExterna.ItemClick
        '' CargarCorrespondencia("E", 0) 'E Correspondencia Externa
        CargarTablaxDefectoExterna()
        OcultarPanelMiniatura()
        OcultarPanelDetalle()
    End Sub


    Private Sub Nbi_CargarCorrInterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarCorrInterna.ItemClick
        '' CargarCorrespondencia("I", 0) ' I Correspondencia Interna
        CargarTablaxDefectoInterna()
        OcultarPanelMiniatura()
        OcultarPanelDetalle()
    End Sub


    Private Sub Nbi_CargarFax_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarFax.ItemClick
        ''CargarCorrespondencia("F", 0) 'F Fax
        CargarTablaxDefectoFax()
        OcultarPanelMiniatura()
        OcultarPanelDetalle()
    End Sub


    Private Sub CargarCorrespondencia(ByVal Tipo As String, ByVal Accion As Integer, Optional ByVal Variable As String = "")
        Nbi_ExportarExterna.Enabled = False
        Nbi_ExportarInterna.Enabled = False
        Nbi_ExportarFax.Enabled = False
        Select Case Tipo
            Case "E"
                TablaCarga = "EXTERNA"
                CargarTablaxDefectoExterna()
            Case "I"
                TablaCarga = "INTERNA"
                CargarTablaxDefectoInterna()
            Case "F"
                TablaCarga = "FAX"
                CargarTablaxDefectoFax()
        End Select
    End Sub


    Private Sub DGV_ListaSisControl_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_ListaSisControl.CellDoubleClick
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            Select Case TablaCarga
                Case "EXTERNA"
                    EditarCorrespondencia("E")
                Case "INTERNA"
                    EditarCorrespondencia("(I")
                Case "FAX"
                    EditarCorrespondencia("F")
            End Select
        End If
    End Sub


    Private Sub Nbi_EditarCorrExterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarCorrExterna.ItemClick
        If TablaCarga = "EXTERNA" Then
            If VariablesBase.VariablesBase.IdPersona = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value Then
                EditarCorrespondencia("E")
            Else
                MsgBox("Solo puede editar la persona que registro", MsgBoxStyle.Critical, "EXTERNA")
            End If

        Else
            MsgBox("Cargue correspondencia externa", MsgBoxStyle.Critical, "EXTERNA")
        End If
    End Sub


    Private Sub Nbi_EditarCorrInterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarCorrInterna.ItemClick
        If TablaCarga = "INTERNA" Then

            If VariablesBase.VariablesBase.IdPersona = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value Then
                EditarCorrespondencia("I")
            Else
                MsgBox("Solo puede editar la persona que registro", MsgBoxStyle.Critical, "EXTERNA")
            End If

        Else
            MsgBox("Cargue correspondencia interna", MsgBoxStyle.Critical, "INTERNA")
        End If
    End Sub


    Private Sub Nbi_EditarFax_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarFax.ItemClick
        Dim PuedeEditar As Boolean = False

        If TablaCarga = "FAX" Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso(995) Then
                PuedeEditar = True
            Else
                If FuncionesBase.FuncionesBase.ConsultarPermiso(994) And 1 = 1 Then
                    Dim IDBodegaOC As Integer = Me.DGV_ListaSisControl.Item("IDBASESISCONTROL", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                    If IDBodegaOC = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                        PuedeEditar = True
                    Else
                        PuedeEditar = False
                    End If
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(993) Then
                        Dim IDRegistro As Integer = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                        If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                            PuedeEditar = True
                        Else
                            PuedeEditar = False
                        End If
                    Else
                        PuedeEditar = False
                    End If
                End If
            End If

            If PuedeEditar Then
                EditarCorrespondencia("F")
            Else
                MsgBox("No cuenta con permiso para editar", MsgBoxStyle.Critical, "Permisos Insuficientes")
            End If
        Else
            MsgBox("Cargue Fax", MsgBoxStyle.Critical, "FAX")
        End If
    End Sub


    Private Sub EditarCorrespondencia(ByVal Tipo As String)
        Dim FrCorrespondenciaExterna As New FormulariosSisControl.Fr_Correspondencia
        Select Case Tipo
            Case "E"
                FrCorrespondenciaExterna.Lb_Titulo.Text = "CORRESPONDENCIA EXTERNA"
                FrCorrespondenciaExterna.Text = "CORRESPONDENCIA EXTERNA"
            Case "I"
                FrCorrespondenciaExterna.Lb_Titulo.Text = "CORRESPONDENCIA INTERNA"
                FrCorrespondenciaExterna.Text = "CORRESPONDENCIA INTERNA"
            Case "F"
                FrCorrespondenciaExterna.Lb_Titulo.Text = "CONTROL DE FAX ENVIADOS"
                FrCorrespondenciaExterna.Text = "CONTROL DE FAX ENVIADOS"
        End Select
        FrCorrespondenciaExterna.Tipo = Tipo
        FrCorrespondenciaExterna.Editando = True
        FrCorrespondenciaExterna.IdCorrespondencia = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrCorrespondenciaExterna.Dependencia = Me.DGV_ListaSisControl.Item("IDDEPENDENCIA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
        FrCorrespondenciaExterna.Cargar_Datos()
        FrCorrespondenciaExterna.ShowDialog()
        CargarCorrespondencia(Tipo, 0)
    End Sub


    Private Sub Nbi_ClonarExterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ClonarExterna.ItemClick
        If TablaCarga = "EXTERNA" Then
            ClonarCorrespondencia("E")
        Else
            MsgBox("Cargue correspondencia externa", MsgBoxStyle.Critical, "EXTERNA")
        End If
    End Sub


    Private Sub Nbi_ClonarInterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ClonarInterna.ItemClick
        If TablaCarga = "INTERNA" Then
            ClonarCorrespondencia("I")
        Else
            MsgBox("Cargue correspondencia interna", MsgBoxStyle.Critical, "INTERNA")
        End If
    End Sub


    Private Sub Nbi_ClonarFax_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ClonarFax.ItemClick
        If TablaCarga = "FAX" Then
            ClonarCorrespondencia("F")
        Else
            MsgBox("Cargue Fax", MsgBoxStyle.Critical, "FAX")
        End If
    End Sub


    Private Sub ClonarCorrespondencia(ByVal Tipo As String)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        'Restricciones exceptuando al usuario de Secretaria Gerencia
        '   Dim comando As New SqlCommand("SELECT COUNT(DOCUMENTO) FROM dbo.CorrespondenciaPendiente() WHERE IDPERSONAREGISTRA = @IDUSUARIO  AND IDPERSONAREGISTRA <> 3608", conexion)
        Dim comando As New SqlCommand("SELECT * FROM dbo.SC_ListarUsuarioCorrespondencia(@IDUSUARIO)", conexion)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim dtUsuarioCorrespondencia As New DataTable
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            comando.Connection.Open()
            'adaptador.FillSchema(dtUsuarioCorrespondencia, SchemaType.Source)
            adaptador.Fill(dtUsuarioCorrespondencia)
            comando.Connection.Close()
            Dim drcCantidad As DataRow() = dtUsuarioCorrespondencia.Select("TIPOCORRESPONDENCIA = '" & Tipo & "'")

            If drcCantidad(0).Item("CANTIDADDOCUMENTOS") >= drcCantidad(0).Item("CANTIDADLIMITE") OrElse drcCantidad(1).Item("CANTIDADDOCUMENTOS") >= drcCantidad(1).Item("CANTIDADLIMITE") Then
                If drcCantidad(0).Item("CANTIDADDOCUMENTOS") >= drcCantidad(0).Item("CANTIDADLIMITE") Then
                    MsgBox("Este usuario presenta " & drcCantidad(0).Item("CANTIDADLIMITE") & " o más pendientes en archivo central, por favor proceder a cerrar los pendientes para continuar", MsgBoxStyle.Exclamation, "CORRESPONDENCIA")
                End If
                If drcCantidad(1).Item("CANTIDADDOCUMENTOS") >= drcCantidad(1).Item("CANTIDADLIMITE") Then
                    MsgBox("Este usuario presenta " & drcCantidad(1).Item("CANTIDADLIMITE") & " o más pendientes en archivo central, por favor proceder a cerrar los pendientes para continuar", MsgBoxStyle.Exclamation, "CORRESPONDENCIA")
                End If
                Exit Sub
            End If

            Dim FrCorrespondenciaExterna As New FormulariosSisControl.Fr_Correspondencia
            Select Case Tipo
                Case "E"
                    FrCorrespondenciaExterna.Lb_Titulo.Text = "CORRESPONDENCIA EXTERNA"
                    FrCorrespondenciaExterna.Text = "CORRESPONDENCIA EXTERNA"
                Case "I"
                    FrCorrespondenciaExterna.Lb_Titulo.Text = "CORRESPONDENCIA INTERNA"
                    FrCorrespondenciaExterna.Text = "CORRESPONDENCIA INTERNA"
                Case "F"
                    FrCorrespondenciaExterna.Lb_Titulo.Text = "CONTROL DE FAX ENVIADOS"
                    FrCorrespondenciaExterna.Text = "CONTROL DE FAX ENVIADOS"
            End Select
            FrCorrespondenciaExterna.Tipo = Tipo
            FrCorrespondenciaExterna.Editando = True
            FrCorrespondenciaExterna.IdCorrespondencia = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
            FrCorrespondenciaExterna.Dependencia = Me.DGV_ListaSisControl.Item("IDDEPENDENCIA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
            FrCorrespondenciaExterna.Clonar = True
            FrCorrespondenciaExterna.Cargar_Datos()
            FrCorrespondenciaExterna.Editando = False
            FrCorrespondenciaExterna.Lb_CódigoArtículo.Visible = False
            FrCorrespondenciaExterna.Tx_Asunto.Text = ""
            FrCorrespondenciaExterna.Dtp_Fecha.Value = Date.Now
            FrCorrespondenciaExterna.ShowDialog()
            CargarCorrespondencia(Tipo, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            comando.Connection.Close()
        End Try
    End Sub


    Private Sub Nbi_VerCorrExterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_VerCorrExterna.ItemClick
        If TablaCarga = "EXTERNA" Then
            VerCorrespondencia("E")
        Else
            MsgBox("Cargue correspondencia externa", MsgBoxStyle.Critical, "EXTERNA")
        End If
    End Sub


    Private Sub Nbi_VerCorrInterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_VerCorrInterna.ItemClick
        If TablaCarga = "INTERNA" Then
            VerCorrespondencia("I")
        Else
            MsgBox("Cargue correspondencia interna", MsgBoxStyle.Critical, "INTERNA")
        End If
    End Sub


    Private Sub Nbi_VerFáx_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_VerFáx.ItemClick
        Dim PuedeVer As Boolean = False

        If TablaCarga = "FAX" Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso(998) Then
                PuedeVer = True
            Else
                If FuncionesBase.FuncionesBase.ConsultarPermiso(997) Then
                    Dim IDBodegaOC As Integer = Me.DGV_ListaSisControl.Item("IDBASESISCONTROL", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                    If IDBodegaOC = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(996) Then
                        Dim IDRegistro As Integer = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                        If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                            PuedeVer = True
                        Else
                            PuedeVer = False
                        End If
                    Else
                        PuedeVer = False
                    End If
                End If
            End If

            If PuedeVer Then
                VerCorrespondencia("F")
            Else
                MsgBox("No cuenta con permiso para ver", MsgBoxStyle.Critical, "Permisos Insuficientes")
            End If
        Else
            MsgBox("Cargue Fax", MsgBoxStyle.Critical, "FAX")
        End If

    End Sub


    Private Sub VerCorrespondencia(ByVal Tipo As String)
        Dim FrCorrespondenciaExterna As New FormulariosSisControl.Fr_Correspondencia

        Select Case Tipo
            Case "E"
                FrCorrespondenciaExterna.Lb_Titulo.Text = "CORRESPONDENCIA EXTERNA"
            Case "I"
                FrCorrespondenciaExterna.Lb_Titulo.Text = "CORRESPONDENCIA INTERNA"
            Case "F"
                FrCorrespondenciaExterna.Lb_Titulo.Text = "CONTROL DE FAX ENVIADOS"
        End Select
        FrCorrespondenciaExterna.Tipo = Tipo
        FrCorrespondenciaExterna.Editando = True
        FrCorrespondenciaExterna.IdCorrespondencia = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrCorrespondenciaExterna.Cargar_Datos()
        FrCorrespondenciaExterna.Bt_Guardar.Enabled = False
        FrCorrespondenciaExterna.ShowDialog()
        CargarCorrespondencia(Tipo, 0)
    End Sub


    Private Sub Nbi_AnularCorrExterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_AnularCorrExterna.ItemClick
        If TablaCarga = "EXTERNA" Then
            AnularCorrespondencia()
        Else
            MsgBox("Cargue correspondencia externa ", MsgBoxStyle.Critical, "EXTERNA")
        End If
    End Sub


    Private Sub Nbi_AnularCorrInterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_AnularCorrInterna.ItemClick
        If TablaCarga = "INTERNA" Then
            AnularCorrespondencia()
        Else
            MsgBox("Cargue correspondencia externa ", MsgBoxStyle.Critical, "INTERNA")
        End If
    End Sub


    Private Sub Nbi_AnularFax_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_AnularFax.ItemClick
        Dim PuedeAnular As Boolean = False

        If TablaCarga = "FAX" Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso(995) Then
                PuedeAnular = True
            Else
                If FuncionesBase.FuncionesBase.ConsultarPermiso(994) And 1 = 1 Then
                    Dim IDBodegaOC As Integer = Me.DGV_ListaSisControl.Item("IDBASESISCONTROL", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                    If IDBodegaOC = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                        PuedeAnular = True
                    Else
                        PuedeAnular = False
                    End If
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(993) Then
                        Dim IDRegistro As Integer = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                        If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                            PuedeAnular = True
                        Else
                            PuedeAnular = False
                        End If
                    Else
                        PuedeAnular = False
                    End If
                End If
            End If

            If PuedeAnular Then
                AnularCorrespondencia()
            Else
                MsgBox("No cuenta con permiso para anular", MsgBoxStyle.Critical, "Permisos Insuficientes")
            End If
        Else
            MsgBox("Cargue Fax", MsgBoxStyle.Critical, "FAX")
        End If

    End Sub


    Private Sub AnularCorrespondencia()
        If MsgBox("¿Desea anular la correspondencia", MsgBoxStyle.YesNo, "ANULAR") = MsgBoxResult.Yes Then
            Dim Dt_OrdenServicio As DataTable
            Dim Cadena_Consulta_Update As String = ""
            Dim FechaAnulado As String = CStr(Date.Now.Day) + "/" + CStr(Date.Now.Month) + "/" + CStr(Date.Now.Year) + " " + CStr(Date.Now.Hour) + ":" + CStr(Date.Now.Minute) + ":" + CStr(Date.Now.Second) + "." + CStr(Date.Now.Millisecond)
            Cadena_Consulta_Update = "UPDATE SC_CORRESPONDENCIA SET ANULADA = 'S' ,  IDPERSONAANULA =  " + CStr(VariablesBase.VariablesBase.IdPersona) + " , FECHAANULACION = '" + FechaAnulado + "' where IDCORRESPONDENCIAEXTERNA = " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_OrdenServicio = New DataTable
            Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
            Adaptador.Fill(Dt_OrdenServicio)
            Consulta.Connection.Close()
        End If
    End Sub


    Private Sub Nbi_ListadoCorreExterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ListadoCorreExterna.ItemClick
        Listado("E")
    End Sub


    Private Sub Nbi_ListadoCorreInterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ListadoCorreInterna.ItemClick
        Listado("I")
    End Sub


    Private Sub Nbi_ListaFax_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ListaFax.ItemClick
        Listado("F")
    End Sub


    Private Sub Listado(ByVal Tipo As String)
        Dim FrListado As New FormulariosSisControl.Fr_Listado
        FrListado.Tipo = Tipo
        FrListado.CargarDatos()
        FrListado.ShowDialog()
    End Sub


    Private Function validarInput(ByVal texto As String) As Boolean
        If IsNumeric(texto) Then
            validarInput = True
        Else
            validarInput = False
        End If
    End Function


    Private Sub CargarTablaxDefectoExterna()
        TablaCarga = "EXTERNA"
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim DSbusqueda = bddatos.BusquedaCondiciones(2, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If DSbusqueda.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            DSbusqueda.Tables.Remove(DSbusqueda.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            DSbusqueda.Clear()
        End If
        CargarCorrespondenciaFiltro("E", DSbusqueda)
    End Sub


    Private Sub CargarTablaxDefectoPendientes()
        Dim TablaDocumentosPendientes As New DataTable("DOCUMENTOSPENDIENTES")
        TablaCarga = "PENDIENTES"
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim Cadena_Consulta As String =
                    "select case when TIPO='PAC' then  'Archivo Central' else 'Subir al Servidor' end as [Pendiente por Cumplir], [Persona Registro],TIPO,count(*) Cantidad from dbo.CorrespondenciaPendiente() group by [Persona Registro],TIPO  order by Cantidad desc"
        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Adaptador.FillSchema(TablaDocumentosPendientes, SchemaType.Source)
        Adaptador.Fill(TablaDocumentosPendientes)
        Consulta.Connection.Close()
        Me.DGV_ListaSisControl.DataSource = TablaDocumentosPendientes
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub CargarTablaxDefectoInterna()
        TablaCarga = "INTERNA"
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim DSbusqueda = bddatos.BusquedaCondiciones(3, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If DSbusqueda.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            DSbusqueda.Tables.Remove(DSbusqueda.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            DSbusqueda.Clear()
        End If
        CargarCorrespondenciaFiltro("I", DSbusqueda)
    End Sub


    Private Sub CargarTablaxDefectoFax()
        TablaCarga = "FAX"
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim DSbusqueda = bddatos.BusquedaCondiciones(4, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If DSbusqueda.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            DSbusqueda.Tables.Remove(DSbusqueda.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            DSbusqueda.Clear()
        End If
        CargarCorrespondenciaFiltro("F", DSbusqueda)
    End Sub


    Private Sub Nbi_BuscarCorreExterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BuscarCorreExterna.ItemClick
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("C.FECHACORRESPONDENCIAEXTERNA", "Fecha", "3")
        campos.Rows.Add("C.CONSECUTIVO", "Consecutivo", "2")
        campos.Rows.Add("C.EMPRESA", "Empresa", "1")
        campos.Rows.Add("C.DIRIGIDOA", "Dirigido a", "1")
        campos.Rows.Add("C.DIRECCIONENVIO", "Dirección Envío", "1")
        campos.Rows.Add("P.NOMBREPOBLACION", "Ciudad Envío", "1")
        campos.Rows.Add("C.ASUNTO", "Asunto", "1   ")
        campos.Rows.Add("MAC.CODIGOCENTROCOSTOSSOLIN", "Centro de Costo", "1")
        campos.Rows.Add("MAS.SUBCENTROCOSTOSSOLIN", "Subcentro de Costo", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(C.ELABORADOPOR)", "Elaborado Por", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(C.FIRMADO)", "Firmado Por", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(C.IDPERSONAREGISTRA)", "Registrado Por", "1")
        campos.Rows.Add("C.ABREVIATURA", "Abreviatura", "1")
        campos.Rows.Add("C.DOCUMENTO", "Documento", "1")
        campos.Rows.Add("SCD.NOMBREDEPENDENCIA", "Dependencia", "1")
        campos.Rows.Add("SCG.NOMBREGERENCIA", "Gerencia", "1")

        frbuscar.campos = campos
        frbuscar.tabla = 2
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarCorrespondenciaFiltro("E", DSbusqueda)
                Nbi_ExportarExterna.Enabled = True
            Else
                MsgBox("Ningún Registro Encontrado")
                Nbi_ExportarExterna.Enabled = False
            End If
        End If
    End Sub


    Private Sub CargarCorrespondenciaFiltro(ByVal tipo As String, ByVal DStabla As DataSet)
        Select Case tipo
            Case "E"
                TablaCarga = "EXTERNA"
            Case "I"
                TablaCarga = "INTERNA"
            Case "F"
                TablaCarga = "FAX"
        End Select
        Me.DGV_ListaSisControl.DataSource = Nothing
        Me.DGV_ListaSisControl.DataSource = DStabla.Tables(0).DefaultView
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True
        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "Año"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Año"
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Fecha Correspondencia"
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "Empresa"
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "Dirigido a "
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "Ciudad"
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "Asunto"
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "Elaborado Por"
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "Frimado Por"
                    DGV_ListaSisControl.Columns(i).Width = 0
                Case "Direcion de envio"
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "IDDEPENDENCIA"
                    DGV_ListaSisControl.Columns(i).Width = 1
                Case "ANULADA"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Anul"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Anulada"
                Case "ABREVIATURA"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Abre"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Abreviatura"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "DOCUMENTO"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Documento"
                    'Case "UBICADOSERVIDORARCHIVO"
                    '    DGV_ListaSisControl.Columns(i).Width = 40
                    '    DGV_ListaSisControl.Columns(i).HeaderText = "Ser"
                    '    DGV_ListaSisControl.Columns(i).ToolTipText = "Servidor"
                    '    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "SUBIDONUBE"
                    DGV_ListaSisControl.Columns(i).Width = 40
                    DGV_ListaSisControl.Columns(i).HeaderText = "Nube"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Nube"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "RECIBIDOARCHIVO"
                    DGV_ListaSisControl.Columns(i).Width = 40
                    DGV_ListaSisControl.Columns(i).HeaderText = "Ac"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Archivo Central"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "REVISADOARCHIVOSERVIDOR"
                    DGV_ListaSisControl.Columns(i).Width = 40
                    DGV_ListaSisControl.Columns(i).HeaderText = "Rser"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Revisada en el Servidor"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(1)
        End If
    End Sub


    Private Sub Nbi_BuscarCorreInterna_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BuscarCorreInterna.ItemClick
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripción")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("C.FECHACORRESPONDENCIAEXTERNA", "Fecha", "3")
        campos.Rows.Add("C.CONSECUTIVO", "Consecutivo", "2")
        campos.Rows.Add("C.EMPRESA", "Empresa", "1")
        campos.Rows.Add("C.DIRIGIDOA", "Dirigido a", "1")
        campos.Rows.Add("C.DIRECCIONENVIO", "Dirección Enví­o", "1")
        campos.Rows.Add("P.NOMBREPOBLACION", "Ciudad Enví­o", "1")
        campos.Rows.Add("C.ASUNTO", "Asunto", "1   ")
        campos.Rows.Add("MAC.CODIGOCENTROCOSTOSSOLIN", "Centro de Costo", "1")
        campos.Rows.Add("MAS.SUBCENTROCOSTOSSOLIN", "Subcentro de Costo", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(C.ELABORADOPOR)", "Elaborado Por", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(C.FIRMADO)", "Firmado Por", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(C.IDPERSONAREGISTRA)", "Registrado Por", "1")
        campos.Rows.Add("C.ABREVIATURA", "Abreviatura", "1")
        campos.Rows.Add("C.DOCUMENTO", "Documento", "1")
        campos.Rows.Add("SCD.NOMBREDEPENDENCIA", "Dependencia", "1")
        campos.Rows.Add("SCG.NOMBREGERENCIA", "Gerencia", "1")
        frbuscar.campos = campos
        frbuscar.tabla = 3
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarCorrespondenciaFiltro("I", DSbusqueda)
                Nbi_ExportarInterna.Enabled = True
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub


    Private Sub Nbi_BuscarFax_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BuscarFax.ItemClick
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripción")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("C.FECHACORRESPONDENCIAEXTERNA", "Fecha", "3")
        campos.Rows.Add("C.CONSECUTIVO", "Consecutivo", "2")
        campos.Rows.Add("C.EMPRESA", "Empresa", "1")
        campos.Rows.Add("C.DIRIGIDOA", "Dirigido a", "1")
        campos.Rows.Add("C.DIRECCIONENVIO", "Dirección Enví­o", "1")
        campos.Rows.Add("P.NOMBREPOBLACION", "Ciudad Enví­o", "1")
        campos.Rows.Add("C.ASUNTO", "Asunto", "1   ")
        campos.Rows.Add("MAC.CODIGOCENTROCOSTOSSOLIN", "Centro de Costo", "1")
        campos.Rows.Add("MAS.SUBCENTROCOSTOSSOLIN", "Subcentro de Costo", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(C.ELABORADOPOR)", "Elaborado Por", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(C.FIRMADO)", "Firmado Por", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(C.IDPERSONAREGISTRA)", "Registrado Por", "1")
        campos.Rows.Add("C.ABREVIATURA", "Abreviatura", "1")
        campos.Rows.Add("C.DOCUMENTO", "Documento", "1")
        campos.Rows.Add("SCD.NOMBREDEPENDENCIA", "Dependencia", "1")
        campos.Rows.Add("SCG.NOMBREGERENCIA", "Gerencia", "1")
        frbuscar.campos = campos
        frbuscar.tabla = 4
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarCorrespondenciaFiltro("F", DSbusqueda)
                Nbi_ExportarFax.Enabled = True
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub

#End Region 'Correspondencia

#Region "Sobre"
    'Dim SOBRETableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_SOBRETableAdapter
    'Dim DsSobre As New DatosSisControl.Ds_Siscontrol
    Private dtSobre As New DataTable

    Private Sub Nbi_CrearSobre_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearSobre.ItemClick
        Dim FrSobre As New FormulariosSisControl.Fr_Sobres
        FrSobre.CargarDatos()
        FrSobre.ShowDialog()
        CargarSobres()
    End Sub

    Private Sub Nbi_CargarSobres_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarSobres.ItemClick
        CargarSobres()
        OcultarPanelMiniatura()
        OcultarPanelDetalle()
    End Sub

    Private Sub CargarSobres()
        Nbi_ExportarSobres.Enabled = False
        TablaCarga = "SOBRE"
        Me.DGV_ListaSisControl.DataSource = Nothing
        dtSobre.Clear()
        'Me.SOBRETableAdapter.Fill(DsSobre.SC_SOBRE, 0, "x", -1, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        'Me.DGV_ListaSisControl.DataSource = Me.DsSobre.SC_SOBRE
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListaSobre(@ACCION,@TIPO,@VARIABLE, @IDBASE)", conexion)
        comando.Parameters.AddWithValue("@ACCION", 0)
        comando.Parameters.AddWithValue("@TIPO", "x")
        comando.Parameters.AddWithValue("@VARIABLE", -1)
        comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dtSobre)
            conexion.Close()

            Me.DGV_ListaSisControl.DataSource = dtSobre
            Me.DGV_ListaSisControl.AutoGenerateColumns = True
            Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.DGV_ListaSisControl.ReadOnly = True

            For i = 0 To DGV_ListaSisControl.ColumnCount - 1
                DGV_ListaSisControl.Columns(i).Visible = True
                Select Case DGV_ListaSisControl.Columns(i).Name
                    Case "Año"
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case "Consecutivo"
                        DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_ListaSisControl.Columns(i).HeaderText = "Conse"
                    Case "Entidad"
                        DGV_ListaSisControl.Columns(i).Width = 200
                        'DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Case "Dependencia De"
                        DGV_ListaSisControl.Columns(i).Width = 130
                        'DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Case "De"
                        DGV_ListaSisControl.Columns(i).Width = 220
                        'DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Case "Dependencia Para"
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Case "Para"
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Case "Asunto"
                        DGV_ListaSisControl.Columns(i).Width = 190
                    Case "IMPRESA"
                        DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_ListaSisControl.Columns(i).HeaderText = "Impr"
                    Case "ANULADA"
                        DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_ListaSisControl.Columns(i).HeaderText = "Anu"
                    Case "Fecha"
                        DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Case Else
                        DGV_ListaSisControl.Columns(i).Visible = False
                End Select
            Next
            If DGV_ListaSisControl.RowCount > 0 Then
                DGV_ListaSisControl.Rows(0).Selected = True
                DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(2)
            End If
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Nbi_EditarSobre_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarSobre.ItemClick
        If TablaCarga = "SOBRE" Then
            If VariablesBase.VariablesBase.IdPersona = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value Then
                EditarSobre()
            Else
                MsgBox("Solo puede editar la persona que registro", MsgBoxStyle.Critical, "ORDEN")
            End If
        Else
            MsgBox("Cargue sobres", MsgBoxStyle.Critical, "SOBRES")
        End If
    End Sub

    Private Sub EditarSobre()
        Dim FrSobre As New FormulariosSisControl.Fr_Sobres
        FrSobre.Editando = True
        FrSobre.IdSobre = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        ' FrSobre.Dependencia = Me.DGV_ListaSisControl.Item("IDDEPENDENCIA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
        FrSobre.CargarDatos()
        FrSobre.ShowDialog()
    End Sub

    Private Sub Nbi_ClonarSobre_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ClonarSobre.ItemClick
        If TablaCarga <> "SOBRE" Then
            MsgBox("Cargue sobres", MsgBoxStyle.Critical, "SOBRES")
            Exit Sub
        End If
        ClonarSobre()
    End Sub

    Private Sub ClonarSobre()
        Dim FrSobre As New FormulariosSisControl.Fr_Sobres
        FrSobre.Editando = True
        FrSobre.IdSobre = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        ' FrSobre.Dependencia = Me.DGV_ListaSisControl.Item("IDDEPENDENCIA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
        FrSobre.CargarDatos()
        FrSobre.Editando = False
        FrSobre.Lb_CódigoArtículo.Visible = False
        FrSobre.ShowDialog()
    End Sub

    Private Sub Nbi_VerSobre_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_VerSobre.ItemClick
        If TablaCarga = "SOBRE" Then
            VerSobre()
        Else
            MsgBox("Cargue sobres", MsgBoxStyle.Critical, "SOBRES")
        End If
    End Sub

    Private Sub VerSobre()
        Dim FrSobre As New FormulariosSisControl.Fr_Sobres
        FrSobre.Editando = True
        FrSobre.IdSobre = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrSobre.Bt_Guardar.Enabled = False
        FrSobre.CargarDatos()
        FrSobre.ShowDialog()
    End Sub

    Private Sub Nbi_ImprimirSobre_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ImprimirSobre.ItemClick
        If TablaCarga = "SOBRE" Then
            ImprimirSobre()
        Else
            MsgBox("Cargue sobres", MsgBoxStyle.Critical, "SOBRES")
        End If
    End Sub

    Private Sub ImprimirSobre()

        If Me.DGV_ListaSisControl.Item("IMPRESA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = "N" Then
            If MsgBox("¿Desea imprimir el sobre", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
                Dim Array As New ArrayList
                Array.Add(71)
                climpresiones.IdSOBRE = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
                climpresiones.FormatoImprimirSisControl(Array, True, False)
                MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
            End If
        Else
            'MsgBox("El sobre de Servicio No" + CStr(Me.DGV_ListaSisControl.Item("Consecutivo", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value) + " - " + CStr(Me.DGV_ListaSisControl.Item("Año", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value) + "  ya fue impresa", vbCritical, "Impresión Orden de Servicio")
            Exit Sub
        End If
    End Sub

    Private Sub Nbi_AnularSobre_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_AnularSobre.ItemClick
        If TablaCarga = "SOBRE" Then
            AnularSobre()
        Else
            MsgBox("Cargue sobres", MsgBoxStyle.Critical, "SOBRES")
        End If
    End Sub


    Private Sub AnularSobre()
        If MsgBox("¿Desea anular el sobre?", MsgBoxStyle.YesNo, "ANULAR") = MsgBoxResult.Yes Then
            Dim Dt_OrdenServicio As DataTable
            Dim Cadena_Consulta_Update As String = ""
            Dim FechaAnulado As String = CStr(Date.Now.Day) + "/" + CStr(Date.Now.Month) + "/" + CStr(Date.Now.Year) + " " + CStr(Date.Now.Hour) + ":" + CStr(Date.Now.Minute) + ":" + CStr(Date.Now.Second) + "." + CStr(Date.Now.Millisecond)
            Cadena_Consulta_Update = "UPDATE SC_SOBRE SET ANULADA = 'S' ,  IDPERSONAANULA =  " + CStr(VariablesBase.VariablesBase.IdPersona) + " , FECHAANULACION = '" + FechaAnulado + "' where IDSOBRE = " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_OrdenServicio = New DataTable
            Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
            Adaptador.Fill(Dt_OrdenServicio)
            Consulta.Connection.Close()
        End If
    End Sub

    Private Sub Nbi_BuscarSobre_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_BuscarSobre.ItemClick
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("Fecha", "Fecha", "3")
        campos.Rows.Add("Consecutivo", "Consecutivo", "2")
        campos.Rows.Add("[Dependencia De]", "DE Dependencia", "1")
        campos.Rows.Add("De", "DE funcionario", "1")
        campos.Rows.Add("CODIGOCENTROCOSTOSSOLIN", "DE Centro de Costo", "1")
        campos.Rows.Add("SUBCENTROCOSTOSSOLIN", "DE Subcentro de Costo", "1")
        campos.Rows.Add("Entidad", "PARA Entidad / Base", "1")
        campos.Rows.Add("PERSONAPARA", "PARA Funcionario", "1")
        campos.Rows.Add("CARGOPARA", "PARA Cargo", "1")
        'campos.Rows.Add("", "PARA Ciudad", "1")
        campos.Rows.Add("DIRECCIONPARA", "PARA Dirección", "1")
        campos.Rows.Add("Descripcion", "Descripción", "1")
        campos.Rows.Add("Trasportadora", "Empresa Despacho", "1")
        campos.Rows.Add("[No.Guia]", "Guía Despacho", "1")
        campos.Rows.Add("FECHADESPACHO", "Fecha Despacho", "3")
        'campos.Rows.Add("", "Fecha Devolución", "3")
        campos.Rows.Add("Firma", "Persona que Firma Devolución", "1")
        frbuscar.campos = campos
        frbuscar.tabla = 8
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarSobresFiltro(DSbusqueda)
                Nbi_ExportarSobres.Enabled = True
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub

    Private Sub CargarSobresFiltro(ByVal DsTabla As DataSet)
        TablaCarga = "SOBRE"
        Me.DGV_ListaSisControl.DataSource = Nothing
        Me.DGV_ListaSisControl.DataSource = DsTabla.Tables(0).DefaultView
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1

            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "Consecutivo"
                    DGV_ListaSisControl.Columns(i).Width = 50
                Case "Año"
                    DGV_ListaSisControl.Columns(i).Width = 50
                Case "Fecha"
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "Entidad"
                    DGV_ListaSisControl.Columns(i).Width = 200
                Case "Dependencia De"
                    DGV_ListaSisControl.Columns(i).Width = 200
                Case "De"
                    DGV_ListaSisControl.Columns(i).Width = 200
                Case "Dependencia Para"
                    DGV_ListaSisControl.Columns(i).Width = 190
                Case "Para"
                    DGV_ListaSisControl.Columns(i).Width = 190
                Case "Asunto"
                    DGV_ListaSisControl.Columns(i).Width = 190
                Case "IMPRESA"
                    DGV_ListaSisControl.Columns(i).Width = 50
                Case "ANULADA"
                    DGV_ListaSisControl.Columns(i).Width = 50
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(2)
        End If
    End Sub

#End Region 'Sobre

#Region "Cobro"
    'Dim CobroTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_CUENTACOBROTableAdapter
    'Dim DsCobro As New DatosSisControl.Ds_Siscontrol
    Private dtCobro As New DataTable

    Private Sub Nbi_CargarCobro_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarCobro.ItemClick
        CargarCobro(0)
        OcultarPanelMiniatura()
        OcultarPanelDetalle()
    End Sub

    Public Sub CargarCobro(ByVal Accion As Integer, Optional ByVal Varibela As String = "")



        'TablaCarga = "FAX"
        ' Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim DSbusqueda As New DataSet
        DSbusqueda = bddatos.BusquedaCondiciones(7, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If DSbusqueda.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            DSbusqueda.Tables.Remove(DSbusqueda.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            DSbusqueda.Clear()
        End If

        Nbi_ExportarCobro.Enabled = False
        Me.DGV_ListaSisControl.DataSource = Nothing
        '   Me.CobroTableAdapter.Fill(DsCobro.SC_CUENTACOBRO, Accion, Varibela, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        'Me.DGV_ListaSisControl.DataSource = Me.DsCobro.SC_CUENTACOBRO
        Me.DGV_ListaSisControl.DataSource = DSbusqueda.Tables(0)
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "Año"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Consecutivo"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Consecutivo"
                Case "Persona cobra"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "Persona Responsoble"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "valor"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Valor"
                Case "ANULADA"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Anulada"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        TablaCarga = "COBRO"

        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(2)
        End If
    End Sub

    Private Sub Nbi_CrearCobro_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearCobro.ItemClick
        CrearCobro()
    End Sub

    Private Sub CrearCobro()
        Dim FrCobro As New FormulariosSisControl.Fr_CuentaCobro
        FrCobro.CargarDatos()
        FrCobro.ShowDialog()
        CargarCobro(0)
    End Sub
    Private Sub Nbi_EditarCobro_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarCobro.ItemClick
        If TablaCarga = "COBRO" Then
            If VariablesBase.VariablesBase.IdPersona = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value Then
                EditarCobro()
            Else
                MsgBox("Solo puede editar la persona que registro", MsgBoxStyle.Critical, "ORDEN")
            End If

        Else
            MsgBox("Cargue Cuentas de cobro", MsgBoxStyle.Critical, "Cuenta Cobro")
        End If

    End Sub

    Private Sub EditarCobro()
        Dim FrCobro As New FormulariosSisControl.Fr_CuentaCobro
        FrCobro.IdCobro = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrCobro.Editando = True
        FrCobro.CargarDatos()
        FrCobro.ShowDialog()
    End Sub


    Private Sub Nbi_ClonarCobro_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ClonarCobro.ItemClick
        If TablaCarga <> "COBRO" Then
            MsgBox("Cargue Cuentas de cobro", MsgBoxStyle.Critical, "Cuenta Cobro")
            Exit Sub
        End If
        ClonarCobro()
    End Sub

    Private Sub ClonarCobro()
        Dim FrCobro As New FormulariosSisControl.Fr_CuentaCobro
        FrCobro.IdCobro = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrCobro.Editando = True
        FrCobro.CargarDatos()
        FrCobro.Editando = False
        FrCobro.Lb_Consecutivo.Visible = False
        FrCobro.ShowDialog()
    End Sub
    Private Sub Nbi_VerCobro_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_VerCobro.ItemClick
        If TablaCarga = "COBRO" Then
            VerCobro()
        Else
            MsgBox("Cargue Cuentas de cobro", MsgBoxStyle.Critical, "Cuenta Cobro")
        End If

    End Sub

    Private Sub VerCobro()

        Dim FrCobro As New FormulariosSisControl.Fr_CuentaCobro
        FrCobro.IdCobro = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrCobro.Editando = True
        FrCobro.CargarDatos()
        FrCobro.Bt_Guardar.Enabled = False
        FrCobro.ShowDialog()
    End Sub

    Private Sub Nbi_AnularCobro_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_AnularCobro.ItemClick

        If TablaCarga = "COBRO" Then
            AnularCobro()
        Else
            MsgBox("Cargue Cuentas de cobro", MsgBoxStyle.Critical, "Cuenta Cobro")
        End If
    End Sub

    Private Sub AnularCobro()
        If MsgBox("¿Desea anular la cuenta de cobro?", MsgBoxStyle.YesNo, "ANULAR") = MsgBoxResult.Yes Then
            Dim Dt_OrdenServicio As DataTable
            Dim Cadena_Consulta_Update As String = ""
            Dim FechaAnulado As String = CStr(Date.Now.Day) + "/" + CStr(Date.Now.Month) + "/" + CStr(Date.Now.Year) + " " + CStr(Date.Now.Hour) + ":" + CStr(Date.Now.Minute) + ":" + CStr(Date.Now.Second) + "." + CStr(Date.Now.Millisecond)
            Cadena_Consulta_Update = "UPDATE SC_CUENTACOBRO SET ANULADA = 'S' ,  IDPERSONAANULA =  " + CStr(VariablesBase.VariablesBase.IdPersona) + " , FECHAANULACION = '" + FechaAnulado + "' where IDCUENTACOBRO = " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_OrdenServicio = New DataTable
            Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
            Adaptador.Fill(Dt_OrdenServicio)
            Consulta.Connection.Close()
        End If
    End Sub

    Private Sub Nbi_BuscarCobro_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BuscarCobro.ItemClick
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("FECHACUENTACOBRO", "Fecha", "3")
        campos.Rows.Add("Consecutivo", "Consecutivo", "2")
        campos.Rows.Add("[Persona cobra]", "Nombre Persona Cobra", "1")
        campos.Rows.Add("Concepto", "Concepto", "1")
        campos.Rows.Add("valor", "Valor", "2")
        campos.Rows.Add("IVACUENTACOBRO", "Iva", "2")
        campos.Rows.Add("FECHAVECIMIENTO", "Fecha Vencimiento", "3")
        campos.Rows.Add("[Persona Responsoble]", "Responsable", "1")
        campos.Rows.Add("MAC.CODIGOCENTROCOSTOSSOLIN", "Centro de Costo", "1")
        campos.Rows.Add("MAS.SUBCENTROCOSTOSSOLIN", "Subcentro de Costo", "1")

        frbuscar.campos = campos
        frbuscar.tabla = 7
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarCobroBusqueda(DSbusqueda)
                Nbi_ExportarCobro.Enabled = True
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub

    Private Sub CargarCobroBusqueda(ByVal DsTabla As DataSet)
        Me.DGV_ListaSisControl.DataSource = Nothing
        Me.DGV_ListaSisControl.DataSource = DsTabla.Tables(0).DefaultView
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "Año"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Consecutivo"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Conse"
                Case "Persona cobra"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "Persona Responsoble"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "valor"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                Case "ANULADA"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Anu"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        TablaCarga = "COBRO"

        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(2)
        End If
    End Sub
#End Region 'Cobro

#Region "Documento Soporte"

    Private dtDocumentoEquivalente As New DataTable

    Private Sub Nbi_CargarDocumento_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarDocumento.ItemClick
        CargarDocumento()
        OcultarPanelMiniatura()
        OcultarPanelDetalle()
    End Sub

    Public Sub CargarDocumento()
        Cursor.Current = Cursors.WaitCursor
        dsDocumento = bddatos.BusquedaCondiciones(52, 1, 4, 1, "", 0, Date.Now, Date.Now, 0, 50)
        If dsDocumento.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
            dsDocumento.Tables.Remove(dsDocumento.Tables(0).TableName) 'Borrar la tabla del conteo.
        Else 'Si solo trae el conteo es porque se exceden los campos.
            MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dsDocumento.Clear()
        End If
        TablaCarga = "DOCUMENTO"
        DGV_ListaSisControl.DataSource = Nothing
        DGV_ListaSisControl.DataSource = dsDocumento.Tables(0)
        AplicarFormatoColumnas()
        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.ClearSelection()
            DGV_ListaSisControl.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default

    End Sub

    Public Sub AplicarFormatoColumnas()
        Nbi_ExportarCobro.Enabled = False
        Me.DGV_ListaSisControl.DataSource = Nothing
        Me.DGV_ListaSisControl.DataSource = dsDocumento.Tables(0)
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "Id"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Id"
                Case "Año"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Consecutivo"
                    DGV_ListaSisControl.Columns(i).Width = 70
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Cons. ISM"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Consecutivo ISM"
                Case "Consecutivo Ismocol"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Documento"
                Case "CONSECUTIVODIAN"
                    DGV_ListaSisControl.Columns(i).Width = 70
                    DGV_ListaSisControl.Columns(i).HeaderText = "Cons. DIAN"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Consecutivo DIAN"
                Case "Proveedor"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "Persona Responsable"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "Valor"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Valor"
                Case "APROBADO"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Aprobado"
                Case "Anulada"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Anulada"
                Case "AUTORIZADESCTSS"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Autoriza Dcto SS"
                Case "SERVIDOR"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Servidor"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        TablaCarga = "DOCUMENTO"

        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(2)
        End If
    End Sub


    Private Sub Nbi_CrearDocumento_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearDocumento.ItemClick
        CrearDocumento()
    End Sub

    Private Sub CrearDocumento()


        Dim FrDocumentoEquivalente As New FormulariosSisControl.Fr_DocumentoEquivalente
        FrDocumentoEquivalente.CargarTablas()
        If FrDocumentoEquivalente.Codigosdisponibles = 0 Then
            MsgBox("No hay consecutivos dian disponibles, Por favor revisar ", MsgBoxStyle.Critical, "CONSECUTIVOS DIAN")
        Else
            FrDocumentoEquivalente.ShowDialog()
            CargarDocumento()
        End If

    End Sub

    Private Sub Nbi_EditarDocumento_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarDocumento.ItemClick
        Try
            If TablaCarga = "DOCUMENTO" Then
                If VariablesBase.VariablesBase.IdPersona = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value Then
                    If Me.DGV_ListaSisControl.Item("Impresa", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = "N" Then
                        EditarDocumento()
                    Else
                        MsgBox("El documento " + Trim(Me.DGV_ListaSisControl.Item("Consecutivo Ismocol", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value) + " ya fue impreso y no se puede editar", vbCritical, "Documento Soporte")
                        Exit Sub
                    End If
                Else
                    MsgBox("Solo puede editar la persona que registro", MsgBoxStyle.Critical, "DOCUMENTO")
                End If
            Else
                MsgBox("Cargue Documentos Soporte ", MsgBoxStyle.Critical, "Documentos Soporte")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub EditarDocumento()
        Try
            Dim FrDocumentoEquivalente As New FormulariosSisControl.Fr_DocumentoEquivalente
            FrDocumentoEquivalente.IdDocumento = Me.DGV_ListaSisControl.SelectedRows(0).Cells("Id").Value
            FrDocumentoEquivalente.Editando = True
            FrDocumentoEquivalente.CargarTablas()
            FrDocumentoEquivalente.CargarDatosDocumento()
            FrDocumentoEquivalente.ShowDialog()
            If FrDocumentoEquivalente.Guardado Then
                Cargar_Tabla()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Nbi_VerDocumento_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerDocumento.ItemClick
        Try
            If TablaCarga = "DOCUMENTO" Then
                Dim FrDocumentoEquivalente As New Fr_DocumentoEquivalente
                FrDocumentoEquivalente.Editando = True
                FrDocumentoEquivalente.IdDocumento = DGV_ListaSisControl.SelectedRows(0).Cells("Id").Value
                FrDocumentoEquivalente.CargarTablas()
                FrDocumentoEquivalente.CargarDatosDocumento()
                FrDocumentoEquivalente.Bt_Guardar.Enabled = False
                FrDocumentoEquivalente.ShowDialog()
            Else
                MessageBox.Show("Cargue el listado de documento soporte")
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Nbi_AnularDocumento_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AnularDocumento.ItemClick
        Try
            If TablaCarga = "DOCUMENTO" Then
                If VariablesBase.VariablesBase.IdPersona = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value Then
                    AnularDocumento()
                Else
                    MsgBox("Solo puede anular la persona que registro", MsgBoxStyle.Critical, "DOCUMENTO")
                End If
            Else
                MsgBox("Cargue Documentos Soporte", MsgBoxStyle.Critical, "Documentos Soporte")
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub AnularDocumento()
        If MsgBox("¿Desea anular el Documento?", MsgBoxStyle.YesNo, "ANULAR") = MsgBoxResult.Yes Then
            Dim Dt_Documento As DataTable
            Dim Cadena_Consulta_Update As String = ""
            Dim FechaAnulado As String = CStr(Date.Now.Day) + "/" + CStr(Date.Now.Month) + "/" + CStr(Date.Now.Year) + " " + CStr(Date.Now.Hour) + ":" + CStr(Date.Now.Minute) + ":" + CStr(Date.Now.Second) + "." + CStr(Date.Now.Millisecond)
            Cadena_Consulta_Update = "UPDATE SC_DOCUMENTOEQUIVALENTE SET ANULADA = 'S' ,  IDPERSONAANULA =  " + CStr(VariablesBase.VariablesBase.IdPersona) + " , FECHAANULACION = '" + FechaAnulado + "' where IDDOCUMENTOEQUIVALENTE = " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_Documento = New DataTable
            Adaptador.FillSchema(Dt_Documento, SchemaType.Source)
            Adaptador.Fill(Dt_Documento)
            Consulta.Connection.Close()
        End If
        CargarDocumento()
    End Sub

    Private Sub Nbi_BuscarDocumento_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarDocumento.ItemClick
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("cast(FECHADOCUMENTOEQUIVALENTE as date)", "Fecha Documento", "3")
        campos.Rows.Add("CONSECUTIVODIAN", "Consecutivo Dian", "1")
        campos.Rows.Add("Consecutivo", "Consecutivo Ismocol", "2")
        campos.Rows.Add("NIT", "Nit del proveedor", "1")
        campos.Rows.Add("PROVEEDOR", "Proveedor", "1")
        campos.Rows.Add("Concepto", "Concepto", "1")
        campos.Rows.Add("VALORDOCUMENTOEQUIVALENTE", "Valor", "2")
        campos.Rows.Add("cast(FECHAVENCIMIENTO as date)", "Fecha Vencimiento", "3")
        campos.Rows.Add("dbo.Personanombrecompleto(DE.IDPERSONARESPONSABLEISMOCOL) ", "Responsable", "1")
        campos.Rows.Add("dbo.codigocompletosubcentro(DE.IDCENTROCOSTO)", "Centro de Costo", "1")

        frbuscar.campos = campos
        frbuscar.tabla = 52
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarDocumentoBusqueda(DSbusqueda)
                Nbi_ExportarCobro.Enabled = True
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub

    Private Sub CargarDocumentoBusqueda(ByVal dsDocumento As DataSet)
        Nbi_ExportarCobro.Enabled = False
        Me.DGV_ListaSisControl.DataSource = Nothing
        Me.DGV_ListaSisControl.DataSource = dsDocumento.Tables(0)
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "Id"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Id"
                Case "Año"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Consecutivo"
                    DGV_ListaSisControl.Columns(i).Width = 50
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Cons. ISM"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Consecutivo ISM"
                Case "Consecutivo Ismocol"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Documento"
                Case "CONSECUTIVODIAN"
                    DGV_ListaSisControl.Columns(i).Width = 50
                    DGV_ListaSisControl.Columns(i).HeaderText = "Cons. DIAN"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Consecutivo DIAN"
                Case "Proveedor"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "Persona Responsable"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "Valor"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Valor"
                Case "APROBADO"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Aprobado"
                Case "Anulada"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Anulada"
                Case "AUTORIZADESCTSS"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Autoriza Dcto SS"
                Case "SERVIDOR"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Servidor"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        TablaCarga = "DOCUMENTO"

        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(2)
        End If
    End Sub




    Private Sub nbi_ExportarBusquedaDocumento_ItemClick(sender As Object, e As EventArgs) Handles nbi_ExportarBusquedaDocumento.ItemClick
        If TablaCarga = "DOCUMENTO" Then
            ExportarBusqueda(DGV_ListaSisControl, "Documento Soporte")
        Else
            MsgBox("Cargue Documentos Soporte", MsgBoxStyle.Critical, "Documento Soporte")
        End If
    End Sub

    Private Sub Nbi_ClonarDocumento_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ClonarDocumento.ItemClick
        If TablaCarga <> "DOCUMENTO" Then
            MsgBox("Cargue Documentos Soporte", MsgBoxStyle.Critical, "Documentos Soporte")
            Exit Sub
        End If
        ClonarDocumento()
    End Sub

    Private Sub ClonarDocumento()
        Dim FrDocumentoEquivalente As New FormulariosSisControl.Fr_DocumentoEquivalente
        FrDocumentoEquivalente.IdDocumento = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrDocumentoEquivalente.Editando = True
        FrDocumentoEquivalente.CargarTablas()
        If FrDocumentoEquivalente.Codigosdisponibles = 0 Then
            MsgBox("No hay consecutivos dian disponibles, Por favor revisar ", MsgBoxStyle.Critical, "CONSECUTIVOS DIAN")
        Else
            FrDocumentoEquivalente.Editando = False
            FrDocumentoEquivalente.Lb_Consecutivo.Visible = False
            FrDocumentoEquivalente.CargarDatosDocumento()
            FrDocumentoEquivalente.Dtp_Fecha.Value = Date.Today
            FrDocumentoEquivalente.ShowDialog()
        End If
    End Sub

    Private Sub Nbi_Imprimir_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Imprimir.ItemClick
        If TablaCarga <> "DOCUMENTO" Then
            MsgBox("Cargue los documentos Soporte.", MsgBoxStyle.Critical, "Documento Soporte")
            Exit Sub
        End If

        If Me.DGV_ListaSisControl.Item("Impresa", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = "N" Then
            If MsgBox("¿Desea imprimir el documento", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
                Dim Array As New ArrayList
                Array.Add(80)
                climpresiones.idDocumento = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
                climpresiones.FormatoImprimirSisControl(Array, True, False)
                MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                CargarDocumento()
            End If
        Else
            MsgBox("El documento ya fue impreso", vbCritical, "Documento Soporte")
            Exit Sub
        End If

    End Sub

    Private Sub Nbi_Aprobar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Aprobar.ItemClick
        If DGV_ListaSisControl.SelectedRows.Count > 0 Then
            Select Case DGV_ListaSisControl.SelectedRows(0).Cells("APROBADO").Value 'Verificar que no este terminado o suspendido.
                Case "S"
                    MessageBox.Show("Este documento ya tiene aprobación")
                    Exit Sub
                Case Else
                    If MessageBox.Show("Se dara la aprobación del documento " & DGV_ListaSisControl.SelectedRows(0).Cells("Consecutivo Ismocol").Value & "." & Environment.NewLine & "¿Desea continuar?", "Aprobación Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                        AprobacionDocumento(DGV_ListaSisControl.SelectedRows(0).Cells("Id").Value)
                        DGV_ListaSisControl.Item("APROBADO", DGV_ListaSisControl.CurrentCell.RowIndex).Value = "S"
                        'Dim IdRequisicion As Integer
                        'IdRequisicion = DGV_ListaRequisiciones.SelectedRows(0).Cells("Id").Value
                        'Try
                        '    CorreoAElaboroRequisicion(IdRequisicion)
                        'Catch ex As Exception
                        '    MsgBox("No se envió notificación al correo, Verificar correo de la persona quien realizo la requisición", MsgBoxStyle.Information, "Requisición")
                        'End Try
                    End If
            End Select
        Else
            MessageBox.Show("Seleccione un documento para realizar la operación.", "Ningún documento seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Friend Sub AprobacionDocumento(idDS As Long)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.AprobacionDocumentoSoporte", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDDOCUMENTO", idDS)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error de conexión. No se pudo realizar la operación.", "Cambiar aprobación documento", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Nbi_HabilitarImpresion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HabilitarImpresion.ItemClick
        If TablaCarga <> "DOCUMENTO" Then
            MsgBox("Cargue el listado de documento soporte", MsgBoxStyle.Critical, "Documento Soporte")
            Exit Sub
        End If
        If MsgBox("¿Desea habilitar la impresión del documento soporte", MsgBoxStyle.YesNo, "Habilitar") = MsgBoxResult.Yes Then
            Dim Dt_OrdenServicio As DataTable
            Dim Cadena_Consulta_Update As String = ""
            Cadena_Consulta_Update = "update SC_DOCUMENTOEQUIVALENTE set IMPRESA = 'N' where IDDOCUMENTOEQUIVALENTE =  " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_OrdenServicio = New DataTable
            Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
            Adaptador.Fill(Dt_OrdenServicio)
            Consulta.Connection.Close()
            CargarDocumento()
        End If
    End Sub

#End Region 'Documento Soporte

#Region "Visitante"

    Private dtVisitante As New DataTable

    Private Sub Ngi_CrearVisitante_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ngi_CrearVisitante.ItemClick
        CrearVisitante()
        CargarVisitante(0)
    End Sub

    Private Sub CrearVisitante()
        Dim FrVisitante As New FormulariosSisControl.Fr_Visitante
        FrVisitante.Cargardatos()
        FrVisitante.ShowDialog()
    End Sub

    Private Sub Nbi_CargarVisitantes_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarVisitantes.ItemClick
        DGV_ListaSisControl.DataSource = Nothing
        CargarVisitante(0)
        MostrarPanelMiniatura()
        OcultarPanelDetalle()
    End Sub

    Private Sub CargarVisitante(ByVal ACCION As Integer, Optional ByVal VARIABLE As String = "")
        Nbi_ExportarVisitante.Enabled = False
        TablaCarga = "VISITANTE"
        dtVisitante.Clear()
        Me.DGV_ListaSisControl.DataSource = Nothing
        'Me.VisitanteTableAdapter.Fill(DsVisitante.SC_VISITANTE, ACCION, VARIABLE, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        'Me.DGV_ListaSisControl.DataSource = Me.DsVisitante.SC_VISITANTE

        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("SELECT * FROM dbo.ListaVisitante(@ACCION, @VARIABLE, @IDBASE)", conn)
        Comando.Parameters.AddWithValue("@ACCION", ACCION)
        Comando.Parameters.AddWithValue("@VARIABLE", VARIABLE)
        Comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Dim da As New SqlDataAdapter(Comando)
        conn.Open()
        da.Fill(dtVisitante)
        conn.Close()
        Me.DGV_ListaSisControl.DataSource = dtVisitante
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "IDVISITANTE"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Id Visitante"
                Case "Año"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Consecutivo"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Conse"
                Case "Empresa"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "Cedula"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "Nombre"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "ANULADA"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Anu"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next

        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(1)
        End If
    End Sub


    Private Sub Nbi_EditarVisitante_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarVisitante.ItemClick
        If TablaCarga = "VISITANTE" Then
            If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
                If VariablesBase.VariablesBase.IdPersona = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value Then
                    If ValidarSalidaVisitante(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value) Then
                        EditarVisitante()
                    Else
                        MsgBox("No se puede editar porque ya se registró la salida de la visita.", MsgBoxStyle.Exclamation, "NO SE PUEDE EDITAR")
                    End If
                Else
                    MsgBox("Solo puede editar la persona que registro", MsgBoxStyle.Critical, "ORDEN")
                End If
            End If
        Else
            MsgBox("Cargue visitantes", MsgBoxStyle.Critical, "Visitantes")
        End If
    End Sub

    Private Sub EditarVisitante()
        Dim FrVisitante As New FormulariosSisControl.Fr_Visitante
        FrVisitante.IdVisitante = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrVisitante.Editando = True
        FrVisitante.Cargardatos()
        FrVisitante.ShowDialog()
    End Sub

    Private Sub Nbi_ClonarVisitante_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ClonarVisitante.ItemClick
        If TablaCarga <> "VISITANTE" Then
            MsgBox("Cargue visitantes", MsgBoxStyle.Critical, "Visitantes")
            Exit Sub
        End If
        ClonarVisitante()
    End Sub

    Private Sub ClonarVisitante()
        Dim FrVisitante As New FormulariosSisControl.Fr_Visitante
        FrVisitante.IdVisitante = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrVisitante.Editando = True
        FrVisitante.Cargardatos()
        FrVisitante.Editando = False
        FrVisitante.Lb_ConsecutivoVisita.Visible = False
        FrVisitante.ShowDialog()
    End Sub

    Private Sub Nbi_VerVisitante_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_VerVisitante.ItemClick
        If TablaCarga = "VISITANTE" Then
            If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
                VerVisitante()
            End If
        Else
            MsgBox("Cargue visitantes", MsgBoxStyle.Critical, "Visitantes")
        End If
    End Sub

    Private Sub VerVisitante()
        Dim FrVisitante As New FormulariosSisControl.Fr_Visitante
        FrVisitante.IdVisitante = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrVisitante.Editando = True
        FrVisitante.Cargardatos()
        FrVisitante.Bt_Guardar.Enabled = False
        FrVisitante.Button_Cargar_Foto_Persona.Enabled = False
        FrVisitante.ShowDialog()
    End Sub

    Private Sub Nbi_AnularVisitante_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_AnularVisitante.ItemClick
        If TablaCarga = "VISITANTE" Then
            If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
                If ValidarSalidaVisitante(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value) Then
                    AnularVisitante()
                Else
                    MsgBox("No se puede anular porque ya se registró la salida de la visita.", MsgBoxStyle.Exclamation, "NO SE PUEDE ANULAR")
                End If
            End If
        Else
            MsgBox("Cargue visitantes", MsgBoxStyle.Critical, "Visitantes")
        End If
    End Sub

    Private Sub AnularVisitante()
        If MsgBox("¿Desea anular el visitante?", MsgBoxStyle.YesNo, "ANULAR") = MsgBoxResult.Yes Then
            Dim Dt_OrdenServicio As DataTable
            Dim Cadena_Consulta_Update As String = ""
            Dim FechaAnulado As String = CStr(Date.Now.Day) + "/" + CStr(Date.Now.Month) + "/" + CStr(Date.Now.Year) + " " + CStr(Date.Now.Hour) + ":" + CStr(Date.Now.Minute) + ":" + CStr(Date.Now.Second) + "." + CStr(Date.Now.Millisecond)
            Cadena_Consulta_Update = "UPDATE SC_VISITANTE SET ANULADA = 'S' ,  IDPERSONAANULA =  " + CStr(VariablesBase.VariablesBase.IdPersona) + " , FECHAANULACION = '" + FechaAnulado + "' where IDVISITANTE = " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_OrdenServicio = New DataTable
            Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
            Adaptador.Fill(Dt_OrdenServicio)
            Consulta.Connection.Close()
        End If
    End Sub

    Private Function ValidarSalidaVisitante(idVisitante As Integer) As Boolean
        Dim dt As New DataTable
        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("SELECT * FROM dbo.ListaVisitante(@ACCION, @VARIABLE, @IDBASE)", conn)
        Comando.Parameters.AddWithValue("@ACCION", 1)
        Comando.Parameters.AddWithValue("@VARIABLE", idVisitante)
        Comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Dim da As New SqlDataAdapter(Comando)
        conn.Open()
        da.Fill(dt)
        conn.Close()
        Return If(IsDBNull(dt.Rows(0)("FECHASALIDA")), True, False)
    End Function

    Private Sub Nbi_RegistrarSalida_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarSalida.ItemClick
        If TablaCarga = "VISITANTE" Then
            If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
                If MsgBox("¿Desea registrar la salida del visitante?", MsgBoxStyle.YesNo, "REGISTRAR SALIDA") = MsgBoxResult.Yes Then
                    Try
                        Dim Comando As New SqlCommand("GestionarVisita")
                        Comando.CommandType = CommandType.StoredProcedure
                        Comando.Parameters.AddWithValue("@TIPO", 4)
                        Comando.Parameters.AddWithValue("@IDVISITANTE", Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
                        Comando.Parameters.AddWithValue("@AÑO", "")
                        Comando.Parameters.AddWithValue("@CONSECUTIVO", 0)
                        Comando.Parameters.AddWithValue("@FECHAVISITA", DateTime.Now)
                        Comando.Parameters.AddWithValue("@EMPRESA", "")
                        Comando.Parameters.AddWithValue("@IDDEPENDENCIA", 0)
                        Comando.Parameters.AddWithValue("@IDPERSONAFUNCIONARIO", 0)
                        Comando.Parameters.AddWithValue("@CEDULA", "")
                        Comando.Parameters.AddWithValue("@NOMBRE", "")
                        Comando.Parameters.AddWithValue("@FECHAREGISTRO", DateTime.Now)
                        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRA", 0)
                        Comando.Parameters.AddWithValue("@FECHAMODIFICACION", DateTime.Now)
                        Comando.Parameters.AddWithValue("@IDPERSONAMODIFICA", 0)
                        Comando.Parameters.AddWithValue("@FECHAANULACION", DateTime.Now)
                        Comando.Parameters.AddWithValue("@IDPERSONAANULA", 0)
                        Comando.Parameters.AddWithValue("@ANULADA", "")
                        Comando.Parameters.AddWithValue("@IMPRESA", "")
                        Comando.Parameters.AddWithValue("@IDBASESISCONTROL", 0)
                        Comando.Parameters.AddWithValue("@EPS", "")
                        Comando.Parameters.AddWithValue("@VIOVIDEOSEGURIDAD", "")
                        Comando.Parameters.AddWithValue("@ACEPTOPOLITICADATOS", "")
                        Comando.Parameters.AddWithValue("@FECHASALIDA", DateTime.Now)
                        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRASALIDA", VariablesBase.VariablesBase.IdPersona)
                        Comando.Parameters.AddWithValue("@OBSERVACION", "")
                        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                        msgParam.Direction = ParameterDirection.Output
                        Comando.Parameters.Add(msgParam)
                        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
                        Comando.Connection = conn
                        conn.Open()
                        Comando.ExecuteNonQuery()
                        conn.Close()
                        MsgBox("Salida registrada.", MsgBoxStyle.OkOnly, "REGISTRAR SALIDA")
                    Catch ex As Exception
                        MsgBox("No se pudo registrar la salida.", MsgBoxStyle.Critical, "ERROR")
                    End Try
                End If
            End If
        Else
            MsgBox("Cargue visitantes", MsgBoxStyle.Critical, "Visitantes")
        End If
    End Sub

    Private Sub Nbi_ImprimirPolDatos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirPolDatos.ItemClick
        If TablaCarga = "VISITANTE" Then
            If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
                If MsgBox("¿Desea imprimir el formulario de la Política para el Tratamiento de Datos Personales de ISMOCOL S.A.?", MsgBoxStyle.YesNo, "IMPRIMIR POLÍTICA DE DATOS") = MsgBoxResult.Yes Then
                    Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
                    Dim Array As New ArrayList
                    Array.Add(75)
                    climpresiones.idVisitante = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
                    climpresiones.FormatoImprimirSisControl(Array, True, False)
                End If
            End If
        Else
            MsgBox("Cargue visitantes", MsgBoxStyle.Critical, "Visitantes")
        End If
    End Sub

    Private Sub Nbi_ImprimirStickerVisita_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirStickerVisita.ItemClick
        If TablaCarga = "VISITANTE" Then
            If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
                If MsgBox("¿Desea imprimir el Sticker de visitante?", MsgBoxStyle.YesNo, "IMPRIMIR STICKER VISITANTE") = MsgBoxResult.Yes Then
                    Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
                    Dim Array As New ArrayList
                    Array.Add(76)
                    climpresiones.idVisitante = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
                    climpresiones.FormatoImprimirSisControl(Array, True, False)
                End If
            End If
        Else
            MsgBox("Cargue visitantes", MsgBoxStyle.Critical, "Visitantes")
        End If
    End Sub

    Private Sub Nbi_BuscarVisitante_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BuscarVisitante.ItemClick
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripción")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("Fecha", "Fecha", "3")
        campos.Rows.Add("Consecutivo", "Consecutivo", "2")
        campos.Rows.Add("Cedula", "Identificación", "1")
        campos.Rows.Add("Nombre", "Visitante", "1")
        campos.Rows.Add("Empresa", "Empresa", "1")
        campos.Rows.Add("Dependencia", "Dependencia", "1")
        campos.Rows.Add("Funcionario", "Funcionario", "1")
        frbuscar.campos = campos
        frbuscar.tabla = 9
        Try
            frbuscar.ShowDialog()
            Dim DSbusqueda = frbuscar.DsBuscar
            If DSbusqueda.Tables.Count > 0 Then
                If DSbusqueda.Tables(0).Rows.Count > 0 Then
                    CargarVisitanteFiltro(DSbusqueda)
                    Nbi_ExportarVisitante.Enabled = True
                Else
                    MsgBox("Ningún Registro Encontrado")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarVisitanteFiltro(ByVal DsTabla As DataSet)
        TablaCarga = "VISITANTE"
        Me.DGV_ListaSisControl.DataSource = Nothing
        Me.DGV_ListaSisControl.DataSource = DsTabla.Tables(0).DefaultView
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "Año"
                    DGV_ListaSisControl.Columns(i).Width = 50
                Case "Consecutivo"
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "Empresa"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "Cedula"
                    DGV_ListaSisControl.Columns(i).Width = 150
                Case "Nombre"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "ANULADA"
                    DGV_ListaSisControl.Columns(i).Width = 50

                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next

        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(2)
        End If
    End Sub

    Private Sub MostrarPanelMiniatura()
        Sc_LateralDerecho.Panel2Collapsed = False
        Sc_LateralDerecho.Panel2.Show()
    End Sub

    Private Sub OcultarPanelMiniatura()
        Sc_LateralDerecho.Panel2Collapsed = True
        Sc_LateralDerecho.Panel2.Hide()
    End Sub
#End Region 'Visitante

#Region "Recepción"
    'Dim ResepcionTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_RECEPCIONTableAdapter
    'Dim DsResepcion As New DatosSisControl.Ds_Siscontrol
    Private dtRecepcion As New DataTable

    Private Sub Nbi_CargarRecepcion_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarRecepcion.ItemClick
        CargarRecepcion(0)
        'OcultarPanelMiniatura()
        'MostrarPanelDetalle()
    End Sub

    Private Sub CargarRecepcion(ByVal ACCION As Integer, Optional ByVal VARIABLE As String = "")
        Nbi_ExportarTablaRecepcion.Enabled = False
        TablaCarga = "RECEPCION"
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim DSbusqueda = bddatos.BusquedaCondiciones(1, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
        If DSbusqueda.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            DSbusqueda.Tables.Remove(DSbusqueda.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            DSbusqueda.Clear()
        End If
        Me.DGV_ListaSisControl.DataSource = DSbusqueda.Tables(0).DefaultView
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        AjustarFilasRecepcion()
    End Sub

    Private Sub AjustarFilasRecepcion()
        DGV_ListaSisControl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None
        DGV_ListaSisControl.ReadOnly = True
        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "Año"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Consecutivo"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Conse"
                Case "NOMBRETIPODOCUMENTO"
                    DGV_ListaSisControl.Columns(i).Width = 100
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).HeaderText = "Tipo"
                Case "STICKER"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Sticker"
                Case "DE"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "Radicado"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "Descripción"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "ANULADA"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Anu"
                Case "IMPRESA"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Impreso"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        OcultarPanelMiniatura()
        MostrarPanelDetalle()
    End Sub

    Private Sub Nbi_Corrresibida_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearRecepcion.ItemClick
        CrearRecepcion()
    End Sub

    Private Sub CrearRecepcion()
        Dim FrCorrespondenciarecibida As New FormulariosSisControl.Fr_CorrespondenciaRecibida
        FrCorrespondenciarecibida.Cargar_Datos(0)
        FrCorrespondenciarecibida.ShowDialog()
        CargarRecepcion(0)
    End Sub

    Private Sub Nbi_EditarRecepcion_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarRecepcion.ItemClick
        If TablaCarga = "RECEPCION" Then
            If DGV_ListaSisControl.SelectedRows(0).Cells("IMPRESA").Value = "N" Then
                If DGV_ListaSisControl.SelectedRows(0).Cells("IDPERSONAREGISTRA").Value = VariablesBase.VariablesBase.IdPersona Then
                    EditarRecepcion()
                Else
                    MsgBox("Solo puede editar la persona que registro", MsgBoxStyle.Exclamation, "Correspondencia Recibida")
                End If
            Else
                MsgBox("La correspondencia con consecutivo " & DGV_ListaSisControl.SelectedRows(0).Cells("Consecutivo").Value & " ya fue impresa.", MsgBoxStyle.Exclamation, "Correspondencia Recibida")
            End If
        Else
            MsgBox("Cargue Correspondencia Recibida", MsgBoxStyle.Exclamation, "Correspondencia Recibida")
        End If
    End Sub

    Private Sub EditarRecepcion()
        Dim FrCorrespondenciarecibida As New FormulariosSisControl.Fr_CorrespondenciaRecibida
        FrCorrespondenciarecibida.Editando = True
        FrCorrespondenciarecibida.IdCorrespondencia = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrCorrespondenciarecibida.Cargar_Datos(1, Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
        FrCorrespondenciarecibida.ShowDialog()
        CargarRecepcion(0)
    End Sub

    Private Sub Nbi_ClonarRecepcion_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ClonarRecepcion.ItemClick
        If TablaCarga <> "RECEPCION" Then
            MsgBox("Cargue Correspondencia Recibida", MsgBoxStyle.Critical, "Correspondencia Recibida")
            Exit Sub
        End If
        ClonarRecepcion()
    End Sub

    Private Sub ClonarRecepcion()
        Dim FrCorrespondenciarecibida As New FormulariosSisControl.Fr_CorrespondenciaRecibida
        FrCorrespondenciarecibida.Editando = True
        FrCorrespondenciarecibida.Clonar = True
        FrCorrespondenciarecibida.IdCorrespondencia = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrCorrespondenciarecibida.Cargar_Datos(1, Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
        FrCorrespondenciarecibida.Editando = False
        FrCorrespondenciarecibida.Lb_Estado.Visible = False
        FrCorrespondenciarecibida.ShowDialog()
        CargarRecepcion(0)
    End Sub

    Private Sub Nbi_VerRecepcion_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_VerRecepcion.ItemClick
        If TablaCarga <> "RECEPCION" Then
            MsgBox("Cargue Correspondencia Recibida", MsgBoxStyle.Critical, "Correspondencia Recibida")
            Exit Sub
        End If
        VerRecepcion()
    End Sub

    Private Sub VerRecepcion()
        Dim FrCorrespondenciarecibida As New FormulariosSisControl.Fr_CorrespondenciaRecibida
        FrCorrespondenciarecibida.Editando = True
        FrCorrespondenciarecibida.SoloLectura = True
        FrCorrespondenciarecibida.IdCorrespondencia = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
        FrCorrespondenciarecibida.Bt_Guardar.Enabled = False
        FrCorrespondenciarecibida.Cargar_Datos(1, Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)

        FrCorrespondenciarecibida.ShowDialog()
    End Sub

    Private Sub Nbi_AnularRecepcion_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_AnularRecepcion.ItemClick
        If TablaCarga = "RECEPCION" Then
            AnularRecepcion()
        Else
            MsgBox("Cargue recepción", MsgBoxStyle.Critical, "RECEPCIÓN")
        End If
    End Sub

    Private Sub AnularRecepcion()
        If MsgBox("¿Desea anular el registro? ", MsgBoxStyle.YesNo, "ANULAR") = MsgBoxResult.Yes Then
            Dim Dt_OrdenServicio As DataTable
            Dim Cadena_Consulta_Update As String = ""
            Dim FechaAnulado As String = CStr(Date.Now.Day) + "/" + CStr(Date.Now.Month) + "/" + CStr(Date.Now.Year) + " " + CStr(Date.Now.Hour) + ":" + CStr(Date.Now.Minute) + ":" + CStr(Date.Now.Second) + "." + CStr(Date.Now.Millisecond)
            Cadena_Consulta_Update = "UPDATE SC_RECEPCION SET ANULADA = 'S' ,  IDPERSONAANULA =  " + CStr(VariablesBase.VariablesBase.IdPersona) + " , FECHAANULACION = '" + FechaAnulado + "' where IDRECEPCION = " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_OrdenServicio = New DataTable
            Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
            Adaptador.Fill(Dt_OrdenServicio)
            Consulta.Connection.Close()
            CargarRecepcion(0)
        End If
    End Sub

    Private Sub Nbi_BuscarRecepcion_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BuscarRecepcion.ItemClick
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("R.FECHARECEPCION", "Fecha de Recepción", "3")
        campos.Rows.Add("R.CONSECUTIVO", "Consecutivo", "2")
        campos.Rows.Add("R.NIT", "Nit DE", "2")
        campos.Rows.Add("DE", "Nombre DE", "1")
        campos.Rows.Add("D.NOMBREDEPENDENCIA", "Para Dependencia", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(R.IDPERSONAFUNCIONARIO)", "Funcionario", "1")
        campos.Rows.Add("R.NRORADICADO", "Radicado", "2")
        campos.Rows.Add("R.DESCRIPCION", "Descripción", "1")
        campos.Rows.Add("R.NUMERODOCUMENTO", "Documento (Factura)", "1")
        campos.Rows.Add("R.FECHADOCUEMNTO", "Fecha Documento", "3")
        campos.Rows.Add("R.FECHAVENCIMIENTODOCUMENTO", "Fecha Vencimiento", "3")
        campos.Rows.Add("R.VALOR", "Valor", "2")
        campos.Rows.Add("R.MEMO", "Memo", "1")
        campos.Rows.Add("R.NUMERORELACION", "Relación", "2")
        campos.Rows.Add("S.NUMEROSTICKER", "Sticker (Número del código de barras)", "2")
        frbuscar.campos = campos
        frbuscar.tabla = 1
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda Is Nothing Then
            Exit Sub
        End If
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarBusqueda(DSbusqueda)
                Nbi_ExportarTablaRecepcion.Enabled = True
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub

    Private Sub CargarBusqueda(ByVal DStabla As DataSet)
        TablaCarga = "RECEPCION"
        Me.DGV_ListaSisControl.DataSource = DStabla.Tables(0).DefaultView
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        AjustarFilasRecepcion()
        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(1)
        End If
    End Sub

    'Private Sub BuscarRecepcion()
    'Dim Valor As String = InputBox("Digite el consecutivo de la correspondencia que desea buscar", "CORRESPONDENCIA", "")
    'If Trim(Valor) <> "" Then
    'If validarInput(Valor) = False Then
    'MsgBox("El Valor Debe Ser Numérico")
    'Exit Sub
    'End If
    'CargarRecepcion(2, Valor)
    'End If
    'End Sub

    Private Sub Nbi_ListaRecepcion_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ListaRecepcion.ItemClick
        Listado("R")
    End Sub

    Private Sub Nbi_RadicaFacturasFinanciero_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RadicaFacturasContabilidad.ItemClick
        RadicacionFacturas()
    End Sub

    Private Sub RadicacionFacturas()
        Dim frRadicacionFacturas As New Fr_RadicacionFacturasPrincipal
        frRadicacionFacturas.ShowDialog()
    End Sub

    Private Sub Nbi_HabilitarImpresionRecepcion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HabilitarImpresionRecepcion.ItemClick
        If TablaCarga <> "RECEPCION" Then
            MessageBox.Show("Cargue el listado de Recepción", "Correspondencia recibida en Recepción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MessageBox.Show("¿Desea habilitar la impresión del registro de Recepción?", "Habilitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("UPDATE SC_RECEPCION SET IMPRESA = 'N' WHERE IDRECEPCION = " + CStr(DGV_ListaSisControl.SelectedRows(0).Cells(0).Value), conexion)
            Try
                conexion.Open()
                comando.ExecuteNonQuery()
                conexion.Close()
                CargarRecepcion(0)
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        End If
    End Sub

    Private Sub Nbi_GenerarStickers_ItemClick(sender As Object, e As EventArgs) Handles Nbi_GenerarStickers.ItemClick
        Dim frGenerarStickers As New Fr_GenerarStickers
        frGenerarStickers.ShowDialog()
    End Sub

    Private Sub Nbi_ImprimirStickers_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirStickers.ItemClick
        Dim frImprimirStickers As New Fr_ImprimirStickers
        frImprimirStickers.ShowDialog()
    End Sub

    Private Sub Nbi_RecibirCodigoBarras_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RecibirStickers.ItemClick
        Dim frRecibirCodigoBarras As New Fr_RecibirStickers
        frRecibirCodigoBarras.ShowDialog()
    End Sub

    Private Sub Nbi_EnviarDocsDependencias_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EnviarDocsDependencias.ItemClick
        Dim frEnviarDocsDependencias As New Fr_EnviarDocsDependencias
        frEnviarDocsDependencias.ShowDialog()
    End Sub

    Private Sub Nbi_DevolverCorrespondenciaAlProveedor_ItemClick(sender As Object, e As EventArgs) Handles Nbi_DevolverCorrespondenciaAlProveedor.ItemClick
        Dim frEnviarATercero As New Fr_EnviarDocsATercero
        frEnviarATercero.ShowDialog()
    End Sub
#End Region 'Recepción

#Region "Dependencia"
    Private Sub Nbi_CambiarDependencia_ItemClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Nbi_AsociarDependencia_ItemClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Nbi_UsuarioDependencia_ItemClick(sender As Object, e As EventArgs)

    End Sub
#End Region 'Dependencia

#Region "Boleta de Salida"

    'Dim BoletaTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_BOLETASALIDATableAdapter
    'Dim DsBoleta As New DatosSisControl.Ds_Siscontrol
    Private dtBoletaSalida As New DataTable

    Private Sub Nbi_CrearBoleta_ItemClick(sender As Object, e As EventArgs)
        Dim FrBoletaSalida As New FormulariosSisControl.Fr_BoletaSalida
        FrBoletaSalida.CargarDatos()
        FrBoletaSalida.ShowDialog()
        CargarBoletaSalida()
    End Sub

    Dim dsCargar As New DataSet
    Public Sub CargarBoletaSalida()

        dsCargar = bddatos1.CargarMaestrasSiscontrol(10, VariablesBase.VariablesBase.IddependenciaSiscontrolActual, 0, 1)
        TablaCarga = "BOLETA"
        Me.DGV_ListaSisControl.DataSource = Nothing
        'Me.BoletaTableAdapter.FillBy(DsBoleta.SC_BOLETASALIDA, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        'Me.DGV_ListaSisControl.DataSource = Me.DsBoleta.SC_BOLETASALIDA
        Me.DGV_ListaSisControl.DataSource = Me.dsCargar.Tables(2)
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "Id"
                    DGV_ListaSisControl.Columns(i).Width = 50
                Case "Año"
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "Consecutivo"
                    DGV_ListaSisControl.Columns(i).Width = 50
                Case "Solicita"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "Hora Salida"
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "Hora Entrada"
                    DGV_ListaSisControl.Columns(i).Width = 100
                Case "ANULADA"
                    DGV_ListaSisControl.Columns(i).Width = 50
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next

        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(2)
        End If
    End Sub


    Public Sub EditarBoleta()
        'If TablaCarga <> "BOLETA" Then
        '    MsgBox("Debe Cargar Primero la Tabla de Boletas de Salida")
        '    Exit Sub
        'End If
        Dim FrBoletaSalida As New FormulariosSisControl.Fr_BoletaSalida
        FrBoletaSalida.Editando = True
        Dim idboleta As Integer
        idboleta = Me.DGV_ListaSisControl.Item("Id", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
        FrBoletaSalida.IdBoletaSalida = idboleta

        FrBoletaSalida.CargarDatos()
        FrBoletaSalida.ShowDialog()
    End Sub


    Public Sub ImprimirBoletaSalida()
        'If TablaCarga <> "BOLETA" Then
        '    MsgBox("Debe Cargar Primero la Tabla de Boletas de Salida")
        '    Exit Sub
        'End If
        'If Me.DGV_ListaSisControl.Item("IMPRESA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = "N" Then
        If MsgBox("¿Desea imprimir la Boleta de Salida?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
            Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
            Dim Array As New ArrayList
            Array.Add(74)
            climpresiones.IdBOLETASALIDA = Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value
            climpresiones.FormatoImprimirSisControl(Array, True, False)
            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESIÓN")
        End If
        'Else
        '    MsgBox("La Boleta de salida No" + CStr(Me.DGV_ListaSisControl.Item("Consecutivo", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value) + " - " + CStr(Me.DGV_ListaSisControl.Item("Año", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value) + "  ya fue impresa", vbCritical, "Impresión Orden de Servicio")
        '    Exit Sub
        'End If
    End Sub

#End Region 'Boleta Salida

#Region "Cambio de consecutivo"

    Private Sub Nbi_ConsecutivoExterno_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ConsecutivoExterno.ItemClick
        If TablaCarga = "EXTERNA" Then
            Dim Valor As String = InputBox("Digite el consecutivo de la correspondencia externa", "CORRESPONDENCIA EXTERNA", "")
            If Trim(Valor) <> "" Then
                If validarInput(Valor) = False Then
                    MsgBox("El Valor Debe Ser Numérico")
                    Exit Sub
                End If
                CambiarConsecutivo(1, Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value, Valor)
                CargarTablaxDefectoExterna()
            End If
        Else
            MsgBox("Cargue correspondencia externa", MsgBoxStyle.Critical, "EXTERNA")
        End If
    End Sub


    Private Sub Nbi_ConsecuticoI_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ConsecuticoI.ItemClick
        If TablaCarga = "INTERNA" Then
            Dim Valor As String = InputBox("Digite el consecutivo de la correspondencia interna", "CORRESPONDENCIA INTERNA", "")
            If Trim(Valor) <> "" Then
                If validarInput(Valor) = False Then
                    MsgBox("El Valor Debe Ser Numérico")
                    Exit Sub
                End If
                CambiarConsecutivo(1, Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value, Valor)
                '' CargarCorrespondencia("I", 0)
                CargarTablaxDefectoInterna()
            End If
        Else
            MsgBox("Cargue correspondencia interna", MsgBoxStyle.Critical, "INTERNA")
        End If
    End Sub


    Private Sub Nbi_ConsecutivoF_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ConsecutivoF.ItemClick
        If TablaCarga = "FAX" Then
            Dim Valor As String = InputBox("Digite el consecutivo del fax", "CORRESPONDENCIA FAX", "")
            If Trim(Valor) <> "" Then
                If validarInput(Valor) = False Then
                    MsgBox("El Valor Debe Ser Numérico")
                    Exit Sub
                End If
                CambiarConsecutivo(1, Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value, Valor)
                ''CargarCorrespondencia("F", 0)
                CargarTablaxDefectoFax()
            End If
        Else
            MsgBox("Cargue correspondencia fax", MsgBoxStyle.Critical, "FAX")
        End If
    End Sub


    Private Sub Nbi_ConsecutigoOrdenes_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ConsecutivoOrdenes.ItemClick
        If TablaCarga = "ORDENSERVICIO" Then
            Dim Valor As String = InputBox("Digite el consecutivo de la orden de servicio", "ORDEN SERVICIO", "")
            If Trim(Valor) <> "" Then
                If validarInput(Valor) = False Then
                    MsgBox("El Valor Debe Ser Numérico")
                    Exit Sub
                End If
                CambiarConsecutivo(2, Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value, Valor)
                CargarOrdenesServicio(0)
            End If
        Else
            MsgBox("Cargue orden de servicio", MsgBoxStyle.Critical, "ORDEN SERVICIO")
        End If
    End Sub


    Private Sub Nbi_consecutivoCobro_ItemClick(sender As Object, e As EventArgs) Handles Nbi_consecutivoCobro.ItemClick
        If TablaCarga = "COBRO" Then
            Dim Valor As String = InputBox("Digite el consecutivo del cobro", "COBRO", "")
            If Trim(Valor) <> "" Then
                If validarInput(Valor) = False Then
                    MsgBox("El Valor Debe Ser Numérico")
                    Exit Sub
                End If
                CambiarConsecutivo(3, Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value, Valor)
                CargarOrdenesServicio(0)
            End If
        Else
            MsgBox("Cargue Cobros", MsgBoxStyle.Critical, "COBRO")
        End If
    End Sub


    Private Sub CambiarConsecutivo(ByVal TIPO As Integer, ByVal ID As Integer, ByVal CONSECUTIVO As Integer)
        Dim Comando As New SqlClient.SqlCommand("dbo.Gestionar_SC_Consecutivo")
        Comando.CommandType = CommandType.StoredProcedure

        Comando.Parameters.AddWithValue("@TIPO", TIPO)
        Comando.Parameters.AddWithValue("@ID", ID)
        Comando.Parameters.AddWithValue("@CONSECUTIVO", CONSECUTIVO)
        Comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        If msgParam.Value = 1 Then
            MsgBox("Ya se encuentra registrado el consecutivo " + CStr(CONSECUTIVO), MsgBoxStyle.Critical, "CONSECUTIVO")
        End If
        conn.Close()
    End Sub

#End Region 'Cambio de consecutivo

#Region "Facturación Electrónica"

    ''' <summary>
    ''' Contiene el listado de aprobaciones cargado con las opciones listar y búsqueda.
    ''' </summary>
    Private dtAprobaciones As New DataTable("APROBACION")

    ''' <summary>
    ''' Contiene el listado de rechazos de aprobaciones cargado con la opción de búsqueda.
    ''' </summary>
    Private dtRechazos As New DataTable("RECHAZO")


    ' Listado inicial de aprobaciones.
    Private Sub Nbi_ListarAprobaciones_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ListarAprobaciones.ItemClick
        ListarAprobaciones()
    End Sub


    ''' <summary>
    ''' Carga el listado de las 50 aprobaciones más recientes.
    ''' </summary>
    Private Sub ListarAprobaciones()
        Dim DSbusqueda = bddatos.BusquedaCondiciones(31, 1, 4, 1, "", 0, Date.Now, Date.Now, 0, 50)
        If DSbusqueda.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            DSbusqueda.Tables.Remove(DSbusqueda.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            DSbusqueda.Clear()
        End If
        CargarAprobacionesFiltro(DSbusqueda)
    End Sub


    ''' <summary>
    ''' Ubica el listado cargado de aprobaciones en la rejilla y organiza las columnas.
    ''' </summary>
    ''' <param name="dsTabla">Listado de aprobaciones.</param>
    Private Sub CargarAprobacionesFiltro(dsTabla As DataSet)
        TablaCarga = "FE_APROBACION"
        DGV_ListaSisControl.DataSource = Nothing
        DGV_ListaSisControl.DataSource = dsTabla.Tables(0)
        DGV_ListaSisControl.AutoGenerateColumns = True
        DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DGV_ListaSisControl.ReadOnly = True
        Lb_Cantidad.Text = "Listado de Aprobaciones. " & dsTabla.Tables(0).Rows.Count & " registros cargados."
        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "APROBACION"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "No. Aprobación"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Número de Aprobación"
                Case "ABREVIATURABASE"
                    DGV_ListaSisControl.Columns(i).Width = 40
                    DGV_ListaSisControl.Columns(i).HeaderText = "Base"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Abreviatura de la Base"
                Case "NOMBREDEPENDENCIA"
                    DGV_ListaSisControl.Columns(i).Width = 100
                    DGV_ListaSisControl.Columns(i).HeaderText = "Dependencia"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Dependencia"
                Case "NIT"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).Width = 80
                    DGV_ListaSisControl.Columns(i).HeaderText = "NIT"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "NIT del Proveedor"
                Case "PROVEEDOR"
                    DGV_ListaSisControl.Columns(i).Width = 200
                    DGV_ListaSisControl.Columns(i).HeaderText = "Proveedor/Contratista"
                Case "PERSONAAPRUEBA"
                    DGV_ListaSisControl.Columns(i).Width = 200
                    DGV_ListaSisControl.Columns(i).HeaderText = "Aprueba"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Persona que aprueba el gasto"
                Case "VALORPESOS"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "c"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Valor"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Valor de la Factura Electrónica"
                Case "SIGLAISO"
                    DGV_ListaSisControl.Columns(i).Width = 55
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Moneda"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Tipo de moneda"
                Case "ACEPTADA"
                    DGV_ListaSisControl.Columns(i).Width = 70
                    DGV_ListaSisControl.Columns(i).HeaderText = "Aceptación"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Factura Electrónica aceptada"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    'Case "PERSONAACEPTA"
                    '    DGV_ListaSisControl.Columns(i).Width = 100
                    '    DGV_ListaSisControl.Columns(i).HeaderText = "Acepta"
                    '    DGV_ListaSisControl.Columns(i).ToolTipText = "Persona que Acepta la Factura Electrónica"
                Case "TIENERECHAZOS"
                    DGV_ListaSisControl.Columns(i).Width = 60
                    DGV_ListaSisControl.Columns(i).HeaderText = "Rechazos"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "La Factura Electrónica tiene rechazos"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    'Case "ANULADA"
                    '    DGV_ListaSisControl.Columns(i).Width = 100
                    '    DGV_ListaSisControl.Columns(i).HeaderText = "Anulada"
                    '    DGV_ListaSisControl.Columns(i).ToolTipText = "La aprobación está anulada"
                    'Case "PERSONAANULA"
                    '    DGV_ListaSisControl.Columns(i).Width = 100
                    '    DGV_ListaSisControl.Columns(i).HeaderText = "Anula"
                    '    DGV_ListaSisControl.Columns(i).ToolTipText = "Persona que anuló la Aprobación"
                Case "FACTURA"
                    DGV_ListaSisControl.Columns(i).Width = 100
                    DGV_ListaSisControl.Columns(i).HeaderText = "Factura"
                    DGV_ListaSisControl.Columns(i).ToolTipText = "Número de Factura Electrónica"
                Case "SUBIDOSERVIDORFACTURAPDF"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).Width = 30
                    DGV_ListaSisControl.Columns(i).HeaderText = "FP"
                    DGV_ListaSisControl.Columns(i).HeaderCell.ToolTipText = "Factura PDF subida al Servidor"
                Case "SUBIDOSERVIDORFACTURAXML"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).Width = 30
                    DGV_ListaSisControl.Columns(i).HeaderText = "FX"
                    DGV_ListaSisControl.Columns(i).HeaderCell.ToolTipText = "Factura XML subida al Servidor"
                Case "SUBIDOSERVIDORACUSEPDF"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).Width = 30
                    DGV_ListaSisControl.Columns(i).HeaderText = "AP"
                    DGV_ListaSisControl.Columns(i).HeaderCell.ToolTipText = "Acuse Recibo PDF subido al Servidor"
                Case "SUBIDOSERVIDORACUSEXML"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).Width = 30
                    DGV_ListaSisControl.Columns(i).HeaderText = "AX"
                    DGV_ListaSisControl.Columns(i).HeaderCell.ToolTipText = "Acuse Recibo XML subido al Servidor"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        DGV_ListaSisControl.Rows(0).Selected = True
    End Sub


    ' Abre la ventana de Aprobación para crear un nuevo registro.
    Private Sub Nbi_RegistrarAprobacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarAprobacion.ItemClick
        Using frFacturaElectronica As New Fr_FacturaElectronica
            frFacturaElectronica.Edicion = Fr_FacturaElectronica.TipoEdicion.Crear
            frFacturaElectronica.ShowDialog()
            If frFacturaElectronica.DialogResult = DialogResult.OK Then
                ListarAprobaciones()
            End If
        End Using
    End Sub


    ' Abre la ventana de Aprobación para visualizar la aprobación seleccionada.
    Private Sub Nbi_VerAprobacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerAprobacion.ItemClick
        If TablaCarga = "FE_APROBACION" Then
            If DGV_ListaSisControl.SelectedRows.Count > 0 Then
                Using frFacturaElectronica As New Fr_FacturaElectronica
                    frFacturaElectronica.SetIdAprobacion(DGV_ListaSisControl.SelectedRows(0).Cells("IDAPROBACION").Value)
                    frFacturaElectronica.Edicion = Fr_FacturaElectronica.TipoEdicion.Ver
                    frFacturaElectronica.ShowDialog()
                End Using
            Else
                MessageBox.Show("No se ha seleccionado ninguna fila.", "Ver Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se ha cargado el listado de Aprobaciones.", "Ver Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    ' Abre la ventana de Aprobación para modificar la aprobación seleccionada.
    Private Sub Nbi_EditarAprobacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarAprobacion.ItemClick
        If TablaCarga = "FE_APROBACION" Then
            If DGV_ListaSisControl.SelectedRows.Count > 0 Then
                If DGV_ListaSisControl.SelectedRows(0).Cells("ACEPTADA").Value <> "S" Then
                    If DGV_ListaSisControl.SelectedRows(0).Cells("TIENERECHAZOS").Value <> "S" Then
                        If DGV_ListaSisControl.SelectedRows(0).Cells("ANULADA").Value <> "S" Then
                            If DGV_ListaSisControl.SelectedRows(0).Cells("IDPERSONAREGISTRA").Value = VariablesBase.VariablesBase.IdPersona Then
                                Dim filaActual = DGV_ListaSisControl.SelectedRows(0).Index
                                Using frFacturaElectronica As New Fr_FacturaElectronica
                                    frFacturaElectronica.SetIdAprobacion(DGV_ListaSisControl.SelectedRows(0).Cells("IDAPROBACION").Value)
                                    frFacturaElectronica.Edicion = Fr_FacturaElectronica.TipoEdicion.Modificar
                                    frFacturaElectronica.ShowDialog()
                                    If frFacturaElectronica.DialogResult = DialogResult.OK Then
                                        ListarAprobaciones()
                                        UbicarRegistro(filaActual)
                                    End If
                                End Using
                            Else
                                MessageBox.Show("Sólo el usuario que registró puede editar la Aprobación.", "Editar Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        Else
                            MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " se encuentra anulada.", "Editar Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " ya cuenta con rechazo(s).", "Editar Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " ya tiene aceptación.", "Editar Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("No se ha seleccionado ninguna fila.", "Editar Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se ha cargado el listado de Aprobaciones.", "Editar Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    ' Marca la aprobación seleccionada como anulada.
    Private Sub Nbi_AnularAprobacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AnularAprobacion.ItemClick
        If TablaCarga = "FE_APROBACION" Then
            If DGV_ListaSisControl.SelectedRows.Count > 0 Then
                If DGV_ListaSisControl.SelectedRows(0).Cells("ACEPTADA").Value <> "S" Then
                    If DGV_ListaSisControl.SelectedRows(0).Cells("TIENERECHAZOS").Value <> "S" Then
                        If DGV_ListaSisControl.SelectedRows(0).Cells("ANULADA").Value <> "S" Then
                            If DGV_ListaSisControl.SelectedRows(0).Cells("IDPERSONAREGISTRA").Value = VariablesBase.VariablesBase.IdPersona Then
                                'If MessageBox.Show("¿Desea anular la aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & "?", "Anular Aprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Dim motivo As String = InputBox("Indique el motivo de la anulación de la aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & ":", "Anular Aprobación")
                                If Trim(motivo).Length > 0 Then
                                    Dim filaActual = DGV_ListaSisControl.SelectedRows(0).Index
                                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                                    Dim comando As New SqlCommand("dbo.CambiarEstadoSC_FE_Aprobacion", conexion)
                                    comando.CommandType = CommandType.StoredProcedure
                                    comando.Parameters.AddWithValue("@ACCION", 3) 'Anular
                                    comando.Parameters.AddWithValue("@IDAPROBACION", DGV_ListaSisControl.SelectedRows(0).Cells("IDAPROBACION").Value)
                                    comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                                    comando.Parameters.AddWithValue("@MOTIVO", motivo)
                                    Try
                                        conexion.Open()
                                        comando.ExecuteNonQuery()
                                        ListarAprobaciones()
                                        UbicarRegistro(filaActual)
                                    Catch ex As Exception
                                        MessageBox.Show(ex.Message, "Anular Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Finally
                                        conexion.Close()
                                    End Try
                                Else
                                    MessageBox.Show("Debe indicar el motivo de la anulación.", "Anular Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                            Else
                                MessageBox.Show("Sólo el usuario que registró puede anular la Aprobación.", "Anular Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        Else
                            MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " ya fue anulada.", "Anular Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " ya cuenta con rechazo(s).", "Anular Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " ya tiene aceptación.", "Anular Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("No se ha seleccionado ninguna fila.", "Anular Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se ha cargado el listado de Aprobaciones.", "Anular Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    ' Abre la ventana de búsqueda de aprobaciones.
    Private Sub Nbi_BuscarAprobacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarAprobacion.ItemClick
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")

        campos.Rows.Add("1", "Aprobaciones anuladas", "4") 'Búsqueda especial
        campos.Rows.Add("APROBACION", "No. Aprobación", "1")
        campos.Rows.Add("3", "Aprobaciones pendientes por gestionar", "4") 'Búsqueda especial
        campos.Rows.Add("PERSONAAPRUEBA", "Persona que aprueba", "1")
        campos.Rows.Add("NOMBREDEPENDENCIA", "Dependencia", "1")
        campos.Rows.Add("ABREVIATURABASE", "Abrev. de la Base", 1)
        campos.Rows.Add("6", "Nombre Proveedor", "7")
        campos.Rows.Add("REPLACE(NIT,'.', '')", "NIT del Proveedor / Contratista", "1")
        campos.Rows.Add("FECHAREGISTRO", "Fecha de registro", "3")
        campos.Rows.Add("PERSONAREGISTRA", "Persona que registra", "1")
        campos.Rows.Add("4", "Aprobaciones con aceptación", "4") 'Búsqueda especial
        campos.Rows.Add("FECHAACEPTACION", "Fecha de aceptación", "3")
        campos.Rows.Add("PERSONAACEPTA", "Persona que acepta", "1")
        campos.Rows.Add("FACTURA", "No. de Factura", "1")
        campos.Rows.Add("2", "Aprobaciones con rechazos", "4") 'Búsqueda especial
        campos.Rows.Add("FECHAANULACION", "Fecha de anulación", "3")
        campos.Rows.Add("PERSONAANULA", "Persona que anula", "1")
        campos.Rows.Add("DESCRIPCION", "Por Documento", "1")

        frbuscar.campos = campos
        frbuscar.tabla = 31 'Aprobaciones de Facturación Electrónica.
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If Not IsNothing(DSbusqueda) Then
            If DSbusqueda.Tables.Count > 0 Then
                If DSbusqueda.Tables(0).Rows.Count > 0 Then
                    CargarAprobacionesFiltro(DSbusqueda)
                Else
                    MsgBox("Ningún registro encontrado.", MsgBoxStyle.OkOnly, "Buscar Aprobaciones")
                End If
            End If
        Else
            MsgBox("Ningún registro encontrado.", MsgBoxStyle.OkOnly, "Buscar Aprobaciones")
        End If
    End Sub

    Private Sub Nbi_Clonar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Clonar.ItemClick
        If TablaCarga <> "FE_APROBACION" Then
            MsgBox("Listar Aprobaciones Facturación Electronica", MsgBoxStyle.Critical, "Facturación Electronica")
            Exit Sub
        End If
        ClonarFE()
    End Sub

    Private Sub ClonarFE()
        Dim FrFE As New FormulariosSisControl.Fr_FacturaElectronica
        FrFE.SetIdAprobacion(DGV_ListaSisControl.SelectedRows(0).Cells("IDAPROBACION").Value)
        FrFE.Edicion = Fr_FacturaElectronica.TipoEdicion.Clonar
        FrFE.ShowDialog()
        ListarAprobaciones()
    End Sub

    ' Abre el cuadro de registro de aceptación para la aprobación seleccionada.
    ' El cuadro cuenta con una caja de texto para ingresar el número de la factura electrónica.
    Private Sub Nbi_RegistrarAceptacion_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarAceptacion.ItemClick
        If TablaCarga = "FE_APROBACION" Then
            If DGV_ListaSisControl.SelectedRows.Count > 0 Then
                If DGV_ListaSisControl.SelectedRows(0).Cells("ACEPTADA").Value <> "S" Then
                    If DGV_ListaSisControl.SelectedRows(0).Cells("ANULADA").Value <> "S" Then
                        Dim motivo As String = InputBox("Indique el número de la factura aceptada para la aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & ":", "Registrar Aceptación")
                        If Trim(motivo).Length > 0 Then
                            Dim filaActual = DGV_ListaSisControl.SelectedRows(0).Index
                            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                            Dim comando As New SqlCommand("dbo.CambiarEstadoSC_FE_Aprobacion", conexion)
                            comando.CommandType = CommandType.StoredProcedure
                            comando.Parameters.AddWithValue("@ACCION", 1) 'Registrar Aceptación
                            comando.Parameters.AddWithValue("@IDAPROBACION", DGV_ListaSisControl.SelectedRows(0).Cells("IDAPROBACION").Value)
                            comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                            comando.Parameters.AddWithValue("@MOTIVO", motivo) 'Factura
                            Try
                                conexion.Open()
                                comando.ExecuteNonQuery()
                                ListarAprobaciones()
                                UbicarRegistro(filaActual)
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Registrar Aceptación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally
                                conexion.Close()
                            End Try
                        Else
                            MessageBox.Show("Debe indicar el número de la factura aceptada.", "Registrar Aceptación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " se encuentra anulada.", "Registrar Aceptación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " ya tiene aceptación.", "Registrar Aceptación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("No se ha seleccionado ninguna fila.", "Registrar Aceptación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se ha cargado el listado de Aprobaciones.", "Registrar Aceptación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    ' Abre el cuadro de rechazo de aprobación.
    Private Sub Nbi_RegistrarRechazo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarRechazo.ItemClick
        If TablaCarga = "FE_APROBACION" Then
            If DGV_ListaSisControl.SelectedRows.Count > 0 Then
                If DGV_ListaSisControl.SelectedRows(0).Cells("ACEPTADA").Value <> "S" Then
                    If DGV_ListaSisControl.SelectedRows(0).Cells("ANULADA").Value <> "S" Then
                        Dim motivo As String = InputBox("Indique el motivo del rechazo de la factura electrónica de la aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & ":", "Registrar Rechazo de Aprobación")
                        If Trim(motivo).Length > 0 Then
                            Dim filaActual = DGV_ListaSisControl.SelectedRows(0).Index
                            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                            Dim comando As New SqlCommand("dbo.CambiarEstadoSC_FE_Aprobacion", conexion)
                            comando.CommandType = CommandType.StoredProcedure
                            comando.Parameters.AddWithValue("@ACCION", 2) 'Registrar Rechazo
                            comando.Parameters.AddWithValue("@IDAPROBACION", DGV_ListaSisControl.SelectedRows(0).Cells("IDAPROBACION").Value)
                            comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                            comando.Parameters.AddWithValue("@MOTIVO", motivo)
                            Try
                                conexion.Open()
                                comando.ExecuteNonQuery()
                                ListarAprobaciones()
                                UbicarRegistro(filaActual)
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Registrar Rechazo de Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally
                                conexion.Close()
                            End Try
                        Else
                            MessageBox.Show("Debe indicar el motivo del rechazo.", "Registrar Rechazo de Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " se encuentra anulada.", "Registrar Rechazo de Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " ya tiene aceptación.", "Registrar Rechazo de Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("No se ha seleccionado ninguna fila.", "Registrar Rechazo de Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se ha cargado el listado de Aprobaciones.", "Registrar Rechazo de Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    ' Abre la ventana de carga de archivos de factura electrónica para subir al servidos los archivos .pdf y .xml de la factura electrónica y el acuse de recibo.
    Private Sub Nbi_SubirArchivosFE_ItemClick(sender As Object, e As EventArgs) Handles Nbi_SubirArchivosFE.ItemClick
        If TablaCarga = "FE_APROBACION" Then
            If DGV_ListaSisControl.SelectedRows.Count > 0 Then
                If DGV_ListaSisControl.SelectedRows(0).Cells("ANULADA").Value <> "S" Then
                    If DGV_ListaSisControl.SelectedRows(0).Cells("ACEPTADA").Value = "S" Then
                        'If FuncionesBase.FuncionesBase.ServidorArchivosDisponible(FuncionesBase.FuncionesBase.TipoServidorArchivos.Correspondencia) Then
                        Dim filaActual = DGV_ListaSisControl.SelectedRows(0).Index
                        Using frSubirArchivosFE As New Fr_SubirArchivosFacturaElectronica
                            frSubirArchivosFE.IdAprobacion = DGV_ListaSisControl.SelectedRows(0).Cells("IDAPROBACION").Value
                            frSubirArchivosFE.NumeroAprobacion = DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value
                            If frSubirArchivosFE.ShowDialog() = DialogResult.OK Then
                                ListarAprobaciones()
                                UbicarRegistro(filaActual)
                            End If
                        End Using
                        'Else
                        'MessageBox.Show("El servidor de archivos no se encuentra disponible, por favor póngase en contacto con el personal de soporte técnico para configurar la conexión.", "Servidor no disponible", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'End If
                    Else
                        MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " no ha sido aceptada.", "Subir Archivos de Factura Electrónica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("La aprobación " & DGV_ListaSisControl.SelectedRows(0).Cells("APROBACION").Value & " se encuentra anulada.", "Subir Archivos de Factura Electrónica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("No se ha seleccionado ninguna fila.", "Subir Archivos de Factura Electrónica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se ha cargado el listado de Aprobaciones.", "Subir Archivos de Factura Electrónica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    ' Envía un correo electrónico a cada usuario que registró aprobaciones de las cuales no se ha recibido factura electrónica a la fecha.
    Private Sub Nbi_CorreosAprobPendxFE_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CorreosAprobPendxFE.ItemClick
        If MessageBox.Show("¿Desea enviar los correos de notificación en bloque?", "Enviar correos Aprobaciones pendientes por Factura Electrónica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                EnviarCorreosAprobPendxFE()
                'MessageBox.Show("Correos enviados correctamente.", "Enviar correos Pendientes por Factura Electrónica", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub


    ''' <summary>
    ''' Enviar correos de Aprobaciones pendientes por Factura electrónica y resumen a la dirección de correo de recepción de FE.
    ''' </summary>
    Private Sub EnviarCorreosAprobPendxFE()
        Cursor = Cursors.WaitCursor

        'IMPLEMENTAR

        Dim tablaUsuarios As DataTable
        Dim tablaUsuariosAprueba As DataTable
        Dim tablaDocumentos As DataTable
        Dim tablaDocumentosContabilidad As DataTable
        Dim tablaResumen As DataTable
        Dim tablaResumenContabilidad As DataTable

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand
        comando.Connection = conexion
        comando.CommandText = "SELECT * FROM AprobacionesPendientes() ORDER BY APROBACION ASC"
        Dim adaptador As New SqlDataAdapter(comando)
        tablaDocumentos = New DataTable()
        comando.Connection.Open()
        adaptador.Fill(tablaDocumentos)
        comando.Connection.Close()

        tablaUsuarios = tablaDocumentos.DefaultView.ToTable(True, "IDPERSONAREGISTRA")

        tablaResumen = New DataTable
        tablaResumen.Columns.Add("DEPENDENCIA")
        tablaResumen.Columns.Add("TIPOAPROBACION")
        tablaResumen.Columns.Add("MONEDA")
        tablaResumen.Columns.Add("NUMAPROBACIONES")
        tablaResumen.Columns.Add("TOTAL")
        Dim query = From row In tablaDocumentos.AsEnumerable()
            Group row By grupoResumen = New With {
                Key .Dependencia = row.Field(Of String)("NOMBREDEPENDENCIA"),
                Key .TipoAprobacion = row.Field(Of String)("NOMBRETIPOAPROBACION"),
                Key .Moneda = row.Field(Of String)("SIGLAISO")
            } Into Group
            Select New With {
                Key .Resumen = grupoResumen,
                .Conteo = Group.Count(Function(x) x.Field(Of String)("APROBACION")),
                .Total = Group.Sum(Function(x) x.Field(Of Decimal)("VALOR"))
            }
        For Each x In query
            tablaResumen.Rows.Add(x.Resumen.Dependencia, x.Resumen.TipoAprobacion, x.Resumen.Moneda, x.Conteo, x.Total)
        Next

        Dim cuerpo As New StringBuilder
        Dim ni As New NotifyIcon
        AddHandler ni.BalloonTipClosed, Sub()
                                            ni.Visible = False
                                            ni.Dispose()
                                        End Sub
        ni.Icon = SystemIcons.Application
        ni.BalloonTipTitle = "Envío de correos SIGMA"
        ni.Text = "Envío de correos SIGMA"
        ni.Visible = True



        For i As Integer = 0 To tablaUsuarios.Rows.Count - 1
            Dim FilaUsuario As DataRow
            FilaUsuario = tablaUsuarios.Rows(i)
            Dim filasDocumentosPendientes As DataRow()
            filasDocumentosPendientes = tablaDocumentos.Select("IDPERSONAREGISTRA=" & FilaUsuario("IDPERSONAREGISTRA").ToString)
            Dim filasDocumentosPendientesReferencia As DataRow
            filasDocumentosPendientesReferencia = filasDocumentosPendientes(0)
            Try
                'crear cuerpo
                cuerpo.AppendLine("<center>")
                cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
                cuerpo.AppendLine("<table style='width:100%;'>")
                cuerpo.AppendLine("    <tr style='border:1px solid;'>")
                cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
                cuerpo.AppendLine("        <td>" & "FACTURACIÓN ELECTRÓNICA" & "<br/>")
                cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br/>")
                cuerpo.AppendLine(Date.Now.ToString) 'fecha actual
                cuerpo.AppendLine("        </td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("</table>")
                cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td><b>Nombre del Empleado:</b></td>")
                cuerpo.AppendLine("        <td colspan='10' >" & filasDocumentosPendientesReferencia("PERSONAREGISTRA") & "</td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td colspan='11' style='text-align:center; background-color:silver;'><b>" & "APROBACIONES PENDIENTES POR RECIBO DE FACTURA ELECTRÓNICA" & "</b></td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>APROBACIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DEPENDENCIA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>TIPO DE APROBACIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>NIT</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PROVEEDOR</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DESCRIPCIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>APRUEBA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>VALOR</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>MONEDA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>FECHA REGISTRO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PERSONA REGISTRÓ</td>")
                cuerpo.AppendLine("    </tr>")

                For nrodocumentopendiente = 0 To filasDocumentosPendientes.Count - 1
                    Dim filaDocumentosPendientes As DataRow
                    filaDocumentosPendientes = filasDocumentosPendientes(nrodocumentopendiente)
                    cuerpo.AppendLine("    <tr>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("APROBACION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NOMBREDEPENDENCIA") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NOMBRETIPOAPROBACION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NIT") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PROVEEDOR") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("DESCRIPCION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PERSONAAPRUEBA") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("VALOR") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("SIGLAISO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("FECHAREGISTRO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PERSONAREGISTRA") & "</td>")
                    cuerpo.AppendLine("    </tr>")
                Next

                cuerpo.AppendLine("</table><hr style='border-style:groove;'/>")
                cuerpo.AppendLine("<p style='text-align:left;'>DIGITA - ENVÍO DE RELACIÓN DE APROBACIONES PENDIENTES POR RECIBO DE FACTURA ELECTRÓNICA.")
                cuerpo.AppendLine("ESTE CORREO FUE ENVIADO AUTOMATICAMENTE, POR FAVOR NO LO CONTESTE. ANTE CUALQUIER INQUIETUD POR FAVOR REMÍTASE A LA PERSONA ENCARGADA DE RECEPCIÓN DE FACTURACIÓN ELECTRÓNICA</p>")

                FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Aprobaciones pendientes por recibo de factura electrónica, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoCorrespondencia, filasDocumentosPendientesReferencia("CORREO"), Nothing, False, "")

                cuerpo.Clear()
                ni.BalloonTipText = i & " de " & tablaUsuarios.Rows.Count - 1 & " correos enviados."
                ni.BalloonTipIcon = ToolTipIcon.Info
                ni.ShowBalloonTip(500)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        'Enviar correos a los que aprueban el gasto
        cuerpo.Clear()
        tablaUsuarios.Clear()
        tablaUsuarios = tablaDocumentos.DefaultView.ToTable(True, "IDPERSONAAPRUEBA")

   
        For i As Integer = 0 To tablaUsuarios.Rows.Count - 1
            Dim FilaUsuario As DataRow
            FilaUsuario = tablaUsuarios.Rows(i)
            Dim filasDocumentosPendientes As DataRow()
            filasDocumentosPendientes = tablaDocumentos.Select("IDPERSONAAPRUEBA=" & FilaUsuario("IDPERSONAAPRUEBA").ToString)
            Dim filasDocumentosPendientesReferencia As DataRow
            filasDocumentosPendientesReferencia = filasDocumentosPendientes(0)
            Try
                'crear cuerpo
                cuerpo.AppendLine("<center>")
                cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
                cuerpo.AppendLine("<table style='width:100%;'>")
                cuerpo.AppendLine("    <tr style='border:1px solid;'>")
                cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
                cuerpo.AppendLine("        <td>" & "FACTURACIÓN ELECTRÓNICA" & "<br/>")
                cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br/>")
                cuerpo.AppendLine(Date.Now.ToString) 'fecha actual
                cuerpo.AppendLine("        </td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("</table>")
                cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td><b>Nombre del Empleado:</b></td>")
                cuerpo.AppendLine("        <td colspan='10' >" & filasDocumentosPendientesReferencia("PERSONAAPRUEBA") & "</td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td colspan='11' style='text-align:center; background-color:silver;'><b>" & "APROBACIONES PENDIENTES POR RECIBO DE FACTURA ELECTRÓNICA" & "</b></td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>APROBACIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DEPENDENCIA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>TIPO DE APROBACIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>NIT</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PROVEEDOR</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DESCRIPCIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>APRUEBA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>VALOR</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>MONEDA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>FECHA REGISTRO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PERSONA REGISTRÓ</td>")
                cuerpo.AppendLine("    </tr>")

                For nrodocumentopendiente = 0 To filasDocumentosPendientes.Count - 1
                    Dim filaDocumentosPendientes As DataRow
                    filaDocumentosPendientes = filasDocumentosPendientes(nrodocumentopendiente)
                    cuerpo.AppendLine("    <tr>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("APROBACION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NOMBREDEPENDENCIA") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NOMBRETIPOAPROBACION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NIT") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PROVEEDOR") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("DESCRIPCION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PERSONAAPRUEBA") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("VALOR") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("SIGLAISO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("FECHAREGISTRO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PERSONAREGISTRA") & "</td>")
                    cuerpo.AppendLine("    </tr>")
                Next

                cuerpo.AppendLine("</table><hr style='border-style:groove;'/>")
                cuerpo.AppendLine("<p style='text-align:left;'>APRUEBA - ENVÍO DE RELACIÓN DE SUS APROBACIONES PENDIENTES POR RECIBO DE FACTURA ELECTRÓNICA.")
                cuerpo.AppendLine("ESTE CORREO FUE ENVIADO AUTOMATICAMENTE, POR FAVOR NO LO CONTESTE. ANTE CUALQUIER INQUIETUD POR FAVOR REMÍTASE A LA PERSONA ENCARGADA DE RECEPCIÓN DE FACTURACIÓN ELECTRÓNICA</p>")

                FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Aprobaciones pendientes por recibo de factura electrónica, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoCorrespondencia, filasDocumentosPendientesReferencia("CORREOAPRUEBA"), Nothing, False, "")

                cuerpo.Clear()
                ni.BalloonTipText = i & " de " & tablaUsuarios.Rows.Count - 1 & " correos enviados."
                ni.BalloonTipIcon = ToolTipIcon.Info
                ni.ShowBalloonTip(500)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next



        'Resumen para Receptor de Factura.
        cuerpo.Clear()
        Try
            cuerpo.AppendLine("<center>")
            cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
            cuerpo.AppendLine("<table style ='width:100%;'>")
            cuerpo.AppendLine("    <tr style='border:1px solid;'>")
            cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
            cuerpo.AppendLine("        <td>" & "FACTURACIÓN ELECTRÓNICA" & "<br />")
            cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br />")
            cuerpo.AppendLine(Date.Now.ToString)
            cuerpo.AppendLine("        </td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("</table>")

            cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td colspan='6' style='text-align:center; background-color:silver;'><b>" & "RESUMEN DE APROBACIONES PENDIENTES POR RECIBO DE FACTURA ELECTRÓNICA" & "</b></td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DEPENDENCIA</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>TIPO DE APROBACIÓN</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>MONEDA</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>NÚM. APROBACIONES</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>TOTAL</td>")
            cuerpo.AppendLine("    </tr>")
            For nrodocumentopendiente = 0 To tablaResumen.Rows.Count - 1
                Dim filaResumenPendientes As DataRow
                filaResumenPendientes = tablaResumen(nrodocumentopendiente)
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("DEPENDENCIA") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("TIPOAPROBACION") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("MONEDA") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("NUMAPROBACIONES") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("TOTAL") & "</td>")
                cuerpo.AppendLine("    </tr>")
            Next
            'cuerpo.AppendLine("    <tr>")
            'cuerpo.AppendLine("        <td colspan='2' style='text-align:right;'>" & "TOTALES:" & "</td>")
            'cuerpo.AppendLine("        <td style='text-align:center;'>" & tablaResumen.Compute("Sum(NUMAPROBACIONES)", "") & "</td>")
            'cuerpo.AppendLine("        <td style='text-align:center;'>" & tablaResumen.Compute("Sum(TOTAL)", "") & "</td>")
            'cuerpo.AppendLine("        <td style='text-align:center;'>" & "" & "</td>")
            'cuerpo.AppendLine("    </tr>")

            cuerpo.AppendLine("</table><hr style='border-style:groove;'/>")
            cuerpo.AppendLine("<p style='text-align:left;'>ENVÍO DE RELACIÓN DE APROBACIONES PENDIENTES POR RECIBO DE FACTURA ELECTRÓNICA.")
            cuerpo.AppendLine("ESTE CORREO FUE ENVIADO AUTOMATICAMENTE, POR FAVOR NO LO CONTESTE. ANTE CUALQUIER INQUIETUD POR FAVOR REMÍTASE A LA PERSONA ENCARGADA DE RECEPCIÓN DE FACTURACIÓN ELECTRÓNICA</p>")

            FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Aprobaciones pendientes por recibo de factura electrónica, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoCorrespondencia, "recepcionfacturaelectronica@ismocol.com", Nothing, False, "")

            FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Aprobaciones pendientes por recibo de factura electrónica, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoCorrespondencia, "asistente.contabilidad@ismocol.com", Nothing, False, "")

            cuerpo.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        ' Pendiente por radicar en Contabilidad
        cuerpo.Clear()
        comando.CommandText = "SELECT * FROM AprobacionesPendientesxRadicarContabilidad() ORDER BY APROBACION ASC"
        Dim adaptador1 As New SqlDataAdapter(comando)
        tablaDocumentosContabilidad = New DataTable()
        comando.Connection.Open()
        adaptador1.Fill(tablaDocumentosContabilidad)
        comando.Connection.Close()

        tablaUsuarios = tablaDocumentosContabilidad.DefaultView.ToTable(True, "IDPERSONAREGISTRA")
        tablaUsuariosAprueba = tablaDocumentosContabilidad.DefaultView.ToTable(True, "IDPERSONAAPRUEBA")

        tablaResumenContabilidad = New DataTable
        tablaResumenContabilidad.Columns.Add("DEPENDENCIA")
        tablaResumenContabilidad.Columns.Add("TIPOAPROBACION")
        tablaResumenContabilidad.Columns.Add("MONEDA")
        tablaResumenContabilidad.Columns.Add("NUMAPROBACIONES")
        tablaResumenContabilidad.Columns.Add("TOTAL")
        Dim query1 = From row In tablaDocumentosContabilidad.AsEnumerable()
            Group row By grupoResumen = New With {
                Key .Dependencia = row.Field(Of String)("NOMBREDEPENDENCIA"),
                Key .TipoAprobacion = row.Field(Of String)("NOMBRETIPOAPROBACION"),
                Key .Moneda = row.Field(Of String)("SIGLAISO")
            } Into Group
            Select New With {
                Key .Resumen = grupoResumen,
                .Conteo = Group.Count(Function(x) x.Field(Of String)("APROBACION")),
                .Total = Group.Sum(Function(x) x.Field(Of Decimal)("VALOR"))
            }
        For Each x In query1
            tablaResumenContabilidad.Rows.Add(x.Resumen.Dependencia, x.Resumen.TipoAprobacion, x.Resumen.Moneda, x.Conteo, x.Total)
        Next


        'Enviar correo Persona Registro

        For i As Integer = 0 To tablaUsuarios.Rows.Count - 1
            Dim FilaUsuario As DataRow
            FilaUsuario = tablaUsuarios.Rows(i)
            Dim filasDocumentosPendientes As DataRow()
            filasDocumentosPendientes = tablaDocumentosContabilidad.Select("IDPERSONAREGISTRA=" & FilaUsuario("IDPERSONAREGISTRA").ToString)
            Dim filasDocumentosPendientesReferencia As DataRow
            filasDocumentosPendientesReferencia = filasDocumentosPendientes(0)
            Try
                'crear cuerpo
                cuerpo.AppendLine("<center>")
                cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
                cuerpo.AppendLine("<table style='width:100%;'>")
                cuerpo.AppendLine("    <tr style='border:1px solid;'>")
                cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
                cuerpo.AppendLine("        <td>" & "FACTURACIÓN ELECTRÓNICA" & "<br/>")
                cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br/>")
                cuerpo.AppendLine(Date.Now.ToString) 'fecha actual
                cuerpo.AppendLine("        </td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("</table>")
                cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td><b>Nombre del Empleado:</b></td>")
                cuerpo.AppendLine("        <td colspan='10' >" & filasDocumentosPendientesReferencia("PERSONAREGISTRA") & "</td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td colspan='11' style='text-align:center; background-color:silver;'><b>" & "FACTURAS PENDIENTES POR RADICAR EN CONTABILIDAD" & "</b></td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>APROBACIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DEPENDENCIA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>TIPO DE APROBACIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>NIT</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PROVEEDOR</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DESCRIPCIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>APRUEBA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>VALOR</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>MONEDA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>FECHA REGISTRO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PERSONA REGISTRÓ</td>")
                cuerpo.AppendLine("    </tr>")

                For nrodocumentopendiente = 0 To filasDocumentosPendientes.Count - 1
                    Dim filaDocumentosPendientes As DataRow
                    filaDocumentosPendientes = filasDocumentosPendientes(nrodocumentopendiente)
                    cuerpo.AppendLine("    <tr>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("APROBACION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NOMBREDEPENDENCIA") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NOMBRETIPOAPROBACION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NIT") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PROVEEDOR") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("DESCRIPCION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PERSONAAPRUEBA") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("VALOR") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("SIGLAISO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("FECHAREGISTRO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PERSONAREGISTRA") & "</td>")
                    cuerpo.AppendLine("    </tr>")
                Next

                cuerpo.AppendLine("</table><hr style='border-style:groove;'/>")
                cuerpo.AppendLine("<p style='text-align:left;'>DIGITA - ENVÍO DE RELACIÓN DE APROBACIONES PENDIENTES POR RADICAR EN CONTABILIDAD.")
                cuerpo.AppendLine("ESTE CORREO FUE ENVIADO AUTOMATICAMENTE, POR FAVOR NO LO CONTESTE. ANTE CUALQUIER INQUIETUD POR FAVOR REMÍTASE A LA PERSONA ENCARGADA DE RECEPCIÓN DE FACTURACIÓN ELECTRÓNICA</p>")

                FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Facturas pendientes por radicar en contabilidad de las aprobaciones" & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoCorrespondencia, filasDocumentosPendientesReferencia("CORREOREGISTRA"), Nothing, False, "")

                cuerpo.Clear()
                ni.BalloonTipText = i & " de " & tablaUsuarios.Rows.Count - 1 & " correos enviados."
                ni.BalloonTipIcon = ToolTipIcon.Info
                ni.ShowBalloonTip(500)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        ' Enviar correo Persona Aprueba
        cuerpo.Clear()


        For i As Integer = 0 To tablaUsuariosAprueba.Rows.Count - 1
            Dim FilaUsuario As DataRow
            FilaUsuario = tablaUsuariosAprueba.Rows(i)
            Dim filasDocumentosPendientes As DataRow()
            filasDocumentosPendientes = tablaDocumentosContabilidad.Select("IDPERSONAAPRUEBA=" & FilaUsuario("IDPERSONAAPRUEBA").ToString)
            Dim filasDocumentosPendientesReferencia As DataRow
            filasDocumentosPendientesReferencia = filasDocumentosPendientes(0)
            Try
                'crear cuerpo
                cuerpo.AppendLine("<center>")
                cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
                cuerpo.AppendLine("<table style='width:100%;'>")
                cuerpo.AppendLine("    <tr style='border:1px solid;'>")
                cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
                cuerpo.AppendLine("        <td>" & "FACTURACIÓN ELECTRÓNICA" & "<br/>")
                cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br/>")
                cuerpo.AppendLine(Date.Now.ToString) 'fecha actual
                cuerpo.AppendLine("        </td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("</table>")
                cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td><b>Nombre del Empleado:</b></td>")
                cuerpo.AppendLine("        <td colspan='10' >" & filasDocumentosPendientesReferencia("PERSONAAPRUEBA") & "</td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td colspan='11' style='text-align:center; background-color:silver;'><b>" & "FACTURAS PENDIENTES POR RADICAR EN CONTABILIDAD" & "</b></td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>APROBACIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DEPENDENCIA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>TIPO DE APROBACIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>NIT</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PROVEEDOR</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DESCRIPCIÓN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>APRUEBA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>VALOR</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>MONEDA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>FECHA REGISTRO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PERSONA REGISTRÓ</td>")
                cuerpo.AppendLine("    </tr>")

                For nrodocumentopendiente = 0 To filasDocumentosPendientes.Count - 1
                    Dim filaDocumentosPendientes As DataRow
                    filaDocumentosPendientes = filasDocumentosPendientes(nrodocumentopendiente)
                    cuerpo.AppendLine("    <tr>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("APROBACION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NOMBREDEPENDENCIA") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NOMBRETIPOAPROBACION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NIT") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PROVEEDOR") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("DESCRIPCION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PERSONAAPRUEBA") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("VALOR") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("SIGLAISO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("FECHAREGISTRO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("PERSONAREGISTRA") & "</td>")
                    cuerpo.AppendLine("    </tr>")
                Next

                cuerpo.AppendLine("</table><hr style='border-style:groove;'/>")
                cuerpo.AppendLine("<p style='text-align:left;'>DIGITA - ENVÍO DE RELACIÓN DE APROBACIONES PENDIENTES POR RADICAR EN CONTABILIDAD.")
                cuerpo.AppendLine("ESTE CORREO FUE ENVIADO AUTOMATICAMENTE, POR FAVOR NO LO CONTESTE. ANTE CUALQUIER INQUIETUD POR FAVOR REMÍTASE A LA PERSONA ENCARGADA DE RECEPCIÓN DE FACTURACIÓN ELECTRÓNICA</p>")

                FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Facturas pendientes por radicar en contabilidad de las aprobaciones " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoCorrespondencia, filasDocumentosPendientesReferencia("CORREOAPRUEBA"), Nothing, False, "")

                cuerpo.Clear()
                ni.BalloonTipText = i & " de " & tablaUsuarios.Rows.Count - 1 & " correos enviados."
                ni.BalloonTipIcon = ToolTipIcon.Info
                ni.ShowBalloonTip(500)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next


        'Resumen Pendientes por radicar contabilidad.

        cuerpo.Clear()
        Try
            cuerpo.AppendLine("<center>")
            cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
            cuerpo.AppendLine("<table style ='width:100%;'>")
            cuerpo.AppendLine("    <tr style='border:1px solid;'>")
            cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
            cuerpo.AppendLine("        <td>" & "FACTURACIÓN ELECTRÓNICA" & "<br />")
            cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br />")
            cuerpo.AppendLine(Date.Now.ToString)
            cuerpo.AppendLine("        </td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("</table>")

            cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td colspan='6' style='text-align:center; background-color:silver;'><b>" & "RESUMEN DE FACTURAS PENDIENTES POR RADICAR EN CONTABILIDAD" & "</b></td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DEPENDENCIA</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>TIPO DE APROBACIÓN</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>MONEDA</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>NÚM. APROBACIONES</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>TOTAL</td>")
            cuerpo.AppendLine("    </tr>")
            For nrodocumentopendiente = 0 To tablaResumenContabilidad.Rows.Count - 1
                Dim filaResumenPendientes As DataRow
                filaResumenPendientes = tablaResumenContabilidad(nrodocumentopendiente)
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("DEPENDENCIA") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("TIPOAPROBACION") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("MONEDA") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("NUMAPROBACIONES") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("TOTAL") & "</td>")
                cuerpo.AppendLine("    </tr>")
            Next
            'cuerpo.AppendLine("    <tr>")
            'cuerpo.AppendLine("        <td colspan='2' style='text-align:right;'>" & "TOTALES:" & "</td>")
            'cuerpo.AppendLine("        <td style='text-align:center;'>" & tablaResumen.Compute("Sum(NUMAPROBACIONES)", "") & "</td>")
            'cuerpo.AppendLine("        <td style='text-align:center;'>" & tablaResumen.Compute("Sum(TOTAL)", "") & "</td>")
            'cuerpo.AppendLine("        <td style='text-align:center;'>" & "" & "</td>")
            'cuerpo.AppendLine("    </tr>")

            cuerpo.AppendLine("</table><hr style='border-style:groove;'/>")
            cuerpo.AppendLine("<p style='text-align:left;'>ENVÍO DE RELACIÓN DE APROBACIONES PENDIENTES POR RADICAR EN CONTABILIDAD.")
            cuerpo.AppendLine("ESTE CORREO FUE ENVIADO AUTOMATICAMENTE, POR FAVOR NO LO CONTESTE. ANTE CUALQUIER INQUIETUD POR FAVOR REMÍTASE A LA PERSONA ENCARGADA DE RECEPCIÓN DE FACTURACIÓN ELECTRÓNICA</p>")

            FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Facturas pendientes por radicar en contabilidad de las aprobaciones " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoCorrespondencia, "recepcionfacturaelectronica@ismocol.com", Nothing, False, "")

            FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Facturas pendientes por radicar en contabilidad de las aprobaciones " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoCorrespondencia, "asistente.contabilidad@ismocol.com", Nothing, False, "")


            cuerpo.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ni.BalloonTipText = "Correos enviados exitosamente."
        ni.BalloonTipIcon = ToolTipIcon.Info
        ni.ShowBalloonTip(2000)
        Cursor = Cursors.Default

    End Sub

#End Region 'Facturación Electrónica

#Region "Opciones Archivo"

    Private Sub SubirArchivosPDF(sender As Object, e As EventArgs) Handles Nbi_SubirPdfCorrespondenciaExterna.ItemClick, Nbi_SubirPdfCorrespondenciaInterna.ItemClick, Nbi_SubirPdfFax.ItemClick, Nbi_SubirPDF.ItemClick, Nbi_SubirPDFDS.ItemClick, Nbi_SubirPDFOS.ItemClick
        If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaSisControl.CurrentCell.RowIndex
            Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
            Dim PuedeSubir As Boolean = False
            Dim Tipo As Integer = 0
            Dim IdDocumento As String = ""
            Dim NombreDocumento As String = ""
            Dim AñoDocumento As String = ""
            Dim SubidoNube As String = ""
            Dim Actualizar As Boolean = False
            Select Case Boton.Name
                Case "Nbi_SubirPdfCorrespondenciaExterna"
                    If TablaCarga <> "EXTERNA" Then
                        MsgBox("No esta cargada la tabla de Correspondencia Externa", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1006) Then
                        PuedeSubir = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(1005) Then
                            Dim IDBase As Integer = Me.DGV_ListaSisControl.Item("IDBASESISCONTROL", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                            If IDBase = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                                PuedeSubir = True
                            Else
                                PuedeSubir = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso(1004) Then
                                Dim IDRegistro As Integer = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    PuedeSubir = True
                                Else
                                    PuedeSubir = False
                                End If
                            Else
                                PuedeSubir = False
                            End If
                        End If
                    End If

                    Tipo = 7
                    IdDocumento = Me.DGV_ListaSisControl.Item("IDCORRESPONDENCIAEXTERNA", Index_Registro_Actual).Value.ToString
                    NombreDocumento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString
                    If SubidoNube = "S" Then
                        Actualizar = True
                    Else
                        Actualizar = False
                    End If
                Case "Nbi_SubirPdfCorrespondenciaInterna"
                    If TablaCarga <> "INTERNA" Then
                        MsgBox("No esta cargada la tabla de Correspondencia Interna", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1011) Then
                        PuedeSubir = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(1010) Then
                            Dim IDBase As Integer = Me.DGV_ListaSisControl.Item("IDBASESISCONTROL", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                            If IDBase = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                                PuedeSubir = True
                            Else
                                PuedeSubir = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso(1009) Then
                                Dim IDRegistro As Integer = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    PuedeSubir = True
                                Else
                                    PuedeSubir = False
                                End If
                            Else
                                PuedeSubir = False
                            End If
                        End If
                    End If

                    Tipo = 7
                    IdDocumento = Me.DGV_ListaSisControl.Item("IDCORRESPONDENCIAEXTERNA", Index_Registro_Actual).Value.ToString
                    NombreDocumento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString
                    If SubidoNube = "S" Then
                        Actualizar = True
                    Else
                        Actualizar = False
                    End If
                Case "Nbi_SubirPdfFax"
                    If TablaCarga <> "FAX" Then
                        MsgBox("No esta cargada la tabla de FAX", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(991) Then
                        PuedeSubir = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(990) Then
                            Dim IDBase As Integer = Me.DGV_ListaSisControl.Item("IDBASESISCONTROL", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                            If IDBase = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                                PuedeSubir = True
                            Else
                                PuedeSubir = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso(989) Then
                                Dim IDRegistro As Integer = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    PuedeSubir = True
                                Else
                                    PuedeSubir = False
                                End If
                            Else
                                PuedeSubir = False
                            End If
                        End If
                    End If
                    Tipo = 8
                    IdDocumento = Me.DGV_ListaSisControl.Item("IDCORRESPONDENCIAEXTERNA", Index_Registro_Actual).Value.ToString
                    NombreDocumento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString
                    If SubidoNube = "S" Then
                        Actualizar = True
                    Else
                        Actualizar = False
                    End If
                Case "Nbi_SubirPDF"
                    Tipo = 6
                    If TablaCarga <> "CONTRATOS" Then
                        MsgBox("No esta cargada la tabla de Contratos", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If MsgBox("¿Desea subir el Documento de Autorización Descuentos de Seguridad Social?", MsgBoxStyle.YesNo, "SUBIR DOCUMENTO ICA-GRAL-F-193") = MsgBoxResult.Yes Then
                        Dim FrArchivoSS As New FormulariosSisControl.Fr_ArchivoSS
                        FrArchivoSS.CargarTablas()
                        FrArchivoSS.Tipo = "CO"
                        FrArchivoSS.IdDocumento = DGV_ListaSisControl.SelectedRows(0).Cells("Id").Value
                        FrArchivoSS.ShowDialog()
                        CargarContratos()
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                Case "Nbi_SubirPDFDS"
                    Tipo = 6
                    If TablaCarga <> "DOCUMENTO" Then
                        MsgBox("No esta cargada la tabla de Documento Soporte", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If MsgBox("¿Desea subir el Documento de Autorización Descuentos de Seguridad Social?", MsgBoxStyle.YesNo, "SUBIR DOCUMENTO ICA-GRAL-F-193") = MsgBoxResult.Yes Then
                        Dim FrArchivoSS As New FormulariosSisControl.Fr_ArchivoSS
                        FrArchivoSS.CargarTablas()
                        FrArchivoSS.Tipo = "DS"
                        FrArchivoSS.IdDocumento = DGV_ListaSisControl.SelectedRows(0).Cells("Id").Value
                        FrArchivoSS.ShowDialog()
                        CargarDocumento()
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                Case "Nbi_SubirPDFOS"
                    Tipo = 6
                    If TablaCarga <> "ORDENSERVICIO" Then
                        MsgBox("No esta cargada la tabla de órdenes de servicio", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If MsgBox("¿Desea subir el Documento de Autorización Descuentos de Seguridad Social?", MsgBoxStyle.YesNo, "SUBIR DOCUMENTO ICA-GRAL-F-193") = MsgBoxResult.Yes Then
                        Dim FrArchivoSS As New FormulariosSisControl.Fr_ArchivoSS
                        FrArchivoSS.CargarTablas()
                        FrArchivoSS.Tipo = "OS"
                        FrArchivoSS.IdDocumento = DGV_ListaSisControl.SelectedRows(0).Cells("Id").Value
                        FrArchivoSS.ShowDialog()
                        CargarOrdenesServicio(0)
                        Exit Sub
                    Else
                        Exit Sub
                    End If
            End Select
            Dim Subido As Boolean = False
            If PuedeSubir = False Then
                MsgBox("No cuenta con permisos para subir archivos.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                If Tipo = 7 Or Tipo = 8 Then
                    Subido = GoogleDrive.SubirArchivo(Tipo, IdDocumento, NombreDocumento, AñoDocumento, False)
                Else
                    Exit Sub
                End If
            End If

            If Subido Then
                Select Case TablaCarga
                    Case "EXTERNA"
                        CargarTablaxDefectoExterna()
                    Case "INTERNA"
                        CargarTablaxDefectoInterna()
                    Case "FAX"
                        CargarTablaxDefectoFax()
                End Select
            End If
        End If
    End Sub

    Private Sub Nbi_VerPdfs(sender As Object, e As EventArgs) Handles Nbi_VerPdfCorrespondenciaExterna.ItemClick, Nbi_VerPdfCorrespondenciaInterna.ItemClick, Nbi_VerPdfFax.ItemClick, Nbi_VerPDF.ItemClick, Nbi_VerPDFDS.ItemClick, Nbi_VerPDFOS.ItemClick
        If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaSisControl.CurrentCell.RowIndex
            Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
            Dim PuedeVer As Boolean = False
            Dim NombreDocumento As String = ""
            Dim AñoDocumento As String = ""
            Dim SubidoNube As String = ""
            Dim Descargar As String = "ArchivosPDF"
            Dim CarpetaDrive As String = ""
            Select Case Boton.Name
                Case "Nbi_VerPdfCorrespondenciaExterna"
                    If TablaCarga <> "EXTERNA" Then
                        MsgBox("No esta cargada la tabla de Correspondencia Externa", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1003) Then
                        PuedeVer = True
                    Else
                        MsgBox("No cuenta con permisos para ver archivos.", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    NombreDocumento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString
                    CarpetaDrive = "Correspondencia"
                Case "Nbi_VerPdfCorrespondenciaInterna"
                    If TablaCarga <> "INTERNA" Then
                        MsgBox("No esta cargada la tabla de Correspondencia Interna", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1008) Then
                        PuedeVer = True
                    Else
                        MsgBox("No cuenta con permisos para ver archivos.", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    NombreDocumento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString
                    CarpetaDrive = "Correspondencia"
                Case "Nbi_VerPdfFax"
                    If TablaCarga <> "FAX" Then
                        MsgBox("No esta cargada la tabla de FAX", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(992) Then
                        PuedeVer = True
                    Else
                        MsgBox("No cuenta con permisos para ver archivos.", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    NombreDocumento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString
                    CarpetaDrive = "Fax"
                Case "Nbi_VerPDF"
                    If TablaCarga <> "CONTRATOS" Then
                        MsgBox("No esta cargada la tabla de Contratos", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    PuedeVer = True
                    NombreDocumento = "CO-" + Trim(Me.DGV_ListaSisControl.Item("Id", Index_Registro_Actual).Value.ToString)
                    'AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString 'Verificar con edwin
                    Dim Fecha As Date = Trim(Me.DGV_ListaSisControl.Item("FECHACONTRATO", Index_Registro_Actual).Value.ToString)
                    Dim Año As String = Fecha.Year
                    AñoDocumento = Año
                    'SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString 'Verificar con edwin
                    SubidoNube = "S"
                    CarpetaDrive = "AutorizaciónDescuento"
                Case "Nbi_VerPDFDS"
                    If TablaCarga <> "DOCUMENTO" Then
                        MsgBox("No esta cargada la tabla de Documento Soporte", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    PuedeVer = True
                    NombreDocumento = "DS-" + Trim(Me.DGV_ListaSisControl.Item("Id", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString 'Verificar con edwin
                    'SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString 'Verificar con edwin
                    SubidoNube = "S"
                    CarpetaDrive = "AutorizaciónDescuento"
                Case "Nbi_VerPDFOS"
                    If TablaCarga <> "ORDENSERVICIO" Then
                        MsgBox("No esta cargada la tabla de órdenes de servicio", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    PuedeVer = True
                    NombreDocumento = "OS-" + Trim(Me.DGV_ListaSisControl.Item("Id", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString 'Verificar con edwin
                    'SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString 'Verificar con edwin
                    SubidoNube = "S"
                    CarpetaDrive = "AutorizaciónDescuento"
            End Select

            If SubidoNube = "S" Then
                GoogleDrive.DescargarArchivoNombre(AñoDocumento, NombreDocumento, Descargar, CarpetaDrive)
            End If
        End If
    End Sub


    'Private Sub Nbi_VerArchivoServidor_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerArchivoServidor.ItemClick
    '    Dim Documento As String = ""
    '    Cursor.Current = Cursors.WaitCursor
    '    Select Case TablaCarga
    '        Case "EXTERNA", "INTERNA" ', "FAX"
    '            Documento = Trim(DGV_ListaSisControl.Item("DOCUMENTO", DGV_ListaSisControl.CurrentCell.RowIndex).Value)
    '        Case Else
    '            Cursor.Current = Cursors.Default
    '            Exit Sub
    '    End Select
    '    Dim sfile As String = Documento & ".pdf"
    '    Dim rutaRemota As String = ""
    '    Dim nube As String = ""
    '    Dim subidoservidor As String = ""

    '    'If (TablaCarga = "FAX") Then
    '    '    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
    '    '    Dim comando As New SqlCommand("select UBICADOSERVIDORARCHIVO, SUBIDONUBE  From SC_CORRESPONDENCIA where DOCUMENTO = @DOCUMENTO", conexion)
    '    '    comando.Parameters.AddWithValue("@DOCUMENTO", Documento)
    '    '    conexion.Open()
    '    '    Dim reader = comando.ExecuteReader()
    '    '    While reader.Read()
    '    '        subidoservidor = reader("UBICADOSERVIDORARCHIVO").ToString()
    '    '        nube = reader("SUBIDONUBE").ToString()
    '    '    End While
    '    '    conexion.Close()
    '    'Else
    '    '    If (IsDBNull(DGV_ListaSisControl.Item("SUBIDONUBE", DGV_ListaSisControl.CurrentCell.RowIndex).Value)) Then
    '    '        nube = ""
    '    '    Else
    '    '        nube = DGV_ListaSisControl.Item("SUBIDONUBE", DGV_ListaSisControl.CurrentCell.RowIndex).Value
    '    '    End If
    '    '    If (IsDBNull(DGV_ListaSisControl.Item("UBICADOSERVIDORARCHIVO", DGV_ListaSisControl.CurrentCell.RowIndex).Value)) Then
    '    '        subidoservidor = ""
    '    '    Else
    '    '        subidoservidor = DGV_ListaSisControl.Item("UBICADOSERVIDORARCHIVO", DGV_ListaSisControl.CurrentCell.RowIndex).Value
    '    '    End If
    '    'End If

    '    If (IsDBNull(DGV_ListaSisControl.Item("SUBIDONUBE", DGV_ListaSisControl.CurrentCell.RowIndex).Value)) Then
    '        nube = ""
    '    Else
    '        nube = DGV_ListaSisControl.Item("SUBIDONUBE", DGV_ListaSisControl.CurrentCell.RowIndex).Value
    '    End If
    '    If (IsDBNull(DGV_ListaSisControl.Item("UBICADOSERVIDORARCHIVO", DGV_ListaSisControl.CurrentCell.RowIndex).Value)) Then
    '        subidoservidor = ""
    '    Else
    '        subidoservidor = DGV_ListaSisControl.Item("UBICADOSERVIDORARCHIVO", DGV_ListaSisControl.CurrentCell.RowIndex).Value
    '    End If

    '    If (subidoservidor = "S") Then
    '        If (nube = "S") Then
    '            'CreateService()
    '            GoogleDrive.DescargarArchivoNombre(Me.DGV_ListaSisControl.Item("AÑO", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value.ToString, Me.DGV_ListaSisControl.Item("DOCUMENTO", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value.ToString, "Correspondenica", "Correspondencia")
    '        Else
    '            Try
    '                If FuncionesBase.FuncionesBase.TIPOCONEXIONLOCAL() Then
    '                    rutaRemota = IO.Path.Combine(VariablesBase.VariablesBase.RutaServidorLocalArchivo, DGV_ListaSisControl.Item("AÑO", DGV_ListaSisControl.CurrentCell.RowIndex).Value)
    '                    sfile = IO.Path.Combine(rutaRemota, sfile)
    '                    If Not System.IO.File.Exists(sfile) Then
    '                        MessageBox.Show("El archivo no se encuentra disponible.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        Cursor.Current = Cursors.Default
    '                        Exit Sub
    '                    End If
    '                Else
    '                    rutaRemota = "ftp://" & VariablesBase.VariablesBase.RutaServidorRemotoArchivo & "/" & DGV_ListaSisControl.Item("AÑO", DGV_ListaSisControl.CurrentCell.RowIndex).Value
    '                    Dim ArchivoRemoto As String = rutaRemota & "/" & sfile
    '                    If Not existeObjeto(ArchivoRemoto, VariablesBase.VariablesBase.UsuarioServidorRemotoArchivo, VariablesBase.VariablesBase.ClaveServidorRemotoArchivo) Then
    '                        MessageBox.Show("El archivo no se encuentra disponible.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                        Cursor.Current = Cursors.Default
    '                        Exit Sub
    '                    Else
    '                        'Verificar si existe por vía FTP cuando se esta fuera de la red.
    '                        sfile = IO.Path.Combine(VariablesBase.VariablesBase._path, DGV_ListaSisControl.Item("AÑO", DGV_ListaSisControl.CurrentCell.RowIndex).Value, sfile)
    '                        If System.IO.File.Exists(sfile) Then
    '                            System.IO.File.Delete(sfile)
    '                        End If
    '                        My.Computer.Network.DownloadFile(ArchivoRemoto, sfile, "CORRESPONDENCIA", "CORRESPONDENCIA")
    '                    End If
    '                End If
    '                Dim psi As New ProcessStartInfo()
    '                psi.UseShellExecute = True
    '                psi.FileName = sfile
    '                Process.Start(psi)
    '            Catch ex As Exception
    '                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Finally
    '                Cursor.Current = Cursors.Default
    '            End Try
    '        End If
    '    Else
    '        MessageBox.Show("No hay un archivo asociado.", "Archivo no adjunto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Sub
    '    End If
    'End Sub

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

    Private Sub MarcarSubidoServidor(idCorrespondencia As Integer, tipo As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.MarcarSubidoServidor_SC_Correspondencia", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDCORRESPONDENCIA", idCorrespondencia)
        comando.Parameters.AddWithValue("@TIPO", tipo)
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

    Private Sub Nbi_GestionarUsuarioCorrespondenciaPendiente_ItemClick(sender As Object, e As EventArgs) Handles Nbi_GestionarUsuarioCorrespondenciaPendiente.ItemClick
        Using frGestionarUsuarioCorrespondencia As New Fr_GestionarUsuarioCorrespondencia
            frGestionarUsuarioCorrespondencia.ShowDialog()
        End Using
    End Sub
#End Region 'Opciones Archivo

#Region "Contratistas"

    Private Sub Nbi_CargarContratistas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarContratistas.ItemClick
        CargarContratistas()
    End Sub

    Private Sub CargarContratistas()
        Cursor.Current = Cursors.WaitCursor
        dsContratistas = bddatos.BusquedaCondiciones(54, 1, 4, 1, "", 0, Date.Now, Date.Now, 0, 50)
        If dsContratistas.Tables.Count > 1 Then 'si el procedimiento trae más de una tabla es decir la tabla de conteo y la tabla de datos
            dsContratistas.Tables.Remove(dsContratistas.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsContratistas.Clear()
        End If
        TablaCarga = "CONTRATISTA"
        DGV_ListaSisControl.DataSource = Nothing
        DGV_ListaSisControl.DataSource = dsContratistas.Tables(0)
        AplicarFormatoColumnasContratistas()
        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.ClearSelection()
            DGV_ListaSisControl.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub AplicarFormatoColumnasContratistas()
        Nbi_ExportarCobro.Enabled = False
        Me.DGV_ListaSisControl.DataSource = Nothing
        Me.DGV_ListaSisControl.DataSource = dsContratistas.Tables(0)
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "IDCONSTRATISTA"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Id"
                Case "IDENTIFICACION"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Nit"
                Case "NOMBRE"
                    DGV_ListaSisControl.Columns(i).Width = 250
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Nombre"
                Case "DIRECCION"
                    DGV_ListaSisControl.Columns(i).Width = 300
                    DGV_ListaSisControl.Columns(i).HeaderText = "Dirección"
                Case "TELEFONO"
                    DGV_ListaSisControl.Columns(i).Width = 80
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).HeaderText = "Teléfono"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        TablaCarga = "CONTRATISTA"

        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            ' DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(2)
        End If
    End Sub



    Private Sub Nbi_CrearContratista_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearContratista.ItemClick
        CrearContratistas()
    End Sub

    Private Sub CrearContratistas()
        Dim FrAgregarContratistas As New FormulariosSisControl.Fr_AgregarContratista
        'FrAgregarContratistas.CargarContratista()
        FrAgregarContratistas.ShowDialog()
        CargarContratistas()
    End Sub

    Private Sub Nbi_EditarContratista_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarContratista.ItemClick
        EditarContratista()
    End Sub

    Private Sub EditarContratista()
        Try
            If TablaCarga = "CONTRATISTA" Then
                Dim FrAgregarContratista As New FormulariosSisControl.Fr_AgregarContratista
                FrAgregarContratista.IdContratista = Me.DGV_ListaSisControl.SelectedRows(0).Cells("IDCONSTRATISTA").Value
                FrAgregarContratista.Editando = True
                FrAgregarContratista.CargarContratista()
                FrAgregarContratista.Tb_Identificacion.Enabled = False
                FrAgregarContratista.ShowDialog()
                If FrAgregarContratista.Guardado Then
                    Cargar_Tabla()
                End If
                CargarContratistas()
            Else
                MessageBox.Show("Cargue el listado de contratistas")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Nbi_VerContratista_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerContratista.ItemClick
        Try
            If TablaCarga = "CONTRATISTA" Then
                Dim FrAgregarContratista As New Fr_AgregarContratista
                FrAgregarContratista.Editando = True
                FrAgregarContratista.IdContratista = DGV_ListaSisControl.SelectedRows(0).Cells("IDCONSTRATISTA").Value
                FrAgregarContratista.CargarContratista()
                FrAgregarContratista.Btn_Aceptar.Enabled = False
                FrAgregarContratista.ShowDialog()
            Else
                MessageBox.Show("Cargue el listado de contratistas")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Nbi_BuscarContratista_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarContratista.ItemClick
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("IDENTIFICACION", "Nit del Contratista", "2")
        campos.Rows.Add("NOMBRE", "Nombre del Contratista", "1")
        frbuscar.campos = campos
        frbuscar.tabla = 54
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarContratistaBusqueda(DSbusqueda)
                Nbi_ExportarCobro.Enabled = True
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub

    Private Sub CargarContratistaBusqueda(ByVal dsContratista As DataSet)
        Nbi_ExportarCobro.Enabled = False
        Me.DGV_ListaSisControl.DataSource = Nothing
        Me.DGV_ListaSisControl.DataSource = dsContratista.Tables(0)
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "IDCONSTRATISTA"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Id"
                Case "IDENTIFICACION"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Nit"
                Case "NOMBRE"
                    DGV_ListaSisControl.Columns(i).Width = 250
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Nombre"
                Case "DIRECCION"
                    DGV_ListaSisControl.Columns(i).Width = 300
                    DGV_ListaSisControl.Columns(i).HeaderText = "Dirección"
                Case "TELEFONO"
                    DGV_ListaSisControl.Columns(i).Width = 80
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).HeaderText = "Teléfono"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        TablaCarga = "CONTRATISTA"

        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            'DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(2)
        End If
    End Sub


#End Region 'Contratistas

#Region "Contratos"

    Private Sub Nbi_CrearContratos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearContratos.ItemClick
        CrearContratos()
    End Sub


    Private Sub CrearContratos()

        Dim FrContratos As New FormulariosSisControl.Fr_Contratos
        FrContratos.CargarTablas()
        FrContratos.ShowDialog()
        CargarContratos()
    End Sub

    Private Sub Nbi_CargarContratos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarContratos.ItemClick

        CargarContratos()
        OcultarPanelMiniatura()
        OcultarPanelDetalle()
    End Sub

    Public Sub CargarContratos()
        Cursor.Current = Cursors.WaitCursor
        dsContratos = bddatos.BusquedaCondiciones(59, 1, 4, 1, "", 0, Date.Now, Date.Now, 0, 50)
        If dsContratos.Tables.Count > 1 Then 'Si el procedimiento trae más de una tabla, es decir, la tabla de conteo y la tabla de datos.
            dsContratos.Tables.Remove(dsContratos.Tables(0).TableName) 'Borrar la tabla del conteo.
        Else 'Si solo trae el conteo es porque se exceden los campos.
            MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dsDocumento.Clear()
        End If
        TablaCarga = "CONTRATOS"
        DGV_ListaSisControl.DataSource = Nothing
        DGV_ListaSisControl.DataSource = dsContratos.Tables(0)
        AplicarFormatoColumnasContratos()
        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.ClearSelection()
            DGV_ListaSisControl.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub CargarFiltro()
        Dim FrFiltrar As New FormulariosSisControl.Fr_BusquedaSisControl
        Dim dt_opcionesfiltro As New DataTable("OPCIONES")
        dt_opcionesfiltro.Rows.Clear()
        dt_opcionesfiltro.Columns.Add("OPCIONES")
        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            ' DGV_ListaSisControl.Columns(i).Visible = True
            Dim filaopciónfiltro As DataRow
            filaopciónfiltro = dt_opcionesfiltro.NewRow
            filaopciónfiltro("OPCIONES") = DGV_ListaSisControl.Columns(i).Name
            dt_opcionesfiltro.Rows.Add(filaopciónfiltro)
        Next

        FrFiltrar.dt_opcionesfiltro = dt_opcionesfiltro
        FrFiltrar.CargarCombo()
        FrFiltrar.ShowDialog()

        ValorFiltro = Trim(FrFiltrar.Valor)
        nombrecolumna = FrFiltrar.Columna

        If ValorFiltro <> "" Then
            Filtro()
        End If
    End Sub

    Public Sub AplicarFormatoColumnasContratos()
        Me.DGV_ListaSisControl.DataSource = Nothing
        Me.DGV_ListaSisControl.DataSource = dsContratos.Tables(0)
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "Id"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Id"
                Case "NIT"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Nit"
                Case "Proveedor"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "NroContrato"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Nro. Contrato"
                Case "NroFactura"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Nro. Factura"
                Case "ValorFactura"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Vr Factura"
                Case "FECHACONTRATO"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Fecha Contrato"
                Case "Anulada"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Anulada"
                Case "AUTORIZADESCTSS"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Autoriza Dcto SS"
                Case "SERVIDOR"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Servidor"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        TablaCarga = "CONTRATOS"

        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
        End If
    End Sub

    Private Sub Nbi_EditarContratos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarContratos.ItemClick
        Try
            If TablaCarga = "CONTRATOS" Then
                If VariablesBase.VariablesBase.IdPersona = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value Then
                    EditarContratos()

                Else
                    MsgBox("Solo puede editar la persona que registro", MsgBoxStyle.Critical, "CONTRATOS")
                End If
            Else
                MsgBox("Cargue Contratos", MsgBoxStyle.Critical, "Contratos")
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub EditarContratos()
        Try
            Dim FrContratos As New FormulariosSisControl.Fr_Contratos
            FrContratos.IdContratos = Me.DGV_ListaSisControl.SelectedRows(0).Cells("Id").Value
            FrContratos.Editando = True
            FrContratos.CargarTablas()
            FrContratos.CargarDatosContratos()
            FrContratos.ShowDialog()
            If FrContratos.Guardado Then
                Cargar_Tabla()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Nbi_VerContratos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerContratos.ItemClick
        Try
            If TablaCarga = "CONTRATOS" Then
                Dim FrContratos As New Fr_Contratos
                FrContratos.Editando = True
                FrContratos.IdContratos = DGV_ListaSisControl.SelectedRows(0).Cells("Id").Value
                FrContratos.CargarTablas()
                FrContratos.CargarDatosContratos()
                FrContratos.Bt_Guardar.Enabled = False
                FrContratos.ShowDialog()
            Else
                MessageBox.Show("Cargue el listado de Contratos")
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Nbi_BuscarContratos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarContratos.ItemClick
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("cast(FECHACONTRATO as date)", "Fecha Contrato", "3")
        campos.Rows.Add("NIT", "Nit del proveedor", "1")
        campos.Rows.Add("PROVEEDOR", "Proveedor", "1")
        frbuscar.campos = campos
        frbuscar.tabla = 59
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarContratosBusqueda(DSbusqueda)
                Nbi_ExportarCobro.Enabled = True
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub

    Private Sub CargarContratosBusqueda(ByVal dsDocumento As DataSet)
        Nbi_ExportarCobro.Enabled = False
        Me.DGV_ListaSisControl.DataSource = Nothing
        Me.DGV_ListaSisControl.DataSource = dsDocumento.Tables(0)
        Me.DGV_ListaSisControl.AutoGenerateColumns = True
        Me.DGV_ListaSisControl.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaSisControl.ReadOnly = True

        For i = 0 To DGV_ListaSisControl.ColumnCount - 1
            DGV_ListaSisControl.Columns(i).Visible = True
            Select Case DGV_ListaSisControl.Columns(i).Name
                Case "Id"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).HeaderText = "Id"
                Case "NIT"
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Nit"
                Case "Proveedor"
                    DGV_ListaSisControl.Columns(i).Width = 250
                Case "NroContrato"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Nro. Contrato"
                Case "NroFactura"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Nro. Factura"
                Case "ValorFactura"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Vr Factura"
                Case "Anulada"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).HeaderText = "Anulada"
                Case "AUTORIZADESCTSS"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Autoriza Dcto SS"
                Case "SERVIDOR"
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaSisControl.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaSisControl.Columns(i).DefaultCellStyle.Format = "C2"
                    DGV_ListaSisControl.Columns(i).HeaderText = "Servidor"
                Case Else
                    DGV_ListaSisControl.Columns(i).Visible = False
            End Select
        Next
        TablaCarga = "CONTRATOS"

        If DGV_ListaSisControl.RowCount > 0 Then
            DGV_ListaSisControl.Rows(0).Selected = True
            'DGV_ListaSisControl.CurrentCell = DGV_ListaSisControl.Rows(0).Cells(2)
        End If
    End Sub

#End Region 'Contratos

    Private Sub Filtro()
        Dim vista As New DataView
        Dim Filtro As String = "000"
        Dim filtrovista As String = ""

        Try
            Select Case TablaCarga
                Case "EXTERNA", "INTERNA", "FAX"
                    vista = New DataView(dtCorrespondencia)
                    Exit Select
                Case "ORDENSERVICIO"
                    vista = New DataView(dtOrdenServicio)
                    Exit Select
                Case "COBRO"
                    vista = New DataView(dtCobro)
                    Exit Select
                Case "SOBRE"
                    vista = New DataView(dtSobre)
                    Exit Select
                Case "RECEPCION"
                    vista = New DataView(dtRecepcion)
                    Exit Select
                Case "VISITANTE"
                    vista = New DataView(dtVisitante)
                    Exit Select
                Case "FE_APROBACION"
                    vista = New DataView(dtAprobaciones)
                    Exit Select
                Case "FE_RECHAZO"
                    vista = New DataView(dtRechazos)
                    Exit Select
            End Select
            filtrovista = ConcatenarFiltro(nombrecolumna, ValorFiltro)
            vista.RowFilter = filtrovista
            Me.DGV_ListaSisControl.SuspendLayout()
            Me.DGV_ListaSisControl.DataSource = vista
            Me.DGV_ListaSisControl.ResumeLayout()
        Catch ex As Exception
            MsgBox("Ocurrió un inconveniente al procesar la instrucción", MsgBoxStyle.Critical, "Inconveniente")
        End Try
    End Sub


    Private Function ConcatenarFiltro(ByVal Columna1 As String, ByVal Valor1 As String) As String
        Select Case DGV_ListaSisControl.Columns(Columna1).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                ConcatenarFiltro = String.Format("[" + Columna1 + "]" + "=" + Valor1)
                Exit Select
            Case Type.GetType("System.String")
                ConcatenarFiltro = String.Format("{0} like '%{1}%'", "[" + Columna1 + "]", Valor1)
                Exit Select
            Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                ConcatenarFiltro = ""
        End Select
    End Function

#Region "Exportar listado a Xls"
    Private Sub Nbi_ExportarExterna_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ExportarExterna.ItemClick
        If TablaCarga = "EXTERNA" Then
            ExportarBusqueda(DGV_ListaSisControl, "Correspondencia Externa")
        Else
            MsgBox("Cargue correspondencia externa", MsgBoxStyle.Critical, "EXTERNA")
        End If
    End Sub


    Private Sub ExportarBusqueda(ByVal Grilla As DataGridView, ByVal Titulo As String)
        If DGV_ListaSisControl.RowCount = 0 Then
            MsgBox("tabla vacía")
            Exit Sub
        End If
        FuncionesBase.FuncionesBase.ExportarDatosExcel(Grilla, Titulo)
    End Sub


    Private Sub Nbi_ExportarInterna_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ExportarInterna.ItemClick
        If TablaCarga = "INTERNA" Then
            ExportarBusqueda(DGV_ListaSisControl, "Correspondencia Interna")
        Else
            MsgBox("Cargue correspondencia externa ", MsgBoxStyle.Critical, "INTERNA")
        End If
    End Sub


    Private Sub Nbi_ExportarFax_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ExportarFax.ItemClick
        If TablaCarga = "FAX" Then
            ExportarBusqueda(DGV_ListaSisControl, "Fax")
        Else
            MsgBox("Cargue Fax", MsgBoxStyle.Critical, "FAX")
        End If
    End Sub


    Private Sub Nbi_ExportarOrden_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ExportarOrden.ItemClick
        If TablaCarga = "ORDENSERVICIO" Then
            ExportarBusqueda(DGV_ListaSisControl, "Orden de Servicio")
        Else
            MsgBox("Cargue Ordenes de servicio", MsgBoxStyle.Critical, "Orden de Servicio")
        End If
    End Sub


    Private Sub Nbi_ExportarCobro_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ExportarCobro.ItemClick
        If TablaCarga = "COBRO" Then
            ExportarBusqueda(DGV_ListaSisControl, "Cuenta Cobro")
        Else
            MsgBox("Cargue Cuentas de cobro", MsgBoxStyle.Critical, "Cuenta Cobro")
        End If
    End Sub


    Private Sub Nbi_ExportarSobres_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ExportarSobres.ItemClick
        If TablaCarga = "SOBRE" Then
            ExportarBusqueda(DGV_ListaSisControl, "SOBRES")
        Else
            MsgBox("Cargue sobres", MsgBoxStyle.Critical, "SOBRES")
        End If
    End Sub


    Private Sub Nbi_ExportarTablaRecepcion_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ExportarTablaRecepcion.ItemClick
        If TablaCarga <> "RECEPCION" Then
            MsgBox("Cargue Correspondencia Recibida", MsgBoxStyle.Critical, "Correspondencia Recibida")
            Exit Sub
        End If
        ExportarBusqueda(DGV_ListaSisControl, "Correspondencia Recibida")
    End Sub


    Private Sub Nbi_ExportarVisitante_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ExportarVisitante.ItemClick
        If TablaCarga = "VISITANTE" Then
            ExportarBusqueda(DGV_ListaSisControl, "Visitantes")
        Else
            MsgBox("Cargue visitantes", MsgBoxStyle.Critical, "Visitantes")
        End If
    End Sub
#End Region 'Exportar listado a Xls

    Private Sub Bt_CancelarFrEvento(sender As Object, e As EventArgs)
        Dim bb As New Button
        Dim Fr As New Form
        bb = sender
        Fr = sender.parent
        RespuestaFr_Aceptada = 0
        Fr.Close()
    End Sub

    Private Sub Bt_AceptarFrEvento(sender As Object, e As EventArgs)
        Dim bb As New Button
        Dim Fr As New Object
        bb = sender
        Fr = sender.parent
        RespuestaFr_Aceptada = 1
        Fr.Close()
    End Sub

#Region "ENVIO DE CORREOS DE CORRESPONDENCIA"




    Private Sub EnviarCorreosCorrespondencia()

        Dim objStreamWriter As StreamWriter
        'Pass the file path and the file name to the StreamWriter constructor.


        nombrearchivo = "\correosCorrespondencia" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt"
        If IO.File.Exists(VariablesBase.VariablesBase._path + nombrearchivo) = True Then

            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + nombrearchivo, True)

        Else
            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + "\" + nombrearchivo)
        End If
        'Open the file.

        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim TablaUsuarioPendientes As New DataTable("USUARIOSPENDIENTES")
        Dim TablaDocumentosPendientes As New DataTable("DOCUMENTOSPENDIENTES")
        Dim TablaResumenPendientes As New DataTable("RESUMENPENDIENTES")

        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim Consulta As New SqlClient.SqlCommand()
        Consulta.Connection = Conexión
        Consulta.CommandText = "SELECT * FROM dbo.CorrespondenciaPendiente() ORDER BY [Persona Registro], [Documento]"
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        TablaDocumentosPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador.Fill(TablaDocumentosPendientes)
        Consulta.Connection.Close()

        Consulta.CommandText = "SELECT DISTINCT IDPERSONAREGISTRA FROM dbo.CorrespondenciaPendiente() WHERE Correo <> '' "
        Dim Adaptador1 As New SqlClient.SqlDataAdapter(Consulta)
        TablaUsuarioPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador1.Fill(TablaUsuarioPendientes)
        Consulta.Connection.Close()

        Consulta.CommandText = "select [Persona Registro], case when " & _
                "TIPO='PSS' then 'Pendiente Subir al Servidor' else " & _
                "'Pendiente Entregar en Archivo Central' end as TIPO, " & _
                "count(TIPO) CANTIDAD, " & _
                "sum(case YEAR(FECHAREGISTRO) when 2018 then 1 else 0 end) as 'A2018', " & _
                "sum(case YEAR(FECHAREGISTRO) when 2019 then 1 else 0 end) as 'A2019', " & _
                "sum(case YEAR(FECHAREGISTRO) when 2020 then 1 else 0 end) as 'A2020', " & _
                "sum(case YEAR(FECHAREGISTRO) when 2021 then 1 else 0 end) as 'A2021', " & _
                "sum(case YEAR(FECHAREGISTRO) when 2022 then 1 else 0 end) as 'A2022', " & _
                "Dependencia from dbo.CorrespondenciaPendiente() " & _
                "group by TIPO,[Persona Registro],Dependencia order by count(TIPO) desc,[Persona Registro] "
        Dim Adaptador2 As New SqlClient.SqlDataAdapter(Consulta)
        TablaResumenPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador1.Fill(TablaResumenPendientes)
        Consulta.Connection.Close()

        Dim cuerpo As New StringBuilder

        Dim ni As New NotifyIcon
        AddHandler ni.BalloonTipClosed, Sub()
                                            ni.Visible = False
                                            ni.Dispose()
                                        End Sub
        ni.Icon = SystemIcons.Application
        ni.BalloonTipTitle = "Envío de correos SIGMA"
        ni.Text = "Envío de correos SIGMA"
        ni.Visible = True

        For i As Integer = 0 To TablaUsuarioPendientes.Rows.Count - 1
            Dim FilaUsuario As DataRow
            FilaUsuario = TablaUsuarioPendientes.Rows(i)
            Dim filasDocumentosPendientes As DataRow()
            filasDocumentosPendientes = TablaDocumentosPendientes.Select("IDPERSONAREGISTRA=" & FilaUsuario("IDPERSONAREGISTRA").ToString)
            Dim filasDocumentosPendientesReferencia As DataRow
            filasDocumentosPendientesReferencia = filasDocumentosPendientes(0)
            Try
                'crear cuerpo
                cuerpo.AppendLine("<center>")
                cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
                cuerpo.AppendLine("<table style='width:100%;'>")
                cuerpo.AppendLine("    <tr style='border:1px solid;'>")
                cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
                cuerpo.AppendLine("        <td>ARCHIVO CENTRAL<br/>")
                cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br/>")
                cuerpo.AppendLine(Date.Now.ToString) 'fecha actual
                cuerpo.AppendLine("        </td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("</table>")

                cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td><b>Nombre del Empleado:</b></td>")
                cuerpo.AppendLine("        <td colspan='6' >" & filasDocumentosPendientesReferencia("Persona Registro") & "</td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td colspan='7' style='text-align:center; background-color:silver;'><b>PENDIENTES POR DIGITALIZAR Y/O ENTREGAR EN ARCHIVO CENTRAL</b></td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DOCUMENTO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>BASE</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DEPENDENCIA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>FECHA REGISTRO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PERSONA ELABORO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>CENTRO COSTO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PENDIENTE</td>")
                cuerpo.AppendLine("    </tr>")

                For nrodocumentopendiente = 0 To filasDocumentosPendientes.Count - 1
                    Dim filaDocumentosPendientes As DataRow
                    filaDocumentosPendientes = filasDocumentosPendientes(nrodocumentopendiente)
                    cuerpo.AppendLine("    <tr>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Documento") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Base") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Dependencia") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("FECHAREGISTRO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Persona Elaboro") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Centro Costo") & "</td>")
                    If filaDocumentosPendientes("TIPO") = "PSS" Then
                        cuerpo.AppendLine("        <td style='text-align:center;'>" & "Subir al Servidor" & "</td>") 'valor
                    Else
                        cuerpo.AppendLine("        <td style='text-align:center;'>" & "Entregar en Archivo de Gerencia" & "</td>") 'valor
                    End If
                    cuerpo.AppendLine("    </tr>")
                Next
                cuerpo.AppendLine("</table><hr style='border-style:groove;'/>")



                cuerpo.AppendLine("<p style='text-align:left;'>ENVIO DE RELACION DE DOCUMENTOS PENDIENTES POR DIGITALIZAR Y/O ENTREGAR EN ARCHIVO CENTRAL.")
                cuerpo.AppendLine("ESTE CORREO FUE ENVIADO AUTOMATICAMENTE FAVOR NO CONTESTAR. CUALQUIER INQUIETUD FAVOR REMITIRSE A LA PERSONA ENCARGADA DEL ARCHIVO CENTRAL</p>")


                FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Pendientes de subir al servidor de correspondencia y/o entregar al archivo central x persona que registro, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoCorrespondencia, filasDocumentosPendientesReferencia("Correo"), Nothing, False, "")

                objStreamWriter.WriteLine(filasDocumentosPendientesReferencia("Correo").ToString + ">" + "SI>" + Date.Now.ToString + ">" + VariablesBase.VariablesBase.correoCorrespondencia.ToString)

                cuerpo.Clear()
                ni.BalloonTipText = i & " de " & TablaUsuarioPendientes.Rows.Count - 1 & " correos enviados."
                ni.BalloonTipIcon = ToolTipIcon.Info
                ni.ShowBalloonTip(500)
                'Registrar correo enviado en archivo de texto
                FuncionesBase.FuncionesBase.RegistrarCorreoEnviado(VariablesBase.VariablesBase.correoCorrespondencia, "SI", filasDocumentosPendientesReferencia("Correo").ToString)
            Catch ex As Exception
                objStreamWriter.WriteLine(filasDocumentosPendientesReferencia("Correo") + ">" + "NO>" + Date.Now.ToString)
                FuncionesBase.FuncionesBase.RegistrarCorreoEnviado(filasDocumentosPendientesReferencia("Correo"), "NO", VariablesBase.VariablesBase.correoCorrespondencia)

                MsgBox(ex.Message)

            End Try



        Next
        objStreamWriter.Close()
        'Resumen para Jefe Administración
        cuerpo.Clear()
        Try
            cuerpo.AppendLine("<center>")
            cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
            cuerpo.AppendLine("<table style ='width:100%;'>")
            cuerpo.AppendLine("    <tr style='border:1px solid;'>")
            cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
            cuerpo.AppendLine("        <td>ARCHIVO CENTRAL<br />")
            cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br />")
            cuerpo.AppendLine(Date.Now.ToString)
            cuerpo.AppendLine("        </td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("</table>")

            cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td colspan='6' style='text-align:center; background-color:silver;'><b>RESUMEN DE PENDIENTES POR DIGITALIZAR Y/O ENTREGAR EN ARCHIVO CENTRALO</b></td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PERSONA REGISTRO</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>TIPO</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>CANTIDAD</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>2018</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>2019</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>2020</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>2021</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>2022</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DEPENDENCIA</td>")
            cuerpo.AppendLine("    </tr>")
            For nrodocumentopendiente = 0 To TablaResumenPendientes.Rows.Count - 1
                Dim filaResumenPendientes As DataRow
                filaResumenPendientes = TablaResumenPendientes(nrodocumentopendiente)
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("Persona Registro") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("TIPO") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("CANTIDAD") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2018") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2019") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2020") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2021") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2022") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("Dependencia") & "</td>")
                cuerpo.AppendLine("    </tr>")
            Next
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td colspan='2' style='text-align:right;'>" & "TOTALES:" & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(CANTIDAD)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2018)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2019)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2020)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2021)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2022)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & "" & "</td>")
            cuerpo.AppendLine("    </tr>")

            cuerpo.AppendLine("</table><hr style='border-style:groove;'/>")
            cuerpo.AppendLine("<p style='text-align:left;'>ENVIO DE RELACION DE DOCUMENTOS PENDIENTES POR DIGITALIZAR Y/O ENTREGAR EN ARCHIVO CENTRAL.")
            cuerpo.AppendLine("ESTE CORREO FUE ENVIADO AUTOMATICAMENTE FAVOR NO CONTESTAR. CUALQUIER INQUIETUD FAVOR REMITIRSE A LA PERSONA ENCARGADA DEL ARCHIVO CENTRAL</p>")

            Dim direccionesConCopia As New List(Of String)
            direccionesConCopia.Add("secretaria.administracion@ismocol.com")
            FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Pendientes de subir al servidor de correspondencia y/o entregar al archivo central x persona que registro, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoCorrespondencia, "administracion@ismocol.com", direccionesConCopia, False, "")
            cuerpo.Clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = System.Windows.Forms.Cursors.Default
        'ni.BalloonTipText = "Correos enviados exitosamente."
        'ni.BalloonTipIcon = ToolTipIcon.Info
        'ni.ShowBalloonTip(2000)
        Cursor = Cursors.Default
        objStreamWriter.Close()
        If MsgBox("¿Visualizar el registro de envío de correspondencia?", MsgBoxStyle.YesNo, "Registro") = MsgBoxResult.Yes Then

            visorCorreos(nombrearchivo)
        End If


    End Sub

    Public Sub visorCorreos(ByVal nombre As String)
        Dim FrVisorRegistrosCorreo As New FormulariosClasesBase.Fr_VisorRegistrosCorreo
        FrVisorRegistrosCorreo._nombreArchivo = nombre.ToString
        FrVisorRegistrosCorreo.ShowDialog()
    End Sub

    Private Sub EnviarCorreosCorrespondenciaelabora()
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim TablaUsuarioPendientes As New DataTable("USUARIOSPENDIENTES")
        Dim TablaDocumentosPendientes As New DataTable("DOCUMENTOSPENDIENTES")
        Dim TablaResumenPendientes As New DataTable("RESUMENPENDIENTES")

        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim Consulta As New SqlClient.SqlCommand()
        Consulta.Connection = Conexión
        Consulta.CommandText = "SELECT * FROM dbo.CorrespondenciaPendiente() ORDER BY [Persona Elaboro], [Documento]"
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        TablaDocumentosPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador.Fill(TablaDocumentosPendientes)
        Consulta.Connection.Close()

        Consulta.CommandText = "SELECT DISTINCT ELABORADOPOR FROM dbo.CorrespondenciaPendiente() WHERE Correoelaboradopor <> '' "
        Dim Adaptador1 As New SqlClient.SqlDataAdapter(Consulta)
        TablaUsuarioPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador1.Fill(TablaUsuarioPendientes)
        Consulta.Connection.Close()

        Consulta.CommandText = "select [Persona Elaboro], case when " & _
                "TIPO='PSS' then 'Pendiente Subir al Servidor' else " & _
                "'Pendiente Entregar en Archivo Central' end as TIPO, " & _
                "count(TIPO) CANTIDAD, " & _
                "sum(case YEAR(FECHAREGISTRO) when 2018 then 1 else 0 end) as 'A2018', " & _
                "sum(case YEAR(FECHAREGISTRO) when 2019 then 1 else 0 end) as 'A2019', " & _
                "sum(case YEAR(FECHAREGISTRO) when 2020 then 1 else 0 end) as 'A2020', " & _
                "sum(case YEAR(FECHAREGISTRO) when 2021 then 1 else 0 end) as 'A2021', " & _
                "sum(case YEAR(FECHAREGISTRO) when 2022 then 1 else 0 end) as 'A2022', " & _
                "Dependencia from dbo.CorrespondenciaPendiente() " & _
                "group by TIPO,[Persona Elaboro],Dependencia order by count(TIPO) desc,[Persona Elaboro] "
        Dim Adaptador2 As New SqlClient.SqlDataAdapter(Consulta)
        TablaResumenPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador1.Fill(TablaResumenPendientes)
        Consulta.Connection.Close()

        Dim cuerpo As New StringBuilder

        Dim ni As New NotifyIcon
        AddHandler ni.BalloonTipClosed, Sub()
                                            ni.Visible = False
                                            ni.Dispose()
                                        End Sub
        ni.Icon = SystemIcons.Application
        ni.BalloonTipTitle = "Envío de correos SIGMA"
        ni.Text = "Envío de correos SIGMA"
        ni.Visible = True

        For i As Integer = 0 To TablaUsuarioPendientes.Rows.Count - 1
            Dim FilaUsuario As DataRow
            FilaUsuario = TablaUsuarioPendientes.Rows(i)
            Dim filasDocumentosPendientes As DataRow()
            filasDocumentosPendientes = TablaDocumentosPendientes.Select("ELABORADOPOR=" & FilaUsuario("ELABORADOPOR").ToString)
            Dim filasDocumentosPendientesReferencia As DataRow
            filasDocumentosPendientesReferencia = filasDocumentosPendientes(0)
            Try
                'crear cuerpo
                cuerpo.AppendLine("<center>")
                cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
                cuerpo.AppendLine("<table style='width:100%;'>")
                cuerpo.AppendLine("    <tr style='border:1px solid;'>")
                cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
                cuerpo.AppendLine("        <td>ARCHIVO CENTRAL<br/>")
                cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br/>")
                cuerpo.AppendLine(Date.Now.ToString) 'fecha actual
                cuerpo.AppendLine("        </td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("</table>")

                cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td><b>Nombre del Empleado que Elaboró:</b></td>")
                cuerpo.AppendLine("        <td colspan='6' >" & filasDocumentosPendientesReferencia("Persona Elaboro") & "</td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td colspan='7' style='text-align:center; background-color:silver;'><b>PENDIENTES POR DIGITALIZAR Y/O ENTREGAR EN ARCHIVO CENTRAL X PERSONA QUE ELABORO</b></td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DOCUMENTO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>BASE</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>DEPENDENCIA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>FECHA REGISTRO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PERSONA REGISTRO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>CENTRO COSTO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PENDIENTE</td>")
                cuerpo.AppendLine("    </tr>")

                For nrodocumentopendiente = 0 To filasDocumentosPendientes.Count - 1
                    Dim filaDocumentosPendientes As DataRow
                    filaDocumentosPendientes = filasDocumentosPendientes(nrodocumentopendiente)
                    cuerpo.AppendLine("    <tr>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Documento") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Base") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Dependencia") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("FECHAREGISTRO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Persona Registro") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Centro Costo") & "</td>")
                    If filaDocumentosPendientes("TIPO") = "PSS" Then
                        cuerpo.AppendLine("        <td style='text-align:center;'>" & "Subir al Servidor" & "</td>") 'valor
                    Else
                        cuerpo.AppendLine("        <td style='text-align:center;'>" & "Entregar en Archivo de Gerencia" & "</td>") 'valor
                    End If
                    cuerpo.AppendLine("    </tr>")
                Next

                cuerpo.AppendLine("</table><hr style='border-style:groove;'/>")
                cuerpo.AppendLine("<p style='text-align:left;'>ENVIO DE RELACION DE DOCUMENTOS PENDIENTES POR DIGITALIZAR Y/O ENTREGAR EN ARCHIVO CENTRAL.")
                cuerpo.AppendLine("ESTE CORREO FUE ENVIADO AUTOMATICAMENTE FAVOR NO CONTESTAR. CUALQUIER INQUIETUD FAVOR REMITIRSE A LA PERSONA ENCARGADA DEL ARCHIVO CENTRAL</p>")

                FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Pendientes de subir al servidor de correspondencia y/o entregar al archivo central x persona que elaboró, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoCorrespondencia, filasDocumentosPendientesReferencia("Correoelaboradopor"), Nothing, False, "")
                cuerpo.Clear()
                ni.BalloonTipText = i & " de " & TablaUsuarioPendientes.Rows.Count - 1 & " correos enviados."
                ni.BalloonTipIcon = ToolTipIcon.Info
                ni.ShowBalloonTip(500)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        Cursor = System.Windows.Forms.Cursors.Default

        ni.BalloonTipText = "Correos enviados exitosamente."
        ni.BalloonTipIcon = ToolTipIcon.Info
        ni.ShowBalloonTip(2000)
        Cursor = Cursors.Default
    End Sub



    Private Sub Nbi_EnviarCorreosFaltantes_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EnviarCorreosFaltantes.ItemClick
        If MsgBox("¿Seguro que desea enviar los correos de pendientes por persona que registra en bloque?", MsgBoxStyle.YesNo, "ENVIAR CORREOS PENDIENTES X PERSONA QUE REGISTRA") = MsgBoxResult.Yes Then
            EnviarCorreosCorrespondencia()
        End If
        If MsgBox("¿Seguro que desea enviar los correos de pendientes por persona que elabora en bloque?", MsgBoxStyle.YesNo, "ENVIAR CORREOS PENDIENTES X PERSONA QUE REGISTRA") = MsgBoxResult.Yes Then
            EnviarCorreosCorrespondenciaelabora()
            visorCorreos(nombrearchivo)

        End If
    End Sub

#End Region 'ENVIO DE CORREOS DE CORRESPONDENCIA

#Region "ENVIO DE CORREOS DE ORDENES DE SERVICIO"

    Private Sub EnviarCorreosOrdenesServicio()

        Dim objStreamWriter As StreamWriter 'Para el log de envio local
        VariablesBase.VariablesBase.TablaCorreosEnviados.Clear() 'Para el visor de correos enviados


        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim TablaUsuarioPendientes As New DataTable("USUARIOSPENDIENTES")
        Dim TablaDocumentosPendientes As New DataTable("ORDENESSERVICIOPENDIENTES")
        Dim TablaResumenPendientes As New DataTable("RESUMENPENDIENTES")

        Dim Consulta As New SqlClient.SqlCommand()
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Consulta.CommandText = "SELECT * FROM dbo.OrdenesPendienteCierre() ORDER BY [Persona Registro], [IDORDENESSERVICIO]"
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        TablaDocumentosPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador.Fill(TablaDocumentosPendientes)
        Consulta.Connection.Close()

        Consulta.CommandText = "SELECT DISTINCT IDPERSONAREGISTRA FROM dbo.OrdenesPendienteCierre() WHERE Correo <> '' "
        Dim Adaptador1 As New SqlClient.SqlDataAdapter(Consulta)
        TablaUsuarioPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador1.Fill(TablaUsuarioPendientes)
        Consulta.Connection.Close()

        Consulta.CommandText = "SELECT [Persona Registro], Base, Dependencia, COUNT(IDORDENESSERVICIO) AS CANTIDAD, " & _
        "SUM(CASE YEAR([Fecha OS]) WHEN 2018 THEN 1 ELSE 0 END) AS 'A2018', " & _
        "SUM(CASE YEAR([Fecha OS]) WHEN 2019 THEN 1 ELSE 0 END) AS 'A2019', " & _
        "SUM(CASE YEAR([Fecha OS]) WHEN 2020 THEN 1 ELSE 0 END) AS 'A2020', " & _
        "SUM(CASE YEAR([Fecha OS]) WHEN 2021 THEN 1 ELSE 0 END) AS 'A2021', " & _
        "SUM(CASE YEAR([Fecha OS]) WHEN 2022 THEN 1 ELSE 0 END) AS 'A2022' " & _
        "FROM dbo.OrdenesPendienteCierre() " & _
        "GROUP BY [Persona Registro], Base, Dependencia " & _
        "ORDER BY [Persona Registro], Base"
        Dim Adaptador2 As New SqlClient.SqlDataAdapter(Consulta)
        TablaResumenPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador1.Fill(TablaResumenPendientes)
        Consulta.Connection.Close()

        Dim cuerpo As New StringBuilder
        Dim ni As New NotifyIcon
        AddHandler ni.BalloonTipClosed, Sub()
                                            ni.Visible = False
                                            ni.Dispose()
                                        End Sub
        ni.Icon = SystemIcons.Application
        ni.BalloonTipTitle = "Envío de correos SIGMA"
        ni.Text = "Envío de correos SIGMA"
        ni.Visible = True

        nombrearchivo = "\correosOrdenesServicio_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt"
        If IO.File.Exists(VariablesBase.VariablesBase._path + nombrearchivo) = True Then

            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + nombrearchivo, True)

        Else
            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + "\" + nombrearchivo)
        End If

        For i As Integer = 0 To TablaUsuarioPendientes.Rows.Count - 1
            Dim FilaUsuario As DataRow
            FilaUsuario = TablaUsuarioPendientes.Rows(i)
            Dim filasDocumentosPendientes As DataRow()
            filasDocumentosPendientes = TablaDocumentosPendientes.Select("IDPERSONAREGISTRA=" + FilaUsuario("IDPERSONAREGISTRA").ToString)
            Dim filasDocumentosPendientesReferencia As DataRow
            filasDocumentosPendientesReferencia = filasDocumentosPendientes(0)


            Try
                'crear cuerpo
                cuerpo.AppendLine("<center>")
                cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
                cuerpo.AppendLine("<table style='width:100%;'>")
                cuerpo.AppendLine("    <tr style='border:1px solid;'>")
                cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
                cuerpo.AppendLine("        <td>ESTADO DE ORDENES DE SERVICIO<br />")
                cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br />")
                cuerpo.AppendLine(Date.Now.ToString) 'fecha actual
                cuerpo.AppendLine("        </td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("</table>")

                cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td><b>Nombre del Empleado:</b></td>")
                cuerpo.AppendLine("        <td colspan='7'>" & filasDocumentosPendientesReferencia("Persona Registro") & "</td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td colspan='8' style='text-align:center; background-color:silver;'><b>PENDIENTES POR CERRAR</b></td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Orden de Servicio</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Base</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Dependencia</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Nit Proveedor</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Nombre Proveedor</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Fecha OS</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Dirección</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Valor Estimado</td>")
                cuerpo.AppendLine("    </tr>")

                For nrodocumentopendiente = 0 To filasDocumentosPendientes.Count - 1
                    Dim filaDocumentosPendientes As DataRow
                    filaDocumentosPendientes = filasDocumentosPendientes(nrodocumentopendiente)
                    cuerpo.AppendLine("    <tr>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Orden de Servicio") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & Trim(filaDocumentosPendientes("Base")) & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Dependencia") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Nit Proveedor") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Nombre Proveedor") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Fecha OS") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Dirección") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Valor Estimado") & "</td>")
                    cuerpo.AppendLine("    </tr>")
                Next

                cuerpo.AppendLine("</table><hr style='border-style:groove;' />")

                cuerpo.AppendLine("<p style='text-align:left'>ENVIO DE RELACION DE ORDENES DE SERVICIO PENDIENTES POR CERRAR.")
                cuerpo.AppendLine("ESTE CORREO FUE ENVIADO AUTOMATICAMENTE FAVOR NO CONTESTAR.</p>")

                FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Ordenes de servicio pendientes por cerrar, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoInformacionMateriales, filasDocumentosPendientesReferencia("Correo"), Nothing, False, "")

                cuerpo.Clear()

                objStreamWriter.WriteLine(filasDocumentosPendientesReferencia("Correo") + ">" + "SI>" + Date.Now.ToString + ">" + VariablesBase.VariablesBase.correoInformacionMateriales)
                objStreamWriter.Close()

                FuncionesBase.FuncionesBase.RegistrarCorreoEnviado(filasDocumentosPendientesReferencia("Correo"), "SI", VariablesBase.VariablesBase.correoInformacionMateriales)


                ni.BalloonTipText = i & " de " & TablaUsuarioPendientes.Rows.Count - 1 & " correos enviados."
                ni.BalloonTipIcon = ToolTipIcon.Info
                ni.ShowBalloonTip(500)

                System.Threading.Thread.Sleep(VariablesBase.VariablesBase.TiempoEsperaEnvioCorreo) 'Pausa para que el servidor de correo no lo tome como SPAM y presente bloqueo, sugerencia de personal tecnico de google

            Catch ex As Exception
                objStreamWriter.WriteLine(filasDocumentosPendientesReferencia("Correo") + ">" + "NO>" + Date.Now.ToString)
                objStreamWriter.Close()

                FuncionesBase.FuncionesBase.RegistrarCorreoEnviado(filasDocumentosPendientesReferencia("Correo"), "NO", VariablesBase.VariablesBase.correoInformacionMateriales)
                MsgBox(ex.Message)
            End Try
        Next

        'Resumen para Auditor y Jefe Administración
        cuerpo.Clear()
        Try
            cuerpo.AppendLine("<center>")
            cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
            cuerpo.AppendLine("<table style ='width:100%;'>")
            cuerpo.AppendLine("    <tr style='border:1px solid;'>")
            cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
            cuerpo.AppendLine("        <td>ESTADO DE ORDENES DE SERVICIO<br />")
            cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br />")
            cuerpo.AppendLine(Date.Now.ToString)
            cuerpo.AppendLine("        </td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("</table>")

            cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td colspan='7' style='text-align:center; background-color:silver;'><b>RESUMEN DE PENDIENTES POR CERRAR</b></td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Persona Registro</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Base</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Dependencia</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Cantidad</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>2018</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>2019</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>2020</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>2021</td>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>2022</td>")
            cuerpo.AppendLine("    </tr>")

            For nrodocumentopendiente = 0 To TablaResumenPendientes.Rows.Count - 1
                Dim filaResumenPendientes As DataRow
                filaResumenPendientes = TablaResumenPendientes(nrodocumentopendiente)
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("Persona Registro") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & Trim(filaResumenPendientes("Base")) & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("Dependencia") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("CANTIDAD") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2018") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2019") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2020") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2021") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2022") & "</td>")
                cuerpo.AppendLine("    </tr>")
            Next
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td colspan='3'style='text-align:right;'>" & "TOTALES:" & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(CANTIDAD)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2018)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2019)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2020)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2021)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2022)", "") & "</td>")
            cuerpo.AppendLine("    </tr>")

            cuerpo.AppendLine("</table><hr style='border-style:groove;' />")
            cuerpo.AppendLine("<p style='text-align:left'>ENVIO DE RELACION DE ORDENES DE SERVICIO PENDIENTES POR CERRAR.")
            cuerpo.AppendLine("ESTE CORREO FUE ENVIADO AUTOMATICAMENTE FAVOR NO CONTESTAR.</p>")

            Dim direccionesConCopia As New List(Of String)
            direccionesConCopia.Add("administracion@ismocol.com")
            FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Ordenes de servicio pendientes por cerrar, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoInformacionMateriales, "auditoria@ismocol.com", direccionesConCopia, False, "")
            cuerpo.Clear()

            If IO.File.Exists(VariablesBase.VariablesBase._path + "\correosnominaenviados.txt") = True Then
                objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + "\correosnominaenviados.txt", True)
            Else
                objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + "\correosnominaenviados.txt")
            End If

            'Write a line of text.
            objStreamWriter.WriteLine("auditoria@ismocol.com" + ">" + "SI>" + Date.Now.ToString + ">" + VariablesBase.VariablesBase.correoInformacionMateriales)
            FuncionesBase.FuncionesBase.RegistrarCorreoEnviado("auditoria@ismocol.com", "SI", VariablesBase.VariablesBase.correoInformacionMateriales)
            objStreamWriter.Close()
        Catch ex As Exception
            objStreamWriter.WriteLine("auditoria@ismocol.com" + ">" + "NO>" + Date.Now.ToString)
            FuncionesBase.FuncionesBase.RegistrarCorreoEnviado("auditoria@ismocol.com", "NO", VariablesBase.VariablesBase.correoInformacionMateriales)
            objStreamWriter.Close()
            MsgBox(ex.Message)
        End Try
        Cursor = System.Windows.Forms.Cursors.Default
        ni.BalloonTipText = "Correos enviados exitosamente."
        ni.BalloonTipIcon = ToolTipIcon.Info
        ni.ShowBalloonTip(2000)
        Cursor = Cursors.Default
    End Sub


    Private Sub Nbi_EnviarCorreoPenOS_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EnviarCorreoPenOS.ItemClick
        If MsgBox("¿Seguro que desea enviar los correos de ordenes de servicio pendientes por cerrar en bloque?", MsgBoxStyle.YesNo, "ENVIAR CORREOS PENDIENTES") = MsgBoxResult.Yes Then
            EnviarCorreosOrdenesServicio()



        End If
        visorCorreos(nombrearchivo)
    End Sub

#End Region 'ENVIO DE CORREOS DE ORDENES DE SERVICIO

    Private Sub Ck_MostrarFotoVisitante_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_MostrarFotoVisitante.CheckedChanged
        If TablaCarga = "VISITANTE" Then
            If Ck_MostrarFotoVisitante.Checked = True Then
                If Me.DGV_ListaSisControl.SelectedRows.Count = 1 Then
                    CargarFotoVisitante(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
                End If
            Else
                Pb_FotoVisitante.Image = Nothing
            End If
        End If
    End Sub


    Private Sub CargarFotoVisitante(ByVal IdVisitante As Integer)
        Try
            Pb_FotoVisitante.Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(2, IdVisitante)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Pb_FotoVisitante_Click(sender As Object, e As EventArgs) Handles Pb_FotoVisitante.Click
        Dim FrMostrarFoto As New Form
        Dim Pb_Foto As New PictureBox
        With Pb_Foto
            .Dock = DockStyle.Fill
            .Size = New Size(640, 480)
        End With
        With FrMostrarFoto
            .ClientSize = New Size(Pb_Foto.Right, Pb_Foto.Bottom)
            .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            .Controls.Add(Pb_Foto)
            .StartPosition = FormStartPosition.CenterScreen
        End With
        Dim Foto As Boolean = GoogleDrive.DescargarFotos("vis_" + Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value.ToString, "Visitante")
        If Foto Then
            Dim appPath As String = Application.StartupPath + "/Temp.jpg"
            Dim filestream As New IO.FileStream(appPath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim imagen As Image = Image.FromStream(filestream)
            filestream.Close()
            Pb_Foto.Image = imagen
        End If
        FrMostrarFoto.ShowDialog()
        Pb_Foto.Image.Dispose()
        Dim appPath2 As String
        Try
            appPath2 = Application.StartupPath + "\" + "vis_" + Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value.ToString.ToString + ".jpg"
            If My.Computer.FileSystem.FileExists(appPath2) Then
                My.Computer.FileSystem.DeleteFile(appPath2)
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Cambia el listado de filas seleccionadas en la rejilla a sólo la fila con índice indicado por el parámetro.
    ''' </summary>
    ''' <param name="filaActual">Índice de la fila a seleccionar.</param>
    Private Sub UbicarRegistro(filaActual As Integer)
        DGV_ListaSisControl.ClearSelection()
        If filaActual < DGV_ListaSisControl.Rows.Count Then
            DGV_ListaSisControl.Rows(filaActual).Selected = True
            DGV_ListaSisControl.FirstDisplayedScrollingRowIndex = DGV_ListaSisControl.SelectedRows(0).Index
        End If
    End Sub

    Private Sub Cu_SisControl_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, DGV_ListaSisControl.KeyDown, Nbc_SisControl.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                FuncionesBase.FuncionesBase.AbrirAyudaOnline("/Inicio.aspx?MODULO=Siscontrol")
            Case Keys.F2
                CrearOrdenServicio()
            Case Keys.F3
                Buscar_Orden()
            Case Keys.F4
                CargarOrdenesServicio(0)
                OcultarPanelMiniatura()
                OcultarPanelDetalle()
            Case Keys.F5

            Case Keys.F6
                ExportarDatosExcel(DGV_ListaSisControl)
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
            With .Range(.Cells(1, 1), .Cells(1, DGV_ListaSisControl.Columns.Count)).Font
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

    Private Sub Cu_SisControl_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Sc_ListaPrincipal.SplitterDistance = Me.Width * 0.7
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MostrarPanelDetalle()
        Sc_ListaSisControl.Panel2Collapsed = False
        Sc_ListaSisControl.Panel2.Show()
    End Sub

    Private Sub OcultarPanelDetalle()
        Sc_ListaSisControl.Panel2Collapsed = True
        Sc_ListaSisControl.Panel2.Hide()
    End Sub

    Private Sub Ck_VerDetalle_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_VerDetalle.CheckedChanged
        If DGV_ListaSisControl.SelectedRows.Count > 0 Then
            If Ck_VerDetalle.Checked Then
                CargarDetalle(DGV_ListaSisControl.SelectedRows(0).Cells("IDRECEPCION").Value)
            End If
        End If
    End Sub

    Private Sub CargarDetalle(identificador As Object)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand
        comando.Connection = conexion
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtResultados As New DataTable
        Select Case TablaCarga
            Case "RECEPCION"
                comando.CommandText = "SELECT * FROM SC_TrazabilidadRecepcionDocumentos(@IdRecepcion) ORDER BY [FECHAREGISTRO] ASC, [HORAREGISTRO] ASC"
                comando.Parameters.AddWithValue("@IdRecepcion", identificador)
            Case Else
                Exit Sub
        End Select
        Try
            conexion.Open()
            adaptador.Fill(dtResultados)
            conexion.Close()
            Dgv_Detalle.DataSource = dtResultados
            AjustarColumnasDetalle()
        Catch ex As Exception

        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub AjustarColumnasDetalle()
        Dim col As DataGridViewColumn
        For i As Integer = 0 To Dgv_Detalle.Columns.Count
            col = Dgv_Detalle.Columns(i)
            Select Case col.Name
                Case "TIPO"
                    col.HeaderText = "Tipo"
                    col.ToolTipText = "Tipo de movimiento"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "BASE"
                    col.HeaderText = "Base"
                    col.ToolTipText = "Base de origen"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "DEPENDENCIA"
                    col.HeaderText = "Dependencia"
                    col.ToolTipText = "Dependencia de origen"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "BASEENVIO"
                    col.HeaderText = "Base envío"
                    col.ToolTipText = "Base a la que se envía"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "DEPENDENCIAENVIO"
                    col.HeaderText = "Dependencia envío"
                    col.ToolTipText = "Dependencia a la que se envía"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "NUMERORELACION"
                    col.HeaderText = "Nº Relación"
                    col.ToolTipText = "Número de la relación de documentos"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "FECHAREGISTRO"
                    col.HeaderText = "Fecha Registro"
                    col.ToolTipText = "Fecha de registro"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "USUARIOREGISTRA"
                    col.HeaderText = "Usuario registra"
                    col.ToolTipText = "Usuario que registró el movimiento"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Case "PENDIENTERECIBIR"
                    col.HeaderText = "Pte. Recibir"
                    col.ToolTipText = "El documento está pendiente por recibir"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "PENDIENTEFINAL"
                    col.HeaderText = "Pte. Final"
                    col.ToolTipText = "El documento está pendiente por ser recibido en su destino final"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    col.Visible = False
            End Select
            Dgv_Detalle.AutoResizeColumns()
        Next
    End Sub

    Private Sub Nbi_Anular_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Anular.ItemClick
        Try
            If TablaCarga = "CONTRATOS" Then
                If VariablesBase.VariablesBase.IdPersona = Me.DGV_ListaSisControl.Item("IDPERSONAREGISTRA", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value Then
                    AnularContratos()
                Else
                    MsgBox("Solo puede anular la persona que registro", MsgBoxStyle.Critical, "CONTRATOS")
                End If
            Else
                MsgBox("Cargue Contratos", MsgBoxStyle.Critical, "Contratos")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AnularContratos()
        If MsgBox("¿Desea anular el Contrato?", MsgBoxStyle.YesNo, "ANULAR") = MsgBoxResult.Yes Then
            Dim Dt_Documento As DataTable
            Dim Cadena_Consulta_Update As String = ""
            Dim FechaAnulado As String = CStr(Date.Now.Day) + "/" + CStr(Date.Now.Month) + "/" + CStr(Date.Now.Year) + " " + CStr(Date.Now.Hour) + ":" + CStr(Date.Now.Minute) + ":" + CStr(Date.Now.Second) + "." + CStr(Date.Now.Millisecond)
            Cadena_Consulta_Update = "UPDATE SC_CONTRATOS SET ANULADA = 'S' ,  IDPERSONAANULA =  " + CStr(VariablesBase.VariablesBase.IdPersona) + " , FECHAANULACION = '" + FechaAnulado + "' where IDCONTRATO = " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
            Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Consulta.Connection.Open()
            Dt_Documento = New DataTable
            Adaptador.FillSchema(Dt_Documento, SchemaType.Source)
            Adaptador.Fill(Dt_Documento)
            Consulta.Connection.Close()
        End If
        CargarContratos()
    End Sub


    Private Sub Nbi_SubirPdfCorrespondenciaInBloque_ItemClick(sender As Object, e As EventArgs) Handles Nbi_SubirPdfCorrespondenciaExBloque.ItemClick, Nbi_SubirPdfCorrespondenciaInBloque.ItemClick, Nbi_SubirPdfFaxBloque.ItemClick
        Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
        Dim PuedeSubir As Boolean = False
        Dim Tipo As Integer = 0
        If Boton.Name = "Nbi_SubirPdfCorrespondenciaExBloque" Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso(1012) Then
                PuedeSubir = True
            End If
        Else
            If Boton.Name = "Nbi_SubirPdfCorrespondenciaInBloque" Then
                If FuncionesBase.FuncionesBase.ConsultarPermiso(1013) Then
                    PuedeSubir = True
                End If
            Else
                If Boton.Name = "Nbi_SubirPdfFaxBloque" Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(422) Then
                        PuedeSubir = True
                        Tipo = 1
                    End If
                End If
                End If
        End If
        If PuedeSubir Then
            If Tipo = 0 Then
                GoogleDrive.VerificarArchivosEnBaseDatos(7)
            Else
                GoogleDrive.VerificarArchivosEnBaseDatos(8)
            End If

        End If
    End Sub

    Private Sub Nbi_MarcarRecibidoArchivoCentralCE_ItemClick(sender As Object, e As EventArgs) Handles Nbi_MarcarRecibidoArchivoCentralCE.ItemClick, Nbi_MarcarRecibidoArchivoCentralCI.ItemClick
        Dim Documento As String
        If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaSisControl.CurrentCell.RowIndex
            Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
            Dim TienePermiso As Boolean = False
            Dim IdDocumento As String = ""
            Select Case Boton.Name
                Case "Nbi_MarcarRecibidoArchivoCentralCE"
                    If TablaCarga <> "EXTERNA" Then
                        MsgBox("No esta cargada la tabla de Correspondencia Externa", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1014) Then
                        TienePermiso = True
                        Documento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value)
                    Else
                        TienePermiso = False
                        Exit Sub
                    End If
                Case "Nbi_MarcarRecibidoArchivoCentralCI"
                    If TablaCarga <> "INTERNA" Then
                        MsgBox("No esta cargada la tabla de Correspondencia Interna", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1015) Then
                        TienePermiso = True
                        Documento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value)
                    Else
                        TienePermiso = False
                        Exit Sub
                    End If
                Case "Nbi_MarcarRecibidoArchivoCentralFax"
                    If TablaCarga <> "FAX" Then
                        MsgBox("No esta cargada la tabla de FAX", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1016) Then
                        TienePermiso = True
                        Documento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value)
                    Else
                        TienePermiso = False
                        Exit Sub
                    End If
                Case Else
                    TienePermiso = False
                    Exit Sub
            End Select

            If TienePermiso Then
                If MsgBox("¿Desea marcar la correspondencia " + Documento + " como recibida en archivo central?", MsgBoxStyle.YesNo, "RECIBIDA EN EL ARCHIVO CENTRAL") = MsgBoxResult.Yes Then
                    Dim Dt_OrdenServicio As DataTable
                    Dim Cadena_Consulta_Update As String = ""
                    Dim FechaRevisado As String = CStr(Date.Now.Day) + "/" + CStr(Date.Now.Month) + "/" + CStr(Date.Now.Year) + " " + CStr(Date.Now.Hour) + ":" + CStr(Date.Now.Minute) + ":" + CStr(Date.Now.Second) + "." + CStr(Date.Now.Millisecond)
                    Cadena_Consulta_Update = "UPDATE SC_CORRESPONDENCIA SET RECIBIDOARCHIVO = 'S' ,  IDPERSONARECIBIOARCHIVO =  " + CStr(VariablesBase.VariablesBase.IdPersona) + " , FECHARECIBIOARCHIVO = '" + FechaRevisado + "' where IDCORRESPONDENCIAEXTERNA = " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
                    Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                    Consulta.Connection = Conexión
                    Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Dt_OrdenServicio = New DataTable
                    Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
                    Adaptador.Fill(Dt_OrdenServicio)
                    Consulta.Connection.Close()
                    Me.DGV_ListaSisControl.Item("RECIBIDOARCHIVO", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = "S"
                End If
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Nbi_MarcarRevisadoServidorCI_ItemClick(sender As Object, e As EventArgs) Handles Nbi_MarcarRevisadoServidorCE.ItemClick, Nbi_MarcarRevisadoServidorCI.ItemClick
        Dim Documento As String
        If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaSisControl.CurrentCell.RowIndex
            Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
            Dim TienePermiso As Boolean = False
            Dim IdDocumento As String = ""
            Select Case Boton.Name
                Case "Nbi_MarcarRevisadoServidorCE"
                    If TablaCarga <> "EXTERNA" Then
                        MsgBox("No esta cargada la tabla de Correspondencia Externa", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1016) Then
                        TienePermiso = True
                        Documento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value)
                    Else
                        TienePermiso = False
                        Exit Sub
                    End If
                Case "Nbi_MarcarRevisadoServidorCI"
                    If TablaCarga <> "INTERNA" Then
                        MsgBox("No esta cargada la tabla de Correspondencia Interna", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1017) Then
                        TienePermiso = True
                        Documento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value)
                    Else
                        TienePermiso = False
                        Exit Sub
                    End If
                Case Else
                    TienePermiso = False
                    Exit Sub
            End Select

            If TienePermiso Then
                If MsgBox("¿Desea marcar la correspondencia " + Documento + " como revisada en el servidor?", MsgBoxStyle.YesNo, "REVISADO EN EL SERVIDOR") = MsgBoxResult.Yes Then
                    Dim Dt_OrdenServicio As DataTable
                    Dim Cadena_Consulta_Update As String = ""
                    Dim FechaRevisado As String = CStr(Date.Now.Day) + "/" + CStr(Date.Now.Month) + "/" + CStr(Date.Now.Year) + " " + CStr(Date.Now.Hour) + ":" + CStr(Date.Now.Minute) + ":" + CStr(Date.Now.Second) + "." + CStr(Date.Now.Millisecond)
                    Cadena_Consulta_Update = "UPDATE SC_CORRESPONDENCIA SET REVISADOARCHIVOSERVIDOR = 'S' ,  IDPERSONAREVISOARCHIVOSERVIDOR =  " + CStr(VariablesBase.VariablesBase.IdPersona) + " , FECHAREVISADOARCHIVOSERVIDOR = '" + FechaRevisado + "' where IDCORRESPONDENCIAEXTERNA = " + CStr(Me.DGV_ListaSisControl.SelectedRows(0).Cells(0).Value)
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
                    Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                    Consulta.Connection = Conexión
                    Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Dt_OrdenServicio = New DataTable
                    Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
                    Adaptador.Fill(Dt_OrdenServicio)
                    Consulta.Connection.Close()
                    Me.DGV_ListaSisControl.Item("REVISADOARCHIVOSERVIDOR", Me.DGV_ListaSisControl.CurrentCell.RowIndex).Value = "S"
                End If
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Nbi_HistorialArchivosPdfCE_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HistorialArchivosPdfCE.ItemClick, Nbi_HistorialArchivosPdfCI.ItemClick, Nbi_HistorialArchivosPdfFax.ItemClick, Nbi_HistorialArchivosPdfOS.ItemClick, Nbi_HistorialArchivosPdfDO.ItemClick, Nbi_HistorialArchivosPdfCO.ItemClick
        If Me.DGV_ListaSisControl.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaSisControl.CurrentCell.RowIndex
            Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
            Dim CarpetaDrive, AñoDocumento, NombreDocumento, SubidoNube As String
            Dim PuedeVer As Boolean

            Select Case Boton.Name
                Case "Nbi_HistorialArchivosPdfCE"
                    If TablaCarga <> "EXTERNA" Then
                        MsgBox("No esta cargada la tabla de Correspondencia Externa", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1018) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    CarpetaDrive = "Correspondencia"
                    NombreDocumento = DGV_ListaSisControl.Rows(Index_Registro_Actual).Cells("DOCUMENTO").Value.ToString
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString
                Case "Nbi_HistorialArchivosPdfCI"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1019) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    If TablaCarga <> "INTERNA" Then
                        MsgBox("No esta cargada la tabla de Correspondencia Interna", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    CarpetaDrive = "Correspondencia"
                    NombreDocumento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString
                Case "Nbi_HistorialArchivosPdfFax"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1020) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    If TablaCarga <> "FAX" Then
                        MsgBox("No esta cargada la tabla de FAX", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    CarpetaDrive = "Fax"
                    NombreDocumento = Trim(Me.DGV_ListaSisControl.Item("DOCUMENTO", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaSisControl.Item("SUBIDONUBE", Index_Registro_Actual).Value.ToString
                Case "Nbi_HistorialArchivosPdfCO"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1023) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    If TablaCarga <> "CONTRATOS" Then
                        MsgBox("No esta cargada la tabla de Contratos", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    NombreDocumento = "CO-" + Trim(Me.DGV_ListaSisControl.Item("Id", Index_Registro_Actual).Value.ToString)
                    Dim Fecha As Date = Trim(Me.DGV_ListaSisControl.Item("FECHACONTRATO", Index_Registro_Actual).Value.ToString)
                    Dim Año As String = Fecha.Year
                    AñoDocumento = Año
                    SubidoNube = "S"
                    CarpetaDrive = "AutorizaciónDescuento"
                Case "Nbi_HistorialArchivosPdfDO"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1022) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    If TablaCarga <> "DOCUMENTO" Then
                        MsgBox("No esta cargada la tabla de Documento Soporte", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    NombreDocumento = "DS-" + Trim(Me.DGV_ListaSisControl.Item("Id", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString 'Verificar con edwin
                    SubidoNube = "S"
                    CarpetaDrive = "AutorizaciónDescuento"
                Case "Nbi_HistorialArchivosPdfOS"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(1021) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    If TablaCarga <> "ORDENSERVICIO" Then
                        MsgBox("No esta cargada la tabla de órdenes de servicio", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    NombreDocumento = "OS-" + Trim(Me.DGV_ListaSisControl.Item("Id", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaSisControl.Item("Año", Index_Registro_Actual).Value.ToString 'Verificar con edwin
                    SubidoNube = "S"
                    CarpetaDrive = "AutorizaciónDescuento"
                Case Else
                    Exit Sub
            End Select
            'CarpetaDrive = "Pruebas"

            If SubidoNube <> "S" Then
                Exit Sub
            End If
            If PuedeVer Then
                Dim ObjLista As Object = GoogleDrive.DtArchivosEnCarpetaDrive(CarpetaDrive, AñoDocumento, NombreDocumento)
                If ObjLista(0) = 2 Then
                    Dim Dt_ListaArchivos As New DataTable
                    Dt_ListaArchivos = ObjLista(2)
                    If Dt_ListaArchivos.Rows.Count > 0 Then
                        Dim FrHistorialArchivos As New FuncionesGoogle.Fr_HistorialArchivos
                        FrHistorialArchivos.DtArchivos = Dt_ListaArchivos
                        FrHistorialArchivos.CargarDgv()
                        FrHistorialArchivos.ShowDialog()
                    End If
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

        End If
    End Sub

   
End Class 'Cu_SisControl


Public Class ORDENSERVICIO
    Private _Factura As String
    Private _FechaFactura As String
    Private _Valorfactura As String

    Private _Impresa As String
    Private _ANULADA As String

    Private _Id As String
    Private _Consecutivo As String
    Private _FECHA As String

    Private _Contratista As String
    Private _Solicita As String
    Private _Recibe As String

    Private _Cerrada As String
    Private _ValorCierre As String

    Private _FechaAnulacion As String
    Private _FechaRecibe As String
    Private _FechaRegistro As String
    Private _FechaModificacion As String
    Private _Acepta As String

    'Private _Año As String
    'Private _IdConstratista As String
    'Private _Ciudad As String
    'Private _Dirección As String
    'Private _Base As String
    'Private _Dependencia As String
    'Private _Descripción As String
    'Private _IdCentroCosto As String
    'Private _FechaVencimientoFactura As String
    'Private _Observación As String
    'Private _Identificación As String
    'Private _CodigoTipoMoneda As String

    Private _Registra As String
    Private _Modifica As String
    Private _Anula As String
    Private _OrdenCompra As String
    Private _OrdenTrabajo As String
    Private _Codigo As String
    Private _Autoriza As String
    Private _Servidor As String


    <Description("Id de la Orden de Servicio"), _
    Category("Orden de Servicio"),
    DisplayNameAttribute("Id")> _
    Public ReadOnly Property Id() As String
        Get
            Return _Id
        End Get
    End Property

    <Description("Consecutivo Orden de Servicio"), _
    Category("Orden de Servicio"),
    DisplayNameAttribute("Consecutivo")> _
    Public ReadOnly Property Consecutivo() As String
        Get
            Return _Consecutivo
        End Get
    End Property

    <Description("Fecha Orden de Servicio"), _
      Category("Orden de Servicio"),
      DisplayNameAttribute("Fecha Orden de Servicio:")> _
    Public ReadOnly Property FECHA() As String
        Get
            Return _FECHA
        End Get
    End Property

    <Description("Nombre del contratista"), _
   Category("Personas"),
   DisplayNameAttribute("Contratista")> _
    Public ReadOnly Property Contratista() As String
        Get
            Return _Contratista
        End Get
    End Property


    <Description("Persona quien solicita"), _
    Category("Personas"),
    DisplayNameAttribute("Solicita")> _
    Public ReadOnly Property Solicita() As String
        Get
            Return _Solicita
        End Get
    End Property

    <Description("Persona quien recibe"), _
    Category("Personas"),
    DisplayNameAttribute("Recibe")> _
    Public ReadOnly Property Recibe() As String
        Get
            Return _Recibe
        End Get
    End Property

    <Description("Factura Orden de servicio"), _
    Category("Factura"),
    DisplayNameAttribute("Factura")> _
    Public ReadOnly Property Factura() As String
        Get
            Return _Factura
        End Get
    End Property

    <Description("Fecha factura Orden de servicio"), _
    Category("Factura"),
    DisplayNameAttribute("Fecha Factura")> _
    Public ReadOnly Property FechaFactura() As String
        Get
            Return _FechaFactura
        End Get
    End Property

    <Description("valor Factura Orden de servicio"), _
    Category("Factura"),
    DisplayNameAttribute("Valor estimado")> _
    Public ReadOnly Property Valorfactura() As String
        Get
            Return _Valorfactura
        End Get
    End Property

    <Description("Impresión Orden de servicio"), _
    Category("Impresa"),
    DisplayNameAttribute("Impresa")> _
    Public ReadOnly Property Impresa() As String
        Get
            Return _Impresa
        End Get
    End Property

    <Description("Muestra si la orden de servicio esta anulada"), _
    Category("Impresa"),
    DisplayNameAttribute("Anulada")> _
    Public ReadOnly Property ANULADA() As String
        Get
            Return _ANULADA
        End Get
    End Property

    <Description("Cierre"), _
  Category("Datos"),
  DisplayNameAttribute("Cerrada")> _
    Public ReadOnly Property Cerrada() As String
        Get
            Return _Cerrada
        End Get
    End Property

    <Description("ValCierre"), _
    Category("Datos"),
    DisplayNameAttribute("Valor Cierre")> _
    Public ReadOnly Property ValorCierre() As String
        Get
            Return _ValorCierre
        End Get
    End Property

    <Description("Fecha de Anulación"), _
    Category("Impresa"),
    DisplayNameAttribute("Fecha Anulación")> _
    Public ReadOnly Property FechaAnulacion() As String
        Get
            Return _FechaAnulacion
        End Get
    End Property

    <Description("Fecha Recibe"), _
    Category("Impresa"),
    DisplayNameAttribute("Fecha Recibe")> _
    Public ReadOnly Property FechaRecibe() As String
        Get
            Return _FechaRecibe
        End Get
    End Property

    <Description("Fecha de Registro"), _
    Category("Impresa"),
    DisplayNameAttribute("Fecha Registro")> _
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Fecha de Modificación"), _
    Category("Impresa"),
    DisplayNameAttribute("Fecha Modificación")> _
    Public ReadOnly Property FechaModificacion() As String
        Get
            Return _FechaModificacion
        End Get
    End Property

    <Description("Persona que Acepta"), _
    Category(""),
    DisplayNameAttribute("Persona Acepta")> _
    Public ReadOnly Property Acepta() As String
        Get
            Return _Acepta
        End Get
    End Property


    <Description("Persona que Registra"), _
    Category(""),
    DisplayNameAttribute("Persona Registra")> _
    Public ReadOnly Property Registra() As String
        Get
            Return _Registra
        End Get
    End Property

    <Description("Persona que Modifica"), _
    Category(""),
    DisplayNameAttribute("Persona Modifica")> _
    Public ReadOnly Property Modifica() As String
        Get
            Return _Modifica
        End Get
    End Property

    <Description("Persona que Anuló"), _
    Category(""),
    DisplayNameAttribute("Persona Anula")> _
    Public ReadOnly Property Anula() As String
        Get
            Return _Anula
        End Get
    End Property

    <Description("Orden de Compra Asociada"), _
    Category("Orden de Servicio"),
    DisplayNameAttribute("Orden de Compra")> _
    Public ReadOnly Property OrdenCompra() As String
        Get
            Return _OrdenCompra
        End Get
    End Property

    <Description("Orden de Trabajo asociada"), _
    Category("Orden de Servicio"),
    DisplayNameAttribute("Orden de Mantenimiento")> _
    Public ReadOnly Property OrdenTrabajo() As String
        Get
            Return _OrdenTrabajo
        End Get
    End Property

    <Description("Orden de Servicio"), _
    Category("Orden de Servicio"),
    DisplayNameAttribute("Orden de Servicio")> _
    Public ReadOnly Property Codigo() As String
        Get
            Return _Codigo
        End Get
    End Property

    <Description("Autoriza Dcto SS"), _
     Category("Datos"),
     DisplayNameAttribute("Autoriza Dcto SS")> _
    Public ReadOnly Property Autoriza() As String
        Get
            Return _Autoriza
        End Get
    End Property

    <Description("Servidor"), _
    Category("Datos"),
    DisplayNameAttribute("Servidor")> _
    Public ReadOnly Property Servidor() As String
        Get
            Return _Servidor
        End Get
    End Property


    Public Sub New(ByVal FilaOrdenServicio As DataGridViewRow)
        Me._Id = FilaOrdenServicio.Cells("Id").Value
        Me._Consecutivo = FilaOrdenServicio.Cells("Consecutivo").Value
        Me._FECHA = FilaOrdenServicio.Cells("FECHA").Value
        Me._Contratista = FilaOrdenServicio.Cells("Nombre Contratista").Value
        Me._Solicita = FilaOrdenServicio.Cells("Solicita").Value
        If IsDBNull(FilaOrdenServicio.Cells("Recibe").Value) Then
            Me._Recibe = ""
        Else
            Me._Recibe = FilaOrdenServicio.Cells("Recibe").Value
        End If
        Me._Factura = FilaOrdenServicio.Cells("FACTURA").Value

        If IsDBNull(FilaOrdenServicio.Cells("FECHAFACTURA").Value) Then
            Me._FechaFactura = ""
        Else
            Me._FechaFactura = FilaOrdenServicio.Cells("FECHAFACTURA").Value
        End If
        Me._Valorfactura = FilaOrdenServicio.Cells("VALORFACTURA").Value
        If FilaOrdenServicio.Cells("IMPRESA").Value = "S" Then
            Me._Impresa = "Si"
        Else
            Me._Impresa = "No"
        End If
        If FilaOrdenServicio.Cells("ANULADA").Value = "S" Then
            Me._ANULADA = "Si"
            _Anula = FilaOrdenServicio.Cells("Anula").Value
            _FechaAnulacion = FilaOrdenServicio.Cells("FECHAANULACION").Value
        Else
            Me._ANULADA = "No"
            _Anula = ""
            _FechaAnulacion = ""
        End If
        If FilaOrdenServicio.Cells("CERRADA").Value = "S" Then
            Me._Cerrada = "Si"
            Me._ValorCierre = FilaOrdenServicio.Cells("VALORCIERRE").Value
        Else
            Me._Cerrada = "No"
            Me._ValorCierre = ""
        End If
        Try
            _FechaRecibe = FilaOrdenServicio.Cells("FECHARECIBE").Value
        Catch
            _FechaRecibe = ""
        End Try
        _FechaRegistro = FilaOrdenServicio.Cells("FECHAREGISTRO").Value
        _FechaModificacion = FilaOrdenServicio.Cells("FECHAMODIFICACION").Value
        Try
            _Acepta = FilaOrdenServicio.Cells("Acepta").Value
        Catch
            _Acepta = ""
        End Try
        Try
            _Registra = FilaOrdenServicio.Cells("Registra").Value
        Catch
            _Registra = ""
        End Try
        Try
            _Modifica = FilaOrdenServicio.Cells("Modifica").Value
        Catch
            _Modifica = ""
        End Try
        Try
            _Anula = FilaOrdenServicio.Cells("Anula").Value
        Catch
            _Anula = ""
        End Try

        Try
            _OrdenCompra = FilaOrdenServicio.Cells("ORDENCOMPRA").Value
        Catch
            _OrdenCompra = ""
        End Try

        Try
            _OrdenTrabajo = FilaOrdenServicio.Cells("NROORDENSAP").Value
        Catch
            _OrdenTrabajo = ""
        End Try

        Try
            _Codigo = FilaOrdenServicio.Cells("Codigo").Value
        Catch
            _Codigo = ""
        End Try

        Try
            _Autoriza = FilaOrdenServicio.Cells("AUTORIZADESCTSS").Value
        Catch
            _Autoriza = ""
        End Try

        Try
            _Servidor = FilaOrdenServicio.Cells("SERVIDOR").Value
        Catch
            _Servidor = ""
        End Try


    End Sub

End Class 'ORDENSERVICIO

Public Class CORRESPONDENCIA
    Private _IDCORRESPONDENCIAEXTERNA As String
    Private _Año As String
    Private _Consecutivo As String
    Private _Fecha As String
    Private _Empresa As String
    Private _Dirigido As String
    Private _Ciudad As String
    Private _Asunto As String
    Private _Elaborado As String
    Private _Firmado As String
    Private _ANULADA As String
    Private _IMPRESA As String
    Private _TIPO As String
    Private _Direcion As String
    Private _DOCUMENTO As String

    Private _DigitadoPor As String
    Private _UBICADOSERVIDORARCHIVO As String
    Private _RECIBIDOARCHIVO As String
    Private _RecibidoenArchivopor As String
    Private _FechaRecibidoenArchivo As String
    Private _REVISADOARCHIVOSERVIDOR As String
    Private _Revisoenelservidor As String
    Private _FechaqueserevisoenServidor As String


    <Description("Recibido en Archivo Central de ISMOCOL"),
      Category("Control Archivo"),
      DisplayNameAttribute("Recibo en Archivo")>
    Public ReadOnly Property RECIBIDOARCHIVO() As String
        Get
            Return _RECIBIDOARCHIVO
        End Get
    End Property

    <Description("Persona que recibió en Archivo Central"),
      Category("Control Archivo"),
      DisplayNameAttribute("Persona que Recibió en Archivo")>
    Public ReadOnly Property RecibidoenArchivopor() As String
        Get
            Return _RecibidoenArchivopor
        End Get
    End Property

    <Description("Fecha de Recibido en Archivo Central"),
      Category("Control Archivo"),
      DisplayNameAttribute("Fecha Recibió en Archivo")>
    Public ReadOnly Property FechaRecibidoenArchivo() As String
        Get
            Return _FechaRecibidoenArchivo
        End Get
    End Property

    <Description("Ubicado en el servidor de ISMOCOL en PDF"),
      Category("Control Archivo"),
      DisplayNameAttribute("Ubicado Servidor")>
    Public ReadOnly Property UBICADOSERVIDORARCHIVO() As String
        Get
            Return _UBICADOSERVIDORARCHIVO
        End Get
    End Property

    <Description("Archivo Revisado en el servidor de ISMOCOL"),
      Category("Control Archivo"),
      DisplayNameAttribute("Revisado en el Servidor")>
    Public ReadOnly Property REVISADOARCHIVOSERVIDOR() As String
        Get
            Return _REVISADOARCHIVOSERVIDOR
        End Get
    End Property

    <Description("Persona que reviso en el servidor de ISMOCOL"),
      Category("Control Archivo"),
      DisplayNameAttribute("Persona que Reviso en el servidor")>
    Public ReadOnly Property Revisoenelservidor() As String
        Get
            Return _Revisoenelservidor
        End Get
    End Property

    <Description("Fecha en la que se reviso el archivo en el servidor de ISMOCOL"),
      Category("Control Archivo"),
      DisplayNameAttribute("Fecha Revisado en el Servidor")>
    Public ReadOnly Property FechaqueserevisoenServidor() As String
        Get
            Return _FechaqueserevisoenServidor
        End Get
    End Property

    <Description("Id de la correspondencia"),
      Category("Correspondencia"),
      DisplayNameAttribute("Id")>
    Public ReadOnly Property IDCORRESPONDENCIAEXTERNA() As String
        Get
            Return _IDCORRESPONDENCIAEXTERNA
        End Get
    End Property

    <Description("Identificación Documento"),
      Category("Correspondencia"),
      DisplayNameAttribute("Identificación Documento")>
    Public ReadOnly Property DOCUMENTO() As String
        Get
            Return _DOCUMENTO
        End Get
    End Property

    <Description("Muestra si el documento fue anulado"),
      Category("Correspondencia"),
      DisplayNameAttribute("Impresa")>
    Public ReadOnly Property IMPRESA() As String
        Get
            Return _IMPRESA
        End Get
    End Property

    <Description("Muestra si el documento fue anulado"),
      Category("Correspondencia"),
      DisplayNameAttribute("Anulada")>
    Public ReadOnly Property ANULADA() As String
        Get
            Return _ANULADA
        End Get
    End Property

    <Description("Persona que Firma"),
      Category("Persona"),
      DisplayNameAttribute("Firmado")>
    Public ReadOnly Property Firmado() As String
        Get
            Return _Firmado
        End Get
    End Property

    <Description("Persona que elabora"),
      Category("Persona"),
      DisplayNameAttribute("Elaborado")>
    Public ReadOnly Property Elaborado() As String
        Get
            Return _Elaborado
        End Get
    End Property

    <Description("Usuario que digitó"),
      Category("Persona"),
      DisplayNameAttribute("Usuario que digitó")>
    Public ReadOnly Property DigitadoPor() As String
        Get
            Return _DigitadoPor
        End Get
    End Property

    <Description("Fecha en que se realizó la Correspondencia"),
      Category("Correspondencia"),
      DisplayNameAttribute("Fecha de registro")>
    Public ReadOnly Property Fecha() As String
        Get
            Return _Fecha
        End Get
    End Property

    '<Description("Consecutivo de la Correspondencia"),
    ' Category("Correspondencia"),
    ' DisplayNameAttribute("Consecutivo")>
    'Public ReadOnly Property Consecutivo() As String
    '    Get
    '        Return _Consecutivo
    '    End Get
    'End Property

    <Description("Año que se realizo la Correspondencia"),
      Category("Correspondencia"),
      DisplayNameAttribute("Año")>
    Public ReadOnly Property Año() As String
        Get
            Return _Año
        End Get
    End Property

    <Description("Empresa"),
      Category("Correspondencia"),
      DisplayNameAttribute("Empresa")>
    Public ReadOnly Property Empresa() As String
        Get
            Return _Empresa
        End Get
    End Property

    <Description("Tipo de correspondencia"),
      Category("Correspondencia"),
      DisplayNameAttribute("Tipo de correspondencia")>
    Public ReadOnly Property TIPO() As String
        Get
            Return _TIPO
        End Get
    End Property

    <Description("Ciudad"),
   Category("Lugar"),
   DisplayNameAttribute("Ciudad")>
    Public ReadOnly Property Ciudad() As String
        Get
            Return _Ciudad
        End Get
    End Property

    <Description("Dirección si el documento fue anulado"),
      Category("Lugar"),
      DisplayNameAttribute("Dirección")>
    Public ReadOnly Property Direcion() As String
        Get
            Return _Direcion
        End Get
    End Property

    <Description("Dirigido"),
   Category("Persona"),
   DisplayNameAttribute("Dirigido")>
    Public ReadOnly Property Dirigido() As String
        Get
            Return _Dirigido
        End Get
    End Property

    <Description("Asunto de la correspondencia"),
   Category("Correspondencia"),
   DisplayNameAttribute("Asunto")>
    Public ReadOnly Property Asunto() As String
        Get
            Return _Asunto
        End Get
    End Property

    Public Sub New(ByVal FilaCORRESPONDENCIA As DataGridViewRow)
        Select Case FilaCORRESPONDENCIA.Cells("TIPO").Value
            Case "E"
                Me._TIPO = "EXTERNA"
            Case "I"
                Me._TIPO = "INTERNA"
            Case "F"
                Me._TIPO = "FAX"
        End Select

        Me._IDCORRESPONDENCIAEXTERNA = FilaCORRESPONDENCIA.Cells("IDCORRESPONDENCIAEXTERNA").Value
        Me._Ciudad = FilaCORRESPONDENCIA.Cells("Ciudad").Value
        Me._Año = FilaCORRESPONDENCIA.Cells("Año").Value
        Me._Empresa = FilaCORRESPONDENCIA.Cells("Empresa").Value
        Me._Direcion = FilaCORRESPONDENCIA.Cells("Direcion de envio").Value
        Select Case FilaCORRESPONDENCIA.Cells("IMPRESA").Value
            Case "S"
                Me._IMPRESA = "Si"
            Case "N"
                Me._IMPRESA = "No"
        End Select
        Select Case FilaCORRESPONDENCIA.Cells("ANULADA").Value
            Case "S"
                Me._ANULADA = "Si"
            Case "N"
                Me._ANULADA = "No"
        End Select
        Me._Firmado = FilaCORRESPONDENCIA.Cells("Frimado Por").Value
        Me._Fecha = FilaCORRESPONDENCIA.Cells("FECHAREGISTRO").Value
        Me._Dirigido = FilaCORRESPONDENCIA.Cells("Dirigido a ").Value
        Me._Asunto = FilaCORRESPONDENCIA.Cells("Asunto").Value
        Me._Elaborado = FilaCORRESPONDENCIA.Cells("Elaborado Por").Value
        Me._DOCUMENTO = Trim(FilaCORRESPONDENCIA.Cells("DOCUMENTO").Value)
        Try
            Me._DigitadoPor = Trim(FilaCORRESPONDENCIA.Cells("Digitado Por").Value)
        Catch ex As Exception
            Me._DigitadoPor = ""
        End Try
        Try
            Me._UBICADOSERVIDORARCHIVO = Trim(FilaCORRESPONDENCIA.Cells("UBICADOSERVIDORARCHIVO").Value)
        Catch ex As Exception
            Me._UBICADOSERVIDORARCHIVO = ""
        End Try
        Try
            Me._RECIBIDOARCHIVO = Trim(FilaCORRESPONDENCIA.Cells("RECIBIDOARCHIVO").Value)
            Me._RecibidoenArchivopor = Trim(FilaCORRESPONDENCIA.Cells("Recibido en Archivo por").Value)
            Me._FechaRecibidoenArchivo = Trim(FilaCORRESPONDENCIA.Cells("Fecha Recibido en Archivo").Value.ToString)
        Catch ex As Exception
            Me._RECIBIDOARCHIVO = ""
            Me._RecibidoenArchivopor = ""
            Me._FechaRecibidoenArchivo = ""
        End Try
        Try
            Me._REVISADOARCHIVOSERVIDOR = Trim(FilaCORRESPONDENCIA.Cells("REVISADOARCHIVOSERVIDOR").Value)
            Me._Revisoenelservidor = Trim(FilaCORRESPONDENCIA.Cells("Reviso en el servidor").Value)
            Me._FechaqueserevisoenServidor = Trim(FilaCORRESPONDENCIA.Cells("Fecha que se reviso en Servidor").Value.ToString)
        Catch ex As Exception
            Me._REVISADOARCHIVOSERVIDOR = ""
            Me._Revisoenelservidor = ""
            Me._FechaqueserevisoenServidor = ""
        End Try
    End Sub

End Class 'CORRESPONDENCIA

Public Class SOBRE
    Private _Fecha As String
    Private _Depndencia As String
    Private _Funcionario As String
    Private _Base As String
    Private _DepndenciaPara As String
    Private _FuncionarioPara As String
    Private _DireccionPara As String
    Private _Trasportadora As String

    <Description("Dependencia"),
      Category("De"),
      DisplayNameAttribute("Dependencia")>
    Public ReadOnly Property Depndencia() As String
        Get
            Return _Depndencia
        End Get
    End Property

    <Description("Fecha sobre"),
      Category("De"),
      DisplayNameAttribute("Funcionario")>
    Public ReadOnly Property Funcionario() As String
        Get
            Return _Funcionario
        End Get
    End Property

    <Description("Base"),
      Category("Para"),
      DisplayNameAttribute("Base")>
    Public ReadOnly Property Base() As String
        Get
            Return _Base
        End Get
    End Property
    '<Description("Dependencia"),
    '  Category("Para"),
    '  DisplayNameAttribute("Dependencia")>
    'Public ReadOnly Property DepndenciaPara() As String
    '    Get
    '        Return _DepndenciaPara
    '    End Get
    'End Property

    <Description("funcionario para "),
      Category("Para"),
      DisplayNameAttribute("Funcionario")>
    Public ReadOnly Property FuncionarioPara() As String
        Get
            Return _FuncionarioPara
        End Get
    End Property

    <Description("Dirección"),
      Category("Para"),
      DisplayNameAttribute("Dirección")>
    Public ReadOnly Property DireccionPara() As String
        Get
            Return _DireccionPara
        End Get
    End Property

    <Description("Fecha sobre"),
      Category("Fecha"),
      DisplayNameAttribute("Fecha")>
    Public ReadOnly Property Fecha() As String
        Get
            Return _Fecha
        End Get
    End Property

    <Description("Despacho"),
      Category("Transportadora"),
      DisplayNameAttribute("Transportadora")>
    Public ReadOnly Property Trasportadora() As String
        Get
            Return _Trasportadora
        End Get
    End Property

    Public Sub New(ByVal FilaSOBRE As DataGridViewRow)
        Me._Fecha = FilaSOBRE.Cells("FECHAMODIFICACION").Value
        Me._Depndencia = FilaSOBRE.Cells("Dependencia De").Value
        Me._Funcionario = FilaSOBRE.Cells("De").Value
        Me._Base = FilaSOBRE.Cells("Base").Value
        ''Me._DepndenciaPara = FilaSOBRE.Cells("").Value
        Me._FuncionarioPara = FilaSOBRE.Cells("PERSONAPARA").Value
        Me._DireccionPara = FilaSOBRE.Cells("DIRECCIONPARA").Value
        Me._Trasportadora = FilaSOBRE.Cells("Trasportadora").Value
    End Sub

End Class 'SOBRE

Public Class COBRO
    Private _Fecha As String
    Private _Personacobra As String
    Private _Concepto As String
    Private _valor As String
    Private _IVACUENTACOBRO As String
    Private _FECHAVECIMIENTO As String
    Private _PersonaResponsable As String
    Private _PersonaRegistra As String
    Private _PersonaModifica As String
    Private _FechaRegistro As String
    Private _FechaModificación As String

    Private _Centro As String
    Private _SubCentro As String

    <Description("Persona cobra"),
     Category("Cuenta Cobro"),
      DisplayNameAttribute("Persona cobra")>
    Public ReadOnly Property Personacobra() As String
        Get
            Return _Personacobra
        End Get
    End Property

    <Description("Concepto"),
     Category("Cuenta Cobro"),
      DisplayNameAttribute("Concepto")>
    Public ReadOnly Property Concepto() As String
        Get
            Return _Concepto
        End Get
    End Property

    <Description("Valor cuenta de cobro"),
        Category("Cuenta Cobro"),
      DisplayNameAttribute("valor")>
    Public ReadOnly Property valor() As String
        Get
            Return _valor
        End Get
    End Property

    <Description("IVA a cobrar"),
     Category("Cuenta Cobro"),
      DisplayNameAttribute("IVA")>
    Public ReadOnly Property IVACUENTACOBRO() As String
        Get
            Return _IVACUENTACOBRO
        End Get
    End Property


    <Description("Fecha de vencimiento"),
     Category("Cuenta Cobro"),
      DisplayNameAttribute("Fecha de vencimiento")>
    Public ReadOnly Property FECHAVECIMIENTO() As String
        Get
            Return _FECHAVECIMIENTO
        End Get
    End Property


    <Description("Persona Responsable"),
       Category("Cuenta Cobro"),
      DisplayNameAttribute("Persona Responsable")>
    Public ReadOnly Property PersonaResponsable() As String
        Get
            Return _PersonaResponsable
        End Get
    End Property

    <Description("Centro de costo"),
     Category("Cuenta Cobro"),
      DisplayNameAttribute("Centro")>
    Public ReadOnly Property Centro() As String
        Get
            Return _Centro
        End Get
    End Property

    <Description("SubCentro de costo"),
      Category("Cuenta Cobro"),
      DisplayNameAttribute("SubCentro de costo")>
    Public ReadOnly Property SubCentro() As String
        Get
            Return _SubCentro
        End Get
    End Property

    <Description("Fecha sobre"),
     Category("Cuenta Cobro"),
      DisplayNameAttribute("Fecha")>
    Public ReadOnly Property Fecha() As String
        Get
            Return _Fecha
        End Get
    End Property


    <Description("Persona Modifica"),
  Category("Auditoria"),
  DisplayNameAttribute("Persona Modifica")>
    Public ReadOnly Property PersonaModifica() As String
        Get
            Return _PersonaModifica
        End Get
    End Property

    <Description("Persona Registra"),
Category("Auditoria"),
DisplayNameAttribute("Persona Registra")>
    Public ReadOnly Property PersonaRegistra() As String
        Get
            Return _PersonaRegistra
        End Get
    End Property

    <Description("Fecha Registro"),
Category("Auditoria"),
DisplayNameAttribute("Fecha Registro")>
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Fecha Modificación"),
Category("Auditoria"),
DisplayNameAttribute("Fecha Modificación")>
    Public ReadOnly Property FechaModificación() As String
        Get
            Return _FechaModificación
        End Get
    End Property

    Public Sub New(ByVal FilaCOBRO As DataGridViewRow)
        Me._Fecha = FilaCOBRO.Cells("FECHACUENTACOBRO").Value
        Me._Personacobra = FilaCOBRO.Cells("Persona cobra").Value
        Me._Concepto = FilaCOBRO.Cells("Concepto").Value
        Me._valor = FilaCOBRO.Cells("valor").Value
        Me._IVACUENTACOBRO = FilaCOBRO.Cells("IVACUENTACOBRO").Value
        Me._FECHAVECIMIENTO = FilaCOBRO.Cells("FECHAVECIMIENTO").Value
        Me._PersonaResponsable = FilaCOBRO.Cells("Persona Responsoble").Value

        Me._PersonaModifica = FilaCOBRO.Cells("Modifica").Value
        Me._PersonaRegistra = FilaCOBRO.Cells("Registra").Value
        Me._FechaRegistro = FilaCOBRO.Cells("FECHAREGISTRO").Value
        Me._FechaModificación = FilaCOBRO.Cells("FECHAMODIFICACION").Value

        Try
            Me._Centro = FilaCOBRO.Cells("CODIGOCENTROCOSTOSSOLIN").Value
            Me._SubCentro = FilaCOBRO.Cells("SUBCENTROCOSTOSSOLIN").Value
        Catch
            Me._Centro = ""
            Me._SubCentro = ""
        End Try
    End Sub

End Class 'COBRO

Public Class VISITANTE
    Private _Fecha As String
    Private _Empresa As String
    Private _Dependencia As String
    Private _Funcionario As String
    Private _Cedula As String
    Private _Nombre As String
    Private _Fecharegistro As String
    Private _Registra As String
    Private _Fechamodificacion As String
    Private _Modifica As String
    Private _Fechaanulacion As String
    Private _Anula As String
    Private _Anulada As String
    Private _Impresa As String
    Private _Base As String
    Private _Eps As String
    Private _Arl As String
    Private _Viovideoseguridad As String
    Private _Aceptopoliticadatos As String
    Private _Fechasalida As String
    Private _RegistraSalida As String
    Private _Observacion As String
    Private _IdVisitante As String

    <Description("Fecha de Visita"),
    Category("Persona"),
    DisplayNameAttribute("Fecha")>
    Public ReadOnly Property Fecha() As String
        Get
            Return _Fecha
        End Get
    End Property

    <Description("Empresa"),
    Category("Persona"),
    DisplayNameAttribute("Empresa")>
    Public ReadOnly Property Empresa() As String
        Get
            Return _Empresa
        End Get
    End Property

    <Description("Dependencia a visitar"),
    Category("Funcionario"),
    DisplayNameAttribute("Dependencia")>
    Public ReadOnly Property Dependencia() As String
        Get
            Return _Dependencia
        End Get
    End Property

    <Description("Funcionario a visitar"),
    Category("Funcionario"),
    DisplayNameAttribute("Funcionario")>
    Public ReadOnly Property Funcionario() As String
        Get
            Return _Funcionario
        End Get
    End Property

    <Description("Cédula del visitante"),
    Category("Persona"),
    DisplayNameAttribute("Cédula")>
    Public ReadOnly Property Cedula() As String
        Get
            Return _Cedula
        End Get
    End Property

    <Description("Visitante"),
    Category("Persona"),
    DisplayNameAttribute("Visitante")>
    Public ReadOnly Property Nombre() As String
        Get
            Return _Nombre
        End Get
    End Property

    <Description("Id del Visitante"),
    Category("Persona"),
    DisplayNameAttribute("IdVisitante")>
    Public ReadOnly Property IdVisitante() As String
        Get
            Return _IdVisitante
        End Get
    End Property

    <Description("Fecha de registro"),
    Category("Persona"),
    DisplayNameAttribute("Fecha de registro")>
    Public ReadOnly Property Fecharegistro() As String
        Get
            Return _Fecharegistro
        End Get
    End Property

    <Description("Persona que registra"),
    Category("Persona"),
    DisplayNameAttribute("Persona que registra")>
    Public ReadOnly Property Registra() As String
        Get
            Return _Registra
        End Get
    End Property

    <Description("Fecha de modificación"),
    Category("Persona"),
    DisplayNameAttribute("Fecha de modificación")>
    Public ReadOnly Property Fechamodificacion() As String
        Get
            Return _Fechamodificacion
        End Get
    End Property

    <Description("Persona que modifica"),
    Category("Persona"),
    DisplayNameAttribute("Persona que modifica")>
    Public ReadOnly Property Modifica() As String
        Get
            Return _Modifica
        End Get
    End Property

    <Description("Fecha de anulación"),
    Category("Persona"),
    DisplayNameAttribute("Fecha de anulación")>
    Public ReadOnly Property Fechaanulacion() As String
        Get
            Return _Fechaanulacion
        End Get
    End Property

    <Description("Persona que anula"),
    Category("Persona"),
    DisplayNameAttribute("Persona que anula")>
    Public ReadOnly Property Anula() As String
        Get
            Return _Anula
        End Get
    End Property

    <Description("Visita anulada"),
    Category("Persona"),
    DisplayNameAttribute("Visita anulada")>
    Public ReadOnly Property Anulada() As String
        Get
            Return _Anulada
        End Get
    End Property

    <Description("Visita impresa"),
    Category("Persona"),
    DisplayNameAttribute("Visita impresa")>
    Public ReadOnly Property Impresa() As String
        Get
            Return _Impresa
        End Get
    End Property

    <Description("Base SisControl"),
    Category("Persona"),
    DisplayNameAttribute("Base")>
    Public ReadOnly Property Base() As String
        Get
            Return _Base
        End Get
    End Property

    <Description("E.P.S. del Visitante"),
    Category("Persona"),
    DisplayNameAttribute("EPS")>
    Public ReadOnly Property Eps() As String
        Get
            Return _Eps
        End Get
    End Property

    <Description("ARL del Visitante"),
    Category("Persona"),
    DisplayNameAttribute("ARL")>
    Public ReadOnly Property Arl() As String
        Get
            Return _Arl
        End Get
    End Property

    <Description("Vio video de seguridad"),
    Category("Persona"),
    DisplayNameAttribute("Vio video de seguridad")>
    Public ReadOnly Property Viovideoseguridad() As String
        Get
            Return _Viovideoseguridad
        End Get
    End Property

    <Description("Aceptó la política de datos personales"),
    Category("Persona"),
    DisplayNameAttribute("Aceptó política de datos")>
    Public ReadOnly Property Aceptopoliticadatos() As String
        Get
            Return _Aceptopoliticadatos
        End Get
    End Property

    <Description("Fecha de salida"),
    Category("Persona"),
    DisplayNameAttribute("Fecha de salida")>
    Public ReadOnly Property Fechasalida() As String
        Get
            Return _Fechasalida
        End Get
    End Property

    <Description("Persona que registró la salida"),
    Category("Persona"),
    DisplayNameAttribute("Persona que registró la salida")>
    Public ReadOnly Property RegistraSalida() As String
        Get
            Return _RegistraSalida
        End Get
    End Property

    <Description("Observación"),
    Category("Persona"),
    DisplayNameAttribute("Observación")>
    Public ReadOnly Property Observacion() As String
        Get
            Return _Observacion
        End Get
    End Property

    Public Sub New(ByVal FilaVISITANTE As DataGridViewRow)
        Me._Fecha = FilaVISITANTE.Cells("Fecha").Value
        Me._Empresa = FilaVISITANTE.Cells("Empresa").Value
        Me._Dependencia = FilaVISITANTE.Cells("Dependencia").Value
        Me._Funcionario = FilaVISITANTE.Cells("Funcionario").Value
        Me._Cedula = FilaVISITANTE.Cells("Cedula").Value
        Me._Nombre = FilaVISITANTE.Cells("Nombre").Value
        Me._IdVisitante = FilaVISITANTE.Cells("IDVISITANTE").Value
        Me._Fecharegistro = FilaVISITANTE.Cells("FECHAREGISTRO").Value
        Me._Registra = FilaVISITANTE.Cells("Registra").Value
        Me._Fechamodificacion = FilaVISITANTE.Cells("FECHAMODIFICACION").Value
        Me._Modifica = FilaVISITANTE.Cells("Modifica").Value
        Me._Fechaanulacion = FilaVISITANTE.Cells("FECHAANULACION").Value
        Me._Anula = FilaVISITANTE.Cells("Anula").Value
        Me._Anulada = FilaVISITANTE.Cells("ANULADA").Value
        Me._Impresa = FilaVISITANTE.Cells("IMPRESA").Value
        Me._Base = FilaVISITANTE.Cells("Base").Value
        Me._Eps = FilaVISITANTE.Cells("EPS").Value
        Me._Viovideoseguridad = FilaVISITANTE.Cells("VIOVIDEOSEGURIDAD").Value
        Me._Aceptopoliticadatos = FilaVISITANTE.Cells("ACEPTOPOLITICADATOS").Value
        Try
            Me._Fechasalida = FilaVISITANTE.Cells("FECHASALIDA").Value
            Me._RegistraSalida = FilaVISITANTE.Cells("RegistraSalida").Value
        Catch
            Me._Fechasalida = ""
            Me._RegistraSalida = ""
        End Try
        Try
            Me._Observacion = FilaVISITANTE.Cells("OBSERVACION").Value
        Catch ex As Exception
            Me._Observacion = ""
        End Try
    End Sub

End Class 'VISITANTE

Public Class RECEPCION
    '_IdRecepcion
    '_Año
    '_Consecutivo
    Private _IdRecepcion As String
    Private _FechaRecepcion As String
    Private _De As String
    '_PersonaDe
    '_NumeroRadicado
    '_Descripcion
    Private _Valor As String
    Private _Nit As String
    '_Funcionario
    '_FechaRegistro
    '_FechaModificacion
    '_FechaAnulacion
    '_Anulada
    Private _Impresa As String
    Private _NumeroDocumento As String
    '_FechaDocumento
    '_FechaVencimiento
    Private _Memo As String
    '_NumeroRelacion
    '_NombreDependencia
    Private _Sticker As String
    Private _Dependencia As String
    Private _Base As String
    Private _UsuarioRegistra As String
    Private _UsuarioModifica As String
    Private _FechaModifica As Date
    Private _FechaRegistro As Date

    <Description("Id de Recepción"),
    Category("Datos"),
    DisplayNameAttribute("Id Recepción")>
    Public ReadOnly Property IdRecepcion() As String
        Get
            Return _IdRecepcion
        End Get
    End Property

    <Description("Fecha de recepción del documento."),
    Category("Datos"),
    DisplayNameAttribute("Fecha Recepción")>
    Public ReadOnly Property FechaRecepcion() As String
        Get
            Return _FechaRecepcion
        End Get
    End Property

    <Description("Contratista que emite el documento."),
    Category("Contratista"),
    DisplayNameAttribute("De")>
    Public ReadOnly Property De() As String
        Get
            Return _De
        End Get
    End Property

    <Description("Valor de la factura."),
    Category("Factura"),
    DisplayNameAttribute("Valor")>
    Public ReadOnly Property Valor() As String
        Get
            Return _Valor
        End Get
    End Property

    <Description("NIT del contratista."),
    Category("Contratista"),
    DisplayNameAttribute("NIT")>
    Public ReadOnly Property Nit() As String
        Get
            Return _Nit
        End Get
    End Property

    <Description("Indica si el registro ya fue impreso."),
    Category("Datos"),
    DisplayNameAttribute("Impreso")>
    Public ReadOnly Property Impresa() As String
        Get
            Return _Impresa
        End Get
    End Property

    <Description("Número del documento."),
    Category("Factura"),
    DisplayNameAttribute("Documento")>
    Public ReadOnly Property NumeroDocumento() As String
        Get
            Return _NumeroDocumento
        End Get
    End Property

    <Description("Memorando."),
    Category("Datos"),
    DisplayNameAttribute("Memorando")>
    Public ReadOnly Property Memo() As String
        Get
            Return _Memo
        End Get
    End Property

    <Description("Código del sticker."),
    Category("Datos"),
    DisplayNameAttribute("Sticker")>
    Public ReadOnly Property Sticker() As String
        Get
            Return _Sticker
        End Get
    End Property

    <Description("Usuario que realizó el registro"),
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Registra")>
    Public ReadOnly Property UsuarioRegistra() As String
        Get
            Return _UsuarioRegistra
        End Get
    End Property

    <Description("Usuario que modificó el registro"),
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Modifica")>
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property

    <Description("Fecha del Registro"),
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Registro")>
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Fecha Modificación"),
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Modificación")>
    Public ReadOnly Property FechaModifica() As String
        Get
            Return _FechaModifica
        End Get
    End Property


    <Description("Dependencia donde se realizo el registro"),
    Category("Datos"),
    DisplayNameAttribute("Dependencia")>
    Public ReadOnly Property Dependencia() As String
        Get
            Return _Dependencia
        End Get
    End Property

    <Description("Base donde se realizo el registro"),
    Category("Datos"),
    DisplayNameAttribute("Base")>
    Public ReadOnly Property Base() As String
        Get
            Return _Base
        End Get
    End Property


    Public Sub New(ByVal FilaRESEPCIONA As DataGridViewRow)

        Try
            _IdRecepcion = FilaRESEPCIONA.Cells("IDRECEPCION").Value
        Catch
            _IdRecepcion = ""
        End Try

        Try
            _FechaRecepcion = FilaRESEPCIONA.Cells("Fecha").Value
        Catch
            _FechaRecepcion = ""
        End Try
        Try
            _De = FilaRESEPCIONA.Cells("DE").Value
        Catch
            _De = ""
        End Try
        Try
            _Valor = FormatCurrency(FilaRESEPCIONA.Cells("VALOR").Value, 0)
        Catch
            _Valor = ""
        End Try
        Try
            _Nit = FilaRESEPCIONA.Cells("NIT").Value
        Catch
            _Nit = ""
        End Try
        Try
            Select Case FilaRESEPCIONA.Cells("IMPRESA").Value
                Case "N"
                    _Impresa = "No"
                Case "S"
                    _Impresa = "Sí"
                Case Else
                    _Impresa = ""
            End Select
        Catch
            _Impresa = ""
        End Try
        Try
            _NumeroDocumento = FilaRESEPCIONA.Cells("NUMERODOCUMENTO").Value
        Catch
            _NumeroDocumento = ""
        End Try
        Try
            _Memo = FilaRESEPCIONA.Cells("MEMO").Value
        Catch
            _Memo = ""
        End Try
        Try
            _Sticker = FilaRESEPCIONA.Cells("STICKER").Value
        Catch
            _Sticker = ""
        End Try
        Try
            _UsuarioRegistra = FilaRESEPCIONA.Cells("PERSONAREGISTRA").Value
        Catch
            _UsuarioRegistra = ""
        End Try
        Try
            _UsuarioModifica = FilaRESEPCIONA.Cells("PERSONAMODIFICA").Value
        Catch
            _UsuarioModifica = ""
        End Try
        Try
            _FechaRegistro = FilaRESEPCIONA.Cells("FECHAREGISTRO").Value
        Catch
            _FechaRegistro = ""
        End Try
        Try
            _FechaModifica = FilaRESEPCIONA.Cells("FECHAMODIFICACION").Value
        Catch
            _FechaModifica = ""
        End Try
        Try
            _Dependencia = FilaRESEPCIONA.Cells("NOMBREDEPENDENCIA").Value
        Catch
            _Dependencia = ""
        End Try
        Try
            _Base = FilaRESEPCIONA.Cells("NOMBREBASE").Value
        Catch
            _Base = ""
        End Try
    End Sub

End Class 'RECEPCION

Public Class BOLETASALIDA
    Private _Id As String
    Private _Consecutivo As String
    Private _Solicita As String
    Private _JefeDepartamento As String
    Private _JefeDpto_Admin As String

    <Description("Id"),
    Category("Boleta"),
    DisplayNameAttribute("Id")>
    Public ReadOnly Property Id() As String
        Get
            Return _Id
        End Get
    End Property

    <Description("Consecutivo"),
    Category("Boleta"),
    DisplayNameAttribute("Consecutivo")>
    Public ReadOnly Property Consecutivo() As String
        Get
            Return _Consecutivo
        End Get
    End Property

    <Description("Persona quien solicita"),
    Category("Personas"),
    DisplayNameAttribute("Solicita")>
    Public ReadOnly Property Solicita() As String
        Get
            Return _Solicita
        End Get
    End Property

    <Description("Jefe departamento"),
    Category("Personas"),
    DisplayNameAttribute("Jefe Departamento")>
    Public ReadOnly Property JefeDepartamento() As String
        Get
            Return _JefeDepartamento
        End Get
    End Property

    <Description("Jefe Administración"),
    Category("Personas"),
    DisplayNameAttribute("Jefe Administración")>
    Public ReadOnly Property JefeDpto_Admin() As String
        Get
            Return _JefeDpto_Admin
        End Get
    End Property


    Public Sub New(ByVal FilaBOLETASALIDA As DataGridViewRow)
        Me._Id = FilaBOLETASALIDA.Cells("Id").Value
        Me._Consecutivo = FilaBOLETASALIDA.Cells("Año").Value.ToString + " - " + FilaBOLETASALIDA.Cells("Consecutivo").Value.ToString
        Me._Solicita = FilaBOLETASALIDA.Cells("Solicita").Value
        Me._JefeDepartamento = FilaBOLETASALIDA.Cells("Jefe de Departamento").Value
        Me._JefeDpto_Admin = FilaBOLETASALIDA.Cells("Jefe de Dpto_ Administrativo").Value
    End Sub

End Class 'BOLETASALIDA

Public Class FE_APROBACION
    Private _idAprobacion As String
    Private _aprobacion As String = ""
    Private _tipoAprobacion As String = ""
    Private _nombreBase As String = ""
    Private _nombreDependencia As String = ""
    Private _personaAprueba As String = ""
    Private _correoAprueba As String = ""
    Private _identificacionNIT As String = ""
    Private _proveedor As String = ""
    Private _valor As String = ""
    Private _moneda As String = ""
    Private _fechaRegistro As String = ""
    Private _personaRegistra As String = ""
    Private _correoRegistra As String = ""
    Private _fechaModificacion As String = ""
    Private _personaModifica As String = ""
    Private _aceptada As String = ""
    Private _fechaAceptacion As String = ""
    Private _personaAcepta As String = ""
    Private _factura As String = ""
    Private _tieneRechazos As String = ""
    Private _anulada As String = ""
    Private _fechaAnulacion As String = ""
    Private _personaAnula As String = ""
    Private _motivoAnulacion As String = ""
    Private _subidoServidorFacturaPdf As String = ""
    Private _fechaSubidoFacturaPdf As String = ""
    Private _personaSubioFacturaPdf As String = ""
    Private _subidoServidorFacturaXml As String = ""
    Private _fechaSubidoFacturaXml As String = ""
    Private _personaSubioFacturaXml As String = ""
    Private _subidoServidorAcusePdf As String = ""
    Private _fechaSubidoAcusePdf As String = ""
    Private _personaSubioAcusePdf As String = ""
    Private _subidoServidorAcuseXml As String = ""
    Private _fechaSubidoAcuseXml As String = ""
    Private _personaSubioAcuseXml As String = ""

    <Description("Identificador de Aprobación."),
    Category("01. Aprobación"),
    DisplayNameAttribute("Id Aprobación")>
    ReadOnly Property IdAprobacion As String
        Get
            Return _idAprobacion
        End Get
    End Property

    <Description("Número de Aprobación."),
    Category("01. Aprobación"),
    DisplayNameAttribute("No. Aprobación")>
    ReadOnly Property Aprobacion As String
        Get
            Return _aprobacion
        End Get
    End Property

    <Description("Tipo de Aprobación."),
    Category("01. Aprobación"),
    DisplayNameAttribute("Tipo Aprobación")>
    ReadOnly Property TipoAprobacion As String
        Get
            Return _tipoAprobacion
        End Get
    End Property

    <Description("Base que genera la Aprobación."),
    Category("02. Dependencia"),
    DisplayNameAttribute("Base")>
    ReadOnly Property NombreBase As String
        Get
            Return _nombreBase
        End Get
    End Property

    <Description("Dependencia que genera la Aprobación."),
    Category("02. Dependencia"),
    DisplayNameAttribute("Dependencia")>
    ReadOnly Property NombreDependencia As String
        Get
            Return _nombreDependencia
        End Get
    End Property

    <Description("Persona que efectúa la aprobación."),
    Category("01. Aprobación"),
    DisplayNameAttribute("Persona Aprueba")>
    ReadOnly Property PersonaAprueba As String
        Get
            Return _personaAprueba
        End Get
    End Property

    <Description("Correo de la persona que efectúa la aprobación."),
    Category("01. Aprobación"),
    DisplayNameAttribute("Correo Persona Aprueba")>
    ReadOnly Property CorreoAprueba As String
        Get
            Return _correoAprueba
        End Get
    End Property

    <Description("Identificación o NIT del Proveedor o Contratista."),
    Category("03. Proveedor"),
    DisplayNameAttribute("Identificación")>
    ReadOnly Property IdentificacionNit As String
        Get
            Return _identificacionNIT
        End Get
    End Property

    <Description("Proveedor o Contratista."),
    Category("03. Proveedor"),
    DisplayNameAttribute("Proveedor")>
    ReadOnly Property Proveedor As String
        Get
            Return _proveedor
        End Get
    End Property

    <Description("Valor de la Aprobación."),
    Category("04. Valor"),
    DisplayNameAttribute("Valor")>
    ReadOnly Property Valor As String
        Get
            Return _valor
        End Get
    End Property

    <Description("Tipo de divisa del valor de la aprobación."),
    Category("04. Valor"),
    DisplayNameAttribute("Moneda")>
    ReadOnly Property Moneda As String
        Get
            Return _moneda
        End Get
    End Property

    <Description("Fecha de registro de la aprobación."),
    Category("05. Registro"),
    DisplayNameAttribute("Fecha Registro")>
    ReadOnly Property FechaRegistro As String
        Get
            Return _fechaRegistro
        End Get
    End Property

    <Description("Persona que registró la aprobación."),
    Category("05. Registro"),
    DisplayNameAttribute("Persona Registra")>
    ReadOnly Property PersonaRegistra As String
        Get
            Return _personaRegistra
        End Get
    End Property

    <Description("Correo de la persona que registró la aprobación."),
    Category("05. Registro"),
    DisplayNameAttribute("Correo Persona Registra")>
    ReadOnly Property CorreoRegistra As String
        Get
            Return _correoRegistra
        End Get
    End Property

    <Description("Fecha de modificación de la aprobación."),
    Category("06. Modificación"),
    DisplayNameAttribute("Fecha Modificación")>
    ReadOnly Property FechaModificacion As String
        Get
            Return _fechaModificacion
        End Get
    End Property

    <Description("Persona que modificó la aprobación."),
    Category("06. Modificación"),
    DisplayNameAttribute("Persona Modifica")>
    ReadOnly Property PersonaModifica As String
        Get
            Return _personaModifica
        End Get
    End Property

    <Description("Si la aprobación tiene Aceptación registrada."),
    Category("09. Aceptación"),
    DisplayNameAttribute("Aceptada")>
    ReadOnly Property Aceptada As String
        Get
            Return _aceptada
        End Get
    End Property

    <Description("Fecha de registro de la Aceptación"),
    Category("09. Aceptación"),
    DisplayNameAttribute("Fecha Aceptación")>
    ReadOnly Property FechaAceptacion As String
        Get
            Return _fechaAceptacion
        End Get
    End Property

    <Description("Persona que reigstró la Aceptación."),
    Category("09. Aceptación"),
    DisplayNameAttribute("Persona Acepta")>
    ReadOnly Property PersonaAcepta As String
        Get
            Return _personaAcepta
        End Get
    End Property

    <Description("Número de la Factura Electrónica aceptada."),
    Category("09. Aceptación"),
    DisplayNameAttribute("Factura")>
    ReadOnly Property Factura As String
        Get
            Return _factura
        End Get
    End Property

    <Description("Si la aprobación cuenta con Rechazos."),
    Category("08. Rechazo"),
    DisplayNameAttribute("Tiene Rechazos")>
    ReadOnly Property TieneRechazos As String
        Get
            Return _tieneRechazos
        End Get
    End Property

    <Description("Si la Aprobación está Anulada."),
    Category("07. Anulación"),
    DisplayNameAttribute("Anulada")>
    ReadOnly Property Anulada As String
        Get
            Return _anulada
        End Get
    End Property

    <Description("Fecha de Anulación de la Aprobación."),
    Category("07. Anulación"),
    DisplayNameAttribute("Fecha Anulación")>
    ReadOnly Property FechaAnulacion As String
        Get
            Return _fechaAnulacion
        End Get
    End Property

    <Description("Persona que Anuló la Aprobación."),
    Category("07. Anulación"),
    DisplayNameAttribute("Persona Anula")>
    ReadOnly Property PersonaAnula As String
        Get
            Return _personaAnula
        End Get
    End Property

    <Description("Motivo de la Anulación de la Aprobación."),
    Category("07. Anulación"),
    DisplayNameAttribute("Motivo Anulación")>
    ReadOnly Property MotivoAnulacion As String
        Get
            Return _motivoAnulacion
        End Get
    End Property

    <Description("Si el archivo PDF de la factura electrónica se subió al servidor."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Subido Factura PDF")>
    ReadOnly Property SubidoServidorFacturaPdf As String
        Get
            Return _subidoServidorFacturaPdf
        End Get
    End Property

    <Description("Fecha de carga del archivo PDF de la factura al servidor."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Fecha Carga Factura PDF")>
    ReadOnly Property FechaSubidoFacturaPdf As String
        Get
            Return _fechaSubidoFacturaPdf
        End Get
    End Property

    <Description("Persona que subió el archivo PDF de la factura al servidor."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Persona Subió Factura PDF")>
    ReadOnly Property PersonaSubioFacturaPdf As String
        Get
            Return _personaSubioFacturaPdf
        End Get
    End Property

    <Description("Si el archivo XML de la factura electrónica se subió al servidor."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Subido Factura XML")>
    ReadOnly Property SubidoServidorFacturaXml As String
        Get
            Return _subidoServidorFacturaXml
        End Get
    End Property

    <Description("Fecha de carga del archivo XML de la factura al servidor."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Fecha Carga Factura XML")>
    ReadOnly Property FechaSubidoFacturaXml As String
        Get
            Return _fechaSubidoFacturaXml
        End Get
    End Property

    <Description("Persona que subió el archivo XML de la factura al servidor."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Persona Subió Factura XML")>
    ReadOnly Property PersonaSubioFacturaXml As String
        Get
            Return _personaSubioFacturaXml
        End Get
    End Property

    <Description("Si el archivo PDF del acuse de recibo se subió al servidor."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Subido Acuse PDF")>
    ReadOnly Property SubidoServidorAcusePdf As String
        Get
            Return _subidoServidorAcusePdf
        End Get
    End Property

    <Description("Fecha de carga del archivo PDF del acuse de recibo."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Fecha Carga Acuse de Recibo PDF")>
    ReadOnly Property FechaSubidoAcusePdf As String
        Get
            Return _fechaSubidoAcusePdf
        End Get
    End Property

    <Description("Persona que subió el archivo PDF del acuse de recibo."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Persona Subió Acuse de Recibo PDF")>
    ReadOnly Property PersonaSubioAcusePdf As String
        Get
            Return _personaSubioAcusePdf
        End Get
    End Property

    <Description("Si el archivo XML del acuse de recibo se subió al servidor."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Subido Acuse XML")>
    ReadOnly Property SubidoServidorAcuseXml As String
        Get
            Return _subidoServidorAcuseXml
        End Get
    End Property

    <Description("Fecha de carga del archivo XML del acuse de recibo."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Fecha Carga Acuse de Recibo XML")>
    ReadOnly Property FechaSubidoAcuseXml As String
        Get
            Return _fechaSubidoAcuseXml
        End Get
    End Property

    <Description("Persona que subió el archivo XML del acuse de recibo."),
    Category("10. Archivos Servidor"),
    DisplayNameAttribute("Persona Subió Acuse de Recibo XML")>
    ReadOnly Property PersonaSubioAcuseXml As String
        Get
            Return _personaSubioAcuseXml
        End Get
    End Property


    Public Sub New(ByVal fila As DataGridViewRow)
        _idAprobacion = fila.Cells("IDAPROBACION").Value    ' Linea se encontraba con marca de comentario
        Try
            _aprobacion = fila.Cells("APROBACION").Value
        Catch
            _aprobacion = ""
        End Try
        Try
            _tipoAprobacion = fila.Cells("NOMBRETIPOAPROBACION").Value
        Catch
            _tipoAprobacion = ""
        End Try
        Try
            _nombreBase = fila.Cells("NOMBREBASE").Value
        Catch
            _nombreBase = ""
        End Try
        Try
            _nombreDependencia = fila.Cells("NOMBREDEPENDENCIA").Value
        Catch
            _nombreDependencia = ""
        End Try
        Try
            _personaAprueba = fila.Cells("PERSONAAPRUEBA").Value
        Catch
            _personaAprueba = ""
        End Try
        Try
            _correoAprueba = fila.Cells("CORREOPERSONAAPRUEBA").Value
        Catch
            _correoAprueba = ""
        End Try

        Try
            _identificacionNIT = fila.Cells("NIT").Value
        Catch
            _identificacionNIT = ""
        End Try
        Try
            _proveedor = fila.Cells("PROVEEDOR").Value
        Catch
            _proveedor = ""
        End Try

        Try
            _valor = fila.Cells("VALORPESOS").Value 'fila.Cells("VALOR").Value
        Catch
            _valor = ""
        End Try
        Try
            _moneda = fila.Cells("SIGLAISO").Value
        Catch
            _moneda = ""
        End Try

        Try
            _fechaRegistro = fila.Cells("FECHAREGISTRO").Value
        Catch
            _fechaRegistro = ""
        End Try
        Try
            _personaRegistra = fila.Cells("PERSONAREGISTRA").Value
        Catch
            _personaRegistra = ""
        End Try
        Try
            _correoRegistra = fila.Cells("CORREOPERSONAREGISTRA").Value
        Catch
            _correoRegistra = ""
        End Try

        Try
            _fechaModificacion = fila.Cells("FECHAMODIFICACION").Value
        Catch
            _fechaModificacion = ""
        End Try
        Try
            _personaModifica = fila.Cells("PERSONAMODIFICA").Value
        Catch
            _personaModifica = ""
        End Try

        Try
            Select Case fila.Cells("ACEPTADA").Value
                Case "S"
                    _aceptada = "Sí"
                Case Else
                    _aceptada = "No"
            End Select
        Catch
            _aceptada = ""
        End Try
        Try
            _fechaAceptacion = fila.Cells("FECHAACEPTACION").Value
        Catch
            _fechaAceptacion = ""
        End Try
        Try
            _personaAcepta = fila.Cells("PERSONAACEPTA").Value
        Catch
            _personaAcepta = ""
        End Try
        Try
            _factura = fila.Cells("FACTURA").Value
        Catch
            _factura = ""
        End Try

        Try
            Select Case fila.Cells("TIENERECHAZOS").Value
                Case "S"
                    _tieneRechazos = "Sí"
                Case Else
                    _tieneRechazos = "No"
            End Select
        Catch
            _tieneRechazos = ""
        End Try

        Try
            Select Case fila.Cells("ANULADA").Value
                Case "S"
                    _anulada = "Sí"
                Case Else
                    _anulada = "No"
            End Select
        Catch
            _anulada = ""
        End Try
        Try
            _fechaAnulacion = fila.Cells("FECHAANULACION").Value
        Catch
            _fechaAnulacion = ""
        End Try
        Try
            _personaAnula = fila.Cells("PERSONAANULA").Value
        Catch
            _personaAnula = ""
        End Try
        Try
            _motivoAnulacion = fila.Cells("MOTIVOANULACION").Value
        Catch
            _motivoAnulacion = ""
        End Try

        Try
            Select Case fila.Cells("SUBIDOSERVIDORFACTURAPDF").Value
                Case "S"
                    _subidoServidorFacturaPdf = "Sí"
                Case Else
                    _subidoServidorFacturaPdf = "No"
            End Select
        Catch
            _subidoServidorFacturaPdf = ""
        End Try
        Try
            _fechaSubidoFacturaPdf = fila.Cells("FECHASUBIDOFACTURAPDF").Value
        Catch
            _fechaSubidoFacturaPdf = ""
        End Try
        Try
            _personaSubioFacturaPdf = fila.Cells("PERSONASUBIOFACTURAPDF").Value
        Catch
            _personaSubioFacturaPdf = ""
        End Try

        Try
            Select Case fila.Cells("SUBIDOSERVIDORFACTURAXML").Value
                Case "S"
                    _subidoServidorFacturaXml = "Sí"
                Case Else
                    _subidoServidorFacturaXml = "No"
            End Select
        Catch
            _subidoServidorFacturaXml = ""
        End Try
        Try
            _fechaSubidoFacturaXml = fila.Cells("FECHASUBIDOFACTURAXML").Value
        Catch
            _fechaSubidoFacturaXml = ""
        End Try
        Try
            _personaSubioFacturaXml = fila.Cells("PERSONASUBIOFACTURAXML").Value
        Catch
            _personaSubioFacturaXml = ""
        End Try

        Try
            Select Case fila.Cells("SUBIDOSERVIDORACUSEPDF").Value
                Case "S"
                    _subidoServidorAcusePdf = "Sí"
                Case Else
                    _subidoServidorAcusePdf = "No"
            End Select
        Catch
            _subidoServidorAcusePdf = ""
        End Try
        Try
            _fechaSubidoAcusePdf = fila.Cells("FECHASUBIDOACUSEPDF").Value
        Catch
            _fechaSubidoAcusePdf = ""
        End Try
        Try
            _personaSubioAcusePdf = fila.Cells("PERSONASUBIOACUSEPDF").Value
        Catch
            _personaSubioAcusePdf = ""
        End Try

        Try
            Select Case fila.Cells("SUBIDOSERVIDORACUSEXML").Value
                Case "S"
                    _subidoServidorAcuseXml = "Sí"
                Case Else
                    _subidoServidorAcuseXml = "No"
            End Select
        Catch
            _subidoServidorAcuseXml = ""
        End Try
        Try
            _fechaSubidoAcuseXml = fila.Cells("FECHASUBIDOACUSEXML").Value
        Catch
            _fechaSubidoAcuseXml = ""
        End Try
        Try
            _personaSubioAcuseXml = fila.Cells("PERSONASUBIOACUSEXML").Value
        Catch
            _personaSubioAcuseXml = ""
        End Try

    End Sub
End Class 'FE_APROBACION

Public Class FE_RECHAZO
    Private _idRechazo As String

    <Description("Identificador de Rechazo de Aprobación"),
    Category(""),
    DisplayNameAttribute("Id Rechazo")>
    ReadOnly Property IdRechazo As String
        Get
            Return _idRechazo
        End Get
    End Property


    Public Sub New(ByVal fila As DataGridViewRow)
        _idRechazo = fila.Cells("IDRECHAZO").Value
    End Sub
End Class 'FE_RECHAZO

Public Class DOCUMENTO

    Private _Identificador As String
    Private _Impreso As String = ""
    Private _aprobado As String = ""
    Private _UsuarioRegistra As String = ""
    Private _UsuarioModifica As String = ""
    Private _UsuarioAnula As String = ""
    Private _UsuarioAprueba As String = ""
    Private _FechaRegistro As String = ""
    Private _FechaModifica As String = ""
    Private _FechaAnula As String = ""
    Private _FechaAprueba As String = ""

    <Description("Identificador de Documento."),
    Category("Datos"),
    DisplayNameAttribute("Id Documento")>
    ReadOnly Property IdDcoumento As String
        Get
            Return _Identificador
        End Get
    End Property

    <Description("Estado de impresion."),
    Category("Datos"),
    DisplayNameAttribute("Impreso")>
    ReadOnly Property Impreso As String
        Get
            Return _Impreso
        End Get
    End Property

    <Description("Aprobación Documento."),
    Category("Datos"),
    DisplayNameAttribute("Aprobado")>
    ReadOnly Property Aprobacion As String
        Get
            Return _aprobado
        End Get
    End Property

    <Description("Persona quien elaboró el documento"),
    Category("Auditoria"),
    DisplayNameAttribute("Usuario Registro")>
    ReadOnly Property UsuarioRegistra As String
        Get
            Return _UsuarioRegistra
        End Get
    End Property

    <Description("Persona quien modifico el documento."),
    Category("Auditoria"),
    DisplayNameAttribute("Usuario Modifica")>
    ReadOnly Property UsuarioModifica As String
        Get
            Return _UsuarioModifica
        End Get
    End Property

    <Description("Persona quien anuló el documento."),
    Category("Auditoria"),
    DisplayNameAttribute("Usuario Anula")>
    ReadOnly Property UsuarioAnula As String
        Get
            Return _UsuarioAnula
        End Get
    End Property

    <Description("Persona quien aprueba el documento."),
    Category("Auditoria"),
    DisplayNameAttribute("Usuario Aprueba")>
    ReadOnly Property UsuarioAprueba As String
        Get
            Return _UsuarioAprueba
        End Get
    End Property

    <Description("Fecha de Registro del documento."),
    Category("Auditoria"),
    DisplayNameAttribute("Fecha Registro")>
    ReadOnly Property FechaRegistro As String
        Get
            Return _FechaRegistro
        End Get
    End Property


    <Description("Fecha de modificación de documento."),
    Category("Auditoria"),
    DisplayNameAttribute("Fecha Modificación")>
    ReadOnly Property FModifica As String
        Get
            Return _FechaModifica
        End Get
    End Property

    <Description("Fecha de anulación del documento."),
    Category("Auditoria"),
    DisplayNameAttribute("Fecha Anulación")>
    ReadOnly Property FAnulacion As String
        Get
            Return _FechaAnula
        End Get
    End Property

    <Description("Fecha de aprobación del documento."),
    Category("Auditoria"),
    DisplayNameAttribute("Fecha Aprobación")>
    ReadOnly Property FAprueba As String
        Get
            Return _FechaAprueba
        End Get
    End Property


    Public Sub New(ByVal fila As DataGridViewRow)

        Try
            _Identificador = fila.Cells("Id").Value
        Catch
            _Identificador = ""
        End Try

        Try
            Select Case fila.Cells("Impresa").Value
                Case "S"
                    _Impreso = "Sí"
                Case Else
                    _Impreso = "No"
            End Select
        Catch
            _Impreso = ""
        End Try

        Try
            Select Case fila.Cells("APROBADO").Value
                Case "S"
                    _aprobado = "Sí"
                Case Else
                    _aprobado = "No"
            End Select
        Catch
            _aprobado = ""
        End Try

        Try
            _UsuarioRegistra = fila.Cells("Registra").Value
        Catch
            _UsuarioRegistra = ""
        End Try

        Try
            _UsuarioModifica = fila.Cells("Modifica").Value
        Catch
            _UsuarioModifica = ""
        End Try

        Try
            _UsuarioAnula = fila.Cells("Anula").Value
        Catch
            _UsuarioAnula = ""
        End Try

        Try
            _UsuarioAprueba = fila.Cells("Aprueba").Value
        Catch
            _UsuarioAprueba = ""
        End Try

        Try
            _FechaRegistro = fila.Cells("FECHAREGISTRO").Value
        Catch
            _FechaRegistro = ""
        End Try

        Try
            _FechaModifica = fila.Cells("FECHAMODIFICACION").Value
        Catch
            _FechaModifica = ""
        End Try

        Try
            _FechaAnula = fila.Cells("FECHAANULACION").Value
        Catch
            _FechaAnula = ""
        End Try

        Try
            _FechaAprueba = fila.Cells("FECHAAPROBACION").Value
        Catch
            _FechaAprueba = ""
        End Try




    End Sub


End Class

Public Class CONTRATO
    Private _idcontrato As String
    Private _PersonaRegistra As String
    Private _PersonaModifica As String
    Private _FechaRegistra As String
    Private _FechaModifica As String
    Private _UsuarioAnula As String = ""
    Private _FechaAnula As String = ""

    <Description("Identificador de Rechazo de Aprobación"),
    Category(""),
    DisplayNameAttribute("Id Contrato")>
    ReadOnly Property IdContrato As String
        Get
            Return _idcontrato
        End Get
    End Property

    <Description("Persona quien elaboró el documento"),
    Category("Auditoria"),
    DisplayNameAttribute("Usuario Registro")>
    ReadOnly Property UsuarioRegistra As String
        Get
            Return _PersonaRegistra
        End Get
    End Property

    <Description("Persona quien modifico el documento."),
    Category("Auditoria"),
    DisplayNameAttribute("Usuario Modifica")>
    ReadOnly Property UsuarioModifica As String
        Get
            Return _PersonaModifica
        End Get
    End Property

    <Description("Fecha de Registro del documento."),
      Category("Auditoria"),
      DisplayNameAttribute("Fecha Registro")>
    ReadOnly Property FechaRegistro As String
        Get
            Return _FechaRegistra
        End Get
    End Property


    <Description("Fecha de modificación de documento."),
    Category("Auditoria"),
    DisplayNameAttribute("Fecha Modificación")>
    ReadOnly Property FModifica As String
        Get
            Return _FechaModifica
        End Get
    End Property

    <Description("Persona quien anuló el documento."),
Category("Auditoria"),
DisplayNameAttribute("Usuario Anula")>
    ReadOnly Property UsuarioAnula As String
        Get
            Return _UsuarioAnula
        End Get
    End Property

    <Description("Fecha de anulación del documento."),
    Category("Auditoria"),
    DisplayNameAttribute("Fecha Anulación")>
    ReadOnly Property FAnulacion As String
        Get
            Return _FechaAnula
        End Get
    End Property


    Public Sub New(ByVal fila As DataGridViewRow)

        Try
            _idcontrato = fila.Cells("Id").Value
        Catch
            _idcontrato = ""
        End Try

        Try
            _PersonaRegistra = fila.Cells("Registra").Value
        Catch
            _PersonaRegistra = ""
        End Try

        Try
            _PersonaModifica = fila.Cells("Modifica").Value
        Catch
            _PersonaModifica = ""
        End Try

        Try
            _FechaRegistra = fila.Cells("FECHAREGISTRO").Value
        Catch
            _FechaRegistra = ""
        End Try

        Try
            _FechaModifica = fila.Cells("FECHAMODIFICACION").Value
        Catch
            _FechaModifica = ""
        End Try

        Try
            _UsuarioAnula = fila.Cells("Anula").Value
        Catch
            _UsuarioAnula = ""
        End Try

        Try
            _FechaAnula = fila.Cells("FECHAANULACION").Value
        Catch
            _FechaAnula = ""
        End Try
    End Sub
  




End Class 'FE_RECHAZO
