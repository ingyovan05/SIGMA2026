Imports System.Data.SqlClient
Imports System.ComponentModel
'Imports System.Data.OleDb
Imports System.IO
Imports FormularioLicitaciones
Imports FormularioLicitaciones.FormulariosLicitaciones
Imports Microsoft.Office.Interop

''' <summary>
''' Componente del Módulo Licitaciones.
''' </summary>
Public Class Cu_Licitaciones

    ''' <summary>
    ''' Contiene los datos de resultados de las búsquedas en el módulo.
    '''</summary>
    Private dsLicitacionesFiltro As New DataSet

    ''' <summary>
    ''' Indica qué listado se encuentra cargado actualmente para habilitar las acciones pertinentes y bloquear las no pertinentes.
    ''' </summary>
    Private tablaCargada As TablaLicitaciones

    ''' <summary>
    ''' Define los listados disponibles en el módulo. Corresponde a las entidades del sistema que maneja el módulo.
    ''' </summary>
    Enum TablaLicitaciones
        Licitacion
        APU
        Material
        Equipo
        ManoDeObra
    End Enum


    ''' <summary>
    ''' Carga inicial del módulo.
    ''' </summary>
    Public Sub Comportamiento_Predeterminado()
        Nbc_Licitaciones.ActiveGroup = Nbg_Licitaciones

        Dgv_Lista.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Lista.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Dgv_Materiales.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Materiales.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Dgv_ManodeObra.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_ManodeObra.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Dgv_Equipos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Equipos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        'Permisos Licitaciones
        Nbg_Licitaciones.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Licitaciones.Tag)
        Nbi_CargarListaLicitaciones.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarListaLicitaciones.Tag)
        Nbi_CrearLicitacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearLicitacion.Tag)
        Nbi_EditarLicitacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarLicitacion.Tag)
        Nbi_ClonarLicitacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarLicitacion.Tag)
        Nbi_BuscarLicitaciones.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarLicitaciones.Tag)
        Nbi_SeleccionarLicitacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_SeleccionarLicitacion.Tag)
        Nbi_PermisosLicitacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_PermisosLicitacion.Tag)
        Nbi_ImprimirLicitacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirLicitacion.Tag)
        Nbi_EliminarLicitacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EliminarLicitacion.Tag)
        Nbi_VerMaterialesLicitacion.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerMaterialesLicitacion.Tag)
        Nbi_VerMaquinariaYEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerMaquinariaYEquipo.Tag)
        Nbi_VerManoDeObra.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerManoDeObra.Tag)
        Lic_SeleccionarLicToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Lic_SeleccionarLicToolStripMenuItem.Tag)
        Lic_EditarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Lic_EditarToolStripMenuItem.Tag)
        Lic_ClonarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Lic_ClonarToolStripMenuItem.Tag)
        Lic_ImprimirToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Lic_ImprimirToolStripMenuItem.Tag)
        Lic_EliminarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Lic_EliminarToolStripMenuItem.Tag)

        'Permisos APU Ítems
        Nbg_APUItems.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_APUItems.Tag)
        Nbi_CargarItems.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarItems.Tag)
        Nbi_CrearItems.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearItems.Tag)
        Nbi_EditarItems.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarItems.Tag)
        Nbi_ClonarItems.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarItems.Tag)
        Nbi_ImportarItems.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImportarItems.Tag)
        Nbi_ExportarItems.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ExportarItems.Tag)
        Nbi_BuscarItems.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarItems.Tag)
        Nbi_ImprimirItems.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirItems.Tag)
        Nbi_EliminarItems.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EliminarItems.Tag)
        Apu_EditarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Apu_EditarToolStripMenuItem.Tag)
        Apu_ClonarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Apu_ClonarToolStripMenuItem.Tag)
        Apu_EliminarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Apu_EliminarToolStripMenuItem.Tag)

        'Permisos Materiales
        Nbg_Materiales.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Materiales.Tag)
        Nbi_CargarMateriales.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarMateriales.Tag)
        Nbi_CrearMaterial.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearMaterial.Tag)
        Nbi_EditarMaterial.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarMaterial.Tag)
        Nbi_ClonarMaterial.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarMaterial.Tag)
        Nbi_BuscarMaterial.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarMaterial.Tag)
        Nbi_EliminarMaterial.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EliminarMaterial.Tag)
        Ma_EditarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Ma_EditarToolStripMenuItem.Tag)
        Ma_ClonarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Ma_ClonarToolStripMenuItem.Tag)
        Ma_EliminarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Ma_EliminarToolStripMenuItem.Tag)

        'Permisos Maquinaria y Equipos
        Nbg_Equipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Equipo.Tag)
        Nbi_CargarEquipos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarEquipos.Tag)
        Nbi_CrearEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearEquipo.Tag)
        Nbi_EditarEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarEquipo.Tag)
        Nbi_ClonarEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarEquipo.Tag)
        Nbi_BuscarEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarEquipo.Tag)
        Nbi_EliminarEquipo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EliminarEquipo.Tag)
        ME_EditarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(ME_EditarToolStripMenuItem.Tag)
        ME_ClonarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(ME_ClonarToolStripMenuItem.Tag)
        ME_EliminarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(ME_EliminarToolStripMenuItem.Tag)

        'Permisos Mano de Obra
        Nbg_ManoDeObra.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_ManoDeObra.Tag)
        Nbi_CargarManoDeObra.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CargarManoDeObra.Tag)
        Nbi_CrearManoDeObra.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_CrearManoDeObra.Tag)
        Nbi_EditarManoDeObra.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarManoDeObra.Tag)
        Nbi_ClonarManoDeObra.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ClonarManoDeObra.Tag)
        Nbi_BuscarManoDeObra.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarManoDeObra.Tag)
        Nbi_EliminarManoDeObra.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EliminarManoDeObra.Tag)
        MO_EditarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(MO_EditarToolStripMenuItem.Tag)
        MO_ClonarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(MO_ClonarToolStripMenuItem.Tag)
        MO_EliminarToolStripMenuItem.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(MO_EliminarToolStripMenuItem.Tag)

        'Permisos Herramientas
        Nbg_Herramientas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Herramientas.Tag)
        Nbi_Soldadura.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Soldadura.Tag)
        Nbi_DiscosyGratas.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_DiscosyGratas.Tag)
        Nbi_Revestimiento.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_Revestimiento.Tag)
        Nbi_OxígenoAcetileno.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_OxígenoAcetileno.Tag)
        Nbi_AgregarTipoUnidad.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_AgregarTipoUnidad.Tag)

        'Dimensiones de los páneles de Recursos
        Sc_EquipoManoObra.Height = CInt(Pn_ContenedorPrincipal.Height / 1.5)
        Sc_EquipoManoObra.SplitterDistance = CInt(Pn_ContenedorPrincipal.Width / 1.5)
    End Sub


    ''' <summary>
    ''' Carga del listado inicial al ingresar al módulo.
    ''' </summary>
    Public Sub Cargar_Tabla()
        ListarLicitaciones(3)
    End Sub


    'Definición de los atajos de teclado que se pueden utilizar cuando el componente del módulo está en primer plano.
    Private Sub AtajoTeclado_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
        Handles Me.KeyDown, Pn_ContenedorPrincipal.KeyDown, Dgv_Lista.KeyDown, Nbc_Licitaciones.KeyDown, Dgv_Materiales.KeyDown, Dgv_Equipos.KeyDown, Dgv_ManodeObra.KeyDown, Pg_DetalleLista.KeyDown

        If (e.Control And e.KeyCode.ToString = "B") OrElse (e.KeyCode.ToString = "F3") Then 'Buscar
            Select Case Nbc_Licitaciones.ActiveGroup.Name
                Case Nbg_Licitaciones.Name
                    BuscarLicitacion()
                Case Nbg_APUItems.Name
                    BuscarAPU()
                Case Nbg_Materiales.Name
                    BuscarMaterial()
                Case Nbg_Equipo.Name
                    BuscarEquipo()
                Case Nbg_ManoDeObra.Name
                    BuscarManoDeObra()
            End Select
        ElseIf (e.Control And e.KeyCode.ToString = "D") OrElse (e.Shift And e.KeyCode.ToString = "Delete") Then 'Eliminar
            If Dgv_Lista.SelectedRows.Count > 0 Then
                Select Case Nbc_Licitaciones.ActiveGroup.Name
                    Case Nbg_Licitaciones.Name
                        'Modificar el método para verificar permisos
                        'EliminarLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
                    Case Nbg_APUItems.Name
                        'Modificar el método para verificar permisos
                        'EliminarAPU(Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
                    Case Nbg_Materiales.Name
                        'Modificar el método para verificar permisos
                        'EliminarMaterial(Dgv_Lista.SelectedRows(0).Cells("IDMATERIAL").Value)
                    Case Nbg_Equipo.Name
                        'Modificar el método para verificar permisos
                        'EliminarEquipo(Dgv_Lista.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value)
                    Case Nbg_ManoDeObra.Name
                        'Modificar el método para verificar permisos
                        'EliminarManoDeObra(Dgv_Lista.SelectedRows(0).Cells("IDMANODEOBRA").Value)
                End Select
            End If
        ElseIf e.Control And e.KeyCode.ToString = "E" Then 'Editar
            If Dgv_Lista.SelectedRows.Count > 0 Then
                Select Case Nbc_Licitaciones.ActiveGroup.Name
                    Case Nbg_Licitaciones.Name
                        'Modificar el método para verificar permisos
                        'EditarLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
                    Case Nbg_APUItems.Name
                        'Modificar el método para verificar permisos
                        'EditarAPU(Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
                    Case Nbg_Materiales.Name
                        'Modificar el método para verificar permisos
                        'EditarMaterial(Dgv_Lista.SelectedRows(0).Cells("IDMATERIAL").Value)
                    Case Nbg_Equipo.Name
                        'Modificar el método para verificar permisos
                        'EditarEquipo(Dgv_Lista.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value)
                    Case Nbg_ManoDeObra.Name
                        'Modificar el método para verificar permisos
                        'EditarManoDeObra(Dgv_Lista.SelectedRows(0).Cells("IDMANODEOBRA").Value)
                End Select
            End If
        ElseIf e.Control And e.KeyCode.ToString = "L" Then 'Cargar Licitación
            If Nbc_Licitaciones.ActiveGroup.Name = Nbg_Licitaciones.Name Then
                SeleccionarLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
            End If
        ElseIf e.Control And e.KeyCode.ToString = "N" Then 'Nuevo
            Select Case Nbc_Licitaciones.ActiveGroup.Name
                Case Nbg_Licitaciones.Name
                    'Modificar el método para verificar permisos
                    'CrearLicitacion()
                Case Nbg_APUItems.Name
                    'Modificar el método para verificar permisos
                    'CrearAPU()
                Case Nbg_Materiales.Name
                    'Modificar el método para verificar permisos
                    'CrearMaterial()
                Case Nbg_Equipo.Name
                    'Modificar el método para verificar permisos
                    'CrearEquipo()
                Case Nbg_ManoDeObra.Name
                    'Modificar el método para verificar permisos
                    'CrearManoDeObra()
            End Select
        ElseIf e.Control And e.KeyCode.ToString = "P" Then 'Imprimir
            If Dgv_Lista.SelectedRows.Count > 0 Then
                Select Case Nbc_Licitaciones.ActiveGroup.Name
                    Case Nbg_Licitaciones.Name
                        'Modificar el método para verificar permisos
                        'ImprimirLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
                    Case Nbg_APUItems.Name
                        'Modificar el método para verificar permisos
                        'ImprimirItemsAPU(Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
                    Case Nbg_Materiales.Name
                        'Modificar el método para verificar permisos
                        'ImprimirMaterial(Dgv_Lista.SelectedRows(0).Cells("IDMATERIAL").Value)
                    Case Nbg_Equipo.Name
                        'Modificar el método para verificar permisos
                        'ImprimirEquipo(Dgv_Lista.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value)
                    Case Nbg_ManoDeObra.Name
                        'Modificar el método para verificar permisos
                        'ImprimirManoDeObra(Dgv_Lista.SelectedRows(0).Cells("IDMANODEOBRA").Value)
                End Select
            End If
        ElseIf (e.Control And e.KeyCode.ToString = "R") OrElse (e.KeyCode.ToString = "F5") Then 'Recargar
            Select Case Nbc_Licitaciones.ActiveGroup.Name
                Case Nbg_Licitaciones.Name
                    ListarLicitaciones(3)
                Case Nbg_APUItems.Name
                    'Modificar el método para verificar permisos
                    'If LicitacionEstaCargada() Then
                    '    If VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Lectura OrElse VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Escritura Then
                    '        CargarAPUItems(1)
                    '    End If
                    'End If
                Case Nbg_Materiales.Name
                    ListarMateriales(1)
                Case Nbg_Equipo.Name
                    ListarEquipos(1)
                Case Nbg_ManoDeObra.Name
                    ListarManoDeObra(1)
            End Select
        ElseIf e.Control And e.KeyCode.ToString = "D1" Then 'Abrir sección Licitaciones en la barra lateral.
            Nbc_Licitaciones.ActiveGroup = Nbg_Licitaciones
        ElseIf e.Control And e.KeyCode.ToString = "D2" Then 'Abrir sección Ítems A.P.U. en la barra lateral.
            Nbc_Licitaciones.ActiveGroup = Nbg_APUItems
        ElseIf e.Control And e.KeyCode.ToString = "D3" Then 'Abrir sección Maquinaria y Equipo en la barra lateral.
            Nbc_Licitaciones.ActiveGroup = Nbg_Equipo
        ElseIf e.Control And e.KeyCode.ToString = "D4" Then 'Abrir sección Materiales en la barra lateral.
            Nbc_Licitaciones.ActiveGroup = Nbg_Materiales
        ElseIf e.Control And e.KeyCode.ToString = "D5" Then 'Abrir sección Mano de Obra en la barra lateral.
            Nbc_Licitaciones.ActiveGroup = Nbg_ManoDeObra
        ElseIf e.Control And e.KeyCode.ToString = "D6" Then 'Abrir sección Herramientas en la barra lateral.
            Nbc_Licitaciones.ActiveGroup = Nbg_Herramientas
        End If
        'Ver (doble clic)
        'Clonar
        Select Case e.KeyCode
            Case Keys.F6
                ExportarDatosExcel(Dgv_Lista)
        End Select
    End Sub

    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView)

        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.ScreenUpdating = False
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)

        With objHojaExcel
            .Name = ("Datos Exportados")
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 1
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq
            ' Establecemos los atributos de la fuente para las
            ' celdas de la primera fila.
            With .Range(.Cells(1, 1), .Cells(1, Dgv_Lista.Columns.Count)).Font
                .Name = "Calibri"
                .Bold = True
                .Size = 12
            End With

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With
        m_Excel.ScreenUpdating = True
        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

    ''' <summary>
    ''' Establece el texto de los encabezados y el tamaño de las columnas del listado principal.
    ''' </summary>
    Private Sub OrganizarColumnasDgvLista()
        For i As Integer = 0 To Dgv_Lista.ColumnCount - 1
            Dgv_Lista.Columns(i).Visible = True
        Next
        Select Case tablaCargada
            Case TablaLicitaciones.Licitacion
                For j As Integer = 0 To Dgv_Lista.ColumnCount - 1
                    Select Case Dgv_Lista.Columns(j).Name
                        Case "HORASDIARIAS"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Horas diarias"
                        Case "PORCENTAJEADMINISTRACION"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Administración"
                            Dgv_Lista.Columns(j).DefaultCellStyle.Format = "0.####'%"
                        Case "PORCENTAJEIMPREVISTOS"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Imprevistos"
                            Dgv_Lista.Columns(j).DefaultCellStyle.Format = "0.####'%"
                        Case "PORCENTAJEUTILIDAD"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Utilidad"
                            Dgv_Lista.Columns(j).DefaultCellStyle.Format = "0.####'%"
                        Case "NROLICITACION"
                            Dgv_Lista.Columns(j).FillWeight = 100
                            Dgv_Lista.Columns(j).HeaderText = "Nro. Licitación"
                        Case "PROYECTO"
                            Dgv_Lista.Columns(j).FillWeight = 200
                            Dgv_Lista.Columns(j).HeaderText = "Proyecto"
                        Case "CLIENTE"
                            Dgv_Lista.Columns(j).FillWeight = 200
                            Dgv_Lista.Columns(j).HeaderText = "Cliente"
                        Case Else
                            'IDLICITACION, TIPOGERENCIA
                            'FECHAREGISTRO, IDUSUARIOREGISTRO,
                            'FECHAMODIFICACION, IDUSUARIOMODIFICA,
                            'ACTIVO, TIPOPERMISO,
                            Dgv_Lista.Columns(j).Visible = False
                    End Select
                Next
            Case TablaLicitaciones.APU
                For j As Integer = 0 To Dgv_Lista.ColumnCount - 1
                    Select Case Dgv_Lista.Columns(j).Name
                        Case "ABREVIATURA"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Unidad"
                        Case "CANTIDADESTIMADA"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Cantidad"
                            Dgv_Lista.Columns(j).DefaultCellStyle.Format = "0.####"
                        Case "RENDIMIENTO"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Rendimiento"
                            Dgv_Lista.Columns(j).DefaultCellStyle.Format = "0.####"
                            'Case "NROITEMLICITACION"
                            '    Dgv_Lista.Columns(j).FillWeight = 50
                            '    Dgv_Lista.Columns(j).HeaderText = "Ítem" 'Ismocol
                        Case "NROITEMCLIENTE"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Ítem" 'Cliente
                        Case "TOTALHORASHOMBRE"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Total H.H." ' sin A.I.U.
                            Dgv_Lista.Columns(j).DefaultCellStyle.Format = "0.####"
                        Case "VALORTOTALITEMSINAIU"
                            Dgv_Lista.Columns(j).FillWeight = 100
                            Dgv_Lista.Columns(j).HeaderText = "Valor Unitario" ' sin A.I.U.
                            Dgv_Lista.Columns(j).DefaultCellStyle.Format = "C0"
                            'Case "VALORTOTALITEMCONAIU"
                            '    Dgv_Lista.Columns(j).FillWeight = 100
                            '    Dgv_Lista.Columns(j).HeaderText = "Valor Unitario con A.I.U."
                            '    Dgv_Lista.Columns(j).DefaultCellStyle.Format = "C0"
                        Case "VALORCANTIDAD"
                            Dgv_Lista.Columns(j).FillWeight = 100
                            Dgv_Lista.Columns(j).HeaderText = "Valor Total"
                            Dgv_Lista.Columns(j).DefaultCellStyle.Format = "C0"
                        Case "DESCRIPCION"
                            Dgv_Lista.Columns(j).FillWeight = 200
                            Dgv_Lista.Columns(j).HeaderText = "Descripción"
                        Case Else
                            'IDAPU, IDLICITACION, CODIGOTIPOUNIDAD,
                            'FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                            'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA,
                            'ACTIVO
                            Dgv_Lista.Columns(j).Visible = False
                    End Select
                Next
            Case TablaLicitaciones.Material
                For j As Integer = 0 To Dgv_Lista.ColumnCount - 1
                    Select Case Dgv_Lista.Columns(j).Name
                        Case "IDMATERIAL"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Cód. Material"
                        Case "ABREVIATURA"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Unidad"
                        Case "VALORISMOCOL"
                            Dgv_Lista.Columns(j).FillWeight = 100
                            Dgv_Lista.Columns(j).HeaderText = "Valor Ismocol"
                        Case "VALORCOMERCIAL"
                            Dgv_Lista.Columns(j).FillWeight = 100
                            Dgv_Lista.Columns(j).HeaderText = "Valor Comercial"
                        Case "DESCRIPCION"
                            Dgv_Lista.Columns(j).FillWeight = 200
                            Dgv_Lista.Columns(j).HeaderText = "Descripción"
                        Case "NOMBREDESCRIPTIVO"
                            Dgv_Lista.Columns(j).FillWeight = 200
                            Dgv_Lista.Columns(j).HeaderText = "Artículo"
                        Case Else
                            'CODIGOTIPOUNIDAD, IDARTICULO,
                            'FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                            'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA
                            'ACTIVO
                            Dgv_Lista.Columns(j).Visible = False
                    End Select
                Next
            Case TablaLicitaciones.Equipo
                For j As Integer = 0 To Dgv_Lista.ColumnCount - 1
                    Select Case Dgv_Lista.Columns(j).Name
                        Case "IDMAQUINARIAYEQUIPO"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Cód. Equipo"
                        Case "TARIFAISMOCOLXHORA"
                            Dgv_Lista.Columns(j).FillWeight = 100
                            Dgv_Lista.Columns(j).HeaderText = "Tarifa Ismocol por Hora"
                        Case "TARIFACOMERCIALXHORA"
                            Dgv_Lista.Columns(j).FillWeight = 100
                            Dgv_Lista.Columns(j).HeaderText = "Tarifa Comercial por hora"
                        Case "COMBUSTIBLEXHORA"
                            Dgv_Lista.Columns(j).FillWeight = 100
                            Dgv_Lista.Columns(j).HeaderText = "Combustible por hora"
                        Case "DESCRIPCION"
                            Dgv_Lista.Columns(j).FillWeight = 200
                            Dgv_Lista.Columns(j).HeaderText = "Descripción"
                        Case "NOMBREDESCRIPTIVO"
                            Dgv_Lista.Columns(j).FillWeight = 200
                            Dgv_Lista.Columns(j).HeaderText = "Artículo"
                        Case Else
                            'IDARTICULO,
                            'FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                            'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA,
                            'ACTIVO
                            Dgv_Lista.Columns(j).Visible = False
                    End Select
                Next
            Case TablaLicitaciones.ManoDeObra
                For j As Integer = 0 To Dgv_Lista.ColumnCount - 1
                    Select Case Dgv_Lista.Columns(j).Name
                        Case "IDMANODEOBRA"
                            Dgv_Lista.Columns(j).FillWeight = 50
                            Dgv_Lista.Columns(j).HeaderText = "Cód. Mano de Obra"
                        Case "TARIFAISMOCOLXHORAHOMBRE"
                            Dgv_Lista.Columns(j).FillWeight = 100
                            Dgv_Lista.Columns(j).HeaderText = "Tarifa Ismocol por HH"
                        Case "DESCRIPCION"
                            Dgv_Lista.Columns(j).FillWeight = 200
                            Dgv_Lista.Columns(j).HeaderText = "Descripción"
                        Case Else
                            'FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                            'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA
                            'ACTIVO
                            Dgv_Lista.Columns(j).Visible = False
                    End Select
                Next
        End Select
    End Sub


    ''' <summary>
    ''' Establece el texto de los encabezados y el tamaño de las columnas en los cuadros inferiores.
    ''' </summary>
    Private Sub OrganizarColumnasRecursosDgv()
        For i As Integer = 0 To Dgv_Materiales.ColumnCount - 1
            Select Case Dgv_Materiales.Columns(i).Name
                Case "IDMATERIAL"
                    Dgv_Materiales.Columns(i).FillWeight = 50
                    Dgv_Materiales.Columns(i).HeaderText = "Cód. Material"
                Case "ABREVIATURA"
                    Dgv_Materiales.Columns(i).FillWeight = 50
                    Dgv_Materiales.Columns(i).HeaderText = "Unidad"
                Case "VALORISMOCOL"
                    Dgv_Materiales.Columns(i).FillWeight = 100
                    Dgv_Materiales.Columns(i).HeaderText = "Valor Ismocol"
                Case "VALORCOMERCIAL"
                    Dgv_Materiales.Columns(i).FillWeight = 100
                    Dgv_Materiales.Columns(i).HeaderText = "Valor Comercial"
                Case "DESCRIPCION"
                    Dgv_Materiales.Columns(i).FillWeight = 200
                    Dgv_Materiales.Columns(i).HeaderText = "Descripción"
                Case "NOMBREDESCRIPTIVO"
                    Dgv_Materiales.Columns(i).FillWeight = 200
                    Dgv_Materiales.Columns(i).HeaderText = "Artículo"
                Case Else
                    'CODIGOTIPOUNIDAD, IDARTICULO,
                    'FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                    'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA
                    'ACTIVO
                    Dgv_Materiales.Columns(i).Visible = False
            End Select
        Next
        For j As Integer = 0 To Dgv_Equipos.ColumnCount - 1
            Select Case Dgv_Equipos.Columns(j).Name
                Case "IDMAQUINARIAYEQUIPO"
                    Dgv_Equipos.Columns(j).FillWeight = 50
                    Dgv_Equipos.Columns(j).HeaderText = "Cód. Equipo"
                Case "TARIFAISMOCOLXHORA"
                    Dgv_Equipos.Columns(j).FillWeight = 100
                    Dgv_Equipos.Columns(j).HeaderText = "Tarifa Ismocol por Hora"
                Case "TARIFACOMERCIALXHORA"
                    Dgv_Equipos.Columns(j).FillWeight = 100
                    Dgv_Equipos.Columns(j).HeaderText = "Tarifa Comercial por hora"
                Case "COMBUSTIBLEXHORA"
                    Dgv_Equipos.Columns(j).FillWeight = 100
                    Dgv_Equipos.Columns(j).HeaderText = "Combustible por hora"
                Case "DESCRIPCION"
                    Dgv_Equipos.Columns(j).FillWeight = 200
                    Dgv_Equipos.Columns(j).HeaderText = "Descripción"
                Case "NOMBREDESCRIPTIVO"
                    Dgv_Equipos.Columns(j).FillWeight = 200
                    Dgv_Equipos.Columns(j).HeaderText = "Artículo"
                Case Else
                    'IDARTICULO,
                    'FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                    'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA,
                    'ACTIVO
                    Dgv_Equipos.Columns(j).Visible = False
            End Select
        Next
        For k As Integer = 0 To Dgv_ManodeObra.ColumnCount - 1
            Select Case Dgv_ManodeObra.Columns(k).Name
                Case "IDMANODEOBRA"
                    Dgv_ManodeObra.Columns(k).FillWeight = 50
                    Dgv_ManodeObra.Columns(k).HeaderText = "Cód. Mano de Obra"
                Case "TARIFAISMOCOLXHORAHOMBRE"
                    Dgv_ManodeObra.Columns(k).FillWeight = 100
                    Dgv_ManodeObra.Columns(k).HeaderText = "Tarifa Ismocol por HH"
                Case "DESCRIPCION"
                    Dgv_ManodeObra.Columns(k).FillWeight = 200
                    Dgv_ManodeObra.Columns(k).HeaderText = "Descripción"
                Case Else
                    'FECHAREGISTRO, IDUSUARIOREGISTRO, USUARIOREGISTRO,
                    'FECHAMODIFICACION, IDUSUARIOMODIFICA, USUARIOMODIFICA
                    'ACTIVO
                    Dgv_ManodeObra.Columns(k).Visible = False
            End Select
        Next
    End Sub


    'Carga los listados de recursos cuando se selecciona una licitación o Ítem A.P.U y carga las propiedades del recurso seleccionado.
    Private Sub Dgv_Lista_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Dgv_Lista.SelectionChanged
        If Not IsNothing(Dgv_Lista.CurrentRow) AndAlso (Dgv_Lista.SelectedRows.Count > 0 AndAlso Dgv_Lista.SelectedRows(0).Cells.Count > 1) Then
            Select Case tablaCargada
                Case TablaLicitaciones.Licitacion
                    ListarMaterialesDgv(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value, -1)
                    ListarMaquinariaEquiposDgv(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value, -1)
                    ListarManoDeObraDgv(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value, -1)
                    CalcularTotales()
                Case TablaLicitaciones.APU
                    ListarMaterialesDgv(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value, Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
                    ListarMaquinariaEquiposDgv(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value, Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
                    ListarManoDeObraDgv(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value, Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
                Case TablaLicitaciones.Material

                Case TablaLicitaciones.Equipo

                Case TablaLicitaciones.ManoDeObra

            End Select
            Try
                Dim xx As New Object
                Select Case tablaCargada
                    Case TablaLicitaciones.Licitacion
                        xx = New Cl_Licitacion(Dgv_Lista.Rows(Dgv_Lista.SelectedRows(0).Index))
                    Case TablaLicitaciones.APU
                        xx = New Cl_APU(Dgv_Lista.Rows(Dgv_Lista.SelectedRows(0).Index))
                    Case TablaLicitaciones.Material
                        xx = New Cl_Material(Dgv_Lista.Rows(Dgv_Lista.SelectedRows(0).Index))
                    Case TablaLicitaciones.Equipo
                        xx = New Cl_Equipo(Dgv_Lista.Rows(Dgv_Lista.SelectedRows(0).Index))
                    Case TablaLicitaciones.ManoDeObra
                        xx = New Cl_ManoDeObra(Dgv_Lista.Rows(Dgv_Lista.SelectedRows(0).Index))
                End Select
                Pg_DetalleLista.SelectedObject = xx
            Catch
                Pg_DetalleLista.SelectedObject = Nothing
            End Try
        Else
            Pg_DetalleLista.SelectedObject = Nothing
        End If
    End Sub


    ''' <summary>
    ''' Cargar listado de Materiales de la Licitación seleccionada en el cuadro inferior.
    ''' Para cargar todos los materiales de la licitación, ingresar un valor de idAPU menor o igual a cero (0).
    ''' </summary>
    ''' <param name="idLicitacion">La licitación de la cual se cargan los materiales.</param>
    ''' <param name="idAPU">
    ''' Opcional. El ítem A.P.U. del cual se cargan los materiales desde la sección Ítems A.P.U.
    ''' Para cargar todos los materiales de la licitación, ingresar un valor de idAPU menor o igual a cero (0).
    ''' </param>
    ''' <remarks>Para cargar todos los materiales de la licitación, ingresar un valor de idAPU menor o igual a cero (0).</remarks>
    Private Sub ListarMaterialesDgv(ByVal idLicitacion As Integer, ByVal idAPU As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand
        comando.Connection = conexion
        If idAPU > 0 Then
            comando.CommandText = "SELECT * FROM dbo.LIC_ListaAPU_Material(@TIPO, @IDLICITACION, @IDAPU)"
            comando.Parameters.AddWithValue("@TIPO", 1)
            comando.Parameters.AddWithValue("@IDAPU", idAPU)
        Else
            comando.CommandText = "SELECT * FROM dbo.LIC_ListaMaterialTotalLicitacion(@IDLICITACION)"
        End If
        comando.Parameters.AddWithValue("@IDLICITACION", idLicitacion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtMaterialesLicitacion As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtMaterialesLicitacion)
            conexion.Close()
            Dgv_Materiales.DataSource = dtMaterialesLicitacion
            OrganizarColumnasRecursosDgv()
        Catch ex As Exception
            MsgBox("No fue posible cargar el listado de Materiales del cuadro inferior.", MsgBoxStyle.Critical, "Error Listar Materiales")
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Cargar listado de Maquinaria de la Licitación seleccionada en el cuadro inferior.
    ''' Para cargar toda la maquinaria de la licitación, ingresar un valor de idAPU menor o igual a cero (0).
    ''' </summary>
    ''' <param name="idLicitacion">La licitación de la cual se carga la maquinaria.</param>
    ''' <param name="idAPU">
    ''' Opcional. El ítem A.P.U. del cual se carga la maquinaria desde la sección Ítems A.P.U.
    ''' Para cargar toda la maquinaria de la licitación, ingresar un valor de idAPU menor o igual a cero (0).
    ''' </param>
    ''' <remarks>Para cargar toda la maquinaria de la licitación, ingresar un valor de idAPU menor o igual a cero (0).</remarks>
    Private Sub ListarMaquinariaEquiposDgv(ByVal idLicitacion As Integer, ByVal idAPU As Integer)
        'Cargar listado de Maquinaria y Equipo de la Licitación seleccionada en Dgv_Equipos
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand
        comando.Connection = conexion
        If idAPU > 0 Then
            comando.CommandText = "SELECT * FROM dbo.LIC_ListaAPU_MaquinariaYEquipo(@TIPO, @IDLICITACION, @IDAPU)"
            comando.Parameters.AddWithValue("@TIPO", 1)
            comando.Parameters.AddWithValue("@IDAPU", idAPU)
        Else
            comando.CommandText = "SELECT * FROM dbo.LIC_ListaMaquinariaYEquipoTotalLicitacion(@IDLICITACION)"
        End If
        comando.Parameters.AddWithValue("@IDLICITACION", idLicitacion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtEquiposLicitacion As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtEquiposLicitacion)
            conexion.Close()
            Dgv_Equipos.DataSource = dtEquiposLicitacion
            OrganizarColumnasRecursosDgv()
        Catch ex As Exception
            MsgBox("No fue posible cargar el listado de Maquinaria y Equipo del cuadro inferior.", MsgBoxStyle.Critical, "Error Listar Maquinaria y Equipo")
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Cargar listado de Mano de Obra de la Licitación seleccionada en el cuadro inferior.
    ''' Para cargar toda la mano de obra de la licitación, ingresar un valor de idAPU menor o igual a cero (0).
    ''' </summary>
    ''' <param name="idLicitacion">La licitación de la cual se carga la mano de obra.</param>
    ''' <param name="idAPU">
    ''' Opcional. El ítem A.P.U. del cual se carga la mano de obra desde la sección Ítems A.P.U.
    ''' Para cargar toda la mano de obra de la licitación, ingresar un valor de idAPU menor o igual a cero (0).
    ''' </param>
    ''' <remarks>Para cargar toda la mano de obra de la licitación, ingresar un valor de idAPU menor o igual a cero (0).</remarks>
    Private Sub ListarManoDeObraDgv(ByVal idLicitacion As Integer, ByVal idAPU As Integer)
        'Cargar listado de Mano de Obra de la Licitación seleccionada en Dgv_ManoDeObra
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand
        comando.Connection = conexion
        If idAPU > 0 Then
            comando.CommandText = "SELECT * FROM dbo.LIC_ListaAPU_ManoDeObra(@TIPO, @IDLICITACION, @IDAPU)"
            comando.Parameters.AddWithValue("@TIPO", 1)
            comando.Parameters.AddWithValue("@IDAPU", idAPU)
        Else
            comando.CommandText = "SELECT * FROM dbo.LIC_ListaManoDeObraTotalLicitacion(@IDLICITACION)"
        End If
        comando.Parameters.AddWithValue("@IDLICITACION", idLicitacion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtManoDeObraLicitacion As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtManoDeObraLicitacion)
            conexion.Close()
            Dgv_ManodeObra.DataSource = dtManoDeObraLicitacion
            OrganizarColumnasDgvLista()
        Catch ex As Exception
            MsgBox("No fue posible cargar el listado de Mano de Obra del cuadro inferior.", MsgBoxStyle.Critical, "Error Listar Mano de Obra")
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub CalcularTotales()
        Dim porcentajeAdministracion As Decimal = 0
        Dim porcentajeImprevistos As Decimal = 0
        Dim porcentajeUtilidades As Decimal = 0
        Dim costoDirecto As Decimal = 0
        Dim valorAdministracion As Decimal = 0
        Dim valorImprevistos As Decimal = 0
        Dim valorUtilidad As Decimal = 0
        Dim totalCosto As Decimal = 0
        Dim totalHorasHombre As Decimal = 0
        Tlp_Totales.Visible = True

        Select Case tablaCargada
            Case TablaLicitaciones.Licitacion
                porcentajeAdministracion = Dgv_Lista.SelectedRows(0).Cells("PORCENTAJEADMINISTRACION").Value
                porcentajeImprevistos = Dgv_Lista.SelectedRows(0).Cells("PORCENTAJEIMPREVISTOS").Value
                porcentajeUtilidades = Dgv_Lista.SelectedRows(0).Cells("PORCENTAJEUTILIDAD").Value

                'Cálculo del Costo Directo
                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_TotalesLicitacion(@IDLICITACION)", conexion)
                comando.Parameters.AddWithValue("@IDLICITACION", Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dtTotales As New DataTable
                Try
                    conexion.Open()
                    adaptador.Fill(dtTotales)
                    conexion.Close()
                    If Not IsNothing(dtTotales) AndAlso dtTotales.Rows.Count > 0 Then
                        costoDirecto = dtTotales.Rows(0).Item("COSTODIRECTO")
                        totalHorasHombre = dtTotales.Rows(0).Item("TOTALHORASHOMBRE")
                    End If
                Catch ex As Exception
                    Tlp_Totales.Visible = False
                    Lb_TotalCostoDirecto.Text = ""
                    Lb_PorcentajeAdministracion.Text = ""
                    Lb_TotalAdministracion.Text = ""
                    Lb_PorcentajeImprevistos.Text = ""
                    Lb_TotalImprevistos.Text = ""
                    Lb_PorcentajeUtilidades.Text = ""
                    Lb_TotalUtilidades.Text = ""
                    Lb_TotalCosto.Text = ""
                    Exit Sub
                Finally
                    conexion.Close()
                End Try
            Case TablaLicitaciones.APU
                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_DatosLicitacion(@IDLICITACION, @IDUSUARIO)", conexion)
                comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
                comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dtLicitacion As New DataTable
                Try
                    conexion.Open()
                    adaptador.Fill(dtLicitacion)
                    conexion.Close()
                    If dtLicitacion.Rows.Count > 0 Then
                        Dim drLicitacion As DataRow
                        drLicitacion = dtLicitacion.Rows(0)
                        porcentajeAdministracion = drLicitacion.Item("PORCENTAJEADMINISTRACION")
                        porcentajeImprevistos = drLicitacion.Item("PORCENTAJEIMPREVISTOS")
                        porcentajeUtilidades = drLicitacion.Item("PORCENTAJEUTILIDAD")

                        'Cálculo del Costo Directo
                        For i As Integer = 0 To Dgv_Lista.Rows.Count - 1
                            If Dgv_Lista.Rows(i).Cells("ESCAPITULO").Value = "N" Then
                                costoDirecto += Dgv_Lista.Rows(i).Cells("VALORCANTIDAD").Value '(Dgv_Lista.Rows(i).Cells("VALORTOTALITEMSINAIU").Value * Dgv_Lista.Rows(i).Cells("CANTIDADESTIMADA").Value)
                                totalHorasHombre += Dgv_Lista.Rows(i).Cells("TOTALHORASHOMBRE").Value
                            End If
                        Next
                    End If
                Catch
                    Tlp_Totales.Visible = False
                    Lb_TotalCostoDirecto.Text = ""
                    Lb_PorcentajeAdministracion.Text = ""
                    Lb_TotalAdministracion.Text = ""
                    Lb_PorcentajeImprevistos.Text = ""
                    Lb_TotalImprevistos.Text = ""
                    Lb_PorcentajeUtilidades.Text = ""
                    Lb_TotalUtilidades.Text = ""
                    Lb_TotalCosto.Text = ""
                    Lb_TotalHorasHombre.Text = ""
                    Exit Sub
                Finally
                    conexion.Close()
                End Try
        End Select
        valorAdministracion = costoDirecto * (porcentajeAdministracion / 100)
        valorImprevistos = costoDirecto * (porcentajeImprevistos / 100)
        valorUtilidad = costoDirecto * (porcentajeUtilidades / 100)

        totalCosto = costoDirecto + valorAdministracion + valorImprevistos + valorUtilidad

        Lb_TotalCostoDirecto.Text = Format(costoDirecto, "C0")
        Lb_PorcentajeAdministracion.Text = porcentajeAdministracion & "%"
        Lb_TotalAdministracion.Text = Format(valorAdministracion, "C0")
        Lb_PorcentajeImprevistos.Text = porcentajeImprevistos & "%"
        Lb_TotalImprevistos.Text = Format(valorImprevistos, "C0")
        Lb_PorcentajeUtilidades.Text = porcentajeUtilidades & "%"
        Lb_TotalUtilidades.Text = Format(valorUtilidad, "C0")
        Lb_TotalCosto.Text = Format(totalCosto, "C0")
        Lb_TotalHorasHombre.Text = Format(totalHorasHombre, "0.####")
    End Sub


    ' Define las acciones al dar doble clic sobre un recurso en el listado principal (por defecto visualizar recurso).
    Private Sub Dgv_Lista_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Dgv_Lista.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Select Case tablaCargada
                Case TablaLicitaciones.Licitacion
                    Using frLicitacion As New Fr_Licitacion
                        frLicitacion.Edicion = TipoEdicion.Ver
                        frLicitacion.IdLicitacion = sender.SelectedRows(0).Cells("IDLICITACION").Value
                        frLicitacion.ShowDialog()
                        If frLicitacion.DialogResult = DialogResult.OK Then 'Se hizo clic en el botón "Seleccionar Licitación"
                            SeleccionarLicitacion(frLicitacion.IdLicitacion)
                        End If
                    End Using
                Case TablaLicitaciones.APU
                    Using frAPU As New Fr_APU
                        frAPU.Edicion = TipoEdicion.Ver
                        frAPU.IdAPU = sender.SelectedRows(0).Cells("IDAPU").Value
                        frAPU.ShowDialog()
                    End Using
                Case TablaLicitaciones.Material
                    Using frMaterial As New Fr_Material
                        frMaterial.Edicion = TipoEdicion.Ver
                        frMaterial.IdMaterial = sender.SelectedRows(0).Cells("IDMATERIAL").Value
                        frMaterial.ShowDialog()
                    End Using
                Case TablaLicitaciones.Equipo
                    Using frMaquinariaEquipo As New Fr_MaquinariaEquipo
                        frMaquinariaEquipo.Edicion = TipoEdicion.Ver
                        frMaquinariaEquipo.IdMaquinariaEquipo = sender.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value
                        frMaquinariaEquipo.ShowDialog()
                    End Using
                Case TablaLicitaciones.ManoDeObra
                    Using frManoDeObra As New Fr_ManoDeObra
                        frManoDeObra.Edicion = TipoEdicion.Ver
                        frManoDeObra.IdManoDeObra = sender.SelectedRows(0).Cells("IDMANODEOBRA").Value
                        frManoDeObra.ShowDialog()
                    End Using
            End Select
        End If
    End Sub


    ' 
    Private Sub Dgv_Lista_Sorted(sender As Object, e As EventArgs) Handles Dgv_Lista.Sorted
        If tablaCargada = TablaLicitaciones.APU Then
            FormatearCapitulos()
        End If
    End Sub


    ''' <summary>
    ''' Verifica si hay alguna licitación cargada. Si no hay ninguna licitación cargada, abre el formulario de selección de licitación para cargar.
    ''' </summary>
    ''' <returns>Si había una licitación cargada, si se cargó licitación con el formulario de selección o si no se cargó ninguna licitación.</returns>
    Private Function LicitacionEstaSeleccionada() As Boolean
        If VariablesBase.VariablesBase.IdLicitacionCargada > 0 Then
            Return True
        Else
            Using frBuscarRecurso As New Fr_BuscarRecurso
                frBuscarRecurso.Recurso = FormulariosLicitaciones.TipoRecurso.Licitacion
                frBuscarRecurso.Text = "Buscar Licitación"
                frBuscarRecurso.ShowDialog()
                If frBuscarRecurso.IdRecurso > 0 Then
                    SeleccionarLicitacion(frBuscarRecurso.IdRecurso)
                    Return True
                Else
                    Return False
                End If
            End Using
        End If
    End Function


    ''' <summary>
    ''' Carga el listado principal filtrado y reestablece los listados de los cuadros inferiores.
    ''' </summary>
    ''' <param name="dsTabla">Listado filtrado.</param>
    ''' <param name="tabla">Tipo de listado que se está cargando.</param>
    Private Sub CargarFiltro(ByVal dsTabla As DataSet, tabla As TablaLicitaciones)
        tablaCargada = tabla
        Dgv_Lista.DataSource = Nothing
        Dgv_Lista.DataSource = dsTabla.Tables(0).DefaultView
        Dgv_Lista.AutoGenerateColumns = True
        Dgv_Lista.ContextMenuStrip = Cms_OpcionesLicitacion
        Dgv_Lista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None
        Dgv_Lista.ReadOnly = True
        OrganizarColumnasDgvLista()
        Select Case tabla
            Case TablaLicitaciones.Licitacion
                Dgv_Lista.ContextMenuStrip = Cms_OpcionesLicitacion
                Dgv_Materiales.DataSource = Nothing
                Dgv_Equipos.DataSource = Nothing
                Dgv_ManodeObra.DataSource = Nothing
            Case TablaLicitaciones.APU
                Dgv_Lista.ContextMenuStrip = Cms_OpcionesItems
                Dgv_Materiales.DataSource = Nothing
                Dgv_Equipos.DataSource = Nothing
                Dgv_ManodeObra.DataSource = Nothing
            Case TablaLicitaciones.Material
                Dgv_Lista.ContextMenuStrip = Cms_OpcionesMaterial
            Case TablaLicitaciones.Equipo
                Dgv_Lista.ContextMenuStrip = Cms_OpcionesEquipos
            Case TablaLicitaciones.ManoDeObra
                Dgv_Lista.ContextMenuStrip = Cms_OpcionesManoDeObra
        End Select
        actualizarContadorRegistros()
    End Sub


    ' 
    Private Sub Dgv_Lista_MouseDown(sender As Object, e As MouseEventArgs) Handles Dgv_Lista.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hit = sender.HitTest(e.X, e.Y)
            If hit.RowIndex >= 0 Then
                If Not sender.SelectedRows.Contains(sender.Rows(hit.RowIndex)) Then
                    sender.ClearSelection()
                    sender.Rows(hit.RowIndex).Selected = True
                End If
            Else
                sender.ClearSelection()
            End If
        End If
    End Sub


    Private Sub UbicarRegistro(filaActual As Integer)
        If filaActual < Dgv_Lista.Rows.Count Then
            Dgv_Lista.Rows(filaActual).Selected = True
            Dgv_Lista.FirstDisplayedScrollingRowIndex = Dgv_Lista.SelectedRows(0).Index
        End If
    End Sub


    ' 
    Private Sub Cms_Opciones_Opening(sender As Object, e As CancelEventArgs) Handles Cms_OpcionesLicitacion.Opening, Cms_OpcionesItems.Opening, Cms_OpcionesEquipos.Opening, Cms_OpcionesMaterial.Opening, Cms_OpcionesManoDeObra.Opening
        If Dgv_Lista.SelectedRows.Count <= 0 Then
            e.Cancel = True
        End If
    End Sub


    ' 
    Private Sub Lic_SeleccionarLicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Lic_SeleccionarLicToolStripMenuItem.Click
        Dim permisoOtorgado As String = Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value
        If permisoOtorgado = TipoPermiso.Escritura OrElse permisoOtorgado = TipoPermiso.Lectura Then
            SeleccionarLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
        End If
    End Sub


    ' 
    Private Sub Lic_EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Lic_EditarToolStripMenuItem.Click
        Dim filaActual As Integer = Dgv_Lista.SelectedRows(0).Index
        If Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value = TipoPermiso.Escritura Then 'El Usuario tiene permiso para editar Licitaciones
            EditarLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
            ListarLicitaciones(3)
            Dgv_Lista.ClearSelection()
            UbicarRegistro(filaActual)
        End If
    End Sub


    ' 
    Private Sub Lic_ClonarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Lic_ClonarToolStripMenuItem.Click
        Dim permisoOtorgado As String = Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value
        If permisoOtorgado = TipoPermiso.Escritura OrElse permisoOtorgado = TipoPermiso.Lectura Then
            ClonarLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
            ListarLicitaciones(3)
        End If
    End Sub


    ' 
    Private Sub Lic_ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Lic_ImprimirToolStripMenuItem.Click
        ImprimirLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
    End Sub


    ' 
    Private Sub Lic_EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Lic_EliminarToolStripMenuItem.Click
        If Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value = TipoPermiso.Escritura Then
            If MsgBox("¿Desea eliminar la Licitación " & Dgv_Lista.SelectedRows(0).Cells("NROLICITACION").Value & " - " & Dgv_Lista.SelectedRows(0).Cells("PROYECTO").Value & "?" & Environment.NewLine & "Este proceso es irreversible.", _
                      MsgBoxStyle.YesNo, "Eliminar Licitación") = MsgBoxResult.Yes Then
                EliminarUnaLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
                VariablesBase.VariablesBase.IdLicitacionCargada = -1
                VariablesBase.VariablesBase.PermisoLicitacionOtorgado = "N"
                Lb_NombreLicitacion.Text = "LICITACIONES"
                ListarLicitaciones(3)
            End If
        End If
    End Sub


    ' 
    Private Sub Apu_EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Apu_EditarToolStripMenuItem.Click
        Dim filaActual As Integer = Dgv_Lista.SelectedRows(0).Index
        If VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Escritura Then
            EditarAPU(Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
            ListarAPUItems(1)
            Dgv_Lista.ClearSelection()
            UbicarRegistro(filaActual)
        End If
    End Sub


    ' 
    Private Sub Apu_ClonarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Apu_ClonarToolStripMenuItem.Click
        If VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Escritura Then
            If Dgv_Lista.SelectedRows(0).Cells("ESCAPITULO").Value = "N" Then
                ClonarAPU(Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
                ListarAPUItems(1)
            End If
        End If
    End Sub


    ' 
    Private Sub Apu_EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Apu_EliminarToolStripMenuItem.Click
        If VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Escritura Then
            If MsgBox("¿Desea eliminar el Ítem A.P.U. " & _
                      If(Not IsDBNull(Dgv_Lista.SelectedRows(0).Cells("NROITEMCLIENTE").Value), Dgv_Lista.SelectedRows(0).Cells("NROITEMCLIENTE").Value, "#" & Dgv_Lista.SelectedRows(0).Cells("NROITEMLICITACION").Value) & _
                      " - " & Dgv_Lista.SelectedRows(0).Cells("DESCRIPCION").Value & "?" & Environment.NewLine & "Este proceso es irreversible.", _
                          MsgBoxStyle.YesNo, "Eliminar Ítem A.P.U.") = MsgBoxResult.Yes Then
                EliminarUnAPU(Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
                ListarAPUItems(1)
            End If
        End If
    End Sub


    ' 
    Private Sub ME_EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ME_EditarToolStripMenuItem.Click
        Dim filaActual As Integer = Dgv_Lista.SelectedRows(0).Index
        EditarEquipo(Dgv_Lista.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value)
        ListarEquipos(1)
        Dgv_Lista.ClearSelection()
        UbicarRegistro(filaActual)
    End Sub


    ' 
    Private Sub ME_ClonarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ME_ClonarToolStripMenuItem.Click
        ClonarEquipo(Dgv_Lista.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value)
        ListarEquipos(1)
    End Sub


    ' 
    Private Sub ME_EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ME_EliminarToolStripMenuItem.Click
        If MsgBox("¿Desea eliminar la Maquinaria y Equipo Cód: " & Dgv_Lista.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value & " - " & Dgv_Lista.SelectedRows(0).Cells("DESCRIPCION").Value & "?" & Environment.NewLine & "Este proceso es irreversible.", _
                          MsgBoxStyle.YesNo, "Eliminar Maquinaria y Equipo") = MsgBoxResult.Yes Then
            EliminarEquipo(Dgv_Lista.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value)
            ListarEquipos(1)
        End If
    End Sub


    ' 
    Private Sub Ma_EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Ma_EditarToolStripMenuItem.Click
        Dim filaActual As Integer = Dgv_Lista.SelectedRows(0).Index
        EditarMaterial(Dgv_Lista.SelectedRows(0).Cells("IDMATERIAL").Value)
        ListarMateriales(1)
        Dgv_Lista.ClearSelection()
        UbicarRegistro(filaActual)
    End Sub


    ' 
    Private Sub Ma_ClonarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Ma_ClonarToolStripMenuItem.Click
        If Dgv_Lista.SelectedRows.Count > 0 Then
            ClonarMaterial(Dgv_Lista.SelectedRows(0).Cells("IDMATERIAL").Value)
            ListarMateriales(1)
        End If
    End Sub


    ' 
    Private Sub Ma_EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Ma_EliminarToolStripMenuItem.Click
        If MsgBox("¿Desea eliminar el Material " & Dgv_Lista.SelectedRows(0).Cells("IDMATERIAL").Value & " - " & Dgv_Lista.SelectedRows(0).Cells("DESCRIPCION").Value & "?" & Environment.NewLine & "Este proceso es irreversible.", _
                          MsgBoxStyle.YesNo, "Eliminar Material") = MsgBoxResult.Yes Then
            EliminarMaterial(Dgv_Lista.SelectedRows(0).Cells("IDMATERIAL").Value)
            ListarMateriales(1)
        End If
    End Sub


    ' 
    Private Sub MO_EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MO_EditarToolStripMenuItem.Click
        Dim filaActual As Integer = Dgv_Lista.SelectedRows(0).Index
        EditarManoDeObra(Dgv_Lista.SelectedRows(0).Cells("IDMANODEOBRA").Value)
        ListarManoDeObra(1)
        Dgv_Lista.ClearSelection()
        UbicarRegistro(filaActual)
    End Sub


    ' 
    Private Sub MO_ClonarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MO_ClonarToolStripMenuItem.Click
        ClonarManoDeObra(Dgv_Lista.SelectedRows(0).Cells("IDMANODEOBRA").Value)
        ListarManoDeObra(1)
    End Sub


    ' 
    Private Sub MO_EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MO_EliminarToolStripMenuItem.Click
        If MsgBox("¿Desea eliminar la Mano de Obra Cód: " & Dgv_Lista.SelectedRows(0).Cells("IDMANODEOBRA").Value & " - " & Dgv_Lista.SelectedRows(0).Cells("DESCRIPCION").Value & "?" & Environment.NewLine & "Este proceso es irreversible.", _
                                  MsgBoxStyle.YesNo, "Eliminar Mano de Obra") = MsgBoxResult.Yes Then
            EliminarManoDeObra(Dgv_Lista.SelectedRows(0).Cells("IDMANODEOBRA").Value)
            ListarManoDeObra(1)
        End If
    End Sub


    ''' <summary>
    ''' Cambia el texto de la etiqueta de listado para actualizar el nombre de la tabla listada y la cantidad de registros encontrados.
    ''' </summary>
    Private Sub actualizarContadorRegistros()
        Dim lista As String = ""
        Select Case tablaCargada
            Case TablaLicitaciones.Licitacion
                lista = "Licitaciones"
            Case TablaLicitaciones.APU
                lista = "Ítems A.P.U"
            Case TablaLicitaciones.Equipo
                lista = "Maquinaria y Equipo"
            Case TablaLicitaciones.Material
                lista = "Materiales"
            Case TablaLicitaciones.ManoDeObra
                lista = "Mano de Obra"
        End Select
        Lb_ListaPrincipal.Text = If(lista <> "", "Listado de " & lista & ". ", "") & Dgv_Lista.Rows.Count & " registros."
    End Sub


#Region "Licitación"

    'Opción Cargar el listado de Licitaciones.
    Private Sub Nbi_CargarListaLicitaciones_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_CargarListaLicitaciones.ItemClick
        ListarLicitaciones(3)
    End Sub


    ''' <summary>
    ''' Carga el listado inicial de licitaciones
    ''' </summary>
    ''' <param name="tipo">
    ''' Tipo de listado.
    ''' 0: Todas las Licitaciones (incluyendo inactivas y de las quue el usuario no tiene permiso de lectura/escritura)
    ''' 1: Todas las Licitaciones activas (incluyendo las licitaciones de las que el usuario no tiene permiso de lectura/escritura)
    ''' 2: Licitaciones de las cuales se tiene permiso de lectura/escritura (incluyendo inactivas).
    ''' 3: Licitaciones activas de las cuales se tiene permiso de lectura/escritura.
    ''' </param>
    Private Sub ListarLicitaciones(ByVal tipo As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaLicitaciones(@TIPO, @IDUSUARIO)", conexion)
        comando.Parameters.AddWithValue("@TIPO", tipo)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtLicitaciones As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtLicitaciones, SchemaType.Source)
            adaptador.Fill(dtLicitaciones)
            conexion.Close()
            tablaCargada = TablaLicitaciones.Licitacion
            Dgv_Lista.ContextMenuStrip = Cms_OpcionesLicitacion
            Dgv_Lista.DataSource = dtLicitaciones
            OrganizarColumnasDgvLista()
            actualizarContadorRegistros()
            'No se debe mostrar el resumen de recursos
            'Splitter1.Visible = True
            'Sc_EquipoManoObra.Visible = True
            Splitter1.Visible = False
            Sc_EquipoManoObra.Visible = False
            Tlp_Totales.Visible = True
        Catch ex As Exception
            MsgBox("No fue posible cargar el listado de Licitaciones.", MsgBoxStyle.Critical, "Error Listar Licitaciones")
        Finally
            conexion.Close()
        End Try
    End Sub


    'Opción Crear una nueva Licitación.
    Private Sub Nbi_CrearLicitacion_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_CrearLicitacion.ItemClick
        CrearLicitacion()
        ListarLicitaciones(3)
    End Sub


    ''' <summary>
    ''' Crear una nueva Licitación.
    ''' </summary>
    Private Sub CrearLicitacion()
        GestionarLicitacion(-1, TipoEdicion.Crear)
    End Sub


    'Opción Editar una Licitación.
    Private Sub Nbi_EditarLicitacion_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_EditarLicitacion.ItemClick
        If tablaCargada = TablaLicitaciones.Licitacion Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                Dim filaActual As Integer = Dgv_Lista.SelectedRows(0).Index
                If Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value = TipoPermiso.Escritura Then 'El Usuario tiene permiso para editar Licitaciones
                    EditarLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
                    ListarLicitaciones(3)
                    Dgv_Lista.ClearSelection()
                    UbicarRegistro(filaActual)
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Licitaciones.", MsgBoxStyle.Information, "Licitaciones")
        End If
    End Sub


    ''' <summary>
    ''' Editar los datos de Licitación.
    ''' </summary>
    ''' <param name="idLicitacion">Licitación a editar.</param>
    Private Sub EditarLicitacion(ByVal idLicitacion As Integer)
        GestionarLicitacion(idLicitacion, TipoEdicion.Editar)
    End Sub


    'Opción Clonar una Licitación.
    Private Sub Nbi_ClonarLicitacion_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_ClonarLicitacion.ItemClick
        If tablaCargada = TablaLicitaciones.Licitacion Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                Dim permisoOtorgado As String = Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value
                If permisoOtorgado = TipoPermiso.Escritura OrElse permisoOtorgado = TipoPermiso.Lectura Then
                    ClonarLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
                    ListarLicitaciones(3)
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Licitaciones.", MsgBoxStyle.Information, "Licitaciones")
        End If
    End Sub


    ''' <summary>
    ''' Clonar una Licitación.
    ''' </summary>
    ''' <param name="idLicitacion">Licitación a partir de la cual se genera la licitación clonada.</param>
    Private Sub ClonarLicitacion(ByVal idLicitacion As Integer)
        GestionarLicitacion(idLicitacion, TipoEdicion.Clonar)
    End Sub


    ''' <summary>
    ''' Permite gestionar licitaciones.
    ''' </summary>
    ''' <param name="idLicitacion">Opcional. Licitación que se va a gestionar.</param>
    ''' <param name="edicion">Indica el tipo de gestión que se realiza.</param>
    Private Sub GestionarLicitacion(ByVal idLicitacion As Integer, ByVal edicion As TipoEdicion)
        Using frLicitacion As New Fr_Licitacion
            frLicitacion.Edicion = edicion
            frLicitacion.IdLicitacion = idLicitacion
            frLicitacion.ShowDialog()
            If frLicitacion.DialogResult = DialogResult.OK Then
                If MsgBox("¿Desea Cargar la Licitación gestionada?", MsgBoxStyle.YesNo, "Gestionar Licitación") = MsgBoxResult.Yes Then
                    SeleccionarLicitacion(frLicitacion.IdLicitacion)
                End If
            End If
        End Using
    End Sub


    'Opción seleccionar una licitación para iniciar la gestión o visualización de ítems A.P.U.
    Private Sub Nbi_SeleccionarLicitacion_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_SeleccionarLicitacion.ItemClick
        If tablaCargada = TablaLicitaciones.Licitacion Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                Dim permisoOtorgado As String = Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value
                If permisoOtorgado = TipoPermiso.Escritura OrElse permisoOtorgado = TipoPermiso.Lectura Then
                    SeleccionarLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Licitaciones.", MsgBoxStyle.Information, "Licitaciones")
        End If
    End Sub


    ''' <summary>
    ''' Carga la licitación seleccionada en variables base para la gestión de Ítems A.P.U.
    ''' </summary>
    ''' <param name="idLicitacion">Licitación a cargar.</param>
    Private Sub SeleccionarLicitacion(ByVal idLicitacion As Integer)
        VariablesBase.VariablesBase.IdLicitacionCargada = idLicitacion
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_DatosLicitacion(@IDLICITACION, @IDUSUARIO)", conexion)
        If idLicitacion > 0 Then
            comando.Parameters.AddWithValue("@IDLICITACION", idLicitacion)
        ElseIf VariablesBase.VariablesBase.IdLicitacionCargada > 0 Then
            comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        Else
            MsgBox("No se encontró ninguna licitación seleccionada.", MsgBoxStyle.Exclamation, "LICITACIÓN")
            Exit Sub
        End If
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtLicitacion As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtLicitacion, SchemaType.Source)
            adaptador.Fill(dtLicitacion)
            conexion.Close()

            'Asignaciones
            VariablesBase.VariablesBase.PermisoLicitacionOtorgado = dtLicitacion.Rows(0).Item("TIPOPERMISO")
            Lb_NombreLicitacion.Text = """" & dtLicitacion.Rows(0).Item("PROYECTO") & """"
            Me.Cursor = Cursors.WaitCursor
            ListarAPUItems(1)
            Nbc_Licitaciones.ActiveGroup = Nbg_APUItems
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgBox("No fue posible cargar los datos de la Licitación.", MsgBoxStyle.Critical, "Error Seleccionar Licitación")
        Finally
            conexion.Close()
        End Try
    End Sub


    'Opción de búsqueda de Licitaciones.
    Private Sub Nbi_BuscarLicitaciones_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_BuscarLicitaciones.ItemClick
        BuscarLicitacion()
    End Sub


    ''' <summary>
    ''' Abre el formulario de búsqueda para filtrar Licitaciones.
    ''' </summary>
    Private Sub BuscarLicitacion()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")

        campos.Rows.Add("NROLICITACION", "Número de Licitación", "1")
        campos.Rows.Add("PROYECTO", "Nombre del Proyecto", "1")
        campos.Rows.Add("CONTRATISTA", "Nombre del Contratista", "1")
        campos.Rows.Add("CLIENTE", "Nombre del Cliente", "1")
        campos.Rows.Add("FECHAREGISTRO", "Fecha de Registro", "3")
        campos.Rows.Add("USUARIOREGISTRO", "Nombre del Usuario que registró", "1")
        campos.Rows.Add("GERENCIA", "Gerencia a cargo", "1")
        campos.Rows.Add("1", "Licitaciones Inactivas", "4") 'CONSULTA ESPECIAL 1

        frbuscar.campos = campos
        frbuscar.tabla = 26
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsLicitacionesFiltro = DSbusqueda
        If Not IsNothing(dsLicitacionesFiltro) Then
            If dsLicitacionesFiltro.Tables.Count > 0 Then
                If dsLicitacionesFiltro.Tables(0).Rows.Count > 0 Then
                    CargarFiltro(DSbusqueda, TablaLicitaciones.Licitacion)
                Else
                    MsgBox("Ningún registro encontrado.", MsgBoxStyle.Exclamation, "Buscar Licitaciones")
                End If
            End If
        End If
    End Sub


    'Opción gestionar permisos de acceso a las Licitaciones.
    Private Sub Nbi_PermisosLicitacion_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_PermisosLicitacion.ItemClick
        'Superusuario asigna permisos a usuarios de L/E
        Using frAsignarPermisosLicitacion As New Fr_AsignarPermisosLicitacion
            frAsignarPermisosLicitacion.ShowDialog()
        End Using
        'Revisar permiso del Usuario actual después de la asignación
        ListarLicitaciones(3)
    End Sub


    'Opción Imprimir una Licitación.
    Private Sub Nbi_ImprimirLicitacion_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_ImprimirLicitacion.ItemClick
        If tablaCargada = TablaLicitaciones.Licitacion Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                ImprimirLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value)
            End If
        Else
            MsgBox("Por favor cargue el listado de Licitaciones.", MsgBoxStyle.Information, "Licitaciones")
        End If
    End Sub


    ''' <summary>
    ''' Permite la impresión de los A.P.U. de la licitación.
    ''' </summary>
    ''' <param name="idLicitacion">Licitación a imprimir.</param>
    Private Sub ImprimirLicitacion(ByVal idLicitacion As Integer)
        Using frOpcionesImpresion As New Fr_OpcionesImpresionLicitacion
            frOpcionesImpresion.IdLicitacion = idLicitacion
            frOpcionesImpresion.ShowDialog()
        End Using
    End Sub


    'Opción Eliminar una Licitación.
    Private Sub Nbi_EliminarLicitacion_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_EliminarLicitacion.ItemClick
        If tablaCargada = TablaLicitaciones.Licitacion Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                If Dgv_Lista.SelectedRows.Count = 1 Then
                    If Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value = TipoPermiso.Escritura Then
                        If MsgBox("¿Desea eliminar la Licitación " & Dgv_Lista.SelectedRows(0).Cells("NROLICITACION").Value & " - " & Dgv_Lista.SelectedRows(0).Cells("PROYECTO").Value & "?" & Environment.NewLine & "Este proceso es irreversible.", _
                                  MsgBoxStyle.YesNo, "Eliminar Licitación") = MsgBoxResult.Yes Then
                            Dim idLicitacion As Integer = Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value
                            EliminarUnaLicitacion(idLicitacion)
                            If VariablesBase.VariablesBase.IdLicitacionCargada = idLicitacion Then
                                VariablesBase.VariablesBase.IdLicitacionCargada = -1
                                VariablesBase.VariablesBase.PermisoLicitacionOtorgado = "N"
                                Lb_NombreLicitacion.Text = "LICITACIONES"
                            End If
                            ListarLicitaciones(3)
                        End If
                    End If
                ElseIf Dgv_Lista.SelectedRows.Count > 1 Then
                    If MsgBox("¿Desea eliminar las " & Dgv_Lista.SelectedRows.Count & " licitaciones seleccionadas?" & Environment.NewLine & "Este proceso es irreversible.", _
                              MsgBoxStyle.YesNo, "Eliminar Licitación") = MsgBoxResult.Yes Then
                        Dim dtLicitaciones As New DataTable
                        dtLicitaciones.Columns.Add("IDLICITACION")
                        For i As Integer = 0 To Dgv_Lista.SelectedRows.Count - 1
                            dtLicitaciones.Rows.Add(Dgv_Lista.SelectedRows(i).Cells("IDLICITACION").Value)
                        Next
                        EliminarLicitaciones(dtLicitaciones)
                        For j As Integer = 0 To dtLicitaciones.Rows.Count - 1
                            If dtLicitaciones.Rows(j).Item(0) = VariablesBase.VariablesBase.IdLicitacionCargada Then
                                VariablesBase.VariablesBase.IdLicitacionCargada = -1
                                VariablesBase.VariablesBase.PermisoLicitacionOtorgado = "N"
                                Lb_NombreLicitacion.Text = "LICITACIONES"
                                Exit For
                            End If
                        Next
                    End If
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Licitaciones.", MsgBoxStyle.Information, "Licitaciones")
        End If
    End Sub


    ''' <summary>
    ''' Elimina la licitación indicada incluyendo sus A.P.U.
    ''' </summary>
    ''' <param name="idLicitacion">Licitación a eliminar</param>
    Private Sub EliminarUnaLicitacion(ByVal idLicitacion As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLic_Licitacion", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TIPO", 3) 'Eliminar
        comando.Parameters.AddWithValue("@IDLICITACION", idLicitacion)
        comando.Parameters.AddWithValue("@NROLICITACION", DBNull.Value)
        comando.Parameters.AddWithValue("@PROYECTO", DBNull.Value)
        comando.Parameters.AddWithValue("@CONTRATISTA", DBNull.Value)
        comando.Parameters.AddWithValue("@CLIENTE", DBNull.Value)
        comando.Parameters.AddWithValue("@HORASDIARIAS", DBNull.Value)
        comando.Parameters.AddWithValue("@PORCENTAJEADMINISTRACION", DBNull.Value)
        comando.Parameters.AddWithValue("@PORCENTAJEIMPREVISTOS", DBNull.Value)
        comando.Parameters.AddWithValue("@PORCENTAJEUTILIDAD", DBNull.Value)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@ACTIVO", DBNull.Value)
        comando.Parameters.AddWithValue("@TIPOGERENCIA", DBNull.Value)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible eliminar la Licitación.", MsgBoxStyle.Critical, "Error Eliminar Licitación")
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dtLicitaciones"></param>
    Private Sub EliminarLicitaciones(ByVal dtLicitaciones As DataTable)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLic_EliminarLicitaciones", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TablaLicitaciones", dtLicitaciones)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.TinyInt)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible eliminar las Licitaciones.", MsgBoxStyle.Critical, "Error Eliminar Licitaciones")
        Finally
            conexion.Close()
        End Try
    End Sub


    'Opción Listar todos los Materiales de una Licitación.
    Private Sub Nbi_VerMateriales_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_VerMaterialesLicitacion.ItemClick
        If tablaCargada = TablaLicitaciones.Licitacion Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                If Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value = TipoPermiso.Lectura OrElse Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value = TipoPermiso.Escritura Then
                    VerRecursoLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value, FormulariosLicitaciones.TipoRecurso.Material)
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Licitaciones.", MsgBoxStyle.Information, "Licitaciones")
        End If
    End Sub


    'Opción Listar toda la Maquinaria y Equipo de una Licitación.
    Private Sub Nbi_VerMaquinariaYEquipo_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_VerMaquinariaYEquipo.ItemClick
        If tablaCargada = TablaLicitaciones.Licitacion Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                If Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value = TipoPermiso.Lectura OrElse Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value = TipoPermiso.Escritura Then
                    VerRecursoLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value, FormulariosLicitaciones.TipoRecurso.MaquinariaEquipo)
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Licitaciones.", MsgBoxStyle.Information, "Licitaciones")
        End If
    End Sub


    'Opción Listar toda la Mano de Obra de una Licitación.
    Private Sub Nbi_VerManoDeObra_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_VerManoDeObra.ItemClick
        If tablaCargada = TablaLicitaciones.Licitacion Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                If Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value = TipoPermiso.Lectura OrElse Dgv_Lista.SelectedRows(0).Cells("TIPOPERMISO").Value = TipoPermiso.Escritura Then
                    VerRecursoLicitacion(Dgv_Lista.SelectedRows(0).Cells("IDLICITACION").Value, FormulariosLicitaciones.TipoRecurso.ManoDeObra)
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Licitaciones.", MsgBoxStyle.Information, "Licitaciones")
        End If
    End Sub


    ''' <summary>
    ''' Abre el formulario con el listado del total del recurso indicado de una licitación.
    ''' </summary>
    ''' <param name="idLicitacion">Licitación de la cual se visualizan los recursos.</param>
    ''' <param name="recurso">Tipo de recurso a listar.</param>
    Private Sub VerRecursoLicitacion(ByVal idLicitacion As Integer, ByVal recurso As TipoRecurso)
        Using frRecursos As New Fr_Recursos
            frRecursos.Recurso = recurso
            frRecursos.IdLicitacion = idLicitacion
            frRecursos.ShowDialog()
        End Using
    End Sub

#End Region 'Licitación

#Region "APU Items"

    'Opción Cargar listado de Ítems A.P.U.
    Private Sub Nbi_CargarAPUItems_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_CargarItems.ItemClick
        If LicitacionEstaSeleccionada() Then
            If VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Lectura OrElse VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Escritura Then 'Verificar Permisos
                ListarAPUItems(1)
            End If
        End If
    End Sub


    ''' <summary>
    ''' Carga el listado inicial de Ítems A.P.U.
    ''' </summary>
    ''' <param name="tipo">
    ''' Tipo de listado.
    ''' 0: Todos los Ítems A.P.U. (incluyendo inactivos)
    ''' 1: Ítems A.P.U. activos.
    ''' </param>
    Sub ListarAPUItems(ByVal tipo As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.LIC_ListaAPU(@TIPO, @IDLICITACION) ORDER BY [NROITEMLICITACION]", conexion)
        comando.Parameters.AddWithValue("@TIPO", tipo)
        comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtAPUItems As New DataTable
        Try
            conexion.Open()
            adaptador.FillSchema(dtAPUItems, SchemaType.Source)
            adaptador.Fill(dtAPUItems)
            conexion.Close()
            tablaCargada = TablaLicitaciones.APU
            Dgv_Lista.ContextMenuStrip = Cms_OpcionesItems
            Dgv_Lista.DataSource = dtAPUItems
            OrganizarColumnasDgvLista()
            actualizarContadorRegistros()
            If dtAPUItems.Rows.Count > 0 Then
                FormatearCapitulos()
                Splitter1.Visible = True
                Sc_EquipoManoObra.Visible = True
                Tlp_Totales.Visible = True
            End If
        Catch ex As Exception
            MsgBox("No fue posible cargar el listado de Ítems A.P.U.", MsgBoxStyle.Critical, "Error Listar Ítems A.P.U.")
            Exit Sub
        Finally
            conexion.Close()
        End Try
        CalcularTotales()
    End Sub


    ''' <summary>
    ''' Aplica formato negrita a los capítulos en el listado de Ítems A.P.U.
    ''' </summary>
    Private Sub FormatearCapitulos()
        For i As Integer = 0 To Dgv_Lista.Rows.Count - 1
            Dim estiloNegrita As New DataGridViewCellStyle
            estiloNegrita.Font = New Font(Dgv_Lista.Font, FontStyle.Bold)
            If Dgv_Lista.Rows(i).Cells("ESCAPITULO").Value = "S" Then
                Dgv_Lista.Rows(i).DefaultCellStyle = estiloNegrita
            End If
        Next
    End Sub


    'Opción Crear un nuevo Ítem A.P.U.
    Private Sub Nbi_CrearAPU_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_CrearItems.ItemClick
        If LicitacionEstaSeleccionada() Then
            If VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Escritura Then
                If VariablesBase.VariablesBase.IdLicitacionCargada > 0 Then 'Condiciones
                    CrearAPU()
                    ListarAPUItems(1)
                End If
            End If
        End If
    End Sub


    ''' <summary>
    ''' Crear un nuevo Ítem A.P.U.
    ''' </summary>
    Private Sub CrearAPU()
        GestionarAPU(-1, TipoEdicion.Crear)
    End Sub

    'Opción Editar un Ítem A.P.U.
    Private Sub Nbi_EditarAPU_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_EditarItems.ItemClick
        If tablaCargada = TablaLicitaciones.APU Then
            If LicitacionEstaSeleccionada() Then
                If VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Escritura Then
                    If Dgv_Lista.SelectedRows.Count > 0 Then
                        Dim filaActual As Integer = Dgv_Lista.SelectedRows(0).Index
                        EditarAPU(Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
                        ListarAPUItems(1)
                        Dgv_Lista.ClearSelection()
                        UbicarRegistro(filaActual)
                    End If
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Ítems A.P.U.", MsgBoxStyle.Information, "Ítems A.P.U.")
        End If
    End Sub


    ''' <summary>
    ''' Editar los datos del Ítem A.P.U.
    ''' </summary>
    ''' <param name="idApu">Ítem A.P.U. a editar.</param>
    Private Sub EditarAPU(ByVal idApu As Integer)
        GestionarAPU(idApu, TipoEdicion.Editar)
    End Sub


    'Opción Clonar un Ítem A.P.U.
    Private Sub Nbi_ClonarItems_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_ClonarItems.ItemClick
        If tablaCargada = TablaLicitaciones.APU Then
            If LicitacionEstaSeleccionada() Then
                If VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Escritura Then
                    If Dgv_Lista.SelectedRows.Count > 0 Then
                        If Dgv_Lista.SelectedRows(0).Cells("ESCAPITULO").Value = "N" Then
                            ClonarAPU(Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
                            ListarAPUItems(1)
                        End If
                    End If
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Ítems A.P.U.", MsgBoxStyle.Information, "Ítems A.P.U.")
        End If
    End Sub


    ''' <summary>
    ''' Clonar un Ítem A.P.U.
    ''' </summary>
    ''' <param name="idApu">Ítem A.P.U. a partir del cual se genera el A.P.U. clonado.</param>
    Private Sub ClonarAPU(ByVal idApu As Integer)
        GestionarAPU(idApu, TipoEdicion.Clonar)
    End Sub


    ''' <summary>
    ''' Gestionar Ítems A.P.U.
    ''' </summary>
    ''' <param name="idApu">Opcional. Ítem A.P.U. que se va a gestionar.</param>
    ''' <param name="edicion">Indica el tipo de gestión que se realiza.</param>
    Private Sub GestionarAPU(ByVal idApu As Integer, ByVal edicion As TipoEdicion)
        Using frAPU As New Fr_APU
            frAPU.Edicion = edicion
            frAPU.IdAPU = idApu
            frAPU.ShowDialog()
        End Using
    End Sub


    'Opción Importar listado de Ítems desde una licitación existente.
    Private Sub Nbi_ImportarItems_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_ImportarItems.ItemClick
        If LicitacionEstaSeleccionada() Then
            If VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Escritura Then
                ImportarItemsDesdeOtraLicitacion()
                ListarAPUItems(1)
            End If
        End If
    End Sub


    ' Opción Importar estructura de Licitación.
    ' Abre el formulario para la importación de estructura de la licitación desde el portapapeles o un archivo en formato de Excel (.xls o .xlsx).
    Private Sub Nbi_ImportarEstructura_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImportarEstructura.ItemClick
        If LicitacionEstaSeleccionada() Then
            If VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Escritura Then
                Using frImportarEstructura As New Fr_ImportarEstructura
                    frImportarEstructura.ShowDialog()
                    Dim dtItems As DataTable
                    If frImportarEstructura.DialogResult = DialogResult.OK Then
                        dtItems = frImportarEstructura.GetDtItems
                        InterpretarValoresItemsImportados(dtItems)
                        GuardarItemsImportados(frImportarEstructura.GetDtItems)
                    End If
                End Using
                ListarAPUItems(1)
            End If
        End If
    End Sub


    ''' <summary>
    ''' Cambia el texto de las unidades ingresado en el archivo de importación de ítems por los códigos de unidades en la tabla maestra.
    ''' </summary>
    ''' <param name="dtItems">Tabla con los valores a interpretar.</param>
    Private Sub InterpretarValoresItemsImportados(dtItems As DataTable)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM dbo.ListarTipoUnidad()", conexion)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtUnidades As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtUnidades)
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            conexion.Close()
        End Try
        Dim resultados As DataRow()
        For i As Integer = 0 To dtItems.Rows.Count - 1
            If dtItems.Rows(i).Item("ESCAPITULO") = "N" Then
                resultados = dtUnidades.Select("ABREVIATURA = '" & dtItems.Rows(i).Item("UNIDAD").ToString & "' OR DESCRIPCION = '" & dtItems.Rows(i).Item("UNIDAD").ToString & "'")
                If resultados.Length > 0 Then
                    dtItems.Rows(i).Item("UNIDAD") = resultados(0).Item("CODIGO")
                Else
                    'Crear Unidad
                    Dim comando2 As New SqlCommand("dbo.GestionarTipoUnidad", conexion)
                    comando2.CommandType = CommandType.StoredProcedure
                    comando2.Parameters.AddWithValue("@TIPO", 0) 'Crear.
                    comando2.Parameters.AddWithValue("@CODIGOTIPOUNIDAD", DBNull.Value)
                    comando2.Parameters.AddWithValue("@ABREVIATURA", Trim(dtItems.Rows(i).Item("UNIDAD")).ToUpper)
                    comando2.Parameters.AddWithValue("@DESCRIPCION", Trim(dtItems.Rows(i).Item("UNIDAD")))
                    comando2.Parameters.AddWithValue("@CODIGOTIPOMEDIDA", 0)
                    comando2.Parameters.AddWithValue("@PERMITEDECIMALES", "N")
                    comando2.Parameters.AddWithValue("@ESTADOTIPOUNIDAD", "A")
                    comando2.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                    Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.TinyInt)
                    msgParam.Direction = ParameterDirection.Output
                    comando2.Parameters.Add(msgParam)
                    Try
                        conexion.Open()
                        comando2.ExecuteNonQuery()
                        conexion.Close()
                        dtItems.Rows(i).Item("UNIDAD") = msgParam.Value
                    Catch ex As Exception
                        dtItems.Rows(i).Item("UNIDAD") = "1"
                    Finally
                        conexion.Close()
                    End Try
                End If
            End If
        Next
    End Sub


    ''' <summary>
    ''' Guarda la Estructura Importada de Licitaciones.
    ''' </summary>
    ''' <param name="dtItems">Tabla de ítems importados.</param>
    Private Sub GuardarItemsImportados(dtItems As DataTable)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLIC_ImportarItems", conexion)
        comando.Parameters.AddWithValue("@TIPO", 0)
        comando.Parameters.AddWithValue("@TablaItems", dtItems)
        comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.TinyInt)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        comando.CommandType = CommandType.StoredProcedure
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible guardar la Estructura importada.", MsgBoxStyle.Critical, "Error Guardar Estructura de Licitación Importada")
        Finally
            conexion.Close()
        End Try
    End Sub


    'Opción buscar Ítems A.P.U.
    Private Sub Nbi_BuscarItems_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_BuscarItems.ItemClick
        BuscarAPU()
    End Sub


    ''' <summary>
    ''' Abrir el formulario de búsqueda para filtrar Ítems A.P.U.
    ''' </summary>
    Private Sub BuscarAPU()
        If LicitacionEstaSeleccionada() Then
            Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
            Dim campos As New DataTable
            campos.Clear()
            campos.Columns.Add("Nombre")
            campos.Columns.Add("Descripcion")
            campos.Columns.Add("Tipo")

            campos.Rows.Add("NROITEMCLIENTE", "Código del Ítem A.P.U.", "1")
            campos.Rows.Add("NROITEMLICITACION", "Número de Ítem", "2")
            campos.Rows.Add("DESCRIPCION", "Descripción", "1")
            campos.Rows.Add("CANTIDADESTIMADA", "Cantidad estimada", "2")
            campos.Rows.Add("VALORTOTALITEMSINAIU", "Valor total del Ítem sin AIU", "2")
            'campos.Rows.Add("VALORTOTALITEMCONAIU", "Valor total de Ítem con AIU", "2")
            campos.Rows.Add("RENDIMIENTO", "Rendimiento", "2")
            campos.Rows.Add("ABREVIATURA", "Tipo Unidad", "1")
            campos.Rows.Add("FECHAREGISTRO", "Fecha de Registro", "3")
            campos.Rows.Add("USUARIOREGISTRO", "Nombre del Usuario que registró", "1")
            campos.Rows.Add("1", "Ítems A.P.U. Inactivos", "4") 'CONSULTA ESPECIAL 1

            frbuscar.campos = campos
            frbuscar.tabla = 27
            frbuscar.ShowDialog()
            Dim DSbusqueda = frbuscar.DsBuscar
            dsLicitacionesFiltro = DSbusqueda
            If Not IsNothing(dsLicitacionesFiltro) Then
                If dsLicitacionesFiltro.Tables.Count > 0 Then
                    If dsLicitacionesFiltro.Tables(0).Rows.Count > 0 Then
                        CargarFiltro(DSbusqueda, TablaLicitaciones.APU)
                    Else
                        MsgBox("Ningún registro encontrado.", MsgBoxStyle.Exclamation, "Buscar Licitaciones")
                    End If
                End If
            End If
        End If
    End Sub


    'Opción exportar listado de ítems sin AIU a hoja de cálculo.
    Private Sub Nbi_ExportarItems_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_ExportarItems.ItemClick
        Dim idLicitacion As Integer = -1
        Dim listaItemsAPU As New DataTable
        listaItemsAPU.Columns.Add("IDAPU")

        If tablaCargada = TablaLicitaciones.APU AndAlso Dgv_Lista.SelectedRows.Count > 0 Then
            'If LicitacionEstaSeleccionada() Then 'redundante
            For i As Integer = 0 To Dgv_Lista.SelectedRows.Count - 1
                listaItemsAPU.Rows.Add(Dgv_Lista.SelectedRows(i).Cells("IDAPU").Value)
                idLicitacion = VariablesBase.VariablesBase.IdLicitacionCargada
            Next
            'End If
        Else
            'Mostrar Diálogo de selección de Ítems.
            Using frSeleccionarItems As New Fr_SeleccionarItems
                If VariablesBase.VariablesBase.IdLicitacionCargada > 0 Then
                    frSeleccionarItems.IdLicitacion = VariablesBase.VariablesBase.IdLicitacionCargada
                End If
                frSeleccionarItems.ShowDialog()
                If frSeleccionarItems.DialogResult = DialogResult.OK Then
                    If frSeleccionarItems.IdLicitacion > 0 Then
                        idLicitacion = frSeleccionarItems.IdLicitacion
                        listaItemsAPU = frSeleccionarItems.ListaItemsAPU
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End Using
        End If
        ExportarExcel_DetalleAPUsUnaHoja(idLicitacion, listaItemsAPU)
    End Sub


    'Opción Imprimir Ítem(s) A.P.U.
    Private Sub Nbi_ImprimirItems_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_ImprimirItems.ItemClick
        Dim idLicitacion As Integer = -1
        Dim listaItemsAPU As New DataTable
        listaItemsAPU.Columns.Add("IDAPU")

        If tablaCargada = TablaLicitaciones.APU AndAlso Dgv_Lista.SelectedRows.Count > 0 Then
            'If LicitacionEstaSeleccionada() Then 'redundante
            For i As Integer = 0 To Dgv_Lista.SelectedRows.Count - 1
                listaItemsAPU.Rows.Add(Dgv_Lista.SelectedRows(i).Cells("IDAPU").Value)
                idLicitacion = VariablesBase.VariablesBase.IdLicitacionCargada
            Next
            'End If
        Else
            'Mostrar Diálogo de selección de Ítems.
            Using frSeleccionarItems As New Fr_SeleccionarItems
                If VariablesBase.VariablesBase.IdLicitacionCargada > 0 Then
                    frSeleccionarItems.IdLicitacion = VariablesBase.VariablesBase.IdLicitacionCargada
                End If
                frSeleccionarItems.ShowDialog()
                If frSeleccionarItems.DialogResult = DialogResult.OK Then
                    If frSeleccionarItems.IdLicitacion > 0 Then
                        idLicitacion = frSeleccionarItems.IdLicitacion
                        listaItemsAPU = frSeleccionarItems.ListaItemsAPU
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End Using
        End If
        ImprimirItemsAPU(listaItemsAPU, idLicitacion)
    End Sub


    ''' <summary>
    ''' Permite la impresión de Ítems A.P.U.
    ''' </summary>
    ''' <param name="listadoAPU">Listado con los identificadores de los Ítems a imprimir.</param>
    Private Sub ImprimirItemsAPU(ByVal listadoAPU As DataTable, Optional ByVal idLicitacion As Integer = -1)
        Dim climpresiones As New ImpresiónLicitaciones.Cl_Impresión
        Dim ListadoDocumentos As New ArrayList
        ListadoDocumentos.Add(2)
        climpresiones.IdLicitacion = idLicitacion
        climpresiones.listadoAPU = listadoAPU
        climpresiones.FormatoImprimirLicitaciones(ListadoDocumentos, True, False)
        MsgBox("Impresión finalizada.", MsgBoxStyle.Information, "Impresión Items A.P.U.")
    End Sub


    'Opción Eliminar un Ítem A.P.U.
    Private Sub Nbi_EliminarItems_ItemClick(ByVal sender As Object, ByVal e As EventArgs) Handles Nbi_EliminarItems.ItemClick
        If tablaCargada = TablaLicitaciones.APU Then
            If LicitacionEstaSeleccionada() Then
                If VariablesBase.VariablesBase.PermisoLicitacionOtorgado = TipoPermiso.Escritura Then
                    If Dgv_Lista.SelectedRows.Count > 0 Then
                        If Dgv_Lista.SelectedRows.Count = 1 Then
                            If MsgBox("¿Desea eliminar el Ítem A.P.U. " & _
                                      If(Not IsDBNull(Dgv_Lista.SelectedRows(0).Cells("NROITEMCLIENTE").Value), Dgv_Lista.SelectedRows(0).Cells("NROITEMCLIENTE").Value, "#" & Dgv_Lista.SelectedRows(0).Cells("NROITEMLICITACION").Value) & _
                                      " - " & Dgv_Lista.SelectedRows(0).Cells("DESCRIPCION").Value & "?" & Environment.NewLine & "Este proceso es irreversible.", _
                                      MsgBoxStyle.YesNo, "Eliminar Ítem A.P.U.") = MsgBoxResult.Yes Then
                                EliminarUnAPU(Dgv_Lista.SelectedRows(0).Cells("IDAPU").Value)
                                ListarAPUItems(1)
                            End If
                        ElseIf Dgv_Lista.SelectedRows.Count > 1 Then
                            If MsgBox("¿Desea eliminar los " & Dgv_Lista.SelectedRows.Count & " Ítems A.P.U. seleccionados?" & Environment.NewLine & "Este proceso es irreversible.", _
                                      MsgBoxStyle.YesNo, "Eliminar Ítems A.P.U.") = MsgBoxResult.Yes Then
                                Dim dtItemsAPU As New DataTable
                                dtItemsAPU.Columns.Add("IDAPU")
                                For i As Integer = 0 To Dgv_Lista.SelectedRows.Count - 1
                                    dtItemsAPU.Rows.Add(Dgv_Lista.SelectedRows(i).Cells("IDAPU").Value)
                                Next
                                EliminarItemsAPU(dtItemsAPU)
                                ListarAPUItems(1)
                            End If
                        End If
                    End If
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Ítems A.P.U.", MsgBoxStyle.Information, "Ítems A.P.U.")
        End If
    End Sub


    ''' <summary>
    ''' Elimina el Ítem A.P.U. indicado incluyendo sus recursos.
    ''' </summary>
    ''' <param name="idAPU">Ítem A.P.U. a eliminar.</param>
    Private Sub EliminarUnAPU(ByVal idAPU As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLIC_APU", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TIPO", 3) 'Eliminar
        comando.Parameters.AddWithValue("@Tabla_APU_Material", Nothing)
        comando.Parameters.AddWithValue("@Tabla_APU_MaquinariaYEquipo", Nothing)
        comando.Parameters.AddWithValue("@Tabla_APU_ManoDeObra", Nothing)
        comando.Parameters.AddWithValue("@IDAPU", idAPU)
        comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        comando.Parameters.AddWithValue("@NROITEMLICITACION", DBNull.Value)
        comando.Parameters.AddWithValue("@NROITEMCLIENTE", DBNull.Value)
        comando.Parameters.AddWithValue("@ESCAPITULO", DBNull.Value)
        comando.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value)
        comando.Parameters.AddWithValue("@CODIGOTIPOUNIDAD", DBNull.Value)
        comando.Parameters.AddWithValue("@CANTIDADESTIMADA", DBNull.Value)
        comando.Parameters.AddWithValue("@VALORTOTALITEMSINAIU", DBNull.Value)
        comando.Parameters.AddWithValue("@VALORTOTALITEMCONAIU", DBNull.Value)
        comando.Parameters.AddWithValue("@TOTALHORASHOMBRE", DBNull.Value)
        comando.Parameters.AddWithValue("@RENDIMIENTO", DBNull.Value)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible eliminar el Ítem A.P.U.", MsgBoxStyle.Critical, "Error Eliminar Ítem A.P.U.")
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dtItemsAPU"></param>
    Private Sub EliminarItemsAPU(ByVal dtItemsAPU As DataTable)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLIC_EliminarItemsAPU", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TablaItemsAPU", dtItemsAPU)
        comando.Parameters.AddWithValue("@IDLICITACION", VariablesBase.VariablesBase.IdLicitacionCargada)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible eliminar los Ítems A.P.U.", MsgBoxStyle.Critical, "Error Eliminar Ítems A.P.U.")
        Finally
            conexion.Close()
        End Try
    End Sub


    ''' <summary>
    ''' Abre el formulario de selección de ítems para indicar qué ítems en específico se agregarán a la licitación actual a partir de una licitación existente.
    ''' </summary>
    Private Sub ImportarItemsDesdeOtraLicitacion()
        If LicitacionEstaSeleccionada() Then
            'Mostrar Diálogo de selección de Ítems.
            Using frSeleccionarItems As New Fr_SeleccionarItems
                frSeleccionarItems.ShowDialog()
                If frSeleccionarItems.DialogResult = DialogResult.OK Then
                    If frSeleccionarItems.IdLicitacion > 0 Then
                        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                        Dim comando As New SqlCommand("dbo.GestionarLIC_ClonarItemsAPU", conexion)
                        comando.CommandType = CommandType.StoredProcedure
                        comando.Parameters.AddWithValue("@TIPO", 0) 'No aplica
                        comando.Parameters.AddWithValue("@TablaItemsAPU", frSeleccionarItems.ListaItemsAPU)
                        comando.Parameters.AddWithValue("@IDLICITACION_ORIGEN", frSeleccionarItems.IdLicitacion)
                        comando.Parameters.AddWithValue("@IDLICITACION_DESTINO", VariablesBase.VariablesBase.IdLicitacionCargada)
                        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                        Dim msjParam As New SqlParameter("@IDMENSAJE", SqlDbType.TinyInt)
                        msjParam.Direction = ParameterDirection.Output
                        comando.Parameters.Add(msjParam)
                        Try
                            conexion.Open()
                            comando.ExecuteNonQuery()
                            conexion.Close()
                        Catch ex As Exception
                            MsgBox("No fue posible importar los ítems de la licitación.", MsgBoxStyle.Critical, "Importar Ítems A.P.U.")
                        Finally
                            conexion.Close()
                        End Try
                    End If
                End If
            End Using
        End If
    End Sub

#End Region 'APU Items

#Region "Materiales"

    'Opción listar tabla maestra de Materiales.
    Private Sub Nbi_CargarMateriales_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarMateriales.ItemClick
        ListarMateriales(1)
    End Sub


    ''' <summary>
    ''' Carga el listado inicial de Materiales.
    ''' </summary>
    ''' <param name="tipo">
    ''' Tipo de listado.
    ''' 0: Todos los materiales (incluyendo inactvos).
    ''' 1: Materiales activos.
    '''</param>
    Private Sub ListarMateriales(ByVal tipo As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM LIC_ListaMaterial(@TIPO, @IDUSUARIO) ORDER BY [IDMATERIAL]", conexion)
        comando.Parameters.AddWithValue("@TIPO", tipo) 'Materiales Activos
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtMateriales As New DataTable
        'Dgv_Lista.DataSource = Nothing
        Try
            conexion.Open()
            adaptador.FillSchema(dtMateriales, SchemaType.Source)
            adaptador.Fill(dtMateriales)
            conexion.Close()
            tablaCargada = TablaLicitaciones.Material
            Dgv_Lista.ContextMenuStrip = Cms_OpcionesMaterial
            Dgv_Lista.DataSource = dtMateriales
            OrganizarColumnasDgvLista()
            actualizarContadorRegistros()
            Splitter1.Visible = False
            Sc_EquipoManoObra.Visible = False
            Tlp_Totales.Visible = False
        Catch ex As Exception
            MsgBox("No fue posible cargar el listado de Materiales.", MsgBoxStyle.Critical, "Error Listar Materiales")
        Finally
            conexion.Close()
        End Try
    End Sub


    'Opción crear un nuevo Material.
    Private Sub Nbi_CrearMaterial_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearMaterial.ItemClick
        CrearMaterial()
        ListarMateriales(1)
    End Sub


    ''' <summary>
    ''' Crear un nuevo Material.
    ''' </summary>
    Private Sub CrearMaterial()
        GestionarMaterial(-1, TipoEdicion.Crear)
    End Sub


    'Opción modificar los datos de un Material.
    Private Sub Nbi_EditarMaterial_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarMaterial.ItemClick
        If tablaCargada = TablaLicitaciones.Material Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                Dim filaActual As Integer = Dgv_Lista.SelectedRows(0).Index
                EditarMaterial(Dgv_Lista.SelectedRows(0).Cells("IDMATERIAL").Value)
                ListarMateriales(1)
                Dgv_Lista.ClearSelection()
                UbicarRegistro(filaActual)
            End If
        Else
            MsgBox("Por favor cargue el listado de Materiales", MsgBoxStyle.Information, "Materiales")
        End If
    End Sub


    ''' <summary>
    ''' Editar los datos de un Material.
    ''' </summary>
    ''' <param name="idMaterial">Material a editar.</param>
    Private Sub EditarMaterial(ByVal idMaterial As Integer)
        GestionarMaterial(idMaterial, TipoEdicion.Editar)
    End Sub


    'Opción clonar un Material a partir de otro.
    Private Sub Nbi_ClonarMaterial_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ClonarMaterial.ItemClick
        If tablaCargada = TablaLicitaciones.Material Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                ClonarMaterial(Dgv_Lista.SelectedRows(0).Cells("IDMATERIAL").Value)
                ListarMateriales(1)
            End If
        Else
            MsgBox("Por favor cargue el listado de Materiales", MsgBoxStyle.Information, "Materiales")
        End If
    End Sub


    ''' <summary>
    ''' Clonar un Material.
    ''' </summary>
    ''' <param name="idMaterial">Material a partir del cual se genera el Material clonado.</param>
    Private Sub ClonarMaterial(ByVal idMaterial As Integer)
        GestionarMaterial(idMaterial, TipoEdicion.Clonar)
    End Sub


    ''' <summary>
    ''' Gestionar Material.
    ''' </summary>
    ''' <param name="idMaterial">Opcional. Material que se va a gestionar.</param>
    ''' <param name="edicion">Indica el tipo de gestíón que se realiza.</param>
    Private Sub GestionarMaterial(ByVal idMaterial As Integer, ByVal edicion As TipoEdicion)
        Using frMaterial As New Fr_Material
            frMaterial.IdMaterial = idMaterial
            frMaterial.Edicion = edicion
            frMaterial.ShowDialog()
        End Using
    End Sub


    'Opción buscar Materiales.
    Private Sub Nbi_BuscarMaterial_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarMaterial.ItemClick
        BuscarMaterial()
    End Sub


    ''' <summary>
    ''' Abre el formulario de búsqueda para filtrar Materiales.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BuscarMaterial()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")

        campos.Rows.Add("IDMATERIAL", "Código Material", "2")
        campos.Rows.Add("DESCRIPCION", "Descripción del Material", "1")
        campos.Rows.Add("FECHAREGISTRO", "Fecha de Registro", "3")
        campos.Rows.Add("USUARIOREGISTRO", "Nombre del Usuario que registró", "1")
        campos.Rows.Add("1", "Materiales Inactivos", "4") 'CONSULTA ESPECIAL 1

        frbuscar.campos = campos
        frbuscar.tabla = 28
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsLicitacionesFiltro = DSbusqueda
        If Not IsNothing(dsLicitacionesFiltro) Then
            If dsLicitacionesFiltro.Tables.Count > 0 Then
                If dsLicitacionesFiltro.Tables(0).Rows.Count > 0 Then
                    CargarFiltro(DSbusqueda, TablaLicitaciones.Material)
                Else
                    MsgBox("Ningún registro encontrado.", MsgBoxStyle.Exclamation, "Buscar Materiales")
                End If
            End If
        End If
    End Sub


    'Opción eliminar un Material.
    Private Sub Nbi_EliminarMaterial_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EliminarMaterial.ItemClick
        If tablaCargada = TablaLicitaciones.Material Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                If MsgBox("¿Desea eliminar el Material " & Dgv_Lista.SelectedRows(0).Cells("IDMATERIAL").Value & " - " & Dgv_Lista.SelectedRows(0).Cells("DESCRIPCION").Value & "?" & Environment.NewLine & "Este proceso es irreversible.", _
                          MsgBoxStyle.YesNo, "Eliminar Material") = MsgBoxResult.Yes Then
                    EliminarMaterial(Dgv_Lista.SelectedRows(0).Cells("IDMATERIAL").Value)
                    ListarMateriales(1)
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Materiales", MsgBoxStyle.Information, "Materiales")
        End If
    End Sub


    ''' <summary>
    ''' Eliminar el Material indicado.
    ''' </summary>
    ''' <param name="idMaterial">Material a eliminar.</param>
    Private Sub EliminarMaterial(ByVal idMaterial As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLIC_Material", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TIPO", 3) 'Eliminar
        comando.Parameters.AddWithValue("@IDMATERIAL", idMaterial)
        comando.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value)
        comando.Parameters.AddWithValue("@CODIGOTIPOUNIDAD", DBNull.Value)
        comando.Parameters.AddWithValue("@IDARTICULO", DBNull.Value)
        comando.Parameters.AddWithValue("@VALORISMOCOL", DBNull.Value)
        comando.Parameters.AddWithValue("@VALORCOMERCIAL", DBNull.Value)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@ACTIVO", DBNull.Value)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible eliminar el Material.", MsgBoxStyle.Critical, "Error Eliminar Material")
        Finally
            conexion.Close()
        End Try
    End Sub

#End Region 'Materiales

#Region "Maquinaria y Equipos"

    'Opción listar la tabla maestra de Maquinaria y Equipos.
    Private Sub Nbi_CargarEquipos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarEquipos.ItemClick
        ListarEquipos(1)
    End Sub


    ''' <summary>
    ''' Cargar el listado inicial de Maquinaria y Equipo.
    ''' </summary>
    ''' <param name="tipo">
    ''' Tipo de listado.
    ''' 0: Toda la Maquinaria y Equipo (incluyendo inactivos).
    ''' 1: Maquinaria y Equipo activo.
    ''' </param>
    Private Sub ListarEquipos(ByVal tipo As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM LIC_ListaMaquinariaYEquipo(@TIPO, @IDUSUARIO) ORDER BY [IDMAQUINARIAYEQUIPO]", conexion)
        comando.Parameters.AddWithValue("@TIPO", tipo) 'Maquinaria y Equipos Activos
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtMaquinariaEquipo As New DataTable
        'Dgv_Lista.DataSource = Nothing
        Try
            conexion.Open()
            adaptador.FillSchema(dtMaquinariaEquipo, SchemaType.Source)
            adaptador.Fill(dtMaquinariaEquipo)
            conexion.Close()
            tablaCargada = TablaLicitaciones.Equipo
            Dgv_Lista.ContextMenuStrip = Cms_OpcionesEquipos
            Dgv_Lista.DataSource = dtMaquinariaEquipo
            OrganizarColumnasDgvLista()
            actualizarContadorRegistros()
            Splitter1.Visible = False
            Sc_EquipoManoObra.Visible = False
            Tlp_Totales.Visible = False
        Catch ex As Exception
            MsgBox("No fue posible cargar el listado de Maquinaria y Equipos.", MsgBoxStyle.Critical, "Error Listar Maquinaria y Equipos")
        Finally
            conexion.Close()
        End Try
    End Sub


    'Opción crear una nueva Maquinaria y Equipo.
    Private Sub Nbi_CrearEquipo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearEquipo.ItemClick
        CrearEquipo()
        ListarEquipos(1)
    End Sub


    ''' <summary>
    ''' Crear una nueva Maquinaria.
    ''' </summary>
    Private Sub CrearEquipo()
        GestionarEquipo(-1, TipoEdicion.Crear)
    End Sub


    'Opción modificar los datos y recursos asociados de una Maquinaria y Equipo.
    Private Sub Nbi_EditarEquipo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarEquipo.ItemClick
        If tablaCargada = TablaLicitaciones.Equipo Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                Dim filaActual As Integer = Dgv_Lista.SelectedRows(0).Index
                EditarEquipo(Dgv_Lista.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value)
                ListarEquipos(1)
                Dgv_Lista.ClearSelection()
                UbicarRegistro(filaActual)
            End If
        Else
            MsgBox("Por favor cargue el listado de Maquinaria y Equipo", MsgBoxStyle.Information, "Maquinaria y Equipo")
        End If
    End Sub


    ''' <summary>
    ''' Editar los datos de una Maquinaria.
    ''' </summary>
    ''' <param name="idMaquinariaEquipo">Maquinaria y Equipo a editar.</param>
    Private Sub EditarEquipo(ByVal idMaquinariaEquipo As Integer)
        GestionarEquipo(idMaquinariaEquipo, TipoEdicion.Editar)
    End Sub


    'Opción clonar una Maquinaria y Equipo a partir de otro.
    Private Sub Nbi_ClonarEquipo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ClonarEquipo.ItemClick
        If tablaCargada = TablaLicitaciones.Equipo Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                ClonarEquipo(Dgv_Lista.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value)
                ListarEquipos(1)
            End If
        Else
            MsgBox("Por favor cargue el listado de Maquinaria y Equipo", MsgBoxStyle.Information, "Maquinaria y Equipo")
        End If
    End Sub


    ''' <summary>
    ''' Clonar una Maquinaria
    ''' </summary>
    ''' <param name="idMaquinariaEquipo">Maquinaria a partir de la cual se genera la Maquinaria clonada.</param>
    Private Sub ClonarEquipo(ByVal idMaquinariaEquipo As Integer)
        GestionarEquipo(idMaquinariaEquipo, TipoEdicion.Clonar)
        ListarEquipos(1)
    End Sub


    ''' <summary>
    ''' Gestionar Maquinaria y Equipo.
    ''' </summary>
    ''' <param name="idMaquinariaEquipo">Opcional. Maquinaria que se va a gestionar.</param>
    ''' <param name="tipoEdicion">Indica el tipo de gestión que se realiza.</param>
    Private Sub GestionarEquipo(ByVal idMaquinariaEquipo As Integer, ByVal tipoEdicion As TipoEdicion)
        Using frMaquinariaEquipo As New Fr_MaquinariaEquipo
            frMaquinariaEquipo.IdMaquinariaEquipo = idMaquinariaEquipo
            frMaquinariaEquipo.Edicion = tipoEdicion
            frMaquinariaEquipo.ShowDialog()
        End Using
    End Sub


    'Opción buscar Maquinaria y Equipo.
    Private Sub Nbi_BuscarEquipo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarEquipo.ItemClick
        BuscarEquipo()
    End Sub


    ''' <summary>
    ''' Abre el formulario de búsqueda para filtrar Maquinaria y Equipo.
    ''' </summary>
    Private Sub BuscarEquipo()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")

        campos.Rows.Add("IDMAQUINARIAYEQUIPO", "Código Maquinaria y Equipo", "2")
        campos.Rows.Add("DESCRIPCION", "Descripción de Maquinaria y Equipo", "1")
        campos.Rows.Add("FECHAREGISTRO", "Fecha de Registro", "3")
        campos.Rows.Add("USUARIOREGISTRO", "Nombre del Usuario que registró", "1")
        campos.Rows.Add("1", "Maquinaria y Equipo Inactivo", "4") 'CONSULTA ESPECIAL 1

        frbuscar.campos = campos
        frbuscar.tabla = 29
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsLicitacionesFiltro = DSbusqueda
        If Not IsNothing(dsLicitacionesFiltro) Then
            If dsLicitacionesFiltro.Tables.Count > 0 Then
                If dsLicitacionesFiltro.Tables(0).Rows.Count > 0 Then
                    CargarFiltro(DSbusqueda, TablaLicitaciones.Equipo)
                Else
                    MsgBox("Ningún registro encontrado.", MsgBoxStyle.Exclamation, "Buscar Maquinaria y Equipo")
                End If
            End If
        End If
    End Sub


    'Opción eliminar una Maquinaria y Equipo incluyendo recursos asociados.
    Private Sub Nbi_EliminarEquipo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EliminarEquipo.ItemClick
        If tablaCargada = TablaLicitaciones.Equipo Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                If MsgBox("¿Desea eliminar la Maquinaria y Equipo Cód: " & Dgv_Lista.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value & " - " & Dgv_Lista.SelectedRows(0).Cells("DESCRIPCION").Value & "?" & Environment.NewLine & "Este proceso es irreversible.", _
                          MsgBoxStyle.YesNo, "Eliminar Maquinaria y Equipo") = MsgBoxResult.Yes Then
                    EliminarEquipo(Dgv_Lista.SelectedRows(0).Cells("IDMAQUINARIAYEQUIPO").Value)
                    ListarEquipos(1)
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Maquinaria y Equipo", MsgBoxStyle.Information, "Maquinaria y Equipo")
        End If
    End Sub


    ''' <summary>
    ''' Eliminar la Maquinaria indicada.
    ''' </summary>
    ''' <param name="idMaquinariaEquipo">Maquinaria y Equipo a eliminar.</param>
    Private Sub EliminarEquipo(ByVal idMaquinariaEquipo As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLIC_MaquinariaYEquipo", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TIPO", 3) 'Eliminar
        comando.Parameters.AddWithValue("@IDMAQUINARIAYEQUIPO", idMaquinariaEquipo)
        comando.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value)
        comando.Parameters.AddWithValue("@IDARTICULO", DBNull.Value)
        comando.Parameters.AddWithValue("@TARIFAISMOCOLXHORA", DBNull.Value)
        comando.Parameters.AddWithValue("@TARIFACOMERCIALXHORA", DBNull.Value)
        comando.Parameters.AddWithValue("@COMBUSTIBLEXHORA", DBNull.Value)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@ACTIVO", DBNull.Value)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible eliminar la Maquinaria.", MsgBoxStyle.Critical, "Error Eliminar Maquinaria y Equipos")
        Finally
            conexion.Close()
        End Try
    End Sub

#End Region 'Maquinaria y Equipos

#Region "Mano de Obra"

    'Opción listar la tabla maestra de Mano de Obra.
    Private Sub Nbi_CargarManoDeObra_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CargarManoDeObra.ItemClick
        ListarManoDeObra(1)
    End Sub


    ''' <summary>
    ''' Carga el listado inicial de Mano de Obra.
    ''' </summary>
    ''' <param name="tipo">
    ''' Tipo de listado.
    ''' 0: Toda la Mano de Obra (incluyendo inactiva).
    ''' 1: Mano de Obra activa.
    '''</param>
    Private Sub ListarManoDeObra(ByVal tipo As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM LIC_ListaManoDeObra(@TIPO, @IDUSUARIO) ORDER BY [IDMANODEOBRA]", conexion)
        comando.Parameters.AddWithValue("@TIPO", tipo) 'Mano de Obra Activa
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtManoDeObra As New DataTable
        'Dgv_Lista.DataSource = Nothing
        Try
            conexion.Open()
            adaptador.FillSchema(dtManoDeObra, SchemaType.Source)
            adaptador.Fill(dtManoDeObra)
            conexion.Close()
            tablaCargada = TablaLicitaciones.ManoDeObra
            Dgv_Lista.ContextMenuStrip = Cms_OpcionesManoDeObra
            Dgv_Lista.DataSource = dtManoDeObra
            OrganizarColumnasDgvLista()
            actualizarContadorRegistros()
            Splitter1.Visible = False
            Sc_EquipoManoObra.Visible = False
            Tlp_Totales.Visible = False
        Catch ex As Exception
            MsgBox("No fue posible cargar el listado de Mano de Obra.", MsgBoxStyle.Critical, "Error Listar Mano de Obra")
        Finally
            conexion.Close()
        End Try
    End Sub


    'Opción crear una nueva Mano de Obra.
    Private Sub Nbi_CrearManoDeObra_ItemClick(sender As Object, e As EventArgs) Handles Nbi_CrearManoDeObra.ItemClick
        CrearManoDeObra()
        ListarManoDeObra(1)
    End Sub


    ''' <summary>
    ''' Crear nueva Mano de Obra.
    ''' </summary>
    Private Sub CrearManoDeObra()
        GestionarManoDeObra(-1, TipoEdicion.Crear)
    End Sub


    'Opción modificar los datos de una Mano de Obra.
    Private Sub Nbi_EditarManoDeObra_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarManoDeObra.ItemClick
        If tablaCargada = TablaLicitaciones.ManoDeObra Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                Dim filaActual As Integer = Dgv_Lista.SelectedRows(0).Index
                EditarManoDeObra(Dgv_Lista.SelectedRows(0).Cells("IDMANODEOBRA").Value)
                ListarManoDeObra(1)
                Dgv_Lista.ClearSelection()
                UbicarRegistro(filaActual)
            End If
        Else
            MsgBox("Por favor cargue el listado de Mano de Obra", MsgBoxStyle.Information, "Mano de Obra")
        End If
    End Sub


    ''' <summary>
    ''' Editar los datos de una Mano de Obra.
    ''' </summary>
    ''' <param name="idManoDeObra">Mano de Obra a editar.</param>
    Private Sub EditarManoDeObra(ByVal idManoDeObra As Integer)
        GestionarManoDeObra(idManoDeObra, TipoEdicion.Editar)
    End Sub


    'Opción clonar una Mano de Obra a partir de otra.
    Private Sub Nbi_ClonarManoDeObra_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ClonarManoDeObra.ItemClick
        If tablaCargada = TablaLicitaciones.ManoDeObra Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                ClonarManoDeObra(Dgv_Lista.SelectedRows(0).Cells("IDMANODEOBRA").Value)
                ListarManoDeObra(1)
            End If
        Else
            MsgBox("Por favor cargue el listado de Mano de Obra", MsgBoxStyle.Information, "Mano de Obra")
        End If
    End Sub


    ''' <summary>
    ''' Clonar Mano de Obra.
    ''' </summary>
    ''' <param name="idManoDeObra">Mano de Obra a partir de la cual se genera la Mano de Obra clonada.</param>
    Private Sub ClonarManoDeObra(ByVal idManoDeObra As Integer)
        GestionarManoDeObra(idManoDeObra, TipoEdicion.Clonar)
    End Sub


    ''' <summary>
    ''' Gestionar Mano de Obra.
    ''' </summary>
    ''' <param name="idManoDeObra">Opcional. Mano de obra que se va a gestionar.</param>
    ''' <param name="edicion">Indica el tipo de gestión que se realiza.</param>
    Private Sub GestionarManoDeObra(ByVal idManoDeObra As Integer, ByVal edicion As TipoEdicion)
        Using frManoDeObra As New Fr_ManoDeObra
            frManoDeObra.IdManoDeObra = idManoDeObra
            frManoDeObra.Edicion = edicion
            frManoDeObra.ShowDialog()
        End Using
    End Sub


    'Opción buscar Mano de Obra.
    Private Sub Nbi_BuscarManoDeObra_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarManoDeObra.ItemClick
        BuscarManoDeObra()
    End Sub


    ''' <summary>
    ''' Abre el formulario de búsqueda para filtrar Mano de Obra.
    ''' </summary>
    Private Sub BuscarManoDeObra()
        Dim frbuscar As New FormulariosClasesBase.Fr_Busquedas
        Dim campos As New DataTable
        campos.Clear()
        campos.Columns.Add("Nombre")
        campos.Columns.Add("Descripcion")
        campos.Columns.Add("Tipo")

        campos.Rows.Add("IDMANODEOBRA", "Código Mano de Obra", "2")
        campos.Rows.Add("DESCRIPCION", "Descripción de la Mano de Obra", "1")
        campos.Rows.Add("FECHAREGISTRO", "Fecha de Registro", "3")
        campos.Rows.Add("USUARIOREGISTRO", "Nombre del Usuario que registró", "1")
        campos.Rows.Add("1", "Mano de Obra Inactiva", "4") 'CONSULTA ESPECIAL 1

        frbuscar.campos = campos
        frbuscar.tabla = 30
        frbuscar.ShowDialog()
        Dim DSbusqueda = frbuscar.DsBuscar
        dsLicitacionesFiltro = DSbusqueda
        If Not IsNothing(dsLicitacionesFiltro) Then
            If dsLicitacionesFiltro.Tables.Count > 0 Then
                If dsLicitacionesFiltro.Tables(0).Rows.Count > 0 Then
                    CargarFiltro(DSbusqueda, TablaLicitaciones.ManoDeObra)
                Else
                    MsgBox("Ningún registro encontrado.", MsgBoxStyle.Exclamation, "Buscar Materiales")
                End If
            End If
        End If
    End Sub


    'Opción eliminar una Mano de Obra.
    Private Sub Nbi_EliminarManoDeObra_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EliminarManoDeObra.ItemClick
        If tablaCargada = TablaLicitaciones.ManoDeObra Then
            If Dgv_Lista.SelectedRows.Count > 0 Then
                If MsgBox("¿Desea eliminar la Mano de Obra Cód: " & Dgv_Lista.SelectedRows(0).Cells("IDMANODEOBRA").Value & " - " & Dgv_Lista.SelectedRows(0).Cells("DESCRIPCION").Value & "?" & Environment.NewLine & "Este proceso es irreversible.", _
                          MsgBoxStyle.YesNo, "Eliminar Mano de Obra") = MsgBoxResult.Yes Then
                    EliminarManoDeObra(Dgv_Lista.SelectedRows(0).Cells("IDMANODEOBRA").Value)
                    ListarManoDeObra(1)
                End If
            End If
        Else
            MsgBox("Por favor cargue el listado de Mano de Obra", MsgBoxStyle.Information, "Mano de Obra")
        End If
    End Sub


    ''' <summary>
    ''' Eliminar la Mano de Obra indicada.
    ''' </summary>
    ''' <param name="idManoDeObra">Mano de Obra a eliminar.</param>
    Private Sub EliminarManoDeObra(ByVal idManoDeObra As Integer)
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.GestionarLIC_ManoDeObra", conexion)
        comando.CommandType = CommandType.StoredProcedure
        comando.Parameters.AddWithValue("@TIPO", 3) 'Eliminar
        comando.Parameters.AddWithValue("@IDMANODEOBRA", idManoDeObra)
        comando.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value)
        comando.Parameters.AddWithValue("@TARIFAISMOCOLXHORAHOMBRE", DBNull.Value)
        comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        comando.Parameters.AddWithValue("@ACTIVO", DBNull.Value)
        Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.Int)
        msgParam.Direction = ParameterDirection.Output
        comando.Parameters.Add(msgParam)
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            MsgBox("No fue posible eliminar la Mano de Obra.", MsgBoxStyle.Critical, "Error Eliminar Mano de Obra")
        Finally
            conexion.Close()
        End Try
    End Sub

#End Region 'Mano de Obra

#Region "Herramientas"

    ' 
    Private Sub Nbi_Soldadura_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Soldadura.ItemClick

    End Sub


    ' 
    Private Sub Nbi_DiscosyGratas_ItemClick(sender As Object, e As EventArgs) Handles Nbi_DiscosyGratas.ItemClick

    End Sub


    ' 
    Private Sub Nbi_Revestimiento_ItemClick(sender As Object, e As EventArgs) Handles Nbi_Revestimiento.ItemClick

    End Sub


    ' 
    Private Sub Nbi_OxígenoAcetileno_ItemClick(sender As Object, e As EventArgs) Handles Nbi_OxígenoAcetileno.ItemClick

    End Sub


    ' 
    Private Sub Nbi_AgregarTipoUnidad_ItemClick(sender As Object, e As EventArgs) Handles Nbi_AgregarTipoUnidad.ItemClick
        AgregarTipoUnidad()
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub AgregarTipoUnidad()
        Dim frAgregarTipoUnidad As New Form
        Dim Pn_Datos As New Panel
        Dim Lb_Abreviatura As New Label
        Dim Tx_Abreviatura As New TextBox
        Dim Lb_Descripcion As New Label
        Dim Tx_Descripcion As New TextBox
        Dim Lb_TipoMedida As New Label
        Dim Cb_TipoMedida As New ComboBox
        Dim Ck_PermiteDecimales As New CheckBox 'S/[N]
        Dim Ck_Activo As New CheckBox '[A]/I
        Dim Flp_Botones As New FlowLayoutPanel
        Dim Bt_Guardar As New Button
        Dim Bt_Cancelar As New Button

        With Lb_Abreviatura
            .Location = New Point(42, 20)
            .AutoSize = True
            .Text = "Abreviatura:"
        End With
        With Tx_Abreviatura
            .Location = New Point(110, 20)
            .MaxLength = 10
            .Width = 60
        End With
        With Lb_Descripcion
            .Location = New Point(40, 50)
            .AutoSize = True
            .Text = "Descripción:"
        End With
        With Tx_Descripcion
            .Location = New Point(110, 50)
            .MaxLength = 30
            .Width = 180
        End With
        With Lb_TipoMedida
            .Location = New Point(37, 80)
            .AutoSize = True
            .Text = "Tipo Medida:"
        End With
        With Cb_TipoMedida
            .Location = New Point(110, 80)
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
        With Ck_PermiteDecimales
            .Location = New Point(10, 110)
            .AutoSize = True
            .Checked = False
            .Text = "Permite decimales:"
            .CheckAlign = ContentAlignment.MiddleRight
        End With
        With Ck_Activo
            .Location = New Point(65, 135)
            .AutoSize = True
            .Checked = True
            .Text = "Activo:"
            .CheckAlign = ContentAlignment.MiddleRight
        End With
        With Pn_Datos
            .Dock = DockStyle.Fill
            .Controls.Add(Lb_Abreviatura)
            .Controls.Add(Tx_Abreviatura)
            .Controls.Add(Lb_Descripcion)
            .Controls.Add(Tx_Descripcion)
            .Controls.Add(Lb_TipoMedida)
            .Controls.Add(Cb_TipoMedida)
            .Controls.Add(Ck_PermiteDecimales)
            .Controls.Add(Ck_Activo)
        End With
        With Bt_Cancelar
            .UseVisualStyleBackColor = True
            .Text = "Cancelar"
        End With
        With Bt_Guardar
            .UseVisualStyleBackColor = True
            .Text = "Guardar"
        End With
        With Flp_Botones
            .Dock = DockStyle.Bottom
            .BackColor = Color.Silver
            .FlowDirection = FlowDirection.RightToLeft
            .Height = 30
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Guardar)
        End With
        With frAgregarTipoUnidad
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .MaximizeBox = False
            .MinimizeBox = False
            .Size = New Size(400, 240)
            .StartPosition = FormStartPosition.CenterParent
            .Text = "Agregar Tipo de Unidad"
            .Controls.Add(Pn_Datos)
            .Controls.Add(Flp_Botones)
        End With
        AddHandler frAgregarTipoUnidad.Load, Sub(sender As Object, e As EventArgs)
                                                 Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                                                 Dim comando As New SqlCommand("SELECT * FROM dbo.ListarTipoMedida()", conexion)
                                                 Dim adaptador As New SqlDataAdapter(comando)
                                                 Dim dtTipoMedida As New DataTable
                                                 Try
                                                     conexion.Open()
                                                     adaptador.Fill(dtTipoMedida)
                                                     conexion.Close()
                                                     Cb_TipoMedida.DataSource = dtTipoMedida
                                                     Cb_TipoMedida.ValueMember = "CODIGO"
                                                     Cb_TipoMedida.DisplayMember = "MEDIDA"
                                                 Catch ex As Exception
                                                     MsgBox("No fue posible cargar los tipos de medida.", MsgBoxStyle.Critical, "Listar")
                                                 Finally
                                                     conexion.Close()
                                                 End Try
                                             End Sub
        AddHandler Bt_Cancelar.Click, Sub()
                                          frAgregarTipoUnidad.DialogResult = DialogResult.Cancel
                                          frAgregarTipoUnidad.Close()
                                      End Sub
        AddHandler Bt_Guardar.Click, Sub()
                                         Dim validarTipoUnidad As Boolean = True
                                         If IsNothing(Tx_Abreviatura.Text) OrElse Trim(Tx_Abreviatura.Text) = "" Then
                                             validarTipoUnidad = False
                                             MsgBox("Debe ingresar la abreviatura de la Unidad.", MsgBoxStyle.Exclamation, "Agregar Tipo de Unidad")
                                             Exit Sub
                                         End If
                                         If IsNothing(Tx_Descripcion.Text) OrElse Trim(Tx_Descripcion.Text) = "" Then
                                             validarTipoUnidad = False
                                             MsgBox("Debe ingresar la descripción de la Unidad.", MsgBoxStyle.Exclamation, "Agregar Tipo de Unidad")
                                             Exit Sub
                                         End If
                                         If IsNothing(Cb_TipoMedida.SelectedIndex) OrElse Cb_TipoMedida.SelectedIndex < 0 Then
                                             validarTipoUnidad = False
                                             MsgBox("Debe indicar el Tipo de Medida de la Unidad.", MsgBoxStyle.Exclamation, "Agregar Tipo de Unidad")
                                             Exit Sub
                                         End If
                                         If validarTipoUnidad Then
                                             Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                                             Dim comando As New SqlCommand("dbo.GestionarTipoUnidad", conexion)
                                             comando.CommandType = CommandType.StoredProcedure
                                             comando.Parameters.AddWithValue("@TIPO", 0) 'Crear
                                             comando.Parameters.AddWithValue("@CODIGOTIPOUNIDAD", 0)
                                             comando.Parameters.AddWithValue("@ABREVIATURA", Trim(Tx_Abreviatura.Text))
                                             comando.Parameters.AddWithValue("@DESCRIPCION", Trim(Tx_Descripcion.Text))
                                             comando.Parameters.AddWithValue("@CODIGOTIPOMEDIDA", Cb_TipoMedida.SelectedValue)
                                             If Ck_PermiteDecimales.Checked Then
                                                 comando.Parameters.AddWithValue("@PERMITEDECIMALES", "S")
                                             Else
                                                 comando.Parameters.AddWithValue("@PERMITEDECIMALES", "N")
                                             End If
                                             If Ck_Activo.Checked Then
                                                 comando.Parameters.AddWithValue("@ESTADOTIPOUNIDAD", "A")
                                             Else
                                                 comando.Parameters.AddWithValue("@ESTADOTIPOUNIDAD", "I")
                                             End If
                                             comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
                                             Dim msgParam As New SqlParameter("@IDMENSAJE", SqlDbType.TinyInt)
                                             msgParam.Direction = ParameterDirection.Output
                                             comando.Parameters.Add(msgParam)
                                             Try
                                                 conexion.Open()
                                                 comando.ExecuteNonQuery()
                                                 conexion.Close()
                                                 frAgregarTipoUnidad.DialogResult = DialogResult.OK
                                                 frAgregarTipoUnidad.Close()
                                             Catch ex As Exception
                                                 MsgBox("No fue posible guardar el tipo de unidad", MsgBoxStyle.Critical, "Agregar Tipo de Unidad")
                                             Finally
                                                 conexion.Close()
                                             End Try
                                         End If
                                     End Sub
        If frAgregarTipoUnidad.ShowDialog = DialogResult.OK Then

        End If
    End Sub

#End Region 'Herramientas

End Class 'Cu_Licitaciones


#Region "Clases para Propiedades"

Friend Class Cl_Licitacion
    Dim _IdLicitacion As String
    Dim _NroLicitacion As String
    Dim _Proyecto As String
    Dim _Contratista As String
    Dim _Cliente As String
    Dim _HorasDiarias As String
    Dim _PorcentajeAdministracion As String
    Dim _PorcentajeImprevistos As String
    Dim _PorcentajeUtilidad As String
    Dim _FechaRegistro As String
    'Dim _IdUsuarioRegistro As String
    Dim _UsuarioRegistro As String
    Dim _FechaModificacion As String
    'Dim _IdUsuarioModifica As String
    Dim _UsuarioModifica As String
    Dim _Activo As String
    Dim _TipoGerencia As String

    <Description("Id. interno de la Licitación"), _
    Category(""),
    DisplayNameAttribute("Id. Licitación")> _
    Public ReadOnly Property IdLicitacion() As String
        Get
            Return _IdLicitacion
        End Get
    End Property

    <Description("Número de la Licitación"), _
    Category(""),
    DisplayNameAttribute("Nro. Licitación")> _
    Public ReadOnly Property NroLicitacion() As String
        Get
            Return _NroLicitacion
        End Get
    End Property

    <Description("Descripción del Proyecto"), _
    Category(""),
    DisplayNameAttribute("Proyecto")> _
    Public ReadOnly Property Proyecto() As String
        Get
            Return _Proyecto
        End Get
    End Property

    <Description("Nombre del Contratista"), _
    Category(""),
    DisplayNameAttribute("Contratista")> _
    Public ReadOnly Property Contratista() As String
        Get
            Return _Contratista
        End Get
    End Property

    <Description("Nombre del Cliente"), _
    Category(""),
    DisplayNameAttribute("Cliente")> _
    Public ReadOnly Property Cliente() As String
        Get
            Return _Cliente
        End Get
    End Property

    <Description("Cantidad de Horas Diarias laborables"), _
    Category(""),
    DisplayNameAttribute("Horas diarias")> _
    Public ReadOnly Property HorasDiarias() As String
        Get
            Return _HorasDiarias
        End Get
    End Property

    <Description("Porcentaje de Administración"), _
    Category(""),
    DisplayNameAttribute("Porcentaje Administración")> _
    Public ReadOnly Property PorcentajeAdministracion() As String
        Get
            Return _PorcentajeAdministracion
        End Get
    End Property

    <Description("Porcentaje de Imprevistos"), _
    Category(""),
    DisplayNameAttribute("Porcentaje Imprevistos")> _
    Public ReadOnly Property PorcentajeImprevistos() As String
        Get
            Return _PorcentajeImprevistos
        End Get
    End Property

    <Description("Porcentaje de Utilidad"), _
    Category(""),
    DisplayNameAttribute("Porcentaje Utilidad")> _
    Public ReadOnly Property PorcentajeUtilidad() As String
        Get
            Return _PorcentajeUtilidad
        End Get
    End Property

    <Description("Fecha en que se registró la licitación"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Registro")> _
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Usuario que registró la Licitación"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Registro")> _
    Public ReadOnly Property UsuarioRegistro() As String
        Get
            Return _UsuarioRegistro
        End Get
    End Property

    <Description("Última fecha de modificación de la Licitación"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Modificación")> _
    Public ReadOnly Property FechaModificacion() As String
        Get
            Return _FechaModificacion
        End Get
    End Property

    <Description("Último usuario que modificó la Licitación"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Modifica")> _
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property

    <Description("Estado de la Licitación. Sí = Activa, No = Inactiva"), _
    Category(""),
    DisplayNameAttribute("Activa")> _
    Public ReadOnly Property Activo() As String
        Get
            Return _Activo
        End Get
    End Property

    <Description("Gerencia"), _
    Category(""),
    DisplayNameAttribute("Gerencia")> _
    Public ReadOnly Property TipoGerencia() As String
        Get
            Return _TipoGerencia
        End Get
    End Property

    Sub New(ByVal FilaLicitacion As DataGridViewRow)
        _IdLicitacion = FilaLicitacion.Cells("IDLICITACION").Value
        _NroLicitacion = FilaLicitacion.Cells("NROLICITACION").Value
        _Proyecto = FilaLicitacion.Cells("PROYECTO").Value
        _Contratista = FilaLicitacion.Cells("CONTRATISTA").Value
        _Cliente = FilaLicitacion.Cells("CLIENTE").Value
        _HorasDiarias = FilaLicitacion.Cells("HORASDIARIAS").Value & " Hora(s)"
        _PorcentajeAdministracion = Format(FilaLicitacion.Cells("PORCENTAJEADMINISTRACION").Value, "0.####") & "%"
        _PorcentajeImprevistos = Format(FilaLicitacion.Cells("PORCENTAJEIMPREVISTOS").Value, "0.####") & "%"
        _PorcentajeUtilidad = Format(FilaLicitacion.Cells("PORCENTAJEUTILIDAD").Value, "0.####") & "%"
        _FechaRegistro = FilaLicitacion.Cells("FECHAREGISTRO").Value
        _UsuarioRegistro = FilaLicitacion.Cells("USUARIOREGISTRO").Value
        Try
            _FechaModificacion = FilaLicitacion.Cells("FECHAMODIFICACION").Value
            _UsuarioModifica = FilaLicitacion.Cells("USUARIOMODIFICA").Value
        Catch
            _FechaModificacion = ""
            _UsuarioModifica = ""
        End Try
        _Activo = If(FilaLicitacion.Cells("ACTIVO").Value = "S", "Sí", "No")
        Try
            Select Case FilaLicitacion.Cells("TIPOGERENCIA").Value
                Case "C"
                    _TipoGerencia = "Construcciones"
                Case "M"
                    _TipoGerencia = "Montajes"
                Case "O"
                    _TipoGerencia = "Operaciones"
                Case Else
                    _TipoGerencia = ""
            End Select
        Catch
            _TipoGerencia = ""
        End Try
    End Sub
End Class 'Cl_Licitacion



Friend Class Cl_APU
    Dim _IdAPU As String
    Dim _IdLicitacion As String
    Dim _NroLicitacion As String
    'Dim _NroItemLicitacion As String
    Dim _NroItemCliente As String
    Dim _EsCapitulo As String
    Dim _Descripcion As String
    Dim _CodigoTipoUnidad As String
    Dim _TipoUnidad As String
    Dim _CantidadEstimada As String
    Dim _ValorTotalItemSinAIU As String
    'Dim _ValorTotalItemConAIU As String
    Dim _TotalHorasHombre As String
    Dim _Rendimiento As String
    Dim _FechaRegistro As String
    Dim _IdUsuarioRegistro As String
    Dim _UsuarioRegistro As String
    Dim _FechaModificacion As String
    Dim _IdUsuarioModifica As String
    Dim _UsuarioModifica As String
    Dim _Activo As String


    <Description("Id. interno del Ítem A.P.U."), _
    Category(""),
    DisplayNameAttribute("Id. A.P.U.")> _
    Public ReadOnly Property IdAPU() As String
        Get
            Return _IdAPU
        End Get
    End Property

    <Description("Id de la Licitación a la que corresponde el ítem actual"), _
    Category(""),
    DisplayNameAttribute("Id Licitación")> _
    Public ReadOnly Property IdLicitacion() As String
        Get
            Return _IdLicitacion
        End Get
    End Property

    <Description("Número de la Licitación a la que corresponde el ítem actual"), _
    Category(""),
    DisplayNameAttribute("Nro. Licitación")> _
    Public ReadOnly Property NroLicitacion() As String
        Get
            Return _NroLicitacion
        End Get
    End Property

    '<Description("Nro. de Ítem de la Licitacion"), _
    'Category(""),
    'DisplayNameAttribute("Nro. Ítem Licitación")> _
    'Public ReadOnly Property NroItemLicitacion() As String
    '    Get
    '        Return _NroItemLicitacion
    '    End Get
    'End Property

    <Description("Código de Ítem indicado por el Cliente"), _
    Category(""),
    DisplayNameAttribute("Código Ítem Cliente")> _
    Public ReadOnly Property NroItemCliente() As String
        Get
            Return _NroItemCliente
        End Get
    End Property

    <Description("El ítem actual es Capítulo"), _
    Category(""),
    DisplayNameAttribute("Es Capítulo")> _
    Public ReadOnly Property EsCapitulo() As String
        Get
            Return _EsCapitulo
        End Get
    End Property

    <Description("Descripción del Ítem A.P.U."), _
    Category(""),
    DisplayNameAttribute("Descripción")> _
    Public ReadOnly Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
    End Property

    <Description("Código Tipo Unidad"), _
    Category(""),
    DisplayNameAttribute("Codigo Tipo Unidad")> _
    Public ReadOnly Property CodigoTipoUnidad() As String
        Get
            Return _CodigoTipoUnidad
        End Get
    End Property

    <Description("Tipo de Unidad del Ítem A.P.U."), _
    Category(""),
    DisplayNameAttribute("Unidad")> _
    Public ReadOnly Property TipoUnidad() As String
        Get
            Return _TipoUnidad
        End Get
    End Property

    <Description("Cantidad estimada"), _
    Category(""),
    DisplayNameAttribute("Cantidad")> _
    Public ReadOnly Property CantidadEstimada() As String
        Get
            Return _CantidadEstimada
        End Get
    End Property

    <Description("Valor total del Ítem sin A.I.U."), _
    Category(""),
    DisplayNameAttribute("Valor total Ítem sin AIU")> _
    Public ReadOnly Property ValorTotalItemSinAIU() As String
        Get
            Return _ValorTotalItemSinAIU
        End Get
    End Property

    '<Description("Valor total del Ítem con A.I.U."), _
    'Category(""),
    'DisplayNameAttribute("Valor total Ítem con AIU")> _
    'Public ReadOnly Property ValorTotalItemConAIU() As String
    '    Get
    '        Return _ValorTotalItemConAIU
    '    End Get
    'End Property

    <Description("Total de Horas Hombre del Ítem"), _
    Category(""),
    DisplayNameAttribute("Total de Horas Hombre")> _
    Public ReadOnly Property TotalHorasHombre() As String
        Get
            Return _TotalHorasHombre
        End Get
    End Property

    <Description("Rendimiento del A.P.U."), _
    Category(""),
    DisplayNameAttribute("Rendimiento")> _
    Public ReadOnly Property Rendimiento() As String
        Get
            Return _Rendimiento
        End Get
    End Property

    <Description("Fecha de registro del A.P.U."), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Registro")> _
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Id del usuario que registró el A.P.U."), _
    Category("Auditoría"),
    DisplayNameAttribute("Id Usuario Registró")> _
    Public ReadOnly Property IdUsuarioRegistro() As String
        Get
            Return _IdUsuarioRegistro
        End Get
    End Property

    <Description("Usuario que registró el A.P.U."), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Registro")> _
    Public ReadOnly Property UsuarioRegistro() As String
        Get
            Return _UsuarioRegistro
        End Get
    End Property

    <Description("Fecha de la última modificación del A.P.U."), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Modificación")> _
    Public ReadOnly Property FechaModificacion() As String
        Get
            Return _FechaModificacion
        End Get
    End Property

    <Description("Id del último usuario que modificó el A.P.U."), _
    Category("Auditoría"),
    DisplayNameAttribute("Id Usuario Modifica")> _
    Public ReadOnly Property IdUsuarioModifica() As String
        Get
            Return _IdUsuarioModifica
        End Get
    End Property

    <Description("Último usuario que modificó el A.P.U."), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Modifica")> _
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _UsuarioModifica
        End Get
    End Property

    <Description("El A.P.U. se encuentra activo (Sí/No)"), _
    Category(""),
    DisplayNameAttribute("Activo")> _
    Public ReadOnly Property Activo() As String
        Get
            Return _Activo
        End Get
    End Property


    Sub New(ByVal FilaAPU As DataGridViewRow)
        _NroLicitacion = FilaAPU.Cells("NROLICITACION").Value
        '_NroItemLicitacion = FilaAPU.Cells("NROITEMLICITACION").Value
        Try
            _NroItemCliente = FilaAPU.Cells("NROITEMCLIENTE").Value
        Catch
            _NroItemCliente = ""
        End Try
        _Descripcion = FilaAPU.Cells("DESCRIPCION").Value
        Try
            _TipoUnidad = FilaAPU.Cells("ABREVIATURA").Value
        Catch
            _TipoUnidad = ""
        End Try
        Try
            _CantidadEstimada = Format(FilaAPU.Cells("CANTIDADESTIMADA").Value, "0.####")
        Catch
            _CantidadEstimada = ""
        End Try
        Try
            _ValorTotalItemSinAIU = Format(FilaAPU.Cells("VALORTOTALITEMSINAIU").Value, "C0")
        Catch
            _ValorTotalItemSinAIU = ""
        End Try
        'Try
        '    _ValorTotalItemConAIU = Format(FilaAPU.Cells("VALORTOTALITEMCONAIU").Value, "C0")
        'Catch
        '    _ValorTotalItemConAIU = ""
        'End Try
        Try
            _TotalHorasHombre = Format(FilaAPU.Cells("TOTALHORASHOMBRE").Value, "0.####")
        Catch
            _TotalHorasHombre = ""
        End Try
        Try
            _Rendimiento = Format(FilaAPU.Cells("RENDIMIENTO").Value, "0.####")
        Catch
            _Rendimiento = ""
        End Try
        _FechaRegistro = FilaAPU.Cells("FECHAREGISTRO").Value
        _UsuarioRegistro = FilaAPU.Cells("USUARIOREGISTRO").Value
        Try
            _FechaModificacion = FilaAPU.Cells("FECHAMODIFICACION").Value
            _UsuarioModifica = FilaAPU.Cells("USUARIOMODIFICA").Value
        Catch
            _FechaModificacion = ""
            _UsuarioModifica = ""
        End Try
        Select Case FilaAPU.Cells("ACTIVO").Value
            Case "S"
                _Activo = "Sí"
            Case "N"
                _Activo = "No"
            Case Else
                _Activo = ""
        End Select
    End Sub
End Class 'Cl_APU



Friend Class Cl_Material
    Private _idmaterial As String
    Private _descripcion As String
    Private _tipounidad As String
    Private _idarticulo As String
    Private _articulo As String
    Private _valorismocol As String
    Private _valorcomercial As String
    Private _fecharegistro As String
    Private _usuarioregistro As String
    Private _fechamodificacion As String
    Private _usuariomodifica As String
    Private _activo As String

    <Description("Id. interno del Material"), _
    Category(""),
    DisplayNameAttribute("Id. Material")> _
    Public ReadOnly Property IdMaterial() As String
        Get
            Return _idmaterial
        End Get
    End Property

    <Description(""), _
    Category(""), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property Descripcion() As String
        Get
            Return _descripcion
        End Get
    End Property

    <Description(""), _
    Category(""), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property TipoUnidad() As String
        Get
            Return _tipounidad
        End Get
    End Property

    <Description(""), _
    Category(""), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property idarticulo() As String
        Get
            Return _idarticulo
        End Get
    End Property

    <Description(""), _
    Category(""), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property Articulo() As String
        Get
            Return _articulo
        End Get
    End Property

    <Description(""), _
    Category(""), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property ValorIsmocol() As String
        Get
            Return _valorismocol
        End Get
    End Property

    <Description(""), _
    Category(""), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property ValorComercial() As String
        Get
            Return _valorcomercial
        End Get
    End Property

    <Description(""), _
    Category("Auditoría"), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _fecharegistro
        End Get
    End Property

    <Description(""), _
    Category("Auditoría"), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property UsuarioRegistro() As String
        Get
            Return _usuarioregistro
        End Get
    End Property

    <Description(""), _
    Category("Auditoría"), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property FechaModificacion() As String
        Get
            Return _fechamodificacion
        End Get
    End Property

    <Description(""), _
    Category("Auditoría"), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _usuariomodifica
        End Get
    End Property

    <Description(""), _
    Category(""), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property Activo() As String
        Get
            Return _activo
        End Get
    End Property


    Sub New(ByVal FilaMaterial As DataGridViewRow)
        _idmaterial = FilaMaterial.Cells("IDMATERIAL").Value
        _descripcion = FilaMaterial.Cells("DESCRIPCION").Value
        _tipounidad = FilaMaterial.Cells("ABREVIATURA").Value
        Try
            _idarticulo = FilaMaterial.Cells("IDARTICULO").Value
            _articulo = FilaMaterial.Cells("NOMBREDESCRIPTIVO").Value
        Catch
            _idarticulo = ""
            _articulo = ""
        End Try
        Try
            _valorismocol = Format(FilaMaterial.Cells("VALORISMOCOL").Value, "C0")
        Catch
            _valorismocol = ""
        End Try
        Try
            _valorcomercial = Format(FilaMaterial.Cells("VALORCOMERCIAL").Value, "C0")
        Catch
            _valorcomercial = ""
        End Try
        _fecharegistro = FilaMaterial.Cells("FECHAREGISTRO").Value
        _usuarioregistro = FilaMaterial.Cells("USUARIOREGISTRO").Value
        _fechamodificacion = FilaMaterial.Cells("FECHAMODIFICACION").Value
        _usuariomodifica = FilaMaterial.Cells("USUARIOMODIFICA").Value
        Select Case FilaMaterial.Cells("ACTIVO").Value
            Case "S"
                _activo = "Sí"
            Case "N"
                _activo = "No"
            Case Else
                _activo = ""
        End Select
    End Sub
End Class 'Cl_Material



Friend Class Cl_Equipo
    Private _idmaquinariayequipo As String
    Private _descripcion As String
    Private _idarticulo As String
    Private _articulo As String
    Private _tarifaismocolxhora As String
    Private _tarifacomercialxhora As String
    Private _combustiblexhora As String
    Private _fecharegistro As String
    Private _usuarioregistro As String
    Private _fechamodificacion As String
    Private _usuariomodifica As String
    Private _activo As String

    <Description("Id interno del Equipo"), _
    Category(""), _
    DisplayNameAttribute("Id. Equipo")> _
    Public ReadOnly Property IdMaquinariaYEquipo() As String
        Get
            Return _idmaquinariayequipo
        End Get
    End Property

    <Description(""), _
    Category(""), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property Descripcion() As String
        Get
            Return _descripcion
        End Get
    End Property

    <Description(""), _
    Category(""), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property IdArticulo() As String
        Get
            Return _idarticulo
        End Get
    End Property

    <Description(""), _
    Category(""), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property Articulo() As String
        Get
            Return _articulo
        End Get
    End Property

    <Description(""), _
    Category(""), _
    DisplayNameAttribute("")> _
    Public ReadOnly Property TarifaIsmocolxHora() As String
        Get
            Return _tarifaismocolxhora
        End Get
    End Property

    <Description(""), _
     Category(""), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property TarifaComercialxHora() As String
        Get
            Return _tarifacomercialxhora
        End Get
    End Property

    <Description(""), _
     Category(""), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property CombustiblexHora() As String
        Get
            Return _combustiblexhora
        End Get
    End Property

    <Description(""), _
     Category("Auditoría"), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _fecharegistro
        End Get
    End Property

    <Description(""), _
     Category("Auditoría"), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property UsuarioRegistro() As String
        Get
            Return _usuarioregistro
        End Get
    End Property

    <Description(""), _
     Category("Auditoría"), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property FechaModificacion() As String
        Get
            Return _fechamodificacion
        End Get
    End Property

    <Description(""), _
     Category("Auditoría"), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _usuariomodifica
        End Get
    End Property

    <Description(""), _
     Category(""), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property Activo() As String
        Get
            Return _activo
        End Get
    End Property


    Sub New(ByVal FilaEquipo As DataGridViewRow)
        _idmaquinariayequipo = FilaEquipo.Cells("IDMAQUINARIAYEQUIPO").Value
        _descripcion = FilaEquipo.Cells("DESCRIPCION").Value
        Try
            _idarticulo = FilaEquipo.Cells("IDARTICULO").Value
            _articulo = FilaEquipo.Cells("NOMBREDESCRIPTIVO").Value
        Catch
            _idarticulo = ""
            _articulo = ""
        End Try
        Try
            _tarifaismocolxhora = Format(FilaEquipo.Cells("TARIFAISMOCOLXHORA").Value, "C0")
        Catch
            _tarifaismocolxhora = ""
        End Try
        Try
            _tarifacomercialxhora = Format(FilaEquipo.Cells("TARIFACOMERCIALXHORA").Value, "C0")
        Catch
            _tarifacomercialxhora = ""
        End Try
        Try
            _combustiblexhora = Format(FilaEquipo.Cells("COMBUSTIBLEXHORA").Value, "0.####")
        Catch
            _combustiblexhora = ""
        End Try
        _fecharegistro = FilaEquipo.Cells("FECHAREGISTRO").Value
        _usuarioregistro = FilaEquipo.Cells("USUARIOREGISTRO").Value
        _fechamodificacion = FilaEquipo.Cells("FECHAMODIFICACION").Value
        _usuariomodifica = FilaEquipo.Cells("USUARIOMODIFICA").Value
        Select Case FilaEquipo.Cells("ACTIVO").Value
            Case "S"
                _activo = "Sí"
            Case "N"
                _activo = "No"
            Case Else
                _activo = ""
        End Select
    End Sub
End Class 'Cl_Equipo



Friend Class Cl_ManoDeObra
    Private _idmanodeobra As String
    Private _descripcion As String
    Private _tarifaismocolxhorahombre As String
    Private _fecharegistro As String
    Private _usuarioregistro As String
    Private _fechamodificacion As String
    Private _usuariomodifica As String
    Private _activo As String

    <Description("Id interno de la Mano de Obra"), _
    Category(""),
    DisplayNameAttribute("Id. Mano de Obra")> _
    Public ReadOnly Property IdManoDeObra() As String
        Get
            Return _idmanodeobra
        End Get
    End Property

    <Description(""), _
     Category(""), _
     DisplayNameAttribute("Descripción")> _
    Public ReadOnly Property Descripcion() As String
        Get
            Return _descripcion
        End Get
    End Property

    <Description(""), _
     Category(""), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property TarifaIsmocolxHoraHombre() As String
        Get
            Return _tarifaismocolxhorahombre
        End Get
    End Property

    <Description(""), _
     Category("Auditoría"), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property FechaRegistro() As String
        Get
            Return _fecharegistro
        End Get
    End Property

    <Description(""), _
     Category("Auditoría"), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property UsuarioRegistro() As String
        Get
            Return _usuarioregistro
        End Get
    End Property

    <Description(""), _
     Category("Auditoría"), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property FechaModificacion() As String
        Get
            Return _fechamodificacion
        End Get
    End Property

    <Description(""), _
     Category("Auditoría"), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property UsuarioModifica() As String
        Get
            Return _usuariomodifica
        End Get
    End Property

    <Description(""), _
     Category(""), _
     DisplayNameAttribute("")> _
    Public ReadOnly Property Activo() As String
        Get
            Return _activo
        End Get
    End Property


    Sub New(ByVal FilaManoDeObra As DataGridViewRow)
        _idmanodeobra = FilaManoDeObra.Cells("IDMANODEOBRA").Value
        Try
            _descripcion = FilaManoDeObra.Cells("DESCRIPCION").Value
        Catch
            _descripcion = ""
        End Try
        Try
            _tarifaismocolxhorahombre = Format(FilaManoDeObra.Cells("TARIFAISMOCOLXHORAHOMBRE").Value, "C0")
        Catch
            _tarifaismocolxhorahombre = ""
        End Try
        _fecharegistro = FilaManoDeObra.Cells("FECHAREGISTRO").Value
        _usuarioregistro = FilaManoDeObra.Cells("USUARIOREGISTRO").Value
        _fechamodificacion = FilaManoDeObra.Cells("FECHAMODIFICACION").Value
        _usuariomodifica = FilaManoDeObra.Cells("USUARIOMODIFICA").Value
        Select Case FilaManoDeObra.Cells("ACTIVO").Value
            Case "S"
                _activo = "Sí"
            Case "N"
                _activo = "No"
            Case Else
                _activo = ""
        End Select
    End Sub
End Class 'Cl_ManoDeObra

#End Region 'Clases para Propiedades