Imports System.Data.SqlClient
Imports System.Text

''' <summary>
''' 
''' </summary>
Public Class Fr_AsignarPermisosLicitacion
    ''' <summary>
    ''' 
    ''' </summary>
    Private conexion As SqlConnection

    ''' <summary>
    ''' 
    ''' </summary>
    Private comando As SqlCommand

    ''' <summary>
    ''' 
    ''' </summary>
    Private adaptador As SqlDataAdapter

    ''' <summary>
    ''' 
    ''' </summary>
    Private dtTipoPermisos As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    Private dtListadoLicitaciones As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    Private dtPermisosLicitacion As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    Private asignacion As TipoAsignacion

    ''' <summary>
    ''' 
    ''' </summary>
    Enum TipoAsignacion
        PorUsuario
        PorLicitacion
    End Enum


    ' 
    Private Sub Fr_AsignarPermisosLicitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtListadoLicitaciones = New DataTable
        dtPermisosLicitacion = New DataTable
        dtTipoPermisos = New DataTable
        dtTipoPermisos.Columns.Add("TIPOPERMISO")
        dtTipoPermisos.Columns.Add("NOMBREPERMISO")
        dtTipoPermisos.Rows.Add("N", "Ninguno")
        dtTipoPermisos.Rows.Add("L", "Lectura")
        dtTipoPermisos.Rows.Add("E", "Escritura")
        Cb_Dgv_TipoPermiso.DataSource = dtTipoPermisos
        Cb_Dgv_TipoPermiso.ValueMember = "TIPOPERMISO"
        Cb_Dgv_TipoPermiso.DisplayMember = "NOMBREPERMISO"
        Cu_BuscarPersona.CargarDatos()
        Cu_BuscarPersona.Cb_Persona.SelectedIndex = -1
        ListarLicitaciones()
        Comportamiento_Predeterminado()
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub Comportamiento_Predeterminado()
        Dgv_Permisos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Permisos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ListarLicitaciones()
        conexion = New SqlConnection(My.Settings.CadenaConexión)
        comando = New SqlCommand("SELECT * FROM dbo.LIC_ListaLicitaciones(@TIPO, @IDUSUARIO)", conexion)
        comando.Parameters.AddWithValue("@TIPO", 1) 'Todas las licitaciones (incluyendo las licitaciones de las que el usuario no tiene permisos).
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        adaptador = New SqlDataAdapter(comando)
        dtListadoLicitaciones.Clear()
        Try
            conexion.Open()
            adaptador.FillSchema(dtListadoLicitaciones, SchemaType.Source)
            adaptador.Fill(dtListadoLicitaciones)
            conexion.Close()
            Cb_Licitacion.DataSource = dtListadoLicitaciones
            Cb_LicitacionNumero.DataSource = dtListadoLicitaciones
            Cb_Licitacion.ValueMember = "IDLICITACION"
            Cb_LicitacionNumero.ValueMember = "IDLICITACION"
            Cb_Licitacion.DisplayMember = "PROYECTO"
            Cb_LicitacionNumero.DisplayMember = "NROLICITACION"
            Cb_Licitacion.SelectedIndex = -1
            Cb_LicitacionNumero.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ' 
    Private Sub Cb_LicitacionNumero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_LicitacionNumero.SelectedIndexChanged
        If Cb_Licitacion.SelectedValue Is Nothing AndAlso Cb_Licitacion.ValueMember <> "" AndAlso Cb_Licitacion.DisplayMember <> "" Then
            If Cb_LicitacionNumero.SelectedIndex = 0 Then
                Cb_Licitacion.SelectedIndex = 0
            End If
        End If
    End Sub


    ' 
    Private Sub Cb_Licitacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Licitacion.SelectedIndexChanged
        If Cb_LicitacionNumero.SelectedValue Is Nothing AndAlso Cb_LicitacionNumero.ValueMember <> "" AndAlso Cb_LicitacionNumero.DisplayMember <> "" Then
            If Cb_Licitacion.SelectedIndex = 0 Then
                Cb_LicitacionNumero.SelectedIndex = 0
            End If
        End If
    End Sub


    ' 
    Private Sub Bt_CargarLicitacionesPorUsuario_Click(sender As Object, e As EventArgs) Handles Bt_CargarLicitacionesPorUsuario.Click
        If Not IsNothing(Cu_BuscarPersona.Cb_Persona.SelectedValue) Then
            CargarPermisos(2)
            asignacion = TipoAsignacion.PorUsuario
        Else
            MsgBox("Seleccione el usuario a gestionar en el listado desplegable.", MsgBoxStyle.Exclamation, "Cargar Licitaciones por Usuario")
            Cu_BuscarPersona.Cb_Persona.Focus()
        End If
    End Sub


    ' 
    Private Sub Bt_CargarUsuariosPorLicitacion_Click(sender As Object, e As EventArgs) Handles Bt_CargarUsuariosPorLicitacion.Click
        If Not IsNothing(Cb_LicitacionNumero.SelectedValue) Then
            CargarPermisos(1)
            asignacion = TipoAsignacion.PorLicitacion
        Else
            MsgBox("Seleccione la licitación a gestionar en el listado desplegable.", MsgBoxStyle.Exclamation, "Cargar Usuarios por Licitación")
            Cb_Licitacion.Focus()
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tipo"></param>
    Private Sub CargarPermisos(tipo As Integer)
        conexion = New SqlConnection(My.Settings.CadenaConexión)
        comando = New SqlCommand("SELECT * FROM dbo.LIC_ListaPermisoLicitacion(@TIPO, @IDLICITACION, @IDPERSONA) ORDER BY [NROLICITACION], [PERSONA]", conexion)
        comando.Parameters.AddWithValue("@TIPO", tipo)
        comando.Parameters.AddWithValue("@IDLICITACION", If(Not IsNothing(Cb_LicitacionNumero.SelectedValue), Cb_LicitacionNumero.SelectedValue, -1))
        comando.Parameters.AddWithValue("@IDPERSONA", If(Not IsNothing(Cu_BuscarPersona.Cb_Persona.SelectedValue), Cu_BuscarPersona.Cb_Persona.SelectedValue, -1))
        adaptador = New SqlDataAdapter(comando)
        dtPermisosLicitacion.Clear()
        Try
            conexion.Open()
            adaptador.FillSchema(dtPermisosLicitacion, SchemaType.Mapped)
            adaptador.Fill(dtPermisosLicitacion)
            conexion.Close()
            Dgv_Permisos.DataSource = dtPermisosLicitacion
            InhabilitarControles()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    ' 
    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        If MsgBox("¿Desea aplicar los cambios realizados?", MsgBoxStyle.YesNo, "Guardar cambios") = MsgBoxResult.No Then
            Exit Sub
        End If

        ' Arreglo que incluye únicamente las filas con permisos de lectura o escritura.
        Dim filas() As DataRow
        filas = Dgv_Permisos.DataSource.Select("TIPOPERMISO<>'N'")

        ' Tabla a la cual se copian las filas seleccionadas.
        ' Es necesaria para enviarse como parámetro en el Procedimiento Almacenado en lugar del arreglo "filas".
        Dim dtTablaPermisos As New DataTable
        dtTablaPermisos.Columns.Add("IDLICITACION")
        dtTablaPermisos.Columns.Add("IDPERSONA")
        dtTablaPermisos.Columns.Add("TIPOPERMISO")
        Dim fila As DataRow
        For i = 0 To filas.Count - 1
            Dim filausuario As DataRow
            filausuario = filas(i)
            fila = dtTablaPermisos.NewRow
            fila("IDLICITACION") = filausuario("IDLICITACION")
            fila("IDPERSONA") = filausuario("IDPERSONA")
            fila("TIPOPERMISO") = If(filausuario("TIPOPERMISO") IsNot DBNull.Value, filausuario("TIPOPERMISO"), "N")
            dtTablaPermisos.Rows.Add(fila)
        Next
        conexion = New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        comando = New SqlClient.SqlCommand("dbo.GestionarLIC_PermisoLicitacion", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@TIPO", SqlDbType.TinyInt)
        Select Case asignacion
            Case TipoAsignacion.PorUsuario
                comando.Parameters("@TIPO").Value = 1
            Case TipoAsignacion.PorLicitacion
                comando.Parameters("@TIPO").Value = 2
        End Select
        comando.Parameters.AddWithValue("@TablaPermisoLicitacion", dtTablaPermisos)
        If Not IsNothing(Cb_LicitacionNumero.SelectedValue) Then
            comando.Parameters.AddWithValue("@IDLICITACION", Cb_LicitacionNumero.SelectedValue)
        Else
            comando.Parameters.AddWithValue("@IDLICITACION", DBNull.Value)
        End If
        comando.Parameters.AddWithValue("@IDPERSONA", If(Not IsNothing(Cu_BuscarPersona.Cb_Persona.SelectedValue), Cu_BuscarPersona.Cb_Persona.SelectedValue, -1))
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.TinyInt)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()

            Dim textoSalirContinuar As New StringBuilder
            textoSalirContinuar.Append("Se actualizaron correctamente los permisos ")
            Select Case asignacion
                Case TipoAsignacion.PorUsuario
                    textoSalirContinuar.AppendLine("del usuario " + Trim(Cu_BuscarPersona.Cb_Persona.Text) + ".")
                Case TipoAsignacion.PorLicitacion
                    textoSalirContinuar.AppendLine("para la licitación Nro. " + Trim(Cb_LicitacionNumero.Text) + ".")
            End Select
            textoSalirContinuar.Append("¿Desea salir?")

            If MsgBox(textoSalirContinuar.ToString, MsgBoxStyle.YesNo, "SALIR") = MsgBoxResult.Yes Then
                Close()
            Else
                HabilitarControles()
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
    Private Sub HabilitarControles()
        Pn_Filtro.Enabled = True
        Bt_Guardar.Enabled = False
        Bt_Cancelar.Enabled = False
        Bt_CargarLicitacionesPorUsuario.Enabled = True
        Bt_CargarUsuariosPorLicitacion.Enabled = True
        dtPermisosLicitacion.Clear()
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub InhabilitarControles()
        Pn_Filtro.Enabled = False
        Bt_Cancelar.Enabled = True
        Bt_Guardar.Enabled = True
        Bt_CargarLicitacionesPorUsuario.Enabled = False
        Bt_CargarUsuariosPorLicitacion.Enabled = False
    End Sub


    ' 
    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        HabilitarControles()
    End Sub


    ' 
    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Close()
    End Sub

End Class