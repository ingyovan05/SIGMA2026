Imports System.Windows.Forms
Imports System.Drawing

Public Class Dg_NovedadEquipo

    Public FORMAREPORTAR As String
    Public TIPODISPONIBILIDAD As String
    Public DISPONIBILIDAD As String
    Public MAXIMOHFKF As String
    Public IdReporte As Integer
    Public IdEquipoNovedad As Integer
    Public FECHAREPORTE As Date

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Validar_ValoresListaEquipos() = False Then
            Me.Lb_Error.Visible = True
            Exit Sub
        Else
            Me.Lb_Error.Visible = False
        End If

        ''Actualizar reporte diario y registrar Novedad
        'Dim adapnovedad As New DatosReporteDiario.Ds_ModificarReporteDiarioTableAdapters.MODIFICANDOREPORTEDIARIOPERSONATableAdapter
        'adapnovedad.RegistrarReporteDiarioNovedadEquipo(Me.Tx_TOTAL.Text, Me.Tx_HI_KI.Text, _
        '                                                 Me.Tx_HF_KF.Text,
        '                                              Me.Tx_DIS.Text, Me.Tx_VAR.Text,
        '                                             VariablesBase.VariablesBase.IdProyecto,
        '                                             IdReporte, IdEquipoNovedad,
        '                                            VariablesBase.VariablesBase.IdPersona)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function Validar_ValoresListaEquipos() As Boolean
        Dim ValidarTotal As Boolean = True
        Try
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            'Cuando esta bien
            Dim Estilo_Celda As New DataGridViewCellStyle
            Estilo_Celda.BackColor = Color.White
            Dim Validar As Boolean = True
            Dim TOTAL As String = Trim(Me.Tx_TOTAL.Text)
            Dim INICIAL As String = Trim(Me.Tx_HI_KI.Text)
            Dim FINAL As String = Trim(Me.Tx_HF_KF.Text)
            Dim DIS As String = Trim(Me.Tx_DIS.Text)
            Dim VAR As String = Trim(Me.Tx_VAR.Text)

            TOTAL = IIf(IsDBNull(TOTAL), "", TOTAL)
            INICIAL = IIf(IsDBNull(INICIAL), "", INICIAL)
            FINAL = IIf(IsDBNull(FINAL), "", FINAL)
            DIS = IIf(IsDBNull(DIS), "", DIS)
            VAR = IIf(IsDBNull(VAR), "", VAR)
            MAXIMOHFKF = Trim(MAXIMOHFKF)

            If ValidarConvencionesEquipos(TOTAL, "TOTAL") = False Then
                Validar = False
                Me.Lb_Error.Text  = "TOTAL no contiene un valor valido"
            Else
                If ValidarConvencionesEquipos(INICIAL, "INICIAL") = False Then
                    Validar = False
                    Me.Lb_Error.Text = "INICIAL no contiene un valor valido"
                Else
                    If ValidarConvencionesEquipos(FINAL, "FINAL") = False Then
                        Validar = False
                        Me.Lb_Error.Text = "FINAL no contiene un valor valido"
                    Else
                        If ValidarConvencionesEquipos(DIS, "DIS") = False Then
                            Validar = False
                            Me.Lb_Error.Text = "DISPONIBLE no contiene un valor valido"
                        Else
                            If ValidarConvencionesEquipos(VAR, "VAR") = False Then
                                Validar = False
                                Me.Lb_Error.Text = "VARADO no contiene un valor valido"
                            End If
                        End If
                    End If
                End If
            End If

            If Validar = True Then
                If INICIAL.Contains(",") = True Or FINAL.Contains(",") = True _
                    Or TOTAL.Contains(",") = True Or DIS.Contains(",") = True _
                    Or VAR.Contains(",") = True Then
                    Validar = False
                    Me.Lb_Error.Text = ", es un caracter no valido"
                Else
                    If INICIAL.Contains(".") = True Or FINAL.Contains(".") = True _
                        Or TOTAL.Contains(".") = True Or DIS.Contains(".") = True _
                        Or VAR.Contains(".") = True Then
                        Validar = False
                        Me.Lb_Error.Text = ". es un caracter no valido"
                    Else
                    End If
                End If
            End If


            If Validar = True Then
                If TOTAL = "T" Then
                    If INICIAL <> "" Then
                        Validar = False
                        Me.Lb_Error.Text = "INICIAL debe estar en blanco"
                    Else
                        If FINAL <> "" Then
                            Validar = False
                            Me.Lb_Error.Text = "FINAL debe estar en blanco"
                        Else
                            If DIS <> "" Then
                                Validar = False
                                Me.Lb_Error.Text = "DISPONIBLE debe estar en blanco"
                            Else
                                If VAR <> "" Then
                                    Validar = False
                                    Me.Lb_Error.Text = "VARADO debe estar en blanco"
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If Validar = True Then
                If VAR = "V" Then
                    If DIS <> "" Then
                        Validar = False
                        Me.Lb_Error.Text = "DISPONIBLE debe estar en blanco"
                    Else
                        If TOTAL <> "" Then
                            If TOTAL <> "0" Then
                                Validar = False
                                Me.Lb_Error.Text = "TOTAL debe ser 0"
                            End If
                        Else
                            If INICIAL <> FINAL Then
                                If FINAL <> "" Then
                                    Validar = False
                                    Me.Lb_Error.Text = "FINAL e INICIAL deben tener el mismo valor"
                                End If
                            Else
                                'If INICIAL) <> "" Then
                                '    Validar = False
                                '    .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                '    Me.Lb_Error.Text = "INICIAL debe estar en blanco"
                                'Else
                                '    If FINAL) <> "" Then
                                '        Validar = False
                                '        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                '        Me.Lb_Error.Text = "FINAL debe estar en blanco"
                                '    End If
                                'End If
                            End If
                        End If
                    End If
                End If
            End If

            If Validar = True Then
                If DIS = "D" Then
                    If VAR <> "" Then
                        Validar = False
                        Me.Lb_Error.Text = "VARADO debe estar en blanco"
                    Else
                        If TOTAL <> "" Then
                            If TOTAL <> "0" Then
                                Validar = False
                                Me.Lb_Error.Text = "TOTAL debe ser 0"
                            End If
                        Else
                            If INICIAL <> FINAL Then
                                If FINAL <> "" Then
                                    Validar = False
                                    Me.Lb_Error.Text = "FINAL e INICIAL deben tener el mismo valor"
                                End If
                            Else
                                'If INICIAL) <> "" Then
                                '    Validar = False
                                '    .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                '    Me.Lb_Error.Text = "INICIAL debe estar en blanco"
                                'Else
                                '    If FINAL) <> "" Then
                                '        Validar = False
                                '        .Rows(i).DefaultCellStyle = Estilo_Celda_convención
                                '        Me.Lb_Error.Text = "FINAL debe estar en blanco"
                                '    End If
                                'End If
                            End If
                        End If
                    End If

                End If
            End If

            If Validar = True Then
                If IsDBNull(TOTAL) = True Then
                    Validar = False
                    Me.Lb_Error.Text = "TOTAL no puede ser vacio"
                Else
                    If TOTAL <> "T" Then
                        If TOTAL <> "" Then
                            If CInt(TOTAL) < 0 Then
                                Validar = False
                                Me.Lb_Error.Text = "TOTAL no puede ser negativo"
                            Else
                                If TOTAL <> 0 Then
                                    'validar la forma de reportar
                                    Select Case FORMAREPORTAR
                                        Case "HOROMETRO", "KILOMETRO"
                                            If IsDBNull(INICIAL) = True Then
                                                Validar = False
                                                Me.Lb_Error.Text = "INICIAL no puede estar vacio"
                                            Else
                                                If IsNumeric(INICIAL) = False Then
                                                    Validar = False
                                                    Me.Lb_Error.Text = "INICIAL debe ser numerico"
                                                Else
                                                    If IsDBNull(FINAL) = True Then
                                                        Validar = False
                                                        Me.Lb_Error.Text = "FINAL no puede estar vacio"
                                                    Else
                                                        If IsNumeric(FINAL) = False Then
                                                            Validar = False
                                                            Me.Lb_Error.Text = "FINAL deber ser numerico"
                                                        Else
                                                            If CInt(TOTAL) <> CInt(FINAL) - CInt(INICIAL) Then
                                                                Validar = False
                                                                Me.Lb_Error.Text = "TOTAL debe ser igual a la diferencia entre INICIAL y FINAL"
                                                            Else
                                                                If CInt(FINAL) < CInt(INICIAL) Then
                                                                    Validar = False
                                                                    Me.Lb_Error.Text = "FINAL no puede ser menor al INICIAL"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                    End Select
                                Else 'TOTAL ES CERO
                                    If IsDBNull(INICIAL) = False Then
                                        If IsDBNull(FINAL) = False Then
                                            If IsNumeric(INICIAL) = True Then
                                                If IsNumeric(FINAL) = True Then
                                                    If CInt(FINAL) - CInt(INICIAL) <> 0 Then
                                                        Validar = False
                                                        Me.Lb_Error.Text = "TOTAL no es valido"
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Else 'total=""
                            If VAR = "" And DIS = "" Then
                                Validar = False
                                Me.Lb_Error.Text = "TOTAL no es valido proque VARADO esta vacio al igual que DISPONIBLE"
                            Else
                                If INICIAL <> "" Then
                                    Validar = False
                                    Me.Lb_Error.Text = "TOTAL no es valido porque INICIAL tiene un valor"
                                Else
                                    If FINAL <> "" Then
                                        Validar = False
                                        Me.Lb_Error.Text = "TOTAL no es valido porque FINAL tiene un valor"
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If Validar = True Then
                'validar VARADO vs TOTAL vs DISPONIBLE cuan VAR es numerico
                If IsDBNull(VAR) = False Then
                    If IsNumeric(VAR) = True Then ' tiena algun valor en varado
                        If IsDBNull(TOTAL) = True Then
                            Validar = False
                            Me.Lb_Error.Text = "TOTAL no es valido porque VARADO tiene un valor"
                        Else
                            If IsNumeric(TOTAL) = False Then
                                Validar = False
                                Me.Lb_Error.Text = "TOTAL no es valido porque VARADO tiene un valor"
                            Else
                                If CInt(TOTAL) < 1 Then
                                    Validar = False
                                    Me.Lb_Error.Text = "TOTAL no es puede ser negativo"
                                End If
                            End If
                        End If
                    End If
                End If

            End If

            If Validar = True Then
                'validar INICIAL con respecto al ultimo reporte
                If IsDBNull(INICIAL) = False Then
                    If IsNumeric(INICIAL) = True Then
                        If IsDBNull(MAXIMOHFKF) = False Then
                            If IsNumeric(MAXIMOHFKF) = True Then
                                If CDec(INICIAL) < CDec(MAXIMOHFKF) Then
                                    Validar = False
                                    Me.Lb_Error.Text = "INICIAL no puede ser menor al ultimo FINAL registrado en reportes anteriores"
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If Validar = True Then
                'validar con respecto al tipo de disponibilidad
                If IsDBNull(TOTAL) = False Then
                    If IsNumeric(TOTAL) = True Then
                        If IsDBNull(DISPONIBILIDAD) = False Then
                            If IsNumeric(DISPONIBILIDAD) = True Then
                                If CInt(TOTAL) > CInt(DISPONIBILIDAD) Then
                                    If CInt(DISPONIBILIDAD) > 0 Then
                                        Select Case TIPODISPONIBILIDAD
                                            Case "HORA"
                                                Me.Lb_Error.Text = "TOTAL no puede ser mayor a la disponibilidad"
                                        End Select
                                    End If
                                End If
                            End If
                        End If
                    Else
                        'TOTAL="" o TOTAL="T"

                    End If
                Else
                    'TOTAL=""

                End If
            End If
            If Validar = True Then
                'validar con respecto a la forma de reportar

            End If
            If Validar = True Then
                'validar con respecto al maximo horometro o kilometraje
                If INICIAL <> "" And INICIAL <> "0" Then
                    If MAXIMOHFKF <> "" And MAXIMOHFKF <> "0" Then
                        If INICIAL <> MAXIMOHFKF Then
                            'Dim adap As New DatosReporteDiario.Ds_ModificarReporteDiarioTableAdapters.REPORTEDIARIOEQUIPOTableAdapter
                            'If adap.ConsultarFinalDiaAnterior(IdEquipoNovedad, DateAdd(DateInterval.Day, -1, FECHAREPORTE)) <> "" Then
                            '    Me.Lb_Error.Text = "INICIAL no puede ser diferente a MAXIMO HF/KF registrado"
                            '    Validar = False
                            'End If
                        End If
                    End If
                End If
            End If
            If ValidarTotal = True Then
                ValidarTotal = Validar
            End If
            Me.Enabled = True
            Me.Cursor = Cursors.Default
            'Validar que el total no sea mayor a 12
        Catch ex As Exception
            MsgBox(ex.ToString)
            ValidarTotal = False
            Me.Lb_Error.Text = "Error al intentar validar los equipos"
            Me.Lb_Error.Visible = True
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try
        Validar_ValoresListaEquipos = ValidarTotal
    End Function

    Public Function ValidarConvencionesEquipos(ByVal convención As String, ByVal Columna As String) As Boolean
        Dim validar As Boolean = False
        Select Case Columna
            Case "TOTAL"
                If IsNumeric(convención) = True Then
                    If CInt(convención) >= 0 Then
                        validar = True
                    End If
                Else
                    If convención = "T" Or convención = "" Then
                        validar = True
                    End If
                End If
            Case "INICIAL", "FINAL"
                If IsNumeric(convención) = True Then
                    If CInt(convención) >= 0 Then
                        validar = True
                    End If
                Else
                    If convención = "" Then
                        validar = True
                    End If
                End If

            Case "DIS"
                If IsNumeric(convención) = True Then
                    If CInt(convención) >= 0 Then
                        validar = True
                    End If
                Else
                    If convención = "D" Or convención = "" Then
                        validar = True
                    End If
                End If
            Case "VAR"
                If IsNumeric(convención) = True Then
                    If CInt(convención) >= 0 Then
                        validar = True
                    End If
                Else
                    If convención = "V" Or convención = "" Then
                        validar = True
                    End If
                End If
        End Select
        ValidarConvencionesEquipos = validar
    End Function

    Private Sub CalcularTotalEquipo()
        Try
            Dim TOTAL As String = Me.Tx_TOTAL.Text
            Dim INICIAL As String = Me.Tx_HI_KI.Text
            Dim FINAL As String = Me.Tx_HF_KF.Text
            Dim DIS As String = Me.Tx_DIS.Text
            Dim VAR As String = Me.Tx_VAR.Text
            Try
                If DIS = "D" Or VAR = "V" Then
                    Me.Tx_HI_KI.Text = MAXIMOHFKF
                    Me.Tx_HF_KF.Text = MAXIMOHFKF
                End If
                If CInt(FINAL) >= CInt(INICIAL) Then
                    If CInt(FINAL) >= 0 Then
                        If CInt(INICIAL) >= 0 Then
                            Me.Tx_TOTAL.Text = (CInt(FINAL) - CInt(INICIAL)).ToString
                        End If
                    End If
                End If
            Catch ex As Exception
                Me.Tx_TOTAL.Text = TOTAL
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Tx_TOTAL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tx_VAR.TextChanged, Tx_TOTAL.TextChanged, Tx_HI_KI.TextChanged, Tx_HF_KF.TextChanged, Tx_DIS.TextChanged
        Tm_Totalizar.Stop()
        Tm_Totalizar.Interval = VariablesBase.VariablesBase.TiempoRespuestaBuscador
        Tm_Totalizar.Start()
    End Sub

    Private Sub Tm_Totalizar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tm_Totalizar.Tick
        Tm_Totalizar.Stop()
        CalcularTotalEquipo()
    End Sub

End Class
