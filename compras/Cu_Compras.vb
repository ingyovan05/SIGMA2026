Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Text
Imports System.Threading
Imports Requisición
Imports Microsoft.Office.Interop
Imports System.Net
Imports System.IO
Imports OrdenCompra

Public Class Cu_Compras
    Dim DsOrdenCompra As New DatosOrdenCompra.Ds_OrdenCompra
    Dim DsProveedor As New DatosProveedores.Ds_Proveedor
    Dim DsEntradas As New DatosEntradaAlmacén.Ds_EntradaAlmacén
    Dim DsFacturas As New Facturas.Ds_Facturas
    Dim TablaCargada As String = ""
    Dim ListarEntradaAlmacenTableAdapter As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.LISTAENTRADAALMACENTableAdapter
    Dim LISTASUMINISTROSPROVEEDOR As New DatosProveedores.Ds_ProveedorTableAdapters.LISTASUMINISTROPROVEEDORTableAdapter
    Dim DsRequisicion As New DatosRequisición.Ds_Requisicion
    Dim Tipo_Tabla_Cargada_RQ As Integer
    Dim Tipo_Tabla_Cargada_OC As Integer
    Dim Index_Registro_Actual As Integer = -1
    Dim bddatos As New DatosClasesBase.Busquedas
    Dim dsRequisiciones As New DataSet
    Dim dsOrdenesCompra As New DataSet
    Dim dsProveedores As New DataSet
    Public IDORDENCOOMPRA As Integer
    Public IDORDENCOMPRAMODIFICANDO As Integer = -1
    Private bddatos1 As New FuncionesBase.ClaseCargarMaestras
    Private WithEvents Bw_correosOCsPendientesRegistroFactura As New BackgroundWorker
    Dim Columna As Integer
    Dim TipoListaCargadaProveedores As Integer
    Dim NITListaCargadaProveedores As String
    Private listadoBodegasVirtualesCMC As New List(Of Integer) From {131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146}
    Public Tipo As String

    'FUNCIONES DE COPIAR REQUISICION EN EL PORTAPAPELES
    Public webbrowser As WebBrowser
    Dim formwebcopiar As Form

    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter

    Private GoogleDrive As New FuncionesGoogle.FuncionesGoogle

    Public Sub Comportamiento_Predeterminado()
        Me.Nbc_Compras.ActiveGroup = Me.Nbg_Requisiciones
        Me.DGV_ListaRequisiciones.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.DGV_ListaRequisiciones.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        'Permisos
        Nbc_Compras.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbc_Compras.Tag)
        Nbg_Requisiciones.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Requisiciones.Tag)
        Nbg_OrdenCompra.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_OrdenCompra.Tag)
        Nbg_Proveedores.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Proveedores.Tag)
        Nbg_Factura.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Factura.Tag)
        Nbg_SolicitudMaquinaria.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_SolicitudMaquinaria.Tag)
        Nbg_Filtro.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Filtro.Tag)

        'Requisición
        Nbi_CargarRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarRQ.Tag)
        'If Not listadoBodegasVirtualesCMC.Contains(VariablesBase.VariablesBase.IdBodegaActual) Then
        Nbi_CrearRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearRQ.Tag)
        'Else
        '    Nbi_CrearRQ.Visible = False
        'End If
        Nbi_VerRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerRQ.Tag)
        Nbi_EditarRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarRQ.Tag)
        ' If Not listadoBodegasVirtualesCMC.Contains(VariablesBase.VariablesBase.IdBodegaActual) Then
        Nbi_GenerarOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_GenerarOC.Tag)
        '  Else
        '  Nbi_GenerarOC.Visible = False
        '  End If
        Nbi_CancelarRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarRQ.Tag)
        Nbi_ImprimirRequisición.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirRequisición.Tag)
        Nbi_ImprimirComplementoRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirComplementoRQ.Tag)
        Nbi_AsignarComprador.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AsignarComprador.Tag)
        Nbi_RevisiónBodegaPrincipal.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RevisiónBodegaPrincipal.Tag)
        Nbi_TrazabilidadRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_TrazabilidadRQ.Tag)
        Nbi_BuscarRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarRQ.Tag)
        'Nbi_BuscarXarticuloRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarXarticuloRQ.Tag)
        Nbi_HablitarImpresionRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HablitarImpresionRQ.Tag)
        'Nbi_CopiarRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CopiarRQ.Tag)
        Nbi_CambiarTipoStock.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CambiarTipoStock.Tag)
        Cms_CancelarItemRQ.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_CancelarItemRQ.Tag)
        Nbi_PendienteRQxUsers.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_PendienteRQxUsers.Tag)
        Nbi_VistoBuenoGerencia.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VistoBuenoGerencia.Tag)
        Nbi_SubirPDFVbG.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPDFVbG.Tag)
        Nbi_VerPDFVbG.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPDFVbG.Tag)
        Nbi_SubirPdfBloqueRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfBloqueRQ.Tag)
        Nbi_HistorialArchivosPdfRQ.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialArchivosPdfRQ.Tag)

        'Órdenes de Compra
        Nbi_CargarOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarOC.Tag)
        'If Not listadoBodegasVirtualesCMC.Contains(VariablesBase.VariablesBase.IdBodegaActual) Then
        '    Nbi_CrearOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearOC.Tag)
        'Else
        Nbi_CrearOC.Visible = False
        'End If
        Nbi_VerOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerOC.Tag)
        Nbi_EditarOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarOC.Tag)
        Nbi_CancelarOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarOC.Tag)
        Nbi_ImprimirOrdenCompra.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirOrdenCompra.Tag)
        Nbi_BuscarOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarOC.Tag)
        Nbi_HabilitarImpresionOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HabilitarImpresionOC.Tag)
        'Nbi_CopiarOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CopiarOC.Tag)
        Cms_CancelarItemOC.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_CancelarItemOC.Tag)
        Nb_PendienteOCxEAxUser.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nb_PendienteOCxEAxUser.Tag)
        Nbi_VerEAxOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerEAxOC.Tag)
        Nbi_BuscarxArticulo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarxArticulo.Tag)
        Nbi_DistribuirCostos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_DistribuirCostos.Tag)
        Nbi_SubirOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirOC.Tag)
        Nbi_VerPdfOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPdfOC.Tag)
        Nbi_SubirPdfBloqueOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfBloqueOC.Tag)
        Nbi_HistorialArchivosPdfOC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialArchivosPdfOC.Tag)

        'Proveedores
        Nbi_CargarProveedor.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarProveedor.Tag)
        Nbi_CrearProveedor.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearProveedor.Tag)
        Nbi_EditarProveedor.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarProveedor.Tag)
        'Nbi_BuscarPorSuministro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarPorSuministro.Tag)
        'Nbi_BucarXArticulo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BucarXArticulo.Tag)
        'Nbi_BucarXCiudad.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BucarXCiudad.Tag)
        'Nbi_BucarProveedor.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BucarProveedor.Tag)

        'Factura
        Nbi_CargarRelaciónFacturas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarRelaciónFacturas.Tag)
        Nbi_CrearRelaciónFacturas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearRelaciónFacturas.Tag)
        Nbi_EditarRelaciónFacturas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarRelaciónFacturas.Tag)
        Nbi_ImprimirRelación.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirRelación.Tag)
        Nbi_RegistrarFactura.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarFactura.Tag)
        Nbi_RelFactura.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RelFactura.Tag)
        Nbi_VerFacturas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerFacturas.Tag)
        Nbi_HabilitarImpresionRelacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HabilitarImpresionRelacion.Tag)
        Nbi_CargarRelaciónFacturasTodas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarRelaciónFacturasTodas.Tag)
        Nbi_EnviarCorreosOCSinFacturaAsociada.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EnviarCorreosOCSinFacturaAsociada.Tag)
        Nbi_SubirPdfRelacionFactura.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfRelacionFactura.Tag)
        Nbi_VerPdfRelacionFactura.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPdfRelacionFactura.Tag)
        Nbi_SubirPdfBloqueRF.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfBloqueRF.Tag)
        Nbi_HistorialArchivosFactura.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialArchivosFactura.Tag)

        'Solicitud de Maquinaria
        Nbi_CargarSolicitud.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarSolicitud.Tag)
        Nbi_CrearSolicitud.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearSolicitud.Tag)
        Nbi_VerSolicitud.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerSolicitud.Tag)
        Nbi_EditarSolicitud.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarSolicitud.Tag)
        Nbi_ImprimirSolicitud.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirSolicitud.Tag)
        Nbi_BuscarSolicitud.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarSolicitud.Tag)
        Nbi_ConvertirA_Rq.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ConvertirA_Rq.Tag)
    End Sub

#Region "Cargar Tablas"
    Dim dt_opcionesfiltro1 As New DataTable("OPCIONES")
    Dim dt_opcionesfiltro2 As New DataTable("OPCIONES")
    Dim dt_opcionesfiltro3 As New DataTable("OPCIONES")


    Public Sub Cargar_Tabla()
        If Me.dt_opcionesfiltro1.Columns.Count = 0 Then
            Me.dt_opcionesfiltro1.Columns.Add("OPCION")
            Me.dt_opcionesfiltro2.Columns.Add("OPCION")
            Me.dt_opcionesfiltro3.Columns.Add("OPCION")
        End If

        Me.Cb_FiltrarPor1.DataSource = Me.dt_opcionesfiltro1
        Me.Cb_FiltrarPor1.DisplayMember = "OPCION"
        Me.Cb_FiltrarPor1.ValueMember = "OPCION"
        Me.Cb_FiltrarPor2.DataSource = Me.dt_opcionesfiltro2
        Me.Cb_FiltrarPor2.DisplayMember = "OPCION"
        Me.Cb_FiltrarPor2.ValueMember = "OPCION"
        Me.Cb_FiltrarPor3.DataSource = Me.dt_opcionesfiltro3
        Me.Cb_FiltrarPor3.DisplayMember = "OPCION"
        Me.Cb_FiltrarPor3.ValueMember = "OPCION"
        If (VariablesBase.VariablesBase.IdBodegaActual = 1) Then

            CargarTablaxDefectoRequisiciones1()
        Else
            CargarTablaxDefectoRequisiciones()

        End If



    End Sub

    Private Sub CargarTablaxDefectoRequisiciones1()
        dsRequisiciones = bddatos.BusquedaCondiciones(10, 1, 4, 1, "", 0, Date.Now, Date.Now, 7, 1000)
        If dsRequisiciones.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            dsRequisiciones.Tables.Remove(dsRequisiciones.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsRequisiciones.Clear()
        End If
        TablaCargada = "LISTAREQUISICION"
        CargarRequisicionFiltro(dsRequisiciones)
    End Sub

    Private Sub CargarTablaxDefectoRequisiciones()
        dsRequisiciones = bddatos.BusquedaCondiciones(10, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        If dsRequisiciones.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            dsRequisiciones.Tables.Remove(dsRequisiciones.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsRequisiciones.Clear()
        End If
        TablaCargada = "LISTAREQUISICION"
        CargarRequisicionFiltro(dsRequisiciones)
    End Sub


    Private Sub CargarCanceladasXdefecto()
        dsRequisiciones = bddatos.BusquedaCondiciones(10, 5, 4, 1, "", 0, Date.Now, Date.Now, 5, 20)
        If dsRequisiciones.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            dsRequisiciones.Tables.Remove(dsRequisiciones.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsRequisiciones.Clear()
        End If
        TablaCargada = "LISTAREQUISICIONCANCELADAS"
        CargarRequisicionFiltro(dsRequisiciones)
    End Sub


    Private Sub Nbi_CargarRQ_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarRQ.ItemClick
        CargarTablaxDefectoRequisiciones()
    End Sub


    Private Sub Nbi_CargarOC_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarOC.ItemClick
        CargarOCxDefecto()

        Dgv_ListaItemRequisición.ContextMenuStrip.Enabled = True
    End Sub


    Private Sub CargarOCxDefecto()
        dsOrdenesCompra = bddatos.BusquedaCondiciones(11, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        If dsOrdenesCompra.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            dsOrdenesCompra.Tables.Remove(dsOrdenesCompra.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsOrdenesCompra.Clear()
        End If
        TablaCargada = "LISTAORDENCOMPRA"
        CargarOrdenCompraFiltro(dsOrdenesCompra)

        If Tipo_Tabla_Cargada_OC = 8 Then
            Me.Lb_Cargado.Text = "ORDENES DE COMPRA CON CANCELACIONES"
            Lb_Filtro.Text = "Órdenes de Compra Canceladas"
        Else
            Me.Lb_Cargado.Text = "ORDENES DE COMPRA"
            Lb_Filtro.Text = "Órdenes de Compra"
        End If
    End Sub


    Private Sub Nbi_CargarProveedor_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarProveedor.ItemClick
        CargarProveedoresXdefecto()
    End Sub


    Private Sub CargarProveedoresXdefecto()
        dsProveedores = bddatos.BusquedaCondiciones(12, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
        Try
            If dsProveedores.Tables.Count > 1 Then 'si el procedimiento trae más de una tabla es decir la tabla de conteo y la tabla de datos
                dsProveedores.Tables.Remove(dsProveedores.Tables(0).TableName) 'borrar la tabla del conteo 
            Else 'si solo trae el conteo es porque se exceden los campos
                MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
                dsProveedores.Clear()
            End If
            TablaCargada = "LISTAPROVEEDORES"
            CargarProveedoresFiltro(dsProveedores)
        Catch ex As Exception
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
        End Try
    End Sub


    Private Sub Cargar_LISTAPROVEEDORES(ByVal TIPO As Integer, ByVal NIT As String) 'CARGUE DE TABLAS VIEJO
        TipoListaCargadaProveedores = TIPO
        NITListaCargadaProveedores = NIT

        Dim adap As New DatosProveedores.Ds_ProveedorTableAdapters.LISTAPROVEEDORESTableAdapter
        adap.FillXTIPO(Me.DsProveedor.LISTAPROVEEDORES, TIPO, NIT)

        If TIPO = 5 Then
            If DsProveedor.LISTAPROVEEDORES.Count = 0 Then
                MsgBox("No se encontraron proveedores.", MsgBoxStyle.Critical, "PROVEEDORES")
                Exit Sub
            End If
        End If

        DGV_ListaRequisiciones.DataSource = Nothing

        Me.DGV_ListaRequisiciones.DataSource = Me.DsProveedor.LISTAPROVEEDORES
        Me.Pn_ListaPrincipal.Height = Pn_ContenedorPrincipal.Height
        Me.DGV_ListaRequisiciones.AutoGenerateColumns = True
        Me.DGV_ListaRequisiciones.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.dt_opcionesfiltro1.Rows.Clear()
        Me.dt_opcionesfiltro2.Rows.Clear()
        Me.dt_opcionesfiltro3.Rows.Clear()
        Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()

        For i = 0 To DGV_ListaRequisiciones.ColumnCount - 1
            Dim filaopciónfiltro1 As DataRow
            Dim filaopciónfiltro2 As DataRow
            Dim filaopciónfiltro3 As DataRow
            filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
            filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
            filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
            filaopciónfiltro1("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            filaopciónfiltro2("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            filaopciónfiltro3("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
            dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
            dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
            CargarTablaxDefectoRequisiciones()
            Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
            Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_ListaRequisiciones.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
            Submenuitem.Name = DGV_ListaRequisiciones.Columns(i).Name
            Submenuitem.Size = New System.Drawing.Size(152, 22)
            Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})

            Select Case DGV_ListaRequisiciones.Columns(i).Name
                Case "Ciudad", "Dirección", "Telefóno", "Email", "Representate Venta", "Tel Rep Venta"
                    DGV_ListaRequisiciones.Columns(i).Visible = False
                Case "Id"
                    DGV_ListaRequisiciones.Columns(i).Width = 30
                Case "Identificación"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle = VariablesBase.VariablesBase.style
                    DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Nombre"
                    DGV_ListaRequisiciones.Columns(i).Width = 300
                Case "Celular"
                    DGV_ListaRequisiciones.Columns(i).Width = 150
            End Select
        Next
        Me.Dgv_ListaItemRequisición.ContextMenuStrip = Nothing
        TablaCargada = "LISTAPROVEEDORES"
        Me.Lb_Cargado.Text = "PROVEEDORES"
        Lb_Filtro.Text = "Proveedores"
        Me.Lb_CantidadRequisición.Text = "Lista de proveedores, está viendo  " + Me.DsProveedor.LISTAPROVEEDORES.Rows.Count.ToString + " proveedores"
        Try
            Me.DGV_ListaRequisiciones.Rows(0).Selected = True
            CargarListaxSeleccion()
        Catch ex As Exception
        End Try
        Me.Dgv_ListaItemRequisición.DataSource = Nothing
    End Sub

    Dim dsCargar1 As New DataSet
    Private Sub CargarItems()
        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Select Case TablaCargada
                Case "LISTAREQUISICION", "LISTAREQUISICIONCANCELADAS"
                    Dim identificador As Long
                    identificador = Me.DGV_ListaRequisiciones.Rows(DGV_ListaRequisiciones.CurrentRow.Index).Cells("id").Value

                    If Tipo_Tabla_Cargada_RQ = 11 Then
                        dsCargar1 = bddatos1.CargarMaestrasMateriales(4, VariablesBase.VariablesBase.IdBodegaActual, identificador, 1)
                        Dgv_ListaItemRequisición.DataSource = dsCargar1.Tables(0)
                    Else
                        dsCargar1 = bddatos1.CargarMaestrasMateriales(4, VariablesBase.VariablesBase.IdBodegaActual, identificador, 2)
                        Dgv_ListaItemRequisición.DataSource = dsCargar1.Tables(0)
                    End If
                    Me.Lb_CantidadItems.Text = "Item asociados a la requisición, cantidad:" + dsCargar1.Tables(0).Rows.Count.ToString
                    Dgv_ListaItemRequisición.Columns(0).Width = 50
                    Dgv_ListaItemRequisición.Columns(1).Width = 50
                    Dgv_ListaItemRequisición.Columns(2).Width = 50
                    Dgv_ListaItemRequisición.Columns(3).Width = 50
                    Dgv_ListaItemRequisición.Columns(4).Width = 50
                    Dgv_ListaItemRequisición.Columns(5).Width = Dgv_ListaItemRequisición.Width - 430
                    Dgv_ListaItemRequisición.Columns(6).Width = 50
                    Dgv_ListaItemRequisición.Columns(7).Width = 70

                Case "LISTAORDENCOMPRA"
                    Dim ada As New DatosOrdenCompra.Ds_OrdenCompraTableAdapters.ListaItemOCTableAdapter
                    If Tipo_Tabla_Cargada_OC = 8 Then
                        ada.FillByITEMOCCANCELADOS(DsOrdenCompra.ListaItemOC, Me.DGV_ListaRequisiciones.Rows(DGV_ListaRequisiciones.CurrentRow.Index).Cells("id").Value)
                    Else
                        ada.FillXIDORDENCOMPRA(DsOrdenCompra.ListaItemOC, Me.DGV_ListaRequisiciones.Rows(DGV_ListaRequisiciones.CurrentRow.Index).Cells("id").Value)
                    End If

                    Me.Dgv_ListaItemRequisición.DataSource = DsOrdenCompra.ListaItemOC
                    Me.Lb_CantidadItems.Text = "Item asociados a la orden de compra, cantidad:" + DsOrdenCompra.ListaItemOC.Rows.Count.ToString
                    Dgv_ListaItemRequisición.Columns(0).Width = 40
                    Dgv_ListaItemRequisición.Columns(1).Width = 50
                    Dgv_ListaItemRequisición.Columns(2).Width = 50
                    Dgv_ListaItemRequisición.Columns(3).Width = Dgv_ListaItemRequisición.Width - 740
                    Dgv_ListaItemRequisición.Columns(4).Width = 50
                    Dgv_ListaItemRequisición.Columns(5).Width = 50
                    Dgv_ListaItemRequisición.Columns(6).Width = 50
                    Dgv_ListaItemRequisición.Columns(7).Width = 50
                    Dgv_ListaItemRequisición.Columns(8).Width = 50
                    Dgv_ListaItemRequisición.Columns(9).Width = 50
                    Dgv_ListaItemRequisición.Columns(10).Width = 50
                    Dgv_ListaItemRequisición.Columns(11).Width = 50
                    Dgv_ListaItemRequisición.Columns(12).Width = 70
                Case "LISTAPROVEEDORES"

                Case "LISTARELACIONESFACTURAS"
                    Me.Dgv_ListaItemRequisición.DataSource = DsFacturas.RELACIONARDOCUMENTOS
                    Dim ada As New Facturas.Ds_FacturasTableAdapters.RELACIONARDOCUMENTOSTableAdapter
                    ada.FillByIDRELACIONDOCUMENTO(Me.DsFacturas.RELACIONARDOCUMENTOS, Me.DGV_ListaRequisiciones.Rows(DGV_ListaRequisiciones.CurrentRow.Index).Cells("id").Value)
                    Me.Lb_CantidadItems.Text = "Facturas asociadas a la relación, cantidad:" + DsFacturas.RELACIONARDOCUMENTOS.Rows.Count.ToString
                    Dgv_ListaItemRequisición.Columns(0).Visible = False
                    Dgv_ListaItemRequisición.Columns(1).Width = 60
                    Dgv_ListaItemRequisición.Columns(2).Width = 70
                    Dgv_ListaItemRequisición.Columns(3).Width = 120
                    Dgv_ListaItemRequisición.Columns(4).Width = Dgv_ListaItemRequisición.Width - 800
                    Dgv_ListaItemRequisición.Columns(5).Width = 120
                    Dgv_ListaItemRequisición.Columns(6).Width = 120
                    Dgv_ListaItemRequisición.Columns(7).Width = 100
                    Dgv_ListaItemRequisición.Columns(8).Visible = False
                    Dgv_ListaItemRequisición.Columns(9).Width = 80
                    Dgv_ListaItemRequisición.Columns(10).Width = 80
                    Dgv_ListaItemRequisición.Columns(11).Visible = False
                    Dgv_ListaItemRequisición.Columns(12).Visible = False
                Case "LISTASOLICITUDMAQUINARIA"
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("SELECT * FROM dbo.ListaItemSolicitudMaquinaria(@IDSOLICITUDMAQUINARIA) ORDER BY [IDITEMSOLICITUDMAQUINARIA] ASC", conexion)
                    comando.Parameters.AddWithValue("@IDSOLICITUDMAQUINARIA", DGV_ListaRequisiciones.Rows(DGV_ListaRequisiciones.CurrentRow.Index).Cells("IDSOLICITUDMAQUINARIA").Value)
                    Dim adaptador As New SqlDataAdapter(comando)
                    Dim dtItemSM As New DataTable
                    Try
                        conexion.Open()
                        adaptador.FillSchema(dtItemSM, SchemaType.Source)
                        adaptador.Fill(dtItemSM)
                        conexion.Close()
                        Dgv_ListaItemRequisición.DataSource = dtItemSM
                        Lb_CantidadItems.Text = "Ítems asociados a la Solicitud de Maquinaria y Equipo, cantidad:" & dsCargar1.Tables(0).Rows.Count
                        For i As Integer = 0 To Dgv_ListaItemRequisición.ColumnCount - 1
                            Select Case Dgv_ListaItemRequisición.Columns(i).Name
                                Case Dgv_ListaItemRequisición.Columns("IDITEMSOLICITUDMAQUINARIA").Name
                                    Dgv_ListaItemRequisición.Columns(i).Width = 55
                                    Dgv_ListaItemRequisición.Columns(i).HeaderText = "Ítem"
                                Case Dgv_ListaItemRequisición.Columns("IDARTICULO").Name
                                    Dgv_ListaItemRequisición.Columns(i).Width = 55
                                    Dgv_ListaItemRequisición.Columns(i).HeaderText = "Ref."
                                Case Dgv_ListaItemRequisición.Columns("DESCRIPCION").Name
                                    Dgv_ListaItemRequisición.Columns(i).Width = 600
                                    Dgv_ListaItemRequisición.Columns(i).HeaderText = "Descripción"
                                Case Dgv_ListaItemRequisición.Columns("CANTIDAD").Name
                                    Dgv_ListaItemRequisición.Columns(i).Width = 75
                                    Dgv_ListaItemRequisición.Columns(i).HeaderText = "Cantidad"
                                Case Dgv_ListaItemRequisición.Columns("FECHAREQUIERE").Name
                                    Dgv_ListaItemRequisición.Columns(i).Width = 160
                                    Dgv_ListaItemRequisición.Columns(i).HeaderText = "Fecha en que se Requiere"
                                Case Else
                                    Dgv_ListaItemRequisición.Columns(i).Visible = False
                            End Select
                        Next
                    Catch ex As Exception

                    Finally
                        conexion.Close()
                    End Try
            End Select
            Me.Dgv_ListaItemRequisición.ClearSelection()
            Windows.Forms.Cursor.Current = Cursors.Default
        Catch ex As Exception
        End Try
    End Sub
#End Region 'Cargar Tablas

#Region "Crear"
    Private Sub Nbi_CrearRQ_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearRQ.ItemClick
        CrearRequisición()
    End Sub

    Private Sub CrearRequisición()
        Dim FrRequisicion As New Requisición.Fr_Requisicion
        FrRequisicion.TIPO = 1
        FrRequisicion.Tb_Base.Text = VariablesBase.VariablesBase.NombreBodegaActual
        FrRequisicion.Tb_Origen.Text = VariablesBase.VariablesBase.DireccionBodegaActual
        FrRequisicion.EDITANDO = False
        FrRequisicion.guardado = False
        FrRequisicion.CargarTablas()
        FrRequisicion.ShowDialog()
        If FrRequisicion.DialogResult = Windows.Forms.DialogResult.OK Then
            TablaCargada = "LISTAREQUISICION"
            If FrRequisicion.guardado = True And FrRequisicion.EDITANDO = False Then
                Cargar_Tabla()
                IMPRIMIR()
            ElseIf FrRequisicion.guardado = True And FrRequisicion.EDITANDO = True Then
                IMPRIMIR()
            End If
        Else
            If FrRequisicion.guardado = True And FrRequisicion.EDITANDO = False Then
                Cargar_Tabla()
                IMPRIMIR()
            ElseIf FrRequisicion.guardado = True And FrRequisicion.EDITANDO = True Then
                IMPRIMIR()
            End If
        End If

    End Sub

    'Private Sub Nbi_CrearOC_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearOC.ItemClick
    '    Dim DgSeleccionarRequisición As New Requisición.Dg_SeleccionarRequisición
    '    DgSeleccionarRequisición.CargarCombos()
    '    DgSeleccionarRequisición.CargarRequisiciones()
    '    DgSeleccionarRequisición.ShowDialog()
    '    If DgSeleccionarRequisición.DialogResult = Windows.Forms.DialogResult.OK Then
    '        TablaCargada = "LISTAORDENCOMPRA"
    '        Dim FrOrdenCompra As New OrdenCompra.Fr_OrdenCompra
    '        FrOrdenCompra.Editando = False
    '        FrOrdenCompra.IDREQUISICION = DgSeleccionarRequisición.IDREQUISICION
    '        FrOrdenCompra.CargarDatos()
    '        If FrOrdenCompra.guardado = False Then
    '            FrOrdenCompra.ShowDialog()
    '            CargarOCxDefecto()
    '        End If
    '    End If
    'End Sub


    Private Sub Nbi_GenerarOC_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_GenerarOC.ItemClick
        If TablaCargada = "LISTAREQUISICION" Then
            Try
                Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
                If Not FuncionesBase.FuncionesBase.EsBodegaPrincipal(VariablesBase.VariablesBase.IdBodegaActual) Then
                    If VariablesBase.VariablesBase.IdBodegaActual <> Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value Then
                        MsgBox("Solo se pueden tramitar las Requisiciones de la misma bodega. Favor cambiar de bodega para tramitar la requisicion seleccionada", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
                If IsDBNull(Me.DGV_ListaRequisiciones.Item("Persona que gestiona", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value) Then
                    MsgBox("Solo se pueden tramitar las Requisiciones asignadas", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If
                'revisar que el usuario asignado sea el que esta generando la orden
                Dim idusuariocompra As Integer
                Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()
                Dim dsComprador As New DataSet

                dsComprador = bddatos.ModificarEntradasSalidas(23, 0, 0, 0, Date.Now, 0, Date.Now, "", 0, Me.DGV_ListaRequisiciones.CurrentRow.Cells("id").Value)
                If dsComprador.Tables(0).Rows.Count > 0 Then
                    idusuariocompra = dsComprador.Tables(0).Rows(0)("IDPERSONA")
                    If idusuariocompra <> VariablesBase.VariablesBase.IdPersona And (VariablesBase.VariablesBase.IdPersona <> 0 And VariablesBase.VariablesBase.IdPersona <> 18445) Then '18445 Cristhian Zárate
                        MsgBox("Solo los compradores Asignados pueden Generar las Ordenes de Compra", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                End If
                '
                Dim FrOrdenCompra As New OrdenCompra.Fr_OrdenCompra
                FrOrdenCompra.Editando = False
                FrOrdenCompra.IDREQUISICION = Me.DGV_ListaRequisiciones.Item(0, Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                FrOrdenCompra.CargarDatos()
                If FrOrdenCompra.guardado = False Then
                    FrOrdenCompra.ShowDialog()
                    Cargar_Tabla()
                End If
                Ubicar_Registro()
            Catch ex As Exception
                MsgBox("Error al generar la orden de compra. Favor seleccionar la requisición nuevamente", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End Try
        Else
            CargarTablaxDefectoRequisiciones()
        End If
    End Sub


    Private Sub Nbi_CrearProveedor_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearProveedor.ItemClick
        Dim FrProveedor As New Proveedores.Fr_Proveedor
        FrProveedor.Cargar_Tablas()
        FrProveedor.ShowDialog()
        TablaCargada = "LISTAPROVEEDORES"
        CargarProveedoresXdefecto()
    End Sub
#End Region 'Crear

#Region "Editar"
    Private Sub Nbi_EditarRQ_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarRQ.ItemClick
        If TablaCargada = "LISTAREQUISICION" Then
            For i = 0 To Dgv_ListaItemRequisición.RowCount - 1
                If IsDBNull(Dgv_ListaItemRequisición.Rows(i).Cells("Cant Canc").Value) = False Then
                    MsgBox("No se puede editar la requisición, Ya que se tienen articulos cancelados.", vbCritical, "Requisición")
                    Exit Sub
                End If
            Next

            If Me.DGV_ListaRequisiciones.Item("IMPRESA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value = "N" Then
                EditarRequisición()
            Else
                MsgBox("La Requisición " + Trim(Me.DGV_ListaRequisiciones.Item("Requisición", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value) + " ya fue impresa y no se puede editar", vbCritical, "Requisición")
                Exit Sub
            End If
        Else
            MsgBox("No esta cargada la tabla de Requisiciones")
        End If
    End Sub


    Public Sub EditarRequisición()
        If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
            If TablaCargada = "LISTAREQUISICION" Then
                Dim EditarRQ As Boolean = False
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarRQ.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("343") = True Then
                        'Puede editar cualquiera
                        EditarRQ = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("342") = True Then
                            'si tiene permisos para editar las rq de las bases
                            'Preguntar si la RQ pertenece a la base del usuario
                            Dim IDBodegaRQ As Integer = Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                            If IDBodegaRQ = VariablesBase.VariablesBase.IdBodegaActual Then
                                EditarRQ = True
                            Else
                                EditarRQ = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("344") = True Then
                                Dim IDRegistro As Integer = Me.DGV_ListaRequisiciones.Item("IDUSUARIOREGISTRA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    EditarRQ = True
                                Else
                                    EditarRQ = False
                                End If
                            Else
                                EditarRQ = False
                            End If
                        End If
                    End If
                End If

                If EditarRQ = True Then
                    Dim FrRequisicion As New Requisición.Fr_Requisicion
                    FrRequisicion.Text = "Editando la Requisición:   " + Me.DGV_ListaRequisiciones.Item("Requisición", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value.ToString
                    FrRequisicion.TIPO = 2
                    FrRequisicion.EDITANDO = True
                    FrRequisicion.IDREQUISICIONMODIFICANDO = Me.DGV_ListaRequisiciones.Item("Id", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                    FrRequisicion.Tb_Origen.Text = Me.DGV_ListaRequisiciones.Item("Origen", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                    FrRequisicion.Tb_Base.Text = Me.DGV_ListaRequisiciones.Item("Bodega", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value

                    FrRequisicion.CargarTablas()
                    FrRequisicion.ShowDialog()
                    Cargar_Tabla()
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
                Ubicar_Registro()
            End If
        End If
    End Sub


    Public Sub VerRequisición()
        If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            If TablaCargada = "LISTAREQUISICION" Then
                Dim VerRQ As Boolean = False
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerRQ.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("359") = True Then
                        'Puede ver cualquiera
                        VerRQ = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("358") = True Then
                            'si tiene permisos para ver las rq de las bases
                            'Preguntar si la RQ pertenece a la base del usuario
                            Dim IDBodegaRQ As Integer = Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                            If IDBodegaRQ = VariablesBase.VariablesBase.IdBodegaActual Then
                                VerRQ = True
                            Else
                                VerRQ = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("357") = True Then
                                Dim IDRegistro As Integer = Me.DGV_ListaRequisiciones.Item("IDUSUARIOREGISTRA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    VerRQ = True
                                Else
                                    VerRQ = False
                                End If
                            Else
                                VerRQ = False
                            End If
                        End If
                    End If
                End If

                If VerRQ = True Then
                    Dim FrRequisicion As New Requisición.Fr_Requisicion
                    FrRequisicion.Text = "Ver la Requisición:   " + Me.DGV_ListaRequisiciones.Item("Requisición", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value.ToString
                    FrRequisicion.TIPO = 2
                    FrRequisicion.EDITANDO = True
                    FrRequisicion.IDREQUISICIONMODIFICANDO = Me.DGV_ListaRequisiciones.Item("Id", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                    FrRequisicion.Tb_Origen.Text = Me.DGV_ListaRequisiciones.Item("Origen", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                    FrRequisicion.Tb_Base.Text = Me.DGV_ListaRequisiciones.Item("Bodega", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                    FrRequisicion.CargarTablas()
                    FrRequisicion.Cu_CentroCosto1.Enabled = False
                    FrRequisicion.Bt_Guardar.Enabled = False
                    FrRequisicion.ShowDialog()
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
        End If
    End Sub


    Private Sub Nbi_EditarOC_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarOC.ItemClick
        If TablaCargada = "LISTAORDENCOMPRA" Then
            If Me.DGV_ListaRequisiciones.Item("IMPRESA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value = "N" Then
                EditarOrdenCompra()
            Else
                MsgBox("La orden de compra" + Trim(Me.DGV_ListaRequisiciones.Item("Orden de Compra", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value) + " ya fue impresa y no se puede editar", vbCritical, "Orden de compra")
                Exit Sub
            End If
        Else
            MsgBox("No esta cargada la tabla de Ordenes de Compra")
        End If
    End Sub


    Private Sub EditarOrdenCompra()
        If Tipo_Tabla_Cargada_OC = 8 Then
            Exit Sub
        End If
        If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            If TablaCargada = "LISTAORDENCOMPRA" Then
                Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
                Dim EditarOC As Boolean = False
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarOC.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("346") = True Then
                        'Puede editar cualquiera
                        EditarOC = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("345") = True Then
                            'si tiene permisos para editar las rq de las bases
                            'Preguntar si la RQ pertenece a la base del usuario
                            Dim IDBodegaOC As Integer = Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                            If IDBodegaOC = VariablesBase.VariablesBase.IdBodegaActual Then
                                EditarOC = True
                            Else
                                EditarOC = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("347") = True Then
                                Dim IDRegistro As Integer = Me.DGV_ListaRequisiciones.Item("IDUSUARIOREGISTRA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    EditarOC = True
                                Else
                                    EditarOC = False
                                End If
                            Else
                                EditarOC = False
                            End If
                        End If
                    End If
                End If

                If EditarOC = True Then
                    Dim FrOrdenCompra As New OrdenCompra.Fr_OrdenCompra
                    FrOrdenCompra.Editando = True
                    FrOrdenCompra.IDORDENCOMPRAMODIFICANDO = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value
                    FrOrdenCompra.IDREQUISICION = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("IDREQUISICION").Value
                    FrOrdenCompra.IDENTIFICACIONPROVEEDOR = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("NIT").Value
                    FrOrdenCompra.Text = "Editando la Orden de Compra:   " + Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Orden de Compra").Value
                    FrOrdenCompra.CargarDatos()
                    FrOrdenCompra.ShowDialog()
                    CargarOCxDefecto()
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
            Ubicar_Registro()
        End If
    End Sub


    Private Sub VerOrdenCompra()
        If Tipo_Tabla_Cargada_OC = 8 Then
            Exit Sub
        End If
        If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            If TablaCargada = "LISTAORDENCOMPRA" Then
                Dim VerOC As Boolean = False
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerOC.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("363") = True Then
                        'Puede ver cualquiera
                        VerOC = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("362") = True Then
                            'si tiene permisos para ver las ordenes de compra de las bases
                            'Preguntar si la orden de compra pertenece a la base del usuario
                            Dim IDBodegaOC As Integer = Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                            If IDBodegaOC = VariablesBase.VariablesBase.IdBodegaActual Then
                                VerOC = True
                            Else
                                VerOC = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("361") = True Then
                                Dim IDRegistro As Integer = Me.DGV_ListaRequisiciones.Item("IDUSUARIOREGISTRA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    VerOC = True
                                Else
                                    VerOC = False
                                End If
                            Else
                                VerOC = False
                            End If
                        End If
                    End If
                End If

                If VerOC = True Then
                    Dim FrOrdenCompra As New OrdenCompra.Fr_OrdenCompra
                    FrOrdenCompra.Editando = True
                    FrOrdenCompra.IDORDENCOMPRAMODIFICANDO = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value
                    FrOrdenCompra.IDREQUISICION = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("IDREQUISICION").Value
                    FrOrdenCompra.IDENTIFICACIONPROVEEDOR = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("NIT").Value
                    FrOrdenCompra.Text = "Editando la Orden de Compra:   " + Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Orden de Compra").Value
                    FrOrdenCompra.CargarDatos()
                    FrOrdenCompra.Cu_CentroCosto1.Enabled = False
                    FrOrdenCompra.Bt_Guardar.Enabled = False
                    FrOrdenCompra.ShowDialog()
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
        End If
    End Sub


    Private Sub Nbi_EditarProveedor_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarProveedor.ItemClick
        EditarProveedor()
    End Sub


    Private Sub EditarProveedor()
        If TablaCargada = "LISTAPROVEEDORES" Then
            If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
                Dim FrProveedor As New Proveedores.Fr_Proveedor
                FrProveedor.Editando = True
                FrProveedor.IDPROVEEDOREDITANDO = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value
                FrProveedor.Cargar_Tablas()
                FrProveedor.ShowDialog()
                CargarProveedoresXdefecto()
                Ubicar_Registro()
            End If
        Else
            MsgBox("No esta cargada la tabla de Proveedores")
        End If
    End Sub


    Private Sub DGV_ListaRequisiciones_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV_ListaRequisiciones.CellMouseDoubleClick
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            Select Case TablaCargada
                Case "LISTAREQUISICION"
                    If Me.DGV_ListaRequisiciones.Item("IMPRESA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value = "N" Then
                        EditarRequisición()
                    Else
                        MsgBox("La Requisicion ya fue impresa", vbCritical, "Requisición")
                        Exit Sub
                    End If

                Case "LISTAORDENCOMPRA"
                    If Me.DGV_ListaRequisiciones.Item("IMPRESA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value = "N" Then
                        EditarOrdenCompra()
                    Else
                        MsgBox("La Orden de compra ya fue impresa", vbCritical, "Orden de compra")
                        Exit Sub
                    End If

                Case "LISTAPROVEEDORES"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarProveedor.Tag) = True Then
                        EditarProveedor()

                    End If
                Case "LISTARELACIONESFACTURAS"
                    EditarRelación()
            End Select
        End If
    End Sub
#End Region 'Editar

#Region "Cancelar"

#Region "Requisición"
    Private Sub Nbi_CancelarRQ_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CancelarRQ.ItemClick
        If TablaCargada = "LISTAREQUISICION" Then
            If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
                Dim CancelarRQ As Boolean = True
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarOC.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("352") = True Then
                        'Puede editar cualquiera
                        CancelarRQ = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("351") = True Then
                            'si tiene permisos para editar las requisiciones de las bases
                            'Preguntar si la RQ pertenece a la base del usuario
                            Dim IDBodegaRQ As Integer = Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                            If IDBodegaRQ = VariablesBase.VariablesBase.IdBodegaActual Then
                                CancelarRQ = True
                            Else
                                CancelarRQ = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("350") = True Then
                                Dim IDRegistro As Integer = Me.DGV_ListaRequisiciones.Item("IDUSUARIOREGISTRA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    CancelarRQ = True
                                Else
                                    CancelarRQ = False
                                End If
                            Else
                                CancelarRQ = False
                            End If
                        End If
                    End If
                End If

                If CancelarRQ = True Then
                    If MsgBox("La cancelación es un proceso irreversible, ¡seguro que desea cancelar la requisición " + Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Requisición").Value + "?", MsgBoxStyle.YesNo, "CANCELAR REQUISICION") = MsgBoxResult.Yes Then
                        If FuncionesBase.FuncionesBase.CancelarRegistro("RQ", Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Id").Value, -1) = 0 Then
                            TablaCargada = "LISTAREQUISICION"
                            'Imprimir *****************************************
                            Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                            Dim Array1 As New ArrayList
                            Array1.Add(61)
                            climpresiones.IDREQUISICION = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Id").Value
                            climpresiones.FormatoImprimirMateriales(Array1, True, False)
                            '**************************************************
                            CorreoCancelacionRequisicion(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Id").Value)
                            CargarTablaxDefectoRequisiciones()
                        End If
                    End If
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
                Ubicar_Registro()
            End If
        Else
            MsgBox("No está cargada la tabla de Requisiciones")
        End If
    End Sub

    Private Sub CorreoCancelacionRequisicion(ByVal IdRequisicion As Integer)
        Dim Cadena_Consulta As String
        Dim Cadena_Consulta2 As String
        Dim Dt_Requisicion As DataTable
        Dim Dt_Correos As DataTable
        Dim FilaRequisicion As DataRow
        Dim textoContenido As String = ""

        Dim asunto As String
        Dim ContadorItems As Integer = 0

        Cadena_Consulta = "select CRQ.IDREQUISICION, CRQ.REQUISICION, CRQ.OBSERVACION, dbo.Personanombrecompleto(CRQ.IDPERSONACANCELA) AS CANCELO, CRQ.FECHACANCELACION  from CAN_REQUISICION CRQ  , PROVEEDOR PROV where CRQ.IDREQUISICION = " + Convert.ToString(IdRequisicion)
        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Dt_Requisicion = New DataTable
        Adaptador.FillSchema(Dt_Requisicion, SchemaType.Source)
        Adaptador.Fill(Dt_Requisicion)
        Consulta.Connection.Close()

        Cadena_Consulta2 = "SELECT  USUARIO.CORREOELECTRONICOCORPORTATIVO FROM USUARIO "
        Cadena_Consulta2 += " WHERE USUARIO.IDPERSONA = (SELECT RQ.IDPERSONASOLICITA FROM CAN_REQUISICION AS RQ WHERE RQ.IDREQUISICION = " + IdRequisicion.ToString + ")"
        Cadena_Consulta2 += " OR  USUARIO.IDPERSONA = (SELECT RQ.IDPERSONAAUTORIZA FROM CAN_REQUISICION AS RQ WHERE RQ.IDREQUISICION = " + IdRequisicion.ToString + ")"
        Cadena_Consulta2 += " OR USUARIO.IDPERSONA = (SELECT RQ.IDPERSONAAPRUEBA FROM CAN_REQUISICION AS RQ WHERE RQ.IDREQUISICION = " + IdRequisicion.ToString + ")"
        Cadena_Consulta2 += " OR USUARIO.IDPERSONA = (SELECT RQ.IDPERSONAREVISA FROM CAN_REQUISICION AS RQ WHERE RQ.IDREQUISICION = " + IdRequisicion.ToString + ")"
        Dim Conexion2 As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim Consulta2 As New SqlClient.SqlCommand(Cadena_Consulta2, Conexion2)
        Dim AdaptadorCorreos As New SqlDataAdapter(Consulta2)
        Dt_Correos = New DataTable
        AdaptadorCorreos.FillSchema(Dt_Correos, SchemaType.Source)

        Try
            Conexion2.Open()
            AdaptadorCorreos.Fill(Dt_Correos)
            Conexion2.Close()
        Catch ex As Exception
        Finally
            Conexion2.Close()
        End Try

        FilaRequisicion = Dt_Requisicion.Rows(0)
        asunto = "Se realizo cancelación de la requisición : " + CStr(Trim(FilaRequisicion("REQUISICION"))) + ".  "
        textoContenido = ""
        textoContenido += "<div style =""padding:10px; max-width :1000px; "">"
        textoContenido += "<table style =""width:100%;"" border= ""1""  >"
        textoContenido += "    <tr style=""border:1px solid;"" text-align:center;>"
        textoContenido += "        <td style=""width:170px; text-align:center; padding:10px;""><img src=""http://190.0.43.174:7070/imagenes/logo.png"" width=""100px"" /></td>"
        textoContenido += "        <td> <CENTER> <B>SISTEMA DE MATERIALES</B> </CENTER></td>"
        textoContenido += "        <td> <CENTER> <B>REQUISICION: </B> " + CStr(Trim(FilaRequisicion("REQUISICION"))) + " </CENTER> </td>"
        textoContenido += "    </tr>"

        textoContenido += "</table>"
        textoContenido += "<P>"
        textoContenido += "<table border= ""1"" style =""width:100%;"" >"

        textoContenido += "<tr>"
        textoContenido += "<td> <B>REQUISICION:  </B>" + Trim(FilaRequisicion("REQUISICION")) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<tr>"
        textoContenido += "<td> <B>CANCELADA POR:  </B>" + Trim(FilaRequisicion("CANCELO")) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<tr>"
        textoContenido += "<td> <B>RAZON CANCELACION:  </B>" + Trim(FilaRequisicion("OBSERVACION")) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<tr>"
        textoContenido += "<td> <B>FECHA CANCELACION:  </B>" + Trim(FilaRequisicion("FECHACANCELACION")) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<P>"
        textoContenido += "<tr>"
        textoContenido += "<td colspan=""3""><CENTER>Por favor no contestar el E-Mail a esta cuenta de Correo.</CENTER></td>"
        textoContenido += "</tr>"
        textoContenido += "<tr>"
        textoContenido += "<td colspan=""3""><CENTER>Para cualquier consulta comuníquese a soporteaplicaciones@ismocol.com</CENTER></td>"
        textoContenido += "</tr>"

        textoContenido += "</div>"
        textoContenido += "</center>"

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

        Dim strSMTP As String = "smtp.gmail.com"
        'revisar conteo para cambiar de correo cuando se llegue a 450 enviados
        Dim correoOrigen As String
        Dim correoOrigenClave As String

        correoOrigen = "informacion-noreplicar@ismocol.com"
        correoOrigenClave = "Sap753150"

        Dim SmtpServer As New SmtpClient("smtp.gmail.com", 587)
        SmtpServer.UseDefaultCredentials = False
        SmtpServer.Credentials = New Net.NetworkCredential(correoOrigen, correoOrigenClave)
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        Dim ContadorCorreosNull As Integer = 0
        If VariablesBase.VariablesBase.NombreBaseDatos = "ISMOCOLPRODUCCION" Then
            If Dt_Correos.Rows.Count > 0 Then
                For i As Integer = 0 To Dt_Correos.Rows.Count - 1
                    If Trim(Dt_Correos.Rows(i).Item("CORREOELECTRONICOCORPORTATIVO").ToString) <> "" And Not IsDBNull(Dt_Correos.Rows(i).Item("CORREOELECTRONICOCORPORTATIVO")) Then
                        mail.To.Add(Dt_Correos.Rows(i).Item("CORREOELECTRONICOCORPORTATIVO").ToString)
                    Else
                        ContadorCorreosNull += 1
                    End If
                Next
            Else
                ContadorCorreosNull += 1
            End If
        Else
            mail.To.Add("soporteaplicaciones@ismocol.com")
        End If

        If (ContadorCorreosNull >= Dt_Correos.Rows.Count) Then
            MsgBox("No se envió notificación al correo, no habian correos asociados", MsgBoxStyle.Information, "Cancelar Requisición")
            Exit Sub
        End If
        mail.From = New MailAddress(correoOrigen)
        mail.Subject = asunto
        mail.Body = cuerpo

        mail.IsBodyHtml = True
        mail.Priority = MailPriority.Normal
        'QUITAR PARA QUE FUNCIONE
        SmtpServer.Send(mail)
        MsgBox("Se envió notificación a los correos", MsgBoxStyle.Information, "Cancelar Requisición")
    End Sub

    Private Sub CancelarItemToolStripMenuItemRQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarItemToolStripMenuItemRQ.Click
        If Me.Dgv_ListaItemRequisición.SelectedRows.Count = 1 Then
            CancelarItemRequisición("T", Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Cant").Value)
        Else
            MsgBox("Debe seleccionar el item a cancelar")
        End If
    End Sub


    Private Sub CancelarCantidadItemToolStripMenuItemRQ_Click(sender As System.Object, e As System.EventArgs) Handles CancelarCantidadItemToolStripMenuItemRQ.Click
        If Me.Dgv_ListaItemRequisición.SelectedRows.Count = 1 Then
            Dim cantidadrq As Double = Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Cant").Value
            Dim cantidadrqpendiente As Double = Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Pend").Value
            Dim cantidadcancelar As String
            cantidadcancelar = InputBox("Digite la cantidad a cancelar", "Cantidad a cancelar", cantidadrqpendiente)
            If IsNumeric(Trim(cantidadcancelar)) = True Then
                If cantidadcancelar > cantidadrq Then
                    MsgBox("Cantidad no válida, no puede superar la cantidad de la RQ", MsgBoxStyle.Critical, "Cantidad no válida")
                Else
                    If cantidadcancelar <= 0 Then
                        MsgBox("Cantidad no válida, no puede ser cero o negativo", MsgBoxStyle.Critical, "Cantidad no válida")
                    Else
                        If cantidadrqpendiente < cantidadcancelar Then
                            MsgBox("Cantidad no válida, no puede superar la cantidad pendiente de la RQ", MsgBoxStyle.Critical, "Cantidad no válida")
                        Else
                            If cantidadcancelar = cantidadrq Then
                                CancelarItemRequisición("T", cantidadrq)
                            Else
                                CancelarItemRequisición("C", cantidadcancelar)
                            End If
                        End If
                    End If
                End If
            Else
                MsgBox("Cantidad no válida, debe ser numérico", MsgBoxStyle.Critical, "Cantidad no válida")
            End If
            If MsgBox("¿Desea recargar la lista de RQ?", MsgBoxStyle.YesNo, "RECARGAR LISTA") = MsgBoxResult.Yes Then
                CargarTablaxDefectoRequisiciones()
            End If
        Else
            MsgBox("Debe seleccionar el item a cancelar")
        End If
    End Sub
    Private Sub CorreoCancelacionItemsRequisicion(ByVal IdRequisicion As Integer, ByVal IdItemRequisicion As Integer, ByVal IdArticulo As Integer, ByVal CantidadCancelada As String)
        Dim Cadena_Consulta As String
        Dim Cadena_Consulta2 As String
        Dim Dt_Requisicion As DataTable
        Dim Dt_Correos As DataTable
        Dim FilaRequisicion As DataRow
        Dim textoContenido As String = ""

        Dim asunto As String
        Dim ContadorItems As Integer = 0

        Cadena_Consulta = "SELECT TOP 1  RQ.IDREQUISICION, RQ.REQUISICION, dbo.Personanombrecompleto(CIRQ.IDPERSONACANCELA) AS CANCELO, CIRQ.FECHACANCELACION, CIRQ.IDARTICULO, ART.NOMBREDESCRIPTIVO, CIRQ.CANTIDADCANCELADA, CIRQ.CANTIDADSOLICITADA, CIRQ.OBSERVACION from REQUISICION RQ  INNER JOIN  CAN_ITEMREQUISICION CIRQ ON CIRQ.IDREQUISICION = RQ.IDREQUISICION INNER JOIN ARTICULO ART ON CIRQ.IDARTICULO = ART.IDARTICULO  where RQ.IDREQUISICION = " + Convert.ToString(IdRequisicion) + " AND CIRQ.IDITEMREQUISICION = " + Convert.ToString(IdItemRequisicion) + " and ART.IDARTICULO = " + Convert.ToString(IdArticulo) + "ORDER BY CIRQ.FECHACANCELACION DESC"
        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Dt_Requisicion = New DataTable
        Adaptador.FillSchema(Dt_Requisicion, SchemaType.Source)
        Adaptador.Fill(Dt_Requisicion)
        Consulta.Connection.Close()

        Cadena_Consulta2 = "SELECT  USUARIO.CORREOELECTRONICOCORPORTATIVO FROM USUARIO "
        Cadena_Consulta2 += " WHERE USUARIO.IDPERSONA = (SELECT RQ.IDPERSONASOLICITA FROM REQUISICION AS RQ WHERE RQ.IDREQUISICION = " + IdRequisicion.ToString + ")"
        Cadena_Consulta2 += " OR  USUARIO.IDPERSONA = (SELECT RQ.IDPERSONAAUTORIZA FROM REQUISICION AS RQ WHERE RQ.IDREQUISICION = " + IdRequisicion.ToString + ")"
        Cadena_Consulta2 += " OR USUARIO.IDPERSONA = (SELECT RQ.IDPERSONAAPRUEBA FROM REQUISICION AS RQ WHERE RQ.IDREQUISICION = " + IdRequisicion.ToString + ")"
        Cadena_Consulta2 += " OR USUARIO.IDPERSONA = (SELECT RQ.IDPERSONAREVISA FROM REQUISICION AS RQ WHERE RQ.IDREQUISICION = " + IdRequisicion.ToString + ")"
        Dim Conexion2 As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim Consulta2 As New SqlClient.SqlCommand(Cadena_Consulta2, Conexion2)
        Dim AdaptadorCorreos As New SqlDataAdapter(Consulta2)
        Dt_Correos = New DataTable
        AdaptadorCorreos.FillSchema(Dt_Correos, SchemaType.Source)

        Try
            Conexion2.Open()
            AdaptadorCorreos.Fill(Dt_Correos)
            Conexion2.Close()
        Catch ex As Exception
        Finally
            Conexion2.Close()
        End Try

        FilaRequisicion = Dt_Requisicion.Rows(0)
        asunto = "Se realizó una cancelación parcial de la requisición : " + CStr(Trim(FilaRequisicion("REQUISICION"))) + ".  "
        textoContenido = ""
        textoContenido += "<div style =""padding:10px; max-width :1000px; "">"
        textoContenido += "<table style =""width:100%;"" border= ""1""  >"
        textoContenido += "    <tr style=""border:1px solid;"" text-align:center;>"
        textoContenido += "        <td style=""width:170px; text-align:center; padding:10px;""><img src=""http://190.0.43.174:7070/imagenes/logo.png"" width=""100px"" /></td>"
        textoContenido += "        <td> <CENTER> <B>SISTEMA DE MATERIALES</B> </CENTER></td>"
        textoContenido += "        <td> <CENTER> <B>REQUISICION: </B> " + CStr(Trim(FilaRequisicion("REQUISICION"))) + " </CENTER> </td>"
        textoContenido += "    </tr>"

        textoContenido += "</table>"
        textoContenido += "<P>"
        textoContenido += "<table border= ""1"" style =""width:100%;"" >"

        textoContenido += "<tr>"
        textoContenido += "<td colspan=""5""><B>SE REALIZÓ UNA CANCELACIÓN PARCIAL DE LA REQUISICIÓN: </B>" + Trim(FilaRequisicion("REQUISICION")) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<tr>"
        textoContenido += "<td colspan=""5""> <B>CANCELADA POR:  </B>" + Trim(FilaRequisicion("CANCELO")) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<tr>"
        textoContenido += "<td colspan=""5""> <B>FECHA CANCELACION:  </B>" + Trim(FilaRequisicion("FECHACANCELACION")) + "</td>"
        textoContenido += "</tr>"



        textoContenido += "<tr>"
        textoContenido += "<td> <B>ID ARTÍCULO:  </B>" + Trim(FilaRequisicion("IDARTICULO")) + "</td>"
        textoContenido += "<td> <B>NOMBRE ARTÍCULO:  </B>" + Trim(FilaRequisicion("NOMBREDESCRIPTIVO")) + "</td>"
        textoContenido += "<td> <B>CANTIDAD CANCELADA:  </B>" + CantidadCancelada + "</td>"
        textoContenido += "<td> <B>CANTIDAD SOLICITADA:  </B>" + Trim(FilaRequisicion("CANTIDADSOLICITADA")) + "</td>"
        textoContenido += "<td> <B>RAZON CANCELACIÓN:  </B>" + Trim(FilaRequisicion("OBSERVACION")) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<P>"
        textoContenido += "<tr>"
        textoContenido += "<td colspan=""5""><CENTER>Por favor no contestar el E-Mail a esta cuenta de Correo.</CENTER></td>"
        textoContenido += "</tr>"
        textoContenido += "<tr>"
        textoContenido += "<td colspan=""5""><CENTER>Para cualquier consulta comuníquese a soporteaplicaciones@ismocol.com</CENTER></td>"
        textoContenido += "</tr>"
        textoContenido += "</p>"
        textoContenido += "</table>"
        textoContenido += "</p>"

        textoContenido += "</div>"
        textoContenido += "</center>"

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

        Dim strSMTP As String = "smtp.gmail.com"
        'revisar conteo para cambiar de correo cuando se llegue a 450 enviados
        Dim correoOrigen As String
        Dim correoOrigenClave As String

        correoOrigen = "informacion-noreplicar@ismocol.com"
        correoOrigenClave = "Sap753150"

        Dim SmtpServer As New SmtpClient("smtp.gmail.com", 587)
        SmtpServer.UseDefaultCredentials = False
        SmtpServer.Credentials = New Net.NetworkCredential(correoOrigen, correoOrigenClave)
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        Dim ContadorCorreosNull As Integer = 0
        If VariablesBase.VariablesBase.NombreBaseDatos = "ISMOCOLPRODUCCION" Then
            If Dt_Correos.Rows.Count > 0 Then
                For i As Integer = 0 To Dt_Correos.Rows.Count - 1
                    If Trim(Dt_Correos.Rows(i).Item("CORREOELECTRONICOCORPORTATIVO").ToString) <> "" And Not IsDBNull(Dt_Correos.Rows(i).Item("CORREOELECTRONICOCORPORTATIVO")) Then
                        mail.To.Add(Dt_Correos.Rows(i).Item("CORREOELECTRONICOCORPORTATIVO").ToString)
                    Else
                        ContadorCorreosNull += 1
                    End If
                Next
            Else
                ContadorCorreosNull += 1
            End If
        Else
            mail.To.Add("soporteaplicaciones@ismocol.com")
        End If

        If (ContadorCorreosNull >= Dt_Correos.Rows.Count) Then
            MsgBox("No se envió notificación al correo, no habian correos asociados", MsgBoxStyle.Information, "Cancelar Requisición")
            Exit Sub
        End If

        mail.From = New MailAddress(correoOrigen)
        mail.Subject = asunto
        mail.Body = cuerpo

        mail.IsBodyHtml = True
        mail.Priority = MailPriority.Normal
        'QUITAR PARA QUE FUNCIONE
        SmtpServer.Send(mail)
        MsgBox("Se envió notificación a los correos", MsgBoxStyle.Information, "Cancelar Requisición")
    End Sub


    Private Sub CancelarItemRequisición(ByVal TIPO As String, ByVal CANTIDAD As Double)
        If Me.Dgv_ListaItemRequisición.SelectedRows.Count = 1 Then
            Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
            If TablaCargada = "LISTAREQUISICION" Then
                Dim CancelarRQ As Boolean = True
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarRQ.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("352") = True Then
                        'Puede editar cualquiera
                        CancelarRQ = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("351") = True Then
                            'si tiene permisos para editar las requisiciones de las bases
                            'Preguntar si la RQ pertenece a la base del usuario
                            Dim IDBodegaRQ As Integer = Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                            If IDBodegaRQ = VariablesBase.VariablesBase.IdBodegaActual Then
                                CancelarRQ = True
                            Else
                                CancelarRQ = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("350") = True Then
                                Dim IDRegistro As Integer = Me.DGV_ListaRequisiciones.Item("IDUSUARIOREGISTRA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    CancelarRQ = True
                                Else
                                    CancelarRQ = False
                                End If
                            Else
                                CancelarRQ = False
                            End If
                        End If
                    End If
                End If
                If CancelarRQ = True Then
                    Dim mensaje As String
                    If TIPO = "T" Then
                        mensaje = "total"
                    Else
                        mensaje = "parcial"
                    End If
                    If MsgBox("La cancelación es un proceso irreversible, ¿seguro que desea cancelar " + mensaje + " el ítem " + Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Item").Value.ToString + " de la Requisición " + Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Requisición").Value + "?", MsgBoxStyle.YesNo, "CANCELAR ITEM REQUISICION") = MsgBoxResult.Yes Then
                        If FuncionesBase.FuncionesBase.CancelarRegistro("IRQ", Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Id").Value, Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Item").Value, TIPO, CANTIDAD) = 0 Then
                            Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                            Dim Array As New ArrayList
                            Array.Add(61)
                            climpresiones.IDREQUISICION = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Id").Value
                            climpresiones.FormatoImprimirMateriales(Array, True, False)
                            Dim IdRQ As Integer = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Id").Value
                            Dim IdItemRQ As Integer = Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Item").Value
                            Dim IdArticulo As Integer = Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Código").Value
                            CorreoCancelacionItemsRequisicion(IdRQ, IdItemRQ, IdArticulo, CANTIDAD)
                            CargarItems()
                        End If
                    End If
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
                Ubicar_Registro()
            Else
                MsgBox("Debe tener cargada la requisición desde la carga de RQ activas")
            End If
        End If
    End Sub
#End Region 'Requisición

#Region "Orden de Compra"
    Private Sub Nbi_CancelarOC_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CancelarOC.ItemClick
        If Tipo_Tabla_Cargada_OC = 8 Then
            Exit Sub
        End If

        If TablaCargada = "LISTAORDENCOMPRA" Then
            If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
                Dim CancelarOC As Boolean = True
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarOC.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("355") = True Then
                        'Puede editar cualquiera
                        CancelarOC = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("354") = True Then
                            'si tiene permisos para editar las rq de las bases
                            'Preguntar si la RQ pertenece a la base del usuario
                            Dim IDBodegaOC As Integer = Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                            If IDBodegaOC = VariablesBase.VariablesBase.IdBodegaActual Then
                                CancelarOC = True
                            Else
                                CancelarOC = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("353") = True Then
                                Dim IDRegistro As Integer = Me.DGV_ListaRequisiciones.Item("IDUSUARIOREGISTRA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    CancelarOC = True
                                Else
                                    CancelarOC = False
                                End If
                            Else
                                CancelarOC = False
                            End If
                        End If
                    End If
                End If
                If CancelarOC = True Then
                    If MsgBox("La cancelación es un proceso irreversible, seguro que desea cancelar la orden de compra " + Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Orden de Compra").Value, MsgBoxStyle.YesNo, "CANCELAR ORDEN DE COMPRA") = MsgBoxResult.Yes Then
                        Dim ID As Integer = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value
                        If FuncionesBase.FuncionesBase.CancelarRegistro("OC", ID, -1) = 0 Then

                            Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                            Dim Array As New ArrayList
                            Array.Add(63)
                            climpresiones.IDORDENDECOMPRA = ID
                            climpresiones.FormatoImprimirMateriales(Array, True, False)

                            CorreoCancelacionOrdenCompra(ID)

                            CargarOCxDefecto()
                        End If
                    End If
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
            Ubicar_Registro()
        Else
            MsgBox("No esta cargada la tabla de Ordenes de Compra")
        End If
    End Sub

    Private Sub CorreoCancelacionOrdenCompra(ByVal IdOrdencompra As Integer)
        Dim Cadena_Consulta As String
        Dim Dt_OrdenCompra As DataTable
        Dim FilaOrdenCompra As DataRow
        Dim textoContenido As String = ""

        Dim asunto As String
        Dim ContadorItems As Integer = 0
        'Dim FilaOC As DataRow

        Cadena_Consulta = "select COC.IDORDENCOMPRA, COC.ORDENCOMPRA, COC.OBSERVACIONCANCELACION, dbo.Personanombrecompleto(coc.IDPERSONACANCELA) AS CANCELO , PROV.NOMBRE AS NOMPROVEEDOR from CAN_ORDENCOMPRA COC  , PROVEEDOR PROV where PROV.IDPROVEEDOR = COC.IDPROVEEDOR AND COC.IDORDENCOMPRA = " + Convert.ToString(IdOrdencompra)

        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Dt_OrdenCompra = New DataTable
        Adaptador.FillSchema(Dt_OrdenCompra, SchemaType.Source)
        Adaptador.Fill(Dt_OrdenCompra)
        Consulta.Connection.Close()
        FilaOrdenCompra = Dt_OrdenCompra.Rows(0)

        asunto = "Se realizo cancelación orden de compra : " + CStr(Trim(FilaOrdenCompra("ORDENCOMPRA"))) + ".  " + CStr(FilaOrdenCompra("OBSERVACIONCANCELACION"))

        textoContenido = ""
        textoContenido += "<div style =""padding:10px; max-width :1000px; "">"
        textoContenido += "<table style =""width:100%;"" border= ""1""  >"
        textoContenido += "    <tr style=""border:1px solid;"" text-align:center;>"
        textoContenido += "        <td style=""width:170px; text-align:center; padding:10px;""><img src=""http://190.0.43.174:7070/imagenes/logo.png"" width=""100px"" /></td>"
        textoContenido += "        <td> <CENTER> <B>SISTEMA DE MATERIALES</B> </CENTER></td>"
        textoContenido += "        <td> <CENTER> <B>ORDEN DE COMPRA </B> " + CStr(Trim(FilaOrdenCompra("ORDENCOMPRA"))) + " </CENTER> </td>"
        textoContenido += "    </tr>"

        textoContenido += "</table>"
        textoContenido += "<P>"
        textoContenido += "<table border= ""1"" style =""width:100%;"" >"

        textoContenido += "<tr>"
        textoContenido += "<td> <B>ORDEN DE COMPRA  </B>" + Trim(FilaOrdenCompra("ORDENCOMPRA")) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<tr>"
        textoContenido += "<td> <B>CANCELADA POR:  </B>" + Trim(FilaOrdenCompra("CANCELO")) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<tr>"
        textoContenido += "<td> <B>RAZON CANCELACION:  </B>" + Trim(FilaOrdenCompra("OBSERVACIONCANCELACION")) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<tr>"
        textoContenido += "<td> <B>NOMBRE PROVEEDOR:  </B>" + Trim(FilaOrdenCompra("NOMPROVEEDOR")) + "</td>"
        textoContenido += "</tr>"

        textoContenido += "<P>"
        textoContenido += "<tr>"
        textoContenido += "<td colspan=""3""><CENTER>Por favor no contestar el E-Mail a esta cuenta de Correo.</CENTER></td>"
        textoContenido += "</tr>"
        textoContenido += "<tr>"
        textoContenido += "<td colspan=""3""><CENTER>Para cualquier consulta comuníquese a desarrolloaplicaciones@ismocol.com</CENTER></td>"
        textoContenido += "</tr>"

        textoContenido += "</div>"
        textoContenido += "</center>"

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

        Dim strSMTP As String = "smtp.gmail.com"
        'revisar conteo para cambiar de correo cuando se llegue a 450 enviados
        Dim correoOrigen As String
        Dim correoOrigenClave As String

        correoOrigen = "informacion-noreplicar@ismocol.com"
        correoOrigenClave = "Sap753150"

        Dim SmtpServer As New SmtpClient("smtp.gmail.com", 587)
        SmtpServer.UseDefaultCredentials = False
        SmtpServer.Credentials = New Net.NetworkCredential(correoOrigen, correoOrigenClave)
        SmtpServer.EnableSsl = True
        Dim mail As New MailMessage()
        If VariablesBase.VariablesBase.NombreBaseDatos = "ISMOCOLPRODUCCION" Then
            mail.To.Add("compras@ismocol.com")
        Else
            mail.To.Add("desarrolloaplicaciones@ismocol.com")
        End If
        mail.From = New MailAddress(correoOrigen)
        mail.Subject = asunto
        mail.Body = cuerpo

        mail.IsBodyHtml = True
        mail.Priority = MailPriority.Normal
        'QUITAR PARA QUE FUNCIONE
        SmtpServer.Send(mail)
        'MsgBox("Se envió notificación al correo " + Trim(correoDestino), MsgBoxStyle.Information, "Entrada de Almacén")
    End Sub


    Private Sub CancelarItemOrdenCompra(ByVal TIPO As String, ByVal CANTIDAD As Double)
        If Me.Dgv_ListaItemRequisición.SelectedRows.Count > 0 Then
            If TablaCargada = "LISTAORDENCOMPRA" Then
                Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
                Dim CancelarOC As Boolean = True
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarOC.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("355") = True Then
                        'Puede editar cualquiera
                        CancelarOC = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("354") = True Then
                            'si tiene permisos para editar las requisiciones de las bases
                            'Preguntar si la RQ pertenece a la base del usuario
                            Dim IDBodegaOC As Integer = Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                            If IDBodegaOC = VariablesBase.VariablesBase.IdBodegaActual Then
                                CancelarOC = True
                            Else
                                CancelarOC = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("353") = True Then
                                Dim IDRegistro As Integer = Me.DGV_ListaRequisiciones.Item("IDUSUARIOREGISTRA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    CancelarOC = True
                                Else
                                    CancelarOC = False
                                End If
                            Else
                                CancelarOC = False
                            End If
                        End If
                    End If
                End If
                If CancelarOC = True Then
                    Dim mensaje As String
                    If TIPO = "T" Then
                        mensaje = "total"
                    Else
                        mensaje = "parcial"
                    End If
                    If MsgBox("La cancelación es un proceso irreversible, seguro que desea cancelar " + mensaje + " el ítem " + Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Item").Value.ToString + " de la Orden de Compra " + Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Orden de Compra").Value, MsgBoxStyle.YesNo, "CANCELAR ITEM ORDEN DE COMPRA") = MsgBoxResult.Yes Then
                        Dim ID As Integer = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Id").Value
                        If FuncionesBase.FuncionesBase.CancelarRegistro("IOC", ID, Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Item").Value, TIPO, CANTIDAD) = 0 Then
                            Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                            Dim Array As New ArrayList
                            Array.Add(63)
                            climpresiones.IDORDENDECOMPRA = ID
                            climpresiones.FormatoImprimirMateriales(Array, True, False)
                            CargarItems()
                        End If
                    End If
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
            CargarOCxDefecto()
            Ubicar_Registro()

        End If
    End Sub


    Private Sub CancelarItemToolStripMenuItemOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarItemToolStripMenuItemOC.Click
        If Tipo_Tabla_Cargada_OC = 8 Then
            Exit Sub
        End If
        CancelarItemOrdenCompra("T", Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Cant OC").Value)
    End Sub


    Private Sub CancelarCantidadItemToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CancelarCantidadItemToolStripMenuItemOC.Click
        If Tipo_Tabla_Cargada_OC = 8 Then
            Exit Sub
        End If
        If Me.Dgv_ListaItemRequisición.SelectedRows.Count > 0 Then
            Dim cantidadoc As Double = Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Cant OC").Value
            Dim cantidadcancelar As String
            cantidadcancelar = InputBox("Digite la cantidad a cancelar", "Cantidad a cancelar", cantidadoc)
            If IsNumeric(Trim(cantidadcancelar)) = True Then
                If cantidadcancelar > cantidadoc Then
                    MsgBox("Cantidad no valida, no puede superar la cantidad de la OC", MsgBoxStyle.Critical, "Cantidad no valida")
                Else
                    If cantidadcancelar < 0 Then
                        MsgBox("Cantidad no valida, no puede ser negativo", MsgBoxStyle.Critical, "Cantidad no valida")
                    Else
                        If cantidadcancelar = cantidadoc Then
                            CancelarItemOrdenCompra("T", Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Cant OC").Value)
                        Else
                            CancelarItemOrdenCompra("C", cantidadcancelar)
                        End If
                    End If
                End If
            Else
                MsgBox("Cantidad no valida, debe ser numérico", MsgBoxStyle.Critical, "Cantidad no valida")
            End If
            If MsgBox("¿Desea recargar la lista de RQ?", MsgBoxStyle.YesNo, "RECARGAR LISTA") = MsgBoxResult.Yes Then
                CargarOCxDefecto()
            End If
        End If
    End Sub

#End Region 'Orden de Compra

#End Region 'Cancelar

#Region "Imprimir"
    Private Sub Nbi_ImprimirOC_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IMPRIMIR()
    End Sub


    Private Sub Nbi_ImprimirRQ_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IMPRIMIR()
    End Sub


    Private Sub Nbi_ImprimirOrdenCompra_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ImprimirOrdenCompra.ItemClick
        If TablaCargada = "LISTAORDENCOMPRA" Then
            IMPRIMIR()
        Else
            MsgBox("No esta cargada la tabla de Ordenes de Compra")
        End If
    End Sub


    Private Sub Nbi_HabilitarImpresionOC_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_HabilitarImpresionOC.ItemClick
        If TablaCargada = "LISTAORDENCOMPRA" Or TablaCargada = "LISTAREQUISICIONCANCELADAS" Then
            HabilitarImpresion()
        Else
            MsgBox("No esta cargada la tabla de Ordenes de Compra")
        End If
    End Sub


    Private Sub Nbi_ImprimirRequisición_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ImprimirRequisición.ItemClick
        If TablaCargada = "LISTAREQUISICION" Or TablaCargada = "LISTAREQUISICIONCANCELADAS" Then
            IMPRIMIR()
        Else
            MsgBox("No esta cargada la tabla de Requisiciones")
        End If
    End Sub


    Private Sub Nbi_ImprimirComplementoRQ_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirComplementoRQ.ItemClick
        If TablaCargada = "LISTAREQUISICION" Then
            If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
                Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                climpresiones.IDREQUISICION = DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value
                Dim ListadoDocumentos As New ArrayList
                ListadoDocumentos.Add(75)
                climpresiones.FormatoImprimirMateriales(ListadoDocumentos, True, False)
                If climpresiones.ImpresionFinalizada Then
                    MessageBox.Show("Impresión finalizada.", "Impresión Materiales", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Ubicar_Registro()
            End If
        Else
            MessageBox.Show("No esta cargada la tabla de Requisiciones", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    Private Sub Nbi_HablitarImpresionRQ_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_HablitarImpresionRQ.ItemClick
        If TablaCargada = "LISTAREQUISICION" Or TablaCargada = "LISTAREQUISICIONCANCELADAS" Then
            HabilitarImpresion()
        Else
            MsgBox("No esta cargada la tabla de Requisiciones")
        End If
    End Sub


    Private Sub IMPRIMIR()
        If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
            Select Case TablaCargada
                Case "LISTAREQUISICION"
                    If Me.DGV_ListaRequisiciones.Item("IMPRESA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value = "N" Then
                        If MsgBox("¿Desea imprimir la requisición?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                            Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                            Dim Array As New ArrayList
                            climpresiones.IDREQUISICION = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value
                            Array.Add(60)
                            If Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value = 45 Then
                                If MsgBox("¿Desea imprimir la requisicion con el logo de CSI?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                                    climpresiones.LogoEmpresa = 1 ' 1 = logo de CSI
                                End If
                            End If
                            If Trim(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Cancelada").Value) <> "Total" Then
                                climpresiones.FormatoImprimirMateriales(Array, True, False)
                                MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                            End If
                            If IsDBNull(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Cancelada").Value) = False Then
                                If Trim(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Cancelada").Value) <> "" Then
                                    If MsgBox("¿Desea imprimir las Cancelaciones asociadas?", MsgBoxStyle.YesNo, "Imprimir Cancelaciones") = MsgBoxResult.Yes Then
                                        Dim climpresiones1 As New ImpresiónMateriales.Cl_Impresión
                                        Dim Array1 As New ArrayList
                                        Array1.Add(61)
                                        climpresiones1.IDREQUISICION = climpresiones.IDREQUISICION
                                        climpresiones1.FormatoImprimirMateriales(Array1, True, False)
                                    End If
                                End If
                            End If
                        End If
                    Else
                        MsgBox("La Requisicion " + Trim(Me.DGV_ListaRequisiciones.Item("Requisición", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value) + " ya fue impresa", vbCritical, "Requisición")
                        Exit Sub
                    End If
                    CargarTablaxDefectoRequisiciones()
                Case "LISTAORDENCOMPRA"
                    If Me.DGV_ListaRequisiciones.Item("IMPRESA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value = "N" Then
                        If Tipo_Tabla_Cargada_OC = 8 Then
                            Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                            Dim Array As New ArrayList
                            Array.Add(63)
                            climpresiones.IDORDENDECOMPRA = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value
                            If Me.DGV_ListaRequisiciones.Item("IDBODEGARQ", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value = 45 Then
                                If MsgBox("¿Desea imprimir la requisicion con el logo de CSI?", MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
                                    climpresiones.LogoEmpresa = 1 ' 1 = logo de CSI
                                End If
                            End If
                            climpresiones.FormatoImprimirMateriales(Array, True, False)
                        Else
                            Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                            Dim Array As ArrayList

                            If Trim(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Cancelada").Value) <> "Total" Then
                                Array = New ArrayList
                                Array.Add(62)
                                climpresiones.IDORDENDECOMPRA = DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value
                                climpresiones.copiaparacontabilidad1 = True
                                climpresiones.copiaparacontabilidad2 = False
                                climpresiones.copiaparaconsecutivo = False
                                climpresiones.copiaparafolderpedido = False
                                climpresiones.FormatoImprimirMateriales(Array, True, False)
                            End If

                            If IsDBNull(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Cancelada").Value) = False Then
                                If Trim(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Cancelada").Value) <> "" Then
                                    If MsgBox("¿Desea imprimir las Cancelaciones asociadas?", MsgBoxStyle.YesNo, "Imprimir Cancelaciones") = MsgBoxResult.Yes Then
                                        Array = New ArrayList
                                        Array.Add(63)
                                        climpresiones.IDORDENDECOMPRA = DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value
                                        climpresiones.FormatoImprimirMateriales(Array, True, False)
                                    End If
                                End If
                            End If
                        End If
                        CargarOCxDefecto()
                    Else
                        MsgBox("La Orden de compra " + Trim(Me.DGV_ListaRequisiciones.Item("Orden de compra", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value) + " ya fue impresa", vbCritical, "Orden de compra")
                        Exit Sub
                    End If
                Case "LISTASOLICITUDMAQUINARIA"
                    If MsgBox("¿Desea imprimir la Solicitud?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                        Dim FrOpcionesImpresión As New ImpresiónMateriales.Fr_OpcionesImpresión
                        FrOpcionesImpresión.Tipo = 4
                        FrOpcionesImpresión.ID = DGV_ListaRequisiciones.SelectedRows(0).Cells("IDSOLICITUDMAQUINARIA").Value
                        FrOpcionesImpresión.Ck_Impresión1.Text = "Departamento de" & Environment.NewLine & "Maquinaria y Equipos"
                        FrOpcionesImpresión.Ck_Impresión1.Checked = True
                        FrOpcionesImpresión.Ck_Impresión2.Text = "Equipo Capital"
                        FrOpcionesImpresión.Ck_Impresión2.Checked = True
                        FrOpcionesImpresión.Ck_Impresión3.Text = "Transportes"
                        FrOpcionesImpresión.Ck_Impresión3.Checked = True
                        FrOpcionesImpresión.Ck_Impresión4.Visible = False
                        FrOpcionesImpresión.Ck_Impresión4.Checked = False
                        FrOpcionesImpresión.Ck_Impresión5.Visible = False
                        FrOpcionesImpresión.Ck_Impresión5.Checked = False
                        FrOpcionesImpresión.ShowDialog()
                    End If
            End Select
            Ubicar_Registro()
        End If
    End Sub


    Private Sub HabilitarImpresion()
        If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            Index_Registro_Actual = DGV_ListaRequisiciones.CurrentRow.Index
            Select Case TablaCargada
                Case "LISTAREQUISICION", "LISTAREQUISICIONCANCELADAS"
                    If MsgBox("¿Desea habilitar la impresion de la Requisición", MsgBoxStyle.YesNo, "Habilitar") = MsgBoxResult.Yes Then
                        '-----------------------
                        Dim Comando As New SqlClient.SqlCommand("HabilitarImpresion")
                        Comando.CommandType = CommandType.StoredProcedure
                        Comando.Parameters.AddWithValue("@IDDOCUMENTO", CStr(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value))
                        Comando.Parameters.AddWithValue("@TIPODOCUMENTO", "RQ")
                        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.NChar, 5)
                        msgParam.Direction = ParameterDirection.Output
                        Comando.Parameters.Add(msgParam)

                        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                        conn.Open()
                        Comando.Connection = conn
                        Try
                            Comando.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try

                        CargarTablaxDefectoRequisiciones()
                        '------------------------

                        'Dim Dt_Requisicion As DataTable
                        'Dim Cadena_Consulta_Update As String = ""
                        'Select Case TablaCargada
                        '    Case "LISTAREQUISICION"
                        '        Cadena_Consulta_Update = "UPDATE REQUISICION SET IMPRESA ='N' WHERE IDREQUISICION = " + CStr(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value)
                        '    Case "LISTAREQUISICIONCANCELADAS"
                        '        If Trim(Me.DGV_ListaRequisiciones.Item("Cancelada", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value) = "Parcial" Then
                        '            Cadena_Consulta_Update = "UPDATE REQUISICION SET IMPRESA ='N' WHERE IDREQUISICION = " + CStr(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value)
                        '        Else
                        '            Cadena_Consulta_Update = "UPDATE CAN_REQUISICION SET IMPRESA ='N' WHERE IDREQUISICION = " + CStr(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value)
                        '        End If
                        'End Select

                        'Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
                        'Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                        'Consulta.Connection = Conexión
                        'Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                        'Consulta.Connection.Open()
                        'Dt_Requisicion = New DataTable
                        'Adaptador.FillSchema(Dt_Requisicion, SchemaType.Source)
                        'Adaptador.Fill(Dt_Requisicion)
                        'Consulta.Connection.Close()
                        'Select Case TablaCargada
                        '    Case "LISTAREQUISICION"
                        '        CargarTablaxDefectoRequisiciones()
                        '    Case "LISTAREQUISICIONCANCELADAS"
                        '        CargarCanceladasXdefecto()
                        'End Select
                    End If

                Case "LISTAORDENCOMPRA"
                    If MsgBox("¿Desea habilitar la impresión de la Orden de compra", MsgBoxStyle.YesNo, "Habilitar") = MsgBoxResult.Yes Then
                        '-----------------------
                        Dim Comando As New SqlClient.SqlCommand("HabilitarImpresion")
                        Comando.CommandType = CommandType.StoredProcedure
                        Comando.Parameters.AddWithValue("@IDDOCUMENTO", CStr(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value))
                        Comando.Parameters.AddWithValue("@TIPODOCUMENTO", "OC")
                        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.NChar, 5)
                        msgParam.Direction = ParameterDirection.Output
                        Comando.Parameters.Add(msgParam)

                        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                        conn.Open()
                        Comando.Connection = conn
                        Try
                            Comando.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try

                        CargarOCxDefecto()
                        '------------------------


                        'Dim Dt_Requisicion As DataTable
                        'Dim Cadena_Consulta_Update As String = ""
                        'Select Case Tipo_Tabla_Cargada_OC
                        '    Case 8
                        '        If Trim(Me.DGV_ListaRequisiciones.Item("Cancelada", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value) = "Parcial" Then
                        '            Cadena_Consulta_Update = "UPDATE ORDENCOMPRA SET IMPRESA ='N' WHERE IDORDENCOMPRA = " + CStr(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value)
                        '        Else
                        '            Cadena_Consulta_Update = "UPDATE CAN_ORDENCOMPRA SET IMPRESA ='N' WHERE IDORDENCOMPRA = " + CStr(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value)
                        '        End If
                        '    Case Else
                        '        Cadena_Consulta_Update = "UPDATE ORDENCOMPRA SET IMPRESA ='N' WHERE IDORDENCOMPRA = " + CStr(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value)

                        'End Select

                        'Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
                        'Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                        'Consulta.Connection = Conexión
                        'Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                        'Consulta.Connection.Open()
                        'Dt_Requisicion = New DataTable
                        'Adaptador.FillSchema(Dt_Requisicion, SchemaType.Source)
                        'Adaptador.Fill(Dt_Requisicion)
                        'Consulta.Connection.Close()
                        'Select Case TablaCargada
                        '    Case "LISTAORDENCOMPRA"
                        '        If Tipo_Tabla_Cargada_OC = 8 Then
                        '            CargarCanceladasXdefecto()
                        '        Else
                        '            CargarOCxDefecto()
                        '        End If

                        '    Case "LISTAORDENCOMPRACANCELADA"
                        '        ''Agregar ordenes de compra canceladas
                        'End Select
                    End If

                Case "LISTARELACIONESFACTURAS"
                    If MsgBox("¿Desea habilitar la impresión de la relación de factuas", MsgBoxStyle.YesNo, "Habilitar") = MsgBoxResult.Yes Then
                        Dim Dt_Requisicion As DataTable
                        Dim Cadena_Consulta_Update As String = "UPDATE CC_RELACIONDOCUMENTO SET IMPRESA ='N' WHERE IDRELACIONDOCUMENTO = " + CStr(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value)
                        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
                        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                        Consulta.Connection = Conexión
                        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                        Consulta.Connection.Open()
                        Dt_Requisicion = New DataTable
                        Adaptador.FillSchema(Dt_Requisicion, SchemaType.Source)
                        Adaptador.Fill(Dt_Requisicion)
                        Consulta.Connection.Close()
                    End If
            End Select
            Ubicar_Registro()
        End If
    End Sub

#End Region 'Imprimir

#Region "Filtro"
    Private Sub Bt_FiltrarLista_Click(sender As System.Object, e As System.EventArgs) Handles Bt_FiltrarLista.Click
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            Dim Filtro As String = "000"
            Dim filtrovista As String = ""
            Dim nombrecolumna1 As String
            Dim nombrecolumna2 As String
            Dim nombrecolumna3 As String
            nombrecolumna1 = Me.Cb_FiltrarPor1.Text
            nombrecolumna2 = Me.Cb_FiltrarPor2.Text
            nombrecolumna3 = Me.Cb_FiltrarPor3.Text

            If Ck_Filtro1.Checked = True Then
                If Trim(Me.Tx_ValorFiltro1.Text) <> "" Then
                    Filtro = "1" + Mid(Filtro, 2, 2)
                    Select Case DGV_ListaRequisiciones.Columns(nombrecolumna1).ValueType
                        Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                            If IsNumeric(Trim(Me.Tx_ValorFiltro1.Text).ToString) = False Then
                                MsgBox("El valor del filtro 1 no corresponde con el tipo de dato", MsgBoxStyle.Critical, "Error del tipo de dato")
                                Exit Sub
                            End If
                    End Select
                End If
            End If
            If Ck_Filtro2.Checked = True Then
                If Trim(Me.Tx_ValorFiltro2.Text) <> "" Then
                    Filtro = Mid(Filtro, 1, 1) + "1" + Mid(Filtro, 3, 1)
                    Select Case DGV_ListaRequisiciones.Columns(nombrecolumna2).ValueType
                        Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                            If IsNumeric(Trim(Me.Tx_ValorFiltro2.Text).ToString) = False Then
                                MsgBox("El valor del filtro 2 no corresponde con el tipo de dato", MsgBoxStyle.Critical, "Error del tipo de dato")
                                Exit Sub
                            End If
                    End Select
                End If
            End If
            If Ck_Filtro3.Checked = True Then
                If Trim(Me.Tx_ValorFiltro3.Text) <> "" Then
                    Filtro = Mid(Filtro, 1, 2) + "1"
                    Select Case DGV_ListaRequisiciones.Columns(nombrecolumna3).ValueType
                        Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                            If IsNumeric(Trim(Me.Tx_ValorFiltro3.Text).ToString) = False Then
                                MsgBox("El valor del filtro 3 no corresponde con el tipo de dato", MsgBoxStyle.Critical, "Error del tipo de dato")
                                Exit Sub
                            End If
                    End Select
                End If
            End If

            'cargar tabla
            Dim vista As DataView
            Select Case TablaCargada
                Case "LISTAPROVEEDORES"
                    vista = New DataView(dsProveedores.Tables(0))
                    Exit Select
                Case "LISTAORDENCOMPRA"
                    vista = New DataView(dsOrdenesCompra.Tables(0))
                    Exit Select
                Case "LISTAREQUISICION"
                    vista = New DataView(dsRequisiciones.Tables(0))
                    Exit Select
                Case Else
                    vista = New DataView(dsRequisiciones.Tables(0))
                    Exit Select
            End Select

            Select Case Filtro
                Case "000"
                    filtrovista = ""
                Case "100"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, Trim(Me.Tx_ValorFiltro1.Text).ToString)
                Case "110"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, nombrecolumna2, Trim(Me.Tx_ValorFiltro1.Text).ToString, Trim(Me.Tx_ValorFiltro2.Text).ToString)
                Case "111"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, nombrecolumna2, nombrecolumna3, Trim(Me.Tx_ValorFiltro1.Text).ToString, Trim(Me.Tx_ValorFiltro2.Text).ToString, Trim(Me.Tx_ValorFiltro3.Text).ToString)
                Case "010"
                    filtrovista = ConcatenarFiltro(nombrecolumna2, Trim(Me.Tx_ValorFiltro2.Text).ToString)
                Case "011"
                    filtrovista = ConcatenarFiltro(nombrecolumna2, nombrecolumna3, Trim(Me.Tx_ValorFiltro2.Text).ToString, Trim(Me.Tx_ValorFiltro3.Text).ToString)
                Case "001"
                    filtrovista = ConcatenarFiltro(nombrecolumna3, Trim(Me.Tx_ValorFiltro3.Text).ToString)
                Case "101"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, nombrecolumna3, Trim(Me.Tx_ValorFiltro1.Text).ToString, Trim(Me.Tx_ValorFiltro3.Text).ToString)
            End Select
            vista.RowFilter = filtrovista
            Me.DGV_ListaRequisiciones.SuspendLayout()
            Me.DGV_ListaRequisiciones.DataSource = vista
            Me.DGV_ListaRequisiciones.ResumeLayout()

            'Actualizar mensaje de regsitros en pantalla 
            Select Case TablaCargada
                Case "LISTAPROVEEDORES"
                    Me.Lb_CantidadRequisición.Text = "Lista de proveedores, esta viendo  " + vista.Count.ToString + " proveedores"
                    Exit Select
                Case "LISTAORDENCOMPRA"
                    Me.Lb_CantidadRequisición.Text = "Lista de Ordenes de Compra, esta viendo  " + vista.Count.ToString
                    Exit Select
                Case "LISTAREQUISICION"
                    Me.Lb_CantidadRequisición.Text = "Lista de Requisiciones, esta viendo  " + vista.Count.ToString

                    Exit Select
                Case Else

                    Exit Select
            End Select
        Catch ex As Exception
            MsgBox("Ocurrio un inconveniente al procesar la instrucción", MsgBoxStyle.Critical, "Inconveniente")
        End Try
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub


    Private Function ConcatenarFiltro(ByVal Columna1 As String, ByVal Valor1 As String) As String
        Select Case DGV_ListaRequisiciones.Columns(Columna1).ValueType
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


    Private Function ConcatenarFiltro(ByVal Columna1 As String, ByVal Columna2 As String, ByVal Valor1 As String, ByVal Valor2 As String) As String
        Select Case DGV_ListaRequisiciones.Columns(Columna1).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                Select Case DGV_ListaRequisiciones.Columns(Columna2).ValueType
                    'columna 1 decimal y columna 2 decimal
                    Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                        ConcatenarFiltro = String.Format("{0} = {1} AND {2} = {3}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                        'columna 1 decimal y columna 2 string
                    Case Type.GetType("System.String")
                        ConcatenarFiltro = String.Format("{0} = {1} AND {2} like '%{3}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                    Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                        ConcatenarFiltro = ""
                End Select
            Case Type.GetType("System.String")
                Select Case DGV_ListaRequisiciones.Columns(Columna2).ValueType
                    'columna 1 string y columna 2 decimal
                    Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                        ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} = {3}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                        'columna 1 string y columna 2 string
                    Case Type.GetType("System.String")
                        ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} like '%{3}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                    Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                        ConcatenarFiltro = ""
                End Select
            Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                ConcatenarFiltro = ""
        End Select
    End Function


    Private Function ConcatenarFiltro(ByVal Columna1 As String, ByVal Columna2 As String, ByVal Columna3 As String, ByVal Valor1 As String, ByVal Valor2 As String, ByVal Valor3 As String) As String
        Dim tipocolumna1 As String
        Dim tipocolumna2 As String
        Dim tipocolumna3 As String

        Select Case DGV_ListaRequisiciones.Columns(Columna1).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                tipocolumna1 = "N"
            Case Type.GetType("System.String")
                tipocolumna1 = "S"
            Case Else
                ConcatenarFiltro = ""
                Exit Function
        End Select
        Select Case DGV_ListaRequisiciones.Columns(Columna2).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                tipocolumna2 = "N"
            Case Type.GetType("System.String")
                tipocolumna2 = "S"
            Case Else
                ConcatenarFiltro = ""
                Exit Function
        End Select
        Select Case DGV_ListaRequisiciones.Columns(Columna3).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                tipocolumna3 = "N"
            Case Type.GetType("System.String")
                tipocolumna3 = "S"
            Case Else
                ConcatenarFiltro = ""
                Exit Function
        End Select
        Select Case tipocolumna1 + tipocolumna2 + tipocolumna3
            Case "NNN"
                ConcatenarFiltro = String.Format("{0} = {1} AND {2} = {3} AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "NNS"
                ConcatenarFiltro = String.Format("{0} = {1} AND {2} = {3} AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "NSS"
                ConcatenarFiltro = String.Format("{0} = {1} AND {2} like '%{3}%' AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SSS"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} like '%{3}%' AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SSN"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} like '%{3}%' AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SNN"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND  {2} = {3} AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SNS"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND  {2} = {3} AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "NSN"
                ConcatenarFiltro = String.Format("{0} = {1} AND  {2} like '%{3}%' AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case Else
                ConcatenarFiltro = ""
        End Select
    End Function

#End Region 'Filtro

#Region "Aplicar estilos"

    Private Sub CargarRequisicionFiltro(ByVal DsTabla As DataSet)
        Me.DGV_ListaRequisiciones.ReadOnly = False
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Me.DGV_ListaRequisiciones.DataSource = Nothing

        Me.DGV_ListaRequisiciones.DataSource = DsTabla.Tables(0).DefaultView
        Me.Lb_CantidadRequisición.Text = "Lista de Requisiciones, está viendo  " + DsTabla.Tables(0).Rows.Count.ToString + " requisiciones"
        Me.DGV_ListaRequisiciones.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_ListaRequisiciones.ReadOnly = True
        Me.dt_opcionesfiltro1.Rows.Clear()
        Me.dt_opcionesfiltro2.Rows.Clear()
        Me.dt_opcionesfiltro3.Rows.Clear()
        Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()

        For i = 0 To DGV_ListaRequisiciones.ColumnCount - 1
            Dim filaopciónfiltro1 As DataRow
            Dim filaopciónfiltro2 As DataRow
            Dim filaopciónfiltro3 As DataRow
            filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
            filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
            filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
            filaopciónfiltro1("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            filaopciónfiltro2("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            filaopciónfiltro3("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
            dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
            dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)

            Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
            Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_ListaRequisiciones.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
            Submenuitem.Name = DGV_ListaRequisiciones.Columns(i).Name
            Submenuitem.Size = New System.Drawing.Size(152, 22)
            Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})

            Select Case DGV_ListaRequisiciones.Columns(i).Name
                Case "Id"
                    DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Id Requisición"
                Case "Persona que gestiona"
                    DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Persona que gestiona"
                Case "Año"
                    DGV_ListaRequisiciones.Columns(i).Width = 50
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Año"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Tipo"
                    DGV_ListaRequisiciones.Columns(i).Width = 40
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Tipo de la RQ"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Stock"
                    DGV_ListaRequisiciones.Columns(i).Name = "Stock"
                    DGV_ListaRequisiciones.Columns(i).Width = 40
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Es stock de bodega"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Aut"
                    DGV_ListaRequisiciones.Columns(i).Width = 30
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Se encuentra Autorizada"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Apr"
                    DGV_ListaRequisiciones.Columns(i).Width = 30
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Se encuentra Aprobada"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Rev"
                    DGV_ListaRequisiciones.Columns(i).Width = 35
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Ya fue revisada"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Vb"
                    DGV_ListaRequisiciones.Columns(i).Width = 30
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "S/N si requiere Visto Bueno"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "RevBP"
                    DGV_ListaRequisiciones.Columns(i).Width = 45
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Revisado Bodega Principal"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "VbSg"
                    DGV_ListaRequisiciones.Columns(i).Width = 40
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "S/N Visto Bueno de gerencia"
                    DGV_ListaRequisiciones.Columns(i).HeaderText = "VbG"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "SSVb"
                    DGV_ListaRequisiciones.Columns(i).Width = 45
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Subido al Servidor"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Requisición"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Identificador de la RQ"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Cancelada"
                    DGV_ListaRequisiciones.Columns(i).Width = 60
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Tiena alguna Cancelación"
                Case "DiasAsignada"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle = VariablesBase.VariablesBase.style
                    DGV_ListaRequisiciones.Columns(i).Width = 50
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Días Asignada"
                    DGV_ListaRequisiciones.Columns(i).HeaderText = "Días Asignada"
                Case "Familia"
                    DGV_ListaRequisiciones.Columns(i).Width = 200
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Familia"
                Case Else
                    DGV_ListaRequisiciones.Columns(i).Visible = False
            End Select
        Next

        Me.Pn_ListaPrincipal.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)

        Me.Dgv_ListaItemRequisición.ContextMenuStrip = Me.Cms_CancelarItemRQ
        Me.Lb_Cargado.Text = "REQUISICIONES"

        Lb_Filtro.Text = "Requisiciones"
        Me.Dgv_ListaItemRequisición.DataSource = Nothing

        Try
            Me.DGV_ListaRequisiciones.Rows(0).Selected = True
            CargarListaxSeleccion()
        Catch ex As Exception
        End Try
        CargarItems()
    End Sub


    Private Sub CargarOrdenCompraFiltro(ByVal dsTabla As DataSet)
        DGV_ListaRequisiciones.DataSource = Nothing

        Me.DGV_ListaRequisiciones.DataSource = dsTabla.Tables(0).DefaultView
        Me.Lb_CantidadRequisición.Text = "Lista de Ordenes de Compra, está viendo  " + dsTabla.Tables(0).Rows.Count.ToString
        Me.DGV_ListaRequisiciones.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.DGV_ListaRequisiciones.ReadOnly = True
        Me.dt_opcionesfiltro1.Rows.Clear()
        Me.dt_opcionesfiltro2.Rows.Clear()
        Me.dt_opcionesfiltro3.Rows.Clear()
        Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()
        For i = 0 To DGV_ListaRequisiciones.ColumnCount - 1
            Dim filaopciónfiltro1 As DataRow
            Dim filaopciónfiltro2 As DataRow
            Dim filaopciónfiltro3 As DataRow
            filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
            filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
            filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
            filaopciónfiltro1("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            filaopciónfiltro2("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            filaopciónfiltro3("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
            dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
            dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)

            Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
            Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_ListaRequisiciones.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
            Submenuitem.Name = DGV_ListaRequisiciones.Columns(i).Name
            Submenuitem.Size = New System.Drawing.Size(152, 22)
            Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})


            Select Case DGV_ListaRequisiciones.Columns(i).Name
                Case "Id"
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Id Orden de Compra"
                    DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "Persona que gestiona"
                    DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Persona que gestiona"
                Case "Tipo"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaRequisiciones.Columns(i).Width = 35
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Tipo de Orden de Compra"
                Case "Orden de Compra"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Orden de Compra"
                Case "Requisición"
                    DGV_ListaRequisiciones.Columns(i).Width = 140
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Requisición Asociada"
                Case "Cancelada"
                    DGV_ListaRequisiciones.Columns(i).Width = 50
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Tiene alguna cancelación"
                Case "Aut"
                    DGV_ListaRequisiciones.Columns(i).Width = 35
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Se encuentra Autoriza"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Apr"
                    DGV_ListaRequisiciones.Columns(i).Width = 35
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Se encuentra Aprobada"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Rev"
                    DGV_ListaRequisiciones.Columns(i).Width = 35
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Se encuentra Revisada"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "ApGe"
                    DGV_ListaRequisiciones.Columns(i).Width = 40
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Se encuentra aprobada de Gerencia"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "EnPr"
                    DGV_ListaRequisiciones.Columns(i).Width = 40
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Se envió al Proveedor"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "AcPr"
                    DGV_ListaRequisiciones.Columns(i).Width = 40
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Aceptada por el Proveedor"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "DiasVencida"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle = VariablesBase.VariablesBase.style
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaRequisiciones.Columns(i).Width = 50
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Días Vencida"
                    DGV_ListaRequisiciones.Columns(i).HeaderText = "Días Vencida"
                Case "Servidor"
                    DGV_ListaRequisiciones.Columns(i).Width = 45
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Subido al Servidor"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    DGV_ListaRequisiciones.Columns(i).Visible = False
            End Select
        Next

        Me.Pn_ListaPrincipal.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)

        Me.Dgv_ListaItemRequisición.ContextMenuStrip = Me.Cms_CancelarItemOC


        Try
            Me.DGV_ListaRequisiciones.Rows(0).Selected = True
            CargarListaxSeleccion()
        Catch ex As Exception
        End Try


        Me.Dgv_ListaItemRequisición.DataSource = Nothing
        CargarItems()
    End Sub

    Private Sub CargarProveedoresFiltro(ByVal DsTabla As DataSet)
        DGV_ListaRequisiciones.DataSource = Nothing
        DGV_ListaRequisiciones.DataSource = DsTabla.Tables(0).DefaultView
        Me.Pn_ListaPrincipal.Height = Pn_ContenedorPrincipal.Height - 30
        Me.DGV_ListaRequisiciones.AutoGenerateColumns = True
        Me.DGV_ListaRequisiciones.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.dt_opcionesfiltro1.Rows.Clear()
        Me.dt_opcionesfiltro2.Rows.Clear()
        Me.dt_opcionesfiltro3.Rows.Clear()
        Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()

        For i = 0 To DGV_ListaRequisiciones.ColumnCount - 1
            Select Case DGV_ListaRequisiciones.Columns(i).Name
                Case "Id", "Est", "Abre", "Nombre", "Identificación", "Ciudad", "Dirección", "Telefóno", "Celular", "Email"
                    Dim filaopciónfiltro1 As DataRow
                    Dim filaopciónfiltro2 As DataRow
                    Dim filaopciónfiltro3 As DataRow
                    filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
                    filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
                    filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
                    filaopciónfiltro1("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
                    filaopciónfiltro2("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
                    filaopciónfiltro3("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
                    dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
                    dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
                    dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)

                    Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
                    Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_ListaRequisiciones.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
                    Submenuitem.Name = DGV_ListaRequisiciones.Columns(i).Name
                    Submenuitem.Size = New System.Drawing.Size(152, 22)
                    Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})
            End Select

            Select Case DGV_ListaRequisiciones.Columns(i).Name
                Case "Id"
                    DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Id"
                Case "Est"
                    DGV_ListaRequisiciones.Columns(i).Width = 40
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Est"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Abre"
                    DGV_ListaRequisiciones.Columns(i).Width = 40
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Abre"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Cat"
                    DGV_ListaRequisiciones.Columns(i).Width = 40
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Cat"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Nombre"
                    DGV_ListaRequisiciones.Columns(i).Width = 300
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Nombre"
                Case "Identificación"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Identificación"
                Case "Ciudad"
                    DGV_ListaRequisiciones.Columns(i).Width = 100
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Ciudad"
                Case "Dirección"
                    DGV_ListaRequisiciones.Columns(i).Width = 100
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Dirección"
                Case "Telefóno"
                    DGV_ListaRequisiciones.Columns(i).Width = 100
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Teléfono"
                Case "Celular"
                    DGV_ListaRequisiciones.Columns(i).Width = 100
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Celular"
                Case "Email"
                    DGV_ListaRequisiciones.Columns(i).Width = 200
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Email"
                Case Else
                    DGV_ListaRequisiciones.Columns(i).Visible = False
            End Select
        Next

        Me.DGV_ListaRequisiciones.ScrollBars = ScrollBars.Both

        Me.Dgv_ListaItemRequisición.ContextMenuStrip = Nothing
        Me.Lb_Cargado.Text = "PROVEEDORES"
        Lb_Filtro.Text = "Proveedores"
        Me.Lb_CantidadRequisición.Text = "Lista de proveedores, esta viendo  " + Me.DGV_ListaRequisiciones.RowCount.ToString + " proveedores"
        Try
            Me.DGV_ListaRequisiciones.Rows(0).Selected = True
            CargarListaxSeleccion()
        Catch ex As Exception
        End Try
        Me.Dgv_ListaItemRequisición.DataSource = Nothing
    End Sub

    Private Sub CargarListaRemisionesFacturas(ByVal Tipo As Integer)
        Dim adap As New Facturas.Ds_FacturasTableAdapters.LISTARELACIONESTableAdapter
        Select Case Tipo
            Case 0
                If VariablesBase.VariablesBase.IdBodegaActual = 1 Then
                    adap.FillByreLACIONfACTURAx50(Me.DsFacturas.LISTARELACIONES)
                Else
                    adap.FillLISTARELACIONESx50iDPERSONA(Me.DsFacturas.LISTARELACIONES, VariablesBase.VariablesBase.IdPersona)
                End If
            Case 1
                If VariablesBase.VariablesBase.IdBodegaActual = 1 Then
                    adap.FillByLISTARELACIONESTODAS(Me.DsFacturas.LISTARELACIONES)
                Else
                    adap.FillByLISTARELACIONTODASxBODEGA(Me.DsFacturas.LISTARELACIONES, VariablesBase.VariablesBase.IdBodegaActual)
                End If
        End Select

        DGV_ListaRequisiciones.DataSource = Nothing

        Me.Pn_ListaPrincipal.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)
        Me.DGV_ListaRequisiciones.DataSource = Me.DsFacturas.LISTARELACIONES
        Me.DGV_ListaRequisiciones.AutoGenerateColumns = True
        Me.DGV_ListaRequisiciones.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.dt_opcionesfiltro1.Rows.Clear()
        Me.dt_opcionesfiltro2.Rows.Clear()
        Me.dt_opcionesfiltro3.Rows.Clear()
        Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()

        For i = 0 To DGV_ListaRequisiciones.ColumnCount - 1
            Dim filaopciónfiltro1 As DataRow
            Dim filaopciónfiltro2 As DataRow
            Dim filaopciónfiltro3 As DataRow
            filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
            filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
            filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
            filaopciónfiltro1("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            filaopciónfiltro2("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            filaopciónfiltro3("OPCION") = DGV_ListaRequisiciones.Columns(i).Name
            dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
            dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
            dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)

            Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
            Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_ListaRequisiciones.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
            Submenuitem.Name = DGV_ListaRequisiciones.Columns(i).Name
            Submenuitem.Size = New System.Drawing.Size(152, 22)
            Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})

            Select Case DGV_ListaRequisiciones.Columns(i).Name
                Case "Id"
                    DGV_ListaRequisiciones.Columns(i).Width = 30
                    DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "No"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "Fecha"
                    DGV_ListaRequisiciones.Columns(i).Width = 80
                Case "Registro"
                    DGV_ListaRequisiciones.Columns(i).Width = 150
                Case "De"
                    DGV_ListaRequisiciones.Columns(i).Width = 150
                Case "Para"
                    DGV_ListaRequisiciones.Columns(i).Width = 150
                Case "IMPRESA"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_ListaRequisiciones.Columns(i).Width = 60
                Case "Servidor"
                    DGV_ListaRequisiciones.Columns(i).Width = 45
                    DGV_ListaRequisiciones.Columns(i).ToolTipText = "Subido al Servidor"
                    DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "AÑO"
                    DGV_ListaRequisiciones.Columns(i).Visible = False
            End Select

            'DGV_ListaRequisiciones.Columns(i).Visible = True

        Next
        Me.Dgv_ListaItemRequisición.ContextMenuStrip = Nothing
        TablaCargada = "LISTARELACIONESFACTURAS"
        Me.Lb_Cargado.Text = "RELACION DE FACTURAS"
        Lb_Filtro.Text = "Relaciones"
        Me.Lb_CantidadRequisición.Text = "Lista de relaciones, está viendo  " + Me.DsFacturas.LISTARELACIONES.Rows.Count.ToString + " proveedores"
        Try
            Me.DGV_ListaRequisiciones.Rows(0).Selected = True
            CargarItems()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarSolicitudesMaquinaria()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListaSolicitudMaquinaria(@TIPO, @IDBODEGA, @IDUSUARIO) ORDER BY [IDSOLICITUDMAQUINARIA] DESC", conexion)
        Dim tipo As Integer
        If FuncionesBase.FuncionesBase.ConsultarPermiso("579") Then
            'Permiso para Visualizar todas las Solicitudes de Maquinaria de Ismocol S.A.
            tipo = 0
        Else
            If FuncionesBase.FuncionesBase.ConsultarPermiso("578") Then
                tipo = 1
            Else
                tipo = 2
            End If
        End If
        comando.Parameters.AddWithValue("@TIPO", tipo)
        comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtSolicitudes As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtSolicitudes)
            conexion.Close()
            DGV_ListaRequisiciones.DataSource = dtSolicitudes
            TablaCargada = "LISTASOLICITUDMAQUINARIA"
            Lb_Cargado.Text = "SOLICITUDES DE MAQUINARIA Y EQUIPO"
            For i As Integer = 0 To DGV_ListaRequisiciones.ColumnCount - 1
                Select Case DGV_ListaRequisiciones.Columns(i).Name
                    Case DGV_ListaRequisiciones.Columns("IDSOLICITUDMAQUINARIA").Name
                        DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_ListaRequisiciones.Columns(i).HeaderText = "Id"
                    Case DGV_ListaRequisiciones.Columns("SOLICITUDMAQUINARIA").Name
                        DGV_ListaRequisiciones.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                        DGV_ListaRequisiciones.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_ListaRequisiciones.Columns(i).Width = 100
                        DGV_ListaRequisiciones.Columns(i).HeaderText = "Consecutivo"
                    Case DGV_ListaRequisiciones.Columns("USUARIOREGISTRO").Name
                        DGV_ListaRequisiciones.Columns(i).Width = 250
                        DGV_ListaRequisiciones.Columns(i).HeaderText = "Registró"
                    Case Else
                        DGV_ListaRequisiciones.Columns(i).Visible = False
                End Select
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


#End Region

    Private Sub CopiarIdentificaciónDocumentoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopiarIdentificaciónDocumentoToolStripMenuItem.Click
        Try
            Clipboard.SetDataObject(Trim(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Identificación").Value))
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Cms_CancelarItemRQ_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles Cms_CancelarItemRQ.Opening
        If Me.Dgv_ListaItemRequisición.DataSource.tablename = "ListaItemRQ" Then
            CopiarIdentificaciónDocumentoToolStripMenuItem.Enabled = False
        Else
            CopiarIdentificaciónDocumentoToolStripMenuItem.Enabled = True
        End If
    End Sub


    Private Sub CargarListaxSeleccion()
        Try
            Select Case TablaCargada
                Case "LISTAREQUISICION", "LISTAREQUISICIONCANCELADAS"
                    Cursor.Current = Cursors.WaitCursor
                    Dim Cadena_Consulta As String
                    Cadena_Consulta = "SELECT * FROM dbo.DetalleRequisición(" + Me.DGV_ListaRequisiciones.Item("Id", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value.ToString + ") AS DetalleRequisición"
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                    Consulta.Connection = Conexión
                    Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Dim Dt_RQ As New DataTable
                    Adaptador.FillSchema(Dt_RQ, SchemaType.Source)
                    Adaptador.Fill(Dt_RQ)
                    Consulta.Connection.Close()
                    Pn_Suministros.Visible = False
                    Dim xx As New Cl_Requisicion(Dt_RQ.Rows(0)) 'Me.DGV_ListaRequisiciones.Rows(DGV_ListaRequisiciones.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                    Cursor.Current = Cursors.Default
                Case "LISTAORDENCOMPRA"
                    Cursor.Current = Cursors.WaitCursor
                    Dim Cadena_Consulta As String
                    Cadena_Consulta = "SELECT * FROM dbo.DetalleOrdenCompra(" + Me.DGV_ListaRequisiciones.Item("Id", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value.ToString + ") AS DetalleOrdenCompra"
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                    Consulta.Connection = Conexión
                    Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Dim Dt_OC As New DataTable
                    Adaptador.FillSchema(Dt_OC, SchemaType.Source)
                    Adaptador.Fill(Dt_OC)
                    Consulta.Connection.Close()
                    Pn_Suministros.Visible = False
                    Dim xx As New Cl_OrdenCompra(Dt_OC.Rows(0)) 'Me.DGV_ListaRequisiciones.Rows(DGV_ListaRequisiciones.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                    Cursor.Current = Cursors.Default
                Case "LISTAPROVEEDORES"
                    Dim xx As New Cl_Proveedor(Me.DGV_ListaRequisiciones.Rows(DGV_ListaRequisiciones.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                    Pn_Suministros.Visible = True
                    Pn_Suministros.Height = Pn_Propiedades.Height - ((Pn_Propiedades.Height * 50) / 100)
                    If ChB_MostrarSuministros.Checked Then
                        Me.Dgv_Suministros.DataSource = Nothing
                        Me.LISTASUMINISTROSPROVEEDOR.Fill(Me.DsProveedor.LISTASUMINISTROPROVEEDOR, Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value)
                        Me.Dgv_Suministros.DataSource = Me.DsProveedor.LISTASUMINISTROPROVEEDOR
                        Me.Dgv_Suministros.AutoGenerateColumns = True
                        Me.Dgv_Suministros.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
                        'Me.Dgv_Suministros.ReadOnly = True
                        Me.Dgv_Suministros.EditMode = False
                        Dgv_Suministros.Columns("Suministro").Width = 450
                        Me.Dgv_Suministros.ColumnHeadersVisible = False
                        Me.Dgv_Suministros.RowHeadersVisible = False
                    End If
                Case "LISTASOLICITUDMAQUINARIA"
                    Cursor.Current = Cursors.WaitCursor
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("SELECT * FROM dbo.DatosSolicitudMaquinaria(@IDSOLICITUDMAQUINARIA)", conexion)
                    comando.Parameters.AddWithValue("@IDSOLICITUDMAQUINARIA", DGV_ListaRequisiciones.SelectedRows(0).Cells("IDSOLICITUDMAQUINARIA").Value) 'DGV_ListaRequisiciones.Item("Id", DGV_ListaRequisiciones.CurrentCell.RowIndex).Value)
                    Dim adaptador As New SqlDataAdapter(comando)
                    Dim dtSolicitudMaquinaria As New DataTable
                    Try
                        conexion.Open()
                        adaptador.FillSchema(dtSolicitudMaquinaria, SchemaType.Source)
                        adaptador.Fill(dtSolicitudMaquinaria)
                        conexion.Close()
                        Pn_Suministros.Visible = False
                        Dim xx As New Cl_SolicitudMaquinaria(dtSolicitudMaquinaria.Rows(0))
                        Pg_DetalleLista.SelectedObject = xx
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conexion.Close()
                    End Try
                    Cursor.Current = Cursors.Default
            End Select
            CargarItems()
        Catch ex As Exception
            Pg_DetalleLista.SelectedObject = Nothing
        End Try
    End Sub


    Private Sub ChB_MostrarSuministros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_MostrarSuministros.CheckedChanged
        If ChB_MostrarSuministros.Checked Then
            CargarListaxSeleccion()
        Else
            Me.Dgv_Suministros.DataSource = Nothing
        End If
    End Sub


    Private Sub DGV_ListaRequisiciones_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV_ListaRequisiciones.SelectionChanged
        CargarListaxSeleccion()
    End Sub


    Private Sub Nbi_AsignarComprador_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_AsignarComprador.ItemClick
        If TablaCargada = "LISTAREQUISICION" Then
            If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
                Dim FrCompradores As New Requisición.Fr_Compradores
                FrCompradores.IDREQUISICION = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value
                FrCompradores.REQUISICION = Trim(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Requisición").Value)
                Try
                    FrCompradores.IdpersonaVistoBueno = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("IDPERSONAVISTOBUENO").Value
                Catch ex As Exception
                    FrCompradores.IdpersonaVistoBueno = -1
                End Try
                Try
                    FrCompradores.IdpersonaVistoBuenoSubgerencia = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("IDPERSONAVBSUBGERENCIA").Value
                Catch ex As Exception
                    FrCompradores.IdpersonaVistoBuenoSubgerencia = -1
                End Try
                FrCompradores.cargar()
                FrCompradores.ShowDialog()
                If MsgBox("¿Desea cargar la lista de requisiciones?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                    CargarTablaxDefectoRequisiciones()
                    Ubicar_Registro()
                End If

            End If
        Else
            MsgBox("No está cargada la tabla de Requisiciones")
        End If
    End Sub


    Private Sub Ubicar_Registro()
        Try
            Me.DGV_ListaRequisiciones.CurrentCell = Me.DGV_ListaRequisiciones(0, Index_Registro_Actual)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Nbi_RevisiónPiede_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_RevisiónBodegaPrincipal.ItemClick
        If TablaCargada = "LISTAREQUISICION" Then
            If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
                If MsgBox("¿Desea marcar como revisada la requisición?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Marcar Revisar Requisición") = vbYes Then
                    Dim Comando As New SqlClient.SqlCommand("dbo.MarcarRevisiónRQBodegaPrincipal")
                    Comando.CommandType = CommandType.StoredProcedure
                    Dim IDrequisicionREvisada As Integer = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value
                    Comando.Parameters.AddWithValue("@IDREQUISICION", IDrequisicionREvisada)
                    Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                    Comando.Parameters.AddWithValue("@REVISADOBODEGAPRINCIPAL", "S")
                    Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                    conn.Open()
                    Comando.Connection = conn
                    Comando.ExecuteNonQuery()
                    conn.Close()
                End If
                Ubicar_Registro()
            End If
        Else
            MsgBox("No esta cargada la tabla de Requisiciones")
        End If
    End Sub


    Private Sub Dgv_ListaItemRequisición_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Dgv_ListaItemRequisición.CellFormatting
        For i = 0 To Dgv_ListaItemRequisición.ColumnCount - 1
            If Dgv_ListaItemRequisición.Columns(i).Name = "Pend" Or Dgv_ListaItemRequisición.Columns(i).Name = "Pend x EA" Then
                Columna = i
            End If
        Next
        Select Case TablaCargada
            Case "LISTAORDENCOMPRA", "LISTAREQUISICION"
                Pn_Suministros.Visible = False
                If e.ColumnIndex = Columna Then
                    Try
                        If e.Value > 0 Then
                            Dgv_ListaItemRequisición.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gold
                        Else
                            Dgv_ListaItemRequisición.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                        End If
                    Catch ex As Exception
                        Dgv_ListaItemRequisición.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                    End Try

                End If
        End Select
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        CargarItems()
        Me.Dgv_ListaItemRequisición.ClearSelection()
    End Sub


    Private Sub Lb_Pendientes_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Lb_Pendientes.LinkClicked
        Select Case TablaCargada
            Case "LISTAREQUISICION"
                Dim vista As New DataView(dsCargar1.Tables(0))
                vista.RowFilter = "Pend>0"
                Me.Dgv_ListaItemRequisición.DataSource = vista
            Case "LISTAORDENCOMPRA"
                Dim vista As New DataView(DsOrdenCompra.ListaItemOC)
                vista.RowFilter = "[Pend x EA]>0"
                Me.Dgv_ListaItemRequisición.DataSource = vista
        End Select

        If TablaCargada = "LISTAREQUISICION" Or TablaCargada = "LISTAORDENCOMPRA" Then

        End If
        Me.Dgv_ListaItemRequisición.ClearSelection()
    End Sub


    Private Sub Nbi_BuscarPorSuministro_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BuscarPorSuministro.ItemClick
        Dim FrFiltrarSuminsitros As New Fr_FiltrarProveedor
        FrFiltrarSuminsitros.CargarSuministros()
        FrFiltrarSuminsitros.ShowDialog()
        If FrFiltrarSuminsitros.IDSUMINISTRO = 33 Then
            dsProveedores = bddatos.BusquedaCondiciones(12, "GSM.NOMBREGRUPOSUMINISTROMATERIAL", 1, 1, FrFiltrarSuminsitros.SUMINISTRO, 0, Date.Now, Date.Now, 0, 0)
        Else
            dsProveedores = bddatos.BusquedaCondiciones(12, "GSM.CODIGOGRUPOSUMINISTROMATERIAL", 2, 1, "", FrFiltrarSuminsitros.IDSUMINISTRO, Date.Now, Date.Now, 0, 0)
        End If
        If dsProveedores.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            dsProveedores.Tables.Remove(dsProveedores.Tables(0).TableName) 'borrar la tabla del conteo 
            CargarProveedoresFiltro(dsProveedores)
            TablaCargada = "LISTAPROVEEDORES"
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsProveedores.Clear()
        End If
    End Sub


    Private Sub Nbi_BucarXArticulo_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BucarXArticulo.ItemClick
        Dim FrArticulo As New Articulos.Fr_BuscarArtículo
        FrArticulo.Familia = "-1"
        FrArticulo.Cargar_Tabla("T")
        FrArticulo.ShowDialog()
        dsProveedores = bddatos.BusquedaCondiciones(12, "GSM.CODIGOGRUPOSUMINISTROMATERIAL", 5, 1, "", FrArticulo.IdArtículo, Date.Now, Date.Now, 2, 0)
        If dsProveedores.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            dsProveedores.Tables.Remove(dsProveedores.Tables(0).TableName) 'borrar la tabla del conteo 
            CargarProveedoresFiltro(dsProveedores)
            TablaCargada = "LISTAPROVEEDORES"
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsProveedores.Clear()
        End If
    End Sub


    Private Sub DGV_ListaRequisiciones_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DGV_ListaRequisiciones.KeyDown
        If TablaCargada = "LISTAPROVEEDORES" Then
            If e.KeyCode = Windows.Forms.Keys.F3 Then
                If FuncionesBase.FuncionesBase.ConsultarPermiso(338) Then
                    BuscarProvedor_Cu_Compras()
                End If
            End If
        End If
    End Sub


    Private Sub BuscarProvedor_Cu_Compras()
        Dim FrBuscarProveedor As New OrdenCompra.Fr_BuscarProveedor
        FrBuscarProveedor.Cargar_Tabla()
        FrBuscarProveedor.ShowDialog()
        If Trim(FrBuscarProveedor.Identificacion) = "" Then
            Exit Sub
        Else
            dsProveedores = bddatos.BusquedaCondiciones(12, "PRO.IDENTIFICACION", 1, 1, FrBuscarProveedor.Identificacion, 0, Date.Now, Date.Now, 0, 0)
            If dsProveedores.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
                dsProveedores.Tables.Remove(dsProveedores.Tables(0).TableName) 'borrar la tabla del conteo 
                CargarProveedoresFiltro(dsProveedores)
                TablaCargada = "LISTAPROVEEDORES"
            Else 'si solo trae el conteo es porque se exceden los campos
                MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
                dsProveedores.Clear()
            End If
        End If
    End Sub


    Private Sub Nbi_TrazabilidadRQ_ItemClick_1(sender As System.Object, e As System.EventArgs) Handles Nbi_TrazabilidadRQ.ItemClick
        If TablaCargada = "LISTAREQUISICION" Then
            If DGV_ListaRequisiciones.SelectedRows.Count > 0 Then

                Try
                    Dim Cadena_Consulta As String = _
                           "select * from dbo.TrazabilidadRQ(" + Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value.ToString + " ) order by Fecha"
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Dim da As New SqlDataAdapter(Consulta.CommandText, Conexión.ConnectionString)
                    Dim dt As New DataTable()
                    Conexión.Open()
                    da.Fill(dt)
                    Conexión.Close()
                    'Esto puedes pasarlo a un DataGridView
                    Me.Dgv_ListaItemRequisición.DataSource = dt
                    Me.Dgv_ListaItemRequisición.DefaultCellStyle.BackColor = Color.White
                Catch ex As Exception

                End Try

            End If
        Else
            MsgBox("No está cargada la tabla de Requisiciones")
        End If
    End Sub


    Private Sub Nbi_VerRQ_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_VerRQ.ItemClick
        If TablaCargada = "LISTAREQUISICION" Then
            VerRequisición()
        Else
            MsgBox("No está cargada la tabla de Requisiciones")
        End If
    End Sub


    Private Sub Nbi_VerOC_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_VerOC.ItemClick
        If TablaCargada = "LISTAORDENCOMPRA" Then
            VerOrdenCompra()
        Else
            MsgBox("No está cargada la tabla de Órdenes de Compra")
        End If
    End Sub


    Private Sub MostrarNombreMenu(ByVal sender As Object, ByVal e As EventArgs)
        '  DGV_ListaRequisiciones.SortedColumn.Name = sender.name
        Dim Vista As DataView
        Select Case TablaCargada
            Case "LISTAREQUISICION"
                Vista = New Data.DataView(dsRequisiciones.Tables(0))
                Vista.Sort = sender.name + " ASC" ' descendiente es el Campo DESC
                DGV_ListaRequisiciones.DataSource = Vista
            Case "LISTAORDENCOMPRA"
                Vista = New Data.DataView(dsOrdenesCompra.Tables(0))
                Vista.Sort = sender.name + " ASC" ' descendiente es el Campo DESC
                DGV_ListaRequisiciones.DataSource = Vista
            Case "LISTAPROVEEDORES"
                Vista = New Data.DataView(dsProveedores.Tables(0))
                Vista.Sort = sender.name + " ASC" ' descendiente es el Campo DESC
                DGV_ListaRequisiciones.DataSource = Vista
        End Select
    End Sub


    Private Sub Nbi_BuscarOC_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_BuscarOC.ItemClick
        BuscarOrdenCompra()
    End Sub

    Private Sub BuscarOrdenCompra()
        'filtro nuevo
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos

        campos.Rows.Add("RQ.REQUISICION", "Código Requisición", "1")
        campos.Rows.Add("OC.ORDENCOMPRA", "Código Orden De Compra", "1")
        campos.Rows.Add("OC.IDORDENCOMPRA", "IDORDENCOMPRA", "1")
        campos.Rows.Add("1", "Pendientes por EA", "4") 'CONSULTA ESPECIAL 1
        campos.Rows.Add("2", "Canceladas", "4") 'CONSULTA ESPECIAL 2
        campos.Rows.Add("3", "De la Base", "4") 'CONSULTA ESPECIAL 3
        campos.Rows.Add("4", "Sin EA Con Entrega vencida", "4") 'CONSULTA ESPECIAL 4
        campos.Rows.Add("5", "Sin enviar al proveedor", "4") 'CONSULTA ESPECIAL 5
        campos.Rows.Add("6", "No Aceptada", "4") 'CONSULTA ESPECIAL 6
        campos.Rows.Add("7", "Pendientes de Facturación", "4") 'CONSULTA ESPECIAL 6
        'campos.Rows.Add("1", "Buscar Por Articulo.", "5") 'CONSULTA ESPECIAL 4
        campos.Rows.Add("OC.FECHAREGISTRO", "Fecha Registro", "3")
        campos.Rows.Add("PRO.IDENTIFICACION", "Identificador Proveedor", "2")
        campos.Rows.Add("OC.NOMBRE", "Nombre Proveedor", "1")
        campos.Rows.Add("OC.DIRECCION", "Dirección Proveedor", "1")
        campos.Rows.Add("CIU.NOMBREPOBLACION", "Ciudad Proveedor", "1")
        campos.Rows.Add("OC.TELEFONO", "Teléfono Proveedor", "1")
        campos.Rows.Add("OC.FAX ", "FAX Proveedor", "1")
        campos.Rows.Add("OC.CELULAR ", "Celular Proveedor", "1")
        campos.Rows.Add("MATO.NOMBRETIPOORDENCOMPRA", "Tipo Orden Compra", "1")
        campos.Rows.Add("OC.COTIZACION", "Cotización", "1")
        campos.Rows.Add("OC.FECHAENTREGA", "Fecha estimada de Entrega", "3")
        campos.Rows.Add("MON.NOMBRETIPOMONEDA", "Tipo de Moneda", "1")
        campos.Rows.Add("MAC.CODIGOCENTROCOSTOSSOLIN", "Código Centro Costo SOLIN", "1")
        campos.Rows.Add("MAS.SUBCENTROCOSTOSSOLIN", "Código Subcentro Costo SOLIN", "1")
        campos.Rows.Add("OC.CONDICIONPAGO", "Condición Pago", "1")
        campos.Rows.Add("OC.DESPACHAR_A", "Despachar A", "1")
        campos.Rows.Add("OC.ENCABEZADO", "Encabezado", "1")
        campos.Rows.Add("OC.OBSERVACION", "Observación", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(oc.IDPERSONAREVISA)", "Persona Revisa", "1")
        campos.Rows.Add("OC.FECHAPERSONAREVISA", "Fecha Revisa", "3")
        campos.Rows.Add("dbo.Personanombrecompleto(oc.IDPERSONAAUTORIZA)", "Persona Autoriza", "1")
        campos.Rows.Add("OC.FECHAAUTORIZADA", "Fecha Autoriza", "3")
        campos.Rows.Add("dbo.Personanombrecompleto(oc.IDPERSONAAPRUEBA)", "Persona Aprueba", "1")
        campos.Rows.Add("OC.FECHAAPRUEBA", "Fecha Aprueba", "3")
        campos.Rows.Add("dbo.Personanombrecompleto(oc.IDPERSONAGERENCIA)", "Persona Aprueba Gerencia", "1")
        campos.Rows.Add("OC.FECHAAPRUEBAGERENCIA", "Fecha Aprueba Gerencia", "3")
        campos.Rows.Add("dbo.Personanombrecompleto(oc.IDPERSONACOMPRA)", "Persona Compra", "1")

        frbuscar.campos = campos
        frbuscar.tabla = 11
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsOrdenesCompra = frbuscar.DsBuscar
        If dsOrdenesCompra.Tables.Count > 0 Then
            If dsOrdenesCompra.Tables(0).Rows.Count > 0 Then
                CargarOrdenCompraFiltro(DSbusqueda)
                Select Case frbuscar.busqueda
                    Case "ORDENES CANCELADAS."
                        TablaCargada = "LISTAORDENCOMPRACANCELADAS"
                        Me.Lb_Cargado.Text = "ÓRDENES DE COMPRA CON CANCELACIONES"
                        Lb_Filtro.Text = "Órdenes de Compra Canceladas"
                    Case Else
                        TablaCargada = "LISTAORDENCOMPRA"

                        Me.Lb_Cargado.Text = "ORDENES DE COMPRA"
                        Lb_Filtro.Text = "Órdenes de Compra"
                End Select
            Else
                MsgBox("Ningún Registro Encontrado")
            End If

        End If
        TablaCargada = "LISTAORDENCOMPRA"
        CargarItems()
    End Sub



    Private Sub Nbi_BuscarRQ_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_BuscarRQ.ItemClick
        'filtro nuevo
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("BG.DIRECCION", "Origen", "1")
        campos.Rows.Add("RQ.REQUISICION", "Número Requisición", "1")
        campos.Rows.Add("OT.NROORDENSAP", "Número Orden SAP", "2")
        campos.Rows.Add("1", "Pendientes por atender", "4") 'CONSULTA ESPECIAL 1
        campos.Rows.Add("2", "Pendientes por EA", "4") 'CONSULTA ESPECIAL 2
        campos.Rows.Add("3", "Pen Revisar Bod Principal", "4") 'CONSULTA ESPECIAL 3
        campos.Rows.Add("4", "Sin Comprador", "4") 'CONSULTA ESPECIAL 4
        campos.Rows.Add("5", "Canceladas", "4") 'CONSULTA ESPECIAL 5
        campos.Rows.Add("6", "Por Código Artículo.", "5") 'CONSULTA ESPECIAL 6
        campos.Rows.Add("BG.NOMBRE", "Base", "1")
        campos.Rows.Add("MAC.CODIGOCENTROCOSTOSSOLIN", "Código Centro Costo SOLIN", "1")
        campos.Rows.Add("MAS.SUBCENTROCOSTOSSOLIN", "Código Subcentro Costo SOLIN", "1")
        campos.Rows.Add("", "Prioridad (N = 'Normal' / U = 'Urgente'", "1")
        campos.Rows.Add("AP.NOMBREACTIVIDADPRINCIPAL", "Actividad", "1")
        campos.Rows.Add("RQ.DESTINO", "Destino", "1")
        campos.Rows.Add("RQ.JUSTIFICACION", "Justificación", "1")
        campos.Rows.Add("RQ.FECHAREGISTRO", "Fecha Registro", "3")
        campos.Rows.Add("dbo.Personanombrecompleto(RQ.IDUSUARIOREGISTRA)", "Usuario Registro", "1")
        campos.Rows.Add("RQ.FECHASOLICITUD", "Fecha Solicitud", "3")
        campos.Rows.Add("dbo.Personanombrecompleto(RQ.IDPERSONASOLICITA)", "Usuario Solicita", "1")
        campos.Rows.Add("RQ.AUTORIZADO", "Autorizado (S/N)", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(RQ.IDPERSONAAUTORIZA)", "Usuario Autoriza", "1")
        campos.Rows.Add("RQ.APROBADO", "Aprobado (S/N)", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(RQ.IDPERSONAAPRUEBA)", "Usuario Aprueba", "1")
        campos.Rows.Add("RQ.REVISADO", "Revisado (S/N)", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(RQ.IDPERSONAREVISA)", "Usuario Revisa", "1")
        campos.Rows.Add("RQ.VISTOBUENO", "Visto bueno (S/N)", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(RQ.IDPERSONAVISTOBUENO)", "Usuario Visto bueno", "1")
        campos.Rows.Add("RQ.VBSUBGERENCIA", "Visto bueno Subgerencia (S/N)", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(RQ.IDPERSONAVBSUBGERENCIA)", "Usuario Visto bueno Subgerencia", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(RQ.IDPERSONAASIGNADACOMPRA)", "Usuario Compra", "1")
        campos.Rows.Add("RQ.FECHAASIGNACION", "Fecha asignación de comprador", "3")
        campos.Rows.Add("dbo.Personanombrecompleto(RQ.IDPERSONAASIGNA)", "Usuario Asignó comprador", "1")
        campos.Rows.Add("RQ.IMPRESA", "Impreso (S/N)", "1")
        campos.Rows.Add("dbo.CodigoEquipoCapital(RQ.IDEQUIPO, 1)", "Equipo Asociado", "1")
        campos.Rows.Add("RQ.ENCABEZADO", "Encabezado", "1")
        frbuscar.campos = campos
        frbuscar.tabla = 10
        frbuscar.ShowDialog()
        dsRequisiciones = frbuscar.DsBuscar
        If dsRequisiciones.Tables.Count > 0 Then
            If dsRequisiciones.Tables(0).Rows.Count > 0 Then
                CargarRequisicionFiltro(dsRequisiciones)
                Select Case frbuscar.busqueda
                    Case "RQ CANCELADAS."
                        TablaCargada = "LISTAREQUISICIONCANCELADAS"
                    Case Else
                        TablaCargada = "LISTAREQUISICION"
                End Select
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If

        Exit Sub
    End Sub


    Private Sub CargarFacturas()
        If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            Dim ada As New Facturas.Ds_FacturasTableAdapters.CC_DETALLEDOCUMENTOTableAdapter
            ada.FillXPROVEEDOR(DsFacturas.CC_DETALLEDOCUMENTO, CInt(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("id").Value))
            Me.Dgv_ListaItemRequisición.DataSource = DsFacturas.CC_DETALLEDOCUMENTO
            Me.Lb_CantidadItems.Text = "Facturas Asociadas al proveedor:" + Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(1).Value
        End If
    End Sub


    Private Sub EditarFacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarFacturaToolStripMenuItem.Click
        Dim fr As New Facturas.Fr_RegistrarFactura
        fr.Editando = True
        fr.Tx_Identificación.Text = Trim(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(2).Value)

        fr.DocumentoEditando = Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Id").Value
        fr.Tx_Factura.Text = Trim(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Nro Factura").Value)
        fr.NumFactura = Trim(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Nro Factura").Value)

        If IsDBNull(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Fecha Documento").Value) = False Then
            fr.Dtp_FechaDocumento.Value = Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Fecha Documento").Value
            fr.Dtp_FechaDocumento.Checked = True
        Else
            fr.Dtp_FechaDocumento.Checked = False
        End If
        If IsDBNull(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Fecha Vencimiento").Value) = False Then
            fr.Dtp_FechaVencimiento.Value = Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Fecha Vencimiento").Value
            fr.Dtp_FechaVencimiento.Checked = True
        Else
            fr.Dtp_FechaVencimiento.Checked = False
        End If
        If IsDBNull(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Fecha Radicado Base").Value) = False Then
            fr.Dtp_FechaRadicadoBase.Value = Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Fecha Radicado Base").Value
            fr.Dtp_FechaRadicadoBase.Checked = True
        Else
            fr.Dtp_FechaRadicadoBase.Checked = False
        End If
        If IsDBNull(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Fecha Radicado Principal").Value) = False Then
            fr.Dtp_FechaRadicadoPrincipal.Value = Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Fecha Radicado Principal").Value
            fr.Dtp_FechaRadicadoPrincipal.Checked = True
        Else
            fr.Dtp_FechaRadicadoPrincipal.Checked = False
        End If
        fr.Tx_Observación.Text = Trim(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Obs").Value)
        fr.Tx_Anexos.Text = Trim(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Anexo").Value)
        fr.Tx_ValorFactura.Text = Trim(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Valor").Value)
        fr.Cargar_Proveedor()
        fr.Tx_Identificación.Enabled = False
        fr.ShowDialog()
        CargarFacturas()
    End Sub


    Private Sub EliminarFacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarFacturaToolStripMenuItem.Click
        If MsgBox("¿Desea eliminar la factura?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then

            Dim Comando As New SqlClient.SqlCommand("dbo.GestionarFacturaCompras")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@TIPO", 3)

            Comando.Parameters.AddWithValue("@IDDOCUMENTO", Trim(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value))
            Comando.Parameters.AddWithValue("@NUMERODOCUMENTOANTERIOR", Trim(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Id").Value))

            Comando.Parameters.AddWithValue("@NUMERODOCUMENTO", Trim(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Nro Factura").Value))
            Comando.Parameters.AddWithValue("@IDPROVEEDOR", Trim(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value))
            Comando.Parameters.AddWithValue("@FECHADOCUMENTO", DBNull.Value)
            Comando.Parameters.AddWithValue("@FECHAVENCIMIENTO", DBNull.Value)
            Comando.Parameters.AddWithValue("@FECHARADICADOBASE", DBNull.Value)

            Comando.Parameters.AddWithValue("@FECHARADICADOPRINCIPAL", DBNull.Value)
            Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
            Comando.Parameters.AddWithValue("@VALORDOCUMENTO", DBNull.Value)
            Comando.Parameters.AddWithValue("@OBSERVACION", DBNull.Value)
            Comando.Parameters.AddWithValue("@ANEXO", DBNull.Value)

            Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            Comando.Parameters.Add(msgParam)

            Dim msgParamDOS As New SqlParameter("@IDMENSAJEEA", SqlDbType.NChar, 30)
            msgParamDOS.Direction = ParameterDirection.Output
            Comando.Parameters.Add(msgParamDOS)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)

            Try
                conn.Open()
                Comando.Connection = conn
                Comando.ExecuteNonQuery()
                conn.Close()

                If IsDBNull(Comando.Parameters("@IDMENSAJEEA").Value) = False Then
                    MsgBox("Existe una entrada de almacén relacionada con la factura " + Trim(Comando.Parameters("@IDMENSAJEEA").Value), MsgBoxStyle.Exclamation, "Existe relación")
                Else
                    MsgBox("Se eliminó correctamente la factura", MsgBoxStyle.Exclamation, "Eliminar factura")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            CargarFacturas()
        End If
    End Sub


    Private Sub Nbi_RegistrarFactura_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_RegistrarFactura.ItemClick
        Dim fr As New Facturas.Fr_RegistrarFactura
        If TablaCargada = "LISTAPROVEEDORES" Then
            fr.Tx_Identificación.Text = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("Identificación").Value
            fr.Cargar_Proveedor()
        End If
        fr.ShowDialog()
        CargarFacturas()
    End Sub


    Private Sub Nbi_RelFactura_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_RelFactura.ItemClick
        If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            If TablaCargada = "LISTAORDENCOMPRA" Then
                Index_Registro_Actual = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value.ToString()
                Dim fr As New Facturas.Fr_RelaciónFacturas
                fr.CargarDatos(Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value)
                If fr.NroEntradasAlmacen <> 0 Then
                    fr.ShowDialog()
                End If
                Ubicar_Registro()
            Else
                MsgBox("Se debe cargar ordenes de compra", MsgBoxStyle.Exclamation, "Error")
            End If
        End If
    End Sub


    Private Sub Nbi_VerFacturas_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_VerFacturas.ItemClick
        If TablaCargada = "LISTAPROVEEDORES" Then
            CargarFacturas()
            Me.Pn_ListaPrincipal.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)
            If Me.Dgv_ListaItemRequisición.Rows.Count > 0 Then
                Me.Dgv_ListaItemRequisición.ContextMenuStrip = Me.Cms_Facturas
            Else
                Me.Dgv_ListaItemRequisición.ContextMenuStrip = Nothing
            End If

        Else
            MsgBox("Debe cargar la lista de proveedores y seleccionar el proveedor del cual desea consultar las facturas", MsgBoxStyle.Information, "Cargar Proveedores")
        End If
    End Sub


    Private Sub Nbi_CargarRelaciónFacturas_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_CargarRelaciónFacturas.ItemClick
        CargarListaRemisionesFacturas(0)
    End Sub


    Private Sub Nbi_CargarRelaciónFacturasTodas_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_CargarRelaciónFacturasTodas.ItemClick
        CargarListaRemisionesFacturas(1)
    End Sub



    Private Sub Nbi_CrearRelaciónFacturas_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_CrearRelaciónFacturas.ItemClick
        Dim fr As New Facturas.Fr_RelacionarFacturas
        fr.CargarDatos()
        fr.ShowDialog()
        CargarListaRemisionesFacturas(0)
    End Sub


    Private Sub Nbi_EditarRelaciónFacturas_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_EditarRelaciónFacturas.ItemClick
        EditarRelación()
    End Sub


    Private Sub EditarRelación()
        If TablaCargada = "LISTARELACIONESFACTURAS" Then
            If Me.DGV_ListaRequisiciones.Item("IMPRESA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value = "N" Then
                If VariablesBase.VariablesBase.IdPersona = Me.DGV_ListaRequisiciones.Item("IDPERSONAREGISTRA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value Then
                    Dim fr As New Facturas.Fr_RelacionarFacturas
                    fr.IdRelaciónModificando = Me.DGV_ListaRequisiciones.Rows(DGV_ListaRequisiciones.CurrentRow.Index).Cells("id").Value
                    fr.Dtp_FechaDocumento.Value = Me.DGV_ListaRequisiciones.Rows(DGV_ListaRequisiciones.CurrentRow.Index).Cells("Fecha").Value
                    fr.CargarDatos()
                    fr.ShowDialog()
                    CargarListaRemisionesFacturas(0)
                Else
                    MsgBox("La relación" + Trim(Me.DGV_ListaRequisiciones.Item("No", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value) + " solo puede ser editada por quien la realizó", vbCritical, "Relación")
                End If

            Else
                MsgBox("La relación" + Trim(Me.DGV_ListaRequisiciones.Item("No", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value) + " ya fue impresa y no se puede editar", vbCritical, "Relación")
                Exit Sub
            End If
        Else
            MsgBox("Debe cargar la lista de relaciones de factura", MsgBoxStyle.Information, "Cargar lista")
        End If
    End Sub


    Private Sub Nbi_ImprimirRelación_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_ImprimirRelación.ItemClick
        If TablaCargada = "LISTARELACIONESFACTURAS" Then
            If Me.DGV_ListaRequisiciones.Item("IMPRESA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value = "N" Then
                If Me.Dgv_ListaItemRequisición.RowCount > 0 Then
                    Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                    Dim Array As New ArrayList
                    Array.Add(69)
                    climpresiones.IDRELACIONDOCUMENTO = Me.DGV_ListaRequisiciones.Rows(DGV_ListaRequisiciones.CurrentRow.Index).Cells("id").Value
                    climpresiones.FormatoImprimirMateriales(Array, True, False)
                    MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                Else
                    MsgBox("La relación  " + Trim(Me.DGV_ListaRequisiciones.Item("No", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value) + " no tiene facturas asociadas", vbCritical, "Relación")
                End If
            Else
                MsgBox("La relación  " + Trim(Me.DGV_ListaRequisiciones.Item("No", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value) + " ya fue impresa y no se puede imprimir nuevamente", vbCritical, "Relación")
                Exit Sub
            End If
        Else
            MsgBox("Debe cargar la lista de relaciones de factura", MsgBoxStyle.Information, "Cargar lista")
        End If
    End Sub


    Private Sub Nbi_HabilitarImpresionRelacion_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_HabilitarImpresionRelacion.ItemClick
        If TablaCargada = "LISTARELACIONESFACTURAS" Then
            HabilitarImpresion()
            CargarListaRemisionesFacturas(0)
        Else
            MsgBox("No esta cargada la tabla de relación facturas")
        End If
    End Sub


    Private Sub Nbi_CopiarOC_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_CopiarOC.ItemClick
        formwebcopiar = New Form
        webbrowser = New WebBrowser
        If DGV_ListaRequisiciones.Rows.Count = 0 Then
            MsgBox("no hay datos cargados")
            Return
        End If
        If TablaCargada <> "LISTAORDENCOMPRA" Then
            MsgBox("Debe cargar la tabla de Órdenes de Compra primero")
            Return
        End If
        Dim id As Integer = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("id").Value
        Dim tipo As String = "OC"
        Dim texto As String = FuncionesBase.FuncionesBase.DatosRequisicionHTML(id, tipo)
        RemoveHandler formwebcopiar.Shown, AddressOf form_mostrar
        RemoveHandler formwebcopiar.Load, AddressOf formcargar
        webbrowser.DocumentText = texto
        formwebcopiar.Controls.Add(webbrowser)
        AddHandler formwebcopiar.Shown, AddressOf form_mostrar
        AddHandler formwebcopiar.Load, AddressOf formcargar
        formwebcopiar.Show()
    End Sub


    Private Sub Nbi_CopiarRQ_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_CopiarRQ.ItemClick
        formwebcopiar = New Form
        webbrowser = New WebBrowser
        If DGV_ListaRequisiciones.Rows.Count = 0 Then
            MsgBox("no hay datos cargados")
            Return
        End If
        If TablaCargada <> "LISTAREQUISICION" Then
            MsgBox("Debe cargar la tabla de Requisiciones primero")
            Return
        End If
        Dim id As Integer = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("id").Value
        Dim tipo As String = "RQ"
        Dim texto As String = FuncionesBase.FuncionesBase.DatosRequisicionHTML(id, tipo)
        RemoveHandler formwebcopiar.Shown, AddressOf form_mostrar
        RemoveHandler formwebcopiar.Load, AddressOf formcargar
        webbrowser.DocumentText = texto
        formwebcopiar.Controls.Add(webbrowser)
        AddHandler formwebcopiar.Shown, AddressOf form_mostrar
        AddHandler formwebcopiar.Load, AddressOf formcargar
        formwebcopiar.Show()
    End Sub


    Private Sub form_mostrar(sender As System.Object, e As System.EventArgs)
        webbrowser.Document.ExecCommand("SelectAll", True, Nothing)
        webbrowser.Document.ExecCommand("Copy", True, Nothing)
        formwebcopiar.Close()
        MsgBox("Datos Copiados al Portapapeles", MsgBoxStyle.OkOnly, "Datos Copiados")
    End Sub


    Private Sub formcargar(sender As System.Object, e As System.EventArgs)
        webbrowser.Document.ExecCommand("SelectAll", True, Nothing)
        webbrowser.Document.ExecCommand("Copy", True, Nothing)
    End Sub


    Private Sub Nbi_BuscarXarticuloRQ_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_BuscarXarticuloRQ.ItemClick
        Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
        FrBuscarArtículo.Familia = "-1"
        FrBuscarArtículo._Tipo = "T"
        FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda por familia, falta implementar

        FrBuscarArtículo.ShowDialog()
        If Trim(FrBuscarArtículo.IdArtículo) = 0 Then
            Exit Sub
        End If

        dsRequisiciones = bddatos.BusquedaCondiciones(10, 6, 5, 1, "", FrBuscarArtículo.IdArtículo, Date.Now, Date.Now, 6, 0)
        If dsRequisiciones.Tables.Count > 1 Then 'si el procedimiento trae más de una tabla es decir la tabla de conteo y la tabla de datos
            dsRequisiciones.Tables.Remove(dsRequisiciones.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("Error al cargar los registros.", MsgBoxStyle.Critical, "Error")
            dsRequisiciones.Clear()
        End If
        TablaCargada = "LISTAREQUISICION"
        CargarRequisicionFiltro(dsRequisiciones)
    End Sub


    Private Sub Nbi_BucarProveedor_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_BucarProveedor.ItemClick
        'filtro nuevo, proveedor
        'abrir formulario        
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("PRO.IDENTIFICACION", "Identificación", "1")
        campos.Rows.Add("PRO.NOMBRE", "Nombre Proveedor", "1")
        campos.Rows.Add("PRO.NOMENCLATURA", "Nomenclatura Proveedor", "1")
        campos.Rows.Add("1", "Todos los Proveedores", "4") 'CONSULTA ESPECIAL 1
        campos.Rows.Add("PRO.DIRECCION", "Dirección Proveedor", "1")
        campos.Rows.Add("PRO.EMAIL", "Correo Proveedor", "1")
        campos.Rows.Add("PRO.CELULAR", "Celular Proveedor", "1")
        campos.Rows.Add("PRO.NOMBREREPRESENTANTEVENTA", "Representante de Ventas", "1")
        campos.Rows.Add("PRO.TELEFONOREPRESENTANTEVENTA", "Tel. Rep. Ventas", "1")
        campos.Rows.Add("GSM.NOMBREGRUPOSUMINISTROMATERIAL", "Buscar por Suministro.", "1")
        campos.Rows.Add("2", "Buscar por ID Artículo", "5") 'CONSULTA ESPECIAL 2
        campos.Rows.Add("3", "Proveedores Últimos 6 Meses", "4") 'CONSULTA ESPECIAL 3
        campos.Rows.Add("4", "Proveedores Activos", "4") 'CONSULTA ESPECIAL 3

        frbuscar.campos = campos
        frbuscar.tabla = 12
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsProveedores = DSbusqueda
        If dsProveedores.Tables.Count > 0 Then
            If dsProveedores.Tables(0).Rows.Count > 0 Then
                CargarProveedoresFiltro(DSbusqueda)
                TablaCargada = "LISTAPROVEEDORES"

            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub




    Private Sub Nbi_BucarXCiudad_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BucarXCiudad.ItemClick
        Dim CodigoCiudad As String = "SIN DATO"
        Dim FrCiudad As New FormulariosClasesBase.Fr_Buscar_Ciudad
        FrCiudad.ShowDialog()
        If FrCiudad.DialogResult = DialogResult.OK Then
            CodigoCiudad = FrCiudad.ComboBox_Municipio.SelectedValue

            dsProveedores = bddatos.BusquedaCondiciones(12, "CODIGOCIUDADDIRECCION", 6, 1, CodigoCiudad, 1, Date.Now, Date.Now, 3, 0)
            If dsProveedores.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
                dsProveedores.Tables.Remove(dsProveedores.Tables(0).TableName) 'borrar la tabla del conteo 
                CargarProveedoresFiltro(dsProveedores)
                TablaCargada = "LISTAPROVEEDORES"
            Else 'si solo trae el conteo es porque se exceden los campos
                MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
                dsProveedores.Clear()
            End If
        End If
    End Sub


    Private Sub Nbi_CambiarTipoStock_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CambiarTipoStock.ItemClick
        If TablaCargada = "LISTAREQUISICION" Then
            If DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
                Dim tipoStock As String
                If DGV_ListaRequisiciones.SelectedRows(0).Cells("Stock").Value = "S" Then
                    tipoStock = "No Stock"
                Else
                    tipoStock = "Stock"
                End If

                If MessageBox.Show("¿Desea cambiar el tipo de Stock de Bodega de la Requisición " +
                          DGV_ListaRequisiciones.SelectedRows(0).Cells("Requisición").Value +
                          " a «" + tipoStock + "»?", "CAMBIAR TIPO STOCK DE BODEGA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    Dim dt_Resultado As New DataTable
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("dbo.CambiarTipoStock", conexion)
                    comando.CommandType = CommandType.StoredProcedure
                    comando.Parameters.AddWithValue("@IDREQUISICION", Trim(DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value))
                    Dim mensajeParam As New SqlParameter("@MENSAJE", SqlDbType.Bit)
                    mensajeParam.Direction = ParameterDirection.Output
                    comando.Parameters.Add(mensajeParam)
                    Dim dtResultado As New DataTable
                    Try
                        conexion.Open()
                        comando.ExecuteNonQuery()
                    Catch ex As Exception

                    Finally
                        conexion.Close()
                    End Try

                    Dim resultadoProcedimiento As Boolean = comando.Parameters("@MENSAJE").Value

                    If resultadoProcedimiento = True Then
                        MsgBox("Cambio realizado satisfactoriamente.", MsgBoxStyle.Information, "CAMBIAR TIPO STOCK DE BODEGA")
                        CargarTablaxDefectoRequisiciones()
                    Else
                        MsgBox("No se realizó el cambio porque la requisición " +
                          DGV_ListaRequisiciones.SelectedRows(0).Cells("Requisición").Value +
                          " tiene movimientos asociados.", MsgBoxStyle.Exclamation, "CAMBIAR TIPO STOCK DE BODEGA")
                    End If
                Else
                    'No realizar cambio.
                End If
            Else
                'No hay RQs seleccionadas.
            End If
        Else
            MsgBox("No esta cargada la tabla de Requisiciones.")
        End If
    End Sub


    Private Sub Nbi_EnviarCorreosOCSinFacturaAsociada_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EnviarCorreosOCSinFacturaAsociada.ItemClick
        If MsgBox("¿Desea notificar a los compradores de las Órdenes de Compra pendientes por asociar Factura?", MsgBoxStyle.YesNo, "Enviar correos OC sin factura registrada") = MsgBoxResult.Yes Then
            EnviarCorreosOrdenesDeCompraSinFacturaAsociada()
        End If
    End Sub


    Private Sub EnviarCorreosOrdenesDeCompraSinFacturaAsociada()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim TablaUsuarioPendientes As New DataTable("USUARIOSPENDIENTES")
        Dim TablaDocumentosPendientes As New DataTable("OCPENDIENTEXREGISTRARFACTURA")
        Dim Conexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim Consulta As New SqlClient.SqlCommand()
        Consulta.Connection = Conexion
        Consulta.CommandText = "SELECT * FROM dbo.OCPendientexRegistrarFactura() ORDER BY COMPRADOR, ORDENCOMPRA"
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        TablaDocumentosPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador.Fill(TablaDocumentosPendientes)
        Consulta.Connection.Close()
        Consulta.CommandText = "SELECT DISTINCT IDPERSONACOMPRA FROM dbo.OCPendientexRegistrarFactura() WHERE CORREO <> '' "
        Dim Adaptador1 As New SqlClient.SqlDataAdapter(Consulta)
        TablaUsuarioPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador1.Fill(TablaUsuarioPendientes)
        Consulta.Connection.Close()
        Dim correos As New DataSet
        correos.Tables.Add(TablaDocumentosPendientes)
        correos.Tables.Add(TablaUsuarioPendientes)
        Windows.Forms.Cursor.Current = Cursors.Default
        Bw_correosOCsPendientesRegistroFactura.RunWorkerAsync(correos)
    End Sub


    Private Sub Bw_correosOCsPendientesRegistroFactura_DoWork(sender As Object, e As DoWorkEventArgs) Handles Bw_correosOCsPendientesRegistroFactura.DoWork
        Dim correos As DataSet = e.Argument
        Dim TablaUsuarioPendientes As DataTable = (correos.Tables("USUARIOSPENDIENTES"))
        Dim TablaDocumentosPendientes As DataTable = (correos.Tables("OCPENDIENTEXREGISTRARFACTURA"))
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
            filasDocumentosPendientes = TablaDocumentosPendientes.Select("IDPERSONACOMPRA = " & FilaUsuario("IDPERSONACOMPRA").ToString)
            Dim filasDocumentosPendientesReferencia As DataRow
            filasDocumentosPendientesReferencia = filasDocumentosPendientes(0)
            cuerpo.AppendLine("<center>")
            cuerpo.AppendLine("<div style='padding: 10px; max-width: 1000px;'>")
            cuerpo.AppendLine("<table style='width: 100%;'>")
            cuerpo.AppendLine("    <tr style='border: 1px solid;'>")
            cuerpo.AppendLine("        <td style='width: 170px; text-align: center; padding: 10px;'>")
            cuerpo.AppendLine("            <img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/>")
            cuerpo.AppendLine("        </td>")
            cuerpo.AppendLine("        <td>ÓRDENES DE COMPRA PENDIENTES POR REGISTRAR FACTURA</td>")
            cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br/>" & Date.Now.ToString & "</td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("</table>")
            cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td><b>Comprador:</b></td>")
            cuerpo.AppendLine("        <td colspan='7'>" & filasDocumentosPendientesReferencia("COMPRADOR") & "</td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td colspan='8' style='text-align: center; background-color: silver;'><b>PENDIENTES POR REGISTRAR FACTURA</b></td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Orden de Compra</td>")
            cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Bodega Requisición</td>")
            cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Descripción Encabezado</td>")
            cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Valor de la OC</td>")
            'cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Cancelación</td>")
            cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Requisición</td>")
            cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>NIT del Proveedor</td>")
            cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Nombre del Proveedor</td>")
            cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Fecha de elaboración</td>")
            cuerpo.AppendLine("    </tr>")
            For nrodocumentopendiente As Integer = 0 To filasDocumentosPendientes.Count - 1
                Dim filaDocumentosPendientes As DataRow
                filaDocumentosPendientes = filasDocumentosPendientes(nrodocumentopendiente)
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("ORDENCOMPRA") & "</td>")
                cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("BODEGARQ") & "</td>")
                cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("ENCABEZADO") & "</td>")
                cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("MONEDA") & " " & String.Format("{0:N2}", filaDocumentosPendientes("VALOROC")) & "</td>")
                'cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("CANCELADA") & "</td>")
                cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("REQUISICION") & "</td>")
                cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("NIT") & "</td>")
                cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("PROVEEDOR") & "</td>")
                cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("FECHAREGISTRO") & "</td>")
                cuerpo.AppendLine("    </tr>")
            Next
            cuerpo.AppendLine("</table>")
            cuerpo.AppendLine("<hr style='border-style: groove;'/>")
            cuerpo.AppendLine("<p style='text-align: left'>ENVÍO DE RELACIÓN DE ÓRDENES DE COMPRA PENDIENTES POR REGISTRAR FACTURA.<br/>ESTE CORREO FUE ENVIADO AUTOMATICAMENTE, POR FAVOR NO CONTESTAR.</p>")
            FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Órdenes de compra pendientes por registrar factura, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoInformacionMateriales, filasDocumentosPendientesReferencia("Correo"), Nothing, False, "")
            cuerpo.Clear()
            ni.BalloonTipText = i & " de " & TablaUsuarioPendientes.Rows.Count - 1 & " correos enviados."
            ni.BalloonTipIcon = ToolTipIcon.Info
            ni.ShowBalloonTip(500)
        Next
        ni.BalloonTipText = "Correos enviados exitosamente."
        ni.BalloonTipIcon = ToolTipIcon.Info
        ni.ShowBalloonTip(2000)
    End Sub

#Region "Solicitud de Maquinaria y Equipo"
    Private Sub Nbi_CargarSolicitud_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarSolicitud.ItemClick
        CargarSolicitudesMaquinaria()
        CargarListaxSeleccion()
    End Sub




    Private Sub Nbi_CrearSolicitud_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearSolicitud.ItemClick
        GestionarSolicitudMaquinaria(Fr_SolicitudMaquinaria.TipoEdicion.Crear)
    End Sub


    Private Sub Nbi_VerSolicitud_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerSolicitud.ItemClick
        If DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            Dim tienePermisoVer As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso("579") Then
                'Permiso de visualización para todas las Solicitudes de Maquinaria de Ismocol S.A.
                tienePermisoVer = True
            Else
                If FuncionesBase.FuncionesBase.ConsultarPermiso("578") Then
                    If DGV_ListaRequisiciones.SelectedRows(0).Cells("IDBODEGA").Value = VariablesBase.VariablesBase.IdBodegaActual Then
                        'Permiso de visualización para las Solicitudes de Maquinaria de la Bodega actual.
                        tienePermisoVer = True
                    Else
                        'Permiso de visualización para las Solicitudes de Maquinaria propias.
                    End If
                Else
                    'Permiso de visualización para las Solicitudes de Maquinaria propias.
                End If
                If FuncionesBase.FuncionesBase.ConsultarPermiso("577") Then
                    If DGV_ListaRequisiciones.SelectedRows(0).Cells("IDUSUARIOREGISTRO").Value = VariablesBase.VariablesBase.IdPersona Then
                        'Permiso de visualización para las Solicitudes de Maquinaria propias.
                        tienePermisoVer = True
                    End If
                End If
            End If
            If tienePermisoVer Then
                GestionarSolicitudMaquinaria(Fr_SolicitudMaquinaria.TipoEdicion.Ver, DGV_ListaRequisiciones.SelectedRows(0).Cells("IDSOLICITUDMAQUINARIA").Value)
            Else
                MsgBox("No cuenta con privilegios suficientes para realizar esta acción.", MsgBoxStyle.Exclamation, "Ver Solicitud de Maquinaria y Equipo")
            End If
        End If
    End Sub


    Private Sub Nbi_EditarSolicitud_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarSolicitud.ItemClick
        If DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            Dim tienePermisoEdicion As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso("582") Then
                'Permiso de edición para todas las Solicitudes de Maquinaria de Ismocol S.A.
                tienePermisoEdicion = True
            Else
                If FuncionesBase.FuncionesBase.ConsultarPermiso("581") Then
                    If DGV_ListaRequisiciones.SelectedRows(0).Cells("IDBODEGA").Value = VariablesBase.VariablesBase.IdBodegaActual Then
                        'Permiso de edición para las Solicitudes de Maquinaria de la Bodega actual.
                        tienePermisoEdicion = True
                    Else
                        'Permiso de edición para las Solicitudes de Maquinaria propias.
                    End If
                Else
                    'Permiso de edición para las Solicitudes de Maquinaria propias.
                End If
                If FuncionesBase.FuncionesBase.ConsultarPermiso("580") Then
                    If DGV_ListaRequisiciones.SelectedRows(0).Cells("IDUSUARIOREGISTRO").Value = VariablesBase.VariablesBase.IdPersona Then
                        'Permiso de edición para las Solicitudes de Maquinaria propias.
                        tienePermisoEdicion = True
                    End If
                End If
            End If
            If tienePermisoEdicion Then
                GestionarSolicitudMaquinaria(Fr_SolicitudMaquinaria.TipoEdicion.Editar, DGV_ListaRequisiciones.SelectedRows(0).Cells("IDSOLICITUDMAQUINARIA").Value)
            Else
                MsgBox("No cuenta con privilegios suficientes para realizar esta acción.", MsgBoxStyle.Exclamation, "Editar Solicitud de Maquinaria y Equipo")
            End If
        End If
    End Sub


    Private Sub GestionarSolicitudMaquinaria(ByVal edicion As Fr_SolicitudMaquinaria.TipoEdicion, Optional ByVal idSolicitudMaquinaria As Integer = -1)
        Using frSolicitudMaquinaria As New Fr_SolicitudMaquinaria
            frSolicitudMaquinaria.Edicion = edicion
            frSolicitudMaquinaria.IdSolicitudMaquinaria = idSolicitudMaquinaria
            frSolicitudMaquinaria.ShowDialog()
        End Using
    End Sub


    Private Sub Nbi_ImprimirSolicitud_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirSolicitud.ItemClick
        If DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            IMPRIMIR()
        End If
    End Sub


    Private Sub Nbi_BuscarSolicitud_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarSolicitud.ItemClick
        BuscarSolicitudesMaquinaria()
    End Sub


    Private Sub BuscarSolicitudesMaquinaria()

    End Sub


    Private Sub Nbi_ConvertirA_Rq_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ConvertirA_Rq.ItemClick
        If DGV_ListaRequisiciones.SelectedRows.Count > 0 Then

        End If
    End Sub
#End Region 'Solicitud de Maquinaria y Equipo


    Private Sub Nbi_PendienteRQxUsers_ItemClick(sender As Object, e As EventArgs) Handles Nbi_PendienteRQxUsers.ItemClick
        dsRequisiciones = bddatos.BusquedaCondiciones(10, 1, 4, 1, "", 0, Date.Now, Date.Now, 7, 1000)
        If dsRequisiciones.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
            dsRequisiciones.Tables.Remove(dsRequisiciones.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
            dsRequisiciones.Clear()
        End If
        TablaCargada = "LISTAREQUISICION"
        CargarRequisicionFiltro(dsRequisiciones)
    End Sub

    Private Sub Nb_PendienteOCxEAxUser_ItemClick(sender As Object, e As EventArgs) Handles Nb_PendienteOCxEAxUser.ItemClick
        Try
            dsOrdenesCompra = bddatos.BusquedaCondiciones(11, 1, 4, 1, "", 0, Date.Now, Date.Now, 8, 1000)
            If dsOrdenesCompra.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
                dsOrdenesCompra.Tables.Remove(dsOrdenesCompra.Tables(0).TableName) 'borrar la tabla del conteo 
            Else 'si solo trae el conteo es porque se exceden los campos
                MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
                dsOrdenesCompra.Clear()
            End If
            TablaCargada = "LISTAORDENCOMPRA"
            CargarOrdenCompraFiltro(dsOrdenesCompra)

            If Tipo_Tabla_Cargada_OC = 8 Then
                Me.Lb_Cargado.Text = "ORDENES DE COMPRA CON CANCELACIONES"
                Lb_Filtro.Text = "Órdenes de Compra Canceladas"
            Else
                Me.Lb_Cargado.Text = "ORDENES DE COMPRA"
                Lb_Filtro.Text = "Órdenes de Compra"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Cu_Compras_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, Dgv_ListaItemRequisición.KeyDown, DGV_ListaRequisiciones.KeyDown, Dgv_Suministros.KeyDown, Nbc_Compras.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                FuncionesBase.FuncionesBase.AbrirAyudaOnline("/Inicio.aspx?MODULO=Materiales")
            Case Keys.F2
                If Not listadoBodegasVirtualesCMC.Contains(VariablesBase.VariablesBase.IdBodegaActual) Then
                    CrearRequisición()
                End If
            Case Keys.F3
                BuscarOrdenCompra()
            Case Keys.F4
                Select Case TablaCargada
                    Case "LISTAREQUISICION"
                        CargarTablaxDefectoRequisiciones()
                    Case "LISTAORDENCOMPRA"
                        CargarOCxDefecto()
                    Case "LISTAPROVEEDORES"
                        CargarProveedoresXdefecto()
                End Select
            Case Keys.F5

            Case Keys.F6
                ExportarDatosExcel(DGV_ListaRequisiciones)
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
            With .Range(.Cells(1, 1), .Cells(1, DGV_ListaRequisiciones.Columns.Count)).Font
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

    Private Sub Cu_Compras_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Pn_ListaPrincipal.Height = Me.Height * 0.7
            Me.SplitContainer1.SplitterDistance = Me.Width * 0.75
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Nbi_CopiarRQxCotizar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CopiarRQxCotizar.ItemClick
        formwebcopiar = New Form
        webbrowser = New WebBrowser
        If DGV_ListaRequisiciones.Rows.Count = 0 Then
            MsgBox("no hay datos cargados")
            Return
        End If
        If TablaCargada <> "LISTAREQUISICION" Then
            MsgBox("Debe cargar la tabla de Requisiciones primero")
            Return
        End If
        Dim id As Integer = Me.DGV_ListaRequisiciones.SelectedRows(0).Cells("id").Value
        Dim tipo As String = "RQ"
        Dim texto As String = FuncionesBase.FuncionesBase.DatosRequisicionHTMLCotizar(id, tipo)
        RemoveHandler formwebcopiar.Shown, AddressOf form_mostrar
        RemoveHandler formwebcopiar.Load, AddressOf formcargar
        webbrowser.DocumentText = texto
        formwebcopiar.Controls.Add(webbrowser)
        AddHandler formwebcopiar.Shown, AddressOf form_mostrar
        AddHandler formwebcopiar.Load, AddressOf formcargar
        formwebcopiar.Show()
    End Sub

    Private Sub Nbi_VistoBuenoGerencia_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VistoBuenoGerencia.ItemClick
        Tipo = "VbG"
        If DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            Select Case DGV_ListaRequisiciones.SelectedRows(0).Cells("VbSg").Value 'Verificar que no este terminado o suspendido.
                Case "S"
                    MessageBox.Show("Este requisición ya tiene visto bueno de gerencia")
                    Exit Sub
                Case Else
                    If MessageBox.Show("Se dara el visto bueno de Gerencia a la Requisición " & DGV_ListaRequisiciones.SelectedRows(0).Cells("Requisición").Value & "." & Environment.NewLine & "¿Desea continuar?", "Visto Bueno Gerencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                        VistoBuenoGerencia(DGV_ListaRequisiciones.SelectedRows(0).Cells("Id").Value)
                        DGV_ListaRequisiciones.Item("VbSg", DGV_ListaRequisiciones.CurrentCell.RowIndex).Value = "S"
                        Dim IdRequisicion As Integer
                        IdRequisicion = DGV_ListaRequisiciones.SelectedRows(0).Cells("Id").Value
                        Try
                            CorreoAElaboroRequisicion(IdRequisicion)
                        Catch ex As Exception
                            MsgBox("No se envió notificación al correo, Verificar correo de la persona quien realizo la requisición", MsgBoxStyle.Information, "Requisición")
                        End Try
                    End If
            End Select
        Else
            MessageBox.Show("Seleccione una requisición para realizar la operación.", "Ningúna requisición seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Friend Sub VistoBuenoGerencia(idRQ As Long)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.VistoBuenoGerencia", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDREQUISICION", idRQ)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error de conexión. No se pudo realizar la operación.", "Cambiar Visto Bueno Gerencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub


    'Private Sub MarcarSubidoServidor(idRequisicion As Integer)
    '    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
    '    Dim comando As New SqlCommand("dbo.MarcarSubidoServidor_Requisicion", conexion)
    '    comando.CommandType = CommandType.StoredProcedure
    '    comando.Parameters.AddWithValue("@IDREQUISICION", idRequisicion)
    '    comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
    '    Try
    '        conexion.Open()
    '        comando.ExecuteNonQuery()
    '        conexion.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        conexion.Close()
    '    End Try
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

    Private Sub CorreoAElaboroRequisicion(ByVal IDREQUISICION As Integer)
        Dim Cadena_Consulta As String = ""
        Dim Dt_Requisicion As DataTable
        Dim FilaRequisicion As DataRow
        Dim textoContenido As New System.Text.StringBuilder
        Dim correoDestino As String = ""
        Dim asunto As String = ""
        Dim ContadorItems As Integer = 0
        Dim FilaEA As DataRow

        Cadena_Consulta += "SELECT RQ.REQUISICION, RTRIM(B.NOMBRE) AS BODEGA,IRQ.IDITEMREQUISICION AS IDITEMREQUISICION, TU.ABREVIATURA AS ABREVIATURA, A.IDARTICULO AS IDARTICULO, A.NOMBREDESCRIPTIVO AS DESCRIPCION, IRQ.CANTIDADSOLICITADA AS CANTIDAD,  "
        Cadena_Consulta += "RTRIM(U.CORREOELECTRONICOCORPORTATIVO) AS CORREO, RTRIM(U1.CORREOELECTRONICOCORPORTATIVO) AS CORREOGRQ, RQ.PERSONASOLICITA, RQ.PERSONAAUTORIZA,RQ.PERSONAREVISA,RQ.PERSONAAPRUEBA, RQ.FECHAASIGNAVBG, RQ.PERSONAASIGNAVBG, G.NOMBREGERENCIA  "
        Cadena_Consulta += "FROM dbo.ImpresionRequisicion(" + CStr(IDREQUISICION) + ") RQ,ITEMREQUISICION IRQ , USUARIO U, BODEGA B, ARTICULO A, USUARIO U1,USUARIO U2, MA_TIPOUNIDAD TU, MA_CENTROCOSTOSSOLIN CC,  SC_GERENCIA G "
        Cadena_Consulta += "WHERE IRQ.IDREQUISICION = " + CStr(IDREQUISICION) + " "
        Cadena_Consulta += "AND U.IDPERSONA = RQ.IDUSUARIOREGISTRA  AND U1.IDPERSONA= RQ.IDPERSONAASIGNADACOMPRA AND B.IDBODEGA = RQ.IDBODEGA AND A.IDARTICULO = IRQ.IDARTICULO AND TU.CODIGOTIPOUNIDAD = A.CODIGOTIPOUNIDAD AND RQ.IDCENTROCOSTO = CC.IDCENTROCOSTO AND  G.IDGERENCIA = CC.IDGERENCIA   "
        Cadena_Consulta += "GROUP BY RQ.REQUISICION,B.NOMBRE,IRQ.IDITEMREQUISICION,TU.ABREVIATURA,A.IDARTICULO,A.NOMBREDESCRIPTIVO,IRQ.CANTIDADSOLICITADA,U.CORREOELECTRONICOCORPORTATIVO, U1.CORREOELECTRONICOCORPORTATIVO, RQ.PERSONASOLICITA,RQ.PERSONAAUTORIZA,RQ.PERSONAREVISA,RQ.PERSONAAPRUEBA,RQ.FECHAASIGNAVBG,RQ.PERSONAASIGNAVBG,G.NOMBREGERENCIA   "


        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Dt_Requisicion = New DataTable
        Adaptador.FillSchema(Dt_Requisicion, SchemaType.Source)
        Adaptador.Fill(Dt_Requisicion)
        Consulta.Connection.Close()
        FilaRequisicion = Dt_Requisicion.Rows(0)

        Dim mail As New MailMessage
        If VariablesBase.VariablesBase.NombreBaseDatos = "ISMOCOLPRODUCCION" Then

            correoDestino = Dt_Requisicion.Rows(0)("CORREO").ToString()

            'If FuncionesBase.FuncionesBase.EsBodegaPrincipal(Dt_EntradaAlmacen.Rows(0)("IDBODEGA").ToString()) = True Then
            '    mail.Bcc.Add("compras7@ismocol.com")
            'Else
            '    mail.Bcc.Add("compras5@ismocol.com")
            'End If

            mail.Bcc.Add("compras@ismocol.com")
            If CStr(Trim(FilaRequisicion("CORREOGRQ"))) <> "" Then
                'Correo destino Compra Bodega
                mail.Bcc.Add(New MailAddress(CStr(Trim(FilaRequisicion("CORREOGRQ")))))
            End If

        Else
            correoDestino = "desarrolloaplicaciones@ismocol.com"
        End If
        Select Case Tipo
            Case "VbG"
                asunto = "Se asignó el visto bueno de gerencia de la requisición  " + CStr(Trim(FilaRequisicion("REQUISICION")))
            Case "SSVbG"
                asunto = "Se subió el PDF del visto bueno de gerencia de la requisición  " + CStr(Trim(FilaRequisicion("REQUISICION")))
        End Select

        Select Case Tipo
            Case "VbG"
                textoContenido.AppendLine("           <tr align='left'> <br/><b>Persona Asignó Visto Bueno de Gerencia </b>" + CStr(Trim(FilaRequisicion("PERSONAASIGNAVBG"))) + "</tr>")
                textoContenido.AppendLine("            <br/><b>Fecha Visto Bueno Gerencia </b>" + CStr(Trim(FilaRequisicion("FECHAASIGNAVBG"))) + "")
            Case "SSVbG"
                textoContenido.AppendLine("           <tr align='left'> <br/><b>Persona que Subió PDF de Visto Bueno de Gerencia </b>" + CStr(Trim(FilaRequisicion("PERSONAASIGNAVBG"))) + "</tr>")
                textoContenido.AppendLine("            <br/><b>Fecha Subió PDF Visto Bueno Gerencia </b>" + CStr(Trim(FilaRequisicion("FECHAASIGNAVBG"))) + "")
        End Select

        textoContenido.AppendLine("<div style='padding:10px; max-width:1000px;'>")
        textoContenido.AppendLine("    <table style='width:100%;' border='1'>")
        textoContenido.AppendLine("        <tr style='border:1px solid; text-align:center;'>")
        textoContenido.AppendLine("            <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='100px'/></td>")
        textoContenido.AppendLine("            <td><center><b>SISTEMA DE MATERIALES</b></center></td>")
        textoContenido.AppendLine("            <td><center><b>Requisición</b> " + CStr(Trim(FilaRequisicion("REQUISICION"))) + "</center></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("    </table>")

        textoContenido.AppendLine("    <p>")
        textoContenido.AppendLine("    <table border='1' style='width:100%;'>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("        <td style ='width:100%;'><tr align='left'> <b>Gerencia de la Requisición </b>" + CStr(Trim(FilaRequisicion("NOMBREGERENCIA"))) + "</tr>")
        textoContenido.AppendLine("        </tr>")

        textoContenido.AppendLine("    </table>")
        textoContenido.AppendLine("    </p>")

        textoContenido.AppendLine("    <table border= '1'>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td width='40'><center><b>ÍTEM</b></center></td>")
        textoContenido.AppendLine("            <td width='50'><center><b>UNIDAD</b></center></td>")
        textoContenido.AppendLine("            <td width='50'><center><b>CÓDIGO</b></center></td>")
        textoContenido.AppendLine("            <td width='760'><center><b>DESCRIPCIÓN</b></center></td>")
        textoContenido.AppendLine("            <td width='50'><center><b>CANTIDAD</b></center></td>")
        textoContenido.AppendLine("        </tr>")
        For i = ContadorItems To Dt_Requisicion.Rows.Count - 1
            FilaEA = Dt_Requisicion.Rows(i)

            textoContenido.AppendLine("        <tr>")
            textoContenido.AppendLine("            <td>" + CStr(FilaEA("IDITEMREQUISICION")) + "</td>")
            textoContenido.AppendLine("            <td>" + CStr(FilaEA("ABREVIATURA")) + "</td>")
            textoContenido.AppendLine("            <td>" + CStr(FilaEA("IDARTICULO")) + "</td>")
            textoContenido.AppendLine("            <td>" + CStr(FilaEA("DESCRIPCION")) + "</td>")
            textoContenido.AppendLine("            <td>" + CStr(FilaEA("CANTIDAD")) + "</td>")
            textoContenido.AppendLine("        </tr>")
            ContadorItems = ContadorItems + 1
        Next
        textoContenido.AppendLine("    </table>")
        textoContenido.AppendLine("    <p>")
        textoContenido.AppendLine("    <table border='1' style='width:100%;'>")


        textoContenido.AppendLine("    </table>")
        textoContenido.AppendLine("    <table style='width:100%;' border='1'>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><center><b>PERSONA SOLICITA</b></center></td>")
        textoContenido.AppendLine("            <td><center><b>PERSONA AUTORIZA</b></center></td>")
        textoContenido.AppendLine("            <td><center><b>PERSONA REVISA</b></center></td>")
        textoContenido.AppendLine("            <td><center><b>PERSONA APRUEBA</b></center></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("        <tr>")
        textoContenido.AppendLine("            <td><center>" + Trim(FilaRequisicion("PERSONASOLICITA")) + "</center></td>")
        textoContenido.AppendLine("            <td><center>" + Trim(FilaRequisicion("PERSONAAUTORIZA")) + "</center></td>")
        textoContenido.AppendLine("            <td><center>" + Trim(FilaRequisicion("PERSONAREVISA")) + "</center></td>")
        textoContenido.AppendLine("            <td><center>" + Trim(FilaRequisicion("PERSONAAPRUEBA")) + "</center></td>")
        textoContenido.AppendLine("        </tr>")
        textoContenido.AppendLine("    </table>")
        textoContenido.AppendLine("    </p>")

        textoContenido.AppendLine("    <tr>")
        textoContenido.AppendLine("        <td colspan='3'>Por favor no contestar el e-mail a esta cuenta de Correo.</td>")
        textoContenido.AppendLine("    </tr>")
        textoContenido.AppendLine("    <tr>")
        textoContenido.AppendLine("        <td colspan='3'>Para cualquier consulta comuníquese a desarrolloaplicaciones@ismocol.com</td>")
        textoContenido.AppendLine("    </tr>")

        textoContenido.AppendLine("</div>")

        ' Se arma el HTML que va a llegar al correo
        Dim cuerpo As String = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>"
        cuerpo += "<html xmlns='http://www.w3.org/1999/xhtml'>"
        cuerpo += "    <head>"
        cuerpo += "        <meta http-equiv='Content-Type' content='text/html charset=utf-8' />"
        cuerpo += "        <title>REQUISICIÓN</title>"
        cuerpo += "    </head>"
        cuerpo += "    <body>"
        cuerpo += "        <center>"
        cuerpo += "        " + textoContenido.ToString()
        cuerpo += "        </center>"
        cuerpo += "    </body>"
        cuerpo += "</html>"

        '********************************************** Envío de mail ************************************************/

        Dim strSMTP As String = "smtp.gmail.com"
        'revisar conteo para cambiar de correo cuando se llegue a 450 enviados
        Dim correoOrigen As String = "informacion-noreplicar@ismocol.com"
        Dim correoOrigenClave As String = "Sap753150"

        Dim SmtpServer As New SmtpClient("smtp.gmail.com", 587)
        SmtpServer.UseDefaultCredentials = False
        SmtpServer.Credentials = New Net.NetworkCredential(correoOrigen, correoOrigenClave)
        SmtpServer.EnableSsl = True
        mail.To.Add(correoDestino)
        mail.From = New MailAddress(correoOrigen)
        mail.Subject = asunto
        mail.Body = cuerpo
        mail.IsBodyHtml = True
        mail.Priority = MailPriority.Normal
        'QUITAR PARA QUE FUNCIONE
        SmtpServer.Send(mail)
        MsgBox("Se envió notificación al correo " + Trim(correoDestino), MsgBoxStyle.Information, "Requisición")

    End Sub

    Private Sub Nbi_VerEAxOC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerEAxOC.ItemClick
        If TablaCargada = "LISTAORDENCOMPRA" Then
            If DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
                Try
                    Dim Cadena_Consulta As String = _
                           "select * from dbo.TrazabilidadEAxOC(" + Me.DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value.ToString + " ) order by Fecha"
                    Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Dim da As New SqlDataAdapter(Consulta.CommandText, Conexión.ConnectionString)
                    Dim dt As New DataTable()
                    Conexión.Open()
                    da.Fill(dt)
                    Conexión.Close()
                    'Esto puedes pasarlo a un DataGridView
                    Me.Dgv_ListaItemRequisición.DataSource = dt
                    Me.Dgv_ListaItemRequisición.DefaultCellStyle.BackColor = Color.White
                    Dgv_ListaItemRequisición.ContextMenuStrip.Enabled = True
                    Me.Dgv_ListaItemRequisición.ContextMenuStrip = Me.Cms_EAxOC

                Catch ex As Exception

                End Try

            End If
        Else
            MsgBox("No está cargada la tabla de Ordenes de Compra")
        End If
    End Sub

    Private Sub CopiarDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarDocumentoToolStripMenuItem.Click
        Try
            Clipboard.SetDataObject(Trim(Me.Dgv_ListaItemRequisición.SelectedRows(0).Cells("Entrada Almacén").Value))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Nbi_BuscarxArticulo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarxArticulo.ItemClick
        Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
        FrBuscarArtículo.Familia = "-1"
        FrBuscarArtículo._Tipo = "T"
        FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda por familia, falta implementar

        FrBuscarArtículo.ShowDialog()
        If Trim(FrBuscarArtículo.IdArtículo) = 0 Then
            Exit Sub
        End If

        dsOrdenesCompra = bddatos.BusquedaCondiciones(11, 6, 5, 1, "", FrBuscarArtículo.IdArtículo, Date.Now, Date.Now, 9, 0)
        If dsOrdenesCompra.Tables.Count > 1 Then 'si el procedimiento trae más de una tabla es decir la tabla de conteo y la tabla de datos
            dsOrdenesCompra.Tables.Remove(dsOrdenesCompra.Tables(0).TableName) 'borrar la tabla del conteo 
        Else 'si solo trae el conteo es porque se exceden los campos
            MsgBox("Error al cargar los registros.", MsgBoxStyle.Critical, "Error")
            dsOrdenesCompra.Clear()
        End If
        TablaCargada = "LISTAORDENCOMPRA"
        CargarOrdenCompraFiltro((dsOrdenesCompra))
    End Sub

    Private Sub Nbi_DistribuirCostos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_DistribuirCostos.ItemClick

        Dim IdOrdenCompra As Integer
        Dim OrdenCompra As String
        IdOrdenCompra = DGV_ListaRequisiciones.SelectedRows(0).Cells(0).Value.ToString()
        OrdenCompra = DGV_ListaRequisiciones.SelectedRows(0).Cells(2).Value.ToString()

        If TablaCargada = "LISTAORDENCOMPRA" Then
            If DGV_ListaRequisiciones.SelectedRows.Count > 0 Then

                comando = New SqlCommand("SELECT DISTINCT ESTADO FROM DISPERSIONORDENCOMPRA WHERE IDORDENCOMPRA =@IDORDENCOMPRA AND ESTADO='C'", conexion)
                comando.Parameters.AddWithValue("@IDORDENCOMPRA", IdOrdenCompra)
                adaptador = New SqlDataAdapter(comando)
                Dim dtEstado As New DataTable
                Try
                    conexion.Open()
                    adaptador.Fill(dtEstado)
                    conexion.Close()
                    If dtEstado.Rows.Count > 0 Then
                        MsgBox("La Orden de Compra ya tiene una distribución confirmada")
                    Else
                        Dim FrDistribucionCostos As New Fr_DistribucionCostos
                        FrDistribucionCostos.idOC = IdOrdenCompra
                        FrDistribucionCostos.OC = OrdenCompra
                        FrDistribucionCostos.Cargar_Tablas()
                        FrDistribucionCostos.AplicarFormatoColumnas()
                        FrDistribucionCostos.Show()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conexion.Close()
                End Try
            End If
        Else
            MsgBox("No está cargada la tabla de Ordenes de Compra")
        End If
    End Sub


    Private Sub SubirArchivosPdf(sender As Object, e As EventArgs) Handles Nbi_SubirPDFVbG.ItemClick, Nbi_SubirOC.ItemClick, Nbi_SubirPdfRelacionFactura.ItemClick
        If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
            Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
            Dim Subido As Boolean = False
            Dim PuedeSubir As Boolean = False
            Dim TipoDocumento As Integer = 0
            Dim IdDocumento As String = ""
            Dim NombreDocumento As String = ""
            Dim AñoDocumento As String = ""
            Dim SubidoNube As String = ""
            Dim Actualizar As Boolean = False
            Dim SubirCancelacion As Boolean = False
            Dim CancelarProceso As Boolean = False
            Dim Cancelada As String = ""
            Dim TextoTitulo As String = ""
            Dim TextoLb As String = ""
            Dim TextoRbDocumento As String = ""
            Dim TextoRbCanDocumento As String = ""
            Select Case Boton.Name
                Case "Nbi_SubirPDFVbG"
                    If TablaCargada <> "LISTAREQUISICION" Then
                        MsgBox("No esta cargada la tabla de requisiciones", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(982) Then
                        PuedeSubir = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(981) And 1 = 1 Then
                            Dim IDBodegaOC As Integer = Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                            If IDBodegaOC = VariablesBase.VariablesBase.IdBodegaActual Then
                                PuedeSubir = True
                            Else
                                PuedeSubir = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso(980) Then
                                Dim IDRegistro As Integer = Me.DGV_ListaRequisiciones.Item("IDUSUARIOREGISTRA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
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
                    IdDocumento = Me.DGV_ListaRequisiciones.Item("Id", Index_Registro_Actual).Value.ToString
                    NombreDocumento = Trim(Me.DGV_ListaRequisiciones.Item("Requisición", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaRequisiciones.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaRequisiciones.Item("SSVb", Index_Registro_Actual).Value.ToString
                    Cancelada = Trim(Me.DGV_ListaRequisiciones.Item("Cancelada", Index_Registro_Actual).Value.ToString)
                    If Cancelada = "Total" Or Cancelada = "Parcial" Then
                        TextoLb = "La requisición " + NombreDocumento + " tiene cancelaciones asociadas, indique el documento que desea subir."
                        TextoRbDocumento = "Requisición"
                        TextoRbCanDocumento = "Cancelación de la Requisición"
                        TextoTitulo = "Requisición con cancelaciones asociadas"
                    End If
                Case "Nbi_SubirOC"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(979) Then
                        PuedeSubir = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(978) And 1 = 1 Then
                            Dim IDBodegaOC As Integer = Me.DGV_ListaRequisiciones.Item("IDBODEGA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
                            If IDBodegaOC = VariablesBase.VariablesBase.IdBodegaActual Then
                                PuedeSubir = True
                            Else
                                PuedeSubir = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso(977) Then
                                Dim IDRegistro As Integer = Me.DGV_ListaRequisiciones.Item("IDUSUARIOREGISTRA", Me.DGV_ListaRequisiciones.CurrentCell.RowIndex).Value
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
                    If TablaCargada <> "LISTAORDENCOMPRA" Then
                        MsgBox("No esta cargada la tabla de ordenes de compra", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    IdDocumento = Me.DGV_ListaRequisiciones.Item("Id", Index_Registro_Actual).Value.ToString
                    NombreDocumento = Trim(Me.DGV_ListaRequisiciones.Item("Orden de Compra", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaRequisiciones.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaRequisiciones.Item("Servidor", Index_Registro_Actual).Value.ToString
                    Cancelada = Trim(Me.DGV_ListaRequisiciones.Item("Cancelada", Index_Registro_Actual).Value.ToString)
                    If Cancelada = "Total" Or Cancelada = "Parcial" Then
                        TextoLb = "La Orden de Compra " + NombreDocumento + " tiene cancelaciones asociadas, indique el documento que desea subir."
                        TextoRbDocumento = "Orden de Compra"
                        TextoRbCanDocumento = "Cancelación de la Orden de Compra"
                        TextoTitulo = "Orden de Compra con cancelaciones asociadas"
                    End If
                Case "Nbi_SubirPdfRelacionFactura"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(955) Then
                        PuedeSubir = True
                    Else
                        PuedeSubir = False
                    End If
                    If TablaCargada <> "LISTARELACIONESFACTURAS" Then
                        MsgBox("No esta cargada la tabla de relación de facturas", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    IdDocumento = Me.DGV_ListaRequisiciones.Item("id", Index_Registro_Actual).Value.ToString
                    TipoDocumento = 5
                    NombreDocumento = Trim(Me.DGV_ListaRequisiciones.Item("No", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaRequisiciones.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaRequisiciones.Item("Servidor", Index_Registro_Actual).Value.ToString
                    Cancelada = ""
            End Select

            If PuedeSubir Then
                If Cancelada = "Parcial" Then
                    Dim Fr_Cancelacion As New Form
                    Dim Lb_TextoCancelar As New Label
                    Dim Rb_Documento As New RadioButton
                    Dim Rb_CanDocumento As New RadioButton
                    Dim Bt_Aceptar As New Button
                    Dim Bt_Cancelar As New Button
                    Dim Pn_Panel As New Panel
                    With Lb_TextoCancelar
                        .Text = TextoLb
                        .Location = New System.Drawing.Point(5, 5)
                        .AutoSize = False
                        .Size = New System.Drawing.Size(280, 40)
                    End With

                    With Rb_Documento
                        .Text = TextoRbDocumento
                        .Location = New System.Drawing.Point(10, 45)
                        .AutoSize = True
                    End With

                    With Rb_CanDocumento
                        .Text = TextoRbCanDocumento
                        .Location = New System.Drawing.Point(10, 65)
                        .AutoSize = True
                    End With

                    With Pn_Panel
                        .Size = New System.Drawing.Size(300, 30)
                        .BackColor = Color.Silver
                        .Controls.Add(Bt_Aceptar)
                        .Controls.Add(Bt_Cancelar)
                        .Dock = DockStyle.Bottom
                    End With

                    With Bt_Aceptar
                        .Location = New System.Drawing.Point(140, 5)
                        .Name = "Bt_Aceptar"
                        .Size = New System.Drawing.Size(85, 23)
                        .TabIndex = 2
                        .Text = "Aceptar"
                        .UseVisualStyleBackColor = True
                    End With

                    With Bt_Cancelar
                        .Location = New System.Drawing.Point(60, 5)
                        .Name = "Bt_Cancelar"
                        .Size = New System.Drawing.Size(75, 23)
                        .TabIndex = 3
                        .Text = "Cancelar"
                        .UseVisualStyleBackColor = True
                    End With

                    With Fr_Cancelacion
                        .AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                        .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                        .AcceptButton = Bt_Aceptar
                        .ControlBox = False
                        .MaximizeBox = False
                        .MinimizeBox = False
                        .Size = New System.Drawing.Size(300, 160)
                        .MaximumSize = New System.Drawing.Size(300, 160)
                        .MinimumSize = New System.Drawing.Size(300, 160)
                        .ShowIcon = False
                        .ShowInTaskbar = False
                        .StartPosition = FormStartPosition.CenterScreen
                        .Text = TextoTitulo
                        .Controls.Add(Pn_Panel)
                        .Controls.Add(Lb_TextoCancelar)
                        .Controls.Add(Rb_Documento)
                        .Controls.Add(Rb_CanDocumento)
                    End With

                    AddHandler Bt_Aceptar.Click, Sub()
                                                     If Rb_CanDocumento.Checked = False AndAlso Rb_Documento.Checked = False Then
                                                         MsgBox("Debe seleccionar una opción.")
                                                         Exit Sub
                                                     End If

                                                     If Rb_CanDocumento.Checked = True Then
                                                         SubirCancelacion = True
                                                         Fr_Cancelacion.Close()
                                                     Else
                                                         If Rb_Documento.Checked = True Then
                                                             SubirCancelacion = False
                                                             Fr_Cancelacion.Close()
                                                         End If
                                                     End If
                                                 End Sub

                    AddHandler Bt_Cancelar.Click, Sub()
                                                      If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then
                                                          SubirCancelacion = False
                                                          CancelarProceso = True
                                                          Fr_Cancelacion.Close()
                                                          Exit Sub
                                                      End If
                                                  End Sub
                    Fr_Cancelacion.ShowDialog()

                    If CancelarProceso = True Then
                        Exit Sub
                    End If

                    If SubirCancelacion Then
                        NombreDocumento = "CAN_" + NombreDocumento
                        If Cancelada = "Parcial" Then
                            If Boton.Name = "Nbi_SubirPDFVbG" Then
                                TipoDocumento = 1
                            Else
                                If Boton.Name = "Nbi_SubirOC" Then
                                    TipoDocumento = 2
                                End If
                            End If
                        End If

                        If SubidoNube = "N" Or SubidoNube = "" Then
                            Subido = GoogleDrive.SubirArchivo(TipoDocumento, IdDocumento, NombreDocumento, AñoDocumento, False)
                        Else
                            Subido = GoogleDrive.SubirArchivo(TipoDocumento, IdDocumento, NombreDocumento, AñoDocumento, True)
                        End If
                    Else
                        If Cancelada = "Total" Then
                            NombreDocumento = "CAN_" + NombreDocumento
                            If Boton.Name = "Nbi_SubirPDFVbG" Then
                                TipoDocumento = 9
                            Else
                                If Boton.Name = "Nbi_SubirOC" Then
                                    TipoDocumento = 10
                                End If
                            End If
                        Else
                            If Boton.Name = "Nbi_SubirPDFVbG" Then
                                TipoDocumento = 1
                            Else
                                If Boton.Name = "Nbi_SubirOC" Then
                                    TipoDocumento = 2
                                End If
                            End If
                        End If

                        If SubidoNube = "N" Or SubidoNube = "" Then
                            Subido = GoogleDrive.SubirArchivo(TipoDocumento, IdDocumento, NombreDocumento, AñoDocumento, False)
                        Else
                            Subido = GoogleDrive.SubirArchivo(TipoDocumento, IdDocumento, NombreDocumento, AñoDocumento, True)
                        End If
                    End If
                Else

                    If Cancelada = "Total" Then
                        NombreDocumento = "CAN_" + NombreDocumento
                        If MsgBox("Va subir el documento de la cancelación total, ¿Está seguro?", MsgBoxStyle.YesNo, "Documento de Cancelación ") = MsgBoxResult.No Then
                            Exit Sub
                        End If
                        If Boton.Name = "Nbi_SubirPDFVbG" Then
                            TipoDocumento = 9
                        Else
                            If Boton.Name = "Nbi_SubirOC" Then
                                TipoDocumento = 10
                            End If
                        End If
                    Else
                        If Boton.Name = "Nbi_SubirPDFVbG" Then
                            TipoDocumento = 1
                        Else
                            If Boton.Name = "Nbi_SubirOC" Then
                                TipoDocumento = 2
                            End If
                        End If
                    End If

                    If SubidoNube = "N" Or SubidoNube = "" Then
                        Subido = GoogleDrive.SubirArchivo(TipoDocumento, IdDocumento, NombreDocumento, AñoDocumento, False)
                    Else
                        Subido = GoogleDrive.SubirArchivo(TipoDocumento, IdDocumento, NombreDocumento, AñoDocumento, True)
                    End If
                End If

                If Subido Then
                    Select Case TablaCargada
                        Case "LISTAREQUISICION"
                            CargarTablaxDefectoRequisiciones()
                        Case "LISTAORDENCOMPRA"
                            CargarOCxDefecto()
                        Case "LISTARELACIONESFACTURAS"
                            CargarListaRemisionesFacturas(0)
                    End Select
                End If
            Else
                MsgBox("No cuenta con permisos para subir archivos.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub VerPdfs(sender As Object, e As EventArgs) Handles Nbi_VerPDFVbG.ItemClick, Nbi_VerPdfOC.ItemClick, Nbi_VerPdfRelacionFactura.ItemClick
        If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
            Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
            Dim PuedeVer As Boolean = False
            Dim NombreDocumento As String = ""
            Dim AñoDocumento As String = ""
            Dim SubidoNube As String = ""
            Dim Descargar As String = "ArchivosPDF"
            Dim CarpetaDrive As String = ""
            Dim VerCancelacion As Boolean = False
            Dim CancelarProceso As Boolean = False
            Dim Cancelada As String = ""
            Dim TextoTitulo As String = ""
            Dim TextoLb As String = ""
            Dim TextoRbDocumento As String = ""
            Dim TextoRbCanDocumento As String = ""
            Select Case Boton.Name
                Case "Nbi_VerPDFVbG"
                    If TablaCargada <> "LISTAREQUISICION" Then
                        MsgBox("No esta cargada la tabla de requisiciones", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(842) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    CarpetaDrive = "Requisición"
                    NombreDocumento = Trim(Me.DGV_ListaRequisiciones.Item("Requisición", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaRequisiciones.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaRequisiciones.Item("SSVb", Index_Registro_Actual).Value.ToString
                    Cancelada = Trim(Me.DGV_ListaRequisiciones.Item("Cancelada", Index_Registro_Actual).Value.ToString)
                    If Cancelada = "Total" Or Cancelada = "Parcial" Then
                        TextoLb = "La requisición " + NombreDocumento + " tiene cancelaciones asociadas, indique el documento que desea ver."
                        TextoRbDocumento = "Requisición"
                        TextoRbCanDocumento = "Cancelación de la Requisición"
                        TextoTitulo = "Requisición con cancelaciones asociadas"
                    End If
                Case "Nbi_VerPdfOC"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(952) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    If TablaCargada <> "LISTAORDENCOMPRA" Then
                        MsgBox("No esta cargada la tabla de ordenes de compra", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    CarpetaDrive = "OrdenCompra"
                    NombreDocumento = Trim(Me.DGV_ListaRequisiciones.Item("Orden de Compra", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaRequisiciones.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaRequisiciones.Item("Servidor", Index_Registro_Actual).Value.ToString
                    Cancelada = Trim(Me.DGV_ListaRequisiciones.Item("Cancelada", Index_Registro_Actual).Value.ToString)
                    If Cancelada = "Total" Or Cancelada = "Parcial" Then
                        TextoLb = "La Orden de Compra " + NombreDocumento + " tiene cancelaciones asociadas, indique el documento que desea ver."
                        TextoRbDocumento = "Orden de Compra"
                        TextoRbCanDocumento = "Cancelación de la Orden de Compra"
                        TextoTitulo = "Orden de Compra con cancelaciones asociadas"
                    End If
                Case "Nbi_VerPdfRelacionFactura"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(956) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    If TablaCargada <> "LISTARELACIONESFACTURAS" Then
                        MsgBox("No esta cargada la tabla de relación de facturas", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    CarpetaDrive = "RelacionFactura"
                    NombreDocumento = Trim(Me.DGV_ListaRequisiciones.Item("No", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaRequisiciones.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaRequisiciones.Item("Servidor", Index_Registro_Actual).Value.ToString
                    Cancelada = ""
            End Select

            If SubidoNube <> "S" Then
                Exit Sub
            End If

            If PuedeVer Then

                If Cancelada = "Parcial" Then
                    Dim ExistenDocumentos As Object = GoogleDrive.VerificarDocumentoYCancelacion(NombreDocumento, "CAN_" + NombreDocumento, CarpetaDrive, AñoDocumento)
                    If ExistenDocumentos(1) = 2 Then
                        Dim Fr_Cancelacion As New Form
                        Dim Lb_TextoCancelar As New Label
                        Dim Rb_Documento As New RadioButton
                        Dim Rb_CanDocumento As New RadioButton
                        Dim Bt_Aceptar As New Button
                        Dim Bt_Cancelar As New Button
                        Dim Pn_Panel As New Panel
                        With Lb_TextoCancelar
                            .Text = TextoLb
                            .Location = New System.Drawing.Point(5, 5)
                            .AutoSize = False
                            .Size = New System.Drawing.Size(280, 40)
                        End With

                        With Rb_Documento
                            .Text = TextoRbDocumento
                            .Location = New System.Drawing.Point(10, 45)
                            .AutoSize = True
                        End With

                        With Rb_CanDocumento
                            .Text = TextoRbCanDocumento
                            .Location = New System.Drawing.Point(10, 65)
                            .AutoSize = True
                        End With

                        With Pn_Panel
                            .Size = New System.Drawing.Size(300, 30)
                            .BackColor = Color.Silver
                            .Controls.Add(Bt_Aceptar)
                            .Controls.Add(Bt_Cancelar)
                            .Dock = DockStyle.Bottom
                        End With

                        With Bt_Aceptar
                            .Location = New System.Drawing.Point(140, 5)
                            .Name = "Bt_Aceptar"
                            .Size = New System.Drawing.Size(85, 23)
                            .TabIndex = 2
                            .Text = "Aceptar"
                            .UseVisualStyleBackColor = True
                        End With


                        With Bt_Cancelar
                            .Location = New System.Drawing.Point(60, 5)
                            .Name = "Bt_Cancelar"
                            .Size = New System.Drawing.Size(75, 23)
                            .TabIndex = 3
                            .Text = "Cancelar"
                            .UseVisualStyleBackColor = True
                        End With

                        With Fr_Cancelacion
                            .AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                            .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                            .AcceptButton = Bt_Aceptar
                            .ControlBox = False
                            .MaximizeBox = False
                            .MinimizeBox = False
                            .Size = New System.Drawing.Size(300, 160)
                            .MaximumSize = New System.Drawing.Size(300, 160)
                            .MinimumSize = New System.Drawing.Size(300, 160)
                            .ShowIcon = False
                            .ShowInTaskbar = False
                            .StartPosition = FormStartPosition.CenterScreen
                            .Text = TextoTitulo
                            .Controls.Add(Pn_Panel)
                            .Controls.Add(Lb_TextoCancelar)
                            .Controls.Add(Rb_Documento)
                            .Controls.Add(Rb_CanDocumento)
                        End With

                        AddHandler Bt_Aceptar.Click, Sub()
                                                         If Rb_CanDocumento.Checked = False AndAlso Rb_Documento.Checked = False Then
                                                             MsgBox("Debe seleccionar una opción.")
                                                             Exit Sub
                                                         End If

                                                         If Rb_CanDocumento.Checked = True Then
                                                             VerCancelacion = True
                                                             Fr_Cancelacion.Close()
                                                         Else
                                                             If Rb_Documento.Checked = True Then
                                                                 VerCancelacion = False
                                                                 Fr_Cancelacion.Close()
                                                             End If
                                                         End If
                                                     End Sub

                        AddHandler Bt_Cancelar.Click, Sub()
                                                          If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then
                                                              VerCancelacion = False
                                                              CancelarProceso = True
                                                              Fr_Cancelacion.Close()
                                                              Exit Sub
                                                          End If
                                                      End Sub
                        Fr_Cancelacion.ShowDialog()

                        If CancelarProceso = True Then
                            Exit Sub
                        End If

                        If VerCancelacion Then
                            NombreDocumento = "CAN_" + NombreDocumento
                            If SubidoNube = "S" Then
                                GoogleDrive.DescargarArchivoNombre(AñoDocumento, NombreDocumento, Descargar, CarpetaDrive)
                            End If
                        Else
                            If SubidoNube = "S" Then
                                GoogleDrive.DescargarArchivoNombre(AñoDocumento, NombreDocumento, Descargar, CarpetaDrive)
                            End If
                        End If
                    Else
                        If ExistenDocumentos(2) = "S" Then
                            GoogleDrive.DescargarArchivoNombre(AñoDocumento, NombreDocumento, Descargar, CarpetaDrive)
                        Else
                            If ExistenDocumentos(3) = "S" Then
                                NombreDocumento = "CAN_" + NombreDocumento
                                GoogleDrive.DescargarArchivoNombre(AñoDocumento, NombreDocumento, Descargar, CarpetaDrive)
                            End If
                        End If
                    End If
                Else
                    If Cancelada = "Total" Then
                        NombreDocumento = "CAN_" + NombreDocumento
                    End If
                    If SubidoNube = "S" Then
                        GoogleDrive.DescargarArchivoNombre(AñoDocumento, NombreDocumento, Descargar, CarpetaDrive)
                    End If
                End If
            Else
                MsgBox("No cuenta con permisos para ver archivos.", MsgBoxStyle.Critical, "Error")
            End If

        End If
    End Sub

    Private Sub Nbi_SubirPdfBloque_ItemClick(sender As Object, e As EventArgs) Handles Nbi_SubirPdfBloqueRQ.ItemClick
        Dim PuedeSubir As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(983) Then
            PuedeSubir = True
        End If
        If PuedeSubir Then
            GoogleDrive.VerificarArchivosEnBaseDatos(1)
        End If
    End Sub

    Private Sub Nbi_SubirPdfBloqueOC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_SubirPdfBloqueOC.ItemClick
        Dim PuedeSubir As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(984) Then
            PuedeSubir = True
        End If
        If PuedeSubir Then
            GoogleDrive.VerificarArchivosEnBaseDatos(2)
        End If
    End Sub

    Private Sub Nbi_SubirPdfBloqueRF_ItemClick(sender As Object, e As EventArgs) Handles Nbi_SubirPdfBloqueRF.ItemClick
        Dim PuedeSubir As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(985) Then
            PuedeSubir = True
        End If
        If PuedeSubir Then
            GoogleDrive.VerificarArchivosEnBaseDatos(5)
        End If
    End Sub

    Private Sub Nbi_HistorialArchivos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HistorialArchivosPdfRQ.ItemClick, Nbi_HistorialArchivosPdfOC.ItemClick, Nbi_HistorialArchivosFactura.ItemClick
        If Me.DGV_ListaRequisiciones.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_ListaRequisiciones.CurrentCell.RowIndex
            Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
            Dim CarpetaDrive, AñoDocumento, NombreDocumento, SubidoNube As String
            Dim PuedeVer As Boolean

            Select Case Boton.Name
                Case "Nbi_HistorialArchivosPdfRQ"
                    If TablaCargada <> "LISTAREQUISICION" Then
                        MsgBox("No esta cargada la tabla de requisiciones", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(423) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    CarpetaDrive = "Requisición"
                    NombreDocumento = DGV_ListaRequisiciones.Rows(Index_Registro_Actual).Cells("Requisición").Value.ToString
                    AñoDocumento = Me.DGV_ListaRequisiciones.Item("Año", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaRequisiciones.Item("SSVb", Index_Registro_Actual).Value.ToString
                Case "Nbi_HistorialArchivosPdfOC"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(424) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    If TablaCargada <> "LISTAORDENCOMPRA" Then
                        MsgBox("No esta cargada la tabla de ordenes de compra", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    CarpetaDrive = "OrdenCompra"
                    NombreDocumento = Trim(Me.DGV_ListaRequisiciones.Item("Orden de Compra", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaRequisiciones.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaRequisiciones.Item("Servidor", Index_Registro_Actual).Value.ToString
                Case "Nbi_HistorialArchivosFactura"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(425) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    If TablaCargada <> "LISTARELACIONESFACTURAS" Then
                        MsgBox("No esta cargada la tabla de relación de facturas", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    CarpetaDrive = "RelacionFactura"
                    NombreDocumento = Trim(Me.DGV_ListaRequisiciones.Item("No", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_ListaRequisiciones.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_ListaRequisiciones.Item("Servidor", Index_Registro_Actual).Value.ToString
                Case Else
                    Exit Sub
            End Select
            'CarpetaDrive = "Pruebas"

            If SubidoNube <> "S" Then
                Exit Sub
            End If

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
        End If
    End Sub

End Class


Public Class Cl_Requisicion
    Private _Id As Integer
    Private _Tipo As String = ""
    Private _Requisición As String = ""
    Private _FechaRegistro As String = ""
    Private _FechaSolicitud As String = ""
    Private _Registro As String = ""
    Private _Solicita As String = ""
    Private _Autoriza As String = ""
    Private _Aprueba As String = ""
    Private _Revisa As String = ""
    Private _VistoBueno As String = ""
    Private _VistoBuenoSubgerencia As String = ""
    Private _Compra As String = ""
    Private _Bodega As String = ""
    Private _Origen As String = ""
    Private _Justificación As String = ""
    Private _revisadobodega As String = ""
    Private _CódigoCentroCosto As String = ""
    Private _NombreCentroCosto As String = ""
    Private _IMPRESO As String = ""
    Private _FechaAsigno As String = ""
    Private _Asigno As String = ""
    Private _TipoRQ As String = ""
    Private _Stock As String = ""
    Private _IdEquipo As String = ""
    Private _CodEquipo As String = ""
    Private _Encabezado As String = ""
    Private _FechaAsignaVBGerencia As String = ""
    Private _UsuarioAsignaVBG As String = ""
    Private _SubidoServidor As String = ""
    Private _PersonaSubioArchivo As String = ""
    Private _FechaSubioArchivo As String = ""


    <Description("Código del Centro de Costo de la Orden de Compra"),
    Category("Centro Costo"),
    DisplayNameAttribute("Código Centro de Costo")>
    Public ReadOnly Property CódigoCentroCosto() As String
        Get
            Return _CódigoCentroCosto
        End Get
    End Property

    <Description("Nombre del Centro Costo de la Requisición"),
    Category("Centro Costo"),
    DisplayNameAttribute("Nombre Centro Costo")>
    Public ReadOnly Property NombreCentroCosto() As String
        Get
            Return _NombreCentroCosto
        End Get
    End Property

    <Description("Fecha en que se registró en el sistema la Requisición"),
    Category("Fechas"),
    DisplayNameAttribute("Fecha de Registro")>
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Identificación de la Requisición"), _
    Category("Identificación"),
    DisplayNameAttribute("Requisición")> _
    Public ReadOnly Property Requisición() As String
        Get
            Return _Requisición
        End Get
    End Property

    <Description("Bodega donde se realizó la Requisición"), _
    Category("Identificación"),
    DisplayNameAttribute("Bodega de Origen")> _
    Public ReadOnly Property Bodega() As String
        Get
            Return _Bodega
        End Get
    End Property

    <Description("Tipo de Cobro"), _
    Category("Identificación"),
    DisplayNameAttribute("Tipo de Cobro")> _
    Public ReadOnly Property TipoRQ() As String
        Get
            Return _TipoRQ
        End Get
    End Property

    <Description("Tipo de Stock de Bodega de la Requisición"), _
    Category("Identificación"),
    DisplayNameAttribute("Stock de Bodega")> _
    Public ReadOnly Property Stock() As String
        Get
            Return _Stock
        End Get
    End Property

    <Description("Fecha en que se solicitó la Requisición"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha de Solicitud")> _
    Public ReadOnly Property FechaSolicitud() As String
        Get
            Return _FechaSolicitud
        End Get
    End Property

    <Description("Usuario que registró la Requisición"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Registra")> _
    Public ReadOnly Property Registro() As String
        Get
            Return _Registro
        End Get
    End Property

    <Description("Persona que solicitó la Requisición"), _
    Category("Usuario"),
    DisplayNameAttribute("Persona Solicita")> _
    Public ReadOnly Property Solicita() As String
        Get
            Return _Solicita
        End Get
    End Property

    <Description("Usuario que autoriza la Requisición"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Autoriza")> _
    Public ReadOnly Property Autoriza() As String
        Get
            Return _Autoriza
        End Get
    End Property

    <Description("Usuario que aprueba la Requisición"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Aprueba")> _
    Public ReadOnly Property Aprueba() As String
        Get
            Return _Aprueba
        End Get
    End Property

    <Description("Usuario que revisa la Requisición"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Revisa")> _
    Public ReadOnly Property Revisa() As String
        Get
            Return _Revisa
        End Get
    End Property

    <Description("Usuario que da el Visto Bueno a la Requisición"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Visto Bueno")> _
    Public ReadOnly Property VistoBueno() As String
        Get
            Return _VistoBueno
        End Get
    End Property

    <Description("Usuario que da el Visto Bueno de SubGerencia a la Requisición"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Visto Bueno Subgerencia")> _
    Public ReadOnly Property VistoBuenoSubgerencia() As String
        Get
            Return _VistoBuenoSubgerencia
        End Get
    End Property

    <Description("Usuario que compra la Requisición"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Compra")> _
    Public ReadOnly Property Compra() As String
        Get
            Return _Compra
        End Get
    End Property

    <Description("Encabezado de la Requisición"), _
    Category("Encabezado"),
    DisplayNameAttribute("Encabezado")> _
    Public ReadOnly Property Encabezado() As String
        Get
            Return _Encabezado
        End Get
    End Property

    <Description("Justificación de la Requisición"), _
    Category("Justificación"),
    DisplayNameAttribute("Justificación")> _
    Public ReadOnly Property Justificación() As String
        Get
            Return _Justificación
        End Get
    End Property

    <Description("Indica si el documento fue impreso"), _
    Category("Documento"),
    DisplayNameAttribute("Impreso")> _
    Public ReadOnly Property IMPRESO() As String
        Get
            Return _IMPRESO
        End Get
    End Property

    <Description("Indica fecha en la que se asigna el comprador a la Requisición"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Asigna Comprador")> _
    Public ReadOnly Property FechaAsignacion() As String
        Get
            Return _FechaAsigno
        End Get
    End Property

    <Description("Usuario que asignó el comprador a la Requisición"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Asignó Comprador")> _
    Public ReadOnly Property AsignoComprador() As String
        Get
            Return _Asigno
        End Get
    End Property

    <Description("Id del equipo asociado a la Requisición"), _
    Category("Equipo"),
    DisplayNameAttribute("Id Equipo asociado")> _
    Public ReadOnly Property IdEquipo() As String
        Get
            Return _IdEquipo
        End Get
    End Property

    <Description("Código del equipo asociado a la Requisición"), _
    Category("Equipo"),
    DisplayNameAttribute("Código Equipo asociado")> _
    Public ReadOnly Property CodEquipo() As String
        Get
            Return _CodEquipo
        End Get
    End Property

    <Description(""), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Asigna VBG")> _
    Public ReadOnly Property UAsignaVBG() As String
        Get
            Return _UsuarioAsignaVBG
        End Get
    End Property

    <Description(""), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Asigna VBG")> _
    Public ReadOnly Property FAsignaVBG() As String
        Get
            Return _FechaAsignaVBGerencia
        End Get
    End Property

    <Description(""), _
    Category(""),
    DisplayNameAttribute("")> _
    Public ReadOnly Property SubidoServidorArchivo() As String
        Get
            Return _SubidoServidor
        End Get
    End Property

    <Description(""), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Subio PDF")> _
    Public ReadOnly Property PSubioPDF() As String
        Get
            Return _PersonaSubioArchivo
        End Get
    End Property

    <Description(""), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Subio PDF")> _
    Public ReadOnly Property FSubioPDF() As String
        Get
            Return _FechaSubioArchivo
        End Get
    End Property

    Public Sub New(ByVal FilaRQ As DataRow)
        _Id = FilaRQ("Id")
        _Tipo = FilaRQ("Tipo")
        _Requisición = FilaRQ("Requisición")
        _TipoRQ = FilaRQ("TIPORQ")
        _FechaRegistro = FilaRQ("Fecha Registro")
        _FechaSolicitud = FilaRQ("Fecha Solicitud")
        _Registro = FilaRQ("Registro")
        _Solicita = FilaRQ("Solicita")
        _Autoriza = FilaRQ("Autoriza")
        _Aprueba = FilaRQ("Aprueba")
        _Revisa = FilaRQ("Revisa")
        _Stock = FilaRQ("Stock")
        _VistoBueno = IIf(IsDBNull(FilaRQ("Visto Bueno")) = True, "", FilaRQ("Visto Bueno"))
        _Compra = IIf(IsDBNull(FilaRQ("Compra")) = True, "", FilaRQ("Compra"))
        _Bodega = FilaRQ("Bodega")
        _Justificación = FilaRQ("Justificación")
        _CódigoCentroCosto = Trim(FilaRQ("Código Centro Costo"))
        _NombreCentroCosto = Trim(FilaRQ("Nombre Centro Costo"))
        _IMPRESO = IIf(FilaRQ("IMPRESA") = "S", "SI", "NO")
        _FechaAsigno = IIf(IsDBNull(FilaRQ("Fecha Asigno")) = True, "", FilaRQ("Fecha Asigno"))
        _Asigno = IIf(IsDBNull(FilaRQ("Asigna")) = True, "", FilaRQ("Asigna"))
        _VistoBuenoSubgerencia = IIf(IsDBNull(FilaRQ("Visto Bueno SubGerencia")) = True, "", FilaRQ("Visto Bueno SubGerencia"))
        _UsuarioAsignaVBG = IIf(IsDBNull(FilaRQ("PersonaasignaVBG")) = True, "", FilaRQ("PersonaasignaVBG"))
        _FechaAsignaVBGerencia = IIf(IsDBNull(FilaRQ("Fecha asigna VBG")) = True, "", FilaRQ("Fecha asigna VBG"))
        _SubidoServidor = IIf(IsDBNull(FilaRQ("SSVB")) = True, "", FilaRQ("SSVB"))
        _PersonaSubioArchivo = IIf(IsDBNull(FilaRQ("Persona subio Archivo PDF")) = True, "", FilaRQ("Persona subio Archivo PDF"))
        _FechaSubioArchivo = IIf(IsDBNull(FilaRQ("Fecha subio Archivo PDF")) = True, "", FilaRQ("Fecha subio Archivo PDF"))


        Try
            _IdEquipo = Trim(FilaRQ("IDEQUIPO"))
            _CodEquipo = Trim(FilaRQ("CODIGO"))
        Catch
            _IdEquipo = ""
            _CodEquipo = ""
        End Try
        Try
            _Encabezado = Trim(FilaRQ("Encabezado"))
        Catch ex As Exception
            _Encabezado = ""
        End Try
    End Sub
End Class 'Cl_Requisicion

Public Class Cl_OrdenCompra
    Private _Id As Integer
    Private _Estado As String = ""
    Private _Tipo As String = ""
    Private _OrdendeCompra As String = ""
    Private _FechaOC As String = ""
    Private _Requisición As String = ""
    Private _FechaSolicitudRQ As String = ""
    Private _NIT As String = ""
    Private _Proveedor As String = ""
    Private _Contacto As String = ""
    Private _Teléfono As String = ""
    Private _CódigoCentroCosto As String = ""
    Private _NombreCentroCosto As String = ""
    Private _Comprador As String = ""
    Private _Aprueba As String = ""
    Private _IMPRESO As String = ""
    Private _Autoriza As String = ""
    Private _ApruebaGerencia As String = ""
    Private _Revisa As String = ""
    Private _FechaEntrega As String = ""
    Private _FechaApruebaGerencia As String = ""
    Private _Encabezado As String = ""
    Private _Observacion As String = ""
    Private _ValorOC As String = ""
    Private _Factura As String = ""


    <Description("Identificación de la Orden de Compra"), _
    Category("Identificación"),
    DisplayNameAttribute("Orden de Compra")> _
    Public ReadOnly Property OrdendeCompra() As String
        Get
            Return _OrdendeCompra
        End Get
    End Property

    <Description("Requisición que cumple la Orden de Compra"),
    Category("Identificación"),
    DisplayNameAttribute("Requisición")>
    Public ReadOnly Property Requisición() As String
        Get
            Return _Requisición
        End Get
    End Property

    <Description("Numero de Factura"), _
Category("Identificación"),
DisplayNameAttribute("Factura")> _
    Public ReadOnly Property Factura() As String
        Get
            Return _Factura
        End Get
    End Property

    <Description("Código Centro de Costo de la Orden de Compra"),
    Category("Centro Costo"),
    DisplayNameAttribute("Código Centro Costo")>
    Public ReadOnly Property CódigoCentroCosto() As String
        Get
            Return _CódigoCentroCosto
        End Get
    End Property

    <Description("Centro de Costo de la Orden de Compra"),
    Category("Centro Costo"),
    DisplayNameAttribute("Nombre Centro de Costo")>
    Public ReadOnly Property NombreCentroCosto() As String
        Get
            Return _NombreCentroCosto
        End Get
    End Property

    <Description("Usuario que hace la Orden de Compra"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Compra")> _
    Public ReadOnly Property Comprador() As String
        Get
            Return _Comprador
        End Get
    End Property

    <Description("Usuario que Aprueba la Orden de Compra"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Aprueba")> _
    Public ReadOnly Property Aprueba() As String
        Get
            Return _Aprueba
        End Get
    End Property

    <Description("Usuario que Autoriza la Orden de Compra"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Autoriza")> _
    Public ReadOnly Property Autoriza() As String
        Get
            Return _Autoriza
        End Get
    End Property

    <Description("Usuario que Aprueba Gerencia la Orden de Compra"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Aprueba Gerencia")> _
    Public ReadOnly Property ApruebaGerencia() As String
        Get
            Return _ApruebaGerencia
        End Get
    End Property

    <Description("Usuario que Revisa la Orden de Compra"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Revisa")> _
    Public ReadOnly Property Revisa() As String
        Get
            Return _Revisa
        End Get
    End Property

    <Description("Fecha en que se solicito la Requisición"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Solicitud RQ")> _
    Public ReadOnly Property FechaSolicitudRQ() As String
        Get
            Return _FechaSolicitudRQ
        End Get
    End Property

    <Description("Fecha en que se aprueba Gerencia"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Aprueba Gerencia la OC")> _
    Public ReadOnly Property FechaApruebaGerencia() As String
        Get
            Return _FechaApruebaGerencia
        End Get
    End Property

    <Description("Fecha en que se realizo la Orden de Compra"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha OC")> _
    Public ReadOnly Property FechaOC() As String
        Get
            Return _FechaOC
        End Get
    End Property

    <Description("Nit del Proveedor"), _
    Category("Proveedor"),
    DisplayNameAttribute("NIT")> _
    Public ReadOnly Property NIT() As String
        Get
            Return _NIT
        End Get
    End Property

    <Description("Nombre del Proveedor"), _
    Category("Proveedor"),
    DisplayNameAttribute("Nombre Proveedor")> _
    Public ReadOnly Property Proveedor() As String
        Get
            Return _Proveedor
        End Get
    End Property

    <Description("Contacto del Proveedor"), _
    Category("Proveedor"),
    DisplayNameAttribute("Contacto del Proveedor")> _
    Public ReadOnly Property Contacto() As String
        Get
            Return _Contacto
        End Get
    End Property

    <Description("Teléfono del Proveedor"), _
    Category("Proveedor"),
    DisplayNameAttribute("Teléfono del Proveedor")> _
    Public ReadOnly Property Teléfono() As String
        Get
            Return _Teléfono
        End Get
    End Property

    <Description("Fecha de entrega"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha de Entrega")> _
    Public ReadOnly Property FechaEntrega() As String
        Get
            Return _FechaEntrega
        End Get
    End Property

    <Description("Indica si el documento fue impreso"), _
    Category("Documento"),
    DisplayNameAttribute("Impreso")> _
    Public ReadOnly Property IMPRESO() As String
        Get
            Return _IMPRESO
        End Get
    End Property

    <Description("Encabezado de la requisición"), _
    Category("Encabezado"),
    DisplayNameAttribute("Encabezado")> _
    Public ReadOnly Property Encabezado() As String
        Get
            Return _Encabezado
        End Get
    End Property

    <Description("Observación de la orden de compra"), _
    Category("Observación"),
    DisplayNameAttribute("Observación")> _
    Public ReadOnly Property Observacion() As String
        Get
            Return _Observacion
        End Get
    End Property

    <Description("Valor Total de la orden de compra"), _
    Category("Valor Total"),
    DisplayNameAttribute("Valor Total")> _
    Public ReadOnly Property ValorT() As String
        Get
            Return _ValorOC
        End Get
    End Property

    Public Sub New(ByVal FilaOC As DataRow)
        _Id = FilaOC("Id")
        _Estado = FilaOC("Estado")
        _Tipo = FilaOC("Tipo")
        _OrdendeCompra = Trim(FilaOC("Orden de Compra"))
        _FechaOC = FilaOC("Fecha OC")
        _Requisición = FilaOC("Requisición")
        _FechaSolicitudRQ = FilaOC("Fecha Solicitud RQ")
        _NIT = FilaOC("NIT")
        _Proveedor = FilaOC("Proveedor")
        _FechaEntrega = IIf(IsDBNull(FilaOC("FechaEntrega")), "", FilaOC("FechaEntrega"))
        _Contacto = FilaOC("Contacto")
        _Teléfono = FilaOC("Teléfono")
        _Comprador = FilaOC("Comprador")
        _Aprueba = FilaOC("Aprueba")
        _Autoriza = FilaOC("Autoriza")
        _ApruebaGerencia = FilaOC("ApruebaGerencia")
        _Revisa = FilaOC("Revisa")
        _CódigoCentroCosto = Trim(FilaOC("Código Centro Costo"))
        _NombreCentroCosto = Trim(FilaOC("Nombre Centro Costo"))
        _IMPRESO = IIf(FilaOC("IMPRESA") = "S", "SI", "NO")
        _FechaApruebaGerencia = IIf(IsDBNull(FilaOC("FechaApruebaGerencia")) = True, "", FilaOC("FechaApruebaGerencia"))
        _ValorOC = FilaOC("ValorOC")
        _Factura = IIf(IsDBNull(FilaOC("Factura")), "", FilaOC("Factura"))
        Try
            _Observacion = Trim(FilaOC("Observacion"))
        Catch ex As Exception
            _Observacion = ""
        End Try
        Try
            _Encabezado = Trim(FilaOC("Encabezado"))
        Catch ex As Exception
            _Encabezado = ""
        End Try
    End Sub
End Class 'Cl_OrdenCompra

Public Class Cl_Proveedor
    Private _Id As Integer
    Private _Nombre As String = ""
    Private _Identificación As String = ""
    Private _Ciudad As String = ""
    Private _Dirección As String = ""
    Private _Telefóno As String = ""
    Private _Celular As String = ""
    Private _Email As String = ""
    Private _RepresentateVenta As String = ""
    Private _TelRepVenta As String = ""
    Private _CelRepVenta As String = ""
    Private _EmailRepVenta As String = ""
    Private _FechaRegistro As String = ""
    Private _UsuarioRegistra As String = ""
    Private _FechaModificación As String = ""
    Private _UsuarioModifica As String = ""


    <Description("Nombre del Proveedor"), _
    Category("Identificación"),
    DisplayNameAttribute("Nombre del Proveedor")> _
    Public ReadOnly Property Nombre() As String
        Get
            Return _Nombre
        End Get
    End Property

    <Description("Identificación del Proveedor"), _
    Category("Identificación"),
    DisplayNameAttribute("Identificación del Proveedor")> _
    Public ReadOnly Property Identificación() As String
        Get
            Return _Identificación
        End Get
    End Property

    <Description("Ciudad del Proveedor"), _
    Category("Ubicación"),
    DisplayNameAttribute("Ciudad del Proveedor")> _
    Public ReadOnly Property Ciudad() As String
        Get
            Return _Ciudad
        End Get
    End Property

    <Description("Dirección del Proveedor"), _
    Category("Ubicación"),
    DisplayNameAttribute("Dirección del Proveedor")> _
    Public ReadOnly Property Dirección() As String
        Get
            Return _Dirección
        End Get
    End Property

    <Description("Teléfono del Proveedor"), _
    Category("Contacto"),
    DisplayNameAttribute("Teléfono del Proveedor")> _
    Public ReadOnly Property Telefóno() As String
        Get
            Return _Telefóno
        End Get
    End Property

    <Description("Celular del Proveedor"), _
    Category("Contacto"),
    DisplayNameAttribute("Celular del Proveedor")> _
    Public ReadOnly Property Celular() As String
        Get
            Return _Celular
        End Get
    End Property

    <Description("Email del Proveedor"), _
    Category("Contacto"),
    DisplayNameAttribute("Email del Proveedor")> _
    Public ReadOnly Property Email() As String
        Get
            Return _Email
        End Get
    End Property

    <Description("Representante de Venta del Proveedor"), _
    Category("Representante de Venta"),
    DisplayNameAttribute("Representante de Venta")> _
    Public ReadOnly Property RepresentateVenta() As String
        Get
            Return _RepresentateVenta
        End Get
    End Property

    <Description("Teléfono del Representante de Venta del Proveedor"), _
    Category("Representante de Venta"),
    DisplayNameAttribute("Teléfono Representante de Venta")> _
    Public ReadOnly Property TelRepVenta() As String
        Get
            Return _TelRepVenta
        End Get
    End Property

    <Description("Celular del Representante de Venta del Proveedor"), _
    Category("Representante de Venta"),
    DisplayNameAttribute("Celular Representante de Venta")> _
    Public ReadOnly Property CelRepVenta() As String
        Get
            Return _CelRepVenta
        End Get
    End Property

    <Description("E-mail del Representante de Venta del Proveedor"), _
    Category("Representante de Venta"),
    DisplayNameAttribute("E-mail Representante de Venta")> _
    Public ReadOnly Property EmailRepVenta() As String
        Get
            Return _EmailRepVenta
        End Get
    End Property

    <Description(""), _
    Category("Auditoria"),
    DisplayNameAttribute("Persona Registro")> _
    Public ReadOnly Property PRegistro() As String
        Get
            Return _UsuarioRegistra
        End Get
    End Property

    <Description(""), _
    Category("Auditoria"),
    DisplayNameAttribute("Fecha Registro")> _
    Public ReadOnly Property FRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description(""), _
    Category("Auditoria"),
    DisplayNameAttribute("Persona Modifica")> _
    Public ReadOnly Property PModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property

    <Description(""), _
    Category("Auditoria"),
    DisplayNameAttribute("Fecha Modificación")> _
    Public ReadOnly Property FModifica() As String
        Get
            Return _FechaModificación
        End Get
    End Property

    Public Sub New(ByVal FilaRQ As DataGridViewRow)
        _Id = FilaRQ.Cells("Id").Value
        _Nombre = FilaRQ.Cells("Nombre").Value
        _Identificación = FilaRQ.Cells("Identificación").Value
        _Ciudad = FilaRQ.Cells("Ciudad").Value
        _Dirección = FilaRQ.Cells("Dirección").Value
        _Telefóno = FilaRQ.Cells("Telefóno").Value
        _Celular = FilaRQ.Cells("Celular").Value
        _Email = FilaRQ.Cells("Email").Value
        Try
            _RepresentateVenta = FilaRQ.Cells("Representate Venta").Value
        Catch
            _RepresentateVenta = ""
        End Try
        Try
            _TelRepVenta = FilaRQ.Cells("Tel Rep Venta").Value
        Catch
            _TelRepVenta = ""
        End Try
        Try
            _CelRepVenta = FilaRQ.Cells("Cel Rep Venta").Value
        Catch
            _CelRepVenta = ""
        End Try
        Try
            _EmailRepVenta = FilaRQ.Cells("Email Rep Venta").Value
        Catch
            _EmailRepVenta = ""
        End Try
        Try
            _UsuarioRegistra = FilaRQ.Cells("Usuario Registra").Value
        Catch
            _UsuarioRegistra = ""
        End Try
        Try
            _FechaRegistro = FilaRQ.Cells("Fecha Registro").Value
        Catch
            _FechaRegistro = ""
        End Try
        Try
            _UsuarioModifica = FilaRQ.Cells("Usuario Modifica").Value
        Catch
            _UsuarioModifica = ""
        End Try
        Try
            _FechaModificación = FilaRQ.Cells("Fecha Modificación").Value
        Catch
            _FechaModificación = ""
        End Try

        '
        '
        '
    End Sub
End Class 'Cl_Proveedor

Friend Class Cl_SolicitudMaquinaria
    Private _IdSolicitudMaquinaria As Integer
    Private _SolicitudMaquinaria As String
    Private _Bodega As String
    Private _Encabezado As String
    Private _Justificacion As String
    Private _PersonaSolicita As String
    Private _PersonaAutoriza As String
    Private _PersonaAprueba As String
    Private _PersonaRevisa As String
    Private _FechaRegistro As String
    Private _UsuarioRegistro As String
    Private _FechaModificacion As String
    Private _UsuarioModifica As String

    <Description("Identificador de la Solicitud de Maquinaria y Equipo"), _
    Category("Identificación"), _
    DisplayNameAttribute("Id Solicitud")> _
    Public ReadOnly Property IdSolicitudMaquinaria() As String
        Get
            Return _IdSolicitudMaquinaria
        End Get
    End Property

    <Description("Consecutivo de la Solicitud de Maquinaria y Equipo"), _
    Category("Identificación"), _
    DisplayNameAttribute("Consecutivo")> _
    Public ReadOnly Property SolicitudMaquinaria() As String
        Get
            Return _SolicitudMaquinaria
        End Get
    End Property

    <Description("Bodega"), _
    Category("Identificación"), _
    DisplayNameAttribute("Bodega")> _
    Public ReadOnly Property Bodega() As String
        Get
            Return _Bodega
        End Get
    End Property

    <Description("Encabezado"), _
    Category("Justificación"), _
    DisplayNameAttribute("Encabezado")> _
    Public ReadOnly Property Encabezado() As String
        Get
            Return _Encabezado
        End Get
    End Property

    <Description("Justificación"), _
    Category("Justificación"), _
    DisplayNameAttribute("Justificación")> _
    Public ReadOnly Property Justificacion() As String
        Get
            Return _Justificacion
        End Get
    End Property

    <Description("Director del Proyecto"), _
    Category("Personal Asociado"), _
    DisplayNameAttribute("Director Proyecto")> _
    Public ReadOnly Property PersonaSolicita() As String
        Get
            Return _PersonaSolicita
        End Get
    End Property

    <Description("Gerente Correspondiente"), _
    Category("Personal Asociado"), _
    DisplayNameAttribute("Gerente Correspondiente")> _
    Public ReadOnly Property PersonaAutoriza() As String
        Get
            Return _PersonaAutoriza
        End Get
    End Property

    <Description("Gerente General"), _
    Category("Personal Asociado"), _
    DisplayNameAttribute("Gerente General")> _
    Public ReadOnly Property PersonaAprueba() As String
        Get
            Return _PersonaAprueba
        End Get
    End Property

    <Description("Fecha en que se registró la Solicitud de Maquinaria y Equipo"), _
    Category("Fechas"), _
    DisplayNameAttribute("Fecha Registro")> _
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Usuario que registró la Solicitud de Maquinaria y Equipo"), _
    Category("Personal Asociado"), _
    DisplayNameAttribute("Usuario Registro")> _
    Public ReadOnly Property UsuarioRegistro() As String
        Get
            Return _UsuarioRegistro
        End Get
    End Property

    <Description("Última fecha en que se modificó la Solicitud de Maquinaria y Equipo"), _
    Category("Fechas"), _
    DisplayNameAttribute("Fecha Modificación")> _
    Public ReadOnly Property FechaModificacion() As String
        Get
            Return _FechaModificacion
        End Get
    End Property

    <Description("Último usuario que modificó la Solicitud de Maquinaria y Equipo"), _
    Category("Personal Asociado"), _
    DisplayNameAttribute("Usuario Modifica")> _
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property


    Public Sub New(ByVal FilaSM As DataRow)
        _IdSolicitudMaquinaria = FilaSM("IdSolicitudMaquinaria")
        _SolicitudMaquinaria = FilaSM("SolicitudMaquinaria")
        _Bodega = FilaSM("Bodega")
        _Encabezado = FilaSM("Encabezado")
        _Justificacion = FilaSM("Justificacion")
        _PersonaSolicita = FilaSM("PersonaSolicita")
        _PersonaAutoriza = FilaSM("PersonaAutoriza")
        _PersonaAprueba = FilaSM("PersonaAprueba")
        _FechaRegistro = FilaSM("FechaRegistro")
        _UsuarioRegistro = FilaSM("UsuarioRegistro")
        Try
            _FechaModificacion = FilaSM("FechaModificacion")
            _UsuarioModifica = FilaSM("UsuarioModifica")
        Catch
            _FechaModificacion = ""
            _UsuarioModifica = ""
        End Try
    End Sub



End Class 'Cl_SolicitudMaquinaria