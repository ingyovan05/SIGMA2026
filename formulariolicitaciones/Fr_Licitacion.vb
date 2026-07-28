Imports System.Data.SqlClient
Imports FormularioLicitaciones.FormulariosLicitaciones

''' <summary>
''' 
''' </summary>
Public Class Fr_Licitacion
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property IdLicitacion As Integer = -1

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    Property Edicion As TipoEdicion

    ''' <summary>
    ''' 
    ''' </summary>
    Private dtGerencia As New DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    Private permisoLicitacion As String = "N"


    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub New()
        InitializeComponent()
        AddHandler Tx_HorasDiarias.KeyPress, AddressOf FuncionesBase.FuncionesBase.TextBoxNumericoEntero_KeyPress
    End Sub


    ' 
    Private Sub Fr_Licitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtGerencia.Columns.Add("IDGERENCIA")
        dtGerencia.Columns.Add("GERENCIA")
        dtGerencia.Rows.Add("N", "NINGUNA")
        dtGerencia.Rows.Add("C", "CONSTRUCCIONES")
        dtGerencia.Rows.Add("M", "MONTAJES")
        dtGerencia.Rows.Add("O", "OPERACIONES")
        Cb_Gerencia.DataSource = dtGerencia
        Cb_Gerencia.ValueMember = "IDGERENCIA"
        Cb_Gerencia.DisplayMember = "GERENCIA"
        If Edicion = TipoEdicion.Editar Or Edicion = TipoEdicion.Ver Or Edicion = TipoEdicion.Clonar Then
            CargarLicitacion()
        Else 'Nuevo
            CuTx_Administracion.Valor = 0
            CuTx_Imprevistos.Valor = 0
            CuTx_Utilidad.Valor = 0
        End If
        If Edicion = TipoEdicion.Ver Then
            Tx_NroLicitacion.ReadOnly = True
            Tx_Proyecto.ReadOnly = True
            Tx_Contratista.ReadOnly = True
            Tx_Cliente.ReadOnly = True
            Cb_Gerencia.Enabled = False
            Ck_Activa.Enabled = False
            Tx_HorasDiarias.ReadOnly = True
            CuTx_Administracion.SoloLectura = True
            CuTx_Imprevistos.SoloLectura = True
            CuTx_Utilidad.SoloLectura = True
            Bt_Guardar.Enabled = False
            Bt_SeleccionarLicitacion.Visible = True
            Bt_Cancelar.Select()
        Else 'Editar, Clonar, Nuevo
            FuncionesBase.FuncionesBase.EnfocarCajaTexto(Tx_NroLicitacion)
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Sub CargarLicitacion()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_DatosLicitacion(@IDLICITACION, @IDUSUARIO)", conexion)
        If IdLicitacion > 0 Then
            comando.Parameters.AddWithValue("@IDLICITACION", IdLicitacion)
        ElseIf VariablesBase.VariablesBase.IdLicitacionCargada > 0 Then
            comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        Else
            MsgBox("No se ha cargado Licitación.", MsgBoxStyle.Critical, "LICITACIÓN")
            Close()
            Exit Sub
        End If
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtLicitacion As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtLicitacion, SchemaType.Source)
            adaptador.Fill(dtLicitacion)
            conexion.Close()

            'Asignaciones
            Tx_NroLicitacion.Text = dtLicitacion.Rows(0).Item("NROLICITACION")
            Tx_Proyecto.Text = dtLicitacion.Rows(0).Item("PROYECTO")
            Tx_Contratista.Text = dtLicitacion.Rows(0).Item("CONTRATISTA")
            Tx_Cliente.Text = dtLicitacion.Rows(0).Item("CLIENTE")
            Tx_HorasDiarias.Text = dtLicitacion.Rows(0).Item("HORASDIARIAS")
            CuTx_Administracion.Valor = dtLicitacion.Rows(0).Item("PORCENTAJEADMINISTRACION")
            CuTx_Imprevistos.Valor = dtLicitacion.Rows(0).Item("PORCENTAJEIMPREVISTOS")
            CuTx_Utilidad.Valor = dtLicitacion.Rows(0).Item("PORCENTAJEUTILIDAD")
            Ck_Activa.ThreeState = False
            If dtLicitacion.Rows(0).Item("ACTIVO") = "S" Then
                Ck_Activa.Checked = True
                Ck_Activa.CheckState = CheckState.Checked
            ElseIf dtLicitacion.Rows(0).Item("ACTIVO") = "N" Then
                Ck_Activa.Checked = False
                Ck_Activa.CheckState = CheckState.Unchecked
            Else
                Ck_Activa.Checked = False
                Ck_Activa.CheckState = CheckState.Indeterminate
            End If
            Cb_Gerencia.SelectedValue = dtLicitacion.Rows(0).Item("TIPOGERENCIA")
            permisoLicitacion = dtLicitacion.Rows(0).Item("TIPOPERMISO")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ' 
    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If ValidarLicitacion() Then
            GuardarLicitacion()
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Private Function ValidarLicitacion() As Boolean
        If Tx_NroLicitacion.Text.Length <= 0 Then
            ValidarLicitacion = False
            MsgBox("El número de la Licitación no debe estar vacío.", MsgBoxStyle.Exclamation, "Licitación")
            Tx_NroLicitacion.Focus()
            Exit Function
        End If
        If FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Proyecto.Text.Length) <= 0 Then
            ValidarLicitacion = False
            MsgBox("El nombre del Proyecto no debe estar vacío.", MsgBoxStyle.Exclamation, "Licitación")
            Tx_Proyecto.Focus()
            Exit Function
        End If
        If Tx_Contratista.Text.Length <= 0 Then
            ValidarLicitacion = False
            MsgBox("El nombre del Contratista no debe estar vacío.", MsgBoxStyle.Exclamation, "Licitación")
            Tx_Contratista.Focus()
            Exit Function
        End If
        If Tx_Cliente.Text.Length <= 0 Then
            ValidarLicitacion = False
            MsgBox("El nombre del Cliente no debe estar vacío.", MsgBoxStyle.Exclamation, "Licitación")
            Tx_Cliente.Focus()
            Exit Function
        End If
        If Tx_HorasDiarias.Text.Length <= 0 Then
            ValidarLicitacion = False
            MsgBox("El número de horas diarias no debe estar vacío.", MsgBoxStyle.Exclamation, "Licitación")
            Tx_NroLicitacion.Focus()
            Exit Function
        End If
        Dim horas As Integer
        horas = FuncionesBase.FuncionesBase.ValorRealInt(Tx_HorasDiarias.Text)
        If horas <= 0 Or horas > 24 Then
            ValidarLicitacion = False
            MsgBox("El número de horas diarias debe ser mayor que cero y menor que 24.", MsgBoxStyle.Exclamation, "Licitación")
            Tx_NroLicitacion.Focus()
            Exit Function
        End If
        If CuTx_Administracion.Texto.Length <= 0 Then
            ValidarLicitacion = False
            MsgBox("El porcentaje de Administración no debe estar vacío.", MsgBoxStyle.Exclamation, "Licitación")
            CuTx_Administracion.Focus()
            Exit Function
        End If
        If CuTx_Administracion.Valor < 0 Then
            ValidarLicitacion = False
            MsgBox("El porcentaje de Administración no debe ser negativo.", MsgBoxStyle.Exclamation, "Licitación")
            CuTx_Administracion.Focus()
            Exit Function
        End If
        If CuTx_Imprevistos.Texto.Length <= 0 Then
            ValidarLicitacion = False
            MsgBox("El porcentaje de Imprevistos no debe estar vacío.", MsgBoxStyle.Exclamation, "Licitación")
            CuTx_Imprevistos.Focus()
            Exit Function
        End If
        If CuTx_Imprevistos.Valor < 0 Then
            ValidarLicitacion = False
            MsgBox("El porcentaje de Administración no debe ser negativo.", MsgBoxStyle.Exclamation, "Licitación")
            CuTx_Imprevistos.Focus()
            Exit Function
        End If
        If CuTx_Utilidad.Texto.Length <= 0 Then
            ValidarLicitacion = False
            MsgBox("El porcentaje de Utilidad no debe estar vacío.", MsgBoxStyle.Exclamation, "Licitación")
            CuTx_Utilidad.Focus()
            Exit Function
        End If
        If CuTx_Utilidad.Valor < 0 Then
            ValidarLicitacion = False
            MsgBox("El porcentaje de Utilidad no debe ser negativo.", MsgBoxStyle.Exclamation, "Licitación")
            CuTx_Utilidad.Focus()
            Exit Function
        End If
        If Ck_Activa.CheckState = CheckState.Indeterminate Then
            ValidarLicitacion = False
            MsgBox("Seleccione el estado de la Licitación (Activa/Inactiva).", MsgBoxStyle.Exclamation, "Licitación")
            Ck_Activa.Focus()
            Exit Function
        End If
        ValidarLicitacion = True
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub GuardarLicitacion()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLic_Licitacion", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@TIPO", SqlDbType.TinyInt)
        comando.Parameters.Add("@IDLICITACION", SqlDbType.Int)
        Select Case Edicion
            Case TipoEdicion.Editar
                comando.Parameters("@TIPO").Value = 2
                If IdLicitacion > 0 Then
                    comando.Parameters("@IDLICITACION").Value = IdLicitacion
                ElseIf VariablesBase.VariablesBase.IdLicitacionCargada > 0 Then
                    comando.Parameters("@IDLICITACION").Value = VariablesBase.VariablesBase.IdLicitacionCargada
                Else
                    MsgBox("No se ha cargado Licitación.", MsgBoxStyle.Critical, "LICITACIÓN")
                    Exit Sub
                End If
            Case TipoEdicion.Clonar
                comando.Parameters("@TIPO").Value = 5
                If IdLicitacion > 0 Then
                    comando.Parameters("@IDLICITACION").Value = IdLicitacion
                ElseIf VariablesBase.VariablesBase.IdLicitacionCargada > 0 Then
                    comando.Parameters("@IDLICITACION").Value = VariablesBase.VariablesBase.IdLicitacionCargada
                Else
                    MsgBox("No se ha cargado Licitación.", MsgBoxStyle.Critical, "LICITACIÓN")
                    Exit Sub
                End If
            Case Else
                'Crear
                comando.Parameters("@TIPO").Value = 1
                comando.Parameters("@IDLICITACION").Value = DBNull.Value
        End Select
        comando.Parameters.AddWithValue("@NROLICITACION", Trim(Tx_NroLicitacion.Text))
        comando.Parameters.AddWithValue("@PROYECTO", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Proyecto.Text))
        comando.Parameters.AddWithValue("@CONTRATISTA", Trim(Tx_Contratista.Text))
        comando.Parameters.AddWithValue("@CLIENTE", Trim(Tx_Cliente.Text))
        comando.Parameters.AddWithValue("@HORASDIARIAS", FuncionesBase.FuncionesBase.ValorRealInt(Tx_HorasDiarias.Text))
        comando.Parameters.AddWithValue("@PORCENTAJEADMINISTRACION", CuTx_Administracion.Valor)
        comando.Parameters.AddWithValue("@PORCENTAJEIMPREVISTOS", CuTx_Imprevistos.Valor)
        comando.Parameters.AddWithValue("@PORCENTAJEUTILIDAD", CuTx_Utilidad.Valor)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@ACTIVO", If(Ck_Activa.Checked, "S", "N"))
        comando.Parameters.AddWithValue("@TIPOGERENCIA", Cb_Gerencia.SelectedValue)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
            If Not IsDBNull(msgParam.Value) AndAlso msgParam.Value > 0 Then
                IdLicitacion = msgParam.Value
            End If
            MsgBox("Datos guardados correctamente.", MsgBoxStyle.Information, "Licitación")
            Close()
            DialogResult = Windows.Forms.DialogResult.OK
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


    ' 
    Private Sub Bt_SeleccionarLicitacion_Click(sender As Object, e As EventArgs) Handles Bt_SeleccionarLicitacion.Click
        Close()
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class