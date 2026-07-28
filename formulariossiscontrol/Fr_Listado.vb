Imports System.Windows.Forms

Public Class Fr_Listado
    Public Tipo As String
    Dim Dt_Correspondencia As DataTable
    Dim FilaOrdeServicio As DataRow
    Dim ListaPORFecha As Boolean = False

    Public Sub CargarDatos()

        Dim annoInicio As Integer = 2015
        For a As Integer = annoInicio To Date.Today.Year
            Cb_Año.Items.Add(a)
        Next

        Select Case Tipo
            Case "E"
                Lb_Titulo.Text = "Listado Correspondencia Externa"
                Gb_Correspondencia.Visible = True
            Case "I"
                Lb_Titulo.Text = "Listado Correspondencia Interna"
                Gb_Correspondencia.Visible = True
            Case "G"
                Lb_Titulo.Text = "Listado Correspondencia Gerencia"
                Gb_Correspondencia.Visible = True
            Case "F"
                Lb_Titulo.Text = "Listado Fax"
                Gb_Correspondencia.Visible = True
            Case "R"
                Lb_Listado.Text = "Listado Recepción"

                'If MsgBox("¿Desea cargar lista por fechas?", MsgBoxStyle.YesNo, "Lista") = MsgBoxResult.Yes Then
                ListaPORFecha = True
                Gb_CargaRecepcion.Visible = True
                'Else
                'Gb_Correspondencia.Visible = True
                'End If

            Case "O"
                Lb_Listado.Text = "Ordenes Servicio"
                ListaPORFecha = True
                Gb_CargaRecepcion.Visible = True

        End Select
        Dtp_Hasta.MaxDate = Date.Now
        cargardependencias()

    End Sub

    Public Sub cargardependencias()
        comportamientoPredeterminado()
        Dim DsDependencias As New DataSet
        Dim Cadena_Consulta As String = ""
        Dim Hasta As String = CStr(Dtp_Hasta.Value.Day + 1) + "/" + CStr(Dtp_Hasta.Value.Month) + "/" + CStr(Dtp_Hasta.Value.Year)
        Dim IdBaseSiscontrolActual As String = CStr(VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Cadena_Consulta = "select IDDEPENDENCIA , NOMBREDEPENDENCIA  from SC_DEPENDENCIA where ACTIVO = 's' and IDBASESISCONTROL =' " + Trim(IdBaseSiscontrolActual) + "'"
        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Adaptador.Fill(DsDependencias)
        Consulta.Connection.Close()
        Me.Cb_Dependencia.DataSource = DsDependencias.Tables(0).DefaultView
        Me.Cb_Dependencia.DisplayMember = "NOMBREDEPENDENCIA"
        Me.Cb_Dependencia.ValueMember = "IDDEPENDENCIA"
        Me.Cb_Dependencia.SelectedValue = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
    End Sub

    Private Sub comportamientoPredeterminado()
        Me.Dgv_Listado.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Listado.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub

    Private Sub Btn_Cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cargar.Click


        CargarInforme()


    End Sub

    Private Sub CargarInforme()
        comportamientoPredeterminado()
        '2014-09-27 23:59:00.000


        Dim Cadena_Consulta As String = ""

        Dim hastafecha As Date

        hastafecha = Dtp_Hasta.Value
        hastafecha = DateAdd(DateInterval.Day, 1, hastafecha)

        Dim Hasta As String = CStr(hastafecha.Day.ToString) + "/" + CStr(hastafecha.Month.ToString) + "/" + CStr(hastafecha.Year.ToString)
        Select Case Tipo
            Case "E"
                If Cb_Año.Text = "" Then
                    MsgBox("Seleccione el año")
                    Exit Sub
                Else
                    Cadena_Consulta = "SELECT * FROM  dbo.InformeCorrespondencia( '" + Tipo + "' , " + Trim(Tx_Desde.Text) + " , " + Trim(Tx_Hasta.Text) + " , 1, " + CStr(VariablesBase.VariablesBase.IdBaseSiscontrolActual) + " ,  '" + Cb_Año.Text + "' ) AS InformeCorrespondencia"
                End If
            Case "I"
                If Cb_Año.Text = "" Then
                    MsgBox("Seleccione el año")
                    Exit Sub
                Else
                    Cadena_Consulta = "SELECT * FROM  dbo.InformeCorrespondencia( '" + Tipo + "' , " + Trim(Tx_Desde.Text) + " , " + Trim(Tx_Hasta.Text) + " , 1, " + CStr(VariablesBase.VariablesBase.IdBaseSiscontrolActual) + " ,  '" + Cb_Año.Text + "') AS InformeCorrespondencia"
                End If
            Case "G"
                If Cb_Año.Text = "" Then
                    MsgBox("Seleccione el año")
                    Exit Sub
                Else
                    Cadena_Consulta = "SELECT * FROM  dbo.InformeCorrespondencia( '" + Tipo + "' , " + Trim(Tx_Desde.Text) + " , " + Trim(Tx_Hasta.Text) + " , 1, " + CStr(VariablesBase.VariablesBase.IdBaseSiscontrolActual) + " ,  '" + Cb_Año.Text + "') AS InformeCorrespondencia"
                End If
            Case "F"
                If Cb_Año.Text = "" Then
                    MsgBox("Seleccione el año")
                    Exit Sub
                Else
                    Cadena_Consulta = "SELECT * FROM  dbo.InformeCorrespondencia( '" + Tipo + "' ,  " + Trim(Tx_Desde.Text) + " , " + Trim(Tx_Hasta.Text) + " , 1, " + CStr(VariablesBase.VariablesBase.IdBaseSiscontrolActual) + " ,  '" + Cb_Año.Text + "') AS InformeCorrespondencia"
                End If
            Case "R"
                If ListaPORFecha Then
                    Cadena_Consulta = "SELECT * FROM  dbo.InformeRecepcion('" + Tipo + "' , '" + Dtp_Desde.Value.ToShortDateString + "' , '" + Hasta + "' , '" + Cb_Dependencia.SelectedValue.ToString + "' , " + CStr(VariablesBase.VariablesBase.IdBaseSiscontrolActual) + ") AS InformeRecepcion"
                Else
                    Cadena_Consulta = "SELECT * FROM  dbo.InformeRecepcionConsecutivo( '" + Tipo + "' ,  " + Trim(Tx_Desde.Text) + " , " + Trim(Tx_Hasta.Text) + CStr(VariablesBase.VariablesBase.IdBaseSiscontrolActual) + " ) AS InformeRecepcionConsecutivo"
                End If
            Case "O"
                Cadena_Consulta = "SELECT * FROM  dbo.InformeOrdenServicio('" + Tipo + "' , '" + Dtp_Desde.Value.ToShortDateString + "' , '" + Hasta + "' , '" + Cb_Dependencia.SelectedValue.ToString + "' , " + CStr(VariablesBase.VariablesBase.IdBaseSiscontrolActual) + ") AS InformeOrdenServicio"

        End Select

        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Dt_Correspondencia = New DataTable
        Adaptador.FillSchema(Dt_Correspondencia, SchemaType.Source)
        Adaptador.Fill(Dt_Correspondencia)
        Consulta.Connection.Close()
        Me.Dgv_Listado.DataSource = Nothing
        Me.Dgv_Listado.DataSource = Dt_Correspondencia.Copy
        Me.Dgv_Listado.AutoGenerateColumns = True
        Me.Dgv_Listado.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Dgv_Listado.ReadOnly = True
        Lb_CantidadRegistros.Text = "Se obtuvieron " + CStr(Dgv_Listado.RowCount - 1) + " Registros"
        Lb_CantidadRegistros.Visible = True

        Select Case Tipo
            Case "E"
                VistaListaCorrespondencia()
            Case "I"
                VistaListaCorrespondencia()
            Case "G"
                VistaListaCorrespondencia()
            Case "F"
                VistaListaCorrespondencia()
            Case "R"
                VistaListaRecepcion()
            Case "O"
                VistaListaOrdenes()
        End Select
    End Sub

    Private Sub VistaListaCorrespondencia()
        For i = 0 To Dgv_Listado.ColumnCount - 1
            Dgv_Listado.Columns(i).Visible = True

            Select Case Dgv_Listado.Columns(i).Name
                Case "Consecutivo"
                    Dgv_Listado.Columns(i).Width = 30
                Case "Abreviatura"
                    Dgv_Listado.Columns(i).Width = 50
                Case "Base"
                    Dgv_Listado.Columns(i).Width = 100
                Case "Fecha"
                    Dgv_Listado.Columns(i).Width = 100
                Case "Empresa"
                    If Tipo = "I" Then
                        Dgv_Listado.Columns(i).Visible = False
                    Else
                        Dgv_Listado.Columns(i).Visible = True
                        Dgv_Listado.Columns(i).Width = 150
                    End If
                Case "Dirigido"
                    Dgv_Listado.Columns(i).Width = 150
                Case "Ciudad"
                    Dgv_Listado.Columns(i).Width = 100
                Case "Asunto"
                    Dgv_Listado.Columns(i).Width = 150
                Case "Elaborado"
                    Dgv_Listado.Columns(i).Width = 150
                Case "Firmado"
                    Dgv_Listado.Columns(i).Width = 150
                Case Else
                    Dgv_Listado.Columns(i).Visible = False
            End Select
        Next
    End Sub
    Private Sub VistaListaRecepcion()
        For i = 0 To Dgv_Listado.ColumnCount - 1
            Dgv_Listado.Columns(i).Visible = True

            Select Case Dgv_Listado.Columns(i).Name
                Case "Consecutivo"
                    Dgv_Listado.Columns(i).Width = 50
                Case "Para"
                    Dgv_Listado.Columns(i).Width = 150
                Case "De"
                    Dgv_Listado.Columns(i).Width = 150
                Case "Tipo Documento"
                    Dgv_Listado.Columns(i).Width = 150
                Case "Numero Documento"
                    Dgv_Listado.Columns(i).Width = 100
                Case "Descripción"
                    Dgv_Listado.Columns(i).Width = 200
            End Select
        Next
    End Sub

    Private Sub VistaListaOrdenes()
        For i = 0 To Dgv_Listado.ColumnCount - 1
            Dgv_Listado.Columns(i).Visible = True

            Select Case Dgv_Listado.Columns(i).Name
                Case "AÑO"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Listado.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Listado.Columns(i).HeaderText = "Año"
                Case "CONSECUTIVO"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Listado.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Listado.Columns(i).HeaderText = "Consec."
                Case "CONTRATISTA"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Listado.Columns(i).Width = 100
                    Dgv_Listado.Columns(i).HeaderText = "Contratista"
                Case "IDENTIFICACION"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Listado.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Listado.Columns(i).HeaderText = "Identificación"
                Case "CIUDAD"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Listado.Columns(i).Width = 100
                    Dgv_Listado.Columns(i).HeaderText = "Ciudad"
                Case "DIRECCION"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Listado.Columns(i).Width = 100
                    Dgv_Listado.Columns(i).HeaderText = "Dirección"
                Case "TELEFONOMOVIL"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Listado.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Listado.Columns(i).HeaderText = "Telefono"
                Case "CORREOELECTRONICO"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv_Listado.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Listado.Columns(i).HeaderText = "Correo Electrónico"
                Case "VALORESTIMADO"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Dgv_Listado.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Listado.Columns(i).HeaderText = "Vr Estimado"
                Case "VALORCIERRE"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Dgv_Listado.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Listado.Columns(i).HeaderText = "Vr Cierre"
                Case "DESCRIPCION"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Listado.Columns(i).Width = 100
                    Dgv_Listado.Columns(i).HeaderText = "descripción"
                Case "FACTURA"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Listado.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Listado.Columns(i).HeaderText = "Factura"
                Case "FECHAFACTURA"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv_Listado.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Listado.Columns(i).HeaderText = "Fecha Fact."
                Case "OBSERVACION"
                    Dgv_Listado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Listado.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Listado.Columns(i).HeaderText = "Observación"
            End Select
        Next
    End Sub

    Private Sub Btn_ExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExportarExcel.Click
        If Dgv_Listado.RowCount > 1 Then
            If Dgv_Listado.RowCount = 1 Then
                MsgBox("No hay ningun dato en la lista")
                Exit Sub
            End If
            Select Case Tipo
                Case "E"
                    FuncionesBase.FuncionesBase.GridAExcel(Dgv_Listado, "Informe de correspondencia Externa " & Date.Now)
                Case "I"
                    FuncionesBase.FuncionesBase.GridAExcel(Dgv_Listado, "Informe de correspondencia Interna " & Date.Now)
                Case "G"
                    FuncionesBase.FuncionesBase.GridAExcel(Dgv_Listado, "Informe de correspondencia Gerencia " & Date.Now)
                Case "F"
                    FuncionesBase.FuncionesBase.GridAExcel(Dgv_Listado, "Informe de Fax " & Date.Now)
                Case "R"
                    FuncionesBase.FuncionesBase.GridAExcel(Dgv_Listado, "Informe de Rcepción " & Date.Now)
                Case "O"
                    FuncionesBase.FuncionesBase.GridAExcel(Dgv_Listado, "Informe de Ordenes de servicio " & Date.Now)
            End Select
            'GuardarImpreso()
        End If
    End Sub

    Private Sub Btn_Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cerrar.Click
        Me.Close()
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        ImprimirLista()
    End Sub

    Private Sub ImprimirLista()
        If Dgv_Listado.RowCount = 1 Then
            MsgBox("No hay ningun dato en la lista")
            Exit Sub
        End If
        If MsgBox("¿Desea imprimir la lista", MsgBoxStyle.YesNo, "IMPRIMIR") = MsgBoxResult.Yes Then
            Dim climpresiones As New ImpresiónSisControl.Cl_Impresión
            Dim Array As New ArrayList
            Select Case Tipo
                Case "E"
                    Array.Add(72)
                Case "I"
                    Array.Add(72)
                Case "G"
                    Array.Add(72)
                Case "F"
                    Array.Add(72)
                Case "R"
                    Array.Add(73)
            End Select

            climpresiones.TipoCorrespondencia = Tipo
            climpresiones.CorrespondenciaDesde = Dtp_Desde.Value.ToShortDateString
            Dim hastafecha As Date

            hastafecha = Dtp_Hasta.Value
            hastafecha = DateAdd(DateInterval.Day, 1, hastafecha)

            Dim Hasta As String = CStr(hastafecha.Day.ToString) + "/" + CStr(hastafecha.Month.ToString) + "/" + CStr(hastafecha.Year.ToString)


            climpresiones.Desde = Trim(Tx_Desde.Text)
            climpresiones.Hasta = Trim(Tx_Hasta.Text)
            climpresiones.Cb_Año = Cb_Año.Text
            climpresiones.ListaFecha = ListaPORFecha
            climpresiones.CorrespondenciaHasta = CStr(hastafecha.Day.ToString) + "/" + CStr(hastafecha.Month.ToString) + "/" + CStr(hastafecha.Year.ToString)
            climpresiones.IDDEPENDENCIA = Cb_Dependencia.SelectedValue
            climpresiones.FormatoImprimirSisControl(Array, True, False)
            MsgBox("Impresión finalizada", MsgBoxStyle.Information, "FIN IMPRESION")
        End If
    End Sub

    Private Sub GuardarImpreso()
        Dim Dt_OrdenServicio As DataTable
        Dim Cadena_Consulta_Update As String = ""

        Dim IDCORRES As String = ""

        Dim Filas As Integer = Me.Dgv_Listado.RowCount - 2
        For i As Integer = 0 To Filas
            Dgv_Listado.CurrentCell = Me.Dgv_Listado(0, i)
            If i = 0 Then
                IDCORRES = CStr(Me.Dgv_Listado.Rows(Dgv_Listado.CurrentRow.Index).Cells(0).Value)
            Else
                IDCORRES = IDCORRES + "," + CStr(Me.Dgv_Listado.Rows(Dgv_Listado.CurrentRow.Index).Cells(0).Value)
            End If
        Next

        Select Case Tipo
            Case "E"
                Cadena_Consulta_Update = "UPDATE SC_CORRESPONDENCIA SET IMPRESOLISTA = 'S' where IDCORRESPONDENCIAEXTERNA in (" + IDCORRES + ")"
            Case "I"
                Cadena_Consulta_Update = "UPDATE SC_CORRESPONDENCIA SET IMPRESOLISTA = 'S' where IDCORRESPONDENCIAEXTERNA in (" + IDCORRES + ")"
            Case "G"
                Cadena_Consulta_Update = "UPDATE SC_CORRESPONDENCIA SET IMPRESOLISTA = 'S' where IDCORRESPONDENCIAEXTERNA in (" + IDCORRES + ")"
            Case "F"
                Cadena_Consulta_Update = "UPDATE SC_CORRESPONDENCIA SET IMPRESOLISTA = 'S' where IDCORRESPONDENCIAEXTERNA in (" + IDCORRES + ")"
            Case "R"
                Cadena_Consulta_Update = "UPDATE SC_RECEPCION SET IMPRESA = 'S' where IDRECEPCION in (" + IDCORRES + ")"
        End Select

        Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta_Update)
        Dim Conexión As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Consulta.Connection = Conexión
        Dim Adaptador As New SqlClient.SqlDataAdapter(Consulta)
        Consulta.Connection.Open()
        Dt_OrdenServicio = New DataTable
        Adaptador.FillSchema(Dt_OrdenServicio, SchemaType.Source)
        Adaptador.Fill(Dt_OrdenServicio)
        Consulta.Connection.Close()
    End Sub

    Private Sub Btn_CargarCorrespondencia_Click(sender As Object, e As EventArgs) Handles Btn_CargarCorrespondencia.Click
        CargarInforme()
    End Sub
End Class