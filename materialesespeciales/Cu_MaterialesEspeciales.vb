Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports FormulariosMaterialesEspeciales
Imports DatosClasesBase

Public Class Cu_MaterialesEspeciales
    Private TablaCargada As String = ""
    Private Structure TablasME
        Const Isometricos = "Isométricos"
        Const Spools = "Spools"
        Const Planos = "Planos"
        Const Tipicos = "Típicos"
        Const Carretes = "Carretes"
        Const EntradaMaterial = "EntradaMaterial"
        Const SalidaMaterial = "SalidaMaterial"
    End Structure

    Public Sub Cargar_Tabla()
        Nbc_MaterialesEspeciales.ActiveGroup = Nbg_Isometricos
        TablaCargada = TablasME.Isometricos
        CargarListaxSeleccion()
    End Sub

    Private Sub Nbi_CargarIsometricos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarIsometricos.ItemClick
        TablaCargada = TablasME.Isometricos
        CargarListaxSeleccion()
    End Sub

    Private Sub Nbi_CrearIsometrico_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearIsometrico.ItemClick
        Dim frIsometrico As New Fr_Isometrico
        frIsometrico.Edicion = Fr_Isometrico.TipoEdicion.Crear
        frIsometrico.ShowDialog()
    End Sub

    Private Sub Nbi_VerIsometrico_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerIsometrico.ItemClick
        Dim frIsometrico As New Fr_Isometrico
        frIsometrico.Id = Dgv_ListaMaterialesEspeciales.SelectedRows(0).Cells(MTE_ISOMETRICO.IdIsometrico).Value
        frIsometrico.Edicion = Fr_Isometrico.TipoEdicion.Ver
        frIsometrico.ShowDialog()
    End Sub

    Private Sub Nbi_EditarIsometrico_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarIsometrico.ItemClick
        Dim frIsometrico As New Fr_Isometrico
        frIsometrico.Id = Dgv_ListaMaterialesEspeciales.SelectedRows(0).Cells(MTE_ISOMETRICO.IdIsometrico).Value
        frIsometrico.Edicion = Fr_Isometrico.TipoEdicion.Editar
        frIsometrico.ShowDialog()
    End Sub

    Private Sub Nbi_CargarSpools_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarSpools.ItemClick
        TablaCargada = TablasME.Spools
        CargarListaxSeleccion()
    End Sub

    Private Sub Nbi_CrearSpool_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearSpool.ItemClick
        Dim frIsometrico As New Fr_Isometrico
        frIsometrico.EsTipoSpool = True
        frIsometrico.Edicion = Fr_Isometrico.TipoEdicion.Crear
        frIsometrico.ShowDialog()
    End Sub

    Private Sub Nbi_VerSpool_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerSpool.ItemClick
        Dim frIsometrico As New Fr_Isometrico
        frIsometrico.EsTipoSpool = True
        frIsometrico.Id = Dgv_ListaMaterialesEspeciales.SelectedRows(0).Cells(MTE_SPOOL.IdSpool).Value
        frIsometrico.Edicion = Fr_Isometrico.TipoEdicion.Ver
        frIsometrico.ShowDialog()
    End Sub

    Private Sub Nbi_EditarSpool_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarSpool.ItemClick
        Dim frIsometrico As New Fr_Isometrico
        frIsometrico.EsTipoSpool = True
        frIsometrico.Id = Dgv_ListaMaterialesEspeciales.SelectedRows(0).Cells(MTE_SPOOL.IdSpool).Value
        frIsometrico.Edicion = Fr_Isometrico.TipoEdicion.Editar
        frIsometrico.ShowDialog()
    End Sub

    Private Sub Dgv_ListaMaterialesEspeciales_SelectionChanged(sender As Object, e As EventArgs) Handles Dgv_ListaMaterialesEspeciales.SelectionChanged
        If Dgv_ListaMaterialesEspeciales.SelectedRows.Count > 0 Then
            CargarItems()
            CargarPropiedades()
        End If
    End Sub

    Private Sub CargarListaxSeleccion()
        Try
            Cursor.Current = Cursors.WaitCursor
            Select Case TablaCargada
                Case TablasME.Isometricos
                    Dgv_ListaMaterialesEspeciales.DataSource = GestionarIsometrico(6, New DataTable, 0, "", "", "", 0, 0, 0, 0, "")
                    If Dgv_ListaMaterialesEspeciales.Rows.Count > 0 Then
                        For i = 0 To Dgv_ListaMaterialesEspeciales.ColumnCount - 1
                            Select Case Dgv_ListaMaterialesEspeciales.Columns(i).Name
                                Case MTE_ISOMETRICO.IdIsometrico, MTE_ISOMETRICO.Abreviatura, MTE_ISOMETRICO.Revision, MTE_ISOMETRICO.NroHoja
                                    Dgv_ListaMaterialesEspeciales.Columns(i).Width = 50
                                Case MTE_ISOMETRICO.Isometrico, MTE_ISOMETRICO.Descripcion, MTE_ISOMETRICO.Linea ', MTE_ISOMETRICO.Proyecto
                                    Dgv_ListaMaterialesEspeciales.Columns(i).Width = 120
                                Case Else
                                    Dgv_ListaMaterialesEspeciales.Columns(i).Visible = False
                            End Select
                        Next
                        Dgv_ListaMaterialesEspeciales.Rows(0).Selected = True
                        CargarPropiedades()
                    End If
                Case TablasME.Spools
                    Dgv_ListaMaterialesEspeciales.DataSource = GestionarSpool(6, New DataTable, 0, "", "", "", "", "", 0, "")
                    If Dgv_ListaMaterialesEspeciales.Rows.Count > 0 Then
                        For i = 0 To Dgv_ListaMaterialesEspeciales.ColumnCount - 1
                            Select Case Dgv_ListaMaterialesEspeciales.Columns(i).Name
                                Case MTE_SPOOL.IdSpool, MTE_SPOOL.Abreviatura, MTE_SPOOL.Estado, MTE_SPOOL.IdIsometrico
                                    Dgv_ListaMaterialesEspeciales.Columns(i).Width = 50
                                Case MTE_SPOOL.Spool, MTE_SPOOL.Descripcion, MTE_SPOOL.Ubicacion, MTE_SPOOL.Isometrico
                                    Dgv_ListaMaterialesEspeciales.Columns(i).Width = 120
                                Case Else
                                    Dgv_ListaMaterialesEspeciales.Columns(i).Visible = False
                            End Select
                        Next
                        Dgv_ListaMaterialesEspeciales.Rows(0).Selected = True
                        CargarPropiedades()
                    End If
                Case TablasME.Planos

                Case TablasME.Tipicos

                Case TablasME.Carretes

                Case TablasME.EntradaMaterial

                Case TablasME.SalidaMaterial

            End Select
            Cursor.Current = Cursors.Default
            CargarItems()
        Catch ex As Exception
            Pg_DetalleLista.SelectedObject = Nothing
        End Try
    End Sub

    Private Sub CargarItems()
        Select Case TablaCargada
            Case TablasME.Isometricos
                Dgv_ListaItemMaterialesEspeciales.DataSource = GestionarIsometrico(5, New DataTable, Dgv_ListaMaterialesEspeciales.SelectedRows(0).Cells(MTE_ISOMETRICO.IdIsometrico).Value, "", "", "", 0, 0, 0, 0, "")
                For i = 0 To Dgv_ListaItemMaterialesEspeciales.ColumnCount - 1
                    Select Case Dgv_ListaItemMaterialesEspeciales.Columns(i).Name
                        Case MTE_ITEMISOMETRICO.Cantidad, MTE_ITEMISOMETRICO.IdArticulo, MTE_ITEMISOMETRICO.IdIsometrico, MTE_ITEMISOMETRICO.IdItemIsometrico
                            Dgv_ListaItemMaterialesEspeciales.Columns(i).Width = 50
                        Case MTE_ITEMISOMETRICO.Articulo, MTE_ITEMISOMETRICO.CodigoIngenieria, MTE_ITEMISOMETRICO.Colada, MTE_ITEMISOMETRICO.Estado, MTE_ITEMISOMETRICO.Isometrico, _
                            MTE_ITEMISOMETRICO.Ubicacion
                            Dgv_ListaItemMaterialesEspeciales.Columns(i).Width = 120
                        Case Else
                            Dgv_ListaItemMaterialesEspeciales.Columns(i).Visible = False
                    End Select
                Next
            Case TablasME.Spools
                Dgv_ListaItemMaterialesEspeciales.DataSource = GestionarSpool(5, New DataTable, Dgv_ListaMaterialesEspeciales.SelectedRows(0).Cells(MTE_SPOOL.IdSpool).Value, "", "", "", 0, 0, 0, "")
                For i = 0 To Dgv_ListaItemMaterialesEspeciales.ColumnCount - 1
                    Select Case Dgv_ListaItemMaterialesEspeciales.Columns(i).Name
                        Case MTE_ITEMSPOOL.Cantidad, MTE_ITEMSPOOL.IdArticulo, MTE_ITEMSPOOL.IdSpool, MTE_ITEMSPOOL.IdItemSpool
                            Dgv_ListaItemMaterialesEspeciales.Columns(i).Width = 50
                        Case MTE_ITEMSPOOL.Articulo, MTE_ITEMSPOOL.CodigoIngenieria, MTE_ITEMSPOOL.Colada, MTE_ITEMSPOOL.Estado, MTE_ITEMSPOOL.Spool, _
                            MTE_ITEMSPOOL.Ubicacion
                            Dgv_ListaItemMaterialesEspeciales.Columns(i).Width = 120
                        Case Else
                            Dgv_ListaItemMaterialesEspeciales.Columns(i).Visible = False
                    End Select
                Next
            Case TablasME.Planos

            Case TablasME.Tipicos

            Case TablasME.Carretes

            Case TablasME.EntradaMaterial

            Case TablasME.SalidaMaterial

        End Select
    End Sub

    Private Sub CargarPropiedades()
        If Dgv_ListaMaterialesEspeciales.Rows.Count > 0 Then
            If Dgv_ListaMaterialesEspeciales.SelectedRows.Count > 0 Then
                Dim drv As DataRowView = Dgv_ListaMaterialesEspeciales.SelectedRows(0).DataBoundItem
                Dim so As New Object
                Select Case TablaCargada
                    Case TablasME.Isometricos
                        so = New Isometrico(drv.Row)
                    Case TablasME.Spools
                        so = New Spool(drv.Row)
                    Case TablasME.Planos

                    Case TablasME.Tipicos

                    Case TablasME.Carretes

                    Case TablasME.EntradaMaterial

                    Case TablasME.SalidaMaterial

                    Case Else
                        so = Nothing
                End Select
                If Not IsNothing(so) Then
                    Pg_DetalleLista.SelectedObject = so
                End If
            End If
        End If
    End Sub

    Private Sub Nbi_BuscarIsometrico_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarIsometrico.ItemClick
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")

        campos.Rows.Add("", "Identificador", "")
        campos.Rows.Add("", "Isométrico", "")
        campos.Rows.Add("", "Abreviatura", "")
        campos.Rows.Add("", "Línea", "")

        frbuscar.campos = campos
        frbuscar.tabla = -1
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarFiltro(DSbusqueda)
            Else
                MsgBox("Ningún Registro Encontrado.")
            End If
        End If
    End Sub

    Private Sub CargarFiltro(ByVal DsTabla As DataSet)
        Dgv_ListaMaterialesEspeciales.DataSource = Nothing
        Dgv_ListaMaterialesEspeciales.DataSource = DsTabla.Tables(0).DefaultView
        Dgv_ListaMaterialesEspeciales.AutoGenerateColumns = True
        Dgv_ListaMaterialesEspeciales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Dgv_ListaMaterialesEspeciales.ReadOnly = True
        Lb_Cantidad.Text = "Cantidad de Personas: " + DsTabla.Tables(0).Rows.Count.ToString
        For i = 0 To Dgv_ListaMaterialesEspeciales.ColumnCount - 1
            Select Case Dgv_ListaMaterialesEspeciales.Columns(i).Name
                Case MTE_ISOMETRICO.IdIsometrico
                    Dgv_ListaMaterialesEspeciales.Columns(i).Width = 80
                    Dgv_ListaMaterialesEspeciales.Columns(i).ToolTipText = ""
                    Dgv_ListaMaterialesEspeciales.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                Case MTE_ISOMETRICO.Isometrico
                    Dgv_ListaMaterialesEspeciales.Columns(i).Width = 80
                    Dgv_ListaMaterialesEspeciales.Columns(i).ToolTipText = ""
                    Dgv_ListaMaterialesEspeciales.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                Case MTE_ISOMETRICO.Descripcion
                    Dgv_ListaMaterialesEspeciales.Columns(i).Width = 160
                    Dgv_ListaMaterialesEspeciales.Columns(i).ToolTipText = ""
                    Dgv_ListaMaterialesEspeciales.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                Case MTE_ISOMETRICO.Abreviatura
                    Dgv_ListaMaterialesEspeciales.Columns(i).Width = 200
                    Dgv_ListaMaterialesEspeciales.Columns(i).ToolTipText = ""
                    Dgv_ListaMaterialesEspeciales.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                Case MTE_ISOMETRICO.Revision
                    Dgv_ListaMaterialesEspeciales.Columns(i).Width = 80
                    Dgv_ListaMaterialesEspeciales.Columns(i).ToolTipText = ""
                    Dgv_ListaMaterialesEspeciales.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                Case MTE_ISOMETRICO.NroHoja
                    Dgv_ListaMaterialesEspeciales.Columns(i).Width = 40
                    Dgv_ListaMaterialesEspeciales.Columns(i).ToolTipText = ""
                    Dgv_ListaMaterialesEspeciales.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                Case MTE_ISOMETRICO.Linea
                    Dgv_ListaMaterialesEspeciales.Columns(i).Width = 140
                    Dgv_ListaMaterialesEspeciales.Columns(i).ToolTipText = ""
                    Dgv_ListaMaterialesEspeciales.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                Case Else
                    Dgv_ListaMaterialesEspeciales.Columns(i).Visible = False
            End Select
        Next
        Try
            Dgv_ListaMaterialesEspeciales.Rows(0).Selected = True
        Catch ex As Exception
        End Try
    End Sub
End Class

Friend Class Isometrico
    Private _IdIsometrico As Integer
    Private _Isometrico As String
    Private _Descripcion As String
    Private _Abreviatura As String
    Private _Revision As Integer
    Private _NroHoja As Integer
    Private _Proyecto As String
    Private _Linea As String
    Private _UsuarioRegistra As String
    Private _FechaRegistro As String
    Private _UsuarioModifica As String
    Private _FechaModificacion As String

    <Description("Identificador del Isométrico en SIGMA"),
    Category("Identificación"),
    DisplayNameAttribute("Id Isométrico")>
    Public ReadOnly Property IdIsometrico() As String
        Get
            Return _IdIsometrico
        End Get
    End Property
    <Description("Nombre del Isométrico"),
    Category("Identificación"),
    DisplayNameAttribute("Isométrico")>
    Public ReadOnly Property Isometrico() As String
        Get
            Return _Isometrico
        End Get
    End Property
    <Description("Descripción del Isométrico"),
    Category("Identificación"),
    DisplayNameAttribute("Descripción")>
    Public ReadOnly Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
    End Property
    <Description("Abreviatura del Isométrico"),
    Category("Identificación"),
    DisplayNameAttribute("Abreviatura")>
    Public ReadOnly Property Abreviatura() As String
        Get
            Return _Abreviatura
        End Get
    End Property
    <Description("Revisión del Isométrico"),
    Category(""),
    DisplayNameAttribute("Revisión")>
    Public ReadOnly Property Revision() As String
        Get
            Return _Revision
        End Get
    End Property
    <Description("Número de Hoja de la Línea"),
    Category(""),
    DisplayNameAttribute("Número de Hoja")>
    Public ReadOnly Property NroHoja() As String
        Get
            Return _NroHoja
        End Get
    End Property
    <Description("Proyecto"),
    Category(""),
    DisplayNameAttribute("Proyecto")>
    Public ReadOnly Property Proyecto() As String
        Get
            Return _Proyecto
        End Get
    End Property
    <Description("Línea"),
    Category(""),
    DisplayNameAttribute("Línea")>
    Public ReadOnly Property Linea() As String
        Get
            Return _Linea
        End Get
    End Property
    <Description("Usuario que registró"),
    Category(""),
    DisplayNameAttribute("Usuario registra")>
    Public ReadOnly Property UsuarioRegistra() As String
        Get
            Return _UsuarioRegistra
        End Get
    End Property
    <Description("Fecha de registro"),
    Category(""),
    DisplayNameAttribute("Fecha registro")>
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property
    <Description("Usuario que modificó"),
    Category(""),
    DisplayNameAttribute("Usuario modifica")>
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property
    <Description("Fecha de modificación"),
    Category(""),
    DisplayNameAttribute("Fecha modificación")>
    Public ReadOnly Property FechaModificacion() As String
        Get
            Return _FechaModificacion
        End Get
    End Property

    Public Sub New(ByVal FilaIsometrico As DataRow)
        _IdIsometrico = FilaIsometrico(MTE_ISOMETRICO.IdIsometrico)
        _Isometrico = FilaIsometrico(MTE_ISOMETRICO.Isometrico)
        Try
            _Descripcion = FilaIsometrico(MTE_ISOMETRICO.Descripcion)
        Catch
            _Descripcion = ""
        End Try
        _Abreviatura = FilaIsometrico(MTE_ISOMETRICO.Abreviatura)
        _Revision = FilaIsometrico(MTE_ISOMETRICO.Revision)
        _NroHoja = FilaIsometrico(MTE_ISOMETRICO.NroHoja)
        _Proyecto = FilaIsometrico(MTE_ISOMETRICO.Proyecto)
        _Linea = FilaIsometrico(MTE_ISOMETRICO.Linea)
        _UsuarioRegistra = FilaIsometrico(MTE_ISOMETRICO.UsuarioRegistra)
        _FechaRegistro = FilaIsometrico(MTE_ISOMETRICO.FechaRegistro)
        Try
            _UsuarioModifica = FilaIsometrico(MTE_ISOMETRICO.UsuarioModifica)
        Catch
            _UsuarioModifica = ""
        End Try
        Try
            _FechaModificacion = FilaIsometrico(MTE_ISOMETRICO.FechaModificacion)
        Catch
            _FechaModificacion = ""
        End Try
    End Sub
End Class

Friend Class Spool
    Private _IdSpool As Integer
    Private _Spool As String
    Private _Descripcion As String
    Private _Abreviatura As String
    Private _Estado As String
    Private _Ubicacion As String
    Private _IdIsometrico As Integer
    Private _Isometrico As String
    Private _UsuarioRegistra As String
    Private _FechaRegistro As String
    Private _UsuarioModifica As String
    Private _FechaModificacion As String

    <Description("Identificador del Spool en SIGMA"),
    Category("Identificación"),
    DisplayNameAttribute("Id Spool")>
    Public ReadOnly Property IdSpool() As String
        Get
            Return _IdSpool
        End Get
    End Property
    <Description("Nombre del Spool"),
    Category("Identificación"),
    DisplayNameAttribute("Spool")>
    Public ReadOnly Property Spool() As String
        Get
            Return _Spool
        End Get
    End Property
    <Description("Descripción del Spool"),
    Category("Identificación"),
    DisplayNameAttribute("Descripción")>
    Public ReadOnly Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
    End Property
    <Description("Abreviatura del Spool"),
    Category("Identificación"),
    DisplayNameAttribute("Abreviatura")>
    Public ReadOnly Property Abreviatura() As String
        Get
            Return _Abreviatura
        End Get
    End Property
    <Description("Estado del Spool"),
    Category("Identificación"),
    DisplayNameAttribute("Estado")>
    Public ReadOnly Property Estado() As String
        Get
            Return _Estado
        End Get
    End Property
    <Description("Ubicación del Spool"),
    Category("Identificación"),
    DisplayNameAttribute("Ubicación")>
    Public ReadOnly Property Ubicacion() As String
        Get
            Return _Ubicacion
        End Get
    End Property
    <Description("Identificador del Isométrico en SIGMA"),
    Category("Identificación"),
    DisplayNameAttribute("Id Isométrico")>
    Public ReadOnly Property IdIsometrico() As String
        Get
            Return _IdIsometrico
        End Get
    End Property
    <Description("Nombre del Isométrico"),
    Category("Identificación"),
    DisplayNameAttribute("Isométrico")>
    Public ReadOnly Property Isometrico() As String
        Get
            Return _Isometrico
        End Get
    End Property
    <Description("Fecha de registro"),
    Category(""),
    DisplayNameAttribute("Fecha registro")>
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property
    <Description("Usuario que modificó"),
    Category(""),
    DisplayNameAttribute("Usuario modifica")>
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property
    <Description("Fecha de modificación"),
    Category(""),
    DisplayNameAttribute("Fecha modificación")>
    Public ReadOnly Property FechaModificacion() As String
        Get
            Return _FechaModificacion
        End Get
    End Property

    Public Sub New(ByVal FilaIsometrico As DataRow)
        Try
            _IdSpool = FilaIsometrico(MTE_SPOOL.IdSpool)
            _Spool = FilaIsometrico(MTE_SPOOL.Spool)
            Try
                _Descripcion = FilaIsometrico(MTE_SPOOL.Descripcion)
            Catch
                _Descripcion = ""
            End Try
            _Abreviatura = FilaIsometrico(MTE_SPOOL.Abreviatura)
            _Estado = FilaIsometrico(MTE_SPOOL.Estado)
            Try
                _Ubicacion = FilaIsometrico(MTE_SPOOL.Ubicacion)
            Catch
                _Ubicacion = ""
            End Try
            _IdIsometrico = FilaIsometrico(MTE_SPOOL.IdIsometrico)
            _Isometrico = FilaIsometrico(MTE_SPOOL.Isometrico)
            _UsuarioRegistra = FilaIsometrico(MTE_SPOOL.UsuarioRegistra)
            _FechaRegistro = FilaIsometrico(MTE_SPOOL.FechaRegistro)
            Try
                _UsuarioModifica = FilaIsometrico(MTE_SPOOL.UsuarioModifica)
            Catch
                _UsuarioModifica = ""
            End Try
            Try
                _FechaModificacion = FilaIsometrico(MTE_SPOOL.FechaModificacion)
            Catch
                _FechaModificacion = ""
            End Try
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
End Class