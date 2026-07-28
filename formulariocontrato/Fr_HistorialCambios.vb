Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data
Imports System.Globalization

Public Class Fr_HistorialCambios
    Public CODIGOTIPO As Short
    Public IDBASE As Integer
    Public IDPERSONA As Integer
    Public IDCONTRATO As Integer

    Private dtHistorialCambios As New DataTable
    Private dtTipoCargo As New DataTable
    Private FilaContrato As DataRow
    Private dsCargar As Object
    Private bddatos As New FuncionesBase.ClaseCargarMaestras
    Private Index_Registro_Actual As Integer = -1


    Public Sub comparar()



    End Sub
    Private Sub Dgv_HistorialCambios_SelectionChanged(sender As Object, e As EventArgs) Handles Dgv_HistorialCambios.SelectionChanged
        Try


            If Dgv_HistorialCambios.SelectedRows.Count > 0 Then

                If Dgv_DetalleCambios.Rows.Count > 0 Then

                    Dgv_DetalleCambios.Rows.Clear()


                    Index_Registro_Actual = Dgv_HistorialCambios.CurrentCell.RowIndex
                    If Index_Registro_Actual <> -1 Then
                        cargarDetallesCambios(Index_Registro_Actual)
                    End If


                End If

            End If





        Catch

        End Try
    End Sub

    Public Sub cargarDatosContrato()



        ''Datos del contrato y persona
        Dim dsCargar As New DataSet
        Dim identificador As Long
        Dim tipo As Integer

        identificador = IDPERSONA
        tipo = 1
        dsCargar = bddatos.CargarMaestras(2, VariablesBase.VariablesBase.IdBaseSiscontrolActual, identificador, tipo)
        Label_Nombre.Text = "Nombre: " & dsCargar.Tables(21).Rows(0).Item("NOMBRE")
        Label_Cedula.Text = "Identificación: " & FuncionesBase.FuncionesBase.FormatearIdentificacion(Trim(dsCargar.Tables(21).Rows(0).Item("IDENTIFICACION")))
        identificador = IDCONTRATO
        tipo = 2
        dsCargar = bddatos.CargarMaestras(2, VariablesBase.VariablesBase.IdBaseSiscontrolActual, identificador, tipo)
        FilaContrato = dsCargar.Tables(0).Rows(0)


        Select Case FilaContrato("ESTADOCONTRATO")
            Case "A" 'Contrato Activo
                Lb_Estado.Text = "ESTADO: CONTRATO NRO.  " & FilaContrato("CODIGOCONTRATO") & "     ACTIVO"
                Lb_Estado.ForeColor = Drawing.Color.Blue
                Lb_Estado.Visible = True
            Case "E" 'Contrato eextendido
                Lb_Estado.Text = "ESTADO: CONTRATO NRO.  " & FilaContrato("CODIGOCONTRATO") & "     EXTENDIDO"
                Lb_Estado.ForeColor = Drawing.Color.DarkRed
                Lb_Estado.Visible = True
            Case "S" 'Contrato Suspendido
                Lb_Estado.Text = "ESTADO: CONTRATO NRO.  " & FilaContrato("CODIGOCONTRATO") & "     SUSPENDIDO"
                Lb_Estado.ForeColor = Drawing.Color.Orange
                Lb_Estado.Visible = True
            Case "T" 'Contrato Terminado


                Lb_Estado.Text = "ESTADO: CONTRATO NRO.  " & FilaContrato("CODIGOCONTRATO") & "     TERMINADO"
                Lb_Estado.ForeColor = Drawing.Color.Red
                Lb_Estado.Visible = True

        End Select
        ''Datos del registro de cambios
        Dgv_HistorialCambios.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_HistorialCambios.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2








        'Try
        '    conexion.Open()
        '    adaptador.Fill(dsHistorialCambios)
        '    conexion.Close()
        '    dtHistorialCambios = dsHistorialCambios.Tables(0)

        '    FilaHistorialCambio = dsHistorialCambios.Tables(0).Rows(0)

        '    
        '    Dim numerolineas As Integer
        '    numerolineas = dsHistorialCambios.Tables(0).Rows.Count
        '    Dgv_HistorialCambios.DataSource = dtHistorialCambios
        'Catch
        '    conexion.Close()

        'End Try
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.HistorialCambiosContrato", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDCONTRATO", IDCONTRATO)
        comando.Parameters.AddWithValue("@IDPERSONA", IDPERSONA)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtHistorialCambios As New DataTable


        Try
            conexion.Open()
            adaptador.Fill(dtHistorialCambios)
            conexion.Close()
            'dtHistorialCambios = dsHistorialCambios.Tables(0)
            'FilaHistorialCambio = dsHistorialCambios.Tables(0).Rows(0)

            If dtHistorialCambios.Rows.Count > 0 Then
                Dgv_HistorialCambios.DataSource = dtHistorialCambios
                'Dgv_Prorrogas.AutoResizeColumns()
            Else
                If Not IsNothing(Dgv_HistorialCambios.DataSource) Then
                    Dgv_HistorialCambios.DataSource.Clear()
                End If
            End If
        Catch
            conexion.Close()
            If Not IsNothing(Dgv_HistorialCambios.DataSource) Then
                Dgv_HistorialCambios.DataSource.Clear()
            End If
        End Try

        For i = 0 To Dgv_HistorialCambios.ColumnCount - 1
            Select Case Dgv_HistorialCambios.Columns(i).Name


                Case DGVHC_Registra.Name
                    Dgv_HistorialCambios.Columns(i).ToolTipText = "NOMBRE CREADOR CONTRATO"
                    Dgv_HistorialCambios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_HistorialCambios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                Case DGVHC_Modifica.Name  'Nombre persona modifica
                    Dgv_HistorialCambios.Columns(i).ToolTipText = "MODIFICA"
                    Dgv_HistorialCambios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_HistorialCambios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case DGVHC_CodigoAuditoria.Name  ' codigo tipo auditoria
                    Dgv_HistorialCambios.Columns(i).ToolTipText = "CODIGO TIPO AUDITORIA"
                    Dgv_HistorialCambios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_HistorialCambios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case DGVHC_ObservacionAuditoria.Name   ' obseracion auditoria
                    Dgv_HistorialCambios.Columns(i).ToolTipText = "ID"
                    Dgv_HistorialCambios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Dgv_HistorialCambios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Case DGVHC_Fecha.Name ' fecha registro auditoria
                    Dgv_HistorialCambios.Columns(i).ToolTipText = "FECHA AUDITORIA"
                    Dgv_HistorialCambios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_HistorialCambios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case DGVHC_FechaRegistro.Name ' fecha registro contrato
                    Dgv_HistorialCambios.Columns(i).ToolTipText = "IDUSUARIO AUDITORIA"
                    Dgv_HistorialCambios.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Dgv_HistorialCambios.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                Case Else
                    Dgv_HistorialCambios.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Public Sub cargarDetallesCambios(ByVal fila As Integer)

        ''Datos del contrato y persona
        Dim dsCargar As New DataSet
        Dim identificador As Long
        Dim tipo As Integer

        identificador = IDPERSONA
        tipo = 1
        dsCargar = bddatos.CargarMaestras(2, VariablesBase.VariablesBase.IdBaseSiscontrolActual, identificador, tipo)
        Label_Nombre.Text = "Nombre: " & dsCargar.Tables(21).Rows(0).Item("NOMBRE")
        Label_Cedula.Text = "Identificación: " & FuncionesBase.FuncionesBase.FormatearIdentificacion(Trim(dsCargar.Tables(21).Rows(0).Item("IDENTIFICACION")))
        identificador = IDCONTRATO
        tipo = 2
        dsCargar = bddatos.CargarMaestras(2, VariablesBase.VariablesBase.IdBaseSiscontrolActual, identificador, tipo)
        FilaContrato = dsCargar.Tables(0).Rows(0)

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.HistorialCambiosContrato", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDCONTRATO", IDCONTRATO)
        comando.Parameters.AddWithValue("@IDPERSONA", IDPERSONA)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dsHistorialCambios As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsHistorialCambios)
            conexion.Close()
            dtHistorialCambios = dsHistorialCambios.Tables(0)
            FilaHistorialCambio = dsHistorialCambios.Tables(0).Rows(0)

            Dim numerolineas As Integer
            numerolineas = dsHistorialCambios.Tables(0).Rows.Count
            Dgv_HistorialCambios.DataSource = dtHistorialCambios

            Try
                If Dgv_HistorialCambios.Rows.Count > 0 Then
                    Dim tamaño As Size
                    Dim dgrow As DataGridViewRow = Dgv_HistorialCambios.Rows(0)
                    tamaño.Height = (dtHistorialCambios.Rows.Count * dgrow.Height) + 120
                    tamaño.Width = Me.Width

                    ListBox1.Items.Add("Fila No " & fila + 1)

                    If FilaContrato.Table.Rows.Count <> dtHistorialCambios.Rows.Count OrElse FilaContrato.Table.Columns.Count <> dtHistorialCambios.Columns.Count Then
                        If fila = 0 Then
                            For j As Integer = 0 To FilaContrato.Table.Columns.Count - 1   '' Columnas contrato (N) 
                                For i As Integer = 0 To FilaContrato.Table.Rows.Count - 1   ''filas contrato (1)
                                    If Not Equals(FilaContrato.Table.Rows(i)(j), dtHistorialCambios.Rows(fila)(j)) Then

                                        Dgv_DetalleCambios.Rows.Add(FilaContrato.Table.Columns(j).ColumnName, FilaContrato.Table.Rows(i)(j), dtHistorialCambios.Rows(fila)(j), dtHistorialCambios.Rows(fila)(78))

                                        'ListBox1.Items.Add(FilaContrato.Table.Columns(j).ColumnName & " Registro Actual " & FilaContrato.Table.Rows(i)(j) & " Registro anterior " & dtHistorialCambios.Rows(fila)(j) & " Editado por " & dtHistorialCambios.Rows(fila)(78))
                                    End If
                                Next
                            Next
                        ElseIf fila > 0 Then
                            For j As Integer = 0 To FilaContrato.Table.Columns.Count - 1   '' Columnas contrato (N) 
                                For i As Integer = 0 To FilaContrato.Table.Rows.Count - 1   ''filas contrato (1)
                                    Dim filaAnt As Integer
                                    filaAnt = fila - 1
                                    If Not Equals(dtHistorialCambios.Rows(filaAnt)(j), dtHistorialCambios.Rows(fila)(j)) Then
                                        'ListBox1.Items.Add("Fila No " & FilaContrato.Table.Columns(j).ColumnName)
                                        'FilaHistorialCambio = dsHistorialCambios.Tables(0).Rows(fila)
                                        'FilaHistorialCambio2 = dsHistorialCambios.Tables(0).Rows(fila - 1)
                                        'If Not Equals(FilaHistorialCambio2(j), FilaHistorialCambio(j)) Then
                                        '    ListBox1.Items.Add("Fila No " & FilaContrato.Table.Columns(j).ColumnName & FilaContrato.Table.Columns(j).ColumnName & FilaContrato.Table.Rows(fila - 1)(j) & dtHistorialCambios.Rows(fila)(j))
                                        'End If


                                        Dgv_DetalleCambios.Rows.Add(FilaContrato.Table.Columns(j).ColumnName, dtHistorialCambios.Rows(filaAnt)(j), dtHistorialCambios.Rows(fila)(j))
                                        ListBox1.Items.Add(dtHistorialCambios.Columns(j).ColumnName & " Registro  " & dtHistorialCambios.Rows(filaAnt)(j) & " Registro anterior " & dtHistorialCambios.Rows(fila)(j) & " Editado por " & dtHistorialCambios.Rows(fila)(78))
                                    End If
                                Next
                            Next
                        End If
                    End If
                End If
            Catch
                conexion.Close()
                If Not IsNothing(Dgv_HistorialCambios.DataSource) Then
                    Dgv_DetalleCambios.DataSource.Clear()
                End If
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private FilaHistorialCambio As DataRow
    Private FilaHistorialCambio2 As DataRow

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
        Dim strRowNumber As String = (e.RowIndex + 1).ToString
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Font)
        If Dgv_HistorialCambios.RowHeadersWidth < CInt(size.Width + 20) Then
            Dgv_HistorialCambios.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim bt As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Font, bt, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub
   
End Class