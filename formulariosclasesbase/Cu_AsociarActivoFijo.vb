Public Class Cu_AsociarActivoFijo

    Public IdEquipo As Integer = -1
    Public CaracteristicasEquipo As ArrayList
    Public Tipo As String


    Private Sub Ll_CentroCostos_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Ll_ActivoFijo.LinkClicked
        Dim FrBuscarEquipo As New Fr_BuscarEquipo
        FrBuscarEquipo.Tipo = Tipo
        FrBuscarEquipo.CargarListaEquipoBase()
        FrBuscarEquipo.ShowDialog()

        FrBuscarEquipo.Lb_horakilometro.Enabled = False
        FrBuscarEquipo.Tb_HoraKilometro.Enabled = False

        If FrBuscarEquipo.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.Ll_ActivoFijo.Text = FrBuscarEquipo.NombreEquipo
            Me.IdEquipo = FrBuscarEquipo.IdEquipo
            Me.LL_odometro.Text = FrBuscarEquipo.ContadorHoraKilometro
        End If
    End Sub


    Public datas As New DataSet
    Public cmde As New SqlClient.SqlCommand
    Public da As New SqlClient.SqlDataAdapter

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        MostrarCaracteristicas(Me.IdEquipo)
    End Sub

    Public Sub MostrarCaracteristicas(ByVal IdEquipo As Integer)
        'declaro la cadena de conexion
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            sqlconeccion.Open()
            cmde.Parameters.Clear()
            cmde.CommandType = CommandType.StoredProcedure
            cmde.Connection = sqlconeccion
            cmde.CommandText = "dbo.GestionarEquipos"
            cmde.Parameters.Add("@accion", SqlDbType.Int).Value = 37
            cmde.Parameters.Add("@idproveedor", SqlDbType.Int).Value = -1
            cmde.Parameters.Add("@idarticulo", SqlDbType.Int).Value = -1
            cmde.Parameters.Add("@idequipo", SqlDbType.Int).Value = IdEquipo
            cmde.Parameters.Add("@idtipo", SqlDbType.Int).Value = 1
            cmde.Parameters.Add("@idsubtipo", SqlDbType.Int).Value = 1
            cmde.Parameters.Add("@idestado", SqlDbType.Int).Value = 1
            cmde.Parameters.Add("@idequipopadre", SqlDbType.Int).Value = 1
            cmde.Parameters.Add("@idbodegaingreso", SqlDbType.Int).Value = 1
            cmde.Parameters.Add("@idpersonaingreso", SqlDbType.Int).Value = 1
            cmde.Parameters.Add("@idpersonaregistro", SqlDbType.Int).Value = 1
            cmde.Parameters.Add("@idpersonaactual", SqlDbType.Int).Value = 1
            cmde.Parameters.Add("@idmodelo", SqlDbType.Int).Value = 1
            cmde.Parameters.Add("@idmarca", SqlDbType.Int).Value = 1
            cmde.Parameters.Add("@idbodega", SqlDbType.Int).Value = 1
            cmde.Parameters.Add("@descripcionequipo", SqlDbType.Text).Value = ""
            cmde.Parameters.Add("@codigoismocol", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@codigoaccess", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@codigomecanico", SqlDbType.VarChar, 50).Value = ""
            cmde.Parameters.Add("@activo", SqlDbType.Bit).Value = 0
            cmde.Parameters.Add("@fechaingreso", SqlDbType.Date).Value = Date.Now

            da = New SqlClient.SqlDataAdapter(cmde)
            datas = New DataSet()
            da.Fill(datas)
            sqlconeccion.Close()

            If datas.Tables(0).Rows.Count > 0 Then
                Dim Fr_ProyCara As New PropiedadesCaracteristicas
                Fr_ProyCara.Dg_Detalle.DataSource = datas.Tables(0)
                Fr_ProyCara.ShowDialog()
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            sqlconeccion.Dispose()
            cmde.Dispose()
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.IdEquipo = -1
        Me.Ll_ActivoFijo.Text = "SIN ASOCIAR"
        Me.LL_odometro.Text = ""
    End Sub

    Public Sub CargarOdometroHorometro()
        Dim sqlconeccion As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        sqlconeccion.Open()
        Dim cmd As New SqlClient.SqlCommand(
            " select top 1 REGISTROODOMETROHOROMETRO, * from SALIDAALMACEN where IdEquipo =" + IdEquipo.ToString + " order by IDSALIDAALMACEN desc", sqlconeccion)
        Me.LL_odometro.Text = Trim(cmd.ExecuteScalar())
        sqlconeccion.Close()
    End Sub
  
End Class


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropiedadesCaracteristicas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Bt_Cerrar = New System.Windows.Forms.Button()
        Me.Dg_Detalle = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.Dg_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Bt_Cerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 324)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(781, 32)
        Me.Panel1.TabIndex = 0
        '
        'Bt_Cerrar
        '
        Me.Bt_Cerrar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Cerrar.Location = New System.Drawing.Point(698, 5)
        Me.Bt_Cerrar.Name = "Bt_Cerrar"
        Me.Bt_Cerrar.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Cerrar.TabIndex = 0
        Me.Bt_Cerrar.Text = "Cerrar"
        Me.Bt_Cerrar.UseVisualStyleBackColor = True
        '
        'Dg_Detalle
        '
        Me.Dg_Detalle.AllowUserToAddRows = False
        Me.Dg_Detalle.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.Dg_Detalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dg_Detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.Dg_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dg_Detalle.DefaultCellStyle = DataGridViewCellStyle2
        Me.Dg_Detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dg_Detalle.Location = New System.Drawing.Point(0, 0)
        Me.Dg_Detalle.Name = "Dg_Detalle"
        Me.Dg_Detalle.Size = New System.Drawing.Size(781, 324)
        Me.Dg_Detalle.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 400)
        Me.Controls.Add(Me.Dg_Detalle)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "PROPIEDADES Y CARACTERISTICAS"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Dg_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bt_Cerrar As System.Windows.Forms.Button
    Friend WithEvents Dg_Detalle As System.Windows.Forms.DataGridView


    Private Sub Bt_Cerrar_Click(sender As Object, e As EventArgs) Handles Bt_Cerrar.Click
        Me.Close()
    End Sub


End Class
