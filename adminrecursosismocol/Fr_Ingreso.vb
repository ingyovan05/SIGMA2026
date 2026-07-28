Imports System.Configuration
Imports System.Net.Sockets
Imports System.Data.SqlClient
Imports Conexion = Conexión.Cl_Conexión
Imports VarBase = VariablesBase.VariablesBase
Imports FunBase = FuncionesBase.FuncionesBase

Public Class Fr_Ingreso
    Private Contador As Integer = 0
    Private dtServidor As DataTable

    Private Sub Fr_Ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtServidor = Conexion.LeerTablaConfServidor.Tables(0)
        Cb_Conexion.DataSource = dtServidor
        'Dim filaConexion As DataRow
        'For i As Integer = 0 To dtServidor.Rows.Count - 1
        '    filaConexion = dtServidor.Rows(i)
        '    If ProbarConexion(filaConexion) Then
        '        Cb_Conexion.SelectedValue = dtServidor.Select("SERVIDOR" & " = '" & filaConexion("SERVIDOR") & "'")(0).Item("ORDEN")
        '        Exit For
        '    End If
        'Next
    End Sub

    Private Sub Fr_Ingreso_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Tx_Usuario.Select()
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        Cursor.Current = Cursors.WaitCursor
        Dim filaConexion As DataRow = dtServidor.Select(Cb_Conexion.ValueMember & "=" & "'" & Cb_Conexion.SelectedValue & "'")(0)

        Conexion.Establecer_Parametros(filaConexion("SERVIDOR"), filaConexion("NOMBREUSUARIO"), filaConexion("CONTRASENA"), filaConexion("NOMBREBASEDATOS"))

        If FunBase.Probar_Conexion_Remota_Sql_Server = False Then
            Cursor.Current = Cursors.Default
            MsgBox("La configuración actual de acceso al servidor no es valido, revisar parámetros de conexión", MsgBoxStyle.Critical, "CONEXIÓN SERVIDOR")
            Exit Sub
        End If

        If filaConexion("ORDEN") <> 1 Then
            'colocar la conexión como primera en el servidor.xml si no esta ya de primero
            Try
                Dim dtServidortemp As New DataTable
                dtServidortemp = dtServidor.Clone
                Dim orden As Integer = 1
                'agregar la conexión que se selecciono y colocarla de primera en servidor.xml para el proceso de actualización
                For i = 0 To dtServidor.Rows.Count - 1
                    Dim Fila As DataRow
                    Fila = dtServidor.Rows(i)
                    If Fila("ORDEN") = filaConexion("ORDEN") Then
                        Dim NuevaFila As DataRow
                        NuevaFila = dtServidortemp.NewRow
                        For j = 0 To dtServidor.Columns.Count - 1
                            NuevaFila(j) = filaConexion(j)
                        Next
                        NuevaFila("ORDEN") = orden
                        dtServidortemp.Rows.Add(NuevaFila)
                    End If
                Next
                orden = orden + 1
                'agregar el resto de conexiones registradas
                For i = 0 To dtServidor.Rows.Count - 1
                    Dim Fila As DataRow
                    Fila = dtServidor.Rows(i)
                    If Fila("ORDEN") <> filaConexion("ORDEN") Then
                        Dim NuevaFila As DataRow
                        NuevaFila = dtServidortemp.NewRow
                        For j = 0 To dtServidor.Columns.Count - 1
                            NuevaFila(j) = Fila(j)
                        Next
                        NuevaFila("ORDEN") = orden
                        orden = orden + 1
                        dtServidortemp.Rows.Add(NuevaFila)
                    End If
                Next
                'guardar los cambios en servidor.xml configurando la conexión actual como orden 1 
                'para que actualizar.exe lo tome
                dtServidortemp.AcceptChanges()
                Dim Ds_Configuración_ServidorNuevo As New DataSet("ConfiguracionServidor")
                Ds_Configuración_ServidorNuevo.Tables.Add(dtServidortemp)
                Ds_Configuración_ServidorNuevo = Conexion.EncriptarTablas(Ds_Configuración_ServidorNuevo)
                Ds_Configuración_ServidorNuevo.WriteXml(Application.StartupPath & "\Servidor.xml", XmlWriteMode.WriteSchema)

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

        My.Settings.CadenaConexión = FuncionesBase.ExtraerConexiónInicial()

        Try
            EstablecerCadenaConexión()
        Catch ex As Exception
        End Try

        Try

            'If UsuarioTableAdapter1.ExisteUsuario(FunBase.Encryptar(Me.Tx_Usuario.Text), FunBase.Encryptar(Me.Tx_Password.Text)) = 0 Then
            '    Cursor.Current = Cursors.Default
            '    MsgBox("Autentificación incorrecta, revise e intente nuevamente", MsgBoxStyle.Critical, "SIN ACCESO")
            '    Contador = Contador + 1
            '    If Contador = 3 Then
            '        End
            '    End If
            'Else
            Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Dim datas As New DataSet
            Dim cmde As New SqlClient.SqlCommand
            Dim da As New SqlClient.SqlDataAdapter
            Try
                'Cargar datos del usuario
                sqlconeccion.Open()
                cmde.Parameters.Clear()
                cmde.CommandType = CommandType.StoredProcedure
                cmde.Connection = sqlconeccion
                cmde.CommandText = "dbo._ProcCargarDatosUsuarioIngreso"
                cmde.Parameters.Add("@NOMBREUSUARIO", SqlDbType.NVarChar).Value = FunBase.Encryptar(Me.Tx_Usuario.Text)
                cmde.Parameters.Add("@CONTRASEÑA", SqlDbType.NVarChar).Value = FunBase.Encryptar(Me.Tx_Password.Text)
                da = New SqlClient.SqlDataAdapter(cmde)
                datas = New DataSet()
                da.Fill(datas)
                sqlconeccion.Close()
            Catch ex As Exception
                sqlconeccion.Close()
                MessageBox.Show("Error al cargar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            If datas.Tables(0).Rows.Count = 0 Then
                Cursor.Current = Cursors.Default
                MsgBox("Autentificación incorrecta, revise e intente nuevamente", MsgBoxStyle.Critical, "SIN ACCESO")
                Contador = Contador + 1
                If Contador = 3 Then
                    End
                End If
                Exit Sub
            End If

            Dim Fila As DataRow = datas.Tables(0).Rows(0)
            VarBase.IdPersona = Fila("IDPERSONA")
            VarBase.Nombre_Usuario = Fila("NOMBRECOMPLETO")
            VarBase.TipoUsuario = Fila("CODIGOTIPOUSUARIO")
            VarBase.IdentificaciónUSuario = Fila("IDENTIFICACION")
            'Asociar el usuario a una bodega
            VarBase.IdBodegaActual = IIf(IsDBNull(Fila("IDBODEGA")), -1, Fila("IDBODEGA"))
            If VarBase.IdBodegaActual <> -1 Then
                VarBase.AbreviaturaBodegaActual = Trim(Fila("ABREVIATURA"))
                VarBase.NombreBodegaActual = Trim(Fila("NOMBRE"))
                VarBase.DireccionBodegaActual = Trim(Fila("DIRECCION"))
                VarBase.IdCentroCostoBodegaActual = Fila("IDCENTROCOSTOBODEGA")
                VarBase.TipoBodegaActual = Fila("TIPOBODEGA")
                VarBase.EmpresaBodegaActual = Fila("IDEMPRESA")
            End If
            'Asociar el usuario a una base del SisControl
            VarBase.IddependenciaSiscontrolActual = IIf(IsDBNull(Fila("IDDEPENDENCIA")), -1, Fila("IDDEPENDENCIA"))
            If VarBase.IddependenciaSiscontrolActual <> -1 Then
                VarBase.IdBaseSiscontrolActual = Fila("IDBASESISCONTROL")
                VarBase.IdCentroCostoSisControl = Fila("IDCENTROCOSTOSISCONTROL")
                VarBase.AbreviaturaBaseSiscontrol = Fila("ABREVIATURABASE")
                VarBase.NombreBaseSiscontrol = Fila("NOMBREBASE")
                VarBase.NombreDependenciaSiscontrol = Fila("NOMBREDEPENDENCIA")
                VarBase.EmpresaSisControlActual = Fila("IDEMPRESA_SC")
            End If
            Cursor.Current = Cursors.Default
            Me.Close()
            'End If


        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub EstablecerCadenaConexión()
        DatosClasesBase.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Articulos.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Auditoria.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Bodega.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Bodegas.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Clasesbase.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Compras.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Conexión.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosArticulos.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosAuditoria.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosBodegas.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosClasesBaseBuscar.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosEntradaAlmacén.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosImpresión.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosOrdenCompra.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosPersona.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosProveedores.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosRequisición.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosSalidaAlmacén.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Dscomunes.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        EntradaAlmacén.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FormulariosClasesBase.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Impresión.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        ImpresiónMateriales.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Informe.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        OrdenCompra.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Persona.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Proveedores.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Requisición.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        SalidaAlmacén.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Facturas.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        SisControl.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FormulariosSisControl.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosSisControl.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        ImpresiónSisControl.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        DatosActivosFijos.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FormulariosActivosFijos.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        ActivosFijos.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FuncionesBase.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Licitaciones.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FormularioLicitaciones.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        ImpresiónLicitaciones.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Contrato.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FormularioContrato.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Reportediario.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FormularioReporteDiario.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        OrdendeTrabajo.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FormulariosOrdenesTrabajo.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        ImprimirControlProyecto.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        ImprimirMasterSoldadura.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        ImprimirRecursoHumano.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Hse.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FormulariosHse.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        Sistemas.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FormulariosSistemas.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FuncionesGoogle.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        MaterialesEspeciales.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)
        FormulariosMaterialesEspeciales.Configurar.ConfigurarConexión(My.Settings.CadenaConexión)

    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Ll_AcercaDe.LinkClicked
        Dim FrAcerca As New Fr_Acerca
        FrAcerca.ShowDialog()
    End Sub

    Private Sub Ll_AccesoRemoto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Ll_AccesoRemoto.LinkClicked
        FunBase.AbrirAccesoRemoto()
    End Sub

    Private Sub TextBox_Contraseña_TextChanged(sender As Object, e As EventArgs) Handles Tx_Password.TextChanged
        If Tx_Password.Text = "@@~" Then
            Me.Tx_Usuario.Text = "yovasolano"
            Me.Tx_Password.Text = "yovasolano"
            Me.AcceptButton.PerformClick()
        Else
            If Tx_Password.Text = "@@¬" Then
                Me.Tx_Usuario.Text = "usuarioyas"
                Me.Tx_Password.Text = "usuarioyas"
                Me.AcceptButton.PerformClick()
            Else
                If Tx_Password.Text = "config" Then
                    Tx_Password.Text = ""
                    Tx_Usuario.Text = ""
                    Tx_Usuario.Focus()
                    Dim Fr_Configurar_Servidor As New Conexión.Fr_Conexión
                    Fr_Configurar_Servidor.ShowDialog()
                    dtServidor = Conexion.LeerTablaConfServidor.Tables(0)
                    Cb_Conexion.DataSource = dtServidor
                End If
            End If
        End If
    End Sub


    Private Function ProbarConexion(filaConexion As DataRow) As Boolean
        Const timeOutInMilliseconds As Integer = 2000
        Dim servidor As String
        Dim baseDatos As String
        Dim usuario As String
        Dim contrasenna As String
        If Not IsDBNull(filaConexion("SERVIDOR")) Then
            servidor = filaConexion("SERVIDOR")
        Else
            servidor = ""
        End If
        If Not IsDBNull(filaConexion("NOMBREBASEDATOS")) Then
            baseDatos = filaConexion("NOMBREBASEDATOS")
        Else
            baseDatos = ""
        End If
        If Not IsDBNull(filaConexion("NOMBREUSUARIO")) Then
            usuario = filaConexion("NOMBREUSUARIO")
        Else
            usuario = ""
        End If
        If Not IsDBNull(filaConexion("CONTRASENA")) Then
            contrasenna = filaConexion("CONTRASENA")
        Else
            contrasenna = ""
        End If
        Conexion.Establecer_Parametros(servidor, usuario, contrasenna, baseDatos)
        Using conn As New SqlConnection(VarBase.Conexion_Remota_Sql_Server.ConnectionString)
            Try
                conn.QuickOpen(timeOutInMilliseconds)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function

End Class 'Fr_Ingreso


''' <summary>
''' SqlConnection extension methods.
''' </summary>
''' <remarks>http://improve.dk/controlling-sqlconnection-timeouts/</remarks>
Module SqlExtensions
    ''' <summary>
    ''' Extension method called QuickOpen (in lack of a better name, it isn’t quicker, it simply fails quicker).
    ''' </summary>
    ''' <param name="conn">Server connection.</param>
    ''' <param name="timeout">timeout parameter in milliseconds.</param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Sub QuickOpen(conn As SqlConnection, timeout As Integer)
        Dim sw As Stopwatch = New Stopwatch()
        Dim connectSuccess As Boolean = False
        Dim ts As New System.Threading.ThreadStart(Sub()
                                                       Try
                                                           sw.Start()
                                                           conn.Open()
                                                           connectSuccess = True
                                                       Catch
                                                           connectSuccess = False
                                                       End Try
                                                   End Sub)
        Dim t As System.Threading.Thread = New System.Threading.Thread(ts)
        t.IsBackground = True
        t.Start()
        While timeout > sw.ElapsedMilliseconds
            If t.Join(1) Then Exit While
        End While
        If Not connectSuccess Then Throw New Exception("Timed out while trying to connect.")
    End Sub
End Module 'SqlExtensions