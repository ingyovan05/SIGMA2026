Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_Correspondencia
    Public Tipo As String
    Public Editando As Boolean = False
    Public IdCorrespondencia As Integer = -1
    Public Dependencia As Integer
    Public Clonar As Boolean = False
    Private Consecutivo As Integer
    Private Año As String = CStr(Year(Date.Now))
    Dim DsCorrespondencia As New DatosSisControl.Ds_Siscontrol


    Private Sub Bt_BuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_BuscarProveedor.Click
        Dim FrBuscarContratista As New Fr_BuscarContratista
        FrBuscarContratista.Cargar_Tabla()
        FrBuscarContratista.ShowDialog()
        Try
            If FrBuscarContratista.IdContratista <> -1 Then
                Me.Tx_Empresa.Text = Trim(FrBuscarContratista.NombreContratista)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Bt_BuscarPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_BuscarPersona.Click
        Dim frBuscarPersona As New FormulariosClasesBase.Fr_BuscarPersona
        frBuscarPersona.Cargar_Tabla("P")
        frBuscarPersona.ShowDialog()
        Try
            If frBuscarPersona.IdPersona <> -1 Then
                Me.Tx_DirigidoA.Text = Trim(frBuscarPersona.NombrePersona)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Cargar_Datos()

        If Editando Then
            'Cargar el IdDependencia del registro.
            VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = Dependencia
        Else
            VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = VariablesBase.VariablesBase.IddependenciaSiscontrolActual
        End If

        Cu_CiudadDirección.CargarDatos()
        Cu_CiudadDirección.Cb_Ciudad.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "C", "CIDUAD", -1)

        Cu_BuscarPersonaElabora.CargarDatos()
        Cu_BuscarPersonaElabora.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "C", "ELABORA", -1)

        Cu_BuscarPersonaFirma.CargarDatos()
        Cu_BuscarPersonaFirma.Cb_Persona.SelectedValue = FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("C", "C", "FIRMA", -1)

        Dim Fecha As Date = Date.Now

        Dtp_Fecha.MinDate = Fecha.AddDays(-7)
        Dtp_Fecha.MaxDate = Fecha.AddDays(7)

        If Editando = True Then
            'Dim sc_CorrespondenciaTableAdapter As New DatosSisControl.Ds_SiscontrolTableAdapters.SC_CORRESPONDENCIATableAdapter
            'sc_CorrespondenciaTableAdapter.Fill(DsCorrespondencia.SC_CORRESPONDENCIA, 1, Tipo, IdCorrespondencia, VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            'Dim fila As DataRow
            'If DsCorrespondencia.SC_CORRESPONDENCIA.Count > 0 Then
            '    fila = DsCorrespondencia.SC_CORRESPONDENCIA.Rows(0)
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT * FROM dbo.ListaCorrespondencia(@ACCION,@TIPO, @VARIABLE, @IDBASE)", conexion)
            comando.Parameters.AddWithValue("@ACCION", 1)
            comando.Parameters.AddWithValue("@TIPO", Tipo)
            comando.Parameters.AddWithValue("@VARIABLE", IdCorrespondencia)
            comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
            Dim adaptador As New SqlDataAdapter(comando)
            Dim dtCorrespondecia As New DataTable
            Try
                conexion.Open()
                adaptador.Fill(dtCorrespondecia)
                conexion.Close()
                Dim fila As DataRow
                If dtCorrespondecia.Rows.Count > 0 Then
                    fila = dtCorrespondecia.Rows(0)

                    Fecha = CDate(fila("Fecha Correspondencia"))

                    Dtp_Fecha.MinDate = Fecha.AddDays(-7)
                    Dtp_Fecha.MaxDate = Fecha.AddDays(7)

                    IdCorrespondencia = fila("IDCORRESPONDENCIAEXTERNA")
                    Dtp_Fecha.Value = fila("Fecha Correspondencia")
                    Tx_Empresa.Text = Trim(fila("Empresa"))
                    Tx_DirigidoA.Text = Trim(fila("Dirigido a"))
                    Tx_Dirección.Text = Trim(fila("Direcion de envio"))
                    Cu_CiudadDirección.Cb_Ciudad.SelectedValue = fila("CODIGOCIUDAD")
                    Tx_Asunto.Text = Trim(fila("Asunto"))
                    Me.Cu_CentroCosto1.IdCentroCosto = fila("IDCENTROCOSTO")
                    Me.Cu_CentroCosto1.Editando = 3

                    VariablesBase.VariablesBase.IddependenciaSiscontrolBusqueda = fila("IDDEPENDENCIA")

                    Cu_BuscarPersonaFirma.CargarDatos()
                    Cu_BuscarPersonaElabora.CargarDatos()

                    Cu_BuscarPersonaElabora.Cb_Persona.SelectedValue = fila("ELABORADOPOR")
                    Cu_BuscarPersonaFirma.Cb_Persona.SelectedValue = fila("FIRMADO")

                    If Clonar = True Then
                        Año = CStr(Year(Date.Now))
                    Else
                        Año = fila("Año")
                    End If

                    Consecutivo = fila("Consecutivo")
                    Lb_CódigoArtículo.Visible = True
                    Lb_CódigoArtículo.Text = CStr(fila("Consecutivo")) + " - " + fila("Año")

                    If Clonar = True Then
                        Dtp_Fecha.MaxDate = Date.Now
                        Dtp_Fecha.MinDate = Date.Now

                        Dtp_Fecha.MinDate = Date.Now.AddDays(-7)
                        Dtp_Fecha.MaxDate = Date.Now.AddDays(7)
                    End If
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
        End If

        Me.Cu_CentroCosto1.CargarCentro()
    End Sub


    Private Sub Bt_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Guardar.Click
        If ValidarCorrespondencia() Then
            GuardarCorrespondencia()
        End If
    End Sub


    Private Sub GuardarCorrespondencia()
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarCorrespondencia")
        Comando.CommandType = CommandType.StoredProcedure

        If Editando = False Then
            Comando.Parameters.AddWithValue("@TIPOEJEC", 1)
        Else
            Comando.Parameters.AddWithValue("@TIPOEJEC", 2)
        End If
        Comando.Parameters.AddWithValue("@IDCORRESPONDENCIAEXTERNA", IdCorrespondencia)
        Comando.Parameters.AddWithValue("@AÑO", CStr(Año))
        Comando.Parameters.AddWithValue("@CONSECUTIVO", Consecutivo)
        Comando.Parameters.AddWithValue("@FECHACORRESPONDENCIAEXTERNA", Dtp_Fecha.Value)
        Comando.Parameters.AddWithValue("@EMPRESA", UCase(Trim(Tx_Empresa.Text)))
        Comando.Parameters.AddWithValue("@DIRIGIDOA", UCase(Trim(Tx_DirigidoA.Text)))
        Comando.Parameters.AddWithValue("@CODIGOCIUDAD", Cu_CiudadDirección.Cb_Ciudad.SelectedValue)
        Comando.Parameters.AddWithValue("@ASUNTO", UCase(Trim(Tx_Asunto.Text)))
        Comando.Parameters.AddWithValue("@ELABORADOPOR", Cu_BuscarPersonaElabora.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@FIRMADO", Cu_BuscarPersonaFirma.Cb_Persona.SelectedValue)
        Comando.Parameters.AddWithValue("@FECHAREGISTRO", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAREGISTRA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAMODIFICACION", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAMODIFICA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@FECHAANULACION", Date.Now)
        Comando.Parameters.AddWithValue("@IDPERSONAANULA", VariablesBase.VariablesBase.IdPersona)
        Comando.Parameters.AddWithValue("@ANULADA", "N")
        Comando.Parameters.AddWithValue("@IMPRESA", "N")
        Comando.Parameters.AddWithValue("@IDBASESISCONTROL", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        Comando.Parameters.AddWithValue("@TIPO", Tipo)
        Comando.Parameters.AddWithValue("@DIRECCIONENVIO", UCase(Trim(Tx_Dirección.Text)))
        Comando.Parameters.AddWithValue("@IMPRESOLISTA", "N")
        Comando.Parameters.AddWithValue("@IDDEPENDENCIA", VariablesBase.VariablesBase.IddependenciaSiscontrolActual)
        Comando.Parameters.AddWithValue("@IDCENTROCOSTO", Me.Cu_CentroCosto1.IdCentroCosto)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        Dim Documento As New SqlParameter("@DOCUMENTO", SqlDbType.Char, 30)
        Documento.Direction = ParameterDirection.Output
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Comando.Parameters.Add(Documento)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()

        If Editando = False Then
            Dim fr As New FormDocumento
            fr.Label1.Text = Trim(Documento.Value)
            fr.ShowDialog()
        End If
        conn.Close()

        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "C", "ELABORA", Cu_BuscarPersonaElabora.Cb_Persona.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "C", "FIRMA", Cu_BuscarPersonaFirma.Cb_Persona.SelectedValue)
        FuncionesBase.FuncionesBase.ValoresxDefectoSisControl("G", "C", "CIDUAD", Cu_CiudadDirección.Cb_Ciudad.SelectedValue)
        Me.Close()
    End Sub


    Private Function ValidarCorrespondencia() As Boolean
        If Trim(Tx_Empresa.Text) = "" Then
            MsgBox("Debe Agregar una empresa", MsgBoxStyle.Critical, "EMPRESA")
            Me.Tx_Empresa.Focus()
            ValidarCorrespondencia = False
            Exit Function
        End If

        If Trim(Tx_DirigidoA.Text) = "" Then
            MsgBox("Agrege a quien va dirigida ", MsgBoxStyle.Critical, "DIRIGIDA")
            Me.Tx_DirigidoA.Focus()
            ValidarCorrespondencia = False
            Exit Function
        End If

        If Trim(Tx_Asunto.Text) = "" Then
            MsgBox("Ingrese el asunto", MsgBoxStyle.Critical, "Asunto")
            Me.Tx_Asunto.Focus()
            ValidarCorrespondencia = False
            Exit Function
        End If

        If Trim(Tx_Dirección.Text) = "" Then
            MsgBox("Agrege la dirección ", MsgBoxStyle.Critical, "DIRECION")
            Me.Tx_Asunto.Focus()
            ValidarCorrespondencia = False
            Exit Function
        End If

        If IsNothing(Cu_BuscarPersonaElabora.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione la persona que elabora", MsgBoxStyle.Critical, "ELABORA")
            Cu_BuscarPersonaElabora.Cb_Persona.Focus()
            ValidarCorrespondencia = False
            Exit Function
        End If

        If IsNothing(Cu_BuscarPersonaFirma.Cb_Persona.SelectedValue) Then
            MsgBox("Seleccione la persona que firma", MsgBoxStyle.Critical, "FIRMA")
            Cu_BuscarPersonaFirma.Cb_Persona.Focus()
            ValidarCorrespondencia = False
            Exit Function
        End If

        If IsNothing(Cu_CiudadDirección.Cb_Ciudad.SelectedValue) Then
            MsgBox("Seleccione la ciudad", MsgBoxStyle.Critical, "CIUDAD")
            Cu_CiudadDirección.Cb_Ciudad.Focus()
            ValidarCorrespondencia = False
            Exit Function
        End If

        ValidarCorrespondencia = True
    End Function


    Private Sub Bt_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub


    'Para cargar al asociar una persona.
    Public Sub cargarpersonalasociadobodega(Optional ByVal IDPERSONA As Integer = -1, Optional ByVal NOMBRECOMPONENTE As String = "")
        Dim temp As Integer
        Try
            temp = Me.Cu_BuscarPersonaElabora.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaElabora.CargarDatos()
            Me.Cu_BuscarPersonaElabora.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaElabora.CargarCajaTexto()
        Catch ex As Exception
        End Try

        Try
            temp = Me.Cu_BuscarPersonaFirma.Cb_Persona.SelectedValue
            Me.Cu_BuscarPersonaFirma.CargarDatos()
            Me.Cu_BuscarPersonaFirma.Cb_Persona.SelectedValue = temp
            Me.Cu_BuscarPersonaFirma.CargarCajaTexto()
        Catch ex As Exception
        End Try

        Select Case NOMBRECOMPONENTE
            Case Cu_BuscarPersonaElabora.Name
                Me.Cu_BuscarPersonaElabora.Cb_Persona.SelectedValue = IDPERSONA
            Case Cu_BuscarPersonaFirma.Name
                Me.Cu_BuscarPersonaFirma.Cb_Persona.SelectedValue = IDPERSONA
        End Select
    End Sub

End Class 'Fr_Correspondencia



Public Class FormDocumento
    Inherits System.Windows.Forms.Form


    Public Sub New()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Bt_Cerrar.Location = New System.Drawing.Point(396, 115)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 0
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(9, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(462, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.AutoSize = False
        Me.Label1.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label2.Location = New System.Drawing.Point(14, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(370, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Se creo el documento con el siguiente consecutivo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label3.Location = New System.Drawing.Point(14, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(398, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Marcar la correspondencia con este nro de consecutivo"
        ''
        ''LinkLabel1
        ''
        'Me.LinkLabel1.AutoSize = True
        'Me.LinkLabel1.Location = New System.Drawing.Point(12, 116)
        'Me.LinkLabel1.Name = "LinkLabel1"
        'Me.LinkLabel1.Size = New System.Drawing.Size(115, 13)
        'Me.LinkLabel1.TabIndex = 2
        'Me.LinkLabel1.TabStop = True
        'Me.LinkLabel1.Text = "Descargar Memorando"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 143)
        Me.MaximumSize = New System.Drawing.Size(494, 181)
        Me.MinimumSize = New System.Drawing.Size(494, 181)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Bt_Cerrar)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "Form1"
        Me.Text = "CONSECUTIVO CORRESPONDENCIA"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel


    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Me.Close()
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://190.0.43.174:7070/manuales/memorandosiscontrol.pdf")
    End Sub

End Class 'FormDocumento