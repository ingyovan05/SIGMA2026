Imports FormularioLicitaciones.FormulariosLicitaciones
Imports System.Data.SqlClient

''' <summary>
''' Formulario de gestión de Ítem A.P.U.
''' </summary>
Public Class Fr_APU

    ''' <summary>
    ''' Identificador del Ítem A.P.U. que se gestiona.
    ''' </summary>
    ''' <value>Identificador del Ítem A.P.U.</value>
    ''' <returns>Identificador del Ítem A.P.U. que se gestiona.</returns>
    Property IdAPU As Integer = -1

    ''' <summary>
    ''' Indica el tipo de gestión que se realiza en el Ítem A.P.U.
    ''' </summary>
    ''' <value>Tipo de gestión que se realiza.</value>
    ''' <returns>Tipo de gestión que se realiza.</returns>
    Property Edicion As TipoEdicion

    ''' <summary>
    ''' Indica cual de las rejillas de recursos se encuentra seleccionada actualmente para que las acciones se realicen sobre el recurso correspondiente.
    ''' Por ejemplo: Al insertar un Material (recurso) se debe insertar en la rejilla Dgv_Materiales.
    ''' El valor cambia con el evento de cambio de pestaña de Tc_Recursos.
    ''' </summary>
    Private dgvActual As DataGridView

    ''' <summary>
    ''' Almacena el valor que contenía la celda que se encuentra en edición antes de empezar a digitar el nuevo valor.
    ''' Permite comparar si el valor cambió después de la edición para no volver a cargar un recurso ya ingresado en la rejilla.
    ''' </summary>
    Private valorAnterior As String = ""

    ''' <summary>
    ''' Estilo visual de las celdas con datos erroneos en la rejilla de recursos.
    ''' </summary>
    Private Estilo_Celda_Error As New DataGridViewCellStyle

    ''' <summary>
    ''' Almacena el valor actual del A.P.U. sin A.I.U.
    ''' </summary>
    Private valorActualSinAIU As Decimal = 0

    ''' <summary>
    ''' Almacena el valor actual del A.P.U. con A.I.U.
    ''' </summary>
    Private valorActualConAIU As Decimal = 0

    ''' <summary>
    ''' Almacena el valor de A.P.U. sin A.I.U. al momento de la carga para comprobar si al guardar el valor ha cambiado.
    ''' </summary>
    Private valorInicialSinAIU As Decimal = 0

    ''' <summary>
    ''' Almacena el valor de A.P.U. con A.I.U. al momento de la carga para comprobar si al guardar el valor ha cambiado.
    ''' </summary>
    Private valorInicialConAIU As Decimal = 0

    ''' <summary>
    ''' Contiene el listado de materiales ingresados en el A.P.U.
    ''' </summary>
    Private dtMaterialesAPU As DataTable

    ''' <summary>
    ''' Contiene el listado de maquinaria y equipo ingresada en el A.P.U.
    ''' </summary>
    Private dtMaquinariaEquipoAPU As DataTable

    ''' <summary>
    ''' Contiene el listado de mano de obra ingresada en el A.P.U.
    ''' </summary>
    Private dtManoDeObraAPU As DataTable

    ''' <summary>
    ''' Contiene los listados de recursos de las tablas maestras para utilizarse en el autocompletado de los nombres en las rejillas de recursos.
    ''' </summary>
    Private dsRecursosMaestras As DataSet

    ''' <summary>
    ''' Contiene el listado de Materiales que se pueden agregar al A.P.U. producto de la carga de recursos con materiales asociados.
    ''' El listado se incrementa al ingresar recursos con materiales asociados en las rejillas.
    ''' El listado disminuye cuando se seleccionan materiales del listado para ingresar a las rejillas mediante el formulario de recursos asociados.
    ''' </summary>
    Private dtMaterialAsociado As DataTable

    ''' <summary>
    ''' Contiene el listado de Mano de Obra que se puede agregar al A.P.U. producto de la carga de recursos con mano de obra asociada.
    ''' El listado se incrementa al ingresar recursos con mano de obra asociada en las rejillas.
    ''' El listado disminuye cuando se selecciona mano de obra del listado para ingresar a las rejillas mediante el formulario de recursos asociados.
    ''' </summary>
    Private dtManoDeObraAsociada As DataTable

    ''' <summary>
    ''' Indica el número de horas laborables definidas en la licitación.
    ''' Usado en el cálculo del rendimiento del A.P.U.
    ''' </summary>
    Private horasLaborables As Decimal


    ''' <summary>
    ''' Inicializa las tablas de datos de recursos de las rejillas, de las tablas maestras y de asociados.
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        dtMaterialesAPU = New DataTable
        dtMaquinariaEquipoAPU = New DataTable
        dtManoDeObraAPU = New DataTable
        dsRecursosMaestras = New DataSet
        dtMaterialAsociado = New DataTable
        dtManoDeObraAsociada = New DataTable

        AddHandler Tx_Cantidad.KeyPress, AddressOf TextBoxNumericoDecimal_KeyPress
        AddHandler Tx_RendimUndxHora.KeyPress, AddressOf TextBoxNumericoDecimal_KeyPress
        AddHandler Tx_RendimDias.KeyPress, AddressOf TextBoxNumericoDecimal_KeyPress
        AddHandler Tx_RendimHoraxUnd.KeyPress, AddressOf TextBoxNumericoDecimal_KeyPress
    End Sub


    ' Nota: Cambiar TextBox del formulario por Cu_TextBoxDecimal
    Private Sub TextBoxNumericoDecimal_KeyPress(sender As Object, e As KeyPressEventArgs)
        If InStr(1, "0123456789" & Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) & Convert.ToChar(Keys.Back), e.KeyChar) = 0 Then
            e.Handled = True
            'e.KeyChar = CChar("")
        End If
        If e.KeyChar = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) And sender.SelectionStart > 0 Then
            If sender.Text.Substring(sender.SelectionStart - 1, 1) = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) Then
                e.Handled = True
                'e.KeyChar = CChar("")
            End If
        End If
    End Sub


    'Carga del Ítem A.P.U. y recursos.
    Private Sub Fr_APU_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'ISMOCOLPRODUCCIONDataSet2.LIC_MA_MANODEOBRA' Puede moverla o quitarla según sea necesario.
        Me.LIC_MA_MANODEOBRATableAdapter.Fill(Me.ISMOCOLPRODUCCIONDataSet2.LIC_MA_MANODEOBRA)
        'TODO: esta línea de código carga datos en la tabla 'ISMOCOLPRODUCCIONDataSet1.LIC_MA_MATERIAL' Puede moverla o quitarla según sea necesario.
        Me.LIC_MA_MATERIALTableAdapter.Fill(Me.ISMOCOLPRODUCCIONDataSet1.LIC_MA_MATERIAL)
        'TODO: esta línea de código carga datos en la tabla 'ISMOCOLPRODUCCIONDataSet.LIC_MA_MAQUINARIAYEQUIPO' Puede moverla o quitarla según sea necesario.
        Me.LIC_MA_MAQUINARIAYEQUIPOTableAdapter.Fill(Me.ISMOCOLPRODUCCIONDataSet.LIC_MA_MAQUINARIAYEQUIPO)

        Comportamiento_Predeterminado()
        CargarListaTipoUnidad()
        CargarDatosLicitacion()
        CargarRecursosMaestras()
        If Edicion = TipoEdicion.Editar Or Edicion = TipoEdicion.Ver Or Edicion = TipoEdicion.Clonar Then
            CargarAPU()
            Ck_EsCapitulo.Enabled = False
        Else 'Crear/Nuevo
            CargarTablas()
            AgregarRecursosMenores()
            Bt_Imprimir.Enabled = False
        End If
        If Edicion = TipoEdicion.Ver Then
            Tx_NroItemLicitacion.ReadOnly = True
            Tx_Cantidad.ReadOnly = True
            Cb_TipoUnidad.Enabled = False
            Tx_NroItemCliente.ReadOnly = True
            Tx_Descripcion.ReadOnly = True
            Tx_RendimUndxHora.ReadOnly = True
            Tx_RendimDias.ReadOnly = True
            Tx_RendimHoraxUnd.ReadOnly = True
            Ll_RecursosAsociados.Enabled = False
            Dgv_Material.ReadOnly = True
            Dgv_Material.AllowUserToAddRows = False
            Dgv_MaquinariaEquipo.ReadOnly = True
            Dgv_MaquinariaEquipo.AllowUserToAddRows = False
            Dgv_ManoDeObra.ReadOnly = True
            Dgv_ManoDeObra.AllowUserToAddRows = False
            Bt_Guardar.Enabled = False
            Bt_Cancelar.Select()
        Else 'Editar, Clonar, Nuevo
            FuncionesBase.FuncionesBase.EnfocarCajaTexto(Tx_NroItemCliente)
        End If
    End Sub


    ''' <summary>
    ''' Carga el listado de unidades para asignarlo a la lista desplegable.
    ''' </summary>
    Private Sub CargarListaTipoUnidad()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListarTipoUnidad() ORDER BY [UNIDAD]", conexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtTipoUnidad As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtTipoUnidad)
            conexion.Close()
            Cb_TipoUnidad.DataSource = dtTipoUnidad
            Cb_TipoUnidad.ValueMember = "CODIGO"
            Cb_TipoUnidad.DisplayMember = "UNIDAD"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga el valor del número de horas laborables de la licitación del A.P.U. gestionado para utilizarlo en los cálculos de rendimiento.
    ''' </summary>
    Private Sub CargarDatosLicitacion()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_DatosLicitacion(@IDLICITACION, @IDUSUARIO)", conexion)
        comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtLicitacion As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtLicitacion)
            conexion.Close()
            If dtLicitacion.Rows.Count > 0 Then
                Dim drLicitacion As DataRow
                drLicitacion = dtLicitacion.Rows(0)
                horasLaborables = drLicitacion.Item("HORASDIARIAS")
            Else
                MsgBox("No fue posible cargar los datos de la licitación actual.", MsgBoxStyle.Critical, "Cargar Datos Licitación")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga los listados de Recursos de las tablas maestras para usarse como fuentes de autocompletado al escribir en la columna "Descripción" de las rejillas de recursos.
    ''' </summary>
    Private Sub CargarRecursosMaestras()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("ListarLIC_RecursosMaestras", conexion)
        comando.CommandType = CommandType.StoredProcedure
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dsRecursosMaestras)
            conexion.Close()
            dsRecursosMaestras.Tables(0).TableName = "MAQUINARIAYEQUIPO"
            dsRecursosMaestras.Tables(1).TableName = "MATERIAL"
            dsRecursosMaestras.Tables(2).TableName = "MANODEOBRA"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga los datos de un Ítem A.P.U. existente y sus recursos.
    ''' </summary>
    Private Sub CargarAPU()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_DatosAPU(@IDAPU)", conexion)
        comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        comando.Parameters.AddWithValue("@IDAPU", IdAPU)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtAPU As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtAPU, SchemaType.Source)
            adaptador.Fill(dtAPU)
            conexion.Close()

            'Asignaciones
            Tx_NroItemLicitacion.Text = dtAPU.Rows(0).Item("NROITEMLICITACION")
            Tx_NroItemCliente.Text = If(Not IsDBNull(dtAPU.Rows(0).Item("NROITEMCLIENTE")), Trim(dtAPU.Rows(0).Item("NROITEMCLIENTE")), "")
            Tx_Descripcion.Text = dtAPU.Rows(0).Item("DESCRIPCION")
            If dtAPU.Rows(0).Item("ESCAPITULO") = "N" Then
                Ck_EsCapitulo.Checked = False
                Cb_TipoUnidad.SelectedValue = dtAPU.Rows(0).Item("CODIGOTIPOUNIDAD")
                If Not IsDBNull(dtAPU.Rows(0).Item("CANTIDADESTIMADA")) Then
                    Tx_Cantidad.Text = FormatoDecimal(dtAPU.Rows(0).Item("CANTIDADESTIMADA"))
                End If

                If Not IsDBNull(dtAPU.Rows(0).Item("VALORTOTALITEMSINAIU")) Then
                    valorInicialSinAIU = dtAPU.Rows(0).Item("VALORTOTALITEMSINAIU")
                End If
                If Not IsDBNull(dtAPU.Rows(0).Item("VALORTOTALITEMCONAIU")) Then
                    valorInicialConAIU = dtAPU.Rows(0).Item("VALORTOTALITEMCONAIU")
                End If

                If Not IsDBNull(dtAPU.Rows(0).Item("RENDIMIENTO")) Then
                    Tx_RendimHoraxUnd.Text = FormatoDecimal(dtAPU.Rows(0).Item("RENDIMIENTO"))
                    CalcularRendimiento_RendimHoraxUnd()
                End If

                CargarTablas()

                'Ck_Activa.ThreeState = False
                'If dtAPU.Rows(0).Item("ACTIVA") = "S" Then
                '    Ck_Activa.Checked = True
                '    Ck_Activa.CheckState = CheckState.Checked
                'ElseIf dtAPU.Rows(0).Item("ACTIVA") = "N" Then
                '    Ck_Activa.Checked = False
                '    Ck_Activa.CheckState = CheckState.Unchecked
                'Else
                '    Ck_Activa.Checked = False
                '    Ck_Activa.CheckState = CheckState.Indeterminate
                'End If
            Else
                Ck_EsCapitulo.Checked = True
                Bt_Imprimir.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga los recursos del Ítem A.P.U.
    ''' </summary>
    Private Sub CargarTablas()
        CargarMaterialesAPU()
        CargarMaquinariaYEquiposAPU()
        CargarManoDeObraAPU()
        CalcularSubtotales()
        Tc_Recursos.SelectedTab = Tp_MaquinariaEquipo
        dgvActual = Dgv_MaquinariaEquipo
    End Sub


    ''' <summary>
    ''' Carga el listado de Materiales del Ítem A.P.U.
    ''' </summary>
    Private Sub CargarMaterialesAPU()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaAPU_Material(@TIPO, @IDLICITACION, @IDAPU)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 1)
        comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        comando.Parameters.AddWithValue("@IDAPU", IdAPU)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.FillSchema(dtMaterialesAPU, SchemaType.Source)
            adaptador.Fill(dtMaterialesAPU)
            conexion.Close()
            dtMaterialesAPU.Columns.Add("SUBTOTAL")
            Dgv_Material.DataSource = dtMaterialesAPU
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Ingresa los Materiales por defecto al crear un A.P.U.
    ''' </summary>
    Private Sub AgregarRecursosMenores()
        Dim bloquearFilas As Boolean = False
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaMaterial(@TIPO, @IDUSUARIO)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 2) 'Recursos Menores.
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtRecursosMenores As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtRecursosMenores)
            conexion.Close()
        Catch ex As Exception
            MsgBox("No se cargaron los recursos menores.", MsgBoxStyle.Critical, "Agregar Recursos Menores")
            Exit Sub
        Finally
            conexion.Close()
        End Try
        Dim drCombustible As DataRow()
        drCombustible = Dgv_Material.DataSource.Select("IDMATERIAL" & "=" & "1") 'Combustible
        If drCombustible.Length = 0 Then
            drCombustible = dtRecursosMenores.Select("IDMATERIAL" & "=" & "1") 'Combustible
            Dgv_Material.DataSource.ImportRow(drCombustible(0))
            For i As Integer = 0 To Dgv_Material.Rows.Count - 1
                If Dgv_Material.Rows(i).Cells(DescripcionMa.Name).Value = "Combustible" Then
                    Dgv_Material.Rows(i).ReadOnly = True
                    Dgv_Material.Rows(i).Cells(CantidadMa.Name).Value = 0
                End If
            Next
        Else
            bloquearFilas = True
        End If

        Dim drHerramientaMenor As DataRow()
        drHerramientaMenor = Dgv_Material.DataSource.Select("IDMATERIAL" & "=" & "2") 'Herramienta Menor
        If drHerramientaMenor.Length = 0 Then
            drHerramientaMenor = dtRecursosMenores.Select("IDMATERIAL" & "=" & "2") 'Herramienta Menor
            Dgv_Material.DataSource.ImportRow(drHerramientaMenor(0))
            For i As Integer = 0 To Dgv_Material.Rows.Count - 1
                If Dgv_Material.Rows(i).Cells(DescripcionMa.Name).Value = "Herramienta Menor" Then
                    Dgv_Material.Rows(i).ReadOnly = True
                    Dgv_Material.Rows(i).Cells(CantidadMa.Name).Value = 1
                    Dgv_Material.Rows(i).Cells(ValorIsmocol.Name).Value = 0
                End If
            Next
        Else
            bloquearFilas = True
        End If

        Dim drMaterialMenor As DataRow()
        drMaterialMenor = Dgv_Material.DataSource.Select("IDMATERIAL" & "=" & "3") 'Material Menor
        If drMaterialMenor.Length = 0 Then
            drMaterialMenor = dtRecursosMenores.Select("IDMATERIAL" & "=" & "3") 'Material Menor
            Dgv_Material.DataSource.ImportRow(drMaterialMenor(0))
            For i As Integer = 0 To Dgv_Material.Rows.Count - 1
                If Dgv_Material.Rows(i).Cells(DescripcionMa.Name).Value = "Material Menor" Then
                    Dgv_Material.Rows(i).ReadOnly = True
                    Dgv_Material.Rows(i).Cells(CantidadMa.Name).Value = 1
                    Dgv_Material.Rows(i).Cells(ValorIsmocol.Name).Value = 0
                End If
            Next
        Else
            bloquearFilas = True
        End If

        NumerarFilas(Dgv_Material)
        MarcarRecursoIsmocol(Dgv_Material)
        EliminarFilasVacias(Dgv_Material)
        CalcularRecursosMenores()
        If bloquearFilas Then
            BloquearFilasRecursosMenores()
        End If
    End Sub


    ''' <summary>
    ''' Desactiva la edición de las filas de recursos menores en la rejilla de materiales.
    ''' </summary>
    Private Sub BloquearFilasRecursosMenores()
        If Not IsNothing(Dgv_Material.DataSource) Then
            Dim drCombustible As DataRow()
            drCombustible = Dgv_Material.DataSource.Select("IDMATERIAL" & "=" & "1") 'Combustible
            If drCombustible.Length > 0 Then
                For i As Integer = 0 To Dgv_Material.Rows.Count - 1
                    If Dgv_Material.Rows(i).Cells(DescripcionMa.Name).Value = "Combustible" Then
                        Dgv_Material.Rows(i).ReadOnly = True
                    End If
                Next
            End If

            Dim drHerramientaMenor As DataRow()
            drHerramientaMenor = Dgv_Material.DataSource.Select("IDMATERIAL" & "=" & "2") 'Herramienta Menor
            If drHerramientaMenor.Length > 0 Then
                For i As Integer = 0 To Dgv_Material.Rows.Count - 1
                    If Dgv_Material.Rows(i).Cells(DescripcionMa.Name).Value = "Herramienta Menor" Then
                        Dgv_Material.Rows(i).ReadOnly = True
                    End If
                Next
            End If

            Dim drMaterialMenor As DataRow()
            drMaterialMenor = Dgv_Material.DataSource.Select("IDMATERIAL" & "=" & "3") 'Material Menor
            If drMaterialMenor.Length > 0 Then
                For i As Integer = 0 To Dgv_Material.Rows.Count - 1
                    If Dgv_Material.Rows(i).Cells(DescripcionMa.Name).Value = "Material Menor" Then
                        Dgv_Material.Rows(i).ReadOnly = True
                    End If
                Next
            End If
        End If
    End Sub


    ''' <summary>
    ''' Determina las cantidades y valores de los recursos incluidos por defecto (Combustible, Herramienta Menor, Material Menor) cuando se agrega un nuevo recurso o se editan valores de recursos ya ingresados.
    ''' </summary>
    Private Sub CalcularRecursosMenores()
        Dim agregarFilas As Boolean = False
        Dim drCombustible As DataRow()
        drCombustible = Dgv_Material.DataSource.Select("DESCRIPCION='Combustible'")
        If drCombustible.Length = 1 Then
            Dim cantidadCombustible As Decimal = 0
            For i As Integer = 0 To Dgv_MaquinariaEquipo.Rows.Count - 2
                If Not IsDBNull(Dgv_MaquinariaEquipo.Rows(i).Cells(CombustiblePorHora.Name).Value) AndAlso Not IsDBNull(Dgv_MaquinariaEquipo.Rows(i).Cells(CantidadME.Name).Value) AndAlso Not IsDBNull(Dgv_MaquinariaEquipo.Rows(i).Cells(RendimientoME.Name).Value) Then
                    cantidadCombustible += Dgv_MaquinariaEquipo.Rows(i).Cells(CombustiblePorHora.Name).Value * Dgv_MaquinariaEquipo.Rows(i).Cells(CantidadME.Name).Value * Dgv_MaquinariaEquipo.Rows(i).Cells(RendimientoME.Name).Value
                End If
            Next
            drCombustible(0).Item("CANTIDAD") = cantidadCombustible
        ElseIf drCombustible.Length = 0 Then
            agregarFilas = True
        End If

        Dim subtotalManoDeObra As Decimal = 0
        If Not IsNothing(Lb_SubtotalManoDeObra.Text) AndAlso Trim(Lb_SubtotalManoDeObra.Text) <> "" Then
            subtotalManoDeObra = CDec(Lb_SubtotalManoDeObra.Text)
        End If

        Dim drHerramienta As DataRow()
        drHerramienta = Dgv_Material.DataSource.Select("DESCRIPCION='Herramienta Menor'")
        If drHerramienta.Length = 1 Then
            drHerramienta(0).Item("VALORISMOCOL") = subtotalManoDeObra * 0.025
        ElseIf drHerramienta.Length = 0 Then
            agregarFilas = True
        End If

        Dim drMaterial As DataRow()
        drMaterial = Dgv_Material.DataSource.Select("DESCRIPCION='Material Menor'")
        If drMaterial.Length = 1 Then
            drMaterial(0).Item("VALORISMOCOL") = subtotalManoDeObra * 0.03
        ElseIf drMaterial.Length = 0 Then
            agregarFilas = True
        End If

        If agregarFilas Then
            AgregarRecursosMenores()
        End If
    End Sub


    ''' <summary>
    ''' Carga el listado de Maquinaria y Equipo del Ítem A.P.U.
    ''' </summary>
    Private Sub CargarMaquinariaYEquiposAPU()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaAPU_MaquinariaYEquipo(@TIPO, @IDLICITACION, @IDAPU)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 1)
        comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        comando.Parameters.AddWithValue("@IDAPU", IdAPU)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.FillSchema(dtMaquinariaEquipoAPU, SchemaType.Source)
            adaptador.Fill(dtMaquinariaEquipoAPU)
            conexion.Close()
            dtMaquinariaEquipoAPU.Columns.Add("SUBTOTAL")
            Dgv_MaquinariaEquipo.DataSource = dtMaquinariaEquipoAPU
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Carga el listado de Mano de Obra del Ítem A.P.U.
    ''' </summary>
    Private Sub CargarManoDeObraAPU()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaAPU_ManoDeObra(@TIPO, @IDLICITACION, @IDAPU)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 1)
        comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        comando.Parameters.AddWithValue("@IDAPU", IdAPU)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.FillSchema(dtManoDeObraAPU, SchemaType.Source)
            adaptador.Fill(dtManoDeObraAPU)
            conexion.Close()
            dtManoDeObraAPU.Columns.Add("SUBTOTAL")
            Dgv_ManoDeObra.DataSource = dtManoDeObraAPU
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Calcula los valores de la columna "Subtotal" en todas las filas de Recursos en las rejillas.
    ''' </summary>
    Private Sub CalcularSubtotales()
        CalcularSubtotalMaquinaria()
        CalcularSubtotalMaterial()
        CalcularSubtotalManoDeObra()
        CalcularValoresItem()
    End Sub


    ''' <summary>
    ''' Calcula los valores de la columna "Subtotal" en todas las filas de la rejilla de Maquinaria y Equipo y el subtotal de Maquinaria del Ítem A.P.U.
    ''' </summary>
    Private Sub CalcularSubtotalMaquinaria()
        If Not IsNothing(Dgv_MaquinariaEquipo.DataSource) Then
            Dim valorParcialME As Decimal = 0
            Dim subtotalMaquinaria As Decimal = 0

            For i As Integer = 0 To Dgv_MaquinariaEquipo.Rows.Count - 2
                If Not IsDBNull(Dgv_MaquinariaEquipo.Rows(i).Cells(CantidadME.Name).Value) AndAlso Not IsDBNull(Dgv_MaquinariaEquipo.Rows(i).Cells(TarifaIsmocolPorHora.Name).Value) AndAlso Not IsDBNull(Dgv_MaquinariaEquipo.Rows(i).Cells(RendimientoME.Name).Value) Then
                    valorParcialME = Math.Round(Dgv_MaquinariaEquipo.Rows(i).Cells(CantidadME.Name).Value * Dgv_MaquinariaEquipo.Rows(i).Cells(TarifaIsmocolPorHora.Name).Value * Dgv_MaquinariaEquipo.Rows(i).Cells(RendimientoME.Name).Value)
                    Dgv_MaquinariaEquipo.Rows(i).Cells(SubtotalME.Name).Value = Format(valorParcialME, "C0")
                    subtotalMaquinaria += valorParcialME
                End If
            Next

            Lb_SubtotalMaquinariaEquipo.Text = Format(subtotalMaquinaria, "C0")
        End If
    End Sub


    ''' <summary>
    ''' Calcula los valores de la columna "Subtotal" en todas las filas de la rejilla de Material y el subtotal de Materiales del Ítem A.P.U.
    ''' </summary>
    Private Sub CalcularSubtotalMaterial()
        If Not IsNothing(Dgv_Material.DataSource) Then
            Dim valorParcialM As Decimal = 0
            Dim subtotalMaterial As Decimal = 0

            For j As Integer = 0 To Dgv_Material.DataSource.Rows.Count - 1
                If Not IsDBNull(Dgv_Material.Rows(j).Cells(CantidadMa.Name).Value) AndAlso Not IsDBNull(Dgv_Material.Rows(j).Cells(ValorIsmocol.Name).Value) Then
                    valorParcialM = Math.Round(Dgv_Material.Rows(j).Cells(CantidadMa.Name).Value * Dgv_Material.Rows(j).Cells(ValorIsmocol.Name).Value)
                    Dgv_Material.Rows(j).Cells(SubtotalMa.Name).Value = Format(valorParcialM, "C0")
                    subtotalMaterial += valorParcialM
                End If
            Next

            Lb_SubtotalMaterial.Text = Format(subtotalMaterial, "C0")
        End If
    End Sub


    ''' <summary>
    ''' Calcula los valores de la columna "Subtotal" en todas las filas de la rejilla de Mano de Obra, el subtotal de Mano de Obra del Ítem A.P.U y el Total de Horas Hombre del Ítem.
    ''' </summary>
    Private Sub CalcularSubtotalManoDeObra()
        If Not IsNothing(Dgv_ManoDeObra.DataSource) Then
            Dim valorParcialMO As Decimal = 0
            Dim horasHombreParcial As Decimal = 0
            Dim subtotalManoDeObra As Decimal = 0
            Dim totalHorasHombrexUnd As Decimal = 0
            Dim totalHorasHombre As Decimal = 0

            For k As Integer = 0 To Dgv_ManoDeObra.DataSource.Rows.Count - 1
                If Not IsDBNull(Dgv_ManoDeObra.Rows(k).Cells(CantidadMO.Name).Value) AndAlso Not IsDBNull(Dgv_ManoDeObra.Rows(k).Cells(TarifaIsmocolPorHoraHombre.Name).Value) AndAlso Not IsDBNull(Dgv_ManoDeObra.Rows(k).Cells(RendimientoMO.Name).Value) Then
                    valorParcialMO = Math.Round(Dgv_ManoDeObra.Rows(k).Cells(CantidadMO.Name).Value * Dgv_ManoDeObra.Rows(k).Cells(TarifaIsmocolPorHoraHombre.Name).Value * Dgv_ManoDeObra.Rows(k).Cells(RendimientoMO.Name).Value)
                    horasHombreParcial = Dgv_ManoDeObra.Rows(k).Cells(CantidadMO.Name).Value * Dgv_ManoDeObra.Rows(k).Cells(RendimientoMO.Name).Value
                    Dgv_ManoDeObra.Rows(k).Cells(SubtotalMO.Name).Value = Format(valorParcialMO, "C0")
                    subtotalManoDeObra += valorParcialMO
                    totalHorasHombrexUnd += horasHombreParcial
                End If
            Next
            totalHorasHombre = totalHorasHombrexUnd * Valor(Tx_Cantidad) 'Cantidad del Ítem

            Lb_SubtotalManoDeObra.Text = Format(subtotalManoDeObra, "C0")
            Lb_TotalHorasHombrexUnd.Text = Format(totalHorasHombrexUnd, "0.##")
            Lb_TotalHorasHombre.Text = Format(totalHorasHombre, "0.##")
        End If
    End Sub


    ''' <summary>
    ''' Calcula los valores unitarios del ítem A.P.U.
    ''' </summary>
    Private Sub CalcularValoresItem()
        CalcularValorItemSinAIU()
        CalcularValorItemConAIU()
    End Sub


    ''' <summary>
    ''' Calcula el valor unitario del ítem A.P.U. sin aplicar los porcentajes de A.I.U. (costo directo).
    ''' </summary>
    Private Sub CalcularValorItemSinAIU()
        Dim subtotalMaquinariaEquipo = FuncionesBase.FuncionesBase.ValorRealDec(Lb_SubtotalMaquinariaEquipo.Text)
        Dim subtotalMaterial = FuncionesBase.FuncionesBase.ValorRealDec(Lb_SubtotalMaterial.Text)
        Dim subtotalManoObra = FuncionesBase.FuncionesBase.ValorRealDec(Lb_SubtotalManoDeObra.Text)
        subtotalMaquinariaEquipo = If(subtotalMaquinariaEquipo > 0, subtotalMaquinariaEquipo, 0)
        subtotalMaterial = If(subtotalMaterial > 0, subtotalMaterial, 0)
        subtotalManoObra = If(subtotalManoObra > 0, subtotalManoObra, 0)
        valorActualSinAIU = subtotalMaquinariaEquipo + subtotalMaterial + subtotalManoObra
        Lb_ValorSinAIU.Text = Format(valorActualSinAIU, "C0")
    End Sub


    ''' <summary>
    ''' Calcula el valor unitario del ítem A.P.U. aplicando los porcentajes de A.I.U.
    ''' </summary>
    Private Sub CalcularValorItemConAIU()
        valorActualConAIU = 0
        Lb_ValorConAIU.Text = Format(valorActualConAIU, "C0")
    End Sub


    ' Ejecuta el cálculo de los valores unitarios del ítem A.P.U. al cambiar el texto de las etiquetas de subtotales de recursos.
    Private Sub Lb_Subtotal_TextChanged(sender As Object, e As EventArgs) Handles Lb_SubtotalMaterial.TextChanged, Lb_SubtotalMaquinariaEquipo.TextChanged, Lb_SubtotalManoDeObra.TextChanged
        CalcularValoresItem()
    End Sub


    ''' <summary>
    ''' Carga de los estilos visuales de la rejilla de recursos.
    ''' </summary>
    Public Sub Comportamiento_Predeterminado()
        Dgv_Material.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Material.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Dgv_MaquinariaEquipo.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_MaquinariaEquipo.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Dgv_ManoDeObra.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_ManoDeObra.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Estilo_Celda_Error.BackColor = Color.Red

        Tsmi_Ma_Editar.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso("609") 'Nbi_EditarMaterial
        Tsmi_ME_Editar.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso("616") 'Nbi_EditarEquipo
        Tsmi_MO_Editar.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso("623") 'Nbi_EditarManoDeObra
    End Sub


    ' Actualiza los demás valores de rendimiento al cambiar el texto en las cajas de texto de rendimiento.
    Private Sub Tx_Rendimiento_TextChanged(sender As Object, e As EventArgs) _
        Handles Tx_Cantidad.TextChanged, Tx_RendimUndxHora.TextChanged, Tx_RendimDias.TextChanged, Tx_RendimHoraxUnd.TextChanged
        If sender.Focused Then 'Verifica que no se ejecute durante la asignación de valores a los controles con el método CargarAPU()
            Select Case sender.Name
                Case Tx_Cantidad.Name
                    CalcularRendimiento_Cantidad()
                Case Tx_RendimUndxHora.Name
                    CalcularRendimiento_RendimUndxHora()
                Case Tx_RendimDias.Name
                    CalcularRendimiento_RendimDias()
                Case Tx_RendimHoraxUnd.Name
                    CalcularRendimiento_RendimHoraxUnd()
            End Select
            CalcularSubtotales()
        End If
    End Sub


    ''' <summary>
    ''' Determina el rendimiento en días cuando cambia el valor de cantidad del Ítem A.P.U.
    ''' </summary>
    Private Sub CalcularRendimiento_Cantidad()
        Dim cantidad As Decimal = 0
        Dim rendimUndH As Decimal = 0

        cantidad = Valor(Tx_Cantidad)
        rendimUndH = Valor(Tx_RendimUndxHora)

        If rendimUndH <> 0 Then
            Tx_RendimDias.Text = FormatoDecimal(cantidad / (rendimUndH * horasLaborables))
        Else
            Tx_RendimDias.Text = FormatoDecimal(0)
        End If
    End Sub


    ''' <summary>
    ''' Determina el rendimiento en unidades por hora y en días cuando cambia el valor de rendimiento en unidad por hora.
    ''' </summary>
    Private Sub CalcularRendimiento_RendimUndxHora()
        Dim cantidad As Decimal = 0
        Dim rendimUndxHora As Decimal = 0
        Dim rendimDias As Decimal = 0
        Dim rendimHoraxUnd As Decimal = 0

        cantidad = Valor(Tx_Cantidad)
        rendimUndxHora = Valor(Tx_RendimUndxHora)

        If rendimUndxHora <> 0 Then
            rendimHoraxUnd = 1 / rendimUndxHora
            rendimDias = cantidad / (rendimUndxHora * horasLaborables)
            Tx_RendimHoraxUnd.Text = FormatoDecimal(rendimHoraxUnd)
            Tx_RendimDias.Text = FormatoDecimal(rendimDias)
        Else
            Tx_RendimHoraxUnd.Text = FormatoDecimal(0)
            Tx_RendimDias.Text = FormatoDecimal(0)
        End If
        HabilitarTx_RendimDias()
        ActualizarRendimientoRecursos()
    End Sub


    ''' <summary>
    ''' Determina el rendimiento en unidades por hora y horas por unidad cuando cambia el valor de rendimiento en días.
    ''' </summary>
    Private Sub CalcularRendimiento_RendimDias()
        Dim cantidad As Decimal = 0
        Dim rendimDias As Decimal = 0
        Dim rendimUndxHora As Decimal = 0
        Dim rendimHoraxUnd As Decimal = 0

        cantidad = Valor(Tx_Cantidad)
        rendimDias = Valor(Tx_RendimDias)

        If rendimDias <> 0 Then
            rendimUndxHora = cantidad / (rendimDias * horasLaborables)
            rendimHoraxUnd = (rendimDias / cantidad) * horasLaborables
            Tx_RendimUndxHora.Text = FormatoDecimal(rendimUndxHora)
            Tx_RendimHoraxUnd.Text = FormatoDecimal(rendimHoraxUnd)
        Else
            Tx_RendimUndxHora.Text = FormatoDecimal(0)
            Tx_RendimHoraxUnd.Text = FormatoDecimal(0)
        End If
        ActualizarRendimientoRecursos()
    End Sub


    ''' <summary>
    ''' calcula el rendimiento en días y en unidades por hora cuando cambia el valor de rendimiento en horas por unidad.
    ''' </summary>
    Private Sub CalcularRendimiento_RendimHoraxUnd()
        Dim cantidad As Decimal = 0
        Dim rendimHoraxUnd As Decimal = 0
        Dim rendimDias As Decimal = 0
        Dim rendimUndxHora As Decimal = 0

        cantidad = Valor(Tx_Cantidad)
        rendimHoraxUnd = Valor(Tx_RendimHoraxUnd)

        If rendimHoraxUnd <> 0 Then
            rendimUndxHora = (1 / rendimHoraxUnd)
            rendimDias = (cantidad * rendimHoraxUnd) / horasLaborables
            Tx_RendimUndxHora.Text = FormatoDecimal(rendimUndxHora)
            Tx_RendimDias.Text = FormatoDecimal(rendimDias)
        Else
            Tx_RendimUndxHora.Text = FormatoDecimal(0)
            Tx_RendimDias.Text = FormatoDecimal(0)
        End If
        HabilitarTx_RendimDias()
        ActualizarRendimientoRecursos()
    End Sub


    ''' <summary>
    ''' Habilita o deshabilita el cuadro de texto de días dependiendo de si se ha ingresado alguno de los valores del rendimiento.
    ''' </summary>
    Private Sub HabilitarTx_RendimDias()
        If Valor(Tx_RendimUndxHora) = 0 AndAlso Valor(Tx_RendimHoraxUnd) = 0 Then
            Tx_RendimDias.Enabled = False
        Else
            Tx_RendimDias.Enabled = True
        End If
    End Sub


    ''' <summary>
    ''' Modifica el valor de la columna "Rendimiento" en todas las filas de Maquinaria y Equipo y Mano de Obra en las rejillas.
    ''' </summary>
    Private Sub ActualizarRendimientoRecursos()
        If Not IsNothing(Dgv_MaquinariaEquipo.DataSource) AndAlso Not IsNothing(Dgv_ManoDeObra.DataSource) Then
            Dim consumo As Decimal = 0
            consumo = Valor(Tx_RendimHoraxUnd)

            If consumo <> 0 Then
                For i As Integer = 0 To Dgv_MaquinariaEquipo.DataSource.Rows.Count - 1
                    Dgv_MaquinariaEquipo.DataSource.Rows(i).Item("RENDIMIENTO") = consumo
                Next
                For j As Integer = 0 To Dgv_ManoDeObra.DataSource.Rows.Count - 1
                    Dgv_ManoDeObra.DataSource.Rows(j).Item("RENDIMIENTO") = consumo
                Next
            End If
            CalcularRecursosMenores()
        End If
    End Sub


    ' Muestra el cuadro de sugerencias de nombre de recurso al empezar a editar el valor de una celda de la columna "Descripción" en las rejillas de recurso.
    Private Sub Dgv_Recurso_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_MaquinariaEquipo.EditingControlShowing, Dgv_Material.EditingControlShowing, Dgv_ManoDeObra.EditingControlShowing
        Dim cb_Descripcion As DataGridViewComboBoxEditingControl
        Select Case dgvActual.Name
            Case Dgv_MaquinariaEquipo.Name
                If dgvActual.CurrentCell.ColumnIndex <> Dgv_MaquinariaEquipo.Columns(IdMaquinariaYEquipo.Name).Index Then 'DescripcionME
                    Exit Sub
                End If
            Case Dgv_Material.Name
                If dgvActual.CurrentCell.ColumnIndex <> Dgv_Material.Columns(IdMaterial.Name).Index Then
                    Exit Sub
                End If
            Case Dgv_ManoDeObra.Name
                If dgvActual.CurrentCell.ColumnIndex <> Dgv_ManoDeObra.Columns(IdManoDeObra.Name).Index Then
                    Exit Sub
                End If
        End Select
        cb_Descripcion = e.Control
        cb_Descripcion.DropDownStyle = ComboBoxStyle.DropDown
        cb_Descripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cb_Descripcion.AutoCompleteSource = AutoCompleteSource.ListItems
        RemoveHandler cb_Descripcion.SelectedIndexChanged, AddressOf DataGridViewComboBox_SelectedIndexChanged
        AddHandler cb_Descripcion.SelectedIndexChanged, AddressOf DataGridViewComboBox_SelectedIndexChanged
        RemoveHandler cb_Descripcion.SelectionChangeCommitted, AddressOf DataGridViewComboBox_SelectionChangeCommitted
        AddHandler cb_Descripcion.SelectionChangeCommitted, AddressOf DataGridViewComboBox_SelectionChangeCommitted
    End Sub


    ' Asigna el valor seleccionado del cuadro de sugerencias al salir de la edición de la celda.
    Private Sub DataGridViewComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim dgvcb_Recurso As DataGridViewComboBoxEditingControl = sender
        If Not IsNothing(sender.SelectedValue) AndAlso IsNumeric(sender.SelectedValue) Then
            sender.EditingControlDataGridView.Rows(sender.EditingControlRowIndex).Cells(sender.EditingControlDataGridView.SelectedCells(0).ColumnIndex).Value = sender.SelectedValue
        End If
    End Sub


    ' 
    Private Sub DataGridViewComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
        Dim dgvcb_Recurso As DataGridViewComboBoxEditingControl = sender
    End Sub


    ' 
    Private Sub Dgv_Recurso_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Dgv_MaquinariaEquipo.DataError, Dgv_Material.DataError, Dgv_ManoDeObra.DataError

    End Sub


    'Acciones de teclas en la rejilla de recursos.
    'F3: Abre el formulario de búsqueda para el recurso actual (según la pestaña activa).
    'Delete/Suprimir: retira los datos en las celdas seleccionadas o elimina las filas seleccionadas.
    Private Sub Dgv_Recurso_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Dgv_Material.KeyDown, Dgv_MaquinariaEquipo.KeyDown, Dgv_ManoDeObra.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Using frBuscarRecurso As New Fr_BuscarRecurso
                    frBuscarRecurso.FrPadre = Me
                    Select Case sender.name
                        Case Dgv_Material.Name
                            frBuscarRecurso.Recurso = TipoRecurso.Material
                        Case Dgv_MaquinariaEquipo.Name
                            frBuscarRecurso.Recurso = TipoRecurso.MaquinariaEquipo
                        Case Dgv_ManoDeObra.Name
                            frBuscarRecurso.Recurso = TipoRecurso.ManoDeObra
                    End Select
                    frBuscarRecurso.ShowDialog()
                End Using
            Case Keys.Delete
                If dgvActual.SelectedRows.Count > 0 Then
                    For Each dgvRow As DataGridViewRow In dgvActual.SelectedRows
                        dgvActual.Rows.Remove(dgvRow)
                    Next
                Else
                    Dim idColumn As String = ""
                    Select Case dgvActual.Name
                        Case Dgv_Material.Name
                            idColumn = Dgv_Material.Columns("IdMaterial").Name
                        Case Dgv_MaquinariaEquipo.Name
                            idColumn = Dgv_MaquinariaEquipo.Columns("IdMaquinariaYEquipo").Name
                        Case Dgv_ManoDeObra.Name
                            idColumn = Dgv_ManoDeObra.Columns("IdManoDeObra").Name
                    End Select
                    For Each dgvCell As DataGridViewCell In dgvActual.SelectedCells
                        If dgvCell.OwningColumn.Name <> idColumn Then
                            If Not dgvCell.ReadOnly Then
                                dgvCell.Value = DBNull.Value
                            End If
                        End If
                    Next
                End If
        End Select

        'Revisar propiedades de Dgv para copiado y pegado.
        'If e.Control And e.KeyCode.ToString = "C" Then
        '    'Copiar()
        'ElseIf e.Control And e.KeyCode.ToString = "V" Then
        '    'If Validar Then
        '    '   Pegar()
        '    'End If
        'End If
    End Sub


    'Almacena el valor previo a edición para evitar la carga de recurso si el valor nuevo es el mismo que el almacenado.
    Private Sub Dgv_Recurso_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles Dgv_Material.CellBeginEdit, Dgv_MaquinariaEquipo.CellBeginEdit, Dgv_ManoDeObra.CellBeginEdit
        If Not IsNothing(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            valorAnterior = sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
        End If
    End Sub


    'Agregar recurso cuando se ingresa un valor en la columna de identificador del recurso.
    Private Sub Dgv_Recurso_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Dgv_Material.CellEndEdit, Dgv_MaquinariaEquipo.CellEndEdit, Dgv_ManoDeObra.CellEndEdit
        Select Case sender.Name
            Case Dgv_Material.Name
                If e.ColumnIndex = sender.Columns("IdMaterial").Index Then
                    If Not IsDBNull(sender.Rows(e.RowIndex).Cells(IdMaterial.Name).Value) Then
                        AgregarRecurso(sender.Rows(e.RowIndex).Cells(IdMaterial.Name).Value, TipoRecurso.Material, e.RowIndex)
                    End If
                ElseIf e.ColumnIndex = sender.Columns("CantidadMa").Index Then
                    CalcularSubtotalMaterial()
                End If
            Case Dgv_MaquinariaEquipo.Name
                If e.ColumnIndex = sender.Columns("IdMaquinariaYEquipo").Index Then
                    If Not IsDBNull(sender.Rows(e.RowIndex).Cells(IdMaquinariaYEquipo.Name).Value) Then
                        AgregarRecurso(sender.Rows(e.RowIndex).Cells(IdMaquinariaYEquipo.Name).Value, TipoRecurso.MaquinariaEquipo, e.RowIndex)
                    End If
                ElseIf e.ColumnIndex = sender.Columns("CantidadME").Index OrElse e.ColumnIndex = sender.Columns("RendimientoME").Index Then
                    CalcularSubtotalMaquinaria()
                    CalcularRecursosMenores()
                    CalcularSubtotalMaterial()
                End If
            Case Dgv_ManoDeObra.Name
                If e.ColumnIndex = sender.Columns("IdManoDeObra").Index Then
                    If Not IsDBNull(sender.Rows(e.RowIndex).Cells(IdManoDeObra.Name).Value) Then
                        AgregarRecurso(sender.Rows(e.RowIndex).Cells(IdManoDeObra.Name).Value, TipoRecurso.ManoDeObra, e.RowIndex)
                    End If
                ElseIf e.ColumnIndex = sender.Columns("CantidadMO").Index OrElse e.ColumnIndex = sender.Columns("RendimientoMO").Index Then
                    CalcularSubtotalManoDeObra()
                    CalcularRecursosMenores()
                    CalcularSubtotalMaterial()
                End If
        End Select
        CalcularValoresItem()
        valorAnterior = ""
    End Sub


    ''' <summary>
    ''' Insertar un recurso en la rejilla de la pestaña activa.
    ''' Si el recurso se agrega por medio del formulario de búsqueda, se inserta la fila del recurso al final de la rejilla.
    ''' Si se ingresa el identificador del recurso en la rejilla, se elimina la fila editada y se inserta la fila cargada en el lugar de la fila anterior.
    ''' </summary>
    ''' <param name="codigoRecurso">Identificador del Recurso del cual se consultan los datos para ingresarlo en la rejilla.</param>
    ''' <param name="tipoDeRecurso">Tipo del recurso a insertar.</param>
    ''' <param name="rowIndex">Opcional. Indica el número de fila que en donde se deben ingresar los datos del recurso.</param>
    Public Sub AgregarRecurso(codigoRecurso As Integer, tipoDeRecurso As TipoRecurso, Optional rowIndex As Integer = -1, Optional cantidad As Decimal = 0)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand()
        Select Case tipoDeRecurso
            Case TipoRecurso.Material
                comando.CommandText = "SELECT * FROM dbo.LIC_DatosMaterial(@TIPO, @IDMATERIAL, @IDLICITACION)"
                comando.Parameters.AddWithValue("@IDMATERIAL", codigoRecurso)
            Case TipoRecurso.MaquinariaEquipo
                comando.CommandText = "SELECT * FROM dbo.LIC_DatosMaquinariaYEquipo(@TIPO, @IDMAQUINARIAYEQUIPO, @IDLICITACION)"
                comando.Parameters.AddWithValue("@IDMAQUINARIAYEQUIPO", codigoRecurso)
            Case TipoRecurso.ManoDeObra
                comando.CommandText = "SELECT * FROM dbo.LIC_DatosManoDeObra(@TIPO, @IDMANODEOBRA, @IDLICITACION)"
                comando.Parameters.AddWithValue("@IDMANODEOBRA", codigoRecurso)
        End Select
        comando.Parameters.AddWithValue("@TIPO", 1) 'Recursos activos.
        comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        comando.Connection = conexion
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtRecurso As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtRecurso, SchemaType.Source)
            adaptador.Fill(dtRecurso)
            conexion.Close()
            If dtRecurso.Rows.Count < 1 Then 'Verifica que el recurso exista en la base de datos.
                dgvActual.CancelEdit()
                EliminarFilasVacias(dgvActual)
                Exit Sub
            End If
            dtRecurso.Rows(0).Item("FECHAREGISTRO") = DateTime.Now
            dtRecurso.Rows(0).Item("IDUSUARIOREGISTRO") = VariablesBase.VariablesBase.IdPersona
            Select Case tipoDeRecurso
                Case TipoRecurso.MaquinariaEquipo
                    Tc_Recursos.SelectedTab = Tp_MaquinariaEquipo
                Case TipoRecurso.Material
                    Tc_Recursos.SelectedTab = Tp_Material
                Case TipoRecurso.ManoDeObra
                    Tc_Recursos.SelectedTab = Tp_ManoDeObra
            End Select

            If ValidarFilaRecurso(dgvActual, dtRecurso.Rows(0)) Then
                EliminarFilasVacias(dgvActual)
                If dgvActual.Rows.Count - 1 > 0 AndAlso rowIndex >= 0 AndAlso rowIndex < dgvActual.Rows.Count - 1 Then 'Insertar la nueva fila en la posición de la fila anterior.
                    dgvActual.Rows.RemoveAt(rowIndex)
                    Dim drRecurso As DataRow = dgvActual.DataSource.NewRow()
                    Select Case tipoDeRecurso
                        Case TipoRecurso.Material
                            drRecurso.Item("IDMATERIAL") = dtRecurso.Rows(0).Item("IDMATERIAL")
                            drRecurso.Item("DESCRIPCION") = dtRecurso.Rows(0).Item("DESCRIPCION")
                            drRecurso.Item("CODIGOTIPOUNIDAD") = dtRecurso.Rows(0).Item("CODIGOTIPOUNIDAD")
                            drRecurso.Item("ABREVIATURA") = dtRecurso.Rows(0).Item("ABREVIATURA")
                            drRecurso.Item("IDARTICULO") = dtRecurso.Rows(0).Item("IDARTICULO")
                            drRecurso.Item("NOMBREDESCRIPTIVO") = dtRecurso.Rows(0).Item("NOMBREDESCRIPTIVO")
                            drRecurso.Item("VALORISMOCOL") = dtRecurso.Rows(0).Item("VALORISMOCOL")
                            drRecurso.Item("VALORCOMERCIAL") = dtRecurso.Rows(0).Item("VALORCOMERCIAL")
                            drRecurso.Item("FECHAREGISTRO") = dtRecurso.Rows(0).Item("FECHAREGISTRO")
                            drRecurso.Item("IDUSUARIOREGISTRO") = dtRecurso.Rows(0).Item("IDUSUARIOREGISTRO")
                            drRecurso.Item("USUARIOREGISTRO") = dtRecurso.Rows(0).Item("USUARIOREGISTRO")
                            drRecurso.Item("FECHAMODIFICACION") = dtRecurso.Rows(0).Item("FECHAMODIFICACION")
                            drRecurso.Item("IDUSUARIOMODIFICA") = dtRecurso.Rows(0).Item("IDUSUARIOMODIFICA")
                            drRecurso.Item("USUARIOMODIFICA") = dtRecurso.Rows(0).Item("USUARIOMODIFICA")
                        Case TipoRecurso.MaquinariaEquipo
                            drRecurso.Item("IDMAQUINARIAYEQUIPO") = dtRecurso.Rows(0).Item("IDMAQUINARIAYEQUIPO")
                            drRecurso.Item("DESCRIPCION") = dtRecurso.Rows(0).Item("DESCRIPCION")
                            drRecurso.Item("IDARTICULO") = dtRecurso.Rows(0).Item("IDARTICULO")
                            drRecurso.Item("NOMBREDESCRIPTIVO") = dtRecurso.Rows(0).Item("NOMBREDESCRIPTIVO")
                            drRecurso.Item("TARIFAISMOCOLXHORA") = dtRecurso.Rows(0).Item("TARIFAISMOCOLXHORA")
                            drRecurso.Item("TARIFACOMERCIALXHORA") = dtRecurso.Rows(0).Item("TARIFACOMERCIALXHORA")
                            drRecurso.Item("COMBUSTIBLEXHORA") = dtRecurso.Rows(0).Item("COMBUSTIBLEXHORA")
                            drRecurso.Item("FECHAREGISTRO") = dtRecurso.Rows(0).Item("FECHAREGISTRO")
                            drRecurso.Item("RENDIMIENTO") = Valor(Tx_RendimHoraxUnd)
                            drRecurso.Item("IDUSUARIOREGISTRO") = dtRecurso.Rows(0).Item("IDUSUARIOREGISTRO")
                            drRecurso.Item("FECHAMODIFICACION") = dtRecurso.Rows(0).Item("FECHAMODIFICACION")
                            drRecurso.Item("IDUSUARIOMODIFICA") = dtRecurso.Rows(0).Item("IDUSUARIOMODIFICA")
                        Case TipoRecurso.ManoDeObra
                            drRecurso.Item("IDMANODEOBRA") = dtRecurso.Rows(0).Item("IDMANODEOBRA")
                            drRecurso.Item("DESCRIPCION") = dtRecurso.Rows(0).Item("DESCRIPCION")
                            drRecurso.Item("TARIFAISMOCOLXHORAHOMBRE") = dtRecurso.Rows(0).Item("TARIFAISMOCOLXHORAHOMBRE")
                            drRecurso.Item("RENDIMIENTO") = Valor(Tx_RendimHoraxUnd)
                            drRecurso.Item("FECHAREGISTRO") = dtRecurso.Rows(0).Item("FECHAREGISTRO")
                            drRecurso.Item("IDUSUARIOREGISTRO") = dtRecurso.Rows(0).Item("IDUSUARIOREGISTRO")
                            drRecurso.Item("USUARIOREGISTRO") = dtRecurso.Rows(0).Item("USUARIOREGISTRO")
                            drRecurso.Item("FECHAMODIFICACION") = dtRecurso.Rows(0).Item("FECHAMODIFICACION")
                            drRecurso.Item("IDUSUARIOMODIFICA") = dtRecurso.Rows(0).Item("IDUSUARIOMODIFICA")
                            drRecurso.Item("USUARIOMODIFICA") = dtRecurso.Rows(0).Item("USUARIOMODIFICA")
                    End Select
                    dgvActual.DataSource.Rows.InsertAt(drRecurso, rowIndex)
                    dgvActual.DataSource.AcceptChanges()
                    NumerarFilas(dgvActual, rowIndex)
                    MarcarRecursoIsmocol(dgvActual, rowIndex)
                Else 'Insertar la fila al final de la rejilla.
                    Select Case tipoDeRecurso
                        Case TipoRecurso.MaquinariaEquipo, TipoRecurso.ManoDeObra
                            dtRecurso.Columns.Add("RENDIMIENTO")
                            dtRecurso.Columns.Add("SUBTOTAL")
                            dtRecurso.Rows(0).Item("RENDIMIENTO") = Valor(Tx_RendimHoraxUnd)
                    End Select
                    dgvActual.DataSource.ImportRow(dtRecurso.Rows(0))
                    dgvActual.DataSource.AcceptChanges()
                    If cantidad > 0 Then
                        dgvActual.DataSource.Rows(dgvActual.DataSource.Rows.count - 1).Item("CANTIDAD") = cantidad
                    End If
                    NumerarFilas(dgvActual, dgvActual.DataSource.Rows.Count - 1)
                    MarcarRecursoIsmocol(dgvActual, dgvActual.DataSource.rows.count - 1)
                End If
            Else
                dgvActual.CancelEdit()
            End If
            EliminarFilasVacias(dgvActual)

            If tipoDeRecurso = TipoRecurso.MaquinariaEquipo Then
                AgregarRecursosAsociadosAEquipos(codigoRecurso)
            End If
            If tipoDeRecurso = TipoRecurso.MaquinariaEquipo Or tipoDeRecurso = TipoRecurso.ManoDeObra Then
                CalcularRecursosMenores()
            End If
            CalcularSubtotales()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Agrega los Recursos asociados a Maquinaria y Equipo a la estructura DataTable.
    ''' Cambia el texto informativo de la etiqueta para indicar la cantidad de recursos asociados disponibles o pendientes para ser agregados a las rejillas.
    ''' </summary>
    ''' <param name="codigoRecurso">Identificador de la Maquinaria de la cual se consulta si tiene Recursos asociados.</param>
    Private Sub AgregarRecursosAsociadosAEquipos(ByVal codigoRecurso As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ListarLIC_RecursosAsociados", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDMAQUINARIAYEQUIPO", codigoRecurso)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsRecursos As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsRecursos)
            conexion.Close()
            dtMaterialAsociado.Merge(dsRecursos.Tables(0))
            dtManoDeObraAsociada.Merge(dsRecursos.Tables(1))

            ActualizarTextoRecursosAsociados()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ActualizarTextoRecursosAsociados()
        If dtMaterialAsociado.Rows.Count + dtManoDeObraAsociada.Rows.Count > 0 Then
            Ll_RecursosAsociados.Text = "Agregar Recursos Asociados (" & (dtMaterialAsociado.Rows.Count + dtManoDeObraAsociada.Rows.Count) & ")."
            Ll_RecursosAsociados.Visible = True
        Else
            Ll_RecursosAsociados.Text = "No hay Recursos Asociados por agregar"
            Ll_RecursosAsociados.Visible = False
        End If
    End Sub


    ' 
    Private Sub Ll_RecursosAsociados_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Ll_RecursosAsociados.LinkClicked
        Using frRecursosAsociados As New Fr_RecursosAsociados(dtMaterialAsociado, dtManoDeObraAsociada)
            frRecursosAsociados.FrPadre = Me
            frRecursosAsociados.ShowDialog()
        End Using
        ActualizarTextoRecursosAsociados()
    End Sub


    ''' <summary>
    ''' Verifica si el recurso se encuentra presente en el listado de A.P.U. antes de agregarlo.
    ''' Si el recurso no se encuentra aun en el listado, la función devuelve el valor verdadero para indicar que se debe agregar.
    ''' En caso contrario se devuelve el valor falso para cancelar la inserción.
    ''' </summary>
    ''' <param name="dgvActual">Listado de los Recursos del A.P.U.</param>
    ''' <param name="drFila">Fila con el recurso que se verifica antes de agregar al listado</param>
    ''' <returns>Verdadero si el recurso no se encuentra en el listado. Falso si el recurso ya ha sido agregado al listado.</returns>
    Private Function ValidarFilaRecurso(ByVal dgvActual As DataGridView, ByVal drFila As DataRow) As Boolean
        Dim filas As DataRow()
        Select Case dgvActual.Name
            Case Dgv_Material.Name
                filas = dgvActual.DataSource.Select("[" & "IDMATERIAL" & "]='" & drFila.Item("IDMATERIAL") & "'")
            Case Dgv_MaquinariaEquipo.Name
                filas = dgvActual.DataSource.Select("[" & "IDMAQUINARIAYEQUIPO" & "]='" & drFila.Item("IDMAQUINARIAYEQUIPO") & "'")
            Case Dgv_ManoDeObra.Name
                filas = dgvActual.DataSource.Select("[" & "IDMANODEOBRA" & "]='" & drFila.Item("IDMANODEOBRA") & "'")
            Case Else
                filas = Nothing
        End Select
        If filas.Length > 0 Then 'Controla que no se inserte un recurso repetido en la rejilla.
            ValidarFilaRecurso = False
            Exit Function
        End If
        ValidarFilaRecurso = True
    End Function


    ''' <summary>
    ''' Elimina las filas sin datos de las rejillas.
    ''' Esta rutina es llamada al agregar recursos para retirar las filas totalmente en blanco o que sólo contienen el identificador con el que se buscó el recurso insertado.
    ''' </summary>
    ''' <param name="dgvActual">Rejilla de la pestaña activa en donde se realiza la limpieza de filas vacías.</param>
    Private Sub EliminarFilasVacias(ByVal dgvActual As DataGridView)
        Select Case dgvActual.Name
            Case Dgv_Material.Name
                For i As Integer = dgvActual.RowCount - 2 To 0 Step -1
                    If (IsDBNull(dgvActual.Rows(i).Cells(IdAPUMaterial.Name).Value) OrElse Trim(dgvActual.Rows(i).Cells(IdAPUMaterial.Name).Value) = "") OrElse _
                        (IsDBNull(dgvActual.Rows(i).Cells(DescripcionMa.Name).Value) OrElse Trim(dgvActual.Rows(i).Cells(DescripcionMa.Name).Value) = "") Then
                        dgvActual.Rows.RemoveAt(i)
                    End If
                Next
            Case Dgv_MaquinariaEquipo.Name
                For i As Integer = dgvActual.RowCount - 2 To 0 Step -1
                    If (IsDBNull(dgvActual.Rows(i).Cells(IdAPUMaquinariaYEquipo.Name).Value) OrElse Trim(dgvActual.Rows(i).Cells(IdAPUMaquinariaYEquipo.Name).Value) = "") OrElse _
                        (IsDBNull(dgvActual.Rows(i).Cells(DescripcionME.Name).Value) OrElse Trim(dgvActual.Rows(i).Cells(DescripcionME.Name).Value) = "") Then
                        dgvActual.Rows.RemoveAt(i)
                    End If
                Next
            Case Dgv_ManoDeObra.Name
                For i As Integer = dgvActual.Rows.Count - 2 To 0 Step -1
                    If (IsDBNull(dgvActual.Rows(i).Cells(IdAPUManoDeObra.Name).Value) OrElse Trim(dgvActual.Rows(i).Cells(IdAPUManoDeObra.Name).Value) = "") OrElse _
                        (IsDBNull(dgvActual.Rows(i).Cells(DescripcionMO.Name).Value) OrElse Trim(dgvActual.Rows(i).Cells(DescripcionMO.Name).Value) = "") Then
                        dgvActual.Rows.RemoveAt(i)
                    End If
                Next
        End Select
    End Sub


    'Renumera las filas posteriores cuando se elimina un recurso.
    Private Sub Dgv_Recurso_RowsRemoved(ByVal sender As Object, ByVal e As DataGridViewRowsRemovedEventArgs) Handles Dgv_Material.RowsRemoved, Dgv_MaquinariaEquipo.RowsRemoved, Dgv_ManoDeObra.RowsRemoved
        If Not IsNothing(sender.DataSource) Then
            If sender.Rows.Count > 0 Then
                NumerarFilas(sender, e.RowIndex)
                CalcularRecursosMenores()
                CalcularSubtotales()
            End If
        End If
    End Sub


    ''' <summary>
    ''' Asigna un número de ítem a las filas cuando se insertan o cuando se borra una fila superior.
    ''' </summary>
    ''' <param name="dgv">Rejilla de la pestaña activa donde se insertaron o retiraron filas.</param>
    ''' <param name="rowIndex">Posición a partir de la cual se numeran las filas restantes.</param>
    Private Sub NumerarFilas(ByVal dgv As DataGridView, Optional ByVal rowIndex As Integer = 0)
        For i As Integer = rowIndex To dgv.Rows.Count - 2
            Select Case dgv.Name
                Case Dgv_Material.Name
                    dgv.Rows(i).Cells(IdAPUMaterial.Name).Value = i + 1
                Case Dgv_MaquinariaEquipo.Name
                    dgv.Rows(i).Cells(IdAPUMaquinariaYEquipo.Name).Value = i + 1
                Case Dgv_ManoDeObra.Name
                    dgv.Rows(i).Cells(IdAPUManoDeObra.Name).Value = i + 1
            End Select
        Next
    End Sub


    ''' <summary>
    ''' Activa la casilla de la columna "EsIsmocol" en las rejillas de recursos al ingresar nuevas filas de recursos.
    ''' Se recurre a este método debido a que no hay una opción nativa para establecer el valor por defecto de la casilla (siempre se crea con valor False).
    ''' </summary>
    ''' <param name="dgv">Control DataGridView en el cual se ingresaron los recursos a marcar.</param>
    ''' <param name="rowIndex">Fila a partir de la cual se enumeran las filas consecuentes.</param>
    Private Sub MarcarRecursoIsmocol(dgv As DataGridView, Optional rowIndex As Integer = 0)
        For i As Integer = rowIndex To dgv.DataSource.Rows.Count - 1 'dgv.Rows.Count - 2
            Select Case dgv.Name
                Case Dgv_Material.Name
                    If IsDBNull(dgv.DataSource.Rows(i).Item(EsIsmocolMa.DataPropertyName)) Then
                        dgv.DataSource.Rows(i).Item(EsIsmocolMa.DataPropertyName) = "S"
                    End If
                Case Dgv_MaquinariaEquipo.Name
                    If IsDBNull(dgv.DataSource.Rows(i).Item(EsIsmocolME.DataPropertyName)) Then
                        dgv.DataSource.Rows(i).Item(EsIsmocolME.DataPropertyName) = "S"
                    End If
            End Select
        Next
    End Sub


    'Almacena la rejilla que está actualmente en uso de acuerdo con la pestaña que se encuentra activa.
    Private Sub Tc_Recursos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Tc_Recursos.SelectedIndexChanged
        Select Case Tc_Recursos.SelectedTab.Name
            Case Tp_Material.Name
                dgvActual = Dgv_Material
                BloquearFilasRecursosMenores()
            Case Tp_MaquinariaEquipo.Name
                dgvActual = Dgv_MaquinariaEquipo
            Case Tp_ManoDeObra.Name
                dgvActual = Dgv_ManoDeObra
        End Select
    End Sub


    ' Controla el comportamiento al hacer clic derecho sobre las rejillas de recursos.
    ' Si se efectuó el clic sobre una celda, selecciona la fila completa de la celda.
    ' Si se hace clic sobre el encabezado de las columnas ignora el llamado del control de menú emergente.
    Private Sub Dgv_Recurso_MouseDown(sender As Object, e As MouseEventArgs) Handles Dgv_MaquinariaEquipo.MouseDown, Dgv_Material.MouseDown, Dgv_ManoDeObra.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hit = sender.HitTest(e.X, e.Y)
            If hit.RowIndex >= 0 Then
                sender.ClearSelection()
                sender.Rows(hit.RowIndex).Selected = True
            End If
        End If
    End Sub


    ' Abre la ventana de gestión del recurso seleccionado en modo de edición.
    Private Sub Tsmi_Editar_Click(sender As Object, e As EventArgs) Handles Tsmi_ME_Editar.Click, Tsmi_Ma_Editar.Click, Tsmi_MO_Editar.Click
        If dgvActual.SelectedCells.Count > 0 Then
            Dim idRecurso As Integer = -1
            Dim nuevoPrecio As Decimal = Nothing
            Select Case dgvActual.Name
                Case Dgv_MaquinariaEquipo.Name
                    idRecurso = Dgv_MaquinariaEquipo.SelectedRows(0).Cells(IdMaquinariaYEquipo.Name).Value
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("616") Then 'Nbi_EditarEquipo
                        Using frMaquinariaEquipo As New Fr_MaquinariaEquipo
                            frMaquinariaEquipo.IdMaquinariaEquipo = idRecurso
                            frMaquinariaEquipo.Edicion = TipoEdicion.Editar
                            frMaquinariaEquipo.EditandoDesdeLicitacion = True
                            If frMaquinariaEquipo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                Dgv_MaquinariaEquipo.SelectedRows(0).Cells(TarifaIsmocolPorHora.Name).Value = frMaquinariaEquipo.TarifaIsmocolxHora
                                Dgv_MaquinariaEquipo.SelectedRows(0).Cells(TarifaComercialPorHora.Name).Value = frMaquinariaEquipo.TarifaComercialxHora
                            End If
                        End Using
                    End If
                Case Dgv_Material.Name
                    idRecurso = Dgv_Material.SelectedRows(0).Cells(IdMaterial.Name).Value
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("609") Then 'Nbi_EditarMaterial
                        Using frMaterial As New Fr_Material
                            frMaterial.IdMaterial = idRecurso
                            frMaterial.Edicion = TipoEdicion.Editar
                            frMaterial.EditandoDesdeLicitacion = True
                            If frMaterial.ShowDialog = Windows.Forms.DialogResult.OK Then
                                Dgv_Material.SelectedRows(0).Cells(ValorIsmocol.Name).Value = frMaterial.ValorIsmocol
                                Dgv_Material.SelectedRows(0).Cells(ValorComercial.Name).Value = frMaterial.ValorComercial
                            End If
                        End Using
                    End If
                Case Dgv_ManoDeObra.Name
                    idRecurso = Dgv_ManoDeObra.SelectedRows(0).Cells(IdManoDeObra.Name).Value
                    If FuncionesBase.FuncionesBase.ConsultarPermiso("623") Then 'Nbi_EditarManoDeObra
                        Using frManoDeObra As New Fr_ManoDeObra
                            frManoDeObra.IdManoDeObra = idRecurso
                            frManoDeObra.Edicion = TipoEdicion.Editar
                            frManoDeObra.EditandoDesdeLicitacion = True
                            If frManoDeObra.ShowDialog = Windows.Forms.DialogResult.OK Then
                                Dgv_ManoDeObra.SelectedRows(0).Cells(TarifaIsmocolPorHoraHombre.Name).Value = frManoDeObra.TarifaIsmocolxHoraHombre
                            End If
                        End Using
                    End If
            End Select
        End If
    End Sub


    'Guardado del Ítem A.P.U.
    Private Sub Bt_Guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_Guardar.Click
        If ValidarAPU() Then
            GuardarAPU()
        End If
    End Sub


    ''' <summary>
    ''' Comprueba que los datos ingresados en los campos del formulario y en las rejillas de recursos sean válidos.
    ''' </summary>
    ''' <returns>
    ''' Verdadero si todos los datos ingresados son válidos.
    ''' Falso si algún dato es inválido.
    ''' </returns>
    Function ValidarAPU() As Boolean
        If Tx_NroItemLicitacion.Text.Length <= 0 Then
            ValidarAPU = False
            MsgBox("El número del ítem no debe estar vacío", MsgBoxStyle.Exclamation, "A.P.U.")
            Tx_NroItemLicitacion.Focus()
            Exit Function
        End If
        If Tx_Descripcion.Text.Length <= 0 Then
            ValidarAPU = False
            MsgBox("La descripción no debe estar vacía", MsgBoxStyle.Exclamation, "A.P.U.")
            Tx_Descripcion.Focus()
            Exit Function
        End If
        If Ck_EsCapitulo.Checked = False Then
            '
            'La cantidad del ítem puede ser indefinida.
            '
            If Cb_TipoUnidad.SelectedValue <= 0 Then
                ValidarAPU = False
                MsgBox("La unidad no debe estar vacía", MsgBoxStyle.Exclamation, "A.P.U.")
                Cb_TipoUnidad.Focus()
                Exit Function
            End If
            If Not ValidarMateriales() Then
                ValidarAPU = False
                Exit Function
            End If
            If Not ValidarEquipos() Then
                ValidarAPU = False
                Exit Function
            End If
            If Not ValidarManoDeObra() Then
                ValidarAPU = False
                Exit Function
            End If
        End If

        ValidarAPU = True
    End Function


    ''' <summary>
    ''' Comprueba que los datos ingresados en la rejilla de Materiales sean válidos.
    ''' </summary>
    ''' <returns>
    ''' Verdadero si todos los datos de todas las filas de Materiales son válidos.
    ''' Falso si algún dato de alguna fila es erróneo.
    '''</returns>
    Private Function ValidarMateriales() As Boolean
        EliminarFilasVacias(Dgv_Material)
        For i As Integer = 0 To Dgv_Material.RowCount - 2
            If IsDBNull(Dgv_Material.Rows(i).Cells(CantidadMa.Name).Value) OrElse Trim(Dgv_Material.Rows(i).Cells(CantidadMa.Name).Value) = "" OrElse (Not IsNumeric(Dgv_Material.Rows(i).Cells(CantidadMa.Name).Value)) Then
                Tc_Recursos.SelectedTab = Tp_Material 'Cambiar a pestaña de Materiales
                ValidarMateriales = False
                Dgv_Material.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                Dgv_Material.Rows(i).ErrorText = "La cantidad no debe estar vacía"
                MsgBox("La cantidad no debe estar vacía", MsgBoxStyle.Exclamation, "A.P.U.")
                Exit Function
            End If
            If Dgv_Material.Rows(i).Cells(CantidadMa.Name).Value <= 0 AndAlso Dgv_Material.Rows(i).Cells(IdMaterial.Name).Value >= 4 Then
                Tc_Recursos.SelectedTab = Tp_Material 'Cambiar a pestaña de Materiales
                ValidarMateriales = False
                Dgv_Material.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                Dgv_Material.Rows(i).ErrorText = "La cantidad debe ser positiva y mayor que cero"
                MsgBox("La cantidad debe ser positiva y mayor que cero", MsgBoxStyle.Exclamation, "A.P.U.")
                Exit Function
            End If
        Next
        ValidarMateriales = True
    End Function


    ''' <summary>
    ''' Comprueba que los datos ingresados en la rejilla de Maquinaria y Equipo sean válidos.
    ''' </summary>
    ''' <returns>
    ''' Verdadero si todos los datos de todas las filas de Maquinaria y Equipo son válidos.
    ''' Falso si algún dato de alguna fila es erróneo.
    ''' </returns>
    Private Function ValidarEquipos() As Boolean
        EliminarFilasVacias(Dgv_MaquinariaEquipo)
        For i As Integer = 0 To Dgv_MaquinariaEquipo.RowCount - 2
            If IsDBNull(Dgv_MaquinariaEquipo.Rows(i).Cells(CantidadME.Name).Value) OrElse Trim(Dgv_MaquinariaEquipo.Rows(i).Cells(CantidadME.Name).Value) = "" Then
                Tc_Recursos.SelectedTab = Tp_MaquinariaEquipo 'Cambiar a pestaña de maquinaria y equipo
                ValidarEquipos = False
                Dgv_MaquinariaEquipo.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                Dgv_MaquinariaEquipo.Rows(i).ErrorText = "La cantidad debe ser positiva y mayor que cero"
                MsgBox("La cantidad debe ser positiva y mayor que cero", MsgBoxStyle.Exclamation, "A.P.U.")
                Exit Function
            End If
        Next
        ValidarEquipos = True
    End Function


    ''' <summary>
    ''' Comprueba que los datos ingresados en la rejilla de Mano de Obra sean válidos.
    ''' </summary>
    ''' <returns>
    ''' Verdadero si todos los datos de todas las filas de Mano de Obra son válidos.
    ''' Falso si algún dato de alguna fila es erróneo.
    ''' </returns>
    Private Function ValidarManoDeObra() As Boolean
        EliminarFilasVacias(Dgv_ManoDeObra)
        For i As Integer = 0 To Dgv_ManoDeObra.RowCount - 2
            If IsDBNull(Dgv_ManoDeObra.Rows(i).Cells(CantidadMO.Name).Value) OrElse Trim(Dgv_ManoDeObra.Rows(i).Cells(CantidadMO.Name).Value) = "" Then
                Tc_Recursos.SelectedTab = Tp_ManoDeObra 'Cambiar a pestaña de mano de obra
                ValidarManoDeObra = False
                Dgv_ManoDeObra.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                Dgv_ManoDeObra.Rows(i).ErrorText = "La cantidad debe ser positiva y mayor que cero"
                MsgBox("La cantidad debe ser positiva y mayor que cero", MsgBoxStyle.Exclamation, "A.P.U.")
                Exit Function
            End If
        Next
        ValidarManoDeObra = True
    End Function


    ''' <summary>
    ''' Invoca el procedimiento almacenado de guardado del Ítem A.P.U. en la base de datos.
    ''' Adecúa las tablas de recursos quitando las columnas que no aceptan los tipos de tabla en la base de datos antes de enviárlas como parámetros al procedimiento almacenado.
    ''' </summary>
    Private Sub GuardarAPU()
        CalcularValoresItem()
        Dim dtMateriales As New DataTable
        Dim dtMaquinariaEquipo As New DataTable
        Dim dtManoDeObra As New DataTable

        'Copia de las tablas fuente de las rejillas para ajustarlas a las tablas parámetro del procedimiento de guardado.
        If Not IsNothing(Dgv_Material.DataSource) Then
            Dgv_Material.DataSource.AcceptChanges()
            dtMateriales = Dgv_Material.DataSource.Copy()
            dtMateriales.Columns.Remove("ABREVIATURA")
            dtMateriales.Columns.Remove("NOMBREDESCRIPTIVO")
            dtMateriales.Columns.Remove("SUBTOTAL")
        End If
        If Not IsNothing(Dgv_MaquinariaEquipo.DataSource) Then
            Dgv_MaquinariaEquipo.DataSource.AcceptChanges()
            dtMaquinariaEquipo = Dgv_MaquinariaEquipo.DataSource.Copy()
            dtMaquinariaEquipo.Columns.Remove("NOMBREDESCRIPTIVO")
            dtMaquinariaEquipo.Columns.Remove("SUBTOTAL")
        End If
        If Not IsNothing(Dgv_ManoDeObra.DataSource) Then
            Dgv_ManoDeObra.DataSource.AcceptChanges()
            dtManoDeObra = Dgv_ManoDeObra.DataSource.Copy()
            dtManoDeObra.Columns.Remove("SUBTOTAL")
        End If

        'Marcado de las casillas de la columna "EsIsmocol" que pueden haber quedado con valor nulo antes del guardado.
        For i As Integer = 0 To dtMateriales.Rows.Count - 1
            If IsDBNull(dtMateriales.Rows(i).Item("ESISMOCOL")) Then
                dtMateriales.Rows(i).Item("ESISMOCOL") = "S"
            End If
        Next
        For i As Integer = 0 To dtMaquinariaEquipo.Rows.Count - 1
            If IsDBNull(dtMaquinariaEquipo.Rows(i).Item("ESISMOCOL")) Then
                dtMaquinariaEquipo.Rows(i).Item("ESISMOCOL") = "S"
            End If
        Next

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLIC_APU", conexion)
        comando.CommandType = CommandType.StoredProcedure
        If Edicion = TipoEdicion.Editar Then
            comando.Parameters.AddWithValue("@TIPO", 2)
        Else 'Nuevo, Clonar
            comando.Parameters.AddWithValue("@TIPO", 1)
        End If
        comando.Parameters.AddWithValue("@Tabla_APU_Material", dtMateriales)
        comando.Parameters.AddWithValue("@Tabla_APU_MaquinariaYEquipo", dtMaquinariaEquipo)
        comando.Parameters.AddWithValue("@Tabla_APU_ManoDeObra", dtManoDeObra)
        If Edicion = TipoEdicion.Editar Then
            comando.Parameters.AddWithValue("@IDAPU", IdAPU)
        Else 'Nuevo, Clonar
            comando.Parameters.AddWithValue("@IDAPU", DBNull.Value)
        End If
        comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        comando.Parameters.AddWithValue("@NROITEMLICITACION", Trim(Tx_NroItemLicitacion.Text))
        comando.Parameters.AddWithValue("@NROITEMCLIENTE", Trim(Tx_NroItemCliente.Text))
        comando.Parameters.AddWithValue("@DESCRIPCION", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Descripcion.Text))
        If Not Ck_EsCapitulo.Checked Then
            comando.Parameters.AddWithValue("@ESCAPITULO", "N")
            comando.Parameters.AddWithValue("@CODIGOTIPOUNIDAD", Cb_TipoUnidad.SelectedValue)
            comando.Parameters.AddWithValue("@CANTIDADESTIMADA", Valor(Tx_Cantidad))
            comando.Parameters.AddWithValue("@VALORTOTALITEMSINAIU", valorActualSinAIU) 'FuncionesBase.FuncionesBase.ValorRealDec(Lb_ResultadoVUsinAIU.Text)
            comando.Parameters.AddWithValue("@VALORTOTALITEMCONAIU", valorActualConAIU) 'FuncionesBase.FuncionesBase.ValorRealDec(Lb_ResultadoVUconAIU.Text)
            Dim thorashombre As Decimal = FuncionesBase.FuncionesBase.ValorRealDec(Lb_TotalHorasHombre.Text)
            comando.Parameters.AddWithValue("@TOTALHORASHOMBRE", If(thorashombre > 0, thorashombre, 0))
            Dim rendimiento As Decimal = Valor(Tx_RendimHoraxUnd)
            comando.Parameters.AddWithValue("@RENDIMIENTO", If(rendimiento > 0, rendimiento, 0)) 'Solo se guarda la expresión del rendimiento en Horas por Unidad (consumo).
        Else
            comando.Parameters.AddWithValue("@ESCAPITULO", "S")
            dtMateriales.Clear()
            dtMaquinariaEquipo.Clear()
            dtManoDeObra.Clear()
            comando.Parameters.AddWithValue("@CODIGOTIPOUNIDAD", DBNull.Value)
            comando.Parameters.AddWithValue("@CANTIDADESTIMADA", DBNull.Value)
            comando.Parameters.AddWithValue("@VALORTOTALITEMSINAIU", DBNull.Value)
            comando.Parameters.AddWithValue("@VALORTOTALITEMCONAIU", DBNull.Value)
            comando.Parameters.AddWithValue("@TOTALHORASHOMBRE", DBNull.Value)
            comando.Parameters.AddWithValue("@RENDIMIENTO", DBNull.Value)
        End If
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
            If Not IsDBNull(msgParam.Value) AndAlso msgParam.Value > 0 Then
                IdAPU = msgParam.Value
                Edicion = TipoEdicion.Editar
            End If
            MostrarEstado("Datos guardados correctamente.")
            If Not Ck_EsCapitulo.Checked Then
                Bt_Imprimir.Enabled = True
            End If
            Ck_EsCapitulo.Enabled = False
            'Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="mensaje"></param>
    Private Sub MostrarEstado(mensaje As String)
        Lb_BarraEstado.Text = mensaje
        Lb_BarraEstado.Visible = True
        Tm_BarraEstado.Start()
    End Sub


    ' 
    Private Sub Tm_BarraEstado_Tick(sender As Object, e As EventArgs) Handles Tm_BarraEstado.Tick
        Lb_BarraEstado.Visible = False
    End Sub


    ' Cierre del formulario de Ítem A.P.U.
    Private Sub Bt_Cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_Cancelar.Click
        Close()
    End Sub


    ' Activa o desactiva los controles del formulario dependiendo de si se gestiona un ítem o un capítulo.
    Private Sub Ck_EsCapitulo_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_EsCapitulo.CheckedChanged
        If Ck_EsCapitulo.Checked Then
            Tx_Cantidad.Enabled = False
            Cb_TipoUnidad.Enabled = False
            Tx_RendimUndxHora.Enabled = False
            Tx_RendimUndxDia.Enabled = False
            Tx_RendimDias.Enabled = False
            Tx_RendimHoraxUnd.Enabled = False
            If Not IsNothing(Dgv_MaquinariaEquipo.DataSource) Then
                dtMaquinariaEquipoAPU = Dgv_MaquinariaEquipo.DataSource.Copy()
                Dgv_MaquinariaEquipo.DataSource.Clear()
            End If
            Dgv_MaquinariaEquipo.ReadOnly = True
            Dgv_MaquinariaEquipo.Enabled = False
            Dgv_MaquinariaEquipo.AllowUserToAddRows = False
            If Not IsNothing(Dgv_Material.DataSource) Then
                dtMaterialesAPU = Dgv_Material.DataSource.Copy()
                Dgv_Material.DataSource.Clear()
            End If
            Dgv_Material.ReadOnly = True
            Dgv_Material.Enabled = False
            Dgv_Material.AllowUserToAddRows = False
            If Not IsNothing(Dgv_ManoDeObra.DataSource) Then
                dtManoDeObraAPU = Dgv_ManoDeObra.DataSource.Copy()
                Dgv_ManoDeObra.DataSource.Clear()
            End If
            Dgv_ManoDeObra.ReadOnly = True
            Dgv_ManoDeObra.Enabled = False
            Dgv_ManoDeObra.AllowUserToAddRows = False
            Flp_ResultadosAPU.Visible = False
        Else
            Tx_Cantidad.Enabled = True
            Cb_TipoUnidad.Enabled = True
            Tx_RendimUndxHora.Enabled = True
            Tx_RendimUndxDia.Enabled = True
            Tx_RendimDias.Enabled = True
            Tx_RendimHoraxUnd.Enabled = True
            Dgv_MaquinariaEquipo.DataSource = dtMaquinariaEquipoAPU
            Dgv_MaquinariaEquipo.ReadOnly = False
            Dgv_MaquinariaEquipo.Enabled = True
            Dgv_MaquinariaEquipo.AllowUserToAddRows = True
            Dgv_Material.DataSource = dtMaterialesAPU
            Dgv_Material.ReadOnly = False
            Dgv_Material.Enabled = True
            Dgv_Material.AllowUserToAddRows = True
            Dgv_ManoDeObra.DataSource = dtManoDeObraAPU
            Dgv_ManoDeObra.ReadOnly = False
            Dgv_ManoDeObra.Enabled = True
            Dgv_ManoDeObra.AllowUserToAddRows = True
            Flp_ResultadosAPU.Visible = True
        End If
    End Sub


    ' Abre el cuadro de dialogo de impresión del ítem A.P.U.
    Private Sub Bt_Imprimir_Click(sender As Object, e As EventArgs) Handles Bt_Imprimir.Click

    End Sub


    ' Abre el cuadro de herramientas de licitaciones.
    Private Sub Bt_Herramientas_Click(sender As Object, e As EventArgs) Handles Bt_Herramientas.Click
        'System.Diagnostics.Process.Start("Calc")
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cajaTexto"></param>
    ''' <returns></returns>
    Private Function Valor(cajaTexto As TextBox) As Decimal
        Return FuncionesBase.FuncionesBase.ValorRealDec(cajaTexto.Text)
    End Function


    Private Function FormatoDecimal(numero As Decimal) As String
        Return numero.ToString("N4", System.Globalization.NumberFormatInfo.CurrentInfo)
    End Function

End Class 'Fr_APU



''' <summary>
''' 
''' </summary>
Class Fr_RecursosAsociados
    Inherits Form

    Private Tc_RecursosAsociados As TabControl
    Private Tp_Materiales As TabPage
    Private Tp_ManoDeObra As TabPage
    Private WithEvents Dgv_Materiales As DataGridView
    Private WithEvents Dgv_ManoDeObra As DataGridView
    Private Flp_Botones As FlowLayoutPanel
    Private WithEvents Bt_Insertar As Button
    Private WithEvents Bt_Cerrar As Button

    ''' <summary>
    ''' Identificador del recurso que se inserta en el formulario padre.
    ''' </summary>
    Private idRecurso As Integer = -1

    ''' <summary>
    ''' 
    ''' </summary>
    Private _frPadre As Object

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property FrPadre As Object
        Private Get
            Return _frPadre
        End Get
        Set(value As Object)
            _frPadre = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    Private dtMateriales As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    Private dtManoObra As DataTable


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dtMa_Asoc"></param>
    ''' <param name="dtMO_Asoc"></param>
    Public Sub New(dtMa_Asoc As DataTable, dtMO_Asoc As DataTable)
        Tc_RecursosAsociados = New TabControl
        Tp_Materiales = New TabPage
        Tp_ManoDeObra = New TabPage
        Tc_RecursosAsociados.TabPages.Add(Tp_Materiales)
        Tc_RecursosAsociados.TabPages.Add(Tp_ManoDeObra)
        Dgv_Materiales = New DataGridView
        Dgv_ManoDeObra = New DataGridView
        Flp_Botones = New FlowLayoutPanel
        Bt_Insertar = New Button
        Bt_Cerrar = New Button
        dtMateriales = dtMa_Asoc
        dtManoObra = dtMO_Asoc

        With Dgv_Materiales
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .Dock = DockStyle.Fill
            .MultiSelect = False
            .ReadOnly = True
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        With Dgv_ManoDeObra
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .Dock = DockStyle.Fill
            .MultiSelect = False
            .ReadOnly = True
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        With Tp_Materiales
            .Text = "Materiales"
            .Controls.Add(Dgv_Materiales)
        End With
        With Tp_ManoDeObra
            .Text = "Mano de Obra"
            .Controls.Add(Dgv_ManoDeObra)
        End With
        With Tc_RecursosAsociados
            .Dock = DockStyle.Fill
        End With
        With Bt_Insertar
            .UseVisualStyleBackColor = True
            .Text = "Insertar"
        End With
        With Bt_Cerrar
            .UseVisualStyleBackColor = True
            .Text = "Cerrar"
        End With
        With Flp_Botones
            .BackColor = Color.Silver
            .Dock = DockStyle.Bottom
            .FlowDirection = FlowDirection.RightToLeft
            .Height = 30
            .Controls.Add(Bt_Cerrar)
            .Controls.Add(Bt_Insertar)
        End With
        With Me
            .FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New Size(640, 400)
            .StartPosition = FormStartPosition.CenterParent
            .Text = "Agregar Recursos Asociados"
            .Controls.Add(Tc_RecursosAsociados)
            .Controls.Add(Flp_Botones)
        End With
    End Sub


    ' 
    Private Sub Fr_RecursosAsociados_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dgv_Materiales.DataSource = dtMateriales
        Dgv_ManoDeObra.DataSource = dtManoObra

        For i As Integer = 0 To Dgv_Materiales.ColumnCount - 1
            Select Case Dgv_Materiales.Columns(i).Name
                Case "ABREVIATURA"
                    Dgv_Materiales.Columns(i).FillWeight = 50
                    Dgv_Materiales.Columns(i).HeaderText = "Unidad"
                Case "CANTIDAD"
                    Dgv_Materiales.Columns(i).FillWeight = 50
                    Dgv_Materiales.Columns(i).HeaderText = "Cantidad"
                Case "DESCRIPCION"
                    Dgv_Materiales.Columns(i).FillWeight = 200
                    Dgv_Materiales.Columns(i).HeaderText = "Descripción"
                Case "NOMBREDESCRIPTIVO"
                    Dgv_Materiales.Columns(i).FillWeight = 200
                    Dgv_Materiales.Columns(i).HeaderText = "Artículo"
                Case Else
                    'IDMATERIAL, FECHAREGISTRO, IDUSUARIOREGISTRO, FECHAMODIFICACION, IDUSUARIOMODIFICA, ACTIVO
                    Dgv_Materiales.Columns(i).Visible = False
            End Select
        Next
        For j As Integer = 0 To Dgv_ManoDeObra.ColumnCount - 1
            Select Case Dgv_ManoDeObra.Columns(j).Name
                Case "CANTIDAD"
                    Dgv_ManoDeObra.Columns(j).FillWeight = 50
                    Dgv_ManoDeObra.Columns(j).HeaderText = "Cantidad"
                Case "DESCRIPCION"
                    Dgv_ManoDeObra.Columns(j).FillWeight = 200
                    Dgv_ManoDeObra.Columns(j).HeaderText = "Descripción"
                Case Else
                    'IDMANODEOBRA, FECHAREGISTRO, IDUSUARIOREGISTRO, FECHAMODIFICACION, IDUSUARIOMODIFICA, ACTIVO
                    Dgv_ManoDeObra.Columns(j).Visible = False
            End Select
        Next
    End Sub


    ''' <summary>
    ''' Asignación de estilos a las celdas de la rejilla.
    ''' </summary>
    Public Sub Comportamiento_Predeterminado()
        Dgv_Materiales.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Materiales.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_ManoDeObra.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_ManoDeObra.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub


    ''' <summary>
    ''' Pasa el identificador del recurso seleccionado mediante la función de agregar recurso implementada en el formulario padre que lo agrega a la respectiva rejilla de recursos.
    ''' </summary>
    Private Sub InsertarRecurso()
        If (Tc_RecursosAsociados.SelectedTab.Text = Tp_Materiales.Text AndAlso Dgv_Materiales.SelectedRows.Count > 0) OrElse _
            (Tc_RecursosAsociados.SelectedTab.Text = Tp_ManoDeObra.Text AndAlso Dgv_ManoDeObra.SelectedRows.Count > 0) Then

            Dim recurso As TipoRecurso
            Dim cantidad As Decimal = 0

            Select Case Tc_RecursosAsociados.SelectedTab.Text
                Case Tp_Materiales.Text
                    idRecurso = Dgv_Materiales.SelectedRows(0).Cells("IDMATERIAL").Value
                    cantidad = Dgv_Materiales.SelectedRows(0).Cells("CANTIDAD").Value
                    Dgv_Materiales.Rows.RemoveAt(Dgv_Materiales.SelectedRows(0).Index)
                    dtMateriales.AcceptChanges()
                    recurso = TipoRecurso.Material
                Case Tp_ManoDeObra.Text
                    idRecurso = Dgv_ManoDeObra.SelectedRows(0).Cells("IDMANODEOBRA").Value
                    cantidad = Dgv_ManoDeObra.SelectedRows(0).Cells("CANTIDAD").Value
                    Dgv_ManoDeObra.Rows.RemoveAt(Dgv_ManoDeObra.SelectedRows(0).Index)
                    dtManoObra.AcceptChanges()
                    recurso = TipoRecurso.ManoDeObra
            End Select

            FrPadre.AgregarRecurso(idRecurso, recurso, -1, cantidad)
        End If
    End Sub


    ' Llama a la función para insertar recurso al hacer doble clic sobre el recurso seleccionado.
    Private Sub Dgv_RecursosAsociados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Materiales.CellDoubleClick, Dgv_ManoDeObra.CellDoubleClick
        InsertarRecurso()
    End Sub


    ' Llama a la función para insertar el recurso seleccionado al presionar el botón Insertar.
    Private Sub Bt_Insertar_Click(sender As Object, e As EventArgs) Handles Bt_Insertar.Click
        InsertarRecurso()
    End Sub


    ' Cierre del formulario.
    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Close()
    End Sub

End Class