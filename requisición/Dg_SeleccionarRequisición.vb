Imports System.Windows.Forms

Public Class Dg_SeleccionarRequisición

    Public IDREQUISICION As Int64 = -1
    Public IDBODEGA As Int64 = -1


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.DsOrdenCompra.REQUISICION.Count = 0 Then
            MsgBox("No se ha seleccionado ninguna requisicion", MsgBoxStyle.Critical, "Seleccionar Requisición")
            Exit Sub
        End If
        If Me.Cb_Requisición.SelectedIndex = -1 Then
            MsgBox("No se ha seleccionado ninguna requisicion", MsgBoxStyle.Critical, "Seleccionar Requisición")
            Exit Sub
        End If
        IDBODEGA = Me.Cb_Bodega.SelectedValue
        IDREQUISICION = Me.Cb_Requisición.SelectedValue
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Dim DsOrdenCompra As New DatosRequisición.Ds_OrdenCompra


    Public Sub CargarCombos()
        If FuncionesBase.FuncionesBase.EsBodegaPrincipal(VariablesBase.VariablesBase.IdBodegaActual) Then
            Dim BODEGATableAdapter As New DatosRequisición.Ds_OrdenCompraTableAdapters.BODEGATableAdapter
            BODEGATableAdapter.Fill(Me.DsOrdenCompra.BODEGA)
            Me.Cb_Bodega.DataSource = Me.DsOrdenCompra.BODEGA
            Me.Cb_Bodega.DisplayMember = "ABREVIATURA"
            Me.Cb_Bodega.ValueMember = "IDBODEGA"
            Me.Cb_Bodega.SelectedValue = VariablesBase.VariablesBase.IdBodegaActual
        Else
            Me.Cb_Bodega.Items.Add(VariablesBase.VariablesBase.AbreviaturaBodegaActual)
            Me.Cb_Bodega.SelectedIndex = 0
        End If
    End Sub

    Private Sub Bt_Cargar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Cargar.Click
        CargarRequisiciones()
    End Sub

    Public Sub CargarRequisiciones()
        Dim REQUISICIONTableAdapter As New DatosRequisición.Ds_OrdenCompraTableAdapters.REQUISICIONTableAdapter

        If Me.DsOrdenCompra.BODEGA.Count > 0 Then
            If Me.Cb_Bodega.SelectedIndex = -1 Then
                MsgBox("Seleccione la bodega de la cual desea cargar las requisiciones pendiente")
                Exit Sub
            Else
                'If VariablesBase.VariablesBase.TipoUsuario = 17 Then
                REQUISICIONTableAdapter.FillIDCOMPRADOR(Me.DsOrdenCompra.REQUISICION, Cb_Bodega.SelectedValue, VariablesBase.VariablesBase.IdPersona)
                '    Else
                '    REQUISICIONTableAdapter.FillByPENDIENTESASIGNAR(Me.DsOrdenCompra.REQUISICION, Cb_Bodega.SelectedValue)
                '    'REQUISICIONTableAdapter.FillREQPENDIENTES(Me.DsOrdenCompra.REQUISICION, Cb_Bodega.SelectedValue)
                'End If
            End If
        Else
            'If VariablesBase.VariablesBase.TipoUsuario = 17 Then
            REQUISICIONTableAdapter.FillIDCOMPRADOR(Me.DsOrdenCompra.REQUISICION, VariablesBase.VariablesBase.IdBodegaActual, VariablesBase.VariablesBase.IdPersona)
            'Else
            '    REQUISICIONTableAdapter.FillREQPENDIENTES(Me.DsOrdenCompra.REQUISICION, VariablesBase.VariablesBase.IdBodegaActual)
            'End If
        End If

        Me.Cb_Requisición.DataSource = Me.DsOrdenCompra.REQUISICION
        Me.Cb_Requisición.DisplayMember = "REQUISICION"
        Me.Cb_Requisición.ValueMember = "IDREQUISICION"
        Me.Cb_Requisición.SelectedIndex = -1
    End Sub

    Private Sub Cb_Bodega_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_Bodega.SelectedIndexChanged
        Me.Cb_Requisición.DataSource = Nothing
    End Sub

End Class
