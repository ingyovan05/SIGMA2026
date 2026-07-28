<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fr_Buscar_Ciudad
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.ComboBox_Municipio = New System.Windows.Forms.ComboBox()
        Me.MAPOBLACIONMAESTRAMUNICIPIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ds_FrBuscarCiudad = New DatosClasesBaseBuscar.Ds_FrBuscarCiudad()
        Me.ComboBox_Departamento = New System.Windows.Forms.ComboBox()
        Me.MAPOBLACIONMAESTRADEPARTAMENTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBox_Pais = New System.Windows.Forms.ComboBox()
        Me.MAPOBLACIONMAESTRAPAISBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.MA_POBLACIONMAESTRAPAISTableAdapter = New DatosClasesBaseBuscar.Ds_FrBuscarCiudadTableAdapters.MA_POBLACIONMAESTRAPAISTableAdapter()
        Me.MA_POBLACIONMAESTRADEPARTAMENTOTableAdapter = New DatosClasesBaseBuscar.Ds_FrBuscarCiudadTableAdapters.MA_POBLACIONMAESTRADEPARTAMENTOTableAdapter()
        Me.MA_POBLACIONMAESTRAMUNICIPIOTableAdapter = New DatosClasesBaseBuscar.Ds_FrBuscarCiudadTableAdapters.MA_POBLACIONMAESTRAMUNICIPIOTableAdapter()
        Me.MA_POBLACIONTableAdapter1 = New Dscomunes.Ds_MaestrosTableAdapters.MA_POBLACIONTableAdapter()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.MAPOBLACIONMAESTRAMUNICIPIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ds_FrBuscarCiudad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAPOBLACIONMAESTRADEPARTAMENTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAPOBLACIONMAESTRAPAISBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(232, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'ComboBox_Municipio
        '
        Me.ComboBox_Municipio.DataSource = Me.MAPOBLACIONMAESTRAMUNICIPIOBindingSource
        Me.ComboBox_Municipio.DisplayMember = "NOMBREMUNICIPIO"
        Me.ComboBox_Municipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Municipio.Enabled = False
        Me.ComboBox_Municipio.FormattingEnabled = True
        Me.ComboBox_Municipio.Location = New System.Drawing.Point(99, 54)
        Me.ComboBox_Municipio.Name = "ComboBox_Municipio"
        Me.ComboBox_Municipio.Size = New System.Drawing.Size(277, 21)
        Me.ComboBox_Municipio.TabIndex = 5
        Me.ComboBox_Municipio.ValueMember = "CODIGOMUNICIPIO"
        '
        'MAPOBLACIONMAESTRAMUNICIPIOBindingSource
        '
        Me.MAPOBLACIONMAESTRAMUNICIPIOBindingSource.DataMember = "MA_POBLACIONMAESTRAMUNICIPIO"
        Me.MAPOBLACIONMAESTRAMUNICIPIOBindingSource.DataSource = Me.Ds_FrBuscarCiudad
        '
        'Ds_FrBuscarCiudad
        '
        Me.Ds_FrBuscarCiudad.DataSetName = "Ds_FrBuscarCiudad"
        Me.Ds_FrBuscarCiudad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ComboBox_Departamento
        '
        Me.ComboBox_Departamento.DataSource = Me.MAPOBLACIONMAESTRADEPARTAMENTOBindingSource
        Me.ComboBox_Departamento.DisplayMember = "NOMBREDEPARTAMENTO"
        Me.ComboBox_Departamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Departamento.Enabled = False
        Me.ComboBox_Departamento.FormattingEnabled = True
        Me.ComboBox_Departamento.Location = New System.Drawing.Point(99, 29)
        Me.ComboBox_Departamento.Name = "ComboBox_Departamento"
        Me.ComboBox_Departamento.Size = New System.Drawing.Size(277, 21)
        Me.ComboBox_Departamento.TabIndex = 3
        Me.ComboBox_Departamento.ValueMember = "CODIGODEPARTAMENTO"
        '
        'MAPOBLACIONMAESTRADEPARTAMENTOBindingSource
        '
        Me.MAPOBLACIONMAESTRADEPARTAMENTOBindingSource.DataMember = "MA_POBLACIONMAESTRADEPARTAMENTO"
        Me.MAPOBLACIONMAESTRADEPARTAMENTOBindingSource.DataSource = Me.Ds_FrBuscarCiudad
        '
        'ComboBox_Pais
        '
        Me.ComboBox_Pais.DataSource = Me.MAPOBLACIONMAESTRAPAISBindingSource
        Me.ComboBox_Pais.DisplayMember = "NOMBREPAIS"
        Me.ComboBox_Pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Pais.FormattingEnabled = True
        Me.ComboBox_Pais.Location = New System.Drawing.Point(99, 4)
        Me.ComboBox_Pais.Name = "ComboBox_Pais"
        Me.ComboBox_Pais.Size = New System.Drawing.Size(277, 21)
        Me.ComboBox_Pais.TabIndex = 1
        Me.ComboBox_Pais.ValueMember = "CODIGOPAIS"
        '
        'MAPOBLACIONMAESTRAPAISBindingSource
        '
        Me.MAPOBLACIONMAESTRAPAISBindingSource.DataMember = "MA_POBLACIONMAESTRAPAIS"
        Me.MAPOBLACIONMAESTRAPAISBindingSource.DataSource = Me.Ds_FrBuscarCiudad
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Municipio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Departamento:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Pais:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel3.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 81)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(381, 33)
        Me.Panel3.TabIndex = 6
        '
        'MA_POBLACIONMAESTRAPAISTableAdapter
        '
        Me.MA_POBLACIONMAESTRAPAISTableAdapter.ClearBeforeFill = True
        '
        'MA_POBLACIONMAESTRADEPARTAMENTOTableAdapter
        '
        Me.MA_POBLACIONMAESTRADEPARTAMENTOTableAdapter.ClearBeforeFill = True
        '
        'MA_POBLACIONMAESTRAMUNICIPIOTableAdapter
        '
        Me.MA_POBLACIONMAESTRAMUNICIPIOTableAdapter.ClearBeforeFill = True
        '
        'MA_POBLACIONTableAdapter1
        '
        Me.MA_POBLACIONTableAdapter1.ClearBeforeFill = True
        '
        'Fr_Buscar_Ciudad
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(381, 114)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ComboBox_Municipio)
        Me.Controls.Add(Me.ComboBox_Departamento)
        Me.Controls.Add(Me.ComboBox_Pais)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fr_Buscar_Ciudad"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Ciudad"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.MAPOBLACIONMAESTRAMUNICIPIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ds_FrBuscarCiudad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MAPOBLACIONMAESTRADEPARTAMENTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MAPOBLACIONMAESTRAPAISBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ComboBox_Departamento As System.Windows.Forms.ComboBox
  Friend WithEvents ComboBox_Pais As System.Windows.Forms.ComboBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Ds_FrBuscarCiudad As DatosClasesBaseBuscar.Ds_FrBuscarCiudad
    Friend WithEvents MAPOBLACIONMAESTRAPAISBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MA_POBLACIONMAESTRAPAISTableAdapter As DatosClasesBaseBuscar.Ds_FrBuscarCiudadTableAdapters.MA_POBLACIONMAESTRAPAISTableAdapter
    Friend WithEvents MAPOBLACIONMAESTRAMUNICIPIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MAPOBLACIONMAESTRADEPARTAMENTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MA_POBLACIONMAESTRADEPARTAMENTOTableAdapter As DatosClasesBaseBuscar.Ds_FrBuscarCiudadTableAdapters.MA_POBLACIONMAESTRADEPARTAMENTOTableAdapter
    Friend WithEvents MA_POBLACIONMAESTRAMUNICIPIOTableAdapter As DatosClasesBaseBuscar.Ds_FrBuscarCiudadTableAdapters.MA_POBLACIONMAESTRAMUNICIPIOTableAdapter
    Friend WithEvents MA_POBLACIONTableAdapter1 As Dscomunes.Ds_MaestrosTableAdapters.MA_POBLACIONTableAdapter
    Public WithEvents ComboBox_Municipio As System.Windows.Forms.ComboBox





End Class
