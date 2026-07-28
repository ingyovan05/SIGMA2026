Imports FunBase = FuncionesBase.FuncionesBase
Imports VarBase = VariablesBase.VariablesBase
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports FormulariosClasesBase
Imports System.Net
Imports System.Globalization

Public Class Cu_Informe

    Public ReactivarPrincipal As Boolean = False
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private DtInformeCargar As DataTable
    Private dtTipoConsulta As DataTable
    Private dtConsultas As DataTable
    Private dtColumnasConsulta As DataTable
    Private dtOpcionesAjusteColumnas As DataTable
    Private numeroinforme As Integer
    Private contador As Integer
    Public Sub Comportamiento_Predeterminado()

        Me.Cursor = Cursors.WaitCursor
        'Cb_AjustarColumnas.SelectedIndex = -1
        Me.Cursor = Cursors.Default
        'Dtp_FechaFinal.MaxDate = Date.Now.AddDays(1)
        Dtp_FechaInicial.Value = DateTime.Today
        'Dtp_FechaFinal.Value = DateTime.Today
    End Sub






    Public Sub Cargar_Tabla()

        Me.Cursor = Cursors.WaitCursor
        comando = New SqlCommand("SELECT * FROM ListaTipoConsulta() ORDER BY [NOMBRETIPOCONSULTA] ASC", conexion)
        adaptador = New SqlDataAdapter(comando)
        dtTipoConsulta = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtTipoConsulta)
            Cb_TipoConsulta.DataSource = dtTipoConsulta
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al intentar conectarse con la base de datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
        CargarConsultasXUsuario()
        ElegirTipoListadoCentroCosto()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button_Cargar_Click(sender As Object, e As EventArgs) Handles Button_Cargar.Click
        Ck_VerColumnasInforme.CheckState = CheckState.Unchecked
        ReportViewer1.Reset()
        Cargar_Informe()
        Lb_Titulo_Informe.Text = Trim(ComboBox_Consulta.Text)
        Ck_VerColumnasInforme.Enabled = False


    End Sub

    Private Sub Cargar_Informe()

        comando = New SqlCommand
        adaptador = New SqlDataAdapter
        DtInformeCargar = New DataTable
        Try
            Dgv_Informe.DataSource = Nothing
        Catch ex As Exception

        End Try
        Try
            DtInformeCargar.Clear()
        Catch ex As Exception

        End Try
        Try
            
            If Validar_informe() Then
                informe(numeroinforme)
            Else
                Exit Sub
            End If
            
            Me.Refresh()
            Me.Focus()

         
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show("No se pudo cargar el informe ", "ERROR DEL REPORTEADOR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub



    Private Sub ComboBox_Consulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Consulta.SelectedIndexChanged
        Dtp_FechaInicial.Value = DateTime.Today
        Dtp_FechaFinal.Value = DateTime.Today
        Tx_Proveedor.Text = ""
        Cu_CentroCosto1.IdCentroCosto = -1
        Cu_CentroCosto1.Ll_CentroCostos.Text = "XXX-XXXXXXXXXXXXXXX-XXXXX"

        ReportViewer1.Reset()
        Ck_VerColumnasInforme.Enabled = True
        Try
            numeroinforme = ComboBox_Consulta.DataSource.Select("[CONSULTA] = '" & ComboBox_Consulta.SelectedValue & "'")(0).Item("CODIGOCONSULTASQL")
            Dgv_Informe.DataSource = Nothing
            Dtp_FechaInicial.Enabled = False
            Dtp_FechaFinal.Enabled = False
            Cu_CentroCosto1.Enabled = False
            Tx_Proveedor.Enabled = False
        Catch ex As Exception

        End Try
        ComboBox_Consulta.Select()
        Buscar_Parametros()

    End Sub


    Private Sub Buscar_Parametros()
        Try
            Dgv_Informe.DataSource = Nothing
            Cu_CentroCosto1.Enabled = False
            If ComboBox_Consulta.SelectedValue.IndexOf("@IDBODEGA") <> -1 Then
                contador = contador + 1
            End If
            If ComboBox_Consulta.SelectedValue.IndexOf("@IDCENTROCOSTO") <> -1 Then
                Cu_CentroCosto1.Enabled = True
                contador = contador + 1
            End If
            If ComboBox_Consulta.SelectedValue.IndexOf("@IDBASESISCONTROL") <> -1 Then
                contador = contador + 1
            End If
            If ComboBox_Consulta.SelectedValue.IndexOf("@IDDEPENDENCIA") <> -1 Then
                contador = contador + 1
            End If
            If ComboBox_Consulta.SelectedValue.IndexOf("@FECHAI") <> -1 Then
                contador = contador + 1
                Dtp_FechaInicial.Enabled = True
                Dtp_FechaFinal.Enabled = True
             
            End If
            If ComboBox_Consulta.SelectedValue.IndexOf("@IDPROVEEDOR") <> -1 Then
                Tx_Proveedor.Enabled = True
                Lb_TextoProveedor.Text = "Nit Proveedor:"

                contador = contador + 1
            End If


            If ComboBox_Consulta.SelectedValue.IndexOf("@NROORDENSAP") <> -1 Then
                Lb_TextoProveedor.Text = "Número Orden SAP:"
                Tx_Proveedor.Enabled = True
                contador = contador + 1
            End If

            If ComboBox_Consulta.SelectedValue.IndexOf("@OMSERVICIO") <> -1 Then
                Lb_TextoProveedor.Text = "OM-SERVICIO:"
                Tx_Proveedor.Enabled = True
                contador = contador + 1
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListarColumnasConsulta()
        Dgv_Informe.DataSource = Nothing
        dtColumnasConsulta = New DataTable
        If Trim(ComboBox_Consulta.Text).Length > 0 Then
            comando = New SqlCommand("SELECT * FROM ListaColumnasInforme(@CODIGOCONSULTASQL) ORDER BY [ORDEN] ASC", conexion)
            comando.Parameters.AddWithValue("@CODIGOCONSULTASQL", ComboBox_Consulta.DataSource.Select("[CONSULTA] = '" & ComboBox_Consulta.SelectedValue & "'")(0).Item("CODIGOCONSULTASQL"))
            adaptador = New SqlDataAdapter(comando)
            Try
                conexion.Open()
                adaptador.Fill(dtColumnasConsulta)
                conexion.Close()
                If dtColumnasConsulta.Rows.Count > 0 Then
                    If dtColumnasConsulta.Columns.Contains("ORDEN") Then
                        dtColumnasConsulta.Columns.Remove("ORDEN")
                    End If
                    Dgv_Informe.DataSource = dtColumnasConsulta
                Else

                End If
            Catch ex As Exception

            Finally
                conexion.Close()
            End Try
        End If
    End Sub

    Private Sub DataGridView_Informe_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles Dgv_Informe.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        Dim bt As Brush = SystemBrushes.ControlText
        If Dgv_Informe.RowHeadersWidth < CInt(size.Width + 20) Then
            Dgv_Informe.RowHeadersWidth = CInt(size.Width + 20)
        End If
        e.Graphics.DrawString(strRowNumber, Me.Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub Bt_ExportarExcel_Click(sender As Object, e As EventArgs)
        If IsNothing(DtInformeCargar) = True Then
            Exit Sub
        End If
        If DtInformeCargar.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        FunBase.ExportarExcel(DtInformeCargar, Trim(ComboBox_Consulta.Text))
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Cb_TipoConsulta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_TipoConsulta.SelectedIndexChanged
        ReportViewer1.Reset()
        CargarConsultasXUsuario()
        ElegirTipoListadoCentroCosto()
    End Sub

    Private Sub CargarConsultasXUsuario()
        Dim rows() As DataRow
        Dim numero As Object
        comando = New SqlCommand("SELECT * FROM dbo.ListarConsultasXUsuario(@IDPERSONA, @CODIGOTIPOCONSULTA) ORDER BY [NOMBRECONSULTA] ASC", conexion)
        comando.Parameters.AddWithValue("@IDPERSONA", VarBase.IdPersona)
        comando.Parameters.AddWithValue("@CODIGOTIPOCONSULTA", Cb_TipoConsulta.SelectedValue)
        adaptador = New SqlDataAdapter(comando)
        dtConsultas = New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtConsultas)
            conexion.Close()
            If dtConsultas.Rows.Count > 0 Then
                ComboBox_Consulta.DataSource = dtConsultas
                Me.ComboBox_Consulta.ValueMember = "CONSULTA"
                Me.ComboBox_Consulta.DisplayMember = "NOMBRECONSULTA"
            Else
                ComboBox_Consulta.DataSource = Nothing
            End If
            rows = dtConsultas.Select("TAMAÑO = MAX(TAMAÑO)")
            numero = rows(0).Item("TAMAÑO")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub ElegirTipoListadoCentroCosto()
        If Cb_TipoConsulta.SelectedIndex > 0 AndAlso Not IsNothing(Cb_TipoConsulta.SelectedValue) Then
            Select Case Cb_TipoConsulta.SelectedValue
                Case 8, 10 'Materiales, Activos Fijos
                    Cu_CentroCosto1.Editando = 0 'Cargar por Bodega Actual
                Case 9 'SisControl
                    Cu_CentroCosto1.Editando = 2 'Cargar por Dependencia Actual
                Case Else
                    Cu_CentroCosto1.Editando = 2 'Cargar por Dependencia Actual
            End Select
        End If
    End Sub

    Private Sub Ck_VerColumnasInforme_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_VerColumnasInforme.CheckedChanged
        If Ck_VerColumnasInforme.CheckState = CheckState.Checked Then
            ListarColumnasConsulta()
            ReportViewer1.Visible = False
        Else
            ReportViewer1.Visible = True
            Dgv_Informe.DataSource = Nothing
        End If
    End Sub

    Private Sub Cu_Informe_Layout(sender As Object, e As LayoutEventArgs) Handles MyBase.Layout
        If Me.Size.Width < 995 Then
            ComboBox_Consulta.Size = New Size(Me.Size.Width - 125, 24)
            Ck_VerColumnasInforme.Visible = False
        Else
            ComboBox_Consulta.Size = New Size(875, 24)
            Ck_VerColumnasInforme.Visible = True
        End If
    End Sub

    Public Sub informe(Optional NumInforme As Integer = -1)
        'Dim Cultura = New System.Globalization.CultureInfo("es-Es")
        'System.Threading.Thread.CurrentThread.CurrentCulture = Cultura
        'System.Threading.Thread.CurrentThread.CurrentUICulture = Cultura
        'Cursor.Current = Cursors.WaitCursor
        Me.ReportViewer1.RefreshReport()
        Buscar_Parametros()

        If ComboBox_Consulta.Items.Count > 0 Then
            Dim NoConeccion As Integer
            If IsNothing(VarBase.NombreBaseDatos) = False Then
                If VarBase.NombreBaseDatos <> "ISMOCOLPRODUCCION" Then
                    NoConeccion = 1
                Else
                    NoConeccion = 0
                End If
            End If
            Try
                Dim informe As String = NumInforme.ToString
                Me.ReportViewer1.RefreshReport()
                ReportViewer1.ProcessingMode = ProcessingMode.Remote
                Dim serverReport As ServerReport
                serverReport = ReportViewer1.ServerReport
                'ReportViewer1.ToolStripRenderer = New ReportViewerToolbarRenderer()

                'Get a reference to the default credentials  
                Dim credentials As System.Net.ICredentials
                credentials = System.Net.CredentialCache.DefaultCredentials
                ' -----credenciales----------------
                Dim Cred As New System.Net.NetworkCredential("informesigma@ism.com", "*Ism*8572@*45")
                'Dim Cred As New System.Net.NetworkCredential("user", "user2021")

                'Get a reference to the report server credentials  
                Dim rsCredentials As ReportServerCredentials
                rsCredentials = serverReport.ReportServerCredentials

                'Set the credentials for the server report  
                rsCredentials.NetworkCredentials = Cred
                'Set the report server URL and report path  
                '-------------------------------------------------------Servidor REPORTES PRO

                Dim servidorReportes As String = VariablesBase.VariablesBase.Servidor

                serverReport.ReportServerUrl = _
                   New Uri("http://" + servidorReportes + ":6600/REPORTES")
                serverReport.ReportPath = _
                   "/InformesSIGMA/" + informe
                '-------------------------------------------------------Servidor REPORTES PRU
                'serverReport.ReportServerUrl = _
                '   New Uri("http://ismpor549/ReportServer")
                'serverReport.ReportPath = "/Proyecto de informe1/" + informe

                Dim parametros As New Generic.List(Of ReportParameter)
                Dim nombreConsulta As String = ComboBox_Consulta.DataSource.Select("[CONSULTA] = '" & ComboBox_Consulta.SelectedValue & "'")(0).Item("NOMBRECONSULTA")
                Me.ReportViewer1.ServerReport.DisplayName = nombreConsulta + "_" + DateTime.Now.ToString("yyyyMMddHH:mm")

                If contador = -1 Then

                Else


                    If ComboBox_Consulta.SelectedValue.IndexOf("@IDBODEGA") <> -1 Then
                        parametros.Add(New ReportParameter("IDBODEGA", VarBase.IdBodegaActual))
                    End If

                    If ComboBox_Consulta.SelectedValue.IndexOf("@IDDEPENDENCIA") <> -1 Then
                        parametros.Add(New ReportParameter("IDDEPENDENCIA", VarBase.IddependenciaSiscontrolActual))
                    End If

                    If ComboBox_Consulta.SelectedValue.IndexOf("@IDCENTROCOSTO") <> -1 Then

                        If Cu_CentroCosto1.IdCentroCosto < 1 Then
                            MsgBox("Debe seleccionar el centro de costos", MsgBoxStyle.Information, "SELECCIONAR Centro de costos")
                            Cu_CentroCosto1.Focus()
                            Exit Sub
                        Else
                            parametros.Add(New ReportParameter("IDCENTROCOSTO", Cu_CentroCosto1.IdCentroCosto))
                        End If

                    End If

                    If ComboBox_Consulta.SelectedValue.IndexOf("@IDBASESISCONTROL") <> -1 Then
                        parametros.Add(New ReportParameter("IDBASESISCONTROL", VarBase.IdBaseSiscontrolActual))
                    End If
                    If ComboBox_Consulta.SelectedValue.IndexOf("@FECHAI") <> -1 Then
                        parametros.Add(New ReportParameter("FECHAI", Dtp_FechaInicial.Value.ToString("yyyy-MM-dd") & "T00:00:00"))
                        parametros.Add(New ReportParameter("FECHAF", Dtp_FechaFinal.Value.ToString("yyyy-MM-dd") & "T23:59:59"))
                    End If

                    If ComboBox_Consulta.SelectedValue.IndexOf("@IDPROVEEDOR") <> -1 Then
                        parametros.Add(New ReportParameter("IDPROVEEDOR", Tx_Proveedor.Text.Trim()))

                    End If

                    If ComboBox_Consulta.SelectedValue.IndexOf("@NROORDENSAP") <> -1 Then
                        parametros.Add(New ReportParameter("NROORDENSAP", Tx_Proveedor.Text.Trim()))
                    End If


                    If ComboBox_Consulta.SelectedValue.IndexOf("@OMSERVICIO") <> -1 Then
                        parametros.Add(New ReportParameter("OMSERVICIO", Tx_Proveedor.Text.Trim()))
                    End If
                    ReportViewer1.ServerReport.SetParameters(parametros)

                End If
                'Refresh the report  
                ReportViewer1.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Error " & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            contador = -1
        End If
    End Sub

    Private Function Validar_informe() As Boolean

        If ComboBox_Consulta.SelectedIndex < 0 Then
            MsgBox("Debe seleccionar el informe", MsgBoxStyle.Information, "SELECCIONAR INFORME")
            ComboBox_Consulta.Focus()
            Validar_informe = False
            Exit Function
        End If

        If Cb_TipoConsulta.SelectedIndex < 0 Then
            MsgBox("Debe seleccionar el informe", MsgBoxStyle.Information, "SELECCIONAR INFORME")

            Cb_TipoConsulta.Focus()
            Validar_informe = False
            Exit Function
        End If

        If Not IsNumeric(numeroinforme) Then
            MsgBox("error")
            Comportamiento_Predeterminado()
            Cargar_Tabla()
            Validar_informe = False
            Exit Function
        End If
        Validar_informe = True
    End Function

    'Friend Class ReportViewerToolbarRenderer
    '    Inherits ToolStripRenderer

    '    Protected Overrides Sub InitializeItem(ByVal item As ToolStripItem)

    '        MyBase.InitializeItem(item)
    '    End Sub
    'End Class


    Private Sub Dtp_FechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaFinal.ValueChanged

        'Dim hoy As Date = Date.Now

        'Dim diaF As Date = hoy.AddDays(-180)
        'Dtp_FechaInicial.Value = diaF



    End Sub
    Private Sub ActualizarRangoFechasInicial(ByVal año As Integer, ByVal mes As Integer)

        Dim FechaInicial As Date
        Dim FechaFinal As Date

        Try

            Dtp_FechaInicial.MaxDate = "01/01/2030"
            Dtp_FechaInicial.MinDate = "01/01/2018"
            Dtp_FechaFinal.MaxDate = "01/01/2030"
            Dtp_FechaFinal.MinDate = "01/01/2018"


            FechaInicial = New Date(año, mes, 1)

            FechaFinal = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 12, FechaInicial))

            Dtp_FechaInicial.MaxDate = FechaFinal

            Dtp_FechaInicial.MinDate = Dtp_FechaInicial.Value
            Dtp_FechaFinal.MaxDate = FechaFinal


        Catch ex As Exception
            'Dtp_FechaInicial.Enabled = False
            'Dtp_FechaFinal.Enabled = False

        End Try
    End Sub

    Private Sub ActualizarRangoFechasFinal(ByVal año As Integer, ByVal mes As Integer)

        Dim FechaInicial As Date
        Dim FechaFinal As Date

        Try

            Dtp_FechaInicial.MaxDate = "01/01/2030"
            Dtp_FechaInicial.MinDate = "01/01/2018"
            Dtp_FechaFinal.MaxDate = "01/01/2030"
            Dtp_FechaFinal.MinDate = "01/01/2018"


            FechaInicial = New Date(año, mes, 1)

            FechaFinal = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 13, FechaInicial))
            'FechaInicial = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, FechaInicial))
            Dtp_FechaInicial.MaxDate = Today
            'Dtp_FechaInicial.MinDate = FechaInicial
            Dtp_FechaInicial.Value = Dtp_FechaInicial.Value

            Dtp_FechaFinal.MaxDate = FechaFinal
            Dtp_FechaFinal.MinDate = FechaInicial



            Dtp_FechaInicial.Enabled = True
            Dtp_FechaFinal.Enabled = True


        Catch ex As Exception
            'Dtp_FechaInicial.Enabled = False
            'Dtp_FechaFinal.Enabled = False

        End Try
    End Sub


    Private Sub Dtp_FechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FechaInicial.ValueChanged

        ActualizarRangoFechasInicial(Year(Dtp_FechaInicial.Value), Month(Dtp_FechaInicial.Value))
        ActualizarRangoFechasFinal(Year(Dtp_FechaInicial.Value), Month(Dtp_FechaInicial.Value))


    End Sub
End Class