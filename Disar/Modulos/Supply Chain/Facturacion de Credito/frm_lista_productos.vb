Imports Disar.data

Public Class frm_lista_productos
    Dim conexion As New clsayudaProductos_agro
    Private Sub frm_lista_productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBusqueda.Text = ""
        grdProducto.DataSource = conexion.helper_precio(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        grdProducto.DataSource = conexion.helper_precio(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub grdProducto_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdProducto.CellDoubleClick
        frm_facturas_credito.new_linea(0, grdProducto.CurrentRow.Cells(0).Value, grdProducto.CurrentRow.Cells(1).Value, grdProducto.CurrentRow.Cells(2).Value, grdProducto.CurrentRow.Cells(3).Value, grdProducto.CurrentRow.Cells(4).Value)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class