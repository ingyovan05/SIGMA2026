<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Acerca
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fr_Acerca))
        Me.Lb_Legal = New System.Windows.Forms.Label()
        Me.Pn_Lateral = New System.Windows.Forms.Panel()
        Me.Ll_Ayuda = New System.Windows.Forms.LinkLabel()
        Me.Pb_Ayuda = New System.Windows.Forms.PictureBox()
        Me.Lb_TextoSigma = New System.Windows.Forms.Label()
        Me.Pb_Ismocolito = New System.Windows.Forms.PictureBox()
        Me.Pb_LogoIsmocol = New System.Windows.Forms.PictureBox()
        Me.Lb_TituloSigma = New System.Windows.Forms.Label()
        Me.Pn_Separador = New System.Windows.Forms.Panel()
        Me.Lb_TextoVersion = New System.Windows.Forms.Label()
        Me.Pn_Datos = New System.Windows.Forms.Panel()
        Me.Tx_Contacto3 = New System.Windows.Forms.TextBox()
        Me.Ll_Contacto3 = New System.Windows.Forms.LinkLabel()
        Me.Tx_Correo3 = New System.Windows.Forms.TextBox()
        Me.Ll_Correo3 = New System.Windows.Forms.LinkLabel()
        Me.Ll_Persona3 = New System.Windows.Forms.LinkLabel()
        Me.Tx_Contacto2 = New System.Windows.Forms.TextBox()
        Me.Ll_Contacto2 = New System.Windows.Forms.LinkLabel()
        Me.Tx_Celular2 = New System.Windows.Forms.TextBox()
        Me.Ll_Celular2 = New System.Windows.Forms.LinkLabel()
        Me.Tx_Correo2 = New System.Windows.Forms.TextBox()
        Me.Ll_Correo2 = New System.Windows.Forms.LinkLabel()
        Me.Ll_Persona2 = New System.Windows.Forms.LinkLabel()
        Me.Tx_Contacto1 = New System.Windows.Forms.TextBox()
        Me.Ll_Contacto1 = New System.Windows.Forms.LinkLabel()
        Me.Tx_Celular1 = New System.Windows.Forms.TextBox()
        Me.Ll_Celular1 = New System.Windows.Forms.LinkLabel()
        Me.Tx_Correo1 = New System.Windows.Forms.TextBox()
        Me.Ll_Correo1 = New System.Windows.Forms.LinkLabel()
        Me.Ll_Persona1 = New System.Windows.Forms.LinkLabel()
        Me.Lb_TextoContactoSoporte = New System.Windows.Forms.Label()
        Me.Pn_Lateral.SuspendLayout()
        CType(Me.Pb_Ayuda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pb_Ismocolito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pb_LogoIsmocol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pn_Datos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lb_Legal
        '
        Me.Lb_Legal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lb_Legal.BackColor = System.Drawing.Color.White
        Me.Lb_Legal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_Legal.Location = New System.Drawing.Point(203, 453)
        Me.Lb_Legal.Name = "Lb_Legal"
        Me.Lb_Legal.Size = New System.Drawing.Size(428, 89)
        Me.Lb_Legal.TabIndex = 9
        Me.Lb_Legal.Text = resources.GetString("Lb_Legal.Text")
        Me.Lb_Legal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pn_Lateral
        '
        Me.Pn_Lateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pn_Lateral.Controls.Add(Me.Ll_Ayuda)
        Me.Pn_Lateral.Controls.Add(Me.Pb_Ayuda)
        Me.Pn_Lateral.Controls.Add(Me.Lb_TextoSigma)
        Me.Pn_Lateral.Controls.Add(Me.Pb_Ismocolito)
        Me.Pn_Lateral.Controls.Add(Me.Pb_LogoIsmocol)
        Me.Pn_Lateral.Dock = System.Windows.Forms.DockStyle.Left
        Me.Pn_Lateral.Location = New System.Drawing.Point(0, 0)
        Me.Pn_Lateral.Name = "Pn_Lateral"
        Me.Pn_Lateral.Size = New System.Drawing.Size(197, 548)
        Me.Pn_Lateral.TabIndex = 11
        '
        'Ll_Ayuda
        '
        Me.Ll_Ayuda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Ayuda.AutoSize = True
        Me.Ll_Ayuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Ayuda.Location = New System.Drawing.Point(78, 516)
        Me.Ll_Ayuda.Name = "Ll_Ayuda"
        Me.Ll_Ayuda.Size = New System.Drawing.Size(47, 16)
        Me.Ll_Ayuda.TabIndex = 50
        Me.Ll_Ayuda.TabStop = True
        Me.Ll_Ayuda.Text = "Ayuda"
        '
        'Pb_Ayuda
        '
        Me.Pb_Ayuda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Pb_Ayuda.Image = Global.ADMINRECURSOSISMOCOL.My.Resources.Resources.FAyuda
        Me.Pb_Ayuda.Location = New System.Drawing.Point(51, 441)
        Me.Pb_Ayuda.Name = "Pb_Ayuda"
        Me.Pb_Ayuda.Size = New System.Drawing.Size(95, 72)
        Me.Pb_Ayuda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Pb_Ayuda.TabIndex = 16
        Me.Pb_Ayuda.TabStop = False
        '
        'Lb_TextoSigma
        '
        Me.Lb_TextoSigma.AutoSize = True
        Me.Lb_TextoSigma.Font = New System.Drawing.Font("Bookman Old Style", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoSigma.ForeColor = System.Drawing.Color.Navy
        Me.Lb_TextoSigma.Location = New System.Drawing.Point(41, 385)
        Me.Lb_TextoSigma.Name = "Lb_TextoSigma"
        Me.Lb_TextoSigma.Size = New System.Drawing.Size(114, 36)
        Me.Lb_TextoSigma.TabIndex = 15
        Me.Lb_TextoSigma.Text = "SIGMA"
        Me.Lb_TextoSigma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pb_Ismocolito
        '
        Me.Pb_Ismocolito.Image = Global.ADMINRECURSOSISMOCOL.My.Resources.Resources.Ismocolito
        Me.Pb_Ismocolito.Location = New System.Drawing.Point(13, 140)
        Me.Pb_Ismocolito.Name = "Pb_Ismocolito"
        Me.Pb_Ismocolito.Size = New System.Drawing.Size(171, 232)
        Me.Pb_Ismocolito.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Pb_Ismocolito.TabIndex = 14
        Me.Pb_Ismocolito.TabStop = False
        '
        'Pb_LogoIsmocol
        '
        Me.Pb_LogoIsmocol.Image = CType(resources.GetObject("Pb_LogoIsmocol.Image"), System.Drawing.Image)
        Me.Pb_LogoIsmocol.Location = New System.Drawing.Point(34, 13)
        Me.Pb_LogoIsmocol.Name = "Pb_LogoIsmocol"
        Me.Pb_LogoIsmocol.Size = New System.Drawing.Size(128, 107)
        Me.Pb_LogoIsmocol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Pb_LogoIsmocol.TabIndex = 13
        Me.Pb_LogoIsmocol.TabStop = False
        '
        'Lb_TituloSigma
        '
        Me.Lb_TituloSigma.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TituloSigma.ForeColor = System.Drawing.Color.Navy
        Me.Lb_TituloSigma.Location = New System.Drawing.Point(211, 3)
        Me.Lb_TituloSigma.Name = "Lb_TituloSigma"
        Me.Lb_TituloSigma.Size = New System.Drawing.Size(392, 51)
        Me.Lb_TituloSigma.TabIndex = 12
        Me.Lb_TituloSigma.Text = "Sistema Integrado de Gestión de Materiales y Administración"
        Me.Lb_TituloSigma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pn_Separador
        '
        Me.Pn_Separador.BackColor = System.Drawing.Color.Gainsboro
        Me.Pn_Separador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pn_Separador.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pn_Separador.Location = New System.Drawing.Point(203, 450)
        Me.Pn_Separador.Name = "Pn_Separador"
        Me.Pn_Separador.Size = New System.Drawing.Size(428, 4)
        Me.Pn_Separador.TabIndex = 13
        '
        'Lb_TextoVersion
        '
        Me.Lb_TextoVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lb_TextoVersion.BackColor = System.Drawing.Color.White
        Me.Lb_TextoVersion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoVersion.Location = New System.Drawing.Point(203, 53)
        Me.Lb_TextoVersion.Name = "Lb_TextoVersion"
        Me.Lb_TextoVersion.Size = New System.Drawing.Size(428, 36)
        Me.Lb_TextoVersion.TabIndex = 14
        Me.Lb_TextoVersion.Text = "Microsoft Visual Studio 2013 Versión 12.0.21005.1 REL, Framework Versión 4.5.5120" & _
    "9 Rel y SQL SERVER 2014"
        Me.Lb_TextoVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Pn_Datos
        '
        Me.Pn_Datos.BackColor = System.Drawing.SystemColors.Info
        Me.Pn_Datos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pn_Datos.Controls.Add(Me.Tx_Contacto3)
        Me.Pn_Datos.Controls.Add(Me.Ll_Contacto3)
        Me.Pn_Datos.Controls.Add(Me.Tx_Correo3)
        Me.Pn_Datos.Controls.Add(Me.Ll_Correo3)
        Me.Pn_Datos.Controls.Add(Me.Ll_Persona3)
        Me.Pn_Datos.Controls.Add(Me.Tx_Contacto2)
        Me.Pn_Datos.Controls.Add(Me.Ll_Contacto2)
        Me.Pn_Datos.Controls.Add(Me.Tx_Celular2)
        Me.Pn_Datos.Controls.Add(Me.Ll_Celular2)
        Me.Pn_Datos.Controls.Add(Me.Tx_Correo2)
        Me.Pn_Datos.Controls.Add(Me.Ll_Correo2)
        Me.Pn_Datos.Controls.Add(Me.Ll_Persona2)
        Me.Pn_Datos.Controls.Add(Me.Tx_Contacto1)
        Me.Pn_Datos.Controls.Add(Me.Ll_Contacto1)
        Me.Pn_Datos.Controls.Add(Me.Tx_Celular1)
        Me.Pn_Datos.Controls.Add(Me.Ll_Celular1)
        Me.Pn_Datos.Controls.Add(Me.Tx_Correo1)
        Me.Pn_Datos.Controls.Add(Me.Ll_Correo1)
        Me.Pn_Datos.Controls.Add(Me.Ll_Persona1)
        Me.Pn_Datos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pn_Datos.Location = New System.Drawing.Point(203, 120)
        Me.Pn_Datos.Name = "Pn_Datos"
        Me.Pn_Datos.Size = New System.Drawing.Size(428, 324)
        Me.Pn_Datos.TabIndex = 17
        '
        'Tx_Contacto3
        '
        Me.Tx_Contacto3.Location = New System.Drawing.Point(173, 289)
        Me.Tx_Contacto3.Name = "Tx_Contacto3"
        Me.Tx_Contacto3.ReadOnly = True
        Me.Tx_Contacto3.Size = New System.Drawing.Size(241, 22)
        Me.Tx_Contacto3.TabIndex = 44
        Me.Tx_Contacto3.Text = "Tel: 60  (7) 6573377 Ext: 1256"
        '
        'Ll_Contacto3
        '
        Me.Ll_Contacto3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Contacto3.AutoSize = True
        Me.Ll_Contacto3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Contacto3.Location = New System.Drawing.Point(103, 292)
        Me.Ll_Contacto3.Name = "Ll_Contacto3"
        Me.Ll_Contacto3.Size = New System.Drawing.Size(64, 16)
        Me.Ll_Contacto3.TabIndex = 45
        Me.Ll_Contacto3.TabStop = True
        Me.Ll_Contacto3.Text = "Contacto:"
        '
        'Tx_Correo3
        '
        Me.Tx_Correo3.Location = New System.Drawing.Point(173, 261)
        Me.Tx_Correo3.Name = "Tx_Correo3"
        Me.Tx_Correo3.ReadOnly = True
        Me.Tx_Correo3.Size = New System.Drawing.Size(241, 22)
        Me.Tx_Correo3.TabIndex = 35
        Me.Tx_Correo3.Text = "materiales@ismocol.com"
        '
        'Ll_Correo3
        '
        Me.Ll_Correo3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Correo3.AutoSize = True
        Me.Ll_Correo3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Correo3.Location = New System.Drawing.Point(112, 264)
        Me.Ll_Correo3.Name = "Ll_Correo3"
        Me.Ll_Correo3.Size = New System.Drawing.Size(55, 16)
        Me.Ll_Correo3.TabIndex = 34
        Me.Ll_Correo3.TabStop = True
        Me.Ll_Correo3.Text = "Correo: "
        '
        'Ll_Persona3
        '
        Me.Ll_Persona3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Persona3.AutoSize = True
        Me.Ll_Persona3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Persona3.Location = New System.Drawing.Point(12, 236)
        Me.Ll_Persona3.Name = "Ll_Persona3"
        Me.Ll_Persona3.Size = New System.Drawing.Size(155, 16)
        Me.Ll_Persona3.TabIndex = 33
        Me.Ll_Persona3.TabStop = True
        Me.Ll_Persona3.Text = "Codificación de Artículos"
        '
        'Tx_Contacto2
        '
        Me.Tx_Contacto2.Location = New System.Drawing.Point(173, 204)
        Me.Tx_Contacto2.Name = "Tx_Contacto2"
        Me.Tx_Contacto2.ReadOnly = True
        Me.Tx_Contacto2.Size = New System.Drawing.Size(241, 22)
        Me.Tx_Contacto2.TabIndex = 53
        Me.Tx_Contacto2.Text = "Tel: 60 (7) 6573377 Ext: 1452"
        '
        'Ll_Contacto2
        '
        Me.Ll_Contacto2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Contacto2.AutoSize = True
        Me.Ll_Contacto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Contacto2.Location = New System.Drawing.Point(103, 207)
        Me.Ll_Contacto2.Name = "Ll_Contacto2"
        Me.Ll_Contacto2.Size = New System.Drawing.Size(64, 16)
        Me.Ll_Contacto2.TabIndex = 54
        Me.Ll_Contacto2.TabStop = True
        Me.Ll_Contacto2.Text = "Contacto:"
        '
        'Tx_Celular2
        '
        Me.Tx_Celular2.Location = New System.Drawing.Point(173, 174)
        Me.Tx_Celular2.Name = "Tx_Celular2"
        Me.Tx_Celular2.ReadOnly = True
        Me.Tx_Celular2.Size = New System.Drawing.Size(241, 22)
        Me.Tx_Celular2.TabIndex = 52
        Me.Tx_Celular2.Text = "314-257-6054"
        '
        'Ll_Celular2
        '
        Me.Ll_Celular2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Celular2.AutoSize = True
        Me.Ll_Celular2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Celular2.Location = New System.Drawing.Point(114, 177)
        Me.Ll_Celular2.Name = "Ll_Celular2"
        Me.Ll_Celular2.Size = New System.Drawing.Size(53, 16)
        Me.Ll_Celular2.TabIndex = 51
        Me.Ll_Celular2.TabStop = True
        Me.Ll_Celular2.Text = "Celular:"
        '
        'Tx_Correo2
        '
        Me.Tx_Correo2.Location = New System.Drawing.Point(173, 143)
        Me.Tx_Correo2.Name = "Tx_Correo2"
        Me.Tx_Correo2.ReadOnly = True
        Me.Tx_Correo2.Size = New System.Drawing.Size(241, 22)
        Me.Tx_Correo2.TabIndex = 50
        Me.Tx_Correo2.Text = "soporteaplicaciones@ismocol.com"
        '
        'Ll_Correo2
        '
        Me.Ll_Correo2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Correo2.AutoSize = True
        Me.Ll_Correo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Correo2.Location = New System.Drawing.Point(112, 149)
        Me.Ll_Correo2.Name = "Ll_Correo2"
        Me.Ll_Correo2.Size = New System.Drawing.Size(55, 16)
        Me.Ll_Correo2.TabIndex = 49
        Me.Ll_Correo2.TabStop = True
        Me.Ll_Correo2.Text = "Correo: "
        '
        'Ll_Persona2
        '
        Me.Ll_Persona2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Persona2.AutoSize = True
        Me.Ll_Persona2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Persona2.Location = New System.Drawing.Point(7, 121)
        Me.Ll_Persona2.Name = "Ll_Persona2"
        Me.Ll_Persona2.Size = New System.Drawing.Size(206, 16)
        Me.Ll_Persona2.TabIndex = 48
        Me.Ll_Persona2.TabStop = True
        Me.Ll_Persona2.Text = "Edwin Eduardo Camargo Medina"
        '
        'Tx_Contacto1
        '
        Me.Tx_Contacto1.Location = New System.Drawing.Point(173, 87)
        Me.Tx_Contacto1.Name = "Tx_Contacto1"
        Me.Tx_Contacto1.ReadOnly = True
        Me.Tx_Contacto1.Size = New System.Drawing.Size(241, 22)
        Me.Tx_Contacto1.TabIndex = 46
        Me.Tx_Contacto1.Text = "Tel:  60 (7) 6573377 Ext: 1450"
        '
        'Ll_Contacto1
        '
        Me.Ll_Contacto1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Contacto1.AutoSize = True
        Me.Ll_Contacto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Contacto1.Location = New System.Drawing.Point(103, 90)
        Me.Ll_Contacto1.Name = "Ll_Contacto1"
        Me.Ll_Contacto1.Size = New System.Drawing.Size(64, 16)
        Me.Ll_Contacto1.TabIndex = 47
        Me.Ll_Contacto1.TabStop = True
        Me.Ll_Contacto1.Text = "Contacto:"
        '
        'Tx_Celular1
        '
        Me.Tx_Celular1.Location = New System.Drawing.Point(173, 57)
        Me.Tx_Celular1.Name = "Tx_Celular1"
        Me.Tx_Celular1.ReadOnly = True
        Me.Tx_Celular1.Size = New System.Drawing.Size(241, 22)
        Me.Tx_Celular1.TabIndex = 23
        Me.Tx_Celular1.Text = "321-469-8471"
        '
        'Ll_Celular1
        '
        Me.Ll_Celular1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Celular1.AutoSize = True
        Me.Ll_Celular1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Celular1.Location = New System.Drawing.Point(114, 60)
        Me.Ll_Celular1.Name = "Ll_Celular1"
        Me.Ll_Celular1.Size = New System.Drawing.Size(53, 16)
        Me.Ll_Celular1.TabIndex = 22
        Me.Ll_Celular1.TabStop = True
        Me.Ll_Celular1.Text = "Celular:"
        '
        'Tx_Correo1
        '
        Me.Tx_Correo1.Location = New System.Drawing.Point(173, 29)
        Me.Tx_Correo1.Name = "Tx_Correo1"
        Me.Tx_Correo1.ReadOnly = True
        Me.Tx_Correo1.Size = New System.Drawing.Size(241, 22)
        Me.Tx_Correo1.TabIndex = 21
        Me.Tx_Correo1.Text = "sistemas@ismocol.com"
        '
        'Ll_Correo1
        '
        Me.Ll_Correo1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Correo1.AutoSize = True
        Me.Ll_Correo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Correo1.Location = New System.Drawing.Point(112, 32)
        Me.Ll_Correo1.Name = "Ll_Correo1"
        Me.Ll_Correo1.Size = New System.Drawing.Size(55, 16)
        Me.Ll_Correo1.TabIndex = 20
        Me.Ll_Correo1.TabStop = True
        Me.Ll_Correo1.Text = "Correo: "
        '
        'Ll_Persona1
        '
        Me.Ll_Persona1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ll_Persona1.AutoSize = True
        Me.Ll_Persona1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ll_Persona1.Location = New System.Drawing.Point(7, 4)
        Me.Ll_Persona1.Name = "Ll_Persona1"
        Me.Ll_Persona1.Size = New System.Drawing.Size(166, 16)
        Me.Ll_Persona1.TabIndex = 19
        Me.Ll_Persona1.TabStop = True
        Me.Ll_Persona1.Text = "Yovan Alirio Solano Florez"
        '
        'Lb_TextoContactoSoporte
        '
        Me.Lb_TextoContactoSoporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Lb_TextoContactoSoporte.BackColor = System.Drawing.Color.White
        Me.Lb_TextoContactoSoporte.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_TextoContactoSoporte.Location = New System.Drawing.Point(203, 96)
        Me.Lb_TextoContactoSoporte.Name = "Lb_TextoContactoSoporte"
        Me.Lb_TextoContactoSoporte.Size = New System.Drawing.Size(428, 17)
        Me.Lb_TextoContactoSoporte.TabIndex = 18
        Me.Lb_TextoContactoSoporte.Text = "Contacto de Soporte:"
        Me.Lb_TextoContactoSoporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Fr_Acerca
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(648, 548)
        Me.Controls.Add(Me.Lb_TextoContactoSoporte)
        Me.Controls.Add(Me.Pn_Datos)
        Me.Controls.Add(Me.Lb_TextoVersion)
        Me.Controls.Add(Me.Pn_Separador)
        Me.Controls.Add(Me.Lb_TituloSigma)
        Me.Controls.Add(Me.Pn_Lateral)
        Me.Controls.Add(Me.Lb_Legal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_Acerca"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acerca de SIGMA"
        Me.Pn_Lateral.ResumeLayout(False)
        Me.Pn_Lateral.PerformLayout()
        CType(Me.Pb_Ayuda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pb_Ismocolito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pb_LogoIsmocol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pn_Datos.ResumeLayout(False)
        Me.Pn_Datos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lb_Legal As System.Windows.Forms.Label
    Friend WithEvents Pn_Lateral As System.Windows.Forms.Panel
    Friend WithEvents Pb_LogoIsmocol As System.Windows.Forms.PictureBox
    Friend WithEvents Lb_TituloSigma As System.Windows.Forms.Label
    Friend WithEvents Pn_Separador As System.Windows.Forms.Panel
    Friend WithEvents Lb_TextoVersion As System.Windows.Forms.Label
    Friend WithEvents Pn_Datos As System.Windows.Forms.Panel
    Friend WithEvents Tx_Celular1 As System.Windows.Forms.TextBox
    Friend WithEvents Ll_Celular1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Tx_Correo1 As System.Windows.Forms.TextBox
    Friend WithEvents Ll_Correo1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Ll_Persona1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Pb_Ismocolito As System.Windows.Forms.PictureBox
    Friend WithEvents Tx_Correo3 As System.Windows.Forms.TextBox
    Friend WithEvents Ll_Correo3 As System.Windows.Forms.LinkLabel
    Friend WithEvents Ll_Persona3 As System.Windows.Forms.LinkLabel
    Friend WithEvents Ll_Contacto3 As System.Windows.Forms.LinkLabel
    Friend WithEvents Tx_Contacto3 As System.Windows.Forms.TextBox
    Friend WithEvents Ll_Contacto1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Tx_Contacto1 As System.Windows.Forms.TextBox
    Friend WithEvents Lb_TextoSigma As System.Windows.Forms.Label
    Friend WithEvents Ll_Contacto2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Tx_Contacto2 As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Celular2 As System.Windows.Forms.TextBox
    Friend WithEvents Ll_Celular2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Tx_Correo2 As System.Windows.Forms.TextBox
    Friend WithEvents Ll_Correo2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Ll_Persona2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Pb_Ayuda As System.Windows.Forms.PictureBox
    Friend WithEvents Ll_Ayuda As System.Windows.Forms.LinkLabel
    Friend WithEvents Lb_TextoContactoSoporte As System.Windows.Forms.Label
End Class