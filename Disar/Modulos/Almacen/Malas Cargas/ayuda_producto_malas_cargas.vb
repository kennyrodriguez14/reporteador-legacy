Imports Disar.data

Public Class ayuda_producto_malas_cargas
    Dim conexion As New clsayudaProductos
    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        grdProducto.DataSource = conexion.helper(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub ayuda_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdProducto.DataSource = conexion.helper(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmProductosAveriados.new_linea(grdProducto.CurrentRow.Cells(0).Value, grdProducto.CurrentRow.Cells(1).Value, grdProducto.CurrentRow.Cells(2).Value)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class