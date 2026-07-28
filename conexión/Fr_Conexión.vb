Imports System.Windows.Forms
Imports System.IO
Imports Conexion = Conexión.Cl_Conexión
Imports System.Data.SqlClient

Public Class Fr_Conexión
    Private dt As DataTable
    Private fila As DataGridViewRow
    Private tempConexion As SqlConnection

    Private Sub Fr_Conexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tempConexion = VariablesBase.VariablesBase.Conexion_Remota_Sql_Server
        dt = (Conexion.LeerTablaConfServidor).Tables(0)
        For i As Integer = 0 To Dgv_Servidores.Columns.Count - 1
            If Not dt.Columns.Contains(Dgv_Servidores.Columns(i).DataPropertyName) Then
                dt.Columns.Add(Dgv_Servidores.Columns(i).DataPropertyName)
            End If
        Next
        Dgv_Servidores.AutoGenerateColumns = False
        Dgv_Servidores.DataSource = dt
        AsignarOrden()
        Dgv_Servidores.AutoResizeColumns()
    End Sub

    Private Sub Fr_Conexión_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        VariablesBase.VariablesBase.Conexion_Remota_Sql_Server = tempConexion
    End Sub

    Private Sub Tsb_AgregarFila_Click(sender As Object, e As EventArgs) Handles Tsb_AgregarFila.Click
        dt.Rows.Add()
        dt.Rows(dt.Rows.Count - 1).Item(Col_Orden.DataPropertyName) = dt.Rows.Count
    End Sub

    Private Sub Tsb_EliminarFila_Click(sender As Object, e As EventArgs) Handles Tsb_EliminarFila.Click
        If Dgv_Servidores.Rows.Count > 1 Then
            Dgv_Servidores.Rows.RemoveAt(Dgv_Servidores.SelectedCells(0).RowIndex)
        End If
    End Sub

    Private Sub Tsb_EditarConexion_Click(sender As Object, e As EventArgs) Handles Tsb_EditarConexion.Click
        fila = Dgv_Servidores.Rows(Dgv_Servidores.SelectedCells(0).RowIndex)
        Dim drResultado As DialogResult
        Using frUsuarioContrasenna As New Fr_DatosUsuarioBD
            If Not IsDBNull(fila.Cells(Col_Usuario.Name).Value) Then
                frUsuarioContrasenna.Usuario = fila.Cells(Col_Usuario.Name).Value
            Else
                frUsuarioContrasenna.Usuario = ""
            End If
            If Not IsDBNull(fila.Cells(Col_Contrasena.Name).Value) Then
                frUsuarioContrasenna.Contrasenna = fila.Cells(Col_Contrasena.Name).Value
            Else
                frUsuarioContrasenna.Contrasenna = ""
            End If
            drResultado = frUsuarioContrasenna.ShowDialog()
            If drResultado = DialogResult.OK Then
                fila.Cells(Col_Usuario.Name).Value = frUsuarioContrasenna.Usuario
                fila.Cells(Col_Contrasena.Name).Value = frUsuarioContrasenna.Contrasenna
            End If
        End Using
    End Sub

    Private Sub Tsb_SubirFila_Click(sender As Object, e As EventArgs) Handles Tsb_SubirFila.Click
        dt.AcceptChanges()
        Dim columnaActual As Integer = Dgv_Servidores.SelectedCells(0).ColumnIndex
        Dim filaActual As Integer = Dgv_Servidores.SelectedCells(0).RowIndex
        If filaActual > 0 Then
            Dim nuevaPosicion As Integer = filaActual - 1
            Dim dgvrFila As DataGridViewRow = Dgv_Servidores.Rows(filaActual)
            Dim drs() As DataRow = dt.Select(Col_Orden.DataPropertyName & " = " & dgvrFila.Cells(Col_Orden.Name).Value)
            If drs.Length > 0 Then
                Dim filaBorrar As DataRow = drs(0)
                Dim nuevaFila As DataRow = dt.NewRow
                nuevaFila.ItemArray = filaBorrar.ItemArray
                dt.Rows.Remove(filaBorrar)
                dt.Rows.InsertAt(nuevaFila, nuevaPosicion)
                Dgv_Servidores.ClearSelection()
                Dgv_Servidores.CurrentCell = Dgv_Servidores(columnaActual, nuevaPosicion)
                AsignarOrden()
                dt.AcceptChanges()
            End If
        End If
    End Sub

    Private Sub Tsb_BajarFila_Click(sender As Object, e As EventArgs) Handles Tsb_BajarFila.Click
        dt.AcceptChanges()
        Dim columnaActual As Integer = Dgv_Servidores.SelectedCells(0).ColumnIndex
        Dim filaActual As Integer = Dgv_Servidores.SelectedCells(0).RowIndex
        If filaActual < dt.Rows.Count - 1 Then
            Dim nuevaPosicion As Integer = filaActual + 1
            Dim dgvrFila As DataGridViewRow = Dgv_Servidores.Rows(filaActual)
            Dim drs() As DataRow = dt.Select(Col_Orden.DataPropertyName & " = " & dgvrFila.Cells(Col_Orden.Name).Value)
            If drs.Length > 0 Then
                Dim filaBorrar As DataRow = drs(0)
                Dim nuevaFila As DataRow = dt.NewRow
                nuevaFila.ItemArray = filaBorrar.ItemArray
                dt.Rows.Remove(filaBorrar)
                dt.Rows.InsertAt(nuevaFila, nuevaPosicion)
                Dgv_Servidores.ClearSelection()
                Dgv_Servidores.CurrentCell = Dgv_Servidores(columnaActual, nuevaPosicion)
                AsignarOrden()
                dt.AcceptChanges()
            End If
        End If
    End Sub

    Private Sub Bt_ProbarSeleccionada_Click(sender As Object, e As EventArgs) Handles Bt_ProbarSeleccionada.Click
        Dim errorText As String = ""
        Dim hasErrors As Boolean = False
        fila = Dgv_Servidores.Rows(Dgv_Servidores.SelectedCells(0).RowIndex)
        fila.ErrorText = ""
        errorText = ProbarConexion(fila)
        If errorText.Length > 0 Then
            fila.ErrorText = errorText
        Else
            MessageBox.Show("Se validó la conexión.", "Probar conexiones", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub Bt_Probar_Click(sender As Object, e As EventArgs) Handles Bt_ProbarTodas.Click
        Dim dr As DialogResult
        dr = MessageBox.Show("Se realizarán pruebas de conexión con todas las direcciones registradas. ¿Desea continuar?", "Probar todas las conexiones", MessageBoxButtons.YesNo)
        If dr = Windows.Forms.DialogResult.Yes Then
            Dim errorText As String = ""
            Dim hasErrors As Boolean = False
            For i As Integer = 0 To Dgv_Servidores.Rows.Count - If(Dgv_Servidores.AllowUserToAddRows, 2, 1)
                fila = Dgv_Servidores.Rows(i)
                fila.ErrorText = ""
                errorText = ProbarConexion(fila)
                If errorText.Length > 0 Then
                    fila.ErrorText = errorText
                    hasErrors = True
                End If
            Next
            If Not hasErrors Then
                MessageBox.Show("Se validaron todas las conexiones.", "Probar conexiones", MessageBoxButtons.OK)
            End If
        End If
    End Sub

    Private Sub Bt_Guardar_Click(sender As Object, e As EventArgs) Handles Bt_Guardar.Click
        Conexion.GuardarTablaConfServidor()
        Me.Close()
    End Sub

    Private Sub Bt_Cancelar_Click(sender As Object, e As EventArgs) Handles Bt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub AsignarOrden()
        For j As Integer = 0 To Dgv_Servidores.Rows.Count - 1
            Dgv_Servidores.Rows(j).Cells(Col_Orden.Name).Value = j + 1
        Next
    End Sub

    Private Function ProbarConexion(fila As DataGridViewRow) As String
        Dim conn As SqlConnection
        Dim servidor As String
        Dim baseDatos As String
        Dim usuario As String
        Dim contrasenna As String
        If Not IsDBNull(fila.Cells(Col_Servidor.Name).Value) Then
            servidor = fila.Cells(Col_Servidor.Name).Value
        Else
            servidor = ""
        End If
        If Not IsDBNull(fila.Cells(Col_BaseDatos.Name).Value) Then
            baseDatos = fila.Cells(Col_BaseDatos.Name).Value
        Else
            baseDatos = ""
        End If
        If Not IsDBNull(fila.Cells(Col_Usuario.Name).Value) Then
            usuario = fila.Cells(Col_Usuario.Name).Value
        Else
            usuario = ""
        End If
        If Not IsDBNull(fila.Cells(Col_Contrasena.Name).Value) Then
            contrasenna = fila.Cells(Col_Contrasena.Name).Value
        Else
            contrasenna = ""
        End If
        Establecer_Parametros(servidor, usuario, contrasenna, baseDatos, 5)
        conn = VariablesBase.VariablesBase.Conexion_Remota_Sql_Server
        Try
            conn.Open()
            conn.Close()
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

End Class