Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class Fr_Artículo
    Public Nuevo As Boolean
    Public IdArticuloEditando As Integer
    Public CODIGOCATEGORIA As Integer
    Public IDUNIDAD As Integer
    Public filas As Integer
    Private DsArtículo As New DatosArticulos.Ds_Artículos
    Private VistaTipoUnidad As DataView
    Private FiltroTipoUnidad As String
    Private ValorRefDecimal As Decimal
    Private SubioFoto As Boolean = False
    Private EliminoFoto As Boolean = False
    Private CódigoSistemaAccess As String = ""
    Private bddatos1 As New FuncionesBase.ClaseCargarMaestras
    Private ds As New DataSet
    Private dstipos As New DataSet
    Private dssubtipos As New DataSet
    Private bddatos As New DatosActivosFijos.ClaseDatosActivosFijos()
    Private tipopivote As Integer = Nothing  'para saber si se va a editar el tipo y el subtipo y advertir al usuario
    Private subtipopivote As Integer = Nothing
    Private dsCargar As New DataSet
    Public CargaFotoServidor As Boolean = True
    Private GoogleDrive As New FuncionesGoogle.FuncionesGoogle

    Public Sub New()
        InitializeComponent()
        AddHandler Tx_ValorReferencia.KeyPress, AddressOf FuncionesBase.FuncionesBase.TextBoxMoneda_KeyPress
        AddHandler Tx_ValorReferencia.LostFocus, AddressOf FuncionesBase.FuncionesBase.TextBoxMoneda_Lostfocus
    End Sub

    Private Sub Fr_Articulo_Closed() Handles MyBase.FormClosed
        Pb_FotoArticulo.Image.Dispose()
        Dim appPath As String
        Try
            appPath = Application.StartupPath + "\Temp.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
        Try
            appPath = Application.StartupPath + "\Temp2.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
        Try
            appPath = Application.StartupPath + "\Temp3.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Comportamiento_Predeterminado()
        Bt_CargarFoto.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Bt_CargarFoto.Tag)
    End Sub

    Public Sub Cargar_Tablas()
        Comportamiento_Predeterminado()
        dsCargar = bddatos1.CargarMaestrasMateriales(8, VariablesBase.VariablesBase.IdBodegaActual, IdArticuloEditando, 1)

        Me.Cb_TipoMedida.DataSource = dsCargar.Tables(1)
        Me.Cb_TipoMedida.DisplayMember = "DESCRIPCIONTIPOMEDIDA"
        Me.Cb_TipoMedida.ValueMember = "CODIGOTIPOMEDIDA"
        Me.Cb_TipoMedida.SelectedIndex = 0

        FiltroTipoUnidad = "CODIGOTIPOMEDIDA=" + Me.Cb_TipoMedida.SelectedValue.ToString

        VistaTipoUnidad = New DataView(dsCargar.Tables(2))
        VistaTipoUnidad.RowFilter = FiltroTipoUnidad

        Me.Cb_Unidad.DataSource = VistaTipoUnidad
        Me.Cb_Unidad.DisplayMember = "DESCRIPCION"
        Me.Cb_Unidad.ValueMember = "CODIGOTIPOUNIDAD"
        Me.Cb_Unidad.SelectedIndex = 0

        Me.Cb_IVA.Text = 19

        'llenar la tabla de tipo y la tabla de personas
        Cb_TipoArticulo.DataSource = Nothing
        CargarTipos()
        Try
            Dim filas() As DataRow
            filas = DsArtículo.MA_TIPOUNIDAD.Select("CODIGOTIPOUNIDAD=" + IDUNIDAD.ToString)
            Dim fila As DataRow
            fila = filas(0)
            Me.Cb_TipoMedida.SelectedValue = fila("CODIGOTIPOMEDIDA")
            Me.Cb_Unidad.SelectedValue = IDUNIDAD
        Catch ex As Exception
        End Try
        If Nuevo = False Then
            Dim fila As DataRow

            fila = Me.dsCargar.Tables(0).Rows(0)
            Me.Tx_NombreArtículo.Text = Trim(fila("NOMBRE"))
            CódigoSistemaAccess = Trim(fila("CODIGOACCESS"))
            Me.Tx_DescripciónArtículo.Text = Trim(fila("NOMBREDESCRIPTIVO"))
            Me.Tx_CódigoBarra.Text = Trim(fila("CODIGOBARRAISMOCOL"))
            If Trim(fila("ESTADOARTICULO")) = "I" Then
                Me.Ck_Activo.Checked = False
            Else
                Me.Ck_Activo.Checked = True
            End If
            ValorRefDecimal = FuncionesBase.FuncionesBase.ValorRealDec(fila("VALORREFERENCIA")).ToString()
            Me.Tx_ValorReferencia.Text = Format(ValorRefDecimal, "C")
            Me.Tx_UsuarioModificaValorRef.Text = fila("IDUSUARIOMODIFICAREF")

            Me.Cb_IVA.Text = fila("TARIFAIVA")

            Dim filas() As DataRow

            filas = dsCargar.Tables(2).Select("CODIGOTIPOUNIDAD=" + fila("CODIGOTIPOUNIDAD").ToString)
            Dim fila1 As DataRow
            fila1 = filas(0)
            Me.Cb_TipoMedida.SelectedValue = fila1("CODIGOTIPOMEDIDA")
            Me.Cb_Unidad.SelectedValue = fila("CODIGOTIPOUNIDAD")

            'revisar si tiene un tipo y un subtipo asociado
            If (fila("IDTIPO").ToString <> "") Then
                tipopivote = fila("IDTIPO")
                Cb_TipoArticulo.SelectedValue = fila("IDTIPO")

                If (fila("IDSUBTIPO").ToString <> "") Then
                    subtipopivote = fila("IDSUBTIPO")
                    Cb_SubtipoArticulo.SelectedValue = fila("IDSUBTIPO")

                End If
            End If

            'revisar si ya se ha usado el articulo en alguna requisición traslado u orden de compra y bloquear las unidades 
            Dim dsEntradas As New DataSet
            dsEntradas = bddatos.ModificarEntradasSalidas(22, 0, fila("IDARTICULO"), 0, Date.Now, 0, Date.Now, "", 0, 0)
            If dsEntradas.Tables(0).Rows(0)("conteo") > 0 Then
                Cb_Unidad.Enabled = False
                Cb_TipoMedida.Enabled = False
            End If

            Dim imagen As Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(3, fila("IDARTICULO"))
            If imagen IsNot Nothing Then
                Pb_FotoArticulo.Image = imagen
            Else
                Pb_FotoArticulo.Image = Im_Defecto.Images(0)
            End If
        End If
    End Sub

    Private Sub Cb_TipoMedida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_TipoMedida.SelectedIndexChanged
        Try
            FiltroTipoUnidad = "CODIGOTIPOMEDIDA=" + Me.Cb_TipoMedida.SelectedValue.ToString
            VistaTipoUnidad.RowFilter = FiltroTipoUnidad
            Me.Cb_Unidad.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Bt_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Cancelar.Click
        If MsgBox("¿Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo, "SALIR") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Function ValidarArticulo() As Boolean
        If Trim(Me.Tx_NombreArtículo.Text) = "" Then
            MsgBox("Debe digitar el nombre del artículo", MsgBoxStyle.Critical, "NOMBRE ARTÍCULO")
            Return False
        End If
        If Me.Cb_IVA.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar el IVA del artículo", MsgBoxStyle.Critical, "IVA ARTÍCULO")
            Return False
        End If

        If FuncionesBase.FuncionesBase.ValorRealDec(Me.Tx_ValorReferencia.Text) <= 0 Then
            MsgBox("Debe ingresar el valor de referencia del artículo", MsgBoxStyle.Critical, "VALOR DE REFERENCIA")
            Me.Tx_ValorReferencia.Focus()
            Return False
        End If
        If Ck_Activo.Checked = False And Not Nuevo Then
            Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
            Dim comando As New SqlCommand("SELECT dbo.ArticuloTieneEquipos(@IdArticulo)", conexion)
            comando.Parameters.AddWithValue("@IdArticulo", IdArticuloEditando)
            Dim esEquipoAF As String = ""
            Try
                comando.Connection.Open()
                esEquipoAF = comando.ExecuteScalar()
                comando.Connection.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                comando.Connection.Close()
            End Try
            If esEquipoAF <> "N" Then
                MsgBox("No se puede desactivar el artículo porque tiene equipos activos asociados.", MsgBoxStyle.Critical, "ARTÍCULO CON EQUIPOS ASOCIADOS")
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub Bt_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bt_Guardar.Click
        If ValidarArticulo() = False Then
            Exit Sub
        End If
        Dim Comando As New SqlClient.SqlCommand("dbo.GestionarArtículo")
        Comando.CommandType = CommandType.StoredProcedure
        If Nuevo = True Then
            Comando.Parameters.AddWithValue("@TIPO", 1)
            Comando.Parameters.AddWithValue("@IDARTICULOMOD", -1)
        Else
            Comando.Parameters.AddWithValue("@TIPO", 2)
            Comando.Parameters.AddWithValue("@IDARTICULOMOD", IdArticuloEditando)
        End If
        Comando.Parameters.AddWithValue("@CODIGOCATEGORIA", CODIGOCATEGORIA)
        Comando.Parameters.AddWithValue("@NOMBRE", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Me.Tx_NombreArtículo.Text))
        Comando.Parameters.AddWithValue("@NOMBREDESCRIPTIVO", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Me.Tx_DescripciónArtículo.Text))
        Comando.Parameters.AddWithValue("@CODIGOBARRAISMOCOL", Me.Tx_CódigoBarra.Text)
        Dim ValorRef As Decimal = FuncionesBase.FuncionesBase.ValorRealDec(Me.Tx_ValorReferencia.Text)
        If ValorRef <> ValorRefDecimal Then
            Comando.Parameters.AddWithValue("@VALORREFERENCIA", ValorRef)
            Comando.Parameters.AddWithValue("@FECHAMODIFICACIONREF", DateTime.Now)
            Comando.Parameters.AddWithValue("@IDUSUARIOMODIFICAREF", VariablesBase.VariablesBase.IdPersona)
        Else
            Comando.Parameters.AddWithValue("@VALORREFERENCIA", DBNull.Value)
            Comando.Parameters.AddWithValue("@FECHAMODIFICACIONREF", DBNull.Value)
            Comando.Parameters.AddWithValue("@IDUSUARIOMODIFICAREF", DBNull.Value)
        End If
        Comando.Parameters.AddWithValue("@TARIFAIVA", IIf(Me.Cb_IVA.SelectedIndex = -1, 0, CInt(Me.Cb_IVA.Text)))

        Comando.Parameters.AddWithValue("@ESTADOARTICULO", IIf(Me.Ck_Activo.Checked = True, "A", "I"))
        Comando.Parameters.AddWithValue("@CODIGOTIPOUNIDAD", Me.Cb_Unidad.SelectedValue)
        Comando.Parameters.AddWithValue("@CODIGOACCESS", CódigoSistemaAccess)
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)

        If Cb_TipoArticulo.SelectedValue <> 0 Then
            Comando.Parameters.AddWithValue("@IDTIPO", Me.Cb_TipoArticulo.SelectedValue)
            Comando.Parameters.AddWithValue("@IDSUBTIPO", Me.Cb_SubtipoArticulo.SelectedValue)
        Else
            Comando.Parameters.AddWithValue("@IDTIPO", DBNull.Value)
            Comando.Parameters.AddWithValue("@IDSUBTIPO", DBNull.Value)
        End If
        Dim msgParam As New SqlParameter("@IDARTICULO", SqlDbType.Int, 1)

        Try
            msgParam.Direction = ParameterDirection.Output
            Comando.Parameters.Add(msgParam)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Comando.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If (Comando.Parameters("@IDARTICULO").Value = -2 Or Comando.Parameters("@IDARTICULO").Value > 0) And SubioFoto Then
            If Comando.Parameters("@IDARTICULO").Value > 0 Then
                IdArticuloEditando = Comando.Parameters("@IDARTICULO").Value
            End If

            If CargaFotoServidor Then
                If SubioFoto Then
                    Dim Vista_Foto As Image
                    Vista_Foto = New Bitmap(Pb_FotoArticulo.Image)
                    Vista_Foto.Save(Application.StartupPath + "\Temp2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                    Vista_Foto.Dispose()
                    FuncionesBase.FuncionesBase.SubirFotoImagenMiniaturaBD(IdArticuloEditando, Pb_FotoArticulo.Image, _
                        "FOTOARTICULO", "art_" + IdArticuloEditando.ToString + ".jpg", 160, 120)
                    If Nuevo = False Then
                        GoogleDrive.SubirFoto(2, IdArticuloEditando, Application.StartupPath + "\Temp2.jpg", True)
                    Else
                        GoogleDrive.SubirFoto(2, IdArticuloEditando, Application.StartupPath + "\Temp2.jpg", False)
                    End If
                End If
            End If
        Else
            If IdArticuloEditando > 0 Then
                If EliminoFoto Then
                    Dim CadenaConsulta As String = "DELETE FROM [FOTOSEIMAGENES].[dbo].[FOTOARTICULO] WHERE IDARTICULO = " + IdArticuloEditando.ToString
                    Dim Consulta As New SqlClient.SqlCommand(CadenaConsulta)
                    Dim Conexion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                    Consulta.Connection = Conexion
                    Consulta.Connection.Open()
                    Consulta.ExecuteScalar()
                    Consulta.Connection.Close()
                End If
            End If
        End If
        Select Case Trim(Comando.Parameters("@IDARTICULO").Value)
            Case Is > 0
                MsgBox("El artículo se creó correctamente", MsgBoxStyle.Information, "Creación de Artículo")
                Exit Select
            Case -1
                MsgBox("No se puede cambiar el artículo porque ya tiene registros asociados", MsgBoxStyle.Critical, "No se puede realizar el cambio")
                Exit Sub
            Case -2
                MsgBox("El artículo se modifico correctamente", MsgBoxStyle.Information, "Modificación de Artículo")
                Exit Select
        End Select
        Me.Close()
        Pb_FotoArticulo.Image.Dispose()
        Dim appPath As String
        Try
            appPath = Application.StartupPath + "\Temp.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
        Try
            appPath = Application.StartupPath + "\Temp2.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
        Try
            appPath = Application.StartupPath + "\Temp3.jpg"
            If My.Computer.FileSystem.FileExists(appPath) Then
                My.Computer.FileSystem.DeleteFile(appPath)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Tx_NombreArtículo_TextChanged(sender As System.Object, e As System.EventArgs) Handles Tx_NombreArtículo.TextChanged
        If Nuevo = True Then
            Tx_DescripciónArtículo.Text = Tx_NombreCategoría.Text + " " + Tx_NombreArtículo.Text
        End If
    End Sub

    Public Sub CargarSubtipo()
        Dim valor As Object = Cb_TipoArticulo.SelectedValue
        Dim a As Boolean = IsNumeric(valor)
        If a = True Then
            'si el valor seleccionado de tipo es numérico llenar la lista de subtipos de artículos
            Try
                dssubtipos = bddatos.ModificarTipos(2, Cb_TipoArticulo.SelectedValue, 0, "", "", "")
                Cb_SubtipoArticulo.DataSource = dssubtipos.Tables(0).DefaultView
                Cb_SubtipoArticulo.ValueMember = "IDSUBTIPO"
                Cb_SubtipoArticulo.DisplayMember = "DESCRIPCION"
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub Cb_SubtipoArticulo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_SubtipoArticulo.SelectedValueChanged
        'llenar la tabla de características
        Dim valor As Object = Cb_SubtipoArticulo.SelectedValue()
        Dim a As Boolean = IsNumeric(valor)
        If a = True Then
            Tb_NomSubtipo.Text = dssubtipos.Tables(0).Rows(Cb_SubtipoArticulo.SelectedIndex)("NOMENCLATURA")
            'leer tabla de datos
            Try
                ds = bddatos.ModificarCaracteristicas(2, 0, Cb_SubtipoArticulo.SelectedValue, 0, 0, "", "", 0, 0, False, "", 0, Date.Now, "")
                Dim tabladatos As New DataTable
                filas = ds.Tables(0).Rows.Count
                If filas > 0 Then 'existen propiedades adicionales
                    'agrego las columnas del DataTable
                    tabladatos.Columns.Add("CARACTERISTICA")
                    tabladatos.Columns.Add("TIPO")
                    tabladatos.Columns.Add("VALOR")
                    tabladatos.Columns.Add("DESCRIPCIONCARACTERISTICA")
                    tabladatos.Columns.Add("IDCARACTERISTICA")
                    tabladatos.Columns.Add("IDTIPOCARACTERISTICA")
                    tabladatos.Columns.Add("IRREPETIBLE")
                    'lleno el DataTable
                    Dim j As Integer = 0
                    For j = 0 To ds.Tables(0).Rows.Count - 1
                        tabladatos.Rows.Add(ds.Tables(0).Rows(j)("NOMBRECARACTERISTICA"), ds.Tables(0).Rows(j)("TIPO"), "", ds.Tables(0).Rows(j)("DESCRIPCIONCARACTERISTICA"), ds.Tables(0).Rows(j)("IDCARACTERISTICASLISTA"), ds.Tables(0).Rows(j)("IDTIPOCARACTERISTICA"), ds.Tables(0).Rows(j)("IRREPETIBLE"))
                    Next
                    'llenar la grilla de datos
                    Me.Dgv_Caracteristicas.AutoGenerateColumns = False
                    Me.Dgv_Caracteristicas.DataSource = tabladatos
                Else
                    Dgv_Caracteristicas.DataSource = Nothing
                End If
            Catch ex As Exception

            End Try
            'advertir si el tipo y subtipo cambia 
            If Nuevo = False Then
                If tipopivote <> 0 And subtipopivote <> 0 Then
                    If subtipopivote <> Cb_SubtipoArticulo.SelectedValue Or tipopivote <> Cb_TipoArticulo.SelectedValue Then
                        Lb_Advertencia.Visible = True
                    Else
                        Lb_Advertencia.Visible = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Dgv_Caracteristicas_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Caracteristicas.CellEnter
        Dim descripcion As String
        descripcion = Dgv_Caracteristicas.CurrentRow.Cells("DESCRIPCIONCARACTERISTICA").Value.ToString
        Lbl_Descripcion.Text = descripcion
    End Sub

    Public Sub CargarTipos()
        Try
            'llenar la listas de tipos de artículos
            dstipos = bddatos.ModificarTipos(1, 0, 0, "", "", "")
            Cb_TipoArticulo.DataSource = dstipos.Tables(0).DefaultView
            Cb_TipoArticulo.ValueMember = "IDTIPO"
            Cb_TipoArticulo.DisplayMember = "DESCRIPCION"
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub Cb_TipoArticulo_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles Cb_TipoArticulo.SelectedValueChanged
        'llenar la tabla de subtipo
        Cb_SubtipoArticulo.SelectedValue = 0
        CargarSubtipo()
        Tb_NomTipo.Text = dstipos.Tables(0).Rows(Cb_TipoArticulo.SelectedIndex)("NOMENCLATURA")
    End Sub

    Private Sub Bt_CargarFoto_Click(sender As Object, e As EventArgs) Handles Bt_CargarFoto.Click
        ' Subir archivo desde el equipo al servidor
        Dim myStream As System.IO.Stream = Nothing
        Dim openFileDialog1 As New Windows.Forms.OpenFileDialog()
        openFileDialog1.InitialDirectory = VariablesBase.VariablesBase.Directorio_Actual_Carga_Foto
        openFileDialog1.Filter = "Archivos jpg (*.jpg)|*.jpg|Archivos png (*.png)|*.png|Archivo bmp (*.bmp)|*.bmp"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.Multiselect = False
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            VariablesBase.VariablesBase.Directorio_Actual_Carga_Foto = openFileDialog1.FileName
            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    'Cargar Imagen en el PictureBox
                    Try
                        Dim Nombre_Archivo As String = openFileDialog1.FileName
                        Dim fs As System.IO.FileStream
                        fs = New System.IO.FileStream(Nombre_Archivo, IO.FileMode.Open, IO.FileAccess.Read)
                        Dim imagen As New Bitmap(New Bitmap(System.Drawing.Image.FromStream(fs)))
                        If imagen.Width = 640 And imagen.Height = 480 Then
                            Pb_FotoArticulo.Image = imagen
                        Else
                            MsgBox("La imagen no tiene las dimensiones adecuadas. Por favor cargue una imagen que mida 640 pixeles de Ancho y 480 pixeles de Alto.", MsgBoxStyle.Critical, "ERROR DE CARGA")
                        End If
                        fs.Close()
                        SubioFoto = True
                    Catch ex As Exception
                        MsgBox("La imagen no es válida, por favor revise y vuelva a intentarlo.", MsgBoxStyle.Critical, "ERROR DE CARGA")
                    End Try
                End If
            Catch Ex As Exception
                MsgBox("El archivo no es válido.")
            Finally
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub Pb_FotoArticulo_DoubleClick(sender As Object, e As EventArgs) Handles Pb_FotoArticulo.DoubleClick
        ' Cargar imagen original
        If SubioFoto Or (Not (Nuevo Or Pb_FotoArticulo.Image Is Nothing)) Then
            Dim FrMostrarFoto As New FormulariosClasesBase.Fr_MostrarFoto
            If SubioFoto Then
                FrMostrarFoto.Set_Pb_Foto_Image(Pb_FotoArticulo.Image)
                FrMostrarFoto.ShowDialog()
            Else
                If Not FuncionesBase.FuncionesBase.ImagenesIguales(Pb_FotoArticulo.Image, Im_Defecto.Images(0)) Then
                    Try
                        Dim Foto As Boolean = GoogleDrive.DescargarFotos("art_" + IdArticuloEditando.ToString, "Artículos")
                        If Foto Then
                            Dim appPath As String = Application.StartupPath + "/Temp.jpg"
                            Dim filestream As New IO.FileStream(appPath, IO.FileMode.Open, IO.FileAccess.Read)
                            Dim imagen As Image = Image.FromStream(filestream)
                            filestream.Close()
                            FrMostrarFoto.Set_Pb_Foto_Image(imagen)
                        End If
                    Catch
                    End Try
                    FrMostrarFoto.ShowDialog()
                End If
            End If

        End If
    End Sub

    Private Sub Fr_Artículo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Ck_Activo.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Ck_Activo.Tag)
    End Sub

    Private Sub Button_Sin_Imagen_Click(sender As Object, e As EventArgs) Handles Button_Sin_Imagen.Click
        Pb_FotoArticulo.Image = Im_Defecto.Images(0)
        SubioFoto = False
        EliminoFoto = True
    End Sub
End Class 'Fr_Artículo