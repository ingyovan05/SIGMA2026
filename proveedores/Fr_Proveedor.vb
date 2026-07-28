Imports System.Drawing
Imports System.Data.SqlClient

Public Class Fr_Proveedor

    Public Editando As Boolean = False
    Public IDPROVEEDOREDITANDO As Integer = -1

    Dim DsProveedor As New DatosProveedores.Ds_Proveedor
    Dim TablaRegimen As New DataTable
    Dim ResponsabilidaFrenteIva As New DataTable


    Dim tablagruposuministro As DataTable
    Dim tablaCalificaciónOperativa As DataTable
    Dim tablaproveedordocumento As DataTable
    Dim tablasucursales As DataTable

    Public Sub Creartablaproveedordocumento()
        Try
            Me.tablaproveedordocumento = New DataTable
            tablaproveedordocumento.TableName = "MA_DOCUMENTOPROVEEDOR"
            Me.Dgv_Documentos.DataSource = tablaproveedordocumento
            tablaproveedordocumento.Columns.Add("CODIGODOCUMENTOPROVEEDOR", Type.GetType("System.Byte"))
            Dgv_Documentos.Columns(0).HeaderText = "Id"
            Dgv_Documentos.Columns(0).Frozen = True
            Dgv_Documentos.Columns(0).ReadOnly = True
            Dgv_Documentos.Columns(0).Width = 0
            Dgv_Documentos.Columns(0).Visible = False
            tablaproveedordocumento.Columns.Add("NOMBREDOCUMENTOPROVEEDOR", Type.GetType("System.String"))
            Dgv_Documentos.Columns(1).HeaderText = "Documento"
            Dgv_Documentos.Columns(1).Frozen = True
            Dgv_Documentos.Columns(1).ReadOnly = True
            Dgv_Documentos.Columns(1).Width = 550
            tablaproveedordocumento.Columns.Add("ADJUNTO", Type.GetType("System.Boolean"))
            Dgv_Documentos.Columns(2).HeaderText = "Adjunto"
            Dgv_Documentos.Columns(2).Width = 50
            For i = 0 To dsCargar.Tables(1).Rows.Count - 1
                Dim filaMA As DataRow
                filaMA = dsCargar.Tables(1).Rows(i)
                Dim Fila As DataRow
                Fila = tablaproveedordocumento.NewRow
                Fila("CODIGODOCUMENTOPROVEEDOR") = filaMA("CODIGODOCUMENTOPROVEEDOR")
                Fila("NOMBREDOCUMENTOPROVEEDOR") = filaMA("NOMBREDOCUMENTOPROVEEDOR")
                Dim filasdocpro As DataRow()
                filasdocpro = dsCargar.Tables(13).Select("CODIGODOCUMENTOPROVEEDOR=" + filaMA("CODIGODOCUMENTOPROVEEDOR").ToString)
                If filasdocpro.Length > 0 Then
                    Fila("ADJUNTO") = True
                Else
                    Fila("ADJUNTO") = False
                End If
                tablaproveedordocumento.Rows.Add(Fila)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub CreartablaGrupoSuministro()
        Try
            Me.tablagruposuministro = New DataTable
            tablagruposuministro.TableName = "GRUPOSUMINISTROMATERIAL"
            Me.Dgv_Suministros.DataSource = tablagruposuministro
            tablagruposuministro.Columns.Add("CODIGOGRUPOSUMINISTROMATERIAL", Type.GetType("System.Int32"))
            Dgv_Suministros.Columns(0).HeaderText = "Id"
            Dgv_Suministros.Columns(0).Frozen = True
            Dgv_Suministros.Columns(0).ReadOnly = True
            Dgv_Suministros.Columns(0).Width = 0
            Dgv_Suministros.Columns(0).Visible = False
            tablagruposuministro.Columns.Add("NOMBREGRUPOSUMINISTROMATERIAL", Type.GetType("System.String"))
            Dgv_Suministros.Columns(1).HeaderText = "Grupo"
            Dgv_Suministros.Columns(1).Frozen = True
            Dgv_Suministros.Columns(1).ReadOnly = True
            Dgv_Suministros.Columns(1).Width = 530
            tablagruposuministro.Columns.Add("SUMINISTRA", Type.GetType("System.Boolean"))
            Dgv_Suministros.Columns(2).HeaderText = "Suministra"
            Dgv_Suministros.Columns(2).Width = 70
            For i = 0 To dsCargar.Tables(2).Rows.Count - 1
                Dim filaMA As DataRow
                filaMA = dsCargar.Tables(2).Rows(i)
                Dim Fila As DataRow
                Fila = tablagruposuministro.NewRow
                Fila("CODIGOGRUPOSUMINISTROMATERIAL") = filaMA("CODIGOGRUPOSUMINISTROMATERIAL")
                Fila("NOMBREGRUPOSUMINISTROMATERIAL") = filaMA("NOMBREGRUPOSUMINISTROMATERIAL")
                Dim filasGrupSum As DataRow()
                filasGrupSum = dsCargar.Tables(12).Select("CODIGOGRUPOSUMINISTROMATERIAL=" + filaMA("CODIGOGRUPOSUMINISTROMATERIAL").ToString)
                If filasGrupSum.Length > 0 Then
                    Fila("SUMINISTRA") = True
                Else
                    Fila("SUMINISTRA") = False
                End If
                tablagruposuministro.Rows.Add(Fila)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub CreartablaCalificaciónOperativa()
        Try
            Me.tablaCalificaciónOperativa = New DataTable
            tablaCalificaciónOperativa.TableName = "CALIFICACIÓNOPERATIVA"
            Me.Dgv_CalificaciónOperativa.DataSource = tablaCalificaciónOperativa
            tablaCalificaciónOperativa.Columns.Add("CODIGOCALIFICACIONOPERATIVA", Type.GetType("System.Int32"))
            Dgv_CalificaciónOperativa.Columns(0).HeaderText = "Id"
            Dgv_CalificaciónOperativa.Columns(0).Frozen = True
            Dgv_CalificaciónOperativa.Columns(0).ReadOnly = True
            Dgv_CalificaciónOperativa.Columns(0).Width = 0
            Dgv_CalificaciónOperativa.Columns(0).Visible = False
            tablaCalificaciónOperativa.Columns.Add("DESCRIPCIONCALIFICACIONOPERATIVA", Type.GetType("System.String"))
            Dgv_CalificaciónOperativa.Columns(1).HeaderText = "Descripción"
            Dgv_CalificaciónOperativa.Columns(1).Frozen = True
            Dgv_CalificaciónOperativa.Columns(1).ReadOnly = True
            Dgv_CalificaciónOperativa.Columns(1).Width = 530
            tablaCalificaciónOperativa.Columns.Add("CUMPLE", Type.GetType("System.Boolean"))
            Dgv_CalificaciónOperativa.Columns(2).HeaderText = "Cumple"
            Dgv_CalificaciónOperativa.Columns(2).Width = 70
            For i = 0 To dsCargar.Tables(15).Rows.Count - 1
                Dim filaMA As DataRow
                filaMA = dsCargar.Tables(15).Rows(i)
                Dim Fila As DataRow
                Fila = tablaCalificaciónOperativa.NewRow
                Fila("CODIGOCALIFICACIONOPERATIVA") = filaMA("CODIGOCALIFICACIONOPERATIVA")
                Fila("DESCRIPCIONCALIFICACIONOPERATIVA") = filaMA("DESCRIPCIONCALIFICACIONOPERATIVA")
                Dim filasCalifOpera As DataRow()
                filasCalifOpera = dsCargar.Tables(16).Select("CODIGOCALIFICACIONOPERATIVA=" + filaMA("CODIGOCALIFICACIONOPERATIVA").ToString)
                If filasCalifOpera.Length > 0 Then
                    Fila("CUMPLE") = True
                Else
                    Fila("CUMPLE") = False
                End If
                tablaCalificaciónOperativa.Rows.Add(Fila)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub Comportamiento_Predeterminado()
        Me.Dgv_Suministros.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Suministros.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Sucursal.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Sucursal.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Documentos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Me.Dgv_Documentos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
    End Sub


    Dim dsCargar As New DataSet
    Private bddatos As New FuncionesBase.ClaseCargarMaestras

    Public Sub Cargar_Tablas()


        '-- 0  --> PROVEEDOR
        '-- 1  --> MA_DOCUMENTOPROVEEDOR
        '-- 2  --> MA_GRUPOSUMINISTROMATERIAL
        '-- 3  --> SUCURSALPROVEEDOR
        '-- 4  --> ResponsabilidaFrenteIva
        '-- 5  --> TablaRegimen
        '-- 6  --> MA_POBLACION
        '-- 7  -->MA_TIPOIDENTIFICACION
        '-- 8  --> MA_CONDICIONPAGO
        '-- 9 --> MA_TIPOENTIDADFINANCIERA
        '-- 10 --> MA_TIPOCUENTA
        '-- 11 --> MA_ACTIVIDADECONOMICADIAN
        '-- 12 --> PROVEEDORGRUPOSUMINISTROMATERIAL
        '-- 13  --> PROVEEDORDOCUMENTO
        '-- 14 --> SUCURSALPROVEEDOR
        '-- 15 --> MA_CALIFICACIONOPERATIVA
        '-- 16 --> PROVEEDORCALIFICACIONOPERATIVA

        Dim identificador As Long
        Dim tipo As Integer

        If IDPROVEEDOREDITANDO < 0 Then
            identificador = -1
            tipo = 1 'Crear
        Else
            identificador = IDPROVEEDOREDITANDO
            tipo = 2 'Editar
        End If


        dsCargar = bddatos.CargarMaestrasMateriales(11, VariablesBase.VariablesBase.IdBodegaActual, identificador, tipo)


        Me.Cb_ResponsabilidadIVA.DataSource = dsCargar.Tables(4)
        Me.Cb_ResponsabilidadIVA.DisplayMember = "NOMBRE"
        Me.Cb_ResponsabilidadIVA.ValueMember = "CODIGO"
        Me.Cb_ResponsabilidadIVA.SelectedIndex = -1


        Me.Cb_RegimenImpuesto.DataSource = dsCargar.Tables(5)
        Me.Cb_RegimenImpuesto.DisplayMember = "NOMBRE"
        Me.Cb_RegimenImpuesto.ValueMember = "CODIGO"
        Me.Cb_RegimenImpuesto.SelectedIndex = -1


        Me.Cu_CiudadDirección.Cb_Ciudad.DataSource = dsCargar.Tables(6)
        Me.Cu_CiudadFabril.Cb_Ciudad.DataSource = dsCargar.Tables(6)
        Me.Cu_CiudadSucursal.Cb_Ciudad.DataSource = dsCargar.Tables(6)

        Me.Cb_TipoIdentificación.DataSource = dsCargar.Tables(7)
        Me.Cb_TipoIdentificación.DisplayMember = "NOMBRETIPOIDENTIFICACION"
        Me.Cb_TipoIdentificación.ValueMember = "CODIGOTIPOIDENTIFICACION"
        Me.Cb_TipoIdentificación.SelectedIndex = -1

        Me.Cb_CondiciónPago.DataSource = dsCargar.Tables(8)
        Me.Cb_CondiciónPago.DisplayMember = "NOMBRECONDICIONPAGO"
        Me.Cb_CondiciónPago.ValueMember = "CODIGOCONDICIONPAGO"
        Me.Cb_CondiciónPago.SelectedIndex = -1

        Me.Cb_Banco.DataSource = dsCargar.Tables(9)
        Me.Cb_Banco.DisplayMember = "NOMBREENTIDADFINANCIERA"
        Me.Cb_Banco.ValueMember = "CODIGOENTIDADFINANCIERA"
        Me.Cb_Banco.SelectedIndex = -1

        Me.Cb_TipoCuenta.DataSource = dsCargar.Tables(10)
        Me.Cb_TipoCuenta.DisplayMember = "NOMBRETIPOCUENTA"
        Me.Cb_TipoCuenta.ValueMember = "CODIGOTIPOCUENTA"
        Me.Cb_TipoCuenta.SelectedIndex = -1

        Me.Cb_ActividadPrincipal.DataSource = dsCargar.Tables(11)
        Me.Cb_ActividadPrincipal.DisplayMember = "NOMBREACTIVIDADECONOMICA"
        Me.Cb_ActividadPrincipal.ValueMember = "IDACTIVIDADECONOMICADIAN"
        Me.Cb_ActividadPrincipal.SelectedIndex = -1


        CargarProveedor()
        CreartablaGrupoSuministro()
        Creartablaproveedordocumento()
        CreartablaCalificaciónOperativa()

        'Cargar Sucursales
        Me.tablasucursales = dsCargar.Tables(14)
        Me.Dgv_Sucursal.DataSource = tablasucursales


        Comportamiento_Predeterminado()
        Marcar_Cajas_Vacias()

    End Sub

    Private Sub CargarProveedor()
        If Editando = True Then
            Dim fila As DataRow = dsCargar.Tables(0).Rows(0)
            Me.Tx_Nombre.Text = Trim(fila("NOMBRE"))
            Me.Cb_TipoIdentificación.SelectedValue = fila("CODIGOTIPOIDENTIFICACION")
            Me.Tx_Identificación.Text = Trim(fila("IDENTIFICACION"))
            Me.Tx_Nomenclatura.Text = Trim(fila("NOMENCLATURA"))
            Me.Tx_DigitoVerificación.Text = Trim(fila("DIGITOVERIFICACION"))
            Me.Tx_PrimerNombre.Text = Trim(fila("PRIMERNOMBRE"))
            Me.Tx_SegundoNombre.Text = Trim(fila("SEGUNDONOMBRE"))
            Me.Tx_PrimerApellido.Text = Trim(fila("PRIMERAPELLIDO"))
            Me.Tx_SegundoApellido.Text = Trim(fila("SEGUNDOAPELLIDO"))
            Me.Tx_Dirección.Text = Trim(fila("DIRECCION"))
            Me.Cu_CiudadDirección.Cb_Ciudad.SelectedValue = fila("CODIGOCIUDADDIRECCION")
            Me.Tx_Teléfono.Text = Trim(fila("TELEFONO"))
            Me.Tx_TeléfonoMóvil.Text = Trim(fila("CELULAR"))
            Me.Tx_CorreoElectrónico.Text = Trim(fila("EMAIL"))
            Me.TextBox_Fax.Text = Trim(fila("FAX"))
            Me.TextBox_NombreRL.Text = Trim(fila("NOMBREREPRESENTANTELEGAL"))
            Me.TextBox_TeléfonoRL.Text = Trim(fila("TELEFONOREPRESENTANTELEGAL"))
            Me.TextBox_TeléfonoMóvilRL.Text = Trim(fila("CELULARREPRESENTANTELEGAL"))
            Me.TextBox_CorreoElectrónicoRL.Text = Trim(fila("EMAILREPRESENTANTELEGAL"))
            Me.TextBox_NombreVenta.Text = Trim(fila("NOMBREREPRESENTANTEVENTA"))
            Me.TextBox_TeléfonoV.Text = Trim(fila("TELEFONOREPRESENTANTEVENTA"))
            Me.TextBox_TeléfonoMóvilV.Text = Trim(fila("CELULARREPRESENTANTEVENTA"))
            Me.TextBox_CorreoElectrónicoV.Text = Trim(fila("EMAILREPRESENTANTEVENTA"))
            Me.Cb_RegimenImpuesto.SelectedValue = fila("REGIMENIMPUESTORENTA")
            Me.Cb_ResponsabilidadIVA.SelectedValue = fila("RESPONSABILIDADFRENTEIVA")

            If IsDBNull(fila("GRANCONTRIBUYENTE")) Then
                Me.Rb_GranContribuyenteNo.Checked = True
            Else
                If fila("GRANCONTRIBUYENTE") = "I" Then
                    Me.Rb_GranContribuyenteSI.Checked = True
                Else
                    Me.Rb_GranContribuyenteNo.Checked = True
                End If

            End If

            If IsDBNull(fila("AGENTERETENEDOR")) Then
                Me.Rb_AgenteReteneedorNo.Checked = True
            Else
                If fila("AGENTERETENEDOR") = "I" Then
                    Me.Rb_AgenteReteneedorSI.Checked = True
                Else
                    Me.Rb_AgenteReteneedorNo.Checked = True
                End If
            End If

            If IsDBNull(fila("AUTORETENEDOR")) Then
                Me.Rb_AutoretenedorNo.Checked = True
            Else
                If fila("AUTORETENEDOR") = "I" Then
                    Me.Rb_AutoretenedorSI.Checked = True
                Else
                    Me.Rb_AutoretenedorNo.Checked = True
                End If

            End If


            Me.NRORESOLUCIONAGENTETextBox.Text = Trim(fila("NRORESOLUCIONAGENTE"))
            If IsDBNull(fila("FECHARESOLUCIONAGENTE")) Then
                Me.FECHARESOLUCIONAGENTEDateTimePicker.Checked = False
            Else
                Me.FECHARESOLUCIONAGENTEDateTimePicker.Checked = True
                Me.FECHARESOLUCIONAGENTEDateTimePicker.Value = fila("FECHARESOLUCIONAGENTE")
            End If

            Me.NRORESOLUCIONAUTORETENEDORTextBox.Text = Trim(fila("NRORESOLUCIONAUTORETENEDOR"))
            If IsDBNull(fila("FECHARESOLUCIONAUTORETENEDOR")) Then
                Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.Checked = False
            Else
                Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.Checked = True
                Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.Value = fila("FECHARESOLUCIONAUTORETENEDOR")
            End If


            If IsDBNull(fila("ACTIVIDADINDUSTRIAL")) Then
                Me.Rb_ActividadIndustrialNo.Checked = False
            Else
                If fila("ACTIVIDADINDUSTRIAL") = "I" Then
                    Me.Rb_ActividadIndustrialSi.Checked = True
                Else
                    Me.Rb_ActividadIndustrialNo.Checked = True
                End If
            End If

            If IsDBNull(fila("ESTADO")) Then
                Me.Cb_Activo.Checked = False
            Else
                If fila("ESTADO") = 1 Then
                    Me.Cb_Activo.Checked = True
                Else
                    Me.Cb_Activo.Checked = False
                End If
            End If


            Me.TARIFAICATextBox.Text = Trim(fila("TARIFAICA").ToString)
            Me.Cu_CiudadFabril.Cb_Ciudad.SelectedValue = fila("CIUDADSEDEFABRIL")
            Me.Cb_CondiciónPago.SelectedValue = fila("CODIGOCONDICIONPAGO")
            Me.CUPOTextBox.Text = fila("CUPO")
            Nud_Descuento.Value = fila("DESCUENTO")
            Me.Cb_Banco.SelectedValue = fila("CODIGOENTIDADFINANCIERA")
            Me.SUCURSALENTIDADFINANCIERATextBox.Text = Trim(fila("SUCURSALENTIDADFINANCIERA"))
            Me.TextBox_NumeroCuenta.Text = Trim(fila("NROCUENTA"))
            Me.TITURALCUENTATextBox.Text = Trim(fila("TITURALCUENTA"))
            Me.IDENTIFICACIONTITULARCUENTATextBox.Text = Trim(fila("IDENTIFICACIONTITULARCUENTA"))
            Me.Cb_TipoCuenta.SelectedValue = fila("CODIGOTIPOCUENTA")
            Me.CONTACTOCARTERAENTIDADFINANCIERATextBox.Text = Trim(fila("CONTACTOCARTERAENTIDADFINANCIERA"))
            Me.OBSERVACIONFINANCIERATextBox.Text = Trim(fila("OBSERVACIONFINANCIERA"))
            Me.Cb_ActividadPrincipal.SelectedValue = fila("CODIGOACTIVIDADECONOMICADIAN")
            If IsDBNull(fila("OTROCUAL")) = False Then
                Me.Tb_Otros.Text = Trim(fila("OTROCUAL"))
            End If

        End If
    End Sub

    Private Sub Caja_Texto_GotFocus _
   (ByVal sender As Object, ByVal e As System.EventArgs) _
   Handles Cb_TipoIdentificación.GotFocus, Tx_Identificación.GotFocus, Tx_Nomenclatura.GotFocus, Tx_Nombre.GotFocus,
        Tx_PrimerNombre.GotFocus, Tx_SegundoNombre.GotFocus, Tx_PrimerApellido.GotFocus, Tx_SegundoApellido.GotFocus,
        Tx_Teléfono.GotFocus, Tx_CorreoElectrónico.GotFocus,
        Tx_Dirección.GotFocus, TextBox_NombreRL.GotFocus, TextBox_NombreVenta.GotFocus, CUPOTextBox.GotFocus
        Dim Objeto As Object = sender
        Objeto.backcolor = Color.MintCream
    End Sub

    Private Sub TextBox_PrimerNombre_LostFocus _
    (ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Cb_TipoIdentificación.LostFocus, Tx_Identificación.LostFocus, Tx_Nomenclatura.GotFocus, Tx_Nombre.LostFocus,
        Tx_PrimerNombre.LostFocus, Tx_SegundoNombre.LostFocus, Tx_PrimerApellido.LostFocus, Tx_SegundoApellido.LostFocus,
        Tx_Teléfono.LostFocus, Tx_CorreoElectrónico.LostFocus,
        Tx_Dirección.LostFocus, TextBox_NombreRL.LostFocus, TextBox_NombreVenta.LostFocus, CUPOTextBox.LostFocus
        Dim Objeto As Object = sender
        Objeto.backcolor = Color.White
        If sender.text = "" Or sender.text = "SIN INFORMACION" Or _
          sender.text = "SE DESCONOCE" Or sender.text = "SIN IDENTIFICAR" Then
            sender.backcolor = Color.Salmon
        End If
        'Marcar_Cajas_Vacias()
    End Sub

    Private Sub Marcar_Cajas_Vacias()
        If Me.Cu_CiudadDirección.Cb_Ciudad.Text = "SIN INFORMACION" Then
            Me.Cu_CiudadDirección.Cb_Ciudad.BackColor = Color.Salmon
        Else
            Me.Cu_CiudadDirección.Cb_Ciudad.BackColor = Color.White
        End If
        If Tx_PrimerNombre.Text = "" Then
            Tx_PrimerNombre.BackColor = Color.Salmon
        Else
            Tx_PrimerNombre.BackColor = Color.White
        End If
        If Tx_SegundoNombre.Text = "" Then
            Tx_SegundoNombre.BackColor = Color.Salmon
        Else
            Tx_SegundoNombre.BackColor = Color.White
        End If
        If Tx_PrimerApellido.Text = "" Then
            Tx_PrimerApellido.BackColor = Color.Salmon
        Else
            Tx_PrimerApellido.BackColor = Color.White
        End If
        If Tx_SegundoApellido.Text = "" Then
            Tx_SegundoApellido.BackColor = Color.Salmon
        Else
            Tx_SegundoApellido.BackColor = Color.White
        End If
        If Cb_TipoIdentificación.Text = "SIN INFORMACION" Then
            Cb_TipoIdentificación.BackColor = Color.Salmon
        Else
            Cb_TipoIdentificación.BackColor = Color.White
        End If
        If Tx_Identificación.Text = "" Then
            Tx_Identificación.BackColor = Color.Salmon
        Else
            Tx_Identificación.BackColor = Color.White
        End If
        If Me.Cu_CiudadDirección.Cb_Ciudad.Text = "SIN INFORMACION" Then
            Cu_CiudadDirección.BackColor = Color.Salmon
        Else
            Cu_CiudadDirección.BackColor = Color.White
        End If
        If Tx_Dirección.Text = "" Then
            Tx_Dirección.BackColor = Color.Salmon
        Else
            Tx_Dirección.BackColor = Color.White
        End If
        If Tx_Teléfono.Text = "" Then
            Tx_Teléfono.BackColor = Color.Salmon
        Else
            Tx_Teléfono.BackColor = Color.White
        End If
        If Tx_TeléfonoMóvil.Text = "" Then
            Tx_TeléfonoMóvil.BackColor = Color.Salmon
        Else
            Tx_TeléfonoMóvil.BackColor = Color.White
        End If
        If Tx_CorreoElectrónico.Text = "" Then
            Tx_CorreoElectrónico.BackColor = Color.Salmon
        Else
            Tx_CorreoElectrónico.BackColor = Color.White
        End If
        If Tx_Nombre.Text = "" Then
            Tx_Nombre.BackColor = Color.Salmon
        Else
            Tx_Nombre.BackColor = Color.White
        End If
        If TextBox_NombreRL.Text = "" Then
            TextBox_NombreRL.BackColor = Color.Salmon
        Else
            TextBox_NombreRL.BackColor = Color.White
        End If
        If TextBox_NombreVenta.Text = "" Then
            TextBox_NombreVenta.BackColor = Color.Salmon
        Else
            TextBox_NombreVenta.BackColor = Color.White
        End If
        If CUPOTextBox.Text = "" Then
            CUPOTextBox.BackColor = Color.Salmon
        Else
            CUPOTextBox.BackColor = Color.White
        End If
        If Tx_Nomenclatura.Text = "" Then
            Tx_Nomenclatura.BackColor = Color.Salmon
        Else
            Tx_Nomenclatura.BackColor = Color.White
        End If
    End Sub

    Private Sub Bt_Guardar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Guardar.Click
        Try
            If ValidarProveedor() = True Then
                GuardarNuevoProveedor()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Function ValidarProveedor() As Boolean
        If Me.Cb_TipoIdentificación.SelectedIndex = -1 Then
            MsgBox("Debe especificar el tipo de identifiación del proveedor", MsgBoxStyle.Critical, "Tipo de Identificación del Proveedor")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.Cb_TipoIdentificación.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Trim(Me.Tx_Identificación.Text) = "" Then
            MsgBox("Debe especificar la identificación del proveedor", MsgBoxStyle.Critical, "Identificación Proveedor")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.Tx_Identificación.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If IsNumeric(Me.Tx_Identificación.Text) = False Then
            MsgBox("Identificación del proveedor no valida", MsgBoxStyle.Critical, "Identificación Proveedor")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.Tx_Identificación.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Trim(Me.Tx_Nombre.Text) = "" And Trim(Me.Tx_PrimerNombre.Text) = "" Then
            MsgBox("Debe especificar el nombre del proveedor", MsgBoxStyle.Critical, "Nombre Proveedor")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.Tx_Nombre.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Trim(Me.Tx_Nomenclatura.Text) = "" And Trim(Me.Tx_PrimerNombre.Text) = "" Then
            MsgBox("Debe especificar la nomenclatura del Proveedor (Máximo 3 Caracteres)", MsgBoxStyle.Critical, "Nomenclatura Proveedor")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.Tx_Nomenclatura.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Trim(Me.Tx_Dirección.Text) = "" Then
            MsgBox("Debe especificar la dirección del proveedor", MsgBoxStyle.Critical, "Dirección Proveedor")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.Tx_Dirección.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Me.Cu_CiudadDirección.Cb_Ciudad.Text = "" Or Me.Cu_CiudadDirección.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la ciudad o municipio de la dirección.", MsgBoxStyle.Critical, "Ciudad de Origen")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.Cu_CiudadDirección.Cb_Ciudad.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Trim(Me.Tx_Teléfono.Text) = "" Then
            MsgBox("Debe especificar el teléfono del proveedor", MsgBoxStyle.Critical, "Teléfono Proveedor")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.Tx_Teléfono.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Trim(Me.Tx_TeléfonoMóvil.Text) = "" Then
            MsgBox("Debe especificar el teléfono móvil del proveedor", MsgBoxStyle.Critical, "Teléfono Móvil Proveedor")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.Tx_TeléfonoMóvil.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Trim(Me.Tx_CorreoElectrónico.Text) = "" Then
            MsgBox("Debe especificar el correo electrónico del proveedor", MsgBoxStyle.Critical, "Teléfono Móvil Proveedor")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.Tx_CorreoElectrónico.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Me.Tx_CorreoElectrónico.Text.IndexOf("@") = -1 Then
            MsgBox("El correo electrónico no cumple con el formato.", MsgBoxStyle.Critical, "Correo Electrónico")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.Tx_CorreoElectrónico.Focus()
            ValidarProveedor = False
            Exit Function
        Else
            If Me.Tx_CorreoElectrónico.Text.IndexOf("@") = (Me.Tx_CorreoElectrónico.Text.Length - 1) Then
                MsgBox("El correo electrónico no cumple con el formato.", MsgBoxStyle.Critical, "Correo Electrónico")
                Me.Tc_Proveedor.SelectedIndex = 0
                Me.Tx_CorreoElectrónico.Focus()
                ValidarProveedor = False
                Exit Function
            End If
        End If


        If Trim(Me.TextBox_NombreRL.Text) = "" Then
            MsgBox("Indique el nombre del representante legal.", MsgBoxStyle.Critical, "Nombre Representante Legal")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.TextBox_NombreRL.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Trim(Me.TextBox_NombreVenta.Text) = "" Then
            MsgBox("Indique el nombre del representante de ventas.", MsgBoxStyle.Critical, "Nombre Representante Venta")
            Me.Tc_Proveedor.SelectedIndex = 0
            Me.TextBox_NombreVenta.Focus()
            ValidarProveedor = False
            Exit Function
        End If


        If Me.Cb_RegimenImpuesto.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el regimen de impuesto de Renta del proveedor", MsgBoxStyle.Critical, "Regimen de Impuesto de Renta Proveedor")
            Me.Tc_Proveedor.SelectedIndex = 1
            Me.Cb_RegimenImpuesto.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Me.Cb_ResponsabilidadIVA.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar al responsabilidad frente al IVA del proveedor", MsgBoxStyle.Critical, "Responsabilidad Frente al IVA Proveedor")
            Me.Tc_Proveedor.SelectedIndex = 1
            Me.Cb_ResponsabilidadIVA.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Me.Cb_ActividadPrincipal.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la actividad económica principal", MsgBoxStyle.Critical, "Actividad Económica Principal")
            Me.Tc_Proveedor.SelectedIndex = 1
            Me.Cb_ActividadPrincipal.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Me.Rb_GranContribuyenteSI.Checked = False And Me.Rb_GranContribuyenteNo.Checked = False Then
            MsgBox("Indique si es gran contribuyente o no", MsgBoxStyle.Critical, "Gran Contribuyente")
            Me.Tc_Proveedor.SelectedIndex = 1
            Me.Gb_GranContribuyente.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Me.Rb_AgenteReteneedorSI.Checked = False And Me.Rb_AgenteReteneedorNo.Checked = False Then
            MsgBox("Indique si es agente retenedor", MsgBoxStyle.Critical, "Agente Retenedor")
            Me.Tc_Proveedor.SelectedIndex = 1
            Me.Gb_AgenteReteneedor.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Me.Rb_AutoretenedorSI.Checked = False And Me.Rb_AutoretenedorNo.Checked = False Then
            MsgBox("Indique si es autoretenedor", MsgBoxStyle.Critical, "Autoretenedor")
            Me.Tc_Proveedor.SelectedIndex = 1
            Me.Gb_Autoretenedor.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Me.Rb_ActividadIndustrialSi.Checked = False And Me.Rb_ActividadIndustrialNo.Checked = False Then
            MsgBox("Indique si es tiene actividad industrial", MsgBoxStyle.Critical, "Actividad Industrial")
            Me.Tc_Proveedor.SelectedIndex = 1
            Me.Gb_ActividadIndustrial.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Me.Cb_CondiciónPago.SelectedIndex = -1 Then
            MsgBox("Seleccione la condición de pago", MsgBoxStyle.Critical, "Condición de pago")
            Me.Tc_Proveedor.SelectedIndex = 2
            Me.Cb_CondiciónPago.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Me.Cb_Banco.SelectedIndex = -1 Then
            MsgBox("Seleccione el banco", MsgBoxStyle.Critical, "Banco")
            Me.Tc_Proveedor.SelectedIndex = 2
            Me.Cb_Banco.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        If Me.Cb_TipoCuenta.SelectedIndex = -1 Then
            MsgBox("Seleccione el tipo de cuenta", MsgBoxStyle.Critical, "Tipo de cuenta")
            Me.Tc_Proveedor.SelectedIndex = 2
            Me.Cb_TipoCuenta.Focus()
            ValidarProveedor = False
            Exit Function
        End If

        For i = 0 To tablagruposuministro.Rows.Count - 1
            Dim filagruposuministro As DataRow
            filagruposuministro = tablagruposuministro.Rows(i)
            If IsDBNull(filagruposuministro("SUMINISTRA")) = False Then
                If filagruposuministro("SUMINISTRA") = True Then
                    If filagruposuministro("CODIGOGRUPOSUMINISTROMATERIAL") = "33" Then
                        If Tb_Otros.Text = "" Then
                            MsgBox("Digite otros suministros", MsgBoxStyle.Critical, "Suministro")
                            Tb_Otros.Focus()
                            Me.Tc_Proveedor.SelectedIndex = 4
                            ValidarProveedor = False
                            Exit Function
                        End If
                    End If
                End If

                If filagruposuministro("SUMINISTRA") = False Then
                    If Tb_Otros.Text <> "" Then
                        If filagruposuministro("CODIGOGRUPOSUMINISTROMATERIAL") = "33" Then
                            MsgBox("Selecciones OTROS (especifique)", MsgBoxStyle.Critical, "Suministro")
                            Tb_Otros.Focus()
                            Me.Tc_Proveedor.SelectedIndex = 4
                            ValidarProveedor = False
                            Exit Function
                        End If
                    End If
                End If
            End If
        Next

        ValidarProveedor = True
    End Function



    Private Sub GuardarNuevoProveedor()
        Dim Fila As DataRow

        'Crear tabla @TablePROVEEDORDOCUMENTO
        Dim TablePROVEEDORDOCUMENTO As New DataTable
        TablePROVEEDORDOCUMENTO.Columns.Add("CODIGODOCUMENTOPROVEEDOR")
        TablePROVEEDORDOCUMENTO.Columns.Add("IDPROVEEDOR")

        For i = 0 To tablaproveedordocumento.Rows.Count - 1
            Dim filaDocumento As DataRow
            filaDocumento = tablaproveedordocumento.Rows(i)
            If IsDBNull(filaDocumento("ADJUNTO")) = False Then
                If filaDocumento("ADJUNTO") = True Then
                    Fila = TablePROVEEDORDOCUMENTO.NewRow
                    Fila("CODIGODOCUMENTOPROVEEDOR") = filaDocumento("CODIGODOCUMENTOPROVEEDOR")
                    Fila("IDPROVEEDOR") = IDPROVEEDOREDITANDO
                    TablePROVEEDORDOCUMENTO.Rows.Add(Fila)
                End If
            End If
        Next

        'Crear tabla @TablePROVEEDORGRUPOSUMINISTROMATERIAL
        Dim TablePROVEEDORGRUPOSUMINISTROMATERIAL As New DataTable
        TablePROVEEDORGRUPOSUMINISTROMATERIAL.Columns.Add("CODIGOGRUPOSUMINISTROMATERIAL")
        TablePROVEEDORGRUPOSUMINISTROMATERIAL.Columns.Add("IDPROVEEDOR")

        For i = 0 To tablagruposuministro.Rows.Count - 1
            Dim filagruposuministro As DataRow
            filagruposuministro = tablagruposuministro.Rows(i)
            If IsDBNull(filagruposuministro("SUMINISTRA")) = False Then
                If filagruposuministro("SUMINISTRA") = True Then
                    Fila = TablePROVEEDORGRUPOSUMINISTROMATERIAL.NewRow
                    Fila("CODIGOGRUPOSUMINISTROMATERIAL") = filagruposuministro("CODIGOGRUPOSUMINISTROMATERIAL")
                    Fila("IDPROVEEDOR") = IDPROVEEDOREDITANDO
                    TablePROVEEDORGRUPOSUMINISTROMATERIAL.Rows.Add(Fila)
                End If
            End If
        Next

        'Crear tabla @TablePROVEEDORCALIFICACIONOPERATIVA
        Dim TablePROVEEDORCALIFICACIONOPERATIVA As New DataTable
        TablePROVEEDORCALIFICACIONOPERATIVA.Columns.Add("CODIGOCALIFICACIONOPERATIVA")
        TablePROVEEDORCALIFICACIONOPERATIVA.Columns.Add("IDPROVEEDOR")

        For i = 0 To tablaCalificaciónOperativa.Rows.Count - 1
            Dim filaCalificaciónOperativa As DataRow
            filaCalificaciónOperativa = tablaCalificaciónOperativa.Rows(i)
            If IsDBNull(filaCalificaciónOperativa("CUMPLE")) = False Then
                If filaCalificaciónOperativa("CUMPLE") = True Then
                    Fila = TablePROVEEDORCALIFICACIONOPERATIVA.NewRow
                    Fila("CODIGOCALIFICACIONOPERATIVA") = filaCalificaciónOperativa("CODIGOCALIFICACIONOPERATIVA")
                    Fila("IDPROVEEDOR") = IDPROVEEDOREDITANDO
                    TablePROVEEDORCALIFICACIONOPERATIVA.Rows.Add(Fila)
                End If
            End If
        Next



        'Crear tabla @TableSUCURSALPROVEEDOR
        Dim TableSUCURSALPROVEEDOR As New DataTable
        TableSUCURSALPROVEEDOR.Columns.Add("IDSUCURSALPROVEEDOR")
        TableSUCURSALPROVEEDOR.Columns.Add("IDPROVEEDOR")
        TableSUCURSALPROVEEDOR.Columns.Add("CODIGOCIUDADDIRECCION")
        TableSUCURSALPROVEEDOR.Columns.Add("DIRECCION")
        TableSUCURSALPROVEEDOR.Columns.Add("TELEFONO")
        TableSUCURSALPROVEEDOR.Columns.Add("CELULAR")
        TableSUCURSALPROVEEDOR.Columns.Add("EMAIL")
        TableSUCURSALPROVEEDOR.Columns.Add("NOMBREREPRESENTANTEVENTA")
        TableSUCURSALPROVEEDOR.Columns.Add("TELEFONOREPRESENTANTEVENTA")
        TableSUCURSALPROVEEDOR.Columns.Add("CELULARREPRESENTANTEVENTA")
        TableSUCURSALPROVEEDOR.Columns.Add("EMAILREPRESENTANTEVENTA")


        For i = 0 To tablasucursales.Rows.Count - 1
            Dim filasucursal As DataRow

            filasucursal = tablasucursales.Rows(i)

            Fila = TableSUCURSALPROVEEDOR.NewRow
            Fila("IDSUCURSALPROVEEDOR") = -1
            Fila("IDPROVEEDOR") = IDPROVEEDOREDITANDO
            Try
                Fila("CODIGOCIUDADDIRECCION") = filasucursal("CODIGOCIUDADDIRECCION")
                Fila("DIRECCION") = filasucursal("DIRECCION")
                Fila("TELEFONO") = filasucursal("TELEFONO")
                Fila("CELULAR") = filasucursal("CELULAR")
                Fila("EMAIL") = filasucursal("EMAIL")
                Fila("NOMBREREPRESENTANTEVENTA") = filasucursal("REPRESENTANTE")
                Fila("TELEFONOREPRESENTANTEVENTA") = filasucursal("TELEFONO REPRESENTANTE")
                Fila("CELULARREPRESENTANTEVENTA") = filasucursal("CELULAR REPRESENTANTE")
                Fila("EMAILREPRESENTANTEVENTA") = filasucursal("EMAILREPRESENTANTE")
                TableSUCURSALPROVEEDOR.Rows.Add(Fila)
            Catch ex As Exception

            End Try
        Next

        'Llamar al procedimiento para crear el tipo categoría
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarProveedor")
        Comando.CommandType = CommandType.StoredProcedure
        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 2)
        End If

        Comando.Parameters.AddWithValue("@TablePROVEEDORDOCUMENTO", TablePROVEEDORDOCUMENTO)
        Comando.Parameters.AddWithValue("@TablePROVEEDORGRUPOSUMINISTROMATERIAL", TablePROVEEDORGRUPOSUMINISTROMATERIAL)
        Comando.Parameters.AddWithValue("@TableSUCURSALPROVEEDOR", TableSUCURSALPROVEEDOR)
        Comando.Parameters.AddWithValue("@TablePROVEEDORCALIFICACIONOPERATIVA", TablePROVEEDORCALIFICACIONOPERATIVA)

        Comando.Parameters.AddWithValue("@IDPROVEEDOR", IDPROVEEDOREDITANDO)

        Comando.Parameters.AddWithValue("@NOMBRE", Trim(Me.Tx_Nombre.Text))
        Comando.Parameters.AddWithValue("@CODIGOTIPOIDENTIFICACION", Me.Cb_TipoIdentificación.SelectedValue)
        Comando.Parameters.AddWithValue("@IDENTIFICACION", Trim(Me.Tx_Identificación.Text))
        Comando.Parameters.AddWithValue("@NOMENCLATURA", Trim(Me.Tx_Nomenclatura.Text).ToUpper)
        Comando.Parameters.AddWithValue("@DIGITOVERIFICACION", Trim(Me.Tx_DigitoVerificación.Text))
        Comando.Parameters.AddWithValue("@PRIMERNOMBRE", Trim(Me.Tx_PrimerNombre.Text))
        Comando.Parameters.AddWithValue("@SEGUNDONOMBRE", Trim(Me.Tx_SegundoNombre.Text))
        Comando.Parameters.AddWithValue("@PRIMERAPELLIDO", Trim(Me.Tx_PrimerApellido.Text))
        Comando.Parameters.AddWithValue("@SEGUNDOAPELLIDO", Trim(Me.Tx_SegundoApellido.Text))
        Comando.Parameters.AddWithValue("@DIRECCION", Trim(Me.Tx_Dirección.Text))
        Comando.Parameters.AddWithValue("@CODIGOCIUDADDIRECCION", Me.Cu_CiudadDirección.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@TELEFONO", Trim(Tx_Teléfono.Text))
        Comando.Parameters.AddWithValue("@CELULAR", Trim(Me.Tx_TeléfonoMóvil.Text))
        Comando.Parameters.AddWithValue("@EMAIL", Trim(Tx_CorreoElectrónico.Text))
        Comando.Parameters.AddWithValue("@FAX", Trim(TextBox_Fax.Text))
        Comando.Parameters.AddWithValue("@NOMBREREPRESENTANTELEGAL", Trim(Me.TextBox_NombreRL.Text))
        Comando.Parameters.AddWithValue("@TELEFONOREPRESENTANTELEGAL", Trim(Me.TextBox_TeléfonoRL.Text))
        Comando.Parameters.AddWithValue("@CELULARREPRESENTANTELEGAL", Trim(Me.TextBox_TeléfonoMóvilRL.Text))
        Comando.Parameters.AddWithValue("@EMAILREPRESENTANTELEGAL", Trim(Me.TextBox_CorreoElectrónicoRL.Text))
        Comando.Parameters.AddWithValue("@NOMBREREPRESENTANTEVENTA", Trim(Me.TextBox_NombreVenta.Text))
        Comando.Parameters.AddWithValue("@TELEFONOREPRESENTANTEVENTA", Trim(Me.TextBox_TeléfonoV.Text))
        Comando.Parameters.AddWithValue("@CELULARREPRESENTANTEVENTA", Trim(Me.TextBox_TeléfonoMóvilV.Text))
        Comando.Parameters.AddWithValue("@EMAILREPRESENTANTEVENTA", Trim(Me.TextBox_CorreoElectrónicoV.Text))
        Comando.Parameters.AddWithValue("@REGIMENIMPUESTORENTA", Me.Cb_RegimenImpuesto.SelectedValue)
        Comando.Parameters.AddWithValue("@RESPONSABILIDADFRENTEIVA", Me.Cb_ResponsabilidadIVA.SelectedValue)
        Comando.Parameters.AddWithValue("@GRANCONTRIBUYENTE", IIf(Me.Rb_GranContribuyenteSI.Checked = True, "S", "N"))
        Comando.Parameters.AddWithValue("@AGENTERETENEDOR", IIf(Me.Rb_AgenteReteneedorSI.Checked = True, "S", "N"))
        Comando.Parameters.AddWithValue("@AUTORETENEDOR", IIf(Me.Rb_AutoretenedorSI.Checked = True, "S", "N"))
        Comando.Parameters.AddWithValue("@NRORESOLUCIONAGENTE", Trim(Me.NRORESOLUCIONAGENTETextBox.Text))
        If Me.FECHARESOLUCIONAGENTEDateTimePicker.Checked = False Then
            Comando.Parameters.AddWithValue("@FECHARESOLUCIONAGENTE", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHARESOLUCIONAGENTE", Me.FECHARESOLUCIONAGENTEDateTimePicker.Value)
        End If
        Comando.Parameters.AddWithValue("@NRORESOLUCIONAUTORETENEDOR", Trim(Me.NRORESOLUCIONAUTORETENEDORTextBox.Text))
        If Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.Checked = False Then
            Comando.Parameters.AddWithValue("@FECHARESOLUCIONAUTORETENEDOR", DBNull.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHARESOLUCIONAUTORETENEDOR", Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.Value)
        End If
        Comando.Parameters.AddWithValue("@ACTIVIDADINDUSTRIAL", IIf(Me.Rb_ActividadIndustrialSi.Checked = True, "S", "N"))
        Comando.Parameters.AddWithValue("@TARIFAICA", Trim(Me.TARIFAICATextBox.Text))
        Comando.Parameters.AddWithValue("@CIUDADSEDEFABRIL", Me.Cu_CiudadFabril.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOCONDICIONPAGO", Me.Cb_CondiciónPago.SelectedValue)
        If IsNumeric(Me.CUPOTextBox.Text) = False Then
            Comando.Parameters.AddWithValue("@CUPO", 0)
        Else
            Comando.Parameters.AddWithValue("@CUPO", CDec(Me.CUPOTextBox.Text))
        End If
        Comando.Parameters.AddWithValue("@DESCUENTO", Nud_Descuento.Value)
        Comando.Parameters.AddWithValue("@CODIGOENTIDADFINANCIERA", Me.Cb_Banco.SelectedValue)
        Comando.Parameters.AddWithValue("@SUCURSALENTIDADFINANCIERA", Trim(Me.SUCURSALENTIDADFINANCIERATextBox.Text))
        Comando.Parameters.AddWithValue("@NROCUENTA", Trim(Me.TextBox_NumeroCuenta.Text))
        Comando.Parameters.AddWithValue("@TITURALCUENTA", Trim(Me.TITURALCUENTATextBox.Text))
        Comando.Parameters.AddWithValue("@IDENTIFICACIONTITULARCUENTA", Trim(Me.IDENTIFICACIONTITULARCUENTATextBox.Text))
        Comando.Parameters.AddWithValue("@CODIGOTIPOCUENTA", Me.Cb_TipoCuenta.SelectedValue)
        Comando.Parameters.AddWithValue("@CONTACTOCARTERAENTIDADFINANCIERA", Trim(Me.CONTACTOCARTERAENTIDADFINANCIERATextBox.Text))
        Comando.Parameters.AddWithValue("@OBSERVACIONFINANCIERA", Trim(Me.OBSERVACIONFINANCIERATextBox.Text))
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@CODIGOACTIVIDADECONOMICADIAN", Me.Cb_ActividadPrincipal.SelectedValue)
        Comando.Parameters.AddWithValue("@OTROCUAL", UCase(Trim(Me.Tb_Otros.Text)))
        Comando.Parameters.AddWithValue("@ESTADO", IIf(Me.Cb_Activo.Checked = True, 1, 0))
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        conn.Close()

        If Comando.Parameters("@IDMENSAJE").Value = -1 Then
            MsgBox("Ya existe un proveedor con esa Identificación", MsgBoxStyle.Exclamation, "Ya Existe Proveedor")
            Exit Sub
        ElseIf Comando.Parameters("@IDMENSAJE").Value = -2 Then
            MsgBox("Ya existe un proveedor con esa Nomenclatura", MsgBoxStyle.Exclamation, "Ya Existe Proveedor")
            Exit Sub
        Else
            MsgBox("Se guardo el registro de proveedor correctamente", MsgBoxStyle.Information, "GUARDAR PROVEEDOR")
            Me.Close()
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Bt_Adicionar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Adicionar.Click
        If Me.validarsucursal = True Then
            If MsgBox("¿Desea adicionar la sucursal?", MsgBoxStyle.YesNo, "ADICIONAR") = MsgBoxResult.Yes Then
                Dim fila As DataRow
                fila = tablasucursales.NewRow
                fila("CIUDAD") = Me.Cu_CiudadSucursal.Cb_Ciudad.Text
                fila("DIRECCION") = Me.Tx_DirecciónSucursal.Text
                fila("TELEFONO") = Me.Tx_TeléfonoSucursal.Text
                fila("CELULAR") = Me.Tx_TeléfonoMóvilSucursal.Text
                fila("EMAIL") = Me.Tx_CorreoSucursal.Text
                fila("REPRESENTANTE") = Me.Tx_NombreRVSucursal.Text
                fila("TELEFONO REPRESENTANTE") = Me.Tx_TeléfonoRVSucursal.Text
                fila("CELULAR REPRESENTANTE") = Me.Tx_TeléfonoMóvilRVSucursal.Text
                fila("EMAILREPRESENTANTE") = Me.Tx_CorreoRVSucursal.Text
                fila("CODIGOCIUDADDIRECCION") = Me.Cu_CiudadSucursal.Cb_Ciudad.SelectedValue
                tablasucursales.Rows.Add(fila)
                limpiarsucursal()
            End If
        End If
    End Sub

    Private Sub limpiarsucursal()
        Me.Tx_DirecciónSucursal.Text = ""
        Me.Tx_TeléfonoSucursal.Text = ""
        Me.Tx_TeléfonoMóvilSucursal.Text = ""
        Me.Tx_CorreoSucursal.Text = ""
        Me.Tx_NombreRVSucursal.Text = ""
        Me.Tx_TeléfonoRVSucursal.Text = ""
        Me.Tx_TeléfonoMóvilRVSucursal.Text = ""
        Me.Tx_CorreoRVSucursal.Text = ""
        Me.Cu_CiudadSucursal.Cb_Ciudad.SelectedIndex = -1
    End Sub

    Private Sub cargarsucursaleditar()
        If Dgv_Sucursal.SelectedRows.Count = 1 Then
            Me.Tx_DirecciónSucursal.Text = Me.Dgv_Sucursal.SelectedRows(0).Cells("DIRECCION").Value
            Me.Tx_TeléfonoSucursal.Text = Me.Dgv_Sucursal.SelectedRows(0).Cells("TELEFONO").Value
            Me.Tx_TeléfonoMóvilSucursal.Text = Me.Dgv_Sucursal.SelectedRows(0).Cells("CELULAR").Value
            Me.Tx_CorreoSucursal.Text = Me.Dgv_Sucursal.SelectedRows(0).Cells("EMAIL").Value
            Me.Tx_NombreRVSucursal.Text = Me.Dgv_Sucursal.SelectedRows(0).Cells("REPRESENTANTE").Value
            Me.Tx_TeléfonoRVSucursal.Text = Me.Dgv_Sucursal.SelectedRows(0).Cells("TELEFONO REPRESENTANTE").Value
            Me.Tx_TeléfonoMóvilRVSucursal.Text = Me.Dgv_Sucursal.SelectedRows(0).Cells("CELULAR REPRESENTANTE").Value
            Me.Tx_CorreoRVSucursal.Text = Me.Dgv_Sucursal.SelectedRows(0).Cells("EMAILREPRESENTANTE").Value
            Me.Cu_CiudadSucursal.Cb_Ciudad.SelectedValue = Me.Dgv_Sucursal.SelectedRows(0).Cells("CODIGOCIUDADDIRECCION").Value
            Me.Dgv_Sucursal.Rows.Remove(Me.Dgv_Sucursal.SelectedRows(0))
        Else
            MsgBox("Debe seleccionar la sucursal que desea editar", MsgBoxStyle.Information, "Seleccionar Sucursal")
        End If
    End Sub

    Private Function validarsucursal() As Boolean
        If Me.Cu_CiudadSucursal.Cb_Ciudad.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar la ciudad de la sucursal", MsgBoxStyle.Critical, "Ciudad")
            Me.Cu_CiudadSucursal.Cb_Ciudad.Focus()
            validarsucursal = False
            Exit Function
        End If
        If Trim(Me.Tx_NombreRVSucursal.Text) = "" Then
            MsgBox("Indique el nombre del representante de ventas de la sucursal.", MsgBoxStyle.Critical, "Representante Venta Sucursal")
            Me.Tx_NombreRVSucursal.Focus()
            validarsucursal = False
            Exit Function
        End If
        validarsucursal = True
    End Function

    Private Sub Bt_Editar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Editar.Click
        cargarsucursaleditar()
    End Sub

    Private Sub Tx_CódigoActividad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Tx_CódigoActividad.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Dim filas As DataRow()
            filas = dsCargar.Tables(11).Select("CODIGOACTIVIDADECONOMICADIAN='" + Me.Tx_CódigoActividad.Text + "'")
            If filas.Length > 0 Then
                Dim fila As DataRow
                fila = filas(0)
                Me.Cb_ActividadPrincipal.SelectedValue = fila("IDACTIVIDADECONOMICADIAN")
            Else
                Me.Cb_ActividadPrincipal.SelectedIndex = -1
            End If
        End If

    End Sub


    Private Sub Cb_ActividadPrincipal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_ActividadPrincipal.SelectedIndexChanged
        Try
            Dim filas As DataRow()
            filas = dsCargar.Tables(11).Select("IDACTIVIDADECONOMICADIAN=" + Me.Cb_ActividadPrincipal.SelectedValue.ToString)
            If filas.Length > 0 Then
                Dim fila As DataRow
                fila = filas(0)
                Me.Tx_CódigoActividad.Text = fila("CODIGOACTIVIDADECONOMICADIAN")
            Else
                Me.Tx_CódigoActividad.Text = ""
            End If
        Catch ex As Exception
            Me.Tx_CódigoActividad.Text = ""
        End Try

    End Sub


    Private Sub Tx_Identificación_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tx_Identificación.LostFocus
        If Trim(Me.Tx_Identificación.Text) <> "" Then
            If Editando = False Then
                If ExisteProveedor(Me.Cb_TipoIdentificación.SelectedValue, Trim(Me.Tx_Identificación.Text)) Then
                    If MsgBox("Ya existe el proveedor ¿Desea cargar los datos? ", MsgBoxStyle.YesNo, "Proveedor") = MsgBoxResult.Yes Then
                        Editando = True
                        CargarProveedor()
                    Else
                        Tx_Identificación.Text = ""

                    End If
                End If
            End If
        End If
    End Sub

    Public Function ExisteProveedor(ByVal TipoIdentificacion As String, ByVal identificacion As String) As Boolean
        Try
            Dim Cadena_Consulta As String = "select IDPROVEEDOR from PROVEEDOR where  ltrim(rtrim(IDENTIFICACION)) = '" + Trim(identificacion) + "'"
            Dim Consulta As New SqlClient.SqlCommand(Cadena_Consulta)
            Dim Conexión As New SqlClient.SqlConnection(VariablesBase.VariablesBase.Conexion_Remota_Sql_Server.ConnectionString)
            Consulta.Connection = Conexión
            Consulta.Connection.Open()
            Dim valor As String = CStr(Consulta.ExecuteScalar)

            If valor = "" Then
                ExisteProveedor = False
            Else
                ExisteProveedor = True
                IDPROVEEDOREDITANDO = valor
            End If

            Consulta.Connection.Close()
        Catch ex As Exception
            ExisteProveedor = False
        End Try
    End Function


End Class