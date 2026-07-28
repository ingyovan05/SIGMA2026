Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Text

Public Class Fr_BuscarArtículo

    Public _Tipo As String
    Public FechaReporteDiario As Date
    Public Familia As String
    Public CodigoArbol As String
    Public Actualizar As Boolean 'Se usa para saber cuando se actualiza el listado y saber si toca refrescar el dataset de artículos en el módulo de compras
    Public idpersonaincluir As Integer = -1
    Public IdArtículo As Integer

    Public FiltrarInactivos As Boolean = False 'Para filtrar en las nuevas requisiciones los artículos inactivos
    Private dt_tablaarticulos As New DataTable
    'Private dsbodega As New DatosBodegas.Ds_Bodega
    'Private adapbodega As New DatosBodegas.Ds_BodegaTableAdapters.BODEGATableAdapter
    Private ActualizarBD As Boolean = False
    Private dtFiltro As New DataTable


    Dim dsCargar As New DataSet
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private GoogleDrive As New FuncionesGoogle.FuncionesGoogle

    Private Sub Fr_BuscarPersona_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dgv_Buscar.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Buscar.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        If Dgv_Buscar.Columns.Contains("FOTOARTICULO") Then
            For i = 0 To Dgv_Buscar.Rows.Count - 1
                If Not IsDBNull(Dgv_Buscar.Rows(i).Cells("FOTOARTICULO").Value) Then
                    Dim LinkCell As New DataGridViewLinkCell
                    Dgv_Buscar.Rows(i).Cells("ID") = LinkCell
                End If
            Next
        End If
    End Sub


    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tb_Descripción.TextChanged
        Timer1.Stop()
        Timer1.Interval = VariablesBase.VariablesBase.TiempoRespuestaBuscador * 2
        Timer1.Start()
    End Sub


    Private Sub Cb_Filtrar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Filtrar.CheckedChanged
        Tb_Descripción.Text = ""
    End Sub


    Public Sub Cargar_Tabla(ByVal TIPO As String, Optional ByVal VARIABLE As Integer = -1, Optional ByVal IDORDENCOMPRA As Integer = 0)
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Actualizar = False
        _Tipo = TIPO
        Gb_filtro.Visible = False
        Cb_BodegaAbreviatura.Enabled = False
        Cb_Bodega.Enabled = False
        Bt_AplicarFiltroOM.Visible = False

        Select Case TIPO
            Case "T"
                If FiltrarInactivos = True Then
                    Try 'Provisional el Try mientras se actualizan todas los XML de artículos locales, para evitar soporte técnico
                        If Familia = "-1" Then
                            dt_tablaarticulos = FuncionesBase.FuncionesBase.CARGARMAESTRAARTICULOS(ActualizarBD).Select("ESTADO='A'").CopyToDataTable()
                        Else
                            dt_tablaarticulos = FuncionesBase.FuncionesBase.CARGARMAESTRAARTICULOS(ActualizarBD).Select("ESTADO='A' AND FAMILIA='" + Familia + "'").CopyToDataTable()
                        End If
                    Catch ex As Exception
                        If Familia = "-1" Then
                            dt_tablaarticulos = FuncionesBase.FuncionesBase.CARGARMAESTRAARTICULOS(ActualizarBD)
                        Else
                            dt_tablaarticulos = FuncionesBase.FuncionesBase.CARGARMAESTRAARTICULOS(ActualizarBD).Select("FAMILIA='" + Familia + "'").CopyToDataTable()
                        End If
                    End Try

                Else
                    If Familia = "-1" Then
                        dt_tablaarticulos = FuncionesBase.FuncionesBase.CARGARMAESTRAARTICULOS(ActualizarBD)
                    Else
                        dt_tablaarticulos = FuncionesBase.FuncionesBase.CARGARMAESTRAARTICULOS(ActualizarBD).Select("FAMILIA='" + Familia + "'").CopyToDataTable()
                    End If
                End If


                ActualizarBD = False
                Lb_FechaArchivo.Text = "Fecha y Hora de Sincronización del archivo local de materiales: " + VariablesBase.VariablesBase.FechaArchivoXMLMaestroLocal.ToString
            Case "OC"
                Dim adap As New DatosArticulos.Ds_ArtículosTableAdapters.ListarArticulosTableAdapter
                Dim ds As New DatosArticulos.Ds_Artículos
                adap.FillOrdenCompra(ds.ListarArticulos, IDORDENCOMPRA)
                dt_tablaarticulos = ds.ListarArticulos
            Case "INV"
                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                Dim comando As New SqlCommand("SELECT * FROM InventarioXBodegaActual(@IDBODEGA)", conexion)
                comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dt As New DataTable
                Try
                    conexion.Open()
                    adaptador.Fill(dt)
                    conexion.Close()
                    dt_tablaarticulos = dt

                    Bt_Actualizar.Text = "Exportar"
                    Lb_FechaArchivo.Visible = False
                    Text = "Inventario de artículos"
                Catch ex As Exception
                    conexion.Close()
                    MsgBox(ex.Message)
                Finally
                    conexion.Close()
                End Try
            Case "TRAZ"
                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                Dim comando As New SqlCommand("SELECT * FROM TrazabilidadArticulo(@TIPO, @IDBODEGA, @IDARTICULO)", conexion)
                comando.Parameters.AddWithValue("@TIPO", 0)
                comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                comando.Parameters.AddWithValue("@IDARTICULO", IdArtículo)
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dt As New DataTable
                Try
                    conexion.Open()
                    adaptador.Fill(dt)
                    conexion.Close()
                    dt_tablaarticulos = dt

                    Try
                        Dim totalSalida As Object = dt.Compute("SUM(SALIDA)", Nothing)
                        Dim totalEntra As Object = dt.Compute("SUM(ENTRA)", Nothing)

                        Lb_FechaArchivo.Text = "Disponibilidad del artículo : " + CStr(totalEntra - totalSalida)

                    Catch ex As Exception
                        Lb_FechaArchivo.Text = "No hay trazabilidad en el artículo"
                    End Try

                    Dim fila As DataRow
                    Try
                        fila = dt.Rows(0)
                        Tx_Descripción.Text = fila("NOMBRE")
                    Catch ex As Exception
                        Tx_Descripción.Text = ""
                    End Try

                    Bt_Actualizar.Text = "Exportar"
                    Lb_FechaArchivo.Visible = True
                    Text = "Trazabilidad Artículo"


                    Cb_BodegaAbreviatura.DataSource = Nothing
                    Cb_BodegaAbreviatura.SelectedIndex = -1
                    Gb_filtro.Visible = True

                    Gb_Búsqueda.Enabled = False
                Catch ex As Exception
                    conexion.Close()
                    MsgBox(ex.Message)
                Finally
                    conexion.Close()
                End Try
            Case "TRAZXT"
                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                Dim comando As New SqlCommand("SELECT * FROM TrazabilidadArticuloTodas(@TIPO, @IDARTICULO)", conexion)
                comando.Parameters.AddWithValue("@TIPO", 0)
                comando.Parameters.AddWithValue("@IDARTICULO", IdArtículo)
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dt As New DataTable
                Try
                    conexion.Open()
                    adaptador.Fill(dt)
                    conexion.Close()
                    dt_tablaarticulos = dt

                    Try
                        Dim totalSalida As Object = dt.Compute("SUM(SALIDA)", Nothing)
                        Dim totalEntra As Object = dt.Compute("SUM(ENTRA)", Nothing)

                        Lb_FechaArchivo.Text = "Disponibilidad del artículo : " + CStr(totalEntra - totalSalida)

                    Catch ex As Exception
                        Lb_FechaArchivo.Text = "No hay trazabilidad en el artículo"
                    End Try

                    Dim fila As DataRow
                    Try
                        fila = dt.Rows(0)
                        Tx_Descripción.Text = fila("NOMBRE")
                    Catch ex As Exception
                        Tx_Descripción.Text = ""
                    End Try

                    Bt_Actualizar.Text = "Exportar"
                    Lb_FechaArchivo.Visible = True
                    Text = "Trazabilidad Articulo"

                    dsCargar = bddatos.CargarMaestrasMateriales(10, VariablesBase.VariablesBase.IdBodegaActual, VariablesBase.VariablesBase.IdBodegaActual, 1)
                    'adapbodega.Fill(dsbodega.BODEGA)
                    'Cb_BodegaAbreviatura.DataSource = dsbodega.BODEGA
                    Cb_BodegaAbreviatura.DataSource = Me.dsCargar.Tables(0)
                    Cb_BodegaAbreviatura.DisplayMember = "ABREVIATURA"
                    Cb_BodegaAbreviatura.ValueMember = "IDBODEGA"
                    Cb_BodegaAbreviatura.SelectedIndex = -1
                    Gb_filtro.Visible = True
                    Cb_BodegaAbreviatura.Enabled = True
                    Cb_Bodega.Enabled = True
                    Gb_Búsqueda.Enabled = False
                Catch ex As Exception
                    conexion.Close()
                    MsgBox(ex.Message)
                Finally
                    conexion.Close()
                End Try
        End Select

        Dgv_Buscar.DataSource = dt_tablaarticulos
        'Ocultar campos
        For i = 0 To Dgv_Buscar.ColumnCount - 1
            Dgv_Buscar.Columns(i).Visible = True
            Select Case Dgv_Buscar.Columns(i).Name
                Case "ID", "IDARTICULO"
                    Dgv_Buscar.Columns(i).Width = 45
                    Dgv_Buscar.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                    Dgv_Buscar.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "Stock Min", "Stock Max", "CONSECUTIVO", "ORDENCOMPRA", "REQUISICION", "DESTINO", "TIPOMOVIMIENTO"
                    Dgv_Buscar.Columns(i).Width = 70
                Case "DESCRIPCION"
                    If _Tipo = "INV" Then
                        Dgv_Buscar.Columns(i).Width = Dgv_Buscar.Width - 560
                    Else
                        Dgv_Buscar.Columns(i).Width = Dgv_Buscar.Width - 270
                    End If
                Case "EXISTENCIAS", "Localización", "MOVIMIENTO", "NOMBRE", "FECHADESPACHO", "FECHARECIBIDO" 'FECHAREGISTRO
                    Dgv_Buscar.Columns(i).Width = 90
                Case "SALIDA", "ENTRA", "ABREVIATURA", "BODEGA"
                    Dgv_Buscar.Columns(i).Width = 45
                Case "UND"
                    Dgv_Buscar.Columns(i).Width = 45
                    Dgv_Buscar.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Cant Pla", "Cant SA"
                    Dgv_Buscar.Columns(i).Width = 45
                    Dgv_Buscar.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    Dgv_Buscar.Columns(i).Visible = False
            End Select
        Next

        'If Dgv_Buscar.Columns.Contains("FOTOARTICULO") Then
        '    For i = 0 To Dgv_Buscar.Rows.Count - 1
        '        If Not IsDBNull(Dgv_Buscar.Rows(i).Cells("FOTOARTICULO").Value) Then
        '            Dim LinkCell As New DataGridViewLinkCell
        '            Dgv_Buscar.Rows(i).Cells("ID") = LinkCell
        '        End If
        '    Next
        'End If

        dtFiltro.Clear()
        If Not dtFiltro.Columns.Contains("Filtro") Then
            dtFiltro.Columns.Add("Filtro")
        End If
        If Not dtFiltro.Columns.Contains("Columna") Then
            dtFiltro.Columns.Add("Columna")
        End If
        dtFiltro.Rows.Add("Descripción", "DESCRIPCION")
        dtFiltro.Rows.Add("Código Articulo(Id)", "ID")
        If TIPO = "T" Then
            dtFiltro.Rows.Add("Inactivos recién creados", "ESTADO")
        End If
        ComboBox_Filtrar.DataSource = dtFiltro
        ComboBox_Filtrar.ValueMember = "Columna"
        ComboBox_Filtrar.DisplayMember = "Filtro"
        ComboBox_Filtrar.SelectedIndex = 0


        If FiltrarxOM = True Then
            'Utilizar esta desviación del codigo para filtar articulos segun las OM registradas en reportes de tiempo,
            'se debe colocar en true desde la vinterfaz de reprote de tiempo
            Bt_AplicarFiltroOM.Visible = True
        End If


        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Cb_Filtrar.Checked = True
        Tb_Descripción.Focus()
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Verificar que el código del municipio no esté en la lista
        Try
            IdArtículo = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("ID").Value
            Familia = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("FAMILIA").Value
        Catch ex As Exception
        End Try
        DialogResult = System.Windows.Forms.DialogResult.OK
        Close()
    End Sub


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        DialogResult = System.Windows.Forms.DialogResult.Cancel
        Close()
    End Sub


    Private Sub Dgv_Buscar_DoubleClick(sender As System.Object, e As System.EventArgs) Handles Dgv_Buscar.DoubleClick
        If _Tipo <> "INV" Then
            OK_Button.PerformClick()
        End If
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor

        If Cb_Filtrar.Checked = True Then
            Dim vista As New DataView(dt_tablaarticulos)
            Dgv_Buscar.SuspendLayout()
            Dgv_Buscar.DataSource = vista
            Dgv_Buscar.ResumeLayout()
            Dim Texto As String = Tb_Descripción.Text
            Dim pabla() As String
            pabla = Split(Trim(Texto), "  ")
            While pabla.Count > 1
                Texto = Replace(Trim(Texto), "  ", " ")
                pabla = Split(Trim(Texto), "  ")
            End While
            pabla = Split(Trim(Texto), " ")
            Select Case ComboBox_Filtrar.SelectedIndex
                Case 0 'Descripción
                    Dim filtroFilas As New StringBuilder
                    For i As Integer = 0 To pabla.Count - 1
                        filtroFilas.Append(ComboBox_Filtrar.SelectedValue & " like '%" & pabla(i) & "%' ")
                        If i < pabla.Count - 1 Then
                            filtroFilas.Append("AND ")
                        End If
                    Next
                    vista.RowFilter = filtroFilas.ToString
                Case 1 'Código Artículo(Id)
                    If IsNumeric(Trim(Tb_Descripción.Text)) Then
                        vista.RowFilter = ComboBox_Filtrar.SelectedValue & "=" & Trim(Tb_Descripción.Text)
                    End If
                Case 2 'Inactivos
                    Dim filtr As String = ComboBox_Filtrar.SelectedValue & "='I'" & " AND " & "FECHAREGISTRO >= #" & DateAdd(DateInterval.Day, -7, Date.Today) & "# "
                    Dim filtroFilas As New StringBuilder
                    For i As Integer = 0 To pabla.Count - 1
                        filtroFilas.Append("DESCRIPCION" & " like '%" & pabla(i) & "%' ")
                        If i < pabla.Count - 1 Then
                            filtroFilas.Append("AND ")
                        End If
                    Next
                    vista.RowFilter = filtr & " AND " & filtroFilas.ToString
            End Select

            If Dgv_Buscar.Columns.Contains("FOTOARTICULO") Then
                For i = 0 To Dgv_Buscar.Rows.Count - 1
                    If Not IsDBNull(Dgv_Buscar.Rows(i).Cells("FOTOARTICULO").Value) Then
                        Dim LinkCell As New DataGridViewLinkCell
                        Dgv_Buscar.Rows(i).Cells("ID") = LinkCell
                    End If
                Next
            End If
        End If
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Actualizar.Click
        Select Case _Tipo
            Case "INV"
                If MsgBox("Desea exportar el inventario a excel", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    FuncionesBase.FuncionesBase.ExportarDatosExcel(Dgv_Buscar, "Inventario_" + Date.Now.Year.ToString + "_" + Date.Now.Month.ToString + "_" + Date.Now.Day.ToString + "_" + Date.Now.Hour.ToString)
                End If
            Case "TRAZ"
                If MsgBox("Desea exportar la trazabilidad a excel", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    FuncionesBase.FuncionesBase.ExportarDatosExcel(Dgv_Buscar, "Trazabilidad_" + Date.Now.Year.ToString + "_" + Date.Now.Month.ToString + "_" + Date.Now.Day.ToString + "_" + Date.Now.Hour.ToString)
                End If
            Case "TRAZXT"
                If MsgBox("Desea exportar la trazabilidad a excel", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    FuncionesBase.FuncionesBase.ExportarDatosExcel(Dgv_Buscar, "Trazabilidad_" + Date.Now.Year.ToString + "_" + Date.Now.Month.ToString + "_" + Date.Now.Day.ToString + "_" + Date.Now.Hour.ToString)
                End If
            Case "T"
                ActualizarBD = True
                Cargar_Tabla(_Tipo)
                Actualizar = True
        End Select
    End Sub


    Private Sub Dgv_Buscar_SelectionChanged(sender As Object, e As System.EventArgs) Handles Dgv_Buscar.SelectionChanged
        Select Case _Tipo
            Case "T", "INV"
                Try
                    Tx_Descripción.Text = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("DESCRIPCION").Value
                Catch ex As Exception
                    Tx_Descripción.Text = ""
                End Try
        End Select
    End Sub


    Private Sub Dgv_Buscar_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Dgv_Buscar.KeyDown
        Select Case e.KeyCode
            Case Windows.Forms.Keys.F7
                ImprimirSticker()
            Case Windows.Forms.Keys.F9
                Inventario()
            Case Windows.Forms.Keys.F10
                FijarCaracterísticas()
            Case Windows.Forms.Keys.F11
                TrazabilidadArticulo()
        End Select
    End Sub


    Private Sub Inventario()
        If MsgBox("Seguro que desea desplegar el inventario de la bodega", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
            FrBuscarArtículo._Tipo = "INV"
            FrBuscarArtículo.Familia = -1
            FrBuscarArtículo.Cargar_Tabla("INV") 'Tipo de búsqueda por familia, falta implementar
            FrBuscarArtículo.ShowDialog()
        End If
    End Sub


    Private Sub FijarCaracterísticas()
        If Dgv_Buscar.SelectedRows.Count > 0 Then
            Dim FrCaracterísticaArtículo As New Fr_CaracterísticaArtículo
            Dim filas() As DataRow
            filas = dt_tablaarticulos.Select("ID=" + Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("ID").Value.ToString)
            Dim fila As DataRow
            fila = filas(0)
            FrCaracterísticaArtículo.IDARTICULO = Trim(fila("ID"))
            FrCaracterísticaArtículo.Tx_Descripción.Text = Trim(fila("DESCRIPCION"))
            FrCaracterísticaArtículo.Lb_BodegaActual.Text = VariablesBase.VariablesBase.NombreBodegaActual
            FrCaracterísticaArtículo.Lb_UnidadMáximo.Text = Trim(fila("UND"))
            FrCaracterísticaArtículo.Lb_UnidadMínimo.Text = Trim(fila("UND"))
            FrCaracterísticaArtículo.CargarTabla()
            FrCaracterísticaArtículo.ShowDialog()
        Else
            MsgBox("Debe seleccionar el artículo en la grilla al cual desea agregar las características, puede usar la opción de búsqueda para ubicar rápidamente el artículo", MsgBoxStyle.Information, "Seleccione el artículo")
        End If
    End Sub


    Private Sub ImprimirSticker()
        If FuncionesBase.FuncionesBase.ConsultarPermiso(349) = True Then
            Dim FrImprimirSticker As New Fr_ImprimirSticker
            FrImprimirSticker.ShowDialog()
        Else
            MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
        End If
    End Sub


    Private Sub TrazabilidadArticulo()
        If Dgv_Buscar.SelectedRows.Count > 0 Then
            If MsgBox("Seguro que desea desplegar la trazabilidad del articulo", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
                FrBuscarArtículo._Tipo = "TRAZ"
                FrBuscarArtículo.Familia = -1
                FrBuscarArtículo.IdArtículo = Dgv_Buscar.Rows(Dgv_Buscar.CurrentRow.Index).Cells("ID").Value.ToString
                FrBuscarArtículo.Cargar_Tabla("TRAZ") 'Tipo de búsqueda por familia, falta implementar
                FrBuscarArtículo.ShowDialog()
            End If
        Else
            MsgBox("Debe seleccionar el artículo en la grilla del cual desea ver la trazabilidad, puede usar la opción de búsqueda para ubicar rápidamente el artículo", MsgBoxStyle.Information, "Seleccione el artículo")
        End If
    End Sub



    Private Sub Bt_filtrar_Click(sender As Object, e As EventArgs) Handles Bt_filtrar.Click
        Try
            Dim Filtro As String = "000"
            Dim filtrovista As String = ""
            Dim Vista As New DataView(dt_tablaarticulos)
            If Cb_Bodega.Checked = True Then
                filtrovista = String.Format("{0} like '%{1}%'", "[ABREVIATURA]", Trim(Cb_BodegaAbreviatura.Text))
            End If

            If Cb_fechas.Checked = True Then
                If filtrovista <> "" Then
                    filtrovista = filtrovista + "AND FECHAREGISTROFECHA >= " + "'" +
                        Convert.ToString(Format(Dtp_FechaInicial.Value, "Short Date")) + "' AND " +
                        "FECHAREGISTROFECHA <= " + "'" +
                        Convert.ToString(Format(Dtp_FechaFinal.Value, "Short Date")) + "'"
                Else
                    filtrovista = "FECHAREGISTROFECHA >= " + "'" +
                        Convert.ToString(Format(Dtp_FechaInicial.Value, "Short Date")) + "' AND " +
                        "FECHAREGISTROFECHA <= " + "'" +
                        Convert.ToString(Format(Dtp_FechaFinal.Value, "Short Date")) + "'"
                End If
            End If

            'Aplicar filtro por bodega
            Vista.RowFilter = filtrovista
            Dgv_Buscar.SuspendLayout()
            Dgv_Buscar.DataSource = Vista
            Dgv_Buscar.ResumeLayout()

            If Dgv_Buscar.Columns.Contains("FOTOARTICULO") Then
                For i = 0 To Dgv_Buscar.Rows.Count - 1
                    If Not IsDBNull(Dgv_Buscar.Rows(i).Cells("FOTOARTICULO").Value) Then
                        Dim LinkCell As New DataGridViewLinkCell
                        Dgv_Buscar.Rows(i).Cells("ID") = LinkCell
                    End If
                Next
            End If

            Try
                Dim totalSalida As Single
                Dim totalEntra As Single
                Dim Col As Integer = Dgv_Buscar.CurrentCell.ColumnIndex
                For Each row As DataGridViewRow In Dgv_Buscar.Rows
                    totalSalida += Val(row.Cells("SALIDA").Value)
                    totalEntra += Val(row.Cells("ENTRA").Value)
                Next
                Lb_FechaArchivo.Text = "Disponibilidad del artículo : " + CStr(totalEntra - totalSalida)
            Catch ex As Exception
                Lb_FechaArchivo.Text = "No hay trazabilidad en el artículo"
            End Try
        Catch ex As Exception
            MsgBox("Ocurrió un inconveniente al procesar la instrucción", MsgBoxStyle.Critical, "Inconveniente")
        End Try
    End Sub


    Private Sub Dgv_Buscar_CellContentClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles Dgv_Buscar.CellContentClick
        If e.ColumnIndex = 0 Then
            If Dgv_Buscar.Rows(e.RowIndex).Cells(e.ColumnIndex).GetType Is GetType(DataGridViewLinkCell) Then
                Dim frMostrarFoto As New FormulariosClasesBase.Fr_MostrarFoto
                Dim Foto As Boolean = GoogleDrive.DescargarFotos("art_" + Dgv_Buscar.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString, "Artículos")
                If Foto Then
                    Dim appPath As String = Application.StartupPath + "/Temp.jpg"
                    Dim filestream As New IO.FileStream(appPath, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim imagen As Image = Image.FromStream(filestream)
                    filestream.Close()
                    frMostrarFoto.Set_Pb_Foto_Image(imagen)
                End If
                frMostrarFoto.ShowDialog()
                Dim appPath2 As String
                Try
                    appPath2 = Application.StartupPath + "\Temp.jpg"
                    If My.Computer.FileSystem.FileExists(appPath2) Then
                        My.Computer.FileSystem.DeleteFile(appPath2)
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub ComboBox_Filtrar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Filtrar.SelectedIndexChanged
        If ComboBox_Filtrar.SelectedIndex = 2 Then 'Inactivos
            Try
                Dim Vista As New DataView(dt_tablaarticulos)
                Dgv_Buscar.SuspendLayout()
                Dgv_Buscar.DataSource = Vista
                Dgv_Buscar.ResumeLayout()
                Dim fechaFiltro As New DateTime
                fechaFiltro = DateAdd(DateInterval.Day, -7, Date.Today)
                Dim filtr As String = ComboBox_Filtrar.SelectedValue & "='I'" & " AND " & "FECHAREGISTRO >= #" &
                           fechaFiltro.Month.ToString & "/" & fechaFiltro.Day.ToString & "/" + fechaFiltro.Year.ToString & "# "
                Vista.RowFilter = filtr
            Catch ex As Exception

            End Try
        End If
    End Sub


    Public FiltrarxOM As Boolean = False
    Public TablaOM As New DataTable("OM")

    Private Sub Bt_AplicarFiltroOM_Click(sender As Object, e As EventArgs) Handles Bt_AplicarFiltroOM.Click


        If Me.Bt_AplicarFiltroOM.Text = "Aplicar Filtro x OM Registradas en RD" Then
            'filtrar los articulos dependiendo de las OM suministradas
            ' Dim Dt_TablaItemsMod As New DataTable
            Dim Comando As New SqlClient.SqlCommand("ListaActualizarArticulosxOM")
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.AddWithValue("@TableIDOTSERVICIO", TablaOM)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            Comando.Connection = conn
            Try
                Dim Adaptador As New SqlClient.SqlDataAdapter(Comando)
                Comando.Connection.Open()
                dt_tablaarticulos = New DataTable
                Adaptador.FillSchema(dt_tablaarticulos, SchemaType.Source)
                Adaptador.Fill(dt_tablaarticulos)
                Comando.Connection.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            'cruza datatable
            Try
                Dim Vista As New DataView(dt_tablaarticulos)
                Dgv_Buscar.SuspendLayout()
                Dgv_Buscar.DataSource = Vista
                Dgv_Buscar.ResumeLayout()

            Catch ex As Exception
            End Try
            Me.Bt_AplicarFiltroOM.Text = "Quitar Filtro x OM Registradas en RD"



            For i = 0 To Dgv_Buscar.ColumnCount - 1
                Dgv_Buscar.Columns(i).Visible = True
                Select Case Dgv_Buscar.Columns(i).Name
                    Case "ID", "IDARTICULO"
                        Dgv_Buscar.Columns(i).Width = 45
                        Dgv_Buscar.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                        Dgv_Buscar.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case "DESCRIPCION"
                        Dgv_Buscar.Columns(i).Width = Dgv_Buscar.Width - 300
                    Case "UND"
                        Dgv_Buscar.Columns(i).Width = 45
                        Dgv_Buscar.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case "Cant Pla", "Cant SA"
                        Dgv_Buscar.Columns(i).Width = 60
                        Dgv_Buscar.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case Else
                        Dgv_Buscar.Columns(i).Visible = False
                End Select
            Next

            If Dgv_Buscar.Columns.Contains("FOTOARTICULO") Then
                For i = 0 To Dgv_Buscar.Rows.Count - 1
                    If Not IsDBNull(Dgv_Buscar.Rows(i).Cells("FOTOARTICULO").Value) Then
                        Dim LinkCell As New DataGridViewLinkCell
                        Dgv_Buscar.Rows(i).Cells("ID") = LinkCell
                    End If
                Next
            End If


        Else

            Cargar_Tabla("T")
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Dim Vista As New DataView(dt_tablaarticulos)
            Dgv_Buscar.SuspendLayout()
            Dgv_Buscar.DataSource = Vista
            Dgv_Buscar.ResumeLayout()
            Me.Bt_AplicarFiltroOM.Text = "Aplicar Filtro x OM Registradas en RD"

            If Dgv_Buscar.Columns.Contains("FOTOARTICULO") Then
                For i = 0 To Dgv_Buscar.Rows.Count - 1
                    If Not IsDBNull(Dgv_Buscar.Rows(i).Cells("FOTOARTICULO").Value) Then
                        Dim LinkCell As New DataGridViewLinkCell
                        Dgv_Buscar.Rows(i).Cells("ID") = LinkCell
                    End If
                Next
            End If

            Windows.Forms.Cursor.Current = Cursors.Default
        End If



    End Sub


End Class


Friend Class Articulo

    Private _ID As Integer
    Private _CODIGOARBOL As String
    Private _NOMBRE As String
    Private _DESCRIPCION As String
    Private _UND As String
    Private _FAMILIA As String
    Private _GRUPO As String
    Private _CLASE As String
    Private _CODIGOBARRAS As String
    Private _REFERENCIA As String

    <Description("Código Árbol de artículos"), Category("Clasificación"), DisplayNameAttribute("Código Árbol")>
    Public ReadOnly Property CODIGOARBOL() As String
        Get
            Return _CODIGOARBOL
        End Get
    End Property

    <Description("Nombre del Articulo"), Category("Descripción"), DisplayNameAttribute("Nombre del Articulo")>
    Public ReadOnly Property Nombre() As String
        Get
            Return _NOMBRE
        End Get
    End Property

    <Description("Unidad de medida"), Category("Identificación"), DisplayNameAttribute("Unidad")>
    Public ReadOnly Property UND() As String
        Get
            Return _UND
        End Get
    End Property

    <Description("Familia a la que pertenece el artículo"), Category("Clasificación"), DisplayNameAttribute("Familia")>
    Public ReadOnly Property FAMILIA() As String
        Get
            Return _FAMILIA
        End Get
    End Property

    <Description("Grupo al que pertenece el artículo"), Category("Clasificación"), DisplayNameAttribute("Grupo")>
    Public ReadOnly Property GRUPO() As String
        Get
            Return _GRUPO
        End Get
    End Property

    <Description("Clase al que pertenece el artículo"), Category("Clasificación"), DisplayNameAttribute("Clase")>
    Public ReadOnly Property CLASE() As String
        Get
            Return _CLASE
        End Get
    End Property

    <Description("Código de barra del artículo"), Category("Identificación"), DisplayNameAttribute("Código de barra")>
    Public ReadOnly Property CODIGOBARRAS() As String
        Get
            Return _CODIGOBARRAS
        End Get
    End Property

    <Description("Referencia"), Category("Identificación"), DisplayNameAttribute("Referencia")>
    Public ReadOnly Property REFERENCIA() As String
        Get
            Return _REFERENCIA
        End Get
    End Property


    Public Sub New(ByVal FilaArticulo As DataGridViewRow)
        _ID = FilaArticulo.Cells("ID").Value
        _CODIGOARBOL = FilaArticulo.Cells("CODIGOARBOL").Value
        _NOMBRE = FilaArticulo.Cells("NOMBRE").Value
        _DESCRIPCION = FilaArticulo.Cells("DESCRIPCION").Value
        _UND = FilaArticulo.Cells("UND").Value
        _FAMILIA = FilaArticulo.Cells("FAMILIA").Value
        _GRUPO = FilaArticulo.Cells("GRUPO").Value
        _CLASE = FilaArticulo.Cells("CLASE").Value
        _CODIGOBARRAS = FilaArticulo.Cells("CODIGOBARRAS").Value
        _REFERENCIA = FilaArticulo.Cells("REFERENCIA").Value
    End Sub

End Class