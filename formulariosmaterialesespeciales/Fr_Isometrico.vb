Imports System.Data.SqlClient
Imports DatosClasesBase
Imports System.Windows.Forms
Imports System.Drawing
Imports Articulos

Public Class Fr_Isometrico
    Public Property Id As Integer = 0
    Public Property Edicion As TipoEdicion
    Public Property EsTipoSpool As Boolean = False
    Private dt_Isometrico As DataTable
    Private dt_Spool As DataTable
    Private dt_Items As DataTable
    Private dt_Estados As DataTable
    Public Enum TipoEdicion
        Crear
        Ver
        Editar
    End Enum
    Private Estilo_Celda As DataGridViewCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    Dim Estilo_Celda_Error As New DataGridViewCellStyle

    Public Sub New()
        InitializeComponent()
        dt_Isometrico = New DataTable
        dt_Spool = New DataTable
        dt_Items = New DataTable
        dt_Estados = New DataTable
        AddHandler Tx_Revision.KeyPress, AddressOf FuncionesBase.FuncionesBase.TextBoxNumericoEntero_KeyPress
    End Sub

    Public Sub Comportamiento_Predeterminado()
        Dgv_ItemIsometrico.DefaultCellStyle = Estilo_Celda
        ' Definir el estilo de encabezado del DataGrid para que salga en dos renglones
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New Font("Arial", 7.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.[True]
        Dgv_ItemIsometrico.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Dgv_ItemIsometrico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    End Sub

    Private Sub Fr_Isometrico_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dgv_ItemIsometrico.ClearSelection()
        Tx_Nombre.Focus()
    End Sub

    Private Sub Fr_Isometrico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar datos
        Cb_Proyecto.DataSource = GestionarProyecto(7, 0, "", "", "", "")
        Cb_Proyecto.ValueMember = MTE_PROYECTO.IdProyecto
        Cb_Proyecto.DisplayMember = MTE_PROYECTO.Proyecto

        If EsTipoSpool Then
            dt_Estados.Columns.Add("CODIGO")
            dt_Estados.Columns.Add("NOMBRE")
            dt_Estados.Rows.Add("A", "Activo")
            dt_Estados.Rows.Add("C", "Cuarentena")
            Cb_Estado.DataSource = dt_Estados
            Cb_Estado.ValueMember = "CODIGO"
            Cb_Estado.DisplayMember = "NOMBRE"

            Lb_NroHoja.Visible = False
            Cb_NroHoja.Visible = False
            Lb_Revision.Visible = False
            Tx_Revision.Visible = False

            Me.Text = "Spool"
            Lb_TituloItems.Text = "ÍTEMS SPOOL"
        Else ' Isométrico
            Lb_Isometrico.Visible = False
            Cb_Isometrico.Visible = False
            Bt_AgregarItemsSpool.Visible = False
            Lb_Estado.Visible = False
            Cb_Estado.Visible = False
            Lb_Ubicacion.Visible = False
            Tx_Ubicacion.Visible = False
        End If

        ' Asignar datos
        If Edicion = TipoEdicion.Ver Or Edicion = TipoEdicion.Editar Then
            If EsTipoSpool Then
                dt_Spool = GestionarSpool(4, New DataTable, Id, "", "", "", "", "", 0, "")
                dt_Items = GestionarSpool(5, New DataTable, Id, "", "", "", "", "", 0, "")
                Cb_Isometrico.SelectedValue = dt_Spool.Rows(0).Item(MTE_SPOOL.IdIsometrico)
                Tx_Nombre.Text = dt_Spool.Rows(0).Item(MTE_SPOOL.Isometrico)
                Tx_Abreviatura.Text = dt_Spool.Rows(0).Item(MTE_SPOOL.Abreviatura)
                Tx_Descripcion.Text = dt_Spool.Rows(0).Item(MTE_SPOOL.Descripcion)
                Tx_Ubicacion.Text = dt_Spool.Rows(0).Item(MTE_SPOOL.Ubicacion)
                Cb_Estado.SelectedValue = dt_Spool.Rows(0).Item(MTE_SPOOL.Estado)

                Dgv_ItemIsometrico.DataSource = dt_Items
                For i As Integer = 0 To Dgv_ItemIsometrico.Columns.Count - 1
                    Select Case Dgv_ItemIsometrico.Columns(i).Name
                        Case MTE_ITEMSPOOL.IdItemSpool, MTE_ITEMSPOOL.IdArticulo, MTE_ITEMSPOOL.Cantidad, MTE_ITEMSPOOL.Estado
                            Dgv_ItemIsometrico.Columns(i).Width = 50
                        Case MTE_ITEMSPOOL.Articulo, MTE_ITEMSPOOL.CodigoIngenieria, MTE_ITEMSPOOL.Colada, MTE_ITEMSPOOL.Ubicacion
                            Dgv_ItemIsometrico.Columns(i).Width = 120
                        Case Else
                            Dgv_ItemIsometrico.Columns(i).Visible = False
                    End Select
                    Select Case Dgv_ItemIsometrico.Columns(i).Name
                        Case MTE_ITEMSPOOL.IdArticulo, MTE_ITEMSPOOL.Cantidad

                        Case Else
                            Dgv_ItemIsometrico.Columns(i).ReadOnly = True
                    End Select
                Next
            Else ' Isométrico
                dt_Isometrico = GestionarIsometrico(4, New DataTable, Id, "", "", "", 0, 0, 0, 0, "")
                dt_Items = GestionarIsometrico(5, New DataTable, Id, "", "", "", 0, 0, 0, 0, "")
                Cb_Proyecto.SelectedValue = dt_Isometrico.Rows(0).Item(MTE_ISOMETRICO.IdProyecto)
                Cb_Linea.SelectedValue = dt_Isometrico.Rows(0).Item(MTE_ISOMETRICO.IdLinea)
                Cb_NroHoja.SelectedValue = dt_Isometrico.Rows(0).Item(MTE_ISOMETRICO.NroHoja)
                Cb_Isometrico.SelectedValue = dt_Isometrico.Rows(0).Item(MTE_ISOMETRICO.IdIsometrico)
                Tx_Nombre.Text = dt_Isometrico.Rows(0).Item(MTE_ISOMETRICO.Isometrico)
                Tx_Abreviatura.Text = dt_Isometrico.Rows(0).Item(MTE_ISOMETRICO.Abreviatura)
                Tx_Revision.Text = dt_Isometrico.Rows(0).Item(MTE_ISOMETRICO.Revision)
                Tx_Descripcion.Text = dt_Isometrico.Rows(0).Item(MTE_ISOMETRICO.Descripcion)

                Dgv_ItemIsometrico.DataSource = dt_Items
                For i As Integer = 0 To Dgv_ItemIsometrico.Columns.Count - 1
                    Select Case Dgv_ItemIsometrico.Columns(i).Name
                        Case MTE_ITEMISOMETRICO.IdItemIsometrico, MTE_ITEMISOMETRICO.IdArticulo, MTE_ITEMISOMETRICO.Cantidad, MTE_ITEMISOMETRICO.Estado
                            Dgv_ItemIsometrico.Columns(i).Width = 50
                        Case MTE_ITEMISOMETRICO.Articulo, MTE_ITEMISOMETRICO.CodigoIngenieria, MTE_ITEMISOMETRICO.Colada, MTE_ITEMISOMETRICO.Ubicacion
                            Dgv_ItemIsometrico.Columns(i).Width = 120
                        Case Else
                            Dgv_ItemIsometrico.Columns(i).Visible = False
                    End Select
                    Select Case Dgv_ItemIsometrico.Columns(i).Name
                        Case MTE_ITEMISOMETRICO.IdArticulo, MTE_ITEMISOMETRICO.Cantidad, MTE_ITEMISOMETRICO.Estado
                            Dgv_ItemIsometrico.Columns(i).ReadOnly = False
                        Case Else
                            Dgv_ItemIsometrico.Columns(i).ReadOnly = True
                    End Select
                Next
            End If
        Else ' Crear
            If EsTipoSpool Then
                dt_Items.Columns.Add(MTE_ITEMSPOOL.IdItemSpool)
                dt_Items.Columns.Add(MTE_ITEMSPOOL.IdSpool)
                dt_Items.Columns.Add(MTE_ITEMSPOOL.Spool)
                dt_Items.Columns.Add(MTE_ITEMSPOOL.IdArticulo)
                dt_Items.Columns.Add(MTE_ITEMSPOOL.Articulo)
                dt_Items.Columns.Add(MTE_ITEMSPOOL.Cantidad)
                dt_Items.Columns.Add(MTE_ITEMSPOOL.CodigoIngenieria)
                dt_Items.Columns.Add(MTE_ITEMSPOOL.Colada)
                dt_Items.Columns.Add(MTE_ITEMSPOOL.Estado)
                dt_Items.Columns.Add(MTE_ITEMSPOOL.Ubicacion)
                Dgv_ItemIsometrico.DataSource = dt_Items
                For i As Integer = 0 To Dgv_ItemIsometrico.Columns.Count - 1
                    Select Case Dgv_ItemIsometrico.Columns(i).Name
                        Case MTE_ITEMSPOOL.IdItemSpool, MTE_ITEMSPOOL.IdArticulo, MTE_ITEMSPOOL.Cantidad, MTE_ITEMSPOOL.Estado
                            Dgv_ItemIsometrico.Columns(i).Width = 50
                        Case MTE_ITEMSPOOL.Articulo, MTE_ITEMSPOOL.CodigoIngenieria, MTE_ITEMSPOOL.Colada, MTE_ITEMSPOOL.Ubicacion
                            Dgv_ItemIsometrico.Columns(i).Width = 120
                        Case Else
                            Dgv_ItemIsometrico.Columns(i).Visible = False
                    End Select
                    Select Case Dgv_ItemIsometrico.Columns(i).Name
                        Case MTE_ITEMSPOOL.IdArticulo, MTE_ITEMSPOOL.Cantidad

                        Case Else
                            Dgv_ItemIsometrico.Columns(i).ReadOnly = True
                    End Select
                    Dgv_ItemIsometrico.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Next
            Else ' Isométrico
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.IdItemIsometrico)
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.IdIsometrico)
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.Isometrico)
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.IdArticulo)
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.Articulo)
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.Cantidad)
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.CodigoIngenieria)
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.Colada)
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.Estado)
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.Ubicacion)
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.IdUsuarioModifica)
                dt_Items.Columns.Add(MTE_ITEMISOMETRICO.FechaModificacion)
                Dgv_ItemIsometrico.DataSource = dt_Items
                For i As Integer = 0 To Dgv_ItemIsometrico.Columns.Count - 1
                    Select Case Dgv_ItemIsometrico.Columns(i).Name
                        Case MTE_ITEMISOMETRICO.IdItemIsometrico, MTE_ITEMISOMETRICO.IdArticulo, MTE_ITEMISOMETRICO.Cantidad, MTE_ITEMISOMETRICO.Estado
                            Dgv_ItemIsometrico.Columns(i).Width = 50
                        Case MTE_ITEMISOMETRICO.Articulo, MTE_ITEMISOMETRICO.CodigoIngenieria, MTE_ITEMISOMETRICO.Colada, MTE_ITEMISOMETRICO.Ubicacion
                            Dgv_ItemIsometrico.Columns(i).Width = 120
                        Case Else
                            Dgv_ItemIsometrico.Columns(i).Visible = False
                    End Select
                    Select Case Dgv_ItemIsometrico.Columns(i).Name
                        Case MTE_ITEMISOMETRICO.IdArticulo, MTE_ITEMISOMETRICO.Cantidad, MTE_ITEMISOMETRICO.Estado
                            Dgv_ItemIsometrico.Columns(i).ReadOnly = False
                        Case Else
                            Dgv_ItemIsometrico.Columns(i).ReadOnly = True
                    End Select
                    Dgv_ItemIsometrico.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Next
            End If
        End If

        If Edicion = TipoEdicion.Ver Then
            Cb_Proyecto.Enabled = False
            Cb_Linea.Enabled = False
            Cb_Isometrico.Enabled = False
            Bt_AgregarItemsSpool.Enabled = False
            Cb_NroHoja.Enabled = False
            Tx_Nombre.Enabled = False
            Tx_Abreviatura.Enabled = False
            Tx_Revision.Enabled = False
            Tx_Descripcion.Enabled = False
            Tx_Ubicacion.Enabled = False
            Cb_Estado.Enabled = False
            Dgv_ItemIsometrico.ReadOnly = True
            Dgv_ItemIsometrico.AllowUserToAddRows = False
            Bt_Guardar.Enabled = False
        End If

        Comportamiento_Predeterminado()
    End Sub

    Private Sub Bt_AgregarItemsSpool_Click(sender As Object, e As EventArgs) Handles Bt_AgregarItemsSpool.Click
        Dim frItemsIsometrico As New Form
        Dim Dgv_ItemsDisponibles As New DataGridView
        Dim Flp_Botones As New FlowLayoutPanel
        Dim Bt_Aceptar As New Button
        Dim Bt_Cancelar As New Button
        With Dgv_ItemsDisponibles
            .Dock = DockStyle.Fill
        End With
        With Bt_Cancelar
            .Text = "Cancelar"
        End With
        With Bt_Aceptar
            .Text = "Aceptar"
        End With
        With Flp_Botones
            .Dock = DockStyle.Bottom
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)
        End With
        With frItemsIsometrico
            .Text = Cb_Isometrico.SelectedValue
            .Controls.Add(Dgv_ItemsDisponibles)
            .Controls.Add(Flp_Botones)
        End With
        frItemsIsometrico.ShowDialog()

    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Close()
    End Sub

    Private Sub Fr_Isometrico_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Edicion = TipoEdicion.Crear Or Edicion = TipoEdicion.Editar Then
            If MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "SALIR SIN GUARDAR CAMBIOS") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If ValidarIsometrico() Then
            dt_Items = Dgv_ItemIsometrico.DataSource
            If EsTipoSpool Then

                ' Retirar columnas

            Else ' Isométrico
                If dt_Items.Columns.Contains(MTE_ITEMISOMETRICO.Isometrico) Then
                    dt_Items.Columns.Remove(MTE_ITEMISOMETRICO.Isometrico)
                End If
                If dt_Items.Columns.Contains(MTE_ITEMISOMETRICO.Articulo) Then
                    dt_Items.Columns.Remove(MTE_ITEMISOMETRICO.Articulo)
                End If
                If dt_Items.Columns.Contains(MTE_ITEMISOMETRICO.UsuarioModifica) Then
                    dt_Items.Columns.Remove(MTE_ITEMISOMETRICO.UsuarioModifica)
                End If
            End If

            Try
                If Edicion = TipoEdicion.Crear Then
                    If EsTipoSpool Then
                        GestionarSpool(1, Dgv_ItemIsometrico.DataSource, 0, Tx_Nombre.Text, Tx_Descripcion.Text, Tx_Abreviatura.Text, Cb_Estado.SelectedValue, Tx_Ubicacion.Text, _
                                            Cb_Isometrico.SelectedValue, "")
                    Else ' Isométrico
                        GestionarIsometrico(1, Dgv_ItemIsometrico.DataSource, 0, Tx_Nombre.Text, Tx_Descripcion.Text, Tx_Abreviatura.Text, Tx_Revision.Text, Cb_NroHoja.SelectedValue, _
                                            Cb_Proyecto.SelectedValue, Cb_Linea.SelectedValue, "")
                    End If
                ElseIf Edicion = TipoEdicion.Editar Then
                    If EsTipoSpool Then
                        GestionarSpool(2, Dgv_ItemIsometrico.DataSource, Id, Tx_Nombre.Text, Tx_Descripcion.Text, Tx_Abreviatura.Text, Cb_Estado.SelectedValue, Tx_Ubicacion.Text, _
                                            Cb_Isometrico.SelectedValue, "")
                    Else ' Isométrico
                        GestionarIsometrico(2, Dgv_ItemIsometrico.DataSource, Id, Tx_Nombre.Text, Tx_Descripcion.Text, Tx_Abreviatura.Text, Tx_Revision.Text, Cb_NroHoja.SelectedValue, _
                                            Cb_Proyecto.SelectedValue, Cb_Linea.SelectedValue, "")
                    End If
                End If
                MsgBox("Se guardaron los datos exitosamente.", MsgBoxStyle.Information, "GUARDADO EXITOSO")
                Close()
            Catch
                MsgBox("No se pudo realizar el guardado de los datos.", MsgBoxStyle.Information, "ERROR GUARDADO")
            End Try
        End If
    End Sub

    Private Function ValidarIsometrico() As Boolean
        If IsNothing(Cb_Proyecto.SelectedValue) Then
            If EsTipoSpool Then
                MsgBox("Debe seleccionar el Proyecto al cual pertenece el Isométrico del Spool que está editando", MsgBoxStyle.Exclamation, "PROYECTO")
            Else ' Isométrico
                MsgBox("Debe seleccionar el Proyecto al cual pertenece el Isométrico que está editando", MsgBoxStyle.Exclamation, "PROYECTO")
            End If
            Cb_Proyecto.Focus()
            ValidarIsometrico = False
            Exit Function
        End If

        If IsNothing(Cb_Linea.SelectedValue) Then
            If EsTipoSpool Then
                MsgBox("Debe seleccionar La Línea a la cual pertenece el Isométrico del Spool que está editando", MsgBoxStyle.Exclamation, "LÍNEA")
            Else ' Isométrico
                MsgBox("Debe seleccionar La Línea a la cual pertenece el Isométrico que está editando", MsgBoxStyle.Exclamation, "LÍNEA")
            End If
            Cb_Linea.Focus()
            ValidarIsometrico = False
            Exit Function
        End If

        If Cb_Isometrico.Visible Then
            If IsNothing(Cb_Isometrico.SelectedValue) Then
                MsgBox("Debe seleccionar un Isométrico válido al cual se asociará el Spool que está editando", MsgBoxStyle.Exclamation, "ISOMÉTRICO")
                Cb_Isometrico.Focus()
                ValidarIsometrico = False
                Exit Function
            End If
        End If

        If Cb_NroHoja.Visible Then
            If IsNothing(Cb_NroHoja.SelectedValue) Then
                MsgBox("Debe seleccionar la Hoja a la cual se asociará el Isométrico que está editando", MsgBoxStyle.Exclamation, "NÚMERO DE HOJA")
                Cb_NroHoja.Focus()
                ValidarIsometrico = False
                Exit Function
            End If
        End If

        If Tx_Revision.Visible Then
            If Tx_Revision.Text.Length < 1 Then
                MsgBox("Debe indicar el número de Revisión del Isométrico que está editando", MsgBoxStyle.Exclamation, "REVISIÓN")
                Tx_Revision.Focus()
                ValidarIsometrico = False
                Exit Function
            End If
        End If

        If Tx_Nombre.Text.Length < 1 Then
            If EsTipoSpool Then
                MsgBox("Debe indicar el Nombre del Spool que está editando", MsgBoxStyle.Exclamation, "NOMBRE DEL SPOOL")
            Else ' Isométrico
                MsgBox("Debe indicar el Nombre del Isométrico que está editando", MsgBoxStyle.Exclamation, "NOMBRE DEL ISOMÉTRICO")
            End If
            Tx_Nombre.Focus()
            ValidarIsometrico = False
            Exit Function
        End If

        'If Tx_Abreviatura.Text.Length < 1 Then
        '    If EsTipoSpool Then
        '        MsgBox("Debe indicar la Abreviatura del Spool que está editando", MsgBoxStyle.Exclamation, "ABREVIATURA DEL SPOOL")
        '    Else ' Isométrico
        '        MsgBox("Debe indicar la Abreviatura del Isométrico que está editando", MsgBoxStyle.Exclamation, "ABREVIATURA DEL ISOMÉTRICO")
        '    End If
        '    Tx_Abreviatura.Focus()
        '    ValidarIsometrico = False
        '    Exit Function
        'End If

        'If Tx_Descripcion.Text.Length < 1 Then
        '    If EsTipoSpool Then
        '        MsgBox("Debe indicar la Descripción del Spool que está editando", MsgBoxStyle.Exclamation, "DESCRIPCIÓN DEL SPOOL")
        '    Else ' Isométrico
        '        MsgBox("Debe indicar la Descripción del Isométrico que está editando", MsgBoxStyle.Exclamation, "DESCRIPCIÓN DEL ISOMÉTRICO")
        '    End If
        '    Tx_Descripcion.Focus()
        '    ValidarIsometrico = False
        '    Exit Function
        'End If

        'If Tx_Ubicacion.Visible Then
        '    If Tx_Ubicacion.Text.Length < 1 Then
        '        MsgBox("Debe indicar la ubicación del Spool que está editando", MsgBoxStyle.Exclamation, "UBICACIÓN")
        '        Tx_Ubicacion.Focus()
        '        ValidarIsometrico = False
        '        Exit Function
        '    End If
        'End If

        If Cb_Estado.Visible Then
            If IsNothing(Cb_Estado.SelectedValue) Then
                MsgBox("Debe seleccionar Estado en el cual se encuentra el Spool que está editando", MsgBoxStyle.Exclamation, "ESTADO DE SPOOL")
                Cb_Estado.Focus()
                ValidarIsometrico = False
                Exit Function
            End If
        End If

        If dt_Items.Rows.Count = 0 Then 'LISTAITEMREQUISICION
            MsgBox("La requisición debe tener mínimo un item", MsgBoxStyle.Critical, "Requisición sin items")
            ValidarIsometrico = False
            Exit Function
        End If

        ' LISTADO DE ÍTEMS
        If Not ValidarItems() Then
            ValidarIsometrico = False
            Exit Function
        End If

        ValidarIsometrico = True
    End Function

    Private Function ValidarItems() As Boolean
        If Dgv_ItemIsometrico.RowCount <= 1 Then
            If EsTipoSpool Then
                MsgBox("Debe agregar los Ítems del Spool", MsgBoxStyle.Critical, "Ítems Spool")
            Else ' Isométrico
                MsgBox("Debe agregar los Ítems del Isométrico", MsgBoxStyle.Critical, "Ítems Isométrico")
            End If
            ValidarItems = False
            Exit Function
        Else
            Dim validos As Boolean = True

            For i = 0 To Dgv_ItemIsometrico.Rows.Count - 2
                Dim FilaDGVItem As DataRow
                FilaDGVItem = Dgv_ItemIsometrico.DataSource.Rows(i)
                Dgv_ItemIsometrico.Rows(i).ErrorText = ""
                Dgv_ItemIsometrico.Rows(i).DefaultCellStyle = Estilo_Celda

                If EsTipoSpool Then
                    If IsDBNull(FilaDGVItem(MTE_ITEMSPOOL.Cantidad)) Then
                        Dgv_ItemIsometrico.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                        Dgv_ItemIsometrico.Rows(i).ErrorText = "La cantidad debe ser mayor a 0"
                        validos = False
                        Dgv_ItemIsometrico.CurrentCell = Dgv_ItemIsometrico(MTE_ITEMSPOOL.Cantidad, i)
                    Else
                        If FilaDGVItem(MTE_ITEMSPOOL.Cantidad) <= 0 Then
                            Dgv_ItemIsometrico.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_ItemIsometrico.Rows(i).ErrorText = "La cantidad debe ser mayor a 0"
                            validos = False
                            Dgv_ItemIsometrico.CurrentCell = Dgv_ItemIsometrico(MTE_ITEMSPOOL.Cantidad, i)
                        End If
                    End If
                Else ' Isométrico
                    If IsDBNull(FilaDGVItem(MTE_ITEMISOMETRICO.Cantidad)) Then
                        Dgv_ItemIsometrico.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                        Dgv_ItemIsometrico.Rows(i).ErrorText = "La cantidad debe ser mayor a 0"
                        validos = False
                        Dgv_ItemIsometrico.CurrentCell = Dgv_ItemIsometrico(MTE_ITEMISOMETRICO.Cantidad, i)
                    Else
                        If FilaDGVItem(MTE_ITEMISOMETRICO.Cantidad) <= 0 Then
                            Dgv_ItemIsometrico.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_ItemIsometrico.Rows(i).ErrorText = "La cantidad debe ser mayor a 0"
                            validos = False
                            Dgv_ItemIsometrico.CurrentCell = Dgv_ItemIsometrico(MTE_ITEMISOMETRICO.Cantidad, i)
                        End If
                    End If
                End If
            Next
            If validos = False Then
                Dgv_ItemIsometrico.Focus()
                ValidarItems = False
                Exit Function
            End If
        End If

        ValidarItems = True
    End Function

    Private Function ValidarItem(ByVal IdArticulo As Integer) As Boolean
        Dim filas As DataRow()
        If EsTipoSpool Then
            filas = Dgv_ItemIsometrico.DataSource.Select("[" & MTE_ITEMSPOOL.IdArticulo & "]='" & IdArticulo.ToString & "'")
        Else
            filas = Dgv_ItemIsometrico.DataSource.Select("[" & MTE_ITEMISOMETRICO.IdArticulo & "]='" & IdArticulo.ToString & "'")
        End If
        If filas.Length > 0 Then
            ValidarItem = False
            Exit Function
        End If
        ValidarItem = True
    End Function

    Private Sub Cb_Proyecto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Proyecto.SelectedIndexChanged
        If IsNumeric(Cb_Proyecto.SelectedValue) Then
            Dim Accion As Integer = 8
            If Edicion = TipoEdicion.Crear Or Edicion = TipoEdicion.Editar Then
                Accion = 9
            Else
                Accion = 8
            End If
            Cb_Linea.DataSource = GestionarLinea(Accion, 0, "", "", "", 0, Cb_Proyecto.SelectedValue)
            Cb_Linea.ValueMember = MTE_LINEA.IdLinea
            Cb_Linea.DisplayMember = MTE_LINEA.Linea
            If IsNothing(Cb_Linea.SelectedValue) Then
                Cb_Linea.Text = ""
                If EsTipoSpool Then
                    Cb_Isometrico.DataSource = Nothing
                    Cb_Isometrico.Text = ""
                Else ' Isométrico
                    Cb_NroHoja.DataSource = Nothing
                    Cb_NroHoja.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub Cb_Linea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Linea.SelectedIndexChanged
        If IsNumeric(Cb_Linea.SelectedValue) Then
            If EsTipoSpool Then
                Cb_Isometrico.DataSource = GestionarIsometrico(8, New DataTable, 0, "", "", "", 0, 0, 0, Cb_Linea.SelectedValue, "")
                Cb_Isometrico.ValueMember = MTE_ISOMETRICO.IdIsometrico
                Cb_Isometrico.DisplayMember = MTE_ISOMETRICO.Isometrico
                If IsNothing(Cb_Isometrico.SelectedValue) Then
                    Cb_Isometrico.Text = ""
                End If
            Else ' Isométrico
                Cb_NroHoja.DataSource = GestionarIsometrico(9, New DataTable, Id, "", "", "", 0, 0, Cb_Proyecto.SelectedValue, Cb_Linea.SelectedValue, "")
                Cb_NroHoja.ValueMember = MTE_ISOMETRICO.NroHoja
                Cb_NroHoja.DisplayMember = MTE_ISOMETRICO.NroHoja
                If IsNothing(Cb_NroHoja.SelectedValue) Then
                    Cb_NroHoja.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub Dgv_ItemIsometrico_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_ItemIsometrico.CellEndEdit
        If IsDBNull(Dgv_ItemIsometrico.Item(e.ColumnIndex, e.RowIndex).Value) Then
            Dgv_ItemIsometrico.Item(e.ColumnIndex, e.RowIndex).Value = 0
        End If
        If Trim(Dgv_ItemIsometrico.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
            If e.RowIndex > 0 Then
                Dgv_ItemIsometrico.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                Dgv_ItemIsometrico.Rows(e.RowIndex).ErrorText = ""
            Else
                Try
                    Dgv_ItemIsometrico.Rows.RemoveAt(e.RowIndex)
                Catch ex As Exception

                End Try
            End If
            Exit Sub
        End If
        Dim idArtcl As Integer = -1
        Dim cant As Double = -1
        If EsTipoSpool Then
            If Not IsDBNull(Dgv_ItemIsometrico.Item(MTE_ITEMSPOOL.IdArticulo, e.RowIndex).Value) Then
                idArtcl = Dgv_ItemIsometrico.Item(MTE_ITEMSPOOL.IdArticulo, e.RowIndex).Value
            End If
            If Not IsDBNull(Dgv_ItemIsometrico.Item(MTE_ITEMSPOOL.Cantidad, e.RowIndex).Value) Then
                cant = Dgv_ItemIsometrico.Item(MTE_ITEMSPOOL.Cantidad, e.RowIndex).Value
            End If
        Else ' Isométrico
            If Not IsDBNull(Dgv_ItemIsometrico.Item(MTE_ITEMISOMETRICO.IdArticulo, e.RowIndex).Value) Then
                idArtcl = Dgv_ItemIsometrico.Item(MTE_ITEMISOMETRICO.IdArticulo, e.RowIndex).Value
            End If
            If Not IsDBNull(Dgv_ItemIsometrico.Item(MTE_ITEMISOMETRICO.Cantidad, e.RowIndex).Value) Then
                cant = Dgv_ItemIsometrico.Item(MTE_ITEMISOMETRICO.Cantidad, e.RowIndex).Value
            End If
        End If

        Dgv_ItemIsometrico.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda
        Dgv_ItemIsometrico.Rows(e.RowIndex).ErrorText = ""

        If EsTipoSpool Then
            Select Case e.ColumnIndex
                Case Dgv_ItemIsometrico.Columns(MTE_ITEMSPOOL.IdArticulo).Index
                    If idArtcl > 0 Then
                        EliminarFilaVacia()
                        AgregarItem(idArtcl)
                    End If
                Case Dgv_ItemIsometrico.Columns(MTE_ITEMSPOOL.Cantidad).Index
                    If idArtcl > 0 Then
                        If Trim(cant) = "" Then
                            Dgv_ItemIsometrico.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_ItemIsometrico.Rows(e.RowIndex).ErrorText = "El campo Cantidad no es válido"
                        Else
                            If Not IsNumeric(cant) Then
                                Dgv_ItemIsometrico.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                Dgv_ItemIsometrico.Rows(e.RowIndex).ErrorText = "El campo Cantidad no es válido"
                            Else
                                If cant <= 0 Then
                                    Dgv_ItemIsometrico.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                    Dgv_ItemIsometrico.Rows(e.RowIndex).ErrorText = "El campo Cantidad no es válido"
                                End If
                            End If
                        End If
                    Else
                        Dgv_ItemIsometrico.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                        Dgv_ItemIsometrico.Rows(e.RowIndex).ErrorText = "No se ha indicado el artículo"
                    End If
            End Select
        Else ' Isométrico
            Select Case e.ColumnIndex
                Case Dgv_ItemIsometrico.Columns(MTE_ITEMISOMETRICO.IdArticulo).Index
                    If idArtcl > 0 Then
                        EliminarFilaVacia()
                        AgregarItem(idArtcl)
                    End If
                Case Dgv_ItemIsometrico.Columns(MTE_ITEMISOMETRICO.Cantidad).Index
                    If idArtcl > 0 Then
                        If Trim(cant) = "" Then
                            Dgv_ItemIsometrico.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_ItemIsometrico.Rows(e.RowIndex).ErrorText = "El campo Cantidad no es válido"
                        Else
                            If Not IsNumeric(cant) Then
                                Dgv_ItemIsometrico.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                Dgv_ItemIsometrico.Rows(e.RowIndex).ErrorText = "El campo Cantidad no es válido"
                            Else
                                If cant <= 0 Then
                                    Dgv_ItemIsometrico.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                                    Dgv_ItemIsometrico.Rows(e.RowIndex).ErrorText = "El campo Cantidad no es válido"
                                End If
                            End If
                        End If
                    Else
                        Dgv_ItemIsometrico.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                        Dgv_ItemIsometrico.Rows(e.RowIndex).ErrorText = "No se ha indicado el artículo"
                    End If
            End Select
            Dgv_ItemIsometrico.DataSource.Rows(e.RowIndex).Item(MTE_ITEMISOMETRICO.IdUsuarioModifica) = VariablesBase.VariablesBase.IdPersona
            Dgv_ItemIsometrico.DataSource.Rows(e.RowIndex).Item(MTE_ITEMISOMETRICO.FechaModificacion) = DateTime.Now
        End If
    End Sub

    Private Sub Dgv_ItemIsometrico_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Dgv_ItemIsometrico.KeyDown
        If Edicion <> TipoEdicion.Ver Then
            Select Case e.KeyCode
                Case Keys.F3
                    Dim FrBuscarArtículo As New Fr_BuscarArtículo
                    FrBuscarArtículo.Familia = -1
                    FrBuscarArtículo._Tipo = "T"
                    FrBuscarArtículo.Cargar_Tabla("T")
                    FrBuscarArtículo.ShowDialog()
                    If Trim(FrBuscarArtículo.IdArtículo) = 0 Then
                        Exit Sub
                    End If
                    AgregarItem(FrBuscarArtículo.IdArtículo)
            End Select
        End If
    End Sub

    Private Sub AgregarItem(ByVal IdArtcl As Integer)
        If ValidarItem(IdArtcl) Then
            Dim articulos As New DataTable
            Dim Conexión As New SqlConnection(My.Settings.CadenaConexión)
            Dim Consulta As New SqlCommand("SELECT * FROM dbo.DatosArticuloxBodega(" & IdArtcl.ToString & "," & VariablesBase.VariablesBase.IdBodegaActual & ")")
            Consulta.Connection = Conexión
            Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
            Try
                Consulta.Connection.Open()
                Adaptador.Fill(articulos)
                Consulta.Connection.Close()
                If articulos.Rows.Count > 0 Then
                    Dim FilaArticulo As DataRow
                    FilaArticulo = articulos(0)
                    Dim NuevaFilaItem As DataRow = Dgv_ItemIsometrico.DataSource.NewRow
                    If EsTipoSpool Then
                        NuevaFilaItem(MTE_ITEMSPOOL.IdItemSpool) = Dgv_ItemIsometrico.Rows.Count - 1
                        NuevaFilaItem(MTE_ITEMSPOOL.IdArticulo) = FilaArticulo("ID")
                        NuevaFilaItem(MTE_ITEMSPOOL.Articulo) = FilaArticulo("NOMBRE")
                        'NuevaFilaItem("Und") = FilaArticulo("UND")
                        NuevaFilaItem(MTE_ITEMSPOOL.IdSpool) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMSPOOL.Spool) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMSPOOL.Cantidad) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMSPOOL.CodigoIngenieria) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMSPOOL.Colada) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMSPOOL.Estado) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMSPOOL.Ubicacion) = DBNull.Value
                        'NuevaFilaItem(MTE_ITEMSPOOL.IdUsuarioModifica) = DBNull.Value
                        'NuevaFilaItem(MTE_ITEMSPOOL.UsuarioModifica) = DBNull.Value
                        'NuevaFilaItem(MTE_ITEMSPOOL.FechaModificacion) = DBNull.Value
                    Else ' Isométrico
                        NuevaFilaItem(MTE_ITEMISOMETRICO.IdItemIsometrico) = Dgv_ItemIsometrico.DataSource.Rows.Count + 1
                        NuevaFilaItem(MTE_ITEMISOMETRICO.IdArticulo) = FilaArticulo("ID")
                        NuevaFilaItem(MTE_ITEMISOMETRICO.Articulo) = FilaArticulo("NOMBRE")
                        'NuevaFilaItem("Und") = FilaArticulo("UND")
                        NuevaFilaItem(MTE_ITEMISOMETRICO.IdIsometrico) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMISOMETRICO.Isometrico) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMISOMETRICO.Cantidad) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMISOMETRICO.CodigoIngenieria) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMISOMETRICO.Colada) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMISOMETRICO.Estado) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMISOMETRICO.Ubicacion) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMISOMETRICO.IdUsuarioModifica) = VariablesBase.VariablesBase.IdPersona
                        'NuevaFilaItem(MTE_ITEMISOMETRICO.UsuarioModifica) = DBNull.Value
                        NuevaFilaItem(MTE_ITEMISOMETRICO.FechaModificacion) = DateTime.Now
                    End If
                    Dgv_ItemIsometrico.DataSource.Rows.Add(NuevaFilaItem)
                    EliminarFilaVacia()
                Else
                    MsgBox("No se encontró un artículo con ese código", MsgBoxStyle.Exclamation, "Artículo no Encontrado")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Consulta.Connection.Close()
            End Try
        Else
            MsgBox("El ítem que desea ingresar ya se encuentra incluido", MsgBoxStyle.Critical, "Ítem Repetido")
        End If
    End Sub

    Private Sub EliminarFilaVacia()
        Try
            For i = Dgv_ItemIsometrico.Rows.Count - 2 To 0 Step -1
                If EsTipoSpool Then
                    If IsDBNull(Dgv_ItemIsometrico.Rows(i).Cells(MTE_ITEMSPOOL.Articulo).Value) Or _
                    IsNothing(Dgv_ItemIsometrico.Rows(i).Cells(MTE_ITEMSPOOL.Articulo).Value) Then
                        Dgv_ItemIsometrico.Rows.RemoveAt(i)
                    End If
                Else ' Isométrico
                    If IsDBNull(Dgv_ItemIsometrico.Rows(i).Cells(MTE_ITEMISOMETRICO.Articulo).Value) Or _
                    IsNothing(Dgv_ItemIsometrico.Rows(i).Cells(MTE_ITEMISOMETRICO.Articulo).Value) Then
                        Dgv_ItemIsometrico.Rows.RemoveAt(i)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgv_ItemIsometrico_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles Dgv_ItemIsometrico.RowsRemoved
        If Dgv_ItemIsometrico.Rows.Count > 0 Then
            Dim ix As Integer = 0
            For ix = e.RowIndex To Dgv_ItemIsometrico.Rows.Count - 2
                If EsTipoSpool Then
                    Dgv_ItemIsometrico.Rows(ix).Cells(MTE_ITEMSPOOL.IdItemSpool).Value = ix + 1
                Else ' Isométrico
                    Dgv_ItemIsometrico.Rows(ix).Cells(MTE_ITEMISOMETRICO.IdItemIsometrico).Value = ix + 1
                End If
            Next
        End If
    End Sub

End Class