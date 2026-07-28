Imports System.Data.SqlClient

Public Class Fr_BaseDependencia

    Public Property Edicion As Boolean = False
    Public Property IdBase As Integer = -1
    Public Property IdDependencia As Integer = -1

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Fr_BaseDependencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarListadoGerencias()
        CargarListadoEmpresas()
        Cu_Ciudad_Base.CargarDatos()

        If IdDependencia >= 0 And IdBase >= 0 Then 'Editando Dependencia
            CargarBase(IdBase)
            CargarDependencia(IdDependencia)
            Tx_NombreBase.Enabled = False
            Tx_Abreviatura.Enabled = False
            Cb_Empresa.Enabled = False
            Ck_BaseActiva.Enabled = False
            Cu_Ciudad_Base.Enabled = False
            Tx_Direccion.Enabled = False
            Tx_NombreDependencia.Focus()
            Me.Text = "Editando Dependencia"
        Else
            If IdBase >= 0 Then
                CargarBase(IdBase)
                If Edicion Then 'Editando Base
                    Pn_TituloDependencia.Visible = False
                    Pn_Dependencia.Visible = False
                    Tx_NombreBase.Focus()
                    Me.Text = "Editando Base"
                Else 'Creando Dependencia
                    Tx_NombreBase.Enabled = False
                    Tx_Abreviatura.Enabled = False
                    Cb_Empresa.Enabled = False
                    Ck_BaseActiva.Enabled = False
                    Cu_Ciudad_Base.Enabled = False
                    Tx_Direccion.Enabled = False
                    Tx_NombreDependencia.Focus()
                    Me.Text = "Creando Dependencia"
                End If
            Else 'Creando Base
                Me.Text = "Creando Base"
            End If
        End If
    End Sub

    Private Sub CargarListadoGerencias()
        Dim dt_Gerencias As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT IDGERENCIA, NOMBREGERENCIA FROM SC_GERENCIA WHERE ACTIVO = 'S'", conexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dt_Gerencias)
            conexion.Close()
            Cb_Gerencia.DataSource = dt_Gerencias
            Cb_Gerencia.DisplayMember = "NOMBREGERENCIA"
            Cb_Gerencia.ValueMember = "IDGERENCIA"
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub CargarListadoEmpresas()
        Dim dt_Empresas As New DataTable
        dt_Empresas.Columns.Add("IdEmpresa")
        dt_Empresas.Columns.Add("Nombre")
        dt_Empresas.Rows.Add("0", "ISMOCOL")
        dt_Empresas.Rows.Add("2", "ZAMORANA")
        Cb_Empresa.DataSource = dt_Empresas
        Cb_Empresa.DisplayMember = "Nombre"
        Cb_Empresa.ValueMember = "IdEmpresa"
    End Sub

    Private Sub CargarBase(ByVal IdBase As Integer)
        Dim dt_BaseSC As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 5)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", IdBase)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", IdDependencia)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dt_BaseSC)
            conexion.Close()
            Dim Fila_Base As DataRow
            Fila_Base = dt_BaseSC(0)
            Tx_NombreBase.Text = Fila_Base("NOMBREBASE")
            Tx_Abreviatura.Text = Fila_Base("ABREVIATURABASE")
            Select Case Fila_Base("ACTIVO")
                Case "S"
                    Ck_BaseActiva.Checked = True
                Case Else
                    Ck_BaseActiva.Checked = False
            End Select
            Cu_Ciudad_Base.Cb_Ciudad.SelectedValue = Fila_Base("CODIGOPOBLACION")
            Tx_Direccion.Text = Fila_Base("DIRECCION")
            Cb_Empresa.SelectedValue = Fila_Base("IDEMPRESA")
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub CargarDependencia(ByVal IdDependencia As Integer)
        Dim dt_DependenciaSC As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 6)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", IdBase)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", IdDependencia)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dt_DependenciaSC)
            conexion.Close()
            Dim Fila_Dependencia As DataRow
            Fila_Dependencia = dt_DependenciaSC(0)
            Tx_NombreDependencia.Text = Fila_Dependencia("NOMBREDEPENDENCIA")
            Select Case Fila_Dependencia("ACTIVO")
                Case "S"
                    Ck_DependenciaActiva.Checked = True
                Case Else
                    Ck_DependenciaActiva.Checked = False
            End Select
            Cb_Gerencia.SelectedValue = Fila_Dependencia("IDGERENCIA")
            Cu_CentroCosto_Dependencia.IdCentroCosto = Fila_Dependencia("IDCENTROCOSTO")
        Catch ex As Exception
            conexion.Close()
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Close()
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If ValidarDatos() Then
            Try
                If IdDependencia >= 0 And IdBase >= 0 Then 'Editando Dependencia
                    ActualizarDependencia()
                Else
                    If IdBase >= 0 Then
                        If Edicion Then 'Editando Base
                            ActualizarBase()
                        Else 'Creando Dependencia
                            CrearDependencia()
                        End If
                    Else 'Creando Base
                        CrearBase()
                    End If
                End If
                MsgBox("Datos guardados correctamente.", MsgBoxStyle.Information, "GUARDADO")
                DialogResult = Windows.Forms.DialogResult.OK
                Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Exit Sub
        End If
    End Sub

    Private Function ValidarDatos() As Boolean
        If IdDependencia < 0 And (IdBase < 0 Or Edicion) Then 'Validar Base
            If Tx_NombreBase.Text.Length < 1 Then
                MsgBox("Indique el nombre de la Base.", MsgBoxStyle.Exclamation, "NOMBRE DE LA BASE")
                Tx_NombreBase.Focus()
                Return False
            End If

            If Tx_Abreviatura.Text.Length < 1 Then
                MsgBox("Indique la abreviatura de la base.", MsgBoxStyle.Exclamation, "ABREVIATURA DE LA BASE")
                Tx_Abreviatura.Focus()
                Return False
            End If

            If Cu_Ciudad_Base.Cb_Ciudad.SelectedIndex <= 0 Then
                MsgBox("Seleccione el municipio en el cual está ubicada la Base.", MsgBoxStyle.Exclamation, "MUNICIPIO DE LA BASE")
                Cu_Ciudad_Base.Cb_Ciudad.Focus()
                Return False
            End If
        End If
        If IdDependencia >= 0 Or Not Edicion Then 'Validar Dependencia
            If Tx_NombreDependencia.Text.Length < 1 Then
                MsgBox("Indique el nombre de la Dependencia.", MsgBoxStyle.Exclamation, "NOMBRE DE LA DEPENDENCIA")
                Tx_NombreDependencia.Focus()
                Return False
            End If

            If Cu_CentroCosto_Dependencia.IdCentroCosto < 1 Then
                MsgBox("Seleccione el Centro de Costos de la Dependencia.", MsgBoxStyle.Exclamation, "CENTRO DE COSTOS DE LA DEPENDENCIA")
                Cu_CentroCosto_Dependencia.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub CrearBase()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 1)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", DBNull.Value)
        comando.Parameters.AddWithValue("@NOMBREBASE", Trim(Tx_NombreBase.Text))
        comando.Parameters.AddWithValue("@ABREVIATURABASE", Trim(Tx_Abreviatura.Text))
        If Ck_BaseActiva.Checked Then
            comando.Parameters.AddWithValue("@ACTIVOBASE", "S")
        Else
            comando.Parameters.AddWithValue("@ACTIVOBASE", "N")
        End If
        comando.Parameters.AddWithValue("@CODIGOPOBLACION", Cu_Ciudad_Base.Cb_Ciudad.SelectedValue)
        comando.Parameters.AddWithValue("@DIRECCION", Trim(Tx_Direccion.Text))
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", DBNull.Value)
        comando.Parameters.AddWithValue("@NOMBREDEPENDENCIA", Trim(Tx_NombreDependencia.Text))
        If Ck_DependenciaActiva.Checked Then
            comando.Parameters.AddWithValue("@ACTIVODEPENDENCIA", "S")
        Else
            comando.Parameters.AddWithValue("@ACTIVODEPENDENCIA", "N")
        End If
        comando.Parameters.AddWithValue("@IDGERENCIA", Cb_Gerencia.SelectedValue)
        comando.Parameters.AddWithValue("@IDCENTROCOSTO", Cu_CentroCosto_Dependencia.IdCentroCosto)
        comando.Parameters.AddWithValue("@IDEMPRESA", Cb_Empresa.SelectedValue)
        Dim mensajeParam As New SqlParameter("@MENSAJE", SqlDbType.Int)
        mensajeParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(mensajeParam)
        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
        IdDependencia = mensajeParam.Value
    End Sub

    Private Sub CrearDependencia()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 2)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", IdBase)
        comando.Parameters.AddWithValue("@NOMBREBASE", DBNull.Value)
        comando.Parameters.AddWithValue("@ABREVIATURABASE", DBNull.Value)
        comando.Parameters.AddWithValue("@ACTIVOBASE", DBNull.Value)
        comando.Parameters.AddWithValue("@CODIGOPOBLACION", DBNull.Value)
        comando.Parameters.AddWithValue("@DIRECCION", DBNull.Value)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", DBNull.Value)
        comando.Parameters.AddWithValue("@NOMBREDEPENDENCIA", Trim(Tx_NombreDependencia.Text))
        If Ck_DependenciaActiva.Checked Then
            comando.Parameters.AddWithValue("@ACTIVODEPENDENCIA", "S")
        Else
            comando.Parameters.AddWithValue("@ACTIVODEPENDENCIA", "N")
        End If
        comando.Parameters.AddWithValue("@IDGERENCIA", Cb_Gerencia.SelectedValue)
        comando.Parameters.AddWithValue("@IDCENTROCOSTO", Cu_CentroCosto_Dependencia.IdCentroCosto)
        comando.Parameters.AddWithValue("@IDEMPRESA", Cb_Empresa.SelectedValue)
        Dim mensajeParam As New SqlParameter("@MENSAJE", SqlDbType.Int)
        mensajeParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(mensajeParam)
        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
        IdDependencia = mensajeParam.Value
    End Sub

    Private Sub ActualizarBase()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 3)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", DBNull.Value)
        comando.Parameters.AddWithValue("@NOMBREBASE", Trim(Tx_NombreBase.Text))
        comando.Parameters.AddWithValue("@ABREVIATURABASE", Trim(Tx_Abreviatura.Text))
        If Ck_BaseActiva.Checked Then
            comando.Parameters.AddWithValue("@ACTIVOBASE", "S")
        Else
            comando.Parameters.AddWithValue("@ACTIVOBASE", "N")
        End If
        comando.Parameters.AddWithValue("@CODIGOPOBLACION", Cu_Ciudad_Base.Cb_Ciudad.SelectedValue)
        comando.Parameters.AddWithValue("@DIRECCION", Trim(Tx_Direccion.Text))
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", DBNull.Value)
        comando.Parameters.AddWithValue("@NOMBREDEPENDENCIA", DBNull.Value)
        comando.Parameters.AddWithValue("@ACTIVODEPENDENCIA", DBNull.Value)
        comando.Parameters.AddWithValue("@IDGERENCIA", DBNull.Value)
        comando.Parameters.AddWithValue("@IDCENTROCOSTO", DBNull.Value)
        comando.Parameters.AddWithValue("@IDEMPRESA", Cb_Empresa.SelectedValue)
        Dim adaptador As New SqlDataAdapter(comando)
        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
    End Sub

    Private Sub ActualizarDependencia()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 4)
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", IdBase)
        comando.Parameters.AddWithValue("@NOMBREBASE", DBNull.Value)
        comando.Parameters.AddWithValue("@ABREVIATURABASE", DBNull.Value)
        comando.Parameters.AddWithValue("@ACTIVOBASE", DBNull.Value)
        comando.Parameters.AddWithValue("@CODIGOPOBLACION", DBNull.Value)
        comando.Parameters.AddWithValue("@DIRECCION", DBNull.Value)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", IdDependencia)
        comando.Parameters.AddWithValue("@NOMBREDEPENDENCIA", Trim(Tx_NombreDependencia.Text))
        If Ck_DependenciaActiva.Checked Then
            comando.Parameters.AddWithValue("@ACTIVODEPENDENCIA", "S")
        Else
            comando.Parameters.AddWithValue("@ACTIVODEPENDENCIA", "N")
        End If
        comando.Parameters.AddWithValue("@IDGERENCIA", Cb_Gerencia.SelectedValue)
        comando.Parameters.AddWithValue("@IDCENTROCOSTO", Cu_CentroCosto_Dependencia.IdCentroCosto)
        comando.Parameters.AddWithValue("@IDEMPRESA", DBNull.Value)
        Dim adaptador As New SqlDataAdapter(comando)
        conexion.Open()
        comando.ExecuteNonQuery()
        conexion.Close()
    End Sub
End Class