Imports System.Drawing

Public Class Fr_MostrarFoto

    Public Sub Set_Pb_Foto_Image(ByVal image As Image)
        Pb_Foto.Image = image
    End Sub

    Public Function Get_Pb_Foto_Image()
        Return Pb_Foto.Image
    End Function

End Class