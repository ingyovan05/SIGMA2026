Imports FormularioLicitaciones.FormulariosLicitaciones
Imports System.Data.SqlClient

''' <summary>
''' 
''' </summary>
Public Class Fr_ManoDeObra
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property IdManoDeObra As Integer = -1

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
    ReadOnly Property TarifaIsmocolxHoraHombre As Decimal
        Get
            Return CuTx_TarifaIsmocol.Valor
        End Get
    End Property


    ' 
    Private Sub Fr_ManoDeObra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Comportamiento_Predeterminado()
        If Edicion = TipoEdicion.Editar OrElse Edicion = TipoEdicion.Ver OrElse Edicion = TipoEdicion.Clonar Then
            CargarManoDeObra()
        Else 'Nuevo

        End If
        If Edicion = TipoEdicion.Ver Then
            Tx_Codigo.ReadOnly = True
            Tx_Descripcion.ReadOnly = True
            CuTx_TarifaIsmocol.SoloLectura = True
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
        CuTx_TarifaIsmocol.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(CuTx_TarifaIsmocol.Tag)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CargarManoDeObra()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM LIC_DatosManoDeObra(@TIPO, @IDMANODEOBRA, @IDLICITACION)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 0) 'Cualquier Mano de Obra (Activa o Inactiva)
        comando.Parameters.AddWithValue("@IDMANODEOBRA", IdManoDeObra)
        comando.Parameters.AddWithValue("@IDLICITACION", DBNull.Value)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtManoDeObra As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtManoDeObra, SchemaType.Source)
            adaptador.Fill(dtManoDeObra)
            conexion.Close()

            'Asignaciones
            Tx_Codigo.Text = dtManoDeObra.Rows(0).Item("IDMANODEOBRA")
            Tx_Descripcion.Text = dtManoDeObra.Rows(0).Item("DESCRIPCION")
            CuTx_TarifaIsmocol.Valor = dtManoDeObra.Rows(0).Item("TARIFAISMOCOLXHORAHOMBRE")
            Ck_Activo.ThreeState = False
            If dtManoDeObra.Rows(0).Item("ACTIVO") = "S" Then
                Ck_Activo.Checked = True
                Ck_Activo.CheckState = CheckState.Checked
            ElseIf dtManoDeObra.Rows(0).Item("ACTIVO") = "N" Then
                Ck_Activo.Checked = False
                Ck_Activo.CheckState = CheckState.Unchecked
            Else
                Ck_Activo.Checked = False
                Ck_Activo.CheckState = CheckState.Indeterminate
            End If
            If Edicion = TipoEdicion.Clonar Then
                IdManoDeObra = -1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ' 
    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If ValidarManoDeObra() Then
            GuardarManoDeObra()
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Private Function ValidarManoDeObra() As Boolean
        If Tx_Descripcion.Text.Length <= 0 OrElse FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Descripcion.Text) = "" Then
            ValidarManoDeObra = False
            MsgBox("La Descripción de la Mano de Obra no puede estar vacía.", MsgBoxStyle.Exclamation, "Mano de Obra")
            Tx_Descripcion.Focus()
            Exit Function
        End If
        If CuTx_TarifaIsmocol.Valor <= 0 Then
            ValidarManoDeObra = False
            MsgBox("Debe indicar el valor de la tarifa.", MsgBoxStyle.Exclamation, "Mano de Obra")
            CuTx_TarifaIsmocol.Focus()
            Exit Function
        End If
        If Ck_Activo.CheckState = CheckState.Indeterminate Then
            ValidarManoDeObra = False
            MsgBox("Seleccione el estado de la Mano de Obra (Activa/Inactiva).", MsgBoxStyle.Exclamation, "Mano de Obra")
            Ck_Activo.Focus()
            Exit Function
        End If
        ValidarManoDeObra = True
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub GuardarManoDeObra()
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
        Dim comando As New SqlCommand("dbo.GestionarLIC_ManoDeObra", conexion)
        comando.CommandType = CommandType.StoredProcedure
        Select Case Edicion
            Case TipoEdicion.Editar
                comando.Parameters.AddWithValue("@TIPO", 2)
                comando.Parameters.AddWithValue("@IDMANODEOBRA", IdManoDeObra)
            Case Else
                'Crear, Clonar
                comando.Parameters.AddWithValue("@TIPO", 1)
                comando.Parameters.AddWithValue("@IDMANODEOBRA", DBNull.Value)
        End Select
        comando.Parameters.AddWithValue("@DESCRIPCION", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Descripcion.Text))
        comando.Parameters.AddWithValue("@TARIFAISMOCOLXHORAHOMBRE", CuTx_TarifaIsmocol.Valor)
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
                IdManoDeObra = msgParam.Value
            End If
            MsgBox("Datos guardados correctamente.", MsgBoxStyle.Information, "Mano de Obra")
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

End Class 'Fr_ManoDeObra