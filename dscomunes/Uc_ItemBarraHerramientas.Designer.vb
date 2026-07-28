<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Uc_ItemBarraHerramientas
    Inherits System.Windows.Forms.Panel

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Uc_ItemBarraHerramientas))
        Me.Lb_titulo = New System.Windows.Forms.Label()
        Me.Pb_Imagen = New System.Windows.Forms.PictureBox()
        Me.Il_Imagenes = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Pb_Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lb_titulo
        '
        Me.Lb_titulo.BackColor = System.Drawing.Color.AliceBlue
        Me.Lb_titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lb_titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.Lb_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_titulo.Location = New System.Drawing.Point(0, 0)
        Me.Lb_titulo.Margin = New System.Windows.Forms.Padding(6)
        Me.Lb_titulo.Name = "Lb_titulo"
        Me.Lb_titulo.Size = New System.Drawing.Size(180, 30)
        Me.Lb_titulo.TabIndex = 2
        Me.Lb_titulo.Text = "Label1"
        Me.Lb_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pb_Imagen
        '
        Me.Pb_Imagen.BackColor = System.Drawing.Color.Transparent
        Me.Pb_Imagen.Location = New System.Drawing.Point(4, 3)
        Me.Pb_Imagen.Name = "Pb_Imagen"
        Me.Pb_Imagen.Size = New System.Drawing.Size(24, 24)
        Me.Pb_Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Pb_Imagen.TabIndex = 3
        Me.Pb_Imagen.TabStop = False
        '
        'Il_Imagenes
        '
        Me.Il_Imagenes.ImageStream = CType(resources.GetObject("Il_Imagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Il_Imagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.Il_Imagenes.Images.SetKeyName(0, "112_DownArrowShort_Blue_24x24_72.png")
        Me.Il_Imagenes.Images.SetKeyName(1, "112_UpArrowLong_Blue_24x24_72.png")
        Me.Il_Imagenes.Images.SetKeyName(2, "imprimir.png")
        Me.Il_Imagenes.Images.SetKeyName(3, "Filter.png")
        Me.Il_Imagenes.Images.SetKeyName(4, "Table_32.png")
        Me.Il_Imagenes.Images.SetKeyName(5, "search.png")
        Me.Il_Imagenes.Images.SetKeyName(6, "history.png")
        '
        'Uc_ItemBarraHerramientas
        '
        Me.Controls.Add(Me.Pb_Imagen)
        Me.Controls.Add(Me.Lb_titulo)
        Me.Size = New System.Drawing.Size(180, 180)
        CType(Me.Pb_Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Lb_titulo As System.Windows.Forms.Label
    Public WithEvents Pb_Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents Il_Imagenes As System.Windows.Forms.ImageList

End Class
