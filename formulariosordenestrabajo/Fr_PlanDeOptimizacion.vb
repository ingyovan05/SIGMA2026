Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Public Class Fr_PlanDeOptimizacion
    Public IdPlanOptimizacion As Integer?
    Public TipoEdicion As TiposEdicion
    Public Enum TiposEdicion
        Crear
        Editar
        Ver
        Cerrar
    End Enum
    Const tamannoMaximoArchivo As Long = 10485760 '10 MB
    Private conexion As New SqlConnection(My.Settings.CadenaConexión)
    Private comando As SqlCommand
    Private adaptador As SqlDataAdapter
    Private filaPlanOptimizacion As DataRow
    Private dtAdjuntos As New DataTable
    Private idBaseActual As Integer
    Private archivoOptimizacion As Byte()
    Private cargoArchivoOptimizacion As Boolean = False
    Private valorCelda As Object
    Private _guardado As Boolean
    ReadOnly Property Guardado As Boolean
        Get
            Return _guardado
        End Get
    End Property


    Private Sub Fr_PlanDeOptimizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'idBaseActual = VariablesBase.VariablesBase.IdBaseSiscontrolActual
        comando = New SqlCommand("dbo.PDO_DatosPlanOptimizacion", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        comando.Parameters.Add("@IDPLANOPTIMIZACION", SqlDbType.Int)
        If TipoEdicion = TiposEdicion.Crear Then
            comando.Parameters("@Accion").Value = 1
            comando.Parameters("@IDPLANOPTIMIZACION").Value = DBNull.Value
        Else
            comando.Parameters("@Accion").Value = 2
            comando.Parameters("@IDPLANOPTIMIZACION").Value = IdPlanOptimizacion
        End If
        adaptador = New SqlDataAdapter(comando)
        Dim dsPlanOptimizacion As New DataSet
        Try
            conexion.Open()
            adaptador.Fill(dsPlanOptimizacion)
            conexion.Close()
            If dsPlanOptimizacion.Tables.Count > 0 Then
                If TipoEdicion = TiposEdicion.Crear Then

                Else
                    If dsPlanOptimizacion.Tables(0).Rows.Count > 0 Then
                        filaPlanOptimizacion = dsPlanOptimizacion.Tables(0).Rows(0)
                        Tx_Titulo.Text = filaPlanOptimizacion("TITULO")
                        Tx_PropositoMejora.Text = filaPlanOptimizacion("PROPOSITOMEJORA")
                        If Not IsDBNull(filaPlanOptimizacion("ARCHIVOOPTIMIZACION")) AndAlso Not IsDBNull(filaPlanOptimizacion("NOMBREARCHIVOOPTIMIZACION")) Then
                            archivoOptimizacion = filaPlanOptimizacion("ARCHIVOOPTIMIZACION")
                            Tx_Archivo.Text = filaPlanOptimizacion("NOMBREARCHIVOOPTIMIZACION")
                        End If
                    Else
                        MessageBox.Show("Ocurrió un error al consultar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    End If
                dtAdjuntos = dsPlanOptimizacion.Tables(1)
                Dgv_Adjuntos.DataSource = dtAdjuntos
                If TipoEdicion = TiposEdicion.Ver Then
                    Tx_Titulo.ReadOnly = True
                    Tx_PropositoMejora.ReadOnly = True
                    Bt_CargarArchivo.Enabled = False
                    Bt_AgregarAdjunto.Enabled = True
                    Dgv_Adjuntos.ReadOnly = True
                    Col_Cargar.Visible = False

                    Bt_Aceptar.Visible = False
                End If
            Else
                MessageBox.Show("Ocurrió un error al cargar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("Ocurrió un error al cargar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Fr_PlanDeOptimizacion_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If TipoEdicion = TiposEdicion.Ver Then
            Bt_Cancelar.Select()
        Else
            Tx_Titulo.Select()
        End If
    End Sub


    Private Sub Tx_Archivo_TextChanged(sender As Object, e As EventArgs) Handles Tx_Archivo.TextChanged
        If Tx_Archivo.Text.Length > 0 Then
            Bt_VerArchivo.Enabled = True
            If TipoEdicion <> TiposEdicion.Ver Then
                Bt_QuitarArchivo.Enabled = True
            End If
        Else
            Bt_VerArchivo.Enabled = False
            Bt_QuitarArchivo.Enabled = False
        End If
    End Sub

    Private Sub Bt_CargarArchivo_Click(sender As Object, e As EventArgs) Handles Bt_CargarArchivo.Click
        If Ofd_ArchivoPDO.ShowDialog() = DialogResult.OK Then
            Dim archivoBinario As Byte() = FuncionesArchivo.CargarBinario(Ofd_ArchivoPDO.FileName)
            If archivoBinario.Length <= tamannoMaximoArchivo Then 'Si el archivo tiene tamaño inferior al tamaño máximo admitido.
                archivoOptimizacion = archivoBinario
                Tx_Archivo.Text = Path.GetFileName(Ofd_ArchivoPDO.FileName)
                cargoArchivoOptimizacion = True
            Else
                MessageBox.Show("El tamaño del archivo seleccionado supera los 10 MB. Por favor elija un archivo de menor tamaño.", "Archivo muy grande", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub Bt_VerArchivo_Click(sender As Object, e As EventArgs) Handles Bt_VerArchivo.Click
        FuncionesArchivo.Ver(archivoOptimizacion, Path.GetExtension(Tx_Archivo.Text))
    End Sub

    Private Sub Bt_QuitarArchivo_Click(sender As Object, e As EventArgs) Handles Bt_QuitarArchivo.Click
        archivoOptimizacion = Nothing
        cargoArchivoOptimizacion = False
        Tx_Archivo.Text = ""
    End Sub

    Private Sub Bt_AgregarAdjunto_Click(sender As Object, e As EventArgs) Handles Bt_AgregarAdjunto.Click
        Using frAgregarAdjunto As New Fr_AgregarAdjunto()
            If frAgregarAdjunto.ShowDialog() = DialogResult.OK Then
                Dim fila As DataRow = dtAdjuntos.NewRow
                If TipoEdicion = TiposEdicion.Crear Then
                    fila(Col_IdPlanoOptimizacion.DataPropertyName) = -1
                Else
                    fila(Col_IdPlanoOptimizacion.DataPropertyName) = IdPlanOptimizacion
                End If
                fila(Col_CodigoTipo.DataPropertyName) = frAgregarAdjunto.CodigoTipo
                fila(Col_NombreTipo.DataPropertyName) = frAgregarAdjunto.NombreTipo
                fila(Col_Archivo.DataPropertyName) = frAgregarAdjunto.Archivo
                fila(Col_NombreArchivo.DataPropertyName) = Path.GetFileName(frAgregarAdjunto.rutaArchivo)
                If frAgregarAdjunto.Fecha IsNot Nothing Then
                    fila(Col_FechaArchivo.DataPropertyName) = frAgregarAdjunto.Fecha.Value.ToShortDateString
                End If
                fila(Col_IdUsuarioRegistra.DataPropertyName) = VariablesBase.VariablesBase.IdPersona
                fila(Col_FechaRegistro.DataPropertyName) = DateTime.Now
                dtAdjuntos.Rows.Add(fila)
            End If
        End Using
    End Sub

    Private Sub Dgv_Adjuntos_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles Dgv_Adjuntos.CellContentClick
        If TypeOf Dgv_Adjuntos.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            Select Case Dgv_Adjuntos.Columns(e.ColumnIndex).Name
                Case Col_Cargar.Name
                    If Ofd_ArchivoPDO.ShowDialog() = DialogResult.OK Then
                        Dim archivoBinario As Byte() = FuncionesArchivo.CargarBinario(Ofd_ArchivoPDO.FileName)
                        If archivoBinario.Length <= tamannoMaximoArchivo Then 'Si el archivo tiene tamaño inferior al tamaño máximo admitido.
                            Dgv_Adjuntos.Rows(e.RowIndex).Cells(Col_Archivo.Name).Value = archivoBinario
                            Dgv_Adjuntos.Rows(e.RowIndex).Cells(Col_NombreArchivo.Name).Value = Path.GetFileName(Ofd_ArchivoPDO.FileName)
                        Else
                            MessageBox.Show("El tamaño del archivo seleccionado supera los 10 MB. Por favor elija un archivo de menor tamaño.", "Archivo muy grande", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                Case Col_Ver.Name
                    FuncionesArchivo.Ver(Dgv_Adjuntos.Rows(e.RowIndex).Cells(Col_Archivo.Name).Value, Path.GetExtension(Dgv_Adjuntos.Rows(e.RowIndex).Cells(Col_NombreArchivo.Name).Value))
                Case Col_Quitar.Name
                Case Else
            End Select
        End If
    End Sub

    Private Sub Dgv_Adjuntos_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Dgv_Adjuntos.CellBeginEdit
        valorCelda = Dgv_Adjuntos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
    End Sub

    Private Sub Dgv_Adjuntos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Adjuntos.CellEndEdit
        If Not IsDBNull(Dgv_Adjuntos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            If IsDBNull(valorCelda) OrElse Dgv_Adjuntos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value <> valorCelda Then
                Dim fila As DataGridViewRow = Dgv_Adjuntos.Rows(e.RowIndex)
                If TipoEdicion = TiposEdicion.Editar Then
                    fila.Cells(Col_IdUsuarioModifica.Name).Value = VariablesBase.VariablesBase.IdPersona
                    fila.Cells(Col_FechaModificacion.Name).Value = DateTime.Now
                End If
            End If
        End If
    End Sub

    Private Sub Dgv_Adjuntos_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Adjuntos.KeyDown
        dtAdjuntos.AcceptChanges()
        If Dgv_Adjuntos.SelectedCells.Count > 0 Then
            If e.KeyCode = Keys.Delete Then
                Dgv_Adjuntos.Rows.RemoveAt(Dgv_Adjuntos.SelectedCells(0).RowIndex)
                dtAdjuntos.AcceptChanges()
                Dgv_Adjuntos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End If
        End If
    End Sub


    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Validar() Then
            Guardar()
            If Guardado Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        If Trim(Tx_Titulo.Text).Length = 0 Then
            MessageBox.Show("Debe indicar el título.", "Plan de Optimización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Tx_Titulo.Select()
            Return False
        End If
        Return True
    End Function

    Private Sub Guardar()
        dtAdjuntos.AcceptChanges()
        For i As Integer = 0 To dtAdjuntos.Rows.Count - 1
            dtAdjuntos.Rows(i).Item(Col_Item.DataPropertyName) = i + 1
        Next
        Dim dtGuardaAdjuntos As DataTable = dtAdjuntos.Copy
        If dtGuardaAdjuntos.Columns.Contains(Col_NombreTipo.DataPropertyName) Then
            dtGuardaAdjuntos.Columns.Remove(Col_NombreTipo.DataPropertyName)
        End If
        If dtGuardaAdjuntos.Columns.Contains(Col_UsuarioRegistra.DataPropertyName) Then
            dtGuardaAdjuntos.Columns.Remove(Col_UsuarioRegistra.DataPropertyName)
        End If
        If dtGuardaAdjuntos.Columns.Contains(Col_UsuarioModifica.DataPropertyName) Then
            dtGuardaAdjuntos.Columns.Remove(Col_UsuarioModifica.DataPropertyName)
        End If
        comando = New SqlCommand("dbo.GestionarPDO_PlanOptimizacion", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.Add("@Accion", SqlDbType.TinyInt)
        Select Case TipoEdicion
            Case TiposEdicion.Crear
                comando.Parameters("@Accion").Value = 1
            Case TiposEdicion.Editar
                comando.Parameters("@Accion").Value = 2
            Case Else
                Exit Sub
        End Select
        comando.Parameters.Add("@IDPLANOPTIMIZACION", SqlDbType.Int)
        If TipoEdicion <> TiposEdicion.Crear Then
            comando.Parameters("@IDPLANOPTIMIZACION").Value = IdPlanOptimizacion
        Else
            comando.Parameters("@IDPLANOPTIMIZACION").Value = DBNull.Value
        End If
        comando.Parameters.AddWithValue("@IDBASE", VariablesBase.VariablesBase.IdBaseSiscontrolActual)
        comando.Parameters.AddWithValue("@TITULO", Trim(Tx_Titulo.Text))
        comando.Parameters.AddWithValue("@PROPOSITOMEJORA", FuncionesBase.FuncionesBase.QuitarCaracteresEnBlanco(Tx_PropositoMejora.Text))

        comando.Parameters.Add("@ARCHIVOOPTIMIZACION", SqlDbType.VarBinary)
        comando.Parameters.Add("@NOMBREARCHIVOOPTIMIZACION", SqlDbType.VarChar)
        If cargoArchivoOptimizacion Then
            comando.Parameters("@ARCHIVOOPTIMIZACION").Value = archivoOptimizacion
            comando.Parameters("@NOMBREARCHIVOOPTIMIZACION").Value = Tx_Archivo.Text
        ElseIf archivoOptimizacion IsNot Nothing Then
            comando.Parameters("@ARCHIVOOPTIMIZACION").Value = DBNull.Value
            comando.Parameters("@NOMBREARCHIVOOPTIMIZACION").Value = ""
        Else
            comando.Parameters("@ARCHIVOOPTIMIZACION").Value = DBNull.Value
            comando.Parameters("@NOMBREARCHIVOOPTIMIZACION").Value = DBNull.Value
        End If

        comando.Parameters.AddWithValue("@TablaADJUNTOS", dtGuardaAdjuntos)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.Add(New SqlParameter("@Mensaje", SqlDbType.Int) With {.Direction = ParameterDirection.Output})
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            conexion.Close()
            MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        If Not IsDBNull(comando.Parameters("@Mensaje").Value) Then
            Select Case comando.Parameters("@Mensaje").Value
                Case 1
                    MessageBox.Show("Se guardaron los cambios correctamente.", "Datos guardados", MessageBoxButtons.OK)
                    _guardado = True
                Case 2
                    MessageBox.Show("Ocurrió un error al intentar guardar los datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Dgv_Adjuntos.CancelEdit()
        If TipoEdicion <> TiposEdicion.Ver AndAlso Not Guardado Then
            If MessageBox.Show("¿Desea salir sin guardar cambios?", "Salir", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End If
        Else
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub AplicarEsquemaTabla(dt As DataTable, dgvcc As DataGridViewColumnCollection)
        For Each col As DataGridViewColumn In dgvcc
            dt.Columns.Add(col.DataPropertyName)
        Next
    End Sub

End Class 'Fr_PlanDeOptimizacion


Class Fr_AgregarAdjunto
    Inherits Form

    Public CodigoTipo As Integer
    Public NombreTipo As String
    Public rutaArchivo As String
    Public Fecha As Date?
    Private WithEvents Flp_Botones As New FlowLayoutPanel
    Private WithEvents Bt_Cancelar As New Button
    Private WithEvents Bt_Aceptar As New Button
    Private WithEvents Lb_Tipo As New Label
    Private WithEvents Lb_Archivo As New Label
    Private WithEvents Lb_Fecha As New Label
    Private WithEvents Cb_Tipo As New ComboBox
    Private WithEvents Dtp_Fecha As New DateTimePicker
    Private WithEvents Pn_Datos As New Panel
    Private WithEvents Tlp_ArchivoOptimizacion As New TableLayoutPanel
    Private WithEvents Bt_QuitarArchivo As New Button
    Private WithEvents Bt_VerArchivo As New Button
    Private WithEvents Bt_CargarArchivo As New Button
    Private WithEvents Tx_Archivo As New TextBox
    Private WithEvents Ofd_Archivo As New OpenFileDialog
    Private clTipo As New Cl_Tipo
    Private _archivo As Byte()
    ReadOnly Property Archivo As Byte()
        Get
            Return _archivo
        End Get
    End Property


    Private Sub Fr_AgregarAdjunto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Flp_Botones.SuspendLayout()
        Me.Pn_Datos.SuspendLayout()
        Me.Tlp_ArchivoOptimizacion.SuspendLayout()
        Me.SuspendLayout()
        With Flp_Botones
            .BackColor = SystemColors.ControlDark
            .Controls.Add(Me.Bt_Cancelar)
            .Controls.Add(Me.Bt_Aceptar)
            .Dock = DockStyle.Bottom
            .FlowDirection = FlowDirection.RightToLeft
            .Location = New Point(0, 91)
            .Name = "Flp_Botones"
            .Size = New Size(384, 30)
            .TabIndex = 1
        End With
        With Bt_Cancelar
            .Location = New Point(306, 3)
            .Name = "Bt_Cancelar"
            .Size = New Size(75, 23)
            .TabIndex = 1
            .Text = "Cancelar"
            .UseVisualStyleBackColor = True
        End With
        With Bt_Aceptar
            .Location = New Point(225, 3)
            .Name = "Bt_Aceptar"
            .Size = New Size(75, 23)
            .TabIndex = 0
            .Text = "Aceptar"
            .UseVisualStyleBackColor = True
        End With
        With Lb_Tipo
            .AutoSize = True
            .Location = New Point(19, 15)
            .Name = "Lb_Tipo"
            .Size = New Size(31, 13)
            .TabIndex = 0
            .Text = "Tipo:"
        End With
        With Lb_Archivo
            .AutoSize = True
            .Location = New Point(4, 42)
            .Name = "Lb_Archivo"
            .Size = New Size(46, 13)
            .TabIndex = 2
            .Text = "Archivo:"
        End With
        With Lb_Fecha
            .AutoSize = True
            .Location = New Point(10, 68)
            .Name = "Lb_Fecha"
            .Size = New Size(40, 13)
            .TabIndex = 4
            .Text = "Fecha:"
        End With
        With Cb_Tipo
            .DataSource = Cl_Tipo.DataSource
            .DisplayMember = Cl_Tipo.DisplayMember
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FormattingEnabled = True
            .Location = New Point(53, 12)
            .Name = "Cb_Tipo"
            .Size = New Size(200, 21)
            .TabIndex = 1
            .ValueMember = Cl_Tipo.ValueMember
        End With
        With Dtp_Fecha
            .Format = DateTimePickerFormat.[Short]
            .Location = New Point(53, 65)
            .Name = "Dtp_Fecha"
            .ShowCheckBox = True
            .Size = New Size(112, 20)
            .TabIndex = 5
        End With
        With Pn_Datos
            .Controls.Add(Me.Dtp_Fecha)
            .Controls.Add(Me.Lb_Fecha)
            .Controls.Add(Me.Tlp_ArchivoOptimizacion)
            .Controls.Add(Me.Lb_Archivo)
            .Controls.Add(Me.Cb_Tipo)
            .Controls.Add(Me.Lb_Tipo)
            .Dock = DockStyle.Fill
            .Location = New Point(0, 0)
            .Name = "Pn_Datos"
            .Size = New Size(384, 91)
            .TabIndex = 0
        End With
        With Tlp_ArchivoOptimizacion
            .Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                Or AnchorStyles.Right), AnchorStyles)
            .ColumnCount = 4
            .ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
            .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 24.0!))
            .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 24.0!))
            .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 25.0!))
            .Controls.Add(Me.Bt_QuitarArchivo, 3, 0)
            .Controls.Add(Me.Bt_VerArchivo, 2, 0)
            .Controls.Add(Me.Bt_CargarArchivo, 1, 0)
            .Controls.Add(Me.Tx_Archivo, 0, 0)
            .Location = New Point(53, 38)
            .Name = "Tlp_ArchivoOptimizacion"
            .RowCount = 1
            .RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            .RowStyles.Add(New RowStyle(SizeType.Absolute, 22.0!))
            .Size = New Size(319, 22)
            .TabIndex = 3
        End With
        With Bt_QuitarArchivo
            .Enabled = False
            .Font = New Font("Segoe UI Emoji", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            .Location = New Point(294, 0)
            .Margin = New Padding(0)
            .Name = "Bt_QuitarArchivo"
            .Size = New Size(24, 22)
            .TabIndex = 3
            .Text = "❌"
            .UseVisualStyleBackColor = True
        End With
        With Bt_VerArchivo
            .Enabled = False
            .Font = New Font("Segoe UI Emoji", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            .Location = New Point(270, 0)
            .Margin = New Padding(0)
            .Name = "Bt_VerArchivo"
            .Size = New Size(24, 22)
            .TabIndex = 2
            .Text = "👁️"
            .UseVisualStyleBackColor = True
        End With
        With Bt_CargarArchivo
            .Font = New Font("Segoe UI", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            .Location = New Point(246, 0)
            .Margin = New Padding(0)
            .Name = "Bt_CargarArchivo"
            .Size = New Size(24, 22)
            .TabIndex = 1
            .Text = "..."
            .UseVisualStyleBackColor = True
        End With
        With Tx_Archivo
            .Dock = DockStyle.Fill
            .Enabled = False
            .Location = New Point(0, 1)
            .Margin = New Padding(0, 1, 1, 0)
            .Name = "Tx_Archivo"
            .ReadOnly = True
            .Size = New Size(245, 20)
            .TabIndex = 0
            .TabStop = False
        End With
        With Ofd_Archivo
            .Filter = "Libro de Excel|*.xlsx;*.xls|Todos los archivos|*.*"
            '.Name = "Ofd_ArchivoPDO"
        End With

        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(384, 121)
        Me.Controls.Add(Me.Pn_Datos)
        Me.Controls.Add(Me.Flp_Botones)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_AgregarArchivo"
        Me.ShowIcon = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Agregar archivo"
        Me.Flp_Botones.ResumeLayout(False)
        Me.Pn_Datos.ResumeLayout(False)
        Me.Pn_Datos.PerformLayout()
        Me.Tlp_ArchivoOptimizacion.ResumeLayout(False)
        Me.Tlp_ArchivoOptimizacion.PerformLayout()
        Me.ResumeLayout(False)
    End Sub


    Private Sub Tx_Archivo_TextChanged(sender As Object, e As EventArgs) Handles Tx_Archivo.TextChanged
        If Tx_Archivo.Text.Length > 0 Then
            Bt_VerArchivo.Enabled = True
            Bt_QuitarArchivo.Enabled = True
        Else
            Bt_VerArchivo.Enabled = False
            Bt_QuitarArchivo.Enabled = False
        End If
    End Sub

    Private Sub Bt_CargarArchivo_Click(sender As Object, e As EventArgs) Handles Bt_CargarArchivo.Click
        If Ofd_Archivo.ShowDialog() = DialogResult.OK Then
            Dim archivoBinario As Byte() = FuncionesArchivo.CargarBinario(Ofd_Archivo.FileName)
            If archivoBinario.Length <= 10485760 Then 'Si el archivo tiene tamaño inferior a 10 MB.
                _archivo = archivoBinario
                Tx_Archivo.Text = Path.GetFileName(Ofd_Archivo.FileName)
            Else
                MessageBox.Show("El tamaño del archivo seleccionado supera los 10 MB. Por favor elija un archivo de menor tamaño.", "Archivo muy grande", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub Bt_VerArchivo_Click(sender As Object, e As EventArgs) Handles Bt_VerArchivo.Click
        FuncionesArchivo.Ver(archivo, Path.GetExtension(Tx_Archivo.Text))
    End Sub

    Private Sub Bt_QuitarArchivo_Click(sender As Object, e As EventArgs) Handles Bt_QuitarArchivo.Click
        _archivo = Nothing
        Tx_Archivo.Text = ""
    End Sub


    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If Validar() Then
            CodigoTipo = Cb_Tipo.SelectedValue
            NombreTipo = Cb_Tipo.Text
            rutaArchivo = Tx_Archivo.Text
            If Dtp_Fecha.Checked Then
                Fecha = Dtp_Fecha.Value
            End If
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Function Validar()

        Return True
    End Function

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class

''' <summary>Tipo de archivo adjunto</summary>
Class Cl_Tipo
    Shared Property DataSource As DataTable
    Public Const DisplayMember As String = "NOMBRETIPO"
    Public Const ValueMember As String = "CODIGOTIPO"

    Public Sub New()
        DataSource = New DataTable
        DataSource.Columns.Add(ValueMember)
        DataSource.Columns.Add(DisplayMember)
        DataSource.Rows.Add(1, "1. Definir (problema, oportunidad)")
        DataSource.Rows.Add(2, "2. Medir (defectos, eficiencias, variables)")
        DataSource.Rows.Add(3, "3. Analizar (encontrar la causa raíz)")
        DataSource.Rows.Add(4, "4. Mejorar")
        DataSource.Rows.Add(5, "5. Controlar")
    End Sub
End Class

Module FuncionesArchivo
    Public Sub Ver(archivoBinario As Byte(), Optional extension As String = ".pdf")
        Dim archivoTemp As String = VariablesBase.VariablesBase._path & "\" & "temp" & extension
        If File.Exists(archivoTemp) Then
            Try
                File.Delete(archivoTemp)
            Catch ex As Exception

            End Try
        End If
        File.WriteAllBytes(archivoTemp, archivoBinario)
        Try
            Process.Start(archivoTemp)
        Catch
            MessageBox.Show("No se pudo abrir el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function CargarBinario(rutaArchivo As String) As Byte()
        Dim archivo As Byte()
        archivo = File.ReadAllBytes(rutaArchivo)
        Return archivo
    End Function
End Module