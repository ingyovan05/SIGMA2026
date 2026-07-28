Public Module Configurar

    Public Function ExtraerConexiónInicial() As String
        ExtraerConexiónInicial = My.Settings.CadenaConexión
    End Function

  Public Sub ConfigurarConexión(ByVal CadenaConexión As String)
    My.Settings.CadenaConexión = CadenaConexión
  End Sub



End Module
