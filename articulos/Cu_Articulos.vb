Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Microsoft.Office.Interop
Imports DatosArticulos
Imports DatosArticulos.Ds_GruposTableAdapters

Public Class Cu_Articulos
    Private CODIGO As String
    Private datas As New DataSet
    Private DsArtículos As New Ds_Artículos
    Private Ds_Grupos As New Ds_Grupos
    Private MA_CLASEMATERIALTableAdapter1 As New MA_CLASEMATERIALTableAdapter
    Private MA_FAMILIAMATERIALTableAdapter1 As New MA_FAMILIAMATERIALTableAdapter
    Private MA_GRUPOMATERIALTableAdapter1 As New MA_GRUPOMATERIALTableAdapter
    Private MA_SUBCLASEMATERIALTableAdapter1 As New MA_SUBCLASEMATERIALTableAdapter
    Dim TablaCargada As String = ""
    Private GoogleDrive As New FuncionesGoogle.FuncionesGoogle

    Public Sub Comportamiento_Predeterminado()
        Dgv_Articulos.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_Articulos.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Dgv_TablaDisponibilidad.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_TablaDisponibilidad.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Dgv_TablaProveedores.ColumnHeadersDefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2
        Dgv_TablaProveedores.DefaultCellStyle = VariablesBase.VariablesBase.DataGridViewCellStyle2

        Nbc_Articulos.ActiveGroup = Nbg_Arbol
        'Árbol de artículos
        Nbg_Arbol.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Arbol.Tag)
        'Artículo
        Nbg_Articulo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbg_Articulo.Tag)
        Nbi_BuscarArticulo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_BuscarArticulo.Tag)
        Nbi_ImprimirSticker.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_ImprimirSticker.Tag)
        Nbi_EditarTipos.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_EditarTipos.Tag)
        Nbi_VerInventario.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_VerInventario.Tag)
        Nbi_FijarCaracteristicaArticulo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_FijarCaracteristicaArticulo.Tag)
        Nbi_TrazabilidadArticulo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_TrazabilidadArticulo.Tag)
        Nbi_TrazabilidadArticuloTotal.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Nbi_TrazabilidadArticuloTotal.Tag)
        TSBt_BuscarArticulo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(TSBt_BuscarArticulo.Tag)
        TSBt_ImprimirSticker.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(TSBt_ImprimirSticker.Tag)
        TSBt_EditarTS.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(TSBt_EditarTS.Tag)
        TSBt_VerInventarios.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(TSBt_VerInventarios.Tag)
        TSBt_UyStock.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(TSBt_UyStock.Tag)
        TSBt_TrazabilidadxBase.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(TSBt_TrazabilidadxBase.Tag)
        TSBt_Trazabilidad.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(TSBt_Trazabilidad.Tag)

        Ck_MostrarDisponibilidad.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Ck_MostrarDisponibilidad.Tag)
        Ck_ProveedoresArticulo.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Ck_ProveedoresArticulo.Tag)

        'Cms_Familia.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_Familia.Tag)
        Tsmi_CrearGrupo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CrearGrupo.Tag)
        Tsmi_EliminarFamilia.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_EliminarFamilia.Tag)
        Tsmi_CambiarNombreFamilia.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CambiarNombreFamilia.Tag)
        Tsmi_StockXArbol_Familia.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_StockXArbol_Familia.Tag)

        'Cms_Grupo.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_Grupo.Tag)
        Tsmi_CrearClase.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CrearClase.Tag)
        Tsmi_EliminarGrupo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_EliminarGrupo.Tag)
        Tsmi_CambiarNombreGrupo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CambiarNombreGrupo.Tag)
        Tsmi_StockXArbol_Grupo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_StockXArbol_Grupo.Tag)

        'Cms_Clase.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_Clase.Tag)
        Tsmi_CrearSubclase.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CrearSubclase.Tag)
        Tsmi_EliminarClase.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_EliminarClase.Tag)
        Tsmi_CambiarNombreClase.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CambiarNombreClase.Tag)
        Tsmi_StockXArbol_Clase.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_StockXArbol_Clase.Tag)

        'Cms_SubClase.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_SubClase.Tag)
        Tsmi_CrearTipoCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CrearTipoCategoría.Tag)
        Tsmi_EliminarSubClase.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_EliminarSubClase.Tag)
        Tsmi_CambiarNombreSubClase.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CambiarNombreSubClase.Tag)
        Tsmi_StockXArbol_SubClase.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_StockXArbol_SubClase.Tag)

        'Cms_SubClaseSinCategoría.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_SubClaseSinCategoría.Tag)
        Tsmi_EliminarSubClaseSinCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_EliminarSubClaseSinCategoría.Tag)
        Tsmi_CambiarNombreSubClaseSinCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CambiarNombreSubClaseSinCategoría.Tag)
        Tsmi_StockXArbol_SubClase2.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_StockXArbol_SubClase2.Tag)

        'Cms_TipoCategoría.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_TipoCategoría.Tag)
        Tsmi_CrearCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CrearCategoría.Tag)
        Tsmi_ModificarTipoCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_ModificarTipoCategoría.Tag)
        Tsmi_EliminarTipoCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_EliminarTipoCategoría.Tag)
        Tsmi_CambiarNombreTipoCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CambiarNombreTipoCategoría.Tag)
        Tsmi_StockXArbol_TipoCategoria.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_StockXArbol_TipoCategoria.Tag)

        'Cms_Categoría.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_Categoría.Tag)
        Tsmi_CrearTipoCategoríaStrip.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CrearTipoCategoríaStrip.Tag)
        Tsmi_ModificarCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_ModificarCategoría.Tag)
        Tsmi_CrearArtículo.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CrearArtículo.Tag)
        Tsmi_EliminarCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_EliminarCategoría.Tag)
        Tsmi_CambiarNombreCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CambiarNombreCategoría.Tag)
        Tsmi_StockXArbol_Categoria.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_StockXArbol_Categoria.Tag)

        'Cms_CategoríaSinCategoria.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_CategoríaSinCategoria.Tag)
        Tsmi_ModificarCategoria2.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_ModificarCategoria2.Tag)
        Tsmi_CrearArtículo2.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CrearArtículo2.Tag)
        Tsmi_EliminarCategoríaSinCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_EliminarCategoríaSinCategoría.Tag)
        Tsmi_CambiarNombreCategoríaSinCategoría.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_CambiarNombreCategoríaSinCategoría.Tag)
        Tsmi_StockXArbol_Categoria2.Visible = FuncionesBase.FuncionesBase.ConsultarPermiso(Tsmi_StockXArbol_Categoria2.Tag)

        Cms_Artículos.Enabled = FuncionesBase.FuncionesBase.ConsultarPermiso(Cms_Artículos.Tag)
    End Sub

    Public Sub Cargar_Tabla()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        MA_FAMILIAMATERIALTableAdapter1.Fill(Ds_Grupos.MA_FAMILIAMATERIAL)
        MA_GRUPOMATERIALTableAdapter1.Fill(Ds_Grupos.MA_GRUPOMATERIAL)
        MA_CLASEMATERIALTableAdapter1.Fill(Ds_Grupos.MA_CLASEMATERIAL)
        MA_SUBCLASEMATERIALTableAdapter1.Fill(Ds_Grupos.MA_SUBCLASEMATERIAL)
        'Cargar Familias
        For i = 0 To Ds_Grupos.MA_FAMILIAMATERIAL.Rows.Count - 1
            Dim FilaFamilia As DataRow
            FilaFamilia = Ds_Grupos.MA_FAMILIAMATERIAL.Rows(i)
            Dim _NodoFamilia As New NodoFamilia
            _NodoFamilia.CODIGOFAMILIAMATERIAL = FilaFamilia("CODIGOFAMILIAMATERIAL")
            _NodoFamilia.Name = Trim(FilaFamilia("CODIGOFAMILIAMATERIAL"))
            _NodoFamilia.Text = Trim(FilaFamilia("CODIGOFAMILIAMATERIAL") + " - " + Trim(FilaFamilia("NOMBREFAMILIAMATERIAL")))
            _NodoFamilia.IDFAMILIAMATERIAL = FilaFamilia("IDFAMILIAMATERIAL")
            _NodoFamilia.CODIGOARBOL = Trim(FilaFamilia("CODIGOFAMILIAMATERIAL"))
            _NodoFamilia.NOMBREFAMILIA = Trim(FilaFamilia("NOMBREFAMILIAMATERIAL"))
            _NodoFamilia.ContextMenuStrip = Cms_Familia
            Tv_Grupos.Nodes.Add(_NodoFamilia)
        Next
    End Sub

    Public Sub Cargar_Nodos_Hijos()
        'cargar nodo y expandir
        If IsNothing(Tv_Grupos.SelectedNode) = False Then
            Dim node As New Windows.Forms.TreeNode
            node = Tv_Grupos.SelectedNode
            Select Case node.Tag
                Case "FAMILIA"
                    Dim nodofamilia As New NodoFamilia
                    nodofamilia = Tv_Grupos.SelectedNode
                    If nodofamilia.Nodes.Count = 0 Then
                        Dim FilasGrupos() As DataRow
                        FilasGrupos = Ds_Grupos.MA_GRUPOMATERIAL.Select("IDFAMILIAMATERIAL=" + nodofamilia.IDFAMILIAMATERIAL.ToString)
                        For j = 0 To FilasGrupos.Count - 1
                            Dim FilaGrupo As DataRow
                            FilaGrupo = FilasGrupos(j)
                            Dim _NodoGrupo As New NodoGrupo
                            _NodoGrupo.CODIGOGRUPOMATERIAL = FilaGrupo("CODIGOGRUPOMATERIAL")
                            _NodoGrupo.Name = nodofamilia.Name + Trim(FilaGrupo("CODIGOGRUPOMATERIAL"))
                            _NodoGrupo.Text = Trim(FilaGrupo("CODIGOGRUPOMATERIAL") + " - " + Trim(FilaGrupo("NOMBREGRUPOMATERIAL")))
                            _NodoGrupo.IDGRUPOMATERIAL = FilaGrupo("IDGRUPOMATERIAL")
                            _NodoGrupo.CODIGOARBOL = nodofamilia.Name + Trim(FilaGrupo("CODIGOGRUPOMATERIAL"))
                            _NodoGrupo.NOMBREGRUPOMATERIAL = Trim(FilaGrupo("NOMBREGRUPOMATERIAL"))
                            _NodoGrupo.ContextMenuStrip = Cms_Grupo
                            nodofamilia.Nodes.Add(_NodoGrupo)
                        Next j
                        nodofamilia.ExpandAll()
                    End If
                Case "GRUPO"
                    Dim nodogrupo As New NodoGrupo
                    nodogrupo = Tv_Grupos.SelectedNode
                    If nodogrupo.Nodes.Count = 0 Then
                        Dim nodopadre As New NodoFamilia
                        nodopadre = nodogrupo.Parent
                        'Cargar Clase
                        Dim FilasClases() As DataRow
                        FilasClases = Ds_Grupos.MA_CLASEMATERIAL.Select("IDFAMILIAMATERIAL=" + nodopadre.IDFAMILIAMATERIAL.ToString + " AND IDGRUPOMATERIAL=" + nodogrupo.IDGRUPOMATERIAL.ToString)
                        For k = 0 To FilasClases.Count - 1
                            Dim FilaClase As DataRow
                            FilaClase = FilasClases(k)
                            Dim _NodoClase As New NodoClase
                            _NodoClase.CODIGOCLASEMATERIAL = FilaClase("CODIGOCLASEMATERIAL")
                            _NodoClase.Name = nodogrupo.Name + Trim(FilaClase("CODIGOCLASEMATERIAL"))
                            _NodoClase.IDCLASEMATERIAL = FilaClase("IDCLASEMATERIAL")
                            _NodoClase.Text = Trim(FilaClase("CODIGOCLASEMATERIAL") + " - " + Trim(FilaClase("NOMBRECLASEMATERIAL")))
                            _NodoClase.CODIGOARBOL = nodogrupo.Name + Trim(FilaClase("CODIGOCLASEMATERIAL"))
                            _NodoClase.NOMBRECLASEMATERIAL = Trim(FilaClase("NOMBRECLASEMATERIAL"))
                            _NodoClase.ContextMenuStrip = Cms_Clase
                            nodogrupo.Nodes.Add(_NodoClase)
                        Next
                        nodogrupo.ExpandAll()
                    End If
                Case "CLASE"
                    Dim nodoclase As New NodoClase
                    nodoclase = Tv_Grupos.SelectedNode
                    If nodoclase.Nodes.Count = 0 Then
                        'consultar, crear nodos y expandir
                        Dim nodopadre As New NodoGrupo
                        nodopadre = nodoclase.Parent
                        'Cargar Clase
                        Dim FilasSubClases() As DataRow
                        FilasSubClases = Ds_Grupos.MA_SUBCLASEMATERIAL.Select("IDGRUPOMATERIAL=" + nodopadre.IDGRUPOMATERIAL.ToString + " AND IDCLASEMATERIAL=" + nodoclase.IDCLASEMATERIAL.ToString)
                        For k = 0 To FilasSubClases.Count - 1
                            Dim FilaSubClase As DataRow
                            FilaSubClase = FilasSubClases(k)
                            Dim _NodoSubClase As New NodoSubClase
                            _NodoSubClase.CODIGOSUBCLASEMATERIAL = FilaSubClase("CODIGOSUBCLASEMATERIAL")
                            _NodoSubClase.Name = nodoclase.Name + Trim(FilaSubClase("CODIGOSUBCLASEMATERIAL"))
                            _NodoSubClase.IDSUBCLASEMATERIAL = FilaSubClase("IDSUBCLASEMATERIAL")
                            _NodoSubClase.Text = Trim(FilaSubClase("CODIGOSUBCLASEMATERIAL") + " - " + Trim(FilaSubClase("NOMBRESUBCLASEMATERIAL")))
                            _NodoSubClase.CODIGOARBOL = nodoclase.Name + Trim(FilaSubClase("CODIGOSUBCLASEMATERIAL"))
                            _NodoSubClase.NOMBRESUBCLASEMATERIAL = Trim(FilaSubClase("NOMBRESUBCLASEMATERIAL"))
                            _NodoSubClase.ContextMenuStrip = Cms_SubClaseSinCategoría
                            nodoclase.Nodes.Add(_NodoSubClase)
                        Next
                        nodoclase.ExpandAll()
                    End If
                Case "SUBCLASE"
                    Dim nodosubclase As New NodoSubClase
                    nodosubclase = Tv_Grupos.SelectedNode
                    If nodosubclase.Nodes.Count = 0 Then
                        'consultar, crear nodos y expandir
                        Dim adap As New DatosArticulos.Ds_GruposTableAdapters.CATEGORIAMATERIALESTableAdapter
                        adap.FillByIDSUBCLASEMATERIAL(Ds_Grupos.CATEGORIAMATERIALES, nodosubclase.IDSUBCLASEMATERIAL)
                        For i = 0 To Ds_Grupos.CATEGORIAMATERIALES.Rows.Count - 1
                            Dim fila As DataRow
                            fila = Ds_Grupos.CATEGORIAMATERIALES.Rows(i)
                            Dim nodotipocategoría As New NodoTipoCategoría
                            nodotipocategoría.CODIGOTIPOCATEGORIAMATERIAL = fila("CODIGOCATEGORIA")
                            nodotipocategoría.CODIGOARBOL = Trim(fila("CODIGOARBOL"))
                            nodotipocategoría.Text = Trim(fila("NOMBRECATEGORIA"))
                            nodotipocategoría.NOMBRETIPOCATEGORIAMATERIAL = Trim(fila("NOMBRECATEGORIA"))
                            nodosubclase.Nodes.Add(nodotipocategoría)
                            nodotipocategoría.ContextMenuStrip = Cms_TipoCategoría
                        Next
                        If nodosubclase.Nodes.Count = 0 Then
                            nodosubclase.ContextMenuStrip = Cms_SubClase
                        End If
                        nodosubclase.ExpandAll()
                    End If
                Case "TIPO CATEGORIA"
                    Dim nodotipocategoria As New NodoTipoCategoría
                    nodotipocategoria = Tv_Grupos.SelectedNode
                    If nodotipocategoria.Nodes.Count = 0 Then
                        'consultar, crear nodos y expandir
                        Dim adap As New DatosArticulos.Ds_GruposTableAdapters.CATEGORIAMATERIALES1TableAdapter
                        adap.FillByCODIGOTIPOCATEGORIAPADRE(Ds_Grupos.CATEGORIAMATERIALES1, nodotipocategoria.CODIGOTIPOCATEGORIAMATERIAL)
                        For i = 0 To Ds_Grupos.CATEGORIAMATERIALES1.Rows.Count - 1
                            Dim fila As DataRow
                            fila = Ds_Grupos.CATEGORIAMATERIALES1.Rows(i)
                            Dim nodocategoría As New NodoCategoría
                            nodocategoría.CODIGOCATEGORIAMATERIAL = fila("CODIGOCATEGORIA")
                            nodocategoría.CODIGOARBOL = Trim(fila("CODIGOARBOL"))
                            nodocategoría.NOMBRECATEGORIAMATERIAL = Trim(fila("NOMBRECATEGORIA"))
                            nodocategoría.Text = Mid(Trim(fila("CODIGOARBOL")), Trim(fila("CODIGOARBOL")).Length - 1, 2) + " - " + Trim(fila("NOMBRECATEGORIA"))
                            nodocategoría.IDCODIGOTIPOUNIDAD = fila("CODIGOTIPOUNIDAD")
                            nodotipocategoria.Nodes.Add(nodocategoría)
                            'verificar cuales categorías tienen subcategorías para no permitir la creación de otros
                            If fila("CODIGOCATEGORIAPADRE") > 0 Then
                                'la categoría ya tiene un tipo de categoría definido, solo se puede un subtipo de categoría por categoría
                                nodocategoría.ContextMenuStrip = Cms_CategoríaSinCategoria
                            Else
                                nodocategoría.ContextMenuStrip = Cms_Categoría
                            End If
                            nodotipocategoria.ExpandAll()
                        Next
                    End If
                Case "CATEGORIA"

                    Windows.Forms.Cursor.Current = Cursors.WaitCursor

                    Dim nodocategoría As New NodoCategoría
                    nodocategoría = Tv_Grupos.SelectedNode
                    If nodocategoría.Nodes.Count = 0 Then
                        'consultar, crear nodos y expandir
                        Dim adap As New DatosArticulos.Ds_GruposTableAdapters.CATEGORIAMATERIALESTableAdapter
                        adap.FillByCODIGOCATEGORIA(Ds_Grupos.CATEGORIAMATERIALES, nodocategoría.CODIGOARBOL)
                        For i = 0 To Ds_Grupos.CATEGORIAMATERIALES.Rows.Count - 1
                            Dim fila As DataRow
                            fila = Ds_Grupos.CATEGORIAMATERIALES.Rows(i)
                            Dim nodotipocategoría As New NodoTipoCategoría
                            nodotipocategoría.CODIGOTIPOCATEGORIAMATERIAL = fila("CODIGOCATEGORIA")
                            nodotipocategoría.CODIGOARBOL = Trim(fila("CODIGOARBOL"))
                            nodotipocategoría.Text = Trim(fila("NOMBRECATEGORIA"))
                            nodotipocategoría.NOMBRETIPOCATEGORIAMATERIAL = Trim(fila("NOMBRECATEGORIA"))
                            nodocategoría.Nodes.Add(nodotipocategoría)
                            nodocategoría.ContextMenuStrip = Cms_CategoríaSinCategoria
                            nodotipocategoría.ContextMenuStrip = Cms_TipoCategoría
                            nodocategoría.ExpandAll()
                        Next
                    End If
                    Dim Adaptador As New Data.SqlClient.SqlDataAdapter
                    Dim Comando As New Data.SqlClient.SqlCommand
                    datas.Clear()
                    Dgv_Articulos.Columns.Clear()
                    Comando.CommandText = "SELECT * FROM dbo.ListarArticulosxcodigocategoria(" + nodocategoría.CODIGOCATEGORIAMATERIAL.ToString + ") ORDER BY FECHAREGISTRO ASC"
                    Comando.Connection = VariablesBase.VariablesBase.Conexion_Remota_Sql_Server
                    Adaptador.SelectCommand = Comando
                    Comando.CommandTimeout = 3600
                    Adaptador.Fill(datas)


                    Dgv_Articulos.DataSource = Nothing
                    Dgv_Articulos.DataSource = datas.Tables(0)
                    Dgv_Articulos.AutoGenerateColumns = True
                    Dgv_Articulos.AllowUserToResizeColumns = True
                    Comportamiento_Predeterminado()

                    For i = 0 To 3
                        Select Case Dgv_Articulos.Columns(i).Name
                            Case "ID"
                                Dgv_Articulos.Columns(i).DefaultCellStyle.Font = VariablesBase.VariablesBase.style.Font
                                Dgv_Articulos.Columns(i).Width = 50
                                Dgv_Articulos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            Case "DESCRIPCION"
                                Dgv_Articulos.Columns(i).Width = 560
                            Case "ESTADOARTICULO"
                                Dgv_Articulos.Columns(i).HeaderText = "EST"
                                Dgv_Articulos.Columns(i).Width = 50
                                Dgv_Articulos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Case "CONTROLARTICULOS"
                                Dgv_Articulos.Columns(i).HeaderText = "CTR"
                                Dgv_Articulos.Columns(i).Width = 60
                                Dgv_Articulos.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        End Select
                    Next

                    For i = 4 To Dgv_Articulos.ColumnCount - 1
                        Dgv_Articulos.Columns(i).Visible = False
                    Next

                    Windows.Forms.Cursor.Current = Cursors.Default

            End Select
        End If
    End Sub

    Private Sub Dgv_Articulos_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles Dgv_Articulos.DataBindingComplete
        For Each row As DataGridViewRow In Dgv_Articulos.Rows
            If Not IsDBNull(row.Cells("FOTOARTICULO").Value) Then
                row.Cells("ID") = New DataGridViewLinkCell
            End If
        Next
    End Sub



    Private Sub Dgv_Artículos_CellContentClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles Dgv_Articulos.CellContentClick
        If e.ColumnIndex = 0 Then
            If Dgv_Articulos.Rows(e.RowIndex).Cells(e.ColumnIndex).GetType Is GetType(DataGridViewLinkCell) Then
                Dim frMostrarFoto As New FormulariosClasesBase.Fr_MostrarFoto
                
                Dim Foto As Boolean = GoogleDrive.DescargarFotos("art_" + Dgv_Articulos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString, "Artículos")
                If Foto Then
                    Dim appPath As String = Application.StartupPath + "/Temp.jpg"
                    Dim filestream As New IO.FileStream(appPath, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim imagen As Image = Image.FromStream(filestream)
                    filestream.Close()
                    frMostrarFoto.Set_Pb_Foto_Image(imagen)
                End If
                frMostrarFoto.ShowDialog()
                Dim appPath2 As String
                Try
                    appPath2 = Application.StartupPath + "\Temp.jpg"
                    If My.Computer.FileSystem.FileExists(appPath2) Then
                        My.Computer.FileSystem.DeleteFile(appPath2)
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Function ExtraerNombreArbol(ByVal nodo As TreeNode) As String
        Dim Nombre As String = ""
        Select Case nodo.Tag
            Case "FAMILIA"
                Dim node As New NodoFamilia
                node = nodo
                ExtraerNombreArbol = node.NOMBREFAMILIA
            Case "GRUPO"
                Dim node As New NodoGrupo
                node = nodo
                Nombre = node.NOMBREGRUPOMATERIAL
                Dim nodopadre As New NodoFamilia
                nodopadre = nodo.Parent
                ExtraerNombreArbol = ExtraerNombreArbol(nodopadre) + " " + Nombre
            Case "CLASE"
                Dim node As New NodoClase
                node = nodo
                Nombre = node.NOMBRECLASEMATERIAL
                Dim nodopadre As New NodoGrupo
                nodopadre = nodo.Parent
                ExtraerNombreArbol = ExtraerNombreArbol(nodopadre) + " " + Nombre
            Case "SUBCLASE"
                Dim node As New NodoSubClase
                node = nodo
                Nombre = node.NOMBRESUBCLASEMATERIAL
                Dim nodopadre As New NodoClase
                nodopadre = nodo.Parent
                ExtraerNombreArbol = ExtraerNombreArbol(nodopadre) + " " + Nombre
            Case "TIPO CATEGORIA"
                Dim node As New NodoTipoCategoría
                node = nodo
                Nombre = node.NOMBRETIPOCATEGORIAMATERIAL
                Dim nodopadre As TreeNode
                nodopadre = nodo.Parent
                Select Case nodopadre.Tag
                    Case "SUBCLASE"
                        Dim nodopadre1 As New NodoSubClase
                        nodopadre1 = nodo.Parent
                        ExtraerNombreArbol = ExtraerNombreArbol(nodopadre1) + " " + Nombre
                    Case "CLASE"
                        Dim nodopadre1 As New NodoClase
                        nodopadre1 = nodo.Parent
                        ExtraerNombreArbol = ExtraerNombreArbol(nodopadre1) + " " + Nombre
                    Case "CATEGORIA"
                        Dim nodopadre1 As New NodoCategoría
                        nodopadre1 = nodo.Parent
                        ExtraerNombreArbol = ExtraerNombreArbol(nodopadre1) + " " + Nombre
                    Case Else
                        ExtraerNombreArbol = ""
                End Select
            Case "CATEGORIA"
                Dim node As New NodoCategoría
                node = nodo
                Nombre = node.NOMBRECATEGORIAMATERIAL
                Dim nodopadre As NodoTipoCategoría
                nodopadre = nodo.Parent
                ExtraerNombreArbol = ExtraerNombreArbol(nodopadre) + " " + Nombre
            Case Else
                ExtraerNombreArbol = ""
        End Select
    End Function

    Private Sub Tv_Grupos_Click(sender As Object, e As EventArgs) Handles Tv_Grupos.Click

        Me.Dgv_Articulos.DataSource = Nothing
        Me.Dgv_Articulos.Refresh()

    End Sub

    Private Sub Tv_Grupos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tv_Grupos.DoubleClick
        Cargar_Nodos_Hijos()
    End Sub


    Private Sub Tsmi_CrearTipoCategoría_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsmi_CrearTipoCategoría.Click
        Dim NombreCategoria As String
        NombreCategoria = Trim(InputBox("¿Nombre del Tipo Categoría?", "CREAR TIPO CATEGORÍA", ""))
        If LTrim(NombreCategoria) <> "" Then
            'se crea el tipo categoría
            'Llamar al procedimiento para crear el tipo categoría
            Dim Comando As New SqlClient.SqlCommand("dbo.CrearTipoCategoría")
            Comando.CommandType = CommandType.StoredProcedure
            Dim node As NodoSubClase
            node = Tv_Grupos.SelectedNode
            Comando.Parameters.AddWithValue("@CODIGOARBOL", Trim(node.Name))
            Comando.Parameters.AddWithValue("@NOMBRECATEGORIA", NombreCategoria)
            Comando.Parameters.AddWithValue("@IDUSUARIOREGISTRO", VariablesBase.VariablesBase.IdPersona)
            Dim msgParam As New SqlParameter("@CODIGOCATEGORIA", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            Comando.Parameters.Add(msgParam)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Comando.ExecuteNonQuery()
            conn.Close()
            Dim nodotipocategoria As New NodoTipoCategoría
            nodotipocategoria.Text = NombreCategoria
            nodotipocategoria.CODIGOARBOL = Trim(node.CODIGOARBOL)
            nodotipocategoria.CODIGOTIPOCATEGORIAMATERIAL = Comando.Parameters("@CODIGOCATEGORIA").Value
            nodotipocategoria.NOMBRETIPOCATEGORIAMATERIAL = NombreCategoria
            nodotipocategoria.ContextMenuStrip = Cms_TipoCategoría
            node.ContextMenuStrip = Cms_SubClaseSinCategoría
            node.Nodes.Add(nodotipocategoria)
            node.ExpandAll()
        End If
    End Sub

    Private Sub CrearCategoríaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsmi_CrearCategoría.Click
        Dim FrCategoríaMaterial As New Fr_CategoríaMaterial
        FrCategoríaMaterial.Cargar_Tablas()
        FrCategoríaMaterial.ShowDialog()
        Dim NombreCategoria As String = FrCategoríaMaterial.Tx_NombreCategoría.Text
        If Trim(NombreCategoria) <> "" Then
            Dim CodigoArbol As String
            CodigoArbol = FrCategoríaMaterial.Tx_CódigoCategoría.Text
            If Trim(CodigoArbol) = "" Then
                MsgBox("Código no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            If IsNumeric(CodigoArbol) = False Then
                MsgBox("Código no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            If CodigoArbol.Length = 1 Or CodigoArbol.Length > 2 Then
                MsgBox("Código no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            'se crea la categoría
            'Llamar al procedimiento para crear la categoría
            Dim Comando As New SqlClient.SqlCommand("dbo.CrearCategoría")
            Comando.CommandType = CommandType.StoredProcedure

            Dim nodo1 As TreeNode
            nodo1 = Tv_Grupos.SelectedNode

            If nodo1.Tag = "SUBCLASE" Then
                Dim node As NodoSubClase
                node = Tv_Grupos.SelectedNode
                Comando.Parameters.AddWithValue("@CODIGOARBOL", Trim(node.CODIGOARBOL + CodigoArbol))
                Comando.Parameters.AddWithValue("@NOMBRECATEGORIA", NombreCategoria)
                Comando.Parameters.AddWithValue("@IDUSUARIOREGISTRO", VariablesBase.VariablesBase.IdPersona)
                Comando.Parameters.AddWithValue("@CODIGOTIPOUNIDAD", FrCategoríaMaterial.Cb_Unidad.SelectedValue)
                Dim msgParam As New SqlParameter("@CODIGOCATEGORIA", SqlDbType.Int, 1)
                msgParam.Direction = ParameterDirection.Output
                Comando.Parameters.Add(msgParam)
                Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                conn.Open()
                Comando.Connection = conn
                Comando.ExecuteNonQuery()
                conn.Close()
                If Comando.Parameters("@CODIGOCATEGORIA").Value = -1 Then
                    MsgBox("Ya existe una categoría con este código de árbol", MsgBoxStyle.Exclamation, "YA EXISTE EL CÓDIGO DE ÁRBOL")
                    Exit Sub
                Else
                    Dim nodocategoria As New NodoCategoría
                    nodocategoria.Text = CodigoArbol + " - " + NombreCategoria
                    nodocategoria.CODIGOARBOL = Trim(node.CODIGOARBOL + CodigoArbol)
                    nodocategoria.Name = nodocategoria.CODIGOARBOL
                    nodocategoria.NOMBRECATEGORIAMATERIAL = NombreCategoria
                    nodocategoria.CODIGOCATEGORIAMATERIAL = Comando.Parameters("@CODIGOCATEGORIA").Value
                    nodocategoria.ContextMenuStrip = Cms_Categoría
                    nodocategoria.IDCODIGOTIPOUNIDAD = FrCategoríaMaterial.Cb_Unidad.SelectedValue
                    node.Nodes.Add(nodocategoria)
                End If
                node.ExpandAll()
            Else
                'Viene de tipo categoría
                Dim node As NodoTipoCategoría
                node = Tv_Grupos.SelectedNode
                Comando.Parameters.AddWithValue("@CODIGOARBOL", Trim(node.CODIGOARBOL + CodigoArbol))
                Comando.Parameters.AddWithValue("@NOMBRECATEGORIA", NombreCategoria)
                Comando.Parameters.AddWithValue("@IDUSUARIOREGISTRO", VariablesBase.VariablesBase.IdPersona)
                Comando.Parameters.AddWithValue("@CODIGOTIPOUNIDAD", FrCategoríaMaterial.Cb_Unidad.SelectedValue)
                Dim msgParam As New SqlParameter("@CODIGOCATEGORIA", SqlDbType.Int, 1)
                msgParam.Direction = ParameterDirection.Output
                Comando.Parameters.Add(msgParam)
                Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
                conn.Open()
                Comando.Connection = conn
                Comando.ExecuteNonQuery()
                conn.Close()
                If Comando.Parameters("@CODIGOCATEGORIA").Value = -1 Then
                    MsgBox("Ya existe una categoría con este código de árbol", MsgBoxStyle.Exclamation, "YA EXISTE EL CÓDIGO DE ÁRBOL")
                    Exit Sub
                Else
                    Dim nodocategoria As New NodoCategoría
                    nodocategoria.Text = CodigoArbol + " - " + NombreCategoria
                    nodocategoria.CODIGOARBOL = Trim(node.CODIGOARBOL + CodigoArbol)
                    nodocategoria.Name = nodocategoria.CODIGOARBOL
                    nodocategoria.NOMBRECATEGORIAMATERIAL = NombreCategoria
                    nodocategoria.CODIGOCATEGORIAPADRE = node.CODIGOTIPOCATEGORIAMATERIAL
                    nodocategoria.CODIGOCATEGORIAMATERIAL = Comando.Parameters("@CODIGOCATEGORIA").Value
                    nodocategoria.ContextMenuStrip = Cms_Categoría
                    nodocategoria.IDCODIGOTIPOUNIDAD = FrCategoríaMaterial.Cb_Unidad.SelectedValue
                    node.Nodes.Add(nodocategoria)
                End If
                node.Nodes.Clear()
                Cargar_Nodos_Hijos()
                node.ExpandAll()
            End If
        End If
    End Sub

    Private Sub Bt_ImprimirSticker_Click(sender As System.Object, e As System.EventArgs)
        ImprimirSticker()
    End Sub

    Private Sub Bt_BuscarArtículo_Click(sender As System.Object, e As System.EventArgs)
        BuscarArticulo()
    End Sub

    Private Sub ImprimirSticker()
        If FuncionesBase.FuncionesBase.ConsultarPermiso(349) Then 'Imprimir sticker
            Dim FrImprimirSticker As New Fr_ImprimirSticker
            FrImprimirSticker.ShowDialog()
        Else
            MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
        End If
    End Sub

    Private Sub Tv_Grupos_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles Tv_Grupos.NodeMouseClick
        Dim nodo As New TreeNode
        nodo = e.Node
        Tv_Grupos.SelectedNode = nodo
    End Sub

    Private Sub Tsmi_CrearTipoCategoríaStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsmi_CrearTipoCategoríaStrip.Click
        Dim NombreCategoria As String
        NombreCategoria = Trim(InputBox("¿Nombre del Tipo Categoría?", "CREAR TIPO CATEGORÍA", ""))
        If LTrim(NombreCategoria) <> "" Then
            'se crea el tipo categoría
            'Llamar al procedimiento para crear el tipo categoría
            Dim Comando As New SqlClient.SqlCommand("dbo.CrearTipoCategoría")
            Comando.CommandType = CommandType.StoredProcedure
            Dim node As NodoCategoría
            node = Tv_Grupos.SelectedNode
            Comando.Parameters.AddWithValue("@CODIGOARBOL", Trim(node.CODIGOARBOL))
            Comando.Parameters.AddWithValue("@NOMBRECATEGORIA", NombreCategoria)
            Comando.Parameters.AddWithValue("@IDUSUARIOREGISTRO", VariablesBase.VariablesBase.IdPersona)
            Dim msgParam As New SqlParameter("@CODIGOCATEGORIA", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            Comando.Parameters.Add(msgParam)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Comando.ExecuteNonQuery()
            conn.Close()
            Dim nodotipocategoria As New NodoTipoCategoría
            nodotipocategoria.Text = NombreCategoria
            nodotipocategoria.CODIGOARBOL = Trim(node.CODIGOARBOL)
            nodotipocategoria.CODIGOTIPOCATEGORIAMATERIAL = Comando.Parameters("@CODIGOCATEGORIA").Value
            nodotipocategoria.ContextMenuStrip = Cms_TipoCategoría
            node.ContextMenuStrip = Cms_CategoríaSinCategoria
            node.Nodes.Add(nodotipocategoria)
            node.ExpandAll()
        End If
    End Sub

    Private Sub Crear1ArtículoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsmi_CrearArtículo.Click, Tsmi_CrearArtículo2.Click
        Dim node As NodoCategoría
        node = Tv_Grupos.SelectedNode
        Dim FrArtículo As New Fr_Artículo
        FrArtículo.Tx_NombreCategoría.Text = ExtraerNombreArbol(node)
        FrArtículo.CODIGOCATEGORIA = node.CODIGOCATEGORIAMATERIAL
        FrArtículo.IDUNIDAD = node.IDCODIGOTIPOUNIDAD
        FrArtículo.Nuevo = True
        FrArtículo.Cargar_Tablas()
        FrArtículo.ShowDialog()
        Cargar_Nodos_Hijos()
    End Sub

    Private Sub CrearSubclaseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_CrearSubclase.Click
        Dim NOMBRESUBCLASE As String
        NOMBRESUBCLASE = InputBox("¿Nombre de la nueva Subclase?", "NUEVA SUBCLASE", "")
        If Trim(NOMBRESUBCLASE) <> "" Then
            Dim CODIGOSUBCLASEMATERIAL As String
            CODIGOSUBCLASEMATERIAL = Trim(InputBox("¿Código nueva Subclase? Ejemplo: 001,002,003 ", "NUEVA SUBCLASE", ""))
            If Trim(CODIGOSUBCLASEMATERIAL) = "" Then
                MsgBox("Código de Subclase no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            If IsNumeric(Trim(CODIGOSUBCLASEMATERIAL)) = False Then
                MsgBox("Código de Subclase no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            If Trim(CODIGOSUBCLASEMATERIAL).Length <> 3 Then
                MsgBox("Código de Subclase no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            'se crea el tipo categoría
            'Llamar al procedimiento para crear el tipo categoría
            Dim Comando As New SqlClient.SqlCommand("dbo.CrearSubClaseMaterial")
            Comando.CommandType = CommandType.StoredProcedure
            Dim nodo As New NodoClase
            nodo = Tv_Grupos.SelectedNode
            Comando.Parameters.AddWithValue("@CODIGOSUBCLASEMATERIAL", CODIGOSUBCLASEMATERIAL)
            Comando.Parameters.AddWithValue("@NOMBRESUBCLASEMATERIAL", NOMBRESUBCLASE)
            Comando.Parameters.AddWithValue("@IDCLASEMATERIAL", nodo.IDCLASEMATERIAL)
            Dim msgParam As New SqlParameter("@IDSUBCLASEMATERIAL", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            Comando.Parameters.Add(msgParam)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Comando.ExecuteNonQuery()
            conn.Close()
            Select Case Comando.Parameters("@IDSUBCLASEMATERIAL").Value
                Case -1
                    MsgBox("Ya existe una subclase con este código para la clase seleccionado", MsgBoxStyle.Critical, "CREAR SUBCLASE")
                Case Else
                    Dim _NodoSubClase As New NodoSubClase
                    _NodoSubClase.CODIGOSUBCLASEMATERIAL = CODIGOSUBCLASEMATERIAL
                    _NodoSubClase.Name = nodo.Name + CODIGOSUBCLASEMATERIAL
                    _NodoSubClase.IDSUBCLASEMATERIAL = Comando.Parameters("@IDSUBCLASEMATERIAL").Value
                    _NodoSubClase.Text = CODIGOSUBCLASEMATERIAL + " - " + NOMBRESUBCLASE
                    _NodoSubClase.CODIGOARBOL = nodo.Name + CODIGOSUBCLASEMATERIAL
                    _NodoSubClase.NOMBRESUBCLASEMATERIAL = NOMBRESUBCLASE
                    _NodoSubClase.ContextMenuStrip = Cms_SubClase
                    nodo.Nodes.Add(_NodoSubClase)
            End Select
            nodo.ExpandAll()
        End If
    End Sub

    Private Sub Tsmi_CrearClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsmi_CrearClase.Click
        Dim NOMBRECLASE As String
        NOMBRECLASE = InputBox("¿Nombre de la nueva Clase?", "NUEVA CLASE", "")
        If Trim(NOMBRECLASE) <> "" Then
            Dim CODIGOCLASEMATERIAL As String
            CODIGOCLASEMATERIAL = Trim(InputBox("¿Código nueva Clase? Ejemplo: 001,002,003 ", "NUEVA CLASE", ""))
            If Trim(CODIGOCLASEMATERIAL) = "" Then
                MsgBox("Código de clase no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            If IsNumeric(Trim(CODIGOCLASEMATERIAL)) = False Then
                MsgBox("Código de clase no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            If Trim(CODIGOCLASEMATERIAL).Length <> 3 Then
                MsgBox("Código de clase no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            'se crea el tipo categoría
            'Llamar al procedimiento para crear el tipo categoría
            Dim Comando As New SqlClient.SqlCommand("dbo.CrearClaseMaterial")
            Comando.CommandType = CommandType.StoredProcedure
            Dim nodo As New NodoGrupo
            nodo = Tv_Grupos.SelectedNode
            Comando.Parameters.AddWithValue("@CODIGOCLASEMATERIAL", CODIGOCLASEMATERIAL)
            Comando.Parameters.AddWithValue("@NOMBRECLASEMATERIAL", NOMBRECLASE)
            Comando.Parameters.AddWithValue("@IDGRUPOMATERIAL", nodo.IDGRUPOMATERIAL)
            Dim msgParam As New SqlParameter("@IDCLASEMATERIAL", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            Comando.Parameters.Add(msgParam)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Comando.ExecuteNonQuery()
            conn.Close()
            Select Case Comando.Parameters("@IDCLASEMATERIAL").Value
                Case -1
                    MsgBox("Ya existe una clase con este código para el grupo seleccionado", MsgBoxStyle.Critical, "CREAR CLASE")
                Case Else
                    Dim _NodoClase As New NodoClase
                    _NodoClase.CODIGOCLASEMATERIAL = CODIGOCLASEMATERIAL
                    _NodoClase.Name = nodo.Name + CODIGOCLASEMATERIAL
                    _NodoClase.IDCLASEMATERIAL = Comando.Parameters("@IDCLASEMATERIAL").Value
                    _NodoClase.Text = CODIGOCLASEMATERIAL + " - " + NOMBRECLASE
                    _NodoClase.CODIGOARBOL = nodo.Name + CODIGOCLASEMATERIAL
                    _NodoClase.NOMBRECLASEMATERIAL = NOMBRECLASE
                    _NodoClase.ContextMenuStrip = Cms_Clase
                    nodo.Nodes.Add(_NodoClase)
            End Select
            nodo.ExpandAll()
        End If
    End Sub

    Private Sub Tsmi_CrearGrupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsmi_CrearGrupo.Click
        Dim NOMBREGRUPO As String
        NOMBREGRUPO = InputBox("¿Nombre del nuevo grupo?", "NUEVO GRUPO", "")
        If Trim(NOMBREGRUPO) <> "" Then
            Dim CODIGOGRUPOMATERIAL As String
            CODIGOGRUPOMATERIAL = Trim(InputBox("¿Código nuevo Grupo? Ejemplo: 001,002,003 ", "NUEVO GRUPO", ""))
            If Trim(CODIGOGRUPOMATERIAL) = "" Then
                MsgBox("Código de grupo no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            If IsNumeric(Trim(CODIGOGRUPOMATERIAL)) = False Then
                MsgBox("Código de grupo no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            If Trim(CODIGOGRUPOMATERIAL).Length <> 3 Then
                MsgBox("Código de grupo no válido", MsgBoxStyle.Critical, "CÓDIGO NO VÁLIDO")
                Exit Sub
            End If
            'se crea el tipo categoría
            'Llamar al procedimiento para crear el tipo categoría
            Dim Comando As New SqlClient.SqlCommand("dbo.CrearGrupoMaterial")
            Comando.CommandType = CommandType.StoredProcedure
            Dim nodo As New NodoFamilia
            nodo = Tv_Grupos.SelectedNode
            Comando.Parameters.AddWithValue("@CODIGOGRUPOMATERIAL", CODIGOGRUPOMATERIAL)
            Comando.Parameters.AddWithValue("@NOMBREGRUPOMATERIAL", NOMBREGRUPO)
            Comando.Parameters.AddWithValue("@IDFAMILIAMATERIAL", nodo.IDFAMILIAMATERIAL)
            Dim msgParam As New SqlParameter("@IDGRUPOMATERIAL", SqlDbType.Int, 1)
            msgParam.Direction = ParameterDirection.Output
            Comando.Parameters.Add(msgParam)
            Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
            conn.Open()
            Comando.Connection = conn
            Comando.ExecuteNonQuery()
            conn.Close()
            Select Case Comando.Parameters("@IDGRUPOMATERIAL").Value
                Case -1
                    MsgBox("Ya existe un grupo con este código para la familia seleccionada", MsgBoxStyle.Critical, "CREAR GRUPO")
                Case Else
                    Dim _NodoGrupo As New NodoGrupo
                    _NodoGrupo.CODIGOGRUPOMATERIAL = CODIGOGRUPOMATERIAL
                    _NodoGrupo.Name = nodo.Name + CODIGOGRUPOMATERIAL
                    _NodoGrupo.IDGRUPOMATERIAL = Comando.Parameters("@IDGRUPOMATERIAL").Value
                    _NodoGrupo.Text = CODIGOGRUPOMATERIAL + " - " + NOMBREGRUPO
                    _NodoGrupo.CODIGOARBOL = nodo.Name + CODIGOGRUPOMATERIAL
                    _NodoGrupo.NOMBREGRUPOMATERIAL = NOMBREGRUPO
                    _NodoGrupo.ContextMenuStrip = Cms_Grupo
                    nodo.Nodes.Add(_NodoGrupo)
            End Select
            nodo.ExpandAll()
        End If
    End Sub

    Private Sub Tsmi_EliminarGrupo_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_EliminarGrupo.Click
        Dim nodo As New NodoGrupo
        nodo = Tv_Grupos.SelectedNode
        If EliminarItemArbol(1, nodo.IDGRUPOMATERIAL) = -1 Then
            Dim nodopadre As TreeNode
            nodopadre = nodo.Parent
            nodopadre.Nodes.Clear()
        End If
        MA_GRUPOMATERIALTableAdapter1.Fill(Ds_Grupos.MA_GRUPOMATERIAL)
    End Sub

    Private Sub Tsmi_EliminarFamilia_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_EliminarFamilia.Click
        Dim nodo As New NodoFamilia
        nodo = Tv_Grupos.SelectedNode
        If EliminarItemArbol(0, nodo.IDFAMILIAMATERIAL) = -1 Then
            Dim nodopadre As TreeNode
            nodopadre = nodo.Parent
            nodopadre.Nodes.Clear()
        End If
        MA_FAMILIAMATERIALTableAdapter1.Fill(Ds_Grupos.MA_FAMILIAMATERIAL)
    End Sub

    Private Sub Tsmi_EliminarSubClase_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_EliminarSubClase.Click, Tsmi_EliminarSubClaseSinCategoría.Click
        Dim nodo As New NodoSubClase
        nodo = Tv_Grupos.SelectedNode
        If EliminarItemArbol(5, nodo.IDSUBCLASEMATERIAL) = -1 Then
            Dim nodopadre As TreeNode
            nodopadre = nodo.Parent
            nodopadre.Nodes.Clear()
        End If
        MA_SUBCLASEMATERIALTableAdapter1.Fill(Ds_Grupos.MA_SUBCLASEMATERIAL)
    End Sub

    Private Sub Tsmi_EliminarTipoCategoría_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_EliminarTipoCategoría.Click
        Dim nodo As New NodoTipoCategoría
        nodo = Tv_Grupos.SelectedNode
        If EliminarItemArbol(3, nodo.CODIGOTIPOCATEGORIAMATERIAL) = -1 Then
            Dim nodopadre As TreeNode
            nodopadre = nodo.Parent
            nodopadre.Nodes.Clear()
            Select Case nodopadre.Tag
                Case "SUBCLASE"
                    nodopadre.ContextMenuStrip = Cms_SubClase
                Case "CATEGORIA"
                    nodopadre.ContextMenuStrip = Cms_Categoría
            End Select

        End If
    End Sub

    Private Sub Tsmi_EliminarCategoría_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_EliminarCategoría.Click, Tsmi_EliminarCategoríaSinCategoría.Click
        Dim nodo As New NodoCategoría
        nodo = Tv_Grupos.SelectedNode
        If EliminarItemArbol(4, nodo.CODIGOCATEGORIAMATERIAL) = -1 Then
            Dim nodopadre As TreeNode
            nodopadre = nodo.Parent
            nodopadre.Nodes.Clear()
        End If
    End Sub

    Private Function EliminarItemArbol(ByVal Tipo As Integer, ByVal ID As Integer) As Integer
        ''--0 Familia, 1 Grupo, 2 Clase, 3 Tipo Categoría, 4 Categoría
        'Llamar al procedimiento para borrar ítem del árbol
        Dim Comando As New SqlClient.SqlCommand("dbo.EliminarArbolMaterial")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TIPO", Tipo)
        Comando.Parameters.AddWithValue("@ID", ID)
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim msgParam As New SqlParameter("@MENSAJE", SqlDbType.NVarChar, 50)
        Dim msgParam1 As New SqlParameter("@IDMENSAJE", SqlDbType.Int, 1)
        msgParam.Direction = ParameterDirection.Output
        msgParam1.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Comando.Parameters.Add(msgParam1)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        conn.Open()
        Comando.Connection = conn
        Comando.ExecuteNonQuery()
        conn.Close()
        MsgBox(Comando.Parameters("@MENSAJE").Value)
        EliminarItemArbol = Comando.Parameters("@IDMENSAJE").Value
    End Function

    Private Sub EliminarArtículoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EliminarArtículoToolStripMenuItem.Click
        If MsgBox("Seguro que desea eliminar los artículos seleccionados", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar Artículos") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim TablaEliminarArticulos As New DataTable
        TablaEliminarArticulos.Columns.Add("IDARTICULO")
        For i = 0 To Dgv_Articulos.SelectedRows.Count - 1
            Dim Fila As DataRow
            Fila = TablaEliminarArticulos.NewRow
            Fila("IDARTICULO") = Dgv_Articulos.SelectedRows(i).Cells(0).Value
            TablaEliminarArticulos.Rows.Add(Fila)
        Next
        Dim Comando As New SqlClient.SqlCommand("dbo.EliminarArticulos")
        Comando.CommandType = CommandType.StoredProcedure
        Comando.Parameters.AddWithValue("@TableIDARTICULOS", TablaEliminarArticulos)
        Comando.Parameters.AddWithValue("@IDUSUARIO", VariablesBase.VariablesBase.IdPersona)
        Dim msgParam As New SqlParameter("@MENSAJE", SqlDbType.VarChar, 50)
        msgParam.Direction = ParameterDirection.Output
        Comando.Parameters.Add(msgParam)
        Dim conn As New SqlClient.SqlConnection(My.Settings.CadenaConexión)
        Try
            conn.Open()
            Comando.Connection = conn
            Comando.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox("Debe eliminar el tipo de control de articulo primero")
        End Try

        If Comando.Parameters("@MENSAJE").Value <> "" Then
            MsgBox(Comando.Parameters("@MENSAJE").Value)
        End If
        Cargar_Nodos_Hijos()
    End Sub

    Private Sub AgregarControlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarControlToolStripMenuItem.Click
        Dim idArticulo As Integer = Dgv_Articulos.SelectedRows(0).Cells("ID").Value
        Dim tipo As String = "N"
        'If Not IsDBNull(Dgv_Articulos.SelectedRows(0).Cells("CONTROLADODOTACIONYPAPELERIA").Value) Then
        '    tipo = Dgv_Articulos.SelectedRows(0).Cells("CONTROLADODOTACIONYPAPELERIA").Value
        'End If
        If Not IsDBNull(Dgv_Articulos.SelectedRows(0).Cells("CONTROLARTICULOS").Value) Then
            tipo = Dgv_Articulos.SelectedRows(0).Cells("CONTROLARTICULOS").Value
        End If
        Dim frTipoControl As New Fr_TipoControlArticulo(idArticulo, tipo)
        If frTipoControl.ShowDialog() = DialogResult.OK Then
            MsgBox("Cambios realizados.", MsgBoxStyle.Information, "AGREGAR CONTROL")
            BuscarArticulo(idArticulo)
        End If
    End Sub

    Private Sub Tsmi_CambiarNombreFamilia_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_CambiarNombreFamilia.Click
        Dim _NodoFamilia As New NodoFamilia
        _NodoFamilia = Tv_Grupos.SelectedNode
        If MsgBox("¿Seguro que desea cambiar el nombre de la familia?", MsgBoxStyle.YesNo, "Cambiar nombre familia") = MsgBoxResult.Yes Then
            Dim NuevoNombre As String = InputBox("¿Nuevo nombre de la Familia?", "Cambiar Nombre Familia", _NodoFamilia.NOMBREFAMILIA)
            If Trim(NuevoNombre) <> "" Then
                Dim adap As New DatosArticulos.Ds_GruposTableAdapters.ProcedimientosActualizarNombres
                adap.ActualizarNombreFamilia(Trim(NuevoNombre), _NodoFamilia.IDFAMILIAMATERIAL)
                _NodoFamilia.Text = _NodoFamilia.CODIGOARBOL + " - " + Trim(NuevoNombre)
                _NodoFamilia.NOMBREFAMILIA = Trim(NuevoNombre)
            End If
        End If
    End Sub

    Private Sub Tsmi_CambiarNombreGrupo_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_CambiarNombreGrupo.Click
        Dim _NodoGrupo As New NodoGrupo
        _NodoGrupo = Tv_Grupos.SelectedNode
        If MsgBox("¿Seguro que desea cambiar el nombre del grupo?", MsgBoxStyle.YesNo, "Cambiar nombre grupo") = MsgBoxResult.Yes Then
            Dim NuevoNombre As String = InputBox("¿Nuevo nombre del grupo?", "Cambiar Nombre Grupo", _NodoGrupo.NOMBREGRUPOMATERIAL)
            If Trim(NuevoNombre) <> "" Then
                Dim adap As New DatosArticulos.Ds_GruposTableAdapters.ProcedimientosActualizarNombres
                adap.ActualizarNombreGrupo(Trim(NuevoNombre), _NodoGrupo.IDGRUPOMATERIAL)
                _NodoGrupo.Text = _NodoGrupo.CODIGOGRUPOMATERIAL + " - " + Trim(NuevoNombre)
                _NodoGrupo.NOMBREGRUPOMATERIAL = Trim(NuevoNombre)
            End If
        End If
    End Sub

    Private Sub CambiarNombreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_CambiarNombreClase.Click
        Dim _NodoClase As New NodoClase
        _NodoClase = Tv_Grupos.SelectedNode
        If MsgBox("¿Seguro que desea cambiar el nombre de la clase?", MsgBoxStyle.YesNo, "Cambiar nombre clase") = MsgBoxResult.Yes Then
            Dim NuevoNombre As String = InputBox("¿Nuevo nombre de la clase?", "Cambiar Nombre Clase", _NodoClase.NOMBRECLASEMATERIAL)
            If Trim(NuevoNombre) <> "" Then
                Dim adap As New DatosArticulos.Ds_GruposTableAdapters.ProcedimientosActualizarNombres
                adap.ActualizarNombreClase(Trim(NuevoNombre), _NodoClase.IDCLASEMATERIAL)
                _NodoClase.Text = _NodoClase.CODIGOCLASEMATERIAL + " - " + Trim(NuevoNombre)
                _NodoClase.NOMBRECLASEMATERIAL = Trim(NuevoNombre)
            End If
        End If
    End Sub

    Private Sub Tsmi_CambiarNombreSubClase_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_CambiarNombreSubClase.Click, Tsmi_CambiarNombreSubClaseSinCategoría.Click
        Dim _NodoSubClase As New NodoSubClase
        _NodoSubClase = Tv_Grupos.SelectedNode
        If MsgBox("¿Seguro que desea cambiar el nombre de la subclase?", MsgBoxStyle.YesNo, "Cambiar nombre subclase") = MsgBoxResult.Yes Then
            Dim NuevoNombre As String = InputBox("¿Nuevo nombre de la subclase?", "Cambiar Nombre Subclase", _NodoSubClase.NOMBRESUBCLASEMATERIAL)
            If Trim(NuevoNombre) <> "" Then
                Dim adap As New DatosArticulos.Ds_GruposTableAdapters.ProcedimientosActualizarNombres
                adap.ActualizarNombreSubClase(Trim(NuevoNombre), _NodoSubClase.IDSUBCLASEMATERIAL)
                _NodoSubClase.Text = _NodoSubClase.CODIGOSUBCLASEMATERIAL + " - " + Trim(NuevoNombre)
                _NodoSubClase.NOMBRESUBCLASEMATERIAL = Trim(NuevoNombre)
            End If
        End If
    End Sub

    Private Sub Tsmi_CambiarNombreTipoCategoría_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_CambiarNombreTipoCategoría.Click
        Dim _NodoTipoCategoría As New NodoTipoCategoría
        _NodoTipoCategoría = Tv_Grupos.SelectedNode
        If MsgBox("¿Seguro que desea cambiar el nombre del tipo de la categoría?", MsgBoxStyle.YesNo, "Cambiar nombre tipo categoría") = MsgBoxResult.Yes Then
            Dim NuevoNombre As String = InputBox("¿Nuevo nombre del tipo de categoría?", "Cambiar Nombre Tipo Categoría", _NodoTipoCategoría.NOMBRETIPOCATEGORIAMATERIAL)
            If Trim(NuevoNombre) <> "" Then
                Dim adap As New DatosArticulos.Ds_GruposTableAdapters.ProcedimientosActualizarNombres
                adap.ActualizarNombreCategoría(Trim(NuevoNombre), _NodoTipoCategoría.CODIGOTIPOCATEGORIAMATERIAL)
                _NodoTipoCategoría.Text = Trim(NuevoNombre)
                _NodoTipoCategoría.NOMBRETIPOCATEGORIAMATERIAL = Trim(NuevoNombre)
            End If
        End If
    End Sub

    Private Sub Tsmi_CambiarNombreCategoría_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_CambiarNombreCategoría.Click, Tsmi_CambiarNombreCategoríaSinCategoría.Click
        Dim _NodoCategoría As New NodoCategoría
        _NodoCategoría = Tv_Grupos.SelectedNode
        If MsgBox("¿Seguro que desea cambiar el nombre de la categoría?", MsgBoxStyle.YesNo, "Cambiar nombre categoría") = MsgBoxResult.Yes Then
            Dim NuevoNombre As String = InputBox("¿Nuevo nombre de la categoría?", "Cambiar Nombre Categoría", _NodoCategoría.NOMBRECATEGORIAMATERIAL)
            If Trim(NuevoNombre) <> "" Then
                Dim adap As New DatosArticulos.Ds_GruposTableAdapters.ProcedimientosActualizarNombres
                adap.ActualizarNombreCategoría(Trim(NuevoNombre), _NodoCategoría.CODIGOCATEGORIAMATERIAL)
                _NodoCategoría.Text = Mid(_NodoCategoría.CODIGOARBOL, _NodoCategoría.CODIGOARBOL.Length - 1, 2) + " - " + Trim(NuevoNombre)
                _NodoCategoría.NOMBRECATEGORIAMATERIAL = Trim(NuevoNombre)
            End If
        End If
    End Sub

    Private Sub ModificarArtículoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ModificarArtículoToolStripMenuItem.Click
        If Dgv_Articulos.SelectedRows.Count = 1 Then
            Dim idArticulo As Integer = Dgv_Articulos.SelectedRows(0).Cells(0).Value
            Dim FrArtículo As New Fr_Artículo
            FrArtículo.Nuevo = False
            FrArtículo.IdArticuloEditando = idArticulo

            Dim node As NodoCategoría
            If Tv_Grupos.SelectedNode.GetType() Is GetType(NodoCategoría) Then
                node = Tv_Grupos.SelectedNode
            Else
                node = Tv_Grupos.SelectedNode.Parent
            End If
            FrArtículo.Tx_NombreCategoría.Text = ExtraerNombreArbol(node)
            FrArtículo.CODIGOCATEGORIA = node.CODIGOCATEGORIAMATERIAL
            FrArtículo.Cargar_Tablas()
            FrArtículo.ShowDialog()
            BuscarArticulo(idArticulo)
        End If
    End Sub

    Private Sub EliminarClaseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Tsmi_EliminarClase.Click
        Dim nodo As New NodoClase
        nodo = Tv_Grupos.SelectedNode
        If EliminarItemArbol(2, nodo.IDCLASEMATERIAL) = -1 Then
            Dim nodopadre As TreeNode
            nodopadre = nodo.Parent
            nodopadre.Nodes.Clear()
        End If
    End Sub

    Private Sub Dgv_Artículos_SelectionChanged(sender As Object, e As System.EventArgs) Handles Dgv_Articulos.SelectionChanged
        If Ck_MostrarDisponibilidad.Checked = True Then
            Try
                CargarDisponibilidad(1)
            Catch ex As Exception
            End Try
        End If
        If Ck_ProveedoresArticulo.Checked = True Then
            Try
                CargarProveedores()
            Catch ex As Exception
            End Try
        End If
        Try
            Tx_Descripcion.Text = Dgv_Articulos.Rows(Dgv_Articulos.CurrentRow.Index).Cells("DESCRIPCION").Value
        Catch ex As Exception
            Tx_Descripcion.Text = ""
        End Try
        Try
            Dim xx As New Pro_Articulo(Dgv_Articulos.Rows(Dgv_Articulos.CurrentRow.Index))
            Pg_DetalleLista.SelectedObject = xx
        Catch ex As Exception

        End Try

        Try
            If Ck_MostrarFotoArticulo.Checked Then
                Pb_FotoArticulo.Enabled = True
                CargarFotoArticulo(Me.Dgv_Articulos.SelectedRows(0).Cells(0).Value)
            Else
                Pb_FotoArticulo.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarDisponibilidad(ByVal tipo As Integer)
        If tipo = 1 Then 'Cargar
            Dim adap As New DatosArticulos.Ds_ArtículosTableAdapters.DisponibilidadArticulosTableAdapter
            adap.Fill(DsArtículos.DisponibilidadArticulos, 1, VariablesBase.VariablesBase.IdBodegaActual, Dgv_Articulos.SelectedRows(0).Cells(0).Value)
            Dgv_TablaDisponibilidad.DataSource = DsArtículos.DisponibilidadArticulos
            Dgv_TablaDisponibilidad.AutoGenerateColumns = True
            Dgv_TablaDisponibilidad.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Else 'limpiar
            Dgv_TablaDisponibilidad.DataSource = Nothing
        End If
    End Sub

    Private Sub Ck_MostrarDisponibilida_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Ck_MostrarDisponibilidad.CheckedChanged
        If Ck_MostrarDisponibilidad.Checked = True Then
            Try
                CargarDisponibilidad(1)
            Catch ex As Exception
            End Try
        Else
            CargarDisponibilidad(0)
        End If
    End Sub

    Private Sub Ck_ProveedoresArticulo_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_ProveedoresArticulo.CheckedChanged
        CargarProveedores()
    End Sub

    Private Sub CargarProveedores()
        If Dgv_Articulos.SelectedRows.Count > 0 Then
            If Ck_ProveedoresArticulo.Checked Then 'Cargar
                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                Dim comando As New SqlCommand("SELECT * FROM dbo.ProveedoresArticulo(@IDARTICULO) ORDER BY [Fecha OC]", conexion)
                comando.Parameters.AddWithValue("@IDARTICULO", Dgv_Articulos.SelectedRows(0).Cells(0).Value)
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dtProveedores As New DataTable
                Try
                    conexion.Open()
                    adaptador.Fill(dtProveedores)
                    conexion.Close()
                    Dgv_TablaProveedores.DataSource = dtProveedores
                    Dgv_TablaProveedores.AutoGenerateColumns = True
                    Dgv_TablaProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Ver Proveedores por Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    conexion.Close()
                End Try
            Else 'Limpiar
                Dgv_TablaProveedores.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Lb_TituloArbol.Click
        If Tv_Grupos.SelectedNode IsNot Nothing Then
            Dim nodo As TreeNode = Tv_Grupos.SelectedNode
            Dim node As Object
            Select Case nodo.Tag
                Case "FAMILIA"
                    node = New NodoFamilia
                Case "GRUPO"
                    node = New NodoGrupo
                Case "CLASE"
                    node = New NodoClase
                Case "SUBCLASE"
                    node = New NodoSubClase
                Case "TIPO CATEGORIA"
                    node = New NodoTipoCategoría
                Case "CATEGORIA"
                    node = New NodoCategoría
            End Select
            node = nodo
            MsgBox(node.CODIGOARBOL)
        End If
    End Sub

    Private Sub BuscarArticulo()
        If FuncionesBase.FuncionesBase.ConsultarPermiso(348) Then 'Buscar artículo
            Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
            FrBuscarArtículo._Tipo = "T"
            FrBuscarArtículo.Familia = -1
            FrBuscarArtículo.Cargar_Tabla("T") 'Tipo de búsqueda por familia, falta implementar
            FrBuscarArtículo.ShowDialog()
            If Trim(FrBuscarArtículo.IdArtículo) = 0 Then
                Exit Sub
            End If
            BuscarArticulo(FrBuscarArtículo.IdArtículo)
        Else
            MsgBox("No cuenta con privilegios suficientes para realizar esta acción", MsgBoxStyle.Information, "No tiene privilegios")
        End If
    End Sub

    Private Sub BuscarArticulo(IdArticulo As Integer)
        'ubicar el código del árbol.
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT dbo.CodigoArbolArticulo(@IDARTICULO)", conexion)
        comando.Parameters.AddWithValue("@IDARTICULO", IdArticulo)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtCodigoArbol As New DataTable
        Dim codigoArbol As String = ""
        conexion.Open()
        Try
            adaptador.Fill(dtCodigoArbol)
            codigoArbol = Trim(dtCodigoArbol.Rows(0).Item(0).ToString)
        Catch ex As Exception

        Finally
            conexion.Close()
        End Try
        Dim Arbol As String = codigoArbol 'FrBuscarArtículo.CodigoArbol
        Dim Familia As String = Mid(Arbol, 1, 2)
        Dim Grupo As String = Mid(Arbol, 3, 3)
        Dim Clase As String = Mid(Arbol, 6, 3)
        Dim Subcalse As String = Mid(Arbol, 9, 3)
        For i = 0 To Tv_Grupos.Nodes.Count - 1
            Dim nodo As TreeNode
            nodo = Tv_Grupos.Nodes(i)
            If nodo.Tag = "FAMILIA" Then
                Dim nodofam As New NodoFamilia
                nodofam = Tv_Grupos.Nodes(i)
                If nodofam.CODIGOFAMILIAMATERIAL = Familia Then
                    Tv_Grupos.SelectedNode = nodofam
                    Cargar_Nodos_Hijos()
                    For j = 0 To nodofam.Nodes.Count - 1
                        Dim nodogrup As New NodoGrupo
                        nodogrup = nodofam.Nodes(j)
                        If nodogrup.CODIGOGRUPOMATERIAL = Grupo Then
                            Tv_Grupos.SelectedNode = nodogrup
                            Cargar_Nodos_Hijos()
                            For k = 0 To nodogrup.Nodes.Count - 1
                                Dim nodoclase As New NodoClase
                                nodoclase = nodogrup.Nodes(k)
                                If nodoclase.CODIGOCLASEMATERIAL = Clase Then
                                    Tv_Grupos.SelectedNode = nodoclase
                                    Cargar_Nodos_Hijos()
                                    For l = 0 To nodoclase.Nodes.Count - 1
                                        Dim nodosubclase As New NodoSubClase
                                        nodosubclase = nodoclase.Nodes(l)
                                        If nodosubclase.CODIGOSUBCLASEMATERIAL = Subcalse Then
                                            Tv_Grupos.SelectedNode = nodosubclase
                                            Cargar_Nodos_Hijos()
                                            'Expandir categorías
                                            Dim nodoticat As NodoTipoCategoría
                                            nodoticat = nodosubclase.Nodes(0)
                                            Tv_Grupos.SelectedNode = nodoticat
                                            Cargar_Nodos_Hijos()
                                            Dim categorias As String = Mid(Arbol, 12, Arbol.Length - 11)
                                            While categorias.Length > 0
                                                Dim categoria As String = Mid(categorias, 1, 2)
                                                For m = 0 To nodoticat.Nodes.Count - 1
                                                    Dim nodocat As NodoCategoría
                                                    nodocat = nodoticat.Nodes(m)
                                                    If Mid(nodocat.CODIGOARBOL, nodocat.CODIGOARBOL.Length - 1, 2) = categoria Then
                                                        Tv_Grupos.SelectedNode = nodocat
                                                        Cargar_Nodos_Hijos()
                                                        If nodocat.Nodes.Count > 0 Then
                                                            nodoticat = nodocat.Nodes(0)
                                                            Tv_Grupos.SelectedNode = nodoticat
                                                            Cargar_Nodos_Hijos()
                                                            Exit For
                                                        End If
                                                    End If
                                                Next
                                                categorias = Mid(categorias, 3, categorias.Length - 2)
                                            End While
                                            'ubicar artículo
                                            Dgv_Articulos.ClearSelection()
                                            For v = 0 To Dgv_Articulos.RowCount - 1
                                                Try
                                                    If Dgv_Articulos.Rows(v).Cells(0).Value = IdArticulo Then
                                                        Dgv_Articulos.Rows(v).Selected = True
                                                        Dgv_Articulos.CurrentCell = Dgv_Articulos(0, v)
                                                        Dgv_Articulos.FirstDisplayedScrollingRowIndex = v
                                                    End If
                                                Catch ex As Exception
                                                End Try
                                            Next
                                            Exit Sub
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub Inventario()
        If MsgBox("Seguro que desea desplegar el inventario de la bodega", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
            FrBuscarArtículo._Tipo = "INV"
            FrBuscarArtículo.Familia = -1
            FrBuscarArtículo.Cargar_Tabla("INV") 'Tipo de búsqueda por familia, falta implementar
            FrBuscarArtículo.ShowDialog()
        End If
    End Sub

    Private Sub Bt_VerInventario_Click(sender As System.Object, e As System.EventArgs)
        Inventario()
    End Sub

    Private Sub Bt_FijarCaracterísticaArtículo_Click(sender As System.Object, e As System.EventArgs)
        FijarCaracterísticas()
    End Sub

    Private Sub Bt_TrazabilidadArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TrazabilidadArticulo()
    End Sub

    Private Sub FijarCaracterísticas()
        If Dgv_Articulos.SelectedRows.Count > 0 Then
            Dim FrCaracterísticaArtículo As New Fr_CaracterísticaArtículo
            Dim filas() As DataRow
            filas = datas.Tables(0).Select("ID=" + Dgv_Articulos.Rows(Dgv_Articulos.CurrentRow.Index).Cells("ID").Value.ToString)
            Dim fila As DataRow
            fila = filas(0)
            FrCaracterísticaArtículo.IDARTICULO = Trim(fila("ID"))
            FrCaracterísticaArtículo.Tx_Descripción.Text = Trim(fila("DESCRIPCION"))
            FrCaracterísticaArtículo.Lb_BodegaActual.Text = VariablesBase.VariablesBase.NombreBodegaActual
            FrCaracterísticaArtículo.Lb_UnidadMáximo.Text = Trim(fila("UND"))
            FrCaracterísticaArtículo.Lb_UnidadMínimo.Text = Trim(fila("UND"))
            FrCaracterísticaArtículo.CargarTabla()
            FrCaracterísticaArtículo.ShowDialog()
        Else
            MsgBox("Debe seleccionar el artículo en la grilla al cual desea agregar las características, puede usar la opción de búsqueda para ubicar rápidamente el artículo", MsgBoxStyle.Information, "Seleccione el artículo")
        End If
    End Sub

    Private Sub TrazabilidadArticuloXTodas()
        If Dgv_Articulos.SelectedRows.Count > 0 Then
            If MsgBox("Seguro que desea desplegar la trazabilidad del artículo", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
                FrBuscarArtículo._Tipo = "TRAZXT"
                FrBuscarArtículo.Familia = -1
                FrBuscarArtículo.IdArtículo = Dgv_Articulos.Rows(Dgv_Articulos.CurrentRow.Index).Cells("ID").Value.ToString
                FrBuscarArtículo.Cargar_Tabla("TRAZXT") 'Tipo de búsqueda por familia, falta implementar
                FrBuscarArtículo.ShowDialog()
            End If
        Else
            MsgBox("Debe seleccionar el artículo en la grilla al cual desea ver la trazabilidad, puede usar la opción de búsqueda para ubicar rápidamente el artículo", MsgBoxStyle.Information, "Seleccione el artículo")
        End If
    End Sub

    Private Sub TrazabilidadArticulo()
        If Dgv_Articulos.SelectedRows.Count > 0 Then
            If MsgBox("Seguro que desea desplegar la trazabilidad del artículo", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim FrBuscarArtículo As New Articulos.Fr_BuscarArtículo
                FrBuscarArtículo._Tipo = "TRAZ"
                FrBuscarArtículo.Familia = -1
                FrBuscarArtículo.IdArtículo = Dgv_Articulos.Rows(Dgv_Articulos.CurrentRow.Index).Cells("ID").Value.ToString
                FrBuscarArtículo.Cargar_Tabla("TRAZ") 'Tipo de búsqueda por familia, falta implementar
                FrBuscarArtículo.ShowDialog()
            End If
        Else
            MsgBox("Debe seleccionar el artículo en la grilla al cual desea ver la trazabilidad, puede usar la opción de búsqueda para ubicar rápidamente el artículo", MsgBoxStyle.Information, "Seleccione el artículo")
        End If
    End Sub

    Private Sub Bt_EditarTipos_Click(sender As System.Object, e As System.EventArgs)
        EditarAgregarTipos()
    End Sub

    Private Sub EditarAgregarTipos()
        Dim formaticulos As New FormulariosActivosFijos.Fr_TiposArticulos
        formaticulos.ShowDialog()
    End Sub

    Private Sub Bt_TrazabilidadArticulototal_Click(sender As System.Object, e As System.EventArgs)
        TrazabilidadArticuloXTodas()
    End Sub

    Private Sub Atajos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Tv_Grupos.KeyDown, Dgv_Articulos.KeyDown, Dgv_TablaDisponibilidad.KeyDown, Dgv_TablaProveedores.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                FuncionesBase.FuncionesBase.AbrirAyudaOnline("/Inicio.aspx?MODULO=Materiales")
            Case Keys.F3
                BuscarArticulo()
            Case Keys.F6
                ExportarDatosExcel(Dgv_Articulos)
            Case Keys.F7
                'ImprimirSticker()
            Case Keys.F8
                'EditarAgregarTipos()
            Case Keys.F9
                'Inventario()
            Case Keys.F10
                'FijarCaracterísticas()
            Case Keys.F11
                'TrazabilidadArticulo()
            Case Keys.F12
                'TrazabilidadArticuloXTodas()
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
            With .Range(.Cells(1, 1), .Cells(1, Dgv_Articulos.Columns.Count)).Font
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

    Private Sub SacarDeControlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SacarDeControlToolStripMenuItem.Click
        Dim idArticulo = Dgv_Articulos.SelectedRows(0).Cells("ID").Value

        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
        Dim EliminarActuales As New SqlCommand("Delete from REL_ARTICULO_TIPOCONTROL where IDARTICULO =@IDARTICULO", conn)
        EliminarActuales.Parameters.AddWithValue("@IDARTICULO", idArticulo)
        conn.Open()
        EliminarActuales.ExecuteNonQuery()
        conn.Close()

        BuscarArticulo(idArticulo)
    End Sub

    Private Sub Tsmi_StockPorCodigoArbol_Click(sender As Object, e As EventArgs) _
        Handles Tsmi_StockXArbol_Familia.Click, Tsmi_StockXArbol_Grupo.Click, Tsmi_StockXArbol_Clase.Click, Tsmi_StockXArbol_SubClase.Click, Tsmi_StockXArbol_SubClase2.Click, _
        Tsmi_StockXArbol_TipoCategoria.Click, Tsmi_StockXArbol_Categoria.Click, Tsmi_StockXArbol_Categoria2.Click

        If MessageBox.Show("El proceso de exportación puede tomar algunos minutos, por favor no cierre la aplicación mientras se genera el informe.", "Consulta de Stock por código de árbol", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        Dim tipo As Integer = 0
        Dim codigoArbol As String = ""
        Dim nodo As New TreeNode
        Dim nodoArticulos As Object

        Cursor.Current = Cursors.WaitCursor
        nodo = Tv_Grupos.SelectedNode
        Select Case nodo.Tag
            Case "FAMILIA"
                nodoArticulos = New NodoFamilia
                tipo = 1
            Case "GRUPO"
                nodoArticulos = New NodoGrupo
                tipo = 2
            Case "CLASE"
                nodoArticulos = New NodoClase
                tipo = 3
            Case "SUBCLASE"
                nodoArticulos = New NodoSubClase
                tipo = 4
            Case "TIPO CATEGORIA"
                nodoArticulos = New NodoTipoCategoría
                tipo = 5
            Case "CATEGORIA"
                nodoArticulos = New NodoCategoría
                tipo = 5
            Case Else
                Cursor.Current = Cursors.Default
                Exit Sub
        End Select
        nodoArticulos = nodo
        codigoArbol = nodoArticulos.CODIGOARBOL

        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("SELECT * FROM StockPorCodigoArbol(@TIPO, @CODIGOARBOL, @IDBODEGA, @FECHAI, @FECHAF)", conexion)
        comando.CommandTimeout = 3600
        comando.Parameters.AddWithValue("@TIPO", tipo)
        comando.Parameters.AddWithValue("@CODIGOARBOL", codigoArbol)
        comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
        comando.Parameters.AddWithValue("@FECHAI", DateTime.Now)
        comando.Parameters.AddWithValue("@FECHAF", DateTime.Now)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim dtArticulos As New DataTable
        Try
            conexion.Open()
            adaptador.Fill(dtArticulos)
            conexion.Close()
            FuncionesBase.FuncionesBase.ExportarExcel(dtArticulos, "Stock por Código de Árbol " & codigoArbol)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Stock por Código Árbol", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conexion.Close()
        End Try
        Cursor.Current = Cursors.Default
    End Sub

#Region "Artículo"
    Private Sub Nbi_BuscarArticulo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_BuscarArticulo.ItemClick, TSBt_BuscarArticulo.Click
        BuscarArticulo()
        TablaCargada = "ARTICULOS"
    End Sub

    Private Sub Nbi_ImprimirSticker_ItemClick(sender As Object, e As EventArgs) Handles Nbi_ImprimirSticker.ItemClick, TSBt_ImprimirSticker.Click
        ImprimirSticker()
    End Sub

    Private Sub Nbi_EditarTipos_ItemClick(sender As Object, e As EventArgs) Handles Nbi_EditarTipos.ItemClick, TSBt_EditarTS.Click
        EditarAgregarTipos()
    End Sub

    Private Sub Nbi_VerInventario_ItemClick(sender As Object, e As EventArgs) Handles Nbi_VerInventario.ItemClick, TSBt_VerInventarios.Click
        Inventario()
    End Sub

    Private Sub Nbi_FijarCaracteristicaArticulo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_FijarCaracteristicaArticulo.ItemClick, TSBt_UyStock.Click
        FijarCaracterísticas()
    End Sub

    Private Sub Nbi_TrazabilidadArticulo_ItemClick(sender As Object, e As EventArgs) Handles Nbi_TrazabilidadArticulo.ItemClick, TSBt_TrazabilidadxBase.Click
        TrazabilidadArticulo()
    End Sub

    Private Sub Nbi_TrazabilidadArticuloTotal_ItemClick(sender As Object, e As EventArgs) Handles Nbi_TrazabilidadArticuloTotal.ItemClick, TSBt_Trazabilidad.Click
        TrazabilidadArticuloXTodas()
    End Sub

    Private Sub Nbi_DistribucionArticuloxCant_ItemClick(sender As Object, e As EventArgs) Handles Nbi_DistribucionArticuloxCant.ItemClick
        If Dgv_Articulos.SelectedRows.Count > 0 Then

            Dim cantidad As Integer
            cantidad = InputBox("Indique la cantidad a distribuir.", "Cantidad a distribuir", "")

            If Dgv_Articulos.SelectedRows.Count > 0 Then
                Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
                Dim comando As New SqlCommand("dbo.DispersionArticulos", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@IDARTICULO", Dgv_Articulos.SelectedRows(0).Cells(0).Value.ToString())
                comando.Parameters.AddWithValue("@CANTIDAD", cantidad)
                comando.Parameters.AddWithValue("@IDBODEGA", VariablesBase.VariablesBase.IdBodegaActual)
                Dim adaptador As New SqlDataAdapter(comando)
                Dim dtDCOC As New DataTable
                Try
                    conexion.Open()
                    adaptador.Fill(dtDCOC)
                    conexion.Close()
                    Me.Dgv_TablaDisponibilidad.DataSource = dtDCOC
                    Me.Dgv_TablaDisponibilidad.DefaultCellStyle.BackColor = Color.White
                    Me.Lb_TituloDisponibilidad.Text = "Lista de distribución del Artículo: " + Dgv_TablaDisponibilidad.RowCount.ToString
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conexion.Close()
                End Try
                Dgv_TablaDisponibilidad.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen
            End If
        Else
            MsgBox("Debe seleccionar el artículo en la grilla al cual desea agregar las características, puede usar la opción de búsqueda para ubicar rápidamente el artículo", MsgBoxStyle.Information, "Seleccione el artículo")
        End If

    End Sub

#End Region 'Artículo




    Private Sub Ck_MostrarFotoArticulo_CheckedChanged(sender As Object, e As EventArgs) Handles Ck_MostrarFotoArticulo.CheckedChanged
        If Dgv_Articulos.Rows.Count > 0 Then
            If Ck_MostrarFotoArticulo.Checked = True Then
                If Me.Dgv_Articulos.SelectedRows.Count = 1 Then
                    CargarFotoArticulo(Me.Dgv_Articulos.SelectedRows(0).Cells(0).Value)
                End If
            Else
                Pb_FotoArticulo.Image = Nothing
            End If
        End If
    End Sub

    Private Sub CargarFotoArticulo(ByVal IdArticulo As Integer)
        Try
            Pb_FotoArticulo.Image = FuncionesBase.FuncionesBase.DevolverImagenMiniatura(3, IdArticulo)
        Catch ex As Exception
        End Try
        If Pb_FotoArticulo.Image Is Nothing Then
            Pb_FotoArticulo.Image = Im_Defecto.Images(0)
        End If
    End Sub

    Private Sub Pb_FotoArticulo_Click(sender As Object, e As EventArgs) Handles Pb_FotoArticulo.Click
        If Ck_MostrarFotoArticulo.Checked Then
            If Dgv_Articulos.Rows.Count > 0 Then
                Dim FrMostrarFoto As New Form
                Dim Pb_Foto As New PictureBox
                With Pb_Foto
                    .Dock = DockStyle.Fill
                    .Size = New Size(640, 480)
                End With
                With FrMostrarFoto
                    .ClientSize = New Size(Pb_Foto.Right, Pb_Foto.Bottom)
                    .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
                    .Controls.Add(Pb_Foto)
                    .StartPosition = FormStartPosition.CenterScreen
                End With
                If Not FuncionesBase.FuncionesBase.ImagenesIguales(Pb_FotoArticulo.Image, Im_Defecto.Images(0)) Then
                    Dim Cedula As String = Me.Dgv_Articulos.SelectedRows(0).Cells("ID").Value.ToString
                    Cedula = Cedula.Replace(".", "")
                    Dim Foto As Boolean = GoogleDrive.DescargarFotos("art_" + Me.Dgv_Articulos.SelectedRows(0).Cells(0).Value.ToString, "Artículos")
                    If Foto Then
                        Dim appPath As String = Application.StartupPath + "/Temp.jpg"
                        Dim filestream As New IO.FileStream(appPath, IO.FileMode.Open, IO.FileAccess.Read)
                        Dim imagen As Image = Image.FromStream(filestream)
                        filestream.Close()
                        Pb_Foto.Image = imagen
                    End If
                    FrMostrarFoto.ShowDialog()

                    Dim appPath2 As String
                    Try
                        Pb_Foto.Image.Dispose()
                        appPath2 = Application.StartupPath + "\Temp.jpg" '+ Me.Dgv_Articulos.SelectedRows(0).Cells("Id").Value.ToString.ToString + ".jpg"
                        If My.Computer.FileSystem.FileExists(appPath2) Then
                            My.Computer.FileSystem.DeleteFile(appPath2)
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
    End Sub
End Class 'Cu_Articulos


Public Class NodoCategoría
    Inherits System.Windows.Forms.TreeNode
    Private _CODIGOCATEGORIAMATERIAL As Integer
    Private _NOMBRECATEGORIAMATERIAL As String
    Private _CODIGOARBOL As String
    Private _CODIGOCATEGORIAPADRE As Integer
    Private _IDCODIGOTIPOUNIDAD As Integer

    Public Property IDCODIGOTIPOUNIDAD() As Integer
        Get
            Return _IDCODIGOTIPOUNIDAD
        End Get
        Set(ByVal value As Integer)
            _IDCODIGOTIPOUNIDAD = value
        End Set
    End Property

    Public Property CODIGOCATEGORIAMATERIAL() As Integer
        Get
            Return _CODIGOCATEGORIAMATERIAL
        End Get
        Set(ByVal value As Integer)
            _CODIGOCATEGORIAMATERIAL = value
        End Set
    End Property

    Public Property NOMBRECATEGORIAMATERIAL() As String
        Get
            Return _NOMBRECATEGORIAMATERIAL
        End Get
        Set(ByVal value As String)
            _NOMBRECATEGORIAMATERIAL = value
        End Set
    End Property

    Public Property CODIGOARBOL() As String
        Get
            Return _CODIGOARBOL
        End Get
        Set(ByVal value As String)
            _CODIGOARBOL = value
        End Set
    End Property

    Public Property CODIGOCATEGORIAPADRE() As Integer
        Get
            Return _CODIGOCATEGORIAPADRE
        End Get
        Set(ByVal value As Integer)
            _CODIGOCATEGORIAPADRE = value
        End Set
    End Property

    Public Sub New()
        Me.Tag = "CATEGORIA"
    End Sub
End Class 'NodoCategoría

Public Class NodoTipoCategoría
    Inherits System.Windows.Forms.TreeNode
    Private _CODIGOTIPOCATEGORIAMATERIAL As Integer
    Private _NOMBRETIPOCATEGORIAMATERIAL As String
    Private _CODIGOARBOL As String

    Public Property CODIGOTIPOCATEGORIAMATERIAL() As Integer
        Get
            Return _CODIGOTIPOCATEGORIAMATERIAL
        End Get
        Set(ByVal value As Integer)
            _CODIGOTIPOCATEGORIAMATERIAL = value
        End Set
    End Property

    Public Property NOMBRETIPOCATEGORIAMATERIAL() As String
        Get
            Return _NOMBRETIPOCATEGORIAMATERIAL
        End Get
        Set(ByVal value As String)
            _NOMBRETIPOCATEGORIAMATERIAL = value
        End Set
    End Property

    Public Property CODIGOARBOL() As String
        Get
            Return _CODIGOARBOL
        End Get
        Set(ByVal value As String)
            _CODIGOARBOL = value
        End Set
    End Property

    Public Sub New()
        Me.Tag = "TIPO CATEGORIA"
        Me.ForeColor = Color.Blue
        Me.NodeFont = New Font("Arial", 6.75, FontStyle.Bold)
    End Sub
End Class 'NodoTipoCategoría

Public Class NodoFamilia
    Inherits System.Windows.Forms.TreeNode
    Private _NOMBREFAMILIA As String
    Private _CODIGOFAMILIAMATERIAL As String
    Private _IDFAMILIAMATERIAL As Integer
    Private _CODIGOARBOL As String

    Public Property NOMBREFAMILIA() As String
        Get
            Return _NOMBREFAMILIA
        End Get
        Set(ByVal value As String)
            _NOMBREFAMILIA = value
        End Set
    End Property

    Public Property CODIGOFAMILIAMATERIAL() As String
        Get
            Return _CODIGOFAMILIAMATERIAL
        End Get
        Set(ByVal value As String)
            _CODIGOFAMILIAMATERIAL = value
        End Set
    End Property

    Public Property IDFAMILIAMATERIAL() As Integer
        Get
            Return _IDFAMILIAMATERIAL
        End Get
        Set(ByVal value As Integer)
            _IDFAMILIAMATERIAL = value
        End Set
    End Property

    Public Property CODIGOARBOL() As String
        Get
            Return _CODIGOARBOL
        End Get
        Set(ByVal value As String)
            _CODIGOARBOL = value
        End Set
    End Property

    Public Sub New()
        Me.Tag = "FAMILIA"
    End Sub
End Class 'NodoFamilia

Public Class NodoGrupo
    Inherits System.Windows.Forms.TreeNode
    Public _NOMBREGRUPOMATERIAL As String
    Private _CODIGOGRUPOMATERIAL As String
    Private _IDGRUPOMATERIAL As Integer
    Private _CODIGOARBOL As String

    Public Property NOMBREGRUPOMATERIAL() As String
        Get
            Return _NOMBREGRUPOMATERIAL
        End Get
        Set(ByVal value As String)
            _NOMBREGRUPOMATERIAL = value
        End Set
    End Property

    Public Property CODIGOGRUPOMATERIAL() As String
        Get
            Return _CODIGOGRUPOMATERIAL
        End Get
        Set(ByVal value As String)
            _CODIGOGRUPOMATERIAL = value
        End Set
    End Property

    Public Property IDGRUPOMATERIAL() As Integer
        Get
            Return _IDGRUPOMATERIAL
        End Get
        Set(ByVal value As Integer)
            _IDGRUPOMATERIAL = value
        End Set
    End Property

    Public Property CODIGOARBOL() As String
        Get
            Return _CODIGOARBOL
        End Get
        Set(ByVal value As String)
            _CODIGOARBOL = value
        End Set
    End Property

    Public Sub New()
        Me.Tag = "GRUPO"
    End Sub
End Class 'NodoGrupo

Public Class NodoClase
    Inherits System.Windows.Forms.TreeNode
    Private _NOMBRECLASEMATERIAL As String
    Private _CODIGOCLASEMATERIAL As String
    Private _IDCLASEMATERIAL As Integer
    Private _CODIGOARBOL As String

    Public Property NOMBRECLASEMATERIAL() As String
        Get
            Return _NOMBRECLASEMATERIAL
        End Get
        Set(ByVal value As String)
            _NOMBRECLASEMATERIAL = value
        End Set
    End Property

    Public Property CODIGOCLASEMATERIAL() As String
        Get
            Return _CODIGOCLASEMATERIAL
        End Get
        Set(ByVal value As String)
            _CODIGOCLASEMATERIAL = value
        End Set
    End Property

    Public Property IDCLASEMATERIAL() As Integer
        Get
            Return _IDCLASEMATERIAL
        End Get
        Set(ByVal value As Integer)
            _IDCLASEMATERIAL = value
        End Set
    End Property

    Public Property CODIGOARBOL() As String
        Get
            Return _CODIGOARBOL
        End Get
        Set(ByVal value As String)
            _CODIGOARBOL = value
        End Set
    End Property

    Public Sub New()
        Me.Tag = "CLASE"
    End Sub
End Class 'NodoClase

Public Class NodoSubClase
    Inherits System.Windows.Forms.TreeNode
    Private _NOMBRESUBCLASEMATERIAL As String
    Private _CODIGOSUBCLASEMATERIAL As String
    Private _IDSUBCLASEMATERIAL As Integer
    Private _CODIGOARBOL As String

    Public Property NOMBRESUBCLASEMATERIAL() As String
        Get
            Return _NOMBRESUBCLASEMATERIAL
        End Get
        Set(ByVal value As String)
            _NOMBRESUBCLASEMATERIAL = value
        End Set
    End Property

    Public Property CODIGOSUBCLASEMATERIAL() As String
        Get
            Return _CODIGOSUBCLASEMATERIAL
        End Get
        Set(ByVal value As String)
            _CODIGOSUBCLASEMATERIAL = value
        End Set
    End Property

    Public Property IDSUBCLASEMATERIAL() As Integer
        Get
            Return _IDSUBCLASEMATERIAL
        End Get
        Set(ByVal value As Integer)
            _IDSUBCLASEMATERIAL = value
        End Set
    End Property

    Public Property CODIGOARBOL() As String
        Get
            Return _CODIGOARBOL
        End Get
        Set(ByVal value As String)
            _CODIGOARBOL = value
        End Set
    End Property

    Public Sub New()
        Me.Tag = "SUBCLASE"
    End Sub
End Class 'NodoSubClase

Public Class Pro_Articulo
    Private _FAMILIA As String
    Private _GRUPO As String
    Private _CLASE As String
    Private _NOMBRE As String
    Private _CODIGOACCESS As String
    Private _DESCRIPCION As String
    Private _CODIGOBARRA As String
    Private _IVA As String
    Private _UND As String
    Private _UsuarioRegistro As String
    Private _FechaRegistro As String
    Private _UsuarioModifico As String
    Private _FechaModificación As String
    Private _ValorReferencia As String
    Private _FechaModificaciónVRef As String
    Private _UsuarioModificoVRef As String

    <Description("Identificación del Artículo"), _
    Category("Identificación"),
    DisplayNameAttribute("Código Access")> _
    Public ReadOnly Property CódigoAcces() As String
        Get
            Return _CODIGOACCESS
        End Get
    End Property

    <Description("Identificación del Artículo"), _
    Category("Identificación"),
    DisplayNameAttribute("Código Barra")> _
    Public ReadOnly Property CódigoBarra() As String
        Get
            Return _CODIGOBARRA
        End Get
    End Property


    <Description("Unidad"), _
    Category("Unidad"),
    DisplayNameAttribute("Unidad")> _
    Public ReadOnly Property Unidad() As String
        Get
            Return _UND
        End Get
    End Property

    <Description("Clasificación del Artículo"), _
    Category("Clasificación"),
    DisplayNameAttribute("Familia")> _
    Public ReadOnly Property Familia() As String
        Get
            Return _FAMILIA
        End Get
    End Property

    <Description("Clasificación del Artículo"), _
    Category("Clasificación"),
    DisplayNameAttribute("Grupo")> _
    Public ReadOnly Property Grupo() As String
        Get
            Return _GRUPO
        End Get
    End Property

    <Description("Clasificación del Artículo"), _
    Category("Clasificación"),
    DisplayNameAttribute("Clase")> _
    Public ReadOnly Property Clase() As String
        Get
            Return _CLASE
        End Get
    End Property

    <Description("Usuario que creó el Artículo"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Crea")> _
    Public ReadOnly Property UsuarioCrea() As String
        Get
            Return _UsuarioRegistro
        End Get
    End Property

    <Description("Fecha Creación del Artículo"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Creación")> _
    Public ReadOnly Property FechaCreación() As String
        Get
            Return _FechaRegistro
        End Get
    End Property

    <Description("Usuario que modificó el Artículo"), _
    Category("Auditoría"),
    DisplayNameAttribute("Usuario Modificó")> _
    Public ReadOnly Property UsuarioModifico() As String
        Get
            Return _UsuarioModifico
        End Get
    End Property

    <Description("Fecha Modificación del Artículo"), _
    Category("Auditoría"),
    DisplayNameAttribute("Fecha Modificación")> _
    Public ReadOnly Property FechaModificación() As String
        Get
            Return _FechaModificación
        End Get
    End Property

    <Description("Valor de Referencia del Artículo"), _
    Category("Valor de Referencia"),
    DisplayNameAttribute("Valor Referencia")> _
    Public ReadOnly Property ValorReferencia() As String
        Get
            Return _ValorReferencia
        End Get
    End Property

    <Description("Fecha Modificación del Valor de Referencia del Artículo"), _
    Category("Valor de Referencia"),
    DisplayNameAttribute("Fecha Modificación")> _
    Public ReadOnly Property FechaModificaciónVRef() As String
        Get
            Return _FechaModificaciónVRef
        End Get
    End Property

    <Description("Usuario que modificó el Valor de Referencia del Artículo"), _
    Category("Valor de Referencia"),
    DisplayNameAttribute("Usuario Modificó")> _
    Public ReadOnly Property UsuarioModificoVRef() As String
        Get
            Return _UsuarioModificoVRef
        End Get
    End Property

    Public Sub New(ByVal FilaArticulo As DataGridViewRow)
        _FAMILIA = FilaArticulo.Cells("FAMILIA").Value
        _GRUPO = FilaArticulo.Cells("GRUPO").Value
        _CLASE = FilaArticulo.Cells("CLASE").Value
        _NOMBRE = FilaArticulo.Cells("NOMBRE").Value
        _CODIGOACCESS = FilaArticulo.Cells("CODIGOACCESS").Value
        _DESCRIPCION = FilaArticulo.Cells("DESCRIPCION").Value
        _CODIGOBARRA = FilaArticulo.Cells("CODIGO BARRA").Value
        _IVA = FilaArticulo.Cells("IVA").Value
        _UND = FilaArticulo.Cells("UND").Value
        _UsuarioRegistro = FilaArticulo.Cells("REGISTRO").Value
        _FechaRegistro = FilaArticulo.Cells("FECHAREGISTRO").Value
        _UsuarioModifico = FilaArticulo.Cells("MODIFICO").Value
        _FechaModificación = FilaArticulo.Cells("FECHAMODIFICACION").Value
        _ValorReferencia = Format(FilaArticulo.Cells("VALORREFERENCIA").Value, "C")
        _FechaModificaciónVRef = FilaArticulo.Cells("FECHAMODIFICACIONREF").Value
        Try
            _UsuarioModificoVRef = FilaArticulo.Cells("IDUSUARIOMODIFICAREF").Value
        Catch
            _UsuarioModificoVRef = ""
        End Try
    End Sub
End Class 'Pro_Articulo

Class Fr_TipoControlArticulo : Inherits Form
    Private _IdArticulo As Integer = 0
    Private _TipoControl As String = "N"
    Private Nombre As String
    Private dtTiposControl As DataTable
    Private dtTiposControlAgregados As DataTable
    Private dtNombre As DataTable
    Private WithEvents Cb_Control As ComboBox
    Private Flp_Botones As FlowLayoutPanel
    Private WithEvents Bt_Aceptar As Button
    Private WithEvents Bt_Cancelar As Button
    Private WithEvents Bt_Agregar As Button
    Private WithEvents Bt_AgregarTodos As Button
    Private WithEvents Bt_Quitar As Button
    Private WithEvents Bt_QuitarTodos As Button
    Private WithEvents Lb_IdArticulo As Label
    Private WithEvents Lb_TipoArticuloAsignado As Label
    Private WithEvents Lb_TipoArticuloPorAsignar As Label
    Private WithEvents Lb_NombreArticulo As Label
    Private WithEvents Tx_IdArticulo As TextBox
    Private WithEvents Tx_NombreArticulo As TextBox
    Private WithEvents Pn_Articulo As Panel
    Private WithEvents Pn_TipoControl As Panel
    Private WithEvents LB_ListaTipoControl As ListBox
    Private WithEvents LB_ListaTipoControlAgregados As ListBox
    Private WithEvents Cn_Container As Container

    Public Sub New(IdArticulo As Integer, Optional TipoControl As String = "N")
        _IdArticulo = IdArticulo
        If TipoControl <> "" Then
            _TipoControl = TipoControl
        End If
        dtTiposControl = New DataTable
        dtTiposControlAgregados = New DataTable
        dtNombre = New DataTable
        Cb_Control = New ComboBox
        Flp_Botones = New FlowLayoutPanel
        Bt_Cancelar = New Button
        Bt_Aceptar = New Button
        Bt_Agregar = New Button
        Bt_AgregarTodos = New Button
        Bt_Quitar = New Button
        Bt_QuitarTodos = New Button
        Lb_IdArticulo = New Label
        Lb_NombreArticulo = New Label
        Lb_TipoArticuloPorAsignar = New Label
        Lb_TipoArticuloAsignado = New Label
        Tx_IdArticulo = New TextBox
        Tx_NombreArticulo = New TextBox
        Pn_Articulo = New Panel
        Pn_TipoControl = New Panel
        LB_ListaTipoControl = New ListBox
        LB_ListaTipoControlAgregados = New ListBox
        Cn_Container = New Container
    End Sub

    Private Sub Fr_TipoControlArticulo_Load() Handles Me.Load
        dtTiposControl.Columns.Add("ID_TIPOCONTROL")
        dtTiposControl.Columns.Add("ABREVIATURA")
        dtTiposControl.Columns.Add("DESCRIPCION")
        dtTiposControlAgregados.Columns.Add("ID_TIPOCONTROL")
        dtTiposControlAgregados.Columns.Add("ABREVIATURA")
        dtTiposControlAgregados.Columns.Add("DESCRIPCION")
        dtNombre.Columns.Add("NOMBRE")
        
        Dim conexion As New SqlConnection(My.Settings.CadenaConexión)
        Dim comando As New SqlCommand("dbo.ObtenerTipoControlArticulo", conexion)
        Dim comando2 As New SqlCommand("dbo.ObtenerTipoControlArticulo", conexion)
        Dim comando3 As New SqlCommand("select NOMBRE from articulo where IDARTICULO= @IDARTICULO", conexion)
        comando.Parameters.AddWithValue("@IDARTICULO", _IdArticulo)
        comando.Parameters.AddWithValue("@Tipo", 2)
        comando.CommandType = CommandType.StoredProcedure

        comando2.Parameters.AddWithValue("@IDARTICULO", _IdArticulo)
        comando2.Parameters.AddWithValue("@Tipo", 1)
        comando2.CommandType = CommandType.StoredProcedure

        comando3.Parameters.AddWithValue("@IDARTICULO", _IdArticulo)
        Dim adaptador As New SqlDataAdapter(comando)
        Dim adaptador2 As New SqlDataAdapter(comando2)
        Dim adaptador3 As New SqlDataAdapter(comando3)
        Try
            conexion.Open()
            adaptador.Fill(dtTiposControl)
            adaptador2.Fill(dtTiposControlAgregados)
            adaptador3.Fill(dtNombre)
            conexion.Close()

        Catch ex As Exception
        Finally
            conexion.Close()
        End Try

        With Pn_Articulo
            .Height = 60
            .Width = 400
            .Controls.Add(Flp_Botones)
            .Controls.Add(Lb_IdArticulo)
            .Controls.Add(Lb_NombreArticulo)
            .Controls.Add(Tx_IdArticulo)
            .Controls.Add(Tx_NombreArticulo)
        End With
        With Pn_TipoControl
            .Controls.Add(Lb_TipoArticuloAsignado)
            .Controls.Add(Lb_TipoArticuloPorAsignar)
            .Controls.Add(LB_ListaTipoControl)
            .Controls.Add(LB_ListaTipoControlAgregados)
            .Controls.Add(Bt_Agregar)
            .Controls.Add(Bt_AgregarTodos)
            .Controls.Add(Bt_Quitar)
            .Controls.Add(Bt_QuitarTodos)
            .Location = New Point(10, 60)
            .Height = 320
            .Width = 400
        End With
        With Lb_IdArticulo
            .Text = "Id del articulo"
            .Location = New Point(20, 15)
        End With
        With Lb_NombreArticulo
            .Text = "Nombre del articulo"
            .Location = New Point(20, 40)
        End With

        With Lb_TipoArticuloAsignado
            .Text = "Tipos de control asignados al articulo"
            .Width = 150
            .Height = 30
            .Location = New Point(200, 10)
        End With
        With Lb_TipoArticuloPorAsignar
            .Text = "Tipos de control para asignar al articulo"
            .Width = 150
            .Height = 30
            .Location = New Point(10, 10)
        End With
        With Tx_IdArticulo
            .Text = _IdArticulo
            .Location = New Point(120, 10)
            .Enabled = False
        End With

        With Tx_NombreArticulo
            .Text = dtNombre.Rows(0).Item("NOMBRE")
            .Location = New Point(120, 35)
            .Enabled = False
            .Width = 200
            .MaximumSize = New Size(250, 20)
        End With
        With LB_ListaTipoControl
            .DataSource = dtTiposControl
            .DisplayMember = "DESCRIPCION"
            .ValueMember = "ID_TIPOCONTROL"
            .Width = 150
            .Height = 250
            .Location = New Point(10, 45)
        End With
        With LB_ListaTipoControlAgregados
            .DataSource = dtTiposControlAgregados
            .DisplayMember = "DESCRIPCION"
            .ValueMember = "ID_TIPOCONTROL"
            .Width = 150
            .Height = 250
            .Location = New Point(200, 45)
        End With
        With Bt_Agregar
            .Text = ">"
            .Location = New Point(165, 65)
            .Width = 30
        End With
        With Bt_AgregarTodos
            .Text = ">>"
            .Location = New Point(165, 90)
            .Width = 30
        End With
        With Bt_Quitar
            .Text = "<"
            .Location = New Point(165, 115)
            .Width = 30
        End With
        With Bt_QuitarTodos
            .Text = "<<"
            .Location = New Point(165, 140)
            .Width = 30
        End With
        With Bt_Aceptar
            .Text = "Aceptar"
        End With
        With Bt_Cancelar
            .Text = "Cancelar"
        End With
        With Flp_Botones
            .Dock = DockStyle.Bottom
            .FlowDirection = FlowDirection.RightToLeft
            .Height = 30
            .Controls.Add(Bt_Cancelar)
            .Controls.Add(Bt_Aceptar)
        End With
        With Me
            .AcceptButton = Bt_Aceptar
            .CancelButton = Bt_Cancelar
            .MaximizeBox = False
            .MinimizeBox = False
            .MinimumSize = New Size(400, 450)
            .MaximumSize = New Size(400, 450)
            .ShowIcon = False
            .Size = New Size(400, 450)
            .StartPosition = FormStartPosition.CenterScreen
            .Text = "Gestionar Control de Artículo"
            .Controls.Add(Pn_Articulo)
            .Controls.Add(Pn_TipoControl)
            .Controls.Add(Flp_Botones)
        End With
    End Sub

    Private Sub Bt_Aceptar_Click() Handles Bt_Aceptar.Click

        dtTiposControl.DefaultView.Sort = "ID_TIPOCONTROL ASC"
        dtTiposControl = dtTiposControl.DefaultView.Table

        Dim conn As New SqlConnection(My.Settings.CadenaConexión)
        Dim EliminarActuales As New SqlCommand("Delete from REL_ARTICULO_TIPOCONTROL where IDARTICULO =@IDARTICULO", conn)
        EliminarActuales.Parameters.AddWithValue("@IDARTICULO", _IdArticulo)
        conn.Open()
        EliminarActuales.ExecuteNonQuery()
        conn.Close()
        For i As Integer = 0 To dtTiposControlAgregados.Rows.Count - 1
            Dim Agregar As New SqlCommand("insert into REL_ARTICULO_TIPOCONTROL (IDARTICULO, ID_TIPOCONTROL) values (@IDARTICULO,@ID_TIPOCONTROL)", conn)
            Dim ID_TIPOCONTROL As String = dtTiposControlAgregados.Rows(i).Item("ID_TIPOCONTROL")
            Agregar.Parameters.AddWithValue("@IDARTICULO", _IdArticulo)
            Agregar.Parameters.AddWithValue("@ID_TIPOCONTROL", ID_TIPOCONTROL)
            conn.Open()
            Agregar.ExecuteNonQuery()
            conn.Close()
        Next
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Bt_Cancelar_Click() Handles Bt_Cancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub Bt_Agregar_Click() Handles Bt_Agregar.Click
        Dim valorSeleccionado As String = LB_ListaTipoControl.SelectedValue
        If valorSeleccionado <> Nothing Then
            Dim ID As DataRow
            ID = dtTiposControl.Select("ID_TIPOCONTROL = '" + valorSeleccionado.ToString() + "'").FirstOrDefault()

            Dim fieldInfo As Reflection.FieldInfo = ID.GetType().GetField("_rowID",
            Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
            Dim ValorIDFila As Integer = CInt(fieldInfo.GetValue(ID))

            Dim id_Tipo As String = ID.Item("ID_TIPOCONTROL")
            Dim Abreviatura As String = ID.Item("ABREVIATURA")
            Dim Descripcion As String = ID.Item("DESCRIPCION")
            Dim IndiceBorrar As Integer

            For i As Integer = 0 To dtTiposControl.Rows.Count - 1
                If (dtTiposControl.Rows(i).Item("ID_TIPOCONTROL") = ID.Item("ID_TIPOCONTROL")) Then
                    IndiceBorrar = i
                End If
            Next
            dtTiposControl.Rows(IndiceBorrar).Delete()
            dtTiposControl.AcceptChanges()
            dtTiposControlAgregados.Rows.Add(id_Tipo, Abreviatura, Descripcion)
            dtTiposControlAgregados.AcceptChanges()
        End If
    End Sub

    Private Sub LB_ListaTipoControl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LB_ListaTipoControl.DoubleClick
        If LB_ListaTipoControl.SelectedIndex >= 0 Then
            Dim valorSeleccionado As String = LB_ListaTipoControl.SelectedValue
            If valorSeleccionado <> Nothing Then
                Dim ID As DataRow
                ID = dtTiposControl.Select("ID_TIPOCONTROL = '" + valorSeleccionado.ToString() + "'").FirstOrDefault()

                Dim fieldInfo As Reflection.FieldInfo = ID.GetType().GetField("_rowID",
                Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
                Dim ValorIDFila As Integer = CInt(fieldInfo.GetValue(ID))

                Dim id_Tipo As String = ID.Item("ID_TIPOCONTROL")
                Dim Abreviatura As String = ID.Item("ABREVIATURA")
                Dim Descripcion As String = ID.Item("DESCRIPCION")
                Dim IndiceBorrar As Integer

                For i As Integer = 0 To dtTiposControl.Rows.Count - 1
                    If (dtTiposControl.Rows(i).Item("ID_TIPOCONTROL") = ID.Item("ID_TIPOCONTROL")) Then
                        IndiceBorrar = i
                    End If
                Next
                dtTiposControl.Rows(IndiceBorrar).Delete()
                dtTiposControl.AcceptChanges()
                dtTiposControlAgregados.Rows.Add(id_Tipo, Abreviatura, Descripcion)
                dtTiposControlAgregados.AcceptChanges()
            End If
        End If
    End Sub
    Private Sub LB_ListaTipoControlAgregados_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LB_ListaTipoControlAgregados.DoubleClick
        If LB_ListaTipoControlAgregados.SelectedIndex >= 0 Then
            Dim valorSeleccionado As String = LB_ListaTipoControlAgregados.SelectedValue
            If valorSeleccionado <> Nothing Then
                Dim ID As DataRow
                ID = dtTiposControlAgregados.Select("ID_TIPOCONTROL = '" + valorSeleccionado.ToString() + "'").FirstOrDefault()

                Dim fieldInfo As Reflection.FieldInfo = ID.GetType().GetField("_rowID",
                Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
                Dim ValorIDFila As Integer = CInt(fieldInfo.GetValue(ID))

                Dim id_Tipo As String = ID.Item("ID_TIPOCONTROL")
                Dim Abreviatura As String = ID.Item("ABREVIATURA")
                Dim Descripcion As String = ID.Item("DESCRIPCION")
                Dim IndiceBorrar As Integer

                For i As Integer = 0 To dtTiposControlAgregados.Rows.Count - 1
                    If (dtTiposControlAgregados.Rows(i).Item("ID_TIPOCONTROL") = ID.Item("ID_TIPOCONTROL")) Then
                        IndiceBorrar = i
                    End If
                Next
                dtTiposControlAgregados.Rows(IndiceBorrar).Delete()
                dtTiposControlAgregados.AcceptChanges()
                dtTiposControl.Rows.Add(id_Tipo, Abreviatura, Descripcion)
                dtTiposControl.AcceptChanges()
            End If
        End If
    End Sub
    Private Sub Bt_Quitar_Click() Handles Bt_Quitar.Click
        Dim valorSeleccionado As String = LB_ListaTipoControlAgregados.SelectedValue
        If valorSeleccionado <> Nothing Then
            Dim ID As DataRow
            ID = dtTiposControlAgregados.Select("ID_TIPOCONTROL = '" + valorSeleccionado.ToString() + "'").FirstOrDefault()

            Dim fieldInfo As Reflection.FieldInfo = ID.GetType().GetField("_rowID",
            Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
            Dim ValorIDFila As Integer = CInt(fieldInfo.GetValue(ID))

            Dim id_Tipo As String = ID.Item("ID_TIPOCONTROL")
            Dim Abreviatura As String = ID.Item("ABREVIATURA")
            Dim Descripcion As String = ID.Item("DESCRIPCION")
            Dim IndiceBorrar As Integer

            For i As Integer = 0 To dtTiposControlAgregados.Rows.Count - 1
                If (dtTiposControlAgregados.Rows(i).Item("ID_TIPOCONTROL") = ID.Item("ID_TIPOCONTROL")) Then
                    IndiceBorrar = i
                End If
            Next
            dtTiposControlAgregados.Rows(IndiceBorrar).Delete()
            dtTiposControlAgregados.AcceptChanges()
            dtTiposControl.Rows.Add(id_Tipo, Abreviatura, Descripcion)
            dtTiposControl.AcceptChanges()
        End If
    End Sub


    Private Sub Bt_AgregarTodos_Click() Handles Bt_AgregarTodos.Click
        For i As Integer = 0 To dtTiposControl.Rows.Count - 1
            Dim id_Tipo As String = dtTiposControl.Rows(i).Item("ID_TIPOCONTROL")
            Dim Abreviatura As String = dtTiposControl.Rows(i).Item("ABREVIATURA")
            Dim Descripcion As String = dtTiposControl.Rows(i).Item("DESCRIPCION")
            dtTiposControlAgregados.Rows.Add(id_Tipo, Abreviatura, Descripcion)
        Next
        For i As Integer = 0 To dtTiposControl.Rows.Count - 1
            dtTiposControl.Rows(i).Delete()
        Next
        dtTiposControlAgregados.AcceptChanges()
        dtTiposControl.AcceptChanges()
    End Sub
    Private Sub Bt_QuitarTodos_Click() Handles Bt_QuitarTodos.Click
        For i As Integer = 0 To dtTiposControlAgregados.Rows.Count - 1
            Dim id_Tipo As String = dtTiposControlAgregados.Rows(i).Item("ID_TIPOCONTROL")
            Dim Abreviatura As String = dtTiposControlAgregados.Rows(i).Item("ABREVIATURA")
            Dim Descripcion As String = dtTiposControlAgregados.Rows(i).Item("DESCRIPCION")
            dtTiposControl.Rows.Add(id_Tipo, Abreviatura, Descripcion)
        Next
        For i As Integer = 0 To dtTiposControlAgregados.Rows.Count - 1
            dtTiposControlAgregados.Rows(i).Delete()
        Next
        dtTiposControlAgregados.AcceptChanges()
        dtTiposControl.AcceptChanges()
    End Sub
End Class 'Fr_TipoControlArticulo