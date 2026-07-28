Imports System.Globalization
Imports System.Windows.Forms

''' <summary>
''' Caja de texto que aplica formatos de texto sobre el valor numérico decimal ingresado.
''' </summary>
''' <remarks>Ver también: Cu_TextBoxEntero, para manejo de valores enteros.</remarks>
Public Class Cu_TextBoxDecimal

    ''' <summary>
    ''' Menú contextual vacío para evitar el despliegue del menú por defecto que contiene las opciones de copiar y pegar.
    ''' </summary>
    ''' <remarks></remarks>
    Private cmVacio As New ContextMenu

    ''' <summary>
    ''' Valor ingresado en la caja de texto antes de aplicar formatos.
    ''' </summary>
    Private valorDecimal As Decimal

    ''' <summary>
    ''' Tipo de formato que se aplica al valor ingresado.
    ''' </summary>
    Private formato As Char = "N"

    ''' <summary>
    ''' Determina cuantas cifras decimales se muestran en la caja de texto.
    ''' </summary>
    Private posiciones As UInt16 = 0

    ''' <summary>
    ''' Listado de caracteres que se pueden ingresar en la caja de texto.
    ''' </summary>
    Private caracteresPermitidos As String = "0123456789.," & Convert.ToChar(Keys.Back)

    ''' <summary>
    ''' Caracter separador de cifras decimales de la configuración regional actual.
    ''' </summary>
    Private separadorDecimales As Char = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

    ''' <summary>
    ''' Cantidad de cifras decimales a mostrar.
    ''' </summary>
    ''' <value>Cantidad de cifras decimales que se pueden ingresar.</value>
    ''' <returns>Cantidad de cifras decimales del valor.</returns>
    Property PosicionesDecimales As UInt16
        Get
            Return posiciones
        End Get
        Set(value As UInt16)
            posiciones = value
            FormatearValor()
        End Set
    End Property

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
    ''' Valor decimal sin formato que representa la caja de texto.
    ''' </summary>
    ''' <value>Valor que contiene la caja de texto.</value>
    ''' <returns>Valor que contiene la caja de texto.</returns>
    Property Valor As Decimal
        Get
            Return valorDecimal
        End Get
        Set(value As Decimal)
            valorDecimal = value
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
            Return Tx_ValorDecimal.Text
        End Get
        Private Set(value As String)
            Tx_ValorDecimal.Text = value
        End Set
    End Property

    ''' <summary>
    ''' Cantidad máxima de caracteres que se puede ingresar a la caja de texto.
    ''' </summary>
    ''' <value>Cantidad de caracteres de la caja de texto.</value>
    ''' <returns>Cantidad de caracteres de la caja de texto.</returns>
    Property MaxLongitudTexto As Integer
        Get
            Return Tx_ValorDecimal.MaxLength
        End Get
        Set(value As Integer)
            Tx_ValorDecimal.MaxLength = value
        End Set
    End Property


    ''' <summary>
    ''' Establece el estado de solo lectura de la caja de texto.
    ''' </summary>
    ''' <value>Nuevo estado de lectura de la caja de texto.</value>
    ''' <returns>Estado actual de lectura de la caja de texto.</returns>
    Property SoloLectura As Boolean
        Get
            Return Tx_ValorDecimal.ReadOnly
        End Get
        Set(value As Boolean)
            Tx_ValorDecimal.ReadOnly = value
        End Set
    End Property


    ' 
    Private Sub Cu_TextBoxDecimal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tx_ValorDecimal.ContextMenu = cmVacio
        Select Case FormatoDeDatos
            Case "N"
                separadorDecimales = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Case "C"
                separadorDecimales = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
            Case "P"
                separadorDecimales = CultureInfo.CurrentCulture.NumberFormat.PercentDecimalSeparator
            Case Else
                separadorDecimales = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        End Select
    End Sub


    ' 
    Private Sub Tx_ValorDecimal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tx_ValorDecimal.KeyPress
        If Not caracteresPermitidos.Contains(e.KeyChar) Then
            e.KeyChar = ""
            e.Handled = True
            Ep_ErrorDecimal.SetError(Me, "Caracter inválido.")
        End If
        If e.KeyChar = "." OrElse e.KeyChar = "," Then
            If sender.Text.Contains(separadorDecimales) Then
                e.KeyChar = ""
                e.Handled = True
                Ep_ErrorDecimal.SetError(Me, "Secuencia de caracteres inválida.")
            Else
                e.KeyChar = separadorDecimales
            End If
        End If
    End Sub


    ' 
    Private Sub Tx_ValorDecimal_KeyDown(sender As Object, e As KeyEventArgs) Handles Tx_ValorDecimal.KeyDown
        If e.Control And e.KeyCode.ToString = "V" Then
            'Tx_ValorDecimal.Paste() 'No habilitar el comando de pegado para evitar el ingreso de valores inválidos.
        ElseIf e.Control And e.KeyCode.ToString = "C" Then
            Tx_ValorDecimal.Copy()
        End If
    End Sub


    ' 
    Private Sub Tx_ValorDecimal_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Tx_ValorDecimal.Validating
        Dim num As Nullable(Of Decimal) = FuncionesBase.FuncionesBase.ValorRealDec(sender.Text)
        If Not IsNothing(num) Then
            valorDecimal = num
            If valorDecimal < 0 Then
                sender.BackColor = Drawing.Color.Red
                Ep_ErrorDecimal.SetError(Me, "Cantidad inválida.")
            Else
                sender.BackColor = Drawing.Color.White
                Ep_ErrorDecimal.SetError(Me, "")
            End If
        Else
            sender.BackColor = Drawing.Color.Red
            Ep_ErrorDecimal.SetError(Me, "Cantidad inválida.")
        End If
    End Sub


    ' 
    Private Sub Tx_ValorDecimal_Validated(sender As Object, e As EventArgs) Handles Tx_ValorDecimal.Validated
        FormatearValor()
    End Sub


    ' 
    Private Sub Tx_ValorDecimal_Enter(sender As Object, e As EventArgs) Handles Tx_ValorDecimal.Enter
        Tx_ValorDecimal.Text = Valor
        Tx_ValorDecimal.SelectAll()
    End Sub


    ''' <summary>
    ''' Aplica el formato especificado en las propiedades del control de usuario sobre el valor decimal y lo ubica en la caja de texto.
    ''' </summary>
    Private Sub FormatearValor()
        Select Case FormatoDeDatos
            Case "P"
                Tx_ValorDecimal.Text = valorDecimal.ToString("N" & PosicionesDecimales, NumberFormatInfo.CurrentInfo) & " " & NumberFormatInfo.CurrentInfo.PercentSymbol
            Case Else
                Tx_ValorDecimal.Text = valorDecimal.ToString(FormatoDeDatos & PosicionesDecimales, NumberFormatInfo.CurrentInfo)
        End Select
    End Sub


    ''' <summary>
    ''' Expone el evento TextChanged de la caja de texto.
    ''' </summary>
    Public Custom Event TextChangedDecimal As EventHandler
        AddHandler(value As EventHandler)
            AddHandler Tx_ValorDecimal.TextChanged, value
        End AddHandler
        RemoveHandler(value As EventHandler)
            RemoveHandler Tx_ValorDecimal.TextChanged, value
        End RemoveHandler
        RaiseEvent(sender As Object, e As EventArgs)

        End RaiseEvent
    End Event


End Class