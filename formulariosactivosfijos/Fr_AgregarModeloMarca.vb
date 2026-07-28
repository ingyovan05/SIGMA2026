Public Class Fr_AgregarModeloMarca

    Public modelomarca As Boolean
    Public idmarca As Integer = 0
    Public agregada As Boolean = False
    Dim ds As New DataSet
    Dim bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()

    Private Sub Fr_AgregarModeloMarca_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'si la variable modelomarca es falsa se va a agregar un modelo, si es verdadera se agrega una marca
        If modelomarca = False Then
            Lb_Info.Text = "Escriba el Nombre del Modelo que desea agregar, Asegurese de que no exista"
        Else
            Lb_Info.Text = "Escriba el Nombre de la Marca que desea agregar, Asegurese de que no exista"
        End If
    End Sub

    Private Sub Bt_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Aceptar.Click
        If modelomarca = True Then
            'agregar marca
            Try
                ds = bddatos.ModificarMarcasModelos(4, 0, 0, "", UCase(Tb_ModeloMarca.Text))
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
            If ds.Tables(0).Rows.Count > 0 Then
                MsgBox("La marca ya se encuentra registrada", MsgBoxStyle.Critical, "error")
                Exit Sub
            Else
                MsgBox("Marca agregada", MsgBoxStyle.OkOnly, "exito")
                agregada = True
                Me.Close()
            End If
        Else
            'agregar modelo
            Try
                ds = bddatos.ModificarMarcasModelos(2, 0, idmarca, UCase(Tb_ModeloMarca.Text), "")
                If ds.Tables(0).Rows.Count > 0 Then
                    MsgBox("El modelo ya se encuentra registrado", MsgBoxStyle.Critical, "error")
                    Exit Sub
                Else
                    MsgBox("Modelo agregado", MsgBoxStyle.OkOnly, "exito")
                    agregada = True
                    Me.Close()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
    End Sub
End Class