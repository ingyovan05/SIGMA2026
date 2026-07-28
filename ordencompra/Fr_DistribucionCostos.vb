Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class Fr_DistribucionCostos

    Public idOC As Integer
    Public OC As String
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)


    Public Sub Cargar_Tablas()

        Lb_OrdenCompra.Text = OC
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.DistribucionCostosOC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDORDENCOMPRA", idOC)
        comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@ACCION", 0)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsDCOC As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsDCOC)
            conexion.Close()
            Lb_Consecutivo.Text = dsDCOC.Tables(0).Rows(0).Item("Column1")
            Dgv_ListaSAI.DataSource = dsDCOC.Tables(1)
            Dgv_ListaDistribucionA.DataSource = dsDCOC.Tables(2)
            Dgv_ListaDistribucionCC.DataSource = dsDCOC.Tables(3)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Sub AplicarFormatoColumnas()
        For i = 0 To Dgv_ListaSAI.ColumnCount - 1
            Select Case Dgv_ListaSAI.Columns(i).Name
                Case "idsalida"
                    Dgv_ListaSAI.Columns(i).Width = 50
                    Dgv_ListaSAI.Columns(i).HeaderText = " Id"
                    Dgv_ListaSAI.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                Case "salidaalmacen"
                    Dgv_ListaSAI.Columns(i).Width = 120
                    Dgv_ListaSAI.Columns(i).HeaderText = "Salida Almacén"
                    Dgv_ListaSAI.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                Case "idArticulo"
                    Dgv_ListaSAI.Columns(i).Width = 50
                    Dgv_ListaSAI.Columns(i).HeaderText = "Id Art"
                    Dgv_ListaSAI.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
                Case "cantidad"
                    Dgv_ListaSAI.Columns(i).Width = 40
                    Dgv_ListaSAI.Columns(i).HeaderText = "Cant."
                    Dgv_ListaSAI.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                Case "bodega"
                    Dgv_ListaSAI.Columns(i).Width = 200
                    Dgv_ListaSAI.Columns(i).HeaderText = "Bodega"
                    Dgv_ListaSAI.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                Case "fechadespacho"
                    Dgv_ListaSAI.Columns(i).Width = 100
                    Dgv_ListaSAI.Columns(i).HeaderText = "Fecha Salida"
                    Dgv_ListaSAI.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                Case Else
                    Dgv_ListaSAI.Columns(i).Visible = False
            End Select
        Next
        For i = 0 To Dgv_ListaDistribucionA.ColumnCount - 1
            Select Case Dgv_ListaDistribucionA.Columns(i).Name
                Case "idarticulo"
                    Dgv_ListaDistribucionA.Columns(i).Width = 50
                    Dgv_ListaDistribucionA.Columns(i).HeaderText = "Id"
                    Dgv_ListaDistribucionA.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                Case "nombreArticulo"
                    Dgv_ListaDistribucionA.Columns(i).Width = 200
                    Dgv_ListaDistribucionA.Columns(i).HeaderText = "Artículo"
                    Dgv_ListaDistribucionA.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                Case "nombrebodega"
                    Dgv_ListaDistribucionA.Columns(i).Width = 200
                    Dgv_ListaDistribucionA.Columns(i).HeaderText = "Bodega"
                    Dgv_ListaDistribucionA.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                Case "centrocosto"
                    Dgv_ListaDistribucionA.Columns(i).Width = 100
                    Dgv_ListaDistribucionA.Columns(i).HeaderText = "Centro Costo"
                    Dgv_ListaDistribucionA.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                Case "porcentajeobra"
                    Dgv_ListaDistribucionA.Columns(i).Width = 50
                    Dgv_ListaDistribucionA.Columns(i).HeaderText = "% Por Obra"
                    Dgv_ListaDistribucionA.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                Case "subtotal"
                    Dgv_ListaDistribucionA.Columns(i).Width = 80
                    Dgv_ListaDistribucionA.Columns(i).HeaderText = "Subtotal"
                    Dgv_ListaDistribucionA.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                Case "iva"
                    Dgv_ListaDistribucionA.Columns(i).Width = 80
                    Dgv_ListaDistribucionA.Columns(i).HeaderText = "Iva"
                    Dgv_ListaDistribucionA.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                Case "porcentajeiva"
                    Dgv_ListaDistribucionA.Columns(i).Width = 40
                    Dgv_ListaDistribucionA.Columns(i).HeaderText = "% Iva"
                    Dgv_ListaDistribucionA.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                Case "total"
                    Dgv_ListaDistribucionA.Columns(i).Width = 80
                    Dgv_ListaDistribucionA.Columns(i).HeaderText = "Total"
                    Dgv_ListaDistribucionA.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                Case Else
                    Dgv_ListaDistribucionA.Columns(i).Visible = False
            End Select
        Next
        For i = 0 To Dgv_ListaDistribucionCC.ColumnCount - 1
            Select Case Dgv_ListaDistribucionCC.Columns(i).Name
                Case "nombrebodega"
                    Dgv_ListaDistribucionCC.Columns(i).Width = 200
                    Dgv_ListaDistribucionCC.Columns(i).HeaderText = "Bodega"
                    Dgv_ListaDistribucionCC.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                Case "centrocosto"
                    Dgv_ListaDistribucionCC.Columns(i).Width = 100
                    Dgv_ListaDistribucionCC.Columns(i).HeaderText = "Centro Costo"
                    Dgv_ListaDistribucionCC.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                Case "porcentajeobra"
                    Dgv_ListaDistribucionCC.Columns(i).Width = 50
                    Dgv_ListaDistribucionCC.Columns(i).HeaderText = "% Por Obra"
                    Dgv_ListaDistribucionCC.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                Case "subtotal"
                    Dgv_ListaDistribucionCC.Columns(i).Width = 80
                    Dgv_ListaDistribucionCC.Columns(i).HeaderText = "Subtotal"
                    Dgv_ListaDistribucionCC.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                Case "iva"
                    Dgv_ListaDistribucionCC.Columns(i).Width = 80
                    Dgv_ListaDistribucionCC.Columns(i).HeaderText = "Iva"
                    Dgv_ListaDistribucionCC.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                Case "porcentajeiva"
                    Dgv_ListaDistribucionCC.Columns(i).Width = 40
                    Dgv_ListaDistribucionCC.Columns(i).HeaderText = "% Iva"
                    Dgv_ListaDistribucionCC.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                Case "total"
                    Dgv_ListaDistribucionCC.Columns(i).Width = 80
                    Dgv_ListaDistribucionCC.Columns(i).HeaderText = "Total"
                    Dgv_ListaDistribucionCC.Columns(i).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
                Case Else
                    Dgv_ListaDistribucionCC.Columns(i).Visible = False
            End Select
        Next

    End Sub


    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click

        comando = New SqlCommand("dbo.DistribucionCostosOC", conexion) With {.CommandType = CommandType.StoredProcedure}
        comando.Parameters.Add("@IDORDENCOMPRA", SqlDbType.BigInt)
        comando.Parameters.Add("@IDBODEGA", SqlDbType.Int)
        comando.Parameters.Add("@IDUSUARIO", SqlDbType.Int)
        comando.Parameters.Add("@ACCION", SqlDbType.Int)
        comando.Parameters("@IDORDENCOMPRA").Value = idOC
        comando.Parameters("@IDBODEGA").Value = VariablesBase.VariablesBase.IdBodegaActual
        comando.Parameters("@IDUSUARIO").Value = VariablesBase.VariablesBase.IdPersona
        comando.Parameters("@ACCION").Value = 1

        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            MsgBox("Distribución Guardada", MsgBoxStyle.Information, "Guardado")
            If MsgBox("¿Desea exportar a un archivo excel?", MsgBoxStyle.YesNo, "SALIR SIN EXPORTAR") = MsgBoxResult.Yes Then
                ExportarDatosExcel(Dgv_ListaSAI, Dgv_ListaDistribucionA, Dgv_ListaDistribucionCC)
            Else
                Close()
            End If
            Close()
        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos." & Environment.NewLine & ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try

    End Sub


    Private Sub Fr_DistribucionCostos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown,
    Dgv_ListaSAI.KeyDown, Dgv_ListaDistribucionA.KeyDown, Dgv_ListaDistribucionCC.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                ExportarDatosExcel(Dgv_ListaSAI, Dgv_ListaDistribucionA, Dgv_ListaDistribucionCC)
        End Select
    End Sub


    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, ByVal DataGridView2 As DataGridView, ByVal DataGridView3 As DataGridView)

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        objLibroExcel.Worksheets.Add()
        objLibroExcel.Worksheets.Add()
        Dim objHojaSalidasAfectadas As Excel.Worksheet = objLibroExcel.Worksheets(1)
        Dim objHojaDistribucionxArticulo As Excel.Worksheet = objLibroExcel.Worksheets(2)
        Dim objHojaDistribucionxCC As Excel.Worksheet = objLibroExcel.Worksheets(3)


        With objHojaSalidasAfectadas
            .Name = ("Salidas de Almacén Afectadas")
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
            With .Range(.Cells(1, 1), .Cells(1, Dgv_ListaSAI.Columns.Count)).Font
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
        With objHojaDistribucionxArticulo
            .Name = ("Distribución x Artículo")
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
            For Each c As DataGridViewColumn In DataGridView2.Columns
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
            With .Range(.Cells(1, 1), .Cells(1, Dgv_ListaDistribucionA.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView2.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView2.Columns
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
            For Each c As DataGridViewColumn In DataGridView2.Columns
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
        With objHojaDistribucionxCC
            .Name = ("Distribución x Centro de Costos")
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
            For Each c As DataGridViewColumn In DataGridView3.Columns
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
            With .Range(.Cells(1, 1), .Cells(1, Dgv_ListaDistribucionCC.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView3.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView3.Columns
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
            For Each c As DataGridViewColumn In DataGridView3.Columns
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

End Class