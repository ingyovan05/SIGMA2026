Imports FormularioLicitaciones.FormulariosLicitaciones
Imports System.Data.SqlClient
Imports Articulos

''' <summary>
''' 
''' </summary>
Public Class Fr_MaquinariaEquipo
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property IdMaquinariaEquipo As Integer = -1

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property Edicion As TipoEdicion

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property EditandoDesdeLicitacion As Boolean

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ReadOnly Property TarifaIsmocolxHora As Decimal
        Get
            Return CuTx_TarifaIsmocol.Valor
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ReadOnly Property TarifaComercialxHora As Decimal
        Get
            Return CuTx_TarifaComercial.Valor
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    Private dgvActual As DataGridView

    ''' <summary>
    ''' 
    ''' </summary>
    Private valorAnterior As String = ""

    ''' <summary>
    ''' 
    ''' </summary>
    Private Estilo_Celda_Error As New DataGridViewCellStyle


    ' 
    Private Sub Fr_MaquinariaEquipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Comportamiento_Predeterminado()
        If Edicion = TipoEdicion.Editar OrElse Edicion = TipoEdicion.Ver OrElse Edicion = TipoEdicion.Clonar Then
            CargarMaquinariaEquipo()
        Else 'Nuevo
            CargarTablas()
        End If
        If Edicion = TipoEdicion.Ver Then
            Tx_Codigo.ReadOnly = True
            Tx_IdArticulo.ReadOnly = True
            Bt_BuscarArticulo.Enabled = False
            Tx_Descripcion.ReadOnly = True
            CuTx_Combustible.SoloLectura = True
            CuTx_TarifaIsmocol.SoloLectura = True
            CuTx_TarifaComercial.SoloLectura = True
            Ck_Activo.Enabled = False
            Dgv_Material.ReadOnly = True
            Dgv_Material.AllowUserToAddRows = False
            Dgv_Material.AllowUserToDeleteRows = False
            Dgv_ManoDeObra.ReadOnly = True
            Dgv_ManoDeObra.AllowUserToAddRows = False
            Dgv_ManoDeObra.AllowUserToDeleteRows = False
            Bt_Guardar.Enabled = False
            Bt_Cancelar.Select()
        Else 'Editar, Clonar, Nuevo
            FuncionesBase.FuncionesBase.EnfocarCajaTexto(Tx_Descripcion)
        End If
        Tx_Descripcion.Select()
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub Comportamiento_Predeterminado()
        Dgv_Material.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Material.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Dgv_ManoDeObra.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_ManoDeObra.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Estilo_Celda_Error.BackColor = Color.Red

        CuTx_TarifaIsmocol.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(CuTx_TarifaIsmocol.Tag)
        CuTx_TarifaComercial.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(CuTx_TarifaComercial.Tag)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CargarMaquinariaEquipo()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM LIC_DatosMaquinariaYEquipo(@TIPO, @IDMAQUINARIAYEQUIPO, @IDLICITACION)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 0) 'Cualquier Maquinaria y Equipo (Activa o Inactiva)
        comando.Parameters.AddWithValue("@IDMAQUINARIAYEQUIPO", IdMaquinariaEquipo)
        comando.Parameters.AddWithValue("@IDLICITACION", DBNull.Value)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtMaquinariaEquipo As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtMaquinariaEquipo, SchemaType.Source)
            adaptador.Fill(dtMaquinariaEquipo)
            conexion.Close()

            'Asignaciones
            Tx_Codigo.Text = dtMaquinariaEquipo.Rows(0).Item("IDMAQUINARIAYEQUIPO")
            If Not IsDBNull(dtMaquinariaEquipo.Rows(0).Item("IDARTICULO")) Then
                Tx_IdArticulo.Text = dtMaquinariaEquipo.Rows(0).Item("IDARTICULO")
            Else
                Tx_IdArticulo.Text = ""
            End If
            Tx_Descripcion.Text = dtMaquinariaEquipo.Rows(0).Item("DESCRIPCION")
            CuTx_Combustible.Valor = dtMaquinariaEquipo.Rows(0).Item("COMBUSTIBLEXHORA")
            If Not IsDBNull(dtMaquinariaEquipo.Rows(0).Item("TARIFAISMOCOLXHORA")) Then
                CuTx_TarifaIsmocol.Valor = dtMaquinariaEquipo.Rows(0).Item("TARIFAISMOCOLXHORA")
            Else
                CuTx_TarifaIsmocol.Valor = 0
            End If
            If Not IsDBNull(dtMaquinariaEquipo.Rows(0).Item("TARIFACOMERCIALXHORA")) Then
                CuTx_TarifaComercial.Valor = dtMaquinariaEquipo.Rows(0).Item("TARIFACOMERCIALXHORA")
            Else
                CuTx_TarifaComercial.Valor = 0
            End If
            Ck_Activo.ThreeState = False
            If dtMaquinariaEquipo.Rows(0).Item("ACTIVO") = "S" Then
                Ck_Activo.Checked = True
                Ck_Activo.CheckState = CheckState.Checked
            ElseIf dtMaquinariaEquipo.Rows(0).Item("ACTIVO") = "N" Then
                Ck_Activo.Checked = False
                Ck_Activo.CheckState = CheckState.Unchecked
            Else
                Ck_Activo.Checked = False
                Ck_Activo.CheckState = CheckState.Indeterminate
            End If
            CargarTablas()
            If Edicion = TipoEdicion.Clonar Then
                IdMaquinariaEquipo = -1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CargarTablas()
        CargarMaterialAsociado()
        CargarManoDeObraAsociada()
        Tc_Recursos.SelectedTab = Tp_Material
        dgvActual = Dgv_Material
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CargarMaterialAsociado()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM LIC_ListaMaterialAsociado(@IDMAQUINARIAYEQUIPO)", conexion)
        comando.Parameters.AddWithValue("@IDMAQUINARIAYEQUIPO", IdMaquinariaEquipo)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtMaterialAsociado As New DataTable
        Try
            conexion.Open()
            'adaptador.FillSchema(dtMaterialAsociado, SchemaType.Mapped)
            adaptador.Fill(dtMaterialAsociado)
            conexion.Close()
            Dgv_Material.DataSource = dtMaterialAsociado
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CargarManoDeObraAsociada()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM LIC_ListaManoDeObraAsociado(@IDMAQUINARIAYEQUIPO)", conexion)
        comando.Parameters.AddWithValue("@IDMAQUINARIAYEQUIPO", IdMaquinariaEquipo)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtManoDeObraAsociada As New DataTable
        Try
            conexion.Open()
            'adaptador.FillSchema(dtManoDeObraAsociada, SchemaType.Mapped)
            adaptador.Fill(dtManoDeObraAsociada)
            conexion.Close()
            Dgv_ManoDeObra.DataSource = dtManoDeObraAsociada
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ' 
    Private Sub Dgv_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Dgv_Material.KeyDown, Dgv_ManoDeObra.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Using frBuscarRecurso As New Fr_BuscarRecurso
                    frBuscarRecurso.FrPadre = Me
                    Select Case sender.name
                        Case Dgv_Material.Name
                            frBuscarRecurso.Recurso = TipoRecurso.Material
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
    End Sub


    ' 
    Private Sub Dgv_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles Dgv_Material.CellBeginEdit, Dgv_ManoDeObra.CellBeginEdit
        If Not IsNothing(sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            valorAnterior = sender.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString
        End If
    End Sub


    ' 
    Private Sub Dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Dgv_Material.DataError, Dgv_ManoDeObra.DataError

    End Sub


    ' 
    Private Sub Dgv_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Dgv_Material.CellEndEdit, Dgv_ManoDeObra.CellEndEdit
        Select Case sender.Name
            Case Dgv_Material.Name
                If e.ColumnIndex = sender.Columns("IdMaterial").Index Then
                    If Not IsDBNull(sender.Rows(e.RowIndex).Cells("IdMaterial").Value) Then
                        AgregarRecurso(sender.Rows(e.RowIndex).Cells("IdMaterial").Value, TipoRecurso.Material, e.RowIndex)
                    Else
                        EliminarFilasVacias(sender)
                    End If
                End If
            Case Dgv_ManoDeObra.Name
                If e.ColumnIndex = sender.Columns("IdManoDeObra").Index Then
                    If Not IsDBNull(sender.Rows(e.RowIndex).Cells("IdManoDeObra").Value) Then
                        AgregarRecurso(sender.Rows(e.RowIndex).Cells("IdManoDeObra").Value, TipoRecurso.ManoDeObra, e.RowIndex)
                    Else
                        EliminarFilasVacias(sender)
                    End If
                End If
        End Select
        valorAnterior = ""
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="codigoRecurso"></param>
    ''' <param name="tipoRecurso"></param>
    ''' <param name="rowIndex"></param>
    Public Sub AgregarRecurso(ByVal codigoRecurso As Integer, ByVal tipoRecurso As TipoRecurso, Optional ByVal rowIndex As Integer = -1)
        'Consultar en DB
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand()
        Select Case tipoRecurso
            Case tipoRecurso.Material
                comando.CommandText = "SELECT * FROM dbo.LIC_DatosMaterial(@TIPO, @IDMATERIAL, @IDLICITACION)"
                comando.Parameters.AddWithValue("@IDMATERIAL", codigoRecurso)
            Case tipoRecurso.ManoDeObra
                comando.CommandText = "SELECT * FROM dbo.LIC_DatosManoDeObra(@TIPO, @IDMANODEOBRA, @IDLICITACION)"
                comando.Parameters.AddWithValue("@IDMANODEOBRA", codigoRecurso)
        End Select
        comando.Parameters.AddWithValue("@TIPO", 1) 'Recursos activos.
        comando.Parameters.AddWithValue("@IDLICITACION", DBNull.Value)
        comando.Connection = conexion
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtRecurso As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtRecurso, SchemaType.Source)
            adaptador.Fill(dtRecurso)
            conexion.Close()
            If dtRecurso.Rows.Count < 1 Then
                dgvActual.CancelEdit()
                EliminarFilasVacias(dgvActual)
                Exit Sub
            End If
            For i As Integer = 0 To dtRecurso.Columns.Count - 1
                If dtRecurso.Columns(i).ColumnName = "FECHAREGISTRO" Then
                    dtRecurso.Rows(0).Item(i) = DateTime.Now
                ElseIf dtRecurso.Columns(i).ColumnName = "IDUSUARIOREGISTRO" Then
                    dtRecurso.Rows(0).Item(i) = VariablesBase.VariablesBase.IdPersona
                End If
            Next
            If ValidarFilaRecurso(dgvActual, dtRecurso.Rows(0)) Then
                EliminarFilasVacias(dgvActual)
                If dgvActual.Rows.Count - 1 > 0 AndAlso rowIndex >= 0 AndAlso rowIndex < dgvActual.Rows.Count - 1 Then
                    dgvActual.Rows.RemoveAt(rowIndex)
                    Dim drRecurso As DataRow = dgvActual.DataSource.NewRow()
                    Select Case tipoRecurso
                        Case tipoRecurso.Material
                            drRecurso.Item("IDMATERIAL") = dtRecurso.Rows(0).Item("IDMATERIAL")
                            drRecurso.Item("DESCRIPCION") = dtRecurso.Rows(0).Item("DESCRIPCION")
                            drRecurso.Item("ABREVIATURA") = dtRecurso.Rows(0).Item("ABREVIATURA")
                            drRecurso.Item("NOMBREDESCRIPTIVO") = dtRecurso.Rows(0).Item("NOMBREDESCRIPTIVO")
                            drRecurso.Item("FECHAREGISTRO") = dtRecurso.Rows(0).Item("FECHAREGISTRO")
                            drRecurso.Item("IDUSUARIOREGISTRO") = dtRecurso.Rows(0).Item("IDUSUARIOREGISTRO")
                            drRecurso.Item("FECHAMODIFICACION") = dtRecurso.Rows(0).Item("FECHAMODIFICACION")
                            drRecurso.Item("IDUSUARIOMODIFICA") = dtRecurso.Rows(0).Item("IDUSUARIOMODIFICA")
                        Case tipoRecurso.ManoDeObra
                            drRecurso.Item("IDMANODEOBRA") = dtRecurso.Rows(0).Item("IDMANODEOBRA")
                            drRecurso.Item("DESCRIPCION") = dtRecurso.Rows(0).Item("DESCRIPCION")
                            drRecurso.Item("FECHAREGISTRO") = dtRecurso.Rows(0).Item("FECHAREGISTRO")
                            drRecurso.Item("IDUSUARIOREGISTRO") = dtRecurso.Rows(0).Item("IDUSUARIOREGISTRO")
                            drRecurso.Item("FECHAMODIFICACION") = dtRecurso.Rows(0).Item("FECHAMODIFICACION")
                            drRecurso.Item("IDUSUARIOMODIFICA") = dtRecurso.Rows(0).Item("IDUSUARIOMODIFICA")
                    End Select
                    dgvActual.DataSource.Rows.InsertAt(drRecurso, rowIndex)
                    dgvActual.DataSource.AcceptChanges()
                    'NumerarFilas(dgvActual, rowIndex)
                Else
                    dgvActual.DataSource.ImportRow(dtRecurso.Rows(0))
                    dgvActual.DataSource.AcceptChanges()
                    'NumerarFilas(dgvActual, dgvActual.DataSource.Rows.Count - 1)
                End If
            Else
                dgvActual.CancelEdit()
            End If
            EliminarFilasVacias(dgvActual)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dgvActual"></param>
    ''' <param name="drFila"></param>
    ''' <returns></returns>
    Private Function ValidarFilaRecurso(ByVal dgvActual As DataGridView, ByVal drFila As DataRow) As Boolean
        Dim filas As DataRow()
        Select Case dgvActual.Name
            Case Dgv_Material.Name
                filas = dgvActual.DataSource.Select("[" & "IDMATERIAL" & "]='" & drFila.Item("IDMATERIAL") & "'")
            Case Dgv_ManoDeObra.Name
                filas = dgvActual.DataSource.Select("[" & "IDMANODEOBRA" & "]='" & drFila.Item("IDMANODEOBRA") & "'")
            Case Else
                filas = Nothing
        End Select
        If filas.Length > 0 Then
            ValidarFilaRecurso = False
            Exit Function
        End If
        ValidarFilaRecurso = True
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dgvActual"></param>
    Private Sub EliminarFilasVacias(ByVal dgvActual As DataGridView)
        'If dgvActual.DataSource.Rows.Count > 0 Then
        Select Case dgvActual.Name
            Case Dgv_Material.Name
                For i As Integer = dgvActual.RowCount - 2 To 0 Step -1
                    If (IsDBNull(dgvActual.Rows(i).Cells("IdMaterial").Value) OrElse Trim(dgvActual.Rows(i).Cells("IdMaterial").Value) = "") OrElse _
                        (IsDBNull(dgvActual.Rows(i).Cells("DescripcionMA").Value) OrElse Trim(dgvActual.Rows(i).Cells("DescripcionMA").Value) = "") Then
                        dgvActual.Rows.RemoveAt(i)
                    End If
                Next
            Case Dgv_ManoDeObra.Name
                For i As Integer = dgvActual.Rows.Count - 2 To 0 Step -1
                    If (IsDBNull(dgvActual.Rows(i).Cells("IdManoDeObra").Value) OrElse Trim(dgvActual.Rows(i).Cells("IdManoDeObra").Value) = "") OrElse _
                        (IsDBNull(dgvActual.Rows(i).Cells("DescripcionMO").Value) OrElse Trim(dgvActual.Rows(i).Cells("DescripcionMO").Value) = "") Then
                        dgvActual.Rows.RemoveAt(i)
                    End If
                Next
        End Select
        'End If
    End Sub


    ' 
    Private Sub Bt_BuscarArticulo_Click(sender As Object, e As EventArgs) Handles Bt_BuscarArticulo.Click
        Dim idArticulo As Integer = -1
        Using frBuscarArticulo As New Fr_BuscarArtículo
            frBuscarArticulo.Familia = "EQUIPO CAPITAL Y EQUIPOS DE LA COMPAÑÍA"
            frBuscarArticulo._Tipo = "T"
            frBuscarArticulo.Cargar_Tabla("T")
            frBuscarArticulo.ShowDialog()
            idArticulo = frBuscarArticulo.IdArtículo
        End Using
        If idArticulo > 0 Then
            CargarDatosArticulo(idArticulo)
        End If
    End Sub


    ' 
    Private Sub Tx_IdArticulo_LostFocus(sender As Object, e As EventArgs) Handles Tx_IdArticulo.LostFocus
        If Tx_IdArticulo.Text.Length > 0 AndAlso FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_IdArticulo.Text) <> "" Then
            CargarDatosArticulo(Tx_IdArticulo.Text)
        End If
    End Sub


    ' 
    Private Sub Tx_IdArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_IdArticulo.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If Tx_IdArticulo.Text.Length > 0 AndAlso FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_IdArticulo.Text) <> "" Then
                    CargarDatosArticulo(Tx_IdArticulo.Text)
                End If
        End Select
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="idArticulo"></param>
    Private Sub CargarDatosArticulo(ByVal idArticulo As Integer)
        If Edicion <> TipoEdicion.Ver Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT * FROM dbo.DatosArticulo(@IDARTICULO)", conexion)
            comando.Parameters.AddWithValue("@IDARTICULO", idArticulo)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dtArticulos As New DataTable
            Try
                conexion.Open()
                adaptador.Fill(dtArticulos)
                conexion.Close()
                If dtArticulos.Rows.Count > 0 Then
                    Tx_IdArticulo.Text = idArticulo.ToString
                    Tx_Descripcion.Text = dtArticulos.Rows(0).Item("NOMBREDESCRIPTIVO")
                Else
                    Tx_IdArticulo.Text = ""
                    MsgBox("El código de artículo digitado no se encuentra disponible.", MsgBoxStyle.Exclamation, "Artículo de referencia")
                    Tx_IdArticulo.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conexion.Close()
            End Try
        End If
    End Sub


    ' 
    Private Sub Tc_Recursos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Tc_Recursos.SelectedIndexChanged
        Select Case Tc_Recursos.SelectedTab.Name
            Case Tp_Material.Name
                dgvActual = Dgv_Material
            Case Tp_ManoDeObra.Name
                dgvActual = Dgv_ManoDeObra
        End Select
    End Sub


    ' 
    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If ValidarMaquinariaEquipo() Then
            GuardarMaquinariaEquipo()
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Private Function ValidarMaquinariaEquipo() As Boolean
        If Tx_Descripcion.Text.Length <= 0 OrElse FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Descripcion.Text.Length) <= 0 Then
            ValidarMaquinariaEquipo = False
            MsgBox("La descripción de la Maquinaria y Equipo no debe estar vacía.", MsgBoxStyle.Exclamation, "Maquinaria y Equipo")
            Tx_Descripcion.Focus()
            Exit Function
        End If
        If CuTx_Combustible.Valor <= 0 Then
            ValidarMaquinariaEquipo = False
            MsgBox("La cantidad de Combustible no debe estar vacía.", MsgBoxStyle.Exclamation, "Maquinaria y Equipo")
            CuTx_Combustible.Focus()
            Exit Function
        End If
        If CuTx_TarifaIsmocol.Valor <= 0 AndAlso CuTx_TarifaComercial.Valor <= 0 Then
            ValidarMaquinariaEquipo = False
            MsgBox("Indique por lo menos uno de los valores de las tarifas Ismocol o Comercial.", MsgBoxStyle.Exclamation, "Maquinaria y Equipo")
            CuTx_TarifaIsmocol.Focus()
            Exit Function
        End If
        If Ck_Activo.CheckState = CheckState.Indeterminate Then
            ValidarMaquinariaEquipo = False
            MsgBox("Seleccione el estado de la Maquinaria y Equipo (Activo/Inactivo).", MsgBoxStyle.Exclamation, "Maquinaria y Equipo")
            Ck_Activo.Focus()
            Exit Function
        End If
        If Not ValidarMaterialAsociado() Then
            ValidarMaquinariaEquipo = False
            'Dgv_Material.Focus()
            Exit Function
        End If
        If Not ValidarManoDeObraAsociada() Then
            ValidarMaquinariaEquipo = False
            'Dgv_ManoDeObra.Focus()
            Exit Function
        End If
        ValidarMaquinariaEquipo = True
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Private Function ValidarMaterialAsociado() As Boolean
        EliminarFilasVacias(Dgv_Material)
        For i As Integer = 0 To Dgv_Material.RowCount - 2
            If IsDBNull(Dgv_Material.Rows(i).Cells("CantidadMA").Value) OrElse Trim(Dgv_Material.Rows(i).Cells("CantidadMA").Value) = "" Then
                Tc_Recursos.SelectedTab = Tp_Material 'Cambiar a pestaña de Materiales
                ValidarMaterialAsociado = False
                Dgv_Material.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                Dgv_Material.Rows(i).ErrorText = "La cantidad debe ser positiva y mayor que cero"
                MsgBox("La cantidad debe ser positiva y mayor que cero", MsgBoxStyle.Exclamation, "A.P.U.")
                Exit Function
            End If
        Next
        ValidarMaterialAsociado = True
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Private Function ValidarManoDeObraAsociada() As Boolean
        EliminarFilasVacias(Dgv_ManoDeObra)
        For i As Integer = 0 To Dgv_ManoDeObra.RowCount - 2
            If IsDBNull(Dgv_ManoDeObra.Rows(i).Cells("CantidadMO").Value) OrElse Trim(Dgv_ManoDeObra.Rows(i).Cells("CantidadMO").Value) = "" Then
                Tc_Recursos.SelectedTab = Tp_ManoDeObra 'Cambiar a pestaña de mano de obra
                ValidarManoDeObraAsociada = False
                Dgv_ManoDeObra.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                Dgv_ManoDeObra.Rows(i).ErrorText = "La cantidad debe ser positiva y mayor que cero"
                MsgBox("La cantidad debe ser positiva y mayor que cero", MsgBoxStyle.Exclamation, "A.P.U.")
                Exit Function
            End If
        Next
        ValidarManoDeObraAsociada = True
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub GuardarMaquinariaEquipo()
        Dim idLicitacion As Integer = -1
        Dim actualizarMaestra As Boolean = True

        If VariablesBase.VariablesBase.IdLicitacionCargada > 0 AndAlso VariablesBase.VariablesBase.PermisoLicitacionOtorgado = "E" Then
            If EditandoDesdeLicitacion Then
                If MsgBox("¿Desea actualizar los datos del recurso en la Tabla Maestra del recurso?", MsgBoxStyle.YesNo, "Actualizar Precio en la Tabla Maestra") = MsgBoxResult.Yes Then
                    actualizarMaestra = True
                Else
                    actualizarMaestra = False
                End If
            Else
                If MsgBox("¿Desea actualizar los datos del recurso en la Licitación seleccionada?", MsgBoxStyle.YesNo, "Actualizar Precio en la Licitación") = MsgBoxResult.Yes Then
                    idLicitacion = VariablesBase.VariablesBase.IdLicitacionCargada
                End If
            End If
        End If

        Dim dtMaterialAsociado As New DataTable
        dtMaterialAsociado = Dgv_Material.DataSource.Copy()
        Dim dtManoDeObraAsociada As New DataTable
        dtManoDeObraAsociada = Dgv_ManoDeObra.DataSource.Copy()

        dtMaterialAsociado.Columns.Remove("DESCRIPCION")
        dtMaterialAsociado.Columns.Remove("ABREVIATURA")
        dtMaterialAsociado.Columns.Remove("NOMBREDESCRIPTIVO")
        dtManoDeObraAsociada.Columns.Remove("DESCRIPCION")

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLIC_MaquinariaYEquipo", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@TIPO", SqlDbType.TinyInt)
        comando.Parameters.Add("@IDMAQUINARIAYEQUIPO", SqlDbType.Int)
        Select Case Edicion
            Case TipoEdicion.Editar
                comando.Parameters("@TIPO").Value = 2
                comando.Parameters("@IDMAQUINARIAYEQUIPO").Value = IdMaquinariaEquipo
            Case Else
                'Crear, Clonar
                comando.Parameters("@TIPO").Value = 1
                comando.Parameters("@IDMAQUINARIAYEQUIPO").Value = DBNull.Value
        End Select
        comando.Parameters.AddWithValue("Tabla_MaquinariaYEquipo_Material", dtMaterialAsociado)
        comando.Parameters.AddWithValue("Tabla_MaquinariaYEquipo_ManoDeObra", dtManoDeObraAsociada)
        comando.Parameters.AddWithValue("@DESCRIPCION", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Descripcion.Text))
        If Trim(Tx_IdArticulo.Text) <> "" Then
            comando.Parameters.AddWithValue("@IDARTICULO", Trim(Tx_IdArticulo.Text))
        Else
            comando.Parameters.AddWithValue("@IDARTICULO", DBNull.Value)
        End If
        comando.Parameters.AddWithValue("@TARIFAISMOCOLXHORA", CuTx_TarifaIsmocol.Valor)
        comando.Parameters.AddWithValue("@TARIFACOMERCIALXHORA", CuTx_TarifaComercial.Valor)
        comando.Parameters.AddWithValue("@COMBUSTIBLEXHORA", CuTx_Combustible.Valor)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@ACTIVO", If(Ck_Activo.Checked, "S", "N"))
        comando.Parameters.AddWithValue("@IDLICITACION", idLicitacion)
        comando.Parameters.AddWithValue("@ACTUALIZARMAESTRA", If(actualizarMaestra, "S", "N"))
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.TinyInt)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
            If Not IsDBNull(msgParam.Value) AndAlso msgParam.Value > 0 Then
                IdMaquinariaEquipo = msgParam.Value
            End If
            MsgBox("Datos guardados correctamente.", MsgBoxStyle.Information, "Material")
            Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ' 
    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Close()
        DialogResult = DialogResult.Cancel
    End Sub

End Class 'Fr_MaquinariaEquipo