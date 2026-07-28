Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Fr_Acerca

    Private Sub Fr_Acerca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM AcercaDeSigma()", conexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtAcerca As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtAcerca)
        Catch ex As Exception
            Exit Sub
        Finally
            conexion.Close()
        End Try
        Dim drSoporteAplicaciones As DataRow = dtAcerca.Select("[TIPO]" & " = " & " 'SOPORTEAPLICACIONES' ")(0)
        Dim drDesarrolloAplicaciones As DataRow = dtAcerca.Select("[TIPO]" & " = " & " 'DESARROLLOAPLICACIONES' ")(0)
        Dim drCodificacionArticulos As DataRow = dtAcerca.Select("[TIPO]" & " = " & " 'CODIFICACIONARTICULOS' ")(0)

        Ll_Persona1.Text = drSoporteAplicaciones("NOMBRE")
        Tx_Correo1.Text = drSoporteAplicaciones("CORREO")
        Tx_Celular1.Text = drSoporteAplicaciones("CELULAR")
        Tx_Contacto1.Text = drSoporteAplicaciones("CONTACTO")

        Ll_Persona2.Text = drDesarrolloAplicaciones("NOMBRE")
        Tx_Correo2.Text = drDesarrolloAplicaciones("CORREO")
        Tx_Celular2.Text = drDesarrolloAplicaciones("CELULAR")
        Tx_Contacto2.Text = drDesarrolloAplicaciones("CONTACTO")

        Ll_Persona3.Text = drCodificacionArticulos("DESCRIPCIONTIPO")
        Tx_Correo3.Text = drCodificacionArticulos("CORREO")
        Tx_Contacto3.Text = drCodificacionArticulos("CONTACTO")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles Pb_Ayuda.Click, Ll_Ayuda.LinkClicked
        FuncionesBase.FuncionesBase.AbrirAyudaOnline("")
    End Sub

End Class