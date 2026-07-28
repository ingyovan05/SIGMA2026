Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Vars = VariablesBase.VariablesBase
Imports Funs = FuncionesBase.FuncionesBase

''' <summary>
''' Permite cargar al servidor los archivos de una Factura Electrónica y del acuse de recibo.
''' </summary>
Public Class Fr_SubirArchivosFacturaElectronica

    ''' <summary>
    ''' Identificador de la aprobación de la cual se cargan los archivos de facturación electrónica.
    ''' </summary>
    ''' <value>Identificador de aprobación.</value>
    ''' <returns>Identificador de aprobación.</returns>
    Property IdAprobacion As Integer

    ''' <summary>
    ''' Número de la aprobación de la cual se cargan los archivos de facturación electrónica.
    ''' </summary>
    ''' <value>Número de aprobación.</value>
    ''' <returns>Número de aprobación.</returns>
    Property NumeroAprobacion As String

    ''' <summary>
    ''' Listado de los archivos que involucra la facturación electrónica.
    ''' </summary>
    Structure ListaArchivosFacturaElectronica
        Public FacturaPdfServidor As String
        Public FacturaXmlServidor As String
        Public AcusePdfServidor As String
        Public AcuseXmlServidor As String
    End Structure

    ''' <summary>
    ''' Listado de archivos de facturación electrónica subidos al servidor.
    ''' </summary>
    Private listaArchivosEnServidor As ListaArchivosFacturaElectronica

    Dim GoogleDrive As New FuncionesGoogle.FuncionesGoogle

    ' Carga inicial de datos.
    Private Sub Fr_SubirArchivosFacturaElectronica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarArchivos()
    End Sub


    ''' <summary>
    ''' Consulta si la aprobación cuenta con archivos en el servidor y ubica sus nombres de archivo en las cajas de texto correspondientes.
    ''' </summary>
    Private Sub CargarArchivos()
        'Cargar listado de archivos de la factura electrónica subidos al Servidor.
        Dim prefijoFactura As String = "f"
        Dim prefijoAcuse As String = "a"
        Dim rutaServidor As String = ""
        Dim archivoServidor As String = ""

        Dim cn As New SqlConnection(My.Settings.CadenaConexión)
        Dim cmd As String
        Dim dtSubidos As New DataTable
        cmd = "SELECT SUBIDOSERVIDORFACTURAPDF,SUBIDOSERVIDORFACTURAXML,SUBIDOSERVIDORACUSEPDF,SUBIDOSERVIDORACUSEXML FROM SC_FE_APROBACION  WHERE APROBACION = '" + NumeroAprobacion + "'"
        cn.Open()
        Dim da As New SqlDataAdapter(cmd, cn)
        da.Fill(dtSubidos)
        cn.Close()

        archivoServidor = prefijoFactura & NumeroAprobacion & ".pdf"
        If dtSubidos.Rows(0).Item(0).ToString = "S" Then
            Tx_RutaFacturaPdf.Text = archivoServidor
            Bt_VerFacturaPdf.Enabled = True
            listaArchivosEnServidor.FacturaPdfServidor = archivoServidor
        End If

        archivoServidor = prefijoFactura & NumeroAprobacion & ".xml"
        If dtSubidos.Rows(0).Item(1).ToString = "S" Then
            Tx_RutaFacturaXml.Text = archivoServidor
            Bt_VerFacturaXml.Enabled = True
            listaArchivosEnServidor.FacturaXmlServidor = archivoServidor
        End If

        archivoServidor = prefijoAcuse & NumeroAprobacion & ".pdf"
        If dtSubidos.Rows(0).Item(2).ToString = "S" Then
            Tx_RutaAcusePdf.Text = archivoServidor
            Bt_VerAcusePdf.Enabled = True
            listaArchivosEnServidor.AcusePdfServidor = archivoServidor
        End If

        archivoServidor = prefijoAcuse & NumeroAprobacion & ".xml"
        If dtSubidos.Rows(0).Item(3).ToString = "S" Then
            Tx_RutaAcuseXml.Text = archivoServidor
            Bt_VerAcuseXml.Enabled = True
            listaArchivosEnServidor.AcuseXmlServidor = archivoServidor
        End If
    End Sub


    ' Abre el cuadro de diálogo de selección de archivo.
    Private Sub Bt_BuscarArchivo_Click(sender As Object, e As EventArgs) Handles Bt_BuscarFacturaPdf.Click, Bt_BuscarFacturaXml.Click, Bt_BuscarAcusePdf.Click, Bt_BuscarAcuseXml.Click
        Dim tx As New TextBox
        Dim ofd As New OpenFileDialog()
        With ofd
            .CheckFileExists = True
            .CheckPathExists = True
            .Multiselect = False
        End With
        Select Case sender.Name
            Case Bt_BuscarFacturaPdf.Name
                ofd.Filter = "Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*"
                ofd.Title = "Subir archivo de Factura Electrónica en PDF..."
                tx = Tx_RutaFacturaPdf
            Case Bt_BuscarFacturaXml.Name
                ofd.Filter = "Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*"
                ofd.Title = "Subir archivo de Factura Electrónica en XML..."
                tx = Tx_RutaFacturaXml
            Case Bt_BuscarAcusePdf.Name
                ofd.Filter = "Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*"
                ofd.Title = "Subir archivo de Acuse de Recibo en PDF..."
                tx = Tx_RutaAcusePdf
            Case Bt_BuscarAcuseXml.Name
                ofd.Filter = "Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*"
                ofd.Title = "Subir archivo de Acuse de Recibo en XML..."
                tx = Tx_RutaAcuseXml
            Case Else
                Exit Sub
        End Select
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tx.Text = ofd.FileName
        End If
    End Sub


    ' Abre el archivo ubicado en el servidor.
    Private Sub Bt_VerArchivo_Click(sender As Object, e As EventArgs) Handles Bt_VerFacturaPdf.Click, Bt_VerFacturaXml.Click, Bt_VerAcusePdf.Click, Bt_VerAcuseXml.Click
        Dim archivo As String = ""
        Dim rutaNombreArchivo As String = ""

        Cursor.Current = Cursors.WaitCursor
        Select Case sender.Name
            Case Bt_VerFacturaPdf.Name
                archivo = Tx_RutaFacturaPdf.Text
            Case Bt_VerFacturaXml.Name
                archivo = Tx_RutaFacturaXml.Text
            Case Bt_VerAcusePdf.Name
                archivo = Tx_RutaAcusePdf.Text
            Case Bt_VerAcuseXml.Name
                archivo = Tx_RutaAcuseXml.Text
            Case Else
                Exit Sub
        End Select

        GoogleDrive.DescargarArchivosSinSubCarpeta(archivo, "FacturaciónElectrónica")
        Cursor.Current = Cursors.Default
    End Sub


    ' Carga los archivos seleccionados al servidor.
    Private Sub Bt_SubirArchivos_Click(sender As Object, e As EventArgs) Handles Bt_SubirArchivos.Click
        ' Archivos a subir

        Dim ArchivosSubidos As Object = {0, 0, 0, 0}
        Dim CantidadSubidos As Integer = 0
        If Tx_RutaFacturaPdf.Text <> "" AndAlso listaArchivosEnServidor.FacturaPdfServidor <> Tx_RutaFacturaPdf.Text Then
            Dim SubirFacturaPdf As Boolean
            SubirFacturaPdf = GoogleDrive.SubirArchivoSinSubCarpeta(1, "f" + NumeroAprobacion.ToString, Tx_RutaFacturaPdf.Text.ToString)
            If SubirFacturaPdf = True Then
                MarcarArchivoSubidoServidor(IdAprobacion, 1)
            Else
                ArchivosSubidos(0) = 1
            End If
            CantidadSubidos += 1
        End If
        If Tx_RutaFacturaXml.Text <> "" AndAlso listaArchivosEnServidor.FacturaXmlServidor <> Tx_RutaFacturaXml.Text Then
            Dim SubirFacturaXml As Boolean
            SubirFacturaXml = GoogleDrive.SubirArchivoSinSubCarpeta(1, "f" & NumeroAprobacion, Tx_RutaFacturaXml.Text)
            If SubirFacturaXml = True Then
                MarcarArchivoSubidoServidor(IdAprobacion, 2)
            Else
                ArchivosSubidos(1) = 2
            End If
            CantidadSubidos += 1
        End If
        If Tx_RutaAcusePdf.Text <> "" AndAlso listaArchivosEnServidor.AcusePdfServidor <> Tx_RutaAcusePdf.Text Then
            Dim SubirAcusePdf As Boolean
            SubirAcusePdf = GoogleDrive.SubirArchivoSinSubCarpeta(1, "a" & NumeroAprobacion, Tx_RutaAcusePdf.Text)
            If SubirAcusePdf = True Then
                MarcarArchivoSubidoServidor(IdAprobacion, 3)
            Else
                ArchivosSubidos(2) = 3
            End If
            CantidadSubidos += 1
        End If
        If Tx_RutaAcuseXml.Text <> "" AndAlso listaArchivosEnServidor.AcuseXmlServidor <> Tx_RutaAcuseXml.Text Then
            Dim SubirAcuseXml As Boolean
            SubirAcuseXml = GoogleDrive.SubirArchivoSinSubCarpeta(1, "a" & NumeroAprobacion, Tx_RutaAcuseXml.Text)
            If SubirAcuseXml = True Then
                MarcarArchivoSubidoServidor(IdAprobacion, 4)
            Else
                ArchivosSubidos(3) = 4
            End If
            CantidadSubidos += 1
        End If

        If CantidadSubidos > 0 Then
            If ArchivosSubidos(0) + ArchivosSubidos(1) + ArchivosSubidos(2) + ArchivosSubidos(3) > 0 Then
                MsgBox("Hubo un error al subir uno de los archivos, verifique cual falló e intente de nuevo.", MsgBoxStyle.Information, "Error en archivos subidos")
            Else
                If ArchivosSubidos(0) + ArchivosSubidos(1) + ArchivosSubidos(2) + ArchivosSubidos(3) = 0 Then
                    MsgBox("Se subieron todos los archivos seleccionados", MsgBoxStyle.Information, "Archivos subidos")
                End If
            End If
        End If

        DialogResult = DialogResult.OK
        Close()
    End Sub

    ''' <summary>
    ''' Actualiza el campo de tipo de archivo subido al servidor en el registro de la aprobación en la base de datos.
    ''' </summary>
    ''' <param name="idAprobacion">Identificador de la aprobación a la que se le aplica la marca.</param>
    ''' <param name="tipoArchivo">Tipo del archivo de la aprobación que se marca como subido.</param>
    Private Sub MarcarArchivoSubidoServidor(idAprobacion As Integer, tipoArchivo As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.MarcarSubidoServidor_SC_FE_Aprobacion", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@IDAPROBACION", idAprobacion)
        comando.Parameters.AddWithValue("@TIPOARCHIVO", tipoArchivo)
        comando.Parameters.AddWithValue("@IDPERSONA", Vars.IdPersona)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    ' Cierre del formulario.
    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

End Class 'FrSubirArchivosFacturaElectronica