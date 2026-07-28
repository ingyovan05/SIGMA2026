Imports System.Windows.Forms

Public Class Dg_Novedad

    Public IdReporte As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Validar_ValoresListaIntegrantes() = False Then
            Me.Lb_Error.Visible = True
            Exit Sub
        Else
            Me.Lb_Error.Visible = False
        End If
        'Actualizar reporte diario y registrar Novedad
        'Dim adapnovedad As New DatosReporteDiario.Ds_ModificarReporteDiarioTableAdapters.MODIFICANDOREPORTEDIARIOPERSONATableAdapter
        'adapnovedad.RegistrarReporteDiarioNovedad(Me.Tx_HN.Text, Me.Tx_ED.Text, Me.Tx_EN.Text,
        '                                             Me.Tx_RN.Text,
        '                                            VariablesBase.VariablesBase.IdProyecto,
        '                                            IdReporte, IdContratoNovedad,
        '                                            VariablesBase.VariablesBase.IdPersona)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tx_HN.TextChanged, Tx_ED.TextChanged, Tx_EN.TextChanged, Tx_RN.TextChanged
        Tm_Totalizar.Stop()
        Tm_Totalizar.Interval = VariablesBase.VariablesBase.TiempoRespuestaBuscador
        Tm_Totalizar.Start()
    End Sub

    Private Sub CalcularTotal()
        Try
            Me.Tx_HN.Text = UCase(Me.Tx_HN.Text)
            Me.Tx_ED.Text = UCase(Me.Tx_ED.Text)
            Me.Tx_EN.Text = UCase(Me.Tx_EN.Text)
            Me.Tx_RN.Text = UCase(Me.Tx_RN.Text)

            Dim N As String
            Dim ED As String
            Dim EN As String
            Dim RN As String
            N = Me.Tx_HN.Text
            ED = Me.Tx_ED.Text
            EN = Me.Tx_EN.Text
            RN = Me.Tx_RN.Text
            If ValidarConvenciones(N) = True Then
                Me.Tx_HN.BackColor = Drawing.Color.White
            Else
                If ValidarValorIngresado(N, "N") = False Then
                    Me.Tx_HN.BackColor = Drawing.Color.Red
                Else
                    Me.Tx_HN.BackColor = Drawing.Color.White
                End If
            End If
            If ValidarValorIngresado(ED, "ED") = False Then
                Me.Tx_ED.BackColor = Drawing.Color.Red
            Else
                Me.Tx_ED.BackColor = Drawing.Color.White
            End If
            If ValidarValorIngresado(EN, "EN") = False Then
                Me.Tx_EN.BackColor = Drawing.Color.Red
            Else
                Me.Tx_EN.BackColor = Drawing.Color.White
            End If
            If ValidarValorIngresado(RN, "RN") = False Then
                Me.Tx_RN.BackColor = Drawing.Color.Red
            Else
                Me.Tx_RN.BackColor = Drawing.Color.White
            End If

            Dim total As Integer = 0
            If IsNumeric(N) = True Then
                total = total + CInt(N)
            End If
            If IsNumeric(ED) = True Then
                total = total + CInt(ED)
            End If
            If IsNumeric(EN) = True Then
                total = total + CInt(EN)
            End If
            Me.Lb_TOTAL.Text = total.ToString
        Catch ex As Exception
        End Try
    End Sub

    Public Function ValidarValorIngresado(ByVal Valor As String, ByVal Columna As String) As Boolean
        Dim validar As Boolean = True
        If IsDBNull(Valor) = False Then
            'Verificar que es numerico
            If Trim(Valor) <> "" Then
                If IsNumeric(Valor) = False Then
                    validar = False
                Else
                    If ValidarValores(Valor) = False Then
                        validar = False
                    End If
                End If
            End If
        End If
        ValidarValorIngresado = validar
    End Function

    Public Function ValidarConvenciones(ByVal convención As String) As Boolean
        Dim validar As Boolean = False
        Select Case UCase(convención)
            Case "O", "D", "A", "I", "IC", "S", "ACSP", "ACCP", "P", "DIS", "NDS", "V"
                validar = True
        End Select
        ValidarConvenciones = validar
    End Function

    Private Function ValidarValores(ByVal Valor As String) As Boolean
        Dim validar As Boolean = True
        If CInt(Valor) > 24 Then
            validar = False
        End If
        ValidarValores = validar
    End Function

    Public IdContratoNovedad As Integer
    Public FECHAREPORTE As Date
    Public TIPOSALARIO As String

    Private Function Validar_ValoresListaIntegrantes() As Boolean
        Dim Validar As Boolean = True
        Try
            Dim ListaIntegrantes As New ArrayList
            ListaIntegrantes.Add(IdContratoNovedad)
            'VariablesBase.VariablesBase.PERMISOSXIDCONTRATOS = FuncionesBase.FuncionesBase.PERMISOXIDCONTRATOS(ListaIntegrantes, FECHAREPORTE)
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Dim N As String
            Dim ED As String
            Dim EN As String
            Dim RN As String

            N = Tx_HN.Text
            ED = Tx_ED.Text
            EN = Tx_EN.Text
            RN = Tx_RN.Text

            If ValidarValorIngresado(ED, "ED") = False Then
                Validar = False
            End If
            If ValidarValorIngresado(EN, "EN") = False Then
                Validar = False
            End If
            If ValidarValorIngresado(RN, "RN") = False Then
                Validar = False
            End If
            If IsDBNull(N) = False Then
                'verificar que es numerico
                If IsNumeric(N) = False Then
                    If ValidarConvenciones(N) = False Then
                        Validar = False
                        Me.Lb_Error.Text = "N no esta dentro de las convenciones establecidas"
                    End If
                Else
                    ValidarValorIngresado(N, "N")
                End If
            Else
                Validar = False
                Me.Lb_Error.Text = "N debe tener algún valor"
            End If
            'Validar por tipo de salario

            If TIPOSALARIO = "M" Then
                If N = "8" Then
                    Validar = False
                   Me.Lb_Error.Text = "N no es valido para el tipo de salario"
                End If
            Else
                If N = "P" Then
                    Validar = False
                  Me.Lb_Error.Text ="N no es valido para el tipo de salario"
                End If
            End If



            ''validar si esta de permiso
            'Dim IDCONTRATO As Integer = Me.IdContratoNovedad
            'Dim FilasDescanso() As DataRow
            'FilasDescanso = FuncionesBase.FuncionesBase.PERMISOXIDCONTRATO(IDCONTRATO)

            ''Dim adap_permiso As New Ds_ModificarReporteDiarioTableAdapters.PERMISOTableAdapter
            ''adap_permiso.Fill(Ds_ModificarReporteDiario.PERMISO, IDCONTRATO, Me.Tx_Fecha.Text, Me.Tx_Fecha.Text)

            'If FilasDescanso.Count > 0 Then
            '    'si es Descanso compensatorio D
            '    Dim filaDescanso As DataRow
            '    filaDescanso = FilasDescanso(0)

            '    If filaDescanso("CODIGOTIPOPERMISO") = 2 Then
            '        If N <> "D" Then
            '            Validar = False
            '             Me.Lb_Error.Text ="Esta persona se encuentra en descanso"
            '        End If
            '    Else
            '        If N = "8" Or N = "P" Or N = "DIS" Or N = "A" Or N = "0" Then
            '            Validar = False
            '             Me.Lb_Error.Text = "Esta persona se encuentra en descanso o de permiso"
            '        Else
            '            If N = "D" Then 'Esta de permiso y le colocaron descanso
            '                Validar = False
            '                Me.Lb_Error.Text = "Esta persona esta de permiso"
            '            Else
            '                If N <> "IC" Then
            '                    If filaDescanso("REMUNERADO") = "S" Then
            '                        If N = "ACSP" Then
            '                            Validar = False
            '                            Me.Lb_Error.Text = "Esta persona esta de permiso con pago"
            '                        End If
            '                    Else
            '                        If N = "ACCP" Then
            '                            Validar = False
            '                            Me.Lb_Error.Text = "Esta persona esta de permiso sin pago"
            '                        End If
            '                    End If
            '                End If
            '            End If
            '        End If
            '    End If
            'Else
            '    'Validar cuando no esta de permiso
            '    If N = "D" Or N = "IC" Or N = "ACSP" Or N = "ACCP" Then
            '        Validar = False
            '      Me.Lb_Error.Text = "Esta persona no se encuentra en descanso"
            '    End If
            'End If


            'Validar que no metan valores cuando este en D
            If N = "D" Or N = "IC" Or N = "ACSP" Or N = "ACCP" Then
                If ED <> "" Or EN <> "" Or RN <> "" Then
                    Validar = False
                    Me.Lb_Error.Text = "Error en ED, EN o RN"
                End If
            End If
            If IsNumeric(Me.Lb_TOTAL.Text) Then
                Dim TOTAL As String
                TOTAL = (Me.Lb_TOTAL.Text).ToString
                If CInt(TOTAL) > 12 Then
                    If MsgBox("El total supera las 12 horas, ¿Desea Continuar?", MsgBoxStyle.YesNo, "SUPERA LAS 12 HORAS") = MsgBoxResult.No Then
                        Validar = False
                        Me.Lb_Error.Text = "El total no puede sumar mas de 12 horas de trabajo"
                    End If
                End If
            End If

            Me.Enabled = True
            Me.Cursor = Cursors.Default
            'Validar que el total no sea mayor a 12
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try
        Validar_ValoresListaIntegrantes = Validar
    End Function


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tm_Totalizar.Tick
        Tm_Totalizar.Stop()
        CalcularTotal()
    End Sub

End Class
