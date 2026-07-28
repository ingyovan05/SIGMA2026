Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.Office.Interop
Imports System.IO

Public Class Cu_Bodega
    Private datasequipos As New DataSet
    Private cmde As New SqlClient.SqlCommand
    Private da As New SqlClient.SqlDataAdapter
    Private WithEvents Bw_correosSAPendientesXEA As New BackgroundWorker
    Dim Index_Registro_Actual As Integer
    Dim vistabodegaactiva As DataView
    Dim vistabodegainactiva As DataView
    'Dim LISTABODEGATableAdapter As New DatosBodegas.Ds_BodegaTableAdapters.LISTABODEGATableAdapter
    Dim ListaRemisionesTableAdapter As New DatosBodegas.Ds_BodegaTableAdapters.ListaRemisionesTableAdapter
    Dim dtEntradaAlmacen As New DataTable
    Dim dtEntradaAlmacenCancelada As New DataTable
    Dim dtSalidaAlmacen As New DataTable
    Dim dtBodega As New DataTable
    Dim dtSalidaAlmacenCancelada As New DataTable
    Dim dtItemEntradaAlmacen As New DataTable
    Dim dtItemEntradaAlmacenCancelada As New DataTable
    Dim dtItemSalidaAlmacen As New DataTable
    Dim dtItemSalidaAlmacenCancelada As New DataTable
    Dim DsBodega As New DatosBodegas.Ds_Bodega
    Dim DsSalidaAlmacénfiltro As New DataSet
    Dim TablaCargada As String = Tabla.Entrada
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()
    Dim EsRemisionValorizada As Boolean = False
    Dim dt_opcionesfiltro1 As New DataTable("OPCIONES")
    Dim dt_opcionesfiltro2 As New DataTable("OPCIONES")
    Dim dt_opcionesfiltro3 As New DataTable("OPCIONES")
    Dim objStreamWriter As StreamWriter
    Dim nombrearchivo As String = "\correosCustodiaPendiente" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt"

    Private GoogleDrive As New FuncionesGoogle.FuncionesGoogle
    Private Structure Tabla
        Const Entrada As String = "ENTRADA"
        Const EntradaCancelada As String = "ENTRADACANCELADA"
        Const Salida As String = "SALIDA"
        Const SalidaCancelada As String = "SALIDACANCELADA"
        Const Bodega As String = "BODEGA"
        Const NoLlegaron As String = "NoLLegaron"
        Const LLegaron As String = "LLegaron"
        Const Remision As String = "REMISION"
        Const Finalizadas As String = "Finalizadas"
        Const NoFinalizadas As String = "NoFinalizadas"
    End Structure

#Region "Cargar Tablas"
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
        CargarSalidasAlmacén(1, "")
    End Sub


    Private Sub Nbi_CargarEntradasAlmacen_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarEntradasAlmacen.ItemClick
        CargarEntradaAlmacén(1)
    End Sub


    Private Sub CargarEntradaAlmacénFiltro(ByVal dsTabla As DataSet)
        TablaCargada = Tabla.Entrada
        Lb_Movimiento.Text = "Lista de Entrada de Almacén"
        Lb_Filtro.Text = "Entrada de Almacén"
        DGV_Lista.DataSource = Nothing
        Me.DGV_Lista.DataSource = dsTabla.Tables(0).DefaultView
        Me.DGV_Lista.AutoGenerateColumns = True
        Me.DGV_Lista.ContextMenuStrip = Me.Cms_Ordenar
        Me.Lb_Cargado.Text = "ENTRADAS DE ALMACÉN"
        DGV_ListaItem.ContextMenuStrip = Cms_CancelarItem
        Me.DGV_Lista.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_Lista.ReadOnly = True
        Me.dt_opcionesfiltro1.Rows.Clear()
        Me.dt_opcionesfiltro2.Rows.Clear()
        Me.dt_opcionesfiltro3.Rows.Clear()
        Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()
        For i = 0 To DGV_Lista.ColumnCount - 1
            DGV_Lista.Columns(i).Visible = True
            Dim filaopciónfiltro1 As DataRow
            Dim filaopciónfiltro2 As DataRow
            Dim filaopciónfiltro3 As DataRow
            filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
            filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
            filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
            filaopciónfiltro1("OPCION") = DGV_Lista.Columns(i).Name
            filaopciónfiltro2("OPCION") = DGV_Lista.Columns(i).Name
            filaopciónfiltro3("OPCION") = DGV_Lista.Columns(i).Name
            dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
            dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
            dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
            Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
            Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_Lista.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
            Submenuitem.Name = DGV_Lista.Columns(i).Name
            Submenuitem.Size = New System.Drawing.Size(152, 22)
            Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})
            Select Case DGV_Lista.Columns(i).Name
                Case "Id"
                    DGV_Lista.Columns(i).Width = 50
                Case "Entrada"
                    DGV_Lista.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Tipo"
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_Lista.Columns(i).Width = 40
                Case "Bodega"
                    DGV_Lista.Columns(i).Width = 80
                Case "Recibio"
                    DGV_Lista.Columns(i).Width = 200
                Case "Remisión"
                    DGV_Lista.Columns(i).Width = 100
                Case "Cancelada"
                    DGV_Lista.Columns(i).Width = 100
                Case "Servidor"
                    DGV_Lista.Columns(i).Width = 45
                    DGV_Lista.Columns(i).ToolTipText = "Subido al Servidor"
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    DGV_Lista.Columns(i).Visible = False
            End Select
        Next
        Me.DGV_ListaItem.DataSource = Nothing
        CargarItems()
    End Sub


    Private Sub CargarEntradaAlmacén(ByVal Tipo As Integer, Optional ByVal Valor As String = "-1")
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        TablaCargada = Tabla.Entrada
        Lb_Movimiento.Text = "Lista de Entrada de Almacén"
        Lb_Filtro.Text = "Entrada de Almacén"
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListaEntradaAlmacén(@TIPO, @IDBODEGA, @VALOR)", conexion)
        comando.Parameters.AddWithValue("@TIPO", Tipo)
        comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        comando.Parameters.AddWithValue("@VALOR", Valor)
        Dim adaptador As New SqlDataAdapter(comando)
        dtEntradaAlmacen.Clear()
        Try
            conexion.Open()
            adaptador.Fill(dtEntradaAlmacen)
            conexion.Close()
            DGV_Lista.DataSource = Nothing
            Me.DGV_Lista.DataSource = dtEntradaAlmacen
            Me.DGV_Lista.AutoGenerateColumns = True
            Me.DGV_Lista.ContextMenuStrip = Me.Cms_Ordenar
            Me.Lb_Cargado.Text = "ENTRADAS DE ALMACÉN"
            Me.Lb_Movimiento.Text = "Lista de " & dtEntradaAlmacen.Rows.Count.ToString & " Entradas de Almacén"
            DGV_ListaItem.ContextMenuStrip = Cms_CancelarItem
            Me.DGV_Lista.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.DGV_Lista.ReadOnly = True
            Me.dt_opcionesfiltro1.Rows.Clear()
            Me.dt_opcionesfiltro2.Rows.Clear()
            Me.dt_opcionesfiltro3.Rows.Clear()
            Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()
            For i = 0 To DGV_Lista.ColumnCount - 1
                DGV_Lista.Columns(i).Visible = True
                Dim filaopciónfiltro1 As DataRow
                Dim filaopciónfiltro2 As DataRow
                Dim filaopciónfiltro3 As DataRow
                filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
                filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
                filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
                filaopciónfiltro1("OPCION") = DGV_Lista.Columns(i).Name
                filaopciónfiltro2("OPCION") = DGV_Lista.Columns(i).Name
                filaopciónfiltro3("OPCION") = DGV_Lista.Columns(i).Name
                dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
                dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
                dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
                Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
                Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_Lista.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
                Submenuitem.Name = DGV_Lista.Columns(i).Name
                Submenuitem.Size = New System.Drawing.Size(152, 22)
                Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})
                Select Case DGV_Lista.Columns(i).Name
                    Case "Id"
                        DGV_Lista.Columns(i).Width = 50
                    Case "Entrada"
                        DGV_Lista.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                        DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Case "Tipo"
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_Lista.Columns(i).Width = 40
                    Case "Bodega"
                        DGV_Lista.Columns(i).Width = 80
                    Case "Recibio"
                        DGV_Lista.Columns(i).Width = 200
                    Case "Remisión"
                        DGV_Lista.Columns(i).Width = 100
                    Case "Servidor"
                        DGV_Lista.Columns(i).Width = 45
                        DGV_Lista.Columns(i).ToolTipText = "Subido al Servidor"
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case Else
                        DGV_Lista.Columns(i).Visible = False
                End Select
            Next
            Me.DGV_ListaItem.DataSource = Nothing
            CargarItems()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub CargarEntradasCanceladas(ByVal Tipo As Integer, Optional ByVal Valor As Integer = -1)
        TablaCargada = Tabla.EntradaCancelada
        Lb_Movimiento.Text = "Lista de Entrada de Almacén Cancelada"
        Lb_Filtro.Text = "Entrada de Almacén Cancelada"
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListaEntradaAlmacénCancelada(@TIPO, @IDBODEGA, @VALOR)", conexion)
        comando.Parameters.AddWithValue("@TIPO", Tipo)
        comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        comando.Parameters.AddWithValue("@VALOR", Valor)
        Dim adaptador As New SqlDataAdapter(comando)
        dtEntradaAlmacenCancelada.Clear()
        Try
            conexion.Open()
            adaptador.Fill(dtEntradaAlmacenCancelada)
            conexion.Close()
            Me.DGV_Lista.DataSource = Nothing
            Me.DGV_Lista.DataSource = dtEntradaAlmacenCancelada
            Me.DGV_Lista.AutoGenerateColumns = True
            Me.DGV_Lista.ContextMenuStrip = Me.Cms_Ordenar
            Me.Lb_Cargado.Text = "ENTRADAS DE ALMACÉN CANCELADA"
            Me.Lb_Movimiento.Text = "Lista de " & dtEntradaAlmacenCancelada.Rows.Count.ToString & " Entradas de Almacén Cancelada"
            DGV_ListaItem.ContextMenuStrip = Cms_CancelarItem
            Me.DGV_Lista.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.DGV_Lista.ReadOnly = True
            Me.dt_opcionesfiltro1.Rows.Clear()
            Me.dt_opcionesfiltro2.Rows.Clear()
            Me.dt_opcionesfiltro3.Rows.Clear()
            Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()
            For i = 0 To DGV_Lista.ColumnCount - 1
                DGV_Lista.Columns(i).Visible = True
                Dim filaopciónfiltro1 As DataRow
                Dim filaopciónfiltro2 As DataRow
                Dim filaopciónfiltro3 As DataRow
                filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
                filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
                filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
                filaopciónfiltro1("OPCION") = DGV_Lista.Columns(i).Name
                filaopciónfiltro2("OPCION") = DGV_Lista.Columns(i).Name
                filaopciónfiltro3("OPCION") = DGV_Lista.Columns(i).Name
                dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
                dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
                dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
                Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
                Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_Lista.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
                Submenuitem.Name = DGV_Lista.Columns(i).Name
                Submenuitem.Size = New System.Drawing.Size(152, 22)
                Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})
                Select Case DGV_Lista.Columns(i).Name
                    Case "Id"
                        DGV_Lista.Columns(i).Width = 50
                    Case "Entrada"
                        DGV_Lista.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                        DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Case "Tipo"
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_Lista.Columns(i).Width = 40
                    Case "Bodega"
                        DGV_Lista.Columns(i).Width = 80
                    Case "Recibio"
                        DGV_Lista.Columns(i).Width = 200
                    Case "Remisión"
                        DGV_Lista.Columns(i).Width = 100
                    Case "Tipo Cancelacion"
                        DGV_Lista.Columns(i).Width = 100
                    Case "Servidor"
                        DGV_Lista.Columns(i).Width = 45
                        DGV_Lista.Columns(i).ToolTipText = "Subido al Servidor"
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case Else
                        DGV_Lista.Columns(i).Visible = False
                End Select
            Next
            Me.DGV_ListaItem.DataSource = Nothing
            CargarItems()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    Private Sub Nbi_CargarSalidaAlmacen_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarSalidaAlmacen.ItemClick
        CargarSalidasAlmacén(1, "")
    End Sub


    Private Sub CargarSalidasAlmacén(ByVal Tipo As Integer, ByVal IDENTIFICACION As String)
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Lb_Movimiento.Text = "Lista de Salida de Almacén"
        Lb_Filtro.Text = "Salida de Almacén"
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListaSalidaAlmacén(@TIPO, @IDBODEGA, @IDENTIFICACION)", conexion)
        comando.Parameters.AddWithValue("@TIPO", Tipo)
        comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        comando.Parameters.AddWithValue("@IDENTIFICACION", IDENTIFICACION)
        Dim adaptador As New SqlDataAdapter(comando)
        dtSalidaAlmacen.Clear()
        Try
            conexion.Open()
            adaptador.Fill(dtSalidaAlmacen)
            conexion.Close()
            Me.DGV_Lista.DataSource = Nothing
            Me.DGV_Lista.DataSource = dtSalidaAlmacen
            Me.DGV_Lista.AutoGenerateColumns = True
            Me.DGV_Lista.ContextMenuStrip = Me.Cms_Ordenar
            TablaCargada = Tabla.Salida
            Me.Lb_Movimiento.Text = "Lista de " & dtSalidaAlmacen.Rows.Count.ToString & " Salidas de Almacén"
            Me.Lb_Cargado.Text = "SALIDAS DE ALMACÉN"
            DGV_ListaItem.ContextMenuStrip = Cms_CancelarItem
            Me.DGV_Lista.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.DGV_Lista.ReadOnly = True
            Me.dt_opcionesfiltro1.Rows.Clear()
            Me.dt_opcionesfiltro2.Rows.Clear()
            Me.dt_opcionesfiltro3.Rows.Clear()
            Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()
            For i = 0 To DGV_Lista.ColumnCount - 1
                Dim filaopciónfiltro1 As DataRow
                Dim filaopciónfiltro2 As DataRow
                Dim filaopciónfiltro3 As DataRow
                filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
                filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
                filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
                filaopciónfiltro1("OPCION") = DGV_Lista.Columns(i).Name
                filaopciónfiltro2("OPCION") = DGV_Lista.Columns(i).Name
                filaopciónfiltro3("OPCION") = DGV_Lista.Columns(i).Name
                dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
                dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
                dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
                Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
                Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_Lista.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
                Submenuitem.Name = DGV_Lista.Columns(i).Name
                Submenuitem.Size = New System.Drawing.Size(152, 22)
                Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})
                DGV_Lista.Columns(i).Visible = True
                Select Case DGV_Lista.Columns(i).Name
                    Case "Id"
                        DGV_Lista.Columns(i).Width = 50
                    Case "Salida"
                        DGV_Lista.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                        DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Case "Tipo"
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_Lista.Columns(i).Width = 50
                    Case "Bodega"
                        DGV_Lista.Columns(i).Width = 100
                    Case "Bodega Destino"
                        DGV_Lista.Columns(i).Width = 200
                    Case "Despacho"
                        DGV_Lista.Columns(i).Width = 190
                    Case "Cancelada"
                        DGV_Lista.Columns(i).Width = 100
                    Case "Servidor"
                        DGV_Lista.Columns(i).Width = 45
                        DGV_Lista.Columns(i).ToolTipText = "Subido al Servidor"
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case Else
                        DGV_Lista.Columns(i).Visible = False
                End Select
            Next
            Me.Pn_ContenedorItems.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)
            Try
                Me.DGV_Lista.Rows(0).Selected = True
                CargarListaxSeleccion()
            Catch ex As Exception

            End Try
            Me.DGV_ListaItem.DataSource = Nothing
            CargarItems()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub CargarSalidasAlmacénFiltro(ByVal dsTabla As DataSet)
        Lb_Movimiento.Text = "Lista de Salida de Almacén"
        Lb_Filtro.Text = "Salida de Almacén"
        Me.DGV_Lista.DataSource = Nothing
        Me.DGV_Lista.DataSource = dsTabla.Tables(0).DefaultView
        Me.DGV_Lista.AutoGenerateColumns = True
        Me.DGV_Lista.ContextMenuStrip = Me.Cms_Ordenar
        TablaCargada = Tabla.Salida
        Me.Lb_Cargado.Text = "SALIDAS DE ALMACÉN"
        DGV_ListaItem.ContextMenuStrip = Cms_CancelarItem
        Me.DGV_Lista.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_Lista.ReadOnly = True
        Me.dt_opcionesfiltro1.Rows.Clear()
        Me.dt_opcionesfiltro2.Rows.Clear()
        Me.dt_opcionesfiltro3.Rows.Clear()
        Me.OrdenarPorToolStripMenuItem.DropDownItems.Clear()
        For i = 0 To DGV_Lista.ColumnCount - 1
            Dim filaopciónfiltro1 As DataRow
            Dim filaopciónfiltro2 As DataRow
            Dim filaopciónfiltro3 As DataRow
            filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
            filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
            filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
            filaopciónfiltro1("OPCION") = DGV_Lista.Columns(i).Name
            filaopciónfiltro2("OPCION") = DGV_Lista.Columns(i).Name
            filaopciónfiltro3("OPCION") = DGV_Lista.Columns(i).Name
            dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
            dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
            dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
            Dim Submenuitem As System.Windows.Forms.ToolStripMenuItem
            Submenuitem = New System.Windows.Forms.ToolStripMenuItem(DGV_Lista.Columns(i).Name, Nothing, AddressOf MostrarNombreMenu)
            Submenuitem.Name = DGV_Lista.Columns(i).Name
            Submenuitem.Size = New System.Drawing.Size(152, 22)
            Me.OrdenarPorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Submenuitem})
            DGV_Lista.Columns(i).Visible = True
            Select Case DGV_Lista.Columns(i).Name
                Case "Id"
                    DGV_Lista.Columns(i).Width = 50
                Case "Salida"
                    DGV_Lista.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Tipo"
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_Lista.Columns(i).Width = 50
                Case "Bodega"
                    DGV_Lista.Columns(i).Width = 100
                Case "Bodega Destino"
                    DGV_Lista.Columns(i).Width = 200
                Case "Despacho"
                    DGV_Lista.Columns(i).Width = 190
                Case "Cancelada"
                    DGV_Lista.Columns(i).Width = 100
                Case "Servidor"
                    DGV_Lista.Columns(i).Width = 45
                    DGV_Lista.Columns(i).ToolTipText = "Subido al Servidor"
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    DGV_Lista.Columns(i).Visible = False
            End Select
        Next
        Me.Pn_ContenedorItems.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)
        Try
            Me.DGV_Lista.Rows(0).Selected = True
            CargarListaxSeleccion()
        Catch ex As Exception

        End Try
        Me.DGV_ListaItem.DataSource = Nothing
        CargarItems()
    End Sub


    Private Sub Nbi_CargarBodegas_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarBodegas.ItemClick
        CargarBodega()
    End Sub


    Private Sub Nbi_VerEntradasCanceladas_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargarEntradasCanceladas(0)
    End Sub


    Private Sub CargarBodega()
        Cursor = Cursors.WaitCursor
        DGV_ListaItem.DataSource = Nothing
        DGV_Lista.DataSource = Nothing
        Dim dsBodegas As New DataSet
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ListarBodegas", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@Where", "")
        comando.Parameters.AddWithValue("@IdPersona", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@AccionEspecial", 1)
        comando.Parameters.AddWithValue("@Top", 500)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dsBodegas)
            conexion.Close()
            vistabodegaactiva = New DataView(dsBodegas.Tables(1))
            vistabodegaactiva.RowFilter = "ESTADO = 'A'"
            vistabodegainactiva = New DataView(dsBodegas.Tables(1))
            vistabodegainactiva.RowFilter = "ESTADO = 'I'"
            Lb_Movimiento.Text = "Lista de Bodega Activas"
            Lb_Filtro.Text = "Bodega"
            Me.DGV_Lista.DataSource = Nothing
            Me.DGV_Lista.DataSource = Me.vistabodegaactiva
            Me.DGV_Lista.AutoGenerateColumns = True
            Lb_MovimientoDos.Text = "Lista de Bodegas Inactivas"
            Me.DGV_ListaItem.DataSource = Me.vistabodegainactiva
            Me.DGV_ListaItem.AutoGenerateColumns = True
            Me.DGV_Lista.ContextMenuStrip = Nothing
            TablaCargada = Tabla.Bodega
            Me.Lb_Cargado.Text = "BODEGAS"
            DGV_ListaItem.ContextMenuStrip = Cms_BodegasInactivas
            Me.DGV_Lista.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.DGV_ListaItem.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DGV_Lista.ReadOnly = True
            Me.dt_opcionesfiltro1.Rows.Clear()
            Me.dt_opcionesfiltro2.Rows.Clear()
            Me.dt_opcionesfiltro3.Rows.Clear()
            For i = 0 To DGV_Lista.ColumnCount - 1
                DGV_Lista.Columns(i).Visible = True
                Dim filaopciónfiltro1 As DataRow
                Dim filaopciónfiltro2 As DataRow
                Dim filaopciónfiltro3 As DataRow
                filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
                filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
                filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
                filaopciónfiltro1("OPCION") = DGV_Lista.Columns(i).Name
                filaopciónfiltro2("OPCION") = DGV_Lista.Columns(i).Name
                filaopciónfiltro3("OPCION") = DGV_Lista.Columns(i).Name
                dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
                dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
                dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
                Select Case DGV_Lista.Columns(i).Name
                    Case "ID"
                        DGV_Lista.Columns(i).Width = 50
                        DGV_ListaItem.Columns(i).Width = 30
                    Case "NOMBRE"
                        DGV_Lista.Columns(i).Width = 150
                        DGV_ListaItem.Columns(i).Width = 150
                    Case "ABREVIATURA"
                        DGV_Lista.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                        DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Case "DIRRECION"
                        DGV_Lista.Columns(i).Width = 300
                        DGV_ListaItem.Columns(i).Width = 300
                    Case "CELULAR BODEGA"
                        DGV_Lista.Columns(i).Width = 100
                        DGV_ListaItem.Columns(i).Width = 100
                    Case "CELULAR COMPRA"
                        DGV_Lista.Columns(i).Width = 100
                        DGV_ListaItem.Columns(i).Width = 100
                    Case "Tipo Salida"
                        DGV_Lista.Columns(i).Width = 100
                        DGV_ListaItem.Columns(i).Width = 100
                    Case Else
                        DGV_Lista.Columns(i).Visible = False
                        DGV_ListaItem.Columns(i).Visible = False
                End Select
            Next
            Me.Pn_ContenedorItems.Height = CInt(Pn_ContenedorPrincipal.Height / 4)
            Me.DGV_ListaItem.ClearSelection()
            Try
                Me.DGV_Lista.Rows(0).Selected = True
                CargarListaxSeleccion()
            Catch ex As Exception

            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        Finally
            conexion.Close()
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub Nbi_CargarNoFinDestTB_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarNoFinDestTB.ItemClick
        Lb_Movimiento.Text = "Lista de traslados de bodega pendiente por ingresar a " & VariablesBase.VariablesBase.NombreBodegaActual
        CargarRemisiones(2)
    End Sub


    Private Sub Nbi_CargarTB_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarNoFinEnviaTB.ItemClick
        Lb_Movimiento.Text = "Lista de traslados de bodega pendiente por confirmar en la bodega de destino"
        CargarRemisiones(1)
    End Sub


    Private Sub CargarRemisiones(ByVal tipo As Integer)
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.DGV_Lista.DataSource = Nothing
        Lb_Filtro.Text = "Traslados"
        Dim datas As New DataSet
        Dim cmde As New SqlClient.SqlCommand
        Dim da As New SqlClient.SqlDataAdapter
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        sqlconeccion.Open()
        cmde.Parameters.Clear()
        cmde.CommandType = CommandType.StoredProcedure
        cmde.Connection = sqlconeccion
        cmde.CommandText = "dbo.ListarRemisionesPendientes"
        cmde.Parameters.Add("@IDpersona", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
        cmde.Parameters.Add("@IDbodegaActual", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBodegaActual
        cmde.Parameters.Add("@TipoConsulta", SqlDbType.Int).Value = tipo
        da = New SqlClient.SqlDataAdapter(cmde)
        datas = New DataSet()
        da.Fill(datas)
        sqlconeccion.Close()
        Me.DGV_Lista.DataSource = Nothing
        Me.DGV_Lista.DataSource = datas.Tables(0)
        Me.DGV_Lista.AutoGenerateColumns = True
        Me.DGV_Lista.ContextMenuStrip = Nothing
        TablaCargada = Tabla.NoLlegaron
        Me.Lb_Cargado.Text = "SALIDAS SIN CONFIRMAR INGRESO A BODEGA DESTINO"
        DGV_ListaItem.ContextMenuStrip = Cms_CancelarItem
        Me.DGV_Lista.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_Lista.ReadOnly = True
        Me.dt_opcionesfiltro1.Rows.Clear()
        Me.dt_opcionesfiltro2.Rows.Clear()
        Me.dt_opcionesfiltro3.Rows.Clear()
        For i = 0 To DGV_Lista.ColumnCount - 1
            DGV_Lista.Columns(i).Visible = True
            DGV_Lista.Columns(i).Visible = True
            DGV_Lista.Columns(i).Visible = True
            Dim filaopciónfiltro1 As DataRow
            Dim filaopciónfiltro2 As DataRow
            Dim filaopciónfiltro3 As DataRow
            filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
            filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
            filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
            filaopciónfiltro1("OPCION") = DGV_Lista.Columns(i).Name
            filaopciónfiltro2("OPCION") = DGV_Lista.Columns(i).Name
            filaopciónfiltro3("OPCION") = DGV_Lista.Columns(i).Name
            dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
            dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
            dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
            Select Case DGV_Lista.Columns(i).Name
                Case "Id"
                    DGV_Lista.Columns(i).Width = 50
                Case "Salida"
                    DGV_Lista.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Tipo"
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGV_Lista.Columns(i).Width = 50
                Case "Bodega"
                    DGV_Lista.Columns(i).Width = 100
                Case "Bodega Destino"
                    DGV_Lista.Columns(i).Width = 200
                Case "Despacho"
                    DGV_Lista.Columns(i).Width = 200
                Case "Fecha Despacho"
                    DGV_Lista.Columns(i).Width = 110
                Case "Requisición"
                    DGV_Lista.Columns(i).Width = 110
                Case "Orden Compra"
                    DGV_Lista.Columns(i).Width = 110
                Case Else
                    DGV_Lista.Columns(i).Visible = False
            End Select
        Next
        Me.Pn_ContenedorItems.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)
        Try
            Me.DGV_Lista.Rows(0).Selected = True
            CargarListaxSeleccion()
        Catch ex As Exception

        End Try
        CargarItems()
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub NBI_ConfirmadoDestino_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Digite la remisión que desea consultar")
        Me.DGV_Lista.DataSource = Nothing
        Lb_Movimiento.Text = "Lista de traslados de bodega confirmado en la bodega de destino"
        Lb_Filtro.Text = "Traslados"
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListaSalidaAlmacén(@TIPO, @IDBODEGA, @IDENTIFICACION)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 8)
        comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        comando.Parameters.AddWithValue("@IDENTIFICACION", "")
        Dim adaptador As New SqlDataAdapter(comando)
        dtSalidaAlmacen.Clear()
        Try
            conexion.Open()
            adaptador.Fill(dtSalidaAlmacen) 'Me.DsSalidaAlmacén.LISTASALIDAALMACEN)
            conexion.Close()
            DGV_Lista.DataSource = Nothing
            Me.DGV_Lista.DataSource = dtSalidaAlmacen 'Me.DsSalidaAlmacén.LISTASALIDAALMACEN
            Me.DGV_Lista.AutoGenerateColumns = True
            Me.DGV_ListaItem.DataSource = Nothing
            Me.DGV_Lista.ContextMenuStrip = Nothing
            TablaCargada = Tabla.LLegaron
            Me.Lb_Cargado.Text = "SALIDAS CONFIRMADA INGRESO A BODEGA DESTINO"
            DGV_ListaItem.ContextMenuStrip = Cms_CancelarItem
            Me.DGV_Lista.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.DGV_Lista.ReadOnly = True
            Me.dt_opcionesfiltro1.Rows.Clear()
            Me.dt_opcionesfiltro2.Rows.Clear()
            Me.dt_opcionesfiltro3.Rows.Clear()
            For i = 0 To DGV_Lista.ColumnCount - 1
                DGV_Lista.Columns(i).Visible = True
                DGV_Lista.Columns(i).Visible = True
                DGV_Lista.Columns(i).Visible = True
                Dim filaopciónfiltro1 As DataRow
                Dim filaopciónfiltro2 As DataRow
                Dim filaopciónfiltro3 As DataRow
                filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
                filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
                filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
                filaopciónfiltro1("OPCION") = DGV_Lista.Columns(i).Name
                filaopciónfiltro2("OPCION") = DGV_Lista.Columns(i).Name
                filaopciónfiltro3("OPCION") = DGV_Lista.Columns(i).Name
                dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
                dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
                dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
                Select Case DGV_Lista.Columns(i).Name
                    Case "Id"
                        DGV_Lista.Columns(i).Width = 50
                    Case "Salida"
                        DGV_Lista.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                        DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Case "Tipo"
                        DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DGV_Lista.Columns(i).Width = 50
                    Case "Bodega"
                        DGV_Lista.Columns(i).Width = 100
                    Case "Bodega Destino"
                        DGV_Lista.Columns(i).Width = 200
                    Case "Despacho"
                        DGV_Lista.Columns(i).Width = 200
                    Case Else
                        DGV_Lista.Columns(i).Visible = False
                End Select
            Next
            Me.Pn_ContenedorItems.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)
            Try
                Me.DGV_Lista.Rows(0).Selected = True
                CargarListaxSeleccion()
            Catch ex As Exception

            End Try
            CargarItems()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    Private Sub Nbi_VerRemisiones_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TablaCargada = Tabla.Remision
        Me.DGV_ListaItem.DataSource = Nothing
        Lb_Movimiento.Text = "Lista de remisiones asociadas a la bodega"
        Lb_Filtro.Text = "Remisiones"
        Me.ListaRemisionesTableAdapter.Fill(Me.DsBodega.ListaRemisiones, 5, VariablesBase.VariablesBase.IdBodegaActual, 1)
        DGV_Lista.DataSource = Nothing
        Me.DGV_Lista.DataSource = Me.DsBodega.ListaRemisiones
        Me.DGV_Lista.AutoGenerateColumns = True
        Me.DGV_Lista.ContextMenuStrip = Nothing
        Me.Lb_Cargado.Text = "REMISIONES"
        DGV_ListaItem.ContextMenuStrip = Cms_CancelarItem
        Me.DGV_Lista.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_Lista.ReadOnly = True
        Me.dt_opcionesfiltro1.Rows.Clear()
        Me.dt_opcionesfiltro2.Rows.Clear()
        Me.dt_opcionesfiltro3.Rows.Clear()
        For i = 0 To DGV_Lista.ColumnCount - 1
            DGV_Lista.Columns(i).Visible = True
            DGV_Lista.Columns(i).Visible = True
            DGV_Lista.Columns(i).Visible = True
            Dim filaopciónfiltro1 As DataRow
            Dim filaopciónfiltro2 As DataRow
            Dim filaopciónfiltro3 As DataRow
            filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
            filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
            filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
            filaopciónfiltro1("OPCION") = DGV_Lista.Columns(i).Name
            filaopciónfiltro2("OPCION") = DGV_Lista.Columns(i).Name
            filaopciónfiltro3("OPCION") = DGV_Lista.Columns(i).Name
            dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
            dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
            dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
            Select Case DGV_Lista.Columns(i).Name
                Case "Id"
                    DGV_Lista.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Requisición"
                    DGV_Lista.Columns(i).Width = 150
                Case "Orden de Compra"
                    DGV_Lista.Columns(i).Width = 150
                Case "Bodega Origen"
                    DGV_Lista.Columns(i).Width = 150
                Case "Destino"
                    DGV_Lista.Columns(i).Width = 150
                Case Else
                    DGV_Lista.Columns(i).Visible = False
            End Select
        Next
        Me.Pn_ContenedorItems.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)
        Try
            Me.DGV_Lista.Rows(0).Selected = True
            CargarListaxSeleccion()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CargarItems()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Try
            Select Case TablaCargada
                Case Tabla.Entrada
                    Pn_equiposasociados.Visible = True
                    If Trim(Me.DGV_Lista.Item("Cancelada", Me.DGV_Lista.CurrentCell.RowIndex).Value) = "Parcial" Or Trim(Me.DGV_Lista.Item("Cancelada", Me.DGV_Lista.CurrentCell.RowIndex).Value) = "" Then
                        'Dim adap As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.LISTAITEMENTRADAALMACENTableAdapter
                        'adap.FillIDENTRADAALMACEN(dtItemEntradaAlmacen, CInt(DGV_Lista.SelectedRows(0).Cells(0).Value)) 'Me.DsEntradaAlmacén.LISTAITEMENTRADAALMACEN
                        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                        Dim comando As New SqlCommand("SELECT * FROM Bodega_CargarItemsEA(@IDENTRADAALMACEN)", conexion)
                        comando.Parameters.AddWithValue("@IDENTRADAALMACEN", CInt(DGV_Lista.SelectedRows(0).Cells(0).Value))
                        Dim adaptador As New SqlDataAdapter(comando)
                        dtItemEntradaAlmacen.Clear()
                        Try
                            conexion.Open()
                            adaptador.Fill(dtItemEntradaAlmacen)
                            conexion.Close()
                            Me.DGV_ListaItem.DataSource = dtItemEntradaAlmacen 'Me.DsEntradaAlmacén.LISTAITEMENTRADAALMACEN
                            Me.Lb_MovimientoDos.Text = "Lista de Items asociados a la entrada de almacén"
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            conexion.Close()
                        End Try
                    Else
                        'Dim adap As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.LISTAITEMSENTRADAALMACENCANCELADATableAdapter
                        'adap.FillITEMSCANCELADOS(dtItemEntradaAlmacenCancelada, CInt(DGV_Lista.SelectedRows(0).Cells(0).Value)) 'Me.DsEntradaAlmacén.LISTAITEMSENTRADAALMACENCANCELADA
                        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                        Dim comando As New SqlCommand("SELECT * FROM Bodega_CargarItemsEACancelada(@IDENTRADAALMACEN)", conexion)
                        comando.Parameters.AddWithValue("@IDENTRADAALMACEN", CInt(DGV_Lista.SelectedRows(0).Cells(0).Value))
                        Dim adaptador As New SqlDataAdapter(comando)
                        dtItemEntradaAlmacenCancelada.Clear()
                        Try
                            conexion.Open()
                            adaptador.Fill(dtItemEntradaAlmacenCancelada)
                            conexion.Close()
                            Me.DGV_ListaItem.DataSource = dtItemEntradaAlmacenCancelada 'Me.DsEntradaAlmacén.LISTAITEMSENTRADAALMACENCANCELADA
                            Me.Lb_MovimientoDos.Text = "Lista de Items cancelados de la entrada de almacén"
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            conexion.Close()
                        End Try
                    End If
                Case Tabla.Bodega
                    Pn_equiposasociados.Visible = False
                Case Tabla.Salida
                    Pn_equiposasociados.Visible = True
                    If Trim(Me.DGV_Lista.Item("Cancelada", Me.DGV_Lista.CurrentCell.RowIndex).Value) = "Parcial" Or Trim(Me.DGV_Lista.Item("Cancelada", Me.DGV_Lista.CurrentCell.RowIndex).Value) = "" Then
                        'Dim adap As New DatosSalidaAlmacén.Ds_SalidaAlmacénTableAdapters.LISTAITEMSALIDAALMACENTableAdapter
                        'adap.FillIDSALIDAALMACEN(dtItemSalidaAlmacen, CInt(DGV_Lista.SelectedRows(0).Cells(0).Value)) 'Me.DsSalidaAlmacén.LISTAITEMSALIDAALMACEN
                        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                        Dim comando As New SqlCommand("SELECT * FROM Bodega_CargarItemsSA(@IDSALIDAALMACEN)", conexion)
                        comando.Parameters.AddWithValue("@IDSALIDAALMACEN", CInt(DGV_Lista.SelectedRows(0).Cells(0).Value))
                        Dim adaptador As New SqlDataAdapter(comando)
                        dtItemSalidaAlmacen.Clear()
                        Try
                            conexion.Open()
                            adaptador.Fill(dtItemSalidaAlmacen)
                            conexion.Close()
                            Me.DGV_ListaItem.DataSource = dtItemSalidaAlmacen 'Me.DsSalidaAlmacén.LISTAITEMSALIDAALMACEN
                            Me.Lb_MovimientoDos.Text = "Lista de Items asociados a la salida de almacén"
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            conexion.Close()
                        End Try
                    Else
                        'Dim adap As New DatosSalidaAlmacén.Ds_SalidaAlmacénTableAdapters.LISTAITEMSALIDAALMACENCANCELADATableAdapter
                        'adap.FillCancelado(dtItemSalidaAlmacenCancelada, CInt(DGV_Lista.SelectedRows(0).Cells(0).Value)) 'Me.DsSalidaAlmacén.LISTAITEMSALIDAALMACENCANCELADA
                        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                        Dim comando As New SqlCommand("SELECT * FROM Bodega_CargarItemsSACancelada(@IDSALIDAALMACEN)", conexion)
                        comando.Parameters.AddWithValue("@IDSALIDAALMACEN", CInt(DGV_Lista.SelectedRows(0).Cells(0).Value))
                        Dim adaptador As New SqlDataAdapter(comando)
                        dtItemSalidaAlmacenCancelada.Clear()
                        Try
                            conexion.Open()
                            adaptador.Fill(dtItemSalidaAlmacenCancelada)
                            conexion.Close()
                            Me.DGV_ListaItem.DataSource = dtItemSalidaAlmacenCancelada 'Me.DsSalidaAlmacén.LISTAITEMSALIDAALMACENCANCELADA
                            Me.Lb_MovimientoDos.Text = "Lista de Items cancelados de la salida de almacén"
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            conexion.Close()
                        End Try
                    End If
                Case Tabla.Remision
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("SELECT * FROM Bodega_CargarItemsSA(@IDSALIDAALMACEN)", conexion)
                    comando.Parameters.AddWithValue("@IDSALIDAALMACEN", CInt(DGV_Lista.SelectedRows(0).Cells(0).Value))
                    Dim adaptador As New SqlDataAdapter(comando)
                    dtItemSalidaAlmacen.Clear()
                    Try
                        conexion.Open()
                        adaptador.Fill(dtItemSalidaAlmacen)
                        conexion.Close()
                        Me.DGV_ListaItem.DataSource = dtItemSalidaAlmacen 'Me.DsSalidaAlmacén.LISTAITEMSALIDAALMACEN
                        Me.Lb_MovimientoDos.Text = "Lista de Items asociados a la salida de almacén"
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conexion.Close()
                    End Try
                Case Tabla.NoFinalizadas, Tabla.NoLlegaron
                    Pn_equiposasociados.Visible = True
                    'Dim adap As New DatosSalidaAlmacén.Ds_SalidaAlmacénTableAdapters.LISTAITEMSALIDAALMACENTableAdapter
                    'adap.FillIDSALIDAALMACEN(dtItemSalidaAlmacen, CInt(DGV_Lista.SelectedRows(0).Cells(0).Value)) 'Me.DsSalidaAlmacén.LISTAITEMSALIDAALMACEN
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("SELECT * FROM Bodega_CargarItemsSA(@IDSALIDAALMACEN)", conexion)
                    comando.Parameters.AddWithValue("@IDSALIDAALMACEN", CInt(DGV_Lista.SelectedRows(0).Cells(0).Value))
                    Dim adaptador As New SqlDataAdapter(comando)
                    dtItemSalidaAlmacen.Clear()
                    Try
                        conexion.Open()
                        adaptador.Fill(dtItemSalidaAlmacen)
                        conexion.Close()
                        Me.DGV_ListaItem.DataSource = dtItemSalidaAlmacen 'Me.DsSalidaAlmacén.LISTAITEMSALIDAALMACEN
                        Me.Lb_MovimientoDos.Text = "Lista de Items asociados al traslado de bodega"
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conexion.Close()
                    End Try
                Case Tabla.Finalizadas, Tabla.LLegaron
                    Pn_equiposasociados.Visible = True
                    'Dim adap As New DatosSalidaAlmacén.Ds_SalidaAlmacénTableAdapters.LISTAITEMSALIDAALMACENTableAdapter
                    'adap.FillIDSALIDAALMACEN(dtItemSalidaAlmacen, CInt(DGV_Lista.SelectedRows(0).Cells(0).Value)) 'Me.DsSalidaAlmacén.LISTAITEMSALIDAALMACEN
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("SELECT * FROM Bodega_CargarItemsSA(@IDSALIDAALMACEN)", conexion)
                    comando.Parameters.AddWithValue("@IDSALIDAALMACEN", CInt(DGV_Lista.SelectedRows(0).Cells(0).Value))
                    Dim adaptador As New SqlDataAdapter(comando)
                    dtItemSalidaAlmacen.Clear()
                    Try
                        conexion.Open()
                        adaptador.Fill(dtItemSalidaAlmacen)
                        conexion.Close()
                        Me.DGV_ListaItem.DataSource = dtItemSalidaAlmacen 'Me.DsSalidaAlmacén.LISTAITEMSALIDAALMACEN
                        Me.Lb_MovimientoDos.Text = "Lista de Items asociados al traslado de bodega"
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conexion.Close()
                    End Try
                Case Tabla.EntradaCancelada
                    Pn_equiposasociados.Visible = True
                    'Dim adap As New DatosEntradaAlmacén.Ds_EntradaAlmacénTableAdapters.LISTAITEMSENTRADAALMACENCANCELADATableAdapter
                    'adap.FillITEMSCANCELADOS(dtItemEntradaAlmacenCancelada, CInt(DGV_Lista.SelectedRows(0).Cells(0).Value)) 'Me.DsEntradaAlmacén.LISTAITEMSENTRADAALMACENCANCELADA
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("SELECT * FROM Bodega_CargarItemsEACancelada(@IDENTRADAALMACEN)", conexion)
                    comando.Parameters.AddWithValue("@IDENTRADAALMACEN", CInt(DGV_Lista.SelectedRows(0).Cells(0).Value))
                    Dim adaptador As New SqlDataAdapter(comando)
                    dtItemEntradaAlmacenCancelada.Clear()
                    Try
                        conexion.Open()
                        adaptador.Fill(dtItemEntradaAlmacenCancelada)
                        conexion.Close()
                        Me.DGV_ListaItem.DataSource = dtItemEntradaAlmacenCancelada 'Me.DsEntradaAlmacén.LISTAITEMSENTRADAALMACENCANCELADA
                        Me.Lb_MovimientoDos.Text = "Lista de Items cancelados de la entrada de almacén"
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conexion.Close()
                    End Try
                Case Tabla.SalidaCancelada
                    Pn_equiposasociados.Visible = True
                    'Dim adap As New DatosSalidaAlmacén.Ds_SalidaAlmacénTableAdapters.LISTAITEMSALIDAALMACENCANCELADATableAdapter
                    'adap.FillCancelado(dtItemSalidaAlmacenCancelada, CInt(DGV_Lista.SelectedRows(0).Cells(0).Value)) 'Me.DsSalidaAlmacén.LISTAITEMSALIDAALMACENCANCELADA
                    Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                    Dim comando As New SqlCommand("SELECT * FROM Bodega_CargarItemsSACancelada(@IDSALIDAALMACEN)", conexion)
                    comando.Parameters.AddWithValue("@IDSALIDAALMACEN", CInt(DGV_Lista.SelectedRows(0).Cells(0).Value))
                    Dim adaptador As New SqlDataAdapter(comando)
                    dtItemSalidaAlmacenCancelada.Clear()
                    Try
                        conexion.Open()
                        adaptador.Fill(dtItemSalidaAlmacenCancelada)
                        conexion.Close()
                        Me.DGV_ListaItem.DataSource = dtItemSalidaAlmacenCancelada 'Me.DsSalidaAlmacén.LISTAITEMSALIDAALMACENCANCELADA
                        Me.Lb_MovimientoDos.Text = "Lista de Items cancelados de la salida de almacén"
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conexion.Close()
                    End Try

            End Select

            For i = 0 To DGV_ListaItem.ColumnCount - 1
                Select Case DGV_ListaItem.Columns(i).Name
                    Case "IDREMISION", "IDREQUISICION", "IDORDENCOMPRA", "IDBODEGA", "IDSALIDAALMACEN", "ValidarCant", "PENDIENTE"
                        DGV_ListaItem.Columns(i).Visible = False
                End Select
            Next
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub


    Private Sub DGV_Lista_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_Lista.CellDoubleClick
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            Editar()
        End If
    End Sub


    Private Sub CargarListaxSeleccion()
        Try
            Select Case TablaCargada
                Case Tabla.Entrada, Tabla.EntradaCancelada
                    Dim xx As New Entrada(Me.DGV_Lista.Rows(DGV_Lista.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                Case Tabla.Salida, Tabla.NoLlegaron, Tabla.NoFinalizadas, Tabla.SalidaCancelada, Tabla.LLegaron, Tabla.Finalizadas
                    Dim xx As New Salida(Me.DGV_Lista.Rows(DGV_Lista.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                Case Tabla.Bodega
                    Dim xx As New Bodega(Me.DGV_Lista.Rows(DGV_Lista.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                Case Tabla.Remision
                    Dim xx As New Remisión(Me.DGV_Lista.Rows(DGV_Lista.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
            End Select
            CargarItems()
            CargarEquipos()
        Catch ex As Exception
            Pg_DetalleLista.SelectedObject = Nothing
        End Try
    End Sub


    Private Sub CargarEquipos()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        'Declaro la cadena de conexión
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim id As Int64
        id = CInt(DGV_Lista.SelectedRows(0).Cells(0).Value)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarEquipos"
            cmde.Parameters.Add("@idproveedor", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idarticulo", SqlDbType.BigInt).Value = id
            cmde.Parameters.Add("@idequipo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idtipo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idsubtipo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idestado", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idequipopadre", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idbodegaingreso", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idpersonaingreso", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idpersonaregistro", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idpersonaactual", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idmodelo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idmarca", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idbodega", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@descripcionequipo", SqlDbType.Text).Value = ""
            cmde.Parameters.Add("@codigoismocol", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@codigoaccess", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@codigomecanico", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@activo", SqlDbType.Bit).Value = 0
            cmde.Parameters.Add("@fechaingreso", SqlDbType.Date).Value = Date.Now
            Select Case TablaCargada
                Case Tabla.Entrada
                    cmde.Parameters.Add("@accion", SqlDbType.Int).Value = 41
                Case Tabla.Salida, Tabla.NoLlegaron, Tabla.Remision
                    cmde.Parameters.Add("@accion", SqlDbType.Int).Value = 40
                Case Tabla.Bodega
                    cmde.Parameters.Add("@accion", SqlDbType.Int).Value = 2
            End Select
            da = New SqlClient.SqlDataAdapter(cmde)
            datasequipos = New DataSet()
            da.Fill(datasequipos)
            sqlconeccion.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()
        End Try
        Windows.Forms.Cursor.Current = Cursors.Default
        Me.DGV_Equipos.DataSource = datasequipos.Tables(0)
        For i = 0 To DGV_Equipos.ColumnCount - 1
            Select Case DGV_Equipos.Columns(i).Name
                Case "IDEQUIPO"
                    DGV_Equipos.Columns(i).Width = 50
                    DGV_Equipos.Columns(i).HeaderText = "ID"
                Case "CODIGO"
                    DGV_Equipos.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    DGV_Equipos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_Equipos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "SERIE"
                    DGV_Equipos.Columns(i).Width = 120
                Case Else
                    DGV_Equipos.Columns(i).Visible = False
            End Select
        Next
    End Sub


    Private Sub FiltrarEquiposXCódigoArticuloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltrarEquiposXCódigoArticuloToolStripMenuItem.Click
        Dim vista As New DataView(datasequipos.Tables(0))
        vista.RowFilter = "IDARTICULO = " & Me.DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("Código").Value.ToString
        Me.DGV_Equipos.DataSource = vista
    End Sub


    Private Sub DGV_Lista_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV_Lista.SelectionChanged
        CargarListaxSeleccion()
    End Sub

#End Region

#Region "Crear"
    Private Sub Nbi_CrearEA_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearEA.ItemClick
        Dim FrEntradaAlmacen As New EntradaAlmacén.Fr_EntradaAlmacen
        FrEntradaAlmacen.CargarDatos()
        FrEntradaAlmacen.ShowDialog()
        CargarEntradaAlmacén(1)
    End Sub


    Private Sub Nbi_CrearBodega_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearBodega.ItemClick
        Dim FrBodega As New Bodegas.Fr_Bodega
        FrBodega.CargarDatos()
        FrBodega.ShowDialog()
        CargarBodega()
    End Sub
#End Region

#Region "Editar"
    Private Sub Nbi_ModificarBodega_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ModificarBodega.ItemClick
        If TablaCargada = Tabla.Bodega Then
            Editar()
        Else
            MsgBox("No esta cargada la tabla de Bodegas")
        End If
    End Sub


    Private Sub Nbi_EditarEA_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarEA.ItemClick
        If TablaCargada = Tabla.Entrada Then
            Editar()
        Else
            MsgBox("No esta cargada la tabla de Entradas de Almacén")
        End If
    End Sub


    Private Sub Nbi_EditarSA_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarSA.ItemClick
        If TablaCargada = Tabla.Salida Then
            Editar()
        Else
            MsgBox("No esta cargada la tabla de Salidas de Almacén")
        End If
    End Sub


    Private Sub Editar()
        Index_Registro_Actual = DGV_Lista.CurrentRow.Index
        If DGV_Lista.SelectedRows.Count > 0 Then

            Select Case TablaCargada
                Case Tabla.Entrada
                    If Me.DGV_Lista.Item("IMPRESA", Me.DGV_Lista.CurrentCell.RowIndex).Value = "N" Then
                        EditarEntradaAlmacen()
                    Else
                        MsgBox("La entrada de almacén " & Trim(Me.DGV_Lista.Item("Entrada", Me.DGV_Lista.CurrentCell.RowIndex).Value) & " ya fue impresa y no se puede editar.", vbCritical, "Editar Entrada")
                        Exit Sub
                    End If
                Case Tabla.Bodega
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ModificarBodega.Tag) Then
                        Dim FrBodega As New Bodegas.Fr_Bodega
                        FrBodega.EditandoBodega = True
                        FrBodega.IdBodega = DGV_Lista.SelectedRows(0).Cells(0).Value
                        FrBodega.CargarDatos()
                        FrBodega.ShowDialog()
                        CargarBodega()
                    End If
                Case Tabla.Salida
                    If Me.DGV_Lista.Item("IMPRESA", Me.DGV_Lista.CurrentCell.RowIndex).Value = "N" Then
                        EditarSalidaAlmacen()
                    Else
                        MsgBox("La salida de almacén " & Trim(Me.DGV_Lista.Item("Salida", Me.DGV_Lista.CurrentCell.RowIndex).Value) & " ya fue impresa y no se puede editar.", vbCritical, "Editar Salida")
                        Exit Sub
                    End If

            End Select
        End If
        UbicarRegistros()
    End Sub


    Private Sub EditarEntradaAlmacen()
        Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
        Dim EditarEA As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarEA.Tag) = True Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso("374") = True Then
                'Puede editar cualquier Entrada de Almacén.
                EditarEA = True
            Else
                If FuncionesBase.FuncionesBase.ConsultarPermiso("373") = True Then
                    'Si tiene permisos para editar las Entradas de Almacén de las bases,
                    'preguntar si la EA pertenece a la base del usuario.
                    Dim IDBodegaOC As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                    If IDBodegaOC = VariablesBase.VariablesBase.IdBodegaActual Then
                        EditarEA = True
                    Else
                        EditarEA = False
                    End If
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("372") = True Then
                        Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDPERSONAREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
                        If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                            EditarEA = True
                        Else
                            EditarEA = False
                        End If
                    Else
                        EditarEA = False
                    End If
                End If
            End If
        End If
        If EditarEA = True Then
            Dim FrEntradaAlmacen As New EntradaAlmacén.Fr_EntradaAlmacen
            FrEntradaAlmacen.Editando = True
            FrEntradaAlmacen.IDENTRADAALMACENMODIFICANDO = DGV_Lista.SelectedRows(0).Cells(0).Value
            FrEntradaAlmacen.EditarEquipos = "EDITAR"
            FrEntradaAlmacen.CargarDatos()
            FrEntradaAlmacen.Text = "Editando la Entrada de Almacén:   " & Me.DGV_Lista.SelectedRows(0).Cells("Entrada").Value
            FrEntradaAlmacen.ShowDialog()
        Else
            MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
        End If
        UbicarRegistros()
    End Sub


    Private Sub EditarSalidaAlmacen()
        Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
        Dim EditarSA As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarSA.Tag) = True Then
            If FuncionesBase.FuncionesBase.ConsultarPermiso("377") = True Then
                'Puede editar cualquier Salida de Almacén.
                EditarSA = True
            Else
                If FuncionesBase.FuncionesBase.ConsultarPermiso("376") = True Then
                    'Si tiene permisos para editar las Salidas de Almacén de las bases,
                    'preguntar si la SA pertenece a la base del usuario.
                    Dim IDBodegaOC As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                    If IDBodegaOC = VariablesBase.VariablesBase.IdBodegaActual Then
                        EditarSA = True
                    Else
                        EditarSA = False
                    End If
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("375") = True Then
                        Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDUSUARIOREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
                        If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                            EditarSA = True
                        Else
                            EditarSA = False
                        End If
                    Else
                        EditarSA = False
                    End If
                End If
            End If
        End If
        If EditarSA = True Then
            Dim FrSalidaAlmacen As New SalidaAlmacén.Fr_SalidaAlmacen
            FrSalidaAlmacen.Editando = True
            FrSalidaAlmacen.IDSALIDAALMACENMODIFICANDO = DGV_Lista.SelectedRows(0).Cells(0).Value
            FrSalidaAlmacen.EditarEquipos = "EDITAR"
            FrSalidaAlmacen.CargarDatos()
            FrSalidaAlmacen.Text = "Editando la Salida de Almacén:   " & Me.DGV_Lista.SelectedRows(0).Cells("Salida").Value
            FrSalidaAlmacen.ShowDialog()
        Else
            MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
        End If
        UbicarRegistros()
    End Sub
#End Region

#Region "Imprimir"
    Private Sub Nbi_ImprimirEntradaAlmacen_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ImprimirEntradaAlmacen.ItemClick
        If TablaCargada = Tabla.Entrada Or TablaCargada = Tabla.EntradaCancelada Then
            IMPRIMIR(TablaCargada)
        Else
            MsgBox("No esta cargada la tabla de Entradas de Almacén")
        End If
    End Sub


    Private Sub Nbi_HabilitarImpresionEntrada_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_HabilitarImpresionEntrada.ItemClick
        If TablaCargada = Tabla.Entrada Or TablaCargada = Tabla.EntradaCancelada Then
            HabilitarImpresion()
        Else
            MsgBox("No esta cargada la tabla de Entradas de Almacén")
        End If
    End Sub


    Private Sub Nbi_ImprimirEntradaAlmacenCancelada_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TablaCargada = Tabla.EntradaCancelada Then
            IMPRIMIR(TablaCargada)
        Else
            MsgBox("No esta cargada la tabla de Entradas de Almacén")
        End If
    End Sub


    Private Sub Nbi_ImprimirSalidaAlmacen_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ImprimirSalidaAlmacen.ItemClick
        If TablaCargada = Tabla.Salida Or TablaCargada = Tabla.SalidaCancelada Then
            IMPRIMIR(TablaCargada)
        Else
            MsgBox("No esta cargada la tabla de Salidas de Almacén")
        End If
    End Sub


    Private Sub Nbi_HabilitarImpresion_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_HabilitarImpresion.ItemClick
        If TablaCargada = Tabla.Salida Or TablaCargada = Tabla.SalidaCancelada Then
            HabilitarImpresion()
        Else
            MsgBox("No esta cargada la tabla de Salidas de Almacén")
        End If
    End Sub


    Private Sub Nbi_ImprimirSalidaCancelada_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TablaCargada = Tabla.SalidaCancelada Then
            IMPRIMIR(TablaCargada)
        Else
            MsgBox("No esta cargada la tabla de Salidas de Almacén")
        End If
    End Sub


    Private Sub Nbi_ImprimirRemisión_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ImprimirRemisión.ItemClick

        If TablaCargada = Tabla.Remision Or TablaCargada = Tabla.NoLlegaron Or TablaCargada = Tabla.Salida Then
            If IsDBNull(Me.DGV_Lista.SelectedRows(0).Cells("IdRemisión").Value) = False Then
                EsRemisionValorizada = False
                IMPRIMIR("REMISION")
            End If

        Else
            MsgBox("No esta cargada la tabla de Remisiones")
        End If
    End Sub


    Private Sub Nbi_ImprimirRemisiónValorizada_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirRemisiónValorizada.ItemClick
        If TablaCargada = Tabla.Remision Or TablaCargada = Tabla.NoLlegaron Or TablaCargada = Tabla.Salida Then
            If IsDBNull(Me.DGV_Lista.SelectedRows(0).Cells("IdRemisión").Value) = False Then
                EsRemisionValorizada = True
                IMPRIMIR("REMISION")
            End If
        Else
            MsgBox("No esta cargada la tabla de Remisiones")
        End If
    End Sub


    Private Sub IMPRIMIR(ByVal Tipo As String)
        If Me.DGV_Lista.SelectedRows.Count > 0 Then
            Index_Registro_Actual = DGV_Lista.CurrentRow.Index
            Select Case Tipo
                Case "ENTRADA"
                    If Me.DGV_Lista.Item("IMPRESA", Me.DGV_Lista.CurrentCell.RowIndex).Value = "N" Then
                        If MsgBox("¿Desea imprimir la Entrada de Almacén?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                            Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                            Dim Array As New ArrayList
                            Array.Add(64)
                            climpresiones.IDENTRADAALMACEN = Me.DGV_Lista.SelectedRows(0).Cells(0).Value

                            If Trim(Me.DGV_Lista.Item("Cancelada", Me.DGV_Lista.CurrentCell.RowIndex).Value) = "" Then
                                climpresiones.FormatoImprimirMateriales(Array, True, False)
                            Else
                                If Trim(Me.DGV_Lista.Item("Cancelada", Me.DGV_Lista.CurrentCell.RowIndex).Value) = "Parcial" Then
                                    climpresiones.FormatoImprimirMateriales(Array, True, False)
                                    climpresiones.CANCELACIONPARCIAL = True
                                Else
                                    climpresiones.CANCELACIONPARCIAL = False
                                End If
                                climpresiones.ENTRADACANCELADA = True
                                climpresiones.CargarDatasetEntradaAlmacen = True
                                If MsgBox("¿Desea imprimir las Cancelaciones asociadas?", MsgBoxStyle.YesNo, "Imprimir Cancelaciones") = MsgBoxResult.Yes Then
                                    climpresiones.FormatoImprimirMateriales(Array, True, False)
                                End If
                            End If

                            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                            CargarEntradaAlmacén(1)
                        End If
                    Else
                        MsgBox("La entrada de almacén " & Trim(Me.DGV_Lista.Item("Entrada", Me.DGV_Lista.CurrentCell.RowIndex).Value) & " ya fue impresa.", vbCritical, "Impresión Entrada")
                        Exit Sub
                    End If
                Case "SALIDA"
                    If Me.DGV_Lista.Item("IMPRESA", Me.DGV_Lista.CurrentCell.RowIndex).Value = "N" Then
                        If MsgBox("¿Desea imprimir la Salida de Almacén?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                            Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                            Dim Array As New ArrayList
                            Array.Add(66)
                            climpresiones.IDSALIDAALMACEN = Me.DGV_Lista.SelectedRows(0).Cells(0).Value
                            If Trim(Me.DGV_Lista.Item("Cancelada", Me.DGV_Lista.CurrentCell.RowIndex).Value) = "" Then
                                climpresiones.FormatoImprimirMateriales(Array, True, False)
                            Else
                                If Trim(Me.DGV_Lista.Item("Cancelada", Me.DGV_Lista.CurrentCell.RowIndex).Value) = "Parcial" Then
                                    climpresiones.FormatoImprimirMateriales(Array, True, False)
                                    climpresiones.CANCELACIONPARCIAL = True
                                Else
                                    climpresiones.CANCELACIONPARCIAL = False
                                End If
                                climpresiones.SALIDACANCELADA = True
                                If MsgBox("¿Desea imprimir las Cancelaciones asociadas?", MsgBoxStyle.YesNo, "Imprimir Cancelaciones") = MsgBoxResult.Yes Then
                                    climpresiones.FormatoImprimirMateriales(Array, True, False)
                                End If
                            End If
                            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                            Cargar_Tabla()
                        End If
                    Else
                        MsgBox("La salida de almacén " & Trim(Me.DGV_Lista.Item("Salida", Me.DGV_Lista.CurrentCell.RowIndex).Value) & " ya fue impresa", vbCritical, "Impresión Salida")
                        Exit Sub
                    End If
                Case "REMISION", "NoLLegaron"
                    If MsgBox("¿Desea imprimir la remisión", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                        Dim FrOpcionesImpresión As New ImpresiónMateriales.Fr_OpcionesImpresión
                        If EsRemisionValorizada = True Then
                            Dim FrArticulosSinValorReferencia As New FormulariosClasesBase.Fr_ArticulosSinValorReferencia
                            FrArticulosSinValorReferencia.IDREMISIONVALORIZADA = Me.DGV_Lista.SelectedRows(0).Cells("Idremisión").Value
                            FrArticulosSinValorReferencia.Cargar()
                            If FrArticulosSinValorReferencia.ValidarValoresRemision() = False Then
                                Dim dr As DialogResult = FrArticulosSinValorReferencia.ShowDialog()
                                If dr = DialogResult.Cancel Then
                                    Exit Sub
                                End If
                            End If
                            FrOpcionesImpresión.Tipo = 3
                        Else
                            FrOpcionesImpresión.Tipo = 1
                        End If
                        FrOpcionesImpresión.ID = Me.DGV_Lista.SelectedRows(0).Cells("IdRemisión").Value
                        FrOpcionesImpresión.Ck_Impresión1.Text = "Copia Destinatario"
                        FrOpcionesImpresión.Ck_Impresión1.Checked = True
                        FrOpcionesImpresión.Ck_Impresión2.Text = "Copia Transportador"
                        FrOpcionesImpresión.Ck_Impresión2.Checked = True
                        FrOpcionesImpresión.Ck_Impresión3.Text = "Copia Consecutivo"
                        FrOpcionesImpresión.Ck_Impresión3.Checked = True
                        FrOpcionesImpresión.Ck_Impresión4.Text = "Copia Portería de Salida"
                        FrOpcionesImpresión.Ck_Impresión4.Checked = True
                        FrOpcionesImpresión.Ck_Impresión5.Visible = False
                        FrOpcionesImpresión.Ck_Impresión5.Checked = False

                        Dim dt_Articulos As DataTable = DGV_ListaItem.DataSource
                        Dim CantidadEquiposPorArticulo As New ArrayList
                        Dim CantidadLineasOcupa As Integer = 0
                        Dim MediaCarta As Boolean = True
                        For i As Integer = 0 To dt_Articulos.Rows.Count - 1
                            Dim filaItemRemision As DataRow
                            filaItemRemision = dt_Articulos.Rows(i)
                            Dim dsequipos As New DataSet
                            dsequipos = bddatos.ModificarCustodias(9, 0, filaItemRemision("Código"), 0, 0, Me.DGV_Lista.SelectedRows(0).Cells("IdRemisión").Value, 0)
                            CantidadEquiposPorArticulo.Add(dsequipos.Tables(0).Rows.Count)
                            Dim LargoArticulo As Integer = dt_Articulos.Rows(i).Item("Descripción").ToString.Length
                            If dt_Articulos.Rows(i).Item("Descripción").ToString.Length < 91 Then
                                CantidadLineasOcupa += 1
                            Else
                                If dt_Articulos.Rows(i).Item("Descripción").ToString.Length < 181 Then
                                    CantidadLineasOcupa += 2
                                Else
                                    CantidadLineasOcupa += 3
                                End If

                            End If

                            If dsequipos.Tables(0).Rows.Count > 0 Then
                                Dim CadenaEquipos As String = "Códigos: "
                                For j As Integer = 0 To dsequipos.Tables(0).Rows.Count - 1
                                    CadenaEquipos += dsequipos.Tables(0).Rows(j)("CODIGO")
                                    If j <> dsequipos.Tables(0).Rows.Count - 1 Then
                                        CadenaEquipos += ", "
                                    End If
                                Next

                                If CadenaEquipos.Length < 75 Then
                                    CantidadLineasOcupa += 1
                                Else
                                    If CadenaEquipos.Length < 140 Then
                                        CantidadLineasOcupa += 2
                                    Else
                                        If CadenaEquipos.Length < 210 Then
                                            CantidadLineasOcupa += 3
                                        Else
                                            If CadenaEquipos.Length < 280 Then
                                                CantidadLineasOcupa += 4
                                            Else
                                                If CadenaEquipos.Length < 350 Then
                                                    CantidadLineasOcupa += 5
                                                End If
                                            End If
                                        End If
                                    End If

                                End If
                            End If
                        Next

                        If CantidadLineasOcupa < 6 Then
                            FrOpcionesImpresión.Ck_MediaCarta.Text = "Imprimir en media carta"
                            FrOpcionesImpresión.Ck_MediaCarta.Checked = False
                            FrOpcionesImpresión.Ck_MediaCarta.Location = New System.Drawing.Point(15, 122)
                            FrOpcionesImpresión.Ck_MediaCarta.Visible = True
                        End If

                        FrOpcionesImpresión.ShowDialog()
                    End If
            End Select
            UbicarRegistros()
        End If
    End Sub


    Private Sub HabilitarImpresion()
        If Me.DGV_Lista.SelectedRows.Count > 0 Then
            Index_Registro_Actual = DGV_Lista.CurrentRow.Index
            Select Case TablaCargada
                Case Tabla.Entrada, Tabla.EntradaCancelada
                    If MsgBox("¿Desea habilitar la impresión de la Entrada de Almacén?", MsgBoxStyle.YesNo, "Habilitar impresión") = MsgBoxResult.Yes Then
                        Dim Comando As New SqlClient.SqlCommand("HabilitarImpresion")
                        Comando.CommandType = CommandType.StoredProcedure
                        Comando.Parameters.AddWithValue("@IDDOCUMENTO", CStr(Me.DGV_Lista.SelectedRows(0).Cells(0).Value))
                        Comando.Parameters.AddWithValue("@TIPODOCUMENTO", "EA")
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
                        CargarEntradaAlmacén(0)
                    End If
                Case Tabla.Salida, Tabla.SalidaCancelada
                    If MsgBox("¿Desea habilitar la impresión de la Salida de Almacén?", MsgBoxStyle.YesNo, "Habilitar impresión") = MsgBoxResult.Yes Then
                        Dim Comando As New SqlClient.SqlCommand("HabilitarImpresion")
                        Comando.CommandType = CommandType.StoredProcedure
                        Comando.Parameters.AddWithValue("@IDDOCUMENTO", CStr(Me.DGV_Lista.SelectedRows(0).Cells(0).Value))
                        Comando.Parameters.AddWithValue("@TIPODOCUMENTO", "SA")
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
                        CargarSalidasAlmacén(1, "")
                    End If
            End Select
            UbicarRegistros()
        End If
    End Sub
#End Region

#Region "Funciones Extra"
    Private Sub Nbi_CambiaBodega_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CambiarBodega.ItemClick
        If DGV_Lista.RowCount > 0 Then
            Index_Registro_Actual = DGV_Lista.CurrentRow.Index
        End If
        Dim FrCambiarBodega As New Bodegas.Fr_CambiarBodega
        Dim IdBodegaActual As String = VariablesBase.VariablesBase.IdBodegaActual
        FrCambiarBodega.ShowDialog()
        If IdBodegaActual <> VariablesBase.VariablesBase.IdBodegaActual Then
            Dim Padre As Object
            Padre = Me.Parent
            Padre.parent.TSSL_Servidor_Usuario_BD.Text = "Servidor BD: " + VariablesBase.VariablesBase.Servidor + "     Base de Datos:   " + VariablesBase.VariablesBase.NombreBaseDatos + "     Usuario: " + VariablesBase.VariablesBase.Usuario + "    " + _
            "Usuario del sistema: " + VariablesBase.VariablesBase.Nombre_Usuario + IIf(VariablesBase.VariablesBase.IdBodegaActual <> -1, "     Bodega: " + VariablesBase.VariablesBase.AbreviaturaBodegaActual, "")
            CargarBodega()
        End If
        UbicarRegistros()
    End Sub


    Public Sub UbicarRegistros()
        Try
            Me.DGV_Lista.CurrentCell = Me.DGV_Lista(0, Index_Registro_Actual)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Nbi_AsociarUsuarioBodega_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_AsociarUsuarioBodega.ItemClick
        If DGV_Lista.RowCount > 0 Then
            Index_Registro_Actual = DGV_Lista.CurrentRow.Index
        End If
        Dim frAsociarUsuarioBodega As New Bodegas.Fr_AsociarUsuarioBodega
        frAsociarUsuarioBodega.ShowDialog()
        UbicarRegistros()
    End Sub


    Public Sub Comportamiento_Predeterminado()
        Me.Nbc_Bodega.ActiveGroup = Me.Nbg_SalidaAlmacen
        Me.DGV_Lista.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.DGV_Lista.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.DGV_ListaItem.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.DGV_ListaItem.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.DGV_Equipos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.DGV_Equipos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Nbc_Bodega.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbc_Bodega.Tag)
        Nbg_SalidaAlmacen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_SalidaAlmacen.Tag)
        Nbg_EntradaAlmacen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_EntradaAlmacen.Tag)
        Nbg_Traslados.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Traslados.Tag)
        Nbg_Bodega.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Bodega.Tag)
        Nbg_Filtro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Filtro.Tag)
        Cms_CancelarItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_CancelarItem.Tag)
        'Salida Almacén
        Nbi_CargarSalidaAlmacen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarSalidaAlmacen.Tag)
        Nbi_CrearSA.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearSA.Tag)
        Nbi_EnviarCorreoPenSATC.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EnviarCorreoPenSATC.Tag)
        Nbi_TrasCustodia.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_TrasCustodia.Tag)
        '   Nbi_VerSA
        Nbi_EditarSA.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarSA.Tag)
        Nbi_CancelarSA.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarSA.Tag)
        Nbi_ImprimirSalidaAlmacen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirSalidaAlmacen.Tag)
        Nbi_HabilitarImpresion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HabilitarImpresion.Tag)
        '   Nbi_BuscarSalidaAlmacen
        Nbi_RegistrarDatosTransportador.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RegistrarDatosTransportador.Tag)
        Nbi_SalidasDotación.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SalidasDotación.Tag)
        Nbi_BuscarSalidaPorArticulo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarSalidaPorArticulo.Tag)
        Nbi_BuscarCustodias.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarCustodias.Tag)
        Nbi_BuscarCustodiaH.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarCustodiaH.Tag)
        'Ver/Subir de pdf Entrada almacen
        Nbi_SubirSalida.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirSalida.Tag)
        Nbi_VerSalidaAlmacenPDF.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerSalidaAlmacenPDF.Tag)
        Nbi_SubirPdfBloqueSA.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfBloqueSA.Tag)
        Nbi_HistorialArchivosPdfSA.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialArchivosPdfSA.Tag)

        'Entrada Almacén
        Nbi_CargarEntradasAlmacen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarEntradasAlmacen.Tag)
        Nbi_CrearEA.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearEA.Tag)
        '   Nbi_VerEA
        Nbi_EditarEA.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarEA.Tag)
        Nbi_CancelarEA.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarEA.Tag)
        Nbi_ImprimirEntradaAlmacen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirEntradaAlmacen.Tag)
        Nbi_HabilitarImpresionEntrada.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HabilitarImpresionEntrada.Tag)
        Nbi_DevolucionProveedor.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_DevolucionProveedor.Tag)
        '   Nbi_BuscarEntrada
        Nbi_BuscarEntradaPorArticulo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarEntradaPorArticulo.Tag)
        Nbi_ImpSticker.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImpSticker.Tag)

        'Ver/Subir de pdf Entrada almacen
        Nbi_SubirEntradaAlmacen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirEntradaAlmacen.Tag)
        Nbi_VerPdfEntradaAlmacen.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerPdfEntradaAlmacen.Tag)
        Nbi_SubirPdfBloqueEA.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SubirPdfBloqueEA.Tag)
        Nbi_HistorialArchivosPdfEA.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialArchivosPdfEA.Tag)

        'Traslados Bodega
        Nbi_CargarNoFinEnviaTB.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarNoFinEnviaTB.Tag)
        Nbi_CargarNoFinDestTB.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarNoFinDestTB.Tag)
        '   Nbi_BuscarRemision
        Nbi_ImprimirRemisión.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirRemisión.Tag)
        Nbi_ImprimirRemisiónValorizada.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirRemisiónValorizada.Tag)
        Nbi_EnviarCorreosSAPendientesXEA.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EnviarCorreosSAPendientesXEA.Tag)
        'Bodega
        Nbi_CargarBodegas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarBodegas.Tag)
        Nbi_CrearBodega.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearBodega.Tag)
        Nbi_VerBodega.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerBodega.Tag)
        Nbi_ModificarBodega.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ModificarBodega.Tag)
        Nbi_ActivarBodega.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ActivarBodega.Tag)
        Nbi_DesactivarBodega.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_DesactivarBodega.Tag)
        Nbi_CambiarBodega.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CambiarBodega.Tag)
        Nbi_AsociarUsuarioBodega.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AsociarUsuarioBodega.Tag)
        Cms_BodegasInactivas.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_BodegasInactivas.Tag)
        Tsmi_VerBodega.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_VerBodega.Tag)
        Tsmi_ActivarBodega.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_ActivarBodega.Tag)
    End Sub
#End Region

#Region "Cancelar"
    Private Sub Nbi_CancelarSA_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CancelarSA.ItemClick
        If TablaCargada = Tabla.Salida Then
            If Me.DGV_Lista.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
                Dim CancelarSA As Boolean = True
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarSA.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("383") = True Then
                        'Puede cancelar cualquier Salida de Almacén.
                        CancelarSA = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("382") = True Then
                            'Si tiene permisos para cancelar las Salidas de Almacén de las bases,
                            'preguntar si la SA pertenece a la base del usuario.
                            Dim IDBodegaSA As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                            If IDBodegaSA = VariablesBase.VariablesBase.IdBodegaActual Then
                                CancelarSA = True
                            Else
                                CancelarSA = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("381") = True Then
                                Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDUSUARIOREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    CancelarSA = True
                                Else
                                    CancelarSA = False
                                End If
                            Else
                                CancelarSA = False
                            End If
                        End If
                    End If
                End If
                If CancelarSA = True Then
                    'Revisar si la salida tiene equipos asociados, si tiene equipos asociados no se puede cancelar.
                    Select Case Me.DGV_Lista.SelectedRows(0).Cells("tipo").Value
                        Case "T"
                            Dim dscancelar As New DataSet
                            dscancelar = bddatos.ModificarEntradasSalidas(8, 0, 0, 0, Date.Now, 0, Date.Now, "", Me.DGV_Lista.SelectedRows(0).Cells("id").Value, 0)
                            If dscancelar.Tables(0).Rows.Count > 0 Then
                                MsgBox("No se pueden cancelar Salidas por Traslado que posean Equipos Asociados", MsgBoxStyle.Information, "Hay Equipos Asociados")
                                Exit Sub
                            End If
                        Case "S"
                            Dim dscancelar As New DataSet
                            dscancelar = bddatos.ModificarCustodias(2, 0, 0, 0, 0, Me.DGV_Lista.SelectedRows(0).Cells("id").Value, 0)
                            If dscancelar.Tables(0).Rows.Count > 0 Then
                                MsgBox("No se pueden cancelar Salidas por Custodia que posean Equipos Asociados", MsgBoxStyle.Information, "Hay Equipos Asociados")
                                Exit Sub
                            End If
                    End Select
                    If MsgBox("La cancelación es un proceso irreversible, seguro que desea cancelar la Salida de Almacén " & Me.DGV_Lista.SelectedRows(0).Cells("Salida").Value, MsgBoxStyle.YesNo, "CANCELAR ORDEN DE COMPRA") = MsgBoxResult.Yes Then
                        Dim idsalida As Integer = Me.DGV_Lista.SelectedRows(0).Cells("Id").Value
                        Dim dstraslado As DataSet
                        Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()
                        dstraslado = bddatos.ModificarEntradasSalidas(9, 0, 0, 0, Date.Now, 0, Date.Now, "", idsalida, 0)
                        If FuncionesBase.FuncionesBase.CancelarRegistro("SA", Me.DGV_Lista.SelectedRows(0).Cells("Id").Value, -1) = 0 Then
                            CargarSalidasAlmacén(1, "")
                        End If
                    End If
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
        Else
            MsgBox("No esta cargada la tabla de Salidas de Almacén")
        End If
        UbicarRegistros()
    End Sub


    Private Sub Nbi_CancelarEA_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CancelarEA.ItemClick
        If TablaCargada = Tabla.Entrada Then
            If Me.DGV_Lista.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
                Dim CancelarEA As Boolean = True
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarEA.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("380") = True Then 'Cancelar Entrada de Almacén ISMOCOL: puede cancelar cualquier Entrada de Almacén.
                        CancelarEA = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("379") = True Then 'Cancelar Entrada de Almacén Base: si tiene permisos para cancelar las Entradas de Almacén de las bases.
                            Dim IDBodegaEA As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                            If IDBodegaEA = VariablesBase.VariablesBase.IdBodegaActual Then 'Preguntar si la EA pertenece a la base del usuario.
                                CancelarEA = True
                            Else
                                CancelarEA = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("378") = True Then 'Cancelar Entrada de Almacén Propia.
                                Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDPERSONAREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    CancelarEA = True
                                Else
                                    CancelarEA = False
                                End If
                            Else
                                CancelarEA = False
                            End If
                        End If
                    End If
                End If
                If CancelarEA = True Then
                    'Revisar si la orden de entrada tiene equipos asociados, si posee no se puede cancelar.
                    Dim dscancelar As New DataSet
                    dscancelar = bddatos.ModificarEntradasSalidas(13, 0, 0, 0, Date.Now, 0, Date.Now, "", 0, Me.DGV_Lista.SelectedRows(0).Cells(0).Value)
                    If dscancelar.Tables(0).Rows.Count > 0 Then
                        MsgBox("No se pueden cancelar Entradas que posean Equipos Asociados", MsgBoxStyle.Information, "Hay Equipos Asociados")
                        Exit Sub
                    End If
                    If Not ValidarCancelacionEntrada(DGV_Lista.SelectedRows(0).Cells("Id").Value) Then
                        MessageBox.Show("No hay suficientes existencias en la bodega para realizar este procedimiento.", "Existencias insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    If MsgBox("La cancelación es un proceso irreversible, seguro que desea cancelar la Entrada de Almacén " & Me.DGV_Lista.SelectedRows(0).Cells("Entrada").Value, MsgBoxStyle.YesNo, "CANCELAR ORDEN DE COMPRA") = MsgBoxResult.Yes Then
                        If FuncionesBase.FuncionesBase.CancelarRegistro("EA", Me.DGV_Lista.SelectedRows(0).Cells("Id").Value, -1) = 0 Then
                            CargarEntradaAlmacén(1)
                        End If
                    End If
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
        Else
            MsgBox("No esta cargada la tabla de Entradas de Almacén")
        End If
        UbicarRegistros()
    End Sub


    Private Sub Nbi_DevolucionProveedor_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_DevolucionProveedor.ItemClick
        If TablaCargada = Tabla.Entrada Then
            If Me.DGV_Lista.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
                Dim CancelarEA As Boolean = True
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarEA.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("380") = True Then
                        'Puede cancelar cualquier Entrada de Almacén.
                        CancelarEA = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("379") = True Then
                            'Si tiene permisos para cancelar las Entradas de Almacén de las bases,
                            'preguntar si la EA pertenece a la base del usuario.
                            Dim IDBodegaEA As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                            If IDBodegaEA = VariablesBase.VariablesBase.IdBodegaActual Then
                                CancelarEA = True
                            Else
                                CancelarEA = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("378") = True Then
                                Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDPERSONAREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    CancelarEA = True
                                Else
                                    CancelarEA = False
                                End If
                            Else
                                CancelarEA = False
                            End If
                        End If
                    End If
                End If
                If CancelarEA = True Then
                    If Me.DGV_Lista.SelectedRows(0).Cells("Tipo").Value = "C" Then
                        If Not ValidarCancelacionEntrada(DGV_Lista.SelectedRows(0).Cells("Id").Value) Then
                            MessageBox.Show("No hay suficientes existencias en la bodega para realizar este procedimiento.", "Existencias insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        If MsgBox("La devolución a proveedor es un proceso irreversible, ¿seguro que desea realizar la devolución " & Trim(Me.DGV_Lista.SelectedRows(0).Cells("Entrada").Value) & "?", MsgBoxStyle.YesNo, "DEVOLUCIÓN A PROVEEDOR") = MsgBoxResult.Yes Then
                            If FuncionesBase.FuncionesBase.CancelarRegistro("DPT", Me.DGV_Lista.SelectedRows(0).Cells("Id").Value, -1) = 0 Then
                                If MsgBox("¿Desea imprimir la Devolución a proveedor", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                                    Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                                    Dim Array As New ArrayList
                                    Array.Add(64)
                                    climpresiones.IDENTRADAALMACEN = Me.DGV_Lista.SelectedRows(0).Cells("Id").Value
                                    climpresiones.ENTRADACANCELADA = True
                                    climpresiones.CANCELACIONPARCIAL = False
                                    climpresiones.FormatoImprimirMateriales(Array, True, False)
                                    MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                                    CargarEntradasCanceladas(0)
                                End If
                                CargarEntradaAlmacén(1)
                            End If
                        End If
                    Else
                        MsgBox("Solo se realizan devoluciones al proveedor de entradas por orden de compra.", MsgBoxStyle.Information, "Entrada de almacén")
                    End If
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
        Else
            MsgBox("No esta cargada la tabla de Entradas de Almacén")
        End If
        UbicarRegistros()
    End Sub


    Private Sub CancelarItemEAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarItemEAToolStripMenuItem.Click
        If TablaCargada = Tabla.Entrada Then
            If Me.DGV_Lista.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
                Dim CancelarEA As Boolean = True
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarEA.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("380") = True Then
                        'Puede cancelar cualquier Entrada de Almacén.
                        CancelarEA = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("379") = True Then
                            'Si tiene permisos para cancelar las Entradas de Almacén de las bases,
                            'preguntar si la EA pertenece a la base del usuario.
                            Dim IDBodegaEA As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                            If IDBodegaEA = VariablesBase.VariablesBase.IdBodegaActual Then
                                CancelarEA = True
                            Else
                                CancelarEA = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("378") = True Then
                                Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDPERSONAREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    CancelarEA = True
                                Else
                                    CancelarEA = False
                                End If
                            Else
                                CancelarEA = False
                            End If
                        End If
                    End If
                End If
                If CancelarEA = True Then
                    If DGV_ListaItem.SelectedRows.Count > 0 Then
                        'Revisar si la orden de entrada tiene equipos asociados, si posee no se puede cancelar.
                        Dim dscancelar As New DataSet
                        dscancelar = bddatos.ModificarEntradasSalidas(13, 0, 0, 0, Date.Now, 0, Date.Now, "", 0, Me.DGV_Lista.SelectedRows(0).Cells(0).Value)
                        If dscancelar.Tables(0).Rows.Count > 0 Then
                            MsgBox("No se pueden cancelar Entradas por Traslado que posean Equipos Asociados", MsgBoxStyle.Information, "Hay Equipos Asociados")
                            Exit Sub
                        End If
                        If Not ValidarCancelacionEntrada(DGV_Lista.SelectedRows(0).Cells("Id").Value, DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("Item").Value) Then
                            MessageBox.Show("No hay suficientes existencias en la bodega para realizar este procedimiento.", "Existencias insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        If MsgBox("La cancelación es un  proceso irreversible, seguro que desea cancelar el ítem " & Me.DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("Item").Value.ToString & " de la Entrada de Almacén " & Me.DGV_Lista.SelectedRows(0).Cells("Entrada").Value, MsgBoxStyle.YesNo, "CANCELAR ITEM ENTRADA DE ALMACÉN") = MsgBoxResult.Yes Then
                            If FuncionesBase.FuncionesBase.CancelarRegistro("IEA", Me.DGV_Lista.SelectedRows(0).Cells("Id").Value, Me.DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("Item").Value) = 0 Then
                                CargarItems()
                            End If
                        End If
                    End If
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
        End If
        If TablaCargada = Tabla.Salida Then
            If Me.DGV_Lista.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
                Dim CancelarSA As Boolean = True
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarSA.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("383") = True Then
                        'Puede cancelar cualquier Salida de Almacén.
                        CancelarSA = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("382") = True Then
                            'Si tiene permisos para cancelar las Salidas de Almacén de las bases,
                            'preguntar si la SA pertenece a la base del usuario.
                            Dim IDBodegaSA As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                            If IDBodegaSA = VariablesBase.VariablesBase.IdBodegaActual Then
                                CancelarSA = True
                            Else
                                CancelarSA = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("381") = True Then
                                Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDUSUARIOREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    CancelarSA = True
                                Else
                                    CancelarSA = False
                                End If
                            Else
                                CancelarSA = False
                            End If
                        End If
                    End If
                End If
                If CancelarSA = True Then
                    If DGV_ListaItem.SelectedRows.Count > 0 Then
                        Dim dscancelar As New DataSet
                        dscancelar = bddatos.ModificarEntradasSalidas(14, 0, 0, 0, Date.Now, 0, Date.Now, "", DGV_Lista.CurrentRow.Cells(0).Value, 0)
                        If dscancelar.Tables(0).Rows.Count > 0 Then
                            MsgBox("No se pueden cancelar ítems individuales en una Salida de Almacén por Traslado que tenga Equipo Capital asociado ya que pueden haber componentes involucrados, intente Editar la Salida")
                            Exit Sub
                        End If
                        If MsgBox("La cancelación es un proceso irreversible, seguro que desea cancelar el ítem " & Me.DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("Item").Value.ToString & " de la Salida de Almacén " & Me.DGV_Lista.SelectedRows(0).Cells("Salida").Value, MsgBoxStyle.YesNo, "CANCELAR ÍTEM SALIDA DE ALMACÉN") = MsgBoxResult.Yes Then
                            If FuncionesBase.FuncionesBase.CancelarRegistro("ISA", Me.DGV_Lista.SelectedRows(0).Cells("Id").Value, Me.DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("Item").Value) = 0 Then
                                CargarItems()
                            End If
                        End If
                    End If
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
        End If
        UbicarRegistros()
    End Sub


    Private Sub DevoluciónAProveedorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DevoluciónAProveedorToolStripMenuItem.Click
        If TablaCargada = Tabla.Entrada Then
            If Me.DGV_Lista.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
                Dim CancelarEA As Boolean = True
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarEA.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("380") = True Then
                        'Puede cancelar cualquier Entrada de Almacén.
                        CancelarEA = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("379") = True Then
                            'Si tiene permisos para cancelar las Entradas de Almacén de las bases,
                            'preguntar si la EA pertenece a la base del usuario.
                            Dim IDBodegaEA As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                            If IDBodegaEA = VariablesBase.VariablesBase.IdBodegaActual Then
                                CancelarEA = True
                            Else
                                CancelarEA = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("378") = True Then
                                Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDPERSONAREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    CancelarEA = True
                                Else
                                    CancelarEA = False
                                End If
                            Else
                                CancelarEA = False
                            End If
                        End If
                    End If
                End If
                If CancelarEA = True Then
                    If DGV_ListaItem.SelectedRows.Count > 0 Then
                        If Me.DGV_Lista.SelectedRows(0).Cells("Tipo").Value = "C" Then
                            If Not ValidarCancelacionEntrada(DGV_Lista.SelectedRows(0).Cells("Id").Value, DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("Item").Value) Then
                                MessageBox.Show("No hay suficientes existencias en la bodega para realizar este procedimiento.", "Existencias insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                            If MsgBox("La devolución a proveedor es un  proceso irreversible, seguro que desea cancelar el ítem " & Me.DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("Item").Value.ToString & " de la Entrada de Almacén " & Me.DGV_Lista.SelectedRows(0).Cells("Entrada").Value, MsgBoxStyle.YesNo, "DEVOLUCIÓN ÍTEM A PROVEEDOR") = MsgBoxResult.Yes Then
                                If FuncionesBase.FuncionesBase.CancelarRegistro("DP", Me.DGV_Lista.SelectedRows(0).Cells("Id").Value, Me.DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("Item").Value) = 0 Then
                                    If MsgBox("¿Desea imprimir la Devolución a proveedor", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                                        Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
                                        Dim Array As New ArrayList
                                        Array.Add(64)
                                        climpresiones.IDENTRADAALMACEN = Me.DGV_Lista.SelectedRows(0).Cells("Id").Value
                                        climpresiones.ENTRADACANCELADA = True
                                        climpresiones.CANCELACIONPARCIAL = True
                                        climpresiones.FormatoImprimirMateriales(Array, True, False)
                                        MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
                                        CargarEntradasCanceladas(0)
                                    End If
                                    CargarItems()
                                End If
                            End If
                        Else
                            MsgBox("Solo se realizan devoluciones al proveedor de entradas por orden de compra", MsgBoxStyle.Information, "Entrada de almacén")
                        End If
                    End If
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
        End If
    End Sub


    ''' <summary>
    ''' Determina si una operación de cancelación de entrada de almacén o ítem de EA se puede realizar sin causar que las existencias en bodega del (de los) ítem(s) pase a estar en cifras negativas.
    ''' </summary>
    ''' <param name="idEntradaAlmacen">Identificador de la Entrada de almacén a cancelar o de la cual se va a cancelar un ítem.</param>
    ''' <param name="idItemEA">Opcional. Indica el ítem que se va a cancelar de la Entrada de Almacén.</param>
    ''' <returns>Verdadero si el inventario resultante tiene valores de ceros o positivos. Falso en caso de que se reduzcan las existencias a valores negativos.</returns>
    ''' <remarks>La validación tiene como objetivo evitar que se realicen cancelaciones de EA de las cuales ya se hayan realizado salidas.</remarks>
    Private Function ValidarCancelacionEntrada(idEntradaAlmacen As Integer, Optional idItemEA As Integer = Nothing) As Boolean
        Dim esValido As Boolean = False
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ValidarCancelacionEA", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDENTRADAALMACEN", idEntradaAlmacen)
        If Not IsNothing(idItemEA) Then
            comando.Parameters.AddWithValue("@IDITEMENTRADAALMACEN", idItemEA)
        End If
        Dim paramMensaje As New SqlParameter("@MENSAJE", SqlDbType.Bit)
        paramMensaje.Direction = ParameterDirection.Output
        comando.Parameters.Add(paramMensaje)
        conexion.Open()
        Try
            comando.ExecuteNonQuery()
            If paramMensaje.Value Then
                esValido = True
            End If
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Cancelación de Entrada de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error)
            esValido = False
        Finally
            conexion.Close()
        End Try
        Return esValido
    End Function
#End Region 'Cancelar


    Private Sub Nbi_BuscarSalidaPorArticulo_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BuscarSalidaPorArticulo.ItemClick
        Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
        FrBuscarArtículo.Familia = "-1"
        FrBuscarArtículo._Tipo = "T"
        FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda por familia, falta implementar
        FrBuscarArtículo.ShowDialog()
        If Trim(FrBuscarArtículo.IdArtículo) = 0 Then
            Exit Sub
        End If
        CargarSalidasAlmacén(6, FrBuscarArtículo.IdArtículo)
    End Sub


    Private Sub Nbi_BuscarEntradaPorArticulo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarEntradaPorArticulo.ItemClick
        Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
        FrBuscarArtículo.Familia = "-1"
        FrBuscarArtículo._Tipo = "T"
        FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda por familia, falta implementar
        FrBuscarArtículo.ShowDialog()
        If Trim(FrBuscarArtículo.IdArtículo) = 0 Then
            Exit Sub
        End If
        CargarEntradaAlmacén(4, FrBuscarArtículo.IdArtículo)
    End Sub


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
                    Select Case DGV_Lista.Columns(nombrecolumna1).ValueType
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
                    Select Case DGV_Lista.Columns(nombrecolumna2).ValueType
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
                    Select Case DGV_Lista.Columns(nombrecolumna3).ValueType
                        Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                            If IsNumeric(Trim(Me.Tx_ValorFiltro3.Text).ToString) = False Then
                                MsgBox("El valor del filtro 3 no corresponde con el tipo de dato", MsgBoxStyle.Critical, "Error del tipo de dato")
                                Exit Sub
                            End If
                    End Select
                End If
            End If
            'Cargar tabla
            Dim vista As DataView
            Select Case TablaCargada
                Case Tabla.Entrada
                    vista = New DataView(dtEntradaAlmacen) 'Me.DsEntradaAlmacén.LISTAENTRADAALMACEN
                    Exit Select
                Case Tabla.Salida
                    vista = New DataView(dtSalidaAlmacen) 'Me.DsSalidaAlmacén.LISTASALIDAALMACEN
                    Exit Select
                Case Tabla.Bodega
                    vista = New DataView(dtBodega) 'Me.DsBodega.LISTABODEGA 
                    Exit Select
                Case Tabla.NoFinalizadas
                    vista = New DataView(dtSalidaAlmacen) 'Me.DsSalidaAlmacén.LISTASALIDAALMACEN
                    Exit Select
                Case Tabla.NoLlegaron
                    vista = New DataView(dtSalidaAlmacen) 'Me.DsSalidaAlmacén.LISTASALIDAALMACEN
                    Exit Select
                Case Tabla.Finalizadas
                    vista = New DataView(dtSalidaAlmacen) 'Me.DsSalidaAlmacén.LISTASALIDAALMACEN
                    Exit Select
                Case Tabla.LLegaron
                    vista = New DataView(dtSalidaAlmacen) 'Me.DsSalidaAlmacén.LISTASALIDAALMACEN
                    Exit Select
                Case Tabla.Remision
                    vista = New DataView(Me.DsBodega.ListaRemisiones)
                    Exit Select
                Case Else
                    vista = New DataView(Me.DsBodega.ListaRemisiones)
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
            Me.DGV_Lista.SuspendLayout()
            Me.DGV_Lista.DataSource = vista
            Me.DGV_Lista.ResumeLayout()
        Catch ex As Exception
            MsgBox("Ocurrió un inconveniente al procesar la instrucción", MsgBoxStyle.Critical, "Inconveniente")
        End Try
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub


    Private Function ConcatenarFiltro(ByVal Columna1 As String, ByVal Valor1 As String) As String
        Select Case DGV_Lista.Columns(Columna1).ValueType
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
        Select Case DGV_Lista.Columns(Columna1).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                Select Case DGV_Lista.Columns(Columna2).ValueType
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
                Select Case DGV_Lista.Columns(Columna2).ValueType
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
        Select Case DGV_Lista.Columns(Columna1).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                tipocolumna1 = "N"
            Case Type.GetType("System.String")
                tipocolumna1 = "S"
            Case Else
                ConcatenarFiltro = ""
                Exit Function
        End Select
        Select Case DGV_Lista.Columns(Columna2).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                tipocolumna2 = "N"
            Case Type.GetType("System.String")
                tipocolumna2 = "S"
            Case Else
                ConcatenarFiltro = ""
                Exit Function
        End Select
        Select Case DGV_Lista.Columns(Columna3).ValueType
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


#End Region
    Private Sub CrearSalidaAlmacen()
        Dim FrSalidaAlmacen As New SalidaAlmacén.Fr_SalidaAlmacen
        FrSalidaAlmacen.CargarDatos()
        FrSalidaAlmacen.ShowDialog()
        CargarSalidasAlmacén(1, "")
    End Sub


    Private Sub CrearEntradaAlmacen()
        Dim FrEntradaAlmacen As New EntradaAlmacén.Fr_EntradaAlmacen
        FrEntradaAlmacen.CargarDatos()
        FrEntradaAlmacen.ShowDialog()
        CargarEntradaAlmacén(1)
    End Sub


    Private Sub Nbi_CrearSA_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearSA.ItemClick
        CrearSalidaAlmacen()
    End Sub


    Private Sub DGV_ListaEnt_Sal_Almacen_RowPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Dim strRowNumber As String = (e.RowIndex + 1).ToString
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DGV_Lista.RowHeadersWidth < CInt(size.Width + 20) Then
            DGV_Lista.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim bt As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub


    Private Sub Nbi_VerEAC_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargarEntradasCanceladas(0)
    End Sub


    Private Sub Nbi_SalidasDotación_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_SalidasDotación.ItemClick
        Dim identificación As String = InputBox("Digite la identificación de la persona", "Identificación", "")
        If Trim(identificación = "") Then
            MsgBox("Identificación no válida", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If IsNumeric(identificación) = False Then
            MsgBox("Identificación no válida", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If identificación.Length > 15 Then
            MsgBox("Identificación no válida", MsgBoxStyle.Critical)
            Exit Sub
        End If
        'cargar salidas
        CargarSalidasAlmacén(5, identificación)
    End Sub


    Private Sub CancelarItemSAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TablaCargada = Tabla.Salida Then
            If Me.DGV_Lista.SelectedRows.Count > 0 Then
                Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
                Dim CancelarSA As Boolean = True
                If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CancelarSA.Tag) = True Then
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("383") = True Then
                        'Puede cancelar cualquier Salida de Almacén.
                        CancelarSA = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("382") = True Then
                            'Si tiene permisos para cancelar las Salidas de Almacén de las bases,
                            'preguntar si la SA pertenece a la base del usuario.
                            Dim IDBodegaSA As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                            If IDBodegaSA = VariablesBase.VariablesBase.IdBodegaActual Then
                                CancelarSA = True
                            Else
                                CancelarSA = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso("381") = True Then
                                Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDUSUARIOREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
                                If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                    CancelarSA = True
                                Else
                                    CancelarSA = False
                                End If
                            Else
                                CancelarSA = False
                            End If
                        End If
                    End If
                End If
                If CancelarSA = True Then
                    If DGV_ListaItem.SelectedRows.Count > 0 Then
                        Dim dscancelar As New DataSet
                        dscancelar = bddatos.ModificarEntradasSalidas(14, 0, 0, 0, Date.Now, 0, Date.Now, "", DGV_ListaItem.CurrentRow.Cells(0).Value, 0)
                        If dscancelar.Tables(0).Rows.Count > 0 Then
                            MsgBox("No se pueden cancelar ítems Individuales en una Salida de Almacén por Traslados que tengan Equipo capital Asociado ya que pueden haber componentes involucrados, intente Editar la Salida")
                        End If
                        If MsgBox("La cancelación es un proceso irreversible, seguro que desea cancelar el ítem " & Me.DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("Item").Value.ToString & " de la Salida de Almacén " & Me.DGV_Lista.SelectedRows(0).Cells("Salida").Value, MsgBoxStyle.YesNo, "CANCELAR ITEM SALIDA DE ALMACÉN") = MsgBoxResult.Yes Then
                            If FuncionesBase.FuncionesBase.CancelarRegistro("ISA", Me.DGV_Lista.SelectedRows(0).Cells("Id").Value, Me.DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("Item").Value) = 0 Then
                                CargarItems()
                            End If
                        End If
                    End If
                Else
                    MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
                End If
            End If
        Else
            MsgBox("No esta cargada la tabla de Salidas de Almacén")
        End If
        UbicarRegistros()
    End Sub


    Private Sub MostrarNombreMenu(ByVal sender As Object, ByVal e As EventArgs)
        '  DGV_ListaRequisiciones.SortedColumn.Name = sender.name
        Dim Vista As DataView
        Select Case TablaCargada
            Case Tabla.Entrada
                Vista = New Data.DataView(dtEntradaAlmacen) 'Me.DsEntradaAlmacén.LISTAENTRADAALMACEN
                Vista.Sort = sender.name + " ASC" ' aquí si se quiere descendiente es el Campo DESC 
                DGV_Lista.DataSource = Vista
            Case Tabla.Salida
                Vista = New Data.DataView(dtSalidaAlmacen) 'Me.DsSalidaAlmacén.LISTASALIDAALMACEN
                Vista.Sort = sender.name + " ASC" ' aquí si se quiere descendiente es el Campo DESC 
                DGV_Lista.DataSource = Vista

            Case Tabla.EntradaCancelada
                Vista = New Data.DataView(dtEntradaAlmacenCancelada) 'Me.DsEntradaAlmacén.ListaEntradaAlmacénCancelada
                Vista.Sort = sender.name + " ASC" ' aquí si se quiere descendiente es el Campo DESC 
                DGV_Lista.DataSource = Vista

            Case Tabla.SalidaCancelada
                Vista = New Data.DataView(dtSalidaAlmacenCancelada) 'Me.DsSalidaAlmacén.ListaSalidaAlmacénCanceladas
                Vista.Sort = sender.name + " ASC" ' aquí si se quiere descendiente es el Campo DESC 
                DGV_Lista.DataSource = Vista
        End Select
    End Sub


    Private Sub Nbi_VerEA_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_VerEA.ItemClick
        If TablaCargada = Tabla.Entrada Then
            Dim VerEA As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerEA.Tag) = True Then
                If FuncionesBase.FuncionesBase.ConsultarPermiso("367") = True Then
                    'Puede visualizar cualquier Entrada de Almacén.
                    VerEA = True
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("366") = True Then
                        'Si tiene permisos para visualizar las Entradas de Almacén de las bases,
                        'preguntar si la EA pertenece a la base del usuario.
                        Dim IDBodegaEA As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                        If IDBodegaEA = VariablesBase.VariablesBase.IdBodegaActual Then
                            VerEA = True
                        Else
                            VerEA = False
                        End If
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("365") = True Then
                            Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDPERSONAREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
                            If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                VerEA = True
                            Else
                                VerEA = False
                            End If
                        Else
                            VerEA = False
                        End If
                    End If
                End If
            End If
            If VerEA = True Then
                Dim FrEntradaAlmacen As New EntradaAlmacén.Fr_EntradaAlmacen
                FrEntradaAlmacen.Editando = True
                FrEntradaAlmacen.IDENTRADAALMACENMODIFICANDO = DGV_Lista.SelectedRows(0).Cells(0).Value
                FrEntradaAlmacen.EditarEquipos = "VER"
                FrEntradaAlmacen.CargarDatos()
                FrEntradaAlmacen.Bt_Guardar.Enabled = False
                FrEntradaAlmacen.Text = "Ver la Entrada de Almacén:   " & Me.DGV_Lista.SelectedRows(0).Cells("Entrada").Value
                FrEntradaAlmacen.ShowDialog()
            Else
                MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
            End If
        Else
            MsgBox("No esta cargada la tabla de Entradas de Almacén")
        End If
    End Sub


    Private Sub Nbi_VerSA_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_VerSA.ItemClick
        If TablaCargada = Tabla.Salida Then
            Dim VerSA As Boolean = False
            If FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerSA.Tag) = True Then
                If FuncionesBase.FuncionesBase.ConsultarPermiso("371") = True Then
                    'Puede visualizar cualquier Salida de Almacén.
                    VerSA = True
                Else
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("370") = True Then
                        'Si tiene permisos para visualizar las Salidas de Almacén de las bases,
                        'preguntar si la SA pertenece a la base del usuario.
                        Dim IDBodegaSA As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                        If IDBodegaSA = VariablesBase.VariablesBase.IdBodegaActual Then
                            VerSA = True
                        Else
                            VerSA = False
                        End If
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso("369") = True Then
                            Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDUSUARIOREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
                            If IDRegistro = VariablesBase.VariablesBase.IdPersona Then
                                VerSA = True
                            Else
                                VerSA = False
                            End If
                        Else
                            VerSA = False
                        End If
                    End If
                End If
            End If
            If VerSA = True Then
                Dim FrSalidaAlmacen As New SalidaAlmacén.Fr_SalidaAlmacen
                FrSalidaAlmacen.Editando = True
                FrSalidaAlmacen.IDSALIDAALMACENMODIFICANDO = DGV_Lista.SelectedRows(0).Cells(0).Value
                FrSalidaAlmacen.EditarEquipos = "VER"
                FrSalidaAlmacen.CargarDatos()
                FrSalidaAlmacen.Bt_GuardarSalida.Enabled = False
                FrSalidaAlmacen.Cu_CentroCosto1.Enabled = False
                FrSalidaAlmacen.Text = "Ver la Salida de Almacén:   " & Me.DGV_Lista.SelectedRows(0).Cells("Salida").Value
                FrSalidaAlmacen.ShowDialog()
            Else
                MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
            End If
        Else
            MsgBox("No esta cargada la tabla de Salidas de Almacén")
        End If
    End Sub


    Private Sub Nbi_BuscarSalidaAlmacen_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BuscarSalidaAlmacen.ItemClick
        BuscarSalidaAlmacen()
    End Sub


    Private Sub BuscarSalidaAlmacen()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("LTRIM(RTRIM(B.ABREVIATURA))", "Abreviatura Bodega", "1")
        campos.Rows.Add("SA.SALIDAALMACEN", "Número Salida Almacén", "1")
        campos.Rows.Add("OT.NROORDENSAP", "Número Orden SAP", "2")
        campos.Rows.Add("SA.FECHADESPACHO", "Fecha Despacho", "3")
        campos.Rows.Add("dbo.Personanombrecompleto(SA.IDPERSONADESPACHA )", "Persona despacha", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(SA.IDPERSONARECIBE)", "Persona Recibe", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(SA.IDUSUARIOREGISTRO )", "Persona Registro", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(SA.IDPERSONAAUTORIZA)", "Persona Autoriza", "1")
        campos.Rows.Add("LTRIM(RTRIM(SA.DESTINO))", "Destino", "1")
        campos.Rows.Add("LTRIM(RTRIM(SA.TRANSPORTADOR))", "Transportadora", "1")
        campos.Rows.Add("LTRIM(RTRIM(BD.ABREVIATURA))", "Abreviatura Bodega Destino", "1")
        campos.Rows.Add("1", "Salidas Canceladas", "4") 'CONSULTA ESPECIAL 1
        campos.Rows.Add("dbo.CodigoEquipoCapital(SA.IDEQUIPO, 1)", "Equipo Asociado", "1")
        frbuscar.campos = campos
        frbuscar.tabla = 15
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        DsSalidaAlmacénfiltro = DSbusqueda
        If DsSalidaAlmacénfiltro.Tables.Count > 0 Then
            If DsSalidaAlmacénfiltro.Tables(0).Rows.Count > 0 Then
                CargarSalidasAlmacénFiltro(DSbusqueda)
                TablaCargada = Tabla.Salida
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub


    Private Sub Nbi_BuscarEntrada_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_BuscarEntrada.ItemClick
        BuscarEntradaAlmacen()
    End Sub


    Private Sub BuscarEntradaAlmacen()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("T.Bodega", "Abreviatura Bodega", "1")
        campos.Rows.Add("T.Entrada", "Número Entrada Almacén", "1")
        campos.Rows.Add("T.[Fecha Recibido]", "Fecha Recibido", "3")
        campos.Rows.Add("T.Recibio", "Persona Recibio", "1")
        campos.Rows.Add("T.Verifica", "Persona Verifico", "1")
        campos.Rows.Add("T.Registro", "Persona Registro", "1")
        campos.Rows.Add("2", "Devoluciones a Proveedor", "4") 'CONSULTA ESPECIAL 2
        campos.Rows.Add("1", "Entradas Canceladas", "4") 'CONSULTA ESPECIAL 1
        campos.Rows.Add("T.IDREMISION", "Número de remisión", "1")
        campos.Rows.Add("T.SALIDAALMACEN", "Salida Almacén", "1")
        frbuscar.campos = campos
        frbuscar.tabla = 13
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        DsSalidaAlmacénfiltro = DSbusqueda
        If DsSalidaAlmacénfiltro.Tables.Count > 0 Then
            If DsSalidaAlmacénfiltro.Tables(0).Rows.Count > 0 Then
                CargarEntradaAlmacénFiltro(DSbusqueda)
                TablaCargada = Tabla.Entrada
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub


    Private Sub Nbi_VerTodasRemisiones_ItemClick(sender As Object, e As EventArgs)
        TablaCargada = Tabla.Remision
        Me.DGV_ListaItem.DataSource = Nothing
        Lb_Movimiento.Text = "Lista de remisiones asociadas a la bodega"
        Lb_Filtro.Text = "Remisiones"
        Me.ListaRemisionesTableAdapter.Fill(Me.DsBodega.ListaRemisiones, 0, VariablesBase.VariablesBase.IdBodegaActual, 1)
        DGV_Lista.DataSource = Nothing
        Me.DGV_Lista.DataSource = Me.DsBodega.ListaRemisiones
        Me.DGV_Lista.AutoGenerateColumns = True
        Me.DGV_Lista.ContextMenuStrip = Nothing
        Me.Lb_Cargado.Text = "REMISIONES"
        DGV_ListaItem.ContextMenuStrip = Cms_CancelarItem
        Me.DGV_Lista.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DGV_Lista.ReadOnly = True
        Me.dt_opcionesfiltro1.Rows.Clear()
        Me.dt_opcionesfiltro2.Rows.Clear()
        Me.dt_opcionesfiltro3.Rows.Clear()
        For i = 0 To DGV_Lista.ColumnCount - 1
            DGV_Lista.Columns(i).Visible = True
            DGV_Lista.Columns(i).Visible = True
            DGV_Lista.Columns(i).Visible = True
            Dim filaopciónfiltro1 As DataRow
            Dim filaopciónfiltro2 As DataRow
            Dim filaopciónfiltro3 As DataRow
            filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
            filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
            filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
            filaopciónfiltro1("OPCION") = DGV_Lista.Columns(i).Name
            filaopciónfiltro2("OPCION") = DGV_Lista.Columns(i).Name
            filaopciónfiltro3("OPCION") = DGV_Lista.Columns(i).Name
            dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
            dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
            dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
            Select Case DGV_Lista.Columns(i).Name
                Case "Id"
                    DGV_Lista.Columns(i).Width = 100
                Case "Requisición"
                    DGV_Lista.Columns(i).Width = 150
                Case "Orden de Compra"
                    DGV_Lista.Columns(i).Width = 150
                Case "Bodega Origen"
                    DGV_Lista.Columns(i).Width = 150
                Case "Destino"
                    DGV_Lista.Columns(i).Width = 150
                Case Else
                    DGV_Lista.Columns(i).Visible = False
            End Select
        Next
        Me.Pn_ContenedorItems.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)
        Try
            Me.DGV_Lista.Rows(0).Selected = True
            CargarListaxSeleccion()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Nbi_BuscarRemision_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarRemision.ItemClick
        Dim Texto As String = InputBox("Digite la descripción con la cual desea hacer la búsqueda, mínimo 4 caracteres.", "Buscar", "")
        If Trim(Texto) <> "" Then
            If Trim(Texto).Length > 3 Then
                If Trim(Texto).Length < 50 Then
                    TablaCargada = Tabla.Remision
                    Me.DGV_ListaItem.DataSource = Nothing
                    Lb_Movimiento.Text = "Lista de remisiones asociadas a la bodega"
                    Lb_Filtro.Text = "Remisiones"
                    Me.ListaRemisionesTableAdapter.Fill(Me.DsBodega.ListaRemisiones, 6, VariablesBase.VariablesBase.IdBodegaActual, Texto)
                    DGV_Lista.DataSource = Nothing
                    Me.DGV_Lista.DataSource = Me.DsBodega.ListaRemisiones
                    Me.DGV_Lista.AutoGenerateColumns = True
                    Me.DGV_Lista.ContextMenuStrip = Nothing
                    Me.Lb_Cargado.Text = "REMISIONES"
                    DGV_ListaItem.ContextMenuStrip = Cms_CancelarItem
                    Me.DGV_Lista.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
                    Me.DGV_Lista.ReadOnly = True
                    Me.dt_opcionesfiltro1.Rows.Clear()
                    Me.dt_opcionesfiltro2.Rows.Clear()
                    Me.dt_opcionesfiltro3.Rows.Clear()
                    For i = 0 To DGV_Lista.ColumnCount - 1
                        DGV_Lista.Columns(i).Visible = True
                        DGV_Lista.Columns(i).Visible = True
                        DGV_Lista.Columns(i).Visible = True
                        Dim filaopciónfiltro1 As DataRow
                        Dim filaopciónfiltro2 As DataRow
                        Dim filaopciónfiltro3 As DataRow
                        filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
                        filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
                        filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
                        filaopciónfiltro1("OPCION") = DGV_Lista.Columns(i).Name
                        filaopciónfiltro2("OPCION") = DGV_Lista.Columns(i).Name
                        filaopciónfiltro3("OPCION") = DGV_Lista.Columns(i).Name
                        dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
                        dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
                        dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
                        Select Case DGV_Lista.Columns(i).Name
                            Case "Id"
                                DGV_Lista.Columns(i).Width = 100
                            Case "Requisición"
                                DGV_Lista.Columns(i).Width = 150
                            Case "Orden de Compra"
                                DGV_Lista.Columns(i).Width = 150
                            Case "Bodega Origen"
                                DGV_Lista.Columns(i).Width = 150
                            Case "Destino"
                                DGV_Lista.Columns(i).Width = 150
                            Case Else
                                DGV_Lista.Columns(i).Visible = False
                        End Select
                    Next
                    Me.Pn_ContenedorItems.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)
                    Try
                        Me.DGV_Lista.Rows(0).Selected = True
                        CargarListaxSeleccion()
                    Catch ex As Exception

                    End Try
                Else
                    MsgBox("Muy largo la descripción, máximo 50 caracteres", MsgBoxStyle.Critical, "Descripción")
                End If
            Else
                MsgBox("Muy poco descripción, sea más explicito", MsgBoxStyle.Critical, "Descripción")
            End If
        End If
    End Sub


    Private Sub Nbi_RegistrarDatosTransportador_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RegistrarDatosTransportador.ItemClick
        If TablaCargada = Tabla.Remision Or TablaCargada = Tabla.NoLlegaron Or TablaCargada = Tabla.Salida Then
            If DGV_Lista.SelectedRows.Count > 0 Then
                Dim idSalidaAlmacen As String = DGV_Lista.SelectedRows(0).Cells("Id").Value
                Dim salidaAlmacen As String = DGV_Lista.SelectedRows(0).Cells("Salida").Value
                Dim EmpresaTransporta As String = DGV_Lista.SelectedRows(0).Cells("Transporta").Value
                Dim PersonaTransporta As String = DGV_Lista.SelectedRows(0).Cells("RECIBETRANSPORTADOR").Value
                Dim PlacaVehiculo As String = DGV_Lista.SelectedRows(0).Cells("PLACAVEHICULO").Value
                Dim FechaDespacho As DateTime = DGV_Lista.SelectedRows(0).Cells("Fecha Despacho").Value
                Dim Guía As String = DGV_Lista.SelectedRows(0).Cells("GUIA").Value
                Dim Fr_RegistrarDatosTransportador As New Form
                Dim Bt_Registrar As New Button
                Dim Bt_Cancelar As New Button
                Dim Lb_EmpresaTransporta As New Label
                Dim Lb_PersonaTransporta As New Label
                Dim Lb_PlacaVehiculo As New Label
                Dim Tx_EmpresaTransporta As New TextBox
                Dim Tx_PersonaTransporta As New TextBox
                Dim Tx_PlacaVehiculo As New TextBox
                Dim Bt_BuscarPlacaVehiculo As New Button
                Dim Pn_Botones As New System.Windows.Forms.Panel
                Dim Lb_FechaDespacho As New Label
                Dim Dtp_FechaDespacho As New System.Windows.Forms.DateTimePicker()
                Dim Lb_Guía As New Label
                Dim Tx_Guía As New TextBox
                With Pn_Botones
                    .BackColor = System.Drawing.SystemColors.ControlDark
                    .Controls.Add(Bt_Registrar)
                    .Controls.Add(Bt_Cancelar)
                    .Dock = System.Windows.Forms.DockStyle.Bottom
                    .Location = New System.Drawing.Point(0, 140)
                    .Name = "Panel1"
                    .Size = New System.Drawing.Size(363, 34)
                    .TabIndex = 5
                End With
                With Lb_EmpresaTransporta
                    .AutoSize = True
                    .Location = New Point(16, 10)
                    .Text = "Empresa Transporta:"
                    .Size = New System.Drawing.Size(105, 13)
                End With
                With Tx_EmpresaTransporta
                    .Location = New Point(122, 7)
                    .Size = New Size(235, 20)
                    .Text = EmpresaTransporta
                    .MaxLength = 50
                    .TabIndex = 1
                End With
                With Lb_PersonaTransporta
                    .AutoSize = True
                    .Location = New Point(18, 35)
                    .Text = "Persona Transporta:"
                    .Size = New System.Drawing.Size(103, 13)
                End With
                With Tx_PersonaTransporta
                    .Location = New Point(122, 32)
                    .Size = New Size(235, 20)
                    .Text = PersonaTransporta
                    .MaxLength = 50
                    .TabIndex = 2
                End With
                With Lb_PlacaVehiculo
                    .AutoSize = True
                    .Location = New Point(38, 60)
                    .Size = New System.Drawing.Size(83, 13)
                    .Text = "Placa Vehículo:"
                End With
                With Tx_PlacaVehiculo
                    .Location = New Point(122, 57)
                    .Size = New Size(72, 20)
                    .Text = PlacaVehiculo
                    .MaxLength = 7
                    .TabIndex = 3
                End With
                With Bt_BuscarPlacaVehiculo
                    .Location = New Point(200, 56)
                    .Size = New Size(32, 23)
                    .Text = "..."
                    .UseVisualStyleBackColor = True
                End With
                With Lb_FechaDespacho
                    .AutoSize = True
                    .Location = New System.Drawing.Point(29, 85)
                    .Size = New System.Drawing.Size(92, 13)
                    .Text = "Fecha Despacho:"
                End With
                With Dtp_FechaDespacho
                    .Location = New System.Drawing.Point(122, 81)
                    .Size = New System.Drawing.Size(200, 20)
                    .MinDate = FechaDespacho.AddDays(-7)
                    .MaxDate = Date.Now.AddDays(7)
                    .Value = FechaDespacho
                    .TabIndex = 4
                End With
                With Lb_Guía
                    .AutoSize = True
                    .Location = New Point(86, 110)
                    .Text = "Guía:"
                    .Size = New System.Drawing.Size(20, 13)
                End With
                With Tx_Guía
                    .Location = New Point(122, 106)
                    .Size = New Size(235, 20)
                    .Text = Guía
                    .MaxLength = 20
                    .TabIndex = 5
                End With
                With Bt_Registrar
                    .Location = New Point(110, 6)
                    .Size = New System.Drawing.Size(75, 23)
                    .Text = "Registrar"
                End With
                With Bt_Cancelar
                    .Location = New Point(200, 6)
                    .Size = New System.Drawing.Size(75, 23)
                    .Text = "Cancelar"
                End With
                With Fr_RegistrarDatosTransportador
                    .AcceptButton = Bt_Registrar
                    .CancelButton = Bt_Cancelar
                    .FormBorderStyle = FormBorderStyle.FixedDialog
                    .MaximizeBox = False
                    .MinimizeBox = False
                    .Size = New Size(380, 213)
                    .StartPosition = FormStartPosition.CenterParent
                    .Text = "Registrar Datos Transportador - SA " & salidaAlmacen
                    .Controls.Add(Lb_EmpresaTransporta)
                    .Controls.Add(Tx_EmpresaTransporta)
                    .Controls.Add(Lb_PersonaTransporta)
                    .Controls.Add(Tx_PersonaTransporta)
                    .Controls.Add(Lb_PlacaVehiculo)
                    .Controls.Add(Tx_PlacaVehiculo)
                    .Controls.Add(Bt_BuscarPlacaVehiculo)
                    .Controls.Add(Lb_Guía)
                    .Controls.Add(Tx_Guía)
                    .Controls.Add(Lb_FechaDespacho)
                    .Controls.Add(Dtp_FechaDespacho)
                    .Controls.Add(Pn_Botones)
                End With
                AddHandler Tx_PlacaVehiculo.KeyPress, Sub(sender1 As Object, e1 As KeyPressEventArgs)
                                                          e1.KeyChar = Char.ToUpper(e1.KeyChar)
                                                          Dim regex As New System.Text.RegularExpressions.Regex("[A-Z0-9]")
                                                          If Not (regex.IsMatch(e1.KeyChar) Or e1.KeyChar = Convert.ToChar(Keys.Back)) Then
                                                              e1.Handled = True
                                                              e1.KeyChar = CChar("")
                                                          End If
                                                      End Sub
                AddHandler Bt_BuscarPlacaVehiculo.Click, Sub()
                                                             Dim placa As String = SalidaAlmacén.Fr_SalidaAlmacen.CargarPlacasVehiculos()
                                                             If placa IsNot Nothing Then
                                                                 If placa <> "" Then
                                                                     Tx_PlacaVehiculo.Text = placa
                                                                 End If
                                                             End If
                                                         End Sub
                AddHandler Bt_Registrar.Click, Sub()
                                                   If MsgBox("¿Desea Guardar la información?", MsgBoxStyle.YesNo, "ACTUALIZAR DATOS") = MsgBoxResult.Yes Then
                                                       Dim dtVacioISA As New DataTable
                                                       dtVacioISA.Columns.Add("IDITEMSALIDAALMACEN")
                                                       dtVacioISA.Columns.Add("IDREQUISICION")
                                                       dtVacioISA.Columns.Add("IDITEMREQUISICION")
                                                       dtVacioISA.Columns.Add("IDARTICULO")
                                                       dtVacioISA.Columns.Add("CANTIDAD")
                                                       dtVacioISA.Columns.Add("IDREMISION")
                                                       dtVacioISA.Columns.Add("IDORDENCOMPRA")
                                                       dtVacioISA.Columns.Add("IDITEMORDENCOMPRA")
                                                       Dim conn As New SqlConnection(My.Settings.CadenaConexión)
                                                       Dim Comando As New SqlCommand("GestionarSalidaAlmacen", conn)
                                                       Comando.CommandType = CommandType.StoredProcedure
                                                       Comando.Parameters.AddWithValue("@IDSALIDAALMACEN", idSalidaAlmacen)
                                                       Comando.Parameters.AddWithValue("@TableItemSA", dtVacioISA)
                                                       Comando.Parameters.AddWithValue("@TIPO", 4)
                                                       Comando.Parameters.AddWithValue("@IDBODEGA", 0)
                                                       Comando.Parameters.AddWithValue("@TIPOSALIDAALMACEN", "")
                                                       Comando.Parameters.AddWithValue("@DESTINO", "")
                                                       Comando.Parameters.AddWithValue("@IDPERSONAAUTORIZA", 0)
                                                       Comando.Parameters.AddWithValue("@FECHADESPACHO", Dtp_FechaDespacho.Value)
                                                       Comando.Parameters.AddWithValue("@IDPERSONADESPACHA", 0)
                                                       Comando.Parameters.AddWithValue("@IDPERSONARECIBE", 0)
                                                       Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                                                       Comando.Parameters.AddWithValue("@OBSERVACION", "")
                                                       Comando.Parameters.AddWithValue("@TRANSPORTADOR", Tx_EmpresaTransporta.Text)
                                                       Comando.Parameters.AddWithValue("@RECIBETRANSPORTADOR", Tx_PersonaTransporta.Text)
                                                       Comando.Parameters.AddWithValue("@PLACAVEHICULO", Tx_PlacaVehiculo.Text)
                                                       Comando.Parameters.AddWithValue("@GUIA", Tx_Guía.Text)
                                                       Comando.Parameters.AddWithValue("@CREARREMISION", 0)
                                                       Comando.Parameters.AddWithValue("@IDBODEGADESTINO", 0)
                                                       Comando.Parameters.AddWithValue("@IDACTIVIDADPRINCIPAL", 0)
                                                       Comando.Parameters.AddWithValue("@IDCENTROCOSTO", 0)
                                                       Comando.Parameters.AddWithValue("@IDEQUIPO", 0)
                                                       Comando.Parameters.AddWithValue("@REGISTROODOMETROHOROMETRO", 0)
                                                       Comando.Parameters.AddWithValue("@IDORDENTRABAJO", DBNull.Value)
                                                       Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                                                       msgParam.Direction = ParameterDirection.Output
                                                       Comando.Parameters.Add(msgParam)
                                                       Dim msgParam1 As New SqlParameter("@CONSECUTIVOREMISION", SqlDbType.BigInt, 1)
                                                       msgParam1.Direction = ParameterDirection.Output
                                                       Comando.Parameters.Add(msgParam1)
                                                       Try
                                                           conn.Open()
                                                           Comando.ExecuteNonQuery()
                                                           conn.Close()
                                                       Catch ex As Exception
                                                           conn.Close()
                                                           MsgBox(ex.Message)
                                                       Finally
                                                           conn.Close()
                                                       End Try
                                                       Fr_RegistrarDatosTransportador.DialogResult = DialogResult.OK
                                                       Fr_RegistrarDatosTransportador.Close()
                                                   End If
                                               End Sub
                AddHandler Bt_Cancelar.Click, Sub()
                                                  Fr_RegistrarDatosTransportador.DialogResult = DialogResult.Cancel
                                                  Fr_RegistrarDatosTransportador.Close()
                                              End Sub
                Fr_RegistrarDatosTransportador.ShowDialog()
            End If
            Select Case TablaCargada
                Case Tabla.Salida
                    CargarSalidasAlmacén(1, "")
                Case Tabla.Remision, Tabla.NoLlegaron
                    CargarRemisiones(1)
            End Select
        Else
            MsgBox("No esta cargada la tabla de Salidas de Almacén")
        End If
    End Sub


    Private Sub Nbi_BuscarCustodias_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarCustodias.ItemClick
        Dim identificacion As String = ""
        Dim tipoBusqueda As Integer = 0
        Dim dt_Custodias As DataTable
        Dim Fr_BuscarCustodia As New Form
        Dim Pn_Controles As New Panel
        Dim Cb_TipoBusqueda As New ComboBox
        Dim Tx_Valor As New TextBox
        Dim Bt_Buscar As New Button
        Dim Dgv_Custodias As New DataGridView
        Dim Flp_Botones As New FlowLayoutPanel
        Dim Bt_ExportarExcel As New Button
        Dim dt_tiposBusqueda As New DataTable
        dt_tiposBusqueda.Columns.Add("Id")
        dt_tiposBusqueda.Columns.Add("Tipo")
        dt_tiposBusqueda.Rows.Add(1, "C.C. o Identificación")
        dt_tiposBusqueda.Rows.Add(2, "Id. de Equipo")
        dt_tiposBusqueda.Rows.Add(3, "Id. de Artículo")
        With Cb_TipoBusqueda
            .DataSource = dt_tiposBusqueda
            .DisplayMember = "Tipo"
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Location = New Point(10, 20)
            .Size = New Size(150, 21)
            .ValueMember = "Id"
        End With
        With Tx_Valor
            .Location = New Point(170, 20)
            .Size = New Size(320, 20)
        End With
        With Bt_Buscar
            .Text = "Buscar"
            .Location = New Point(500, 18)
        End With
        With Pn_Controles
            .Dock = DockStyle.Top
            .Height = 50
            .Controls.Add(Cb_TipoBusqueda)
            .Controls.Add(Tx_Valor)
            .Controls.Add(Bt_Buscar)
        End With
        With Dgv_Custodias
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
            .Dock = DockStyle.Fill
            .MultiSelect = True
            .ReadOnly = True
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        End With
        With Bt_ExportarExcel
            .AutoSize = True
            .Enabled = False
            .Text = "Exportar a Excel"
        End With
        With Flp_Botones
            .Dock = DockStyle.Bottom
            .FlowDirection = FlowDirection.RightToLeft
            .Height = 30
            .Controls.Add(Bt_ExportarExcel)
        End With
        With Fr_BuscarCustodia
            .AcceptButton = Bt_Buscar
            .FormBorderStyle = FormBorderStyle.Sizable
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New Size(860, 700)
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Buscar Custodias"
            .Controls.Add(Dgv_Custodias)
            .Controls.Add(Flp_Botones)
            .Controls.Add(Pn_Controles)
        End With
        AddHandler Bt_Buscar.Click, Sub()
                                        identificacion = Tx_Valor.Text
                                        tipoBusqueda = Cb_TipoBusqueda.SelectedValue
                                        identificacion = System.Text.RegularExpressions.Regex.Replace(identificacion, "[^0-9]", "")
                                        If identificacion = "" Or Not IsNumeric(identificacion) Then
                                            MsgBox("No se especificó un código o número de identificación válido." & Environment.NewLine _
                                                   & "Por favor ingrese el valor correcto para la búsqueda.", MsgBoxStyle.Exclamation, "VALOR INVÁLIDO")
                                        Else
                                            If Not IsNothing(Dgv_Custodias.DataSource) Then
                                                Dgv_Custodias.DataSource = Nothing
                                                Bt_ExportarExcel.Enabled = False
                                            End If
                                            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                                            Dim comandoCustodias As New SqlCommand("dbo.ListarCustodias", conexion)
                                            comandoCustodias.CommandType = CommandType.StoredProcedure
                                            Select Case tipoBusqueda
                                                Case 1 'por Identificación
                                                    comandoCustodias.Parameters.AddWithValue("@TIPO", 1)
                                                Case 2 'por Id. de Equipo
                                                    comandoCustodias.Parameters.AddWithValue("@TIPO", 2)
                                                Case 3 'por Id. de Artículo
                                                    comandoCustodias.Parameters.AddWithValue("@TIPO", 3)
                                            End Select
                                            comandoCustodias.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                                            comandoCustodias.Parameters.AddWithValue("@IDENTIFICACION", identificacion)
                                            Dim adaptadorCustodias As New SqlDataAdapter(comandoCustodias)
                                            dt_Custodias = New DataTable
                                            Try
                                                Cursor = Cursors.WaitCursor
                                                conexion.Open()
                                                adaptadorCustodias.Fill(dt_Custodias)
                                                conexion.Close()
                                                Cursor = Cursors.Default
                                                If dt_Custodias.Rows.Count < 1 Then
                                                    Select Case tipoBusqueda
                                                        Case 1 'por Identificación
                                                            Dim cnl As New FuncionesBase.Cl_Convertir_Num_Letras
                                                            MsgBox("No se ha encontrado la persona con número de identificación " & cnl.Fun_FormatearCedula(identificacion) & "." & Environment.NewLine _
                                                                                            & "Por favor ingrese el número de identificación correcto de la persona registrada en el sistema.", _
                                                                                            MsgBoxStyle.Exclamation, "PERSONA NO ENCONTRADA")
                                                        Case 2 'por Id. de Equipo
                                                            MsgBox("No se ha encontrado el equipo con Id. " & identificacion & "." & Environment.NewLine _
                                                                                            & "Por favor ingrese el identificador correcto del equipo registrado en el sistema.", _
                                                                                            MsgBoxStyle.Exclamation, "EQUIPO NO ENCONTRADO")
                                                        Case 3 'por Id. de Artículo
                                                            MsgBox("No se ha encontrado el artículo con Id. " & identificacion & "." & Environment.NewLine _
                                                                                            & "Por favor ingrese el identificador correcto del artículo registrado en el sistema.", _
                                                                                            MsgBoxStyle.Exclamation, "ARTÍCULO NO ENCONTRADO")
                                                    End Select
                                                    Exit Sub
                                                Else
                                                    Dgv_Custodias.DataSource = dt_Custodias
                                                    Bt_ExportarExcel.Enabled = True
                                                    For i As Integer = 0 To Dgv_Custodias.Columns.Count
                                                        Select Case Dgv_Custodias.Columns(i).Name
                                                            Case "Id Artículo", "Cantidad", "Id Equipo", "Id SA"
                                                                Dgv_Custodias.Columns(i).Width = 50
                                                            Case "Tipo Custodia", "Equipo", "Equipo Padre", "Salida Almacén", "Bodega", "Fecha Custodia"
                                                                Dgv_Custodias.Columns(i).Width = 100
                                                            Case "Artículo", "Persona Recibe", "Observación"
                                                                Dgv_Custodias.Columns(i).Width = 200
                                                        End Select
                                                    Next
                                                End If
                                            Catch es As Exception
                                                conexion.Close()
                                            Finally
                                                conexion.Close()
                                            End Try
                                        End If
                                    End Sub
        AddHandler Bt_ExportarExcel.Click, Sub()
                                               ' Exportar a Excel
                                               Dim nombreArchivo As String = ""
                                               Select Case tipoBusqueda
                                                   Case 1 'por Identificación
                                                       nombreArchivo = "Custodias a nombre de "
                                                   Case 2 'por Id. de Equipo
                                                       nombreArchivo = "Custodias del Equipo Id"
                                                   Case 3 'por Id. de Artículo
                                                       nombreArchivo = "Custodias de Herramienta con Id"
                                               End Select
                                               Cursor = Cursors.WaitCursor
                                               FuncionesBase.FuncionesBase.ExportarExcel(Dgv_Custodias.DataSource, nombreArchivo & identificacion)
                                               Cursor = Cursors.Default
                                               Fr_BuscarCustodia.Close()
                                           End Sub
        Fr_BuscarCustodia.ShowDialog()
    End Sub


    Private Sub Nbi_EnviarCorreosSAPendientesXEA_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EnviarCorreosSAPendientesXEA.ItemClick
        If MsgBox("¿Desea notificar a los bodegueros de los traslados pendientes por ingresar en bodega de destino?", MsgBoxStyle.YesNo, "Enviar correos traslados pendientes por ingreso") = MsgBoxResult.Yes Then
            EnviarCorreosSAPendientesXEA()
        End If
    End Sub


    Private Sub EnviarCorreosSAPendientesXEA()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim TablaUsuarioPendientes As New DataTable("USUARIOSPENDIENTES")
        Dim TablaDocumentosPendientes As New DataTable("SAPENDIENTEXINGRESOENDESTINO")
        Dim Conexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Dim Consulta As New SqlClient.SqlCommand()
        Consulta.Connection = Conexion
        Consulta.CommandText = "SELECT * FROM dbo.SAPendientexIngresoEnDestino() ORDER BY PERSONADESPACHA, BODEGAORIGEN, PERSONARECIBE, BODEGADESTINO"
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        TablaDocumentosPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador.Fill(TablaDocumentosPendientes)
        Consulta.Connection.Close()
        Consulta.CommandText = "SELECT DISTINCT IDPERSONADESPACHA AS IDBODEGUERO FROM dbo.SAPendientexIngresoEnDestino() WHERE CORREODESPACHA <> '' AND ESTADOUSUARIODESPACHA = 'A' " & _
                               "UNION " & _
                               "SELECT DISTINCT IDPERSONARECIBE AS IDBODEGUERO FROM dbo.SAPendientexIngresoEnDestino() WHERE CORREORECIBE <> '' AND ESTADOUSUARIORECIBE = 'A' "
        Dim Adaptador1 As New SqlClient.SqlDataAdapter(Consulta)
        TablaUsuarioPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador1.Fill(TablaUsuarioPendientes)
        Consulta.Connection.Close()
        Dim correos As New DataSet
        correos.Tables.Add(TablaDocumentosPendientes)
        correos.Tables.Add(TablaUsuarioPendientes)
        Windows.Forms.Cursor.Current = Cursors.Default
        Bw_correosSAPendientesXEA.RunWorkerAsync(correos)
    End Sub


    Private Sub Bw_correosSAPendientesXEA_DoWork(sender As Object, e As DoWorkEventArgs) Handles Bw_correosSAPendientesXEA.DoWork
        Dim correos As DataSet = e.Argument
        Dim TablaUsuarioPendientes As DataTable = (correos.Tables("USUARIOSPENDIENTES"))
        Dim TablaDocumentosPendientes As DataTable = (correos.Tables("SAPENDIENTEXINGRESOENDESTINO"))
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
            Dim filasDocumentosDespacha As DataRow()
            Dim filasDocumentosRecibe As DataRow()
            filasDocumentosDespacha = TablaDocumentosPendientes.Select("IDPERSONADESPACHA = " & FilaUsuario("IDBODEGUERO"))
            filasDocumentosRecibe = TablaDocumentosPendientes.Select("IDPERSONARECIBE = " & FilaUsuario("IDBODEGUERO"))
            Dim strBodeguero As String = ""
            Dim strCorreoOrigen As String = ""
            If filasDocumentosDespacha.Length > 0 Then
                strBodeguero = filasDocumentosDespacha(0).Item("PERSONADESPACHA")
                strCorreoOrigen = filasDocumentosDespacha(0).Item("CORREODESPACHA")
            Else
                strBodeguero = filasDocumentosRecibe(0).Item("PERSONARECIBE")
                strCorreoOrigen = filasDocumentosRecibe(0).Item("CORREORECIBE")
            End If
            cuerpo.AppendLine("<center>")
            cuerpo.AppendLine("<div style='padding: 10px; max-width: 1000px;'>")
            cuerpo.AppendLine("<table style='width: 100%;'>")
            cuerpo.AppendLine("    <tr style='border: 1px solid;'>")
            cuerpo.AppendLine("        <td style='width: 170px; text-align: center; padding: 10px;'>")
            cuerpo.AppendLine("            <img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/>")
            cuerpo.AppendLine("        </td>")
            cuerpo.AppendLine("        <td>TRASLADOS PENDIENTES POR INGRESAR EN LA BODEGA DE DESTINO</td>")
            cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br/>" & Date.Now.ToString & "</td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("</table>")
            cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td><b>Bodeguero:</b></td>")
            cuerpo.AppendLine("        <td colspan='7'>" & strBodeguero & "</td>")
            cuerpo.AppendLine("    </tr>")
            If filasDocumentosDespacha.Length > 0 Then
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td colspan='8' style='text-align: center; background-color: silver;'><b>TRASLADOS REALIZADOS POR EL BODEGUERO</b></td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Salida de almacén</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Remisión</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Bodega de origen</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Persona que despacha</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Fecha de despacho</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Bodega de destino</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Persona que recibe</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Fecha de registro</td>")
                cuerpo.AppendLine("    </tr>")
                For nDocDespacha As Integer = 0 To filasDocumentosDespacha.Length - 1
                    Dim filaDocumentosPendientes As DataRow
                    filaDocumentosPendientes = filasDocumentosDespacha(nDocDespacha)
                    cuerpo.AppendLine("    <tr>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("SALIDAALMACEN") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("REMISION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("BODEGAORIGEN") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("PERSONADESPACHA") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("FECHADESPACHO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("BODEGADESTINO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("PERSONARECIBE") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("FECHAREGISTRO") & "</td>")
                    cuerpo.AppendLine("    </tr>")
                Next
            End If
            If filasDocumentosRecibe.Length > 0 Then
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td colspan='8' style='text-align: center; background-color: silver;'><b>TRASLADOS A RECIBIR POR EL BODEGUERO</b></td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Salida de almacén</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Remisión</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Bodega de origen</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Persona que despacha</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Fecha de despacho</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Bodega de destino</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Persona que recibe</td>")
                cuerpo.AppendLine("        <td style='text-align: center; background-color: lemonchiffon;'>Fecha de registro</td>")
                cuerpo.AppendLine("    </tr>")
                For nDocRecibe As Integer = 0 To filasDocumentosRecibe.Length - 1
                    Dim filaDocumentosPendientes As DataRow
                    filaDocumentosPendientes = filasDocumentosRecibe(nDocRecibe)
                    cuerpo.AppendLine("    <tr>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("SALIDAALMACEN") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("REMISION") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("BODEGAORIGEN") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("PERSONADESPACHA") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("FECHADESPACHO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("BODEGADESTINO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("PERSONARECIBE") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align: center;'>" & filaDocumentosPendientes("FECHAREGISTRO") & "</td>")
                    cuerpo.AppendLine("    </tr>")
                Next
            End If
            cuerpo.AppendLine("</table>")
            cuerpo.AppendLine("<hr style='border-style: groove;'/>")
            cuerpo.AppendLine("<p style='text-align: left'>ENVÍO DE RELACIÓN DE TRASLADOS PENDIENTES POR INGRESAR EN LA BODEGA DE DESTINO.<br/>ESTE CORREO FUE ENVIADO AUTOMATICAMENTE, POR FAVOR NO CONTESTAR.</p>")
            FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Traslados pendientes por ingresar en la bodega de destino, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoInformacionMateriales, strCorreoOrigen, Nothing, False, "")
            cuerpo.Clear()
            ni.BalloonTipText = i & " de " & TablaUsuarioPendientes.Rows.Count - 1 & " correos enviados."
            ni.BalloonTipIcon = ToolTipIcon.Info
            ni.ShowBalloonTip(500)
        Next
        ni.BalloonTipText = "Correos enviados exitosamente."
        ni.BalloonTipIcon = ToolTipIcon.Info
        ni.ShowBalloonTip(2000)
    End Sub


    Private Sub DGV_Lista_DataSourceChanged(sender As Object, e As EventArgs) Handles DGV_Lista.DataSourceChanged

    End Sub


    Private Sub Cu_Bodega_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, DGV_Lista.KeyDown, DGV_ListaItem.KeyDown, DGV_Equipos.KeyDown, Nbc_Bodega.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                FuncionesBase.FuncionesBase.AbrirAyudaOnline("/Inicio.aspx?MODULO=Materiales")
            Case Keys.F2
                Select Case Nbc_Bodega.ActiveGroup.Name
                    Case Nbg_SalidaAlmacen.Name
                        CrearSalidaAlmacen()
                    Case Nbg_EntradaAlmacen.Name
                        CrearEntradaAlmacen()
                End Select
            Case Keys.F3
                Select Case Nbc_Bodega.ActiveGroup.Name
                    Case Nbg_SalidaAlmacen.Name
                        BuscarSalidaAlmacen()
                    Case Nbg_EntradaAlmacen.Name
                        BuscarEntradaAlmacen()
                End Select
            Case Keys.F4
                Select Case TablaCargada
                    Case Tabla.Salida
                        CargarSalidasAlmacén(1, "")
                    Case Tabla.Entrada
                        CargarEntradaAlmacén(1)
                    Case Tabla.Bodega
                        CargarBodega()
                End Select
            Case Keys.F6
                ExportarDatosExcel(DGV_Lista)
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
            With .Range(.Cells(1, 1), .Cells(1, DGV_Lista.Columns.Count)).Font
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


    Private Sub Cu_Bodega_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try
            Me.SplitContainer1.Height = Me.Height * 0.7
            Me.SplitContainer1.SplitterDistance = Me.Width * 0.75
            Me.Pn_equiposasociados.Width = Me.Pn_ContenedorItems.Width / 2
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Cms_BodegasInactivas_Opening(sender As Object, e As CancelEventArgs) Handles Cms_BodegasInactivas.Opening
        Dim tieneOpcionesActivas As Boolean = False
        For Each tsmi As ToolStripMenuItem In Cms_BodegasInactivas.Items
            If tsmi.Enabled Then
                tieneOpcionesActivas = True
                Exit For
            End If
        Next
        If Not tieneOpcionesActivas Then
            e.Cancel = True
        End If
    End Sub


    Private Sub VerBodega(idBodega As Integer)
        Dim FrBodega As New Bodegas.Fr_Bodega
        FrBodega.EditandoBodega = True
        FrBodega.SoloLectura = True
        FrBodega.IdBodega = idBodega
        FrBodega.CargarDatos()
        FrBodega.ShowDialog()
    End Sub


    Private Sub Tsmi_VerBodega_Click(sender As Object, e As EventArgs) Handles Tsmi_VerBodega.Click
        VerBodega(DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("ID").Value)
    End Sub


    Private Sub Tsmi_ActivarBodega_Click(sender As Object, e As EventArgs) Handles Tsmi_ActivarBodega.Click
        If DGV_Lista.SelectedRows(0).Cells("ESTADO").Value = "A" Then
            CambiarEstadoBodega(DGV_ListaItem.Rows(DGV_ListaItem.CurrentCell.RowIndex).Cells("ID").Value, "A")
        End If
    End Sub


    Private Sub Nbi_DesactivarBodega_ItemClick(sender As Object, e As EventArgs) Handles Nbi_DesactivarBodega.ItemClick
        If TablaCargada = Tabla.Bodega Then
            If DGV_Lista.SelectedRows(0).Cells("ESTADO").Value = "A" Then
                CambiarEstadoBodega(DGV_Lista.SelectedRows(0).Cells("ID").Value, "I")
            End If
        Else
            MessageBox.Show("Cargue la tabla de bodegas.", "CARGAR BODEGAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    Private Sub CambiarEstadoBodega(idBodega As Integer, tipo As String)
        If TablaCargada = Tabla.Bodega Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.CambiarEstadoBodega", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
            comando.Parameters.Add("@IDBODEGA", SqlDbType.Int)
            comando.Parameters.Add(New SqlParameter("@Mensaje", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
            Select Case tipo
                Case "A"
                    comando.Parameters("@Accion").Value = 1
                Case "I"
                    comando.Parameters("@Accion").Value = 2
            End Select
            comando.Parameters("@IDBODEGA").Value = idBodega
            Try
                conexion.Open()
                comando.ExecuteNonQuery()
                conexion.Close()
                If Not IsDBNull(comando.Parameters("@Mensaje").Value) Then
                    Select Case comando.Parameters("@Mensaje").Value
                        Case 0
                            MessageBox.Show("Cambios guardados.", "Cambiar estado bodega", MessageBoxButtons.OK)
                            CargarBodega()
                        Case 1
                            MessageBox.Show("La bodega aún cuenta artículos en su inventario." & Environment.NewLine & _
                                            "Por favor despache las cantidades del inventario e intente nuevamente.", _
                                            "La bodega tiene inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Select
                End If
            Catch ex As Exception
                MessageBox.Show("Ocurrió un error al intentar cambiar el estado de la bodega.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conexion.Close()
            End Try
        Else
            MessageBox.Show("Cargue la tabla de bodegas.", "CARGAR BODEGAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    Private Sub Nbi_VerBodega_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerBodega.ItemClick
        If TablaCargada = Tabla.Bodega Then
            VerBodega(DGV_Lista.SelectedRows(0).Cells("ID").Value)
        Else
            MessageBox.Show("Cargue la tabla de bodegas.", "CARGAR BODEGAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    Private Sub Nbi_ActivarBodega_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ActivarBodega.ItemClick
        If TablaCargada = Tabla.Bodega Then
            If DGV_ListaItem.SelectedRows(0).Cells("ESTADO").Value = "I" Then
                CambiarEstadoBodega(DGV_ListaItem.SelectedRows(0).Cells("ID").Value, "A")
            End If
        Else
            MessageBox.Show("Cargue la tabla de bodegas.", "CARGAR BODEGAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub DGV_ListaItem_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_ListaItem.CellMouseDown
        If e.Button = MouseButtons.Right Then
            If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
                DGV_ListaItem.ClearSelection()
                DGV_ListaItem.Rows(e.RowIndex).Selected = True
            End If
        End If
    End Sub

    Private Sub Nbi_BuscarCustodiaH_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarCustodiaH.ItemClick
        Dim identificación As String = InputBox("Digite la identificación de la persona", "Identificación", "")
        If Trim(identificación = "") Then
            MsgBox("Identificación no válida", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If IsNumeric(identificación) = False Then
            MsgBox("Identificación no válida", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If identificación.Length > 15 Then
            MsgBox("Identificación no válida", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If DGV_Lista.SelectedRows.Count > 0 Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.CustodiaHerramientasxPersona", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@IDENTIFICACION", identificación)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dtCH As New DataTable
            Try
                conexion.Open()
                adaptador.Fill(dtCH)
                conexion.Close()
                Me.DGV_Lista.DataSource = dtCH
                Me.Lb_Movimiento.Text = "Lista de Salidas de Almacen : " + DGV_Lista.RowCount.ToString
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conexion.Close()
            End Try
            'DGV_Lista.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue
        End If

        For i = 0 To DGV_Lista.ColumnCount - 1
            Select Case DGV_Lista.Columns(i).Name
                Case "Persona Recibe"
                    DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Salida Almacen"
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "Bodega"
                    DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Fecha Registro"
                    DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Id Art."
                    DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Articulo"
                    DGV_Lista.Columns(i).Width = 200
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Cantidad"
                    DGV_Lista.Columns(i).Width = 40
                    DGV_Lista.Columns(i).HeaderText = "Cant."
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "Persona Despacha"
                    DGV_Lista.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    DGV_Lista.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case Else
                    DGV_Lista.Columns(i).Visible = False
            End Select
        Next

    End Sub

    Private Sub SubirArchivosPdf(sender As Object, e As EventArgs) Handles Nbi_SubirSalida.ItemClick, Nbi_SubirEntradaAlmacen.ItemClick
        If Me.DGV_Lista.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
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
                Case "Nbi_SubirSalida"
                    If TablaCargada <> Tabla.Salida Then
                        MsgBox("No esta cargada la tabla de salidas", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(973) Then
                        PuedeSubir = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(972) Then
                            Dim IDBodegaOC As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                            If IDBodegaOC = VariablesBase.VariablesBase.IdBodegaActual Then
                                PuedeSubir = True
                            Else
                                PuedeSubir = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso(971) Then
                                Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDUSUARIOREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
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
                    IdDocumento = Me.DGV_Lista.Item("Id", Index_Registro_Actual).Value.ToString
                    AñoDocumento = Me.DGV_Lista.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_Lista.Item("Servidor", Index_Registro_Actual).Value.ToString
                    Cancelada = Trim(Me.DGV_Lista.Item("Cancelada", Index_Registro_Actual).Value.ToString)
                    NombreDocumento = Trim(Me.DGV_Lista.Item("Salida", Index_Registro_Actual).Value.ToString)
                    If Cancelada = "Total" Or Cancelada = "Parcial" Then
                        TextoLb = "La salida de almacén " + NombreDocumento + " tiene cancelaciones asociadas, indique el documento que desea subir."
                        TextoRbDocumento = "Salida Almacén"
                        TextoRbCanDocumento = "Cancelación de la Salida Almacén"
                        TextoTitulo = "Salida Almacén con cancelaciones asociadas"
                    End If
                Case "Nbi_SubirEntradaAlmacen"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(976) Then
                        PuedeSubir = True
                    Else
                        If FuncionesBase.FuncionesBase.ConsultarPermiso(975) Then
                            Dim IDBodegaOC As Integer = Me.DGV_Lista.Item("IDBODEGA", Me.DGV_Lista.CurrentCell.RowIndex).Value
                            If IDBodegaOC = VariablesBase.VariablesBase.IdBodegaActual Then
                                PuedeSubir = True
                            Else
                                PuedeSubir = False
                            End If
                        Else
                            If FuncionesBase.FuncionesBase.ConsultarPermiso(974) Then
                                Dim IDRegistro As Integer = Me.DGV_Lista.Item("IDPERSONAREGISTRO", Me.DGV_Lista.CurrentCell.RowIndex).Value
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
                    If TablaCargada <> Tabla.Entrada Then
                        MsgBox("No esta cargada la tabla de entradas", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    IdDocumento = Me.DGV_Lista.Item("Id", Index_Registro_Actual).Value.ToString
                    AñoDocumento = Me.DGV_Lista.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_Lista.Item("Servidor", Index_Registro_Actual).Value.ToString
                    Cancelada = Trim(Me.DGV_Lista.Item("Cancelada", Index_Registro_Actual).Value.ToString)
                    NombreDocumento = Trim(Me.DGV_Lista.Item("Entrada", Index_Registro_Actual).Value.ToString)
                    If Cancelada = "Total" Or Cancelada = "Parcial" Then
                        TextoLb = "La Entrada de Almacén " + NombreDocumento + " tiene cancelaciones asociadas, indique el documento que desea subir."
                        TextoRbDocumento = "Entrada Almacén"
                        TextoRbCanDocumento = "Cancelación de la Entrada Almacén"
                        TextoTitulo = "Entrada Almacén con cancelaciones asociadas"
                    End If
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
                            If Boton.Name = "Nbi_SubirSalida" Then
                                TipoDocumento = 3
                            Else
                                If Boton.Name = "Nbi_SubirEntradaAlmacen" Then
                                    TipoDocumento = 4
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
                            If Boton.Name = "Nbi_SubirSalida" Then
                                TipoDocumento = 11
                            Else
                                If Boton.Name = "Nbi_SubirEntradaAlmacen" Then
                                    TipoDocumento = 12
                                End If
                            End If
                        Else
                            If Boton.Name = "Nbi_SubirSalida" Then
                                TipoDocumento = 3
                            Else
                                If Boton.Name = "Nbi_SubirEntradaAlmacen" Then
                                    TipoDocumento = 4
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
                        If MsgBox("Se subirá el documento de la cancelación total, ¿Desea continuar?", MsgBoxStyle.YesNo, "Documento de Cancelación ") = MsgBoxResult.No Then
                            Exit Sub
                        End If
                        If Boton.Name = "Nbi_SubirSalida" Then
                            TipoDocumento = 11
                        Else
                            If Boton.Name = "Nbi_SubirEntradaAlmacen" Then
                                TipoDocumento = 12
                            End If
                        End If
                    Else
                        If Boton.Name = "Nbi_SubirSalida" Then
                            TipoDocumento = 3
                        Else
                            If Boton.Name = "Nbi_SubirEntradaAlmacen" Then
                                TipoDocumento = 4
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
                        Case Tabla.Salida
                            CargarSalidasAlmacén(1, "")
                        Case Tabla.Entrada
                            CargarEntradaAlmacén(1, "")
                    End Select
                End If
            Else
                MsgBox("No cuenta con permisos para subir archivos.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub VerPdfs(sender As Object, e As EventArgs) Handles Nbi_VerSalidaAlmacenPDF.ItemClick, Nbi_VerPdfEntradaAlmacen.ItemClick
        If Me.DGV_Lista.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
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
                Case "Nbi_VerSalidaAlmacenPDF"
                    If TablaCargada <> Tabla.Salida Then
                        MsgBox("No esta cargada la tabla de salidas", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(948) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    CarpetaDrive = "SalidaAlmacén"
                    AñoDocumento = Me.DGV_Lista.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_Lista.Item("Servidor", Index_Registro_Actual).Value.ToString
                    Cancelada = Trim(Me.DGV_Lista.Item("Cancelada", Index_Registro_Actual).Value.ToString)
                    NombreDocumento = Trim(Me.DGV_Lista.Item("Salida", Index_Registro_Actual).Value.ToString)
                    If Cancelada = "Total" Or Cancelada = "Parcial" Then
                        TextoLb = "La salida de almacén " + NombreDocumento + " tiene cancelaciones asociadas, indique el documento que desea ver."
                        TextoRbDocumento = "Salida Almacén"
                        TextoRbCanDocumento = "Cancelación de la Salida Almacén"
                        TextoTitulo = "Salida Almacén con cancelaciones asociadas"
                    End If
                Case "Nbi_VerPdfEntradaAlmacen"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(950) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    If TablaCargada <> Tabla.Entrada Then
                        MsgBox("No esta cargada la tabla de entradas", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    CarpetaDrive = "EntradaAlmacén"
                    AñoDocumento = Me.DGV_Lista.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_Lista.Item("Servidor", Index_Registro_Actual).Value.ToString
                    Cancelada = Trim(Me.DGV_Lista.Item("Cancelada", Index_Registro_Actual).Value.ToString)
                    NombreDocumento = Trim(Me.DGV_Lista.Item("Entrada", Index_Registro_Actual).Value.ToString)
                    If Cancelada = "Total" Or Cancelada = "Parcial" Then
                        TextoLb = "La Entrada de Almacén " + NombreDocumento + " tiene cancelaciones asociadas, indique el documento que desea ver."
                        TextoRbDocumento = "Entrada Almacén"
                        TextoRbCanDocumento = "Cancelación de la Entrada Almacén"
                        TextoTitulo = "Entrada Almacén con cancelaciones asociadas"
                    End If
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


    Private Sub Nbi_SubirPdfBloqueSA_ItemClick(sender As Object, e As EventArgs) Handles Nbi_SubirPdfBloqueSA.ItemClick
        Dim PuedeSubir As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(986) Then
            PuedeSubir = True
        End If
        If PuedeSubir Then
            GoogleDrive.VerificarArchivosEnBaseDatos(3)
        End If
    End Sub

    Private Sub Nbi_SubirPdfBloqueEA_ItemClick(sender As Object, e As EventArgs) Handles Nbi_SubirPdfBloqueEA.ItemClick
        Dim PuedeSubir As Boolean = False
        If FuncionesBase.FuncionesBase.ConsultarPermiso(987) Then
            PuedeSubir = True
        End If
        If PuedeSubir Then
            GoogleDrive.VerificarArchivosEnBaseDatos(4)
        End If
    End Sub

    Private Sub Nbi_HistorialArchivosPdf_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HistorialArchivosPdfSA.ItemClick, Nbi_HistorialArchivosPdfEA.ItemClick
        If Me.DGV_Lista.SelectedRows.Count > 0 Then
            Index_Registro_Actual = Me.DGV_Lista.CurrentCell.RowIndex
            Dim Boton As NetBarControl.NetBarItem = CType(sender, NetBarControl.NetBarItem)
            Dim CarpetaDrive, AñoDocumento, NombreDocumento, SubidoNube As String
            Dim PuedeVer As Boolean

            Select Case Boton.Name
                Case "Nbi_HistorialArchivosPdfSA"
                    If TablaCargada <> Tabla.Salida Then
                        MsgBox("No esta cargada la tabla de salidas", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(426) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    CarpetaDrive = "SalidaAlmacén"
                    NombreDocumento = DGV_Lista.Rows(Index_Registro_Actual).Cells("Salida").Value.ToString
                    AñoDocumento = Me.DGV_Lista.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_Lista.Item("Servidor", Index_Registro_Actual).Value.ToString
                Case "Nbi_HistorialArchivosPdfEA"
                    If FuncionesBase.FuncionesBase.ConsultarPermiso(428) Then
                        PuedeVer = True
                    Else
                        PuedeVer = False
                    End If
                    If TablaCargada <> Tabla.Entrada Then
                        MsgBox("No esta cargada la tabla de entradas", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    CarpetaDrive = "EntradaAlmacén"
                    NombreDocumento = Trim(Me.DGV_Lista.Item("Entrada", Index_Registro_Actual).Value.ToString)
                    AñoDocumento = Me.DGV_Lista.Item("AÑO", Index_Registro_Actual).Value.ToString
                    SubidoNube = Me.DGV_Lista.Item("Servidor", Index_Registro_Actual).Value.ToString
                Case Else
                    Exit Sub
            End Select
            'CarpetaDrive = "Pruebas"

            If SubidoNube <> "S" Then
                Exit Sub
            End If
            If PuedeVer = True Then
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

    Private Sub Nbi_ImpSticker_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImpSticker.ItemClick
        If TablaCargada = Tabla.Entrada Then

            Dim EA As Integer
            Dim TipoEA As String
            Dim FechaEA As Date

            TipoEA = Me.DGV_Lista.Item("Tipo", Me.DGV_Lista.CurrentCell.RowIndex).Value

            EA = Me.DGV_Lista.Item("Id", Me.DGV_Lista.CurrentCell.RowIndex).Value
            FechaEA = Me.DGV_Lista.Item("Fecha Recibido", Me.DGV_Lista.CurrentCell.RowIndex).Value

            If TipoEA = "C" And (VariablesBase.VariablesBase.IdBodegaActual = 20 Or VariablesBase.VariablesBase.IdBodegaActual = 71) Then

                Dim FrImprimirSticker As New Articulos.Fr_ImprimirSticker
                FrImprimirSticker.Tipo = "EAS"

                Dim dt_sticker As New DataTable("STICKER")
                dt_sticker.Columns.Add("Cód", Type.GetType("System.Int32"))
                'dt_sticker.Columns.Add("Und")
                dt_sticker.Columns.Add("Requisición")
                dt_sticker.Columns.Add("Orden Compra")
                dt_sticker.Columns.Add("Descripción")
                dt_sticker.Columns.Add("Cant", Type.GetType("System.Int32"))

                For Each row As DataGridViewRow In DGV_ListaItem.Rows

                    Dim Fila As DataRow = dt_sticker.NewRow()
                    Fila("Cód") = row.Cells(1).Value
                    Fila("Requisición") = row.Cells(3).Value
                    Fila("Orden Compra") = row.Cells(6).Value
                    Fila("Descripción") = row.Cells(2).Value
                    Fila("Cant") = row.Cells(9).Value
                    dt_sticker.Rows.Add(Fila)
                Next
                FrImprimirSticker.FechaEA = FechaEA
                FrImprimirSticker.EA = EA
                FrImprimirSticker.Tb_Sticker_EA = dt_sticker
                FrImprimirSticker.ShowDialog()

            Else

                Dim FrImprimirSticker As New Articulos.Fr_ImprimirSticker
                FrImprimirSticker.Tipo = "EA"

                Dim dt_sticker As New DataTable("STICKER")
                dt_sticker.Columns.Add("Cód", Type.GetType("System.Int32"))
                dt_sticker.Columns.Add("Und")
                dt_sticker.Columns.Add("Descripción")
                dt_sticker.Columns.Add("Cant", Type.GetType("System.Int32"))

                'llenar el dt_sticker

                For Each row As DataGridViewRow In DGV_ListaItem.Rows

                    Dim Fila As DataRow = dt_sticker.NewRow()
                    Fila("Cód") = row.Cells(1).Value
                    Fila("Und") = row.Cells(5).Value
                    Fila("Descripción") = row.Cells(2).Value
                    Fila("Cant") = row.Cells(9).Value
                    dt_sticker.Rows.Add(Fila)

                Next
                FrImprimirSticker.Tb_Sticker_EA = dt_sticker
                FrImprimirSticker.ShowDialog()
            End If
        Else
            MsgBox("No esta cargada la tabla de Entradas de Almacén")
        End If

    End Sub



#Region "ENVIO DE CORREOS CUSTODIAS PENDIENTES POR SUBIR PDF"

    Private Sub EnviarCorreocustodiasPendientesSubirPDF()

        Dim objStreamWriter As StreamWriter
        'Pass the file path and the file name to the StreamWriter constructor.


        nombrearchivo = "\correosSACustodiaPendientes" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt"
        If IO.File.Exists(VariablesBase.VariablesBase._path + nombrearchivo) = True Then

            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + nombrearchivo, True)

        Else
            objStreamWriter = New StreamWriter(VariablesBase.VariablesBase._path + "\" + nombrearchivo)
        End If


        Cursor = System.Windows.Forms.Cursors.WaitCursor

        Dim TablaUsuarioPendientes As New DataTable("USUARIOSPENDIENTES")
        Dim TablaDocumentosPendientes As New DataTable("CUSTODIASPENDIENTES")
        Dim TablaResumenPendientes As New DataTable("RESUMENPENDIENTES")

        Dim Consulta As New SqlClient.SqlCommand()
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Consulta.CommandText = "SELECT * FROM dbo.SAPendienteSubirPDF() ORDER BY [Persona Registro], [IDSALIDAALMACEN]"
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        TablaDocumentosPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador.Fill(TablaDocumentosPendientes)
        Consulta.Connection.Close()

        Consulta.CommandText = "SELECT DISTINCT IDUSUARIOREGISTRO FROM dbo.SAPendienteSubirPDF() WHERE Correo <> '' "
        Dim Adaptador1 As New SqlClient.SqlDataAdapter(Consulta)
        TablaUsuarioPendientes.Clear()
        Consulta.Connection.Open()
        Adaptador1.Fill(TablaUsuarioPendientes)
        Consulta.Connection.Close()

        Consulta.CommandText = "   SELECT [Persona Registro], COUNT(SalidaAlmacen) AS CANTIDAD,  " & _
        "SUM(CASE YEAR(FECHAREGISTRO) WHEN 2018 THEN 1 ELSE 0 END) AS 'A2018', " & _
        "SUM(CASE YEAR(FECHAREGISTRO) WHEN 2019 THEN 1 ELSE 0 END) AS 'A2019', " & _
        "SUM(CASE YEAR(FECHAREGISTRO) WHEN 2020 THEN 1 ELSE 0 END) AS 'A2020', " & _
        "SUM(CASE YEAR(FECHAREGISTRO) WHEN 2021 THEN 1 ELSE 0 END) AS 'A2021', " & _
        "SUM(CASE YEAR(FECHAREGISTRO) WHEN 2022 THEN 1 ELSE 0 END) AS 'A2022' " & _
        "FROM dbo.SAPendienteSubirPDF() " & _
        "GROUP BY [Persona Registro]" & _
        "ORDER BY [Persona Registro]"
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
            filasDocumentosPendientes = TablaDocumentosPendientes.Select("IDUSUARIOREGISTRO=" + FilaUsuario("IDUSUARIOREGISTRO").ToString)
            Dim filasDocumentosPendientesReferencia As DataRow
            filasDocumentosPendientesReferencia = filasDocumentosPendientes(0)

            Try
                'crear cuerpo
                cuerpo.AppendLine("<center>")
                cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
                cuerpo.AppendLine("<table style='width:100%;'>")
                cuerpo.AppendLine("    <tr style='border:1px solid;'>")
                cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
                cuerpo.AppendLine("        <td>SALIDAS ALMACEN TIPO CUSTODIA SIN SUBIR PDF A SERVIDOR<br />")
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
                cuerpo.AppendLine("        <td colspan='8' style='text-align:center; background-color:silver;'><b>PENDIENTES POR SUBIR</b></td>")
                cuerpo.AppendLine("    </tr>")
                cuerpo.AppendLine("    <tr>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>SALIDA ALMACEN</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>FECHA REGISTRO</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PERSONA RECIBE</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PERSONA REGISTRÓ</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>PERSONA DESPACHA</td>")
                cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>BODEGA</td>")
                cuerpo.AppendLine("    </tr>")

                For nrodocumentopendiente = 0 To filasDocumentosPendientes.Count - 1
                    Dim filaDocumentosPendientes As DataRow
                    filaDocumentosPendientes = filasDocumentosPendientes(nrodocumentopendiente)
                    cuerpo.AppendLine("    <tr>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("SALIDAALMACEN") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("FECHAREGISTRO") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Persona Recibe") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Persona Registro") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("Persona Despacha") & "</td>")
                    cuerpo.AppendLine("        <td style='text-align:center;'>" & filaDocumentosPendientes("NOMBREBODEGA") & "</td>")
                    cuerpo.AppendLine("    </tr>")
                Next

                cuerpo.AppendLine("</table><hr style='border-style:groove;' />")

                cuerpo.AppendLine("<p style='text-align:left'>ENVÍO DE RELACION SALIDAS DE ALMACÉN QUE FALTAN POR SUBIR PDF AL SERVIDOR.")
                cuerpo.AppendLine("ENVÍO DE RELACIÓN SALIDAS ALMACÉN TIPO CUSTODIA PENDIENTES POR SUBIR PDF AL SERVIDOR. ESTE CORREO FUE ENVIADO AUTOMÁTICAMENTE, POR FAVOR NO LO CONTESTE. ANTE CUALQUIER INQUIETUD POR FAVOR REMÍTASE A LA PERSONA ENCARGADA.</p>")

                FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "Salidas Almacen Tipo Custodia con pendientes por subir PDF al servidor, " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoInformacionMateriales, filasDocumentosPendientesReferencia("Correo"), Nothing, False, "")
                objStreamWriter.WriteLine(filasDocumentosPendientesReferencia("Correo").ToString + ">" + "SI>" + Date.Now.ToString + ">" + VariablesBase.VariablesBase.correoInformacionMateriales.ToString)
                cuerpo.Clear()
                ni.BalloonTipText = i & " de " & TablaUsuarioPendientes.Rows.Count - 1 & " correos enviados."
                ni.BalloonTipIcon = ToolTipIcon.Info
                ni.ShowBalloonTip(500)
            Catch ex As Exception
                objStreamWriter.WriteLine(filasDocumentosPendientesReferencia("Correo") + ">" + "NO>" + Date.Now.ToString)
                FuncionesBase.FuncionesBase.RegistrarCorreoEnviado(filasDocumentosPendientesReferencia("Correo"), "NO", VariablesBase.VariablesBase.correoInformacionMateriales)
                MsgBox(ex.Message)
            End Try
        Next
        objStreamWriter.Close()
        'Resumen para Auditor y Jefe Administración
        cuerpo.Clear()
        Try
            cuerpo.AppendLine("<center>")
            cuerpo.AppendLine("<div style='padding:10px; max-width :1000px;'>")
            cuerpo.AppendLine("<table style ='width:100%;'>")
            cuerpo.AppendLine("    <tr style='border:1px solid;'>")
            cuerpo.AppendLine("        <td style='width:170px; text-align:center; padding:10px;'><img src='http://190.0.43.174:7070/imagenes/logo.png' width='150px'/></td>")
            cuerpo.AppendLine("        <td>RESUMEN DE SALIDAS ALMACEN PENDIENTES SUBIR PDF A SERVIDOR<br />")
            cuerpo.AppendLine("        <td>ENVIADO POR: " & VariablesBase.VariablesBase.Nombre_Usuario & "<br />")
            cuerpo.AppendLine(Date.Now.ToString)
            cuerpo.AppendLine("        </td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("</table>")

            cuerpo.AppendLine("<table style='width:100%;' border='1' cellpadding='8' cellspacing='0'>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td colspan='7' style='text-align:center; background-color:silver;'><b>RESUMEN DE SALIDAS ALMACEN PENDIENTES SUBIR PDF A SERVIDOR</b></td>")
            cuerpo.AppendLine("    </tr>")
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td style='text-align:center; background-color:lemonchiffon;'>Persona Registro</td>")
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
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("CANTIDAD") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2018") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2019") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2020") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2021") & "</td>")
                cuerpo.AppendLine("        <td style='text-align:center;'>" & filaResumenPendientes("A2022") & "</td>")
                cuerpo.AppendLine("    </tr>")
            Next
            cuerpo.AppendLine("    <tr>")
            cuerpo.AppendLine("        <td colspan='1'style='text-align:right;'>" & "TOTALES:" & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(CANTIDAD)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2018)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2019)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2020)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2021)", "") & "</td>")
            cuerpo.AppendLine("        <td style='text-align:center;'>" & TablaResumenPendientes.Compute("Sum(A2022)", "") & "</td>")
            cuerpo.AppendLine("    </tr>")

            cuerpo.AppendLine("</table><hr style='border-style:groove;' />")
            cuerpo.AppendLine("<p style='text-align:left'>ENVÍO DE RELACION SALIDAS ALMACEN TIPO CUSTODIA PENDIENTES POR SUBIR PDF AL SERVIDOR.")
            cuerpo.AppendLine(" ESTE CORREO FUE ENVIADO AUTOMÁTICAMENTE, POR FAVOR NO LO CONTESTE. ANTE CUALQUIER INQUIETUD POR FAVOR REMÍTASE A LA PERSONA ENCARGADA.</p>")


            'Dim direccionesConCopia As New List(Of String)
            'direccionesConCopia.Add("soporteaplicaciones@ismocol.com")
            'FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "RELACION SALIDAS ALMACEN TIPO CUSTODIA PENDIENTES POR SUBIR PDF AL SERVIDOR. " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoInformacionMateriales, "materiales@ismocol.com", direccionesConCopia, False, "")

            FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "RELACION SALIDAS ALMACEN TIPO CUSTODIA PENDIENTES POR SUBIR PDF AL SERVIDOR. " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoInformacionMateriales, "materiales@ismocol.com", Nothing, False, "")


            'FuncionesBase.FuncionesBase.EnviarCorreo(cuerpo.ToString, "RELACION SALIDAS ALMACEN TIPO CUSTODIA PENDIENTES POR SUBIR PDF AL SERVIDOR. " & Date.Now.ToLongDateString, VariablesBase.VariablesBase.correoInformacionMateriales, "bodega@ismocol.com", Nothing, False, "")


            cuerpo.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = System.Windows.Forms.Cursors.Default
        ni.BalloonTipText = "Correos enviados exitosamente."
        ni.BalloonTipIcon = ToolTipIcon.Info
        ni.ShowBalloonTip(2000)
        Cursor = Cursors.Default

        If MsgBox("¿Visualizar el registro de envío de correos?", MsgBoxStyle.YesNo, "Visualizar registro correos") = MsgBoxResult.Yes Then
            visorCorreos(nombrearchivo)
        End If
    End Sub
#End Region
    
    Private Sub Nbi_EnviarCorreoPenSATC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EnviarCorreoPenSATC.ItemClick

        If MsgBox("¿Seguro que desea enviar los correos de salidas de almacen tipo custodia pendientes por subir PDF al servidor?", MsgBoxStyle.YesNo, "ENVIAR CORREOS PENDIENTES SUBIR PDF") = MsgBoxResult.Yes Then
            EnviarCorreocustodiasPendientesSubirPDF()
        End If
        visorCorreos(nombrearchivo)
    End Sub
    Public Sub visorCorreos(ByVal nombre As String)
        Dim FrVisorRegistrosCorreo As New FormulariosClasesBase.Fr_VisorRegistrosCorreo
        FrVisorRegistrosCorreo._nombreArchivo = nombre.ToString
        FrVisorRegistrosCorreo.ShowDialog()
    End Sub
    Private Sub Nbi_TrasCustodia_ItemClick(sender As Object, e As EventArgs) Handles Nbi_TrasCustodia.ItemClick

        Dim FrTrasladoCustodias As New Bodegas.Fr_TrasladoCustodias
        FrTrasladoCustodias.CargarDatos()
        FrTrasladoCustodias.ShowDialog()

    End Sub


End Class 'Cu_Bodega

Friend Class Entrada
    Private _Id As Integer
    Private _FechaR As String
    Private _Verifica As String
    Private _Aprobo As String
    Private _Recibio As String
    Private _Tipo As String
    Private _Entrada As String
    Private _Registro As String
    Private _Cancelar As String
    Private _Impreso As String

    <Description("Tipo de entrada de almacén"), _
    Category("Identificación"),
    DisplayNameAttribute("Tipo Entrada")> _
    Public ReadOnly Property Tipo() As String
        Get
            Return _Tipo
        End Get
    End Property

    <Description("Identificación de la Entrada de almacén"), _
    Category("Identificación"),
    DisplayNameAttribute("Entrada de almacén")> _
    Public ReadOnly Property Entrada() As String
        Get
            Return _Entrada
        End Get
    End Property

    <Description("Fecha de la entrada de almacén"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Entrada")> _
    Public ReadOnly Property FechaR() As String
        Get
            Return _FechaR
        End Get
    End Property

    <Description("Verifica entrada de almacén"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Verifica")> _
    Public ReadOnly Property Verifica() As String
        Get
            Return _Verifica
        End Get
    End Property

    <Description("Aprueba Entrada de almacén"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Aprueba")> _
    Public ReadOnly Property Aprobo() As String
        Get
            Return _Aprobo
        End Get
    End Property

    <Description("Recibió Entrada de almacén"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Recibió")> _
    Public ReadOnly Property Recibio() As String
        Get
            Return _Recibio
        End Get
    End Property

    <Description("Registro Entrada de almacén"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Registro")> _
    Public ReadOnly Property Registro() As String
        Get
            Return _Registro
        End Get
    End Property

    <Description("Usuario Cancelo Entrada de almacén"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Cancelo ")> _
    Public ReadOnly Property Cancelar() As String
        Get
            Return _Cancelar
        End Get
    End Property

    <Description("Indica si el documento ya fue impreso"), _
    Category("Documento"),
    DisplayNameAttribute("Impreso")> _
    Public ReadOnly Property Impreso() As String
        Get
            Return _Impreso
        End Get
    End Property

    Public Sub New(ByVal FilaREntrada As DataGridViewRow)
        Me._FechaR = FilaREntrada.Cells("Fecha Recibido").Value
        Me._Verifica = FilaREntrada.Cells("Verifica").Value
        Me._Aprobo = FilaREntrada.Cells("Aprobo").Value
        Me._Recibio = FilaREntrada.Cells("Recibio").Value
        Me._Registro = FilaREntrada.Cells("Registro").Value
        Me._Entrada = FilaREntrada.Cells("Entrada").Value
        If FilaREntrada.Cells("IMPRESA").Value = "S" Then
            Me._Impreso = "Si"
        Else
            Me._Impreso = "No"
        End If
        Try
            Me._Cancelar = FilaREntrada.Cells("Cancelo").Value
        Catch ex As Exception
            Me._Cancelar = ""
        End Try
        Select Case FilaREntrada.Cells("Tipo").Value
            Case "I"
                Me._Tipo = "Ajuste de inventario"
            Case "V"
                Me._Tipo = "Inventario Inicial"
            Case "R"
                Me._Tipo = "Requisición"
            Case "A"
                Me._Tipo = "Alquiler"
            Case "C"
                Me._Tipo = "Orden de Compra"
            Case "T"
                Me._Tipo = "Traslado de Bodega"
            Case "D"
                Me._Tipo = "Devolución a Bodega"
            Case "S"
                Me._Tipo = "Retorno de Custodia"
            Case "H"
                Me._Tipo = "Devolución de Herramienta"
            Case Else
                Me._Tipo = ""
        End Select
    End Sub
End Class 'Entrada


Friend Class Salida
    ' "Fecha Despacho", "Recibio", "Autorizada", "Autoriza", "Destino", "Transporta"
    Private _Id As Integer
    Private _FechaD As String
    Private _EmpresaTransporta As String
    Private _PlacaVehiculo As String
    Private _RecibioTransportador As String
    Private _Recibio As String
    Private _Autoriza As String
    Private _Destino As String
    Private _Registro As String
    Private _Despacho As String
    Private _Salida As String
    Private _Tipo As String
    Private _Remisión As String
    Private _Cancelar As String
    Private _Impreso As String
    Private _IdEquipo As String
    Private _CodEquipo As String
    Private _TipoEnvio As String

    <Description("Identificación de remisión de la salida de almacén"), _
    Category("Destino"),
    DisplayNameAttribute("Remisión")> _
    Public ReadOnly Property Remisión() As String
        Get
            Return _Remisión
        End Get
    End Property

    <Description("Identificación de la salida de almacén"), _
    Category("Identificación"),
    DisplayNameAttribute("Salida Almacén")> _
    Public ReadOnly Property Salida() As String
        Get
            Return _Salida
        End Get
    End Property

    <Description("Tipo de la salida de almacén"), _
    Category("Identificación"),
    DisplayNameAttribute("Tipo Salida Almacén")> _
    Public ReadOnly Property Tipo() As String
        Get
            Return _Tipo
        End Get
    End Property

    <Description("Fecha de la salida de almacén"), _
    Category("Fecha"),
    DisplayNameAttribute("Fecha Salida Almacén")> _
    Public ReadOnly Property FechaD() As String
        Get
            Return _FechaD
        End Get
    End Property

    <Description("Empresa de transporte"), _
    Category("Transporta"),
    DisplayNameAttribute("Empresa de transporte")> _
    Public ReadOnly Property EmpresaTransporta() As String
        Get
            Return _EmpresaTransporta
        End Get
    End Property

    <Description("Placa Vehículo que transporta"), _
    Category("Transporta"),
    DisplayNameAttribute("Placa Vehículo")> _
    Public ReadOnly Property PlacaVehiculo() As String
        Get
            Return _PlacaVehiculo
        End Get
    End Property

    <Description("Persona que recibió la salida de almacén para transportar"), _
    Category("Transporta"),
    DisplayNameAttribute("Persona Recibió")> _
    Public ReadOnly Property RecibioTransportador() As String
        Get
            Return _RecibioTransportador
        End Get
    End Property

    <Description("Usuario que autoriza la salida de almacén"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Autoriza")> _
    Public ReadOnly Property Autoriza() As String
        Get
            Return _Autoriza
        End Get
    End Property

    <Description("Usuario que registró la salida de almacén"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Registró")> _
    Public ReadOnly Property Registro() As String
        Get
            Return _Registro
        End Get
    End Property

    <Description("Usuario que despachó la salida de almacén"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Despachó")> _
    Public ReadOnly Property Despacho() As String
        Get
            Return _Despacho
        End Get
    End Property

    <Description("Persona que recibió la salida de almacén"), _
    Category("Usuario"),
    DisplayNameAttribute("Persona Recibió")> _
    Public ReadOnly Property Recibio() As String
        Get
            Return _Recibio
        End Get
    End Property

    <Description("Lugar de destino"), _
    Category("Destino"),
    DisplayNameAttribute("Bodega de destino")> _
    Public ReadOnly Property Destino() As String
        Get
            Return _Destino
        End Get
    End Property

    <Description("Usuario que canceló la salida de almacén"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Canceló")> _
    Public ReadOnly Property Cancelar() As String
        Get
            Return _Cancelar
        End Get
    End Property
    <Description("Indica si el documento ya fue impreso"), _
    Category("Documento"),
    DisplayNameAttribute("Impreso")> _
    Public ReadOnly Property Impreso() As String
        Get
            Return _Impreso
        End Get
    End Property

    <Description("Id del equipo asociado a la Salida de Almacén"), _
    Category("Equipo"),
    DisplayNameAttribute("Id Equipo asociado")> _
    Public ReadOnly Property IdEquipo() As String
        Get
            Return _IdEquipo
        End Get
    End Property

    <Description("Código del equipo asociado a la Salida de Almacén"), _
    Category("Equipo"),
    DisplayNameAttribute("Código Equipo asociado")> _
    Public ReadOnly Property CodEquipo() As String
        Get
            Return _CodEquipo
        End Get
    End Property

    <Description("Tipo de Envío"), _
    Category("Transporta"),
    DisplayNameAttribute("Tipo Envío")> _
    Public ReadOnly Property TipoEnvio() As String
        Get
            Return _TipoEnvio
        End Get
    End Property

    Public Sub New(ByVal FilaRSalida As DataGridViewRow)
        _FechaD = FilaRSalida.Cells("Fecha Despacho").Value
        _EmpresaTransporta = FilaRSalida.Cells("Transporta").Value
        _PlacaVehiculo = FilaRSalida.Cells("PLACAVEHICULO").Value
        _RecibioTransportador = FilaRSalida.Cells("RECIBETRANSPORTADOR").Value
        _Recibio = FilaRSalida.Cells("Recibio").Value
        _Autoriza = FilaRSalida.Cells("Autoriza").Value
        _Destino = FilaRSalida.Cells("Destino").Value
        _Registro = FilaRSalida.Cells("Registro").Value
        _Despacho = FilaRSalida.Cells("Despacho").Value
        _Salida = FilaRSalida.Cells("Salida").Value
        If FilaRSalida.Cells("IMPRESA").Value = "N" Then
            _Impreso = "No"
        Else
            _Impreso = "Si"
        End If
        Try
            Me._Cancelar = FilaRSalida.Cells("Cancelo").Value
        Catch ex As Exception
            _Cancelar = ""
        End Try
        Select Case FilaRSalida.Cells("Tipo").Value
            Case "I"
                Me._Tipo = "Ajuste de Inventario"
            Case "C"
                Me._Tipo = "Consumo"
            Case "D"
                Me._Tipo = "Dotación"
            Case "R"
                Me._Tipo = "Atender Requisición"
            Case "T"
                Me._Tipo = "Traslado de Bodega"
            Case "A"
                Me._Tipo = "Devolución Alquiler"
            Case "S"
                Me._Tipo = "Custodia de Equipo"
            Case "H"
                Me._Tipo = "Custodia de Herramienta"
            Case Else
                Me._Tipo = ""
        End Select
        _Remisión = IIf(IsDBNull(FilaRSalida.Cells("IdRemisión").Value), "", FilaRSalida.Cells("IdRemisión").Value)
        Try
            _IdEquipo = FilaRSalida.Cells("IDEQUIPO").Value
            _CodEquipo = FilaRSalida.Cells("CODIGO").Value
        Catch
            _IdEquipo = ""
            _CodEquipo = ""
        End Try
        If Not IsDBNull(FilaRSalida.Cells("TipoEnvio").Value) Then
            Select Case FilaRSalida.Cells("TipoEnvio").Value
                Case "E"
                    _TipoEnvio = "Exportación"
                Case "I"
                    _TipoEnvio = "Importación"
                Case "N"
                    _TipoEnvio = "No Aplica"
                Case Else
                    _TipoEnvio = ""
            End Select
        Else
            _TipoEnvio = ""
        End If
    End Sub
End Class 'Salida


Friend Class Bodega
    Private _DIRECCION As String
    Private _INDICACIONES As String
    Private _CIUDAD As String
    Private _TELEFONOBODEGA As String
    Private _CELULARBODEGA As String
    Private _EMAILBODEGA As String
    Private _PERSONACOMPRA As String
    Private _TELEFONOCOMPRA As String
    Private _EMAILCOMPRA As String
    Private _CELULARCOMPRA As String
    Private _CENTROCOSTOS As String

    <Description("Indicaciones para llegar a la bodega"), _
    Category("Ubicación"),
    DisplayNameAttribute("Indicaciones")> _
    Public ReadOnly Property INDICACIONES() As String
        Get
            Return _INDICACIONES
        End Get
    End Property

    <Description("Ciudad donde esta localizada la bodega"), _
    Category("Ubicación"),
    DisplayNameAttribute("Ciudad")> _
    Public ReadOnly Property CIUDAD() As String
        Get
            Return _CIUDAD
        End Get
    End Property

    <Description("Número de teléfono de la Bodega"), _
    Category("Bodega"),
    DisplayNameAttribute("Teléfono Bodega")> _
    Public ReadOnly Property TELEFONOBODEGA() As String
        Get
            Return _TELEFONOBODEGA
        End Get
    End Property

    <Description("Número celular de la Bodega"), _
    Category("Bodega"),
    DisplayNameAttribute("Celular")> _
    Public ReadOnly Property CELULARBODEGA() As String
        Get
            Return _CELULARBODEGA
        End Get
    End Property

    <Description("Dirección de correo de la bodega "), _
    Category("Bodega"),
    DisplayNameAttribute("Correo electrónico")> _
    Public ReadOnly Property EMAILBODEGA() As String
        Get
            Return _EMAILBODEGA
        End Get
    End Property

    <Description("Persona encargada de las compras en la bodega"), _
    Category("Usuario"),
    DisplayNameAttribute("Comprador")> _
    Public ReadOnly Property PERSONACOMPRA() As String
        Get
            Return _PERSONACOMPRA
        End Get
    End Property

    <Description("Teléfono compras de la bodega"), _
    Category("Compras"),
    DisplayNameAttribute("Teléfono")> _
    Public ReadOnly Property TELEFONOCOMPRA() As String
        Get
            Return _TELEFONOCOMPRA
        End Get
    End Property

    <Description("Correo del comprador de la bodega"), _
    Category("Compras"),
    DisplayNameAttribute("Correo electrónico")> _
    Public ReadOnly Property EMAILCOMPRA() As String
        Get
            Return _EMAILCOMPRA
        End Get
    End Property

    <Description("Centro de costos de la bodega"), _
    Category("Costos"),
    DisplayNameAttribute("Centro de costos")> _
    Public ReadOnly Property CENTROCOSTOS() As String
        Get
            Return _CENTROCOSTOS
        End Get
    End Property

    <Description("Celular Comprador"), _
    Category("Compras"),
    DisplayNameAttribute("Celular")> _
    Public ReadOnly Property CELULARCOMPRA() As String
        Get
            Return _CELULARCOMPRA
        End Get
    End Property

    Public Sub New(ByVal FilaRBodega As DataGridViewRow)
        Me._INDICACIONES = FilaRBodega.Cells("INDICACIONES").Value
        Me._CIUDAD = FilaRBodega.Cells("CIUDAD").Value
        Me._TELEFONOBODEGA = IIf(IsDBNull(FilaRBodega.Cells("TELEFONO BODEGA").Value) = True, "", FilaRBodega.Cells("TELEFONO BODEGA").Value)
        Me._CELULARBODEGA = IIf(IsDBNull(FilaRBodega.Cells("CELULAR BODEGA").Value) = True, "", FilaRBodega.Cells("CELULAR BODEGA").Value)
        Me._EMAILBODEGA = IIf(IsDBNull(FilaRBodega.Cells("E-MAIL BODEGA").Value) = True, "", FilaRBodega.Cells("E-MAIL BODEGA").Value)
        Me._TELEFONOCOMPRA = IIf(IsDBNull(FilaRBodega.Cells("TELEFONO COMPRA").Value) = True, "", FilaRBodega.Cells("TELEFONO COMPRA").Value)
        Me._CELULARCOMPRA = IIf(IsDBNull(FilaRBodega.Cells("CELULAR COMPRA").Value) = True, "", FilaRBodega.Cells("CELULAR COMPRA").Value)
        Me._EMAILCOMPRA = IIf(IsDBNull(FilaRBodega.Cells("E-MAIL COMPRA").Value) = True, "", FilaRBodega.Cells("E-MAIL COMPRA").Value)
        Me._CENTROCOSTOS = FilaRBodega.Cells("CENTRO COSTO").Value
    End Sub
End Class 'Bodega


Friend Class Remisión
    Private _OrdenCompra As String
    Private _SalidaAlmacén As String
    Private _Despachado As String
    Private _Autoriza As String
    Private _Digita As String
    Private _Recibe As String
    Private _Id As String
    Private _IdRemisión As String
    Private _Requisición As String
    Private _CiudadyFechas As String
    Private _EmpresaTransporta As String
    Private _PlacaVehiculo As String
    Private _RecibioTransportador As String

    <Description("Identificación de la Remisión"), _
    Category("Identificación"),
    DisplayNameAttribute("Remisión")> _
    Public ReadOnly Property IdRemisión() As String
        Get
            Return _IdRemisión
        End Get
    End Property

    <Description("Identificación de la salida de almacén"), _
    Category("Identificación"),
    DisplayNameAttribute("Id Salida de Almacén")> _
    Public ReadOnly Property Id() As String
        Get
            Return _Id
        End Get
    End Property

    <Description("Ciudad y Fecha de la Remisión"), _
    Category("Identificación"),
    DisplayNameAttribute("Ciudad y Fecha")> _
    Public ReadOnly Property CiudadyFechas() As String
        Get
            Return _CiudadyFechas
        End Get
    End Property

    <Description("Empresa de transporte"), _
    Category("Transporta"),
    DisplayNameAttribute("Empresa de transporte")> _
    Public ReadOnly Property EmpresaTransporta() As String
        Get
            Return _EmpresaTransporta
        End Get
    End Property

    <Description("Placa Vehículo que transporta"), _
    Category("Transporta"),
    DisplayNameAttribute("Placa Vehículo")> _
    Public ReadOnly Property PlacaVehiculo() As String
        Get
            Return _PlacaVehiculo
        End Get
    End Property

    <Description("Persona que recibió la salida de almacén para transportar"), _
    Category("Transporta"),
    DisplayNameAttribute("Persona Recibió")> _
    Public ReadOnly Property RecibioTransportador() As String
        Get
            Return _RecibioTransportador
        End Get
    End Property

    <Description("Orden de Compra asociada a la Remisión"), _
    Category("Asociada"),
    DisplayNameAttribute("Salida Almacén")> _
    Public ReadOnly Property SalidaAlmacén() As String
        Get
            Return _SalidaAlmacén
        End Get
    End Property

    <Description("Orden de Compra asociada a la Remisión"), _
    Category("Asociada"),
    DisplayNameAttribute("Orden de compra")> _
    Public ReadOnly Property OrdenCompra() As String
        Get
            Return _OrdenCompra
        End Get
    End Property

    <Description("Requisición asociada a la Remisión"), _
    Category("Asociada"),
    DisplayNameAttribute("Requisición")> _
    Public ReadOnly Property Requisición() As String
        Get
            Return _Requisición
        End Get
    End Property


    <Description("Usuario que Despacha la remisión"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Despacha")> _
    Public ReadOnly Property Despachado() As String
        Get
            Return _Despachado
        End Get
    End Property

    <Description("Usuario que autoriza la remisión"), _
    Category("Usuario"),
    DisplayNameAttribute("Usuario Autoriza")> _
    Public ReadOnly Property Autoriza() As String
        Get
            Return _Autoriza
        End Get
    End Property

    <Description("Persona que recibió la remisión"), _
    Category("Usuario"),
    DisplayNameAttribute("Persona recibió")> _
    Public ReadOnly Property Recibe() As String
        Get
            Return _Recibe
        End Get
    End Property

    <Description("Usuario que digitó la remisión"), _
        Category("Usuario"),
        DisplayNameAttribute("Usuario Digitó")> _
    Public ReadOnly Property Digita() As String
        Get
            Return _Digita
        End Get
    End Property


    Public Sub New(ByVal FilaREntrada As DataGridViewRow)
        Me._EmpresaTransporta = FilaREntrada.Cells("Transporta").Value
        Me._PlacaVehiculo = FilaREntrada.Cells("PLACAVEHICULO").Value
        Me._RecibioTransportador = FilaREntrada.Cells("RECIBETRANSPORTADOR").Value
        Me._SalidaAlmacén = FilaREntrada.Cells("Salida").Value

        Me._CiudadyFechas = IIf(IsDBNull(FilaREntrada.Cells("Ciudad y Fecha").Value) = True, "", FilaREntrada.Cells("Ciudad y Fecha").Value)
        Me._OrdenCompra = IIf(IsDBNull(FilaREntrada.Cells("Orden de Compra").Value) = True, "", FilaREntrada.Cells("Orden de Compra").Value)

        Me._Despachado = IIf(IsDBNull(FilaREntrada.Cells("Despacha").Value) = True, "", FilaREntrada.Cells("Despacha").Value)
        Me._Autoriza = IIf(IsDBNull(FilaREntrada.Cells("Autoriza").Value) = True, "", FilaREntrada.Cells("Autoriza").Value)
        Me._Digita = IIf(IsDBNull(FilaREntrada.Cells("Digita").Value) = True, "", FilaREntrada.Cells("Digita").Value)
        Me._Recibe = IIf(IsDBNull(FilaREntrada.Cells("Recibe").Value) = True, "", FilaREntrada.Cells("Recibe").Value)
        Me._Id = IIf(IsDBNull(FilaREntrada.Cells("Id").Value) = True, "", FilaREntrada.Cells("Id").Value)
        Me._IdRemisión = IIf(IsDBNull(FilaREntrada.Cells("IdRemisión").Value) = True, "", FilaREntrada.Cells("IdRemisión").Value)
        Me._Requisición = IIf(IsDBNull(FilaREntrada.Cells("Requisición").Value) = True, "", FilaREntrada.Cells("Requisición").Value)
    End Sub
End Class 'Remisión