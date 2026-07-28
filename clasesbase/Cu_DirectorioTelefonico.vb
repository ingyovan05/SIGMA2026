Imports System.Windows.Forms


Public Class Cu_DirectorioTelefonico


    Private Sub cu_directorio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.WebBrowser1.Navigate("http://190.0.43.174:6565/admin/loginAdmin.aspx")
        Me.WebBrowser1.Navigate("http://190.0.43.174:6565/Inicio.aspx?UBICACION=Bucaramanga")
        WebBrowser1.ScriptErrorsSuppressed = True

    End Sub





    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        WebBrowser1.Document.Body.Style = "zoom:120%"
        Dim superior = WebBrowser1.Document.GetElementById("superior")
        If superior IsNot Nothing Then
            WebBrowser1.Document.GetElementById("superior").SetAttribute("hidden", True)
        End If

       

      
        Dim cookiee = WebBrowser1.Document.Cookie

        If cookiee = "User=ismocol" Then


        Else
            Dim usuario = WebBrowser1.Document.GetElementById("ContentPlaceHolder1_Tx_User")
            Dim contraseña = WebBrowser1.Document.GetElementById("ContentPlaceHolder1_Tx_Pass")
            If usuario IsNot Nothing Then
                WebBrowser1.Document.GetElementById("ContentPlaceHolder1_Tx_User").SetAttribute("value", "ismocol")
            End If

            If contraseña IsNot Nothing Then
                WebBrowser1.Document.GetElementById("ContentPlaceHolder1_Tx_Pass").SetAttribute("value", "Sis*2022@")
            End If

            WebBrowser1.Document.GetElementById("ContentPlaceHolder1_Bt_Login").InvokeMember("click")



        End If

        'Dim count As Integer
        'count = WebBrowser1.Document.Cookie.Length
        'WebBrowser1.Document.Cookie.Remove(0, count)






    End Sub
 
    Private Sub WebBrowser1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then

            MsgBox("Form1_MouseUp(ByVal sender As System.Object, ByVal e AsSystem.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown")

        End If
    End Sub


End Class
