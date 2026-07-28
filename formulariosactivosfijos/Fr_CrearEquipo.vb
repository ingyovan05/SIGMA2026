Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System

Public Class Fr_CrearEquipo

    Dim ds As New DataSet
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()
    Public filas As Integer
    Public idtipo, idtipoverificacion As Integer
    Public idsubtipo, idsubtipoverificacion As Integer
    Public idarticulo, idarticuloverificacion As Integer
    Public articulovalido As Boolean
    Public proveedorvalido As Boolean
    Public idproveedor, idequipo As Integer
    Public personaasignada As Boolean
    Public varcreacion As String = "NUEVO" 'VARIABLE PARA SABER SI ESTOY EDITANDO CLONANDO O ES UN REGISTRO NUEVO


    Private Sub Fr_CrearEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llenar la tabla de tipo y la tabla de personas
        Cb_TipoArticulo.DataSource = Nothing
        CargarTipos()
        CargarMarcas()
        CargarBodegas()
        CargarPersonas()
        personaasignada = False
        Dtp_FechaIngreso.MaxDate = Date.Now
        Dtp_FechaIngreso.Text = Date.Now

        'revisar si se esta clonando el equipo
        If varcreacion <> "NUEVO" Then
            Try
                'extraer los datos del equipo para llenar
                Dim dscargar As New DataSet
                dscargar = bddatos.ModificarEquipos(5, 0, 0, idequipo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", False, Date.Now)
                LlenarEquipo(dscargar)
                'campos de la grilla
                Dim dscaracteristicas As New DataSet
                If Not IsDBNull(dscargar.Tables(0).Rows(0)("IDPERSONAASIGNADA")) Then
                    Cbx_Componente.Enabled = False
                    Cb_componente.Enabled = False
                End If
                'llenar catos de caracteristicas
                Try
                    dscaracteristicas = bddatos.ModificarCaracteristicas(7, Cb_TipoArticulo.SelectedValue, Cb_SubtipoArticulo.SelectedValue, 0, idequipo, "", "", 0, 0, False, "", 0, Date.Now, "")
                    'cargar datos
                    CargarCaracteristicas(dscaracteristicas)
                    'llenar valores existentes
                    LlenarCaracteristicas(dscaracteristicas)
                Catch ex As Exception
                    MsgBox("no se pueden leer las caracteristicas")
                End Try
                If varcreacion = "CLONAR" Then
                    idequipo = Nothing
                End If

                If varcreacion = "VER" Then
                    Btn_Guardar.Enabled = False
                End If

            Catch ex As Exception
                MsgBox("Error al intentar Cargar datos de equipo")
            End Try
        Else 'es formulario nuevo
            ProveedorDefecto() 'carga el proveedor por defecto 
        End If

    End Sub

    Public Sub LlenarCaracteristicas(ByVal dscaracteristicas As DataSet)
        Dim tablacaracteristicas As DataTable = Dgv_Caracteristicas.DataSource
        Dim i, j As Integer
        For i = 0 To (dscaracteristicas.Tables(0).Rows.Count - 1)
            For j = 0 To (Dgv_Caracteristicas.Rows.Count - 1)
                If dscaracteristicas.Tables(0).Rows(i)("IDCARACTERISTICA") = -1 Then
                    j = Dgv_Caracteristicas.Rows.Count
                Else
                    If tablacaracteristicas.Rows(j)("IDCARACTERISTICA") = dscaracteristicas.Tables(0).Rows(i)("IDCARACTERISTICASLISTA") Then
                        'revisar booleano
                        If dscaracteristicas.Tables(0).Rows(i)("IDTIPOCARACTERISTICA") = 3 Then
                            If dscaracteristicas.Tables(0).Rows(i)("VALOR") = 0 Then
                                Dgv_Caracteristicas("VALOR", j).Value = False
                            Else
                                Dgv_Caracteristicas("VALOR", j).Value = True
                            End If
                        Else
                            Dgv_Caracteristicas("VALOR", j).Value = dscaracteristicas.Tables(0).Rows(i)("VALOR")
                        End If
                        j = Dgv_Caracteristicas.Rows.Count
                    End If
                End If
            Next
        Next
    End Sub

    Public Sub LlenarEquipo(ByVal dsllenar As DataSet)
        'codigo articulo
        Tb_CodigoArticulo.Text = dsllenar.Tables(0).Rows(0)("IDARTICULO").ToString
        Dim ds2 As New DataSet
        ds2 = bddatos.ModificarArticulos(6, Tb_CodigoArticulo.Text, 0, "", "", "", 0, "", 0, "", 0, 0, 0, 0)
        llenarArticulo(ds2)
        'Tx_Consecutivo.Text = dsllenar.Tables(0).Rows(0)("CONSECUTIVO").ToString 'consecutivo

        'cargar codigos opcionales
        Tb_CodigoAccess.Text = dsllenar.Tables(0).Rows(0)("CODIGOACCESS").ToString
        Tb_CodigoIsmocol.Text = dsllenar.Tables(0).Rows(0)("CODIGOISMOCOL").ToString
        Tb_CodigoMecanico.Text = dsllenar.Tables(0).Rows(0)("CODIGOMECANICO").ToString

        'proveedor
        Tx_Identificación.Text = dsllenar.Tables(0).Rows(0)("IDPROVEEDOR").ToString
        If Tx_Identificación.Text = "-1" Then
            Tx_Identificación.Text = Nothing
            Tx_NombreProveedor.Text = "ISMOCOL S.A."
            Tb_NomenclaturaProveedor.Text = "ISM"
            Tb_NomenclaturaProveedor.BackColor = Color.WhiteSmoke
            idproveedor = -1
            proveedorvalido = True
        Else
            Dim dsproveedor As New DataSet
            dsproveedor = bddatos.ModificarEquipos(30, Integer.Parse(Tx_Identificación.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", False, Date.Now)
            Tx_Identificación.Text = dsproveedor.Tables(0).Rows(0)("IDENTIFICACION").ToString
            Cargar_Proveedor()
        End If

        'marca
        Cb_MarcaEquipo.SelectedValue = dsllenar.Tables(0).Rows(0)("IDMARCA")
        'modelo
        Cb_ModeloEquipo.SelectedValue = dsllenar.Tables(0).Rows(0)("IDMODELO")

        'fecha de ingreso 
        If dsllenar.Tables(0).Rows(0)("FECHAINGRESO") Is DBNull.Value Then
            Dtp_FechaIngreso.Checked = False
        Else
            If varcreacion = "CLONAR" Then
                Dtp_FechaIngreso.MaxDate = Date.Now
                Dtp_FechaIngreso.Text = Date.Now
                Dtp_FechaIngreso.Checked = True
            Else
                Dtp_FechaIngreso.Text = dsllenar.Tables(0).Rows(0)("FECHAINGRESO")
                Dtp_FechaIngreso.Checked = True
            End If

        End If
        'bodega de ingreso
        Cb_BodegaIngreso.SelectedValue = dsllenar.Tables(0).Rows(0)("IDBODEGAINGRESO")
        'persona recibe
        Cu_BuscarPersonaIngreso.Cb_Persona.SelectedValue = dsllenar.Tables(0).Rows(0)("IDPERSONAINGRESO")
        'perosna asignada
        Cu_BuscarPersonaAsignada.Cb_Persona.SelectedValue = dsllenar.Tables(0).Rows(0)("IDPERSONAASIGNADA")
        If Cu_BuscarPersonaAsignada.Cb_Persona.SelectedValue = Nothing Or varcreacion = "CLONAR" Then
            Cu_BuscarPersonaAsignada.Cb_Persona.Text = "NINGUNA - SE GUARDA COMO ESTADO 'EN BODEGA"
            Cu_BuscarPersonaAsignada.Tx_TextoCódigo.Text = "000"
        End If

        If varcreacion = "EDITAR" Then
            Tx_Consecutivo.Text = dsllenar.Tables(0).Rows(0)("CONSECUTIVO").ToString 'consecutivo
            ''llenar datos adicionales, si tiene padre yla bodega y la fecha de ingreso y registro
            Tb_DescripcionAdicional.Text = dsllenar.Tables(0).Rows(0)("DESCRIPCIONEQUIPO")
            If dsllenar.Tables(0).Rows(0)("IDEQUIPOPADRE") <> 0 Then
                Cbx_Componente.Checked = True
                Cb_componente.SelectedValue = dsllenar.Tables(0).Rows(0)("IDEQUIPOPADRE")
                Cu_BuscarPersonaAsignada.Enabled = False
            End If

            'BLOQUEAR LOS CAMPOS NO EDITABLES
            Gb_Articulo.Enabled = False

            'revisar si es un equipo padre, y deshabilitar la opcion de seleccionar componentes
            If dsllenar.Tables(2).Rows(0)("HIJOS").ToString <> "0" Then
                Cbx_Componente.Enabled = False
            End If
        ElseIf varcreacion = "CLONAR" Then
            ConsultarCaracteristicasYConsecutivo()
        End If
    End Sub

    Public Sub CargarTipos()
        Try
            'llenar la listas de tipos de articulos
            Dim ds2 As New DataSet
            ds2 = bddatos.ModificarTipos(1, 0, 0, "", "", "")
            Cb_TipoArticulo.DataSource = ds2.Tables(0).DefaultView
            Cb_TipoArticulo.ValueMember = "IDTIPO"
            Cb_TipoArticulo.DisplayMember = "DESCRIPCION"
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Public Sub CargarMarcas()
        'lleno el ds con las marcas
        Try
            ds = bddatos.ModificarMarcasModelos(3, 0, 0, "", "")
            Cb_MarcaEquipo.DataSource = ds.Tables(0).DefaultView
            Cb_MarcaEquipo.ValueMember = "CODIGOTIPOMARCA"
            Cb_MarcaEquipo.DisplayMember = "NOMBRETIPOMARCA"
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Public Sub CargarBodegas()
        'llenar las listas de bodegas
        Try
            ds = bddatos.ModificarEquipos(11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", False, Date.Now)
            Cb_BodegaIngreso.DataSource = ds.Tables(0).DefaultView
            Cb_BodegaIngreso.ValueMember = "ID"
            Cb_BodegaIngreso.DisplayMember = "NOMBRE"

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Public Sub CargarPersonas()
        'llenar las listas de bodegas
        Cu_BuscarPersonaAsignada.CargarDatos()
        If varcreacion = "NUEVO" Then
            Cu_BuscarPersonaAsignada.Cb_Persona.SelectedValue = -1
            Cu_BuscarPersonaAsignada.Tx_TextoCódigo.Text = "000"
            Cu_BuscarPersonaAsignada.Cb_Persona.Text = "NINGUNA - SE GUARDA COMO ESTADO 'EN BODEGA"
        End If
        Cu_BuscarPersonaIngreso.CargarDatos()
        Cu_BuscarPersonaIngreso.CargarCajaTexto()
    End Sub

    Private Sub Dgv_Caracteristicas_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Caracteristicas.CellEnter
        Dim descripcion As String
        descripcion = Dgv_Caracteristicas.CurrentRow.Cells("DESCRIPCIONCARACTERISTICA").Value.ToString
        Lbl_Descripcion.Text = descripcion
    End Sub


    Private Sub Dgv_Caracteristicas_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Dgv_Caracteristicas.EditingControlShowing
        If Dgv_Caracteristicas.CurrentRow.Cells("IDTIPOCARACTERISTICA").Value <> "4" Then
            'cuando se va a editar un campo revisar si es numerico y solo permitir numeros
            RemoveHandler CType(e.Control, TextBox).KeyPress, AddressOf CampoTexto
            RemoveHandler CType(e.Control, TextBox).KeyPress, AddressOf CampoNumerico
            If Dgv_Caracteristicas.CurrentRow.Cells("IDTIPOCARACTERISTICA").Value = "2" Then
                'el campo es numerico
                AddHandler CType(e.Control, TextBox).KeyPress, AddressOf CampoNumerico

            Else
                AddHandler CType(e.Control, TextBox).KeyPress, AddressOf CampoTexto

            End If
        End If
    End Sub

    Private Sub CampoNumerico(ByVal sender As Object, ByVal e As KeyPressEventArgs)

        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If

    End Sub

    Private Sub CampoTexto(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.Handled = False
    End Sub

    Private Sub Cb_TipoArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_TipoArticulo.SelectedIndexChanged
        'llenar la tabla de subtipo
        CargarSubtipo()
    End Sub

    Public Sub CargarSubtipo()
        Dim valor As Object = Cb_TipoArticulo.SelectedValue
        Dim a As Boolean = IsNumeric(valor)
        If a = True Then
            'si el valor seleccionado de tipo es numerico llenar la lista de subtipos de articulos
            Try
                Dim ds3 As New DataSet
                ds3 = bddatos.ModificarTipos(2, Cb_TipoArticulo.SelectedValue, 0, "", "", "")
                Cb_SubtipoArticulo.DataSource = ds3.Tables(0).DefaultView
                Cb_SubtipoArticulo.ValueMember = "IDSUBTIPO"
                Cb_SubtipoArticulo.DisplayMember = "DESCRIPCION"
                If ds3.Tables(0).Rows.Count = 0 Then
                    Dgv_Caracteristicas.DataSource = Nothing
                End If
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
    End Sub


    Private Sub Cb_SubtipoArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_SubtipoArticulo.SelectedIndexChanged
        ConsultarCaracteristicasYConsecutivo()
    End Sub

    Private Sub ConsultarCaracteristicasYConsecutivo()
        If varcreacion <> "EDITAR" Then
            'llenar la tabla de caracteristicas
            Dgv_Caracteristicas.ReadOnly = False
            Try
                ds = bddatos.ModificarCaracteristicas(2, 0, Cb_SubtipoArticulo.SelectedValue, 0, 0, "", "", idproveedor, 0, False, "", 0, Date.Now, "")
                'leer tabla de datos
                CargarCaracteristicas(ds)
                'Consultar el siguiente consecutivo de equipo según subtipo y proveedor seleccionados.
                If ds.Tables.Count > 1 Then
                    If ds.Tables(1).Rows.Count > 0 AndAlso Cb_SubtipoArticulo.SelectedValue > 0 Then
                        Tx_Consecutivo.Text = ds.Tables(1).Rows(0).Item("CONSECUTIVO")
                    End If
                End If
            Catch
            End Try
        End If
    End Sub


    Public Sub CargarCaracteristicas(ByVal dscar As DataSet)
        Dim tabladatos As New DataTable

        filas = dscar.Tables(0).Rows.Count
        If filas > 0 Then
            'existen propiedades adicionales

            'agrego las columnas del datatable
            tabladatos.Columns.Add("NOMBRECARACTERISTICA")
            tabladatos.Columns.Add("TIPO")
            tabladatos.Columns.Add("VALOR")
            tabladatos.Columns.Add("DESCRIPCIONCARACTERISTICA")
            tabladatos.Columns.Add("IDCARACTERISTICA")
            tabladatos.Columns.Add("IDTIPOCARACTERISTICA")
            tabladatos.Columns.Add("IRREPETIBLE")
            'lleno el datatable
            Dim j As Integer = 0
            For j = 0 To dscar.Tables(0).Rows.Count - 1
                tabladatos.Rows.Add(dscar.Tables(0).Rows(j)("NOMBRECARACTERISTICA"), dscar.Tables(0).Rows(j)("TIPO"), "", dscar.Tables(0).Rows(j)("DESCRIPCIONCARACTERISTICA"), dscar.Tables(0).Rows(j)("IDCARACTERISTICASLISTA"), dscar.Tables(0).Rows(j)("IDTIPOCARACTERISTICA"), dscar.Tables(0).Rows(j)("IRREPETIBLE"))

            Next
            'llenar la grilla de datos
            Me.Dgv_Caracteristicas.AutoGenerateColumns = False
            Me.Dgv_Caracteristicas.DataSource = tabladatos
            Me.Dgv_Caracteristicas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            'recorrer la grilla y poner los elementos que corresponen al tipo de caracteristica
            Dim i As Integer
            For i = 0 To tabladatos.Rows.Count - 1
                'agrego los controles personalizados a la grilla dependiendo del valor 


                Dim campo As Integer = tabladatos.Rows(i)("IDTIPOCARACTERISTICA")
                Select Case campo
                    Case 1
                        Dim TextBoxCell As New DataGridViewTextBoxCell
                        TextBoxCell.MaxInputLength = 50
                        Me.Dgv_Caracteristicas("VALOR", i) = TextBoxCell 'texto
                        Me.Dgv_Caracteristicas("VALOR", i).Value = ""

                    Case 2
                        Dim TextBoxCell As New DataGridViewTextBoxCell
                        TextBoxCell.MaxInputLength = 18
                        Me.Dgv_Caracteristicas("VALOR", i) = TextBoxCell 'numero
                        Me.Dgv_Caracteristicas("VALOR", i).Value = "0"

                    Case 3
                        Dim CheckBoxCell As New DataGridViewCheckBoxCell
                        CheckBoxCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Me.Dgv_Caracteristicas("VALOR", i) = CheckBoxCell  'boolean
                        Me.Dgv_Caracteristicas("VALOR", i).Value = False

                    Case 4
                        Dim TextBoxCell As New DataGridViewTextBoxCell 'fechas
                        Me.Dgv_Caracteristicas("VALOR", i) = TextBoxCell
                        Me.Dgv_Caracteristicas("VALOR", i).Value = ""


                End Select

            Next

        Else
            Dgv_Caracteristicas.DataSource = Nothing
        End If
    End Sub

    Private Sub Btn_Articulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Articulo.Click
        If Cb_SubtipoArticulo.SelectedValue = Nothing Or Cb_SubtipoArticulo.SelectedValue = 0 Then
            MsgBox("no hay ningun Subtipo de Articulo Seleccionado", MsgBoxStyle.Exclamation, "Selecciona un Subtipo")
            Return
        End If
        'abrir ventana con todos los articulos pertenecientes al subtipo, al dar dible click a uno o al boton de aceptar retornar valores con el id y el nombre del mismo
        Dim formarticulo As New Fr_SeleccionarArticulo
        formarticulo.nombretipo = Cb_TipoArticulo.Text
        formarticulo.nombresubtipo = Cb_SubtipoArticulo.Text
        formarticulo.idtipo = Cb_TipoArticulo.SelectedValue
        formarticulo.idsubtipo = Cb_SubtipoArticulo.SelectedValue
        formarticulo.ShowDialog()
        If formarticulo.idarticulo <> 0 Then
            Tb_CodigoArticulo.Text = formarticulo.idarticulo
            Dim ds2 As New DataSet
            ds2 = bddatos.ModificarArticulos(6, Tb_CodigoArticulo.Text, 0, "", "", "", 0, "", 0, "", 0, 0, 0, 0)
            llenarArticulo(ds2)
        End If
    End Sub

    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
        'verificar consecutivo valido
        If VerificarConsecutivo() = False Then
            Exit Sub
        End If


        'validacion de campos
        Dim validacion As Boolean = ValidarCampos()
        If validacion = True Then
            Exit Sub
        Else
            Dim datos As New DataTable

            'saco los valores
            Dim i As Integer = 0
            Dim cadena As String

            'llenar el registro del equipo
            Dim persona_asignada As New Integer
            If Cu_BuscarPersonaAsignada.Cb_Persona.SelectedValue = Nothing Then
                persona_asignada = -1
            Else
                persona_asignada = Cu_BuscarPersonaAsignada.Cb_Persona.SelectedValue
            End If

            Dim fechaingreso As Date
            If Dtp_FechaIngreso.Checked = False Then
                'no hay fecha de ingreso
                fechaingreso = Nothing
            Else
                fechaingreso = Dtp_FechaIngreso.Text
            End If
            'revisar si tiene padre seleccionado
            Dim idequipopadre As Integer
            If Cbx_Componente.Checked = True Then
                idequipopadre = Cb_componente.SelectedValue
            Else
                idequipopadre = 0
            End If

            'REVISAR si hay campos IRREPETIBLES y mirar si estan repitiendose
            Dim conteo As Integer
            conteo = Dgv_Caracteristicas.RowCount
            If conteo > 0 Then
                'revisar si existe algun campo irrepetible
                For i = 0 To conteo - 1
                    If Dgv_Caracteristicas.Rows(i).Cells("IRREPETIBLE").Value = "S" Then
                        'existe un campo irrepetible, verificar si el valor se esta repitiendo en otro articulo
                        'CON LA MISMA MARCA
                        'recuperar valores
                        Dim valortx As String = ""
                        Dim valornum As Single = 0
                        Dim valordt As Date = Date.Now
                        Dim valorsn As Boolean = False
                        Select Case Dgv_Caracteristicas.Rows(i).Cells("IDTIPOCARACTERISTICA").Value
                            Case 1
                                valortx = Dgv_Caracteristicas("VALOR", i).Value
                            Case 2
                                valornum = Dgv_Caracteristicas("VALOR", i).Value
                            Case 3
                                valorsn = Dgv_Caracteristicas("VALOR", i).Value
                            Case 4
                                valordt = Dgv_Caracteristicas("VALOR", i).Value
                        End Select
                        Dim DesRevisionRepetidos As New DataSet
                        If varcreacion = "NUEVO" Then
                            idequipo = 0
                        End If
                        Dim idCar As Integer = Dgv_Caracteristicas.Rows(i).Cells("IDCARACTERISTICASLISTA").Value
                        DesRevisionRepetidos = bddatos.ModificarCaracteristicas(16, Cb_MarcaEquipo.SelectedValue, 0, idCar, idequipo, "", "", 0, Dgv_Caracteristicas.Rows(i).Cells("IDTIPOCARACTERISTICA").Value, valorsn, valortx, valornum, valordt, "")
                        If DesRevisionRepetidos.Tables(0).Rows.Count > 0 Then
                            MsgBox("La caracteristica (" + Dgv_Caracteristicas.Rows(i).Cells("NOMBRECARACTERISTICA").Value + ") Es irrepetible y coincide con el equipo de código (" + DesRevisionRepetidos.Tables(0).Rows(0)("CODIGO") + ") el cual posee la misma marca (" + Cb_MarcaEquipo.Text + "). Por favor revisar y corregir la caracteristica mencionada ó la marca del equipo actual para proceder con el guardado.", vbOKOnly, "campos repetidos")
                            Exit Sub
                        End If
                    End If
                Next
            End If

            If varcreacion <> "EDITAR" Then
                Try
                    'PARA REGISTRO NUEVO O CLONADO
                    'guardar registro en la tabla de CAF_EQUIPO
                    If varcreacion = "CLONAR" Then
                        persona_asignada = -1
                    End If
                    ds = bddatos.ModificarEquipos(10, idproveedor, idarticulo, Tx_Consecutivo.Text, Cb_TipoArticulo.SelectedValue, Cb_SubtipoArticulo.SelectedValue, 0, idequipopadre, Cb_BodegaIngreso.SelectedValue, Cu_BuscarPersonaIngreso.Cb_Persona.SelectedValue, VariablesBase.VariablesBase.IdPersona, persona_asignada, VariablesBase.VariablesBase.IdBodegaActual, Cb_ModeloEquipo.SelectedValue, Cb_MarcaEquipo.SelectedValue, UCase(Tb_DescripcionAdicional.Text), Tb_CodigoIsmocol.Text, Tb_CodigoAccess.Text, Tb_CodigoMecanico.Text, 0, fechaingreso)

                    'llenar la tabla de datos con todos los datos
                    datos = Dgv_Caracteristicas.DataSource

                    'llenar las tablas de equipo
                    Dim idequipo As Integer = ds.Tables(0).Rows(0)("IDEQUIPO") 'obtengo el id del equipo que acabo de insertar

                    Dim dscaracteristicas As New DataSet
                    If datos IsNot Nothing Then
                        For i = 0 To (datos.Rows.Count - 1)
                            cadena = Dgv_Caracteristicas("VALOR", i).Value
                            datos(i)("VALOR") = cadena
                            If datos(i)("IDTIPOCARACTERISTICA") = 1 Then 'TEXTO
                                dscaracteristicas = bddatos.ModificarCaracteristicas(8, 0, 0, datos.Rows(i)("IDCARACTERISTICA"), idequipo, "", "", 0, 0, False, datos.Rows(i)("VALOR"), 0, Date.Now, "")

                            ElseIf datos(i)("IDTIPOCARACTERISTICA") = 2 Then 'NUMERO
                                Dim nulodecimal As Nullable(Of Decimal)
                                Dim tem As Decimal
                                Try
                                    tem = CDec(datos.Rows(i)("VALOR"))
                                    dscaracteristicas = bddatos.ModificarCaracteristicas(9, 0, 0, datos.Rows(i)("IDCARACTERISTICA"), idequipo, "", "", 0, 0, False, "", CDec(datos.Rows(i)("VALOR")), Date.Now, "")
                                Catch ex As Exception
                                    dscaracteristicas = bddatos.ModificarCaracteristicas(9, 0, 0, datos.Rows(i)("IDCARACTERISTICA"), idequipo, "", "", 0, 0, False, "", nulodecimal, Date.Now, "")
                                End Try

                            ElseIf datos(i)("IDTIPOCARACTERISTICA") = 3 Then 'SI/NO
                                    dscaracteristicas = bddatos.ModificarCaracteristicas(10, 0, 0, datos.Rows(i)("IDCARACTERISTICA"), idequipo, "", "", 0, 0, datos.Rows(i)("VALOR"), "", 0, Date.Now, "")

                            ElseIf datos(i)("IDTIPOCARACTERISTICA") = 4 Then 'FECHA

                                    Dim nulodate As Nullable(Of DateTime)

                                    If datos.Rows(i)("VALOR") Is Nothing Then
                                        datos.Rows(i)("VALOR") = ""
                                    End If

                                    If ValidarFechaCaracteristica(datos.Rows(i)("VALOR")) = False Then
                                        If datos.Rows(i)("VALOR") <> "" Then
                                            MsgBox("Valor de fecha no valido, revisar el formato (DD/MM/AAAA) en la caracteristica " + datos.Rows(i)("NOMBRECARACTERISTICA"))
                                            Exit Sub
                                        Else
                                            dscaracteristicas = bddatos.ModificarCaracteristicas(11, 0, 0, datos.Rows(i)("IDCARACTERISTICA"), idequipo, "", "", 0, 0, False, "", 0, nulodate, "")
                                        End If
                                    Else
                                    dscaracteristicas = bddatos.ModificarCaracteristicas(11, 0, 0, datos.Rows(i)("IDCARACTERISTICA"), idequipo, "", "", 0, 0, False, "", 0, CDate(datos.Rows(i)("VALOR")), "")
                                End If
                            End If
                        Next
                    End If
                    If MsgBox("Registro exitoso, desea agregar otro equipo?", vbYesNo, "registro exitoso") = MsgBoxResult.No Then
                        Me.Close()
                    End If
                Catch ex As Exception
                    MsgBox("error en el registro del equipo", vbCritical, "error")
                End Try
            Else
                Try
                    'PARA EDICION DE UN EQUIPO
                    'hacer el update de los datos del equipo
                    ds = bddatos.ModificarEquipos(14, idproveedor, 0, idequipo, 0, 0, 0, idequipopadre, Cb_BodegaIngreso.SelectedValue, Cu_BuscarPersonaIngreso.Cb_Persona.SelectedValue, VariablesBase.VariablesBase.IdPersona, persona_asignada, VariablesBase.VariablesBase.IdBodegaActual, Cb_ModeloEquipo.SelectedValue, Cb_MarcaEquipo.SelectedValue, UCase(Tb_DescripcionAdicional.Text), Tb_CodigoIsmocol.Text, Tb_CodigoAccess.Text, Tb_CodigoMecanico.Text, 0, Dtp_FechaIngreso.Value)
                    'llenar las tablas de equipo
                    ds = bddatos.ModificarCaracteristicas(7, Cb_TipoArticulo.SelectedValue, Cb_SubtipoArticulo.SelectedValue, 0, idequipo, "", "", 0, 0, False, "", 0, Date.Now, "")

                    'llenar la tabla de datos con todos los datos
                    datos = ds.Tables(0)
                    'hacer el update de los valores de las caracteristicas
                    'si el valor del id de caracteristica es -1 agregar el valor, si no, editar el existente
                    Dim dscaracteristicas As New DataSet
                    For i = 0 To (datos.Rows.Count - 1)
                        Try
                            cadena = Dgv_Caracteristicas("VALOR", i).Value
                        Catch ex As Exception
                            cadena = ""
                        End Try

                        If cadena = Nothing Then
                            cadena = ""
                        End If

                        If datos(i)("IDTIPOCARACTERISTICA") = 2 Then
                            If cadena = "" Then
                                cadena = Nothing
                            End If
                        End If

                        datos(i)("VALOR") = cadena
                        If datos(i)("IDTIPOCARACTERISTICA") = 1 Then 'TEXTO
                            If datos.Rows(i)("IDCARACTERISTICA") = -1 Then 'AGREGAR
                                dscaracteristicas = bddatos.ModificarCaracteristicas(8, 0, 0, datos.Rows(i)("IDCARACTERISTICASLISTA"), idequipo, "", "", 0, 0, False, datos.Rows(i)("VALOR"), 0, Date.Now, "")
                            Else 'EDITAR
                                dscaracteristicas = bddatos.ModificarCaracteristicas(12, 0, 0, 0, idequipo, "", "", datos.Rows(i)("IDCARACTERISTICA"), 0, False, datos.Rows(i)("VALOR"), 0, Date.Now, "")
                            End If

                        ElseIf datos(i)("IDTIPOCARACTERISTICA") = 2 Then 'NUMERO
                            If datos.Rows(i)("IDCARACTERISTICA") = -1 Then 'AGREGAR
                                Dim nulodecimal As Nullable(Of Decimal)
                                Dim tem As Decimal
                                Try
                                    tem = CDec(datos.Rows(i)("VALOR"))
                                    dscaracteristicas = bddatos.ModificarCaracteristicas(9, 0, 0, datos.Rows(i)("IDCARACTERISTICASLISTA"), idequipo, "", "", 0, 0, False, "", CDec(datos.Rows(i)("VALOR")), Date.Now, "")
                                Catch ex As Exception
                                    dscaracteristicas = bddatos.ModificarCaracteristicas(9, 0, 0, datos.Rows(i)("IDCARACTERISTICASLISTA"), idequipo, "", "", 0, 0, False, "", nulodecimal, Date.Now, "")
                                End Try
                            Else 'EDITAR
                                Dim nulodecimal As Nullable(Of Decimal)
                                Dim tem As Decimal
                                Try
                                    tem = CDec(datos.Rows(i)("VALOR"))
                                    dscaracteristicas = bddatos.ModificarCaracteristicas(13, 0, 0, 0, idequipo, "", "", datos.Rows(i)("IDCARACTERISTICA"), 0, False, "", CDec(datos.Rows(i)("VALOR")), Date.Now, "")
                                Catch ex As Exception
                                    dscaracteristicas = bddatos.ModificarCaracteristicas(13, 0, 0, 0, idequipo, "", "", datos.Rows(i)("IDCARACTERISTICA"), 0, False, "", nulodecimal, Date.Now, "")
                                End Try
                            End If
                        ElseIf datos(i)("IDTIPOCARACTERISTICA") = 3 Then 'SI/NO
                            If datos.Rows(i)("IDCARACTERISTICA") = -1 Then 'AGREGAR
                                dscaracteristicas = bddatos.ModificarCaracteristicas(10, 0, 0, datos.Rows(i)("IDCARACTERISTICASLISTA"), idequipo, "", "", 0, 0, datos.Rows(i)("VALOR"), "", 0, Date.Now, "")
                            Else 'EDITAR
                                dscaracteristicas = bddatos.ModificarCaracteristicas(14, 0, 0, 0, idequipo, "", "", datos.Rows(i)("IDCARACTERISTICA"), 0, datos.Rows(i)("VALOR"), "", 0, Date.Now, "")
                            End If
                        ElseIf datos(i)("IDTIPOCARACTERISTICA") = 4 Then 'FECHA
                            Dim nulodate As Nullable(Of DateTime)
                            If datos.Rows(i)("VALOR") Is Nothing Then
                                datos.Rows(i)("VALOR") = ""
                            End If

                            If ValidarFechaCaracteristica(datos.Rows(i)("VALOR")) = False Then
                                If datos.Rows(i)("VALOR") <> "" Then
                                    MsgBox("Valor de fecha no valido, revisar el formato (DD/MM/AAAA) en la caracteristica " + datos.Rows(i)("NOMBRECARACTERISTICA"))
                                    Exit Sub
                                Else
                                    If datos.Rows(i)("IDCARACTERISTICA") = -1 Then 'AGREGAR
                                        dscaracteristicas = bddatos.ModificarCaracteristicas(11, 0, 0, datos.Rows(i)("IDCARACTERISTICASLISTA"), idequipo, "", "", 0, 0, False, "", 0, nulodate, "")
                                    Else 'EDITAR
                                        dscaracteristicas = bddatos.ModificarCaracteristicas(15, 0, 0, 0, idequipo, "", "", datos.Rows(i)("IDCARACTERISTICA"), 0, False, "", 0, nulodate, "")
                                    End If
                                End If
                            Else
                                If datos.Rows(i)("IDCARACTERISTICA") = -1 Then 'AGREGAR
                                    dscaracteristicas = bddatos.ModificarCaracteristicas(11, 0, 0, datos.Rows(i)("IDCARACTERISTICASLISTA"), idequipo, "", "", 0, 0, False, "", 0, CDate(datos.Rows(i)("VALOR")), "")
                                Else 'EDITAR
                                    dscaracteristicas = bddatos.ModificarCaracteristicas(15, 0, 0, 0, idequipo, "", "", datos.Rows(i)("IDCARACTERISTICA"), 0, False, "", 0, CDate(datos.Rows(i)("VALOR")), "")
                                End If
                            End If

                        End If
                    Next
                    MsgBox("Datos Actualizados Correctamente", vbOKOnly, "Registro Modificado")
                    Me.Close()
                Catch ex As Exception
                    MsgBox("error en la edicion del equipo", vbCritical, "error")
                End Try
            End If
        End If
    End Sub

    Public Function ValidarFechaCaracteristica(ByVal fecha As String) As Boolean
        If fecha.LongCount <> 10 Then
            ValidarFechaCaracteristica = False
            Exit Function
        End If
        Dim dia As String
        Dim mes As String
        Dim año As String
        dia = Mid(fecha, 1, fecha.IndexOf("/"))
        fecha = Mid(fecha, fecha.IndexOf("/") + 2, fecha.Length - fecha.IndexOf("/"))
        mes = Mid(fecha, 1, fecha.IndexOf("/"))
        fecha = Mid(fecha, fecha.IndexOf("/") + 2, fecha.Length - fecha.IndexOf("/"))
        año = fecha
        Try
            Dim fechavalida As New DateTime(Int(año), Int(mes), Int(dia))

        Catch ex As Exception
            ValidarFechaCaracteristica = False
            Exit Function
        End Try
        ValidarFechaCaracteristica = True
    End Function


    Public Function ValidarCampos() As Boolean
        'PARA REGISTRO NUEVO
        'validacion de campos
        Dim strmensaje As String
        ValidarCampos = False
        strmensaje = "Los siguientes campos estan erroneos:"

        'revisar si se repiten los codigos de access ismocol o mecánico
        If Tb_CodigoAccess.Text <> "" Or Tb_CodigoIsmocol.Text <> "" Or Tb_CodigoMecanico.Text <> "" Then
            Try
                Dim dsCodigos As New DataSet
                dsCodigos = bddatos.ModificarEquipos(33, 0, 0, idequipo, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", Tb_CodigoIsmocol.Text, Tb_CodigoAccess.Text, Tb_CodigoMecanico.Text, False, Date.Now)
                If dsCodigos.Tables(0).Rows.Count > 0 Then
                    strmensaje += vbCrLf + "* El código ACCESS ya pertenece al equipo " + dsCodigos.Tables(0).Rows(0)(0).ToString
                    ValidarCampos = True
                End If
                If dsCodigos.Tables(1).Rows.Count > 0 Then
                    strmensaje += vbCrLf + "* El código ISMOCOL ya pertenece al equipo " + dsCodigos.Tables(1).Rows(0)(0).ToString
                    ValidarCampos = True
                End If
                If dsCodigos.Tables(2).Rows.Count > 0 Then
                    strmensaje += vbCrLf + "* El código MECANICO ya pertenece al equipo " + dsCodigos.Tables(2).Rows(0)(0).ToString
                    ValidarCampos = True
                End If
            Catch ex As Exception
                MsgBox("Error en codigos access, ismocol o mecanico")
                ValidarCampos = True
                Exit Function
            End Try
        End If

        'tipo y subtipo
        If Cb_SubtipoArticulo.SelectedValue = Nothing Or Cb_SubtipoArticulo.SelectedValue = 0 Or Cb_TipoArticulo.SelectedValue = Nothing Or Cb_TipoArticulo.SelectedValue = 0 Then
            strmensaje += vbCrLf + "* Falta el TIPO o el SUBTIPO de Artículo, debe seleccionar un tipo y un subtipo"
            ValidarCampos = True
        End If

        'persona que recibio por primera vez
        If Cu_BuscarPersonaIngreso.Cb_Persona.SelectedValue = Nothing Then
            strmensaje += vbCrLf + "* Falta seleccionar una PERSONA QUE RECIBE el equipo por primera vez, asegurese de que ha seleccionado una correctamente"
            ValidarCampos = True
        End If

        'persona asignada
        If Cu_BuscarPersonaAsignada.Cb_Persona.SelectedValue = Nothing And Cu_BuscarPersonaAsignada.Cb_Persona.Text <> "NINGUNA - SE GUARDA COMO ESTADO 'EN BODEGA" Then
            strmensaje += vbCrLf + "* la PERSONA ASIGNADA es erronea, recuerde, si no hay ninguna persona asignada pulse enter en la caja de identificacion vacia o con un valor de 0"
            ValidarCampos = True
        End If


        'articulo
        If articulovalido = False Then
            strmensaje += vbCrLf + "* El ARTÍCULO esta vacío o no es válido, escriba un articulo valido"
            ValidarCampos = True
        End If

        'verificacion de varialbes de articulo tipo y subtipo para ver que coiciden
        If Tb_CodigoArticulo.Text <> "" Then
            If idarticuloverificacion <> Tb_CodigoArticulo.Text Or idtipoverificacion <> Cb_TipoArticulo.SelectedValue Or idsubtipoverificacion <> Cb_SubtipoArticulo.SelectedValue Then
                strmensaje += vbCrLf + "* El código del ARTICULO no coincide con el TIPO y el SUBTIPO seleccionados"
                ValidarCampos = True
            End If
        End If

        'proveedor
        If proveedorvalido = False Then
            strmensaje += vbCrLf + "* El PROVEEDOR esta vacío o no es válido, Debe tener una nomenclatura valida"
            ValidarCampos = True
        End If

        'marca y modelo
        If Cb_ModeloEquipo.SelectedValue = Nothing Or Cb_MarcaEquipo.SelectedValue = Nothing Then
            strmensaje += vbCrLf + "* Debe seleccionar una MARCA y un MODELO validos"
            ValidarCampos = True
        End If

        'equipo padre
        If Cbx_Componente.Checked = True And Cb_componente.SelectedValue = Nothing Then
            ValidarCampos = True
            strmensaje += vbCrLf + "* Falta seleccionar un EQUIPO valido al cual PERTENECE el componente"
        End If

        If varcreacion = "NUEVO" Or varcreacion = "CLONAR" Then
            'revisar si se esta excediendo el numero de articulos disponibles para la bodega actual
            Dim dsDisponibles As New DataSet
            Try
                dsDisponibles = bddatos.ModificarEquipos(29, 0, Integer.Parse(Tb_CodigoArticulo.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, VariablesBase.VariablesBase.IdBodegaActual, 0, 0, "", "", "", "", False, Date.Now)
                If dsDisponibles.Tables(0).Rows.Count = 0 Then
                    'no hay existencias del articulo mencionado
                    strmensaje += vbCrLf + "* El Artículo con Código: " + Tb_CodigoArticulo.Text + " no se encuentra en Stock"
                    ValidarCampos = True
                Else
                    'existe un numero en stock
                    Dim stock As Integer = 0
                    Dim creados As Integer = 0
                    Dim total As Integer
                    stock = dsDisponibles.Tables(0).Rows(0)("STOCK")
                    creados = dsDisponibles.Tables(1).Rows(0)("CREADOS")
                    total = stock - creados
                    If total <= 0 Then
                        strmensaje += vbCrLf + "* No se pueden agregar mas articulos con codigo: " + Tb_CodigoArticulo.Text + " ya que el limite de stock es de: " + stock.ToString + " y ya hay: " + creados.ToString + " Existencias creadas"
                        ValidarCampos = True
                    End If
                End If
            Catch ex As Exception
                ValidarCampos = True
            End Try
        End If

        If ValidarCampos = True Then
            MsgBox(strmensaje, vbCritical, "Faltan Campos")
        End If

    End Function

    Private Sub Btn_BuscarProveedor_Click(sender As System.Object, e As System.EventArgs) Handles Btn_BuscarProveedor.Click
        Dim FrBuscarProveedor As New FormulariosClasesBase.Fr_BuscarProveedor
        FrBuscarProveedor.Cargar_Tabla()
        FrBuscarProveedor.ShowDialog()
        Try
            Me.Tx_Identificación.Text = FrBuscarProveedor.Identificacion
            Cargar_Proveedor()
            'Consultar siguiente consecutivo
            ConsultarCaracteristicasYConsecutivo()
        Catch ex As Exception
        End Try
    End Sub

    Dim FilaProveedor As DataRow
    Dim DsOrdenCompra As New DatosOrdenCompra.Ds_OrdenCompra

    Private Sub Cargar_Proveedor()
        Me.Tx_Identificación.Text = Trim(Me.Tx_Identificación.Text)
        Dim PROVEEDORTableAdapter As New DatosOrdenCompra.Ds_OrdenCompraTableAdapters.PROVEEDORTableAdapter
        PROVEEDORTableAdapter.FillIDENTIFICACION(Me.DsOrdenCompra.PROVEEDOR, Me.Tx_Identificación.Text)
        If Me.DsOrdenCompra.PROVEEDOR.Rows.Count > 0 Then
            FilaProveedor = Me.DsOrdenCompra.PROVEEDOR.Rows(0)
            Me.Tx_DigVerificación.Text = Trim(FilaProveedor("DIGITOVERIFICACION"))
            If Trim(FilaProveedor("NOMBRE")) <> "" Then
                Me.Tx_NombreProveedor.Text = Trim(FilaProveedor("NOMBRE"))
            Else
                Me.Tx_NombreProveedor.Text = Trim(FilaProveedor("NOMBREPROVEEDOR"))
            End If
            If FilaProveedor("NOMENCLATURA") Is DBNull.Value Then
                Me.Tb_NomenclaturaProveedor.Text = ""
                idproveedor = FilaProveedor("IDPROVEEDOR")
                Tb_NomenclaturaProveedor.BackColor = Color.Pink
                proveedorvalido = True
            Else
                Me.Tb_NomenclaturaProveedor.Text = Trim(FilaProveedor("NOMENCLATURA"))
                Tb_NomenclaturaProveedor.BackColor = Color.WhiteSmoke
                idproveedor = FilaProveedor("IDPROVEEDOR")
                proveedorvalido = True
            End If
        Else
            Me.Tx_Identificación.Focus()
        End If
    End Sub

    Private Sub Tb_CodigoArticulo_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tb_CodigoArticulo.TextChanged
        articulovalido = False 'para saber si el articulo es valido o existe
        Cb_TipoArticulo.SelectedValue = 0
        idarticulo = 0
        Dim valor As Object = Tb_CodigoArticulo.Text
        Dim a As Boolean = IsNumeric(valor)
        If a = True Then 'si es numero
            Tb_NombreArticulo.Text = "Oprima ENTER Para Buscar y llenar"
        Else
            Tb_NombreArticulo.Text = "Introduzca un valor numérico"
        End If

    End Sub

    Private Sub llenarArticulo(ByVal ds2 As DataSet)
        Tb_NombreArticulo.Text = ds2.Tables(0).Rows(0)("NOMBRE").ToString
        Cb_TipoArticulo.SelectedValue = ds2.Tables(0).Rows(0)("IDTIPO")
        Cb_SubtipoArticulo.SelectedValue = ds2.Tables(0).Rows(0)("IDSUBTIPO")
        'variables de validacion en el momento de hacer click en guardar
        articulovalido = True
        idarticulo = ds2.Tables(0).Rows(0)("IDARTICULO")
        idarticuloverificacion = Tb_CodigoArticulo.Text
        idtipoverificacion = Cb_TipoArticulo.SelectedValue
        idsubtipoverificacion = Cb_SubtipoArticulo.SelectedValue
    End Sub

    Private Sub Cb_MarcaEquipo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_MarcaEquipo.SelectedValueChanged
        'LLENAR LOS MODELOS
        Try
            ds = bddatos.ModificarMarcasModelos(1, 0, Cb_MarcaEquipo.SelectedValue, "", "")
            Cb_ModeloEquipo.DataSource = ds.Tables(0).DefaultView
            Cb_ModeloEquipo.ValueMember = "CODIGOTIPOMODELO"
            Cb_ModeloEquipo.DisplayMember = "NOMBRETIPOMODELO"
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub Bt_AgregarModeloEquipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_AgregarModeloEquipo.Click
        If Cb_MarcaEquipo.SelectedValue = 0 Then
            MsgBox("no hay una marca seleccionada", MsgBoxStyle.Information, "error")
            Exit Sub
        End If
        Dim frmodelomarca As New Fr_AgregarModeloMarca
        frmodelomarca.modelomarca = False ' si es falsa se agrega modelo, si es verdadera se agrega marca
        frmodelomarca.idmarca = Cb_MarcaEquipo.SelectedValue
        frmodelomarca.ShowDialog()
        If frmodelomarca.agregada = True Then
            CargarMarcas()
            Cb_MarcaEquipo.SelectedValue = frmodelomarca.idmarca
        End If

    End Sub

    Private Sub Bt_AgregarMarcaEquipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_AgregarMarcaEquipo.Click
        Dim frmodelomarca As New Fr_AgregarModeloMarca
        frmodelomarca.modelomarca = True ' si es falsa se agrega modelo, si es verdadera se agrega marca
        frmodelomarca.ShowDialog()
        If frmodelomarca.agregada = True Then
            CargarMarcas()
        End If
    End Sub

    Private Sub Tx_Identificación_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tx_Identificación.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                If Tx_Identificación.Text = Nothing Or Tx_Identificación.Text = "0" Then
                    ProveedorDefecto()
                Else
                    Cargar_Proveedor()
                End If
            End If
        Catch ex As Exception
            MsgBox("error al cargar el proveedor")
        End Try
    End Sub

    Private Sub ProveedorDefecto()
        Tx_NombreProveedor.Text = "ISMOCOL S.A."
        Tb_NomenclaturaProveedor.Text = "ISM"
        Tb_NomenclaturaProveedor.BackColor = Color.WhiteSmoke
        idproveedor = -1
        proveedorvalido = True
    End Sub

    Public Sub LimpiarProveedor()
        Tx_DigVerificación.Text = ""
        Tx_NombreProveedor.Text = "Oprima ENTER Para Buscar y llenar"
        Tb_NomenclaturaProveedor.Text = ""
        proveedorvalido = False
    End Sub

    Private Sub Tx_Identificación_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tx_Identificación.TextChanged
        LimpiarProveedor()
    End Sub

    Private Sub Tb_CodigoArticulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tb_CodigoArticulo.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                'buscar el articulo que corresponda al id correspondiente, llenar las cajas de tipo y subtipo y escribir el nombre del articulo en la caja de texto
                If Tb_NombreArticulo.Text <> "" Then
                    Dim ds2 As New DataSet
                    ds2 = bddatos.ModificarArticulos(6, Tb_CodigoArticulo.Text, 0, "", "", "", 0, "", 0, "", 0, 0, 0, 0)
                    If ds2.Tables(0).Rows.Count > 0 Then
                        llenarArticulo(ds2)
                    Else
                        Tb_NombreArticulo.Text = "Articulo NO encontrado, verificar numero"
                    End If
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Tb_Codigotipo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Tb_Codigotipo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Tb_Codigosubtipo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Public Sub EventoCajaEnter(Optional ByVal NombreComponente As String = "")
        Dim filas() As DataRow
        Select Case NombreComponente
            Case Me.Cu_BuscarPersonaAsignada.Name
                Try
                    filas = Cu_BuscarPersonaAsignada.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaAsignada.Tx_TextoCódigo.Text).ToString + "'")
                    If Cu_BuscarPersonaAsignada.Tx_TextoCódigo.Text = "" Or Cu_BuscarPersonaAsignada.Tx_TextoCódigo.Text = Nothing Or Cu_BuscarPersonaAsignada.Tx_TextoCódigo.Text = 0 Then
                        'Cu_BuscarPersonaAsignada.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefecto("C", "RQ", "SOLICITA", -1)
                        Cu_BuscarPersonaAsignada.Cb_Persona.SelectedValue = -1
                        Cu_BuscarPersonaAsignada.Cb_Persona.Text = "NINGUNA - SE GUARDA COMO ESTADO 'EN BODEGA"
                        Me.Cu_BuscarPersonaAsignada.Tx_TextoCódigo.Text = "000"
                        personaasignada = False
                    Else
                        If filas.Length > 0 Then
                            Dim fila As DataRow = filas(0)
                            Me.Cu_BuscarPersonaAsignada.Cb_Persona.SelectedValue = fila("IDPERSONA")
                            personaasignada = True
                        Else
                            MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                        End If
                    End If
                Catch ex As Exception
                    Me.Cu_BuscarPersonaAsignada.Tx_TextoCódigo.Text = "000"
                    Cu_BuscarPersonaAsignada.Cb_Persona.SelectedValue = -1
                    Cu_BuscarPersonaAsignada.Cb_Persona.Text = "NINGUNA - SE GUARDA COMO ESTADO 'EN BODEGA"
                    personaasignada = False
                End Try

            Case Me.Cu_BuscarPersonaIngreso.Name
                Try
                    filas = Cu_BuscarPersonaIngreso.DT_BUSCARPERSONA.Select("IDENTIFICACION='" + (Cu_BuscarPersonaIngreso.Tx_TextoCódigo.Text).ToString + "'")
                    If filas.Length > 0 Then
                        Dim fila As DataRow = filas(0)
                        Me.Cu_BuscarPersonaIngreso.Cb_Persona.SelectedValue = fila("IDPERSONA")
                    Else
                        MsgBox("Esta identificación no esta registrada o no esta asociada a la bodega", MsgBoxStyle.Critical, "No se encuentra")
                    End If
                Catch ex As Exception
                    Me.Cu_BuscarPersonaIngreso.Tx_TextoCódigo.Text = ""
                End Try
        End Select
    End Sub

   
    Private Sub Cb_BodegaIngreso_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_BodegaIngreso.SelectedValueChanged

        Try
            If Cb_BodegaIngreso.SelectedValue <> Nothing Then
                Dim idbodega As Integer = VariablesBase.VariablesBase.IdBodegaActual
                VariablesBase.VariablesBase.IdBodegaActual = Cb_BodegaIngreso.SelectedValue
                Cu_BuscarPersonaIngreso.CargarDatos()
                Cu_BuscarPersonaIngreso.CargarCajaTexto()
                VariablesBase.VariablesBase.IdBodegaActual = idbodega
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cbx_Componente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbx_Componente.CheckedChanged
        If Cbx_Componente.Checked = True Then
            'Cu_BuscarPersonaAsignada.Enabled = False
            'cargar equipos asignables
            Dim idequipoverificacion As New Integer
            If varcreacion = "EDITAR" Then
                idequipoverificacion = idequipo
            Else
                idequipoverificacion = 0
            End If
            Dim dscomponentes As New DataSet
            Dim idbodega As Integer = VariablesBase.VariablesBase.IdBodegaActual
            dscomponentes = bddatos.ModificarEquipos(3, 0, 0, idequipoverificacion, 0, 0, 0, 0, 0, 0, 0, 0, idbodega, 0, 0, "", "", "", "", False, Date.Now)
            Cb_componente.DataSource = dscomponentes.Tables(0).DefaultView
            Cb_componente.ValueMember = "IDEQUIPO"
            Cb_componente.DisplayMember = "NOMBREEQUIPO"
        Else
            'Cu_BuscarPersonaAsignada.Enabled = True
        End If
    End Sub

    Private Sub Lb_PerRec_Click(sender As Object, e As EventArgs) Handles Lb_PerRec.Click
        MsgBox("Persona que recibió el equipo por primera vez en la compañía ")
    End Sub

    Private Sub Lb_BodIng_Click(sender As Object, e As EventArgs) Handles Lb_BodIng.Click
        MsgBox("Bodega en donde Se recibió el equipo por primera vez en la compañía ")
    End Sub

    Private Sub Lb_FecIng_Click(sender As Object, e As EventArgs) Handles Lb_FecIng.Click
        MsgBox("Fecha en la cual se recibió el equipo por primera vez en la compañía ")
    End Sub

    
    Private Sub Tx_Consecutivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_Consecutivo.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Bt_VerifiCons_Click(sender As Object, e As EventArgs) Handles Bt_VerifiCons.Click
        If VerificarConsecutivo() = True Then
            MsgBox("Número de consecutivo disponible")
        End If
    End Sub

    Public Function VerificarConsecutivo() As Boolean
        If Tx_Consecutivo.Text = "" Then
            MsgBox("El campo de consecutivo no puede estar vacío.", MsgBoxStyle.OkOnly, "Campo vacío")
            VerificarConsecutivo = False
            Tx_Consecutivo.Focus()
            Exit Function
        End If
        VerificarConsecutivo = IsNumeric(Tx_Consecutivo.Text)
        If VerificarConsecutivo = False Then
            MsgBox("El Campo de Consecutivo debe ser Numérico.", MsgBoxStyle.Critical, "Campo incorrecto")
            Exit Function
        End If
        If Tx_Consecutivo.Text < 0 Then
            MsgBox("El consecutivo debe ser mayor que 0", MsgBoxStyle.Exclamation, "Consecutio inválido")
            VerificarConsecutivo = False
            Exit Function
        End If
        'revisar que haya un tipo y un subtipo seleccionado
        If Cb_TipoArticulo.SelectedValue = Nothing Or Cb_SubtipoArticulo.SelectedValue = Nothing Then
            MsgBox("Sebe Seleccionar un tipo y un Subtipo válidos", MsgBoxStyle.Exclamation, "Falta tipo o subtipo")
            VerificarConsecutivo = False
            Exit Function
        End If

        'revisar que no se repita en la base de datos
        Dim dsconsecutivo As New DataSet
        dsconsecutivo = bddatos.ModificarEquipos(32, Me.idproveedor, Tx_Consecutivo.Text, idequipo, Cb_TipoArticulo.SelectedValue, Cb_SubtipoArticulo.SelectedValue, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", False, Date.Now)
        If dsconsecutivo.Tables(0).Rows.Count > 0 Then
            MsgBox("Este consecutivo ya existe para el proveedor seleccionado, tipo " + Cb_TipoArticulo.Text + " y Subtipo " + Cb_SubtipoArticulo.Text, MsgBoxStyle.Information, "Campo Repetido")
            VerificarConsecutivo = False
        Else
            VerificarConsecutivo = True
            Exit Function
        End If
    End Function

    Private Sub Lb_infoproveedor_Click(sender As Object, e As EventArgs) Handles Lb_infoproveedor.Click
        MsgBox("Para establecer como proveedor a ISMOCOL S.A. deje la caja de identificación vacía y oprima la tecla 'ENTER'", MsgBoxStyle.Information, "proveedor")
    End Sub

    Private Sub Lb_asignadaInfo_Click(sender As Object, e As EventArgs) Handles Lb_asignadaInfo.Click
        MsgBox("Para cambiar la persona asignada a este articulo debe hacer una salida de almacén con motivo 'SALIDA CUSTODIA'", MsgBoxStyle.Information, "Persona Asignada")
    End Sub
End Class
