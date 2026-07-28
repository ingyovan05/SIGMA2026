Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Globalization


''' <summary>
''' 
''' </summary>
Public Class Fr_Requisicion
    Public TIPO As Integer '1: Insert, 2: Update
    Public IDREQUISICION As Integer
    Public IDREQUISICIONMODIFICANDO As Integer = -1
    Public EDITANDO As Boolean
    Public guardado As Boolean
    Private familia As Integer = -1
    Private NombreFamilia As String = "-1"
    Private tempbodega As Integer
    Private Estilo_Celda_Error As New DataGridViewCellStyle
    Private Estilo_Celda As New DataGridViewCellStyle
    Private MensajeError As String
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private filarequisición As DataRow
    Private DsRequisicion As New DatosRequisición.Ds_Requisicion
    Private dtFamiliaMateriales As New DataTable
    Private dtRequisicion As New DataTable
    Private dtItemRequisicion As New DataTable
    Property IdPersonaEditando As Integer = -1
    Private bddatos As New FuncionesBase.ClaseCargarMaestras


    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub Comportamiento_Predeterminado()
        Me.Dgv_ItemRequisicion.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ItemRequisicion.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        'Definir el estilo de encabezado del DataGrid para que salga en dos renglones
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv_ItemRequisicion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        'Me.Dgv_ItemRequisicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Cu_ApbSolicita.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_ApbSolicita.Tag)
        Cu_ApbAutoriza.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_ApbAutoriza.Tag)
        Cu_ApbRevisa.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_ApbRevisa.Tag)
        Cu_ApbAprueba.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cu_ApbAprueba.Tag)
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Function ValidarCasillas() As Boolean

        If Ck_Stock.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si la requisición es o no de tipo Stock de bodega.", MsgBoxStyle.Critical, "REQUISICIÓN TIPO STOCK (SI/NO)")
            'Me.Ck_Stock.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Ck_RecGasto.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si la requisición tiene Recuperación del Gasto.", MsgBoxStyle.Critical, "RECUPERACIÓN DEL GASTO (SI/NO)")
            'Me.Ck_RecGasto.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Ck_Incorporable.CheckState = CheckState.Indeterminate Then
            MsgBox("Debe indicar si la requisición es Incorporable.", MsgBoxStyle.Critical, "INCORPORABLE (SI/NO)")
            Me.Ck_Incorporable.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Ck_RecGasto.Checked = True Then
            If Me.Cb_TipoReq.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar el tipo de cobro de la requisición", MsgBoxStyle.Critical, "Tipo de cobro Requisición")
                Me.Cb_TipoReq.Focus()
                ValidarCasillas = False
                Exit Function
            End If
            If Me.Cb_TipoReq.SelectedValue = "N" Then
                MsgBox("Debe seleccionar el tipo de cobro de la requisición", MsgBoxStyle.Critical, "Tipo de cobro Requisición")
                Me.Cb_TipoReq.Focus()
                ValidarCasillas = False
                Exit Function
            End If
        Else
            If Me.Cb_TipoReq.SelectedValue <> "N" Then
                MsgBox("Debe seleccionar no aplica en el tipo de cobro de la requisición", MsgBoxStyle.Critical, "Tipo de cobro Requisición")
                Me.Cb_TipoReq.Focus()
                ValidarCasillas = False
                Exit Function
            End If
        End If

        If Me.Cb_TipoPrioridad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de prioridad", MsgBoxStyle.Critical, "Tipo Prioridad")
            Me.Cb_TipoPrioridad.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Me.Cb_TipoItem.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el tipo de Item de Requisición", MsgBoxStyle.Critical, "Tipo Item Requisición")
            Me.Cb_TipoItem.Focus()
            ValidarCasillas = False
            Exit Function
        End If

        If Ck_Incorporable.Checked = True Then
            If Me.Cb_TipoItem.SelectedValue = "N" Then
                MsgBox("Debe seleccionar el tipo de Item de Requisición, (No aplica) es un valor invalido", MsgBoxStyle.Critical, "Tipo Item Requisición")
                Me.Cb_TipoItem.Focus()
                ValidarCasillas = False
                Exit Function
            End If
        End If

        If Trim(Tb_Destino.Text) = "" Then
            Tb_Destino.BackColor = Color.Red
            MsgBox("El campo Destino no puede estar vacío", MsgBoxStyle.Critical, "Campos Vacíos")
            ValidarCasillas = False
            Exit Function
        ElseIf Trim(Tb_Destino.Text).Count > 200 Then
            Tb_Destino.BackColor = Color.Red
            MensajeError = "El capo Destino no puede tener mas de 200 caracteres"
            MsgBox(MensajeError, MsgBoxStyle.Critical, "Desbordamiento")
            ValidarCasillas = False
            Exit Function
        End If

        If Trim(Tb_Justificacion.Text) = "" Then
            Tb_Justificacion.BackColor = Color.Red
            MensajeError = "El campo Justificación no puede estar vacío"
            MsgBox(MensajeError, MsgBoxStyle.Critical, "Campos Vacíos")
            ValidarCasillas = False
            Exit Function
        ElseIf Trim(Tb_Justificacion.Text).Count > 300 Then
            Tb_Justificacion.BackColor = Color.Red
            MensajeError = "El capo Justificación no puede tener mas de 300 caracteres"
            MsgBox(MensajeError, MsgBoxStyle.Critical, "Desbordamiento")
            ValidarCasillas = False
            Exit Function
        End If

        If dtItemRequisicion.Rows.Count = 0 Then 'LISTAITEMREQUISICION
            MsgBox("La requisición debe tener mínimo un item", MsgBoxStyle.Critical, "Requisición sin items")
            ValidarCasillas = False
            Exit Function
        End If

        'Validar ítems.
        For i As Integer = 0 To Me.Dgv_ItemRequisicion.Rows.Count - 2
            If Not IsNumeric(Me.Dgv_ItemRequisicion.Item(Col_Cantidad.Name, i).Value) OrElse Not IsNumeric(Me.Dgv_ItemRequisicion.Item(Col_ExistBodLocal.Name, i).Value) Then '4, 5
                Me.Dgv_ItemRequisicion.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                MensajeError = "En el campo Cantidad Solicitada y Cantidad Existente deben ser numéricas"
                MsgBox(MensajeError, MsgBoxStyle.Critical, "Tipo de dato incorrecto")
                Me.Dgv_ItemRequisicion.Rows(i).ErrorText = MensajeError
                Try
                    Me.Dgv_ItemRequisicion.CurrentCell = Me.Dgv_ItemRequisicion(Col_IdArticulo.Name, i) '0
                Catch
                End Try
                ValidarCasillas = False
                Exit Function
            ElseIf Me.Dgv_ItemRequisicion.Item(Col_Cantidad.Name, i).Value <= 0 Then '4
                Me.Dgv_ItemRequisicion.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                MensajeError = "La cantidad solicitada debe ser superior a 0"
                MsgBox(MensajeError, MsgBoxStyle.Critical, "Tipo de dato incorrecto")
                Me.Dgv_ItemRequisicion.Rows(i).ErrorText = MensajeError
                Try
                    Me.Dgv_ItemRequisicion.CurrentCell = Me.Dgv_ItemRequisicion(Col_IdArticulo.Name, i) '0
                Catch
                End Try
                ValidarCasillas = False
                Exit Function
            End If
            Dim cantidad As String = Dgv_ItemRequisicion.Item(Col_Cantidad.Name, i).Value.ToString '4
            If cantidad.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) > 0 Then
                If cantidad.Substring(cantidad.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) + 1).Length > 2 Then
                    Dgv_ItemRequisicion.Rows(i).DefaultCellStyle = Estilo_Celda_Error
                    MensajeError = "La cantidad solicitada no debe tener más de 2 cifras decimales."
                    MsgBox(MensajeError, MsgBoxStyle.Critical, "Tipo de dato incorrecto")
                    Me.Dgv_ItemRequisicion.Rows(i).ErrorText = MensajeError
                    Try
                        Me.Dgv_ItemRequisicion.CurrentCell = Me.Dgv_ItemRequisicion(Col_IdArticulo.Name, i) '0
                    Catch
                    End Try
                    ValidarCasillas = False
                    Exit Function
                End If
            End If
        Next





        ValidarCasillas = True
    End Function

    Dim dsCargar As New DataSet
    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub CargarTablas()
        '-- 0  --> REQUISICION
        '-- 1  --> ITEMREQUISICION
        '-- 2  --> MA_TIPOPAGO 
        '-- 3  --> MA_TIPOPRIORIDAD
        '-- 4  --> MA_TIPOITEMREQUISICION
        '-- 5  --> FAMILIAMATERIALES
        '-- 6  --> ACTIVIDADPRINCIPAL
        '-- 7  --> MA_CENTROCOSTOSSOLIN
        '-- 8  --> OT_ORDENTRABAJO
        '-- 9  --> Cu_BuscarPersonaSolicita
        '-- 10 --> Cu_BuscarPersonaAprueba
        '-- 11 --> Cu_BuscarPersonaAutoriza
        '-- 12 --> Cu_BuscarPersonaRevisa

        Dim identificador As Long
        Dim tipo As Integer

        If IDREQUISICIONMODIFICANDO < 0 Then
            identificador = IDREQUISICION
            tipo = 1 'Crear
        Else
            identificador = IDREQUISICIONMODIFICANDO
            tipo = 2 'Editar
        End If


        dsCargar = bddatos.CargarMaestrasMateriales(0, VariablesBase.VariablesBase.IdBodegaActual, identificador, tipo)

        Cb_TipoReq.DataSource = dsCargar.Tables(2)
        Cb_TipoReq.ValueMember = "CODIGO"
        Cb_TipoReq.DisplayMember = "NOMBRE"

        Me.Cb_TipoReq.SelectedValue = "N"
        Me.Cb_TipoItem.SelectedValue = "N"
        Me.Cb_TipoPrioridad.SelectedValue = "N"

        Cb_TipoPrioridad.DataSource = dsCargar.Tables(3)
        Cb_TipoPrioridad.ValueMember = "CODIGO"
        Cb_TipoPrioridad.DisplayMember = "NOMBRE"

        Cb_TipoItem.DataSource = dsCargar.Tables(4)
        Cb_TipoItem.ValueMember = "CODIGO"
        Cb_TipoItem.DisplayMember = "NOMBRE"

        Cb_Actividad.DataSource = dsCargar.Tables(6)
        Cb_Actividad.ValueMember = "IDACTIVIDADPRINCIPAL"
        Cb_Actividad.DisplayMember = "ACTIVIDAD"

        dtFamiliaMateriales = dsCargar.Tables(5)


        'Me.Cu_CentroCosto1.Ll_CentroCostos.Text 

        guardado = False
        Estilo_Celda_Error.BackColor = Color.Red
        Estilo_Celda.BackColor = Color.White

        Me.Tb_Origen.ReadOnly = False
        Me.Tb_Base.ReadOnly = False
        Me.Tb_Destino.Text = VariablesBase.VariablesBase.DireccionBodegaActual
        If EDITANDO = True Then

            dtRequisicion = dsCargar.Tables(0)
            If dtRequisicion.Rows.Count > 0 Then
                filarequisición = dtRequisicion.Rows(0)
            End If

            'dtItemRequisicion = dsCargar.Tables(1)
            'Me.Dgv_ItemRequisicion.DataSource = dtItemRequisicion 'LISTAITEMREQUISICION
            'Comportamiento_Predeterminado()

            tempbodega = VariablesBase.VariablesBase.IdBodegaActual 'Necesario para poder cargar los usuarios de la bodega donde se digitó la requisición
            VariablesBase.VariablesBase.IdBodegaActual = filarequisición("IDBODEGA")
        End If

        If IDREQUISICIONMODIFICANDO = -1 Then

            Me.Cu_BuscarPersonaSolicita.DT_BUSCARPERSONA = dsCargar.Tables(7)
            Me.Cu_BuscarPersonaSolicita.Cb_Persona.DataSource = Me.Cu_BuscarPersonaSolicita.DT_BUSCARPERSONA
            Me.Cu_BuscarPersonaAprueba.DT_BUSCARPERSONA = dsCargar.Tables(8)
            Me.Cu_BuscarPersonaAprueba.Cb_Persona.DataSource = Me.Cu_BuscarPersonaAprueba.DT_BUSCARPERSONA
            Me.Cu_BuscarPersonaAutoriza.DT_BUSCARPERSONA = dsCargar.Tables(9)
            Me.Cu_BuscarPersonaAutoriza.Cb_Persona.DataSource = Me.Cu_BuscarPersonaAutoriza.DT_BUSCARPERSONA
            Me.Cu_BuscarPersonaRevisa.DT_BUSCARPERSONA = dsCargar.Tables(10)
            Me.Cu_BuscarPersonaRevisa.Cb_Persona.DataSource = Me.Cu_BuscarPersonaRevisa.DT_BUSCARPERSONA
            Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "RQ", "SOLICITA", -1)
            Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "RQ", "AUTORIZA", -1)
            Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "RQ", "REVISA", -1)
            Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "RQ", "APRUEBA", -1)
        Else
            Me.Ck_Stock.Enabled = False
            Me.Ck_RecGasto.Enabled = False
            Me.Cb_TipoReq.Enabled = False
            Me.Cb_TipoItem.Enabled = False
            Me.Ck_Incorporable.Enabled = False
            Me.Cb_TipoPrioridad.Enabled = True
        End If
        'CargarCombos ()
        LlenarRequisición()
    End Sub





    ''' <summary>
    ''' 
    ''' </summary>
    'Private Sub CargarCombos()


    'Ck_RecGasto.Checked = False
    'Me.Cb_TipoReq.Enabled = False

    '    Me.DsRequisicion.MA_TIPOITEMREQUISICION.Rows.Add("A", "Item Adicional")
    '    Me.DsRequisicion.MA_TIPOITEMREQUISICION.Rows.Add("M", "Item Mayor Cantidad")
    '    Me.DsRequisicion.MA_TIPOITEMREQUISICION.Rows.Add("P", "Item de Pago Contractual")
    '    Me.DsRequisicion.MA_TIPOITEMREQUISICION.Rows.Add("N", "No aplica")
    '    Me.Cb_TipoItem.DataSource = Me.DsRequisicion.MA_TIPOITEMREQUISICION
    '    Me.Cb_TipoItem.DisplayMember = "NOMBRE"
    '    Me.Cb_TipoItem.ValueMember = "CODIGO"
    '    Me.Cb_TipoItem.SelectedIndex = -1

    'Me.Cb_TipoReq.SelectedValue = "N"
    'Me.Cb_TipoItem.SelectedValue = "N"
    'Me.Cb_TipoPrioridad.SelectedValue = "N"
    'End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdRequisicionModificando"></param>
    'Private Sub CargarRequisicion(IdRequisicionModificando As Integer)
    '    comando = New SqlCommand("SELECT * FROM RQ_Requisicion(@IDREQUISICION)", conexion)
    '    comando.Parameters.AddWithValue("@IDREQUISICION", IdRequisicionModificando)
    '    adaptador = New SqlDataAdapter(comando)
    '    Try
    '        conexion.Open()
    '        adaptador.Fill(dtRequisicion)
    '        conexion.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        conexion.Close()
    '    End Try
    'End Sub


    ' ''' <summary>
    ' ''' 
    ' ''' </summary>
    'Private Sub CargarItemsRequisicion()
    '    comando = New SqlCommand("SELECT * FROM RQ_ItemRequisicion(@IDREQUISICION)", conexion)
    '    comando.Parameters.AddWithValue("@IDREQUISICION", IDREQUISICIONMODIFICANDO)
    '    adaptador = New SqlDataAdapter(comando)
    '    Try
    '        conexion.Open()
    '        adaptador.Fill(dtItemRequisicion)
    '        conexion.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        conexion.Close()
    '    End Try
    'End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub LlenarRequisición()


        Me.Cu_CentroCosto1.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoBodegaActual
        Me.Cu_CentroCosto1.CargarCentro()
        Me.AOT.Identificador = -1
        Me.AOT.Ll_Asociar.Text = "SIN ASOCIAR OT"
        If EDITANDO = True Then
            Me.Cu_CentroCosto1.IdCentroCosto = filarequisición("IDCENTROCOSTO")
            Me.Cu_CentroCosto1.Ll_CentroCostos.Text = filarequisición("CENTROCOSTO")
            Me.Cu_CentroCosto1.Editando = 1 'Se esta editando la RQ
            Me.Cb_TipoPrioridad.SelectedValue = filarequisición("CODIGOTIPOPRIORIDAD")
            Me.Tb_Destino.Text = Trim(filarequisición("DESTINO"))
            Me.Tb_Justificacion.Text = Trim(filarequisición("JUSTIFICACION"))

            Me.Cu_BuscarPersonaSolicita.DT_BUSCARPERSONA = dsCargar.Tables(7)
            Me.Cu_BuscarPersonaSolicita.Cb_Persona.DataSource = Me.Cu_BuscarPersonaSolicita.DT_BUSCARPERSONA
            Me.Cu_BuscarPersonaAprueba.DT_BUSCARPERSONA = dsCargar.Tables(8)
            Me.Cu_BuscarPersonaAprueba.Cb_Persona.DataSource = Me.Cu_BuscarPersonaAprueba.DT_BUSCARPERSONA
            Me.Cu_BuscarPersonaAutoriza.DT_BUSCARPERSONA = dsCargar.Tables(9)
            Me.Cu_BuscarPersonaAutoriza.Cb_Persona.DataSource = Me.Cu_BuscarPersonaAutoriza.DT_BUSCARPERSONA
            Me.Cu_BuscarPersonaRevisa.DT_BUSCARPERSONA = dsCargar.Tables(10)
            Me.Cu_BuscarPersonaRevisa.Cb_Persona.DataSource = Me.Cu_BuscarPersonaRevisa.DT_BUSCARPERSONA
            Me.Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue = Trim(filarequisición("IDPERSONASOLICITA"))
            Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = Trim(filarequisición("IDPERSONAAPRUEBA"))
            Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue = Trim(filarequisición("IDPERSONAREVISA"))
            Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = Trim(filarequisición("IDPERSONAAUTORIZA"))

            Me.Cb_Actividad.SelectedValue = filarequisición("IDACTIVIDADPRINCIPAL")
            If ((filarequisición("IDORDENTRABAJO") Is DBNull.Value)) Then
                filarequisición("IDORDENTRABAJO") = -1
            End If

            If filarequisición("IDORDENTRABAJO") = -1 Then
                Me.AOT.Identificador = -1
                Me.AOT.Ll_Asociar.Text = "SIN ASOCIAR OT"
            Else
                Me.AOT.Identificador = filarequisición("IDORDENTRABAJO")
                Me.AOT.Ll_Asociar.Text = filarequisición("NROORDENSAP")
            End If

            familia = filarequisición("IDFAMILIAMATERIAL")

            Select Case filarequisición("STOCKBODEGA")
                Case "S"
                    Me.Ck_Stock.CheckState = CheckState.Checked
                    Me.Ck_Incorporable.Checked = False
                    Me.Cb_TipoItem.SelectedValue = "N"
                    Me.Cb_TipoReq.SelectedValue = "N"
                Case "N"
                    Me.Ck_Stock.CheckState = CheckState.Unchecked
                    Me.Cb_TipoReq.SelectedValue = filarequisición("CODIGOTIPOREQUISICION")
                    If filarequisición("INCORPORABLE") = "S" Then
                        Me.Ck_Incorporable.Checked = True
                        Me.Cb_TipoItem.SelectedValue = filarequisición("CODIGOTIPOITEM")
                    Else
                        Me.Ck_Incorporable.Checked = False
                        Me.Cb_TipoItem.SelectedValue = "N"
                    End If
                Case Else
                    Me.Ck_Stock.CheckState = CheckState.Indeterminate
            End Select
            Me.Cb_TipoReq.SelectedValue = Me.filarequisición("CODIGOTIPOREQUISICION")
            If Me.Cb_TipoReq.SelectedValue <> "N" Then
                Me.Ck_RecGasto.Checked = True
                Me.Cb_TipoReq.Enabled = False
            Else
                Me.Ck_RecGasto.Checked = False
            End If
            Try
                Cu_AsociarActivoFijo1.IdEquipo = filarequisición("IDEQUIPO")
                Cu_AsociarActivoFijo1.Ll_ActivoFijo.Text = filarequisición("EQUIPO")
            Catch
            End Try
            Try
                Tb_Encabezado.Text = Trim(filarequisición("ENCABEZADO"))
            Catch
                Tb_Encabezado.Text = ""
            End Try
            Bt_GestionarActividades.Enabled = False
        End If

        'CargarItemsRequisicion()
        dtItemRequisicion = dsCargar.Tables(1)
        Me.Dgv_ItemRequisicion.DataSource = dtItemRequisicion 'LISTAITEMREQUISICION
        Comportamiento_Predeterminado()
        'Me.Cu_CentroCosto1.CargarCentro()

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdArticulo"></param>
    ''' <param name="ItemLista"></param>
    ''' <returns></returns>
    Private Function ValidarItemsRQ(ByVal IdArticulo As Integer, ByVal ItemLista As Integer) As Boolean
        Dim filas As DataRow()

        'dtItemRequisicion = dsCargar.Tables(1)

        If ItemLista = -1 Then
            filas = dtItemRequisicion.Select("IDARTICULO=" + IdArticulo.ToString + " AND NROITEM<>0") 'LISTAITEMREQUISICION
        Else
            filas = dtItemRequisicion.Select("IDARTICULO=" + IdArticulo.ToString + " AND NROITEM<>" + ItemLista.ToString) 'LISTAITEMREQUISICION
        End If
        If filas.Length > 0 Then
            ValidarItemsRQ = False
            Exit Function
        End If
        ValidarItemsRQ = True
    End Function


    '
    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_ItemRequisicion.CellEndEdit
        If IsDBNull(Me.Dgv_ItemRequisicion.Item(e.ColumnIndex, e.RowIndex).Value) Then
            Me.Dgv_ItemRequisicion.Item(e.ColumnIndex, e.RowIndex).Value = 0
        End If
        If Trim(Me.Dgv_ItemRequisicion.Item(e.ColumnIndex, e.RowIndex).Value) = "" Then
            If e.RowIndex > 0 Then
                Me.Dgv_ItemRequisicion.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                Me.Dgv_ItemRequisicion.Rows(e.RowIndex).ErrorText = ""
            Else
                Try
                    Me.Dgv_ItemRequisicion.Rows.RemoveAt(e.RowIndex)
                Catch
                End Try
            End If
            Exit Sub
        End If

        Dim IDARTICULO As Integer = -1
        Dim ITEM As Integer = -1
        If Not IsDBNull(Me.Dgv_ItemRequisicion.Item(Col_IdArticulo.Name, e.RowIndex).Value) Then
            IDARTICULO = Me.Dgv_ItemRequisicion.Item(Col_IdArticulo.Name, e.RowIndex).Value
        End If
        If Not IsDBNull(Me.Dgv_ItemRequisicion.Item(Col_Item.Name, e.RowIndex).Value) Then
            ITEM = Me.Dgv_ItemRequisicion.Item(Col_Item.Name, e.RowIndex).Value
        End If
        Dim CANTIDAD As Double = -1
        If Not IsDBNull(Me.Dgv_ItemRequisicion.Item(Col_Cantidad.Name, e.RowIndex).Value) Then
            CANTIDAD = Me.Dgv_ItemRequisicion.Item(Col_Cantidad.Name, e.RowIndex).Value
        End If

        Dim Estilo_Celda As New DataGridViewCellStyle
        Estilo_Celda.BackColor = Color.White
        Me.Dgv_ItemRequisicion.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda
        Me.Dgv_ItemRequisicion.Rows(e.RowIndex).ErrorText = ""

        'Validar Artículo
        Select Case e.ColumnIndex
            Case Dgv_ItemRequisicion.Columns(Col_IdArticulo.Name).Index '1
                If ValidarItemsRQ(IDARTICULO, ITEM) = True Then
                    Dim FilasArticulos As DataRow()
                    Dim FilaArticulo As DataRow
                    Dim FilasFamilias As DataRow()
                    Dim FilasFamilia As DataRow
                    Dim NuevaFilaItem As DataRow

                    Dim articulos As New DataTable()
                    Dim Cadena_Consulta As String = "SELECT * FROM dbo.DatosArticuloxBodegaRQ(" & IDARTICULO & "," & VariablesBase.VariablesBase.IdBodegaActual & ")"
                    Dim Consulta As New SqlCommand(Cadena_Consulta)
                    Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                    Consulta.Connection = Conexión
                    Dim Adaptador As New SqlDataAdapter(Consulta)
                    Consulta.Connection.Open()
                    Adaptador.FillSchema(articulos, SchemaType.Source)
                    Adaptador.Fill(articulos)
                    Consulta.Connection.Close()
                    If Me.Dgv_ItemRequisicion.Rows.Count > 2 Then
                        FilasArticulos = articulos.Select("ID=" + IDARTICULO.ToString + " AND IDFAMILIAMATERIAL='" + familia.ToString + "'")
                    Else
                        FilasArticulos = articulos.Select("ID=" + IDARTICULO.ToString)
                    End If
                    If FilasArticulos.Length > 0 Then
                        FilaArticulo = FilasArticulos(0)
                        familia = FilaArticulo("IDFAMILIAMATERIAL")
                        FilasFamilias = dtFamiliaMateriales.Select("IDFAMILIAMATERIAL=" + familia.ToString)
                        FilasFamilia = FilasFamilias(0)
                        NombreFamilia = FilasFamilia("NOMBREFAMILIAMATERIAL")

                        Me.Ck_Stock.Enabled = False
                        Me.Cb_TipoReq.Enabled = False
                        Me.Ck_RecGasto.Enabled = False
                        Me.Cb_TipoItem.Enabled = False
                        Me.Ck_Incorporable.Enabled = False
                        FilaArticulo = FilasArticulos(0)

                        NuevaFilaItem = dtItemRequisicion.NewRow 'LISTAITEMREQUISICION
                        NuevaFilaItem("IDARTICULO") = IDARTICULO
                        NuevaFilaItem("NROITEM") = e.RowIndex + 1
                        NuevaFilaItem("CODIGOTIPOUNIDAD") = FilaArticulo("CODIGOTIPOUNIDAD")
                        NuevaFilaItem("ABREVIATURA") = FilaArticulo("UND")

                        NuevaFilaItem("CANTIDADSOLICITADA") = 0
                        NuevaFilaItem("CANTIDADEXISTENCIA") = FilaArticulo("CANTIDADEXISTENCIA")
                        NuevaFilaItem("CANTEXISTENCIAPPAL") = FilaArticulo("CANTEXISTENCIAPPAL")
                        NuevaFilaItem("CANTADQUISICIONLOCAL") = FilaArticulo("CANTADQUISICIONLOCAL")
                        NuevaFilaItem("CANTADQUISICIONPPAL") = FilaArticulo("CANTADQUISICIONPPAL")
                        NuevaFilaItem("NOMBREDESCRIPTIVO") = Trim(FilaArticulo("NOMBRE"))
                        If dtItemRequisicion.Rows.Count = Me.Dgv_ItemRequisicion.CurrentCell.RowIndex Then 'LISTAITEMREQUISICION
                            Try
                                Me.Dgv_ItemRequisicion.Rows.RemoveAt(e.RowIndex)
                            Catch
                            End Try
                            dtItemRequisicion.Rows.Add(NuevaFilaItem) 'LISTAITEMREQUISICION
                        Else
                            dtItemRequisicion.Rows(e.RowIndex).Item("IDARTICULO") = NuevaFilaItem("IDARTICULO") 'LISTAITEMREQUISICION
                            dtItemRequisicion.Rows(e.RowIndex).Item("NROITEM") = NuevaFilaItem("NROITEM") 'LISTAITEMREQUISICION
                            dtItemRequisicion.Rows(e.RowIndex).Item("CODIGOTIPOUNIDAD") = NuevaFilaItem("CODIGOTIPOUNIDAD") 'LISTAITEMREQUISICION
                            dtItemRequisicion.Rows(e.RowIndex).Item("ABREVIATURA") = NuevaFilaItem("ABREVIATURA") 'LISTAITEMREQUISICION
                            dtItemRequisicion.Rows(e.RowIndex).Item("CANTIDADSOLICITADA") = NuevaFilaItem("CANTIDADSOLICITADA") 'LISTAITEMREQUISICION
                            dtItemRequisicion.Rows(e.RowIndex).Item("CANTIDADEXISTENCIA") = NuevaFilaItem("CANTIDADEXISTENCIA") 'LISTAITEMREQUISICION
                            dtItemRequisicion.Rows(e.RowIndex).Item("NOMBREDESCRIPTIVO") = NuevaFilaItem("NOMBREDESCRIPTIVO") 'LISTAITEMREQUISICION
                        End If
                    Else
                        'No existe un artículo con este código
                        MensajeError = "No se encontró un artículo con ese código"
                        MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Artículo no Encontrado")
                        Try
                            Me.Dgv_ItemRequisicion.Rows.RemoveAt(e.RowIndex)
                        Catch
                        End Try
                    End If
                Else
                    MensajeError = "El item que desea ingresar, ya se encuentra incluido en la requisición"
                    MsgBox(MensajeError, MsgBoxStyle.Critical, "Item Repetido")
                    Try
                        Me.Dgv_ItemRequisicion.Rows.RemoveAt(e.RowIndex)
                    Catch
                    End Try
                End If
            Case Dgv_ItemRequisicion.Columns(Col_Cantidad.Name).Index '4
                If Trim(CANTIDAD) = "" Then
                    Me.Dgv_ItemRequisicion.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                    MensajeError = "El campo Cantidad Solicitada no es valido"
                    Me.Dgv_ItemRequisicion.Rows(e.RowIndex).ErrorText = MensajeError
                Else
                    If Not IsNumeric(CANTIDAD) Then
                        Me.Dgv_ItemRequisicion.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                        MensajeError = "El campo Cantidad Solicitada no es valido"
                        Me.Dgv_ItemRequisicion.Rows(e.RowIndex).ErrorText = MensajeError
                    Else
                        If CANTIDAD <= 0 Then
                            Me.Dgv_ItemRequisicion.Rows(e.RowIndex).DefaultCellStyle = Estilo_Celda_Error
                            MensajeError = "El campo Cantidad Solicitada no es valido"
                            Me.Dgv_ItemRequisicion.Rows(e.RowIndex).ErrorText = MensajeError
                        End If
                    End If
                End If
        End Select
        ELiminarFilaVacia()
    End Sub


    '
    Private Sub Dgv_ItemRequisicion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv_ItemRequisicion.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F3 Then
            Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
            If EDITANDO = False Then
                FrBuscarArtículo.FiltrarInactivos = True
            End If
            If NombreFamilia = "-1" Then
                FrBuscarArtículo.Familia = NombreFamilia

                FrBuscarArtículo._Tipo = "T"
                FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda
            Else
                FrBuscarArtículo.Familia = NombreFamilia
                FrBuscarArtículo._Tipo = "T"
                FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda por familia, falta implementar
            End If
            FrBuscarArtículo.ShowDialog()
            If Trim(FrBuscarArtículo.IdArtículo) = 0 Then
                If FrBuscarArtículo.Actualizar = False Then
                    Exit Sub
                End If
            End If

            NombreFamilia = FrBuscarArtículo.Familia
            If ValidarItemsRQ(FrBuscarArtículo.IdArtículo, -1) = True Then
                Dim FilasArticulos As DataRow()
                Dim articulos As New DataTable()
                Dim Cadena_Consulta As String = "SELECT * FROM dbo.DatosArticuloxBodegaRQ(" & FrBuscarArtículo.IdArtículo.ToString & "," & VariablesBase.VariablesBase.IdBodegaActual & ")" 'DatosArticuloxBodega
                Dim Consulta As New SqlCommand(Cadena_Consulta)
                Dim Conexión As New SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
                Consulta.Connection = Conexión
                Dim Adaptador As New SqlDataAdapter(Consulta)
                Consulta.Connection.Open()
                Adaptador.FillSchema(articulos, SchemaType.Source)
                Adaptador.Fill(articulos)
                Consulta.Connection.Close()
                If Me.Dgv_ItemRequisicion.Rows.Count > 2 Then
                    FilasArticulos = articulos.Select("ID=" + FrBuscarArtículo.IdArtículo.ToString + " AND IDFAMILIAMATERIAL='" + familia.ToString + "'")
                Else
                    FilasArticulos = articulos.Select("ID=" + FrBuscarArtículo.IdArtículo.ToString)
                End If
                If FilasArticulos.Length > 0 Then
                    Dim FilaArticulo As DataRow
                    FilaArticulo = FilasArticulos(0)
                    Dim NuevaFilaItem As DataRow
                    NuevaFilaItem = dtItemRequisicion.NewRow 'LISTAITEMREQUISICION
                    NuevaFilaItem("IDARTICULO") = FrBuscarArtículo.IdArtículo
                    NuevaFilaItem("NROITEM") = dtItemRequisicion.Rows.Count + 1 'LISTAITEMREQUISICION
                    NuevaFilaItem("CODIGOTIPOUNIDAD") = FilaArticulo("CODIGOTIPOUNIDAD")
                    NuevaFilaItem("ABREVIATURA") = FilaArticulo("UND")
                    NuevaFilaItem("CANTIDADSOLICITADA") = DBNull.Value
                    NuevaFilaItem("CANTIDADEXISTENCIA") = FilaArticulo("CANTIDADEXISTENCIA")
                    NuevaFilaItem("CANTEXISTENCIAPPAL") = FilaArticulo("CANTEXISTENCIAPPAL")
                    NuevaFilaItem("CANTADQUISICIONLOCAL") = FilaArticulo("CANTADQUISICIONLOCAL")
                    NuevaFilaItem("CANTADQUISICIONPPAL") = FilaArticulo("CANTADQUISICIONPPAL")
                    NuevaFilaItem("NOMBREDESCRIPTIVO") = FilaArticulo("NOMBRE")
                    dtItemRequisicion.Rows.Add(NuevaFilaItem) 'LISTAITEMREQUISICION
                    familia = FilaArticulo("IDFAMILIAMATERIAL")
                Else
                    'No existe un artículo con este código
                    MensajeError = "No se encontró un artículo con ese código"
                    MsgBox(MensajeError, MsgBoxStyle.Exclamation, "Artículo no Encontrado")
                End If
            Else
                MensajeError = "El item que desea ingresar, ya se encuentra incluido en la requisición"
                MsgBox(MensajeError, MsgBoxStyle.Critical, "Item Repetido")
            End If
            ELiminarFilaVacia()
        ElseIf e.KeyCode = Windows.Forms.Keys.Delete Then 'SI PRESIONA PARA ELIMINAR FILA
            Try
                If Me.Dgv_ItemRequisicion.SelectedRows Is Nothing Then Exit Sub

                Dim selectedRowCount As Integer = Dgv_ItemRequisicion.Rows.GetRowCount(DataGridViewElementStates.Selected)
                For I As Integer = 0 To selectedRowCount - 1
                    Me.Dgv_ItemRequisicion.Rows.Remove(Dgv_ItemRequisicion.SelectedRows(0))
                Next
            Catch
            End Try

            Try
                dtItemRequisicion.AcceptChanges() 'LISTAITEMREQUISICION
            Catch
            End Try
            If Me.Dgv_ItemRequisicion.Rows.Count > 1 Then
                For x As Integer = Dgv_ItemRequisicion.CurrentCell.RowIndex To dtItemRequisicion.Rows.Count - 1
                    If Not IsDBNull(dtItemRequisicion.Rows(x).Item(Col_NroItem.DataPropertyName)) Then 'LISTAITEMREQUISICION
                        dtItemRequisicion.Rows(x).Item(Col_NroItem.DataPropertyName) = x + 1 'LISTAITEMREQUISICION
                    End If
                Next
            Else
                NombreFamilia = "-1"
            End If
            If Me.Dgv_ItemRequisicion.Rows.Count = 1 Then
                Ck_Stock.Enabled = True
                Select Case Ck_Stock.CheckState
                    Case CheckState.Checked
                        Cb_TipoReq.Enabled = False
                        Ck_Incorporable.Enabled = False
                    Case CheckState.Unchecked
                        Me.Cb_TipoReq.Enabled = True
                        Me.Ck_Incorporable.Enabled = True
                        If Ck_Incorporable.Checked = True Then
                            Cb_TipoItem.Enabled = True
                        Else
                            Cb_TipoItem.Enabled = False
                        End If
                End Select
                Me.Ck_RecGasto.Enabled = True
                If Me.Ck_RecGasto.Checked = True Then
                    Me.Cb_TipoReq.Enabled = True
                End If
            End If
            ELiminarFilaVacia()
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub GuardarRequisición()
        If ValidarCasillas() = False Then
            Exit Sub
        End If
        Dim TablaItemRQ As New DataTable
        TablaItemRQ.Columns.Add("IDARTICULO")
        TablaItemRQ.Columns.Add("NROITEM")
        TablaItemRQ.Columns.Add("CODIGOTIPOUNIDAD")
        TablaItemRQ.Columns.Add("CANTIDADSOLICITADA")
        TablaItemRQ.Columns.Add("CANTIDADEXISTENCIA")
        TablaItemRQ.Columns.Add("CANTEXISTENCIAPPAL")
        TablaItemRQ.Columns.Add("CANTADQUISICIONLOCAL")
        TablaItemRQ.Columns.Add("CANTADQUISICIONPPAL")
        TablaItemRQ.Columns.Add("AUTORIZADO")
        TablaItemRQ.Columns.Add("ESTADO")
        TablaItemRQ.Columns.Add("TIPO")
        Dim Fila As DataRow
        For i = 0 To dtItemRequisicion.Rows.Count - 1 'LISTAITEMREQUISICION
            Dim FilaListaRequisición As DataRow
            FilaListaRequisición = dtItemRequisicion.Rows(i) 'LISTAITEMREQUISICION
            Fila = TablaItemRQ.NewRow
            Fila("IDARTICULO") = FilaListaRequisición("IDARTICULO")
            Fila("NROITEM") = FilaListaRequisición("NROITEM")
            Fila("CODIGOTIPOUNIDAD") = FilaListaRequisición("CODIGOTIPOUNIDAD")
            Fila("CANTIDADSOLICITADA") = Replace(FilaListaRequisición("CANTIDADSOLICITADA"), ",", ".")
            Fila("CANTIDADEXISTENCIA") = Replace(FilaListaRequisición("CANTIDADEXISTENCIA"), ",", ".")
            Fila("CANTEXISTENCIAPPAL") = Replace(FilaListaRequisición("CANTEXISTENCIAPPAL"), ",", ".")
            Fila("CANTADQUISICIONLOCAL") = Replace(FilaListaRequisición("CANTADQUISICIONLOCAL"), ",", ".")
            Fila("CANTADQUISICIONPPAL") = Replace(FilaListaRequisición("CANTADQUISICIONPPAL"), ",", ".")
            Fila("AUTORIZADO") = DBNull.Value
            Fila("ESTADO") = "P"
            Fila("TIPO") = TIPO.ToString
            TablaItemRQ.Rows.Add(Fila)
        Next
        Dim Comando As New SqlCommand("dbo.GestionarRequisicion")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TIPO", TIPO)
        Comando.Parameters.AddWithValue("@TableItemRQ", TablaItemRQ)
        Comando.Parameters.AddWithValue("@IDREQUISICION", IDREQUISICIONMODIFICANDO)
        Comando.Parameters.AddWithValue("@CONS", "0")
        Comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        Comando.Parameters.AddWithValue("@IDFAMILIAMATERIAL", familia)
        Comando.Parameters.AddWithValue("@AÑO", Now.Year)
        Comando.Parameters.AddWithValue("@IDUSUARIOREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@IDUSUARIOMODIFICA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@DESTINO", Trim(Me.Tb_Destino.Text))
        Comando.Parameters.AddWithValue("@JUSTIFICACION", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tb_Justificacion.Text))
        Comando.Parameters.AddWithValue("@CODIGOPRIORIDAD", Me.Cb_TipoPrioridad.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONASOLICITA", Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAAUTORIZA", Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAREVISA", Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAAPRUEBA", Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@ESTADO", "P")
        Comando.Parameters.AddWithValue("@IMPRESA", "N")
        Comando.Parameters.AddWithValue("@IDCENTROCOSTO", Me.Cu_CentroCosto1.IdCentroCosto)
        Comando.Parameters.AddWithValue("@IDORDENTRABAJO", Me.AOT.Identificador)
        Select Case Ck_Stock.CheckState
            Case CheckState.Checked
                Comando.Parameters.AddWithValue("@INCORPORABLE", "N")
                Comando.Parameters.AddWithValue("@STOCKBODEGA", "S")
                Comando.Parameters.AddWithValue("@CODIGOTIPOITEM", "N")
                Comando.Parameters.AddWithValue("@CODIGOTIPOREQUISICION", "N")
            Case CheckState.Unchecked
                Comando.Parameters.AddWithValue("@STOCKBODEGA", "N")
                Comando.Parameters.AddWithValue("@CODIGOTIPOREQUISICION", Me.Cb_TipoReq.SelectedValue)
                If Ck_Incorporable.Checked = True Then
                    Comando.Parameters.AddWithValue("@INCORPORABLE", "S")
                    Comando.Parameters.AddWithValue("@CODIGOTIPOITEM", Cb_TipoItem.SelectedValue)
                Else
                    Comando.Parameters.AddWithValue("@INCORPORABLE", "N")
                    Comando.Parameters.AddWithValue("@CODIGOTIPOITEM", "N")
                End If
        End Select
        Comando.Parameters.AddWithValue("@IDACTIVIDADPRINCIPAL", Cb_Actividad.SelectedValue)
        If Me.Cu_AsociarActivoFijo1.IdEquipo = -1 Then
            Comando.Parameters.AddWithValue("@IDEQUIPO", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@IDEQUIPO", Me.Cu_AsociarActivoFijo1.IdEquipo)
        End If
        Comando.Parameters.AddWithValue("@ENCABEZADO", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tb_Encabezado.Text))

        Dim msgParam As New SqlParameter("@CONSECUTIVO", SqlDbType.NChar, 5)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)

        Dim msgParam1 As New SqlParameter("@VALIDACION", SqlDbType.Int)
        msgParam1.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam1)

        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Try
            Comando.ExecuteNonQuery()
            conn.Close()
            '1: tiene salidas de almacen, 2: tiene orden de compra
            If Trim(msgParam.Value.ToString.Trim) <> "0" Then
                Dim Consecutivo As String
                Consecutivo = VariablesBase.VariablesBase.AbreviaturaBodegaActual & "." & Now.Year & msgParam.Value
                If TIPO = 1 Then
                    MsgBox("El código del la requisición es: " & Consecutivo)
                    'Guardar valores por defecto para personas
                    FuncionesBase.FuncionesBase.ValoresxDefecto("G", "RQ", "SOLICITA", Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue)
                    FuncionesBase.FuncionesBase.ValoresxDefecto("G", "RQ", "AUTORIZA", Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue)
                    FuncionesBase.FuncionesBase.ValoresxDefecto("G", "RQ", "REVISA", Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue)
                    FuncionesBase.FuncionesBase.ValoresxDefecto("G", "RQ", "APRUEBA", Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue)
                ElseIf TIPO = 2 Then
                    MsgBox("La requisición ha sido modificada satisfactoriamente.")
                ElseIf TIPO = 3 Then
                    MsgBox("La requisición ha sido eliminada satisfactoriamente.")
                End If
                guardado = True
            ElseIf msgParam1.Value.ToString.Trim = -1 Then
                MsgBox("No fue posible actualizar la requisición dado que tiene Entradas de Almacén o Salidas de Almacén asociadas a la Requisición.", , "Actualización Fallida")
                guardado = False
            ElseIf msgParam1.Value.ToString.Trim = -2 Then
                MsgBox("No fue posible actualizar la requisición dado que tiene Orden de Compra asociadas a la Requisición.", , "Actualización Fallida")
                guardado = False
            End If
            Me.Close()
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.ToString)
            guardado = False
        End Try
    End Sub


    '
    Private Sub Bt_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Guardar.Click
        GuardarRequisición()
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDPERSONA"></param>
    ''' <param name="NOMBRECOMPONENTE"></param>
    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1, Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaSolicita.CargarDatos()
            Me.Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaSolicita.CargarCajaTexto()
        Catch
        End Try
        Try
            temp = Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaAutoriza.CargarDatos()
            Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaAutoriza.CargarCajaTexto()
        Catch
        End Try
        Try
            temp = Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaRevisa.CargarDatos()
            Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaRevisa.CargarCajaTexto()
        Catch
        End Try
        Try
            temp = Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaAprueba.CargarDatos()
            Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaAprueba.CargarCajaTexto()
        Catch
        End Try
        Select Case NOMBRECOMPONENTE
            Case Cu_BuscarPersonaSolicita.Name
                Me.Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaAutoriza.Name
                Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaRevisa.Name
                Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaAprueba.Name
                Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="NombreComponente"></param>
    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Me.Cu_BuscarPersonaSolicita.Name
                Try
                    filas = Cu_BuscarPersonaSolicita.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaSolicita.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaSolicita.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaAutoriza.Name
                Try
                    filas = Cu_BuscarPersonaAutoriza.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaAutoriza.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaAutoriza.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaRevisa.Name
                Try
                    filas = Cu_BuscarPersonaRevisa.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaRevisa.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaRevisa.Tx_TextoCódigo.Text = ""
                End Try
            Case Me.Cu_BuscarPersonaAprueba.Name
                Try
                    filas = Cu_BuscarPersonaAprueba.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaAprueba.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch
                    Me.Cu_BuscarPersonaAprueba.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub


    '
    Private Sub Bt_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub


    '
    Private Sub Tb_Destino_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tb_Destino.GotFocus
        Me.Tb_Destino.BackColor = Color.White
    End Sub


    '
    Private Sub Tb_Destino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tb_Destino.LostFocus
        If Trim(Me.Tb_Destino.Text) = "" Then
            Me.Tb_Destino.BackColor = Color.Red
        Else
            Me.Tb_Destino.BackColor = Color.White
        End If
    End Sub


    '
    Private Sub Fr_Requisicion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If guardado = False And Me.Bt_Guardar.Enabled = True Then
            If MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "SALIR SIN GUARDAR") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                If IDREQUISICIONMODIFICANDO <> -1 Then
                    VariablesBase.VariablesBase.IdBodegaActual = tempbodega
                End If
            End If
        Else
            If IDREQUISICIONMODIFICANDO <> -1 Then
                VariablesBase.VariablesBase.IdBodegaActual = tempbodega
            End If
        End If
    End Sub


    '
    Private Sub Ck_Stock_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ck_Stock.CheckStateChanged
        If Ck_Stock.CheckState <> CheckState.Indeterminate Then
            Ck_Stock.ThreeState = False
            Ck_RecGasto.Enabled = True
            Ck_Incorporable.Enabled = True
            If Ck_Stock.CheckState = CheckState.Checked Then
                Ck_Incorporable.Enabled = False
            Else 'CheckState.Unchecked
                Ck_Incorporable.Enabled = True
            End If
        Else 'CheckState.Indeterminate
            Ck_RecGasto.Enabled = True
            Ck_Incorporable.Enabled = True
        End If
        Ck_Incorporable.Checked = False
        Cb_TipoItem.Enabled = False
        Cb_TipoItem.SelectedValue = "N"
    End Sub


    '
    Private Sub Ck_Incorporable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ck_Incorporable.CheckedChanged
        If Ck_Incorporable.Checked = True Then
            Cb_TipoItem.Enabled = True
            Cb_TipoItem.SelectedIndex = -1
        Else
            Cb_TipoItem.Enabled = False
            Cb_TipoItem.SelectedValue = "N"
        End If
    End Sub


    '
    Private Sub Ck_RecGasto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Ck_RecGasto.CheckedChanged
        If Me.Ck_RecGasto.Checked = True Then
            Cb_TipoReq.Enabled = True
            Cb_TipoReq.SelectedIndex = -1
        Else
            Cb_TipoReq.Enabled = False
            Cb_TipoReq.SelectedValue = "N"
        End If
    End Sub


    '
    Private Sub Cb_TipoItem_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_TipoItem.SelectedIndexChanged
        Try
            If Cb_TipoItem.SelectedValue = "N" Then
                Cb_TipoItem.Enabled = False
                Ck_Incorporable.Checked = False
            End If
        Catch
        End Try
    End Sub


    '
    Private Sub Dgv_ItemRequisicion_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Dgv_ItemRequisicion.DataError
        If e.Exception IsNot Nothing AndAlso e.Context = DataGridViewDataErrorContexts.Commit Then
            MessageBox.Show("Favor comunicarse con el personal de sistemas")
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ELiminarFilaVacia()
        Try
            For i = 0 To Dgv_ItemRequisicion.Rows.Count - 2
                If IsDBNull(Me.Dgv_ItemRequisicion.Rows(i).Cells(Col_Descripcion.Name).Value) Then
                    Me.Dgv_ItemRequisicion.Rows.RemoveAt(i)
                End If
            Next
        Catch
        End Try
    End Sub


    '
    Private Sub Ll_ActualizarContacto_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_ActualizarContacto.LinkClicked
        If MsgBox("Desea ver o actualizar los contactos asociados al documento", MsgBoxStyle.YesNo, "Ver o Actualizar Contactos") = MsgBoxResult.Yes Then
            If Me.Cu_BuscarPersonaSolicita.Cb_Persona.SelectedIndex <> -1 And
                Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedIndex <> -1 And
                Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedIndex <> -1 And
                Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedIndex <> -1 Then
                Dim FrActualizarContacto As New FormulariosClasesBase.Fr_ActualizarContacto
                FrActualizarContacto.Bt_Aceptar.Enabled = Me.Bt_Guardar.Enabled
                FrActualizarContacto.Cu_Contacto1.IDPERSONA = Me.Cu_BuscarPersonaSolicita.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto1.Gb_Contacto.Text = "Solicita: " + Me.Cu_BuscarPersonaSolicita.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto2.IDPERSONA = Me.Cu_BuscarPersonaAutoriza.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto2.Gb_Contacto.Text = "Autoriza: " + Me.Cu_BuscarPersonaAutoriza.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto3.IDPERSONA = Me.Cu_BuscarPersonaRevisa.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto3.Gb_Contacto.Text = "Revisa: " + Me.Cu_BuscarPersonaRevisa.Cb_Persona.Text
                FrActualizarContacto.Cu_Contacto4.IDPERSONA = Me.Cu_BuscarPersonaAprueba.Cb_Persona.SelectedValue
                FrActualizarContacto.Cu_Contacto4.Gb_Contacto.Text = "Aprueba: " + Me.Cu_BuscarPersonaAprueba.Cb_Persona.Text
                FrActualizarContacto.CargarDatos()
                FrActualizarContacto.ShowDialog()
            Else
                MsgBox("Debe seleccionar todas las personas que interactúan con el documento", MsgBoxStyle.Information, "Seleccionar todas las personas")
            End If
        End If
    End Sub


    '
    Private Sub Bt_AgregarActividad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_AgregarActividad.Click
        Dim NuevaActividad As String
        NuevaActividad = Trim(Mid(InputBox("Digite la actividad que desea agregar", "Agregar Actividad", ""), 1, 300))
        If NuevaActividad = "" Then
            Exit Sub
        End If
        Dim Comando As New SqlCommand("GestionarActividadPrincipal")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TablaActividadesPrincipales", Nothing)
        Comando.Parameters.AddWithValue("@ACCION", 1)
        Comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        Comando.Parameters.AddWithValue("@NOMBREACTIVIDADPRINCIPAL", UCase(NuevaActividad))
        Dim msgParam As New SqlParameter("@ACTIVIDADPRINCIPAL", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Try
            Comando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()
        Select Case Comando.Parameters("@ACTIVIDADPRINCIPAL").Value
            Case 0
                MsgBox("No se pudo realizar la operación", MsgBoxStyle.Exclamation, "No se completo la operación")
                Exit Sub
            Case Is > 0
                MsgBox("Se agrego la actividad correctamente", MsgBoxStyle.Information, "Nueva Salida de Almacén")
                CargarActividades()
                Cb_Actividad.SelectedValue = Comando.Parameters("@ACTIVIDADPRINCIPAL").Value
        End Select
    End Sub


    '
    Private Sub Bt_GestionarActividades_Click(sender As Object, e As EventArgs) Handles Bt_GestionarActividades.Click
        If EDITANDO = False Then
            Dim dr As New DialogResult
            Using frGestionarActividades As New FormulariosClasesBase.Fr_GestionarActividadPrincipal
                dr = frGestionarActividades.ShowDialog()
            End Using
            If dr <> Windows.Forms.DialogResult.Cancel Then
                CargarActividades()
            End If
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CargarActividades()
        Dim dt_Actividades As New DataTable
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("GestionarActividadPrincipal", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TablaActividadesPrincipales", Nothing)
        comando.Parameters.AddWithValue("@ACCION", 2)
        comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        comando.Parameters.AddWithValue("@NOMBREACTIVIDADPRINCIPAL", "")
        Dim msgParam As New SqlParameter("@ACTIVIDADPRINCIPAL", DbType.Int32)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Dim adaptador As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adaptador.Fill(dt_Actividades)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
        Me.Cb_Actividad.DataSource = dt_Actividades
        Me.Cb_Actividad.DisplayMember = "ACTIVIDAD"
        Me.Cb_Actividad.ValueMember = "IDACTIVIDADPRINCIPAL"
    End Sub

    Private Sub Fr_Requisicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class 'Fr_Requisicion