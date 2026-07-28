Imports System.Globalization
Imports System.Windows.Forms

''' <summary>
''' Caja de texto que aplica formatos de texto sobre el valor numérico entero ingresado.
''' </summary>
''' <remarks>Ver también: Cu_TextBoxDecimal, para manejo de valores con decimales.</remarks>
Public Class Cu_TextBoxEntero

    ''' <summary>
    ''' Menú contextual vacío para evitar el despliegue del menú por defecto que contiene las opciones de copiar y pegar.
    ''' </summary>
    ''' <remarks></remarks>
    Private cmVacio As New ContextMenu

    ''' <summary>
    ''' Valor ingresado en la caja de texto antes de aplicar formatos.
    ''' </summary>
    Private valorEntero As Integer

    ''' <summary>
    ''' Tipo de formato que se aplica al valor ingresado.
    ''' </summary>
    Private formato As Char = "N"

    ''' <summary>
    ''' Listado de caracteres que se pueden ingresar en la caja de texto.
    ''' </summary>
    Private caracteresPermitidos As String = "0123456789" & Convert.ToChar(Keys.Back) & Convert.ToChar(Keys.Delete)

    ''' <summary>
    ''' Tipo de formato que se aplica al valor ingresado. Las posibles opciones son:
    ''' "N": Numérico
    ''' "C": Moneda
    ''' "P": Porcentaje
    ''' </summary>
    ''' <value>Tipo de formato que se aplica al valor.</value>
    ''' <returns>Formato aplicado al valor.</returns>
    ''' <remarks>
    ''' Número: "N" ó "F"
    ''' Moneda: "C"
    ''' Porcentaje: "P"
    ''' </remarks>
    Property FormatoDeDatos As Char
        Get
            Return formato
        End Get
        Set(value As Char)
            formato = value
            FormatearValor()
        End Set
    End Property

    ''' <summary>
    ''' Valor entero sin formato que representa la caja de texto.
    ''' </summary>
    ''' <value>Valor que contiene la caja de texto.</value>
    ''' <returns>Valor que contiene la caja de texto.</returns>
    Property Valor As Integer
        Get
            Return valorEntero
        End Get
        Set(value As Integer)
            valorEntero = value
            FormatearValor()
        End Set
    End Property

    ''' <summary>
    ''' Texto con formato representativo del valor contenido en la caja de texto.
    ''' </summary>
    ''' <value>Texto con formato de la caja de texto.</value>
    ''' <returns>Texto con formato de la caja de texto.</returns>
    Property Texto As String
        Get
            Return Tx_ValorEntero.Text
        End Get
        Private Set(value As String)
            Tx_ValorEntero.Text = value
        End Set
    End Property

    ''' <summary>
    ''' Cantidad máxima de caracteres que se puede ingresar a la caja de texto.
    ''' </summary>
    ''' <value>Cantidad de caracteres de la caja de texto.</value>
    ''' <returns>Cantidad de caracteres de la caja de texto.</returns>
    Property MaxLongitudTexto As Integer
        Get
            Return Tx_ValorEntero.MaxLength
        End Get
        Set(value As Integer)
            Tx_ValorEntero.MaxLength = value
        End Set
    End Property


    ''' <summary>
    ''' Establece el estado de solo lectura de la caja de texto.
    ''' </summary>
    ''' <value>Nuevo estado de lectura de la caja de texto.</value>
    ''' <returns>Estado actual de lectura de la caja de texto.</returns>
    Property SoloLectura As Boolean
        Get
            Return Tx_ValorEntero.ReadOnly
        End Get
        Set(value As Boolean)
            Tx_ValorEntero.ReadOnly = value
        End Set
    End Property


    ' 
    Private Sub Cu_TextBoxEntero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tx_ValorEntero.ContextMenu = cmVacio
    End Sub


    ' 
    Private Sub Tx_ValorEntero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_ValorEntero.KeyPress
        If Not caracteresPermitidos.Contains(e.KeyChar) Then
            e.Handled = True
            Ep_ErrorEntero.SetError(Me, "Caracter inválido.")
        ElseIf e.KeyChar = "." Then 'Retira el caractér "." que tiene un código equivalente a "Keys.Delete".
            e.Handled = True
        End If
    End Sub


    ' 
    Private Sub Tx_ValorEntero_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_ValorEntero.KeyDown
        If e.Control And e.KeyCode.ToString = "V" Then
            'Tx_ValorEntero.Paste() 'No habilitar el comando de pegado para evitar el ingreso de valores inválidos.
        ElseIf e.Control And e.KeyCode.ToString = "C" Then
            Tx_ValorEntero.Copy()
        End If
    End Sub


    ' 
    Private Sub Tx_ValorEntero_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Tx_ValorEntero.Validating
        Dim num As Nullable(Of Integer) = FuncionesBase.FuncionesBase.ValorRealInt(sender.Text)
        If Not IsNothing(num) Then
            valorEntero = num
            If valorEntero < 0 Then
                sender.BackColor = Drawing.Color.Red
                Ep_ErrorEntero.SetError(Me, "Cantidad inválida.")
            Else
                sender.BackColor = Drawing.Color.White
                Ep_ErrorEntero.SetError(Me, "")
            End If
        Else
            sender.BackColor = Drawing.Color.Red
            Ep_ErrorEntero.SetError(Me, "Cantidad inválida.")
        End If
    End Sub


    ' 
    Private Sub Tx_ValorEntero_Validated(sender As Object, e As EventArgs) Handles Tx_ValorEntero.Validated
        FormatearValor()
    End Sub


    ' 
    Private Sub Tx_ValorEntero_Enter(sender As Object, e As EventArgs) Handles Tx_ValorEntero.Enter
        Tx_ValorEntero.Text = Valor
        FuncionesBase.FuncionesBase.EnfocarCajaTexto(Tx_ValorEntero)
    End Sub


    ''' <summary>
    ''' Aplica el formato especificado en las propiedades del control de usuario sobre el valor entero y lo ubica en la caja de texto.
    ''' </summary>
    Private Sub FormatearValor()
        Select Case FormatoDeDatos
            Case "P"
                Tx_ValorEntero.Text = valorEntero.ToString("N0", NumberFormatInfo.CurrentInfo) & " " & NumberFormatInfo.CurrentInfo.PercentSymbol
            Case Else
                Tx_ValorEntero.Text = valorEntero.ToString(FormatoDeDatos & "0", NumberFormatInfo.CurrentInfo)
        End Select
    End Sub


    ''' <summary>
    ''' Expone el evento TextChanged de la caja de texto.
    ''' </summary>
    Public Custom Event TextChangedDecimal As EventHandler
        AddHandler(value As EventHandler)
            AddHandler Tx_ValorEntero.TextChanged, value
        End AddHandler
        RemoveHandler(value As EventHandler)
            RemoveHandler Tx_ValorEntero.TextChanged, value
        End RemoveHandler
        RaiseEvent(sender As Object, e As EventArgs)

        End RaiseEvent
    End Event

End Class