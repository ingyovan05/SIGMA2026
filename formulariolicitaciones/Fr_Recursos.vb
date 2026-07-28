Imports FormularioLicitaciones.FormulariosLicitaciones
Imports System.Data.SqlClient
Imports System.Text

''' <summary>
''' Formulario de visualización de listado de recursos de licitaciones.
''' </summary>
Public Class Fr_Recursos
    ''' <summary>
    ''' Indica el tipo de recurso de licitación que se está visualizando.
    ''' </summary>
    ''' <value>Tipo de recurso listado.</value>
    ''' <returns>Tipo de recurso listado.</returns>
    Property Recurso As TipoRecurso

    ''' <summary>
    ''' Identificador de la licitación de la cual se muestra el listado de recursos.
    ''' </summary>
    ''' <value>Identificador de la licitación de la cual se cargan los recursos.</value>
    ''' <returns>Identificador de la licitación de la cual se cargan los recursos.</returns>
    Property IdLicitacion As Integer = -1

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


    'Carga del listado de recursos dependiendo del tipo de recurso.
    Private Sub Fr_Recursos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Case TipoRecurso.Material
                ListarMateriales()
            Case TipoRecurso.MaquinariaEquipo
                ListarMaquinariaYEquipos()
            Case TipoRecurso.ManoDeObra
                ListarManoDeObra()
            Case TipoRecurso.Licitacion
                Close()
        End Select
        Tx_Descripcion.Select()
    End Sub


    ''' <summary>
    ''' Estilos visuales de la rejilla.
    ''' </summary>
    Private Sub Comportamiento_Predeterminado()
        Dgv_Recursos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Recursos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
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
            Dgv_Recursos.SuspendLayout()
            Dgv_Recursos.DataSource = vista
            Dgv_Recursos.ResumeLayout()
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
    ''' Carga del listado del recurso Materiales.
    ''' </summary>
    Private Sub ListarMateriales()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaMaterialTotalLicitacion(@IDLICITACION)", conexion)
        comando.Parameters.AddWithValue("@IDLICITACION", IdLicitacion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dgv_Recursos.DataSource = Nothing
        Try
            conexion.Open()
            adaptador.Fill(dtRecurso)
            conexion.Close()
            Dgv_Recursos.DataSource = dtRecurso
            For i As Integer = 0 To Dgv_Recursos.ColumnCount - 1
                Select Case Dgv_Recursos.Columns(i).Name
                    Case "IDMATERIAL"
                        Dgv_Recursos.Columns(i).FillWeight = 50
                        Dgv_Recursos.Columns(i).HeaderText = "Código"
                    Case "ABREVIATURA"
                        Dgv_Recursos.Columns(i).FillWeight = 50
                        Dgv_Recursos.Columns(i).HeaderText = "Unidad"
                    Case "CANTIDAD"
                        Dgv_Recursos.Columns(i).FillWeight = 50
                        Dgv_Recursos.Columns(i).HeaderText = "Cantidad"
                        'Case "ESISMOCOL"
                        '    Dgv_Recursos.Columns(i).FillWeight = 50
                        '    Dgv_Recursos.Columns(i).HeaderText = "Es Ismocol"
                    Case "VALORISMOCOL"
                        Dgv_Recursos.Columns(i).FillWeight = 100
                        Dgv_Recursos.Columns(i).HeaderText = "Valor Ismocol"
                    Case "VALORCOMERCIAL"
                        Dgv_Recursos.Columns(i).FillWeight = 100
                        Dgv_Recursos.Columns(i).HeaderText = "Valor Comercial"
                    Case "DESCRIPCION"
                        Dgv_Recursos.Columns(i).FillWeight = 200
                        Dgv_Recursos.Columns(i).HeaderText = "Descripción"
                        'Case "NOMBREDESCRIPTIVO"
                        '    Dgv_Recursos.Columns(i).FillWeight = 200
                        '    Dgv_Recursos.Columns(i).HeaderText = "Artículo"
                    Case Else
                        'IDAPUMATERIAL, IDLICITACION, IDAPU, CODIGOTIPOUNIDAD, IDARTICULO, FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                        'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA, ELIMINADO, FECHAELIMINACION, IDUSUARIOELIMINA, USUARIOELIMINA, ASOCIADOAEQUIPO
                        Dgv_Recursos.Columns(i).Visible = False
                End Select
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga del listado del recurso Maquinaria y Equipo
    ''' </summary>
    Private Sub ListarMaquinariaYEquipos()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaMaquinariaYEquipoTotalLicitacion(@IDLICITACION)", conexion)
        comando.Parameters.AddWithValue("@IDLICITACION", IdLicitacion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dgv_Recursos.DataSource = Nothing
        Try
            conexion.Open()
            adaptador.Fill(dtRecurso)
            conexion.Close()
            Dgv_Recursos.DataSource = dtRecurso
            For i As Integer = 0 To Dgv_Recursos.ColumnCount - 1
                Select Case Dgv_Recursos.Columns(i).Name
                    Case "IDMAQUINARIAYEQUIPO"
                        Dgv_Recursos.Columns(i).FillWeight = 50
                        Dgv_Recursos.Columns(i).HeaderText = "Código"
                    Case "CANTIDAD"
                        Dgv_Recursos.Columns(i).FillWeight = 50
                        Dgv_Recursos.Columns(i).HeaderText = "Cantidad"
                        'Case "ESISMOCOL"
                        '    Dgv_Recursos.Columns(i).FillWeight = 50
                        '    Dgv_Recursos.Columns(i).HeaderText = "Es Ismocol"
                        'Case "PORCENTAJEUTILIZACION"
                        '    Dgv_Recursos.Columns(i).FillWeight = 50
                        '    Dgv_Recursos.Columns(i).HeaderText = "Utilización"
                    Case "TARIFAISMOCOLXHORA"
                        Dgv_Recursos.Columns(i).FillWeight = 100
                        Dgv_Recursos.Columns(i).HeaderText = "Tarifa Ismocol por Hora"
                    Case "TARIFACOMERCIALXHORA"
                        Dgv_Recursos.Columns(i).FillWeight = 100
                        Dgv_Recursos.Columns(i).HeaderText = "Tarifa Comercial por hora"
                        'Case "COMBUSTIBLEXHORA"
                        '    Dgv_Recursos.Columns(i).FillWeight = 100
                        '    Dgv_Recursos.Columns(i).HeaderText = "Combustible por hora"
                    Case "DESCRIPCION"
                        Dgv_Recursos.Columns(i).FillWeight = 200
                        Dgv_Recursos.Columns(i).HeaderText = "Descripción"
                        'Case "NOMBREDESCRIPTIVO"
                        '    Dgv_Recursos.Columns(i).FillWeight = 200
                        '    Dgv_Recursos.Columns(i).HeaderText = "Artículo"
                    Case Else
                        'IDAPUMAQUINARIAYEQUIPO, IDLICITACION, IDAPU, IDMAQUINARIAYEQUIPO, IDARTICULO, FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                        'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA, ELIMINADO, FECHAELIMINACION, IDUSUARIOELIMINA, USUARIOELIMINA
                        Dgv_Recursos.Columns(i).Visible = False
                End Select
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga del listado del recurso Mano de Obra.
    ''' </summary>
    Private Sub ListarManoDeObra()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaManoDeObraTotalLicitacion(@IDLICITACION)", conexion)
        comando.Parameters.AddWithValue("@IDLICITACION", IdLicitacion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dgv_Recursos.DataSource = Nothing
        Try
            conexion.Open()
            adaptador.Fill(dtRecurso)
            conexion.Close()
            Dgv_Recursos.DataSource = dtRecurso
            For i As Integer = 0 To Dgv_Recursos.ColumnCount - 1
                Select Case Dgv_Recursos.Columns(i).Name
                    Case "IDMANODEOBRA"
                        Dgv_Recursos.Columns(i).FillWeight = 50
                        Dgv_Recursos.Columns(i).HeaderText = "Código"
                    Case "CANTIDAD"
                        Dgv_Recursos.Columns(i).FillWeight = 50
                        Dgv_Recursos.Columns(i).HeaderText = "Cantidad"
                        'Case "PORCENTAJEUTILIZACION"
                        '    Dgv_Recursos.Columns(i).FillWeight = 50
                        '    Dgv_Recursos.Columns(i).HeaderText = "Utilización"
                    Case "TARIFAISMOCOLXHORAHOMBRE"
                        Dgv_Recursos.Columns(i).FillWeight = 100
                        Dgv_Recursos.Columns(i).HeaderText = "Tarifa Ismocol por HH"
                        'Case "MAQUINARIAYEQUIPOASOCIADO"
                        '    Dgv_Recursos.Columns(i).FillWeight = 100
                        '    Dgv_Recursos.Columns(i).HeaderText = "Maquinaria y Equipo que Asocia"
                    Case "DESCRIPCION"
                        Dgv_Recursos.Columns(i).FillWeight = 200
                        Dgv_Recursos.Columns(i).HeaderText = "Descripción"
                    Case Else
                        'IDAPUMANODEOBRA, IDLICITACION, IDAPU, FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                        'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA, ELIMINADO,FECHAELIMINACION, IDUSUARIOELIMINA, USUARIOELIMINA,
                        'ASOCIADOAEQUIPO, IDMAQUINARIAYEQUIPO, ACTIVOASOCIADO
                        Dgv_Recursos.Columns(i).Visible = False
                End Select
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    '
    Private Sub Dgv_Recursos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Recursos.CellDoubleClick
        'Abrir info del recurso (Fr_APU?, Fr_<<Recurso>>?).
    End Sub


    '
    Private Sub Cb_Filtrar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Filtrar.SelectedIndexChanged

    End Sub


    '
    Private Sub Bt_Exportar_Click(sender As Object, e As EventArgs) Handles Bt_Exportar.Click

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ExportarRecursos()

    End Sub


    'Cierre del formulario.
    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Close()
    End Sub

End Class 'Fr_Recursos