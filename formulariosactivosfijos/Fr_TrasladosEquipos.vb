Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.ComponentModel
Imports System

Public Class Fr_TrasladosEquipos
    Public tablaarticulos As New DataTable
    Public tablaequipos As New DataTable
    Public tablaequiposfin As New DataTable
    Public tablacomponentes As New DataTable
    Public tablacomponentesfin As New DataTable
    Public EdicionEquipos As Boolean = False
    Public guardar As Boolean
    Public bodegadestino As Integer = 0
    Public AccionEquipos As String = "NUEVO"
    Public IDSALIDAALMACENMODIFICANDO As Integer 'para edición de salidas
    Public IDENTRADAALMACENMODIFICANDO As Integer 'para edición de entradas 

    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()
    Public tablaequiposfinInicial As DataTable = tablaequiposfin
    Public tablacomponentesfinInicial As DataTable = tablacomponentesfin

    Public tipoEntradaSalida As String = "SALIDA" 'SALIDA O ENTRADA, SALIDA POR DEFECTO

    Public tipoentrada As String = "T" 'por defecto traslado, las entradas por Devolución manejan una búsqueda de elementos disponibles distinta

    Private Sub Bt_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Cancelar.Click
        guardar = False
        Me.Close()
    End Sub

    Private Sub Fr_TrasladosEquipos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        guardar = False ' variable para verificar si guardo el formulario o solo lo cierro

        CargarArticulos()
        CargarBodegas()
        If AccionEquipos = "VER" Then
            Bt_Aceptar.Enabled = False
            Bt_Cancelar.Enabled = False
            Bt_Agregar.Enabled = False
            Cb_Equipos.Enabled = False
        End If
    End Sub

    Public Sub CargarArticulos()
        'limpiar grilla
        Dgv_Articulos.DataSource = Nothing
        'agregar las filas de la grilla
        Dgv_Articulos.DataSource = tablaarticulos.DefaultView

        If tablaequiposfin.Rows.Count > 0 Then ' si existen filas en la tabla de equipos cargarlos y descontar
            AgregarEquipoTabla()
        End If
    End Sub

    Public Sub CargarBodegas()
        'llenar las listas de bodegas
        Try
            Dim ds As New DataSet
            ds = bddatos.ModificarEquipos(11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", False, Date.Now)
            Cb_BodegaDestino.DataSource = ds.Tables(0).DefaultView
            Cb_BodegaDestino.ValueMember = "ID"
            Cb_BodegaDestino.DisplayMember = "NOMBRE"

            If bodegadestino > 0 Then
                Cb_BodegaDestino.SelectedValue = bodegadestino
                Cb_BodegaDestino.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub Dgv_Articulos_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Articulos.CellEnter
        If AccionEquipos = "VER" Then
            Exit Sub
        End If

        'MOSTRAR LA INFORMACION DEL ARTICULO
        Lb_Articulo.Text = Dgv_Articulos.CurrentRow.Cells("DESCRIPCION").Value
        Lb_Cantidad.Text = Dgv_Articulos.CurrentRow.Cells("CANTIDAD").Value

        'llenar el ComboBox con los equipos asociados a este articulo almacenados en la bodega
        LlenarLista(Dgv_Articulos.CurrentRow.Cells("IDARTICULO").Value)
    End Sub

    Public Sub LlenarLista(ByVal idarticulo As Integer)
        'limpiar ComboBox
        Cb_Equipos.DataSource = Nothing
        'TRAER EQUIPOS ESTADO EN BODEGA QUE PERTENECEN AL CODIGO DE ARTICULO SELECCIONADO DE LA BODEGA ACTUAL
        Dim ds As New DataSet
        If AccionEquipos = "EDITAR" Then
            If tipoEntradaSalida = "ENTRADA" Then
                'SI ES UNA ENTRADA A ALMACEN
                'mostrar equipos disponibles y pendientes-relacionados a una orden de entrada en la bodega en caso de edición
                ds = bddatos.ModificarEquipos(24, 0, idarticulo, 0, 0, 0, 0, 0, IDSALIDAALMACENMODIFICANDO, 0, 0, 0, IDENTRADAALMACENMODIFICANDO, 0, 0, "", "", "", "", False, Date.Now)
            Else
                'SI ES SALIDA DE ALMACEN
                'mostrar equipos disponibles y pendientes-relacionados a una orden de salida en la bodega en caso de edición
                ds = bddatos.ModificarEquipos(22, 0, idarticulo, 0, 0, 0, 0, 0, IDSALIDAALMACENMODIFICANDO, 0, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, 0, 0, "", "", "", "", False, Date.Now)
            End If
        ElseIf AccionEquipos = "VER" Then
            If tipoEntradaSalida = "ENTRADA" Then
                'SI ES UNA ENTRADA A ALMACEN
                'mostrar equipos en bodega relacionados a una orden de entrada en caso de VER
                ds = bddatos.ModificarEquipos(26, 0, idarticulo, 0, 0, 0, 0, 0, IDSALIDAALMACENMODIFICANDO, 0, 0, 0, IDENTRADAALMACENMODIFICANDO, 0, 0, "", "", "", "", False, Date.Now)
            Else
                'SI ES SALIDA DE ALMACEN
                'mostrar equipos pendientes-relacionados a una orden de salida en la bodega en caso de VER
                ds = bddatos.ModificarEquipos(22, 0, idarticulo, 0, 0, 0, 0, 0, IDSALIDAALMACENMODIFICANDO, 0, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, 0, 0, "", "", "", "", False, Date.Now)
            End If
        Else 'NUEVO
            If tipoEntradaSalida = "ENTRADA" Then
                'SI ES ENTRADA DE ALMACEN
                'mostrar solo los equipos en estado PENDIENTE para nuevo registro
                Select Case tipoentrada
                    Case "T" ' equipos que pertenecen a una orden de salida
                        ds = bddatos.ModificarEquipos(23, 0, idarticulo, 0, 0, 0, 0, 0, IDSALIDAALMACENMODIFICANDO, 0, 0, 0, 0, 0, 0, "", "", "", "", False, Date.Now)
                    Case "S" ' equipos que pertenecen a la bodega y están bajo custodia
                        ds = bddatos.ModificarEquipos(31, 0, idarticulo, 0, 0, 0, 0, 0, 0, 0, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, 0, 0, "", "", "", "", False, Date.Now)
                End Select
            Else
                'SI ES SALIDA DE ALMACEN
                'mostrar solo los equipos disponibles para nuevo registro
                ds = bddatos.ModificarEquipos(18, 0, idarticulo, 0, 0, 0, 0, 0, 0, 0, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, 0, 0, "", "", "", "", False, Date.Now)
            End If
            
        End If

        'REVISAR EL DATASET Y BORRAR LAS FILAS QUE ESTAN EN LA TABLA DE EQUIPOS
        Dim tablacombo As New DataTable
        tablacombo.Clear()
        tablacombo.Columns.Add("IDEQUIPO")
        tablacombo.Columns.Add("CODIGO")
        tablacombo.Columns.Add("NOMBREEQUIPO")

        If ds.Tables(0).Rows.Count = 0 Then
            If AccionEquipos <> "VER" Then
                'no hay elementos para llenar
                MsgBox("No hay equipos libres asociados a este articulo. Verificar disponibilidad y estado de uso de los equipos a asociar.")
                Exit Sub
            End If
        ElseIf Dgv_Equipos.Rows.Count > 0 Then
            Dim i, j, contador As Integer
            For i = 0 To (ds.Tables(0).Rows.Count - 1)
                contador = 0
                For j = 0 To (Dgv_Equipos.Rows.Count - 1)
                    'revisar si el id del equipo es el mismo que en  y del articulo coinciden
                    If Dgv_Articulos.CurrentRow.Cells("IDARTICULO").Value = Dgv_Equipos.Rows(j).Cells("IDARTICULOEQUIPO").Value And Dgv_Equipos.Rows(j).Cells("IDEQUIPO").Value = ds.Tables(0).Rows(i)("IDEQUIPO") Then
                        contador = 1
                    End If
                Next
                If contador = 0 Then
                    'agregar la fila al ComboBox
                    tablacombo.Rows.Add(ds.Tables(0).Rows(i)(0), ds.Tables(0).Rows(i)(1), ds.Tables(0).Rows(i)(2))
                End If
            Next
        Else
            tablacombo = ds.Tables(0)
            'agregar todas normal porque la tabla de equipos esta vacía
        End If
        'ds.Tables(0).Rows(0).Delete()
        Cb_Equipos.DataSource = tablacombo.DefaultView
        Cb_Equipos.ValueMember = "IDEQUIPO"
        Cb_Equipos.DisplayMember = "CODIGO"


        'quitar los elementos que ya están agregados en la tabla de equipos
    End Sub

    Private Sub Bt_Agregar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Agregar.Click
        AgregarEquipo()
    End Sub

    Public Sub AgregarEquipo()
        'revisar si es nulo
        If Cb_Equipos.SelectedItem Is Nothing Then
            MsgBox("El equipo que esta intentando ingresar no es valido.")
            Exit Sub
        End If

        'revisar que si hay elementos por agregar
        If Cb_Equipos.Items.Count = 0 Then
            MsgBox("no hay mas equipos disponibles para agregar.")
            Exit Sub
        End If

        'revisar si se pueden agregar mas unidades
        If Dgv_Articulos.CurrentRow.Cells("CANTIDAD").Value > 0 Then
            'agrego el elemento
            Dgv_Equipos.Rows.Add(Cb_Equipos.SelectedValue, Dgv_Articulos.CurrentRow.Cells("IDARTICULO").Value, Cb_Equipos.Text, Dgv_Articulos.CurrentRow.Cells("DESCRIPCION").Value.ToString.Trim)

            'agrego los componentes del equipo que acabo de seleccionar si tiene componentes
            Dim dscomponentes As New DataSet
            dscomponentes.Clear()
            If tipoEntradaSalida = "ENTRADA" Then
                dscomponentes = bddatos.ModificarEquipos(25, 0, 0, Cb_Equipos.SelectedValue, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", False, Date.Now)
            Else
                dscomponentes = bddatos.ModificarEquipos(19, 0, 0, Cb_Equipos.SelectedValue, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", False, Date.Now)
            End If

            Dim i, j, val As Integer
            If dscomponentes.Tables(0).Rows.Count > 0 Then
                'si tiene componentes
                For i = 0 To (dscomponentes.Tables(0).Rows.Count - 1)
                    Dgv_Componentes.Rows.Add(dscomponentes.Tables(0).Rows(i).ItemArray)
                    'cuando agrego un componente agrego el ítem al articulo adicional
                    val = 0
                    For j = 0 To Dgv_ArticulosAdicionales.RowCount - 1
                        If Dgv_ArticulosAdicionales.Rows(j).Cells("IDARTICULOADICIONAL").Value = dscomponentes.Tables(0).Rows(i)("IDARTICULO") Then
                            val = 1
                            'sumar una cantidad a la fila actual con el id de articulo del componente agregado
                            Dgv_ArticulosAdicionales.Rows(j).Cells("CANTIDADADICIONAL").Value = Dgv_ArticulosAdicionales.Rows(j).Cells("CANTIDADADICIONAL").Value + 1
                            Exit For
                        End If
                    Next
                    If val = 0 Then
                        Dgv_ArticulosAdicionales.Rows.Add(dscomponentes.Tables(0).Rows(i)("IDARTICULO"), 1, dscomponentes.Tables(0).Rows(i)("NOMBREEQUIPO"))
                    End If
                Next
            End If

            'recargo el ComboBox 
            LlenarLista(Dgv_Articulos.CurrentRow.Cells("IDARTICULO").Value)

            'restar unidades a unidades restantes
            Dgv_Articulos.CurrentRow.Cells("CANTIDAD").Value = Dgv_Articulos.CurrentRow.Cells("CANTIDAD").Value - 1
            Lb_Cantidad.Text = Dgv_Articulos.CurrentRow.Cells("CANTIDAD").Value
        Else
            MsgBox("No puede agregar mas Equipos de este tipo")
            Exit Sub
        End If
    End Sub

    Public Sub AgregarEquipoTabla()
        'limpiar tabla de equipo y de componentes
        tablaequipos.Clear()
        tablacomponentes.Clear()
        Dim i, j As Integer

        'primero descontar los artículos de los componentes ya que la tabla de artículos viene cargada en el formulario
        For i = 0 To (tablacomponentesfin.Rows.Count - 1)
            For j = 0 To (Dgv_Articulos.RowCount - 1)
                If Dgv_Articulos.Rows(j).Cells("IDARTICULO").Value = tablacomponentesfin.Rows(i)("IDARTICULO") Then
                    Dgv_Articulos.Rows(j).Cells("CANTIDAD").Value = Dgv_Articulos.Rows(j).Cells("CANTIDAD").Value - 1
                    If Dgv_Articulos.Rows(j).Cells("CANTIDAD").Value = 0 Then
                        Dgv_Articulos.Rows.Remove(Dgv_Articulos.Rows(j))
                    End If
                    Exit For
                End If
            Next
        Next

        'agregar equipo
        Dim ds As New DataSet

        Try
            For i = 0 To (tablaequiposfin.Rows.Count - 1)
                ds = bddatos.ModificarEquipos(20, 0, 0, tablaequiposfin.Rows(i)("IDEQUIPO"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", False, Date.Now)
                Dgv_Equipos.Rows.Add(ds.Tables(0).Rows(0)("IDEQUIPO"), ds.Tables(0).Rows(0)("IDARTICULO"), ds.Tables(0).Rows(0)("CODIGO"), ds.Tables(0).Rows(0)("NOMBREEQUIPO"))

                'descontar en artículos
                For j = 0 To (Dgv_Articulos.Rows.Count - 1)
                    If Dgv_Articulos.Rows(j).Cells("IDARTICULO").Value = ds.Tables(0).Rows(0)("IDARTICULO") Then
                        Dgv_Articulos.Rows(j).Cells("CANTIDAD").Value = Dgv_Articulos.Rows(j).Cells("CANTIDAD").Value - 1
                        Exit For
                    End If
                Next
            Next

            'agregar componentes
            For i = 0 To (tablacomponentesfin.Rows.Count - 1)
                ds = bddatos.ModificarEquipos(21, 0, 0, tablacomponentesfin.Rows(i)("IDEQUIPO"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", False, Date.Now)
                Dgv_Componentes.Rows.Add(ds.Tables(0).Rows(0).ItemArray)

                'cuando agrego un componente agrego el ítem al articulo adicional y le resto al de articulo normal que acabo de traer del formulario de traslado
                Dim Val As Integer = 0
                For j = 0 To Dgv_ArticulosAdicionales.RowCount - 1
                    If Dgv_ArticulosAdicionales.Rows(j).Cells("IDARTICULOADICIONAL").Value = ds.Tables(0).Rows(0)("IDARTICULO") Then
                        Val = 1
                        'sumar una cantidad a la fila actual con el id de articulo del componente agregado
                        Dgv_ArticulosAdicionales.Rows(j).Cells("CANTIDADADICIONAL").Value = Dgv_ArticulosAdicionales.Rows(j).Cells("CANTIDADADICIONAL").Value + 1
                        Exit For
                    End If
                Next
                If Val = 0 Then
                    Dgv_ArticulosAdicionales.Rows.Add(ds.Tables(0).Rows(0)("IDARTICULO"), 1, ds.Tables(0).Rows(0)("NOMBREEQUIPO"))
                End If
            Next
            Lb_Cantidad.Text = "0"
            'recargo el ComboBox 
            LlenarLista(Dgv_Articulos.CurrentRow.Cells("IDARTICULO").Value)
        Catch ex As Exception
            MsgBox("Error al cargar Artículos. Si esta haciendo una entrada a almacén probablemente este intentando agregar solo Componentes de Equipos y estos no pueden entrar a bodega sin sus respectivos equipos")
        End Try

    End Sub

    Private Sub Bt_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Aceptar.Click
        'revisar si no faltan equipos 
        Dim total As Integer = 0
        Dim i As Integer
        For i = 0 To (Dgv_Articulos.Rows.Count - 1)
            total += Dgv_Articulos.Rows(i).Cells("CANTIDAD").Value
        Next
        If total <> 0 Then
            MsgBox("Faltan o Sobran Equipos por Seleccionar")
            Exit Sub
        End If

        'preguntar al usuario si desea agregar los componentes asociados a los equipos seleccionados lo cual modificara la orden inicial
        If Dgv_Componentes.Rows.Count > 0 Then
            If tipoEntradaSalida = "SALIDA" Then
                Dim respuesta As MsgBoxResult = MsgBox("Existen equipos con componentes, estos artículos se agregarán a la orden de salida, desea continuar?", vbYesNo, "ADICIONAR COMPONENTES")
                If respuesta = vbNo Then
                    Exit Sub
                End If
            Else
                Dim respuesta As MsgBoxResult = MsgBox("Existen equipos con componentes, estos artículos se agregarán a la orden de entrada, desea continuar?", vbYesNo, "ADICIONAR COMPONENTES")
                If respuesta = vbNo Then
                    Exit Sub
                End If
            End If
        End If

        'extraer tabla con todos los id de los equipos registrados con sus id de articulo correspondientes
        tablaequiposfin.Clear()
        tablacomponentesfin.Clear()
        tablacomponentesfin.Columns.Clear()
        tablaequiposfin.Columns.Clear()
        tablaequiposfin.Columns.Add("IDEQUIPO")
        tablaequiposfin.Columns.Add("IDARTICULO")
        tablacomponentesfin.Columns.Add("IDEQUIPO")
        tablacomponentesfin.Columns.Add("IDARTICULO")

        'lleno con la tabla de equipos
        For i = 0 To (Dgv_Equipos.Rows.Count - 1)
            tablaequiposfin.Rows.Add(Dgv_Equipos.Rows(i).Cells("IDEQUIPO").Value, Dgv_Equipos.Rows(i).Cells("IDARTICULOEQUIPO").Value)
        Next

        If Dgv_Componentes.Rows.Count > 0 Then
            'lleno con la tabla de componentes si existe alguno
            For i = 0 To (Dgv_Componentes.Rows.Count - 1)
                tablacomponentesfin.Rows.Add(Dgv_Componentes.Rows(i).Cells("IDEQUIPOCOMP").Value, Dgv_Componentes.Rows(i).Cells("IDARTICULOCOMP").Value)
            Next
        End If

        'decir que la variable EdicionEquipos es verdadera para que no se pierdan los equipos actuales en caso de que se vaya a editar
        EdicionEquipos = True
        guardar = True
        Me.Close()
    End Sub

  
    Private Sub Cb_Equipos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Cb_Equipos.KeyDown
        If e.KeyCode = Keys.Enter Then
            AgregarEquipo()
        End If
    End Sub

    Private Sub Dgv_Equipos_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Equipos.CellContentClick
        If AccionEquipos = "VER" Then
            Exit Sub
        End If
        If Dgv_Equipos.Columns(e.ColumnIndex).Name = "ACCION" Then
            'obtener el id del articulo
            Dim IdArtEqu As Integer = Dgv_Equipos.CurrentRow.Cells("IDARTICULOEQUIPO").Value
            Dim IdEqu As Integer = Dgv_Equipos.CurrentRow.Cells("IDEQUIPO").Value

            'borrar fila
            Dgv_Equipos.Rows.Remove(Dgv_Equipos.CurrentRow)

            'quitar los componentes del equipo
            Dim i, j, k As Integer
            j = Dgv_Componentes.Rows.Count - 1
            If Dgv_Componentes.Rows.Count > 0 Then
                'si la tabla de componentes tiene filas buscar y eliminar los componentes que tienen el padre a borrar
                For i = 0 To j Step 0
                    If Dgv_Componentes.Rows(i).Cells("IDEQUIPOPADRE").Value = IdEqu Then
                        'restar uno al artículo del componente
                        For k = 0 To Dgv_ArticulosAdicionales.RowCount - 1
                            If Dgv_ArticulosAdicionales.Rows(k).Cells("IDARTICULOADICIONAL").Value = Dgv_Componentes.Rows(i).Cells("IDARTICULOCOMP").Value Then
                                Dgv_ArticulosAdicionales.Rows(k).Cells("CANTIDADADICIONAL").Value = Dgv_ArticulosAdicionales.Rows(k).Cells("CANTIDADADICIONAL").Value - 1
                                If Dgv_ArticulosAdicionales.Rows(k).Cells("CANTIDADADICIONAL").Value = 0 Then
                                    'si la cantidad llega a 0 quito el articulo adicional
                                    Dgv_ArticulosAdicionales.Rows.Remove(Dgv_ArticulosAdicionales.Rows(k))
                                End If
                                Exit For
                            End If
                        Next
                        'borrar el componente
                        Dgv_Componentes.Rows.Remove(Dgv_Componentes.Rows(i))
                        j = j - 1
                    Else
                        i = i + 1
                    End If
                    If j < i Then
                        Exit For
                    End If
                Next
            End If

            'cargar tabla
            LlenarLista(Dgv_Articulos.CurrentRow.Cells("IDARTICULO").Value)

            'sumar 1 al valor de cantidad de artículos
            For i = 0 To (Dgv_Articulos.Rows.Count - 1)
                If Dgv_Articulos.Rows(i).Cells("IDARTICULO").Value = IdArtEqu Then
                    Dgv_Articulos.Rows(i).Cells("CANTIDAD").Value = Dgv_Articulos.Rows(i).Cells("CANTIDAD").Value + 1
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub Fr_TrasladosEquipos_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If AccionEquipos <> "VER" Then
            If guardar = False Then
                If MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "SALIR SIN GUARDAR") = MsgBoxResult.No Then
                    e.Cancel = True
                Else
                    'se cierra, se revierten los cambios
                    tablaequiposfin = tablaequiposfinInicial
                    tablacomponentesfin = tablacomponentesfinInicial
                End If
            End If
        End If
    End Sub
End Class