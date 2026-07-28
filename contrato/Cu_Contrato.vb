Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.ComponentModel
Imports FormularioContrato
Imports Microsoft.Office.Interop
Imports VarBase = VariablesBase.VariablesBase
Imports FunBase = FuncionesBase.FuncionesBase

Public Class Cu_Contrato
    Private Index_Registro_Actual As Integer = -1
    Private bddatos As New DatosClasesBase.Busquedas
    Private dsContratos As New DataSet

    Property IdPersonaContratar As Integer
    Property Idcontrato As Integer

    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private dsMaestras As DataSet

    Public Sub Comportamiento_Predeterminado()
        Dgv_Contratos.ColumnHeadersDefaultCellStyle = VarBase.DataGridViewCellStyle2
        Dgv_Contratos.DefaultCellStyle = VarBase.DataGridViewCellStyle2
        Nbc_Contrato.ActiveGroup = Nbg_Contrato
        'Contrato
        Nbg_Contrato.Visible = FunBase.ConsultarPermiso(Nbg_Contrato.Tag)
        Nbi_Cargar_Contratos.Visible = FunBase.ConsultarPermiso(Nbi_Cargar_Contratos.Tag)
        Nbi_VerContrato.Visible = FunBase.ConsultarPermiso(Nbi_VerContrato.Tag)
        Nbi_Editar.Visible = FunBase.ConsultarPermiso(Nbi_Editar.Tag)
        Nbi_Terminar.Visible = FunBase.ConsultarPermiso(Nbi_Terminar.Tag)
        Nbi_Prorrogar_Contrato.Visible = FunBase.ConsultarPermiso(Nbi_Prorrogar_Contrato.Tag)
        Nbi_Buscar.Visible = FunBase.ConsultarPermiso(Nbi_Buscar.Tag)
        Nbi_Otrosi_Contrato.Visible = FunBase.ConsultarPermiso(Nbi_Otrosi_Contrato.Tag)
        Nbi_Extender.Visible = FunBase.ConsultarPermiso(Nbi_Extender.Tag)
        Nbi_Suspender.Visible = FunBase.ConsultarPermiso(Nbi_Suspender.Tag)
        Nbi_Activar.Visible = FunBase.ConsultarPermiso(Nbi_Activar.Tag)
        Nbi_Imprimir.Visible = FunBase.ConsultarPermiso(Nbi_Imprimir.Tag)
        Nbi_Reclasificar.Visible = FunBase.ConsultarPermiso(Nbi_Reclasificar.Tag)
        Nbi_RevContratosXterminar.Visible = FunBase.ConsultarPermiso(Nbi_RevContratosXterminar.Tag)
        Nbi_GestionarProrrogas.Visible = FunBase.ConsultarPermiso(Nbi_GestionarProrrogas.Tag)
        Nbi_HistorialContratos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_HistorialContratos.Tag)

        'Proyecto
        Nbg_Proyecto.Visible = FunBase.ConsultarPermiso(Nbg_Proyecto.Tag)
        Nbi_VincularBase.Visible = FunBase.ConsultarPermiso(Nbi_VincularBase.Tag)
        Nbi_DesvincularBase.Visible = FunBase.ConsultarPermiso(Nbi_DesvincularBase.Tag)
        Nbi_CambiarTurno.Visible = FunBase.ConsultarPermiso(Nbi_CambiarTurno.Tag)
        'Imprimir
        Nbg_Imprimir.Visible = FunBase.ConsultarPermiso(Nbg_Imprimir.Tag)
        Nbi_FormatosContratación.Visible = FunBase.ConsultarPermiso(Nbi_FormatosContratación.Tag)
        Nbi_ImprimirBloque.Visible = FunBase.ConsultarPermiso(Nbi_ImprimirBloque.Tag)
        Nbi_ImprimirProrrogas.Visible = FunBase.ConsultarPermiso(Nbi_ImprimirProrrogas.Tag)
        Nbi_ImprimirOtrosi.Visible = FunBase.ConsultarPermiso(Nbi_ImprimirOtrosi.Tag)
        Nbi_ImpContratoAnterior.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImpContratoAnterior.Tag)

    End Sub

    Public Sub Cargar_Tabla()
        Try
            Cursor.Current = Cursors.WaitCursor
            dsContratos = bddatos.BusquedaCondiciones(33, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 20)
            If dsContratos.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
                dsContratos.Tables.Remove(dsContratos.Tables(0).TableName) 'borrar la tabla del conteo 
            Else 'si solo trae el conteo es porque se exceden los campos
                MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsContratos.Clear()
            End If
            Dgv_Contratos.DataSource = dsContratos.Tables(0)
            AplicarFormatoColumnas()
            Lb_CantidadResultados.Text = "Cantidad de Personas: " & dsContratos.Tables(0).Rows.Count
            Try
                Dgv_Contratos.Rows(0).Selected = True
            Catch
            End Try
            Lb_CantidadResultados.Text = "Cantidad de Contratos: " & Dgv_Contratos.RowCount
            Ubicar_Registro()
            Cursor.Current = Cursors.Default
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AplicarFormatoColumnas()
        For i = 0 To Dgv_Contratos.ColumnCount - 1
            Select Case Dgv_Contratos.Columns(i).Name
                Case "Id"
                    Dgv_Contratos.Columns(i).Width = 5
                    Dgv_Contratos.Columns(i).ToolTipText = ""
                Case "Identificación"
                    Dgv_Contratos.Columns(i).DefaultCellStyle.Font = VarBase.style.Font
                    Dgv_Contratos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Contratos.Columns(i).ToolTipText = "Identificación"
                    Dgv_Contratos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "Id Persona"
                    Dgv_Contratos.Columns(i).Width = 5
                    Dgv_Contratos.Columns(i).ToolTipText = ""
                Case "Nombre"
                    Dgv_Contratos.Columns(i).Width = 250
                    Dgv_Contratos.Columns(i).ToolTipText = ""
                Case "Idbase"
                    'Dgv_Persona.Columns(i).Width = 80
                    Dgv_Contratos.Columns(i).ToolTipText = ""
                Case "Base"
                    Dgv_Contratos.Columns(i).Width = 80
                    Dgv_Contratos.Columns(i).ToolTipText = ""
                Case "Cód Contrato"
                    Dgv_Contratos.Columns(i).DefaultCellStyle.Font = VarBase.style.Font
                    Dgv_Contratos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Contratos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv_Contratos.Columns(i).ToolTipText = ""
                Case "CodTipoSalario"
                    Dgv_Contratos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Contratos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv_Contratos.Columns(i).ToolTipText = ""
                    Dgv_Contratos.Columns(i).HeaderText = "Tipo Salario"
                Case "Fecha Inicial"
                    Dgv_Contratos.Columns(i).Width = 80
                    Dgv_Contratos.Columns(i).ToolTipText = ""
                    Dgv_Contratos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Fecha Final"
                    Dgv_Contratos.Columns(i).Width = 80
                    Dgv_Contratos.Columns(i).ToolTipText = ""
                    Dgv_Contratos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Dias x Terminar"
                    Dgv_Contratos.Columns(i).Width = 80
                    Dgv_Contratos.Columns(i).ToolTipText = "Dias x Terminar"
                    Dgv_Contratos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Estado"
                    Dgv_Contratos.Columns(i).Width = 50
                    Dgv_Contratos.Columns(i).ToolTipText = ""
                    Dgv_Contratos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "Nombre Tipo Contrato"
                    Dgv_Contratos.Columns(i).Width = 180
                    Dgv_Contratos.Columns(i).ToolTipText = "Nombre Tipo Contrato"
                Case "CONSECUTIVOPRORROGAS"
                    Dgv_Contratos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Dgv_Contratos.Columns(i).Width = 50
                    Dgv_Contratos.Columns(i).ToolTipText = "Número de prorrogas"
                    Dgv_Contratos.Columns(i).HeaderText = "Nro Pro"
                Case "CARGO"
                    Dgv_Contratos.Columns(i).Width = 180
                    Dgv_Contratos.Columns(i).HeaderText = "Cargo"
                Case "Frente Trabajo"
                    Dgv_Contratos.Columns(i).Width = 180
                    Dgv_Contratos.Columns(i).ToolTipText = "F. Trabajo"
                Case Else
                    Dgv_Contratos.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Public Sub Ubicar_Registro()
        If Not IsNothing(Dgv_Contratos.DataSource) Then
            Try
                Dgv_Contratos.CurrentCell = Dgv_Contratos.Item(0, Index_Registro_Actual)
            Catch
                Dgv_Contratos.CurrentCell = Dgv_Contratos.Item(0, 0)
            End Try
        End If
    End Sub

    Private Sub Cu_Contrato_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown,
        Dgv_Contratos.KeyDown, Nbc_Contrato.KeyDown
        Select Case e.KeyCode
            Case Keys.F4
                Cargar_Tabla()
            Case Keys.F3
                BuscarContrato()
            Case Keys.F1
                FunBase.AbrirAyudaOnline("/Inicio.aspx?MODULO=Personal")
            Case Keys.F6
                ExportarDatosExcel(Dgv_Contratos)
        End Select
    End Sub

    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView)

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)

        With objHojaExcel
            .Name = ("Datos Exportados")
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 1
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, Dgv_Contratos.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    Private Sub Dgv_Contratos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Dgv_Contratos.CellFormatting
        Dim dgv As DataGridView
        dgv = sender
        If dgv.Columns(e.ColumnIndex).Name = "Estado" Then
            Dim _filaDGV As DataGridViewRow = dgv.Rows(e.RowIndex)
            If e.Value.ToString.Contains("T") Then
                _filaDGV.DefaultCellStyle.ForeColor = Color.Red
            End If
        End If
        If dgv.Columns(e.ColumnIndex).Name = "Estado" Then
            Dim _filaDGV As DataGridViewRow = dgv.Rows(e.RowIndex)
            If e.Value.ToString.Contains("N") Then
                _filaDGV.DefaultCellStyle.ForeColor = Color.Salmon
            End If
        End If

        If dgv.Columns(e.ColumnIndex).Name = "Dias x Terminar" Then
            Dim _filaDGV As DataGridViewRow = dgv.Rows(e.RowIndex)
            If e.Value.ToString.Contains(" 0") Then
                _filaDGV.DefaultCellStyle.ForeColor = Color.ForestGreen
            End If
        End If
    End Sub

    Private Sub Dgv_Contratos_DoubleClick(sender As Object, e As EventArgs) Handles Dgv_Contratos.DoubleClick
        If FunBase.ConsultarPermiso("52") Then
            EditarContrato()
        End If
    End Sub

    Private Sub Dgv_Contratos_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles Dgv_Contratos.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If Dgv_Contratos.RowHeadersWidth < CInt(size.Width + 20) Then
            Dgv_Contratos.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim bt As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub Dgv_Contratos_SelectionChanged(sender As Object, e As EventArgs) Handles Dgv_Contratos.SelectionChanged
        Try
            Dim xx As New Cl_Contrato(Dgv_Contratos.SelectedRows(0))
            Pg_Detalles.SelectedObject = xx

            Cargar_ProrrogasOtrosi()
            Cargar_ConceptosContrato()
        Catch
            Pg_Detalles.SelectedObject = Nothing
        End Try
    End Sub

    Private Sub Cargar_ProrrogasOtrosi()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListaProrrogasOtrosiContratos(@IDCONTRATO) WHERE CONSECUTIVOPRORROGA<>0", conexion)
        comando.Parameters.AddWithValue("@IDCONTRATO", Dgv_Contratos.SelectedRows(0).Cells("Id").Value)
        Dim adaptador As New SqlDataAdapter(comando)

        Dim dtProrrogasOtrosi As New DataTable

        Try
            conexion.Open()
            adaptador.Fill(dtProrrogasOtrosi)
            conexion.Close()

            If dtProrrogasOtrosi.Rows.Count > 0 Then
                Dgv_Prorrogas.DataSource = dtProrrogasOtrosi
                'Dgv_Prorrogas.AutoResizeColumns()
            Else
                If Not IsNothing(Dgv_Prorrogas.DataSource) Then
                    Dgv_Prorrogas.DataSource.Clear()
                End If
            End If
        Catch
            conexion.Close()
            If Not IsNothing(Dgv_Prorrogas.DataSource) Then
                Dgv_Prorrogas.DataSource.Clear()
            End If
        End Try

        For i = 0 To Dgv_Prorrogas.ColumnCount - 1
            Select Case Dgv_Prorrogas.Columns(i).Name
                Case DGVTBC_Tipo.Name
                    Dgv_Prorrogas.Columns(i).ToolTipText = "Tipo"
                    Dgv_Prorrogas.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Prorrogas.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case DGVTBC_ProrrogasConsecutivo.Name
                    Dgv_Prorrogas.Columns(i).ToolTipText = "Consecutivo"
                    Dgv_Prorrogas.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Prorrogas.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case DGVTBC_ProrrogasFechaInicio.Name
                    Dgv_Prorrogas.Columns(i).ToolTipText = "Fecha Inicio"
                    Dgv_Prorrogas.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_Prorrogas.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case DGVTBC_ProrrogasFechaFin.Name
                    Dgv_Prorrogas.Columns(i).ToolTipText = "Fecha Fin"
                    Dgv_Prorrogas.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Prorrogas.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case DGVTBC_ProrrogasFechaFirma.Name
                    Dgv_Prorrogas.Columns(i).ToolTipText = "Fecha Firma"
                    Dgv_Prorrogas.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Prorrogas.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case DGVTBC_ProrrogasDuracion.Name
                    Dgv_Prorrogas.Columns(i).ToolTipText = "Duración"
                    Dgv_Prorrogas.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Prorrogas.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case DGVTBC_ProrrogasTipoDuracion.Name
                    Dgv_Prorrogas.Columns(i).ToolTipText = "Tipo Duración"
                    Dgv_Prorrogas.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Prorrogas.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case DGVTBC_ProrrogasUsuarioModifica.Name
                    Dgv_Prorrogas.Columns(i).ToolTipText = "Usuario Modifica"
                    Dgv_Prorrogas.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Prorrogas.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case DGVTBC_ProrrogasFechaModifica.Name
                    Dgv_Prorrogas.Columns(i).ToolTipText = "fecha Modificación"
                    Dgv_Prorrogas.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Prorrogas.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case Else
                    Dgv_Prorrogas.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Private Sub Cargar_ConceptosContrato()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListaConceptoContrato(@IDCONTRATO)", conexion)
        comando.Parameters.AddWithValue("@IDCONTRATO", Dgv_Contratos.SelectedRows(0).Cells("Id").Value)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtConceptos As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtConceptos)
            conexion.Close()
            If dtConceptos.Rows.Count > 0 Then
                Dgv_Conceptos.DataSource = dtConceptos
                'Dgv_Prorrogas.AutoResizeColumns()
            Else
                If Not IsNothing(Dgv_Prorrogas.DataSource) Then
                    Dgv_Conceptos.DataSource.Clear()
                End If
            End If
        Catch
            conexion.Close()
            If Not IsNothing(Dgv_Conceptos.DataSource) Then
                Dgv_Conceptos.DataSource.Clear()
            End If
        End Try

        For i = 0 To Dgv_Conceptos.ColumnCount - 1
            Select Case Dgv_Conceptos.Columns(i).Name
                Case "DGVTBC_NOMBRE"
                    Dgv_Conceptos.Columns(i).ToolTipText = "Nombre Concepto"
                    Dgv_Conceptos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Conceptos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case "DGVTBC_VALOR"
                    Dgv_Conceptos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Dgv_Conceptos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Conceptos.Columns(i).DefaultCellStyle.Format = "C2"
                    Dgv_Conceptos.Columns(i).HeaderText = "Valor"
                Case "DGVTBC_PERIODICIDAD"
                    Dgv_Conceptos.Columns(i).ToolTipText = "Periodicidad"
                    Dgv_Conceptos.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_Conceptos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case Else
                    Dgv_Conceptos.Columns(i).Visible = False
            End Select
        Next

    End Sub

#Region "Contrato"
    Private Sub Nbi_Cargar_Contratos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Cargar_Contratos.ItemClick
        Cargar_Tabla()
    End Sub

    Private Sub Nbi_Editar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Editar.ItemClick
        EditarContrato()
    End Sub

    Private Sub EditarContrato()
        If Dgv_Contratos.SelectedRows.Count > 0 Then
            If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
                Select Case Dgv_Contratos.SelectedRows(0).Cells("Estado").Value
                    Case "N"
                        MessageBox.Show("Este contrato se encuentra Anulado.")
                        Exit Sub
                    Case "E"
                        MessageBox.Show("Este contrato se encuentra extendido.")
                        Exit Sub
                    Case "T"
                        MessageBox.Show("Este contrato se encuentra terminado.")
                        Exit Sub
                    Case Else
                        Index_Registro_Actual = Dgv_Contratos.CurrentCell.RowIndex
                        Dim FrContratar As New Fr_Contratar
                        FrContratar.IdPersonaContratar = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Id Persona").Value
                        FrContratar.IdContrato_Modificar = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Id").Value
                        FrContratar.TipoAccion = "E"
                        FrContratar.Cu_padre = New Object
                        FrContratar.Cu_padre = Me
                        FrContratar.Cargar_Tablas()
                        FrContratar.CargarDatosContrato()
                        FrContratar.Show()
                        If FrContratar.Guardado Then
                            Cargar_Tabla()
                            Ubicar_Registro()
                        End If
                End Select
            Else
                MessageBox.Show("Este contrato pertenece a otra base y no puede ser modificado.")
            End If
        Else
            MessageBox.Show("Seleccione un contrato para realizar la operación.", "Ningún contrato seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Nbi_VerContrato_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerContrato.ItemClick
        If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
            Index_Registro_Actual = Dgv_Contratos.CurrentCell.RowIndex
            Dim FrContratar As New Fr_Contratar
            FrContratar.IdPersonaContratar = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Id Persona").Value
            FrContratar.IdContrato_Modificar = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Id").Value
            FrContratar.TipoAccion = "V"
            FrContratar.Cargar_Tablas()
            FrContratar.CargarDatosContrato()
            FrContratar.ShowDialog()
        Else
            MessageBox.Show("Este contrato pertenece a otra base y no puede ser visualizado.")
        End If
    End Sub

    Private Sub Nbi_Terminar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Terminar.ItemClick
        If Dgv_Contratos.SelectedRows.Count > 0 Then
            If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
                Select Case Dgv_Contratos.SelectedRows(0).Cells("Estado").Value
                    Case "N"
                        MessageBox.Show("Este contrato se encuentra Anulado.")
                        Exit Sub
                    Case "T" 'Contrato no terminado
                        MessageBox.Show("Este contrato ya se encuentra terminado.")
                        Exit Sub
                    Case Else
                        Index_Registro_Actual = Dgv_Contratos.CurrentCell.RowIndex
                        Dim FrContratar As New Fr_Contratar
                        FrContratar.IdPersonaContratar = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Id Persona").Value
                        FrContratar.IdContrato_Modificar = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Id").Value
                        FrContratar.TipoAccion = "T"
                        FrContratar.Cargar_Tablas()
                        FrContratar.CargarDatosContrato()
                        FrContratar.ShowDialog()
                        If FrContratar.Guardado Then
                            Cargar_Tabla()
                            Ubicar_Registro()
                        End If
                End Select
            Else
                MessageBox.Show("Este contrato pertenece a otra base y no puede ser terminado en la base actual.")
            End If
        Else
            MessageBox.Show("Seleccione un contrato para realizar la operación.", "Ningún contrato seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Nbi_Prorrogar_Contrato_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Prorrogar_Contrato.ItemClick
        If Dgv_Contratos.SelectedRows.Count > 0 Then
            If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
                Select Case Dgv_Contratos.SelectedRows(0).Cells("Estado").Value 'Verificar que no este terminado o suspendido.
                    Case "N"
                        MessageBox.Show("Este contrato se encuentra Anulado.")
                        Exit Sub
                    Case "E"
                        MessageBox.Show("Este contrato se encuentra extendido.")
                        Exit Sub
                    Case "S"
                        MessageBox.Show("Este contrato se encuentra suspendido.")
                        Exit Sub
                    Case "T"
                        MessageBox.Show("Este contrato se encuentra terminado.")
                        Exit Sub
                    Case Else
                        Dim Identificacion As String
                        Identificacion = Dgv_Contratos.SelectedRows(0).Cells("Identificación").Value
                        Index_Registro_Actual = Dgv_Contratos.CurrentCell.RowIndex
                        'Verificar Estado de la persona
                        comando = New SqlCommand("dbo.GestionarAccesosISMOCOL", conexion) With {.CommandType = CommandType.StoredProcedure}
                        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
                        comando.Parameters.Add("@ACCESODENEGADO", SqlDbType.Char)
                        comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
                        comando.Parameters.Add("@IDENTIFICACION", SqlDbType.NVarChar, 15)
                        comando.Parameters.Add("@TIPOMODULO", SqlDbType.NChar, 1)
                        comando.Parameters.Add("@TIPOOBSERVACION", SqlDbType.Char)
                        comando.Parameters.Add("@OBSERVACION", SqlDbType.NVarChar, 300)
                        comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)

                        comando.Parameters("@Accion").Value = 1
                        comando.Parameters("@ACCESODENEGADO").Value = ""
                        comando.Parameters("@IDPERSONA").Value = -1
                        comando.Parameters("@IDENTIFICACION").Value = Replace(Identificacion, ".", "")
                        comando.Parameters("@TIPOMODULO").Value = "X"
                        comando.Parameters("@TIPOOBSERVACION").Value = ""
                        comando.Parameters("@OBSERVACION").Value = ""
                        comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona

                        comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})

                        adaptador = New SqlDataAdapter(comando)
                        dsMaestras = New DataSet
                        Try
                            conexion.Open()
                            adaptador.Fill(dsMaestras)
                            conexion.Close()

                            If comando.Parameters("@IDMENSAJE").Value = 1 Then
                                Dim fila As DataRow
                                fila = dsMaestras.Tables(0).Rows(0)

                                If fila("ACCESODENEGADO") = "S" Then
                                    MessageBox.Show("Esta persona tiene el acceso denegado.", "Estado Ismocol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Exit Sub
                                End If
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Error al carlos los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            conexion.Close()
                        End Try

                        'Verificar el tipo de contrato
                        Select Case Dgv_Contratos.SelectedRows(0).Cells("CodTipoContrato").Value
                            Case 6, 7, 8, 9, 10 'Contratos por obra o labor.
                                MessageBox.Show("Este contrato no aplica para ser prorrogado", "No aplica para prórrogas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            Case 11, 12 'Contratos de término indefinido.
                                MessageBox.Show("Este contrato no aplica para ser prorrogado", "No aplica para prórrogas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                        End Select
                        If Dgv_Contratos.SelectedRows(0).Cells("CONSECUTIVOPRORROGAS").Value < 3 Then
                            Dim DiaProrrogarContrato As New Dia_ProrrogarContrato
                            DiaProrrogarContrato.IdPersona = Dgv_Contratos.SelectedRows(0).Cells("Id Persona").Value
                            DiaProrrogarContrato.IdContrato = Dgv_Contratos.SelectedRows(0).Cells("Id").Value
                            If Not IsNothing(Dgv_Contratos.SelectedRows(0).Cells("CodTipoSalario").Value) Then
                                Select Case Dgv_Contratos.SelectedRows(0).Cells("CodTipoSalario").Value
                                    Case "D", "M"
                                        DiaProrrogarContrato.TipoDuracion = Dgv_Contratos.SelectedRows(0).Cells("CodTipoSalario").Value
                                    Case Else
                                        MessageBox.Show("Este contrato no aplica para ser prorrogado", "No aplica para prórrogas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                End Select
                            Else
                                MessageBox.Show("Este contrato no aplica para ser prorrogado", "No aplica para prórrogas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                            DiaProrrogarContrato.Duracion = Dgv_Contratos.SelectedRows(0).Cells("DURACION").Value
                            If Not IsDBNull(Dgv_Contratos.SelectedRows(0).Cells("Fecha Final").Value) Then
                                DiaProrrogarContrato.FechaInicioProrroga = Dgv_Contratos.SelectedRows(0).Cells("Fecha Final").Value
                            Else
                                MessageBox.Show("Este contrato no cuenta con fecha de finalización", "No aplica para prórrogas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                            DiaProrrogarContrato.Nombre = Dgv_Contratos.SelectedRows(0).Cells("Nombre").Value
                            DiaProrrogarContrato.CodigoContrato = Dgv_Contratos.SelectedRows(0).Cells("Cód Contrato").Value.ToString
                            DiaProrrogarContrato.ShowDialog()
                            If DiaProrrogarContrato.Guardado Then
                                Cargar_Tabla()
                                Ubicar_Registro()
                            End If
                        Else
                            MessageBox.Show("Este contrato ya cuenta con 3 prórrogas.", "No aplica para prórrogas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                End Select
            Else
                MessageBox.Show("Este contrato pertenece a otra base y no puede ser prorrogado en la base actual.")
            End If
        Else
            MessageBox.Show("Seleccione un contrato para realizar la operación.", "Ningún contrato seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub Nbi_Buscar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Buscar.ItemClick
        BuscarContrato()
    End Sub

    Private Sub BuscarContrato()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        'agregar campos
        campos.Rows.Add("7", "Nombre de la persona", "7")
        campos.Rows.Add("C.CODIGOCONTRATO", "Código del contrato", "1")
        campos.Rows.Add("P.IDENTIFICACION", "Número de identificación (sin puntos)", "2")
        campos.Rows.Add("C.IDBASECONTRATADO = " & VarBase.IdBaseSiscontrolActual & " AND C.FECHAINICIOCONTRATO", "Fecha de inicio del contrato", "3")
        campos.Rows.Add("C.IDBASECONTRATADO = " & VarBase.IdBaseSiscontrolActual & " AND TC.CODIGOTIPOCONTRATO IN (1,2,3,4,5) AND C.ESTADOCONTRATO <>'T' AND dbo.ContratoFechaFin(C.IDCONTRATO) ", "Fecha de terminación", "3")
        campos.Rows.Add("10", "Cargo a desempeñar", "7")
        campos.Rows.Add("11", "Rol en la base", "7")
        campos.Rows.Add("8", "Obra o labor contratada", "7")
        campos.Rows.Add("12", "Frente de trabajo", "7")
        campos.Rows.Add("13", "Últimos 20 Contratos", "4")
        campos.Rows.Add("3", "Contratos activos de la base", "4")
        campos.Rows.Add("2", "Contratos terminados de la base", "4")
        campos.Rows.Add("9", "Contratos extendidos de la base", "4")
        campos.Rows.Add("4", "Contratos suspendidos de la base", "4")
        campos.Rows.Add("5", "Todos los contratos de la base", "4")
        frbuscar.campos = campos
        '******************************
        frbuscar.Text = "Búsqueda de Contratos"
        frbuscar.tabla = 33
        '******************************
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsContratos = DSbusqueda
        Try
            If dsContratos.Tables.Count > 0 Then
                If dsContratos.Tables(0).Rows.Count > 0 Then
                    Dgv_Contratos.DataSource = dsContratos.Tables(0)
                    AplicarFormatoColumnas()
                    Lb_CantidadResultados.Text = "Cantidad de Contratos: " + Dgv_Contratos.RowCount.ToString
                    Dgv_Contratos.Rows(0).Selected = True
                Else
                    MessageBox.Show("Ningún Registro Encontrado")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Nbi_Otrosi_Contrato_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Otrosi_Contrato.ItemClick
        If Dgv_Contratos.SelectedRows.Count > 0 Then
            If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
                Select Case Dgv_Contratos.SelectedRows(0).Cells("Estado").Value 'Verificar que no este terminado o suspendido.
                    Case "N"
                        MessageBox.Show("Este contrato se encuentra Anulado.")
                        Exit Sub
                    Case "E"
                        MessageBox.Show("Este contrato se encuentra extendido.")
                        Exit Sub
                    Case "S"
                        MessageBox.Show("Este contrato se encuentra suspendido.")
                        Exit Sub
                    Case "T"
                        MessageBox.Show("Este contrato se encuentra terminado.")
                        Exit Sub
                    Case Else
                        Index_Registro_Actual = Dgv_Contratos.CurrentCell.RowIndex
                        'Verificar estado Persona
                        Dim Identificacion As String
                        Identificacion = Dgv_Contratos.SelectedRows(0).Cells("Identificación").Value
                        Index_Registro_Actual = Dgv_Contratos.CurrentCell.RowIndex
                        'Verificar Estado de la persona
                        comando = New SqlCommand("dbo.GestionarAccesosISMOCOL", conexion) With {.CommandType = CommandType.StoredProcedure}
                        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
                        comando.Parameters.Add("@ACCESODENEGADO", SqlDbType.Char)
                        comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
                        comando.Parameters.Add("@IDENTIFICACION", SqlDbType.NVarChar, 15)
                        comando.Parameters.Add("@TIPOMODULO", SqlDbType.NChar, 1)
                        comando.Parameters.Add("@TIPOOBSERVACION", SqlDbType.Char)
                        comando.Parameters.Add("@OBSERVACION", SqlDbType.NVarChar, 300)
                        comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)

                        comando.Parameters("@Accion").Value = 1
                        comando.Parameters("@ACCESODENEGADO").Value = ""
                        comando.Parameters("@IDPERSONA").Value = -1
                        comando.Parameters("@IDENTIFICACION").Value = Replace(Identificacion, ".", "")
                        comando.Parameters("@TIPOMODULO").Value = "O"
                        comando.Parameters("@TIPOOBSERVACION").Value = ""
                        comando.Parameters("@OBSERVACION").Value = ""
                        comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona

                        comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})

                        adaptador = New SqlDataAdapter(comando)
                        dsMaestras = New DataSet
                        Try
                            conexion.Open()
                            adaptador.Fill(dsMaestras)
                            conexion.Close()

                            If comando.Parameters("@IDMENSAJE").Value = 1 Then
                                Dim fila As DataRow
                                fila = dsMaestras.Tables(0).Rows(0)

                                If fila("ACCESODENEGADO") = "S" Then
                                    MessageBox.Show("Esta persona tiene el acceso denegado.", "Estado Ismocol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Exit Sub
                                End If
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Error al carlos los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            conexion.Close()
                        End Try

                        'Verificar el tipo de contrato
                        Select Case Dgv_Contratos.SelectedRows(0).Cells("CodTipoContrato").Value
                            Case 6, 7, 8, 9, 10 'Contratos por obra o labor.

                            Case Else
                                MessageBox.Show("Este contrato no aplica para otrosí.", "No aplica para otrosí", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                        End Select
                        Dim frOtrosi As New Fr_OtrosiContrato
                        frOtrosi.IdPersona = Dgv_Contratos.SelectedRows(0).Cells("Id Persona").Value
                        frOtrosi.IdContrato = Dgv_Contratos.SelectedRows(0).Cells("Id").Value
                        frOtrosi.Nombre = Dgv_Contratos.SelectedRows(0).Cells("Nombre").Value
                        frOtrosi.CodigoContrato = Dgv_Contratos.SelectedRows(0).Cells("Cód Contrato").Value.ToString
                        frOtrosi.ShowDialog()
                        If frOtrosi.Guardado Then
                            Cargar_Tabla()
                            Ubicar_Registro()
                        End If
                End Select
            Else
                MessageBox.Show("Este contrato pertenece a otra base y no se le puede registrar otrosí en la base actual.")
            End If
        Else
            MessageBox.Show("Seleccione un contrato para realizar la operación", "Ningún contrato seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub Nbi_Suspender_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Suspender.ItemClick
        If Dgv_Contratos.SelectedRows.Count > 0 Then
            If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
                Select Case Dgv_Contratos.SelectedRows(0).Cells("Estado").Value 'Verificar que no este terminado o suspendido.
                    Case "N"
                        MessageBox.Show("Este contrato se encuentra Anulado.")
                        Exit Sub
                    Case "E"
                        MessageBox.Show("Este contrato se encuentra extendido.")
                        Exit Sub
                    Case "T"
                        MessageBox.Show("Este contrato se encuentra terminado.")
                        Exit Sub
                    Case "S"
                        MessageBox.Show("Este contrato ya se encuentra suspendido.")
                        Exit Sub
                    Case Else
                        If MessageBox.Show("Se marcará el contrato como SUSPENDIDO." & Environment.NewLine & "¿Desea continuar?", "Suspender contrato", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                            CambiarEstadoContrato(Dgv_Contratos.SelectedRows(0).Cells("Id").Value, 1)
                            Cargar_Tabla()
                            Ubicar_Registro()
                        End If
                End Select
            Else
                MessageBox.Show("Este contrato pertenece a otra base y no puede ser suspendido en la base actual.")
            End If
        Else
            MessageBox.Show("Seleccione un contrato para realizar la operación.", "Ningún contrato seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Nbi_ExtenderPorIC_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Extender.ItemClick
        If Dgv_Contratos.SelectedRows.Count > 0 Then
            If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
                Select Case Dgv_Contratos.SelectedRows(0).Cells("Estado").Value 'Verificar que no este terminado o suspendido.
                    Case "N"
                        MessageBox.Show("Este contrato se encuentra Anulado.")
                        Exit Sub
                    Case "E"
                        MessageBox.Show("Este contrato ya se encuentra en extensión.")
                        Exit Sub
                    Case "T"
                        MessageBox.Show("Este contrato se encuentra terminado.")
                        Exit Sub
                    Case Else
                        Dim avisoExtension As String = "La extensión de un contrato aplica en condiciones muy exclusivas, debido a esto verifique que posee el soporte de parte de administración de ISMOCOL S.A. para proceder a su extensión. Extender el contrato implica que el trabajador sigue vinculado a la compañía independiente de los términos de vencimiento del contrato y prorrogas hasta que se cumplan las condiciones requeridas para su terminación." & Environment.NewLine & "¿Desea continuar?"
                        Select Case Dgv_Contratos.SelectedRows(0).Cells("CodTipoContrato").Value

                            Case 1, 2, 3, 4, 5 'Contratos a término fijo.
                                If Dgv_Contratos.SelectedRows(0).Cells("Fecha Final").Value >= Date.Today Then
                                    If MessageBox.Show("El contrato tiene fecha de finalización posterior a la fecha actual." & Environment.NewLine & "¿Desea continuar?", "Contrato vigente", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                                        Exit Sub
                                    End If
                                Else
                                    If MessageBox.Show(avisoextension, "Extender Contrato", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                                        Exit Sub
                                    End If
                                End If
                                CambiarEstadoContrato(Dgv_Contratos.SelectedRows(0).Cells("Id").Value, 2)
                                Cargar_Tabla()
                                Ubicar_Registro()
                            Case 6, 7, 8, 9, 10 'Contratos por obra o labor.
                                If MessageBox.Show(avisoExtension, "Extender Contrato", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                                    Exit Sub
                                End If
                                If MessageBox.Show("¿Desea imprimir la carta de terminación de la labor contratada?", "Imprimir Formato", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                                    Dim Consultar As New Boolean
                                    Dim Fr_FechasTerminacion As New Form
                                    Dim Lb_FechaI As New Label
                                    Dim Dtp_FechaI As New DateTimePicker
                                    Dim Bt_Aceptar As New Button
                                    Dim Bt_Cancelar As New Button

                                    With Lb_FechaI
                                        .AutoSize = True
                                        .Location = New System.Drawing.Point(22, 27)
                                        .Name = "Lb_FechaI"
                                        .Size = New System.Drawing.Size(60, 13)
                                        .Text = "Fecha Terminación:"
                                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                    End With

                                    With Dtp_FechaI
                                        .Format = System.Windows.Forms.DateTimePickerFormat.[Short]
                                        .Location = New System.Drawing.Point(175, 26)
                                        .MinDate = New Date(2019, 1, 1, 0, 0, 0, 0)
                                        .Name = "Ddp_FechaI"
                                        .Size = New System.Drawing.Size(122, 20)
                                        .TabIndex = 2
                                    End With

                                    With Bt_Aceptar
                                        .Location = New System.Drawing.Point(140, 68)
                                        .Name = "Bt_Aceptar"
                                        .Size = New System.Drawing.Size(75, 23)
                                        .TabIndex = 4
                                        .Text = "Imprimir"
                                        .UseVisualStyleBackColor = True
                                    End With

                                    With Bt_Cancelar
                                        .Location = New System.Drawing.Point(220, 68)
                                        .Name = "Bt_Cancelar"
                                        .Size = New System.Drawing.Size(75, 23)
                                        .TabIndex = 5
                                        .Text = "Cancelar"
                                        .UseVisualStyleBackColor = True
                                    End With

                                    With Fr_FechasTerminacion
                                        .AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                                        .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                                        .AcceptButton = Bt_Aceptar
                                        .FormBorderStyle = FormBorderStyle.Sizable
                                        .MaximizeBox = False
                                        .MinimizeBox = False
                                        .Size = New System.Drawing.Size(320, 140)
                                        .MaximumSize = New System.Drawing.Size(320, 140)
                                        .MinimumSize = New System.Drawing.Size(320, 140)
                                        .ShowIcon = False
                                        .ShowInTaskbar = False
                                        .StartPosition = FormStartPosition.CenterScreen
                                        .Text = "Fecha Terminación "
                                        .Controls.Add(Bt_Cancelar)
                                        .Controls.Add(Bt_Aceptar)
                                        .Controls.Add(Dtp_FechaI)
                                        .Controls.Add(Lb_FechaI)
                                    End With


                                    AddHandler Bt_Aceptar.Click, Sub()

                                                                     'If MsgBox("Seguro desea exportar el excel de la OT", MsgBoxStyle.YesNo, "Exportar Excel") = MsgBoxResult.Yes Then

                                                                     Consultar = True
                                                                     Fr_FechasTerminacion.Close()
                                                                     'End If
                                                                 End Sub

                                    AddHandler Bt_Cancelar.Click, Sub()

                                                                      If MsgBox("Seguro que desea Cancelar", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then

                                                                          Consultar = False
                                                                          Fr_FechasTerminacion.Close()
                                                                      End If
                                                                  End Sub
                                    Fr_FechasTerminacion.ShowDialog()

                                    Dim clImpresion As New ImprimirRecursoHumano.Cl_Impresión
                                    clImpresion.IdContrato = Dgv_Contratos.SelectedRows(0).Cells("Id").Value
                                    clImpresion.Idpersona = Dgv_Contratos.SelectedRows(0).Cells("Id Persona").Value
                                    clImpresion.IdBase = Dgv_Contratos.SelectedRows(0).Cells("IdBase").Value
                                    clImpresion.FechaterminaciónObraLabor = Dtp_FechaI.Value

                                    Dim formatos As New ArrayList
                                    formatos.Add(14)
                                    clImpresion.FormatosImprimir(formatos, True)
                                    If clImpresion.ImpresionFinalizada Then
                                        MessageBox.Show("Impresión finalizada.")
                                    End If
                                End If
                                CambiarEstadoContrato(Dgv_Contratos.SelectedRows(0).Cells("Id").Value, 2)
                                Cargar_Tabla()
                                Ubicar_Registro()
                            Case Else
                                MessageBox.Show("Este contrato no aplica para extensión.", "No aplica para extensión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End Select
                End Select
            Else
                MessageBox.Show("Este contrato pertenece a otra base y no se puede realizar la extensión en la base actual.")
            End If
        Else
            MessageBox.Show("Seleccione un contrato para realizar la operación", "Ningún contrato seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Nbi_Activar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Activar.ItemClick
        If Dgv_Contratos.SelectedRows.Count > 0 Then
            If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
                Select Case Dgv_Contratos.SelectedRows(0).Cells("Estado").Value 'Verificar que no este terminado o suspendido.
                    Case "N"
                        MessageBox.Show("Este contrato se encuentra Anulado.")
                        Exit Sub
                    Case "A"
                        MessageBox.Show("Este contrato ya se encuentra activo.")
                        Exit Sub
                    Case "E"
                        MessageBox.Show("Este contrato se encuentra extendido.")
                        Exit Sub
                    Case "T"
                        MessageBox.Show("Este contrato se encuentra terminado.")
                        Exit Sub
                    Case Else
                        If MessageBox.Show("Se activará el contrato " & Dgv_Contratos.SelectedRows(0).Cells("Cód Contrato").Value & "." & Environment.NewLine & "¿Desea continuar?", "Activa contrato", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                            CambiarEstadoContrato(Dgv_Contratos.SelectedRows(0).Cells("Id").Value, 3)
                            Cargar_Tabla()
                            Ubicar_Registro()
                        End If
                End Select
            Else
                MessageBox.Show("Este contrato pertenece a otra base y no puede ser activado en la base actual.")
            End If
        Else
            MessageBox.Show("Seleccione un contrato para realizar la operación.", "Ningún contrato seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    ''' <summary>Cambia el estado de un contrato activo a SUSPENDIDO o EXTENDIDO.</summary>
    ''' <param name="idContrato">Identificador del contrato al cual se le cambiará el estado.</param>
    ''' <param name="accion">Acción para el cambio de estado, 1: suspender, 2: extender.</param>
    Friend Sub CambiarEstadoContrato(idContrato As Long, accion As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.CambiarEstadoContrato", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", accion)
        comando.Parameters.AddWithValue("@IDCONTRATO", idContrato)
        comando.Parameters.AddWithValue("@IDUSUARIO", VarBase.IdPersona)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error de conexión. No se pudo realizar la operación.", "Cambiar estado del contrato", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Nbi_Reclasificar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Reclasificar.ItemClick
        If Dgv_Contratos.SelectedRows.Count > 0 Then
            If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
                Select Case Dgv_Contratos.SelectedRows(0).Cells("Estado").Value 'Verificar que no este terminado o suspendido.
                    Case "N"
                        MessageBox.Show("Este contrato se encuentra Anulado.")
                        Exit Sub
                    Case "E"
                        MessageBox.Show("Este contrato se encuentra en extensión.")
                        Exit Sub
                    Case "S"
                        MessageBox.Show("Este contrato se encuentra suspendido.")
                        Exit Sub
                    Case "T"
                        MessageBox.Show("Este contrato se encuentra terminado.")
                        Exit Sub
                    Case Else
                        Dim frReclasificar As New Fr_ReclasificarContrato
                        frReclasificar.IdContrato_Modificar = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Id").Value
                        If frReclasificar.ShowDialog = DialogResult.OK AndAlso frReclasificar.Guardado Then
                            Cargar_Tabla()
                            Ubicar_Registro()
                        End If
                End Select
            Else
                MessageBox.Show("Este contrato pertenece a otra base y no se puede realizar la extensión en la base actual.")
            End If
        Else
            MessageBox.Show("Seleccione un contrato para realizar la operación", "Ningún contrato seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Nbi_GestionarProrrogas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_GestionarProrrogas.ItemClick
        If Dgv_Contratos.SelectedRows.Count > 0 Then
            If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
                Index_Registro_Actual = Dgv_Contratos.CurrentCell.RowIndex
                'Verificar estado persona
                Dim Identificacion As String
                Identificacion = Dgv_Contratos.SelectedRows(0).Cells("Identificación").Value
                Index_Registro_Actual = Dgv_Contratos.CurrentCell.RowIndex
                'Verificar Estado de la persona
                comando = New SqlCommand("dbo.GestionarAccesosISMOCOL", conexion) With {.CommandType = CommandType.StoredProcedure}
                comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
                comando.Parameters.Add("@ACCESODENEGADO", SqlDbType.Char)
                comando.Parameters.Add("@IDPERSONA", SqlDbType.Int)
                comando.Parameters.Add("@IDENTIFICACION", SqlDbType.NVarChar, 15)
                comando.Parameters.Add("@TIPOMODULO", SqlDbType.NChar, 1)
                comando.Parameters.Add("@TIPOOBSERVACION", SqlDbType.Char)
                comando.Parameters.Add("@OBSERVACION", SqlDbType.NVarChar, 300)
                comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)

                comando.Parameters("@Accion").Value = 1
                comando.Parameters("@ACCESODENEGADO").Value = ""
                comando.Parameters("@IDPERSONA").Value = -1
                comando.Parameters("@IDENTIFICACION").Value = Replace(Identificacion, ".", "")
                comando.Parameters("@TIPOMODULO").Value = "X"
                comando.Parameters("@TIPOOBSERVACION").Value = ""
                comando.Parameters("@OBSERVACION").Value = ""
                comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona

                comando.Parameters.Add(New SqlParameter("@IDMENSAJE", SqlDbType.Int) With {.Direction = ParameterDirection.Output})

                adaptador = New SqlDataAdapter(comando)
                dsMaestras = New DataSet
                Try
                    conexion.Open()
                    adaptador.Fill(dsMaestras)
                    conexion.Close()

                    If comando.Parameters("@IDMENSAJE").Value = 1 Then
                        Dim fila As DataRow
                        fila = dsMaestras.Tables(0).Rows(0)

                        If fila("ACCESODENEGADO") = "S" Then
                            MessageBox.Show("Esta persona tiene el acceso denegado.", "Estado Ismocol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al carlos los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    conexion.Close()
                End Try

                'Verificar el tipo de contrato
                Select Case Dgv_Contratos.SelectedRows(0).Cells("CodTipoContrato").Value
                    Case 6, 7, 8, 9, 10 'Contratos por obra o labor.
                        MessageBox.Show("Este contrato no aplica para ser prorrogado", "No aplica para prórrogas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Case 11, 12 'Contratos de término indefinido.
                        MessageBox.Show("Este contrato no aplica para ser prorrogado", "No aplica para prórrogas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                End Select
                Dim frGestionarProrrogas As New Fr_GestionarProrrogas
                If Dgv_Contratos.SelectedRows(0).Cells("Estado").Value = "A" Then 'Activo
                    frGestionarProrrogas.Editar = True
                Else 'Extendido, Suspendido, Terminado
                    frGestionarProrrogas.Editar = False
                End If
                frGestionarProrrogas.IdPersona = Dgv_Contratos.SelectedRows(0).Cells("Id Persona").Value
                frGestionarProrrogas.IdContrato = Dgv_Contratos.SelectedRows(0).Cells("Id").Value
                frGestionarProrrogas.Nombre = Dgv_Contratos.SelectedRows(0).Cells("Nombre").Value
                frGestionarProrrogas.CodigoContrato = Dgv_Contratos.SelectedRows(0).Cells("Cód Contrato").Value.ToString
                frGestionarProrrogas.ShowDialog()
                If frGestionarProrrogas.Guardado Then
                    Cargar_Tabla()
                    Ubicar_Registro()
                End If
            Else
                MessageBox.Show("Este contrato pertenece a otra base y no puede ser modificado en la base actual.")
            End If
        Else
            MessageBox.Show("Seleccione un contrato para realizar la operación.", "Ningún contrato seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub

#End Region 'Contrato

#Region "Proyecto"
    Private Sub Nbi_VincularBase_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VincularBase.ItemClick

    End Sub

    Private Sub Nbi_DesvincularBase_ItemClick(sender As Object, e As EventArgs) Handles Nbi_DesvincularBase.ItemClick

    End Sub

    Private Sub Nbi_CambiarTurno_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CambiarTurno.ItemClick

    End Sub
#End Region 'Proyecto

#Region "Imprimir"
    Private Sub Nbi_FormatosContratación_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nbi_FormatosContratación.ItemClick
        If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
            Try
                Dim FrImprimirFormatos As New ImprimirRecursoHumano.Fr_ImprimirFormatos
                FrImprimirFormatos.IDPERSONA = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Id Persona").Value
                FrImprimirFormatos.IDCONTRATO = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Id").Value
                FrImprimirFormatos.IDBASE = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("IdBase").Value
                FrImprimirFormatos.CODIGOTIPO = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("CodTipoContrato").Value
                FrImprimirFormatos.cargarformatos()
                'Quitar Formatos segun tipo de contrato
                Dim TipoContrato As String = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("CodTipoSalario").Value
                If TipoContrato = "M" Then 'Rol mensual
                    'FrImprimirFormatos.ActivarDocumento()
                    'FrImprimirFormatos.DesactivarDocumento()
                ElseIf TipoContrato = "D" Then 'Rol diario
                    'FrImprimirFormatos.ActivarDocumento()
                    'FrImprimirFormatos.DesactivarDocumento()
                End If
                FrImprimirFormatos.Label1.Visible = False
                FrImprimirFormatos.ComboBox_Cargo_Desempeña.Visible = False
                FrImprimirFormatos.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Imprimir Formatos Contratación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Este contrato pertenece a otra base y no puede imprimir los formatos.")
        End If
    End Sub

    Private Sub Nbi_ImprimirBloque_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirBloque.ItemClick

    End Sub

    Private Sub Nbi_ImprimirProrrogas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirProrrogas.ItemClick
        If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
            ImprimirProrrogas()
        Else
            MessageBox.Show("Este contrato pertenece a otra base y no puede imprimir las prorrogas")
        End If
    End Sub

    Private Sub Nbi_ImprimirOtrosi_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirOtrosi.ItemClick
        If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
            ImprimirOtrosi()
        Else
            MessageBox.Show("Este contrato pertenece a otra base y no puede imprimir las prorrogas")
        End If
    End Sub

    Private Sub ImprimirProrrogas()
        ImprimirProrrogasOtroSi(1)
    End Sub

    Private Sub ImprimirOtrosi()
        ImprimirProrrogasOtroSi(2)
    End Sub

    Private Sub ImprimirProrrogasOtroSi(accion As Integer)
        Dim clImpresion As New ImprimirRecursoHumano.Cl_Impresión
        clImpresion.IdContrato = Dgv_Contratos.SelectedRows(0).Cells("Id").Value
        clImpresion.Idpersona = Dgv_Contratos.SelectedRows(0).Cells("Id Persona").Value
        clImpresion.IdBase = Dgv_Contratos.SelectedRows(0).Cells("IdBase").Value
        Dim formatos As New ArrayList
        Select Case accion
            Case 1 'prórrogas
                If MessageBox.Show("¿Desea imprimir las prórrogas y la carta de terminación del contrato?", "PRÓRROGAS REGISTRADAS", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
                    formatos.Add(71)
                End If
                'formatos.Add(52)
            Case 2 'otrosí
                formatos.Add(55)
            Case Else
                Exit Sub
        End Select
        clImpresion.FormatosImprimir(formatos, True)
        If clImpresion.ImpresionFinalizada Then
            MessageBox.Show("Impresión finalizada.")
        End If
    End Sub

#End Region 'Imprimir

    Private Sub Cms_OpcionesProrrogas_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Cms_OpcionesProrrogas.Opening
        If Dgv_Prorrogas.SelectedRows.Count > 0 Then
            Select Case Dgv_Contratos.SelectedRows(0).Cells("CodTipoContrato").Value
                Case 1, 2, 3, 4, 5 'Contratos de término fijo.
                    Tsmi_ImprimirProrrogas.Visible = FunBase.ConsultarPermiso(Tsmi_ImprimirProrrogas.Tag)
                    Tsmi_ImprimirOtrosi.Visible = False
                Case 6, 7, 8, 9, 10 'Contratos por obra o labor.
                    Tsmi_ImprimirOtrosi.Visible = FunBase.ConsultarPermiso(Tsmi_ImprimirOtrosi.Tag)
                    Tsmi_ImprimirProrrogas.Visible = False
                Case Else
                    e.Cancel = True
            End Select
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub Tsmi_ImprimirProrrogas_Click(sender As Object, e As EventArgs) Handles Tsmi_ImprimirProrrogas.Click
        If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
            ImprimirProrrogas()
        Else
            MessageBox.Show("Este contrato pertenece a otra base y no puede imprimir las prorrogas")
        End If

    End Sub

    Private Sub Tsmi_ImprimirOtrosi_Click(sender As Object, e As EventArgs) Handles Tsmi_ImprimirOtrosi.Click
        If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
            ImprimirOtrosi()
        Else
            MessageBox.Show("Este contrato pertenece a otra base y no puede imprimir los Otros si.")
        End If
    End Sub

    Private Sub Cu_Contrato_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Sc_Contratos.SplitterDistance = Me.Width * 0.75
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Sc_Contratos_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Sc_Contratos.SplitterMoved
        'Pendiente poder guardar los tamños de los componentes
        'Se debe guardar los valores pero en proporciones no en valores fijos
        '        FunBase.ValoresxDefecto("G", "ICO", "Sc_Contratos", Me.Sc_Contratos.SplitterDistance)
    End Sub

    Private Sub Nbi_Imprimir_ItemClick_1(sender As Object, e As EventArgs) Handles Nbi_Imprimir.ItemClick
        If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
            Dim climpresion As New ImprimirRecursoHumano.Cl_Impresión
            Dim Array As New ArrayList
            climpresion.IdContrato = Dgv_Contratos.SelectedRows(0).Cells("Id").Value
            climpresion.Idpersona = Dgv_Contratos.SelectedRows(0).Cells("Id Persona").Value
            climpresion.IdBase = Dgv_Contratos.SelectedRows(0).Cells("IdBase").Value
            If MessageBox.Show("¿Desea imprimir el Formato F14?", "IMPRIMIR FORMATO F14", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
                Array.Add(70)
                climpresion.inicialF14 = ""
                climpresion.modificaciónF14 = "X"
            End If
            If Array.Count > 0 Then
                climpresion.FormatosImprimir(Array, True)
            End If
        Else
            MessageBox.Show("Este contrato pertenece a otra base y no puede imprimir el documento.")
        End If
    End Sub

    Private Sub Nbi_RevContratosXterminar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_RevContratosXterminar.ItemClick
        Try
            Cursor.Current = Cursors.WaitCursor
            dsContratos = bddatos.BusquedaCondiciones(33, 1, 4, 1, "", 0, Date.Now, Date.Now, 6, 50)
            If dsContratos.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
                dsContratos.Tables.Remove(dsContratos.Tables(0).TableName) 'borrar la tabla del conteo 
            Else 'si solo trae el conteo es porque se exceden los campos
                MessageBox.Show("Error al cargar los registros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dsContratos.Clear()
            End If
            Dgv_Contratos.DataSource = dsContratos.Tables(0)
            AplicarFormatoColumnas()
            Lb_CantidadResultados.Text = "Cantidad de Personas: " & dsContratos.Tables(0).Rows.Count
            Try
                Dgv_Contratos.Rows(0).Selected = True
            Catch
            End Try
            Lb_CantidadResultados.Text = "Cantidad de Contratos: " & Dgv_Contratos.RowCount
            Ubicar_Registro()
            Cursor.Current = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Nbi_ImpContratoAnterior_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImpContratoAnterior.ItemClick
        If Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Idbase").Value = VarBase.IdBaseSiscontrolActual Then
            Dim climpresion As New ImprimirRecursoHumano.Cl_Impresión
            Dim Array As New ArrayList
            climpresion.IdContrato = Dgv_Contratos.SelectedRows(0).Cells("Id").Value
            climpresion.Idpersona = Dgv_Contratos.SelectedRows(0).Cells("Id Persona").Value
            climpresion.IdBase = Dgv_Contratos.SelectedRows(0).Cells("IdBase").Value
            Dim fechaCorte As Date = Dgv_Contratos.SelectedRows(0).Cells("Fecha Inicial").Value


            Select Case Dgv_Contratos.SelectedRows(0).Cells("CodTipoContrato").Value
                Case 1, 2, 3, 4, 5

                    If fechaCorte < "20/03/2021" Then
                        If MessageBox.Show("¿Desea imprimir la revisión anterior del contrato ?", "IMPRIMIR CONTRATO", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
                            'Verificar el tipo de contrato
                            Select Case Dgv_Contratos.SelectedRows(0).Cells("CodTipoContrato").Value
                                Case 1
                                    Array.Add(89)
                                Case 2
                                    Array.Add(90)
                                Case 3
                                    Array.Add(91)
                                Case 4
                                    Array.Add(92)
                                Case 5
                                    Array.Add(93)
                                Case Else
                                    MessageBox.Show("Este contrato no es de Tipo Termino Fijo ")
                            End Select
                        End If
                        If Array.Count > 0 Then
                            climpresion.FormatosImprimir(Array, True)
                        End If
                    Else
                        MessageBox.Show("Este contrato pertenece a la ultima revisión")
                    End If

                Case Else
                    MessageBox.Show("Este contrato no es de Tipo Termino Fijo ")
            End Select

        Else
            MessageBox.Show("Este contrato pertenece a otra base y no puede imprimir el documento.")
        End If
    End Sub

    Private Sub Nbi_HistorialContratos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_HistorialContratos.ItemClick

        Try
            Dim FrHistorialContrato As New Fr_HistorialCambios
            FrHistorialContrato.IDPERSONA = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Id Persona").Value
            FrHistorialContrato.IDCONTRATO = Dgv_Contratos.Rows(Dgv_Contratos.CurrentRow.Index).Cells("Id").Value
            FrHistorialContrato.cargarDatosContrato()
            FrHistorialContrato.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class 'Cu_Contrato


Friend Class Cl_Contrato
    Private _id As String
    Private _identificación As String
    Private _nombre As String
    Private _base As String
    Private _codigoContrato As String
    Private _fechaInicial As String
    Private _terminacionInicial As String
    Private _fechaFinal As String
    Private _diasterminar As String
    Private _estado As String
    Private _tipoContrato As String
    Private _tipoSalario As String
    Private _usuarioRegistra As String
    Private _fechaRegistro As String
    Private _usuarioModifica As String
    Private _fechaModificacion As String
    Private _consecutivoProrrogas As String
    Private _duracion As String
    Private _Cargo As String
    Private _Celular As String
    Private _lugarContratacíon As String

    <Description("Identificador interno del contrato"), _
    Category("Contrato"),
    DisplayNameAttribute("Id Contrato")> _
    Public ReadOnly Property Id() As String
        Get
            Return _id
        End Get
    End Property

    <Description("Número de identificación"), _
    Category("Persona"),
    DisplayNameAttribute("Identificación")> _
    Public ReadOnly Property Identificacion() As String
        Get
            Return _identificación
        End Get
    End Property

    <Description("Nombre completo"), _
    Category("Persona"),
    DisplayNameAttribute("Nombre")> _
    Public ReadOnly Property Nombre() As String
        Get
            Return _nombre
        End Get
    End Property

    <Description("Base de contratación"), _
    Category("Contrato"),
    DisplayNameAttribute("Base")> _
    Public ReadOnly Property Base() As String
        Get
            Return _base
        End Get
    End Property

    <Description("Código del contrato"), _
    Category("Contrato"),
    DisplayNameAttribute("Código Contrato")> _
    Public ReadOnly Property CodigoContrato() As String
        Get
            Return _codigoContrato
        End Get
    End Property

    <Description("Fecha de inicio del contrato"), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Inicial")> _
    Public ReadOnly Property FechaInicial() As String
        Get
            Return _fechaInicial
        End Get
    End Property

    <Description("Fecha de terminación del contrato inicial"), _
    Category("Fechas"),
    DisplayNameAttribute("Terminación Inicial")> _
    Public ReadOnly Property TerminacionInicial() As String
        Get
            Return _terminacionInicial
        End Get
    End Property

    <Description("Fecha de terminación del contrato inicial."), _
    Category("Fechas"),
    DisplayNameAttribute("Fecha Final")> _
    Public ReadOnly Property FechaFinal() As String
        Get
            Return _fechaFinal
        End Get
    End Property

    <Description("Dias para la terminación de contrato"), _
    Category("Fechas"),
    DisplayNameAttribute("Días X Terminar")> _
    Public ReadOnly Property DiasTerminar() As String
        Get
            Return _diasterminar
        End Get
    End Property

    <Description("Estado del contrato"), _
    Category("Contrato"),
    DisplayNameAttribute("Estado")> _
    Public ReadOnly Property Estado() As String
        Get
            Return _estado
        End Get
    End Property

    <Description("Tipo de contrato"), _
    Category("Contrato"),
    DisplayNameAttribute("Tipo Contrato")> _
    Public ReadOnly Property TipoContrato() As String
        Get
            Return _tipoContrato
        End Get
    End Property

    <Description("Tipo de salario"), _
    Category("Contrato"),
    DisplayNameAttribute("Tipo Salario")> _
    Public ReadOnly Property TipoSalario() As String
        Get
            Return _tipoSalario
        End Get
    End Property

    <Description("Usuario que realizó el registro"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Registra")> _
    Public ReadOnly Property UsuarioRegistra() As String
        Get
            Return _usuarioRegistra
        End Get
    End Property

    <Description("Fecha de registro"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Registro")> _
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _fechaRegistro
        End Get
    End Property

    <Description("Usuario que modificó el registro"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Modifica")> _
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _usuarioModifica
        End Get
    End Property

    <Description("Fecha de modificación"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Modificación")> _
    Public ReadOnly Property FechaModificacion() As String
        Get
            Return _fechaModificacion
        End Get
    End Property

    <Description("Número de prórrogas realizadas al contrato"), _
    Category("Prórrogas"),
    DisplayNameAttribute("Cantidad Prórrogas")> _
    Public ReadOnly Property ConsecutivoProrrogas() As String
        Get
            Return _consecutivoProrrogas
        End Get
    End Property

    <Description("Duración del contrato"), _
    Category("Contrato"),
    DisplayNameAttribute("Duración")> _
    Public ReadOnly Property Duracion() As String
        Get
            Return _duracion
        End Get
    End Property

    <Description("Cargo"), _
    Category("Contrato"),
    DisplayNameAttribute("Cargo")> _
    Public ReadOnly Property Cargo() As String
        Get
            Return _Cargo
        End Get
    End Property

    <Description("Celular"), _
    Category("Persona"),
    DisplayNameAttribute("Celular")> _
    Public ReadOnly Property Celular() As String
        Get
            Return _Celular
        End Get
    End Property

    <Description("Lugar donde fue contratada la persona"), _
    Category("Contrato"),
    DisplayNameAttribute("Lugar de Contratación")> _
    Public ReadOnly Property LugarContratacion() As String
        Get
            Return _lugarContratacíon
        End Get
    End Property



    Public Sub New(fila As DataGridViewRow)
        Try
            _id = fila.Cells("Id").Value
        Catch
            _id = ""
        End Try
        Try
            _identificación = fila.Cells("Identificación").Value
        Catch
            _identificación = ""
        End Try
        Try
            _nombre = fila.Cells("Nombre").Value
        Catch
            _nombre = ""
        End Try
        Try
            _base = fila.Cells("Base").Value
        Catch
            _base = ""
        End Try
        Try
            _codigoContrato = fila.Cells("Cód Contrato").Value
        Catch
            _codigoContrato = ""
        End Try
        Try
            _fechaInicial = fila.Cells("Fecha Inicial").Value
        Catch
            _fechaInicial = ""
        End Try
        Try
            _terminacionInicial = fila.Cells("Terminación Inicial").Value
        Catch
            _terminacionInicial = ""
        End Try
        Try
            _fechaFinal = fila.Cells("Fecha Final").Value
        Catch
            _fechaFinal = ""
        End Try
        Try
            _diasterminar = fila.Cells("Dias x Terminar").Value
        Catch
            _diasterminar = ""
        End Try
        Try
            Select Case fila.Cells("Estado").Value
                Case "A"
                    _estado = "Activo"
                Case "S"
                    _estado = "Suspendido"
                Case "T"
                    _estado = "Terminado"
                Case Else
                    _estado = fila.Cells("Estado").Value
            End Select
        Catch
            _estado = ""
        End Try
        Try
            _tipoContrato = fila.Cells("Tipo Contrato").Value
        Catch
            _tipoContrato = ""
        End Try
        Try
            Select Case fila.Cells("CodTipoSalario").Value
                Case "D"
                    _tipoSalario = "Diario"
                Case "M"
                    _tipoSalario = "Mensual"
            End Select
        Catch
            _tipoSalario = ""
        End Try
        Try
            _usuarioRegistra = fila.Cells("USUARIOREGISTRA").Value
        Catch
            _usuarioRegistra = ""
        End Try
        Try
            _fechaRegistro = fila.Cells("FECHAREGISTRO").Value
        Catch
            _fechaRegistro = ""
        End Try
        Try
            _usuarioModifica = fila.Cells("USUARIOMODIFICA").Value
        Catch
            _usuarioModifica = ""
        End Try
        Try
            _fechaModificacion = fila.Cells("FECHAMODIFICACION").Value
        Catch
            _fechaModificacion = ""
        End Try
        Try
            _consecutivoProrrogas = fila.Cells("CONSECUTIVOPRORROGAS").Value
        Catch
            _consecutivoProrrogas = ""
        End Try
        Try
            Select Case fila.Cells("CODIGOTIPODURACION").Value
                Case "D"
                    _duracion = fila.Cells("DURACION").Value & " día" & If(fila.Cells("DURACION").Value <> 1, "s", "")
                Case "M"
                    _duracion = fila.Cells("DURACION").Value & " mes" & If(fila.Cells("DURACION").Value <> 1, "es", "")
                Case Else
                    _duracion = ""
            End Select
        Catch
            _duracion = ""
        End Try
        Try
            _Cargo = fila.Cells("CARGO").Value
        Catch ex As Exception

        End Try

        Try
            _Celular = fila.Cells("Celular").Value
        Catch ex As Exception

        End Try

        Try
            _lugarContratacíon = fila.Cells("Lugar Contrato").Value
        Catch ex As Exception

        End Try



    End Sub
End Class 'Cl_Contrato