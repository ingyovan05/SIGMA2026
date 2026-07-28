Imports FormularioLicitaciones.FormulariosLicitaciones
Imports System.Data.SqlClient
Imports Articulos

''' <summary>
''' 
''' </summary>
Public Class Fr_Material
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property IdMaterial As Integer = -1

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
    ReadOnly Property ValorIsmocol As Decimal
        Get
            Return CuTx_ValorIsmocol.Valor
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ReadOnly Property ValorComercial As Decimal
        Get
            Return CuTx_ValorComercial.Valor
        End Get
    End Property


    ' 
    Private Sub Fr_Material_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Comportamiento_Predeterminado()
        CargarDatosComponentes()
        If Edicion = TipoEdicion.Editar OrElse Edicion = TipoEdicion.Ver OrElse Edicion = TipoEdicion.Clonar Then
            CargarMaterial()
        Else 'Nuevo
            CuTx_ValorComercial.Valor = 0
            CuTx_ValorIsmocol.Valor = 0
        End If
        If Edicion = TipoEdicion.Ver Then
            Tx_Codigo.ReadOnly = True
            Tx_IdArticulo.ReadOnly = True
            Bt_BuscarArticulo.Enabled = False
            Tx_Descripcion.ReadOnly = True
            Cb_TipoUnidad.Enabled = False
            CuTx_ValorIsmocol.SoloLectura = True
            CuTx_ValorComercial.SoloLectura = True
            Ck_Activo.Enabled = False
            Bt_Guardar.Enabled = False
            Bt_Cancelar.Select()
        Else 'Editar, Clonar, Nuevo
            FuncionesBase.FuncionesBase.EnfocarCajaTexto(Tx_Descripcion)
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub Comportamiento_Predeterminado()
        CuTx_ValorIsmocol.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(CuTx_ValorIsmocol.Tag)
        CuTx_ValorComercial.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(CuTx_ValorComercial.Tag)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CargarDatosComponentes()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListarTipoUnidad() ORDER BY [UNIDAD]", conexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtTipoUnidad As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtTipoUnidad, SchemaType.Source)
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
    ''' 
    ''' </summary>
    Private Sub CargarMaterial()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM LIC_DatosMaterial(@TIPO, @IDMATERIAL, @IDLICITACION)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 0) 'Cualquier Material (Activo o Inactivo)
        comando.Parameters.AddWithValue("@IDMATERIAL", IdMaterial)
        comando.Parameters.AddWithValue("@IDLICITACION", DBNull.Value)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtMaterial As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtMaterial, SchemaType.Source)
            adaptador.Fill(dtMaterial)
            conexion.Close()

            'Asignaciones
            Tx_Codigo.Text = dtMaterial.Rows(0).Item("IDMATERIAL")
            If Not IsDBNull(dtMaterial.Rows(0).Item("IDARTICULO")) Then
                Tx_IdArticulo.Text = dtMaterial.Rows(0).Item("IDARTICULO")
            Else
                Tx_IdArticulo.Text = ""
            End If
            Tx_Descripcion.Text = dtMaterial.Rows(0).Item("DESCRIPCION")
            Cb_TipoUnidad.SelectedValue = dtMaterial.Rows(0).Item("CODIGOTIPOUNIDAD")
            If Not IsDBNull(dtMaterial.Rows(0).Item("VALORISMOCOL")) Then
                CuTx_ValorIsmocol.Valor = dtMaterial.Rows(0).Item("VALORISMOCOL")
            Else
                CuTx_ValorIsmocol.Valor = 0
            End If
            If Not IsDBNull(dtMaterial.Rows(0).Item("VALORCOMERCIAL")) Then
                CuTx_ValorComercial.Valor = dtMaterial.Rows(0).Item("VALORCOMERCIAL")
            Else
                CuTx_ValorComercial.Valor = 0
            End If
            Ck_Activo.ThreeState = False
            If dtMaterial.Rows(0).Item("ACTIVO") = "S" Then
                Ck_Activo.Checked = True
                Ck_Activo.CheckState = CheckState.Checked
            ElseIf dtMaterial.Rows(0).Item("ACTIVO") = "N" Then
                Ck_Activo.Checked = False
                Ck_Activo.CheckState = CheckState.Unchecked
            Else
                Ck_Activo.Checked = False
                Ck_Activo.CheckState = CheckState.Indeterminate
            End If
            If Edicion = TipoEdicion.Clonar Then
                IdMaterial = -1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ' 
    Private Sub Bt_BuscarArticulo_Click(sender As Object, e As EventArgs) Handles Bt_BuscarArticulo.Click
        Dim idArticulo As Integer = -1
        Using frBuscarArticulo As New Fr_BuscarArtículo
            frBuscarArticulo.Familia = "-1"
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
                    Cb_TipoUnidad.SelectedValue = dtArticulos.Rows(0).Item("CODIGOTIPOUNIDAD")
                    CuTx_ValorIsmocol.Valor = dtArticulos.Rows(0).Item("VALORREFERENCIA")
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
    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If ValidarMaterial() Then
            GuardarMaterial()
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Private Function ValidarMaterial() As Boolean
        If Tx_Descripcion.Text.Length <= 0 OrElse FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Descripcion.Text.Length) <= 0 Then
            ValidarMaterial = False
            MsgBox("La descripción del Material no debe estar vacía.", MsgBoxStyle.Exclamation, "Material")
            Tx_Descripcion.Focus()
            Exit Function
        End If
        If Cb_TipoUnidad.SelectedIndex < 0 Then
            ValidarMaterial = False
            MsgBox("Debe seleccionar el tipo de unidad del Material.", MsgBoxStyle.Exclamation, "Material")
            Cb_TipoUnidad.Focus()
            Exit Function
        End If
        If CuTx_ValorIsmocol.Valor <= 0 AndAlso CuTx_ValorComercial.Valor <= 0 Then
            ValidarMaterial = False
            MsgBox("Indique por lo menos uno los valores de las tarifas Ismocol o Comercial.", MsgBoxStyle.Exclamation, "Material")
            CuTx_ValorIsmocol.Focus()
            Exit Function
        End If
        If Ck_Activo.CheckState = CheckState.Indeterminate Then
            ValidarMaterial = False
            MsgBox("Seleccione el estado del Material (Activo/Inactivo).", MsgBoxStyle.Exclamation, "Material")
            Ck_Activo.Focus()
            Exit Function
        End If
        ValidarMaterial = True
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub GuardarMaterial()
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

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLIC_Material", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@TIPO", SqlDbType.TinyInt)
        comando.Parameters.Add("@IDMATERIAL", SqlDbType.Int)
        Select Case Edicion
            Case TipoEdicion.Editar
                comando.Parameters("@TIPO").Value = 2
                comando.Parameters("@IDMATERIAL").Value = IdMaterial
            Case Else
                'Crear, Clonar
                comando.Parameters("@TIPO").Value = 1
                comando.Parameters("@IDMATERIAL").Value = DBNull.Value
        End Select
        comando.Parameters.AddWithValue("@DESCRIPCION", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Descripcion.Text))
        comando.Parameters.AddWithValue("@CODIGOTIPOUNIDAD", Cb_TipoUnidad.SelectedValue)
        If Trim(Tx_IdArticulo.Text) <> "" Then
            comando.Parameters.AddWithValue("@IDARTICULO", Trim(Tx_IdArticulo.Text))
        Else
            comando.Parameters.AddWithValue("@IDARTICULO", DBNull.Value)
        End If
        comando.Parameters.AddWithValue("@VALORISMOCOL", CuTx_ValorIsmocol.Valor)
        comando.Parameters.AddWithValue("@VALORCOMERCIAL", CuTx_ValorComercial.Valor)
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
                IdMaterial = msgParam.Value
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
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class 'Fr_Material