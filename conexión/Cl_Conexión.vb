Imports System.IO
Imports System.Windows.Forms
Imports VarBase = VariablesBase.VariablesBase
Imports FunBase = FuncionesBase.FuncionesBase

Public Module Cl_Conexión
    Private archivo As String = Application.StartupPath & "\Servidor.xml"
    Public Ds_Configuración_Servidor As New DataSet("ConfiguracionServidor")

    Public Function LeerTablaConfServidor() As DataSet
        If File.Exists(archivo) = True Then
            Try
                Ds_Configuración_Servidor.Clear()
                Ds_Configuración_Servidor.ReadXml(archivo, XmlReadMode.ReadSchema)
                Ds_Configuración_Servidor = DesencriptarTablas(Ds_Configuración_Servidor)
                If Not Ds_Configuración_Servidor.Tables(0).Columns.Contains("ORDEN") Then
                    Ds_Configuración_Servidor.Tables(0).Columns.Add("ORDEN")
                End If
                If Not Ds_Configuración_Servidor.Tables(0).Columns.Contains("DESCRIPCION") Then
                    Ds_Configuración_Servidor.Tables(0).Columns.Add("DESCRIPCION")
                End If
                Dim filaDescripcion As DataRow
                For i As Integer = 0 To Ds_Configuración_Servidor.Tables(0).Rows.Count - 1
                    filaDescripcion = Ds_Configuración_Servidor.Tables(0).Rows(i)
                    If IsDBNull(filaDescripcion.Item("ORDEN")) Then
                        filaDescripcion.Item("ORDEN") = i
                    End If
                    If IsDBNull(filaDescripcion.Item("DESCRIPCION")) Then
                        filaDescripcion.Item("DESCRIPCION") = DescripcionConexion(If(Not IsDBNull(filaDescripcion.Item("SERVIDOR")), filaDescripcion.Item("SERVIDOR"), ""), If(Not IsDBNull(filaDescripcion.Item("NOMBREBASEDATOS")), filaDescripcion.Item("NOMBREBASEDATOS"), ""))
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Ds_Configuración_Servidor.Tables.Add(New DataTable("SERVIDOR"))
        End If
        Return Ds_Configuración_Servidor
    End Function

    Public Sub Establecer_Parametros(Servidor As String, Usuario As String, Contraseña As String, NombreBaseDatos As String, Optional timeOut As Integer = 30)
        VarBase.Conexion_Remota_Sql_Server.ConnectionString = "Data Source=" & Servidor & ";" & _
                                                                                  "Initial Catalog=" & NombreBaseDatos & ";" & _
                                                                                  "Persist Security Info=True;" & _
                                                                                  "User ID=" & Usuario & ";" & _
                                                                                  "Password=" & Contraseña & ";" & _
                                                                                  "Connect Timeout = " & timeOut
        VarBase.Contraseña = Contraseña
        VarBase.Servidor = Servidor
        VarBase.Usuario = Usuario
        VarBase.NombreBaseDatos = NombreBaseDatos
        My.Settings.CadenaConexión = VarBase.Conexion_Remota_Sql_Server.ConnectionString
    End Sub

    Public Sub GuardarTablaConfServidor()
        Ds_Configuración_Servidor.AcceptChanges()
        Ds_Configuración_Servidor = EncriptarTablas(Ds_Configuración_Servidor)
        Ds_Configuración_Servidor.WriteXml(archivo, XmlWriteMode.WriteSchema)
    End Sub

    Public Function EncriptarTablas(ds As DataSet) As DataSet
        Dim ds2 As DataSet = ds.Clone()
        Dim fila As DataRow
        For i As Integer = 0 To ds.Tables.Count - 1
            For j As Integer = 0 To ds.Tables(i).Rows.Count - 1
                fila = ds2.Tables(i).NewRow
                For k As Integer = 0 To ds.Tables(i).Rows(j).ItemArray.Count - 1
                    If Not IsDBNull(ds.Tables(i).Rows(j).Item(k)) Then
                        fila.Item(k) = FunBase.Encryptar(ds.Tables(i).Rows(j).Item(k))
                    End If
                Next
                ds2.Tables(i).Rows.Add(fila)
            Next
        Next
        Return ds2
    End Function

    Public Function DesencriptarTablas(ds As DataSet) As DataSet
        Dim ds2 As DataSet = ds.Clone()
        Dim fila As DataRow
        For i As Integer = 0 To ds.Tables.Count - 1
            For j As Integer = 0 To ds.Tables(i).Rows.Count - 1
                fila = ds2.Tables(i).NewRow
                For k As Integer = 0 To ds.Tables(i).Rows(j).ItemArray.Count - 1
                    If Not IsDBNull(ds.Tables(i).Rows(j).Item(k)) Then
                        fila.Item(k) = FunBase.Desencryptar(ds.Tables(i).Rows(j).Item(k))
                    End If
                Next
                ds2.Tables(i).Rows.Add(fila)
            Next
        Next
        Return ds2
    End Function

    Private Function DescripcionConexion(servidor As String, baseDatos As String) As String
        Select Case servidor
            Case "192.168.20.9"
                If baseDatos = "ISMOCOLPRODUCCION" Then
                    Return "Real local"
                Else
                    Return "Pruebas local"
                End If
            Case "190.0.43.170"
                If baseDatos = "ISMOCOLPRODUCCION" Then
                    Return "Real Claro"
                Else
                    Return "Pruebas Claro"
                End If
            Case "186.148.190.202"
                If baseDatos = "ISMOCOLPRODUCCION" Then
                    Return "Real Azteca"
                Else
                    Return "Pruebas Azteca"
                End If
            Case Else
                Return "Conexión no identificada"
        End Select
    End Function

End Module 'Cl_Conexión