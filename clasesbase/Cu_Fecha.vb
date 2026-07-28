Public Class Cu_Fecha

  Private Sub Cu_Fecha_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Lb_Fecha.Text = Now.ToLongDateString
  End Sub

End Class
