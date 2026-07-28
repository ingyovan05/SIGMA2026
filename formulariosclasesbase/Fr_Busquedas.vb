Imports System.Windows.Forms

Public Class Fr_Busquedas
    Public tabla As Integer
    Public campos As DataTable
    Public tipo As Integer
    Public Dt_condicionstring As New DataTable
    Public Dt_condicionnumero As New DataTable
    Public Dt_condicionfecha As New DataTable
    Public camposllenos As Boolean = False
    Public procedimiento As Integer = 0 'AQUI PASO EL PROCEDIMIENTO A EJECUTAR, LA LSITA ESTA EN LA CLASE BUSQUEDAS 
    Dim bddatos As New DatosClasesBase.Busquedas
    Public tablacargada As Integer
    Public DsBuscar As New DataSet
    Public busqueda As String = ""

    Private Sub Fr_Busquedas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'cargo los tipos de condiciones que se usan dependiendo de los criterios
        Dim fila As DataRow
        Dt_condicionstring.Clear()
        Dt_condicionnumero.Clear()
        Dt_condicionfecha.Clear()

        Dt_condicionstring.Columns.Add("nombre")
        Dt_condicionstring.Columns.Add("valor")
        'agrego las filas
        fila = Dt_condicionstring.NewRow
        fila(0) = "Coincide"
        fila(1) = "1"
        Dt_condicionstring.Rows.Add(fila)

        fila = Dt_condicionstring.NewRow
        fila(0) = "Es Exactamente"
        fila(1) = "2"
        Dt_condicionstring.Rows.Add(fila)

        fila = Dt_condicionstring.NewRow
        fila(0) = "No Contiene"
        fila(1) = "3"
        Dt_condicionstring.Rows.Add(fila)
        '------

        Dt_condicionnumero.Columns.Add("nombre")
        Dt_condicionnumero.Columns.Add("valor")
        'agrego las filas
        fila = Dt_condicionnumero.NewRow
        fila(0) = "="
        fila(1) = "1"
        Dt_condicionnumero.Rows.Add(fila)

        fila = Dt_condicionnumero.NewRow
        fila(0) = ">"
        fila(1) = "2"
        Dt_condicionnumero.Rows.Add(fila)

        fila = Dt_condicionnumero.NewRow
        fila(0) = "<"
        fila(1) = "3"
        Dt_condicionnumero.Rows.Add(fila)

        fila = Dt_condicionnumero.NewRow
        fila(0) = "<>"
        fila(1) = "4"
        Dt_condicionnumero.Rows.Add(fila)
        '------

        Dt_condicionfecha.Columns.Add("nombre")
        Dt_condicionfecha.Columns.Add("valor")
        'agrego las filas
        fila = Dt_condicionfecha.NewRow
        fila(0) = "En la fecha"
        fila(1) = "1"
        Dt_condicionfecha.Rows.Add(fila)

        fila = Dt_condicionfecha.NewRow
        fila(0) = "Desde la fecha"
        fila(1) = "2"
        Dt_condicionfecha.Rows.Add(fila)

        fila = Dt_condicionfecha.NewRow
        fila(0) = "Hasta la fecha"
        fila(1) = "3"
        Dt_condicionfecha.Rows.Add(fila)

        fila = Dt_condicionfecha.NewRow
        fila(0) = "Diferente de la fecha"
        fila(1) = "4"
        Dt_condicionfecha.Rows.Add(fila)

        fila = Dt_condicionfecha.NewRow
        fila(0) = "Entre las Fechas"
        fila(1) = "5"
        Dt_condicionfecha.Rows.Add(fila)
        '-------

        'leer la tabla de la cual vamos a buscar la informacion

        'leer una matriz de datos
        'campos 
        '| nombre_campo | Descripcion campo | Tipo_Valor | 



        Cb_Criterio.DataSource = campos
        Cb_Criterio.ValueMember = "Tipo"
        Cb_Criterio.DisplayMember = "Descripcion"
        camposllenos = True

        Cb_Criterio.SelectedIndex = 1
        Cb_Top.SelectedIndex = 3

    End Sub

    Private Sub Cb_Criterio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_Criterio.SelectedIndexChanged
        'revisar cuando se selecciona un valor y mirar que tipo de valor es

        'se limpia la caja de busqueda y se restringen valores o se cambia de tipo
        If camposllenos = False Then
            Exit Sub
        End If
        camposllenos = False
        Tx_valor.Clear()
        Dtp_valor.Width = Tx_valor.Width
        Dtp_valorHasta.Visible = False
        tipo = Cb_Criterio.SelectedValue
        Tx_valor.Enabled = True
        Cb_Condicion.Enabled = True
        Tx_valor.Clear()
        Tx_valor.MaxLength = 8
        Select Case tipo
            Case 1 'texto
                Tx_valor.Visible = True
                Dtp_valor.Visible = False
                Cb_Condicion.DataSource = Dt_condicionstring
                Cb_Condicion.ValueMember = "valor"
                Cb_Condicion.DisplayMember = "nombre"
                Tx_valor.Focus()
                Tx_valor.MaxLength = 30
            Case 2 'numero
                Tx_valor.Visible = True
                Dtp_valor.Visible = False
                Cb_Condicion.DataSource = Dt_condicionnumero
                Cb_Condicion.ValueMember = "valor"
                Cb_Condicion.DisplayMember = "nombre"
                Tx_valor.Focus()
                Tx_valor.MaxLength = 20
            Case 3 'fecha
                Tx_valor.Visible = False
                Dtp_valor.Visible = True
                Cb_Condicion.DataSource = Dt_condicionfecha
                Cb_Condicion.ValueMember = "valor"
                Cb_Condicion.DisplayMember = "nombre"
                Tx_valor.Text = Dtp_valor.Value.ToShortDateString
                Dtp_valor.Focus()
            Case 4 'Especiales, no piden criterios
                Tx_valor.Enabled = False
                Tx_valor.Visible = True
                Dtp_valor.Visible = False
                Dtp_valorHasta.Visible = False
                Cb_Condicion.Enabled = False
            Case 5 'Especial con criterio de IDADRTICULO para MODULOS QUE SOLICITEN UN VALOR NUMERICO
                Tx_valor.Enabled = True
                Tx_valor.Visible = True
                Dtp_valor.Visible = False
                Dtp_valorHasta.Visible = False
                Cb_Condicion.Enabled = False
            Case 6 'Consultar proveedor por ciudad
            Case 7 'Consulta por desglose de parágrafo, separando por palabras (máximo 5)
                Tx_valor.Enabled = True
                Tx_valor.Visible = True
                Dtp_valor.Visible = False
                Dtp_valorHasta.Visible = False
                Cb_Condicion.Enabled = False
                Tx_valor.Focus()
                Tx_valor.MaxLength = 30
            Case Else
                MsgBox("Dato no valido")
        End Select
        camposllenos = True
    End Sub

    Private Sub Tx_valor_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Tx_valor.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            If Cb_Criterio.SelectedValue = 2 Or Cb_Criterio.SelectedValue = 5 Then 'si el tipo de campo debe ser solo numerico se restringen los caracteres
                Me.Tx_valor.Text = Clipboard.GetText(TextDataFormat.UnicodeText)
            End If
        End If
    End Sub

    Private Sub Tx_valor_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Tx_valor.KeyPress
        If Cb_Criterio.SelectedValue = 2 Or Cb_Criterio.SelectedValue = 5 Then 'si el tipo de campo debe ser solo numerico se restringen los caracteres
            If InStr(1, "0123456789,.v" & Chr(8), e.KeyChar) = 0 Then
                e.Handled = True
                e.KeyChar = CChar("")
            End If
        End If
    End Sub

    Private Sub Bt_Buscar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Buscar.Click
        If Tx_valor.Text = "" And Cb_Criterio.SelectedValue <> 4 Then
            MsgBox("Debe escribir algun valor")
            Exit Sub
        ElseIf Cb_Criterio.SelectedValue = 2 Then
            If IsNumeric(Tx_valor.Text) = False Then
                MsgBox("El valor debe ser numerico")
                Exit Sub
            End If
        End If

        'es valido, llamar al procedimiento
        Dim valorstr As String = ""
        Dim valornum As Double = 0
        Dim valordate As Date = Date.Now
        Dim valordate2 As Date = Date.Now
        Dim condicion As Integer
        Dim campo As String
        Dim accionespecial As Integer = 0
        campo = campos.Rows(Cb_Criterio.SelectedIndex)("Nombre")
        Dim tipo As Integer = Cb_Criterio.SelectedValue
        condicion = Cb_Condicion.SelectedValue
        'DsBuscar.Tables.Clear()
        Select Case Cb_Criterio.SelectedValue
            Case 1 'texto
                valorstr = Tx_valor.Text
            Case 2
                valornum = Double.Parse(Tx_valor.Text)
            Case 3
                valordate = Dtp_valor.Value
                valordate2 = Dtp_valorHasta.Value
            Case 4
                accionespecial = Integer.Parse(campo) 'PASO EL VALOR DEL CAMPO QUE EN ESTE CASO ES LA ACCION A REALIZAR PARA CONSULTAS ESPECIALES
            Case 5
                valornum = Tx_valor.Text
                accionespecial = Integer.Parse(campo) 'PASO EL VALOR DEL CAMPO QUE EN ESTE CASO ES LA ACCION A REALIZAR PARA CONSULTAS ESPECIALES
            Case 6
            Case 7
                valorstr = Tx_valor.Text
                accionespecial = Integer.Parse(campo) 'PASO EL VALOR DEL CAMPO QUE EN ESTE CASO ES LA ACCION A REALIZAR PARA CONSULTAS ESPECIALES
            Case Else
                MsgBox("El criterio no es válido")
                Exit Sub
        End Select
        'ejecutar el procedimiento
        'Dim DsBuscarPivote As New DataSet

        Select Case tabla
            Case 36
                If campo = "U.NOMBREUSUARIO" Then
                    valorstr = FuncionesBase.FuncionesBase.Encryptar(valorstr)
                End If
        End Select

        DsBuscar = bddatos.BusquedaCondiciones(tabla, campo, tipo, condicion, valorstr, valornum, valordate, valordate2, accionespecial, CInt(Me.Cb_Top.Text))

        If DsBuscar Is Nothing Then
            Exit Sub
        Else
            If DsBuscar.Tables.Count = 0 Then
                Exit Sub
            End If
            If DsBuscar.Tables.Count > 1 Then 'si el procedimiento trae mas de una tabla es decir la tabla de conteo y la tabla de datos
                DsBuscar.Tables.Remove(DsBuscar.Tables(0).TableName) 'borrar la tabla del conteo 

            Else 'si solo trae el conteo es porque se exceden los campos
                MsgBox("La Consulta Excede los 2.000 registros, intente ser mas especifico", MsgBoxStyle.Critical, "Consulta muy pesada")
                DsBuscar.Clear()
            End If
            If DsBuscar.Tables(0).Rows.Count > 0 Then
                Me.Close()
                busqueda = Cb_Criterio.Text
            Else
                MsgBox("Ningun Registro Encontrado")
                DsBuscar.Clear()
            End If
        End If
    End Sub

    Private Sub Bt_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Dtp_valor_ValueChanged(sender As System.Object, e As System.EventArgs) Handles Dtp_valor.ValueChanged
        Tx_valor.Text = Date.Parse(Dtp_valor.Value.ToString).ToShortDateString
    End Sub

    Private Sub Cb_Condicion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cb_Condicion.SelectedIndexChanged
        If camposllenos = False Then
            Exit Sub
        End If
        If Cb_Criterio.SelectedValue = 3 And Cb_Condicion.SelectedValue = 5 Then
            Dtp_valor.Width = 106
            Dtp_valorHasta.Visible = True
        Else
            Dtp_valor.Width = Tx_valor.Width
            Dtp_valorHasta.Visible = False
        End If
    End Sub


    Private Sub Cb_Criterio_DrawItem(sender As System.Object, e As System.Windows.Forms.DrawItemEventArgs) Handles Cb_Criterio.DrawItem
        Dim item As System.Data.DataRowView
        item = Cb_Criterio.Items(e.Index)
        e.DrawBackground()
        If item(2) = "4" Or item(2) = "5" Then
            e.Graphics.DrawImage(ImageList1.Images(0), New Drawing.PointF(e.Bounds.Left, e.Bounds.Top))
        End If
        e.Graphics.DrawString(item(1), e.Font, New Drawing.SolidBrush(e.ForeColor), New Drawing.PointF(e.Bounds.Left + ImageList1.ImageSize.Width + 1, e.Bounds.Top))
    End Sub
End Class


