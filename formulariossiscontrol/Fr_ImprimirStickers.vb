Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_ImprimirStickers
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private dsStickers As DataSet
    Private dtGrupos As DataTable
    Private dvHojas As DataView
    Private dvNumeroSticker As DataView
    Private maxHoja As Integer
    Private minHoja As Integer
    Private tienePermisoImpresionContinua As Boolean = False
    ''' <summary>Enumeración de los posibles tipos de impresión de stickers.</summary>
    Private Enum TipoImpresion
        ''' <summary>Hoja tamaño carta con 30 stickers 67 × 25 mm para impresora normal.</summary>
        HojaPor30
        ''' <summary>Etiqueta con sticker 51 × 32 mm para impresora continua.</summary>
        Continua
    End Enum

    Private Sub Fr_ImprimirStickers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dgv_Consecutivos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Consecutivos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        CargarBases()
        If FuncionesBase.FuncionesBase.ConsultarPermiso(766) Then
            tienePermisoImpresionContinua = True
            HabilitarControlesImpresionContinua()
        Else
            tienePermisoImpresionContinua = False
            DeshabilitarControlesImpresionContinua()
        End If
        AddHandler Cb_Dependencia.SelectedIndexChanged, AddressOf Cb_Dependencia_SelectedIndexChanged
        ConsultarStickers()
    End Sub

    ''' <summary>Desactiva los controles correspondientes a la impresión continua de stickers.</summary>
    Private Sub DeshabilitarControlesImpresionContinua()
        Lb_TextoBase.Enabled = False
        Cb_Base.Enabled = False
        Lb_TextoDependencia.Enabled = False
        Cb_Dependencia.Enabled = False
        Lb_TextoAdicionarSticker.Visible = False
        Tx_AdicionarSticker.Visible = False
        Bt_AdicionarSticker.Visible = False
        Bt_GenerarStickers.Visible = False
        Bt_ImprimirContinua.Visible = False
        Bt_Aceptar.Text = "Imprimir"
    End Sub

    ''' <summary>Activa los controles correspondientes a la impresión continua de stickers.</summary>
    Private Sub HabilitarControlesImpresionContinua()
        Lb_TextoBase.Enabled = True
        Cb_Base.Enabled = True
        Lb_TextoDependencia.Enabled = True
        Cb_Dependencia.Enabled = True
        Lb_TextoAdicionarSticker.Visible = True
        Tx_AdicionarSticker.Visible = True
        Bt_AdicionarSticker.Visible = True
        Bt_GenerarStickers.Visible = True
        Bt_ImprimirContinua.Visible = True
        Bt_Aceptar.Text = "Impresión normal"
    End Sub

    ''' <summary>Carga el listado de bases en la lista desplegable Cb_Base.</summary>
    Public Sub CargarBases()
        comando = New SqlCommand("ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 2) 'Cargar todas las bases activas.
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        adaptador = New SqlDataAdapter(comando)
        Dim dtBases As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtBases)
            conexion.Close()
            Cb_Base.DataSource = dtBases
            Cb_Base.SelectedValue = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    ''' <summary>Carga el listado de dependencias en la lista desplegable Cb_Dependencia</summary>
    Public Sub CargarDependencias()
        comando = New SqlCommand("ListarBaseDependenciaSC", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@ACCION", 11) 'Cargar todas las dependencias activas de la base (incluyendo Gerencia).
        comando.Parameters.AddWithValue("@IDBASESISCONTROL", Cb_Base.SelectedValue)
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        adaptador = New SqlDataAdapter(comando)
        Dim dtDependencias As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtDependencias)
            conexion.Close()
            Cb_Dependencia.DataSource = dtDependencias
            If Cb_Base.SelectedValue = VariablesBase.VariablesBase.IdBaseSiscontrolActual Then
                Cb_Dependencia.SelectedValue = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
            Else
                Cb_Dependencia.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Cb_Base_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Base.SelectedIndexChanged
        CargarDependencias()
    End Sub

    Private Sub Cb_Dependencia_SelectedIndexChanged(sender As Object, e As EventArgs)
        HabilitarControles()
        ConsultarStickers()
    End Sub

    ''' <summary>Carga los stickers registrados en la dependencia actual del usuario.</summary>
    Private Sub ConsultarStickers()
        comando = New SqlCommand("dbo.ListarStickersRecepcion", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        If Cb_Dependencia.SelectedIndex >= 0 Then
            comando.Parameters("@IDDEPENDENCIA").Value = Cb_Dependencia.SelectedValue
        Else
            comando.Parameters("@IDDEPENDENCIA").Value = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        End If
        adaptador = New SqlDataAdapter(comando)
        dsStickers = New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsStickers)
            conexion.Close()
            If dsStickers.Tables.Count > 0 Then
                If dsStickers.Tables(0).Rows.Count > 0 Then
                    dtGrupos = dsStickers.Tables(0)
                    dvHojas = New DataView(dsStickers.Tables(1))
                    dvNumeroSticker = New DataView(dsStickers.Tables(2))
                    Cb_Grupo.DataSource = dtGrupos
                    Dgv_Consecutivos.DataSource = dvNumeroSticker
                    Bt_Aceptar.Enabled = True
                    FiltrarStickers()
                Else
                    'No se han generado stickers en la dependencia actual.
                    If GenerarStickers() = True Then
                        HabilitarControles()
                        ConsultarStickers()
                    Else
                        DeshabilitarControles()
                    End If
                End If
            Else
                Throw New Exception("No se cargaron las tablas.")
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al ejecutar la operación.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DeshabilitarControles()
        Finally
            conexion.Close()
        End Try
    End Sub

    ''' <summary>Activa los controles de la ventana.</summary>
    Private Sub HabilitarControles()
        Cb_Grupo.Enabled = True
        Nud_HojaDesde.Enabled = True
        Nud_HojaHasta.Enabled = True
        Lb_FechaRegistro.Enabled = True
        Lb_UsuarioRegistra.Enabled = True
        'Dgv_Consecutivos.ReadOnly = False
        Bt_Aceptar.Enabled = True
    End Sub

    ''' <summary>Desctiva los controles de la ventana cuando no se han cargado stickers o no hay acciones disponibles para ejecutar.</summary>
    Private Sub DeshabilitarControles()
        Cb_Grupo.Enabled = False
        Nud_HojaDesde.Enabled = False
        Nud_HojaHasta.Enabled = False
        Lb_FechaRegistro.Enabled = False
        Lb_UsuarioRegistra.Enabled = False
        'Dgv_Consecutivos.ReadOnly = True
        Bt_Aceptar.Enabled = False
    End Sub

    Private Sub Cb_Grupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_Grupo.SelectedIndexChanged
        Dim dr As DataRow = dtGrupos.Select(Cb_Grupo.ValueMember & " = " & Cb_Grupo.SelectedValue)(0)
        Lb_FechaRegistro.Text = DirectCast(dr.Item("FECHAREGISTRO"), DateTime).ToString("d/MM/yyyy hh:mm tt")
        Lb_UsuarioRegistra.Text = dr.Item("USUARIOREGISTRA")
        dvHojas.RowFilter = Cb_Grupo.ValueMember & " = " & Cb_Grupo.SelectedValue
        minHoja = dvHojas.Table.Compute("MIN(HOJA)", Cb_Grupo.ValueMember & " = " & Cb_Grupo.SelectedValue)
        maxHoja = dvHojas.Table.Compute("MAX(HOJA)", Cb_Grupo.ValueMember & " = " & Cb_Grupo.SelectedValue)
        Nud_HojaDesde.Minimum = minHoja
        Nud_HojaHasta.Minimum = minHoja
        Nud_HojaDesde.Maximum = maxHoja
        Nud_HojaHasta.Maximum = maxHoja
        Nud_HojaDesde.Value = minHoja
        Nud_HojaHasta.Value = maxHoja
        FiltrarStickers()
    End Sub

    Private Sub Nud_HojaDesde_ValueChanged(sender As Object, e As EventArgs) Handles Nud_HojaDesde.ValueChanged
        If Not IsNothing(Cb_Grupo.SelectedValue) Then
            If Nud_HojaDesde.Value > Nud_HojaHasta.Value Then
                Nud_HojaHasta.Value = Nud_HojaDesde.Value
            End If
            FiltrarStickers()
        End If
    End Sub

    Private Sub Nud_HojaHasta_ValueChanged(sender As Object, e As EventArgs) Handles Nud_HojaHasta.ValueChanged
        If Not IsNothing(Cb_Grupo.SelectedValue) Then
            If Nud_HojaHasta.Value < Nud_HojaDesde.Value Then
                Nud_HojaDesde.Value = Nud_HojaHasta.Value
            End If
            FiltrarStickers()
        End If
    End Sub

    ''' <summary>Mostrar en la rejilla los stickers pertenecientes al grupo y hojas seleccionados.</summary>
    Private Sub FiltrarStickers()
        If Not IsNothing(Cb_Grupo.SelectedValue) Then
            dvNumeroSticker.RowFilter = Col_Grupo.DataPropertyName & " = " & Cb_Grupo.SelectedValue & " AND (" & Col_Hoja.DataPropertyName & " >= " & Nud_HojaDesde.Value & " AND " & Col_Hoja.DataPropertyName & " <= " & Nud_HojaHasta.Value & ")"
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Dgv_Consecutivos.Rows.Count > 0 Then
            ImprimirStickers(TipoImpresion.HojaPor30, True)
        End If
    End Sub

    Private Sub Bt_ImprimirContinua_Click(sender As Object, e As EventArgs) Handles Bt_ImprimirContinua.Click
        If Dgv_Consecutivos.Rows.Count > 0 Then
            ImprimirStickers(TipoImpresion.Continua, True)
        End If
    End Sub

    ''' <summary>Ejecuta el comando de impresión de stickers según la opción de impresión seleccionada.</summary>
    ''' <param name="tipo">Tipo de impresión seleccionado</param>
    ''' <param name="abrirEnVistaPrevia">Mostrar o no la ventana de previsualización de impresión</param>
    Private Sub ImprimirStickers(tipo As TipoImpresion, Optional abrirEnVistaPrevia As Boolean = True)
        Dim clImpresion As New ImpresiónSisControl.Cl_Impresión
        clImpresion.dtNumeroSticker = DirectCast(Dgv_Consecutivos.DataSource, DataView).ToTable
        Dim formatos As New ArrayList
        Select Case tipo
            Case TipoImpresion.HojaPor30
                formatos.Add(77)
            Case TipoImpresion.Continua
                formatos.Add(79)
        End Select
        clImpresion.FormatoImprimirSisControl(formatos, abrirEnVistaPrevia, False)
    End Sub

    Private Sub Bt_GenerarStickers_Click(sender As Object, e As EventArgs) Handles Bt_GenerarStickers.Click
        If GenerarStickers() = True Then
            HabilitarControles()
            ConsultarStickers()
            'Else
            'If Dgv_Consecutivos.Rows.Count <= 0 Then
            'DeshabilitarControles()
            'End If
        End If
    End Sub

    ''' <summary>Abre la ventana de creación de stickers</summary>
    ''' <returns>Verdadero si se crearon nuevos stickers. Falso si se cerró la ventana sin crear stickers.</returns>
    Private Function GenerarStickers() As Boolean
        Dim dr As DialogResult
        Dim tempBase As Integer = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        Dim tempDependencia As Integer = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        If tienePermisoImpresionContinua Then
            VariablesBase.VariablesBase.IdBaseSiscontrolActual = Cb_Base.SelectedValue
            VariablesBase.VariablesBase.IddependenciaSiscontrolActual = Cb_Dependencia.SelectedValue
        End If
        Dim frGenerarStickers As New Fr_GenerarStickers
        dr = frGenerarStickers.ShowDialog()
        VariablesBase.VariablesBase.IdBaseSiscontrolActual = tempBase
        VariablesBase.VariablesBase.IddependenciaSiscontrolActual = tempDependencia
        Return If(dr = DialogResult.OK, True, False)
    End Function
End Class