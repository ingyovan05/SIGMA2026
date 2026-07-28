Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

''' <summary>
''' Permite la personalización de la condición de pago en una orden de compra.
''' </summary>
''' <remarks>
''' La condición de pago se consolida en una cadena de texto que se construye seleccionando, en las filas de la rejilla, la modalidad y porcentaje de los pagos a realizar.
''' </remarks>
Public Class Fr_CondicionPago

    ''' <summary>
    ''' Tamaño máximo de la cadena de texto de la condición de pago para no exceder el tamaño del campo en la tabla de la base de datos.
    ''' </summary>
    Private maxLength As Integer = 0

    ''' <summary>
    ''' Cadena de texto que contiene la condición de pago.
    ''' </summary>
    Private condicionPago As String = ""

    ''' <summary>
    ''' Constantes con los nombres de las Modalidades de pagos para cargar en la lista desplegable.
    ''' </summary>
    Private Structure Modalidad
        Const Anticipado As String = "ANTICIPADO"
        Const Contado As String = "CONTADO"
        Const Contraentrega As String = "CONTRAENTREGA"
        Const PrevioAlDespacho As String = "PREVIO AL DESPACHO"
        Const Credito As String = "CRÉDITO"
    End Structure

    ''' <summary>
    ''' Constantes con el texto de fecha de inicio de crédito que se adjuntan a la condición cuando se incluye la modalidad crédito.
    ''' </summary>
    Private Structure FechaCredito
        Const FechaDeFactura As String = "FECHA DE FACTURA"
        Const FechaRadicadoFactura As String = "FECHA RADICACIÓN FACTURA"
    End Structure

    ''' <summary>
    ''' Determina que botón de radio se encuentra seleccionado en el grupo de fecha de inicio de crédito.
    ''' </summary>
    ''' <remarks>
    ''' Es consultada cuando se va a agregar el texto de fecha de crédito en la condición de pago.
    ''' </remarks>
    Private rbFechaCredito As RadioButton


    ' Carga de componentes.
    Private Sub Fr_CondicionPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvCb_Modalidad.Items.Add(Modalidad.Anticipado)
        DgvCb_Modalidad.Items.Add(Modalidad.Contado)
        DgvCb_Modalidad.Items.Add(Modalidad.Credito)
        DgvCb_Modalidad.Items.Add(Modalidad.PrevioAlDespacho)
        maxLength = 100 'AsignarLongMaximaCondicion()
    End Sub


    ' Carga de componentes.
    Private Sub Fr_CondicionPago_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            'Detectar el botón de radio chequeado en el diseñador de formulario.
            For Each rb As RadioButton In Flp_FechaCredito.Controls
                If rb.Checked Then
                    rbFechaCredito = rb
                    Exit For
                End If
            Next
        Catch
            Rb_FechaRadicado.Checked = True
            rbFechaCredito = Rb_FechaRadicado
        End Try
    End Sub


    ''' <summary>
    ''' Determina la longitud del campo de condición de pago en la tabla de orden de compra de la base de datos y la asigna a la variable de verificación de longitud de la condición de pago.
    ''' </summary>
    Private Sub AsignarLongMaximaCondicion()
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ORDENCOMPRA' AND COLUMN_NAME = 'CONDICIONPAGO'", conexion)
        Try
            conexion.Open()
            maxLength = comando.ExecuteScalar()
            conexion.Close()
        Catch
            maxLength = 100
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Retorna la cadena de texto con la condición de pago al formulario de Orden de Compra.
    ''' </summary>
    ''' <returns>Cadena de texto de la condición de pago.</returns>
    Public Function GetCondicionPago() As String
        Return condicionPago
    End Function


    ' Validación y envío de la condición de pago.
    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        If ValidarCondiciones() Then
            DialogResult = DialogResult.OK
            Close()
        Else

        End If
    End Sub


    ''' <summary>
    ''' Determina si la condición de pago es válida y se puede incluir en el formulario de la orden de compra o si se deben corregir valores.
    ''' </summary>
    ''' <returns>Verdadero si la condición de pago es válida. Falso si hay inconsistencias en la condición de pago.</returns>
    Private Function ValidarCondiciones() As Boolean
        Dim porcentaje As Integer = 0
        Dim dias As Integer = 0
        Dim sumaPorcentajes As Integer = 0
        Dim condValida As Boolean = True
        Dim erroresCond As Boolean = False
        Dim condicionesStrBld As New StringBuilder
        Dim cond As String = ""

        'Si solo tiene una fila, se asume que el porcentaje es del 100%.
        If Dgv_Condiciones.Rows.Count = 2 AndAlso Dgv_Condiciones.Rows(0).Cells(DgvTx_Porcentaje.Name).Value = "" Then
            Dgv_Condiciones.Rows(0).Cells(DgvTx_Porcentaje.Name).Value = 100
        End If
        For i As Integer = 0 To Dgv_Condiciones.Rows.Count - 2
            If Not IsNothing(Dgv_Condiciones.Rows(i).Cells(DgvTx_Porcentaje.Name).Value) AndAlso Trim(Dgv_Condiciones.Rows(i).Cells(DgvTx_Porcentaje.Name).Value) <> "" Then
                porcentaje = FuncionesBase.FuncionesBase.ValorRealInt(Dgv_Condiciones.Rows(i).Cells(DgvTx_Porcentaje.Name).Value)
                If porcentaje > 0 Then
                    If porcentaje <= 100 Then
                        sumaPorcentajes += porcentaje
                        Dgv_Condiciones.Rows(i).Cells(DgvTx_Porcentaje.Name).ErrorText = ""
                    Else
                        Dgv_Condiciones.Rows(i).Cells(DgvTx_Porcentaje.Name).ErrorText = "Debe especificar el porcentaje como un valor entre 1 y 100."
                        condValida = False
                    End If
                Else
                    Dgv_Condiciones.Rows(i).Cells(DgvTx_Porcentaje.Name).ErrorText = "Debe especificar el porcentaje como un valor numérico entre 1 y 100."
                    condValida = False
                End If
            Else
                Dgv_Condiciones.Rows(i).Cells(DgvTx_Porcentaje.Name).ErrorText = "El porcentaje no debe estar vacío."
                condValida = False
            End If

            If Not IsNothing(Dgv_Condiciones.Rows(i).Cells(DgvCb_Modalidad.Name).Value) AndAlso Trim(Dgv_Condiciones.Rows(i).Cells(DgvCb_Modalidad.Name).Value) <> "" Then
                Dgv_Condiciones.Rows(i).Cells(DgvCb_Modalidad.Name).ErrorText = ""
                If Dgv_Condiciones.Rows(i).Cells(DgvCb_Modalidad.Name).Value = Modalidad.Credito Then
                    If Not IsNothing(Dgv_Condiciones.Rows(i).Cells(DgvTx_Dias.Name).Value) AndAlso Trim(Dgv_Condiciones.Rows(i).Cells(DgvTx_Dias.Name).Value) <> "" Then
                        dias = FuncionesBase.FuncionesBase.ValorRealInt(Dgv_Condiciones.Rows(i).Cells(DgvTx_Dias.Name).Value)
                        If dias > 0 AndAlso dias <= 365 Then
                            Dgv_Condiciones.Rows(i).Cells(DgvTx_Dias.Name).ErrorText = ""
                        Else
                            Dgv_Condiciones.Rows(i).Cells(DgvTx_Dias.Name).ErrorText = "La cantidad de días debe ser un número mayor a cero y menor igual a 365 días para la modalidad a crédito."
                            condValida = False
                        End If
                    Else
                        Dgv_Condiciones.Rows(i).Cells(DgvTx_Dias.Name).ErrorText = "La cantidad de días no debe ser vacía para la modalidad a crédito."
                        condValida = False
                    End If
                Else
                    Dgv_Condiciones.Rows(i).Cells(DgvTx_Dias.Name).ErrorText = ""
                End If
            Else
                Dgv_Condiciones.Rows(i).Cells(DgvCb_Modalidad.Name).ErrorText = "La modalidad no debe estar vacía."
                condValida = False
            End If

            If condValida Then
                If porcentaje <> 100 Then
                    condicionesStrBld.Append(porcentaje & "% ")
                End If
                condicionesStrBld.Append(Dgv_Condiciones.Rows(i).Cells(DgvCb_Modalidad.Name).Value)
                If Dgv_Condiciones.Rows(i).Cells(DgvCb_Modalidad.Name).Value = Modalidad.Credito Then
                    condicionesStrBld.Append(" " & dias & " DÍAS")
                End If
                condicionesStrBld.Append(", ")
            Else
                erroresCond = True
            End If
            condValida = True
        Next
        If erroresCond Then
            MessageBox.Show("Se presentan inconsistencias en los valores de la condición de pago.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ValidarCondiciones = False
            Exit Function
        End If
        If sumaPorcentajes <> 100 Then
            MessageBox.Show("La suma de los porcentajes de las condiciones debe ser igual a 100%", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ValidarCondiciones = False
            Exit Function
        End If

        condicionesStrBld.Remove(condicionesStrBld.Length - 2, 2) 'Retirar última coma.
        If condicionesStrBld.ToString.Contains(Modalidad.Credito) Then
            condicionesStrBld.Append(" ")
            Select Case rbFechaCredito.Name
                Case Rb_FechaFactura.Name
                    condicionesStrBld.Append(FechaCredito.FechaDeFactura)
                Case Rb_FechaRadicado.Name
                    condicionesStrBld.Append(FechaCredito.FechaRadicadoFactura)
            End Select
        End If
        If Ck_AplicaDctoFinanciero.Checked Then
            condicionesStrBld.Append(". APLICA DESCUENTO FINANCIERO")
        End If
        cond = Trim(condicionesStrBld.ToString) & "."
        If cond.Length <= 0 OrElse cond.Length > maxLength Then
            MessageBox.Show("La condición de pago cuenta con " & cond.Length & "caracteres y la longitud máxima aceptada es " & maxLength & " caracteres" & _
                            "Por favor reduzca el número de criterios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ValidarCondiciones = False
            Exit Function
        Else
            condicionPago = cond
        End If

        ValidarCondiciones = True
    End Function


    ' Cierre del formulario.
    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub


    ' Agrega el evento de cambio de selección a las listas desplegables en la rejilla.
    Private Sub Dgv_Condiciones_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Dgv_Condiciones.EditingControlShowing
        If Dgv_Condiciones.CurrentCell.ColumnIndex = DgvCb_Modalidad.Index Then
            Dim combo As ComboBox = CType(e.Control, ComboBox)
            If (combo IsNot Nothing) Then
                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted)
                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionChangeCommitted)
            End If
        End If
    End Sub


    ' Habilita la caja de texto de días y los botones de radio cuando la modalidad seleccionada es "Crédito".
    Private Sub ComboBox_SelectionChangeCommitted(sender As Object, e As EventArgs)
        Dim combo As ComboBox = CType(sender, ComboBox)
        Dim celda As DataGridViewCell = Dgv_Condiciones.Rows(Dgv_Condiciones.CurrentCell.RowIndex).Cells(DgvTx_Dias.Index)
        If combo.SelectedItem = Modalidad.Credito Then
            celda.ReadOnly = False
            celda.Style.BackColor = Color.White
            celda.Style.ForeColor = Color.Black
            AlternarHabilitarRbFechasCredito(True)
        Else
            celda.Value = Nothing
            celda.ReadOnly = True
            celda.Style.BackColor = celda.OwningColumn.DefaultCellStyle.BackColor
            celda.Style.ForeColor = celda.OwningColumn.DefaultCellStyle.ForeColor
            AlternarHabilitarRbFechasCredito(False, celda.RowIndex)
        End If
    End Sub


    ''' <summary>
    ''' Habilita o inhabilita los botones de radio dependiendo de si se presenta la modalidad crédito en la condición de pago.
    ''' </summary>
    ''' <param name="habilitar"></param>
    Private Sub AlternarHabilitarRbFechasCredito(habilitar As Boolean, Optional rowIndex As Integer = 0)
        If habilitar Then
            Gb_FechaCredito.Enabled = True
        Else
            Dim existeModalidadCredito As Boolean = False
            For i As Integer = 0 To Dgv_Condiciones.Rows.Count - 1
                If i <> rowIndex AndAlso Dgv_Condiciones.Rows(i).Cells(DgvCb_Modalidad.Name).Value = Modalidad.Credito Then
                    existeModalidadCredito = True
                    Exit For
                End If
            Next
            Gb_FechaCredito.Enabled = existeModalidadCredito
        End If
    End Sub


    ' Guarda la referencia del botón de radio que se encuentra chequeado.
    Private Sub Rb_FechaCredito_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_FechaFactura.CheckedChanged, Rb_FechaRadicado.CheckedChanged
        If Not IsNothing(sender) AndAlso sender.Focused Then
            rbFechaCredito = sender
        End If
    End Sub

End Class 'Fr_CondicionPago