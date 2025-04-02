Imports Disar.data
Public Class ayuda_clientes_agro
    Dim conexion As New clsayudaClientes
    Private Sub ayuda_clientes_agro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBusqueda.Text = ""
        grdClientes.DataSource = conexion.helper_agro(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        grdClientes.DataSource = conexion.helper_agro(Val(txtBusqueda.Text), txtBusqueda.Text.ToUpper)
    End Sub

    Private Sub grdClientes_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdClientes.CellMouseDoubleClick
        frmProductosAveriados_agro.codigo.Text = grdClientes.CurrentRow.Cells(0).Value
        frmProductosAveriados_agro.nombre.Text = grdClientes.CurrentRow.Cells(1).Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class