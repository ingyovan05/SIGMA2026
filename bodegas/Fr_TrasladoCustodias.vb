Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_TrasladoCustodias

    Dim identificacion As String = ""
    Dim ds_Custodias As New DataSet
    Dim dt_BodegaCustodias As New DataTable

    Private dvFiltrados As DataView

    Public IDENTRADAALMACENMODIFICANDO As Integer = -1
    Public IDSALIDAALMACENMODIFICANDO As Integer = -1
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos

    Public IdEntradaE As Integer
    Public IdEntradaH As Integer
    Public IdSalidaE As Integer
    Public IdSalidaH As Integer

    Public CantH As Integer
    Public CantE As Integer

    Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)


    Public Sub CargarDatos()

        Me.Cu_BuscarPersona.CargarDatos()
        Me.Cu_BuscarPersona.Cb_Persona.SelectedIndex = -1

        Me.Cu_BuscarPersona1.CargarDatos()
        Me.Cu_BuscarPersona1.Cb_Persona.SelectedIndex = -1

        Cu_BuscarPersona.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "SA", "RECIBE", -1)
        Cu_BuscarPersona1.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "SA", "AUTORIZA", -1)

        CargarActividades()
    End Sub




    Private Sub Bt_Buscar_Click(sender As Object, e As EventArgs) Handles Bt_Buscar.Click

        BuscarIdentificacion()
    End Sub

    Public Sub BuscarIdentificacion()


        Dim cnl As New FuncionesBase.Cl_Convertir_Num_Letras

        identificacion = Tx_Valor.Text

        identificacion = System.Text.RegularExpressions.Regex.Replace(identificacion, "[^0-9]", "")
        If identificacion = "" Or Not IsNumeric(identificacion) Then
            MsgBox("No se especificó un código o número de identificación válido." & Environment.NewLine _
                   & "Por favor ingrese el valor correcto para la búsqueda.", MsgBoxStyle.Exclamation, "VALOR INVÁLIDO")
        Else


            Dim FilaBodega As DataRow
            Dim IdBodega As Integer

            'Me.ds_Custodias.Clear()
            Dim con As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("dbo.ListarIdbodegaCustodia", con)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@IDENTIFICACION", identificacion)
            Dim adaptador As New SqlDataAdapter(comando)
            dt_BodegaCustodias = New DataTable
            Try
                Cursor = Cursors.WaitCursor
                con.Open()
                adaptador.Fill(dt_BodegaCustodias)
                con.Close()
                Cursor = Cursors.Default

                If dt_BodegaCustodias.Rows.Count <> 0 Then

                    If dt_BodegaCustodias.Rows.Count = 1 Then

                        FilaBodega = dt_BodegaCustodias.Rows(0)
                        IdBodega = FilaBodega("IDBODEGA")

                        If IdBodega = VariablesBase.VariablesBase.IdBodegaActual Then

                            If Not IsNothing(Dgv_Custodias.DataSource) Then
                                Dgv_Custodias.DataSource = Nothing
                            End If

                            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                            Dim comandoCustodias As New SqlCommand("dbo.ListarCustodias", conexion)
                            comandoCustodias.CommandType = CommandType.StoredProcedure
                            comandoCustodias.Parameters.AddWithValue("@TIPO", 1)
                            comandoCustodias.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                            comandoCustodias.Parameters.AddWithValue("@IDENTIFICACION", identificacion)
                            Dim adaptadorCustodias As New SqlDataAdapter(comandoCustodias)
                            Try
                                Cursor = Cursors.WaitCursor
                                conexion.Open()
                                ds_Custodias.Clear()
                                adaptadorCustodias.Fill(ds_Custodias)
                                conexion.Close()
                                Cursor = Cursors.Default
                                Dgv_Custodias.DataSource = ds_Custodias.Tables(0)
                                'AplicarFormato()
    
                            Catch es As Exception
                                conexion.Close()
                            Finally
                                conexion.Close()
                            End Try

                        Else
                            MsgBox("La persona con número de identificación " & cnl.Fun_FormatearCedula(identificacion) & "." & Environment.NewLine _
                              & " tiene custodias en una bodega diferente a " & VariablesBase.VariablesBase.NombreBodegaActual & ".", MsgBoxStyle.Exclamation, "CUSTODIA EN BODEGA DIFERENTE")
                        End If
                    Else
                        MsgBox("La persona con número de identificación " & cnl.Fun_FormatearCedula(identificacion) & "." & Environment.NewLine _
                          & " tiene custodias en más de una bodega", MsgBoxStyle.Exclamation, "CUSTODIAS EN VARIAS BODEGAS")
                    End If
                Else
                    MsgBox("No se ha encontrado la persona con número de identificación " & cnl.Fun_FormatearCedula(identificacion) & "." & Environment.NewLine _
                      & "Por favor ingrese el número de identificación correcto de la persona registrada en el sistema.", MsgBoxStyle.Exclamation, "PERSONA NO ENCONTRADA")
                    Exit Sub
                End If

            Catch es As Exception
                con.Close()
            Finally
                con.Close()
            End Try

        End If
    End Sub


    Private Sub AplicarFormato()

        Me.Dgv_Custodias.DataSource = Nothing
        Me.Dgv_Custodias.DataSource = ds_Custodias.Tables(0)
        Me.Dgv_Custodias.AutoGenerateColumns = True
        Me.Dgv_Custodias.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Dgv_Custodias.ReadOnly = True

        For i = 0 To Dgv_Custodias.ColumnCount - 1
            Select Case Dgv_Custodias.Columns(i).Name
                Case "Tipo Custodia"
                    Dgv_Custodias.Columns(i).HeaderText = "Tipo Custodia"
                    Dgv_Custodias.Columns(i).Width = 130

                Case "Id Artículo"
                    Dgv_Custodias.Columns(i).HeaderText = "Id Art."
                    Dgv_Custodias.Columns(i).Width = 50

                Case "Artículo"
                    Dgv_Custodias.Columns(i).HeaderText = "Artículo"
                    Dgv_Custodias.Columns(i).Width = 280

                Case "Cantidad"
                    Dgv_Custodias.Columns(i).HeaderText = "Cant."
                    Dgv_Custodias.Columns(i).Width = 40

                Case "Id Equipo"
                    Dgv_Custodias.Columns(i).HeaderText = "Id Eq."
                    Dgv_Custodias.Columns(i).Width = 50

                Case "Equipo"
                    Dgv_Custodias.Columns(i).HeaderText = "Equipo"
                    Dgv_Custodias.Columns(i).Width = 110

                Case "Equipo Padre"
                    Dgv_Custodias.Columns(i).HeaderText = "Equipo Padre"
                    Dgv_Custodias.Columns(i).Width = 110

                Case "MARCAR"
                    Dgv_Custodias.Columns(i).HeaderText = "Marcar"
                    Dgv_Custodias.Columns(i).Width = 50

                Case Else
                    Dgv_Custodias.Columns(i).Visible = False
            End Select
        Next
    End Sub


    Private Sub Bt_Seleccionar_Click(sender As Object, e As EventArgs) Handles Bt_Seleccionar.Click
        For i = 0 To Dgv_Custodias.RowCount - 1
            Dgv_Custodias.Rows(i).Cells("MARCAR").Value = "S"
        Next
    End Sub

    Private Sub Bt_Desseleccionar_Click(sender As Object, e As EventArgs) Handles Bt_Desseleccionar.Click
        For i = 0 To Dgv_Custodias.RowCount - 1
            Dgv_Custodias.Rows(i).Cells("MARCAR").Value = "N"
        Next
    End Sub

    Private Sub Bt_Imprimir_Click(sender As Object, e As EventArgs) Handles Bt_Imprimir.Click

        CantH = Dgv_Custodias.Rows.Cast(Of DataGridViewRow).Where(Function(x) x.Cells("TIPOCUSTODIA").Value = "Custodia de Herramienta" And x.Cells("MARCAR").Value = "S").ToList().Count
        CantE = Dgv_Custodias.Rows.Cast(Of DataGridViewRow).Where(Function(x) x.Cells("TIPOCUSTODIA").Value = "Custodia de Equipo" And x.Cells("MARCAR").Value = "S").ToList().Count


        If Validar() = True Then

            Dim TablaItemEA As New DataTable
            Dim TablaItemSA As New DataTable
            Dim TablaItemEAE As New DataTable
            Dim TablaItemSAE As New DataTable
            Dim TablaEEA As New DataTable
            Dim TablaECEA As New DataTable
            Dim _TipoCustodia As String
            Dim _Marcar As String
            Dim _IdArticulo As Integer
            Dim _IdEquipo As Integer
            Dim _IdEquipoPadre As Integer
            Dim _Cantidad As Integer


            'Entrada de Custodias
            TablaItemEA.Columns.Add("IDITEMENTRADAALMACEN")
            TablaItemEA.Columns.Add("IDORDENCOMPRA")
            TablaItemEA.Columns.Add("IDITEMORDENCOMPRA")
            TablaItemEA.Columns.Add("CANTIDAD")
            TablaItemEA.Columns.Add("IDARTICULO")
            TablaItemEA.Columns.Add("IDREQUISICION")
            TablaItemEA.Columns.Add("IDITEMREQUISICION")
            TablaItemEA.Columns.Add("NUMEROFACTURA")
            TablaItemEA.Columns.Add("IDREMISION")

            TablaItemEAE.Columns.Add("IDITEMENTRADAALMACEN")
            TablaItemEAE.Columns.Add("IDORDENCOMPRA")
            TablaItemEAE.Columns.Add("IDITEMORDENCOMPRA")
            TablaItemEAE.Columns.Add("CANTIDAD")
            TablaItemEAE.Columns.Add("IDARTICULO")
            TablaItemEAE.Columns.Add("IDREQUISICION")
            TablaItemEAE.Columns.Add("IDITEMREQUISICION")
            TablaItemEAE.Columns.Add("NUMEROFACTURA")
            TablaItemEAE.Columns.Add("IDREMISION")

            'Salida  de Custodias
            TablaItemSA.Columns.Add("IDITEMSALIDAALMACEN")
            TablaItemSA.Columns.Add("IDREQUISICION")
            TablaItemSA.Columns.Add("IDITEMREQUISICION")
            TablaItemSA.Columns.Add("IDARTICULO")
            TablaItemSA.Columns.Add("CANTIDAD")
            TablaItemSA.Columns.Add("IDREMISION")
            TablaItemSA.Columns.Add("IDORDENCOMPRA")
            TablaItemSA.Columns.Add("IDITEMORDENCOMPRA")

            TablaItemSAE.Columns.Add("IDITEMSALIDAALMACEN")
            TablaItemSAE.Columns.Add("IDREQUISICION")
            TablaItemSAE.Columns.Add("IDITEMREQUISICION")
            TablaItemSAE.Columns.Add("IDARTICULO")
            TablaItemSAE.Columns.Add("CANTIDAD")
            TablaItemSAE.Columns.Add("IDREMISION")
            TablaItemSAE.Columns.Add("IDORDENCOMPRA")
            TablaItemSAE.Columns.Add("IDITEMORDENCOMPRA")


            TablaEEA.Columns.Add("IDEQUIPO")

            TablaECEA.Columns.Add("IDEQUIPOPADRE")

            For i = 0 To Dgv_Custodias.RowCount - 1

                _Marcar = Dgv_Custodias.Rows(i).Cells("MARCAR").Value
                _TipoCustodia = Dgv_Custodias.Rows(i).Cells("TIPOCUSTODIA").Value
                _IdArticulo = Dgv_Custodias.Rows(i).Cells("IDARTICULO").Value
                _Cantidad = Dgv_Custodias.Rows(i).Cells("CANTIDAD").Value

                If _Marcar = "S" Then

                    Select Case _TipoCustodia

                        Case "Custodia de Equipo"
                            _IdEquipo = Dgv_Custodias.Rows(i).Cells("IDEQUIPO").Value
                            _IdEquipoPadre = Dgv_Custodias.Rows(i).Cells("IDEQUIPOPADRE").Value

                            'Llenar Item EA con articulos para equipos
                            Dim FilaTablaItemEAE As DataRow
                            FilaTablaItemEAE = TablaItemEAE.NewRow
                            FilaTablaItemEAE("IDITEMENTRADAALMACEN") = i + 1
                            FilaTablaItemEAE("IDORDENCOMPRA") = DBNull.Value
                            FilaTablaItemEAE("IDITEMORDENCOMPRA") = DBNull.Value
                            FilaTablaItemEAE("CANTIDAD") = Replace(_Cantidad, ",", ".")
                            FilaTablaItemEAE("IDARTICULO") = _IdArticulo
                            FilaTablaItemEAE("IDREQUISICION") = DBNull.Value
                            FilaTablaItemEAE("IDITEMREQUISICION") = DBNull.Value
                            FilaTablaItemEAE("NUMEROFACTURA") = ""
                            FilaTablaItemEAE("IDREMISION") = DBNull.Value
                            TablaItemEAE.Rows.Add(FilaTablaItemEAE)

                            'Llenar Item SA con articulos para equipos
                            Dim FilaTablaItemSAE As DataRow
                            FilaTablaItemSAE = TablaItemSAE.NewRow
                            FilaTablaItemSAE("IDITEMSALIDAALMACEN") = i + 1
                            FilaTablaItemSAE("CANTIDAD") = Replace(_Cantidad, ",", ".")
                            FilaTablaItemSAE("IDARTICULO") = _IdArticulo
                            FilaTablaItemSAE("IDREQUISICION") = DBNull.Value
                            FilaTablaItemSAE("IDITEMREQUISICION") = DBNull.Value
                            FilaTablaItemSAE("IDREMISION") = DBNull.Value
                            FilaTablaItemSAE("IDORDENCOMPRA") = DBNull.Value
                            FilaTablaItemSAE("IDITEMORDENCOMPRA") = DBNull.Value
                            TablaItemSAE.Rows.Add(FilaTablaItemSAE)

                            'Llenar datatable con IdEquipo
                            Dim FilaTablaEEA As DataRow
                            FilaTablaEEA = TablaEEA.NewRow
                            FilaTablaEEA("IDEQUIPO") = _IdEquipo
                            TablaEEA.Rows.Add(FilaTablaEEA)

                            'Llenar datable con IdEquipo cuando son componentes
                            Dim FilaTablaECEA As DataRow
                            FilaTablaECEA = TablaECEA.NewRow
                            FilaTablaECEA("IDEQUIPOPADRE") = _IdEquipoPadre
                            TablaECEA.Rows.Add(FilaTablaECEA)

                        Case "Custodia de Herramienta"
                            'Llenar Item EA
                            Dim FilaTablaItemEA As DataRow
                            FilaTablaItemEA = TablaItemEA.NewRow
                            FilaTablaItemEA("IDITEMENTRADAALMACEN") = i + 1
                            FilaTablaItemEA("IDORDENCOMPRA") = DBNull.Value
                            FilaTablaItemEA("IDITEMORDENCOMPRA") = DBNull.Value
                            FilaTablaItemEA("CANTIDAD") = Replace(_Cantidad, ",", ".")
                            FilaTablaItemEA("IDARTICULO") = _IdArticulo
                            FilaTablaItemEA("IDREQUISICION") = DBNull.Value
                            FilaTablaItemEA("IDITEMREQUISICION") = DBNull.Value
                            FilaTablaItemEA("NUMEROFACTURA") = ""
                            FilaTablaItemEA("IDREMISION") = DBNull.Value
                            TablaItemEA.Rows.Add(FilaTablaItemEA)

                            'Llenar Item SA.
                            Dim FilaTablaItemSA As DataRow
                            FilaTablaItemSA = TablaItemSA.NewRow
                            FilaTablaItemSA("IDITEMSALIDAALMACEN") = i + 1
                            FilaTablaItemSA("CANTIDAD") = Replace(_Cantidad, ",", ".")
                            FilaTablaItemSA("IDARTICULO") = _IdArticulo
                            FilaTablaItemSA("IDREQUISICION") = DBNull.Value
                            FilaTablaItemSA("IDITEMREQUISICION") = DBNull.Value
                            FilaTablaItemSA("IDREMISION") = DBNull.Value
                            FilaTablaItemSA("IDORDENCOMPRA") = DBNull.Value
                            FilaTablaItemSA("IDITEMORDENCOMPRA") = DBNull.Value
                            TablaItemSA.Rows.Add(FilaTablaItemSA)
                    End Select
                End If
            Next



            If CantH > 0 Then

                ' Guardar Entrada de almacen de Custodia Con Herramientas
                Dim Comando As New SqlClient.SqlCommand("GestionarEntradaAlmacen")
                Comando.CommandType = CommandType.StoredProcedure
                Comando.Parameters.AddWithValue("@TableItemEA", TablaItemEA)
                Comando.Parameters.AddWithValue("@IDENTRADAALMACEN", IDENTRADAALMACENMODIFICANDO)
                Comando.Parameters.AddWithValue("@TIPO", 1)
                Comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                Comando.Parameters.AddWithValue("@TIPOENTRADAALMACEN", "H")
                Comando.Parameters.AddWithValue("@FECHARECIBIDO", Today.Date)
                Comando.Parameters.AddWithValue("@IDPERSONARECIBIO", VariablesBase.VariablesBase.IdPersona)
                Comando.Parameters.AddWithValue("@IDPERSONAVERIFICO", VariablesBase.VariablesBase.IdPersona)
                Comando.Parameters.AddWithValue("@IDPERSONAAPROBO", Me.Cu_BuscarPersona1.Cb_Persona.SelectedValue)
                Comando.Parameters.AddWithValue("@IDPERSONAENTREGAABODEGA", FuncionesBase.FuncionesBase.ConsultarIdPersona(identificacion))
                Comando.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                Dim Obser As String = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tb_ObservaciónEAH.Text)
                Comando.Parameters.AddWithValue("@OBSERVACION", Obser)
                Comando.Parameters.AddWithValue("@NROREMISION", "")
                Comando.Parameters.AddWithValue("@FECHAREMISION", DBNull.Value)
                Comando.Parameters.AddWithValue("@TRANSPORTADOR", "")
                Comando.Parameters.AddWithValue("@ENTREGA", "")

                Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                msgParam.Direction = ParameterDirection.Output
                Comando.Parameters.Add(msgParam)


                conn.Open()
                Comando.Connection = conn
                Try
                    Comando.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                'guardado = True
                conn.Close()
                Me.Close()

                IdEntradaH = msgParam.Value

                ' Guardar Salida de almacen de Custodia Con Herramientas
                Dim Comando2 As New SqlClient.SqlCommand("GestionarSalidaAlmacen")
                Comando2.CommandType = CommandType.StoredProcedure
                Comando2.Parameters.AddWithValue("@TableItemSA", TablaItemSA)
                Comando2.Parameters.AddWithValue("@IDSALIDAALMACEN", IDSALIDAALMACENMODIFICANDO)
                Comando2.Parameters.AddWithValue("@TIPO", 1)
                Comando2.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                Comando2.Parameters.AddWithValue("@TIPOSALIDAALMACEN", "H")
                Comando2.Parameters.AddWithValue("@DESTINO", Tx_Destino.Text)
                Comando2.Parameters.AddWithValue("@IDPERSONAAUTORIZA", Me.Cu_BuscarPersona1.Cb_Persona.SelectedValue)
                Comando2.Parameters.AddWithValue("@FECHADESPACHO", Today.Date)
                Comando2.Parameters.AddWithValue("@IDPERSONADESPACHA", VariablesBase.VariablesBase.IdPersona)
                Comando2.Parameters.AddWithValue("@IDPERSONARECIBE", Me.Cu_BuscarPersona.Cb_Persona.SelectedValue)
                Comando2.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                Dim Obser2 As String = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tb_ObservaciónSAH.Text)
                Comando2.Parameters.AddWithValue("@OBSERVACION", Obser2)
                Comando2.Parameters.AddWithValue("@TRANSPORTADOR", "")
                Comando2.Parameters.AddWithValue("@PLACAVEHICULO", "")
                Comando2.Parameters.AddWithValue("@RECIBETRANSPORTADOR", "")
                Comando2.Parameters.AddWithValue("@GUIA", "")
                Comando2.Parameters.AddWithValue("@TIPOENVIO", "N")
                Comando2.Parameters.AddWithValue("@IDORDENTRABAJO", -1)
                Comando2.Parameters.AddWithValue("@CREARREMISION", 0)
                Comando2.Parameters.AddWithValue("@IDBODEGADESTINO", DBNull.Value)
                Comando2.Parameters.AddWithValue("@IDACTIVIDADPRINCIPAL", 9933)
                Comando2.Parameters.AddWithValue("@IDCENTROCOSTO", DBNull.Value)
                Comando2.Parameters.AddWithValue("@IDEQUIPO", DBNull.Value)
                Comando2.Parameters.AddWithValue("@REGISTROODOMETROHOROMETRO", DBNull.Value)

                Dim msgParam2 As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                msgParam2.Direction = ParameterDirection.Output
                Comando2.Parameters.Add(msgParam2)

                Dim msgParam3 As New SqlParameter("@CONSECUTIVOREMISION", SqlDbType.BigInt, 1)
                msgParam3.Direction = ParameterDirection.Output
                Comando2.Parameters.Add(msgParam3)

                Comando2.Connection = conn
                Dim errorguardado As Boolean = False

                Try
                    conn.Open()
                    Comando2.ExecuteNonQuery()
                    conn.Close()
                Catch ex As Exception
                    errorguardado = True
                    MsgBox(ex.ToString)
                Finally
                    conn.Close()
                End Try

                IdSalidaH = msgParam2.Value

            End If

            If CantE > 0 Then

                ' Guardar Entrada de almacen de Custodia con Equipos

                Dim dsentradas As New DataSet
                If TablaEEA.Rows.Count > 0 Then

                    Dim Comando1 As New SqlClient.SqlCommand("GestionarEntradaAlmacen")
                    Comando1.CommandType = CommandType.StoredProcedure
                    Comando1.Parameters.AddWithValue("@TableItemEA", TablaItemEAE)
                    Comando1.Parameters.AddWithValue("@IDENTRADAALMACEN", IDENTRADAALMACENMODIFICANDO)
                    Comando1.Parameters.AddWithValue("@TIPO", 1)
                    Comando1.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                    Comando1.Parameters.AddWithValue("@TIPOENTRADAALMACEN", "S")
                    Comando1.Parameters.AddWithValue("@FECHARECIBIDO", Today.Date)
                    Comando1.Parameters.AddWithValue("@IDPERSONARECIBIO", VariablesBase.VariablesBase.IdPersona)
                    Comando1.Parameters.AddWithValue("@IDPERSONAVERIFICO", VariablesBase.VariablesBase.IdPersona)
                    Comando1.Parameters.AddWithValue("@IDPERSONAAPROBO", Me.Cu_BuscarPersona1.Cb_Persona.SelectedValue)
                    Comando1.Parameters.AddWithValue("@IDPERSONAENTREGAABODEGA", FuncionesBase.FuncionesBase.ConsultarIdPersona(identificacion))
                    Comando1.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                    Dim Obser1 As String = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tb_ObservaciónEAE.Text)
                    Comando1.Parameters.AddWithValue("@OBSERVACION", Obser1)
                    Comando1.Parameters.AddWithValue("@NROREMISION", "")
                    Comando1.Parameters.AddWithValue("@FECHAREMISION", DBNull.Value)
                    Comando1.Parameters.AddWithValue("@TRANSPORTADOR", "")
                    Comando1.Parameters.AddWithValue("@ENTREGA", "")

                    Dim msgParam1 As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                    msgParam1.Direction = ParameterDirection.Output
                    Comando1.Parameters.Add(msgParam1)

                    Dim conn1 As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                    conn1.Open()
                    Comando1.Connection = conn1
                    Try
                        Comando1.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                    'guardado = True
                    conn1.Close()
                    Me.Close()

                    IdEntradaE = msgParam1.Value

                    For i = 0 To TablaEEA.Rows.Count - 1
                        dsentradas = bddatos.ModificarCustodias(3, 0, TablaEEA.Rows(i)("IDEQUIPO"), 6, 0, 0, IdEntradaE)
                    Next
                ElseIf TablaECEA.Rows.Count > 0 Then
                    For i = 0 To TablaECEA.Rows.Count - 1
                        dsentradas = bddatos.ModificarCustodias(3, 0, TablaECEA.Rows(i)("IDEQUIPO"), 6, 0, 0, IdEntradaE)
                    Next

                End If

                ' Guardar salida de almacen de custodia con equipos
                Dim dstraslado As New DataSet
                If TablaEEA.Rows.Count > 0 Then

                    Dim Comando3 As New SqlClient.SqlCommand("GestionarSalidaAlmacen")
                    Comando3.CommandType = CommandType.StoredProcedure
                    Comando3.Parameters.AddWithValue("@TableItemSA", TablaItemSAE)
                    Comando3.Parameters.AddWithValue("@IDSALIDAALMACEN", IDSALIDAALMACENMODIFICANDO)
                    Comando3.Parameters.AddWithValue("@TIPO", 1)
                    Comando3.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                    Comando3.Parameters.AddWithValue("@TIPOSALIDAALMACEN", "S")
                    Comando3.Parameters.AddWithValue("@DESTINO", Tx_Destino.Text)
                    Comando3.Parameters.AddWithValue("@IDPERSONAAUTORIZA", Me.Cu_BuscarPersona1.Cb_Persona.SelectedValue)
                    Comando3.Parameters.AddWithValue("@FECHADESPACHO", Today.Date)
                    Comando3.Parameters.AddWithValue("@IDPERSONADESPACHA", VariablesBase.VariablesBase.IdPersona)
                    Comando3.Parameters.AddWithValue("@IDPERSONARECIBE", Me.Cu_BuscarPersona.Cb_Persona.SelectedValue)
                    Comando3.Parameters.AddWithValue("@IDPERSONA", VariablesBase.VariablesBase.IdPersona)
                    Dim Obser3 As String = FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tb_ObservaciónSAE.Text)
                    Comando3.Parameters.AddWithValue("@OBSERVACION", Obser3)
                    Comando3.Parameters.AddWithValue("@TRANSPORTADOR", "")
                    Comando3.Parameters.AddWithValue("@PLACAVEHICULO", "")
                    Comando3.Parameters.AddWithValue("@RECIBETRANSPORTADOR", "")
                    Comando3.Parameters.AddWithValue("@GUIA", "")
                    Comando3.Parameters.AddWithValue("@TIPOENVIO", "N")
                    Comando3.Parameters.AddWithValue("@IDORDENTRABAJO", -1)
                    Comando3.Parameters.AddWithValue("@CREARREMISION", 0)
                    Comando3.Parameters.AddWithValue("@IDBODEGADESTINO", DBNull.Value)
                    Comando3.Parameters.AddWithValue("@IDACTIVIDADPRINCIPAL", 9933)
                    Comando3.Parameters.AddWithValue("@IDCENTROCOSTO", DBNull.Value)
                    Comando3.Parameters.AddWithValue("@IDEQUIPO", DBNull.Value)
                    Comando3.Parameters.AddWithValue("@REGISTROODOMETROHOROMETRO", DBNull.Value)


                    Dim msgParam4 As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
                    msgParam4.Direction = ParameterDirection.Output
                    Comando3.Parameters.Add(msgParam4)

                    Dim msgParam5 As New SqlParameter("@CONSECUTIVOREMISION", SqlDbType.BigInt, 1)
                    msgParam5.Direction = ParameterDirection.Output
                    Comando3.Parameters.Add(msgParam5)

                    Comando3.Connection = conn
                    Dim errorguardado1 As Boolean = False

                    Try
                        conn.Open()
                        Comando3.ExecuteNonQuery()
                        conn.Close()
                    Catch ex As Exception
                        errorguardado1 = True
                        MsgBox(ex.ToString)
                    Finally
                        conn.Close()
                    End Try

                    IdSalidaE = msgParam4.Value

                    For i = 0 To (TablaEEA.Rows.Count - 1)
                        dstraslado = bddatos.ModificarCustodias(1, 0, TablaEEA.Rows(i)("IDEQUIPO"), 7, Cu_BuscarPersona.Cb_Persona.SelectedValue, IdSalidaE, 0)
                    Next
                    ' agregar componentes si existen
                ElseIf TablaECEA.Rows.Count > 0 Then
                    For i = 0 To (TablaECEA.Rows.Count - 1)
                        dstraslado = bddatos.ModificarCustodias(1, 0, TablaECEA.Rows(i)("IDEQUIPO"), 7, Cu_BuscarPersona.Cb_Persona.SelectedValue, IdSalidaE, 0)
                    Next

                End If
            End If

            'Imprimir documentos de EA y SA.
            If MsgBox("¿Desea imprimir los documentos?", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
                Try
                    Dim Cl_Imprimir As New ImpresiónMateriales.Cl_Impresión
                    Dim ArrayH As New ArrayList
                    Dim ArrayE As New ArrayList
                    'Dim ArraySH As New ArrayList
                    'Dim ArraySE As New ArrayList

                    If CantH > 0 Then
                        ArrayH.Add(64)
                        ArrayH.Add(66)
                        Cl_Imprimir.IDENTRADAALMACEN = IdEntradaH
                        Cl_Imprimir.IDSALIDAALMACEN = IdSalidaH
                        Cl_Imprimir.FormatoImprimirMateriales(ArrayH, Ck_VistaPrevia.Checked)
                    End If

                    If CantE > 0 Then
                        ArrayE.Add(64)
                        ArrayE.Add(66)
                        Cl_Imprimir.IDENTRADAALMACEN = IdEntradaE
                        Cl_Imprimir.IDSALIDAALMACEN = IdSalidaE
                        Cl_Imprimir.CargarDatasetEntradaAlmacen = True
                        Cl_Imprimir.CargarDatasetSalidaAlmacen = True
                        Cl_Imprimir.FormatoImprimirMateriales(ArrayE, Ck_VistaPrevia.Checked)
                    End If

                    Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    Close()
                End Try
            End If
        End If
    End Sub

    Private Function Validar()

        If CantE > 0 Then
            If Tb_ObservaciónEAE.Text = Nothing Then
                MsgBox("El campo de Observación de EA del Equipo no puede estar vacío", MsgBoxStyle.Critical, "OBSERVACION EA EQUIPO")
                Me.Tb_ObservaciónEAH.Focus()
                Validar = False
                Exit Function
            End If

            If Tb_ObservaciónSAE.Text = Nothing Then
                MsgBox("El campo de Observación de SA del Equipo no puede estar vacío", MsgBoxStyle.Critical, "OBSERVACION SA EQUIPO")
                Me.Tb_ObservaciónSAH.Focus()
                Validar = False
                Exit Function
            End If
        End If

        If CantH > 0 Then
            If Tb_ObservaciónEAH.Text = Nothing Then
                MsgBox("El campo de Observación de EA de la herramienta no puede estar vacío", MsgBoxStyle.Critical, "OBSERVACION EA HERRAMIENTA")
                Me.Tb_ObservaciónEAH.Focus()
                Validar = False
                Exit Function
            End If

            If Tb_ObservaciónSAH.Text = Nothing Then
                MsgBox("El campo de Observación de SA de la herramienta no puede estar vacío", MsgBoxStyle.Critical, "OBSERVACION SA HERRAMIENTA")
                Me.Tb_ObservaciónSAH.Focus()
                Validar = False
                Exit Function
            End If
        End If

        Dim seleccionados As Integer = Dgv_Custodias.Rows.Cast(Of DataGridViewRow).Where(Function(x) x.Cells("MARCAR").Value = "S").ToList().Count

        If seleccionados = 0 Then
            MsgBox("Marque al menos un registro de la lista ", MsgBoxStyle.Critical, "MARCAR CASILLA")
            Validar = False
            Exit Function
        End If

        If Me.Cu_BuscarPersona.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la persona que recibe la custodia", MsgBoxStyle.Critical, "PERSONA RECIBE CUSTODIA")
            Cu_BuscarPersona.Cb_Persona.Focus()
            Validar = False
            Exit Function
        End If

        If Me.Cu_BuscarPersona1.Cb_Persona.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la persona que autoriza", MsgBoxStyle.Critical, "PERSONA AUTORIZA")
            Cu_BuscarPersona1.Cb_Persona.Focus()
            Validar = False
            Exit Function
        End If

        If Tx_Destino.Text = Nothing Then
            MsgBox("El campo destino no puede estar vacío", MsgBoxStyle.Critical, "DESTINO")
            Me.Tx_Destino.Focus()
            Validar = False
            Exit Function
        End If

        If Cb_Actividad.SelectedIndex = -1 Then
            MsgBox("debe selecionar una actividad principal", MsgBoxStyle.Critical, "ACTIVIDAD PRINCIPAL")
            Me.Cb_Actividad.Focus()
            Validar = False
            Exit Function
        End If

        Validar = True
    End Function

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
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
        Me.Cb_Actividad.DataSource = dt_Actividades
        Me.Cb_Actividad.DisplayMember = "ACTIVIDAD"
        Me.Cb_Actividad.ValueMember = "IDACTIVIDADPRINCIPAL"
        Me.Cb_Actividad.SelectedIndex = -1
    End Sub


    Private Sub Tx_Valor_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_Valor.KeyDown
        Select Case e.KeyData
            Case Keys.Enter
                BuscarIdentificacion()
        End Select
    End Sub

    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Close()
    End Sub
End Class