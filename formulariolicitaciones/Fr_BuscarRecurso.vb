Imports FormularioLicitaciones.FormulariosLicitaciones
Imports System.Data.SqlClient
Imports System.Text

''' <summary>
''' Formulario de búsqueda de recursos de licitaciones.
''' Permite asociar recursos en las rejillas de Ítems A.P.U. y recursos agrupadores como Maquinaria y Equipo.
''' </summary>
Public Class Fr_BuscarRecurso
    ''' <summary>
    ''' Indica el tipo de recurso que se busca para cargar el listado correspondiente.
    ''' </summary>
    ''' <value>Tipo de recurso que se busca</value>
    ''' <returns>Tipo de recurso que se busca</returns>
    Property Recurso As TipoRecurso

    ''' <summary>
    ''' 
    ''' </summary>
    Private _idrecurso As Integer = -1

    ''' <summary>
    ''' Identificador del recurso que se inserta en el formulario padre.
    ''' </summary>
    ''' <value>Identificador del recurso.</value>
    ''' <returns>Identificador del recurso.</returns>
    ReadOnly Property IdRecurso As Integer
        Get
            Return _idRecurso
        End Get
    End Property

    ''' <summary>
    ''' Formulario que llama al formulario de búsqueda. Los recursos se agregan a las rejillas de este formulario.
    ''' </summary>
    ''' <value>Padre del formulario de búsqueda</value>
    ''' <returns>Padre del formulario de búsqueda</returns>
    Property FrPadre As Object

    ''' <summary>
    ''' Listado de recursos sobre el cual se aplica el criterio de búsqueda.
    ''' </summary>
    Private dtRecurso As DataTable

    ''' <summary>
    ''' Listado de criterios que se pueden aplicar en la búsqueda, Se asigna a la lista desplegable de criterios.
    ''' </summary>
    Private dtFiltro As DataTable

    ''' <summary>
    ''' Lleva el control del tiempo desde que se tecleó por última vez en la caja de texto de búsqueda para ejecutar el procedimiento de filtrado solo hasta que el usuario termine de digitar.
    ''' </summary>
    Private WithEvents temporizador As Timer


    'Carga del listado de recursos.
    Private Sub Fr_BuscarRecurso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtRecurso = New DataTable
        dtFiltro = New DataTable
        temporizador = New Timer
        Comportamiento_Predeterminado()
        dtFiltro.Clear()
        dtFiltro.Columns.Add("Filtro")
        dtFiltro.Columns.Add("Columna")
        dtFiltro.Rows.Add("Descripción", "DESCRIPCION")
        dtFiltro.Rows.Add("Código Recurso (Id)", "ID")
        Cb_Filtrar.DataSource = dtFiltro
        Cb_Filtrar.ValueMember = "Columna"
        Cb_Filtrar.DisplayMember = "Filtro"
        Select Case Recurso
            Case TipoRecurso.Licitacion
                CargarLicitaciones()
            Case TipoRecurso.Material
                CargarMateriales()
            Case TipoRecurso.MaquinariaEquipo
                CargarMaquinariaYEquipo()
            Case TipoRecurso.ManoDeObra
                CargarManoDeObra()
        End Select
        If Recurso = TipoRecurso.Licitacion Then
            Bt_AgregarRecurso.Visible = False
        End If
        Tx_Descripcion.Select()
    End Sub


    'Reinicia el contador de la ejecución de la búsqueda al modificar el contenido de la caja de texto.
    Private Sub Tx_Descripcion_TextChanged(sender As Object, e As EventArgs) Handles Tx_Descripcion.TextChanged
        temporizador.Stop()
        temporizador.Interval = VariablesBase.VariablesBase.TiempoRespuestaBuscador * 2
        temporizador.Start()
    End Sub


    'Procedimiento en el que se aplica el criterio de búsqueda. Se desencadena por el temporizador de tecleo.
    Private Sub temporizador_Tick(sender As Object, e As EventArgs) Handles temporizador.Tick
        temporizador.Stop()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor

        If Ck_Filtrar.Checked = True Then
            Dim vista As New DataView(dtRecurso)
            Dgv_Buscar.SuspendLayout()
            Dgv_Buscar.DataSource = vista
            Dgv_Buscar.ResumeLayout()
            Dim Texto As String = Tx_Descripcion.Text
            Dim pabla() As String
            pabla = Split(Trim(Texto), "  ")
            While pabla.Count > 1
                Texto = Replace(Trim(Texto), "  ", " ")
                pabla = Split(Trim(Texto), "  ")
            End While
            pabla = Split(Trim(Texto), " ")
            Select Case Cb_Filtrar.SelectedIndex
                Case 0 'Descripción
                    Dim filtroFilas As New StringBuilder
                    For i As Integer = 0 To pabla.Count - 1
                        filtroFilas.Append(Cb_Filtrar.SelectedValue & " like '%" & pabla(i) & "%' ")
                        If i < pabla.Count - 1 Then
                            filtroFilas.Append("AND ")
                        End If
                    Next
                    vista.RowFilter = filtroFilas.ToString
                Case 1 'Código Recurso (Id)
                    If IsNumeric(Trim(Tx_Descripcion.Text)) Then
                        Dim nombreColumna As String = ""
                        Select Case Recurso
                            Case TipoRecurso.Licitacion
                                nombreColumna = "IDLICITACION"
                            Case TipoRecurso.MaquinariaEquipo
                                nombreColumna = "IDMAQUINARIAYEQUIPO"
                            Case TipoRecurso.Material
                                nombreColumna = "IDMATERIAL"
                            Case TipoRecurso.ManoDeObra
                                nombreColumna = "IDMANODEOBRA"
                        End Select
                        vista.RowFilter = nombreColumna & " = " & Trim(Tx_Descripcion.Text)
                    End If
            End Select
        End If
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub


    ''' <summary>
    ''' Carga del listado de licitaciones para búsqueda.
    ''' Se cargan las licitaciones que estén activas y para las cuales el usuario tiene permiso de lectura y/o escritura.
    ''' </summary>
    Private Sub CargarLicitaciones()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaLicitaciones(@TIPO, @IDUSUARIO)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 3) 'Licitaciones activas de las cuales se tiene permiso de lectura/escritura.
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        dtRecurso.Clear()
        Try
            conexion.Open()
            adaptador.FillSchema(dtRecurso, SchemaType.Source)
            adaptador.Fill(dtRecurso)
            conexion.Close()
            Dgv_Buscar.DataSource = dtRecurso
            For j As Integer = 0 To Dgv_Buscar.ColumnCount - 1
                Select Case Dgv_Buscar.Columns(j).Name
                    Case "HORASDIARIAS"
                        Dgv_Buscar.Columns(j).FillWeight = 50
                        Dgv_Buscar.Columns(j).HeaderText = "Horas diarias"
                    Case "PORCENTAJEADMINISTRACION"
                        Dgv_Buscar.Columns(j).FillWeight = 50

                        Dgv_Buscar.Columns(j).HeaderText = "Administración"
                    Case "PORCENTAJEIMPREVISTOS"
                        Dgv_Buscar.Columns(j).FillWeight = 50
                        Dgv_Buscar.Columns(j).HeaderText = "Imprevistos"
                    Case "PORCENTAJEUTILIDAD"
                        Dgv_Buscar.Columns(j).FillWeight = 50
                        Dgv_Buscar.Columns(j).HeaderText = "Utilidad"
                    Case "NROLICITACION"
                        Dgv_Buscar.Columns(j).FillWeight = 100
                        Dgv_Buscar.Columns(j).HeaderText = "Nro. Licitación"
                    Case "PROYECTO"
                        Dgv_Buscar.Columns(j).FillWeight = 200
                        Dgv_Buscar.Columns(j).HeaderText = "Proyecto"
                    Case "CLIENTE"
                        Dgv_Buscar.Columns(j).FillWeight = 200
                        Dgv_Buscar.Columns(j).HeaderText = "Cliente"
                    Case Else
                        'IDLICITACION, FECHAREGISTRO, IDUSUARIOREGISTRO, FECHAMODIFICACION, IDUSUARIOMODIFICA, TIPOPERMISO, ACTIVO, TIPOGERENCIA
                        Dgv_Buscar.Columns(j).Visible = False
                End Select
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga del listado de Materiales para la búsqueda.
    ''' Se cargan los materiales en estado activo.
    ''' </summary>
    Private Sub CargarMateriales()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaMaterial(@TIPO, @IDUSUARIO)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 1) 'Listado de Materiales Activos.
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        dtRecurso.Clear()
        Try
            conexion.Open()
            adaptador.FillSchema(dtRecurso, SchemaType.Source)
            adaptador.Fill(dtRecurso)
            conexion.Close()
            Dgv_Buscar.DataSource = dtRecurso
            For i As Integer = 0 To Dgv_Buscar.ColumnCount - 1
                Select Case Dgv_Buscar.Columns(i).Name
                    Case "ABREVIATURA"
                        Dgv_Buscar.Columns(i).FillWeight = 50
                        Dgv_Buscar.Columns(i).HeaderText = "Unidad"
                    Case "CANTIDAD"
                        Dgv_Buscar.Columns(i).FillWeight = 50
                        Dgv_Buscar.Columns(i).HeaderText = "Cantidad"
                    Case "ESISMOCOL"
                        Dgv_Buscar.Columns(i).FillWeight = 50
                        Dgv_Buscar.Columns(i).HeaderText = "Es Ismocol"
                    Case "VALORISMOCOL"
                        Dgv_Buscar.Columns(i).FillWeight = 100
                        Dgv_Buscar.Columns(i).HeaderText = "Valor Ismocol"
                    Case "VALORCOMERCIAL"
                        Dgv_Buscar.Columns(i).FillWeight = 100
                        Dgv_Buscar.Columns(i).HeaderText = "Valor Comercial"
                    Case "DESCRIPCION"
                        Dgv_Buscar.Columns(i).FillWeight = 200
                        Dgv_Buscar.Columns(i).HeaderText = "Descripción"
                    Case "NOMBREDESCRIPTIVO"
                        Dgv_Buscar.Columns(i).FillWeight = 200
                        Dgv_Buscar.Columns(i).HeaderText = "Artículo"
                    Case Else
                        'IDAPUMATERIAL, IDLICITACION, IDAPU, IDMATERIAL, CODIGOTIPOUNIDAD, IDARTICULO, FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                        'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA, ELIMINADO, FECHAELIMINACION, IDUSUARIOELIMINA, USUARIOELIMINA, ASOCIADOAEQUIPO
                        Dgv_Buscar.Columns(i).Visible = False
                End Select
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga del listado de Maquinaria y Equipo para la búsqueda.
    ''' Se carga la maquinaria en estado activo.
    ''' </summary>
    Private Sub CargarMaquinariaYEquipo()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaMaquinariaYEquipo(@TIPO, @IDUSUARIO)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 1)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        dtRecurso.Clear()
        Try
            conexion.Open()
            adaptador.FillSchema(dtRecurso, SchemaType.Source)
            adaptador.Fill(dtRecurso)
            conexion.Close()
            Dgv_Buscar.DataSource = dtRecurso
            For i As Integer = 0 To Dgv_Buscar.ColumnCount - 1
                Select Case Dgv_Buscar.Columns(i).Name
                    Case "CANTIDAD"
                        Dgv_Buscar.Columns(i).FillWeight = 50
                        Dgv_Buscar.Columns(i).HeaderText = "Cantidad"
                    Case "ESISMOCOL"
                        Dgv_Buscar.Columns(i).FillWeight = 50
                        Dgv_Buscar.Columns(i).HeaderText = "Es Ismocol"
                    Case "PORCENTAJEUTILIZACION"
                        Dgv_Buscar.Columns(i).FillWeight = 50
                        Dgv_Buscar.Columns(i).HeaderText = "Utilización"
                    Case "TARIFAISMOCOLXHORA"
                        Dgv_Buscar.Columns(i).FillWeight = 100
                        Dgv_Buscar.Columns(i).HeaderText = "Tarifa Ismocol por Hora"
                    Case "TARIFACOMERCIALXHORA"
                        Dgv_Buscar.Columns(i).FillWeight = 100
                        Dgv_Buscar.Columns(i).HeaderText = "Tarifa Comercial por hora"
                    Case "COMBUSTIBLEXHORA"
                        Dgv_Buscar.Columns(i).FillWeight = 100
                        Dgv_Buscar.Columns(i).HeaderText = "Combustible por hora"
                    Case "DESCRIPCION"
                        Dgv_Buscar.Columns(i).FillWeight = 200
                        Dgv_Buscar.Columns(i).HeaderText = "Descripción"
                    Case "NOMBREDESCRIPTIVO"
                        Dgv_Buscar.Columns(i).FillWeight = 200
                        Dgv_Buscar.Columns(i).HeaderText = "Artículo"
                    Case Else
                        'IDAPUMAQUINARIAYEQUIPO, IDLICITACION, IDAPU, IDMAQUINARIAYEQUIPO, IDARTICULO, FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                        'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA, ELIMINADO, FECHAELIMINACION, IDUSUARIOELIMINA, USUARIOELIMINA
                        Dgv_Buscar.Columns(i).Visible = False
                End Select
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga del listado de Mano de Obra para la búsqueda.
    ''' Se carga la mano de obra en estado activo.
    ''' </summary>
    Private Sub CargarManoDeObra()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaManoDeObra(@TIPO, @IDUSUARIO)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 1)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        dtRecurso.Clear()
        Try
            conexion.Open()
            adaptador.FillSchema(dtRecurso, SchemaType.Source)
            adaptador.Fill(dtRecurso)
            conexion.Close()
            Dgv_Buscar.DataSource = dtRecurso
            For i As Integer = 0 To Dgv_Buscar.ColumnCount - 1
                Select Case Dgv_Buscar.Columns(i).Name
                    Case "PORCENTAJEUTILIZACION"
                        Dgv_Buscar.Columns(i).FillWeight = 50
                        Dgv_Buscar.Columns(i).HeaderText = "Utilización"
                    Case "TARIFAISMOCOLXHORAHOMBRE"
                        Dgv_Buscar.Columns(i).FillWeight = 100
                        Dgv_Buscar.Columns(i).HeaderText = "Tarifa Ismocol por HH"
                    Case "MAQUINARIAYEQUIPOASOCIADO"
                        Dgv_Buscar.Columns(i).FillWeight = 100
                        Dgv_Buscar.Columns(i).HeaderText = "Maquinaria y Equipo que Asocia"
                    Case "DESCRIPCION"
                        Dgv_Buscar.Columns(i).FillWeight = 200
                        Dgv_Buscar.Columns(i).HeaderText = "Descripción"
                    Case Else
                        'IDAPUMANODEOBRA, IDLICITACION, IDAPU, IDMANODEOBRA, FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                        'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA, ELIMINADO,FECHAELIMINACION, IDUSUARIOELIMINA, USUARIOELIMINA,
                        'ASOCIADOAEQUIPO, IDMAQUINARIAYEQUIPO, ACTIVOASOCIADO
                        Dgv_Buscar.Columns(i).Visible = False
                End Select
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Asignación de estilos a las celdas de la rejilla.
    ''' </summary>
    Public Sub Comportamiento_Predeterminado()
        Dgv_Buscar.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Buscar.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub


    'Cierre del formulario
    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Close()
    End Sub


    'Llama a la función para insertar el recurso seleccionado al presionar el botón Insertar.
    Private Sub Bt_Insertar_Click(sender As Object, e As EventArgs) Handles Bt_Insertar.Click
        InsertarRecurso()
    End Sub


    '
    Private Sub Cb_Filtrar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Filtrar.SelectedIndexChanged

    End Sub


    'Llama a la función para insertar recurso al hacer doble clic sobre el recurso seleccionado.
    Private Sub Dgv_Buscar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Buscar.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            InsertarRecurso()
        End If
    End Sub


    ''' <summary>
    ''' Pasa el identificador del recurso seleccionado mediante la función de agregar recurso implementada en el formulario padre que lo agrega a la respectiva rejilla de recursos.
    ''' </summary>
    Private Sub InsertarRecurso()
        Select Case Recurso
            Case TipoRecurso.Licitacion
                _idrecurso = Dgv_Buscar.SelectedRows(0).Cells("IDLICITACION").Value
            Case TipoRecurso.Material
                _idrecurso = Dgv_Buscar.SelectedRows(0).Cells("IDMATERIAL").Value
            Case TipoRecurso.MaquinariaEquipo
                _idrecurso = Dgv_Buscar.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value
            Case TipoRecurso.ManoDeObra
                _idrecurso = Dgv_Buscar.SelectedRows(0).Cells("IDMANODEOBRA").Value
        End Select
        Select Case Recurso
            Case TipoRecurso.Licitacion
                Close()
            Case TipoRecurso.Material, TipoRecurso.MaquinariaEquipo, TipoRecurso.ManoDeObra
                FrPadre.AgregarRecurso(IdRecurso, Recurso)
        End Select
    End Sub


    'Abre el formulario de creación para el recurso en búsqueda y pasa el recurso para ser insertado en la respectiva rejilla del formulario padre.
    Private Sub Bt_AgregarRecurso_Click(sender As Object, e As EventArgs) Handles Bt_AgregarRecurso.Click
        Select Case Recurso
            Case TipoRecurso.Licitacion
                Exit Sub
            Case TipoRecurso.Material
                Using frMaterial As New Fr_Material
                    frMaterial.Edicion = TipoEdicion.Crear
                    frMaterial.ShowDialog()
                    If frMaterial.DialogResult = Windows.Forms.DialogResult.OK Then
                        _idrecurso = frMaterial.IdMaterial
                    End If
                End Using
            Case TipoRecurso.MaquinariaEquipo
                Using frMaquinaria As New Fr_MaquinariaEquipo
                    frMaquinaria.Edicion = TipoEdicion.Crear
                    frMaquinaria.ShowDialog()
                    If frMaquinaria.DialogResult = Windows.Forms.DialogResult.OK Then
                        _idrecurso = frMaquinaria.IdMaquinariaEquipo
                    End If
                End Using
            Case TipoRecurso.ManoDeObra
                Using frManoDeObra As New Fr_ManoDeObra
                    frManoDeObra.Edicion = TipoEdicion.Crear
                    frManoDeObra.ShowDialog()
                    If frManoDeObra.DialogResult = Windows.Forms.DialogResult.OK Then
                        _idrecurso = frManoDeObra.IdManoDeObra
                    End If
                End Using
        End Select
        FrPadre.AgregarRecurso(IdRecurso, Recurso)
    End Sub
End Class