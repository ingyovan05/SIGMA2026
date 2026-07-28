Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_MaterialNoConforme
    Public IdMaterialNoConforme As Integer
    Public TipoEdicion As TiposEdicion
    Public Enum TiposEdicion
        Crear
        Editar
        Ver
        Cerrar
    End Enum
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private filaMaterialNoConforme As DataRow
    Private idBaseActual As Integer
    Private idProveedor As Integer = 0
    Private idOrdenTrabajo As Integer = 0
    Private idRequisicion As Long = 0
    Private idOrdenCompra As Long = 0
    Private _guardado As Boolean = False
    ReadOnly Property Guardado As Boolean
        Get
            Return _guardado
        End Get
    End Property

    Private Sub Fr_MaterialNoConforme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        idBaseActual = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        comando = New SqlCommand("dbo.NC_DatosMaterialNoConforme", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        Select Case TipoEdicion
            Case TiposEdicion.Crear
                comando.Parameters("@Accion").Value = 1
            Case TiposEdicion.Editar
                comando.Parameters("@Accion").Value = 2
            Case TiposEdicion.Ver
                comando.Parameters("@Accion").Value = 3
            Case TiposEdicion.Cerrar
                comando.Parameters("@Accion").Value = 4
            Case Else
                comando.Parameters("@Accion").Value = DBNull.Value
        End Select
        comando.Parameters.Add("@IDMATERIALNOCONFORME", SqlDbType.Int)
        If TipoEdicion <> TiposEdicion.Crear Then
            comando.Parameters("@IDMATERIALNOCONFORME").Value = IdMaterialNoConforme
        End If
        adaptador = New SqlDataAdapter(comando)
        Dim dsMaterialNoConforme As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsMaterialNoConforme)
            conexion.Close()
            If dsMaterialNoConforme.Tables.Count > 0 Then
                If TipoEdicion <> TiposEdicion.Crear Then
                    If dsMaterialNoConforme.Tables(0).Rows.Count > 0 Then
                        filaMaterialNoConforme = dsMaterialNoConforme.Tables(0).Rows(0)
                    Else
                        MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                Cb_Unidad.DataSource = dsMaterialNoConforme.Tables(1)
            Else
                MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        CuC_Ciudad.CargarDatos()
        If TipoEdicion = TiposEdicion.Crear Then
            CuBP_Verifica.CargarDatos()
            CuBP_Verifica.Cb_Persona.SelectedIndex = -1
            CuBP_Elabora.CargarDatos()
            CuBP_Elabora.Cb_Persona.SelectedIndex = -1
            CuBP_Acepta.CargarDatos()
            CuBP_Acepta.Cb_Persona.SelectedIndex = -1
        Else
            VariablesBase.VariablesBase.IdBaseSiscontrolActual = filaMaterialNoConforme("IDBASE")
            'idDependencia
            If Not IsDBNull(filaMaterialNoConforme("CONTRATO")) Then
                Tx_Contrato.Text = filaMaterialNoConforme("CONTRATO")
            End If
            If Not IsDBNull(filaMaterialNoConforme("NUMEROREPORTE")) Then
                Tx_NumeroReporte.Text = filaMaterialNoConforme("NUMEROREPORTE")
            End If
            If Not IsDBNull(filaMaterialNoConforme("LUGAR")) Then
                Tx_Lugar.Text = filaMaterialNoConforme("LUGAR")
            End If
            If Not IsDBNull(filaMaterialNoConforme("FECHARECEPCION")) Then
                Dtp_FechaRecepcion.Value = filaMaterialNoConforme("FECHARECEPCION")
            Else
                Dtp_FechaRecepcion.Checked = False
            End If
            If Not IsDBNull(filaMaterialNoConforme("IDPROVEEDOR")) Then
                idProveedor = filaMaterialNoConforme("IDPROVEEDOR")
                Tx_NombreProveedor.Text = filaMaterialNoConforme("NOMBREPROVEEDOR")
                Tx_NitProveedor.Text = Trim(filaMaterialNoConforme("NITPROVEEDOR"))
            End If
            If Not IsDBNull(filaMaterialNoConforme("IDORDENTRABAJO")) Then
                idOrdenTrabajo = filaMaterialNoConforme("IDORDENTRABAJO")
                Tx_OrdenTrabajo.Text = filaMaterialNoConforme("ORDENTRABAJO")
            End If
            If Not IsDBNull(filaMaterialNoConforme("CODIGOPOBLACION")) Then
                CuC_Ciudad.Cb_Ciudad.SelectedValue = filaMaterialNoConforme("CODIGOPOBLACION")
            End If
            If Not IsDBNull(filaMaterialNoConforme("IDREQUISICION")) Then
                idRequisicion = filaMaterialNoConforme("IDREQUISICION")
                Tx_Requisicion.Text = filaMaterialNoConforme("REQUISICION")
            End If
            If Not IsDBNull(filaMaterialNoConforme("REMISION")) Then
                Tx_Remision.Text = filaMaterialNoConforme("REMISION")
            End If
            If Not IsDBNull(filaMaterialNoConforme("IDORDENCOMPRA")) Then
                idOrdenCompra = filaMaterialNoConforme("IDORDENCOMPRA")
                Tx_OrdenCompra.Text = filaMaterialNoConforme("ORDENCOMPRA")
            End If
            If Not IsDBNull(filaMaterialNoConforme("MATERIAL")) Then
                Tx_Material.Text = filaMaterialNoConforme("MATERIAL")
            End If
            If Not IsDBNull(filaMaterialNoConforme("ITEMORDENCOMPRA")) Then
                Tx_ItemOC.Text = filaMaterialNoConforme("ITEMORDENCOMPRA")
            End If
            If Not IsDBNull(filaMaterialNoConforme("CODIGOTIPOUNIDAD")) Then
                Cb_Unidad.SelectedValue = filaMaterialNoConforme("CODIGOTIPOUNIDAD")
            End If
            If Not IsDBNull(filaMaterialNoConforme("CANTIDAD")) AndAlso filaMaterialNoConforme("CANTIDAD") > 0 Then
                Tx_Cantidad.Text = filaMaterialNoConforme("CANTIDAD")
            End If
            If Not IsDBNull(filaMaterialNoConforme("OBSERVACION")) Then
                Tx_Observacion.Text = filaMaterialNoConforme("OBSERVACION")
            End If
            If Not IsDBNull(filaMaterialNoConforme("DESCRIPCION")) Then
                Tx_Descripcion.Text = filaMaterialNoConforme("DESCRIPCION")
            End If
            If Not IsDBNull(filaMaterialNoConforme("MARCADO")) Then
                If filaMaterialNoConforme("MARCADO") = "S" Then
                    Ck_Marcado.CheckState = CheckState.Checked
                Else
                    Ck_Marcado.CheckState = CheckState.Unchecked
                End If
            Else
                Ck_Marcado.CheckState = CheckState.Indeterminate
            End If
            If Not IsDBNull(filaMaterialNoConforme("LLEVADOAREACUARENTENA")) Then
                If filaMaterialNoConforme("LLEVADOAREACUARENTENA") = "S" Then
                    Ck_LlevadoAreaCuarentena.CheckState = CheckState.Checked
                Else
                    Ck_LlevadoAreaCuarentena.CheckState = CheckState.Unchecked
                End If
            Else
                Ck_LlevadoAreaCuarentena.CheckState = CheckState.Indeterminate
            End If
            If Not IsDBNull(filaMaterialNoConforme("SEGUIMIENTO")) Then
                Tx_Seguimiento.Text = filaMaterialNoConforme("SEGUIMIENTO")
            End If
            CuBP_Elabora.CargarDatos()
            If Not IsDBNull(filaMaterialNoConforme("IDPERSONAELABORA")) Then
                CuBP_Elabora.Cb_Persona.SelectedValue = filaMaterialNoConforme("IDPERSONAELABORA")
            End If
            CuBP_Verifica.CargarDatos()
            If Not IsDBNull(filaMaterialNoConforme("IDPERSONAVERIFICA")) Then
                CuBP_Verifica.Cb_Persona.SelectedValue = filaMaterialNoConforme("IDPERSONAVERIFICA")
            End If
            CuBP_Acepta.CargarDatos()
            If Not IsDBNull(filaMaterialNoConforme("IDPERSONAACEPTA")) Then
                CuBP_Acepta.Cb_Persona.SelectedValue = filaMaterialNoConforme("IDPERSONAACEPTA")
            End If
            If TipoEdicion = TiposEdicion.Cerrar Then
                Dtp_FechaCierre.Enabled = True
                If Not IsDBNull(filaMaterialNoConforme("FECHACIERRE")) Then
                    Dtp_FechaCierre.Value = filaMaterialNoConforme("FECHACIERRE")
                End If
            End If
        End If
        If TipoEdicion = TiposEdicion.Crear OrElse TipoEdicion = TiposEdicion.Editar Then
            Dtp_FechaCierre.Enabled = False
        ElseIf TipoEdicion = TiposEdicion.Cerrar Then
            Tx_Contrato.ReadOnly = True
            Tx_NumeroReporte.ReadOnly = True
            Tx_Lugar.ReadOnly = True
            Dtp_FechaRecepcion.Enabled = False
            Tx_NitProveedor.ReadOnly = True
            Tx_NombreProveedor.ReadOnly = True
            Tx_OrdenTrabajo.ReadOnly = True
            Bt_BuscarOT.Enabled = False
            CuC_Ciudad.Enabled = False
            Tx_Requisicion.ReadOnly = True
            Bt_BuscarRQ.Enabled = False
            Tx_Remision.ReadOnly = True
            Tx_OrdenCompra.ReadOnly = True
            Bt_BuscarOC.Enabled = False
            Tx_Material.ReadOnly = True
            Tx_ItemOC.ReadOnly = True
            Cb_Unidad.Enabled = False
            Tx_Cantidad.ReadOnly = True
            Tx_Observacion.ReadOnly = True
            Tx_Descripcion.ReadOnly = True
            Ck_Marcado.Enabled = False
            Ck_LlevadoAreaCuarentena.Enabled = False
            Tx_Seguimiento.ReadOnly = True
            CuBP_Elabora.Enabled = False
            CuBP_Acepta.Enabled = False
            CuBP_Verifica.Enabled = False

            Dtp_FechaCierre.Enabled = True
        ElseIf TipoEdicion = TiposEdicion.Ver Then
            Tx_Contrato.ReadOnly = True
            Tx_NumeroReporte.ReadOnly = True
            Tx_Lugar.ReadOnly = True
            Dtp_FechaRecepcion.Enabled = False
            Tx_NitProveedor.ReadOnly = True
            Tx_NombreProveedor.ReadOnly = True
            Tx_OrdenTrabajo.ReadOnly = True
            Bt_BuscarOT.Enabled = False
            CuC_Ciudad.Enabled = False
            Tx_Requisicion.ReadOnly = True
            Bt_BuscarRQ.Enabled = False
            Tx_Remision.ReadOnly = True
            Tx_OrdenCompra.ReadOnly = True
            Bt_BuscarOC.Enabled = False
            Tx_Material.ReadOnly = True
            Tx_ItemOC.ReadOnly = True
            Cb_Unidad.Enabled = False
            Tx_Cantidad.ReadOnly = True
            Tx_Observacion.ReadOnly = True
            Tx_Descripcion.ReadOnly = True
            Ck_Marcado.Enabled = False
            Ck_LlevadoAreaCuarentena.Enabled = False
            Tx_Seguimiento.ReadOnly = True
            CuBP_Elabora.Enabled = False
            CuBP_Acepta.Enabled = False
            CuBP_Verifica.Enabled = False
            Dtp_FechaCierre.Enabled = False
            Bt_Aceptar.Visible = False
        End If
    End Sub

    Private Sub Fr_MaterialNoConforme_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If TipoEdicion = TiposEdicion.Ver Then
            Bt_Cancelar.Select()
        ElseIf TipoEdicion = TiposEdicion.Cerrar Then
            Dtp_FechaCierre.Select()
        Else
            Tx_NumeroReporte.Select()
        End If
    End Sub


    Private Sub Tx_NitProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_NitProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            CargarProveedor(FuncionesBase.FuncionesBase.ValorRealInt(Tx_NitProveedor.Text))
        End If
    End Sub

    Private Sub Tx_NitProveedor_Leave(sender As Object, e As EventArgs) Handles Tx_NitProveedor.Leave
        FuncionesBase.FuncionesBase.FormatearNIT(Tx_NitProveedor.Text)
    End Sub

    Private Sub Bt_BuscarProveedor_Click(sender As Object, e As EventArgs) Handles Bt_BuscarProveedor.Click
        Using frBuscarProveedor As New FormulariosClasesBase.Fr_BuscarProveedor
            frBuscarProveedor.Cargar_Tabla()
            If frBuscarProveedor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CargarProveedor(frBuscarProveedor.Identificacion)
            End If
        End Using
    End Sub

    Private Sub CargarProveedor(nit As Integer)
        comando = New SqlCommand("SELECT * FROM DatosProveedorOC(@IDENTIFICACION)", conexion) 'DatosBasicosProveedor(@IDPROVEEDOR), DatosProveedor(@IDPROVEEDOR)
        comando.Parameters.AddWithValue("@IDENTIFICACION", nit)
        adaptador = New SqlDataAdapter(comando)
        Dim dtProveedor As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtProveedor)
            conexion.Close()
            If dtProveedor.Rows.Count > 0 Then
                Dim fila As DataRow = dtProveedor.Rows(0)
                idProveedor = fila("IDPROVEEDOR")
                If Not IsDBNull(fila("NOMBRE")) Then
                    Tx_NombreProveedor.Text = fila("NOMBRE")
                ElseIf Not IsDBNull(fila("NOMBREPROVEEDOR")) Then
                    Tx_NombreProveedor.Text = fila("NOMBREPROVEEDOR")
                Else
                    Tx_NombreProveedor.Text = Trim(fila("IDENTIFICACION"))
                End If
                Tx_NitProveedor.Text = FuncionesBase.FuncionesBase.FormatearNIT(nit)
            Else
                MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Tx_NitProveedor.Select()
            End If
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Bt_BuscarOT_Click(sender As Object, e As EventArgs) Handles Bt_BuscarOT.Click

    End Sub

    Private Sub Bt_BuscarRQ_Click(sender As Object, e As EventArgs) Handles Bt_BuscarRQ.Click

    End Sub

    Private Sub Bt_BuscarOC_Click(sender As Object, e As EventArgs) Handles Bt_BuscarOC.Click

    End Sub

    Public Sub EventoEnterCiudad(Optional NombreComponente As String = "")
        Dim controles() As Control = Me.Controls.Find(NombreComponente, True)
        If controles.Length > 0 Then
            Dim cuCiudad As FormulariosClasesBase.Cu_Ciudad = controles(0)
            Dim filas() As DataRow
            Try
                filas = cuCiudad.Cb_Ciudad.DataSource.Select("CODIGOPOBLACION='" + (cuCiudad.Tx_Codigo.Text).ToString + "'")
                If filas.Length > 0 Then
                    Dim fila As DataRow = filas(0)
                    cuCiudad.Cb_Ciudad.SelectedValue = fila("CODIGOPOBLACION")
                Else
                    MessageBox.Show("Esta población no está registrada.", "No se encontró la ciudad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch
                cuCiudad.Tx_Codigo.Text = ""
            End Try
        End If
    End Sub

    Public Sub EventoCajaEnter(Optional NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case CuBP_Elabora.Name
                Try
                    filas = CuBP_Elabora.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (CuBP_Elabora.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        CuBP_Elabora.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    CuBP_Elabora.Tx_TextoCódigo.Text = ""
                End Try
            Case CuBP_Verifica.Name
                Try
                    filas = CuBP_Verifica.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (CuBP_Verifica.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        CuBP_Verifica.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    CuBP_Verifica.Tx_TextoCódigo.Text = ""
                End Try
            Case CuBP_Acepta.Name
                Try
                    filas = CuBP_Acepta.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (CuBP_Acepta.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        CuBP_Acepta.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    CuBP_Acepta.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub


    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Validar() Then
            Guardar()
            If Guardado Then
                Me.Close()
            End If
        End If
    End Sub

    Private Function Validar()
        If Tx_OrdenTrabajo.Text.Length > 0 AndAlso Not EsValidaOT() Then
            MessageBox.Show("La orden de trabajo ingresada no es válida.", "Material No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tx_OrdenTrabajo.Select()
            Return False
        End If
        If Tx_Requisicion.Text.Length > 0 AndAlso Not EsValidaRQ() Then
            MessageBox.Show("La requisición ingresada no es válida.", "Material No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tx_Requisicion.Select()
            Return False
        End If
        If Tx_OrdenCompra.Text.Length > 0 AndAlso Not EsValidaOC() Then
            MessageBox.Show("La orden de compra ingresada no es válida.", "Material No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tx_OrdenCompra.Select()
            Return False
        End If
        If Ck_Marcado.CheckState = CheckState.Indeterminate Then
            MessageBox.Show("Debe indicar si fue marcado.", "Material No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Ck_Marcado.Select()
            Return False
        End If
        If Ck_LlevadoAreaCuarentena.CheckState = CheckState.Indeterminate Then
            MessageBox.Show("Debe indicar si fue llevado al área de cuarentena.", "Material No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Ck_LlevadoAreaCuarentena.Select()
            Return False
        End If
        If CuBP_Elabora.Cb_Persona.SelectedIndex < 0 OrElse CuBP_Elabora.Cb_Persona.SelectedValue < 0 Then
            MessageBox.Show("Debe indicar el nombre de la persona que elabora.", "Material No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CuBP_Elabora.Cb_Persona.Select()
            Return False
        End If
        If CuBP_Acepta.Cb_Persona.SelectedIndex < 0 OrElse CuBP_Acepta.Cb_Persona.SelectedValue < 0 Then
            MessageBox.Show("Debe indicar el nombre de la persona que acepta.", "Material No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CuBP_Acepta.Cb_Persona.Select()
            Return False
        End If
        If CuBP_Verifica.Cb_Persona.SelectedIndex < 0 OrElse CuBP_Verifica.Cb_Persona.SelectedValue < 0 Then
            MessageBox.Show("Debe indicar el nombre de la persona que verifica.", "Material No Conforme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CuBP_Verifica.Cb_Persona.Select()
            Return False
        End If
        Return True
    End Function

    Private Function EsValidaOT()
        Dim ordenTrabajo As String = Tx_OrdenTrabajo.Text
        Dim idOT As Integer?
        comando = New SqlCommand("SELECT dbo.IdOTxNroOrdenSAP(@NROORDENSAP)", conexion)
        comando.Parameters.AddWithValue("@NROORDENSAP", Tx_OrdenTrabajo.Text)
        Try
            conexion.Open()
            idOT = comando.ExecuteScalar
            conexion.Close()
            If Not IsDBNull(idOT) Then
                idOrdenTrabajo = idOT.Value
                Return True
            Else
                idOrdenTrabajo = 0
                Return False
            End If
        Catch ex As Exception
            conexion.Close()
            Return False
        End Try
    End Function

    Private Function EsValidaRQ()
        Dim idRQ As Long?
        comando = New SqlCommand("SELECT dbo.IdRQxRequisicion(@REQUISICION)", conexion)
        comando.Parameters.AddWithValue("@REQUISICION", Tx_Requisicion.Text)
        Try
            conexion.Open()
            idRQ = comando.ExecuteScalar
            conexion.Close()
            If Not IsDBNull(idRQ) Then
                idRequisicion = idRQ.Value
                Return True
            Else
                idRequisicion = 0
                Return False
            End If
        Catch ex As Exception
            conexion.Close()
            Return False
        End Try
    End Function

    Private Function EsValidaOC()
        Dim idOC As Long?
        comando = New SqlCommand("SELECT dbo.IdOCxOrdenCompra(@ORDENCOMPRA)", conexion)
        comando.Parameters.AddWithValue("@ORDENCOMPRA", Tx_OrdenCompra.Text)
        Try
            conexion.Open()
            idOC = comando.ExecuteScalar
            conexion.Close()
            If Not IsDBNull(idOC) Then
                idOrdenCompra = idOC.Value
                Return True
            Else
                idOrdenCompra = 0
                Return False
            End If
        Catch ex As Exception
            conexion.Close()
            Return False
        End Try
    End Function

    Private Sub Guardar()
        comando = New SqlCommand("dbo.GestionarNC_MaterialNoConforme", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        Select Case TipoEdicion
            Case TiposEdicion.Crear
                comando.Parameters("@Accion").Value = 1
            Case TiposEdicion.Editar
                comando.Parameters("@Accion").Value = 2
            Case TiposEdicion.Cerrar
                comando.Parameters("@Accion").Value = 3
            Case Else
                comando.Parameters("@Accion").Value = DBNull.Value
        End Select
        comando.Parameters.Add("@IDMATERIALNOCONFORME", SqlDbType.Int)
        If TipoEdicion <> TiposEdicion.Crear Then
            comando.Parameters("@IDMATERIALNOCONFORME").Value = IdMaterialNoConforme
        Else
            comando.Parameters("@IDMATERIALNOCONFORME").Value = DBNull.Value
        End If
        comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@NUMEROREPORTE", Trim(Tx_NumeroReporte.Text))
        comando.Parameters.AddWithValue("@LUGAR", Trim(Tx_Lugar.Text))
        comando.Parameters.Add("@FECHARECEPCION", SqlDbType.Date)
        If Dtp_FechaRecepcion.Checked Then
            comando.Parameters("@FECHARECEPCION").Value = Dtp_FechaRecepcion.Value
        Else
            comando.Parameters("@FECHARECEPCION").Value = DBNull.Value
        End If
        comando.Parameters.Add("@IDPROVEEDOR", SqlDbType.Int)
        If idProveedor > 0 Then
            comando.Parameters("@IDPROVEEDOR").Value = idProveedor
        Else
            comando.Parameters("@IDPROVEEDOR").Value = DBNull.Value
        End If
        comando.Parameters.Add("@IDORDENTRABAJO", SqlDbType.Int)
        If idOrdenTrabajo > 0 Then
            comando.Parameters("@IDORDENTRABAJO").Value = idOrdenTrabajo
        Else
            comando.Parameters("@IDORDENTRABAJO").Value = DBNull.Value
        End If
        comando.Parameters.AddWithValue("@CODIGOPOBLACION", CuC_Ciudad.Cb_Ciudad.SelectedValue)
        comando.Parameters.Add("@IDREQUISICION", SqlDbType.BigInt)
        If idRequisicion > 0 Then
            comando.Parameters("@IDREQUISICION").Value = idRequisicion
        Else
            comando.Parameters("@IDREQUISICION").Value = DBNull.Value
        End If
        comando.Parameters.AddWithValue("@REMISION", Trim(Tx_Remision.Text))
        comando.Parameters.Add("@IDORDENCOMPRA", SqlDbType.BigInt)
        comando.Parameters.Add("@ITEMORDENCOMPRA", SqlDbType.TinyInt)
        If idOrdenCompra > 0 Then
            comando.Parameters("@IDORDENCOMPRA").Value = idOrdenCompra
            If Tx_ItemOC.Text.Length > 0 Then
                comando.Parameters("@ITEMORDENCOMPRA").Value = FuncionesBase.FuncionesBase.ValorRealInt(Tx_ItemOC.Text)
            Else
                comando.Parameters("@ITEMORDENCOMPRA").Value = DBNull.Value
            End If
        Else
            comando.Parameters("@IDORDENCOMPRA").Value = DBNull.Value
            comando.Parameters("@ITEMORDENCOMPRA").Value = DBNull.Value
        End If
        comando.Parameters.AddWithValue("@MATERIAL", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Material.Text))
        comando.Parameters.Add("@CODIGOTIPOUNIDAD", SqlDbType.Int)
        If Cb_Unidad.SelectedIndex > 0 AndAlso Cb_Unidad.SelectedValue > 0 Then
            comando.Parameters("@CODIGOTIPOUNIDAD").Value = Cb_Unidad.SelectedValue
        Else
            comando.Parameters("@CODIGOTIPOUNIDAD").Value = DBNull.Value
        End If
        comando.Parameters.AddWithValue("@CANTIDAD", FuncionesBase.FuncionesBase.ValorRealDec(Tx_Cantidad.Text))
        comando.Parameters.AddWithValue("@OBSERVACION", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Observacion.Text))
        comando.Parameters.AddWithValue("@DESCRIPCION", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Descripcion.Text))
        comando.Parameters.Add("@MARCADO", SqlDbType.Char, 1)
        Select Case Ck_Marcado.CheckState
            Case CheckState.Checked
                comando.Parameters("@MARCADO").Value = "S"
            Case CheckState.Unchecked
                comando.Parameters("@MARCADO").Value = "N"
            Case Else
                comando.Parameters("@MARCADO").Value = DBNull.Value
        End Select
        comando.Parameters.Add("@LLEVADOAREACUARENTENA", SqlDbType.Char, 1)
        Select Case Ck_LlevadoAreaCuarentena.CheckState
            Case CheckState.Checked
                comando.Parameters("@LLEVADOAREACUARENTENA").Value = "S"
            Case CheckState.Unchecked
                comando.Parameters("@LLEVADOAREACUARENTENA").Value = "N"
            Case Else
                comando.Parameters("@LLEVADOAREACUARENTENA").Value = DBNull.Value
        End Select
        comando.Parameters.AddWithValue("@SEGUIMIENTO", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_Seguimiento.Text))
        comando.Parameters.Add("@IDPERSONAELABORA", SqlDbType.Int)
        If CuBP_Elabora.Cb_Persona.SelectedIndex > 0 Then
            comando.Parameters("@IDPERSONAELABORA").Value = CuBP_Elabora.Cb_Persona.SelectedValue
        Else
            comando.Parameters("@IDPERSONAELABORA").Value = DBNull.Value
        End If
        comando.Parameters.Add("@IDPERSONAVERIFICA", SqlDbType.Int)
        If CuBP_Verifica.Cb_Persona.SelectedIndex > 0 Then
            comando.Parameters("@IDPERSONAVERIFICA").Value = CuBP_Verifica.Cb_Persona.SelectedValue
        Else
            comando.Parameters("@IDPERSONAVERIFICA").Value = DBNull.Value
        End If
        comando.Parameters.Add("@IDPERSONAACEPTA", SqlDbType.Int)
        If CuBP_Acepta.Cb_Persona.SelectedIndex > 0 Then
            comando.Parameters("@IDPERSONAACEPTA").Value = CuBP_Acepta.Cb_Persona.SelectedValue
        Else
            comando.Parameters("@IDPERSONAACEPTA").Value = DBNull.Value
        End If
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.Add(New SqlParameter("@Mensaje", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        If Not IsDBNull(comando.Parameters("@Mensaje").Value) Then
            Select Case comando.Parameters("@Mensaje").Value
                Case 1
                    MessageBox.Show("Se guardaron los cambios correctamente.", "Datos guardados", MessageBoxButtons.OK)
                    _guardado = True
                Case 2
                    MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Case Else
                    MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
        Else
            MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        If TipoEdicion <> TiposEdicion.Ver AndAlso Not Guardado Then
            If MessageBox.Show("¿Desea salir sin guardar cambios?", "Salir", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Fr_MaterialNoConforme_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        VariablesBase.VariablesBase.IdBaseSiscontrolActual = idBaseActual
    End Sub

    Public Function Anular() As Boolean
        If IdMaterialNoConforme > 0 Then
            comando = New SqlCommand("dbo.GestionarNC_MaterialNoConforme", conexion)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@Accion", 4) 'Anular
            comando.Parameters.AddWithValue("@IDMATERIALNOCONFORME", IdMaterialNoConforme)
            comando.Parameters.AddWithValue("@IDBASE", DBNull.Value)
            comando.Parameters.AddWithValue("@NUMEROREPORTE", DBNull.Value)
            comando.Parameters.AddWithValue("@LUGAR", DBNull.Value)
            comando.Parameters.AddWithValue("@FECHARECEPCION", DBNull.Value)
            comando.Parameters.AddWithValue("@IDPROVEEDOR", DBNull.Value)
            comando.Parameters.AddWithValue("@IDORDENTRABAJO", DBNull.Value)
            comando.Parameters.AddWithValue("@CODIGOPOBLACION", DBNull.Value)
            comando.Parameters.AddWithValue("@IDREQUISICION", DBNull.Value)
            comando.Parameters.AddWithValue("@REMISION", DBNull.Value)
            comando.Parameters.AddWithValue("@IDORDENCOMPRA", DBNull.Value)
            comando.Parameters.AddWithValue("@ITEMORDENCOMPRA", DBNull.Value)
            comando.Parameters.AddWithValue("@MATERIAL", DBNull.Value)
            comando.Parameters.AddWithValue("@CODIGOTIPOUNIDAD", DBNull.Value)
            comando.Parameters.AddWithValue("@CANTIDAD", DBNull.Value)
            comando.Parameters.AddWithValue("@OBSERVACION", DBNull.Value)
            comando.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value)
            comando.Parameters.AddWithValue("@MARCADO", DBNull.Value)
            comando.Parameters.AddWithValue("@LLEVADOAREACUARENTENA", DBNull.Value)
            comando.Parameters.AddWithValue("@SEGUIMIENTO", DBNull.Value)
            comando.Parameters.AddWithValue("@IDPERSONAELABORA", DBNull.Value)
            comando.Parameters.AddWithValue("@IDPERSONAVERIFICA", DBNull.Value)
            comando.Parameters.AddWithValue("@IDPERSONAACEPTA", DBNull.Value)
            comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
            comando.Parameters.Add(New SqlParameter("@Mensaje", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
            Try
                conexion.Open()
                comando.ExecuteNonQuery()
                conexion.Close()
            Catch ex As Exception
                conexion.Close()
                MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
            If Not IsDBNull(comando.Parameters("@Mensaje").Value) Then
                Select Case comando.Parameters("@Mensaje").Value
                    Case 1
                        MessageBox.Show("Se guardaron los cambios correctamente.", "Datos guardados", MessageBoxButtons.OK)
                        Return True
                    Case 2
                        MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    Case Else
                        MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                End Select
            Else
                MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            MessageBox.Show("Debe indicar el registro de Material No Conforme que se va a anular.", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function

End Class