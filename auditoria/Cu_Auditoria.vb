Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class Cu_Auditoria
    Public Shared ValorConsecutivoAsignado As Integer = -1
    Private Index_Registro_Actual As Integer
    Private ConsecutivoAsignado As Boolean = False
    Private ModificarConsecutivo As Boolean
    Private dsLegalizacion As New DataSet
    Private tabla_cargada As String = ""
    Private bddatos As New DatosClasesBase.Busquedas

    Private Enum Tablas
        Legalizaciones
    End Enum
    Private tablaCargada As Tablas

    Public Sub Comportamiento_Predeterminado()
        Cb_FiltrarInforme.SelectedIndex = -1
        Nbg_Legalización.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Legalización.Tag)
        Nbi_AgregarLegalización.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AgregarLegalización.Tag)
        Nbi_EditarLegalización.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarLegalización.Tag)
        Nbi_EliminarLegalización.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EliminarLegalización.Tag)
        Nbi_AnularLegalización.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AnularLegalización.Tag)
        Nbi_VerLegalización.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerLegalización.Tag)
        Nbi_ModConsecutivo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ModConsecutivo.Tag)
        Nbi_RestablecerLegalizacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_RestablecerLegalizacion.Tag)
        Nbg_Filtro.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Filtro.Tag)
        Nbi_Buscar.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Buscar.Tag)
        Nbg_Informes.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Informes.Tag)
        Nbg_Exportar.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Exportar.Tag)
        Nbg_Imprimir.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Imprimir.Tag)
        Nbi_CargarLegalización.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarLegalización.Tag)
    End Sub


    Public Sub Cargar_Tabla()
        Cursor.Current = Cursors.WaitCursor
            Me.CONS_LEGALIZACIONTableAdapter.FillCONS_LEGALIZACION(Me.Ds_Auditoria.CONS_LEGALIZACION)
            Me.DGV_ListaLegalización.SuspendLayout()
            Me.DGV_ListaLegalización.DataSource = Me.Ds_Auditoria.CONS_LEGALIZACION
            Me.DGV_ListaLegalización.ResumeLayout()
    End Sub


    Private Sub Ubicar_Registro()
        Try
            DGV_ListaLegalización.ClearSelection()
            If Index_Registro_Actual < DGV_ListaLegalización.Rows.Count Then
                DGV_ListaLegalización.Rows(Index_Registro_Actual).Selected = True
                DGV_ListaLegalización.FirstDisplayedScrollingRowIndex = DGV_ListaLegalización.SelectedRows(0).Index
            End If
        Catch
        End Try
    End Sub


    Private Sub Pn_ContenedorPrincipal_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Pn_ContenedorPrincipal.Resize
        Me.DGV_ListaLegalización.Height = CInt(Pn_ContenedorPrincipal.Height / 3) * 2
        Me.Pn_ContenedorComprobantes.Width = CInt(Pn_ContenedorPrincipal.Width / 2)
    End Sub


    Private Sub Nbi_AgregarLegalización_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_AgregarLegalización.ItemClick
        Nuevoformulario()
    End Sub


    Public Sub Nuevoformulario()
        Dim message, title As String
        Dim consecutivo As String = CStr(FuncionesBase.FuncionesBase.Siguiente("SC_CONSECUTIVOLEGALIZACION", 0, Date.Now)).ToString
        Dim Asignadoconsecutivo As String
        If ValorConsecutivoAsignado = -1 Then
            If FuncionesBase.FuncionesBase.ExisteConsecutivo(CInt(ValorConsecutivoAsignado) + 1) = True Then
                Dim style1 = MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical Or MsgBoxStyle.Critical
                Dim response1 = MsgBox("Ya existe el consecutivo " & CStr(CInt(ValorConsecutivoAsignado) + 1) & ".", style1, "Advertencia")
                Exit Sub
            End If
            message = "El consecutivo actual es: " & consecutivo & " ¿Ingrese y acepte nuevo consecutivo?"
            title = "Consecutivo"
            Asignadoconsecutivo = InputBox(message, title, consecutivo)
            If IsNumeric(Asignadoconsecutivo) = False Then
                If Asignadoconsecutivo = "" Then
                    Exit Sub
                Else
                    Dim msg1 = "No es valor para un consecutivo: " & Asignadoconsecutivo
                    Dim title1 = "Advertencia"
                    Dim style1 = MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical Or MsgBoxStyle.Critical
                    Dim response1 = MsgBox(msg1, style1, title1)
                    Exit Sub
                End If
            End If
            If Asignadoconsecutivo = "" Then
                Exit Sub
                ConsecutivoAsignado = False
                ValorConsecutivoAsignado = consecutivo - 1
            Else
                If FuncionesBase.FuncionesBase.ExisteConsecutivo(CInt(Asignadoconsecutivo)) = False Then
                    ConsecutivoAsignado = True
                    ValorConsecutivoAsignado = CInt(Asignadoconsecutivo) - 1
                Else
                    Dim msg1 = "Ya existe el consecutivo " & Asignadoconsecutivo
                    Dim title1 = "Advertencia"
                    Dim style1 = MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical Or MsgBoxStyle.Critical
                    Dim response1 = MsgBox(msg1, style1, title1)
                    ValorConsecutivoAsignado = -1
                    Exit Sub
                End If
            End If
        End If
        If FuncionesBase.FuncionesBase.ExisteConsecutivo(CInt(ValorConsecutivoAsignado) + 1) = True Then
            Dim style1 = MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical Or MsgBoxStyle.Critical
            Dim response1 = MsgBox("Ya existe el consecutivo " & CStr(CInt(ValorConsecutivoAsignado) + 1) & ".", style1, "Advertencia")
            Exit Sub
        End If
        If DGV_ListaLegalización.RowCount > 0 Then
            Index_Registro_Actual = DGV_ListaLegalización.CurrentRow.Index
        End If
        Dim FrLegalización As New Fr_Legalización
        If ConsecutivoAsignado = True Then
            FrLegalización.ConsecutivoAsignado = True
            ValorConsecutivoAsignado = ValorConsecutivoAsignado + 1
            FrLegalización.ValorConsecutivoAsignado = ValorConsecutivoAsignado
        Else
            FrLegalización.ValorConsecutivoAsignado = consecutivo
        End If
        FrLegalización.Editando = False
        FrLegalización.ShowDialog()
        Cargar_Tabla()
    End Sub


    Private Sub DGV_ListaLegalización_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DGV_ListaLegalización.SelectionChanged
        Cargar_TablaComprobante_Concepto()
    End Sub


    Private Sub Cargar_TablaComprobante_Concepto()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim idlegalizacion As Integer = Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("IDLEGALIZACIONDataGridViewTextBoxColumn").Value
            Me.CONS_COMPROBANTETableAdapter.FillSC_COMPROBANTE(Ds_Auditoria.CONS_COMPROBANTE, idlegalizacion)
            Me.CONS_CONCEPTOTableAdapter.FillCONS_CONCEPTO(Ds_Auditoria.CONS_CONCEPTO, idlegalizacion)
            Cursor.Current = Cursors.Default
        Catch
        End Try
    End Sub


    Private Sub Cargar_Auditoria(ByVal idlegalizacion As Integer, ByVal Tipo As String)
        Dim FrLegalización As New Fr_Legalización
        FrLegalización.Editando = True
        FrLegalización.idlegalizacion = idlegalizacion
        If Tipo = "V" Then
            FrLegalización.Button_Aceptar.Enabled = False
        End If
        FrLegalización.ShowDialog()
    End Sub


    Private Sub Nbi_EditarLegalización_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_EditarLegalización.ItemClick
        Index_Registro_Actual = DGV_ListaLegalización.CurrentRow.Index
        Cargar_Auditoria(Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("IDLEGALIZACIONDataGridViewTextBoxColumn").Value, "E")
        Cargar_Tabla()
        Ubicar_Registro()
        Cargar_TablaComprobante_Concepto()
    End Sub


    Private Sub Nbi_EliminarLegalización_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_EliminarLegalización.ItemClick
        Index_Registro_Actual = DGV_ListaLegalización.CurrentRow.Index
        EliminarLegalizacion(Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("IDLEGALIZACIONDataGridViewTextBoxColumn").Value)
        Cargar_Tabla()
        Ubicar_Registro()
    End Sub


    Private Sub EliminarLegalizacion(ByRef idlegalizacion As Integer)
        Dim msg = "Desea eliminar esta legalización?"
        Dim title = "Eliminar"
        Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.Critical Or MsgBoxStyle.Critical
        Dim response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then
            Dim adap As New DatosAuditoria.Ds_AuditoriaTableAdapters.SC_LEGALIZACIONTableAdapter
            adap.CAMBIARESTADOLEGALIZACION("E", idlegalizacion)
        End If
    End Sub


    Private Function ValidarComprobantes(ByVal idlegalizacion As Integer) As Boolean
        ValidarComprobantes = True
        Dim AdatadorComprobante As New DatosAuditoria.Ds_AuditoriaTableAdapters.LISTACOMPROBANTETableAdapter
        AdatadorComprobante.Fill(Ds_Auditoria.LISTACOMPROBANTE, idlegalizacion)
        If Ds_Auditoria.LISTACOMPROBANTE.Rows.Count > 0 Then
            Return ValidarComprobantes = True
        Else
            Return ValidarComprobantes = False
        End If
    End Function


    Private Function ValidarConceptos(ByVal idlegalizacion As Integer) As Boolean
        ValidarConceptos = True
        Dim AdatadorConceptos As New DatosAuditoria.Ds_AuditoriaTableAdapters.LISTACONCEPTOTableAdapter
        AdatadorConceptos.Fill(Ds_Auditoria.LISTACONCEPTO, idlegalizacion)
        If Ds_Auditoria.LISTACOMPROBANTE.Rows.Count > 0 Then
            Return ValidarConceptos = True
        Else
            Return ValidarConceptos = False
        End If
    End Function


    Private Sub Cb_Filtrar_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Cb_Filtrar.CheckedChanged
        Cursor.Current = Cursors.WaitCursor
        Me.Tb_Descripción.Text = ""
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub DGV_ListaLegalización_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles DGV_ListaLegalización.MouseDoubleClick
        If Nbi_EditarLegalización.Enabled = True Then
            Index_Registro_Actual = DGV_ListaLegalización.CurrentRow.Index
            Cargar_Auditoria(Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("IDLEGALIZACIONDataGridViewTextBoxColumn").Value, "E")
            Cargar_Tabla()
            Ubicar_Registro()
        End If
    End Sub


    Private Sub ComboBox_Filtrar_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox_Filtrar.SelectedIndexChanged
        Select Case Me.ComboBox_Filtrar.SelectedIndex
            Case 0
                Me.Dtp_FechaFiltro.Visible = False
                Me.Tb_Descripción.Visible = True
            Case 1
                Me.Dtp_FechaFiltro.Visible = False
                Me.Tb_Descripción.Visible = True
            Case 2
                Me.Dtp_FechaFiltro.Visible = True
                Me.Tb_Descripción.Visible = False
            Case 3
                Me.Dtp_FechaFiltro.Visible = False
                Me.Tb_Descripción.Visible = True
            Case 4
                Me.Dtp_FechaFiltro.Visible = False
                Me.Tb_Descripción.Visible = True
        End Select
    End Sub


    Private Sub Dtp_FechaFiltro_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Dtp_FechaFiltro.ValueChanged
        If Cb_Filtrar.Checked = True Then
            Dim vista As New DataView(Me.Ds_Auditoria.CONS_LEGALIZACION)
            Me.DGV_ListaLegalización.SuspendLayout()
            Me.DGV_ListaLegalización.DataSource = vista
            Me.DGV_ListaLegalización.ResumeLayout()
            Dim Columna As String = ""
            Columna = "FECHALEGALIZACION"
            Try
                vista.RowFilter = "FECHALEGALIZACION='" & CDate(Me.Dtp_FechaFiltro.Value).ToShortDateString & "'"
            Catch
                vista.RowFilter = ""
            End Try
        End If
    End Sub


    Private Sub Nbi_AnularLegalización_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_AnularLegalización.ItemClick
        Index_Registro_Actual = DGV_ListaLegalización.CurrentRow.Index
        AunlarLegalizacion(Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("IDLEGALIZACIONDataGridViewTextBoxColumn").Value)
        Cargar_Tabla()
        Ubicar_Registro()
    End Sub


    Private Sub AunlarLegalizacion(ByVal idlegalizacion As Integer)
        Dim msg = "¿Desea anular esta legalización?"
        Dim title = "Eliminar"
        Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.Critical Or MsgBoxStyle.Critical
        Dim response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then
            Dim adap As New DatosAuditoria.Ds_AuditoriaTableAdapters.SC_LEGALIZACIONTableAdapter
            adap.CAMBIARESTADOLEGALIZACION("N", idlegalizacion)
        End If
    End Sub


    'Private Sub Cargar_tablas_ver()
    '    'Identificación 0
    '    'Nombre 1
    '    'Fecha 2
    '    'Cargo 3
    '    'Nulos 4
    '    'Eliminado 5
    '    'Consecutivo 6
    '    'Todo 7
    '    If ChecB_Ver.Checked Then
    '        Select Case Me.Cb_Ver.SelectedIndex
    '            Case 0
    '                Me.CONS_LEGALIZACIONTableAdapter.FillByIDENTIFICACION(Me.Ds_Auditoria.CONS_LEGALIZACION, Tb_ver.Text)
    '                Dtp_Ver.Visible = False
    '                Tb_ver.Visible = True
    '            Case 1
    '                Me.CONS_LEGALIZACIONTableAdapter.FillByNOMBRE(Me.Ds_Auditoria.CONS_LEGALIZACION, Tb_ver.Text)
    '                Dtp_Ver.Visible = False
    '                Tb_ver.Visible = True
    '            Case 2
    '                Me.CONS_LEGALIZACIONTableAdapter.FillByFECHA(Me.Ds_Auditoria.CONS_LEGALIZACION, Format(Dtp_Ver.Value, "yyyy-MM-dd"))
    '                Dtp_Ver.Visible = True
    '                Tb_ver.Visible = False
    '            Case 3
    '                Me.CONS_LEGALIZACIONTableAdapter.FillByCARGO(Me.Ds_Auditoria.CONS_LEGALIZACION, Tb_ver.Text)
    '                Dtp_Ver.Visible = False
    '                Tb_ver.Visible = True
    '            Case 4
    '                Me.CONS_LEGALIZACIONTableAdapter.FillVERESTADO(Me.Ds_Auditoria.CONS_LEGALIZACION, "N")
    '                Dtp_Ver.Visible = False
    '                Tb_ver.Visible = False
    '            Case 5
    '                Me.CONS_LEGALIZACIONTableAdapter.FillVERESTADO(Me.Ds_Auditoria.CONS_LEGALIZACION, "E")
    '                Dtp_Ver.Visible = False
    '                Tb_ver.Visible = False
    '            Case 6
    '                If IsNumeric(Tb_ver.Text) = False Then
    '                    MsgBox("Agregue un valor numérico", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Consecutivo")
    '                    Exit Sub
    '                End If
    '                Me.CONS_LEGALIZACIONTableAdapter.FillByCONSECUTIVO(Me.Ds_Auditoria.CONS_LEGALIZACION, Tb_ver.Text)
    '                Dtp_Ver.Visible = False
    '                Tb_ver.Visible = True
    '            Case 7
    '                Me.CONS_LEGALIZACIONTableAdapter.FillVerTodo(Me.Ds_Auditoria.CONS_LEGALIZACION)
    '                Dtp_Ver.Visible = False
    '                Tb_ver.Visible = False
    '        End Select
    '        Me.DGV_ListaLegalización.SuspendLayout()
    '        Me.DGV_ListaLegalización.DataSource = Me.Ds_Auditoria.CONS_LEGALIZACION
    '        Me.DGV_ListaLegalización.ResumeLayout()
    '    End If
    'End Sub


    Private Sub RecuperarLegalizacion(ByRef idlegalizacion As Integer)
        Dim msg = "¿Desea recuperar esta legalización?"
        Dim title = "Recuperar"
        Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.Critical Or MsgBoxStyle.Critical
        Dim response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then
            If FuncionesBase.FuncionesBase.ConsultarLegalizacionExistente(FuncionesBase.FuncionesBase.ConsultarIdPersona(Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("IDENTIFICACION").Value), Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("FECHADESDEDataGridViewTextBoxColumn").Value, Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("ESTADOLEGALIZACION").Value, idlegalizacion, True) Then
                Dim msg1 = "Ya existe una legalización con identificación " & RTrim(Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("IDENTIFICACION").Value) & " y fecha " & Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("FECHADESDEDataGridViewTextBoxColumn").Value & " ¿Desea recuperarla?"
                Dim title1 = "Advertencia"
                Dim style1 = MsgBoxStyle.YesNo Or MsgBoxStyle.Critical Or MsgBoxStyle.Critical
                Dim response1 = MsgBox(msg1, style1, title1)
                If response1 = MsgBoxResult.Yes Then
                    Dim adap As New DatosAuditoria.Ds_AuditoriaTableAdapters.SC_LEGALIZACIONTableAdapter
                    adap.CAMBIARESTADOLEGALIZACION(Nothing, idlegalizacion)
                End If
            Else
                Dim adap As New DatosAuditoria.Ds_AuditoriaTableAdapters.SC_LEGALIZACIONTableAdapter
                adap.CAMBIARESTADOLEGALIZACION(Nothing, idlegalizacion)
            End If
        End If
    End Sub


    Private Sub Nbi_ModConsecutivo_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_ModConsecutivo.ItemClick
        Dim message, title As String
        Dim consecutivo As String = CStr(FuncionesBase.FuncionesBase.Siguiente("SC_CONSECUTIVOLEGALIZACION", 0, Date.Now)).ToString
        Dim Asignadoconsecutivo As String
        message = "El consecutivo actual es: " & CStr(consecutivo) & " ¿Ingrese y acepte nuevo consecutivo?"
        title = "Consecutivo"
        Asignadoconsecutivo = InputBox(message, title, consecutivo)
        If IsNumeric(Asignadoconsecutivo) = False Then
            If Asignadoconsecutivo = "" Then
                Exit Sub
            Else
                Dim msg1 = "No es valor para un consecutivo: " & Asignadoconsecutivo
                Dim title1 = "Advertencia"
                Dim style1 = MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical Or MsgBoxStyle.Critical
                Dim response1 = MsgBox(msg1, style1, title1)
                Exit Sub
            End If
        End If
        If Asignadoconsecutivo = "" Then
            Exit Sub
            ConsecutivoAsignado = False
            'ValorConsecutivoAsignado = consecutivo - 1
        Else
            If FuncionesBase.FuncionesBase.ExisteConsecutivo(CInt(Asignadoconsecutivo)) = False Then
                Dim ultimoasiganado As String = CStr(FuncionesBase.FuncionesBase.Siguiente("SC_CONSECUTIVOLEGALIZACION", 0, Date.Now)).ToString
                If ultimoasiganado = Asignadoconsecutivo Then
                    ConsecutivoAsignado = True
                    ValorConsecutivoAsignado = CInt(Asignadoconsecutivo) - 1
                    ModificarConsecutivo = True
                Else
                    If consecutivo = Asignadoconsecutivo Then
                        ValorConsecutivoAsignado = CInt(Asignadoconsecutivo)
                        ModificarConsecutivo = True
                    Else
                        ConsecutivoAsignado = True
                        ValorConsecutivoAsignado = CInt(Asignadoconsecutivo) - 1
                        ModificarConsecutivo = True
                    End If
                End If
            Else
                Dim msg1 = "Ya existe el consecutivo " & Asignadoconsecutivo
                Dim title1 = "Advertencia"
                Dim style1 = MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical Or MsgBoxStyle.Critical
                Dim response1 = MsgBox(msg1, style1, title1)
                'ValorConsecutivoAsignado = -1
                Exit Sub
            End If
        End If
    End Sub


    Private Sub Bt_HistoricoTrabajador_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_HistoricoTrabajador.Click
        Dim FrHistoricoTrabajador As New Fr_HistoricoTrabajadorvb
        FrHistoricoTrabajador.identificacion = Trim(Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("IDENTIFICACION").Value)
        FrHistoricoTrabajador.añoRegistra = Year(Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("FECHALEGALIZACIONDataGridViewTextBoxColumn").Value)
        FrHistoricoTrabajador.ShowDialog()
    End Sub


    Private Sub Bt_CargarInforme_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_CargarInforme.Click
        Dim FrInformeLegalizacion As New Fr_InformeLegalizacion
        Select Case Me.Cb_FiltrarInforme.Text
            Case "Consecutivo Desde-Hasta"
                If Nud_Desde_Informe.Value > Nud_Hasta_Informe.Value Then
                    MsgBox("El consecutvo Hasta no puede ser inferior a Desde", MsgBoxStyle.Information, "Advertencia")
                    Exit Sub
                End If
                FrInformeLegalizacion.TipoInforme = 0
                FrInformeLegalizacion.Consecutivo_desde = Nud_Desde_Informe.Value
                FrInformeLegalizacion.Consecutivo_Hasta = Nud_Hasta_Informe.Value
                FrInformeLegalizacion.año = Nud_Año_informe.Value
            Case "Identificacion"
                FrInformeLegalizacion.TipoInforme = 1
                FrInformeLegalizacion.Identificacion = Tb_IdentificacionInforme.Text
                FrInformeLegalizacion.fecha = DtpFechaIdenti_Informe.Value
            Case "Fecha Desde-Hasta"
                If Dtp_DesdeInforme.Value > Dtp_Hasta_Informe.Value Then
                    MsgBox("La fecha Hasta no puede ser inferior a Desde", MsgBoxStyle.Information, "Advertencia")
                    Exit Sub
                End If
                FrInformeLegalizacion.TipoInforme = 2
                FrInformeLegalizacion.Fecha_Desde = Dtp_DesdeInforme.Value
                FrInformeLegalizacion.Fecha_Hasta = Dtp_Hasta_Informe.Value
        End Select
        FrInformeLegalizacion.ShowDialog()
    End Sub


    Private Sub Cb_FiltrarInforme_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Cb_FiltrarInforme.SelectedIndexChanged
        Select Case Me.Cb_FiltrarInforme.SelectedIndex
            Case 0
                Pn_Consecutivo.Visible = True
                Pn_Identificacion_Informe.Visible = False
                Pn_Fecha_Informe.Visible = False
                Bt_CargarInforme.Visible = True
            Case 1
                Pn_Consecutivo.Visible = False
                Pn_Identificacion_Informe.Visible = True
                Pn_Fecha_Informe.Visible = False
                Bt_CargarInforme.Visible = True
            Case 2
                Pn_Consecutivo.Visible = False
                Pn_Identificacion_Informe.Visible = False
                Pn_Fecha_Informe.Visible = True
                Bt_CargarInforme.Visible = True
        End Select
    End Sub

    Private Sub Cu_Auditoria_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, Dgv_ListaComprobantes.KeyDown, Dgv_ListaConceptos.KeyDown, DGV_ListaLegalización.KeyDown, Nbc_Auditoria.KeyDown
        Select Case e.KeyCode
            Case Keys.F6
                ExportarDatosExcel(DGV_ListaLegalización)
        End Select
    End Sub


    Private Sub Cu_Auditoria_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.DGV_ListaLegalización.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.DGV_ListaLegalización.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaComprobantes.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaComprobantes.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaConceptos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_ListaConceptos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub


    'Private Sub Bt_CargarVer_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Cargar_tablas_ver()
    'End Sub


    'Private Sub Cb_Ver_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    Select Case Me.Cb_Ver.SelectedIndex
    '        Case 0
    '            Dtp_Ver.Visible = False
    '            Tb_ver.Visible = True
    '        Case 1
    '            Dtp_Ver.Visible = False
    '            Tb_ver.Visible = True
    '        Case 2
    '            Dtp_Ver.Visible = True
    '            Tb_ver.Visible = False
    '        Case 3
    '            Dtp_Ver.Visible = False
    '            Tb_ver.Visible = True
    '        Case 4
    '            Dtp_Ver.Visible = False
    '            Tb_ver.Visible = False
    '        Case 5
    '            Dtp_Ver.Visible = False
    '            Tb_ver.Visible = False
    '        Case 6
    '            Dtp_Ver.Visible = False
    '            Tb_ver.Visible = True
    '        Case 7
    '            Dtp_Ver.Visible = False
    '            Tb_ver.Visible = False
    '    End Select
    '    Tb_ver.Text = ""
    'End Sub


    Private Sub Nbi_RestablecerLegalizacion_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_RestablecerLegalizacion.ItemClick
        If Me.DGV_ListaLegalización.Rows.Count > 0 Then
            RecuperarLegalizacion(Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("IDLEGALIZACIONDataGridViewTextBoxColumn").Value)
        End If
        'Cargar_tablas_ver()
    End Sub


    Private Sub Bt_Filtrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Bt_Filtrar.Click
        Dim vista As New DataView(Me.Ds_Auditoria.CONS_LEGALIZACION)
        Me.DGV_ListaLegalización.SuspendLayout()
        Me.DGV_ListaLegalización.DataSource = vista
        Me.DGV_ListaLegalización.ResumeLayout()
        Dim Columna As String = ""
        Select Case Me.ComboBox_Filtrar.SelectedIndex
            Case 0
                Columna = "IDENTIFICACION"
                Try
                    vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
                Catch
                End Try
            Case 1
                Columna = "Nombre"
                Try
                    vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
                Catch
                End Try
            Case 2
                Columna = "FECHALEGALIZACION"
                Try
                    vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Dtp_FechaFiltro.Value))
                Catch
                End Try
            Case 3
                Columna = "Cargo"
                Try
                    vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
                Catch
                End Try
            Case 4
                Columna = "Consecutivo"
                Try
                    vista.RowFilter = String.Format("{0} like '%{1}%'", Columna, Trim(Me.Tb_Descripción.Text))
                Catch
                End Try
        End Select
    End Sub


    Private Sub Nbi_Exportar_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_Exportar.ItemClick
        FuncionesBase.FuncionesBase.GridAExcel(DGV_ListaLegalización, "Impresion Legalizacion " & Date.Now)
    End Sub


    Private Sub Nbi_ImprimirCompensatorio_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_ImprimirCompensatorio.ItemClick
        FuncionesBase.FuncionesBase.GridAExcel(DGV_ListaLegalización, "Impresion Legalizacion " & Date.Now)
    End Sub


    Private Sub Tb_ver_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            'Cargar_tablas_ver()
        End If
    End Sub


    Private Sub Nbi_VerLegalización_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerLegalización.ItemClick
        Index_Registro_Actual = DGV_ListaLegalización.CurrentRow.Index
        Cargar_Auditoria(Me.DGV_ListaLegalización.Rows(DGV_ListaLegalización.CurrentRow.Index).Cells("IDLEGALIZACIONDataGridViewTextBoxColumn").Value, "V")
        Cargar_Tabla()
        Ubicar_Registro()
        Cargar_TablaComprobante_Concepto()
    End Sub


    Private Sub Nbi_CargarLegalización_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarLegalización.ItemClick
        Cargar_Tabla()
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
            With .Range(.Cells(1, 1), .Cells(1, DGV_ListaLegalización.Columns.Count)).Font
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

    Public Sub Cargar_Tabla_Cuadrillas()
        tabla_cargada = ""
        Cursor.Current = Cursors.WaitCursor
        Try
            dsLegalizacion = bddatos.BusquedaCondiciones(40, 1, 4, 1, "", 0, Date.Now, Date.Now, 1, 50)
            If dsLegalizacion.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
                dsLegalizacion.Tables.Remove(dsLegalizacion.Tables(0).TableName) 'borrar la tabla del conteo 
            Else 'si solo trae el conteo es porque se exceden los campos
                MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
                dsLegalizacion.Clear()
            End If
            tabla_cargada = "Legalizaciones"
            DGV_ListaLegalización.DataSource = dsLegalizacion.Tables(0)
            'AplicarFormatoColumnas()
            Lb_ListaLegalizaciones.Text = "Cantidad de Legalizaciones: " + dsLegalizacion.Tables(0).Rows.Count.ToString
            Ubicar_Registro()
        Catch ex As Exception
            '   MsgBox("error al cargar los registros", MsgBoxStyle.Critical, "error")
        End Try
        Try
            DGV_ListaLegalización.Rows(0).Selected = True
        Catch
        End Try
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Nbi_Buscar_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Buscar.ItemClick
        BuscarLegalizacion()
    End Sub

    Private Sub BuscarLegalizacion()

        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")
        campos.Rows.Add("P.IDENTIFICACION", "Identificación (sin puntos)", "2")
        campos.Rows.Add("dbo.Personanombrecompleto(L.IDPERSONA)", "Nombre", "1")
        campos.Rows.Add("L.FECHALEGALIZACION", "Fecha Legalización", "3")
        campos.Rows.Add("TC.NOMBRETIPOCARGO", "Cargo", "1")
        campos.Rows.Add("L.CONSECUTIVO", "Consecutivo", "2")
        campos.Rows.Add("L.ESTADOLEGALIZACION", "Estado Legalización", "1")
        frbuscar.campos = campos
        frbuscar.Text = "Búsqueda de calificación registrada en SIGMA"
        frbuscar.tabla = 40 ' legalizaciones
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsLegalizacion = DSbusqueda
        If Not IsNothing(dsLegalizacion) Then
            If dsLegalizacion.Tables.Count > 0 Then
                If dsLegalizacion.Tables(0).Rows.Count > 0 Then
                    CargarLegalizacionesFiltro(DSbusqueda)
                Else
                    MessageBox.Show("Ningún registro encontrado.")
                End If
            End If
        End If
    End Sub

    Private Sub CargarLegalizacionesFiltro(ByVal DsTabla As DataSet)
        Cursor.Current = Cursors.WaitCursor
        DGV_ListaLegalización.DataSource = Nothing
        DGV_ListaLegalización.DataSource = DsTabla.Tables(0).DefaultView
        tablaCargada = Tablas.Legalizaciones
        'AplicarFormatoColumnas()
        DGV_ListaLegalización.ReadOnly = True
        Lb_ListaLegalizaciones.Text = "Cantidad de Legalizaciones: " + DsTabla.Tables(0).Rows.Count.ToString
        If DGV_ListaLegalización.RowCount > 0 Then
            DGV_ListaLegalización.ClearSelection()
            DGV_ListaLegalización.Rows(0).Selected = True
        End If
        Cursor.Current = Cursors.Default
    End Sub

End Class