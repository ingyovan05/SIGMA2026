Imports System.Windows.Forms

Public Class Fr_Buscar_Ciudad


  Dim busqueda As Boolean = False

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Actualizar maestro
        Try
            If Me.ComboBox_Municipio.Enabled = False Then
                MsgBox("Debe seleccionar el municipio o ciudad!", MsgBoxStyle.Information, "MUNICIPIO")
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    'Verificar que el codigo del municipio no este en la lista
    If busqueda = False Then
      Try
        If CInt(Me.MA_POBLACIONTableAdapter1.Existepoblación(Me.ComboBox_Municipio.SelectedValue)) = 0 Then
          'Cargar municipio en el combox

          'MsgBox("Este muncipio ya esta registrado", MsgBoxStyle.Information, "MUNICIPIO")
          'Exit Sub
          Try
            Me.MA_POBLACIONTableAdapter1.Insert(Nothing, Me.ComboBox_Municipio.SelectedValue, Me.ComboBox_Municipio.Text)
          Catch ex As Exception
            MsgBox("Error al actualizar la lista de ciudades", MsgBoxStyle.Critical, "ERROR DE ACTUALIZACION")
            MsgBox(ex.ToString)
            Exit Sub
          End Try
        End If
      Catch ex As Exception
      End Try
    End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ComboBox_Pais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Pais.SelectedIndexChanged
        Try
            Me.MA_POBLACIONMAESTRADEPARTAMENTOTableAdapter.Fill(Me.Ds_FrBuscarCiudad .MA_POBLACIONMAESTRADEPARTAMENTO , Me.ComboBox_Pais.SelectedValue)
            Me.ComboBox_Departamento.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Fr_Buscar_Ciudad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Ds_FrBuscarCiudad.MA_POBLACIONMAESTRAPAIS' Puede moverla o quitarla según sea necesario.
        Me.MA_POBLACIONMAESTRAPAISTableAdapter.Fill(Me.Ds_FrBuscarCiudad.MA_POBLACIONMAESTRAPAIS)
    End Sub

    Private Sub ComboBox_Departamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_Departamento.SelectedIndexChanged
        Try
            Me.MA_POBLACIONMAESTRAMUNICIPIOTableAdapter.Fill(Me.Ds_FrBuscarCiudad.MA_POBLACIONMAESTRAMUNICIPIO, Me.ComboBox_Pais.SelectedValue, Me.ComboBox_Departamento.SelectedValue)
            Me.ComboBox_Municipio.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

End Class
