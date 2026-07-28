Imports System.Windows.Forms

''' <summary>
''' Numero de aprobación de borrador de factura electrónica.
''' </summary>
Public Class Fr_NumeroAprobacion

    ''' <summary>
    ''' Constructor del formulario, muestra el número de aprobación que se pasa como parámetro.
    ''' </summary>
    ''' <param name="naprob">Número de Aprobación generado al guardar una aprobación.</param>
    Public Sub New(naprob As Integer)
        InitializeComponent()
        Ll_NumAprobacion.Text = naprob
    End Sub

    ' 
    Private Sub Fr_NumeroAprobacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ' Copiar el número de aprobación al portapapeles.
    Private Sub Ll_NumAprobacion_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_NumAprobacion.LinkClicked
        Clipboard.SetText(Ll_NumAprobacion.Text)
    End Sub

    ' Copiar el número de aprobación al portapapeles.
    Private Sub Bt_Copiar_Click(sender As Object, e As EventArgs) Handles Bt_Copiar.Click
        Clipboard.SetText(Ll_NumAprobacion.Text)
    End Sub

    ' Cierre del formulario.
    Private Sub Bt_Aceptar_Click(sender As Object, e As EventArgs) Handles Bt_Aceptar.Click
        Close()
    End Sub

End Class 'Fr_NumeroAprobacion


''' <summary>
''' Label control that allows auto-adjustable text.
''' </summary>
''' <remarks>
''' https://social.msdn.microsoft.com/Forums/windows/en-US/97c18a1d-729e-4a68-8223-0fcc9ab9012b/automatically-wrap-text-in-label?forum=winforms
''' </remarks>
Friend Class GrowLabel
    Inherits Windows.Forms.Label

    ''' <summary>
    ''' 
    ''' </summary>
    Private mGrowing As Boolean

    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub GrowLabel()
        Me.AutoSize = False
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub resizeLabel()
        If mGrowing Then
            Return
        End If
        Try
            mGrowing = True
            Dim sz As Drawing.Size = New Drawing.Size(Me.Width, Int32.MaxValue)
            sz = Windows.Forms.TextRenderer.MeasureText(Me.Text, Me.Font, sz, Windows.Forms.TextFormatFlags.WordBreak)
            Me.Height = sz.Height
        Finally
            mGrowing = False
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        resizeLabel()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnFontChanged(e As EventArgs)
        MyBase.OnFontChanged(e)
        resizeLabel()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        resizeLabel()
    End Sub

End Class 'GrowLabel