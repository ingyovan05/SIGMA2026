Imports System.Drawing

Public Class Uc_ItemBarraHerramientas

    Inherits Windows.Forms.Panel

    Public Property Alto As Integer
    Public Property Titulo As String = ""
    Public Property Imagen As Integer = -1

    Dim valor_defecto As Integer = 30

    Dim padre As Object

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lb_titulo.Click
        ExpandirMenu()
    End Sub

    Public Sub ExpandirMenu()
        padre = Me.Parent
        Try
            For i = 0 To padre.Controls.Count - 1
                If padre.controls(i).name <> "Pn_HoraFecha" Then
                    padre.Controls(i).Height = valor_defecto



                    padre.Controls(i).Lb_titulo.BackColor = Color.AliceBlue
                    padre.Controls(i).Lb_titulo.forecolor = Color.Black
                    padre.Controls(i).Pb_Imagen.BackColor = Color.AliceBlue
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Me.Lb_titulo.BackColor = Color.Blue
        Me.Pb_Imagen.BackColor = Color.Blue
        Me.Lb_titulo.ForeColor = Color.White
        Me.Height = Alto
    End Sub

    Private Sub Uc_ItemBarraHerramientas_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout
        Me.SuspendLayout()
        Try
            Me.Lb_titulo.Text = Titulo
        Catch ex As Exception
        End Try
        Try
            If Imagen <> -1 Then
                Me.Pb_Imagen.Image = Il_Imagenes.Images(Imagen)
            End If
        Catch ex As Exception
        End Try
        Me.ResumeLayout()
    End Sub

    Private Sub Lb_titulo_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lb_titulo.MouseHover
        If Me.Lb_titulo.BackColor <> Color.Blue Then
            Me.Lb_titulo.BackColor = Color.NavajoWhite
            Me.Pb_Imagen.BackColor = Color.NavajoWhite
        End If

    End Sub

    Private Sub Lb_titulo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lb_titulo.MouseLeave
        If Me.Lb_titulo.BackColor <> Color.Blue Then
            Me.Lb_titulo.BackColor = Color.AliceBlue
            Me.Pb_Imagen.BackColor = Color.AliceBlue
        End If
    End Sub

    Dim AltoEstablecido As Boolean = False

    Private Sub Uc_ItemBarraHerramientas_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If AltoEstablecido = False Then
            AltoEstablecido = True
            Me.Alto = Me.Height
            Me.valor_defecto = Me.Lb_titulo.Height
        End If
        
    End Sub

    
End Class
