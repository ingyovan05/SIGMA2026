Public Class Cu_AsociarPersonaBodega

    Private _componenteasociado As String
    Private _CrearUsuario As Boolean
    Private _TipoAsociacion As String = "BOD"
    Private _TipoBúsqueda As String = "P"
    Public Property componenteasociado() As String
        Get
            Return CType(_componenteasociado, String)
        End Get
        Set(value As String)
            _componenteasociado = value
        End Set
    End Property

    Public Property CrearUsuario() As Boolean
        Get
            Return CType(_CrearUsuario, Boolean)
        End Get
        Set(value As Boolean)
            _CrearUsuario = value
        End Set
    End Property

    Public Property TipoAsociacion() As String
        Get
            Return CType(_TipoAsociacion, String)
        End Get
        Set(ByVal value As String)
            _TipoAsociacion = value
        End Set
    End Property

    Public Property TipoBúsqueda() As String
        Get
            Return CType(_TipoBúsqueda, String)
        End Get
        Set(ByVal value As String)
            _TipoBúsqueda = value
        End Set
    End Property


    Private Sub Bt_AsociarPersonaBodega_Click(sender As System.Object, e As System.EventArgs) Handles Bt_AsociarPersonaBodega.Click

        Select Case _TipoAsociacion
            Case "DEP"
                Dim Padre As Object
                Padre = Me.Parent
                If Me.Parent.Name.ToString = "Fr_CorrespondenciaRecibida" Or Me.Parent.Name.ToString = "Fr_OrdenServicio" Or Me.Parent.Name.ToString = "Fr_Visitante" Or Me.Parent.Name.ToString = "Fr_Sobres" Then
                    Padre.CambiarDependenciaParaAsociar()
                End If
        End Select

        Dim Fr_AsociarPersonaBodega As New Fr_AsociarPersonaBodega
        Fr_AsociarPersonaBodega.TipoAsociacion = TipoAsociacion
        Fr_AsociarPersonaBodega.CrearUsuario = CrearUsuario
        Fr_AsociarPersonaBodega.TipoBúsqueda = TipoBúsqueda
        Fr_AsociarPersonaBodega.ShowDialog()
        Try
            If Fr_AsociarPersonaBodega.Respuesta = True Then
                Dim formpadre As Object
                formpadre = Me.ParentForm
                formpadre.cargarpersonalasociadobodega(Fr_AsociarPersonaBodega.IDPERSONA, Me.componenteasociado)
            End If
        Catch ex As Exception
        End Try
    End Sub



End Class
