Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class Fr_SolicitudMaquinaria
    Property IdSolicitudMaquinaria As Integer = -1
    Property Edicion As TipoEdicion
    Enum TipoEdicion
        Crear
        Ver
        Editar
    End Enum
    Private conexion As SqlConnection
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private dtSolicitudMaquinaria As DataTable
    Private dtItemSolicitudMaquinaria As DataTable
    Private Estilo_Celda_Error As New DataGridViewCellStyle
    Private celdaValorAnterior As Object
    Private Guardado As Boolean = False
    Private TempBodega As Integer
    Private dtpValorAnterior As Date

    Sub New()
        InitializeComponent()
        dtSolicitudMaquinaria = New DataTable
        dtItemSolicitudMaquinaria = New DataTable
    End Sub


    Private Sub Fr_SolicitudMaquinaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Comportamiento_Predeterminado()
        If Edicion = TipoEdicion.Crear Then
            CargarPersonalAsociadoBodega()
            Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "SM", "SOLICITA", -1)
            Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "SM", "AUTORIZA", -1)
            'Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "SM", "APRUEBA", -1)
            CargarItemsSolicitudMaquinaria() 'Llenar el esquema de la tabla
            OrdenarColumnas()
        Else 'Ver, Editar
            CargarSolicitudMaquinaria()
        End If
        Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = 1439 'Siempre PersonaAprueba Gerente Gral
        Tb_Origen.Text = VariablesBase.VariablesBase.DireccionBodegaActual
        Tb_Base.Text = VariablesBase.VariablesBase.NombreBodegaActual
        dtpValorAnterior = Dtp_FechaSolicitud.Value
        Dtp_FechaSolicitud.MinDate = Date.Today
        Dtp_FechaSolicitud.MaxDate = DateAdd(DateInterval.Month, 3, Date.Today)
        If Edicion = TipoEdicion.Ver Then
            Tb_Encabezado.ReadOnly = True
            Tb_Justificacion.ReadOnly = True
            Pn_Opciones.Visible = False
            Dtp_FechaSolicitud.Enabled = False
            Dgv_ItemSolicitudMaquinaria.ReadOnly = True
            Dgv_ItemSolicitudMaquinaria.AllowUserToAddRows = False
            Dgv_ItemSolicitudMaquinaria.AllowUserToDeleteRows = False
            Cu_BuscarPersonaSolicita.Enabled = False
            Cu_ApbSolicita.Enabled = False
            Cu_BuscarPersonaAutoriza.Enabled = False
            Cu_ApbAutoriza.Enabled = False
            Cu_BuscarPersonaAprueba.Enabled = False
            Cu_ApbAprueba.Enabled = False
            Bt_Guardar.Enabled = False
        End If
    End Sub


    Public Sub Comportamiento_Predeterminado()
        Dgv_ItemSolicitudMaquinaria.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_ItemSolicitudMaquinaria.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Dgv_ItemSolicitudMaquinaria.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Dgv_ItemSolicitudMaquinaria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Cu_ApbSolicita.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_ApbSolicita.Tag)
        Cu_ApbAutoriza.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_ApbAutoriza.Tag)
        'Cu_ApbAprueba.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_ApbAprueba.Tag)
    End Sub


    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Cu_BuscarPersonaSolicita.Name
                Try
                    filas = Cu_BuscarPersonaSolicita.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaSolicita.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Cu_BuscarPersonaSolicita.Tx_TextoCódigo.Text = ""
                End Try
            Case Cu_BuscarPersonaAutoriza.Name
                Try
                    filas = Cu_BuscarPersonaAutoriza.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaAutoriza.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Cu_BuscarPersonaAutoriza.Tx_TextoCódigo.Text = ""
                End Try
                'Case Cu_BuscarPersonaAprueba.Name
                '    Try
                '        filas = Cu_BuscarPersonaAprueba.Ds_FrBuscarPersona.PERSONABUSCAR.Select("IDENTIFICACION='" + (Cu_BuscarPersonaAprueba.Tx_TextoCódigo.Text).ToString + "'")
                '        If filas.Length > 0 Then
                '            Dim fila As DataRow = filas(0)
                '            Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = fila("IDPERSONA")
                '        Else
                '            MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                '        End If
                '    Catch ex As Exception
                '        Cu_BuscarPersonaAprueba.Tx_TextoCódigo.Text = ""
                '    End Try
        End Select
    End Sub


    Public Sub CargarPersonalAsociadoBodega(Optional ByVal IDPERSONA As Integer = -1, Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue
            Cu_BuscarPersonaSolicita.CargarDatos()
            Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue = temp
            Cu_BuscarPersonaSolicita.CargarCajaTexto()
        Catch
        End Try
        Try
            temp = Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue
            Cu_BuscarPersonaAutoriza.CargarDatos()
            Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = temp
            Cu_BuscarPersonaAutoriza.CargarCajaTexto()
        Catch
        End Try
        Try
            temp = Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue
            Cu_BuscarPersonaAprueba.CargarDatos()
            Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = temp
            Cu_BuscarPersonaAprueba.CargarCajaTexto()
        Catch
        End Try
        Select Case NOMBRECOMPONENTE
            Case Cu_BuscarPersonaSolicita.Name
                Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaAutoriza.Name
                Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaAprueba.Name
                Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub


    Private Sub CargarSolicitudMaquinaria()
        conexion = New SqlConnection(My.Settings.CadenaConexión)
        comando = New SqlCommand("SELECT * FROM dbo.DatosSolicitudMaquinaria(@IDSOLICITUDMAQUINARIA)", conexion)
        comando.Parameters.AddWithValue("@IDSOLICITUDMAQUINARIA", IdSolicitudMaquinaria)
        adaptador = New SqlDataAdapter(comando)
        dtSolicitudMaquinaria.Clear()
        Try
            conexion.Open()
            adaptador.FillSchema(dtSolicitudMaquinaria, SchemaType.Source)
            adaptador.Fill(dtSolicitudMaquinaria)
            conexion.Close()
            'Necesario para poder cargar los usuarios de la bodega donde se digitó la solicitud
            TempBodega = VariablesBase.VariablesBase.IdBodegaActual
            VariablesBase.VariablesBase.IdBodegaActual = dtSolicitudMaquinaria.Rows(0).Item("IDBODEGA")
            CargarPersonalAsociadoBodega()
            If dtSolicitudMaquinaria.Rows.Count > 0 Then
                Dim filaSolicitudMaquinaria As DataRow = dtSolicitudMaquinaria.Rows(0)
                Tb_Encabezado.Text = filaSolicitudMaquinaria("ENCABEZADO")
                Tb_Justificacion.Text = filaSolicitudMaquinaria("JUSTIFICACION")
                Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue = filaSolicitudMaquinaria("IDPERSONASOLICITA")
                Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = filaSolicitudMaquinaria("IDPERSONAAUTORIZA")
                'Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = filaSolicitudMaquinaria("IDPERSONAAPRUEBA")
            End If
            CargarItemsSolicitudMaquinaria()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    Private Sub CargarItemsSolicitudMaquinaria()
        conexion = New SqlConnection(My.Settings.CadenaConexión)
        comando = New SqlCommand("SELECT * FROM dbo.ListaItemSolicitudMaquinaria(@IDSOLICITUDMAQUINARIA)", conexion)
        comando.Parameters.AddWithValue("@IDSOLICITUDMAQUINARIA", IdSolicitudMaquinaria)
        adaptador = New SqlDataAdapter(comando)
        dtItemSolicitudMaquinaria.Clear()
        Try
            conexion.Open()
            adaptador.FillSchema(dtItemSolicitudMaquinaria, SchemaType.Source)
            adaptador.Fill(dtItemSolicitudMaquinaria)
            conexion.Close()
            Dgv_ItemSolicitudMaquinaria.DataSource = dtItemSolicitudMaquinaria
            OrdenarColumnas()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub


    Private Sub OrdenarColumnas()
        For i As Integer = 0 To Dgv_ItemSolicitudMaquinaria.Columns.Count - 1
            Select Case Dgv_ItemSolicitudMaquinaria.Columns(i).Name
                Case Dgv_ItemSolicitudMaquinaria.Columns("IDITEMSOLICITUDMAQUINARIA").Name

                Case Dgv_ItemSolicitudMaquinaria.Columns("IDARTICULO").Name

                Case Dgv_ItemSolicitudMaquinaria.Columns("DESCRIPCION").Name

                Case Dgv_ItemSolicitudMaquinaria.Columns("CANTIDAD").Name

                Case Dgv_ItemSolicitudMaquinaria.Columns("FECHAREQUIERE").Name

                Case Else
                    'FECHAREGISTRO, IDUSUARIOREGISTRO, FECHAMODIFICACION, IDUSUARIOMODIFICA
                    Dgv_ItemSolicitudMaquinaria.Columns(i).Visible = False
            End Select
        Next
    End Sub


    Private Sub Dgv_ItemRequisicion_CellEndEdit(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_ItemSolicitudMaquinaria.CellEndEdit
        If IsDBNull(Dgv_ItemSolicitudMaquinaria.Item(e.ColumnIndex, e.RowIndex).Value) = True Then
            Dgv_ItemSolicitudMaquinaria.Item(e.ColumnIndex, e.RowIndex).Value = 0
        End If
        If Trim(Dgv_ItemSolicitudMaquinaria.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
            If e.RowIndex > 0 Then
                Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).ErrorText = ""
            Else
                Try
                    Dgv_ItemSolicitudMaquinaria.Rows.RemoveAt(e.RowIndex)
                Catch ex As Exception
                End Try
            End If
            Exit Sub
        End If
        Dim idArticulo As Integer = -1
        If IsDBNull(Dgv_ItemSolicitudMaquinaria.Item("IDARTICULO", e.RowIndex).Value) = False Then
            idArticulo = Dgv_ItemSolicitudMaquinaria.Item("IDARTICULO", e.RowIndex).Value
        End If
        Dim cantidad As Integer = -1
        If IsDBNull(Dgv_ItemSolicitudMaquinaria.Item("CANTIDAD", e.RowIndex).Value) = False Then
            cantidad = Dgv_ItemSolicitudMaquinaria.Item("CANTIDAD", e.RowIndex).Value
        End If

        Dim Estilo_Celda As New DataGridViewCellStyle
        Estilo_Celda.BackColor = Color.White
        Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda
        Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).ErrorText = ""

        ' Validar Artículo
        Select Case Dgv_ItemSolicitudMaquinaria.Columns(e.ColumnIndex).Name
            Case Dgv_ItemSolicitudMaquinaria.Columns("IDARTICULO").Name
                AgregarArticulo(idArticulo, e.ColumnIndex, e.RowIndex)
            Case Dgv_ItemSolicitudMaquinaria.Columns("CANTIDAD").Name
                If Trim(cantidad) = "" Then
                    Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                    Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).ErrorText = "El campo Cantidad Solicitada no es válido"
                Else
                    If IsNumeric(cantidad) = False Then
                        Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                        Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).ErrorText = "El campo Cantidad Solicitada no es válido"
                    Else
                        If cantidad <= 0 Then
                            Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                            Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).ErrorText = "El campo Cantidad Solicitada no es válido"
                        End If
                    End If
                End If
            Case Dgv_ItemSolicitudMaquinaria.Columns("FECHAREQUIERE").Name
                If IsDate(Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                    If DateDiff(DateInterval.Day, Date.Today, Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) >= 0 Then

                    Else
                        Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                        Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).ErrorText = "El campo Fecha en que se requiere no es válido"
                    End If
                Else

                End If
        End Select
        ELiminarFilaVacia()
    End Sub


    Private Sub ELiminarFilaVacia()
        Try
            For i = 0 To Dgv_ItemSolicitudMaquinaria.Rows.Count - 2
                If IsDBNull(Dgv_ItemSolicitudMaquinaria.Rows(i).Cells("DESCRIPCION").Value) = True Then
                    Dgv_ItemSolicitudMaquinaria.Rows.RemoveAt(i)
                End If
            Next
        Catch
        End Try
    End Sub


    Private Sub Dgv_ItemSolicitudMaquinaria_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Dgv_ItemSolicitudMaquinaria.DataError
        Select Case Dgv_ItemSolicitudMaquinaria.Columns(e.ColumnIndex).Name
            Case Dgv_ItemSolicitudMaquinaria.Columns("FECHAREQUIERE").Name
                Dgv_ItemSolicitudMaquinaria.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Date.Today
        End Select
    End Sub


    Private Sub Dgv_ItemRequisicion_CellBeginEdit(sender As Object, e As Windows.Forms.DataGridViewCellCancelEventArgs) Handles Dgv_ItemSolicitudMaquinaria.CellBeginEdit
        guardarCeldaValorAnterior(e.ColumnIndex, e.RowIndex)
    End Sub


    Private Sub Dgv_ItemRequisicion_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Dgv_ItemSolicitudMaquinaria.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Using FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
                    guardarCeldaValorAnterior(Dgv_ItemSolicitudMaquinaria.CurrentCell.ColumnIndex, Dgv_ItemSolicitudMaquinaria.CurrentCell.RowIndex)
                    FrBuscarArtículo._Tipo = "T"
                    FrBuscarArtículo.Familia = "EQUIPO CAPITAL Y EQUIPOS DE LA COMPAÑÍA"
                    FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda por familia, falta implementar
                    FrBuscarArtículo.ShowDialog()
                    If Trim(FrBuscarArtículo.IdArtículo) > 0 Then
                        AgregarArticulo(FrBuscarArtículo.IdArtículo)
                        ELiminarFilaVacia()
                    End If
                End Using
        End Select
    End Sub


    Private Sub guardarCeldaValorAnterior(ByVal columnIndex As Integer, ByVal rowIndex As Integer)
        If Not IsDBNull(Dgv_ItemSolicitudMaquinaria.Item(columnIndex, rowIndex).Value) Then
            celdaValorAnterior = Dgv_ItemSolicitudMaquinaria.Item(columnIndex, rowIndex).Value
        Else
            celdaValorAnterior = -1
        End If
    End Sub


    Private Function ValidarItems(ByVal idArticulo As Integer) As Boolean
        Dim filas As DataRow()
        If Not IsNothing(dtItemSolicitudMaquinaria) AndAlso dtItemSolicitudMaquinaria.Rows.Count > 0 Then
            filas = dtItemSolicitudMaquinaria.Select("IDARTICULO=" + idArticulo.ToString)
            If filas.Length > 0 Then
                ValidarItems = False
                Exit Function
            End If
        End If
        ValidarItems = True
    End Function


    Private Sub AgregarArticulo(ByVal idArticulo As Integer)
        AgregarArticulo(idArticulo, Dgv_ItemSolicitudMaquinaria.CurrentCell.ColumnIndex, Dgv_ItemSolicitudMaquinaria.CurrentCell.RowIndex)
    End Sub


    Private Sub AgregarArticulo(ByVal idArticulo As Integer, ByVal columnIndex As Integer, ByVal rowIndex As Integer)
        If ValidarItems(idArticulo) = True Then
            Dim FilasArticulos As DataRow()
            Dim Articulos As New DataTable
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT * FROM dbo.DatosArticuloxBodega(@IDARTICULO, @IDBODEGA)", conexion)
            comando.Parameters.AddWithValue("@IDARTICULO", idArticulo)
            comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
            Dim Adaptador As New SqlDataAdapter(comando)
            conexion.Open()
            Adaptador.FillSchema(Articulos, SchemaType.Source)
            Adaptador.Fill(Articulos)
            conexion.Close()
            FilasArticulos = Articulos.Select("ID=" & idArticulo & "AND IDFAMILIAMATERIAL='" & "4" & "'")
            If FilasArticulos.Length > 0 Then
                Dim FilaArticulo As DataRow
                FilaArticulo = FilasArticulos(0)
                Dim FilaNueva As DataRow
                FilaNueva = dtItemSolicitudMaquinaria.NewRow
                FilaNueva("IDITEMSOLICITUDMAQUINARIA") = 0
                FilaNueva("IDARTICULO") = idArticulo
                FilaNueva("DESCRIPCION") = FilaArticulo("NOMBRE")
                FilaNueva("CANTIDAD") = 0
                FilaNueva("FECHAREQUIERE") = Date.Today
                FilaNueva("IDUSUARIOREGISTRO") = VariablesBase.VariablesBase.IdPersona
                FilaNueva("FECHAREGISTRO") = DateTime.Now

                If celdaValorAnterior = -1 Then
                    dtItemSolicitudMaquinaria.Rows.Add(FilaNueva)
                Else
                    dtItemSolicitudMaquinaria.Rows.RemoveAt(rowIndex)
                    dtItemSolicitudMaquinaria.Rows.InsertAt(FilaNueva, rowIndex)
                End If
                NumerarFilas(rowIndex)
            Else
                ' No existe un articulo con este código
                MsgBox("No se encontró un artículo con ese Código.", MsgBoxStyle.Exclamation, "Artículo no Encontrado")
                Try
                    Dgv_ItemSolicitudMaquinaria.Item(columnIndex, rowIndex).Value = celdaValorAnterior
                Catch
                End Try
            End If
        Else
            MsgBox("El ítem que desea ingresar ya se encuentra incluido en la Solicitud de Maquinaria.", MsgBoxStyle.Critical, "Ítem repetido")
            Try
                Dgv_ItemSolicitudMaquinaria.Item(columnIndex, rowIndex).Value = celdaValorAnterior
            Catch
            End Try
        End If
    End Sub


    Private Sub NumerarFilas(Optional ByVal rowIndex As Integer = 0)
        For i As Integer = rowIndex To dtItemSolicitudMaquinaria.Rows.Count - 1
            dtItemSolicitudMaquinaria.Rows(i).Item("IDITEMSOLICITUDMAQUINARIA") = i + 1
        Next
    End Sub


    Private Sub Ll_ActualizarContacto_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_ActualizarContacto.LinkClicked
        If MsgBox("¿Desea ver o actualizar los contactos asociados al documento?", MsgBoxStyle.YesNo, "Ver o Actualizar Contactos") = MsgBoxResult.Yes Then
            If Cu_BuscarPersonaSolicita.Cb_Persona.SelectedIndex <> -1 And _
                Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedIndex <> -1 Then 'And Cu_BuscarPersonaAprueba.Cb_Persona.SelectedIndex <> -1
                Dim FrActualizarContacto As New FormulariosClasesBase.Fr_ActualizarContacto
                FrActualizarContacto.Bt_Aceptar.Enabled = Bt_Guardar.Enabled
                FrActualizarContacto.Cu_Contacto1.IDPERSONA = Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto1.Gb_Contacto.Text = "Director: " + Cu_BuscarPersonaSolicita.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto2.IDPERSONA = Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto2.Gb_Contacto.Text = "Gerente: " + Cu_BuscarPersonaAutoriza.Cb_Persona.Text
                'FrActualizarContacto.Cu_Contacto4.IDPERSONA = Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue
                'FrActualizarContacto.Cu_Contacto4.Gb_Contacto.Text = "Aprueba: " + Cu_BuscarPersonaAprueba.Cb_Persona.Text
                FrActualizarContacto.CargarDatos()
                FrActualizarContacto.ShowDialog()
            Else
                MsgBox("Debe seleccionar todas las personas que interactúan con el documento", MsgBoxStyle.Information, "Seleccionar todas las personas")
            End If
        End If
    End Sub


    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        GuardarSolicitudMaquinaria()
    End Sub


    Private Sub GuardarSolicitudMaquinaria()
        If ValidarSolicitudMaquinaria() Then
            Try
                dtItemSolicitudMaquinaria.AcceptChanges()
            Catch
            End Try
            Dim dtItems As New DataTable
            dtItems = dtItemSolicitudMaquinaria.Copy
            dtItems.Columns.Remove("DESCRIPCION")

            conexion = New SqlConnection(My.Settings.CadenaConexión)
            comando = New SqlCommand("dbo.GestionarSolicitudMaquinaria", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@TIPO", SqlDbType.TinyInt)
            comando.Parameters.AddWithValue("@TablaItemSolicitudMaquinaria", dtItems)
            comando.Parameters.AddWithValue("@IDSOLICITUDMAQUINARIA", IdSolicitudMaquinaria)
            comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
            comando.Parameters.AddWithValue("@ENCABEZADO", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tb_Encabezado.Text))
            comando.Parameters.AddWithValue("@JUSTIFICACION", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tb_Justificacion.Text))
            comando.Parameters.AddWithValue("@IDPERSONASOLICITA", Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue) 'Director de Proyecto
            comando.Parameters.AddWithValue("@IDPERSONAAUTORIZA", Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue) 'Gerente Correspondiente
            comando.Parameters.AddWithValue("@IDPERSONAAPRUEBA", Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue) 'Gerente Gral
            comando.Parameters.AddWithValue("@IdUsuario", VariablesBase.VariablesBase.IdPersona)
            Dim msgParam As New SqlParameter("@Mensaje", SqlDbType.TinyInt)
            msgParam.Direction = ParameterDirection.Output
            comando.Parameters.Add(msgParam)
            Select Case Edicion
                Case TipoEdicion.Crear
                    comando.Parameters("@TIPO").Value = 1
                Case TipoEdicion.Editar
                    comando.Parameters("@TIPO").Value = 2
            End Select
            Try
                conexion.Open()
                comando.ExecuteNonQuery()
                conexion.Close()
                Guardado = True
                MsgBox("Se guardaron los cambios de la Solicitud de Maquinaria.", MsgBoxStyle.Information, "Guardar Solicitud de Maquinaria")
                FuncionesBase.FuncionesBase.ValoresxDefecto("G", "SM", "SOLICITA", Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue)
                FuncionesBase.FuncionesBase.ValoresxDefecto("G", "SM", "AUTORIZA", Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue)
                'FuncionesBase.FuncionesBase.ValoresxDefecto("G", "SM", "APRUEBA", Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue)
                Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conexion.Close()
            End Try
        End If
    End Sub


    Private Function ValidarSolicitudMaquinaria() As Boolean
        'If FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tb_Encabezado.Text) = "" Then
        '    MsgBox("Debe digitar el Encabezado.", MsgBoxStyle.Critical, "ENCABEZADO")
        '    Tb_Encabezado.Focus()
        '    ValidarSolicitudMaquinaria = False
        '    Exit Function
        'End If

        If FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tb_Justificacion.Text) = "" Then
            MsgBox("Debe digitar la Justificación.", MsgBoxStyle.Critical, "JUSTIFICACIÓN")
            Tb_Justificacion.Focus()
            ValidarSolicitudMaquinaria = False
            Exit Function
        End If

        If dtItemSolicitudMaquinaria.Rows.Count = 0 Then
            MsgBox("La solicitud debe tener al menos un ítem", MsgBoxStyle.Critical, "ITEMS DE LA SOLICITUD")
            ValidarSolicitudMaquinaria = False
            Exit Function
        End If

        For i = 0 To dtItemSolicitudMaquinaria.Rows.Count - 1
            If IsDBNull(Dgv_ItemSolicitudMaquinaria.Item("CANTIDAD", i).Value) = True Then
                Dgv_ItemSolicitudMaquinaria.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                Dgv_ItemSolicitudMaquinaria.Rows(i).ErrorText = "El campo Cantidad Solicitada no es válido"
                ValidarSolicitudMaquinaria = False
                Try
                    Dgv_ItemSolicitudMaquinaria.CurrentCell = Dgv_ItemSolicitudMaquinaria(0, i)
                Catch
                End Try
                Exit Function
            End If

            If Dgv_ItemSolicitudMaquinaria.Item("CANTIDAD", i).Value <= 0 Then
                Dgv_ItemSolicitudMaquinaria.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                Dgv_ItemSolicitudMaquinaria.Rows(i).ErrorText = "El campo Cantidad Solicitada no es válido"
                ValidarSolicitudMaquinaria = False
                Try
                    Dgv_ItemSolicitudMaquinaria.CurrentCell = Dgv_ItemSolicitudMaquinaria(0, i)
                Catch
                End Try
                Exit Function
            End If
        Next
        ValidarSolicitudMaquinaria = True
    End Function


    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Close()
    End Sub


    Private Sub Fr_SalidaAlmacen_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Guardado = False AndAlso Bt_Guardar.Enabled = True Then
            If MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "SALIR SIN GUARDAR") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                If Edicion = TipoEdicion.Editar Then
                    VariablesBase.VariablesBase.IdBodegaActual = TempBodega
                End If
            End If
        Else
            If Edicion = TipoEdicion.Editar Then
                VariablesBase.VariablesBase.IdBodegaActual = TempBodega
            End If
        End If
    End Sub


    Private Sub Dtp_FechaSolicitud_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaSolicitud.ValueChanged
        If DateDiff(DateInterval.Day, dtpValorAnterior, Dtp_FechaSolicitud.Value) <> 0 Then
            If MsgBox("¿Desea aplicar la fecha seleccionada a todos los ítems de la Solicitud de Maquinaria y Equipo?", MsgBoxStyle.YesNo, "Aplicar a todos los ítems") = MsgBoxResult.Yes Then
                For i As Integer = 0 To dtItemSolicitudMaquinaria.Rows.Count - 1
                    dtItemSolicitudMaquinaria.Rows(i).Item("FECHAREQUIERE") = Dtp_FechaSolicitud.Value
                Next
            End If
            dtpValorAnterior = Dtp_FechaSolicitud.Value
        End If
    End Sub


    Private Sub Dtp_FechaSolicitud_DropDown(ByVal sender As Object, ByVal e As EventArgs) Handles Dtp_FechaSolicitud.DropDown
        RemoveHandler Dtp_FechaSolicitud.ValueChanged, AddressOf Dtp_FechaSolicitud_ValueChanged
    End Sub


    Private Sub Dtp_FechaSolicitud_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtp_FechaSolicitud.CloseUp
        AddHandler Dtp_FechaSolicitud.ValueChanged, AddressOf Dtp_FechaSolicitud_ValueChanged
        Call Dtp_FechaSolicitud_ValueChanged(sender, EventArgs.Empty)
    End Sub

End Class 'Fr_SolicitudMaquinaria