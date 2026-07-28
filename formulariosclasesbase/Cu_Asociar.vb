Public Class Cu_Asociar

    Public _Tipo As String
    ' OC asociar orden de compra 
    ' OT asociar orden de mantenimiento

    Public Identificador As Integer = -1


    Public Property Tipo() As String
        Get
            Return CType(_Tipo, String)
        End Get
        Set(value As String)
            _Tipo = value
        End Set
    End Property


    Private Sub Ll_OrdenCompra_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_Asociar.LinkClicked
        Dim FrBusqueda As New Fr_Asociar
        Select Case _Tipo
            Case "OC"
                FrBusqueda.Tipo = _Tipo
                FrBusqueda.ComboBox_Filtrar.Items.Add("OrdenCompra")
                FrBusqueda.ComboBox_Filtrar.SelectedIndex = 0
            Case "OT"
                FrBusqueda.Tipo = _Tipo
                FrBusqueda.ComboBox_Filtrar.Items.Add("OrdenSap")
                FrBusqueda.ComboBox_Filtrar.Items.Add("Objeto")
                FrBusqueda.ComboBox_Filtrar.Items.Add("CodigoIsmocol")
                FrBusqueda.ComboBox_Filtrar.SelectedIndex = 0
        End Select
        FrBusqueda.ShowDialog()
        If IsNothing(FrBusqueda.Resultado) Then
        Else
            Me.Identificador = FrBusqueda.Identificador
            Me.Ll_Asociar.Text = FrBusqueda.Resultado 'puede ser texto o numerico dependiendo de la tabla
        End If
    End Sub

    Public Sub Cargar()
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        sqlconeccion.Open()
        Select Case _Tipo
            Case "OC"
                Dim cmd As New SqlClient.SqlCommand("select  rtrim(ltrim(ORDENCOMPRA)) AS OrdenCompra FROM ORDENCOMPRA where  IDORDENCOMPRA=" + Identificador.ToString, sqlconeccion)
                Me.Ll_Asociar.Text = Trim(cmd.ExecuteScalar())
                If Identificador = -1 Then
                    Me.Ll_Asociar.Text = "SIN ASOCIAR " + Tipo
                End If
            Case "OT"
                Dim cmd As New SqlClient.SqlCommand("select NROORDENSAP AS OrdenSap FROM OT_ORDENTRABAJO  where  IDORDENTRABAJO=" + Identificador.ToString, sqlconeccion)
                Me.Ll_Asociar.Text = Trim(cmd.ExecuteScalar())
                If Identificador = -1 Then
                    Me.Ll_Asociar.Text = "SIN ASOCIAR " + Tipo
                End If
        End Select

        sqlconeccion.Close()
    End Sub

End Class
