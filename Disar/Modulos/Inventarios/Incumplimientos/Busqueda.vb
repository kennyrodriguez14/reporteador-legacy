Imports Disar.data
Public Class Busqueda
    Dim Conexion As New clsIncumplimientos
    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        Try
            grd_productos.DataSource = Conexion.CargarProductos(txtBusqueda.Text.ToUpper)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grd_productos_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grd_productos.MouseDoubleClick
        Ingreso.txtCodigo.Text = grd_productos.CurrentRow.Cells(0).Value
        Me.Close()
    End Sub
End Class