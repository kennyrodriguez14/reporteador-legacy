Imports Disar.data

Public Class frm_ayuda_productos_malas_cargas
    Public Codigo As String
    Public Descripcion As String
    Dim conexion As New clsMalasCargas
    Public Empresa As String

    Private Sub frm_ayuda_productos_malas_cargas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBusqueda.Text = ""
        If Empresa = "SAN RAFAEL" Then
            grdProducto.DataSource = conexion.ayuda_productos(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
        ElseIf Empresa = "DIMOSA" Then
            grdProducto.DataSource = conexion.ayuda_productosDimosa(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
        End If

    End Sub

    Private Sub grdProducto_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProducto.CellDoubleClick
        Codigo = grdProducto.CurrentRow.Cells(0).Value
        Descripcion = grdProducto.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        If Empresa = "SAN RAFAEL" Then
            grdProducto.DataSource = conexion.ayuda_productos(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
        ElseIf Empresa = "DIMOSA" Then
            grdProducto.DataSource = conexion.ayuda_productosDimosa(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
        End If
    End Sub
End Class