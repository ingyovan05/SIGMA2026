Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_CuentaCobro
    Dim DsCobro As New DatosSisControl.Ds_Siscontrol
    Public Editando As Boolean = False
    Public IdCobro As Integer
    Public Consecutivo As Integer
    Private Año As String = Year(Date.Now)
    Private IdDependencia As Integer

    Dim DsCuentaCObre As New DatosSisControl.Ds_Siscontrol

  Public Sub CargarDatos()
        IdDependencia = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        CargarCombos()
    If Editando Then
            'Dim sc_CobroTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_CUENTACOBROTableAdapter
            'sc_CobroTableAdapter.Fill(DsCobro.SC_CUENTACOBRO, 1, IdCobro, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            'Dim fila As DataRow
            'If DsCobro.SC_CUENTACOBRO.Count > 0 Then
            '  fila = DsCobro.SC_CUENTACOBRO.Rows(0)
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT * FROM dbo.ListaCobro(@ACCION,@VARIABLE, @IDBASE)", conexion)
            comando.Parameters.AddWithValue("@ACCION", 1)
            comando.Parameters.AddWithValue("@VARIABLE", IdCobro)
            comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dtCobro As New DataTable
            Try
                conexion.Open()
                adaptador.Fill(dtCobro)
                conexion.Close()
                Dim fila As DataRow
                If dtCobro.Rows.Count > 0 Then
                    fila = dtCobro.Rows(0)
                    Consecutivo = fila("CONSECUTIVO")
                    Año = fila("AÑO")
                    Dtp_Fecha.Value = fila("FECHACUENTACOBRO")

                    VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = fila("IDDEPENDENCIA")
                    CargarPersonas()

                    Cu_BuscarPersonaNombre.Cb_Persona.SelectedValue = fila("IDPERSONACUENTACOBRO")
                    Tx_Concepto.Text = fila("CONCEPTO")
                    Tx_ValorDocumento.Text = Replace(CStr(fila("valor")), ".00", "")
                    Tx_IvaAsumido.Text = fila("IVACUENTACOBRO")
                    Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue = fila("IDPERSONARESPONSABLE")

                    If Year(fila("FECHAVECIMIENTO")) <> 1900 Then
                        Dtp_FechaVencimiento.Value = fila("FECHAVECIMIENTO")
                        Dtp_FechaVencimiento.Checked = True
                    End If
                    Me.Cu_CentroCosto1.IdCentroCosto = fila("IDCENTROCOSTO")
                    Me.Cu_CentroCosto1.Editando = 3
                    Me.Cu_CentroCosto1.CargarCentro()

                    Lb_Consecutivo.Text = fila("Consecutivo")
                    IdDependencia = fila("IDDEPENDENCIA")
                    Lb_Consecutivo.Visible = True

                End If
            Catch ex As Exception
                conexion.Close()
                MsgBox(ex.Message)
            Finally
                conexion.Close()
            End Try
        Else
            Me.Cu_CentroCosto1.IdCentroCosto = VariablesBase.VariablesBase.IdCentroCostoSisControl
            Me.Cu_CentroCosto1.Editando = 2
            Me.Cu_CentroCosto1.CargarCentro()
        End If
    End Sub


    Private Sub CargarPersonas()
        Cu_BuscarPersonaNombre.CargarDatos()
        Cu_BuscarPersonaResponsable.CargarDatos()
    End Sub

    Private Sub CargarCombos()


    'VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
    Cu_BuscarPersonaNombre.CargarDatos()
        Cu_BuscarPersonaNombre.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "CC", "NOMBRE", -1)
        Cu_BuscarPersonaResponsable.CargarDatos()
        Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "CC", "RESPONSABLE", -1)
    End Sub

    Private Sub Bt_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Guardar.Click
        If ValidarCobro() Then
            GuardarCobro()
        End If

    End Sub

    Private Sub GuardarCobro()
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarCuentaCobro")
        Comando.CommandType = CommandType.StoredProcedure

        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 2)
        End If
        Comando.Parameters.AddWithValue("@IDCUENTACOBRO", IdCobro)
        Comando.Parameters.AddWithValue("@AÑO", Año)
        Comando.Parameters.AddWithValue("@CONSECUTIVO", Consecutivo)
        Comando.Parameters.AddWithValue("@FECHACUENTACOBRO", Dtp_Fecha.Value)
        Comando.Parameters.AddWithValue("@IDPERSONACUENTACOBRO", Cu_BuscarPersonaNombre.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@CONCEPTO", UCase(Tx_Concepto.Text))
        Comando.Parameters.AddWithValue("@VALORCUENTACOBRO", CDec(Trim(Tx_ValorDocumento.Text)))

        If Dtp_FechaVencimiento.Checked Then
            Comando.Parameters.AddWithValue("@FECHAVECIMIENTO", Dtp_FechaVencimiento.Value)
        Else
            Comando.Parameters.AddWithValue("@FECHAVECIMIENTO", "")
        End If

        Comando.Parameters.AddWithValue("@IVACUENTACOBRO", CDec(Trim(Tx_IvaAsumido.Text)))
        Comando.Parameters.AddWithValue("@IDPERSONARESPONSABLE", Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAREGISTRO", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAMODIFICACION", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAANULA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAANULACION", Date.Now)
        Comando.Parameters.AddWithValue("@ANULADA", "N")
        Comando.Parameters.AddWithValue("@IMPRESA", "N")
        Comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
    Comando.Parameters.AddWithValue("@IDCENTROCOSTO", Cu_CentroCosto1.IdCentroCosto)

    Comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()

        If Editando = False Then
            MsgBox("El consecutivo es: " + CStr(msgParam.Value), MsgBoxStyle.Information, "CONSECUTIVO")
        End If

        conn.Close()

        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "CC", "NOMBRE", Cu_BuscarPersonaNombre.Cb_Persona.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "CC", "RESPONSABLE", Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue)


        Me.Close()

    End Sub

    Private Function ValidarCobro() As Boolean

        If Tx_Concepto.Text = "" Then
            MsgBox("Debe Agregar un concepto", MsgBoxStyle.Critical, "CONCEPTO")
            ValidarCobro = False
            Tx_Concepto.Focus()
            Exit Function
        End If

        'If Dtp_FechaVencimiento.Checked = False Then
        '    MsgBox("Seleccioné fecha de vencimiento", MsgBoxStyle.Critical, "FECHA VENCIMIENTO")
        '    ValidarCobro = False
        '    Dtp_FechaVencimiento.Focus()
        '    Exit Function
        'End If

        If Tx_ValorDocumento.Text = "" Then
            MsgBox("Agrege valor de documento", MsgBoxStyle.Critical, "Valor")
            ValidarCobro = False
            Tx_ValorDocumento.Focus()
            Exit Function
        End If

        If IsNumeric(Tx_ValorDocumento.Text) = False Then
            MsgBox("Agrege valor de documento", MsgBoxStyle.Critical, "Valor")
            ValidarCobro = False
            Tx_ValorDocumento.Text = ""
            Tx_ValorDocumento.Focus()
            Exit Function
        End If

        If Tx_IvaAsumido.Text = "" Then
            MsgBox("Agrege el IVA correspondiente", MsgBoxStyle.Critical, "IVA")
            ValidarCobro = False
            Tx_IvaAsumido.Focus()
            Exit Function
        End If

        If IsNumeric(Tx_IvaAsumido.Text) = False Then
            MsgBox("El IVA debe ser numerico", MsgBoxStyle.Critical, "IVA")
            ValidarCobro = False
            Tx_IvaAsumido.Focus()
            Exit Function
        End If

        If IsNothing(Cu_BuscarPersonaNombre.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione el nombre ", MsgBoxStyle.Critical, "NOMBRE")
            ValidarCobro = False
            Cu_BuscarPersonaNombre.Cb_Persona.Focus()
            Exit Function
        End If


        If IsNothing(Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione la persona responsable  ", MsgBoxStyle.Critical, "RESPONSABLE")
            ValidarCobro = False
            Cu_BuscarPersonaResponsable.Cb_Persona.Focus()
            Exit Function
        End If

        ValidarCobro = True
    End Function

    Private Sub Bt_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Tx_ValorDocumento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tx_ValorDocumento.KeyPress, Tx_ValorDocumento.KeyPress
        Dim Caja As TextBox = sender
        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.Handled = True
            e.KeyChar = CChar("")
        End If
    End Sub

    Private Sub Tx_ValorDocumentoGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tx_ValorDocumento.LostFocus
        Try
            Dim Caja As TextBox = sender
            Dim Cadena As String = Replace(Caja.Text, "$", "")
            Cadena = Replace(Cadena, " ", "")
            Cadena = Replace(Cadena, ".", "")

            Dim pos As Integer = Cadena.LastIndexOf(",")
            If pos = Cadena.Length - 3 Then
                'tiene ",00"
                Cadena = Mid(Cadena, 1, Cadena.Length - 3)
            Else
                If pos = Cadena.Length - 2 Then
                    'tiene ",0"
                    Cadena = Mid(Cadena, 1, Cadena.Length - 2)
                End If
            End If
            Cadena = Replace(Cadena, ",", "")
            If IsNumeric(Cadena) = False Then
                Caja.BackColor = Drawing.Color.MintCream
            Else
                Caja.Text = Replace(Format(Cadena, "Currency"), ",00", "")
                Caja.BackColor = Drawing.Color.White
            End If
        Catch ex As Exception

        End Try

    End Sub

    'Para cargar al asociar una persona 
    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1, Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_BuscarPersonaNombre.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaNombre.CargarDatos()
            Me.Cu_BuscarPersonaNombre.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaNombre.CargarCajaTexto()
        Catch ex As Exception
        End Try

        Try
            temp = Me.Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaResponsable.CargarDatos()
            Me.Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaResponsable.CargarCajaTexto()
        Catch ex As Exception
        End Try

        Select Case NOMBRECOMPONENTE
            Case Cu_BuscarPersonaNombre.Name
                Me.Cu_BuscarPersonaNombre.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaResponsable.Name
                Me.Cu_BuscarPersonaResponsable.Cb_Persona.SelectedValue = IDPERSONA

        End Select

    End Sub

End Class