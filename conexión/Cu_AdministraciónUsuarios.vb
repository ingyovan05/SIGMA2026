Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Public Class Cu_AdministraciónUsuarios

    Dim Index_Registro_Actual As Integer = -1

    Private Sub Ubicar_Registro()
        Try
            Me.Dgv_Usuarios.CurrentCell = Me.Dgv_Usuarios("IDPERSONADataGridViewTextBoxColumn", Index_Registro_Actual)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Comportamiento_Predeterminado()
        Me.Dgv_Usuarios.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Usuarios.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Nbc_Usuario.ActiveGroup = Me.Nbg_Usuario
        EstablecerModoNoEdición(True)
        TempTablaCopiarPegar.Columns.Add("CODIGOFUNCIONMODULO", Type.GetType("System.Int32"))
        TempTablaCopiarPegar.Columns.Add("TIENEPERMISO", Type.GetType("System.String"))
        Nbc_Usuario.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbc_Usuario.Tag)
        Nbg_Usuario.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Usuario.Tag)
        Nbg_Filtro.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Filtro.Tag)
        Nbi_NuevoUsuario.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_NuevoUsuario.Tag)
        Nbi_EditarUsuario.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarUsuario.Tag)
        Nbi_Desactivar.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Desactivar.Tag)
        Bt_GuardarPermisosTipoUsuario.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_GuardarPermisosTipoUsuario.Tag)
        NBGCC_Filtro.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(NBGCC_Filtro.Tag)

    End Sub

    Public datas As New DataSet
    Public cmde As New SqlClient.SqlCommand
    Public da As New SqlClient.SqlDataAdapter

    Public Sub Cargar_Tabla()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor

        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)

        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo._GestionarUsuario"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = 4
            cmde.Parameters.AddWithValue("@IDPERSONA", 1)
            cmde.Parameters.AddWithValue("@CODIGOTIPOUSUARIO", 1)
            cmde.Parameters.AddWithValue("@NOMBREUSUARIO", "")
            cmde.Parameters.AddWithValue("@CONTRASEÑA", "")
            cmde.Parameters.AddWithValue("@ESTADOUSUARIO", "")
            cmde.Parameters.AddWithValue("@CODIGOPERSONAINGRESA", VariablesBase.VariablesBase.IdPersona)
            cmde.Parameters.AddWithValue("@IDBODEGA", 1)
            cmde.Parameters.AddWithValue("@TELEFONOMOVILCORPORATIVO", "")
            cmde.Parameters.AddWithValue("@CORREOELECTRONICOCORPORTATIVO", "")
            cmde.Parameters.AddWithValue("@IDDEPENDENCIA", 1)
            Dim TablePERMISOS As New DataTable("PERMISOS")
            TablePERMISOS.Columns.Add("CODIGOFUNCIONMODULO")
            TablePERMISOS.Columns.Add("IDPERSONA")
            TablePERMISOS.Columns.Add("TIENEPERMISO")
            cmde.Parameters.AddWithValue("@TablePERMISOS", TablePERMISOS)
            Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            cmde.Parameters.Add(msgParam)
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

        '-- 0	20 USUARIOS
        '-- 1	MA_TIPOUSUARIO
        '-- 2	USU_FUNCION
        '-- 3	BODEGA
        '-- 4	SC_BASE
        '-- 5	SC_DEPENDENCIA

        TablaUsuarios = datas.Tables(0)

        Me.Dgv_Usuarios.DataSource = TablaUsuarios
        Lb_CantidadUsuario.Text = "Cantidad de Usuario: " + Me.Dgv_Usuarios.RowCount.ToString

        Cb_TipoUsuario.DataSource = datas.Tables(1)
        Cb_TipoUsuario.ValueMember = "CODIGOTIPOUSUARIO"
        Cb_TipoUsuario.DisplayMember = "NOMBRETIPOUSUARIO"

        Cb_Bodega.DataSource = datas.Tables(3)
        Me.Cb_Bodega.DisplayMember = "ABREVIATURA"
        Me.Cb_Bodega.ValueMember = "IDBODEGA"

        Me.Cb_Base.DataSource = datas.Tables(4)
        Me.Cb_Base.DisplayMember = "NOMBREBASE"
        Me.Cb_Base.ValueMember = "IDBASESISCONTROL"


        Dim TablaDependencias As New DataView(datas.Tables(5))
        TablaDependencias.RowFilter = "IDBASESISCONTROL=" + Cb_Base.SelectedValue.ToString


        Me.Cb_Dependencia.DataSource = TablaDependencias
        Me.Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
        Me.Cb_Dependencia.ValueMember = "IDDEPENDENCIA"

        Me.Tv_Permisos.SuspendLayout()


        If Me.dt_opcionesfiltro1.Columns.Count = 0 Then
            Me.dt_opcionesfiltro1.Columns.Add("OPCION")
        End If

        Me.ComboBox_Filtrar.DataSource = Me.dt_opcionesfiltro1
        Me.ComboBox_Filtrar.DisplayMember = "OPCION"
        Me.ComboBox_Filtrar.ValueMember = "OPCION"


        AplicarFormato()

        Me.Tv_Permisos.Nodes.Clear()
        Dim fila As DataRow
        For i = 0 To datas.Tables(2).Rows.Count - 1
            fila = datas.Tables(2).Rows(i)
            Dim nodohijo As New Windows.Forms.TreeNode
            nodohijo.ContextMenuStrip = Cm_MarcarDesmarcarTodos
            nodohijo.Text = fila("DESCRIPCION")
            nodohijo.Name = fila("CODIGOFUNCIONMODULO")
            If fila("CODIGOPADREFUNCIONMODULO") <> 0 Then
                'Se Declara una colección de nodos apartir de tu Treeview
                'del que se va a recorrer
                Dim nodes As Windows.Forms.TreeNodeCollection = Tv_Permisos.Nodes
                'Se recorren los nodos principales
                For Each n As Windows.Forms.TreeNode In nodes
                    If n.Name = fila("CODIGOPADREFUNCIONMODULO") Then
                        n.ContextMenuStrip = Cm_MarcarDesmarcarTodos
                        n.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
                        n.Nodes.Add(nodohijo)
                    End If
                    RecorrerNodos(n, fila("CODIGOPADREFUNCIONMODULO"), nodohijo)
                Next
            Else
                Me.Tv_Permisos.Nodes.Add(nodohijo)
                Me.Tv_Permisos.Nodes(0).NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            End If
        Next

        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub


    Dim dt_opcionesfiltro1 As New DataTable("OPCIONES")

    Private Sub AplicarFormato()

        Me.Dgv_Usuarios.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Dgv_Usuarios.ReadOnly = True
        Me.dt_opcionesfiltro1.Rows.Clear()
        Dim agregarfiltro As Boolean = False
        For i = 0 To Dgv_Usuarios.ColumnCount - 1
            Dgv_Usuarios.Columns(i).Visible = True
            Select Case Dgv_Usuarios.Columns(i).Name
                Case "IDPERSONA"
                    Dgv_Usuarios.Columns(i).HeaderText = "Id"
                    Dgv_Usuarios.Columns(i).Width = 50
                Case "ESTADO"
                    Dgv_Usuarios.Columns(i).HeaderText = "Est"
                    Dgv_Usuarios.Columns(i).Width = 20
                Case "IDENTIFICACION"
                    Dgv_Usuarios.Columns(i).HeaderText = "Identificación"
                    Dgv_Usuarios.Columns(i).Width = 100
                    agregarfiltro = True
                Case "NOMBREPERSONA"
                    Dgv_Usuarios.Columns(i).HeaderText = "Nombre Persona"
                    Dgv_Usuarios.Columns(i).Width = 200
                    agregarfiltro = True
                Case "NOMBREUSUARIO"
                    Dgv_Usuarios.Columns(i).HeaderText = "Usuario"
                    Dgv_Usuarios.Columns(i).Width = 100
                Case "CONTRASEÑA"
                    Dgv_Usuarios.Columns(i).HeaderText = "Contraseña"
                    Dgv_Usuarios.Columns(i).Width = 100
                Case "NOMBRETIPOUSUARIO"
                    Dgv_Usuarios.Columns(i).HeaderText = "Tipo"
                    Dgv_Usuarios.Columns(i).Width = 100
                Case "BODEGA"
                    Dgv_Usuarios.Columns(i).HeaderText = "Bodega"
                    Dgv_Usuarios.Columns(i).Width = 100
                    agregarfiltro = True
                Case "NOMBREBASE"
                    Dgv_Usuarios.Columns(i).HeaderText = "Base"
                    Dgv_Usuarios.Columns(i).Width = 100
                    agregarfiltro = True
                Case "NOMBREDEPENDENCIA"
                    Dgv_Usuarios.Columns(i).HeaderText = "Dependencia"
                    Dgv_Usuarios.Columns(i).Width = 100
                    agregarfiltro = True
                Case "TELEFONOMOVILCORPORATIVO"
                    Dgv_Usuarios.Columns(i).HeaderText = "Celular"
                    Dgv_Usuarios.Columns(i).Width = 100
                Case "CORREOELECTRONICOCORPORTATIVO"
                    Dgv_Usuarios.Columns(i).HeaderText = "Correo"
                    Dgv_Usuarios.Columns(i).Width = 100
                Case Else
                    Dgv_Usuarios.Columns(i).Visible = False
            End Select


            If agregarfiltro = True Then
                Dim filaopciónfiltro1 As DataRow
                filaopciónfiltro1 = dt_opcionesfiltro1.NewRow
                filaopciónfiltro1("OPCION") = Dgv_Usuarios.Columns(i).HeaderText
                dt_opcionesfiltro1.Rows.Add(filaopciónfiltro1)
                agregarfiltro = False
            End If

        Next

        Me.Pn_Contenedor.Height = CInt(Pn_Contenedor.Height / 1.5)
    End Sub

    Private Sub RecorrerNodos(ByVal treeNode As Windows.Forms.TreeNode,
                            ByVal NombrePadre As Integer,
                            ByVal nodohijo As Windows.Forms.TreeNode)
        Try
            For Each tn As Windows.Forms.TreeNode In treeNode.Nodes
                If tn.Name = NombrePadre Then
                    nodohijo.ContextMenuStrip = Cm_MarcarDesmarcarTodos
                    tn.Nodes.Add(nodohijo)
                    tn.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
                    Exit Sub
                End If
                RecorrerNodos(tn, NombrePadre, nodohijo)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Pn_Contenedor_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pn_Contenedor.Resize
        Pn_Superior.Height = Me.Pn_Contenedor.Height - 250
    End Sub

    Private Sub Ll_AjustarTabla_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_AjustarTabla.LinkClicked
        Me.Dgv_Usuarios.AutoResizeRows(Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)
    End Sub


    Public Sub CargarDatosUsuario()
        'Cargar los datos de usuario de la persona
        Dim filas() As DataRow
        filas = TablaUsuarios.Select("IDPERSONA=" + IDPERSONAMODIFICANDO.ToString)
        Dim fila As DataRow
        fila = filas(0)

        Me.TextBox_NombreUsuario.Text = FuncionesBase.FuncionesBase.Desencryptar(fila("NOMBREUSUARIO"))
        Me.TextBox_Contraseña.Text = FuncionesBase.FuncionesBase.Desencryptar(fila("CONTRASEÑA"))
        Me.Cb_TipoUsuario.SelectedValue = fila("CODIGOTIPOUSUARIO")
        Try
            Me.Cb_Bodega.SelectedValue = fila("IDBODEGA")
        Catch ex As Exception
            Me.Cb_Bodega.SelectedIndex = -1
        End Try

        Try
            Me.Cb_Base.SelectedValue = fila("IDBASESISCONTROL")
        Catch ex As Exception
            Me.Cb_Base.SelectedIndex = -1
        End Try

        Try
            Me.Cb_Dependencia.SelectedValue = fila("IDDEPENDENCIA")
        Catch ex As Exception
            Me.Cb_Dependencia.SelectedIndex = -1
        End Try

        If fila("ESTADO") = "A" Then
            RadioButton_UsuarioSi.Checked = True
        Else
            RadioButton_UsuarioNo.Checked = True
        End If
        Me.TextBox_CorreoElectrónico.Text = IIf(IsDBNull(fila("CORREOELECTRONICOCORPORTATIVO")) = True, "", fila("CORREOELECTRONICOCORPORTATIVO"))
        Me.TextBox_CorreoElectrónico.Text = Trim(Me.TextBox_CorreoElectrónico.Text)
        Me.TextBox_TeléfonoMóvil.Text = IIf(IsDBNull(fila("TELEFONOMOVILCORPORATIVO")) = True, "", fila("TELEFONOMOVILCORPORATIVO"))
        Me.TextBox_TeléfonoMóvil.Text = Trim(Me.TextBox_TeléfonoMóvil.Text)

    End Sub

    Dim adaptadorusuario As New Ds_UsuarioTableAdapters.USUARIOTableAdapter


    Private Function Validar_Datos_Usuario() As Boolean
        If RadioButton_UsuarioNo.Checked = False And RadioButton_UsuarioSi.Checked = False Then
            MsgBox("Debe seleccionar si la persona sera usuario del sistema", MsgBoxStyle.Critical, "Es Usuario")
            Validar_Datos_Usuario = False
            Exit Function
        End If
        If Me.RadioButton_UsuarioSi.Checked Then
            If Me.Cb_TipoUsuario.Text = "" Then
                MsgBox("Debe seleccionar un tipo de usuario", MsgBoxStyle.Critical, "Tipo de Usuario")
                Validar_Datos_Usuario = False
                Exit Function
            End If
            If Me.TextBox_NombreUsuario.Text = "" Then
                MsgBox("El nombre de usuario es obligatorio", MsgBoxStyle.Critical, "Nombre Usuario")
                Validar_Datos_Usuario = False
                Exit Function
            End If
            If Me.TextBox_Contraseña.Text = "" Then
                MsgBox("La clave de usuario es obligatoria", MsgBoxStyle.Critical, "Contraseóa de Usuario")
                Validar_Datos_Usuario = False
                Exit Function
            End If
            If Me.TextBox_NombreUsuario.Text.Length <> 10 Then
                MsgBox("El nombre de usuario debe ser de 10 caracteres", MsgBoxStyle.Critical, "Nombre Usuario")
                Validar_Datos_Usuario = False
                Exit Function
            End If
            If Me.TextBox_Contraseña.Text.Length <> 10 Then
                MsgBox("La clave de usuario debe ser de 10 caracteres", MsgBoxStyle.Critical, "Contraseóa de Usuario")
                Validar_Datos_Usuario = False
                Exit Function
            End If
            If Me.TextBox_NombreUsuario.Text.IndexOf(" ") <> -1 Then
                MsgBox("El nombre de usuario no puede contener espacios en blanco", MsgBoxStyle.Critical, "Nombre Usuario")
                Validar_Datos_Usuario = False
                Exit Function
            End If
            If Me.TextBox_Contraseña.Text.IndexOf(" ") <> -1 Then
                MsgBox("La clave de usuario no puede contener espacios en blanco", MsgBoxStyle.Critical, "Contraseóa de Usuario")
                Validar_Datos_Usuario = False
                Exit Function
            End If
            'Validar que no exista otra usuario con ese nombre de usuario
            'Dim adap As New Ds_UsuarioTableAdapters.USUARIOTableAdapter
            'If CInt(adap.EXISTENOMBREUSUARIO(FuncionesBase.FuncionesBase.Encryptar(Me.TextBox_NombreUsuario.Text))) <> 0 Then
            '    If Me.Cu_BuscarPersona1.Cb_Persona.Visible = False Then
            '        'Averiguar si el nombre de usuario es del registro que se esta editando
            '        If Me.Dgv_Usuarios.Rows(Dgv_Usuarios.CurrentRow.Index).Cells(4).Value <> FuncionesBase.FuncionesBase.Encryptar(4) Then
            '            MsgBox("Este nombre de usuario ya está registrado", MsgBoxStyle.Critical, "Nombre Usuario")
            '            Validar_Datos_Usuario = False
            '            Exit Function
            '        End If
            '    Else
            '        MsgBox("Este nombre de usuario ya está registrado", MsgBoxStyle.Critical, "Nombre Usuario")
            '        Validar_Datos_Usuario = False
            '        Exit Function
            '    End If
            'End If
            If Me.TextBox_CorreoElectrónico.Text <> "" Then
                If Not FuncionesBase.FuncionesBase.validarCorreoCorporativo(TextBox_CorreoElectrónico.Text) Then
                    MsgBox("El correo electrónico no cumple con el formato (ejemplo@ismocol.com) ó (ejemplo@zamoranacolombia.com).", MsgBoxStyle.Critical, "Correo Electrónico")
                    Validar_Datos_Usuario = False
                    Exit Function
                End If
            End If

        End If
        Validar_Datos_Usuario = True
    End Function


    Private Sub RadioButton_UsuarioSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RadioButton_UsuarioSi.Checked = True Then
            If TextBox_Contraseña.Text = "" Then
                TextBox_Contraseña.BackColor = Color.Salmon
            End If
            If TextBox_NombreUsuario.Text = "" Then
                TextBox_NombreUsuario.BackColor = Color.Salmon
            End If
        Else
            TextBox_Contraseña.BackColor = Color.White
            TextBox_NombreUsuario.BackColor = Color.White
        End If
    End Sub

    Private Sub Caja_Texto_GotFocus _
(ByVal sender As Object, ByVal e As System.EventArgs) _
Handles Cb_TipoUsuario.GotFocus
        Dim Objeto As Object = sender
        Objeto.backcolor = Color.MintCream
    End Sub

    Private Sub TextBox_PrimerNombre_LostFocus _
   (ByVal sender As Object, ByVal e As System.EventArgs) _
   Handles Cb_TipoUsuario.LostFocus
        Dim Objeto As Object = sender
        Objeto.backcolor = Color.White
        If sender.text = "" Then
            sender.backcolor = Color.Salmon
        End If
        'Marcar_Cajas_Vacias()
    End Sub

    Dim IDPERSONAMODIFICANDO As Integer
    Dim NOMBREPERSONA As String
    Dim adap As New Ds_UsuarioTableAdapters.USU_PERMISOTableAdapter
    Dim editando As Boolean = False
    Dim nuevo As Boolean = False
    Private Sub Nbi_EditarUsuario_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_EditarUsuario.ItemClick
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor

        Index_Registro_Actual = Me.Dgv_Usuarios.CurrentCell.RowIndex
        IDPERSONAMODIFICANDO = Me.Dgv_Usuarios.Rows(Dgv_Usuarios.CurrentRow.Index).Cells(0).Value
        NOMBREPERSONA = Me.Dgv_Usuarios.Rows(Dgv_Usuarios.CurrentRow.Index).Cells(3).Value
        editando = True
        nuevo = False

        Dim FotopersonaTableAdapter1 As New DatosPersona.Ds_PersonaTableAdapters.FOTOPERSONATableAdapter
        Dim Ds_Persona1 As New DatosPersona.Ds_Persona

        'Cargar Foto si Existe
        FotopersonaTableAdapter1.FillByIDPERSONA(Ds_Persona1.FOTOPERSONA, IDPERSONAMODIFICANDO)

        If Ds_Persona1.FOTOPERSONA.Rows.Count > 0 Then
            'Cargar Foto
            Dim Fila_FotoPersona As DataRow = Ds_Persona1.FOTOPERSONA.Rows(0)
            Try
                Dim byteBLOBData(-1) As [Byte]
                byteBLOBData = CType(Fila_FotoPersona("FOTO"), [Byte]())
                Dim stmBLOBData As New MemoryStream(byteBLOBData)
                Me.PictureBox_Foto_Persona.Image = Image.FromStream(stmBLOBData)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If


        adap.FillByIDPERSONA(Ds_Usuario1.USU_PERMISO, IDPERSONAMODIFICANDO)
        Me.Lb_Nombre.Text = NOMBREPERSONA
        CargarDatosUsuario()
        'Cargar permisos del arbol, la raiz primero
        Dim filas() As DataRow = Ds_Usuario1.USU_PERMISO.Select("CODIGOFUNCIONMODULO=" + Me.Tv_Permisos.Nodes(0).Name)
        If filas.Length > 0 Then
            Dim fila As DataRow = filas(0)
            Me.Tv_Permisos.Nodes(0).Checked = fila("TIENEPERMISO")
        Else
            Me.Tv_Permisos.Nodes(0).Checked = False
        End If
        Cargandoarbol = True
        CargarPermisosArbol(Me.Tv_Permisos.Nodes(0))
        Cargandoarbol = False
        Me.Cu_BuscarPersona1.Visible = False
        Me.Lb_Nombre.Visible = True
        EstablecerModoNoEdición(True)

        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default

    End Sub
    Dim Cargandoarbol As Boolean = False

    Private Sub CargarPermisosArbol(ByVal treeNode As Windows.Forms.TreeNode)

        For Each tn As Windows.Forms.TreeNode In treeNode.Nodes
            Dim filas() As DataRow = Ds_Usuario1.USU_PERMISO.Select("CODIGOFUNCIONMODULO=" + tn.Name)
            If filas.Length > 0 Then
                Dim fila As DataRow = filas(0)
                tn.Checked = fila("TIENEPERMISO")
            Else
                tn.Checked = False
            End If
            CargarPermisosArbol(tn)
        Next

    End Sub


    Private Sub ActualizarTablaPermisos(ByVal treeNode As Windows.Forms.TreeNode)
        For Each tn As Windows.Forms.TreeNode In treeNode.Nodes
            Dim filas() As DataRow = Ds_Usuario1.USU_PERMISO.Select("CODIGOFUNCIONMODULO=" + tn.Name)
            If filas.Length > 0 Then
                'Actualizar
                Dim fila As DataRow = filas(0)
                If tn.Checked = True Then
                    fila("TIENEPERMISO") = 1
                Else
                    fila("TIENEPERMISO") = 0
                End If
            Else
                ''Agregar
                Dim NuevaFila As DataRow
                NuevaFila = Ds_Usuario1.USU_PERMISO.NewRow
                NuevaFila("IDPERSONA") = IDPERSONAMODIFICANDO
                NuevaFila("CODIGOFUNCIONMODULO") = CInt(tn.Name)
                If tn.Checked = True Then
                    NuevaFila("TIENEPERMISO") = 1
                Else
                    NuevaFila("TIENEPERMISO") = 0
                End If
                Ds_Usuario1.USU_PERMISO.Rows.Add(NuevaFila)
            End If
            ActualizarTablaPermisos(tn)
        Next

    End Sub

    Private Sub Bt_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Guardar.Click


        If Validar_Datos_Usuario() = False Then
            MsgBox("Existen datos por verificar")
            Exit Sub
        End If


        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim Comando As New SqlCommand("dbo._GestionarUsuario", conexion)
        Comando.CommandType = CommandType.StoredProcedure

        If editando = True And nuevo = False Then
            Comando.Parameters.AddWithValue("@ACCION", 2)
        Else
            If Me.RadioButton_UsuarioNo.Checked = True Then
                MsgBox("Debe seleccionar la persona como usuario del sistema para agregarla")
                Exit Sub
            End If
            If Me.Cu_BuscarPersona1.Cb_Persona.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la persona que desea agregar como usuario")
                Exit Sub
            Else
                IDPERSONAMODIFICANDO = Cu_BuscarPersona1.Cb_Persona.SelectedValue
            End If
            Comando.Parameters.AddWithValue("@ACCION", 1)
        End If
        '*************************************MANEJO DE PERMISOS*********************************
        'Actualizar permisos, primero la raiz
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim filas() As DataRow = Ds_Usuario1.USU_PERMISO.Select("CODIGOFUNCIONMODULO=" + Me.Tv_Permisos.Nodes(0).Name)
        If filas.Length > 0 Then
            'Actualizar
            Dim fila As DataRow = filas(0)
            If Me.Tv_Permisos.Nodes(0).Checked = True Then
                fila("TIENEPERMISO") = 1
            Else
                fila("TIENEPERMISO") = 0
            End If
        Else
            ''Agregar
            Dim NuevaFila As DataRow
            NuevaFila = Ds_Usuario1.USU_PERMISO.NewRow
            NuevaFila("IDPERSONA") = IDPERSONAMODIFICANDO
            NuevaFila("CODIGOFUNCIONMODULO") = CInt(Me.Tv_Permisos.Nodes(0).Name)
            If Me.Tv_Permisos.Nodes(0).Checked = True Then
                NuevaFila("TIENEPERMISO") = 1
            Else
                NuevaFila("TIENEPERMISO") = 0
            End If
            Ds_Usuario1.USU_PERMISO.Rows.Add(NuevaFila)
        End If

        ActualizarTablaPermisos(Me.Tv_Permisos.Nodes(0))

        'Actualizar permisos BD
        Dim TablePERMISOS As New DataTable
        TablePERMISOS.Columns.Add("CODIGOFUNCIONMODULO")
        TablePERMISOS.Columns.Add("IDPERSONA")
        TablePERMISOS.Columns.Add("TIENEPERMISO")
        For i = 0 To Me.Ds_Usuario1.USU_PERMISO.Rows.Count - 1
            Dim filausuario As DataRow = Me.Ds_Usuario1.USU_PERMISO.Rows(i)
            Dim Fila As DataRow
            Fila = TablePERMISOS.NewRow
            Fila("CODIGOFUNCIONMODULO") = filausuario("CODIGOFUNCIONMODULO")
            Fila("IDPERSONA") = filausuario("IDPERSONA")
            Fila("TIENEPERMISO") = filausuario("TIENEPERMISO")
            TablePERMISOS.Rows.Add(Fila)
        Next
        '***************************************************************************************************************

        Comando.Parameters.AddWithValue("@IDPERSONA", IDPERSONAMODIFICANDO)
        Comando.Parameters.AddWithValue("@CODIGOTIPOUSUARIO", Me.Cb_TipoUsuario.SelectedValue)
        Comando.Parameters.AddWithValue("@NOMBREUSUARIO", FuncionesBase.FuncionesBase.Encryptar(Me.TextBox_NombreUsuario.Text))
        Comando.Parameters.AddWithValue("@CONTRASEÑA", FuncionesBase.FuncionesBase.Encryptar(Me.TextBox_Contraseña.Text))
        Comando.Parameters.AddWithValue("@ESTADOUSUARIO", IIf(RadioButton_UsuarioSi.Checked, "A", "I"))
        Comando.Parameters.AddWithValue("@CODIGOPERSONAINGRESA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@IDBODEGA", Me.Cb_Bodega.SelectedValue)
        Comando.Parameters.AddWithValue("@TELEFONOMOVILCORPORATIVO", Me.TextBox_TeléfonoMóvil.Text)
        Comando.Parameters.AddWithValue("@CORREOELECTRONICOCORPORTATIVO", Me.TextBox_CorreoElectrónico.Text)
        Comando.Parameters.AddWithValue("@IDDEPENDENCIA", Cb_Dependencia.SelectedValue)
        Comando.Parameters.AddWithValue("@TablePERMISOS", TablePERMISOS)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Try
            conexion.Open()
            Comando.ExecuteNonQuery()
            conexion.Close()

            Select Case Comando.Parameters("@IDMENSAJE").Value
                Case 0
                    MsgBox("No se pudo realizar la operación", MsgBoxStyle.Exclamation, "No se completo la operación")
                    Exit Sub
                Case 1
                    MsgBox("Se guardaron los cambios correctamente", MsgBoxStyle.Information, "Cambios Guardados")
                Case 2
                    MsgBox("Ya existe una persona con este usuario asociado", MsgBoxStyle.Information, "No se completo la operación")
                    Exit Sub
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try

        Me.Bt_Guardar.Enabled = False
        Me.Cargar_Tabla()
        EstablecerModoNoEdición(False)
        Me.Cu_BuscarPersona1.Visible = False
        Windows.Forms.Cursor.Current = Cursors.Default
        Ubicar_Registro()

    End Sub

    Private Sub Bt_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        EstablecerModoNoEdición(False)
        Me.Bt_Cancelar.Enabled = False
    End Sub

    Private Sub Dgv_Usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dgv_Usuarios.Click
        EstablecerModoNoEdición(False)
    End Sub

    Private Sub EstablecerModoNoEdición(ByVal Modo As Boolean)
        If Modo = False Then
            Me.Bt_Cancelar.Enabled = False
            Me.Bt_Guardar.Enabled = False
            Me.TextBox_NombreUsuario.Text = ""
            Me.TextBox_Contraseña.Text = ""
            Me.TextBox_TeléfonoMóvil.Text = ""
            Me.TextBox_CorreoElectrónico.Text = ""
            Me.Cb_TipoUsuario.SelectedIndex = -1
            Me.RadioButton_UsuarioNo.Enabled = False
            Me.RadioButton_UsuarioSi.Enabled = False
            Me.PictureBox_Foto_Persona.Image = Me.PictureBox_Foto_Persona.InitialImage
            Me.Lb_Nombre.Text = ""
            Me.Tv_Permisos.Enabled = False
            Me.Pn_TituloArbol.Enabled = False
            Me.Tv_Permisos.CollapseAll()
            Me.Bt_GuardarPermisosTipoUsuario.Enabled = False
            Me.Bt_Adicionar.Enabled = False
            Me.Bt_Asignar.Enabled = False
            Me.Cb_TipoUsuario.Enabled = False
            Cu_BuscarPersona1.Visible = False
            Me.Cb_Bodega.Enabled = False
            Me.Cb_Base.Enabled = False
            Me.Cb_Dependencia.Enabled = False
        Else
            Me.Bt_Cancelar.Enabled = True
            Me.Bt_Guardar.Enabled = True
            Me.Tv_Permisos.Enabled = True
            Me.Tv_Permisos.CollapseAll()
            Me.Pn_TituloArbol.Enabled = True
            Me.RadioButton_UsuarioNo.Enabled = True
            Me.RadioButton_UsuarioSi.Enabled = True
            Me.Bt_GuardarPermisosTipoUsuario.Enabled = True
            Me.Bt_Adicionar.Enabled = True
            Me.Bt_Asignar.Enabled = True
            Me.Cb_TipoUsuario.Enabled = True
            Me.Cb_Bodega.Enabled = True
            Me.Cb_Base.Enabled = True
            Me.Cb_Dependencia.Enabled = True
        End If
    End Sub

    Private Sub Lb_Contraer_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Lb_Contraer.LinkClicked
        Me.Tv_Permisos.CollapseAll()
    End Sub

    Private Sub Ll_Expandir_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_Expandir.LinkClicked
        Me.Tv_Permisos.ExpandAll()
    End Sub

    Private Sub Ll_Todos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_Todos.LinkClicked
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Cargandoarbol = True
        Me.Tv_Permisos.Nodes(0).Checked = True
        MarcarDesmarcarTodos(Me.Tv_Permisos.Nodes(0), True)
        Cargandoarbol = False
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub Ll_Ninguno_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_Ninguno.LinkClicked
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Cargandoarbol = True
        Me.Tv_Permisos.Nodes(0).Checked = False
        MarcarDesmarcarTodos(Me.Tv_Permisos.Nodes(0), False)
        Cargandoarbol = False
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub MarcarDesmarcarTodos(ByVal treeNode As Windows.Forms.TreeNode, ByVal valor As Boolean)
        For Each tn As Windows.Forms.TreeNode In treeNode.Nodes()
            tn.Checked = valor
            MarcarDesmarcarTodos(tn, valor)
        Next
    End Sub

    Dim TempTablaCopiarPegar As New DataTable("PERMISOS")

    Private Sub Ll_CopiarPermisos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_CopiarPermisos.LinkClicked
        Me.TempTablaCopiarPegar.Clear()
        Dim fila As DataRow
        fila = TempTablaCopiarPegar.NewRow
        fila("CODIGOFUNCIONMODULO") = Me.Tv_Permisos.Nodes(0).Name
        fila("TIENEPERMISO") = Me.Tv_Permisos.Nodes(0).Checked
        TempTablaCopiarPegar.Rows.Add(fila)
        Cargandoarbol = True
        CopiarPortaPermisos(Me.Tv_Permisos.Nodes(0))
        Cargandoarbol = False
    End Sub

    Private Sub CopiarPortaPermisos(ByVal treeNode As Windows.Forms.TreeNode)
        For Each tn As Windows.Forms.TreeNode In treeNode.Nodes()
            Dim fila As DataRow
            fila = TempTablaCopiarPegar.NewRow
            fila("CODIGOFUNCIONMODULO") = tn.Name
            fila("TIENEPERMISO") = tn.Checked
            TempTablaCopiarPegar.Rows.Add(fila)
            CopiarPortaPermisos(tn)
        Next
    End Sub

    Private Sub Ll_Pegar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_Pegar.LinkClicked
        Dim filas() As DataRow
        filas = TempTablaCopiarPegar.Select("CODIGOFUNCIONMODULO=" + Me.Tv_Permisos.Nodes(0).Name)
        If filas.Length > 0 Then
            Dim fila As DataRow = filas(0)
            Me.Tv_Permisos.Nodes(0).Checked = fila("TIENEPERMISO")
        End If
        Cargandoarbol = True
        PegarPortaPermisos(Me.Tv_Permisos.Nodes(0))
        Cargandoarbol = False
    End Sub

    Private Sub PegarPortaPermisos(ByVal treeNode As Windows.Forms.TreeNode)
        For Each tn As Windows.Forms.TreeNode In treeNode.Nodes()
            Dim filas() As DataRow
            filas = TempTablaCopiarPegar.Select("CODIGOFUNCIONMODULO=" + tn.Name)
            If filas.Length > 0 Then
                Dim fila As DataRow = filas(0)
                tn.Checked = fila("TIENEPERMISO")
            End If
            PegarPortaPermisos(tn)
        Next
    End Sub


    Private Sub Nbi_NuevoUsuario_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_NuevoUsuario.ItemClick
        nuevo = True
        editando = False
        IDPERSONAMODIFICANDO = -1
        Index_Registro_Actual = -1
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Me.EstablecerModoNoEdición(False)
        Me.EstablecerModoNoEdición(True)
        Me.Cu_BuscarPersona1.CargarDatos()
        Me.Cu_BuscarPersona1.Visible = True
        Me.Pn_TituloUsuario.Enabled = True
        Me.Lb_Nombre.Visible = False
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub

    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Try
            Dim filas() As DataRow
            filas = Cu_BuscarPersona1.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersona1.Tx_TextoCódigo.Text).ToString + "'")
            If filas.Length > 0 Then
                Dim fila As DataRow
                fila = filas(0)
                Me.Cu_BuscarPersona1.Cb_Persona.SelectedValue = fila("IDPERSONA")
            Else
                Me.Cu_BuscarPersona1.Cb_Persona.SelectedIndex = -1
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Nbi_Desactivar_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_Desactivar.ItemClick
        IDPERSONAMODIFICANDO = Me.Dgv_Usuarios.Rows(Dgv_Usuarios.CurrentRow.Index).Cells(0).Value
        Index_Registro_Actual = Me.Dgv_Usuarios.CurrentCell.RowIndex
        If MsgBox("¿Seguro que desea desactivar este usuario?", MsgBoxStyle.YesNo, "Desactivar") = MsgBoxResult.Yes Then
            adaptadorusuario.DESACTIVARUSUARIO(IDPERSONAMODIFICANDO)
        End If
        Ubicar_Registro()
    End Sub

    Private Sub Tb_Descripción_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tb_Descripción.TextChanged
        If Cb_Filtrar.Checked = True Then
            Timer1.Stop()
            Timer1.Interval = VariablesBase.VariablesBase.TiempoRespuestaBuscador
            Timer1.Start()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Dim vista As New DataView(TablaUsuarios)
        Me.Dgv_Usuarios.SuspendLayout()
        Me.Dgv_Usuarios.DataSource = vista
        Me.Dgv_Usuarios.ResumeLayout()
        Dim Columna As String = ""

        Select Case Me.ComboBox_Filtrar.SelectedValue
            Case "Identificación"
                Columna = "IDENTIFICACION"
            Case "Nombre Persona"
                Columna = "NOMBREPERSONA"
            Case "Bodega"
                Columna = "BODEGA"
            Case "Base"
                Columna = "NOMBREBASE"
            Case "Dependencia"
                Columna = "NOMBREDEPENDENCIA"
        End Select

        Try
            vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
        Catch ex As Exception
        End Try
        Lb_CantidadUsuario.Text = "Cantidad de Usuario: " + Me.Dgv_Usuarios.RowCount.ToString
    End Sub

    Private Sub Bt_Asignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Asignar.Click
        If Me.Cb_TipoUsuario.SelectedIndex <> -1 Then
            If MsgBox("¿Seguro que desea asignar los permisos de este tipo de usuario al usuario que esta editando?, los permisos actuales se quitaran.", MsgBoxStyle.YesNo, "Asignar Permisos") = vbYes Then
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Me.Tv_Permisos.Nodes(0).Checked = False
                MarcarDesmarcarTodos(Me.Tv_Permisos.Nodes(0), False)
                Dim adap As New Ds_UsuarioTableAdapters.USU_PERMISOXTIPOUSUARIOTableAdapter
                adap.FillByCODIGOTIPOUSUARIO(Ds_Usuario1.USU_PERMISOXTIPOUSUARIO, Me.Cb_TipoUsuario.SelectedValue)
                Dim filas() As DataRow = Ds_Usuario1.USU_PERMISOXTIPOUSUARIO.Select("CODIGOFUNCIONMODULO=" + Me.Tv_Permisos.Nodes(0).Name)
                If filas.Length > 0 Then
                    Me.Tv_Permisos.Nodes(0).Checked = True
                End If
                CargarPermisosArbolTipoUsuario(Me.Tv_Permisos.Nodes(0))
                Windows.Forms.Cursor.Current = Cursors.Default
            End If
        End If

    End Sub


    Private Sub CargarPermisosArbolTipoUsuario(ByVal treeNode As Windows.Forms.TreeNode)
        For Each tn As Windows.Forms.TreeNode In treeNode.Nodes
            Dim filas() As DataRow = Ds_Usuario1.USU_PERMISOXTIPOUSUARIO.Select("CODIGOFUNCIONMODULO=" + tn.Name)
            If filas.Length > 0 Then
                tn.Checked = True
            End If
            CargarPermisosArbolTipoUsuario(tn)
        Next
    End Sub

    Private Sub Bt_Adicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Adicionar.Click
        If Me.Cb_TipoUsuario.SelectedIndex <> -1 Then
            If MsgBox("¿Seguro que desea agregar los permisos de este tipo de usuario al usuario que esta editando?", MsgBoxStyle.YesNo, "Agregar Permisos") = vbYes Then
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Dim adap As New Ds_UsuarioTableAdapters.USU_PERMISOXTIPOUSUARIOTableAdapter
                adap.FillByCODIGOTIPOUSUARIO(Ds_Usuario1.USU_PERMISOXTIPOUSUARIO, Me.Cb_TipoUsuario.SelectedValue)
                Dim filas() As DataRow = Ds_Usuario1.USU_PERMISOXTIPOUSUARIO.Select("CODIGOFUNCIONMODULO=" + Me.Tv_Permisos.Nodes(0).Name)
                If filas.Length > 0 Then
                    Me.Tv_Permisos.Nodes(0).Checked = True
                End If
                CargarPermisosArbolTipoUsuario(Me.Tv_Permisos.Nodes(0))
                Windows.Forms.Cursor.Current = Cursors.Default
            End If
        End If
    End Sub


    Private Sub Bt_GurdarPermisosTipoUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_GuardarPermisosTipoUsuario.Click
        If MsgBox("¿Desea asignar los permisos marcados al tipo de usuario selecionado?", MsgBoxStyle.YesNo, "Agregar Permisos") = vbYes Then
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            'Actualizar permisos, primero la raiz
            Dim filas() As DataRow = Ds_Usuario1.USU_PERMISO.Select("CODIGOFUNCIONMODULO=" + Me.Tv_Permisos.Nodes(0).Name)
            If filas.Length > 0 Then
                'Actualizar
                Dim fila As DataRow = filas(0)
                If Me.Tv_Permisos.Nodes(0).Checked = True Then
                    fila("TIENEPERMISO") = 1
                Else
                    fila("TIENEPERMISO") = 0
                End If
            Else
                ''Agregar
                Dim NuevaFila As DataRow
                NuevaFila = Ds_Usuario1.USU_PERMISO.NewRow
                NuevaFila("IDPERSONA") = IDPERSONAMODIFICANDO
                NuevaFila("CODIGOFUNCIONMODULO") = CInt(Me.Tv_Permisos.Nodes(0).Name)
                If Me.Tv_Permisos.Nodes(0).Checked = True Then
                    NuevaFila("TIENEPERMISO") = 1
                Else
                    NuevaFila("TIENEPERMISO") = 0
                End If
                Ds_Usuario1.USU_PERMISO.Rows.Add(NuevaFila)
            End If

            ActualizarTablaPermisos(Me.Tv_Permisos.Nodes(0))

            'Actualizar permisos BD
            Dim TablePERMISOS As New DataTable("PERMISOS")
            TablePERMISOS.Columns.Add("CODIGOFUNCIONMODULO")
            TablePERMISOS.Columns.Add("IDPERSONA")
            TablePERMISOS.Columns.Add("TIENEPERMISO")
            For i = 0 To Me.Ds_Usuario1.USU_PERMISO.Rows.Count - 1
                Dim filausuario As DataRow = Me.Ds_Usuario1.USU_PERMISO.Rows(i)
                If filausuario("TIENEPERMISO") = 1 Then
                    Dim Fila As DataRow
                    Fila = TablePERMISOS.NewRow
                    Fila("CODIGOFUNCIONMODULO") = filausuario("CODIGOFUNCIONMODULO")
                    Fila("IDPERSONA") = filausuario("IDPERSONA")
                    Fila("TIENEPERMISO") = filausuario("TIENEPERMISO")
                    TablePERMISOS.Rows.Add(Fila)
                End If
            Next
            Dim Comando As New SqlCommand("dbo.AsociarPermisosTipoUsuario")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@TablePERMISOS", TablePERMISOS)
            Comando.Parameters.AddWithValue("@CODIGOTIPOUSUARIO", Me.Cb_TipoUsuario.SelectedValue)
            Dim conn As New SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Comando.ExecuteNonQuery()
            conn.Close()
            Windows.Forms.Cursor.Current = Cursors.Default
            MsgBox("Se asignaron correctamente los permisos al tipo de usuario seleccionado", MsgBoxStyle.Information, "Asignar Permisos")
        End If
    End Sub

    Private Sub Tv_Permisos_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Tv_Permisos.AfterCheck
        Try
            If Cargandoarbol = False Then
                If e.Node.Checked Then
                    e.Node.Parent.Checked = True
                Else
                    For Each Nodo In e.Node.Nodes
                        Nodo.Checked = False
                    Next
                End If
            End If
            
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MarcarRecursive(ByVal n As TreeNode, ByVal Estado As Boolean)
        Dim aNode As TreeNode = n
        aNode.Checked = Estado
        For Each aNode In n.Nodes
            MarcarRecursive(aNode, Estado)
        Next
    End Sub


    Private Sub MarcarTodosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MarcarTodosToolStripMenuItem.Click
        Cursor.Current = Cursors.WaitCursor
        MarcarRecursive(Tv_Permisos.SelectedNode, True)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub DesmarcarTodosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DesmarcarTodosToolStripMenuItem.Click
        Cursor.Current = Cursors.WaitCursor
        MarcarRecursive(Tv_Permisos.SelectedNode, False)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Tv_Permisos_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Tv_Permisos.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Tv_Permisos.SelectedNode = Tv_Permisos.GetNodeAt(e.X, e.Y)
        End If
    End Sub

    Private Sub Cb_Base_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_Base.SelectedIndexChanged

        Dim TablaDependencias As New DataView(datas.Tables(5))
        TablaDependencias.RowFilter = "IDBASESISCONTROL=" + Cb_Base.SelectedValue.ToString

   
        Me.Cb_Dependencia.DataSource = TablaDependencias
        Me.Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
        Me.Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
    End Sub

    Dim TablaUsuarios As DataTable

    Private Sub Nbi_Buscar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Buscar.ItemClick

        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos

        campos.Rows.Add("2", "Nombre Persona", "7")
        campos.Rows.Add("P.IDENTIFICACION", "Identificación", "1")
        campos.Rows.Add("SCB.NOMBREBASE", "Base Siscontrol", "1")
        campos.Rows.Add("B.NOMBRE", "Bodega", "1")
        campos.Rows.Add("U.NOMBREUSUARIO", "Usuario", "1")


        frbuscar.campos = campos
        frbuscar.tabla = 36
        frbuscar.ShowDialog()
        Try
            TablaUsuarios = frbuscar.DsBuscar.Tables(1)
            Me.Dgv_Usuarios.DataSource = TablaUsuarios
            AplicarFormato()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Nbi_Cargar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Cargar.ItemClick
        Cargar_Tabla()
    End Sub


End Class
