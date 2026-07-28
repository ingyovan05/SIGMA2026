Imports System.Drawing
Imports System.Windows.Forms

Public Class Fr_BuscarEquipo


    Public IdEquipo As Integer
    Public NombreEquipo As String
    Public CaracteristicasEquipo As ArrayList
    Public ContadorHoraKilometro As String
    Public Tipo As String


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Buscar.CellClick
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Me.Panel3.Visible = False
        If dgv.CurrentRow IsNot Nothing Then
            Dim FilaSeleccionada As DataGridViewRow = DirectCast(dgv.CurrentRow.Clone(), DataGridViewRow)


            If validadarOdoKm() = True Then
                MsgBox("No no se ha seleccionado el Contador '", MsgBoxStyle.Critical, "EQUIPOS")
                Tb_HoraKilometro.Focus()
                Exit Sub
            End If

        End If
    End Sub
    Private Sub Tb_HoraKilometro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tb_HoraKilometro.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        'Verificar que el codigo del municipio no este en la lista


        If validadarOdoKm() = True Then

            'Verificar que el codigo del municipio no este en la lista
            Try
                IdEquipo = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IDEQUIPO").Value
                NombreEquipo = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("CODIGO").Value
            Catch ex As Exception

            End Try


            Exit Sub
        Else

            Try

                Select Case Tipo
                    Case "C"
                        IdEquipo = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IDEQUIPO").Value
                        NombreEquipo = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("CODIGO").Value
                        If Not IsNumeric(Tb_HoraKilometro.Text) Then
                            MsgBox("No se ha agregado el registro", MsgBoxStyle.Critical, "REGISTRO CONTADOR")

                            Exit Sub
                            Tb_HoraKilometro.Focus()

                        End If

                        Dim b As String = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("UltimoRegistrohkequipo").Value

                        Dim ultimoregistrocontador As Integer
                        If b <> "" Then
                            ultimoregistrocontador = Conversion.Int(b)
                        Else
                            ultimoregistrocontador = -1
                        End If


                        ContadorHoraKilometro = Me.Tb_HoraKilometro.Text
                        Dim NuevoRegistroContador As Integer = Conversion.Int(Me.Tb_HoraKilometro.Text)
                        If NuevoRegistroContador > ultimoregistrocontador Then

                        Else
                            MsgBox("El valor registrado en el contado es  menor al ultimo registrado en SIGMA", MsgBoxStyle.Critical, "REGISTRO CONTADOR")
                            Tb_HoraKilometro.Focus()
                            Tb_HoraKilometro.Text = ""
                            Exit Sub

                        End If

                    Case Else

                End Select

            Catch ex As Exception
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            End Try


        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub




    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dgv_Buscar_RowPostPaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles Dgv_Buscar.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If Dgv_Buscar.RowHeadersWidth < CInt(size.Width + 20) Then
            Dgv_Buscar.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim bt As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub Fr_BuscarCentroCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Dgv_Buscar.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Buscar.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.ComboBox_Filtrar.SelectedIndex = 0
    End Sub

    Public datas As New DataSet
    Public cmde As New SqlClient.SqlCommand
    Public da As New SqlClient.SqlDataAdapter

    Public datas2 As New DataTable


    Public Sub BuscarEquiposCombustibleBase()

        Dim sqlConexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        sqlConexion.Open()
        cmde.Parameters.Clear()
        cmde.CommandType = CommandType.StoredProcedure
        cmde.Connection = sqlConexion
        cmde.CommandText = "dbo.BuscarCentroCostoxDependencia"
        cmde.Parameters.Add("@IDBODEGA", SqlDbType.Int, 300).Value = VariablesBase.VariablesBase.IdBodegaActual

        Try
            da = New SqlClient.SqlDataAdapter(cmde)
            datas2 = New DataTable()
            da.Fill(datas2)
            sqlConexion.Close()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub CargarListaEquipoBase()

        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        sqlconeccion.Open()
        cmde.Parameters.Clear()
        cmde.CommandType = CommandType.StoredProcedure
        cmde.Connection = sqlconeccion
        cmde.CommandText = "dbo.ListarActivosFijoBase"
        cmde.Parameters.Add("@IDBODEGA", SqlDbType.Int, 300).Value = VariablesBase.VariablesBase.IdBodegaActual

        da = New SqlClient.SqlDataAdapter(cmde)
        datas = New DataSet()

        da.Fill(datas)
        sqlconeccion.Close()

        Me.Dgv_Buscar.SuspendLayout()
        Me.Dgv_Buscar.DataSource = datas.Tables(0)
        Me.Dgv_Buscar.ResumeLayout()


        For i = 0 To Dgv_Buscar.ColumnCount - 1

            Select Case Dgv_Buscar.Columns(i).Name
                Case "IDEQUIPO"
                    Dgv_Buscar.Columns(i).Width = 40
                    Dgv_Buscar.Columns(i).ToolTipText = "Id"
                    Dgv_Buscar.Columns(i).HeaderText = "Id"
                Case "CODIGO"
                    Dgv_Buscar.Columns(i).Width = 150
                    Dgv_Buscar.Columns(i).ToolTipText = "Código"
                    Dgv_Buscar.Columns(i).HeaderText = "Código"
                Case "ESTADO USO'"
                    Dgv_Buscar.Columns(i).Width = 450
                    Dgv_Buscar.Columns(i).ToolTipText = "Estado Uso"
                    Dgv_Buscar.Columns(i).HeaderText = "Estado Uso"
                Case "ESTADO"
                    Dgv_Buscar.Columns(i).Width = 30
                    Dgv_Buscar.Columns(i).ToolTipText = "Estado"
                    Dgv_Buscar.Columns(i).HeaderText = "Estado"

            End Select
        Next

        EquiposBodegaCombustible()
    End Sub

    Private Sub Dgv_Buscar_CellMouseDoubleClick(sender As Object, e As Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv_Buscar.CellMouseDoubleClick
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            'Verificar que el codigo del municipio no este en la lista
            Try
                IdEquipo = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IDEQUIPO").Value
                NombreEquipo = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("CODIGO").Value
            Catch ex As Exception
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            End Try

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tb_Descripción.TextChanged
        If Cb_Filtrar.Checked = True Then
            Dim vista As New DataView(datas.Tables(0))
            Me.Dgv_Buscar.SuspendLayout()
            Me.Dgv_Buscar.DataSource = vista
            Me.Dgv_Buscar.ResumeLayout()
            Dim Columna As String = ""
            Dim Texto As String = Me.Tb_Descripción.Text
            Dim pabla() As String
            pabla = Split(Trim(Texto), "  ")
            While pabla.Count > 1
                Texto = Replace(Trim(Texto), "  ", " ")
                pabla = Split(Trim(Texto), "  ")
            End While
            pabla = Split(Trim(Texto), " ")
            Select Case Me.ComboBox_Filtrar.SelectedIndex
                Case 0
                    Columna = "CODIGO"
                Case 1
                    Columna = "CODIGO"
            End Select


            If pabla.Count > 2 Then
                vista.RowFilter = String.Format("{0} like '%{1}%' AND {0} like '%{2}%' AND {0} like '%{3}%' ", Columna, pabla(0), pabla(1), pabla(2))
            ElseIf pabla.Count = 2 Then
                vista.RowFilter = String.Format("{0} like '%{1}%' AND {0} like '%{2}%'", Columna, pabla(0), pabla(1))
            ElseIf pabla.Count = 1 Then
                vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, pabla(0))
            End If

        End If
    End Sub

    Private Sub Cb_Filtrar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Filtrar.CheckedChanged
        Me.Tb_Descripción.Text = ""
        If Me.Cb_Filtrar.Checked = False Then
            CargarListaEquipoBase()
        End If
    End Sub


    Private Sub Bt_BúsquedaAvanzada_Click(sender As Object, e As EventArgs) Handles Bt_BúsquedaAvanzada.Click
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
        campos.Rows.Add("e.IDARTICULO", "Código Articulo", "2")
        campos.Rows.Add("a.NOMBRE", "Nombre Artículo", "1")
        campos.Rows.Add("es.NOMBREESTADO", "Estado Actual", "1")
        campos.Rows.Add("euso.NOMBREESTADO", "Estado Uso Actual", "1")
        campos.Rows.Add("1", "Listar Dados de Baja", "4")
        campos.Rows.Add("2", "Serie o número serial", "7")
        campos.Rows.Add("3", "Placa de vehículo", "7")

        frbuscar.campos = campos
        frbuscar.tabla = 16
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        If DSbusqueda.Tables.Count > 0 Then
            If DSbusqueda.Tables(0).Rows.Count > 0 Then


                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
                Dgv_Buscar.DataSource = DSbusqueda.Tables(0)
                Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default

            Else
                MsgBox("Ningun Registro Encontrado")
            End If
        End If



    End Sub


    Public Sub EquiposBodegaCombustible()
        Dim sqlConexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        sqlConexion.Open()
        cmde.Parameters.Clear()
        cmde.CommandType = CommandType.StoredProcedure
        cmde.Connection = sqlConexion
        cmde.CommandText = "dbo.BuscarEquipoCombustiblexBodega"
        'cmde.Parameters.Add("@IDBODEGA", SqlDbType.Int, 300).Value = VariablesBase.VariablesBase.IdBodegaActual

        Try
            da = New SqlClient.SqlDataAdapter(cmde)
            datas2 = New DataTable()
            da.Fill(datas2)
            sqlConexion.Close()

        Catch ex As Exception

        End Try

    End Sub
    Private Function ValidarContador() As Boolean
        If Tb_HoraKilometro.Text = "" Then
            MsgBox("Debe digitar la identificación", MsgBoxStyle.Critical, "IDENTIFICACIÓN")
            Me.Tb_HoraKilometro.Focus()
            ValidarContador = False
            Exit Function
        End If

        ValidarContador = True
    End Function

    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
ByVal e As DataGridViewCellFormattingEventArgs) _
Handles Dgv_Buscar.CellFormatting
    End Sub


    Private Function validadarOdoKm() As Boolean
        Try
            Select Case Tipo
                Case "C"
                    Dim a As DataRow() = datas2.Select("IDEQUIPO = " & Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IDEQUIPO").Value & " and ID_TIPOCONTROL = 15")
                    Dim b As DataRow() = datas2.Select("IDEQUIPO = " & Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IDEQUIPO").Value & " and ID_TIPOCONTROL = 16")
                    Dim Response
                    Dim tipoEquipo As Integer
                    If a.Count > 0 Then
                        tipoEquipo = 1
                        validadarOdoKm = False
                        Lb_horakilometro.Text = "Hora / Kilometro"
                        If Trim(Tb_HoraKilometro.Text) = "" Then
                            Response = MsgBox(" Este equipo usa combustible, registrar odometro(Km) o horometro(h) ", , "Equipo con registro de contador")
                            If Response = vbOK Then    ' User chose Yes.
                                Me.Panel3.Enabled = True
                                Me.Panel3.Visible = True
                                Me.Tb_HoraKilometro.Focus()
                            End If
                        End If
                    ElseIf b.Count > 0 Then
                        tipoEquipo = 2
                        validadarOdoKm = False
                        Lb_horakilometro.Text = "Contador Paginas"
                        If Trim(Tb_HoraKilometro.Text) = "" Then
                            Response = MsgBox(" Este equipo requiere registrar el contador actual de paginas ", , "Equipo con registro de contador")
                            If Response = vbOK Then    ' User chose Yes.
                                Me.Panel3.Enabled = True
                                Me.Panel3.Visible = True
                                Me.Tb_HoraKilometro.Focus()
                            End If
                        End If
                    Else
                        Me.Panel3.Visible = False
                        validadarOdoKm = False
                        Return False
                    End If
                Case Else
                    Me.Panel3.Visible = False
                    validadarOdoKm = False

                    'Verificar que el codigo del municipio no este en la lista
                    Try
                        IdEquipo = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("IDEQUIPO").Value
                        NombreEquipo = Me.Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("CODIGO").Value
                    Catch ex As Exception

                    End Try



            End Select
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class