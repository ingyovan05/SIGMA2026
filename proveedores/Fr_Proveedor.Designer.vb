<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Proveedor
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

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim NOMBRELabel As System.Windows.Forms.Label
        Dim DIGITOVERIFICACIONLabel As System.Windows.Forms.Label
        Dim NOMBREREPRESENTANTELEGALLabel As System.Windows.Forms.Label
        Dim SUCURSALENTIDADFINANCIERALabel As System.Windows.Forms.Label
        Dim IDENTIFICACIONTITULARCUENTALabel As System.Windows.Forms.Label
        Dim CONTACTOCARTERAENTIDADFINANCIERALabel As System.Windows.Forms.Label
        Dim OBSERVACIONFINANCIERALabel As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim CODIGOREGIMENIMPUESTORENTALabel As System.Windows.Forms.Label
        Dim RESPONSABILIDADFRENTEIVALabel As System.Windows.Forms.Label
        Dim NRORESOLUCIONAGENTELabel As System.Windows.Forms.Label
        Dim FECHARESOLUCIONAGENTELabel As System.Windows.Forms.Label
        Dim NRORESOLUCIONAUTORETENEDORLabel As System.Windows.Forms.Label
        Dim FECHARESOLUCIONAUTORETENEDORLabel As System.Windows.Forms.Label
        Dim TARIFAICALabel As System.Windows.Forms.Label
        Dim CIUDADSEDEFABRILLabel As System.Windows.Forms.Label
        Dim CODIGOCONDICIONPAGOLabel As System.Windows.Forms.Label
        Dim CUPOLabel As System.Windows.Forms.Label
        Dim DESCUENTOLabel As System.Windows.Forms.Label
        Dim Label30 As System.Windows.Forms.Label
        Dim Label33 As System.Windows.Forms.Label
        Dim Label35 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Lb_CódigoArtículo = New System.Windows.Forms.Label()
        Me.Bt_Guardar = New System.Windows.Forms.Button()
        Me.Bt_Cancelar = New System.Windows.Forms.Button()
        Me.Tx_Nombre = New System.Windows.Forms.TextBox()
        Me.Tx_DigitoVerificación = New System.Windows.Forms.TextBox()
        Me.TextBox_NombreRL = New System.Windows.Forms.TextBox()
        Me.SUCURSALENTIDADFINANCIERATextBox = New System.Windows.Forms.TextBox()
        Me.TITURALCUENTATextBox = New System.Windows.Forms.TextBox()
        Me.IDENTIFICACIONTITULARCUENTATextBox = New System.Windows.Forms.TextBox()
        Me.CONTACTOCARTERAENTIDADFINANCIERATextBox = New System.Windows.Forms.TextBox()
        Me.OBSERVACIONFINANCIERATextBox = New System.Windows.Forms.TextBox()
        Me.Cb_TipoIdentificación = New System.Windows.Forms.ComboBox()
        Me.GroupBox_DirecciónResidencia = New System.Windows.Forms.GroupBox()
        Me.Cu_CiudadDirección = New FormulariosClasesBase.Cu_Ciudad()
        Me.Tx_Dirección = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Tx_Identificación = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Tx_SegundoApellido = New System.Windows.Forms.TextBox()
        Me.Tx_PrimerApellido = New System.Windows.Forms.TextBox()
        Me.Tx_SegundoNombre = New System.Windows.Forms.TextBox()
        Me.Tx_PrimerNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tx_CorreoElectrónico = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Tx_TeléfonoMóvil = New System.Windows.Forms.TextBox()
        Me.Tx_Teléfono = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox_Fax = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox_CorreoElectrónicoRL = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox_TeléfonoMóvilRL = New System.Windows.Forms.TextBox()
        Me.TextBox_TeléfonoRL = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Tc_Proveedor = New System.Windows.Forms.TabControl()
        Me.Tp_Básica = New System.Windows.Forms.TabPage()
        Me.Cb_Activo = New System.Windows.Forms.CheckBox()
        Me.Tx_Nomenclatura = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox_CorreoElectrónicoV = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox_TeléfonoMóvilV = New System.Windows.Forms.TextBox()
        Me.TextBox_TeléfonoV = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox_NombreVenta = New System.Windows.Forms.TextBox()
        Me.Tp_Contable = New System.Windows.Forms.TabPage()
        Me.Tx_CódigoActividad = New System.Windows.Forms.TextBox()
        Me.Cb_ActividadPrincipal = New System.Windows.Forms.ComboBox()
        Me.Gb_ActividadIndustrial = New System.Windows.Forms.GroupBox()
        Me.Rb_ActividadIndustrialNo = New System.Windows.Forms.RadioButton()
        Me.Cu_CiudadFabril = New FormulariosClasesBase.Cu_Ciudad()
        Me.Rb_ActividadIndustrialSi = New System.Windows.Forms.RadioButton()
        Me.TARIFAICATextBox = New System.Windows.Forms.TextBox()
        Me.Gb_Autoretenedor = New System.Windows.Forms.GroupBox()
        Me.Rb_AutoretenedorNo = New System.Windows.Forms.RadioButton()
        Me.Rb_AutoretenedorSI = New System.Windows.Forms.RadioButton()
        Me.NRORESOLUCIONAUTORETENEDORTextBox = New System.Windows.Forms.TextBox()
        Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Gb_AgenteReteneedor = New System.Windows.Forms.GroupBox()
        Me.Rb_AgenteReteneedorNo = New System.Windows.Forms.RadioButton()
        Me.Rb_AgenteReteneedorSI = New System.Windows.Forms.RadioButton()
        Me.NRORESOLUCIONAGENTETextBox = New System.Windows.Forms.TextBox()
        Me.FECHARESOLUCIONAGENTEDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Gb_GranContribuyente = New System.Windows.Forms.GroupBox()
        Me.Rb_GranContribuyenteNo = New System.Windows.Forms.RadioButton()
        Me.Rb_GranContribuyenteSI = New System.Windows.Forms.RadioButton()
        Me.Cb_ResponsabilidadIVA = New System.Windows.Forms.ComboBox()
        Me.Cb_RegimenImpuesto = New System.Windows.Forms.ComboBox()
        Me.Tp_Complementaria = New System.Windows.Forms.TabPage()
        Me.CUPOTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.Nud_Descuento = New System.Windows.Forms.NumericUpDown()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Dgv_Documentos = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Cb_CondiciónPago = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Cb_Banco = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox_NumeroCuenta = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Cb_TipoCuenta = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Tp_Sucursales = New System.Windows.Forms.TabPage()
        Me.Bt_Editar = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Dgv_Sucursal = New System.Windows.Forms.DataGridView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Bt_Adicionar = New System.Windows.Forms.Button()
        Me.Gb_RepresentanteVentaSucursal = New System.Windows.Forms.GroupBox()
        Me.Tx_CorreoRVSucursal = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Tx_TeléfonoMóvilRVSucursal = New System.Windows.Forms.TextBox()
        Me.Tx_TeléfonoRVSucursal = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Tx_NombreRVSucursal = New System.Windows.Forms.TextBox()
        Me.Tx_CorreoSucursal = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Tx_TeléfonoMóvilSucursal = New System.Windows.Forms.TextBox()
        Me.Tx_TeléfonoSucursal = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Gb_DirecciónSucursal = New System.Windows.Forms.GroupBox()
        Me.Cu_CiudadSucursal = New FormulariosClasesBase.Cu_Ciudad()
        Me.Tx_DirecciónSucursal = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Tp_Suministro = New System.Windows.Forms.TabPage()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Dgv_Suministros = New System.Windows.Forms.DataGridView()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Tb_Otros = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Tp_CalificaciónOperativa = New System.Windows.Forms.TabPage()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Dgv_CalificaciónOperativa = New System.Windows.Forms.DataGridView()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Ck_DespachaEntrega = New System.Windows.Forms.CheckBox()
        NOMBRELabel = New System.Windows.Forms.Label()
        DIGITOVERIFICACIONLabel = New System.Windows.Forms.Label()
        NOMBREREPRESENTANTELEGALLabel = New System.Windows.Forms.Label()
        SUCURSALENTIDADFINANCIERALabel = New System.Windows.Forms.Label()
        IDENTIFICACIONTITULARCUENTALabel = New System.Windows.Forms.Label()
        CONTACTOCARTERAENTIDADFINANCIERALabel = New System.Windows.Forms.Label()
        OBSERVACIONFINANCIERALabel = New System.Windows.Forms.Label()
        Label16 = New System.Windows.Forms.Label()
        CODIGOREGIMENIMPUESTORENTALabel = New System.Windows.Forms.Label()
        RESPONSABILIDADFRENTEIVALabel = New System.Windows.Forms.Label()
        NRORESOLUCIONAGENTELabel = New System.Windows.Forms.Label()
        FECHARESOLUCIONAGENTELabel = New System.Windows.Forms.Label()
        NRORESOLUCIONAUTORETENEDORLabel = New System.Windows.Forms.Label()
        FECHARESOLUCIONAUTORETENEDORLabel = New System.Windows.Forms.Label()
        TARIFAICALabel = New System.Windows.Forms.Label()
        CIUDADSEDEFABRILLabel = New System.Windows.Forms.Label()
        CODIGOCONDICIONPAGOLabel = New System.Windows.Forms.Label()
        CUPOLabel = New System.Windows.Forms.Label()
        DESCUENTOLabel = New System.Windows.Forms.Label()
        Label30 = New System.Windows.Forms.Label()
        Label33 = New System.Windows.Forms.Label()
        Label35 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox_DirecciónResidencia.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Tc_Proveedor.SuspendLayout()
        Me.Tp_Básica.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Tp_Contable.SuspendLayout()
        Me.Gb_ActividadIndustrial.SuspendLayout()
        Me.Gb_Autoretenedor.SuspendLayout()
        Me.Gb_AgenteReteneedor.SuspendLayout()
        Me.Gb_GranContribuyente.SuspendLayout()
        Me.Tp_Complementaria.SuspendLayout()
        CType(Me.Nud_Descuento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Dgv_Documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Tp_Sucursales.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.Dgv_Sucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Gb_RepresentanteVentaSucursal.SuspendLayout()
        Me.Gb_DirecciónSucursal.SuspendLayout()
        Me.Tp_Suministro.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.Dgv_Suministros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Tp_CalificaciónOperativa.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.Dgv_CalificaciónOperativa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel13.SuspendLayout()
        Me.SuspendLayout()
        '
        'NOMBRELabel
        '
        NOMBRELabel.AutoSize = True
        NOMBRELabel.Location = New System.Drawing.Point(6, 36)
        NOMBRELabel.Name = "NOMBRELabel"
        NOMBRELabel.Size = New System.Drawing.Size(122, 13)
        NOMBRELabel.TabIndex = 32
        NOMBRELabel.Text = "Nombre o Razón Social:"
        '
        'DIGITOVERIFICACIONLabel
        '
        DIGITOVERIFICACIONLabel.AutoSize = True
        DIGITOVERIFICACIONLabel.Location = New System.Drawing.Point(531, 8)
        DIGITOVERIFICACIONLabel.Name = "DIGITOVERIFICACIONLabel"
        DIGITOVERIFICACIONLabel.Size = New System.Drawing.Size(25, 13)
        DIGITOVERIFICACIONLabel.TabIndex = 3
        DIGITOVERIFICACIONLabel.Text = "DV:"
        '
        'NOMBREREPRESENTANTELEGALLabel
        '
        NOMBREREPRESENTANTELEGALLabel.AutoSize = True
        NOMBREREPRESENTANTELEGALLabel.Location = New System.Drawing.Point(9, 23)
        NOMBREREPRESENTANTELEGALLabel.Name = "NOMBREREPRESENTANTELEGALLabel"
        NOMBREREPRESENTANTELEGALLabel.Size = New System.Drawing.Size(47, 13)
        NOMBREREPRESENTANTELEGALLabel.TabIndex = 60
        NOMBREREPRESENTANTELEGALLabel.Text = "Nombre:"
        '
        'SUCURSALENTIDADFINANCIERALabel
        '
        SUCURSALENTIDADFINANCIERALabel.AutoSize = True
        SUCURSALENTIDADFINANCIERALabel.Location = New System.Drawing.Point(358, 35)
        SUCURSALENTIDADFINANCIERALabel.Name = "SUCURSALENTIDADFINANCIERALabel"
        SUCURSALENTIDADFINANCIERALabel.Size = New System.Drawing.Size(51, 13)
        SUCURSALENTIDADFINANCIERALabel.TabIndex = 108
        SUCURSALENTIDADFINANCIERALabel.Text = "Sucursal:"
        '
        'IDENTIFICACIONTITULARCUENTALabel
        '
        IDENTIFICACIONTITULARCUENTALabel.AutoSize = True
        IDENTIFICACIONTITULARCUENTALabel.Location = New System.Drawing.Point(409, 90)
        IDENTIFICACIONTITULARCUENTALabel.Name = "IDENTIFICACIONTITULARCUENTALabel"
        IDENTIFICACIONTITULARCUENTALabel.Size = New System.Drawing.Size(105, 13)
        IDENTIFICACIONTITULARCUENTALabel.TabIndex = 114
        IDENTIFICACIONTITULARCUENTALabel.Text = "Identificación Titular:"
        '
        'CONTACTOCARTERAENTIDADFINANCIERALabel
        '
        CONTACTOCARTERAENTIDADFINANCIERALabel.AutoSize = True
        CONTACTOCARTERAENTIDADFINANCIERALabel.Location = New System.Drawing.Point(37, 117)
        CONTACTOCARTERAENTIDADFINANCIERALabel.Name = "CONTACTOCARTERAENTIDADFINANCIERALabel"
        CONTACTOCARTERAENTIDADFINANCIERALabel.Size = New System.Drawing.Size(87, 13)
        CONTACTOCARTERAENTIDADFINANCIERALabel.TabIndex = 118
        CONTACTOCARTERAENTIDADFINANCIERALabel.Text = "Contacto Banco:"
        '
        'OBSERVACIONFINANCIERALabel
        '
        OBSERVACIONFINANCIERALabel.AutoSize = True
        OBSERVACIONFINANCIERALabel.Location = New System.Drawing.Point(2, 145)
        OBSERVACIONFINANCIERALabel.Name = "OBSERVACIONFINANCIERALabel"
        OBSERVACIONFINANCIERALabel.Size = New System.Drawing.Size(122, 13)
        OBSERVACIONFINANCIERALabel.TabIndex = 120
        OBSERVACIONFINANCIERALabel.Text = "Observación Financiera:"
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(8, 22)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(47, 13)
        Label16.TabIndex = 60
        Label16.Text = "Nombre:"
        '
        'CODIGOREGIMENIMPUESTORENTALabel
        '
        CODIGOREGIMENIMPUESTORENTALabel.AutoSize = True
        CODIGOREGIMENIMPUESTORENTALabel.Location = New System.Drawing.Point(36, 8)
        CODIGOREGIMENIMPUESTORENTALabel.Name = "CODIGOREGIMENIMPUESTORENTALabel"
        CODIGOREGIMENIMPUESTORENTALabel.Size = New System.Drawing.Size(130, 13)
        CODIGOREGIMENIMPUESTORENTALabel.TabIndex = 100
        CODIGOREGIMENIMPUESTORENTALabel.Text = "Regimen Impuesto Renta:"
        '
        'RESPONSABILIDADFRENTEIVALabel
        '
        RESPONSABILIDADFRENTEIVALabel.AutoSize = True
        RESPONSABILIDADFRENTEIVALabel.Location = New System.Drawing.Point(14, 34)
        RESPONSABILIDADFRENTEIVALabel.Name = "RESPONSABILIDADFRENTEIVALabel"
        RESPONSABILIDADFRENTEIVALabel.Size = New System.Drawing.Size(152, 13)
        RESPONSABILIDADFRENTEIVALabel.TabIndex = 102
        RESPONSABILIDADFRENTEIVALabel.Text = "Responsabilidad Frente al IVA:"
        '
        'NRORESOLUCIONAGENTELabel
        '
        NRORESOLUCIONAGENTELabel.AutoSize = True
        NRORESOLUCIONAGENTELabel.Location = New System.Drawing.Point(14, 43)
        NRORESOLUCIONAGENTELabel.Name = "NRORESOLUCIONAGENTELabel"
        NRORESOLUCIONAGENTELabel.Size = New System.Drawing.Size(103, 13)
        NRORESOLUCIONAGENTELabel.TabIndex = 110
        NRORESOLUCIONAGENTELabel.Text = "Número Resolución:"
        '
        'FECHARESOLUCIONAGENTELabel
        '
        FECHARESOLUCIONAGENTELabel.AutoSize = True
        FECHARESOLUCIONAGENTELabel.Location = New System.Drawing.Point(21, 69)
        FECHARESOLUCIONAGENTELabel.Name = "FECHARESOLUCIONAGENTELabel"
        FECHARESOLUCIONAGENTELabel.Size = New System.Drawing.Size(96, 13)
        FECHARESOLUCIONAGENTELabel.TabIndex = 112
        FECHARESOLUCIONAGENTELabel.Text = "Fecha Resolución:"
        '
        'NRORESOLUCIONAUTORETENEDORLabel
        '
        NRORESOLUCIONAUTORETENEDORLabel.AutoSize = True
        NRORESOLUCIONAUTORETENEDORLabel.Location = New System.Drawing.Point(14, 44)
        NRORESOLUCIONAUTORETENEDORLabel.Name = "NRORESOLUCIONAUTORETENEDORLabel"
        NRORESOLUCIONAUTORETENEDORLabel.Size = New System.Drawing.Size(103, 13)
        NRORESOLUCIONAUTORETENEDORLabel.TabIndex = 114
        NRORESOLUCIONAUTORETENEDORLabel.Text = "Número Resolución:"
        '
        'FECHARESOLUCIONAUTORETENEDORLabel
        '
        FECHARESOLUCIONAUTORETENEDORLabel.AutoSize = True
        FECHARESOLUCIONAUTORETENEDORLabel.Location = New System.Drawing.Point(21, 71)
        FECHARESOLUCIONAUTORETENEDORLabel.Name = "FECHARESOLUCIONAUTORETENEDORLabel"
        FECHARESOLUCIONAUTORETENEDORLabel.Size = New System.Drawing.Size(96, 13)
        FECHARESOLUCIONAUTORETENEDORLabel.TabIndex = 116
        FECHARESOLUCIONAUTORETENEDORLabel.Text = "Fecha Resolución:"
        '
        'TARIFAICALabel
        '
        TARIFAICALabel.AutoSize = True
        TARIFAICALabel.Location = New System.Drawing.Point(29, 44)
        TARIFAICALabel.Name = "TARIFAICALabel"
        TARIFAICALabel.Size = New System.Drawing.Size(57, 13)
        TARIFAICALabel.TabIndex = 120
        TARIFAICALabel.Text = "Tarifa ICA:"
        '
        'CIUDADSEDEFABRILLabel
        '
        CIUDADSEDEFABRILLabel.AutoSize = True
        CIUDADSEDEFABRILLabel.Location = New System.Drawing.Point(15, 71)
        CIUDADSEDEFABRILLabel.Name = "CIUDADSEDEFABRILLabel"
        CIUDADSEDEFABRILLabel.Size = New System.Drawing.Size(71, 13)
        CIUDADSEDEFABRILLabel.TabIndex = 122
        CIUDADSEDEFABRILLabel.Text = "Ciudad Fabril:"
        '
        'CODIGOCONDICIONPAGOLabel
        '
        CODIGOCONDICIONPAGOLabel.AutoSize = True
        CODIGOCONDICIONPAGOLabel.Location = New System.Drawing.Point(39, 10)
        CODIGOCONDICIONPAGOLabel.Name = "CODIGOCONDICIONPAGOLabel"
        CODIGOCONDICIONPAGOLabel.Size = New System.Drawing.Size(85, 13)
        CODIGOCONDICIONPAGOLabel.TabIndex = 137
        CODIGOCONDICIONPAGOLabel.Text = "Condición Pago:"
        '
        'CUPOLabel
        '
        CUPOLabel.AutoSize = True
        CUPOLabel.Location = New System.Drawing.Point(371, 10)
        CUPOLabel.Name = "CUPOLabel"
        CUPOLabel.Size = New System.Drawing.Size(35, 13)
        CUPOLabel.TabIndex = 138
        CUPOLabel.Text = "Cupo:"
        '
        'DESCUENTOLabel
        '
        DESCUENTOLabel.AutoSize = True
        DESCUENTOLabel.Location = New System.Drawing.Point(528, 10)
        DESCUENTOLabel.Name = "DESCUENTOLabel"
        DESCUENTOLabel.Size = New System.Drawing.Size(62, 13)
        DESCUENTOLabel.TabIndex = 140
        DESCUENTOLabel.Text = "Descuento:"
        '
        'Label30
        '
        Label30.AutoSize = True
        Label30.Location = New System.Drawing.Point(6, 22)
        Label30.Name = "Label30"
        Label30.Size = New System.Drawing.Size(47, 13)
        Label30.TabIndex = 60
        Label30.Text = "Nombre:"
        '
        'Label33
        '
        Label33.AutoSize = True
        Label33.Location = New System.Drawing.Point(647, 10)
        Label33.Name = "Label33"
        Label33.Size = New System.Drawing.Size(15, 13)
        Label33.TabIndex = 144
        Label33.Text = "%"
        '
        'Label35
        '
        Label35.AutoSize = True
        Label35.Location = New System.Drawing.Point(16, 62)
        Label35.Name = "Label35"
        Label35.Size = New System.Drawing.Size(153, 13)
        Label35.TabIndex = 133
        Label35.Text = "Actividad Económica Principal:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Lb_CódigoArtículo)
        Me.Panel1.Controls.Add(Me.Bt_Guardar)
        Me.Panel1.Controls.Add(Me.Bt_Cancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 431)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(694, 30)
        Me.Panel1.TabIndex = 29
        '
        'Lb_CódigoArtículo
        '
        Me.Lb_CódigoArtículo.AutoSize = True
        Me.Lb_CódigoArtículo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_CódigoArtículo.ForeColor = System.Drawing.Color.Red
        Me.Lb_CódigoArtículo.Location = New System.Drawing.Point(11, 8)
        Me.Lb_CódigoArtículo.Name = "Lb_CódigoArtículo"
        Me.Lb_CódigoArtículo.Size = New System.Drawing.Size(52, 13)
        Me.Lb_CódigoArtículo.TabIndex = 2
        Me.Lb_CódigoArtículo.Text = "Label13"
        Me.Lb_CódigoArtículo.Visible = False
        '
        'Bt_Guardar
        '
        Me.Bt_Guardar.Location = New System.Drawing.Point(524, 3)
        Me.Bt_Guardar.Name = "Bt_Guardar"
        Me.Bt_Guardar.Size = New System.Drawing.Size(75, 22)
        Me.Bt_Guardar.TabIndex = 0
        Me.Bt_Guardar.Text = "Guardar"
        Me.Bt_Guardar.UseVisualStyleBackColor = True
        '
        'Bt_Cancelar
        '
        Me.Bt_Cancelar.Location = New System.Drawing.Point(605, 2)
        Me.Bt_Cancelar.Name = "Bt_Cancelar"
        Me.Bt_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cancelar.TabIndex = 1
        Me.Bt_Cancelar.Text = "Cancelar"
        Me.Bt_Cancelar.UseVisualStyleBackColor = True
        '
        'Tx_Nombre
        '
        Me.Tx_Nombre.Location = New System.Drawing.Point(134, 33)
        Me.Tx_Nombre.MaxLength = 150
        Me.Tx_Nombre.Name = "Tx_Nombre"
        Me.Tx_Nombre.Size = New System.Drawing.Size(340, 20)
        Me.Tx_Nombre.TabIndex = 4
        '
        'Tx_DigitoVerificación
        '
        Me.Tx_DigitoVerificación.Location = New System.Drawing.Point(559, 5)
        Me.Tx_DigitoVerificación.MaxLength = 1
        Me.Tx_DigitoVerificación.Name = "Tx_DigitoVerificación"
        Me.Tx_DigitoVerificación.Size = New System.Drawing.Size(32, 20)
        Me.Tx_DigitoVerificación.TabIndex = 3
        '
        'TextBox_NombreRL
        '
        Me.TextBox_NombreRL.Location = New System.Drawing.Point(59, 20)
        Me.TextBox_NombreRL.Name = "TextBox_NombreRL"
        Me.TextBox_NombreRL.Size = New System.Drawing.Size(297, 20)
        Me.TextBox_NombreRL.TabIndex = 0
        '
        'SUCURSALENTIDADFINANCIERATextBox
        '
        Me.SUCURSALENTIDADFINANCIERATextBox.Location = New System.Drawing.Point(412, 31)
        Me.SUCURSALENTIDADFINANCIERATextBox.Name = "SUCURSALENTIDADFINANCIERATextBox"
        Me.SUCURSALENTIDADFINANCIERATextBox.Size = New System.Drawing.Size(141, 20)
        Me.SUCURSALENTIDADFINANCIERATextBox.TabIndex = 4
        '
        'TITURALCUENTATextBox
        '
        Me.TITURALCUENTATextBox.Location = New System.Drawing.Point(126, 88)
        Me.TITURALCUENTATextBox.Name = "TITURALCUENTATextBox"
        Me.TITURALCUENTATextBox.Size = New System.Drawing.Size(276, 20)
        Me.TITURALCUENTATextBox.TabIndex = 7
        '
        'IDENTIFICACIONTITULARCUENTATextBox
        '
        Me.IDENTIFICACIONTITULARCUENTATextBox.Location = New System.Drawing.Point(521, 88)
        Me.IDENTIFICACIONTITULARCUENTATextBox.MaxLength = 15
        Me.IDENTIFICACIONTITULARCUENTATextBox.Name = "IDENTIFICACIONTITULARCUENTATextBox"
        Me.IDENTIFICACIONTITULARCUENTATextBox.Size = New System.Drawing.Size(141, 20)
        Me.IDENTIFICACIONTITULARCUENTATextBox.TabIndex = 8
        '
        'CONTACTOCARTERAENTIDADFINANCIERATextBox
        '
        Me.CONTACTOCARTERAENTIDADFINANCIERATextBox.Location = New System.Drawing.Point(126, 114)
        Me.CONTACTOCARTERAENTIDADFINANCIERATextBox.Name = "CONTACTOCARTERAENTIDADFINANCIERATextBox"
        Me.CONTACTOCARTERAENTIDADFINANCIERATextBox.Size = New System.Drawing.Size(276, 20)
        Me.CONTACTOCARTERAENTIDADFINANCIERATextBox.TabIndex = 9
        '
        'OBSERVACIONFINANCIERATextBox
        '
        Me.OBSERVACIONFINANCIERATextBox.Location = New System.Drawing.Point(126, 140)
        Me.OBSERVACIONFINANCIERATextBox.MaxLength = 200
        Me.OBSERVACIONFINANCIERATextBox.Name = "OBSERVACIONFINANCIERATextBox"
        Me.OBSERVACIONFINANCIERATextBox.Size = New System.Drawing.Size(536, 20)
        Me.OBSERVACIONFINANCIERATextBox.TabIndex = 10
        '
        'Cb_TipoIdentificación
        '
        Me.Cb_TipoIdentificación.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cb_TipoIdentificación.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cb_TipoIdentificación.DisplayMember = "NOMBRETIPOIDENTIFICACION"
        Me.Cb_TipoIdentificación.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoIdentificación.FormattingEnabled = True
        Me.Cb_TipoIdentificación.Location = New System.Drawing.Point(134, 5)
        Me.Cb_TipoIdentificación.Name = "Cb_TipoIdentificación"
        Me.Cb_TipoIdentificación.Size = New System.Drawing.Size(200, 21)
        Me.Cb_TipoIdentificación.TabIndex = 1
        Me.Cb_TipoIdentificación.ValueMember = "CODIGOTIPOIDENTIFICACION"
        '
        'GroupBox_DirecciónResidencia
        '
        Me.GroupBox_DirecciónResidencia.Controls.Add(Me.Cu_CiudadDirección)
        Me.GroupBox_DirecciónResidencia.Controls.Add(Me.Tx_Dirección)
        Me.GroupBox_DirecciónResidencia.Controls.Add(Me.Label6)
        Me.GroupBox_DirecciónResidencia.Location = New System.Drawing.Point(10, 110)
        Me.GroupBox_DirecciónResidencia.Name = "GroupBox_DirecciónResidencia"
        Me.GroupBox_DirecciónResidencia.Size = New System.Drawing.Size(324, 90)
        Me.GroupBox_DirecciónResidencia.TabIndex = 10
        Me.GroupBox_DirecciónResidencia.TabStop = False
        Me.GroupBox_DirecciónResidencia.Text = "Dirección Residencia"
        '
        'Cu_CiudadDirección
        '
        Me.Cu_CiudadDirección.Location = New System.Drawing.Point(45, 64)
        Me.Cu_CiudadDirección.Name = "Cu_CiudadDirección"
        Me.Cu_CiudadDirección.Size = New System.Drawing.Size(266, 23)
        Me.Cu_CiudadDirección.TabIndex = 1
        '
        'Tx_Dirección
        '
        Me.Tx_Dirección.Location = New System.Drawing.Point(7, 19)
        Me.Tx_Dirección.MaxLength = 100
        Me.Tx_Dirección.Multiline = True
        Me.Tx_Dirección.Name = "Tx_Dirección"
        Me.Tx_Dirección.Size = New System.Drawing.Size(304, 43)
        Me.Tx_Dirección.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Ciudad:"
        '
        'Tx_Identificación
        '
        Me.Tx_Identificación.Location = New System.Drawing.Point(419, 6)
        Me.Tx_Identificación.MaxLength = 15
        Me.Tx_Identificación.Name = "Tx_Identificación"
        Me.Tx_Identificación.Size = New System.Drawing.Size(106, 20)
        Me.Tx_Identificación.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(340, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 13)
        Me.Label20.TabIndex = 141
        Me.Label20.Text = "Identificación:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(34, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(97, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Tipo Identificación:"
        '
        'Tx_SegundoApellido
        '
        Me.Tx_SegundoApellido.Location = New System.Drawing.Point(483, 81)
        Me.Tx_SegundoApellido.MaxLength = 30
        Me.Tx_SegundoApellido.Name = "Tx_SegundoApellido"
        Me.Tx_SegundoApellido.Size = New System.Drawing.Size(179, 20)
        Me.Tx_SegundoApellido.TabIndex = 9
        '
        'Tx_PrimerApellido
        '
        Me.Tx_PrimerApellido.Location = New System.Drawing.Point(134, 84)
        Me.Tx_PrimerApellido.MaxLength = 30
        Me.Tx_PrimerApellido.Name = "Tx_PrimerApellido"
        Me.Tx_PrimerApellido.Size = New System.Drawing.Size(200, 20)
        Me.Tx_PrimerApellido.TabIndex = 8
        '
        'Tx_SegundoNombre
        '
        Me.Tx_SegundoNombre.Location = New System.Drawing.Point(483, 57)
        Me.Tx_SegundoNombre.MaxLength = 30
        Me.Tx_SegundoNombre.Name = "Tx_SegundoNombre"
        Me.Tx_SegundoNombre.Size = New System.Drawing.Size(179, 20)
        Me.Tx_SegundoNombre.TabIndex = 7
        '
        'Tx_PrimerNombre
        '
        Me.Tx_PrimerNombre.BackColor = System.Drawing.Color.White
        Me.Tx_PrimerNombre.Location = New System.Drawing.Point(134, 60)
        Me.Tx_PrimerNombre.MaxLength = 30
        Me.Tx_PrimerNombre.Name = "Tx_PrimerNombre"
        Me.Tx_PrimerNombre.Size = New System.Drawing.Size(200, 20)
        Me.Tx_PrimerNombre.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(387, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "Segundo Apellido:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 137
        Me.Label3.Text = "Primer Apellido:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(387, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Segundo Nombre:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Primer Nombre:"
        '
        'Tx_CorreoElectrónico
        '
        Me.Tx_CorreoElectrónico.Location = New System.Drawing.Point(483, 157)
        Me.Tx_CorreoElectrónico.MaxLength = 60
        Me.Tx_CorreoElectrónico.Name = "Tx_CorreoElectrónico"
        Me.Tx_CorreoElectrónico.Size = New System.Drawing.Size(179, 20)
        Me.Tx_CorreoElectrónico.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(383, 160)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 148
        Me.Label10.Text = "Correo Electrónico:"
        '
        'Tx_TeléfonoMóvil
        '
        Me.Tx_TeléfonoMóvil.Location = New System.Drawing.Point(483, 132)
        Me.Tx_TeléfonoMóvil.MaxLength = 10
        Me.Tx_TeléfonoMóvil.Name = "Tx_TeléfonoMóvil"
        Me.Tx_TeléfonoMóvil.Size = New System.Drawing.Size(179, 20)
        Me.Tx_TeléfonoMóvil.TabIndex = 12
        '
        'Tx_Teléfono
        '
        Me.Tx_Teléfono.Location = New System.Drawing.Point(483, 107)
        Me.Tx_Teléfono.MaxLength = 10
        Me.Tx_Teléfono.Name = "Tx_Teléfono"
        Me.Tx_Teléfono.Size = New System.Drawing.Size(179, 20)
        Me.Tx_Teléfono.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(445, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 147
        Me.Label8.Text = "Móvil:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(425, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 146
        Me.Label9.Text = "Teléfono:"
        '
        'TextBox_Fax
        '
        Me.TextBox_Fax.Location = New System.Drawing.Point(483, 182)
        Me.TextBox_Fax.MaxLength = 10
        Me.TextBox_Fax.Name = "TextBox_Fax"
        Me.TextBox_Fax.Size = New System.Drawing.Size(179, 20)
        Me.TextBox_Fax.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(453, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 150
        Me.Label5.Text = "Fax:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox_CorreoElectrónicoRL)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TextBox_TeléfonoMóvilRL)
        Me.GroupBox1.Controls.Add(Me.TextBox_TeléfonoRL)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(NOMBREREPRESENTANTELEGALLabel)
        Me.GroupBox1.Controls.Add(Me.TextBox_NombreRL)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 207)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(660, 77)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Representante Legal"
        '
        'TextBox_CorreoElectrónicoRL
        '
        Me.TextBox_CorreoElectrónicoRL.Location = New System.Drawing.Point(419, 46)
        Me.TextBox_CorreoElectrónicoRL.MaxLength = 60
        Me.TextBox_CorreoElectrónicoRL.Name = "TextBox_CorreoElectrónicoRL"
        Me.TextBox_CorreoElectrónicoRL.Size = New System.Drawing.Size(235, 20)
        Me.TextBox_CorreoElectrónicoRL.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(320, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 13)
        Me.Label7.TabIndex = 154
        Me.Label7.Text = "Correo Electrónico:"
        '
        'TextBox_TeléfonoMóvilRL
        '
        Me.TextBox_TeléfonoMóvilRL.Location = New System.Drawing.Point(209, 47)
        Me.TextBox_TeléfonoMóvilRL.MaxLength = 10
        Me.TextBox_TeléfonoMóvilRL.Name = "TextBox_TeléfonoMóvilRL"
        Me.TextBox_TeléfonoMóvilRL.Size = New System.Drawing.Size(101, 20)
        Me.TextBox_TeléfonoMóvilRL.TabIndex = 2
        '
        'TextBox_TeléfonoRL
        '
        Me.TextBox_TeléfonoRL.Location = New System.Drawing.Point(59, 47)
        Me.TextBox_TeléfonoRL.MaxLength = 10
        Me.TextBox_TeléfonoRL.Name = "TextBox_TeléfonoRL"
        Me.TextBox_TeléfonoRL.Size = New System.Drawing.Size(104, 20)
        Me.TextBox_TeléfonoRL.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(172, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 153
        Me.Label11.Text = "Móvil:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 152
        Me.Label12.Text = "Teléfono:"
        '
        'Tc_Proveedor
        '
        Me.Tc_Proveedor.Controls.Add(Me.Tp_Básica)
        Me.Tc_Proveedor.Controls.Add(Me.Tp_Contable)
        Me.Tc_Proveedor.Controls.Add(Me.Tp_Complementaria)
        Me.Tc_Proveedor.Controls.Add(Me.Tp_Sucursales)
        Me.Tc_Proveedor.Controls.Add(Me.Tp_Suministro)
        Me.Tc_Proveedor.Controls.Add(Me.Tp_CalificaciónOperativa)
        Me.Tc_Proveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tc_Proveedor.Location = New System.Drawing.Point(0, 0)
        Me.Tc_Proveedor.Name = "Tc_Proveedor"
        Me.Tc_Proveedor.SelectedIndex = 0
        Me.Tc_Proveedor.Size = New System.Drawing.Size(694, 431)
        Me.Tc_Proveedor.TabIndex = 0
        '
        'Tp_Básica
        '
        Me.Tp_Básica.Controls.Add(Me.Cb_Activo)
        Me.Tp_Básica.Controls.Add(Me.Tx_Nomenclatura)
        Me.Tp_Básica.Controls.Add(Me.Label37)
        Me.Tp_Básica.Controls.Add(Me.GroupBox2)
        Me.Tp_Básica.Controls.Add(NOMBRELabel)
        Me.Tp_Básica.Controls.Add(Me.GroupBox1)
        Me.Tp_Básica.Controls.Add(Me.Tx_DigitoVerificación)
        Me.Tp_Básica.Controls.Add(Me.TextBox_Fax)
        Me.Tp_Básica.Controls.Add(DIGITOVERIFICACIONLabel)
        Me.Tp_Básica.Controls.Add(Me.Label5)
        Me.Tp_Básica.Controls.Add(Me.Tx_Nombre)
        Me.Tp_Básica.Controls.Add(Me.Tx_CorreoElectrónico)
        Me.Tp_Básica.Controls.Add(Me.Label1)
        Me.Tp_Básica.Controls.Add(Me.Label10)
        Me.Tp_Básica.Controls.Add(Me.Label2)
        Me.Tp_Básica.Controls.Add(Me.Tx_TeléfonoMóvil)
        Me.Tp_Básica.Controls.Add(Me.Label3)
        Me.Tp_Básica.Controls.Add(Me.Tx_Teléfono)
        Me.Tp_Básica.Controls.Add(Me.Label4)
        Me.Tp_Básica.Controls.Add(Me.Label8)
        Me.Tp_Básica.Controls.Add(Me.Tx_PrimerNombre)
        Me.Tp_Básica.Controls.Add(Me.Label9)
        Me.Tp_Básica.Controls.Add(Me.Tx_SegundoNombre)
        Me.Tp_Básica.Controls.Add(Me.Cb_TipoIdentificación)
        Me.Tp_Básica.Controls.Add(Me.Tx_PrimerApellido)
        Me.Tp_Básica.Controls.Add(Me.GroupBox_DirecciónResidencia)
        Me.Tp_Básica.Controls.Add(Me.Tx_SegundoApellido)
        Me.Tp_Básica.Controls.Add(Me.Tx_Identificación)
        Me.Tp_Básica.Controls.Add(Me.Label19)
        Me.Tp_Básica.Controls.Add(Me.Label20)
        Me.Tp_Básica.Location = New System.Drawing.Point(4, 22)
        Me.Tp_Básica.Name = "Tp_Básica"
        Me.Tp_Básica.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_Básica.Size = New System.Drawing.Size(686, 405)
        Me.Tp_Básica.TabIndex = 0
        Me.Tp_Básica.Text = "Básica"
        Me.Tp_Básica.UseVisualStyleBackColor = True
        '
        'Cb_Activo
        '
        Me.Cb_Activo.AutoSize = True
        Me.Cb_Activo.Location = New System.Drawing.Point(606, 6)
        Me.Cb_Activo.Name = "Cb_Activo"
        Me.Cb_Activo.Size = New System.Drawing.Size(56, 17)
        Me.Cb_Activo.TabIndex = 152
        Me.Cb_Activo.Text = "Activo"
        Me.Cb_Activo.UseVisualStyleBackColor = True
        '
        'Tx_Nomenclatura
        '
        Me.Tx_Nomenclatura.Location = New System.Drawing.Point(559, 33)
        Me.Tx_Nomenclatura.MaxLength = 3
        Me.Tx_Nomenclatura.Name = "Tx_Nomenclatura"
        Me.Tx_Nomenclatura.Size = New System.Drawing.Size(103, 20)
        Me.Tx_Nomenclatura.TabIndex = 5
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(480, 36)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(73, 13)
        Me.Label37.TabIndex = 151
        Me.Label37.Text = "Nomenclatura"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox_CorreoElectrónicoV)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TextBox_TeléfonoMóvilV)
        Me.GroupBox2.Controls.Add(Me.TextBox_TeléfonoV)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Label16)
        Me.GroupBox2.Controls.Add(Me.TextBox_NombreVenta)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 287)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(660, 77)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Representante Venta"
        '
        'TextBox_CorreoElectrónicoV
        '
        Me.TextBox_CorreoElectrónicoV.Location = New System.Drawing.Point(418, 48)
        Me.TextBox_CorreoElectrónicoV.MaxLength = 60
        Me.TextBox_CorreoElectrónicoV.Name = "TextBox_CorreoElectrónicoV"
        Me.TextBox_CorreoElectrónicoV.Size = New System.Drawing.Size(235, 20)
        Me.TextBox_CorreoElectrónicoV.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(318, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 13)
        Me.Label13.TabIndex = 154
        Me.Label13.Text = "Correo Electrónico:"
        '
        'TextBox_TeléfonoMóvilV
        '
        Me.TextBox_TeléfonoMóvilV.Location = New System.Drawing.Point(208, 48)
        Me.TextBox_TeléfonoMóvilV.MaxLength = 10
        Me.TextBox_TeléfonoMóvilV.Name = "TextBox_TeléfonoMóvilV"
        Me.TextBox_TeléfonoMóvilV.Size = New System.Drawing.Size(101, 20)
        Me.TextBox_TeléfonoMóvilV.TabIndex = 2
        '
        'TextBox_TeléfonoV
        '
        Me.TextBox_TeléfonoV.Location = New System.Drawing.Point(59, 48)
        Me.TextBox_TeléfonoV.MaxLength = 10
        Me.TextBox_TeléfonoV.Name = "TextBox_TeléfonoV"
        Me.TextBox_TeléfonoV.Size = New System.Drawing.Size(104, 20)
        Me.TextBox_TeléfonoV.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(170, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 13)
        Me.Label14.TabIndex = 153
        Me.Label14.Text = "Móvil:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 152
        Me.Label15.Text = "Teléfono:"
        '
        'TextBox_NombreVenta
        '
        Me.TextBox_NombreVenta.Location = New System.Drawing.Point(58, 19)
        Me.TextBox_NombreVenta.Name = "TextBox_NombreVenta"
        Me.TextBox_NombreVenta.Size = New System.Drawing.Size(297, 20)
        Me.TextBox_NombreVenta.TabIndex = 0
        '
        'Tp_Contable
        '
        Me.Tp_Contable.Controls.Add(Me.Tx_CódigoActividad)
        Me.Tp_Contable.Controls.Add(Me.Cb_ActividadPrincipal)
        Me.Tp_Contable.Controls.Add(Label35)
        Me.Tp_Contable.Controls.Add(Me.Gb_ActividadIndustrial)
        Me.Tp_Contable.Controls.Add(Me.Gb_Autoretenedor)
        Me.Tp_Contable.Controls.Add(Me.Gb_AgenteReteneedor)
        Me.Tp_Contable.Controls.Add(Me.Gb_GranContribuyente)
        Me.Tp_Contable.Controls.Add(Me.Cb_ResponsabilidadIVA)
        Me.Tp_Contable.Controls.Add(Me.Cb_RegimenImpuesto)
        Me.Tp_Contable.Controls.Add(CODIGOREGIMENIMPUESTORENTALabel)
        Me.Tp_Contable.Controls.Add(RESPONSABILIDADFRENTEIVALabel)
        Me.Tp_Contable.Location = New System.Drawing.Point(4, 22)
        Me.Tp_Contable.Name = "Tp_Contable"
        Me.Tp_Contable.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp_Contable.Size = New System.Drawing.Size(686, 405)
        Me.Tp_Contable.TabIndex = 1
        Me.Tp_Contable.Text = "Contable"
        Me.Tp_Contable.UseVisualStyleBackColor = True
        '
        'Tx_CódigoActividad
        '
        Me.Tx_CódigoActividad.Location = New System.Drawing.Point(172, 58)
        Me.Tx_CódigoActividad.Name = "Tx_CódigoActividad"
        Me.Tx_CódigoActividad.Size = New System.Drawing.Size(48, 20)
        Me.Tx_CódigoActividad.TabIndex = 3
        '
        'Cb_ActividadPrincipal
        '
        Me.Cb_ActividadPrincipal.FormattingEnabled = True
        Me.Cb_ActividadPrincipal.Location = New System.Drawing.Point(226, 58)
        Me.Cb_ActividadPrincipal.Name = "Cb_ActividadPrincipal"
        Me.Cb_ActividadPrincipal.Size = New System.Drawing.Size(445, 21)
        Me.Cb_ActividadPrincipal.TabIndex = 4
        '
        'Gb_ActividadIndustrial
        '
        Me.Gb_ActividadIndustrial.Controls.Add(Me.Rb_ActividadIndustrialNo)
        Me.Gb_ActividadIndustrial.Controls.Add(Me.Cu_CiudadFabril)
        Me.Gb_ActividadIndustrial.Controls.Add(Me.Rb_ActividadIndustrialSi)
        Me.Gb_ActividadIndustrial.Controls.Add(CIUDADSEDEFABRILLabel)
        Me.Gb_ActividadIndustrial.Controls.Add(Me.TARIFAICATextBox)
        Me.Gb_ActividadIndustrial.Controls.Add(TARIFAICALabel)
        Me.Gb_ActividadIndustrial.Location = New System.Drawing.Point(6, 225)
        Me.Gb_ActividadIndustrial.Name = "Gb_ActividadIndustrial"
        Me.Gb_ActividadIndustrial.Size = New System.Drawing.Size(367, 95)
        Me.Gb_ActividadIndustrial.TabIndex = 8
        Me.Gb_ActividadIndustrial.TabStop = False
        Me.Gb_ActividadIndustrial.Text = "Actividad Industrial"
        '
        'Rb_ActividadIndustrialNo
        '
        Me.Rb_ActividadIndustrialNo.AutoSize = True
        Me.Rb_ActividadIndustrialNo.Location = New System.Drawing.Point(76, 19)
        Me.Rb_ActividadIndustrialNo.Name = "Rb_ActividadIndustrialNo"
        Me.Rb_ActividadIndustrialNo.Size = New System.Drawing.Size(41, 17)
        Me.Rb_ActividadIndustrialNo.TabIndex = 1
        Me.Rb_ActividadIndustrialNo.TabStop = True
        Me.Rb_ActividadIndustrialNo.Text = "NO"
        Me.Rb_ActividadIndustrialNo.UseVisualStyleBackColor = True
        '
        'Cu_CiudadFabril
        '
        Me.Cu_CiudadFabril.Location = New System.Drawing.Point(92, 66)
        Me.Cu_CiudadFabril.Name = "Cu_CiudadFabril"
        Me.Cu_CiudadFabril.Size = New System.Drawing.Size(266, 23)
        Me.Cu_CiudadFabril.TabIndex = 3
        '
        'Rb_ActividadIndustrialSi
        '
        Me.Rb_ActividadIndustrialSi.AutoSize = True
        Me.Rb_ActividadIndustrialSi.Location = New System.Drawing.Point(21, 19)
        Me.Rb_ActividadIndustrialSi.Name = "Rb_ActividadIndustrialSi"
        Me.Rb_ActividadIndustrialSi.Size = New System.Drawing.Size(35, 17)
        Me.Rb_ActividadIndustrialSi.TabIndex = 0
        Me.Rb_ActividadIndustrialSi.TabStop = True
        Me.Rb_ActividadIndustrialSi.Text = "SI"
        Me.Rb_ActividadIndustrialSi.UseVisualStyleBackColor = True
        '
        'TARIFAICATextBox
        '
        Me.TARIFAICATextBox.Location = New System.Drawing.Point(92, 41)
        Me.TARIFAICATextBox.Name = "TARIFAICATextBox"
        Me.TARIFAICATextBox.Size = New System.Drawing.Size(48, 20)
        Me.TARIFAICATextBox.TabIndex = 2
        '
        'Gb_Autoretenedor
        '
        Me.Gb_Autoretenedor.Controls.Add(Me.Rb_AutoretenedorNo)
        Me.Gb_Autoretenedor.Controls.Add(Me.Rb_AutoretenedorSI)
        Me.Gb_Autoretenedor.Controls.Add(Me.NRORESOLUCIONAUTORETENEDORTextBox)
        Me.Gb_Autoretenedor.Controls.Add(Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker)
        Me.Gb_Autoretenedor.Controls.Add(FECHARESOLUCIONAUTORETENEDORLabel)
        Me.Gb_Autoretenedor.Controls.Add(NRORESOLUCIONAUTORETENEDORLabel)
        Me.Gb_Autoretenedor.Location = New System.Drawing.Point(272, 126)
        Me.Gb_Autoretenedor.Name = "Gb_Autoretenedor"
        Me.Gb_Autoretenedor.Size = New System.Drawing.Size(259, 95)
        Me.Gb_Autoretenedor.TabIndex = 7
        Me.Gb_Autoretenedor.TabStop = False
        Me.Gb_Autoretenedor.Text = "Autoretenedor"
        '
        'Rb_AutoretenedorNo
        '
        Me.Rb_AutoretenedorNo.AutoSize = True
        Me.Rb_AutoretenedorNo.Location = New System.Drawing.Point(76, 19)
        Me.Rb_AutoretenedorNo.Name = "Rb_AutoretenedorNo"
        Me.Rb_AutoretenedorNo.Size = New System.Drawing.Size(41, 17)
        Me.Rb_AutoretenedorNo.TabIndex = 1
        Me.Rb_AutoretenedorNo.TabStop = True
        Me.Rb_AutoretenedorNo.Text = "NO"
        Me.Rb_AutoretenedorNo.UseVisualStyleBackColor = True
        '
        'Rb_AutoretenedorSI
        '
        Me.Rb_AutoretenedorSI.AutoSize = True
        Me.Rb_AutoretenedorSI.Location = New System.Drawing.Point(21, 19)
        Me.Rb_AutoretenedorSI.Name = "Rb_AutoretenedorSI"
        Me.Rb_AutoretenedorSI.Size = New System.Drawing.Size(35, 17)
        Me.Rb_AutoretenedorSI.TabIndex = 0
        Me.Rb_AutoretenedorSI.TabStop = True
        Me.Rb_AutoretenedorSI.Text = "SI"
        Me.Rb_AutoretenedorSI.UseVisualStyleBackColor = True
        '
        'NRORESOLUCIONAUTORETENEDORTextBox
        '
        Me.NRORESOLUCIONAUTORETENEDORTextBox.Location = New System.Drawing.Point(123, 41)
        Me.NRORESOLUCIONAUTORETENEDORTextBox.Name = "NRORESOLUCIONAUTORETENEDORTextBox"
        Me.NRORESOLUCIONAUTORETENEDORTextBox.Size = New System.Drawing.Size(127, 20)
        Me.NRORESOLUCIONAUTORETENEDORTextBox.TabIndex = 2
        '
        'FECHARESOLUCIONAUTORETENEDORDateTimePicker
        '
        Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.Checked = False
        Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.Location = New System.Drawing.Point(123, 67)
        Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.Name = "FECHARESOLUCIONAUTORETENEDORDateTimePicker"
        Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.ShowCheckBox = True
        Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.Size = New System.Drawing.Size(127, 20)
        Me.FECHARESOLUCIONAUTORETENEDORDateTimePicker.TabIndex = 3
        '
        'Gb_AgenteReteneedor
        '
        Me.Gb_AgenteReteneedor.Controls.Add(Me.Rb_AgenteReteneedorNo)
        Me.Gb_AgenteReteneedor.Controls.Add(Me.Rb_AgenteReteneedorSI)
        Me.Gb_AgenteReteneedor.Controls.Add(NRORESOLUCIONAGENTELabel)
        Me.Gb_AgenteReteneedor.Controls.Add(Me.NRORESOLUCIONAGENTETextBox)
        Me.Gb_AgenteReteneedor.Controls.Add(FECHARESOLUCIONAGENTELabel)
        Me.Gb_AgenteReteneedor.Controls.Add(Me.FECHARESOLUCIONAGENTEDateTimePicker)
        Me.Gb_AgenteReteneedor.Location = New System.Drawing.Point(6, 126)
        Me.Gb_AgenteReteneedor.Name = "Gb_AgenteReteneedor"
        Me.Gb_AgenteReteneedor.Size = New System.Drawing.Size(258, 95)
        Me.Gb_AgenteReteneedor.TabIndex = 6
        Me.Gb_AgenteReteneedor.TabStop = False
        Me.Gb_AgenteReteneedor.Text = "Agente Retenedor"
        '
        'Rb_AgenteReteneedorNo
        '
        Me.Rb_AgenteReteneedorNo.AutoSize = True
        Me.Rb_AgenteReteneedorNo.Location = New System.Drawing.Point(76, 19)
        Me.Rb_AgenteReteneedorNo.Name = "Rb_AgenteReteneedorNo"
        Me.Rb_AgenteReteneedorNo.Size = New System.Drawing.Size(41, 17)
        Me.Rb_AgenteReteneedorNo.TabIndex = 1
        Me.Rb_AgenteReteneedorNo.TabStop = True
        Me.Rb_AgenteReteneedorNo.Text = "NO"
        Me.Rb_AgenteReteneedorNo.UseVisualStyleBackColor = True
        '
        'Rb_AgenteReteneedorSI
        '
        Me.Rb_AgenteReteneedorSI.AutoSize = True
        Me.Rb_AgenteReteneedorSI.Location = New System.Drawing.Point(21, 19)
        Me.Rb_AgenteReteneedorSI.Name = "Rb_AgenteReteneedorSI"
        Me.Rb_AgenteReteneedorSI.Size = New System.Drawing.Size(35, 17)
        Me.Rb_AgenteReteneedorSI.TabIndex = 0
        Me.Rb_AgenteReteneedorSI.TabStop = True
        Me.Rb_AgenteReteneedorSI.Text = "SI"
        Me.Rb_AgenteReteneedorSI.UseVisualStyleBackColor = True
        '
        'NRORESOLUCIONAGENTETextBox
        '
        Me.NRORESOLUCIONAGENTETextBox.Location = New System.Drawing.Point(123, 40)
        Me.NRORESOLUCIONAGENTETextBox.Name = "NRORESOLUCIONAGENTETextBox"
        Me.NRORESOLUCIONAGENTETextBox.Size = New System.Drawing.Size(127, 20)
        Me.NRORESOLUCIONAGENTETextBox.TabIndex = 2
        '
        'FECHARESOLUCIONAGENTEDateTimePicker
        '
        Me.FECHARESOLUCIONAGENTEDateTimePicker.Checked = False
        Me.FECHARESOLUCIONAGENTEDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FECHARESOLUCIONAGENTEDateTimePicker.Location = New System.Drawing.Point(123, 66)
        Me.FECHARESOLUCIONAGENTEDateTimePicker.Name = "FECHARESOLUCIONAGENTEDateTimePicker"
        Me.FECHARESOLUCIONAGENTEDateTimePicker.ShowCheckBox = True
        Me.FECHARESOLUCIONAGENTEDateTimePicker.Size = New System.Drawing.Size(127, 20)
        Me.FECHARESOLUCIONAGENTEDateTimePicker.TabIndex = 3
        '
        'Gb_GranContribuyente
        '
        Me.Gb_GranContribuyente.Controls.Add(Me.Rb_GranContribuyenteNo)
        Me.Gb_GranContribuyente.Controls.Add(Me.Rb_GranContribuyenteSI)
        Me.Gb_GranContribuyente.Location = New System.Drawing.Point(6, 82)
        Me.Gb_GranContribuyente.Name = "Gb_GranContribuyente"
        Me.Gb_GranContribuyente.Size = New System.Drawing.Size(150, 41)
        Me.Gb_GranContribuyente.TabIndex = 5
        Me.Gb_GranContribuyente.TabStop = False
        Me.Gb_GranContribuyente.Text = "Gran Contribuyente"
        '
        'Rb_GranContribuyenteNo
        '
        Me.Rb_GranContribuyenteNo.AutoSize = True
        Me.Rb_GranContribuyenteNo.Location = New System.Drawing.Point(76, 19)
        Me.Rb_GranContribuyenteNo.Name = "Rb_GranContribuyenteNo"
        Me.Rb_GranContribuyenteNo.Size = New System.Drawing.Size(41, 17)
        Me.Rb_GranContribuyenteNo.TabIndex = 1
        Me.Rb_GranContribuyenteNo.TabStop = True
        Me.Rb_GranContribuyenteNo.Text = "NO"
        Me.Rb_GranContribuyenteNo.UseVisualStyleBackColor = True
        '
        'Rb_GranContribuyenteSI
        '
        Me.Rb_GranContribuyenteSI.AutoSize = True
        Me.Rb_GranContribuyenteSI.Location = New System.Drawing.Point(21, 19)
        Me.Rb_GranContribuyenteSI.Name = "Rb_GranContribuyenteSI"
        Me.Rb_GranContribuyenteSI.Size = New System.Drawing.Size(35, 17)
        Me.Rb_GranContribuyenteSI.TabIndex = 0
        Me.Rb_GranContribuyenteSI.TabStop = True
        Me.Rb_GranContribuyenteSI.Text = "SI"
        Me.Rb_GranContribuyenteSI.UseVisualStyleBackColor = True
        '
        'Cb_ResponsabilidadIVA
        '
        Me.Cb_ResponsabilidadIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_ResponsabilidadIVA.FormattingEnabled = True
        Me.Cb_ResponsabilidadIVA.Items.AddRange(New Object() {"Régimen Común", "Régimen Simplificado"})
        Me.Cb_ResponsabilidadIVA.Location = New System.Drawing.Point(172, 31)
        Me.Cb_ResponsabilidadIVA.Name = "Cb_ResponsabilidadIVA"
        Me.Cb_ResponsabilidadIVA.Size = New System.Drawing.Size(121, 21)
        Me.Cb_ResponsabilidadIVA.TabIndex = 2
        '
        'Cb_RegimenImpuesto
        '
        Me.Cb_RegimenImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_RegimenImpuesto.FormattingEnabled = True
        Me.Cb_RegimenImpuesto.Items.AddRange(New Object() {"Ordinario", "Especial", "No Contribuyente"})
        Me.Cb_RegimenImpuesto.Location = New System.Drawing.Point(172, 5)
        Me.Cb_RegimenImpuesto.Name = "Cb_RegimenImpuesto"
        Me.Cb_RegimenImpuesto.Size = New System.Drawing.Size(121, 21)
        Me.Cb_RegimenImpuesto.TabIndex = 1
        '
        'Tp_Complementaria
        '
        Me.Tp_Complementaria.Controls.Add(Me.CUPOTextBox)
        Me.Tp_Complementaria.Controls.Add(Me.Nud_Descuento)
        Me.Tp_Complementaria.Controls.Add(Label33)
        Me.Tp_Complementaria.Controls.Add(Me.Panel2)
        Me.Tp_Complementaria.Controls.Add(Me.Cb_CondiciónPago)
        Me.Tp_Complementaria.Controls.Add(CODIGOCONDICIONPAGOLabel)
        Me.Tp_Complementaria.Controls.Add(CUPOLabel)
        Me.Tp_Complementaria.Controls.Add(DESCUENTOLabel)
        Me.Tp_Complementaria.Controls.Add(Me.Label21)
        Me.Tp_Complementaria.Controls.Add(Me.Cb_Banco)
        Me.Tp_Complementaria.Controls.Add(Me.Label17)
        Me.Tp_Complementaria.Controls.Add(Me.TextBox_NumeroCuenta)
        Me.Tp_Complementaria.Controls.Add(Me.Label18)
        Me.Tp_Complementaria.Controls.Add(Me.Cb_TipoCuenta)
        Me.Tp_Complementaria.Controls.Add(Me.Label25)
        Me.Tp_Complementaria.Controls.Add(Me.OBSERVACIONFINANCIERATextBox)
        Me.Tp_Complementaria.Controls.Add(OBSERVACIONFINANCIERALabel)
        Me.Tp_Complementaria.Controls.Add(Me.CONTACTOCARTERAENTIDADFINANCIERATextBox)
        Me.Tp_Complementaria.Controls.Add(CONTACTOCARTERAENTIDADFINANCIERALabel)
        Me.Tp_Complementaria.Controls.Add(Me.IDENTIFICACIONTITULARCUENTATextBox)
        Me.Tp_Complementaria.Controls.Add(IDENTIFICACIONTITULARCUENTALabel)
        Me.Tp_Complementaria.Controls.Add(SUCURSALENTIDADFINANCIERALabel)
        Me.Tp_Complementaria.Controls.Add(Me.TITURALCUENTATextBox)
        Me.Tp_Complementaria.Controls.Add(Me.SUCURSALENTIDADFINANCIERATextBox)
        Me.Tp_Complementaria.Location = New System.Drawing.Point(4, 22)
        Me.Tp_Complementaria.Name = "Tp_Complementaria"
        Me.Tp_Complementaria.Size = New System.Drawing.Size(686, 405)
        Me.Tp_Complementaria.TabIndex = 2
        Me.Tp_Complementaria.Text = "Complementaria"
        Me.Tp_Complementaria.UseVisualStyleBackColor = True
        '
        'CUPOTextBox
        '
        Me.CUPOTextBox.Location = New System.Drawing.Point(412, 7)
        Me.CUPOTextBox.Mask = "9999999999999999"
        Me.CUPOTextBox.Name = "CUPOTextBox"
        Me.CUPOTextBox.Size = New System.Drawing.Size(110, 20)
        Me.CUPOTextBox.TabIndex = 1
        '
        'Nud_Descuento
        '
        Me.Nud_Descuento.Location = New System.Drawing.Point(596, 6)
        Me.Nud_Descuento.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.Nud_Descuento.Name = "Nud_Descuento"
        Me.Nud_Descuento.Size = New System.Drawing.Size(45, 20)
        Me.Nud_Descuento.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Dgv_Documentos)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(0, 170)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(677, 197)
        Me.Panel2.TabIndex = 143
        '
        'Dgv_Documentos
        '
        Me.Dgv_Documentos.AllowUserToAddRows = False
        Me.Dgv_Documentos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Documentos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Documentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Documentos.Location = New System.Drawing.Point(0, 20)
        Me.Dgv_Documentos.Name = "Dgv_Documentos"
        Me.Dgv_Documentos.Size = New System.Drawing.Size(675, 175)
        Me.Dgv_Documentos.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(675, 20)
        Me.Panel3.TabIndex = 0
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label31.Location = New System.Drawing.Point(0, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(675, 20)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "LISTA DE DOCUMENTOS ADJUNTADOS"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cb_CondiciónPago
        '
        Me.Cb_CondiciónPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_CondiciónPago.FormattingEnabled = True
        Me.Cb_CondiciónPago.Location = New System.Drawing.Point(126, 5)
        Me.Cb_CondiciónPago.Name = "Cb_CondiciónPago"
        Me.Cb_CondiciónPago.Size = New System.Drawing.Size(190, 21)
        Me.Cb_CondiciónPago.TabIndex = 0
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(48, 90)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 13)
        Me.Label21.TabIndex = 128
        Me.Label21.Text = "Titular Cuenta:"
        '
        'Cb_Banco
        '
        Me.Cb_Banco.DisplayMember = "NOMBREENTIDADFINANCIERA"
        Me.Cb_Banco.FormattingEnabled = True
        Me.Cb_Banco.Location = New System.Drawing.Point(126, 31)
        Me.Cb_Banco.Name = "Cb_Banco"
        Me.Cb_Banco.Size = New System.Drawing.Size(190, 21)
        Me.Cb_Banco.TabIndex = 3
        Me.Cb_Banco.ValueMember = "CODIGOENTIDADFINANCIERA"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(25, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 13)
        Me.Label17.TabIndex = 125
        Me.Label17.Text = "Banco a consignar:"
        '
        'TextBox_NumeroCuenta
        '
        Me.TextBox_NumeroCuenta.Location = New System.Drawing.Point(412, 59)
        Me.TextBox_NumeroCuenta.MaxLength = 20
        Me.TextBox_NumeroCuenta.Name = "TextBox_NumeroCuenta"
        Me.TextBox_NumeroCuenta.Size = New System.Drawing.Size(142, 20)
        Me.TextBox_NumeroCuenta.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(325, 63)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 13)
        Me.Label18.TabIndex = 126
        Me.Label18.Text = "Numero Cuenta:"
        '
        'Cb_TipoCuenta
        '
        Me.Cb_TipoCuenta.DisplayMember = "NOMBRETIPOCUENTA"
        Me.Cb_TipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_TipoCuenta.FormattingEnabled = True
        Me.Cb_TipoCuenta.Location = New System.Drawing.Point(126, 59)
        Me.Cb_TipoCuenta.Name = "Cb_TipoCuenta"
        Me.Cb_TipoCuenta.Size = New System.Drawing.Size(190, 21)
        Me.Cb_TipoCuenta.TabIndex = 5
        Me.Cb_TipoCuenta.ValueMember = "CODIGOTIPOCUENTA"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(56, 64)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 13)
        Me.Label25.TabIndex = 127
        Me.Label25.Text = "Tipo Cuenta:"
        '
        'Tp_Sucursales
        '
        Me.Tp_Sucursales.AutoScroll = True
        Me.Tp_Sucursales.Controls.Add(Me.Bt_Editar)
        Me.Tp_Sucursales.Controls.Add(Me.Panel4)
        Me.Tp_Sucursales.Controls.Add(Me.Bt_Adicionar)
        Me.Tp_Sucursales.Controls.Add(Me.Gb_RepresentanteVentaSucursal)
        Me.Tp_Sucursales.Controls.Add(Me.Tx_CorreoSucursal)
        Me.Tp_Sucursales.Controls.Add(Me.Label23)
        Me.Tp_Sucursales.Controls.Add(Me.Tx_TeléfonoMóvilSucursal)
        Me.Tp_Sucursales.Controls.Add(Me.Tx_TeléfonoSucursal)
        Me.Tp_Sucursales.Controls.Add(Me.Label24)
        Me.Tp_Sucursales.Controls.Add(Me.Label26)
        Me.Tp_Sucursales.Controls.Add(Me.Gb_DirecciónSucursal)
        Me.Tp_Sucursales.Location = New System.Drawing.Point(4, 22)
        Me.Tp_Sucursales.Name = "Tp_Sucursales"
        Me.Tp_Sucursales.Size = New System.Drawing.Size(686, 405)
        Me.Tp_Sucursales.TabIndex = 3
        Me.Tp_Sucursales.Text = "Sucursales"
        Me.Tp_Sucursales.UseVisualStyleBackColor = True
        '
        'Bt_Editar
        '
        Me.Bt_Editar.Location = New System.Drawing.Point(594, 182)
        Me.Bt_Editar.Name = "Bt_Editar"
        Me.Bt_Editar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Editar.TabIndex = 158
        Me.Bt_Editar.Text = "Editar"
        Me.Bt_Editar.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Dgv_Sucursal)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Location = New System.Drawing.Point(0, 207)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(677, 160)
        Me.Panel4.TabIndex = 157
        '
        'Dgv_Sucursal
        '
        Me.Dgv_Sucursal.AllowUserToAddRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Sucursal.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Sucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Sucursal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Sucursal.Location = New System.Drawing.Point(0, 20)
        Me.Dgv_Sucursal.Name = "Dgv_Sucursal"
        Me.Dgv_Sucursal.Size = New System.Drawing.Size(675, 138)
        Me.Dgv_Sucursal.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label32)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(675, 20)
        Me.Panel5.TabIndex = 0
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label32.Location = New System.Drawing.Point(0, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(675, 20)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "LISTA DE SUCURSALES"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bt_Adicionar
        '
        Me.Bt_Adicionar.Location = New System.Drawing.Point(513, 182)
        Me.Bt_Adicionar.Name = "Bt_Adicionar"
        Me.Bt_Adicionar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Adicionar.TabIndex = 156
        Me.Bt_Adicionar.Text = "Adicionar"
        Me.Bt_Adicionar.UseVisualStyleBackColor = True
        '
        'Gb_RepresentanteVentaSucursal
        '
        Me.Gb_RepresentanteVentaSucursal.Controls.Add(Me.Tx_CorreoRVSucursal)
        Me.Gb_RepresentanteVentaSucursal.Controls.Add(Me.Label27)
        Me.Gb_RepresentanteVentaSucursal.Controls.Add(Me.Tx_TeléfonoMóvilRVSucursal)
        Me.Gb_RepresentanteVentaSucursal.Controls.Add(Me.Tx_TeléfonoRVSucursal)
        Me.Gb_RepresentanteVentaSucursal.Controls.Add(Me.Label28)
        Me.Gb_RepresentanteVentaSucursal.Controls.Add(Me.Label29)
        Me.Gb_RepresentanteVentaSucursal.Controls.Add(Label30)
        Me.Gb_RepresentanteVentaSucursal.Controls.Add(Me.Tx_NombreRVSucursal)
        Me.Gb_RepresentanteVentaSucursal.Location = New System.Drawing.Point(8, 102)
        Me.Gb_RepresentanteVentaSucursal.Name = "Gb_RepresentanteVentaSucursal"
        Me.Gb_RepresentanteVentaSucursal.Size = New System.Drawing.Size(661, 77)
        Me.Gb_RepresentanteVentaSucursal.TabIndex = 4
        Me.Gb_RepresentanteVentaSucursal.TabStop = False
        Me.Gb_RepresentanteVentaSucursal.Text = "Representante Venta"
        '
        'Tx_CorreoRVSucursal
        '
        Me.Tx_CorreoRVSucursal.Location = New System.Drawing.Point(419, 47)
        Me.Tx_CorreoRVSucursal.MaxLength = 60
        Me.Tx_CorreoRVSucursal.Name = "Tx_CorreoRVSucursal"
        Me.Tx_CorreoRVSucursal.Size = New System.Drawing.Size(236, 20)
        Me.Tx_CorreoRVSucursal.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(316, 51)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(97, 13)
        Me.Label27.TabIndex = 154
        Me.Label27.Text = "Correo Electrónico:"
        '
        'Tx_TeléfonoMóvilRVSucursal
        '
        Me.Tx_TeléfonoMóvilRVSucursal.Location = New System.Drawing.Point(209, 47)
        Me.Tx_TeléfonoMóvilRVSucursal.MaxLength = 10
        Me.Tx_TeléfonoMóvilRVSucursal.Name = "Tx_TeléfonoMóvilRVSucursal"
        Me.Tx_TeléfonoMóvilRVSucursal.Size = New System.Drawing.Size(101, 20)
        Me.Tx_TeléfonoMóvilRVSucursal.TabIndex = 2
        '
        'Tx_TeléfonoRVSucursal
        '
        Me.Tx_TeléfonoRVSucursal.Location = New System.Drawing.Point(59, 47)
        Me.Tx_TeléfonoRVSucursal.MaxLength = 10
        Me.Tx_TeléfonoRVSucursal.Name = "Tx_TeléfonoRVSucursal"
        Me.Tx_TeléfonoRVSucursal.Size = New System.Drawing.Size(104, 20)
        Me.Tx_TeléfonoRVSucursal.TabIndex = 1
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(168, 51)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(35, 13)
        Me.Label28.TabIndex = 153
        Me.Label28.Text = "Móvil:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 51)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(52, 13)
        Me.Label29.TabIndex = 152
        Me.Label29.Text = "Teléfono:"
        '
        'Tx_NombreRVSucursal
        '
        Me.Tx_NombreRVSucursal.Location = New System.Drawing.Point(59, 20)
        Me.Tx_NombreRVSucursal.Name = "Tx_NombreRVSucursal"
        Me.Tx_NombreRVSucursal.Size = New System.Drawing.Size(296, 20)
        Me.Tx_NombreRVSucursal.TabIndex = 0
        '
        'Tx_CorreoSucursal
        '
        Me.Tx_CorreoSucursal.Location = New System.Drawing.Point(466, 74)
        Me.Tx_CorreoSucursal.MaxLength = 60
        Me.Tx_CorreoSucursal.Name = "Tx_CorreoSucursal"
        Me.Tx_CorreoSucursal.Size = New System.Drawing.Size(197, 20)
        Me.Tx_CorreoSucursal.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(363, 77)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(97, 13)
        Me.Label23.TabIndex = 154
        Me.Label23.Text = "Correo Electrónico:"
        '
        'Tx_TeléfonoMóvilSucursal
        '
        Me.Tx_TeléfonoMóvilSucursal.Location = New System.Drawing.Point(466, 49)
        Me.Tx_TeléfonoMóvilSucursal.MaxLength = 10
        Me.Tx_TeléfonoMóvilSucursal.Name = "Tx_TeléfonoMóvilSucursal"
        Me.Tx_TeléfonoMóvilSucursal.Size = New System.Drawing.Size(197, 20)
        Me.Tx_TeléfonoMóvilSucursal.TabIndex = 2
        '
        'Tx_TeléfonoSucursal
        '
        Me.Tx_TeléfonoSucursal.Location = New System.Drawing.Point(466, 24)
        Me.Tx_TeléfonoSucursal.MaxLength = 10
        Me.Tx_TeléfonoSucursal.Name = "Tx_TeléfonoSucursal"
        Me.Tx_TeléfonoSucursal.Size = New System.Drawing.Size(197, 20)
        Me.Tx_TeléfonoSucursal.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(424, 52)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(35, 13)
        Me.Label24.TabIndex = 153
        Me.Label24.Text = "Móvil:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(408, 27)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(52, 13)
        Me.Label26.TabIndex = 152
        Me.Label26.Text = "Teléfono:"
        '
        'Gb_DirecciónSucursal
        '
        Me.Gb_DirecciónSucursal.Controls.Add(Me.Cu_CiudadSucursal)
        Me.Gb_DirecciónSucursal.Controls.Add(Me.Tx_DirecciónSucursal)
        Me.Gb_DirecciónSucursal.Controls.Add(Me.Label22)
        Me.Gb_DirecciónSucursal.Location = New System.Drawing.Point(8, 7)
        Me.Gb_DirecciónSucursal.Name = "Gb_DirecciónSucursal"
        Me.Gb_DirecciónSucursal.Size = New System.Drawing.Size(349, 90)
        Me.Gb_DirecciónSucursal.TabIndex = 0
        Me.Gb_DirecciónSucursal.TabStop = False
        Me.Gb_DirecciónSucursal.Text = "Dirección Residencia"
        '
        'Cu_CiudadSucursal
        '
        Me.Cu_CiudadSucursal.Location = New System.Drawing.Point(45, 64)
        Me.Cu_CiudadSucursal.Name = "Cu_CiudadSucursal"
        Me.Cu_CiudadSucursal.Size = New System.Drawing.Size(297, 23)
        Me.Cu_CiudadSucursal.TabIndex = 1
        '
        'Tx_DirecciónSucursal
        '
        Me.Tx_DirecciónSucursal.Location = New System.Drawing.Point(7, 19)
        Me.Tx_DirecciónSucursal.MaxLength = 100
        Me.Tx_DirecciónSucursal.Multiline = True
        Me.Tx_DirecciónSucursal.Name = "Tx_DirecciónSucursal"
        Me.Tx_DirecciónSucursal.Size = New System.Drawing.Size(335, 43)
        Me.Tx_DirecciónSucursal.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(4, 69)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(43, 13)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "Ciudad:"
        '
        'Tp_Suministro
        '
        Me.Tp_Suministro.Controls.Add(Me.Panel6)
        Me.Tp_Suministro.Location = New System.Drawing.Point(4, 22)
        Me.Tp_Suministro.Name = "Tp_Suministro"
        Me.Tp_Suministro.Size = New System.Drawing.Size(686, 405)
        Me.Tp_Suministro.TabIndex = 4
        Me.Tp_Suministro.Text = "Suministro"
        Me.Tp_Suministro.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(686, 405)
        Me.Panel6.TabIndex = 158
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Dgv_Suministros)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 20)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(684, 349)
        Me.Panel9.TabIndex = 3
        '
        'Dgv_Suministros
        '
        Me.Dgv_Suministros.AllowUserToAddRows = False
        Me.Dgv_Suministros.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_Suministros.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv_Suministros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_Suministros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Suministros.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Suministros.Name = "Dgv_Suministros"
        Me.Dgv_Suministros.Size = New System.Drawing.Size(684, 349)
        Me.Dgv_Suministros.TabIndex = 1
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkGray
        Me.Panel8.Controls.Add(Me.Label36)
        Me.Panel8.Controls.Add(Me.Tb_Otros)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 369)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(684, 34)
        Me.Panel8.TabIndex = 2
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(7, 10)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(76, 13)
        Me.Label36.TabIndex = 1
        Me.Label36.Text = "Digite otros:"
        '
        'Tb_Otros
        '
        Me.Tb_Otros.Location = New System.Drawing.Point(89, 7)
        Me.Tb_Otros.MaxLength = 100
        Me.Tb_Otros.Name = "Tb_Otros"
        Me.Tb_Otros.Size = New System.Drawing.Size(587, 20)
        Me.Tb_Otros.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label34)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(684, 20)
        Me.Panel7.TabIndex = 0
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label34.Location = New System.Drawing.Point(0, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(684, 20)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "INFORMACIÓN SOBRE SUMINISTRO"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tp_CalificaciónOperativa
        '
        Me.Tp_CalificaciónOperativa.Controls.Add(Me.Panel10)
        Me.Tp_CalificaciónOperativa.Location = New System.Drawing.Point(4, 22)
        Me.Tp_CalificaciónOperativa.Name = "Tp_CalificaciónOperativa"
        Me.Tp_CalificaciónOperativa.Size = New System.Drawing.Size(686, 405)
        Me.Tp_CalificaciónOperativa.TabIndex = 5
        Me.Tp_CalificaciónOperativa.Text = "Calificación Operativa"
        Me.Tp_CalificaciónOperativa.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.Panel11)
        Me.Panel10.Controls.Add(Me.Panel13)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(686, 405)
        Me.Panel10.TabIndex = 159
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.Dgv_CalificaciónOperativa)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(0, 20)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(684, 383)
        Me.Panel11.TabIndex = 3
        '
        'Dgv_CalificaciónOperativa
        '
        Me.Dgv_CalificaciónOperativa.AllowUserToAddRows = False
        Me.Dgv_CalificaciónOperativa.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Dgv_CalificaciónOperativa.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv_CalificaciónOperativa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv_CalificaciónOperativa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_CalificaciónOperativa.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_CalificaciónOperativa.Name = "Dgv_CalificaciónOperativa"
        Me.Dgv_CalificaciónOperativa.Size = New System.Drawing.Size(684, 383)
        Me.Dgv_CalificaciónOperativa.TabIndex = 1
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.Label39)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(684, 20)
        Me.Panel13.TabIndex = 0
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label39.Location = New System.Drawing.Point(0, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(684, 20)
        Me.Label39.TabIndex = 0
        Me.Label39.Text = "CALIFICACIÓN OPERATIVA"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Ck_DespachaEntrega
        '
        Me.Ck_DespachaEntrega.Location = New System.Drawing.Point(0, 0)
        Me.Ck_DespachaEntrega.Name = "Ck_DespachaEntrega"
        Me.Ck_DespachaEntrega.Size = New System.Drawing.Size(104, 24)
        Me.Ck_DespachaEntrega.TabIndex = 0
        '
        'Fr_Proveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(694, 461)
        Me.Controls.Add(Me.Tc_Proveedor)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Fr_Proveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proveedor"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox_DirecciónResidencia.ResumeLayout(False)
        Me.GroupBox_DirecciónResidencia.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Tc_Proveedor.ResumeLayout(False)
        Me.Tp_Básica.ResumeLayout(False)
        Me.Tp_Básica.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Tp_Contable.ResumeLayout(False)
        Me.Tp_Contable.PerformLayout()
        Me.Gb_ActividadIndustrial.ResumeLayout(False)
        Me.Gb_ActividadIndustrial.PerformLayout()
        Me.Gb_Autoretenedor.ResumeLayout(False)
        Me.Gb_Autoretenedor.PerformLayout()
        Me.Gb_AgenteReteneedor.ResumeLayout(False)
        Me.Gb_AgenteReteneedor.PerformLayout()
        Me.Gb_GranContribuyente.ResumeLayout(False)
        Me.Gb_GranContribuyente.PerformLayout()
        Me.Tp_Complementaria.ResumeLayout(False)
        Me.Tp_Complementaria.PerformLayout()
        CType(Me.Nud_Descuento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.Dgv_Documentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Tp_Sucursales.ResumeLayout(False)
        Me.Tp_Sucursales.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.Dgv_Sucursal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Gb_RepresentanteVentaSucursal.ResumeLayout(False)
        Me.Gb_RepresentanteVentaSucursal.PerformLayout()
        Me.Gb_DirecciónSucursal.ResumeLayout(False)
        Me.Gb_DirecciónSucursal.PerformLayout()
        Me.Tp_Suministro.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        CType(Me.Dgv_Suministros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Tp_CalificaciónOperativa.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        CType(Me.Dgv_CalificaciónOperativa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel13.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lb_CódigoArtículo As System.Windows.Forms.Label
    Friend WithEvents Bt_Guardar As System.Windows.Forms.Button
    Friend WithEvents Bt_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Tx_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Tx_DigitoVerificación As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_NombreRL As System.Windows.Forms.TextBox
    Friend WithEvents SUCURSALENTIDADFINANCIERATextBox As System.Windows.Forms.TextBox
    Friend WithEvents TITURALCUENTATextBox As System.Windows.Forms.TextBox
    Friend WithEvents IDENTIFICACIONTITULARCUENTATextBox As System.Windows.Forms.TextBox
    Friend WithEvents CONTACTOCARTERAENTIDADFINANCIERATextBox As System.Windows.Forms.TextBox
    Friend WithEvents OBSERVACIONFINANCIERATextBox As System.Windows.Forms.TextBox
    Friend WithEvents Cb_TipoIdentificación As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox_DirecciónResidencia As System.Windows.Forms.GroupBox
    Friend WithEvents Cu_CiudadDirección As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Tx_Dirección As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Tx_Identificación As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Tx_SegundoApellido As System.Windows.Forms.TextBox
    Friend WithEvents Tx_PrimerApellido As System.Windows.Forms.TextBox
    Friend WithEvents Tx_SegundoNombre As System.Windows.Forms.TextBox
    Friend WithEvents Tx_PrimerNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tx_CorreoElectrónico As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Tx_TeléfonoMóvil As System.Windows.Forms.TextBox
    Friend WithEvents Tx_Teléfono As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Fax As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox_CorreoElectrónicoRL As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox_TeléfonoMóvilRL As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_TeléfonoRL As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Tc_Proveedor As System.Windows.Forms.TabControl
    Friend WithEvents Tp_Básica As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox_CorreoElectrónicoV As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox_TeléfonoMóvilV As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_TeléfonoV As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox_NombreVenta As System.Windows.Forms.TextBox
    Friend WithEvents Tp_Contable As System.Windows.Forms.TabPage
    Friend WithEvents NRORESOLUCIONAGENTETextBox As System.Windows.Forms.TextBox
    Friend WithEvents FECHARESOLUCIONAGENTEDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents NRORESOLUCIONAUTORETENEDORTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FECHARESOLUCIONAUTORETENEDORDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents TARIFAICATextBox As System.Windows.Forms.TextBox
    Friend WithEvents Tp_Complementaria As System.Windows.Forms.TabPage
    Friend WithEvents Tp_Sucursales As System.Windows.Forms.TabPage
    Friend WithEvents Cu_CiudadFabril As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Gb_Autoretenedor As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_AutoretenedorNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_AutoretenedorSI As System.Windows.Forms.RadioButton
    Friend WithEvents Gb_AgenteReteneedor As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_AgenteReteneedorNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_AgenteReteneedorSI As System.Windows.Forms.RadioButton
    Friend WithEvents Gb_GranContribuyente As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_GranContribuyenteNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_GranContribuyenteSI As System.Windows.Forms.RadioButton
    Friend WithEvents Cb_ResponsabilidadIVA As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_RegimenImpuesto As System.Windows.Forms.ComboBox
    Friend WithEvents Cb_CondiciónPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Cb_Banco As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox_NumeroCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Cb_TipoCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Gb_RepresentanteVentaSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents Tx_CorreoRVSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Tx_TeléfonoMóvilRVSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Tx_TeléfonoRVSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Tx_NombreRVSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Tx_CorreoSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Tx_TeléfonoMóvilSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Tx_TeléfonoSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Gb_DirecciónSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents Cu_CiudadSucursal As FormulariosClasesBase.Cu_Ciudad
    Friend WithEvents Tx_DirecciónSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Bt_Adicionar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Dgv_Documentos As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Sucursal As System.Windows.Forms.DataGridView
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Gb_ActividadIndustrial As System.Windows.Forms.GroupBox
    Friend WithEvents Rb_ActividadIndustrialNo As System.Windows.Forms.RadioButton
    Friend WithEvents Rb_ActividadIndustrialSi As System.Windows.Forms.RadioButton
    Friend WithEvents Tp_Suministro As System.Windows.Forms.TabPage
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Suministros As System.Windows.Forms.DataGridView
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Cb_ActividadPrincipal As System.Windows.Forms.ComboBox
    Friend WithEvents Nud_Descuento As System.Windows.Forms.NumericUpDown
    Friend WithEvents CUPOTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Bt_Editar As System.Windows.Forms.Button
    Friend WithEvents Tx_CódigoActividad As System.Windows.Forms.TextBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Tb_Otros As System.Windows.Forms.TextBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Tx_Nomenclatura As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Cb_Activo As Windows.Forms.CheckBox
    Friend WithEvents Ck_DespachaEntrega As System.Windows.Forms.CheckBox
    Friend WithEvents Tp_CalificaciónOperativa As System.Windows.Forms.TabPage
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_CalificaciónOperativa As System.Windows.Forms.DataGridView
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label39 As System.Windows.Forms.Label
End Class
