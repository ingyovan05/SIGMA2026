Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Microsoft.Office.Interop
Imports FormulariosActivosFijos

Public Class Cu_ActivosFijos
    Public filtrocargado As Boolean = False
    Public TablaCargada As String
    Public datas As New DataSet
    Public cmde As New SqlCommand
    Public da As New SqlDataAdapter
    Dim dt_opcionesfiltro1 As New DataTable("OPCIONES")
    Dim dt_opcionesfiltro2 As New DataTable("OPCIONES")
    Dim dt_opcionesfiltro3 As New DataTable("OPCIONES")
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()

    Public Sub Cargar_Tabla()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Dim ds As New DataSet
        ds = bddatos.ModificarEquipos(2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, 0, 0, "", "", "", "", False, Date.Now)
        Dgv_Equipos.DataSource = ds.Tables(0).DefaultView
        TablaCargada = "EQUIPOS"
        Lb_Titulo.Text = "INFORMACIÓN DE EQUIPOS"
        AplicarFormato()
        If filtrocargado = False Then
            CargarFiltros()
            filtrocargado = True
        End If
        If Dgv_Equipos.RowCount > 0 Then
            Me.Dgv_Equipos.Rows(0).Selected = True
        End If
        CargarListaSeleccion()
    End Sub

    Public Sub Comportamiento_Predeterminado()
        Dgv_Equipos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Equipos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Componentes.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Componentes.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Historial.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Historial.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Nbc_Equipos.ActiveGroup = Nbg_Equipo
        'Equipo
        Nbg_Equipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Equipo.Tag)
        Nbi_CargarEquipos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarEquipos.Tag)
        Nbi_CrearEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearEquipo.Tag)
        Nbi_ClonarEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarEquipo.Tag)
        Nbi_EditarEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarEquipo.Tag)
        Nbi_DarBaja.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_DarBaja.Tag)
        Nbi_EliminarEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EliminarEquipo.Tag)
        Nbi_BuscarEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarEquipo.Tag)
        Nbi_EstadoUso.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EstadoUso.Tag)
        Nbi_VerCaracteristicas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerCaracteristicas.Tag)
        Nbi_CrearRevisiónExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearRevisiónExterna.Tag)
        Nbi_VerHojaVida.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerHojaVida.Tag)
        Nbi_ImprimirPazSalvo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirPazSalvo.Tag)
        Nbi_ImprimirStickerEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirStickerEquipo.Tag)
        Nbi_Asegurado.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Asegurado.Tag)
        'Administración
        Nbg_Administracion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Administracion.Tag)
        Nbi_AdministrarTipos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AdministrarTipos.Tag)
        Nbi_RestaurarEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RestaurarEquipo.Tag)
        'Traslados
        Nbg_Traslados.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Traslados.Tag)
        Nbi_PendientesEnviados.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_PendientesEnviados.Tag)
        Nbi_EnviadosRecibidos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EnviadosRecibidos.Tag)
        Nbi_PendientesRecibir.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_PendientesRecibir.Tag)
        Nbi_Recibidos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Recibidos.Tag)
        'Revisión Externa
        Nbg_RevisiónExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_RevisiónExterna.Tag)
        'Filtrar
        Nbg_Filtrar.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Filtrar.Tag)
        Nbi_CargarRevisionesExternas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarRevisionesExternas.Tag)
        Nbi_VerRevisiónExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerRevisiónExterna.Tag)
        Nbi_EditarRevisiónExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarRevisiónExterna.Tag)
        Nbi_CerrarRevisiónExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CerrarRevisiónExterna.Tag)
        Nbi_AnularRevisiónExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularRevisiónExterna.Tag)
        Nbi_BuscarRevisiónExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarRevisiónExterna.Tag)
        Nbi_ImprimirRevisiónExterna.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirRevisiónExterna.Tag)
    End Sub

    Private Sub AplicarFormato()
        For i = 0 To Dgv_Equipos.ColumnCount - 1
            Select Case Dgv_Equipos.Columns(i).Name
                Case "CODIGO"
                    Dgv_Equipos.Columns(i).HeaderText = "Cód"
                    Dgv_Equipos.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    Dgv_Equipos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "ESTADO USO"
                    Dgv_Equipos.Columns(i).HeaderText = "Estado uso"
                    Dgv_Equipos.Columns(i).Width = 85
                Case "ESTADO"
                    Dgv_Equipos.Columns(i).HeaderText = "Ubicación"
                    Dgv_Equipos.Columns(i).Width = 70
                Case "BODEGAACTUAL"
                    Dgv_Equipos.Columns(i).HeaderText = "Bod Actual"
                    Dgv_Equipos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "TIPO"
                    Dgv_Equipos.Columns(i).HeaderText = "Tipo"
                    Dgv_Equipos.Columns(i).Width = 100
                Case "SUBTIPO"
                    Dgv_Equipos.Columns(i).HeaderText = "Subtipo"
                    Dgv_Equipos.Columns(i).Width = 100
                Case "MARCA"
                    Dgv_Equipos.Columns(i).HeaderText = "Marca"
                    Dgv_Equipos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "MODELO"
                    Dgv_Equipos.Columns(i).HeaderText = "Modelo"
                    Dgv_Equipos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "PERSONA_ASIGNADA"
                    Dgv_Equipos.Columns(i).HeaderText = "Persona Asignada "
                    Dgv_Equipos.Columns(i).Width = 118
                Case "SERIE"
                    Dgv_Equipos.Columns(i).HeaderText = "Serie"
                    Dgv_Equipos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case "ASEGURADO"
                    Dgv_Equipos.Columns(i).HeaderText = "Asegurado"
                    'Dgv_Equipos.Columns(i).DisplayIndex() = 4
                    Dgv_Equipos.Columns(i).Width = 55
                Case Else
                    Dgv_Equipos.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Private Sub Dgv_Equipos_SelectionChanged(sender As Object, e As EventArgs) Handles Dgv_Equipos.SelectionChanged
        CargarListaSeleccion()
    End Sub

    Private Sub CargarListaSeleccion()
        Select Case TablaCargada
            Case "EQUIPOS"
                Try
                    'mostrar propiedades
                    Try
                        Dim dspropiedades As New DataSet
                        Dim idequipo As Integer = Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDEQUIPO").Value
                        dspropiedades = bddatos.ModificarEquipos(34, 0, 0, idequipo, 0, 0, 0, 0, 0, 0, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, 0, 0, "", "", "", "", False, Date.Now)
                        Dim xx As New Pro_Equipo(dspropiedades.Tables(0).Rows(0))
                        'Dim xx As New Pro_Equipo(Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index))
                        Me.Pg_DetalleLista.SelectedObject = xx
                    Catch ex As Exception
                        ' MsgBox("error al cargar las propiedades")
                    End Try
                    'llenar la tabla de componentes
                    Dim dscomp As New DataSet
                    Dim equipo As New Integer
                    equipo = Integer.Parse(Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDEQUIPO").Value)
                    Try
                        dscomp = bddatos.ModificarEquipos(4, 0, 0, equipo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", False, Date.Now)
                        Dgv_Componentes.DataSource = dscomp.Tables(0).DefaultView
                    Catch ex As Exception
                        'MsgBox("error al cargar los Componentes")
                    End Try

                    'llenar tabla de historial            
                    Try
                        Dim dshistorial As New DataSet
                        dshistorial = bddatos.ModificarEntradasSalidas(2, 0, equipo, 0, Date.Now, 0, Date.Now, "", 0, 0)
                        Dgv_Historial.DataSource = dshistorial.Tables(0).DefaultView
                    Catch ex As Exception
                        ' MsgBox("error al cargar el Historial")
                    End Try
                Catch ex As Exception

                End Try
            Case "MANTENIMIENTOS"
                Dgv_Componentes.DataSource = Nothing
                Dgv_Historial.DataSource = Nothing
                'mostrar propiedades
                Try
                    Dim dspropiedades As New DataSet
                    Dim idrevisiónexterna As Integer = Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("ID").Value
                    Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
                    'declaro la cadena de conexión
                    Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                    sqlconeccion.Open()
                    cmde.Parameters.Clear()
                    cmde.CommandType = CommandType.StoredProcedure
                    cmde.Connection = sqlconeccion
                    cmde.CommandText = "dbo.GestionarMantenimientoExterno"
                    cmde.Parameters.AddWithValue("@accion", 10)
                    cmde.Parameters.AddWithValue("@IDMANTENIMIENTOEXTERNO", idrevisiónexterna)
                    cmde.Parameters.AddWithValue("@IDEQUIPO", -1)
                    cmde.Parameters.AddWithValue("@IDESTADOPARAUSOENVIO", 1)
                    cmde.Parameters.AddWithValue("@IDCONTRATISTA", -1)
                    cmde.Parameters.AddWithValue("@NOMBRE", "")
                    cmde.Parameters.AddWithValue("@CODIGOCIUDAD", "")
                    cmde.Parameters.AddWithValue("@FECHAENVIO", Date.Now)
                    cmde.Parameters.AddWithValue("@DIRECCIONENVIO", "")
                    cmde.Parameters.AddWithValue("@VALORESTIMADO", CDec("0,0"))
                    cmde.Parameters.AddWithValue("@CODIGOTIPOMONEDA", 1)
                    cmde.Parameters.AddWithValue("@IDSOLICITADOPOR", -1)
                    cmde.Parameters.AddWithValue("@DESCRIPCION", "")
                    cmde.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                    cmde.Parameters.AddWithValue("@IDPERSONAREGISTRA", -1)
                    cmde.Parameters.AddWithValue("@IDPERSONAMODIFICA", -1)
                    cmde.Parameters.AddWithValue("@FECHARECIBIDO", Date.Now)
                    cmde.Parameters.AddWithValue("@VALORCIERRE", CDec("0,0"))
                    cmde.Parameters.AddWithValue("@IDESTADOPARAUSORECIBIDO", 1)
                    cmde.Parameters.AddWithValue("@OBSERVACION", "")
                    cmde.Parameters.AddWithValue("@IDPERSONARECIBE", -1)
                    cmde.Parameters.AddWithValue("@IDPERSONACIERRA", -1)
                    cmde.Parameters.AddWithValue("@IDPERSONAANULA", -1)
                    cmde.Parameters.AddWithValue("@OBERVACIONANULACION", "")
                    cmde.Parameters.AddWithValue("@VALORASEGURADORA", CDec("0,0"))
                    cmde.Parameters.AddWithValue("@IDPERSONAAPRUEBA", DBNull.Value)
                    cmde.Parameters.AddWithValue("@TIPOENVIO", DBNull.Value)
                    cmde.Parameters.AddWithValue("@FECHADESPACHO", DBNull.Value)
                    cmde.Parameters.AddWithValue("@TRANSPORTADOR", DBNull.Value)
                    cmde.Parameters.AddWithValue("@CELULAR", DBNull.Value)
                    cmde.Parameters.AddWithValue("@PLACAVEHICULO", DBNull.Value)
                    cmde.Parameters.AddWithValue("@EMPRESATRANSPORTADORA", DBNull.Value)
                    cmde.Parameters.AddWithValue("@GUIA", DBNull.Value)
                    cmde.Parameters.AddWithValue("@NOMBRERESPONSABLE", DBNull.Value)
                    Dim msgParam As New SqlParameter("@IDMANTENIMIENTOEXTERNONUEVO", SqlDbType.Int, 1)
                    msgParam.Direction = ParameterDirection.Output
                    cmde.Parameters.Add(msgParam)
                    da = New SqlClient.SqlDataAdapter(cmde)
                    datas = New DataSet()
                    da.Fill(datas)
                    sqlconeccion.Close()
                    Dim xx As New Pro_RevisiónExterna(datas.Tables(0).Rows(0))
                    'Dim xx As New Pro_Equipo(Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index))
                    Me.Pg_DetalleLista.SelectedObject = xx
                Catch ex As Exception
                    ' MsgBox("error al cargar las propiedades")
                End Try
        End Select
    End Sub

    Private Sub Dgv_Equipos_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Equipos.CellDoubleClick
        EditarEquipo()
    End Sub

    Private Sub Cu_ActivosFijos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, Dgv_Componentes.KeyDown, Dgv_Equipos.KeyDown, Dgv_Historial.KeyDown, Nbc_Equipos.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                FuncionesBase.FuncionesBase.AbrirAyudaOnline("/Inicio.aspx?MODULO=Materiales")
            Case Keys.F2
                CrearEquipo()
            Case Keys.F3
                BuscarEquipo()
            Case Keys.F4
                Cargar_Tabla()
            Case Keys.F5

            Case Keys.F6
                ExportarDatosExcel(Dgv_Equipos)
            Case Keys.F7

            Case Keys.F8

            Case Keys.F9

            Case Keys.F10

            Case Keys.F11

            Case Keys.F12
                FuncionesBase.FuncionesBase.AbrirAccesoRemoto()
        End Select
    End Sub

#Region "Equipo"
    Private Sub Nbi_CargarEquipos_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CargarEquipos.ItemClick
        'llenar grilla de equipos
        Cargar_Tabla()
    End Sub

    Private Sub Nbi_CrearEquipo_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_CrearEquipo.ItemClick
        CrearEquipo()
    End Sub

    Private Sub CrearEquipo()
        Dim formcrear As New FormulariosActivosFijos.Fr_CrearEquipo
        formcrear.ShowDialog()
        Cargar_Tabla()
    End Sub

    Private Sub Nbi_ClonarEquipo_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_ClonarEquipo.ItemClick
        'se va a clonar el equipo, capturar la variable de id del equipo seleccionado y enviar la señal de clonación
        If Dgv_Equipos.Rows.Count = 0 Then
            MsgBox("No hay datos cargados o no existe ningún equipo registrado", MsgBoxStyle.Exclamation, "Advertencia")
        Else
            Dim formclonar As New FormulariosActivosFijos.Fr_CrearEquipo
            formclonar.varcreacion = "CLONAR"
            formclonar.idequipo = Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDEQUIPO").Value
            formclonar.ShowDialog()
            Cargar_Tabla()
        End If
    End Sub

    Private Sub Nbi_EditarEquipo_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_EditarEquipo.ItemClick
        If RevisarMantenimientosPendientes(Dgv_Equipos.CurrentRow.Cells("IDEQUIPO").Value) = True Then
            MsgBox("Este equipo tiene mantenimiento externo pendiente de cierre o anulación", MsgBoxStyle.Critical, "CERRAR MANTENIMIENTOS EXTERNOS")
            Exit Sub
        End If
        EditarEquipo()
    End Sub

    Public Sub EditarEquipo()
        If TablaCargada = "EQUIPOS" Then
            If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDESTADO").Value = 0 Then
                MsgBox("LOS EQUIPOS ELIMINADOS NO SE PUEDEN EDITAR")
                Exit Sub
            End If
            'voy a editar un equipo existente, capturo el id del equipo seleccionado
            If Dgv_Equipos.Rows.Count = 0 Then
                MsgBox("No hay datos cargados o no existe ningún equipo registrado", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            Else
                Dim formeditar As New FormulariosActivosFijos.Fr_CrearEquipo
                formeditar.Text = "Editar Equipo Existente"
                formeditar.varcreacion = "EDITAR"
                If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDESTADO").Value = 8 Then
                    MsgBox("LOS EQUIPOS DADOS DE BAJA NO SE PUEDEN EDITAR")
                    formeditar.varcreacion = "VER"
                End If
                Dim id As Integer = Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDEQUIPO").Value
                Dim indice As Integer = Dgv_Equipos.CurrentRow.Index
                formeditar.idequipo = id
                formeditar.ShowDialog()
                Cargar_Tabla()
                'seleccionar el articulo editado
                Dgv_Equipos.CurrentCell = Me.Dgv_Equipos.Rows(indice).Cells("CODIGO")
            End If
        Else
            MsgBox("No puede Editar estos equipos, solo puede Editar los que se cargan desde el Menú 'EQUIPOS'", MsgBoxStyle.OkOnly, "NO PUEDE ELIMINAR TRASLADOS")
        End If
    End Sub

    Private Sub Nbi_DarBaja_ItemClick(sender As Object, e As EventArgs) Handles Nbi_DarBaja.ItemClick
        If RevisarMantenimientosPendientes(Dgv_Equipos.CurrentRow.Cells("IDEQUIPO").Value) = True Then
            MsgBox("Este equipo tiene mantenimiento externo pendiente de cierre o anulación", MsgBoxStyle.Critical, "CERRAR MANTENIMIENTOS EXTERNOS")
            Exit Sub
        End If
        'revisar que el equipo no este dado de baja
        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDESTADO").Value = 8 Then 'YA ESTA DADO DE BAJA
            MsgBox("No se puede dar de baja un equipo que ya esta dado de baja", MsgBoxStyle.Critical, "no se puede dar de baja")
            Exit Sub
        ElseIf Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDESTADO").Value <> 1 Then 'YA ESTA DADO DE BAJA
            MsgBox("El equipo debe estar almacenado en bodega, (ESTADO: EN BODEGA) para poderse dar de baja", MsgBoxStyle.Critical, "no se puede dar de baja")
            Exit Sub
        End If
        'REVISAR QUE NO ESTE ASOCIADO A NINGUN EQUIPO
        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDEQUIPOPADRE").Value <> 0 Then 'YA ESTA DADO DE BAJA
            MsgBox("No se puede dar de baja un equipo que esta asociado a otro equipo, primero desasocielo del equipo padre", MsgBoxStyle.Critical, "no se puede dar de baja")
            Exit Sub
        End If
        Dim accion, efecto As String
        accion = "Dar de Baja"
        efecto = "Dado de Baja"
        'revisar si tiene hijos
        If Dgv_Componentes.RowCount > 0 Then
            Dim resuesta = MsgBox("Este equipo tiene " + Dgv_Componentes.RowCount.ToString + " asociados, ¿desea darlos de baja también? ", vbYesNo, " Dar de Baja Componentes")
            If resuesta = vbYes Then
                'desasociar y dar de baja o dar de baja todo junto
                CambiarEstado(accion, efecto, 8, True) 'cambiar estado a 8 dado de baja
                Exit Sub
            Else
                MsgBox("Por favor desasocie los componentes que pertenecen al equipo antes de darlo de baja", MsgBoxStyle.Information, "no dar de baja componentes")
                Exit Sub
            End If
        End If
        If TablaCargada = "EQUIPOS" Then
            CambiarEstado(accion, efecto, 8, False) 'cambiar estado a 8 dado de baja
        Else
            MsgBox("No puede " + accion + " estos equipos, solo puede " + accion + " los que se cargan desde el Menú 'EQUIPOS'", MsgBoxStyle.OkOnly, "NO PUEDE EDITAR TRASLADOS")
        End If
    End Sub

    Private Sub Nbi_EliminarEquipo_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_EliminarEquipo.ItemClick
        If RevisarMantenimientosPendientes(Dgv_Equipos.CurrentRow.Cells("IDEQUIPO").Value) = True Then
            MsgBox("Este equipo tiene mantenimiento externo pendiente de cierre o anulación", MsgBoxStyle.Critical, "CERRAR MANTENIMIENTOS EXTERNOS")
            Exit Sub
        End If
        'debe estar en estado distinto a dado de baja o eliminado
        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDESTADO").Value <> 1 Then 'YA ESTA DADO DE BAJA
            MsgBox("El equipo debe estar almacenado en bodega, (ESTADO: EN BODEGA) para que se pueda ELIMINAR", MsgBoxStyle.Critical, "no se puede eliminar.")
            Exit Sub
        End If
        'debe estar en stock no puede tener movimientos
        If Dgv_Historial.RowCount <> 1 Then
            MsgBox("El equipo no puede tener movimientos y debe estar almacenado en bodega")
            Exit Sub
        ElseIf Dgv_Historial.Rows(0).Cells("ESTADOBODEGA").Value <> "A" Then
            MsgBox("El equipo tiene movimientos, no se puede eliminar un equipo que ya ha tenido traslados o se encuentra en traslado")
            Exit Sub
        End If
        'no puede tener componentes asociados
        If Dgv_Componentes.RowCount > 0 Then
            MsgBox("El equipo tiene componentes, no se puede eliminar, desasocie los componentes y luego inténtelo de nuevo.")
            Exit Sub
        End If
        'no puede estar asociado a un equipo
        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDEQUIPOPADRE").Value <> 0 Then
            MsgBox("No se puede eliminar un equipo que esta asociado a otro equipo, primero desasocielo del equipo padre", MsgBoxStyle.Critical, "no se puede dar de baja")
            Exit Sub
        End If
        Dim accion, efecto As String
        accion = "Eliminar"
        efecto = "Eliminado"
        If TablaCargada = "EQUIPOS" Then
            CambiarEstado(accion, efecto, 0, False) 'cambiar estado a eliminado = 0
        Else
            MsgBox("No puede " + accion + " estos equipos, solo puede " + accion + " los que se cargan desde el Menú 'EQUIPOS'", MsgBoxStyle.OkOnly, "NO PUEDE EDITAR TRASLADOS")
        End If
    End Sub

    Private Sub Nbi_BuscarEquipo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarEquipo.ItemClick
        BuscarEquipo()
    End Sub

    Private Sub BuscarEquipo()
        'filtro nuevo, proveedor
        'abrir formulario
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("e.CODIGOACCESS", "Código ACCESS", "1")
        campos.Rows.Add("dbo.CodigoEquipoCapital(e.IDEQUIPO,1)", "Código DEL EQUIPO", "1")
        campos.Rows.Add("e.CODIGOISMOCOL", "Código ISMOCOL", "1")
        campos.Rows.Add("e.CODIGOMECANICO ", "Código MECÁNICO", "1")
        campos.Rows.Add("2", "Serie o número serial", "7")
        campos.Rows.Add("3", "Placa de vehículo", "7")
        'campos.Rows.Add("", "Identificación Proveedor", "2") ISMOCOL NO TIENE NUMERO DE PROVEEDOR EN LA BASE DE PROVEEDORES
        campos.Rows.Add("ISNULL(p.NOMBRE , 'ISMOCOL S.A.' )", "Nombre Proveedor", "1")
        campos.Rows.Add("ISNULL(p.NOMENCLATURA , ISNULL(P.NOMBRE,'ISM'))", "Nomenclatura Proveedor", "1")
        campos.Rows.Add("dbo.CodigoEquipoCapital(e.IDEQUIPOPADRE,1)", "Código Equipo Padre", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(e.IDPERSONAASIGNADA)", "Nombre Persona Asignada", "1")
        campos.Rows.Add("dbo.IDPERSONAXIDENTIFICACION(e.IDPERSONAASIGNADA)", "Ver Custodias por C.C. Persona", "1")
        campos.Rows.Add("ma.NOMBRETIPOMARCA", "MARCA", "1")
        campos.Rows.Add("mo.NOMBRETIPOMODELO", "MODELO", "1")
        campos.Rows.Add("dbo.CodigoEquipoCapital(e.IDEQUIPO,2)", "Nombre, Código ó Nomenclatura TIPO", "1")
        campos.Rows.Add("dbo.CodigoEquipoCapital(e.IDEQUIPO,3)", "Nombre, Código ó Nomenclatura SUBTIPO", "1")
        campos.Rows.Add("bi.NOMBRE", "Nombre Bodega Ingreso", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(e.IDPERSONAINGRESO)", "Nombre Persona Ingreso", "1")
        campos.Rows.Add("e.FECHAINGRESO", "Fecha Ingreso", "3")
        'campos.Rows.Add("", "Nombre Bodega Registro", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(e.IDPERSONAREGISTRO)", "Nombre Persona Registro", "1")
        campos.Rows.Add("e.FECHAREGISTRO", "Fecha Registro", "3")
        campos.Rows.Add("dbo.Personanombrecompleto(e.IDPERSONAREGISTRO)", "Persona Registro", "1")
        campos.Rows.Add("e.IDARTICULO", "Código Artículo", "2")
        campos.Rows.Add("a.NOMBRE", "Nombre Artículo", "1")
        campos.Rows.Add("es.NOMBREESTADO", "Estado Actual", "1")
        campos.Rows.Add("euso.NOMBREESTADO", "Estado Uso Actual", "1")
        campos.Rows.Add("1", "Listar Dados de Baja", "4")
        campos.Rows.Add("1", " Asegurado", "4")
        frbuscar.campos = campos
        frbuscar.tabla = 16
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarActivosFijosFiltro(DSbusqueda)
                TablaCargada = "EQUIPOS"
                AplicarFormato()
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub

    Private Sub Nbi_EstadoUso_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EstadoUso.ItemClick
        If RevisarMantenimientosPendientes(Dgv_Equipos.CurrentRow.Cells("IDEQUIPO").Value) = True Then
            MsgBox("Este equipo tiene mantenimiento externo pendiente de cierre o anulación", MsgBoxStyle.Critical, "CERRAR MANTENIMIENTOS EXTERNOS")
            Exit Sub
        End If

        'If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDESTADO").Value <> 1 Then 'YA ESTA DADO DE BAJA
        '    MsgBox("El equipo debe estar almacenado en bodega, (Ubicación: EN BODEGA) para que se pueda cambiar el estado de uso", MsgBoxStyle.Critical, "No se puede cambiar el estado de uso.")
        '    Exit Sub
        'End If

        'Dim Historial As New DataTable
        'Historial = TryCast(Dgv_Historial.DataSource, System.Data.DataView).Table.Copy
        'For i As Integer = 0 To Historial.Rows.Count - 1
        '    If Historial.Rows(i).Item("ESTADO").ToString = "P" Then
        '        MsgBox("No se puede cambiar el estado de uso de un equipo que se encuentra en traslado")
        '        Exit Sub
        '    End If
        'Next

        Dim form As New FormularioCambioEstado
        form.Lb_Equipo.Text = Dgv_Equipos.CurrentRow.Cells("CODIGO").Value
        form.idequipomodificando = Dgv_Equipos.CurrentRow.Cells("IDEQUIPO").Value
        form.CargarListaEstados()
        form.ShowDialog()
    End Sub

    Private Sub Nbi_VerCaracteristicas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerCaracteristicas.ItemClick
        Dim CuAsociarActivoFijo As New FormulariosClasesBase.Cu_AsociarActivoFijo
        Dim IdEquipo As Integer = Dgv_Equipos.CurrentRow.Cells("IDEQUIPO").Value
        CuAsociarActivoFijo.MostrarCaracteristicas(IdEquipo)
    End Sub

    Private Sub Nbi_CrearRevisiónExterna_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearRevisiónExterna.ItemClick
        If Dgv_Equipos.Rows.Count = 0 Then
            MsgBox("No hay datos cargados o no existe ningún equipo registrado", MsgBoxStyle.Exclamation, "Advertencia")
            Exit Sub
        End If
        If RevisarMantenimientosPendientes(Dgv_Equipos.CurrentRow.Cells("IDEQUIPO").Value) = True Then
            MsgBox("Este equipo tiene mantenimiento externo pendiente de cierre o anulación", MsgBoxStyle.Critical, "CERRAR MANTENIMIENTOS EXTERNOS")
            Exit Sub
        End If
        If Dgv_Equipos.CurrentRow.Cells("IDESTADO").Value <> 1 Then
            MsgBox("El equipo debe estar en bodega para poder ser enviado a revisión externa", MsgBoxStyle.Critical, "CERRAR MANTENIMIENTOS EXTERNOS")
            Exit Sub
        End If
        Dim FrEnvioMantenimientoExterno As New FormulariosActivosFijos.Fr_EnvioMantenimientoExterno
        FrEnvioMantenimientoExterno.IdEquipo = Dgv_Equipos.CurrentRow.Cells("IDEQUIPO").Value
        FrEnvioMantenimientoExterno.TipoEdicion = 0
        FrEnvioMantenimientoExterno.IdMantenimientoModificando = -1
        FrEnvioMantenimientoExterno.CargarComponentesFormularios()
        FrEnvioMantenimientoExterno.ShowDialog()
        Cargar_Tabla()
    End Sub

    Private Sub Nbi_VerHojaVida_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerHojaVida.ItemClick
        If TablaCargada = "EQUIPOS" Then
            If Me.Dgv_Equipos.RowCount = 0 Then
                MsgBox("No hay datos cargados o no existe ningún equipo registrado", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If
            Dim id As Integer = Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDEQUIPO").Value
            Dim climpresiones As New ImpresiónMateriales.Cl_Impresión
            Dim Array As New ArrayList
            Array.Add(71)
            climpresiones.IDEQUIPOHOJADEVIDA = id
            climpresiones.FormatoImprimirMateriales(Array, True, False)
        End If
    End Sub

    Private Sub Nbi_ImprimirPazSalvo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirPazSalvo.ItemClick
        Dim FrImprimirPYS As New Fr_ImprimirPazYSalvos
        FrImprimirPYS.ShowDialog()
    End Sub
#End Region 'Equipo

#Region "Administración"
    Private Sub Nbi_AdministrarTipos_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_AdministrarTipos.ItemClick
        Dim formadministrartipos As New FormulariosActivosFijos.Fr_TiposArticulos
        formadministrartipos.ShowDialog()
    End Sub

    Private Sub Nbi_RestaurarEquipo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RestaurarEquipo.ItemClick
        If Dgv_Equipos.RowCount = 0 Then
            MsgBox("No hay ningún equipo cargado")
            Exit Sub
        End If
        'revisar que el equipo este efectivamente en estado dado de baja
        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDESTADO").Value <> 8 Then 'no esta dado de baja
            MsgBox("Este Equipo no esta dado de baja", MsgBoxStyle.Critical, "no se puede dar de baja")
            Exit Sub
        Else
            'revisar que haya espacio en stock para que si se restaura no se exceda la cantidad de artículos disponibles
            Dim dsDisponibles As New DataSet
            Try
                Dim idarticulo As Integer
                idarticulo = Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDARTICULO").Value
                dsDisponibles = bddatos.ModificarEquipos(29, 0, idarticulo, 0, 0, 0, 0, 0, 0, 0, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, 0, 0, "", "", "", "", False, Date.Now)
                If dsDisponibles.Tables(0).Rows.Count = 0 Then
                    'no hay existencias del artículo mencionado
                    MsgBox("Este Equipo no se encuentra en inventario, no se puede restaurar", MsgBoxStyle.Critical, "no stock")
                    Exit Sub
                Else
                    'existe un numero en stock
                    Dim stock As Integer = 0
                    Dim creados As Integer = 0
                    Dim total As Integer
                    stock = dsDisponibles.Tables(0).Rows(0)("STOCK")
                    creados = dsDisponibles.Tables(1).Rows(0)("CREADOS")
                    total = stock - creados
                    If total <= 0 Then
                        MsgBox("No se pueden agregar más artículos de este tipo ya que el límite de stock es de: " + stock.ToString + " y ya hay: " + creados.ToString + " Existencias creadas", MsgBoxStyle.Critical, "cantidad sobrepasada")
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MsgBox("Error al revisar cantidades de artículo dado de baja, contacte un administrador.")
                Exit Sub
            End Try
            Dim accion, efecto As String
            accion = "Restaurar de Baja"
            efecto = "Dado de Alta"
            CambiarEstado(accion, efecto, 1, False) 'cambiar estado a 1 ACTIVO
        End If
    End Sub
#End Region 'Administración

#Region "Traslados"
    Private Sub Nbi_PendientesEnviados_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_PendientesEnviados.ItemClick
        'mostrar en la tabla los registros de equipos pendientes de recepción enviados desde la bodega actual
        Dim idbodegaactual = VariablesBase.VariablesBase.IdBodegaActual
        Dim ds As New DataSet
        ds = bddatos.ModificarEquipos(16, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, idbodegaactual, 0, 0, "", "", "", "", False, Date.Now) 'estado 4 = P
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("Todos los Equipos enviados desde esta bodega han sido recibidos en sus destinos")
            Exit Sub
        End If
        Dgv_Equipos.DataSource = ds.Tables(0).DefaultView
        TablaCargada = "TRASLADOS"
        Lb_Titulo.Text = "EQUIPOS ENVIADOS PENDIENTES POR RECIBIR EN DESTINO"
    End Sub

    Private Sub Nbi_EnviadosRecibidos_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_EnviadosRecibidos.ItemClick
        'mostrar en la tabla los registros de equipos inactivos enviados desde la bodega actual
        Dim idbodegaactual = VariablesBase.VariablesBase.IdBodegaActual
        Dim ds As New DataSet
        ds = bddatos.ModificarEquipos(16, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, idbodegaactual, 0, 0, "", "", "", "", False, Date.Now) 'estado 5 = I
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("No se ha recibido nunca en ninguna bodega un Equipo despachado desde esta")
            Exit Sub
        End If
        Dgv_Equipos.DataSource = ds.Tables(0).DefaultView
        TablaCargada = "TRASLADOS"
        Lb_Titulo.Text = "EQUIPOS ENVIADOS RECIBIDOS EN DESTINO"
    End Sub

    Private Sub Nbi_PendientesRecibir_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_PendientesRecibir.ItemClick
        'mostrar en la tabla los registros de equipos enviados de otras bodegas a esta y pendientes de recibir
        Dim idbodegaactual = VariablesBase.VariablesBase.IdBodegaActual
        Dim ds As New DataSet
        ds = bddatos.ModificarEquipos(17, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, idbodegaactual, 0, 0, "", "", "", "", False, Date.Now) 'estado 4 = P
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("Esta Bodega no tiene equipos pendientes por recibir")
            Exit Sub
        End If
        Dgv_Equipos.DataSource = ds.Tables(0).DefaultView
        TablaCargada = "TRASLADOS"
        Lb_Titulo.Text = "EQUIPOS ENVIADOS DE OTRAS BODEGAS PENDIENTES POR RECIBIR"
    End Sub

    Private Sub NbiRecibidos_ItemClick(sender As System.Object, e As System.EventArgs) Handles Nbi_Recibidos.ItemClick
        'mostrar en la tabla los registros de equipos enviados de otras bodegas a esta alguna vez recibidos
        Dim idbodegaactual = VariablesBase.VariablesBase.IdBodegaActual
        Dim ds As New DataSet
        ds = bddatos.ModificarEquipos(17, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, idbodegaactual, 0, 0, "", "", "", "", False, Date.Now) 'estado 5 = I
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("Esta Bodega no ha recibido nunca un equipo de ninguna otra Bodega")
            Exit Sub
        End If
        Dgv_Equipos.DataSource = ds.Tables(0).DefaultView
        TablaCargada = "TRASLADOS"
        Lb_Titulo.Text = "EQUIPOS ENVIADOS DE OTRAS BODEGAS RECIBIDOS EN ESTA"
    End Sub
#End Region 'Traslados

#Region "Revisión Externa"
    Private Sub Nbi_CargarRevisionesExternas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarRevisionesExternas.ItemClick
        Cargar_Tabla_Revisiones_Externas()
    End Sub

    Private Sub Cargar_Tabla_Revisiones_Externas()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        'declaro la cadena de conexión
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarMantenimientoExterno"
            cmde.Parameters.AddWithValue("@accion", 5)
            cmde.Parameters.AddWithValue("@IDMANTENIMIENTOEXTERNO", -1)
            cmde.Parameters.AddWithValue("@IDEQUIPO", -1)
            cmde.Parameters.AddWithValue("@IDESTADOPARAUSOENVIO", 1)
            cmde.Parameters.AddWithValue("@IDCONTRATISTA", -1)
            cmde.Parameters.AddWithValue("@NOMBRE", "")
            cmde.Parameters.AddWithValue("@CODIGOCIUDAD", "")
            cmde.Parameters.AddWithValue("@FECHAENVIO", Date.Now)
            cmde.Parameters.AddWithValue("@DIRECCIONENVIO", "")
            cmde.Parameters.AddWithValue("@VALORESTIMADO", CDec("0,0"))
            cmde.Parameters.AddWithValue("@CODIGOTIPOMONEDA", 1)
            cmde.Parameters.AddWithValue("@IDSOLICITADOPOR", -1)
            cmde.Parameters.AddWithValue("@DESCRIPCION", "")
            cmde.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
            cmde.Parameters.AddWithValue("@IDPERSONAREGISTRA", -1)
            cmde.Parameters.AddWithValue("@IDPERSONAMODIFICA", -1)
            cmde.Parameters.AddWithValue("@FECHARECIBIDO", Date.Now)
            cmde.Parameters.AddWithValue("@VALORCIERRE", CDec("0,0"))
            cmde.Parameters.AddWithValue("@IDESTADOPARAUSORECIBIDO", 1)
            cmde.Parameters.AddWithValue("@OBSERVACION", "")
            cmde.Parameters.AddWithValue("@IDPERSONARECIBE", -1)
            cmde.Parameters.AddWithValue("@IDPERSONACIERRA", -1)
            cmde.Parameters.AddWithValue("@IDPERSONAANULA", -1)
            cmde.Parameters.AddWithValue("@OBERVACIONANULACION", "")
            cmde.Parameters.AddWithValue("@VALORASEGURADORA", CDec("0,0"))
            cmde.Parameters.AddWithValue("@IDPERSONAAPRUEBA", DBNull.Value)
            cmde.Parameters.AddWithValue("@TIPOENVIO", DBNull.Value)
            cmde.Parameters.AddWithValue("@FECHADESPACHO", DBNull.Value)
            cmde.Parameters.AddWithValue("@TRANSPORTADOR", DBNull.Value)
            cmde.Parameters.AddWithValue("@CELULAR", DBNull.Value)
            cmde.Parameters.AddWithValue("@PLACAVEHICULO", DBNull.Value)
            cmde.Parameters.AddWithValue("@EMPRESATRANSPORTADORA", DBNull.Value)
            cmde.Parameters.AddWithValue("@GUIA", DBNull.Value)
            cmde.Parameters.AddWithValue("@NOMBRERESPONSABLE", DBNull.Value)
            cmde.Parameters.AddWithValue("@FECHAMANTENIMIENTOEXTERNO", DBNull.Value)
            Dim msgParam As New SqlParameter("@IDMANTENIMIENTOEXTERNONUEVO", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            cmde.Parameters.Add(msgParam)
            da = New SqlClient.SqlDataAdapter(cmde)
            datas = New DataSet()
            da.Fill(datas)
            sqlconeccion.Close()

            'Dgv_Equipos.DataSource = Nothing

            Dgv_Equipos.DataSource = datas.Tables(0)

            Dgv_Equipos.Refresh()
            TablaCargada = "MANTENIMIENTOS"
            Lb_Titulo.Text = "MANTENIMIENTOS EXTERNOS"
            For i = 0 To Dgv_Equipos.ColumnCount - 1
                Select Case Dgv_Equipos.Columns(i).Name
                    Case "ID"
                        Dgv_Equipos.Columns(i).HeaderText = "Id Rev"
                        Dgv_Equipos.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                        Dgv_Equipos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Dgv_Equipos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case "EQUIPO"
                        Dgv_Equipos.Columns(i).HeaderText = "Cód"
                        Dgv_Equipos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Dgv_Equipos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Case "SERIE"
                        Dgv_Equipos.Columns(i).HeaderText = "Serie"
                        Dgv_Equipos.Columns(i).Width = 85
                    Case "SERVICIO"
                        Dgv_Equipos.Columns(i).HeaderText = "Servicio"
                        Dgv_Equipos.Columns(i).Width = 80
                    Case "FECHAENVIO"
                        Dgv_Equipos.Columns(i).HeaderText = "Fecha Envío"
                        Dgv_Equipos.Columns(i).Width = 84
                    Case "CONTRATISTA"
                        Dgv_Equipos.Columns(i).HeaderText = "Contratista"
                        Dgv_Equipos.Columns(i).Width = 53
                    Case "DIRECCION"
                        Dgv_Equipos.Columns(i).HeaderText = "Dirección"
                        Dgv_Equipos.Columns(i).Width = 53
                    Case "CIUDAD"
                        Dgv_Equipos.Columns(i).HeaderText = "Ciudad"
                        Dgv_Equipos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Case "CERRADA"
                        Dgv_Equipos.Columns(i).HeaderText = "Cer"
                        Dgv_Equipos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        Dgv_Equipos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case "ANULADA"
                        Dgv_Equipos.Columns(i).HeaderText = "Anu"
                        Dgv_Equipos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Dgv_Equipos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Case Else
                        Dgv_Equipos.Columns(i).Visible = False
                End Select
            Next
            If filtrocargado = False Then
                CargarFiltros()
                filtrocargado = True
            End If
            Me.Dgv_Equipos.Rows(0).Selected = True
            CargarListaSeleccion()
        Catch ex As Exception
            '   Throw New Exception(ex.Message)
        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()
        End Try
    End Sub

    Private Sub Nbi_VerRevisiónExterna_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerRevisiónExterna.ItemClick
        If TablaCargada = "MANTENIMIENTOS" Then
            EditarRevisiónExterna(1)
        End If
    End Sub

    Private Sub Nbi_EditarRevisiónExterna_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarRevisiónExterna.ItemClick
        If TablaCargada = "MANTENIMIENTOS" Then
            EditarRevisiónExterna(0)
            Cargar_Tabla_Revisiones_Externas()
        End If
    End Sub

    Private Sub EditarRevisiónExterna(ByVal Tipo As Integer) ' 0 editando, 1 Ver
        If TablaCargada = "MANTENIMIENTOS" Then
            'voy a editar un equipo existente, capturo el id del equipo seleccionado
            If Dgv_Equipos.Rows.Count = 0 Then
                MsgBox("No hay datos cargados o no existe ningún mantenimiento registrado", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            Else
                Dim formeditar As New FormulariosActivosFijos.Fr_EnvioMantenimientoExterno
                formeditar.Text = "Editar mantenimiento Existente"
                Select Case Tipo
                    Case 0 'Editar
                        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDBODEGA").Value <> VariablesBase.VariablesBase.IdBodegaActual Then
                            MsgBox("LAS REVISIONES EXTERNAS SOLO SE PUEDEN EDITAR EN LA BODEGA QUE SE GENERO")
                            Exit Sub
                        End If
                        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("ANULADA").Value = "S" Then
                            MsgBox("LAS REVISIONES EXTERNAS ANULADAS NO SE PUEDEN EDITAR")
                            Exit Sub
                        End If
                        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("CERRADA").Value = "S" Then
                            MsgBox("LAS REVISIONES EXTERNAS CERRADAS NO SE PUEDEN EDITAR")
                            Exit Sub
                        End If
                        formeditar.TipoEdicion = 1
                    Case 1 'Ver
                        formeditar.TipoEdicion = 4
                    Case 2 'cerrar
                        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDBODEGA").Value <> VariablesBase.VariablesBase.IdBodegaActual Then
                            MsgBox("LAS REVISIONES EXTERNAS SOLO SE PUEDEN CERRAR EN LA BODEGA QUE SE GENERO")
                            Exit Sub
                        End If
                        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("ANULADA").Value = "S" Then
                            MsgBox("LAS REVISIONES EXTERNAS ANULADAS NO SE PUEDEN CERRAR")
                            Exit Sub
                        End If
                        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("CERRADA").Value = "S" Then
                            MsgBox("LAS REVISIONES EXTERNAS CERRADAS NO SE PUEDEN CERRAR NUEVAMENTE")
                            Exit Sub
                        End If
                        formeditar.TipoEdicion = 2
                End Select
                Dim id As Integer = Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("ID").Value
                Dim indice As Integer = Dgv_Equipos.CurrentRow.Index
                formeditar.IdMantenimientoModificando = id
                formeditar.CargarComponentesFormularios()
                formeditar.Cargar_Datos_Editar_Ver()
                formeditar.ShowDialog()
                Cargar_Tabla_Revisiones_Externas()
                'seleccionar el articulo editado
                Try
                    Dgv_Equipos.CurrentCell = Me.Dgv_Equipos.Rows(indice).Cells(2)
                Catch ex As Exception

                End Try
            End If
        Else
            MsgBox("Debe cargar Revisiones Externas desde el Menú 'Revisión Externa'", MsgBoxStyle.OkOnly, "CARGAR REVISION EXTERNA")
        End If
    End Sub

    Private Sub Nbi_CerrarRevisiónExterna_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CerrarRevisiónExterna.ItemClick
        If TablaCargada = "MANTENIMIENTOS" Then
            EditarRevisiónExterna(2)
            Cargar_Tabla_Revisiones_Externas()
        End If
    End Sub

    Private Sub Nbi_AnularRevisiónExterna_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AnularRevisiónExterna.ItemClick
        If TablaCargada <> "MANTENIMIENTOS" Then
            Exit Sub
        End If
        If Me.Dgv_Equipos.RowCount = 0 Then
            MsgBox("No hay datos cargados o no existe ningún mantenimiento registrado", MsgBoxStyle.Exclamation, "Advertencia")
            Exit Sub
        End If
        Dim id As Integer = Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("ID").Value
        Dim idequipo As Integer = Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDEQUIPO").Value
        Dim indice As Integer = Dgv_Equipos.CurrentRow.Index
        If MsgBox("¿Seguro que desea ANULAR el servicio de revisión externa seleccionado", MsgBoxStyle.YesNo, "ANULAR") = MsgBoxResult.No Then
            Exit Sub
        End If
        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDBODEGA").Value <> VariablesBase.VariablesBase.IdBodegaActual Then
            MsgBox("LAS REVISIONES EXTERNAS SOLO SE PUEDEN ANULAR EN LA BODEGA QUE SE GENERO")
            Exit Sub
        End If
        If Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("CERRADA").Value = "S" Then
            MsgBox("LAS REVISIONES EXTERNAS CERRADOS NO SE PUEDEN ANULAR")
            Exit Sub
        End If
        Dim OBERVACIONANULACION As String
        OBERVACIONANULACION = Mid(InputBox("¿Motivo por el cual se anula el servicio de mantenimiento externo?", "OBSERVACION", ""), 1, 100)
        If Trim(OBERVACIONANULACION) <> "" Then
            'dejar el estado de uso como estaba antes del registro de la revisión
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            'declaro la cadena de conexión
            Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Try
                sqlconeccion.Open()
                cmde.Parameters.Clear()
                cmde.CommandType = CommandType.StoredProcedure
                cmde.Connection = sqlconeccion
                cmde.CommandText = "dbo.GestionarMantenimientoExterno"
                cmde.Parameters.AddWithValue("@accion", 3)
                cmde.Parameters.AddWithValue("@IDMANTENIMIENTOEXTERNO", id)
                cmde.Parameters.AddWithValue("@IDEQUIPO", idequipo)
                cmde.Parameters.AddWithValue("@IDESTADOPARAUSOENVIO", 1)
                cmde.Parameters.AddWithValue("@IDCONTRATISTA", -1)
                cmde.Parameters.AddWithValue("@NOMBRE", "")
                cmde.Parameters.AddWithValue("@CODIGOCIUDAD", "")
                cmde.Parameters.AddWithValue("@FECHAENVIO", Date.Now)
                cmde.Parameters.AddWithValue("@DIRECCIONENVIO", "")
                cmde.Parameters.AddWithValue("@VALORESTIMADO", CDec("0,0"))
                cmde.Parameters.AddWithValue("@CODIGOTIPOMONEDA", 1)
                cmde.Parameters.AddWithValue("@IDSOLICITADOPOR", -1)
                cmde.Parameters.AddWithValue("@DESCRIPCION", "")
                cmde.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                cmde.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
                cmde.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)
                cmde.Parameters.AddWithValue("@FECHARECIBIDO", Date.Now)
                cmde.Parameters.AddWithValue("@VALORCIERRE", CDec("0,0"))
                cmde.Parameters.AddWithValue("@IDESTADOPARAUSORECIBIDO", 1)
                cmde.Parameters.AddWithValue("@OBSERVACION", "")
                cmde.Parameters.AddWithValue("@IDPERSONARECIBE", -1)
                cmde.Parameters.AddWithValue("@IDPERSONACIERRA", -1)
                cmde.Parameters.AddWithValue("@IDPERSONAANULA", VariablesBase.VariablesBase.IdPersona)
                cmde.Parameters.AddWithValue("@OBERVACIONANULACION", OBERVACIONANULACION)
                cmde.Parameters.AddWithValue("@VALORASEGURADORA", CDec("0,0"))
                cmde.Parameters.AddWithValue("@IDPERSONAAPRUEBA", DBNull.Value)
                cmde.Parameters.AddWithValue("@TIPOENVIO", DBNull.Value)
                cmde.Parameters.AddWithValue("@FECHADESPACHO", DBNull.Value)
                cmde.Parameters.AddWithValue("@TRANSPORTADOR", DBNull.Value)
                cmde.Parameters.AddWithValue("@CELULAR", DBNull.Value)
                cmde.Parameters.AddWithValue("@PLACAVEHICULO", DBNull.Value)
                cmde.Parameters.AddWithValue("@EMPRESATRANSPORTADORA", DBNull.Value)
                cmde.Parameters.AddWithValue("@GUIA", DBNull.Value)
                cmde.Parameters.AddWithValue("@NOMBRERESPONSABLE", DBNull.Value)
                cmde.Parameters.AddWithValue("@FECHAMANTENIMIENTOEXTERNO", DBNull.Value)
                Dim msgParam As New SqlParameter("@IDMANTENIMIENTOEXTERNONUEVO", SqlDbType.Int, 1)
                msgParam.Direction = ParameterDirection.Output
                cmde.Parameters.Add(msgParam)
                da = New SqlClient.SqlDataAdapter(cmde)
                datas = New DataSet()
                da.Fill(datas)
                sqlconeccion.Close()
            Catch ex As Exception
            End Try
        End If
        If MsgBox("Se anuló el servicio de revisión externa seleccionado, ¿desea imprimir el soporte?", MsgBoxStyle.YesNo, "ANULADO") = MsgBoxResult.Yes Then
            Imprimir_revisionexterna(id)
        End If
        Cargar_Tabla_Revisiones_Externas()
    End Sub

    Private Sub Nbi_BuscarRevisiónExterna_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarRevisiónExterna.ItemClick
        'filtro nuevo, proveedor
        'abrir formulario        
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("dbo.SerieEquipo(ME.IDEQUIPO,1)", "Serie DEL EQUIPO", "1")
        campos.Rows.Add("dbo.CodigoEquipoCapital(ME.IDEQUIPO,1)", "Código DEL EQUIPO", "1")
        campos.Rows.Add("CC.IDENTIFICACION", "Identificación Proveedor", "1")
        campos.Rows.Add("ME.NOMBRE", "Nombre Proveedor", "1")
        campos.Rows.Add("ME.NROREMISION", "Numero de RE - Revisión Externa", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(ME.IDSOLICITADOPOR)", "Nombre Persona solicita", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(ME.IDPERSONAREGISTRA)", "Nombre Persona Registró", "1")
        campos.Rows.Add("dbo.Personanombrecompleto(ME.IDPERSONARECIBE)", "Nombre Persona Recibió", "1")
        campos.Rows.Add("dbo.CodigoEquipoCapital(ME.IDEQUIPO,2)", "Nombre, Código o Nomenclatura TIPO", "1")
        campos.Rows.Add("dbo.CodigoEquipoCapital(ME.IDEQUIPO,3)", "Nombre, Código o Nomenclatura SUBTIPO", "1")
        campos.Rows.Add("ME.FECHAENVIO", "Fecha Envío", "3")
        campos.Rows.Add("ME.FECHARECIBIDO", "Fecha Recibido", "3")
        campos.Rows.Add("ME.FECHACIERRE", "Fecha Cierre", "3")
        campos.Rows.Add("ME.FECHAANULACION", "Fecha Anulación", "3")
        campos.Rows.Add("EUE.NOMBREESTADO", "Tipo Servicio", "1")
        campos.Rows.Add("1", "Últimas 100 Cerradas", "4")
        campos.Rows.Add("2", "Últimas 100 Anuladas", "4")
        campos.Rows.Add("3", "Pendientes por Cerrar ", "4")
        frbuscar.campos = campos
        frbuscar.tabla = 17
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then
                CargarActivosFijosFiltro(DSbusqueda)
                TablaCargada = "MANTENIMIENTOS"
            Else
                MsgBox("Ningún Registro Encontrado")
            End If
        End If
    End Sub

    Private Sub Nbi_ImprimirRevisiónExterna_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirRevisiónExterna.ItemClick
        If TablaCargada = "MANTENIMIENTOS" Then
            If Me.Dgv_Equipos.RowCount = 0 Then
                MsgBox("No hay datos cargados o no existe ningún mantenimiento registrado", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If
            Dim id As Integer = Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("ID").Value
            Imprimir_revisionexterna(id)
        End If
    End Sub

    Private Sub Imprimir_revisionexterna(ByVal ID As Integer)
        If MsgBox("¿Desea imprimir la revisión externa?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
            Dim FrOpcionesImpresión As New ImpresiónMateriales.Fr_OpcionesImpresión
            FrOpcionesImpresión.Tipo = 2
            FrOpcionesImpresión.ID = ID
            FrOpcionesImpresión.Ck_Impresión1.Text = "Copia Destinatario"
            FrOpcionesImpresión.Ck_Impresión1.Checked = True
            FrOpcionesImpresión.Ck_Impresión2.Text = "Copia Transportador"
            FrOpcionesImpresión.Ck_Impresión2.Checked = True
            FrOpcionesImpresión.Ck_Impresión3.Text = "Copia Consecutivo"
            FrOpcionesImpresión.Ck_Impresión3.Checked = True
            FrOpcionesImpresión.Ck_Impresión4.Text = "Copia Portería de Salida"
            FrOpcionesImpresión.Ck_Impresión4.Checked = True
            FrOpcionesImpresión.Ck_Impresión5.Visible = False
            FrOpcionesImpresión.Ck_Impresión5.Checked = False
            FrOpcionesImpresión.ShowDialog()
        End If
    End Sub
#End Region 'Revisión Externa

#Region "Filtrar"
    Private Sub CargarFiltros()
        If Me.dt_opcionesfiltro1.Columns.Count = 0 Then
            Me.dt_opcionesfiltro1.Columns.Add("OPCION")
            Me.dt_opcionesfiltro2.Columns.Add("OPCION")
            Me.dt_opcionesfiltro3.Columns.Add("OPCION")
        End If
        Me.Cb_FiltrarPor1.DataSource = Me.dt_opcionesfiltro1
        Me.Cb_FiltrarPor1.DisplayMember = "OPCION"
        Me.Cb_FiltrarPor1.ValueMember = "OPCION"
        Me.Cb_FiltrarPor2.DataSource = Me.dt_opcionesfiltro2
        Me.Cb_FiltrarPor2.DisplayMember = "OPCION"
        Me.Cb_FiltrarPor2.ValueMember = "OPCION"
        Me.Cb_FiltrarPor3.DataSource = Me.dt_opcionesfiltro3
        Me.Cb_FiltrarPor3.DisplayMember = "OPCION"
        Me.Cb_FiltrarPor3.ValueMember = "OPCION"
        Me.dt_opcionesfiltro1.Rows.Clear()
        Me.dt_opcionesfiltro2.Rows.Clear()
        Me.dt_opcionesfiltro3.Rows.Clear()
        For i = 0 To Dgv_Equipos.ColumnCount - 1
            Dim filaopciónfiltro1 As DataRow
            Dim filaopciónfiltro2 As DataRow
            Dim filaopciónfiltro3 As DataRow
            filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
            filaopciónfiltro2 = dt_opcionesfiltro2.NewRow
            filaopciónfiltro3 = dt_opcionesfiltro3.NewRow
            filaopciónfiltro1("OPCION") = Dgv_Equipos.Columns(i).Name
            filaopciónfiltro2("OPCION") = Dgv_Equipos.Columns(i).Name
            filaopciónfiltro3("OPCION") = Dgv_Equipos.Columns(i).Name
            dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
            dt_opcionesfiltro2.Rows.Add(filaopciónfiltro2)
            dt_opcionesfiltro3.Rows.Add(filaopciónfiltro3)
        Next
    End Sub

    Private Sub Btn_Filtrar_Click(sender As System.Object, e As System.EventArgs) Handles Btn_Filtrar.Click
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            Dim Filtro As String = "000"
            Dim filtrovista As String = ""
            Dim nombrecolumna1 As String
            Dim nombrecolumna2 As String
            Dim nombrecolumna3 As String
            nombrecolumna1 = Me.Cb_FiltrarPor1.Text
            nombrecolumna2 = Me.Cb_FiltrarPor2.Text
            nombrecolumna3 = Me.Cb_FiltrarPor3.Text
            If Ck_Filtro1.Checked = True Then
                If Trim(Me.Tx_ValorFiltro1.Text) <> "" Then
                    Filtro = "1" + Mid(Filtro, 2, 2)
                    Select Case Dgv_Equipos.Columns(nombrecolumna1).ValueType
                        Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                            If IsNumeric(Trim(Me.Tx_ValorFiltro1.Text).ToString) = False Then
                                MsgBox("El valor del filtro 1 no corresponde con el tipo de dato", MsgBoxStyle.Critical, "Error del tipo de dato")
                                Exit Sub
                            End If
                    End Select
                End If
            End If
            If Ck_Filtro2.Checked = True Then
                If Trim(Me.Tx_ValorFiltro2.Text) <> "" Then
                    Filtro = Mid(Filtro, 1, 1) + "1" + Mid(Filtro, 3, 1)
                    Select Case Dgv_Equipos.Columns(nombrecolumna2).ValueType
                        Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                            If IsNumeric(Trim(Me.Tx_ValorFiltro2.Text).ToString) = False Then
                                MsgBox("El valor del filtro 2 no corresponde con el tipo de dato", MsgBoxStyle.Critical, "Error del tipo de dato")
                                Exit Sub
                            End If
                    End Select
                End If
            End If
            If Ck_Filtro3.Checked = True Then
                If Trim(Me.Tx_ValorFiltro3.Text) <> "" Then
                    Filtro = Mid(Filtro, 1, 2) + "1"
                    Select Case Dgv_Equipos.Columns(nombrecolumna3).ValueType
                        Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                            If IsNumeric(Trim(Me.Tx_ValorFiltro3.Text).ToString) = False Then
                                MsgBox("El valor del filtro 3 no corresponde con el tipo de dato", MsgBoxStyle.Critical, "Error del tipo de dato")
                                Exit Sub
                            End If
                    End Select
                End If
            End If
            'cargar tabla
            Dim vista As DataView
            vista = Dgv_Equipos.DataSource
            Select Case Filtro
                Case "000"
                    filtrovista = ""
                Case "100"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, Trim(Me.Tx_ValorFiltro1.Text).ToString)
                Case "110"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, nombrecolumna2, Trim(Me.Tx_ValorFiltro1.Text).ToString, Trim(Me.Tx_ValorFiltro2.Text).ToString)
                Case "111"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, nombrecolumna2, nombrecolumna3, Trim(Me.Tx_ValorFiltro1.Text).ToString, Trim(Me.Tx_ValorFiltro2.Text).ToString, Trim(Me.Tx_ValorFiltro3.Text).ToString)
                Case "010"
                    filtrovista = ConcatenarFiltro(nombrecolumna2, Trim(Me.Tx_ValorFiltro2.Text).ToString)
                Case "011"
                    filtrovista = ConcatenarFiltro(nombrecolumna2, nombrecolumna3, Trim(Me.Tx_ValorFiltro2.Text).ToString, Trim(Me.Tx_ValorFiltro3.Text).ToString)
                Case "001"
                    filtrovista = ConcatenarFiltro(nombrecolumna3, Trim(Me.Tx_ValorFiltro3.Text).ToString)
                Case "101"
                    filtrovista = ConcatenarFiltro(nombrecolumna1, nombrecolumna3, Trim(Me.Tx_ValorFiltro1.Text).ToString, Trim(Me.Tx_ValorFiltro3.Text).ToString)
            End Select
            vista.RowFilter = filtrovista
            Me.Dgv_Equipos.SuspendLayout()
            Me.Dgv_Equipos.DataSource = vista
            Me.Dgv_Equipos.ResumeLayout()
        Catch ex As Exception
            MsgBox("Ocurrió un inconveniente al procesar la instrucción", MsgBoxStyle.Critical, "Inconveniente")
        End Try
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub

    Private Function ConcatenarFiltro(ByVal Columna1 As String, ByVal Valor1 As String) As String
        Select Case Dgv_Equipos.Columns(Columna1).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                ConcatenarFiltro = String.Format("[" + Columna1 + "]" + "=" + Valor1)
                Exit Select
            Case Type.GetType("System.String")
                ConcatenarFiltro = String.Format("{0} like '%{1}%'", "[" + Columna1 + "]", Valor1)
                Exit Select
            Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                ConcatenarFiltro = ""
        End Select
    End Function

    Private Function ConcatenarFiltro(ByVal Columna1 As String, ByVal Columna2 As String, ByVal Valor1 As String, ByVal Valor2 As String) As String
        Select Case Dgv_Equipos.Columns(Columna1).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                Select Case Dgv_Equipos.Columns(Columna2).ValueType
                    'columna 1 decimal y columna 2 decimal
                    Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                        ConcatenarFiltro = String.Format("{0} = {1} AND {2} = {3}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                        'columna 1 decimal y columna 2 string
                    Case Type.GetType("System.String")
                        ConcatenarFiltro = String.Format("{0} = {1} AND {2} like '%{3}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                    Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                        ConcatenarFiltro = ""
                End Select
            Case Type.GetType("System.String")
                Select Case Dgv_Equipos.Columns(Columna2).ValueType
                    'columna 1 string y columna 2 decimal
                    Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                        ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} = {3}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                        'columna 1 string y columna 2 string
                    Case Type.GetType("System.String")
                        ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} like '%{3}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2)
                        Exit Function
                    Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                        ConcatenarFiltro = ""
                End Select
            Case Else ' Type.GetType("System.DateTime"), Type.GetType("System.Double"), Type.GetType("System.Byte[]")
                ConcatenarFiltro = ""
        End Select
    End Function

    Private Function ConcatenarFiltro(ByVal Columna1 As String, ByVal Columna2 As String, ByVal Columna3 As String, ByVal Valor1 As String, ByVal Valor2 As String, ByVal Valor3 As String) As String
        Dim tipocolumna1 As String
        Dim tipocolumna2 As String
        Dim tipocolumna3 As String
        Select Case Dgv_Equipos.Columns(Columna1).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                tipocolumna1 = "N"
            Case Type.GetType("System.String")
                tipocolumna1 = "S"
            Case Else
                ConcatenarFiltro = ""
                Exit Function
        End Select
        Select Case Dgv_Equipos.Columns(Columna2).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                tipocolumna2 = "N"
            Case Type.GetType("System.String")
                tipocolumna2 = "S"
            Case Else
                ConcatenarFiltro = ""
                Exit Function
        End Select
        Select Case Dgv_Equipos.Columns(Columna3).ValueType
            Case Type.GetType("System.Int32"), Type.GetType("System.Decimal"), Type.GetType("System.Int64")
                tipocolumna3 = "N"
            Case Type.GetType("System.String")
                tipocolumna3 = "S"
            Case Else
                ConcatenarFiltro = ""
                Exit Function
        End Select
        Select Case tipocolumna1 + tipocolumna2 + tipocolumna3
            Case "NNN"
                ConcatenarFiltro = String.Format("{0} = {1} AND {2} = {3} AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "NNS"
                ConcatenarFiltro = String.Format("{0} = {1} AND {2} = {3} AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "NSS"
                ConcatenarFiltro = String.Format("{0} = {1} AND {2} like '%{3}%' AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SSS"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} like '%{3}%' AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SSN"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND {2} like '%{3}%' AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SNN"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND  {2} = {3} AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "SNS"
                ConcatenarFiltro = String.Format("{0} like '%{1}%' AND  {2} = {3} AND {4} like '%{5}%'", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case "NSN"
                ConcatenarFiltro = String.Format("{0} = {1} AND  {2} like '%{3}%' AND {4} = {5}", "[" + Columna1 + "]", Valor1, "[" + Columna2 + "]", Valor2, "[" + Columna3 + "]", Valor3)
                Exit Function
            Case Else
                ConcatenarFiltro = ""
        End Select
    End Function
#End Region 'Filtrar

    Private Sub CambiarEstado(ByVal accion As String, ByVal efecto As String, ByVal idestado As Integer, ByVal por_lote As Boolean)
        'se puede pedir una justificación y guardarse en alguna tabla
        Dim Respuesta = MsgBox("¿Está Seguro de que desea " + accion + " el Equipo Seleccionado?, esta acción no se puede deshacer.", vbYesNo, accion + " Equipo")
        If Respuesta = vbYes Then
            Dim observacion As String
            observacion = InputBox("Escriba la Razón por la cual desea " + accion + " el equipo.", accion + " Equipo Capital", "")
            If observacion.Trim = "" Then
                MsgBox("Debe escribir una Justificación válida.", MsgBoxStyle.Critical, "justificación vacía")
                Exit Sub
            End If
            'Revisar si el equipo esta trasladándose de bodega
            Dim ds As New DataSet
            ds = bddatos.ModificarEntradasSalidas(15, 0, Dgv_Equipos.CurrentRow.Cells("IDEQUIPO").Value, 0, Date.Now, 0, Date.Now, "", 0, 0)
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("Este Equipo esta siendo trasladado a otra bodega, no puede ser " + efecto)
                Exit Sub
            End If
            'cambiar el estado y desasociar el equipo de los que tenga a asociados
            observacion = "-- " + Date.Now.ToShortDateString + " MOTIVO " + efecto.ToUpper + ": " + observacion
            If por_lote = True Then 'se desasocia de los padres y los hijos
                ds = bddatos.ModificarEquipos(15, 0, 0, Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDEQUIPO").Value, 0, 0, idestado, 0, 0, 0, 0, 0, 0, 0, 0, observacion, "", "", "", False, Date.Now)
                For i = 0 To (Dgv_Componentes.RowCount - 1)
                    ds = bddatos.ModificarEquipos(15, 0, 0, Me.Dgv_Componentes.Rows(i).Cells("IDCOMPONENTE").Value, 0, 0, idestado, 0, 0, 0, 0, 0, 0, 0, 0, observacion, "", "", "", False, Date.Now)
                Next
            Else 'solo se cambia el equipo seleccionado
                ds = bddatos.ModificarEquipos(15, 0, 0, Me.Dgv_Equipos.Rows(Dgv_Equipos.CurrentRow.Index).Cells("IDEQUIPO").Value, 0, 0, idestado, 0, 0, 0, 0, 0, 0, 0, 0, observacion, "", "", "", False, Date.Now)
            End If
            MsgBox("Equipo/s " + efecto)
            Cargar_Tabla()
        Else
            MsgBox("Equipo NO " + efecto)
        End If
    End Sub

    Private Sub CargarActivosFijosFiltro(ByVal ds As DataSet)
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Dgv_Equipos.DataSource = ds.Tables(0).DefaultView
        TablaCargada = "EQUIPOS"
        Lb_Titulo.Text = "INFORMACIÓN DE EQUIPOS"
        If filtrocargado = False Then
            CargarFiltros()
            filtrocargado = True
        End If
    End Sub

    Public Function RevisarMantenimientosPendientes(ByVal IDEQUIPO As Integer) As Boolean
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        'declaro la cadena de conexión
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarMantenimientoExterno"
            cmde.Parameters.AddWithValue("@accion", 9)
            cmde.Parameters.AddWithValue("@IDMANTENIMIENTOEXTERNO", -1)
            cmde.Parameters.AddWithValue("@IDEQUIPO", IDEQUIPO)
            cmde.Parameters.AddWithValue("@IDESTADOPARAUSOENVIO", 1)
            cmde.Parameters.AddWithValue("@IDCONTRATISTA", -1)
            cmde.Parameters.AddWithValue("@NOMBRE", "")
            cmde.Parameters.AddWithValue("@CODIGOCIUDAD", "")
            cmde.Parameters.AddWithValue("@FECHAENVIO", Date.Now)
            cmde.Parameters.AddWithValue("@DIRECCIONENVIO", "")
            cmde.Parameters.AddWithValue("@VALORESTIMADO", CDec("0,0"))
            cmde.Parameters.AddWithValue("@CODIGOTIPOMONEDA", 1)
            cmde.Parameters.AddWithValue("@IDSOLICITADOPOR", -1)
            cmde.Parameters.AddWithValue("@DESCRIPCION", "")
            cmde.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
            cmde.Parameters.AddWithValue("@IDPERSONAREGISTRA", -1)
            cmde.Parameters.AddWithValue("@IDPERSONAMODIFICA", -1)
            cmde.Parameters.AddWithValue("@FECHARECIBIDO", Date.Now)
            cmde.Parameters.AddWithValue("@VALORCIERRE", CDec("0,0"))
            cmde.Parameters.AddWithValue("@IDESTADOPARAUSORECIBIDO", 1)
            cmde.Parameters.AddWithValue("@OBSERVACION", "")
            cmde.Parameters.AddWithValue("@IDPERSONARECIBE", -1)
            cmde.Parameters.AddWithValue("@IDPERSONACIERRA", -1)
            cmde.Parameters.AddWithValue("@IDPERSONAANULA", -1)
            cmde.Parameters.AddWithValue("@OBERVACIONANULACION", "")
            cmde.Parameters.AddWithValue("@VALORASEGURADORA", CDec("0,0"))
            cmde.Parameters.AddWithValue("@IDPERSONAAPRUEBA", DBNull.Value)
            cmde.Parameters.AddWithValue("@TIPOENVIO", DBNull.Value)
            cmde.Parameters.AddWithValue("@FECHADESPACHO", DBNull.Value)
            cmde.Parameters.AddWithValue("@TRANSPORTADOR", DBNull.Value)
            cmde.Parameters.AddWithValue("@CELULAR", DBNull.Value)
            cmde.Parameters.AddWithValue("@PLACAVEHICULO", DBNull.Value)
            cmde.Parameters.AddWithValue("@EMPRESATRANSPORTADORA", DBNull.Value)
            cmde.Parameters.AddWithValue("@GUIA", DBNull.Value)
            cmde.Parameters.AddWithValue("@NOMBRERESPONSABLE", DBNull.Value)
            cmde.Parameters.AddWithValue("@FECHAMANTENIMIENTOEXTERNO", DBNull.Value)
            Dim msgParam As New SqlParameter("@IDMANTENIMIENTOEXTERNONUEVO", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            cmde.Parameters.Add(msgParam)
            da = New SqlClient.SqlDataAdapter(cmde)
            datas = New DataSet()
            da.Fill(datas)
            sqlconeccion.Close()
            If msgParam.Value > 0 Then
                RevisarMantenimientosPendientes = True
                Exit Function
            Else
                RevisarMantenimientosPendientes = False
                Exit Function
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
            RevisarMantenimientosPendientes = False
        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()
        End Try
    End Function

    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView)
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)

        With objHojaExcel
            .Name = ("Datos Exportados")
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 1
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, Dgv_Equipos.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  
                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    Private Sub Nbi_ImprimirStickerEquipo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirStickerEquipo.ItemClick
        Dim cantidad As Integer
        Dim InicioImp As Integer
        cantidad = InputBox("Indique la cantidad de Sticker's.", "Cantidad de Sticker's a Imprimir", "")
        InicioImp = InputBox("Indique el Inicio de la Impresión.", "Inicio Impresión", "")

        Dim clImpresion As New ImpresiónMateriales.Cl_Impresión
        clImpresion.Id = Me.Dgv_Equipos.SelectedRows(0).Cells("IDARTICULO").Value
        clImpresion.Codigo = Me.Dgv_Equipos.SelectedRows(0).Cells("CODIGO").Value
        clImpresion.IdEquipo = Me.Dgv_Equipos.SelectedRows(0).Cells("IDEQUIPO").Value
        clImpresion.Serie = Me.Dgv_Equipos.SelectedRows(0).Cells("SERIE").Value
        clImpresion.Cant = cantidad
        Dim formatos As New ArrayList
        formatos.Add(79)
        clImpresion.InicioImpresión = InicioImp
        clImpresion.FormatoImprimirMateriales(formatos, True, False)
    End Sub

    Private Sub Nbi_Asegurado_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Asegurado.ItemClick
        Dim IdEquipo As Integer = Dgv_Equipos.CurrentRow.Cells("IDEQUIPO").Value
        Dim Asegudaro As String = Dgv_Equipos.CurrentRow.Cells("ASEGURADO").Value
        Dim tipo As Integer
        If IsDBNull(Asegudaro) Or Asegudaro = "N" Or Asegudaro = "" Then

            If MsgBox("¿Desea asegurar el equipo al 100%", MsgBoxStyle.YesNo, "Asegurar") = MsgBoxResult.Yes Then
                tipo = 1
            Else
                Exit Sub
            End If

        ElseIf Asegudaro = "S" Then
            If MsgBox("El equipo seleccionado se encuentra asegurado ¿Desea desasegurar el equipo? ", MsgBoxStyle.YesNo, "Desasegurar") = MsgBoxResult.Yes Then
                tipo = 2
            Else
                Exit Sub
            End If
        End If

        Try
            Dim Comando As New SqlClient.SqlCommand("GestionarEquipoAsegurado")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@ACCION", tipo)
            Comando.Parameters.AddWithValue("@IDEQUIPO", IdEquipo)
            Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Try
                Comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conn.Close()
        Catch ex As Exception
        End Try
        Cargar_Tabla()
    End Sub
End Class 'Cu_ActivosFijos


#Region "FormularioCambioEstado"
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormularioCambioEstado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cb_ListaEstados = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tx_Observación = New System.Windows.Forms.TextBox()
        Me.Lb_Equipo = New System.Windows.Forms.Label()
        Me.Bt_Aceptar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Estado a Actualizar:"
        '
        'ComboBox1
        '
        Me.Cb_ListaEstados.FormattingEnabled = True
        Me.Cb_ListaEstados.Location = New System.Drawing.Point(114, 49)
        Me.Cb_ListaEstados.Name = "ComboBox1"
        Me.Cb_ListaEstados.Size = New System.Drawing.Size(208, 21)
        Me.Cb_ListaEstados.TabIndex = 1


        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Observación:"
        '
        'TextBox1
        '
        Me.Tx_Observación.Location = New System.Drawing.Point(10, 96)
        Me.Tx_Observación.MaxLength = 100
        Me.Tx_Observación.Multiline = True
        Me.Tx_Observación.Name = "Tx_Observación"
        Me.Tx_Observación.Size = New System.Drawing.Size(312, 53)
        Me.Tx_Observación.TabIndex = 3
        '
        'Label3
        '
        Me.Lb_Equipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Equipo.ForeColor = System.Drawing.Color.Blue
        Me.Lb_Equipo.Location = New System.Drawing.Point(12, 9)
        Me.Lb_Equipo.Name = "Lb_Equipo"
        Me.Lb_Equipo.Size = New System.Drawing.Size(310, 23)
        Me.Lb_Equipo.TabIndex = 4
        Me.Lb_Equipo.Text = "Lb_Equipo"
        Me.Lb_Equipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bt_Aceptar
        '
        Me.Bt_Aceptar.Location = New System.Drawing.Point(84, 155)
        Me.Bt_Aceptar.Name = "Bt_Aceptar"
        Me.Bt_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Aceptar.TabIndex = 5
        Me.Bt_Aceptar.Text = "Aceptar"
        Me.Bt_Aceptar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(179, 155)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 6
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 183)
        Me.Controls.Add(Me.Bt_Cancelar)
        Me.Controls.Add(Me.Bt_Aceptar)
        Me.Controls.Add(Me.Lb_Equipo)
        Me.Controls.Add(Me.Tx_Observación)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cb_ListaEstados)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(350, 222)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(350, 222)
        Me.Name = "Form1"
        Me.Text = "CAMBIAR DE ESTADO DE USO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cb_ListaEstados As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tx_Observación As System.Windows.Forms.TextBox
    Friend WithEvents Lb_Equipo As System.Windows.Forms.Label
    Friend WithEvents Bt_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button


    Public datas As New DataSet
    Public cmde As New SqlClient.SqlCommand
    Public da As New SqlClient.SqlDataAdapter
    Public idequipomodificando As Integer

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Me.Tx_Observación.Text.Length < 10 Then
            MsgBox("La observación debe tener entre 10 y 100 caracteres", MsgBoxStyle.Information, "OBSERVACIÓN")
            Exit Sub
        End If

        'declaro la cadena de conexión
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarEquipos"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = 35
            cmde.Parameters.Add("@idproveedor", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idarticulo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idequipo", SqlDbType.Int).Value = idequipomodificando
            cmde.Parameters.Add("@idtipo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idsubtipo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idestado", SqlDbType.Int).Value = Me.Cb_ListaEstados.SelectedValue
            cmde.Parameters.Add("@idequipopadre", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idbodegaingreso", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idpersonaingreso", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idpersonaregistro", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdPersona
            cmde.Parameters.Add("@idpersonaactual", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idmodelo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idmarca", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idbodega", SqlDbType.Int).Value = VariablesBase.VariablesBase.IdBodegaActual
            cmde.Parameters.Add("@descripcionequipo", SqlDbType.Text).Value = Me.Tx_Observación.Text
            cmde.Parameters.Add("@codigoismocol", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@codigoaccess", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@codigomecanico", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@activo", SqlDbType.Bit).Value = 0
            cmde.Parameters.Add("@fechaingreso", SqlDbType.Date).Value = Date.Now
            da = New SqlClient.SqlDataAdapter(cmde)
            datas = New DataSet()
            da.Fill(datas)
            sqlconeccion.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()
        End Try
        Me.Close()
    End Sub


    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Public Sub CargarListaEstados()
        'declaro la cadena de conexión
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)

        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarEquipos"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = 36
            cmde.Parameters.Add("@idproveedor", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idarticulo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idequipo", SqlDbType.Int).Value = idequipomodificando
            cmde.Parameters.Add("@idtipo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idsubtipo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idestado", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idequipopadre", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idbodegaingreso", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idpersonaingreso", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idpersonaregistro", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idpersonaactual", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idmodelo", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idmarca", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@idbodega", SqlDbType.Int).Value = 0
            cmde.Parameters.Add("@descripcionequipo", SqlDbType.Text).Value = ""
            cmde.Parameters.Add("@codigoismocol", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@codigoaccess", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@codigomecanico", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@activo", SqlDbType.Bit).Value = 0
            cmde.Parameters.Add("@fechaingreso", SqlDbType.Date).Value = Date.Now
            da = New SqlClient.SqlDataAdapter(cmde)
            datas = New DataSet()
            da.Fill(datas)
            sqlconeccion.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()
        End Try

        Me.Cb_ListaEstados.DataSource = datas.Tables(0)
        Me.Cb_ListaEstados.DisplayMember = "NOMBREESTADO"
        Me.Cb_ListaEstados.ValueMember = "IDESTADOPARAUSO"

    End Sub

End Class 'FormularioCambioEstado
#End Region 'FormularioCambioEstado

Public Class Pro_Equipo
    Private _IDEQUIPO As Integer
    Private _CODIGO As String
    Private _CODIGOISMOCOL As String
    Private _CODIGOACCESS As String
    Private _CODIGOMECANICO As String
    Private _ACTIVO_FIJO As Boolean
    Private _ESTADO As String
    Private _ESTADOUSO As String
    Private _PROVEEDOR As String
    Private _IDARTICULO As String
    Private _NOMBRE_ARTICULO As String
    Private _DESCRIPCION_ARTICULO As String
    Private _DESCRIPCION_ADICIONAL As String
    Private _VALOR_REFERENCIA As String
    Private _TIPO As String
    Private _SUBTIPO As String
    Private _BODEGA_INGRESO As String
    Private _FECHA_INGRESO As String
    Private _PERSONA_INGRESO As String
    Private _FECHA_REGISTRO As String
    Private _PERSONA_REGISTRO As String
    Private _PERSONA_ASIGNADA As String
    Private _SALIDA_CUSTODIA As String
    Private _FECHA_MODIFICO As String
    Private _PERSONA_MODIFICO As String
    Private _MODELO As String
    Private _MARCA As String
    Private _COMPONENTE_DE As String
    Private _SERIE As String
    Private _PLACA As String
    Private _ASEGURADO As String
    Private _FECHA_ASEGURADO As String
    Private _PERSONA_ASEGURO As String

    'IDENTIFICACIÓN DEL EQUIPO POR CÓDIGOS

    <Description("Identificación del Equipo en la Base de Datos"), _
    Category("Identificación Por Códigos"),
    DisplayNameAttribute("Id Equipo")> _
    Public ReadOnly Property IDEQUIPO() As String
        Get
            Return _IDEQUIPO
        End Get
    End Property

    <Description("Código de Equipo compuesto por TIPO-SUBTIPO-CONSECUTIVO"), _
    Category("Identificación Por Códigos"),
    DisplayNameAttribute("Código de Equipo ")> _
    Public ReadOnly Property CODIGO() As String
        Get
            Return _CODIGO
        End Get
    End Property

    <Description("Código Opcional ISMOCOL"), _
    Category("Identificación Por Códigos"),
    DisplayNameAttribute("Código ISMOCOL")> _
    Public ReadOnly Property CODIGOISMOCOL() As String
        Get
            Return _CODIGOISMOCOL
        End Get
    End Property

    <Description("Código Opcional del Sistema ACCESS"), _
    Category("Identificación Por Códigos"),
    DisplayNameAttribute("Código Access")> _
    Public ReadOnly Property CODIGOACCESS() As String
        Get
            Return _CODIGOACCESS
        End Get
    End Property

    <Description("Código Opcional MECANICO para identificación del equipo de Mantenimiento"), _
    Category("Identificación Por Códigos"),
    DisplayNameAttribute("Código Mecánico")> _
    Public ReadOnly Property CODIGOMECANICO() As String
        Get
            Return _CODIGOMECANICO
        End Get
    End Property

    <Description("Proveedor del Equipo "), _
    Category("Identificación Por Códigos"),
    DisplayNameAttribute("Proveedor")> _
    Public ReadOnly Property PROVEEDOR() As String
        Get
            Return _PROVEEDOR
        End Get
    End Property

    'INFORMACIÓN DEL ARTÍCULO AL QUE PERTENECE EL EQUIPO

    <Description("Id del Artículo al que pertenece el Equipo"), _
    Category("Información del Artículo"),
    DisplayNameAttribute("ID del Articulo")> _
    Public ReadOnly Property IDARTICULO() As String
        Get
            Return _IDARTICULO
        End Get
    End Property

    <Description("Nombre del Artículo al que pertenece el Equipo"), _
    Category("Información del Artículo"),
    DisplayNameAttribute("Nombre Artículo")> _
    Public ReadOnly Property NOMBRE_ARTICULO() As String
        Get
            Return _NOMBRE_ARTICULO
        End Get
    End Property

    <Description("Descripción del Artículo al que pertenece el Equipo"), _
    Category("Información del Artículo"),
    DisplayNameAttribute("Descripción Artículo")> _
    Public ReadOnly Property DESCRIPCION_ARTICULO() As String
        Get
            Return _DESCRIPCION_ARTICULO
        End Get
    End Property

    <Description("Valor de referencia del Artículo"), _
    Category("Información del Artículo"),
    DisplayNameAttribute("Valor Referencia")> _
    Public ReadOnly Property VALOR_REFERENCIA() As String
        Get
            Return _VALOR_REFERENCIA
        End Get
    End Property

    'ES COMPONENTE DE:
    <Description("Equipo al cual pertenece el equipo actual"), _
    Category("Información de Componentes"),
    DisplayNameAttribute("Es componente?")> _
    Public ReadOnly Property COMPONENTE_DE() As String
        Get
            Return _COMPONENTE_DE
        End Get
    End Property

    <Description("Estado en que se Encuentra el Equipo"), _
    Category("Información del Equipo"),
    DisplayNameAttribute("Estado Actual")> _
    Public ReadOnly Property ESTADO() As String
        Get
            Return _ESTADO
        End Get
    End Property

    <Description("Estado de uso en que se Encuentra el Equipo"), _
    Category("Información del Equipo"),
    DisplayNameAttribute("Estado Uso Actual")> _
    Public ReadOnly Property ESTADOUSO() As String
        Get
            Return _ESTADOUSO
        End Get
    End Property

    <Description("Persona asignada Actualmente al Equipo"), _
    Category("Información del Equipo"),
    DisplayNameAttribute("Persona Asignada")> _
    Public ReadOnly Property PERSONA_ASIGNADA() As String
        Get
            Return _PERSONA_ASIGNADA
        End Get
    End Property

    <Description("Salida de la custodia realizada al Equipo"), _
    Category("Información del Equipo"),
    DisplayNameAttribute("Salida de Custodia")> _
    Public ReadOnly Property SALIDA_CUSTODIA() As String
        Get
            Return _SALIDA_CUSTODIA
        End Get
    End Property

    <Description("Tipo de Artículo al que pertenece el Equipo"), _
    Category("Información del Equipo"),
    DisplayNameAttribute("Tipo")> _
    Public ReadOnly Property TIPO() As String
        Get
            Return _TIPO
        End Get
    End Property

    <Description("Subtipo de Artículo al que pertenece el Equipo"), _
    Category("Información del Equipo"),
    DisplayNameAttribute("Subtipo")> _
    Public ReadOnly Property SUBTIPO() As String
        Get
            Return _SUBTIPO
        End Get
    End Property

    <Description("Modelo del Equipo"), _
    Category("Información del Equipo"),
    DisplayNameAttribute("Modelo")> _
    Public ReadOnly Property MODELO() As String
        Get
            Return _MODELO
        End Get
    End Property

    <Description("Marca del Equipo"), _
    Category("Información del Equipo"),
    DisplayNameAttribute("Marca")> _
    Public ReadOnly Property MARCA() As String
        Get
            Return _MARCA
        End Get
    End Property


    <Description("Descripción adicional del Equipo"), _
    Category("Información del Equipo"),
    DisplayNameAttribute("Descripción adicional")> _
    Public ReadOnly Property DESCRIPCION_ADICIONAL() As String
        Get
            Return _DESCRIPCION_ADICIONAL
        End Get
    End Property


    <Description("Descripción adicional del Equipo"), _
    Category("Información del Equipo"),
    DisplayNameAttribute("Serie")> _
    Public ReadOnly Property SERIE() As String
        Get
            Return _SERIE
        End Get
    End Property

    <Description("Descripción adicional del Equipo"), _
    Category("Información del Equipo"),
    DisplayNameAttribute("Placa")> _
    Public ReadOnly Property PLACA() As String
        Get
            Return _PLACA
        End Get
    End Property


    'INFORMACIÓN DE INGRESO

    <Description("Bodega a la que ingresó el equipo por primera vez a la compañía"), _
    Category("Información de Ingreso a la Compañía"),
    DisplayNameAttribute("Bodega Ingreso")> _
    Public ReadOnly Property BODEGA_INGRESO() As String
        Get
            Return _BODEGA_INGRESO
        End Get
    End Property

    <Description("Fecha en la que ingresó el equipo a la compañía"), _
    Category("Información de Ingreso a la Compañía"),
    DisplayNameAttribute("Fecha Ingreso")> _
    Public ReadOnly Property FECHA_INGRESO() As String
        Get
            Return _FECHA_INGRESO
        End Get
    End Property

    <Description("Persona que recibió el equipo por primera vez"), _
    Category("Información de Ingreso a la Compañía"),
    DisplayNameAttribute("Persona Ingreso")> _
    Public ReadOnly Property PERSONA_INGRESO() As String
        Get
            Return _PERSONA_INGRESO
        End Get
    End Property

    'INFORMACIÓN DE ASEGURAMIENTO

    <Description("Indica si el equipo se encuentra asegurado el 100%"), _
    Category("Información de Aseguramiento"),
    DisplayNameAttribute("Asegurado")> _
    Public ReadOnly Property ASEGURADO() As String
        Get
            Return _ASEGURADO
        End Get
    End Property

    <Description("Fecha en la que se registra si el equipo esta asegurado el 100% o es desasegurado"), _
    Category("Información de Aseguramiento"),
    DisplayNameAttribute("Fecha Registro ")> _
    Public ReadOnly Property FECHA_ASEGURADO() As String
        Get
            Return _FECHA_ASEGURADO
        End Get
    End Property

    <Description("Persona que Registra si el equipo esta asegurado el 100% o es desasegurado"), _
    Category("Información de Aseguramiento"),
    DisplayNameAttribute("Persona Registo")> _
    Public ReadOnly Property PERSONA_ASEGURO() As String
        Get
            Return _PERSONA_ASEGURO
        End Get
    End Property
    'INFORMACION DE REGISTRO

    <Description("Fecha en la que se Registró el Equipo en el sistema"), _
    Category("Información de Registro en el Sistema"),
    DisplayNameAttribute("Fecha de Registro")> _
    Public ReadOnly Property FECHA_REGISTRO() As String
        Get
            Return _FECHA_REGISTRO
        End Get
    End Property
    <Description("Persona que Registró el Equipo en el sistema"), _
    Category("Información de Registro en el Sistema"),
    DisplayNameAttribute("Persona Registro")> _
    Public ReadOnly Property PERSONA_REGISTRO() As String
        Get
            Return _PERSONA_REGISTRO
        End Get
    End Property

    <Description("Fecha en la que se Modifico el Equipo en el sistema"), _
    Category("Información de Registro en el Sistema"),
    DisplayNameAttribute("Fecha de Modificación")> _
    Public ReadOnly Property FECHA_MODIFICO() As String
        Get
            Return _FECHA_MODIFICO
        End Get
    End Property
    <Description("Persona que Modificó el Equipo en el sistema"), _
    Category("Información de Registro en el Sistema"),
    DisplayNameAttribute("Persona Modifica")> _
    Public ReadOnly Property PERSONA_MODIFICO() As String
        Get
            Return _PERSONA_MODIFICO
        End Get
    End Property


    Public Sub New(ByVal FilaArticulo As DataRow)
        Me._IDEQUIPO = FilaArticulo("IDEQUIPO")
        Me._CODIGO = FilaArticulo("CODIGO")
        Me._ACTIVO_FIJO = FilaArticulo("ACTIVO_FIJO")
        Me._ESTADO = FilaArticulo("ESTADO")
        Me._ESTADOUSO = FilaArticulo("ESTADO USO")
        Me._PROVEEDOR = FilaArticulo("PROVEEDOR")
        Me._IDARTICULO = FilaArticulo("IDARTICULO")
        Me._NOMBRE_ARTICULO = FilaArticulo("NOMBRE_ARTICULO")
        Me._DESCRIPCION_ARTICULO = FilaArticulo("DESCRIPCION_ARTICULO")
        Me._DESCRIPCION_ADICIONAL = FilaArticulo("DESCRIPCION_ADICIONAL")
        If Not IsDBNull(FilaArticulo("VALOR_REFERENCIA")) Then
            _VALOR_REFERENCIA = Format(FilaArticulo("VALOR_REFERENCIA"), "C0")
        Else
            _VALOR_REFERENCIA = ""
        End If
        Me._TIPO = FilaArticulo("TIPO")
        Me._SUBTIPO = FilaArticulo("SUBTIPO")
        Me._BODEGA_INGRESO = FilaArticulo("BODEGA_INGRESO")
        If DBNull.Value.Equals(FilaArticulo("FECHA_INGRESO")) Then
            Me._FECHA_INGRESO = "NO REGISTRA"
        Else
            Me._FECHA_INGRESO = FilaArticulo("FECHA_INGRESO")
        End If
        Me._PERSONA_INGRESO = FilaArticulo("PERSONA_INGRESO")
        Me._FECHA_REGISTRO = FilaArticulo("FECHA_REGISTRO")
        Me._PERSONA_REGISTRO = FilaArticulo("PERSONA_REGISTRO")
        If DBNull.Value.Equals(FilaArticulo("PERSONA_ASIGNADA")) Then
            Me._PERSONA_ASIGNADA = "NINGUNA PERSONA ASIGNADA"
        Else
            Me._PERSONA_ASIGNADA = FilaArticulo("PERSONA_ASIGNADA")
        End If
        If DBNull.Value.Equals(FilaArticulo("SALIDA_ALMACEN")) Then
            Me._SALIDA_CUSTODIA = ""
        Else
            Me._SALIDA_CUSTODIA = FilaArticulo("SALIDA_ALMACEN")
        End If
        If DBNull.Value.Equals(FilaArticulo("FECHA_MODIFICA")) Then
            Me._FECHA_MODIFICO = ""
        Else
            Me._FECHA_MODIFICO = FilaArticulo("FECHA_MODIFICA")
        End If
        If DBNull.Value.Equals(FilaArticulo("PERSONA_MODIFICA")) Then
            Me._PERSONA_MODIFICO = ""
        Else
            Me._PERSONA_MODIFICO = FilaArticulo("PERSONA_MODIFICA")
        End If
        Me._MODELO = FilaArticulo("MODELO")
        Me._MARCA = FilaArticulo("MARCA")
        Me._CODIGOISMOCOL = FilaArticulo("CODIGOISMOCOL")
        Me._CODIGOACCESS = FilaArticulo("CODIGOACCESS")
        Me._CODIGOMECANICO = FilaArticulo("CODIGOMECANICO")
        If FilaArticulo("COMPONENTE_DE") = "0" Then
            Me._COMPONENTE_DE = "NO ES COMPONENTE"
        Else
            Me._COMPONENTE_DE = FilaArticulo("NOMBREPADRE")
        End If
        If IsDBNull(FilaArticulo("SERIE")) = False Then
            Me._SERIE = FilaArticulo("SERIE")
        Else
            Me._SERIE = ""
        End If
        If IsDBNull(FilaArticulo("PLACA")) = False Then
            Me._PLACA = FilaArticulo("PLACA")
        Else
            Me._PLACA = ""
        End If
        If IsDBNull(FilaArticulo("ASEGURADO")) = False Then
            Me._ASEGURADO = FilaArticulo("ASEGURADO")
        Else
            Me._ASEGURADO = ""
        End If
        If IsDBNull(FilaArticulo("FECHAASEGURADOEQUIPO")) = False Then
            Me._FECHA_ASEGURADO = FilaArticulo("FECHAASEGURADOEQUIPO")
        Else
            Me._FECHA_ASEGURADO = ""
        End If
        If IsDBNull(FilaArticulo("PERSONAASEGURAEQUIPO")) = False Then
            Me._PERSONA_ASEGURO = FilaArticulo("PERSONAASEGURAEQUIPO")
        Else
            Me._PERSONA_ASEGURO = ""
        End If

    End Sub

End Class 'Pro_Equipo

Public Class Pro_RevisiónExterna
    Private _ID As Integer
    Private _EQUIPO As String
    Private _SERIE As String
    Private _SERVICIO As String
    Private _FECHAENVIO As String
    Private _FECHAREGISTRO As String
    Private _FECHAMODIFICACION As String
    Private _FECHACIERRE As String
    Private _FECHARECIBIDO As String
    Private _FECHAANULACION As String
    Private _IDENTIFICACION As String
    Private _CONTRATISTA As String
    Private _DIRECCION As String
    Private _CIUDAD As String
    Private _CERRADA As String
    Private _ANULADA As String
    Private _IDEQUIPO As String
    Private _BODEGA As String
    Private _REGISTRA As String
    Private _MODIFICA As String
    Private _RECIBE As String
    Private _CIERRA As String
    Private _ANULA As String
    Private _REMISION As String
    Private _VALORESTIMADO As String
    Private _VALORCIERRE As String
    Private _NOMBRETIPOMONEDA As String
    Private _ESTADOUSORECIBIDO As String
    Private _TipoEnvio As String
    Private _FechaDespacho As String
    Private _Transportador As String
    Private _CelularTransportador As String
    Private _PlacaVehiculo As String
    Private _EmpresaTransportadora As String
    Private _Guia As String
    Private _NombreResponsable As String

    <Description("Identificación de la revisión Externa"), _
    Category("1. Identificación Por Códigos"),
    DisplayNameAttribute("Id Revisión Externa")> _
    Public ReadOnly Property ID() As Integer
        Get
            Return _ID
        End Get
    End Property

    <Description("Código de Equipo compuesto por TIPO-SUBTIPO-CONSECUTIVO"), _
    Category("1. Identificación Por Códigos"),
    DisplayNameAttribute("Código de Equipo")> _
    Public ReadOnly Property EQUIPO() As String
        Get
            Return _EQUIPO
        End Get
    End Property

    <Description("Id de Equipo"), _
    Category("1. Identificación Por Códigos"),
    DisplayNameAttribute("Id de Equipo")> _
    Public ReadOnly Property IDEQUIPO() As String
        Get
            Return _IDEQUIPO
        End Get
    End Property

    <Description("Serial de Equipo compuesto por TIPO-SUBTIPO-CONSECUTIVO"), _
    Category("1. Identificación Por Códigos"),
    DisplayNameAttribute("Código de Equipo ")> _
    Public ReadOnly Property SERIE() As String
        Get
            Return _SERIE
        End Get
    End Property

    <Description("Tipo de servicio de revisión Externa"), _
    Category("2. Servicio"),
    DisplayNameAttribute("Tipo Servicio")> _
    Public ReadOnly Property SERVICIO() As String
        Get
            Return _SERVICIO
        End Get
    End Property

    <Description("Fecha de Servicio de Revisión Externo"), _
    Category("2. Servicio"),
    DisplayNameAttribute("Fecha de Servicio")> _
    Public ReadOnly Property FECHAENVIO() As String
        Get
            Return _FECHAENVIO
        End Get
    End Property

    <Description("Contratista de Revisión Externo"), _
    Category("2. Servicio"),
    DisplayNameAttribute("Contratista")> _
    Public ReadOnly Property CONTRATISTA() As String
        Get
            Return _CONTRATISTA
        End Get
    End Property

    <Description("NIT Contratista de Revisión Externo"), _
    Category("2. Servicio"),
    DisplayNameAttribute("NIT Contratista")> _
    Public ReadOnly Property IDENTIFICACION() As String
        Get
            Return _IDENTIFICACION
        End Get
    End Property

    <Description("Dirección del contratista de Revisión Externo"), _
    Category("2. Servicio"),
    DisplayNameAttribute("Dirección del contratista")> _
    Public ReadOnly Property DIRECCION() As String
        Get
            Return _DIRECCION
        End Get
    End Property

    <Description("Ciudad del contratista de Revisión Externo"), _
    Category("2. Servicio"),
    DisplayNameAttribute("Ciudad del contratista")> _
    Public ReadOnly Property CIUDAD() As String
        Get
            Return _CIUDAD
        End Get
    End Property

    <Description("Valor estimado de la Revisión Externo"), _
    Category("2. Servicio"),
    DisplayNameAttribute("Valor estimado")> _
    Public ReadOnly Property VALORESTIMADO() As String
        Get
            Return _VALORESTIMADO
        End Get
    End Property

    <Description("Tipo Moneda de la Revisión Externo"), _
    Category("2. Servicio"),
    DisplayNameAttribute("Tipo Moneda")> _
    Public ReadOnly Property NOMBRETIPOMONEDA() As String
        Get
            Return _NOMBRETIPOMONEDA
        End Get
    End Property

    <Description("Bodega solicita la Revisión Externo"), _
    Category("2. Servicio"),
    DisplayNameAttribute("Bodega solicita")> _
    Public ReadOnly Property BODEGA() As String
        Get
            Return _BODEGA
        End Get
    End Property

    <Description("Remisión de la Revisión Externa"), _
    Category("3. Envío"),
    DisplayNameAttribute("Remisión")> _
    Public ReadOnly Property REMISION() As String
        Get
            Return _REMISION
        End Get
    End Property

    <Description("Tipo de envío del equipo a Revisión Externa"), _
    Category("3. Envío"),
    DisplayNameAttribute("Tipo de Envío")> _
    Public ReadOnly Property TipoEnvio() As String
        Get
            Return _TipoEnvio
        End Get
    End Property

    <Description("Fecha de despacho del equipo"), _
    Category("3. Envío"),
    DisplayNameAttribute("Fecha de Despacho")> _
    Public ReadOnly Property FechaDespacho As String
        Get
            Return _FechaDespacho
        End Get
    End Property

    <Description("Nombre del transportador"), _
    Category("3. Envío"),
    DisplayNameAttribute("Transportador")> _
    Public ReadOnly Property Transportador As String
        Get
            Return _Transportador
        End Get
    End Property

    <Description("Número de celular del transportador"), _
    Category("3. Envío"),
    DisplayNameAttribute("Celular")> _
    Public ReadOnly Property CelularTransportador As String
        Get
            Return _CelularTransportador
        End Get
    End Property

    <Description("Número de placa del vehículo transportador"), _
    Category("3. Envío"),
    DisplayNameAttribute("Placa Vehículo")> _
    Public ReadOnly Property PlacaVehiculo As String
        Get
            Return _PlacaVehiculo
        End Get
    End Property

    <Description("Nombre de la empresa transportadora"), _
    Category("3. Envío"),
    DisplayNameAttribute("Empresa Transportadora")> _
    Public ReadOnly Property EmpresaTransportadora As String
        Get
            Return _EmpresaTransportadora
        End Get
    End Property

    <Description("Número de guía del envío"), _
    Category("3. Envío"),
    DisplayNameAttribute("Guía")> _
    Public ReadOnly Property Guia As String
        Get
            Return _Guia
        End Get
    End Property

    <Description("Nombre del responsable del transporte"), _
    Category("3. Envío"),
    DisplayNameAttribute("Responsable")> _
    Public ReadOnly Property NombreResponsable As String
        Get
            Return _NombreResponsable
        End Get
    End Property

    <Description("Usuario que registra"), _
    Category("4. Usuario"),
    DisplayNameAttribute("Usuario que registra")> _
    Public ReadOnly Property REGISTRA() As String
        Get
            Return _REGISTRA
        End Get
    End Property

    <Description("Fecha Registro"), _
    Category("4. Usuario"),
    DisplayNameAttribute("Fecha Registro")> _
    Public ReadOnly Property FECHAREGISTRO() As String
        Get
            Return _FECHAREGISTRO
        End Get
    End Property

    <Description("Usuario que Modifica"), _
    Category("4. Usuario"),
    DisplayNameAttribute("Usuario que Modifica")> _
    Public ReadOnly Property MODIFICA() As String
        Get
            Return _MODIFICA
        End Get
    End Property

    <Description("Fecha Modifica"), _
    Category("4. Usuario"),
    DisplayNameAttribute("Fecha Modifica")> _
    Public ReadOnly Property FECHAMODIFICACION() As String
        Get
            Return _FECHAMODIFICACION
        End Get
    End Property

    <Description("Revisión Cerrada"), _
    Category("5. Cierre"),
    DisplayNameAttribute("Revisión Cerrada")> _
    Public ReadOnly Property CERRADA() As String
        Get
            Return _CERRADA
        End Get
    End Property

    <Description("Fecha que se registro el Cierre"), _
    Category("5. Cierre"),
    DisplayNameAttribute("Fecha Cierre")> _
    Public ReadOnly Property FECHACIERRE() As String
        Get
            Return _FECHACIERRE
        End Get
    End Property

    <Description("Usuario que Cerro"), _
    Category("5. Cierre"),
    DisplayNameAttribute("Usuario que Cerro")> _
    Public ReadOnly Property CIERRA() As String
        Get
            Return _CIERRA
        End Get
    End Property

    <Description("Persona que recibió el Equipo después de la revisión externa"), _
    Category("5. Cierre"),
    DisplayNameAttribute("Persona que Recibio")> _
    Public ReadOnly Property RECIBE() As String
        Get
            Return _RECIBE
        End Get
    End Property

    <Description("Fecha que se recibió el equipo después de la revisión externa"), _
    Category("5. Cierre"),
    DisplayNameAttribute("Fecha Recibido")> _
    Public ReadOnly Property FECHARECIBIDO() As String
        Get
            Return _FECHARECIBIDO
        End Get
    End Property

    <Description("Valor del cierre de la revisión externa"), _
    Category("5. Cierre"),
    DisplayNameAttribute("Valor del cierre")> _
    Public ReadOnly Property VALORCIERRE() As String
        Get
            Return _VALORCIERRE
        End Get
    End Property

    <Description("Estado de Uso depues del cierre"), _
    Category("5. Cierre"),
    DisplayNameAttribute("Estado de Uso Cierre")> _
    Public ReadOnly Property ESTADOUSORECIBIDO() As String
        Get
            Return _ESTADOUSORECIBIDO
        End Get
    End Property

    <Description("Anulada"), _
    Category("6. Anulación"),
    DisplayNameAttribute("Anulada")> _
    Public ReadOnly Property ANULADA() As String
        Get
            Return _ANULADA
        End Get
    End Property

    <Description("Usuario que anulo la revisión externa"), _
    Category("6. Anulación"),
    DisplayNameAttribute("Usuario que anulo")> _
    Public ReadOnly Property ANULA() As String
        Get
            Return _ANULA
        End Get
    End Property

    <Description("Fecha anulación de la revisión externa"), _
    Category("6. Anulación"),
    DisplayNameAttribute("Fecha anulación")> _
    Public ReadOnly Property FECHAANULACION() As String
        Get
            Return _FECHAANULACION
        End Get
    End Property


    Public Sub New(ByVal FilaRevisiónExterna As DataRow)
        Me._ID = FilaRevisiónExterna("ID")
        Me._EQUIPO = FilaRevisiónExterna("EQUIPO")
        If IsDBNull(FilaRevisiónExterna("SERIE")) = True Then
            Me._SERIE = ""
        Else
            Me._SERIE = FilaRevisiónExterna("SERIE")
        End If

        Me._SERVICIO = FilaRevisiónExterna("SERVICIO")
        Me._FECHAENVIO = FilaRevisiónExterna("FECHAENVIO")
        Me._FECHAREGISTRO = FilaRevisiónExterna("FECHAREGISTRO")
        Me._FECHAMODIFICACION = FilaRevisiónExterna("FECHAMODIFICACION")

        If IsDBNull(FilaRevisiónExterna("FECHACIERRE")) Then
            Me._FECHACIERRE = ""
        Else
            Me._FECHACIERRE = FilaRevisiónExterna("FECHACIERRE")
        End If

        If IsDBNull(FilaRevisiónExterna("FECHARECIBIDO")) Then
            Me._FECHARECIBIDO = ""
        Else
            Me._FECHARECIBIDO = FilaRevisiónExterna("FECHARECIBIDO")
        End If

        If IsDBNull(FilaRevisiónExterna("FECHAANULACION")) Then
            Me._FECHAANULACION = ""
        Else
            Me._FECHAANULACION = FilaRevisiónExterna("FECHAANULACION")
        End If

        Me._IDENTIFICACION = FilaRevisiónExterna("IDENTIFICACION")
        Me._CONTRATISTA = FilaRevisiónExterna("CONTRATISTA")
        Me._DIRECCION = FilaRevisiónExterna("DIRECCION")
        Me._CIUDAD = FilaRevisiónExterna("CIUDAD")
        Me._CERRADA = FilaRevisiónExterna("CERRADA")
        Me._ANULADA = FilaRevisiónExterna("ANULADA")
        Me._IDEQUIPO = FilaRevisiónExterna("IDEQUIPO")
        Me._BODEGA = FilaRevisiónExterna("BODEGA")
        Me._REGISTRA = FilaRevisiónExterna("REGISTRA")
        Me._MODIFICA = FilaRevisiónExterna("MODIFICA")
        If IsDBNull(FilaRevisiónExterna("RECIBE")) Then
            Me._RECIBE = ""
        Else
            Me._RECIBE = FilaRevisiónExterna("RECIBE")
        End If
        If IsDBNull(FilaRevisiónExterna("CIERRA")) Then
            Me._CIERRA = ""
        Else
            Me._CIERRA = FilaRevisiónExterna("CIERRA")
        End If
        If IsDBNull(FilaRevisiónExterna("ANULA")) Then
            Me._ANULA = ""
        Else
            Me._ANULA = FilaRevisiónExterna("ANULA")
        End If

        Me._REMISION = FilaRevisiónExterna("REMISION")
        Me._VALORESTIMADO = FilaRevisiónExterna("VALORESTIMADO")

        If IsDBNull(FilaRevisiónExterna("VALORCIERRE")) Then
            Me._VALORCIERRE = ""
        Else
            Me._VALORCIERRE = FilaRevisiónExterna("VALORCIERRE")
        End If

        Me._NOMBRETIPOMONEDA = FilaRevisiónExterna("NOMBRETIPOMONEDA")
        If IsDBNull(FilaRevisiónExterna("ESTADOUSORECIBIDO")) Then
            Me._ESTADOUSORECIBIDO = ""
        Else
            Me._ESTADOUSORECIBIDO = FilaRevisiónExterna("ESTADOUSORECIBIDO")
        End If
        If Not IsDBNull(FilaRevisiónExterna("TipoEnvio")) Then
            Select Case FilaRevisiónExterna("TipoEnvio")
                Case "E"
                    _TipoEnvio = "Exportación"
                Case "I"
                    _TipoEnvio = "Importación"
                Case "N"
                    _TipoEnvio = "No Aplica"
                Case Else
                    _TipoEnvio = ""
            End Select
        Else
            _TipoEnvio = ""
        End If
        If Not IsDBNull(FilaRevisiónExterna("FECHADESPACHO")) Then
            _FechaDespacho = FilaRevisiónExterna("FECHADESPACHO")
        Else
            _FechaDespacho = ""
        End If
        If Not IsDBNull(FilaRevisiónExterna("TRANSPORTADOR")) Then
            _Transportador = FilaRevisiónExterna("TRANSPORTADOR")
        Else
            _Transportador = ""
        End If
        If Not IsDBNull(FilaRevisiónExterna("CELULAR")) Then
            _CelularTransportador = FilaRevisiónExterna("CELULAR")
        Else
            _CelularTransportador = ""
        End If
        If Not IsDBNull(FilaRevisiónExterna("PLACAVEHICULO")) Then
            _PlacaVehiculo = FilaRevisiónExterna("PLACAVEHICULO")
        Else
            _PlacaVehiculo = ""
        End If
        If Not IsDBNull(FilaRevisiónExterna("EMPRESATRANSPORTADORA")) Then
            _EmpresaTransportadora = FilaRevisiónExterna("EMPRESATRANSPORTADORA")
        Else
            _EmpresaTransportadora = ""
        End If
        If Not IsDBNull(FilaRevisiónExterna("GUIA")) Then
            _Guia = FilaRevisiónExterna("GUIA")
        Else
            _Guia = ""
        End If
        If Not IsDBNull(FilaRevisiónExterna("NOMBRERESPONSABLE")) Then
            _NombreResponsable = FilaRevisiónExterna("NOMBRERESPONSABLE")
        Else
            _NombreResponsable = ""
        End If
    End Sub
End Class 'Pro_RevisiónExterna