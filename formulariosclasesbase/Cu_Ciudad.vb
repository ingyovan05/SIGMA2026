Public Class Cu_Ciudad

    Public Sub New()
        InitializeComponent()
        AddHandler Cb_Ciudad.KeyDown, AddressOf FuncionesBase.FuncionesBase.ComboBoxAutocompletar_KeyDown
    End Sub

    Private Sub Cu_Ciudad_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Tx_Codigo.Text = Me.Cb_Ciudad.SelectedValue
        Catch ex As Exception
        End Try

    End Sub

    Public Sub CargarDatos()
        If VariablesBase.VariablesBase.TablaPOBLACIONES Is Nothing Then
            VariablesBase.VariablesBase.TablaPOBLACIONES = New DatosClasesBaseBuscar.Ds_FrBuscarCiudad.MA_POBLACIONDataTable
            Me.MA_POBLACIONTableAdapter.Fill(VariablesBase.VariablesBase.TablaPOBLACIONES)
        End If
        Me.Cb_Ciudad.DataSource = VariablesBase.VariablesBase.TablaPOBLACIONES
    End Sub

    Private Sub Caja_Texto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cb_Ciudad.GotFocus, Tx_Codigo.GotFocus
        Dim Objeto As Object = sender
        Objeto.backcolor = Drawing.Color.MintCream
    End Sub

    Private Sub Caja_Texto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tx_Codigo.LostFocus
        Dim Objeto As Object = sender
        Objeto.backcolor = Drawing.Color.White
        Try
            'Buscar la población por código
            Dim Padre As New Object
            Padre = Me.ParentForm
            Padre.EventoEnterCiudad(Me.Name)
            If Me.Tx_Codigo.Text = "" Then
                Me.Cb_Ciudad.SelectedIndex = -1
            End If
            Me.Cb_Ciudad.Focus()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Caja_Texto1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cb_Ciudad.LostFocus
        Dim Objeto As Object = sender
        Objeto.backcolor = Drawing.Color.White
    End Sub


    Private Sub Cb_Ciudad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_Ciudad.SelectedIndexChanged
        Try
            Me.Tx_Codigo.Text = Me.Cb_Ciudad.SelectedValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Bt_Buscar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Buscar.Click
        Dim FrBuscarCiudad As New Fr_Buscar_Ciudad
        FrBuscarCiudad.Text = Me.Bt_Buscar.Tag
        FrBuscarCiudad.ShowDialog()
        Try
            VariablesBase.VariablesBase.TablaPOBLACIONES = Nothing
            CargarDatos()
            Me.Cb_Ciudad.SelectedValue = FrBuscarCiudad.ComboBox_Municipio.SelectedValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Tx_Codigo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Tx_Codigo.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                'Buscar la población por código
                Dim Padre As New Object
                Padre = Me.ParentForm
                Padre.EventoEnterCiudad(Me.Name)
                Me.Cb_Ciudad.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub



End Class


