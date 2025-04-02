Imports Disar.data

Public Class ayuda_productos_agro
    Dim conexion As New clsayudaProductos
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmProductosAveriados_agro.new_linea(grdProducto.CurrentRow.Cells(0).Value, grdProducto.CurrentRow.Cells(1).Value, grdProducto.CurrentRow.Cells(2).Value)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ayuda_productos_agro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBusqueda.Text = ""
        grdProducto.DataSource = conexion.helper_agro(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        grdProducto.DataSource = conexion.helper(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub
End Class